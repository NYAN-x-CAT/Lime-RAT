Public Class PWD
    Public F As Form1
    Public C As C
    Private m_SortingColumn As ColumnHeader

    Private Sub PWD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "PWD"
    End Sub

    ' Sort using the clicked column.
    Private Sub lvwBooks_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = ListView1.Columns(e.Column)

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
        ListView1.ListViewItemSorter = New Form1.ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If (Me.ListView1.SelectedItems.Item(0).SubItems.Item(2).Text.Length > 0) Then
                Clipboard.SetText(Me.ListView1.SelectedItems.Item(0).SubItems.Item(2).Text + " " + Me.ListView1.SelectedItems.Item(0).SubItems.Item(3).Text + " " + Me.ListView1.SelectedItems.Item(0).SubItems.Item(4).Text)
            End If
        Catch exception1 As Exception

        End Try
    End Sub
End Class