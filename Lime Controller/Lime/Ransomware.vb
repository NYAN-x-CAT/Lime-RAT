Public Class Ransomware
    Public OK As Boolean
    Public o As New OpenFileDialog

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            With o
                .Filter = "Image File(*.JPEG;*.JPG)|*.JPEG;*.JPG;|All files (*.*)|*.*"
                .Title = "Select a Image File"
                .InitialDirectory = Application.StartupPath
            End With
            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox1.Text = o.FileName
                PictureBox1.ImageLocation = TextBox1.Text
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Nothing)
        End Try


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> Nothing AndAlso PictureBox1.ImageLocation <> Nothing AndAlso RichTextBox1.Text <> Nothing Then
            OK = True
            Me.Close()
        Else
            MsgBox("Please select wallpaper", MsgBoxStyle.Information)
            Return
        End If
    End Sub

End Class