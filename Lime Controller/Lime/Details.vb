Public Class Details
    Public F As Form1
    Public C As C
    Private m_SortingColumn As ColumnHeader

    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = C.L.Text + "_" + C.ip
    End Sub

    Private Sub TabPage2_click(sender As Object, e As EventArgs) Handles TabPage2.Enter
        C.SendText("Processes")
    End Sub


    ' Sort using the clicked column.
    Private Sub lvwBooks_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles ListView2.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = ListView2.Columns(e.Column)

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
        ListView2.ListViewItemSorter = New Form1.ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView2.Sort()
    End Sub
End Class