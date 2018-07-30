Imports System.Drawing

Public Class Remote_Desktop
    Public M As Main
    Public U As USER
    Public Sz As Size
    Public C2 As Integer = 10
    Public SPL = S_Settings.SPL



    Private Sub Cap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To 6
            Combo_size.Items.Add(QZ(i))
        Next

        P1.Image = New Bitmap(Sz.Width, Sz.Height)
        Combo_size.SelectedIndex = 2
        Combo_quality.SelectedIndex = 0
        Timer1.Interval = 1000
        Timer1.Start()
        MetroButton1_Click(MetroButton1, e)
    End Sub

    Public Sub PktToImage(ByVal BY As Byte())
        Try
            If MetroButton1.Text = "Stop" Then
                M.S.Send(U, "@" & SPL & Combo_size.SelectedIndex & SPL & C2 & SPL & Combo_quality.SelectedItem)
            End If
            Dim B As Array = fx(BY, "|'IMG'|")
            Dim Q As New IO.MemoryStream(CType(B(1), Byte()))
            Dim L As Bitmap = Image.FromStream(Q)
            Dim QQ As String() = Split(BS(B(0)), ",")
            MetroLabel3.Text = "Remote Desktop  " & "Size: " & siz(BY.LongLength) & " ,Changes: " & QQ.Length - 2
            Dim K As Bitmap = P1.Image.GetThumbnailImage(CType(Split(QQ(0), ".")(0), Integer), CType(Split(QQ(0), ".")(1), Integer), Nothing, Nothing)
            Dim G As Graphics = Graphics.FromImage(K)
            Dim tp As Integer = 0
            For i As Integer = 1 To QQ.Length - 2
                Dim P As New Point(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1))
                Dim SZ As New Size(L.Width, Split(QQ(i), ".")(2))
                G.DrawImage(L.Clone(New Rectangle(0, tp, L.Width, CType(Split(QQ(i), ".")(2), Integer)), L.PixelFormat), New Point(CType(Split(QQ(i), ".")(0), Integer), CType(Split(QQ(i), ".")(1), Integer)))

                tp += SZ.Height
            Next
            G.Dispose()
            P1.Image = K
        Catch ex As Exception
        End Try
    End Sub
    Function QZ(ByVal q As Integer) As Size '  Lower Size of image
        Try
            Dim zs As New Size(Sz)
            Select Case q
                Case 0
                    Return Sz
                Case 1
                    zs.Width = zs.Width / 1.1
                    zs.Height = zs.Height / 1.1
                Case 2
                    zs.Width = zs.Width / 1.3
                    zs.Height = zs.Height / 1.3
                Case 3
                    zs.Width = zs.Width / 1.5
                    zs.Height = zs.Height / 1.5
                Case 4
                    zs.Width = zs.Width / 1.9
                    zs.Height = zs.Height / 1.9
                Case 5
                    zs.Width = zs.Width / 2
                    zs.Height = zs.Height / 2
                Case 6
                    zs.Width = zs.Width / 2.1
                    zs.Height = zs.Height / 2.1
            End Select
            zs.Width = Mid(zs.Width.ToString, 1, zs.Width.ToString.Length - 1) & 0
            zs.Height = Mid(zs.Height.ToString, 1, zs.Height.ToString.Length - 1) & 0
            Return zs
        Catch ex As Exception
        End Try
    End Function
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Try
            If MetroButton1.Text = "Start" Then
                M.S.Send(U, "@" & SPL & Combo_size.SelectedIndex & SPL & C2 & SPL & Combo_quality.SelectedIndex)
                MetroButton1.Text = "Stop"
                MetroButton1.Highlight = True
                Combo_size.Enabled = False
                Combo_quality.Enabled = False
            Else
                MetroButton1.Text = "Start"
                MetroButton1.Highlight = False
                Combo_size.Enabled = True
                Combo_quality.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Try
            Dim s As New SaveFileDialog
            s.Filter = "Pic|*.png"
            If s.ShowDialog = Windows.Forms.DialogResult.OK Then
                P1.Image.Save(s.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        M.S.Send(U, "Close")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If U.IsConnected = False Then
            Me.Close()
        End If
    End Sub

End Class