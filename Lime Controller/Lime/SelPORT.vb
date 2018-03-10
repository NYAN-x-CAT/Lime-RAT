Public Class SelPORT
    Public Myport As Integer

    Private Sub SelPORT_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = "Lime Controller || " & Environment.UserName
    End Sub

    Private Sub ChButton2_Click(sender As Object, e As EventArgs) Handles ChButton2.Click
        End
    End Sub

    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click
        Myport = ChTextbox1.Text
        Me.Close()
    End Sub
End Class