Public Class Details
    Public F As Form1
    Public C As C

    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = C.L.Text + "_" + C.ip
    End Sub
End Class