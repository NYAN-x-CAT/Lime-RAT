Public Class Form2
    Private Sub Port_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Label4.Text = Environment.UserName
            PN.Text = My.Settings.port
            update_label.Visible = False
        Catch ex As Exception
        End Try


        Try
            Dim URL As String = "https://pastebin.com/raw/DDTVwwbu"
            Dim ww As New Net.WebClient
            Dim Getit As String = ww.DownloadString(URL)
            If Getit.Contains("Yes") Then
                update_label.Visible = True
                update_label.ForeColor = Color.Yellow
                update_label.Font = New Font(update_label.Font, FontStyle.Bold)
                update_label.Text = "New update is available"
            ElseIf Getit.Contains("No") Then
                update_label.Visible = True
                update_label.Text = "No update available"
            Else
                update_label.Visible = False
            End If

        Catch ex As Exception
            update_label.Visible = False
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim iCount As Integer
            For iCount = 95 To 0 Step -10
                Me.Opacity = iCount / 100
                Me.Refresh()
                Threading.Thread.Sleep(50)
            Next

            Me.Hide()
            Form1.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim iCount As Integer
        For iCount = 95 To 0 Step -10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next

        End
    End Sub

End Class