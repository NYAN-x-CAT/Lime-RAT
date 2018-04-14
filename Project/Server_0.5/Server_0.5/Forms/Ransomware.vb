Public Class Ransomware
    Public F As Form1
    Public OK As Boolean
    Public ofd As New OpenFileDialog

    Private Sub Ransomware_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PictureBox1.ImageLocation = Application.StartupPath + "\Wallpaper\Lime's wallpaper.jpg"
        Catch ex As Exception
            PictureBox1.ImageLocation = Nothing
        End Try
    End Sub

    Private Sub ChButton2_Click(sender As Object, e As EventArgs) Handles ChButton2.Click
        OK = True
        Me.Close()
    End Sub

    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click
        Try
            With ofd
                .Filter = "Image File(*.JPEG;*.JPG)|*.JPEG;*.JPG;|All files (*.*)|*.*"
                .Title = "Select a Image File"
                .InitialDirectory = Application.StartupPath
            End With

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.ImageLocation = ofd.FileName
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
End Class