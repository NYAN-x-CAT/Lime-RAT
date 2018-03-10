Imports System.Net, System.Net.Sockets, System.IO, System.Threading

Public Class CL
    'Credit=DRHAZEM
    Public Async Sub Start(ByVal port As Integer)
        ls = New TcpListener(New IPEndPoint(IPAddress.Any, port))
        ls.Server.ReceiveTimeout = -1
        ls.Server.SendTimeout = -1
        ls.Start()
        Do While True
            Dim C As New C(Await ls.AcceptSocketAsync, Me)
            C.S.ReceiveBufferSize = 8000000
            C.S.SendBufferSize = 8000000
            C.S.ReceiveTimeout = -1
            C.S.SendTimeout = -1
            If Not Online.Contains(C.ip) Then Online.Add(C.ip)

        Loop
    End Sub

    Public ls As TcpListener
    Public Online As New List(Of String)

End Class



Public Class C
    Public Sub New(ByVal S As Socket, ByVal CL As CL)
        Me.T = New Timer(New TimerCallback(AddressOf Check), Nothing, 0, 2500)
        Me.S = S
        Me.CL = CL
        M = New MemoryStream
        Me.B = New Byte(0) {}
        S.BeginReceive(B, 0, B.Length, SocketFlags.None, New AsyncCallback(AddressOf rc), Nothing)
    End Sub

    Public Async Sub rc(ar As IAsyncResult)
        Try
            Thread.Sleep(10)
            Dim I As Integer = Me.S.EndReceive(ar, ER)
            If ER <> SocketError.Success Then GoTo E

            Select Case B.Length
                Case 1
                    If B(0) = 0 Then
                        B = New Byte(Integer.Parse(FN.GS(M.ToArray))) {}
                        M.Dispose() : M = New MemoryStream
                    Else
                        M.WriteByte(B(0))
                    End If
                Case Is > 1
                    Await M.WriteAsync(B, 0, I)
                    Form1.Dt(Me, M.ToArray)
                    M.Dispose() : M = New MemoryStream
                    B = New Byte(0) {}
            End Select

            Me.S.BeginReceive(B, 0, B.Length, SocketFlags.None, New AsyncCallback(AddressOf rc), Nothing)
            Return
        Catch ex As Exception : End Try
E:
        bool = False


    End Sub

    Public Async Sub Close()
        If Not Me.bool Then
            Me.bool = True

            Try
                If CL.Online.Contains(ip) Then CL.Online.Remove(ip)
            Catch ex As Exception

            End Try

            Try
                Me.T.Dispose()
            Catch ex As Exception

            End Try


            Try
                Await M.FlushAsync()
            Catch ex As Exception

            End Try
            Try
                M.Dispose()
            Catch ex As Exception

            End Try
            Try
                S.Shutdown(SocketShutdown.Both)
            Catch ex As Exception

            End Try

            Try
                S.Close()
            Catch ex As Exception

            End Try


        End If


    End Sub

    Public Sub Check()
        Try
            SyncLock Form1.F.L1.Items

                If Not bool Then


                    For Each L As ListViewItem In Form1.F.L1.Items
                        If L.SubItems(1).Text = Me.ip Then
                            Form1.Messages("{" + L.SubItems(0).Text + "}" + " " + "{" + L.SubItems(2).Text + "}", "Disconnected")
                            L.Remove()
                            Exit For
                        End If
                    Next
                    Close()
                End If
            End SyncLock
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SendText(ByVal MSG As String)
        Send(FN.GB(MSG))
    End Sub

    Public Async Sub Send(ByVal b() As Byte)
        Try

            NT = New NetworkStream(Me.S)
            Dim L() As Byte = FN.GB(CInt(b.Length.ToString) & ChrW(0))

            Dim MS As New MemoryStream
            Await MS.WriteAsync(L, 0, L.Length)
            Await MS.WriteAsync(b, 0, b.Length)

            NT.Write(MS.ToArray, 0, MS.Length)
            MS.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub






    Public Function ip() As String
        Return S.RemoteEndPoint.ToString.Split(":")(0)
    End Function

    Public S As Socket
    Public M As MemoryStream
    Public ER As SocketError
    Public CL As CL
    Public B() As Byte
    Public L As ListViewItem
    Public bool As Boolean = True
    Public T As Timer
    Public NT As NetworkStream
End Class
