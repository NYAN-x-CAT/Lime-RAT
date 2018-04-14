Public Class Info
    Public F As Form1
    Public U As USER

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If (Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text.Length > 0) Then
                Clipboard.SetText(Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text)
            End If
        Catch exception1 As Exception

        End Try
    End Sub

    Private Sub Info_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer2.Interval = 1000
        Timer2.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If U.IsConnected = False Then
            Me.Close()
        End If
    End Sub

    Private Sub Info_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        F.S.Send(U, "Close")
    End Sub
End Class