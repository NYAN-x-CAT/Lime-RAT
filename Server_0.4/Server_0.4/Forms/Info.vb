Public Class Info
    Public F
    Public U

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If (Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text.Length > 0) Then
                Clipboard.SetText(Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text)
            End If
        Catch exception1 As Exception

        End Try
    End Sub
End Class