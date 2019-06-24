Imports System.IO
Imports System.Net.Sockets


Public Class S_Client

    Public IsConnected As Boolean = True
    Public L As ListViewItem = Nothing
    Public C As Socket = Nothing
    Public IP As String = Nothing
    Public Buffer(1024 * 1000) As Byte
    Public MS As MemoryStream = Nothing
    Public Shared Event Read(ByVal C As S_Client, ByVal b() As Byte)

    Sub New(ByVal CL As Socket)
        Me.C = CL
        Me.Buffer = New Byte(1024 * 1000) {}
        C.ReceiveBufferSize = 1024 * 1000
        C.SendBufferSize = 1024 * 1000
        Me.MS = New MemoryStream
        Me.IP = CL.RemoteEndPoint.ToString
        C.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), Nothing)
    End Sub

    Async Sub BeginReceive(ByVal ar As IAsyncResult)
        If IsConnected = False OrElse C.Connected = False Then
            isDisconnected()
            Exit Sub
        End If
        Try
            Dim Received As Integer = C.EndReceive(ar)
            If Received > 0 Then
                Await MS.WriteAsync(Buffer, 0, Received)
re:
                If BS(MS.ToArray).Contains(S_Settings.EOF) Then
                    Dim A As Array = Await fx(MS.ToArray, S_Settings.EOF)
                    RaiseEvent Read(Me, A(0))
                    ' Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf BeginRead), A(0))
                    MS.Dispose()
                    MS = New MemoryStream

                    If A.Length = 2 Then
                        MS.Write(A(1), 0, A(1).length)
                        GoTo re
                    End If

                End If
            Else
                isDisconnected()
                Exit Sub
            End If
            C.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf BeginReceive), Nothing)
        Catch ex As Exception
            isDisconnected()
            Exit Sub
        End Try
    End Sub

    'Sub BeginRead(ByVal A As Array)
    '    S_Messages.Read(Me, A)
    'End Sub

    Delegate Sub _isDisconnected()
    Sub isDisconnected()

        IsConnected = False

        Try
            If S_Messages.M.InvokeRequired Then
                S_Messages.M.Invoke(New _isDisconnected(AddressOf isDisconnected))
                Exit Sub
            Else
                '  L.Remove()
                If L IsNot Nothing Then
                    SyncLock S_Settings.LVlocker
                        L.SubItems(S_Messages.M.PING.Index).Text = "Offline"
                        L.ForeColor = Color.Red
                        S_Messages.Messages("{" + IP + "}", "Disconnected")
                        S_Settings.Online.Remove(Me)
                    End SyncLock
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            C.Close()
            C.Dispose()
        Catch ex As Exception
        End Try

        Try
            MS.Dispose()
        Catch ex As Exception
        End Try

    End Sub

    Async Sub BeginSend(ByVal S As String)
        If IsConnected Then
            Dim M As New MemoryStream
            Dim B As Byte() = SB(S_Encryption.AES_Encrypt(S))
            Await M.WriteAsync(B, 0, B.Length)
            Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

            Try
                C.Poll(-1, SelectMode.SelectWrite)
                C.BeginSend(M.ToArray, 0, M.Length, SocketFlags.None, New AsyncCallback(AddressOf EndSend), Nothing)
            Catch ex As Exception
                isDisconnected()
            End Try

            Try
                Await M.FlushAsync
                M.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub Send(ByVal b As Byte())
        If IsConnected Then
            Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf _BeginSend), b)
        End If
    End Sub

    Sub _BeginSend(ByVal b As Byte())
        Try
            C.Poll(-1, SelectMode.SelectWrite)
            C.BeginSend(b.ToArray, 0, b.Length, SocketFlags.None, New AsyncCallback(AddressOf EndSend), Nothing)
        Catch ex As Exception
            isDisconnected()
        End Try
    End Sub

    Sub EndSend(ByVal ar As IAsyncResult)
        Try
            C.EndSend(ar)
            L.BackColor = Nothing
        Catch ex As Exception
        End Try
    End Sub

End Class
