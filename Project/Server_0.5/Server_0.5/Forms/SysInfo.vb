Public Class SysInfo
    Public F As Form1
    Public U As USER
    Private m_SortingColumn As ColumnHeader


    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If (Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text.Length > 0) Then
                Clipboard.SetText(Me.ListView1.SelectedItems.Item(0).SubItems.Item(1).Text)
            End If
        Catch exception1 As Exception

        End Try
    End Sub

    Private Sub Info_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer2.Interval = 1000
        Timer2.Start()

        Dim G1 As New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run\", HorizontalAlignment.Left)
        Dim G7 As New ListViewGroup("Startup Folder", HorizontalAlignment.Left)

        Try
            With L2
                .Clear()
                .View = View.Details
                .Columns.Add("Process name", 250)
                .Columns.Add("Process ID", 80)
                .Columns.Add("Process path", 160)
                .GridLines = True
            End With
        Catch ex As Exception
        End Try

        Try
            With L3
                .Clear()
                .View = View.Details
                .HeaderStyle = ColumnHeaderStyle.None
                .Columns.Add("")
                .Columns.Add("")
                .GridLines = True
                .Groups.Add(G1)
                .Groups.Add(G7)
                .ShowGroups = True
                .FullRowSelect = True
            End With
        Catch ex As Exception
        End Try

        With L3.Items
            .Add(New ListViewItem("", G1)).SubItems.Add("")
            .Add(New ListViewItem("", G7)).SubItems.Add("")

        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If U.IsConnected = False Then
            Me.Close()
        End If
    End Sub

    Private Sub Info_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        F.S.Send(U, "Close")
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        F.S.Send(U, "PROC")
    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        F.S.Send(U, "STUP")
    End Sub

    Private Sub RefreshToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem2.Click
        F.S.Send(U, "Sysinfo")
    End Sub

    ' Sort using the clicked column.
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
        L2.ListViewItemSorter = New Form1.ListViewComparer(e.Column, sort_order)

        ' Sort.
        L2.Sort()
    End Sub


End Class