Namespace Lime

    Public Class C_CriticalProcess
        'https://www.codeproject.com/Articles/43405/Protecting-Your-Process-with-RtlSetProcessIsCriti
        <Runtime.InteropServices.DllImport("NTdll.dll", EntryPoint:="RtlSetProcessIsCritical", SetLastError:=True)>
        Public Shared Sub SetCurrentProcessIsCritical(
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal isCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByRef refWasCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal needSystemCriticalBreaks As Boolean)
        End Sub

        Public Shared Sub CriticalProcess_Enable()
            Try
                Dim refWasCritical As Boolean
                System.Diagnostics.Process.EnterDebugMode()
                SetCurrentProcessIsCritical(True, refWasCritical, False)
            Catch ex As Exception
            End Try
        End Sub

        Public Shared Sub CriticalProcesses_Disable()
            Try
                Dim refWasCritical As Boolean
                SetCurrentProcessIsCritical(False, refWasCritical, False)
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
