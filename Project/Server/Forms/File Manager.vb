Imports System.ComponentModel

Public Class File_Manager

    Public M As Main
    Public U
    Private m_SortingColumn As ColumnHeader



#Region "Theme"
    Private Sub L1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles L1.DrawColumnHeader
        Dim BL As New SolidBrush(Color.FromArgb(17, 17, 17))
        Dim LM As New SolidBrush(Color.FromArgb(142, 188, 0))
        e.DrawBackground()
        e.Graphics.FillRectangle(BL, e.Bounds)
        Dim headerFont As New Font("Segoe UI", 8, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, LM, e.Bounds)
    End Sub

    Private Sub L1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L1.DrawItem
        If e.Item.Selected = False Then
            e.DrawDefault = True
        End If
    End Sub

    Private Sub L1_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles L1.DrawSubItem
        If e.Item.Selected = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(142, 188, 0)), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, New Font("Segoe UI", 8, FontStyle.Regular), New Point(e.Bounds.Left + 3, e.Bounds.Top + 2), Color.FromArgb(17, 17, 17))
        Else
            e.DrawDefault = True
        End If
    End Sub

    ' Sort using the clicked column.
    Private Sub lvwBooks_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles L1.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = L1.Columns(e.Column)

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
        L1.ListViewItemSorter = New Main.ListViewComparer(e.Column, sort_order)

        ' Sort.
        L1.Sort()
    End Sub

#End Region


    Private Sub File_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        M.S.Send(U, "Drivers")

        Timer1.Interval = 1000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If U.IsConnected = False Then
            Close()
        End If
    End Sub

    Public Sub RefreshList()
        M.S.Send(U, "FM" & M.SPL & Label1.Text)
    End Sub

    Private Sub L1_DoubleClick(sender As Object, e As EventArgs) Handles L1.DoubleClick
        Try
            If L1.FocusedItem.ImageIndex = 0 Or L1.FocusedItem.ImageIndex = 1 Or L1.FocusedItem.ImageIndex = 2 Then
                If Label1.Text.Length = 0 Then
                    Label1.Text += L1.FocusedItem.Text
                Else
                    Label1.Text += L1.FocusedItem.Text & "\"
                End If
                RefreshList()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

    Private Sub File_Manager_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        M.S.Send(U, "Close")
    End Sub

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        Try
            If Label1.Text.Length < 4 Then
                Label1.Text = ""
                M.S.Send(U, "Drivers" & M.SPL)
            Else
                Label1.Text = Label1.Text.Substring(0, Label1.Text.LastIndexOf("\"))
                Label1.Text = Label1.Text.Substring(0, Label1.Text.LastIndexOf("\") + 1)
                RefreshList()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub File_Manager_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub
End Class