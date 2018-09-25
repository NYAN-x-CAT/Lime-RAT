Public Class Ransomware

    Public M As Main
    Public OK As Boolean
    Public ofd As New OpenFileDialog

    Private Sub Ransomware_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PictureBox1.ImageLocation = Application.StartupPath + "\Misc\Wallpaper\Lime's wallpaper.jpg"
        Catch ex As Exception
            PictureBox1.ImageLocation = Nothing
        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If PictureBox1.ImageLocation = Nothing Then
            MsgBox("Missing Wallpaper", MsgBoxStyle.Critical)
            Return
        End If
        OK = True
        Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            With ofd
                .Filter = "Image File(*.JPEG;*.JPG)|*.JPEG;*.JPG;|All files (*.*)|*.*"
                .Title = "Select a Image File"
                .InitialDirectory = Application.StartupPath
            End With

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.ImageLocation = ofd.FileName
            Else
                PictureBox1.ImageLocation = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class