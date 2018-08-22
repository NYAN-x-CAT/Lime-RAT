Public Class XMR

    'For more info https://coinguides.org/xmrig-beginners-guide/

    Public M As Main
    Public OK As Boolean = False
    Public K As Boolean = False
    Public ofd As New OpenFileDialog
    Public cpu
    Public url
    Public user
    Public pass

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click

        If txtCPU.Text <> "" AndAlso txtURL.Text <> "" AndAlso txtUSER.Text <> "" Then

            If chk.Checked = True Then
                cpu = "50%"
            Else
                cpu = txtCPU.Text
            End If

            If chkPass.Checked Then
                pass = "ID%"
            Else
                pass = txtPASS.Text
            End If

            url = txtURL.Text
            user = txtUSER.Text
            K = False
            OK = True
            Me.Close()
        End If

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        K = True
        OK = True
        Me.Close()
    End Sub

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chk.CheckedChanged
        If chk.Checked Then
            txtCPU.Enabled = False
        Else
            txtCPU.Enabled = True
        End If
    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked Then
            txtPASS.Enabled = False
        Else
            txtPASS.Enabled = True
        End If
    End Sub
End Class