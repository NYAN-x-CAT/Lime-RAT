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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RansomwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VvvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromDiskToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisitWebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComputerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WormSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ChTabcontrol1 = New Lime.CHTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.L1 = New System.Windows.Forms.ListView()
        Me.c_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_ip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_ransomware = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_stub = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_country = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_os = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_version = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_install = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_av = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.c_usb = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.L2 = New Lime.CHListbox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button4 = New Lime.CHButton()
        Me.Button1 = New Lime.CHButton()
        Me.ChGroupBox3 = New Lime.CHGroupBox()
        Me.SPUSB = New Lime.CHCheckbox()
        Me.ANTI_VM = New Lime.CHCheckbox()
        Me.ChGroupBox2 = New Lime.CHGroupBox()
        Me.CHKDR = New Lime.CHOnOffBox()
        Me.DRPATH = New Lime.CHCombobox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DRFOLDER = New Lime.CHTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.exename = New Lime.CHTextbox()
        Me.ChGroupBox1 = New Lime.CHGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.port = New Lime.CHTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.host = New Lime.CHTextbox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ChTabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ChGroupBox3.SuspendLayout()
        Me.ChGroupBox2.SuspendLayout()
        Me.ChGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.RansomwareToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.VvvToolStripMenuItem, Me.VisitWebsiteToolStripMenuItem, Me.ComputerToolStripMenuItem, Me.WormSettingToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(199, 226)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(195, 6)
        '
        'RansomwareToolStripMenuItem
        '
        Me.RansomwareToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EncryptToolStripMenuItem, Me.DecryptToolStripMenuItem})
        Me.RansomwareToolStripMenuItem.Name = "RansomwareToolStripMenuItem"
        Me.RansomwareToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.RansomwareToolStripMenuItem.Text = "Ransomware"
        '
        'EncryptToolStripMenuItem
        '
        Me.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem"
        Me.EncryptToolStripMenuItem.Size = New System.Drawing.Size(158, 30)
        Me.EncryptToolStripMenuItem.Text = "Encrypt"
        '
        'DecryptToolStripMenuItem
        '
        Me.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem"
        Me.DecryptToolStripMenuItem.Size = New System.Drawing.Size(158, 30)
        Me.DecryptToolStripMenuItem.Text = "Decrypt"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'VvvToolStripMenuItem
        '
        Me.VvvToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem1, Me.FromURLToolStripMenuItem1})
        Me.VvvToolStripMenuItem.Name = "VvvToolStripMenuItem"
        Me.VvvToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.VvvToolStripMenuItem.Text = "Run File"
        '
        'FromDiskToolStripMenuItem1
        '
        Me.FromDiskToolStripMenuItem1.Name = "FromDiskToolStripMenuItem1"
        Me.FromDiskToolStripMenuItem1.Size = New System.Drawing.Size(177, 30)
        Me.FromDiskToolStripMenuItem1.Text = "From Disk"
        '
        'FromURLToolStripMenuItem1
        '
        Me.FromURLToolStripMenuItem1.Name = "FromURLToolStripMenuItem1"
        Me.FromURLToolStripMenuItem1.Size = New System.Drawing.Size(177, 30)
        Me.FromURLToolStripMenuItem1.Text = "From URL"
        '
        'VisitWebsiteToolStripMenuItem
        '
        Me.VisitWebsiteToolStripMenuItem.Name = "VisitWebsiteToolStripMenuItem"
        Me.VisitWebsiteToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.VisitWebsiteToolStripMenuItem.Text = "Visit Website"
        '
        'ComputerToolStripMenuItem
        '
        Me.ComputerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoffToolStripMenuItem, Me.ToolStripMenuItem3, Me.ShutdownToolStripMenuItem})
        Me.ComputerToolStripMenuItem.Name = "ComputerToolStripMenuItem"
        Me.ComputerToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.ComputerToolStripMenuItem.Text = "User PC"
        '
        'LogoffToolStripMenuItem
        '
        Me.LogoffToolStripMenuItem.Name = "LogoffToolStripMenuItem"
        Me.LogoffToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.LogoffToolStripMenuItem.Text = "Logoff"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(177, 30)
        Me.ToolStripMenuItem3.Text = "Restart"
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.ShutdownToolStripMenuItem.Text = "Shutdown"
        '
        'WormSettingToolStripMenuItem
        '
        Me.WormSettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem, Me.RestartToolStripMenuItem1, Me.UninstallToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.WormSettingToolStripMenuItem.Name = "WormSettingToolStripMenuItem"
        Me.WormSettingToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.WormSettingToolStripMenuItem.Text = "Controller Setting"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem, Me.FromURLToolStripMenuItem})
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.ShowShortcutKeys = False
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'FromDiskToolStripMenuItem
        '
        Me.FromDiskToolStripMenuItem.Name = "FromDiskToolStripMenuItem"
        Me.FromDiskToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.FromDiskToolStripMenuItem.Text = "From Disk"
        '
        'FromURLToolStripMenuItem
        '
        Me.FromURLToolStripMenuItem.Name = "FromURLToolStripMenuItem"
        Me.FromURLToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.FromURLToolStripMenuItem.Text = "From URL"
        '
        'RestartToolStripMenuItem1
        '
        Me.RestartToolStripMenuItem1.Name = "RestartToolStripMenuItem1"
        Me.RestartToolStripMenuItem1.Size = New System.Drawing.Size(177, 30)
        Me.RestartToolStripMenuItem1.Text = "Reconnect"
        '
        'UninstallToolStripMenuItem1
        '
        Me.UninstallToolStripMenuItem1.Name = "UninstallToolStripMenuItem1"
        Me.UninstallToolStripMenuItem1.Size = New System.Drawing.Size(177, 30)
        Me.UninstallToolStripMenuItem1.Text = "Uninstall"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(195, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(180, 25)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Black
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 633)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1461, 30)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ChTabcontrol1
        '
        Me.ChTabcontrol1.Controls.Add(Me.TabPage1)
        Me.ChTabcontrol1.Controls.Add(Me.TabPage2)
        Me.ChTabcontrol1.Controls.Add(Me.TabPage3)
        Me.ChTabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChTabcontrol1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ChTabcontrol1.GlowColor = System.Drawing.Color.Empty
        Me.ChTabcontrol1.ItemSize = New System.Drawing.Size(80, 30)
        Me.ChTabcontrol1.Location = New System.Drawing.Point(0, 0)
        Me.ChTabcontrol1.Name = "ChTabcontrol1"
        Me.ChTabcontrol1.SelectedIndex = 0
        Me.ChTabcontrol1.Size = New System.Drawing.Size(1461, 633)
        Me.ChTabcontrol1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.L1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1453, 595)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bots"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1145, 392)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(287, 182)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.Black
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.c_id, Me.c_ip, Me.c_user, Me.c_ransomware, Me.c_stub, Me.c_country, Me.c_os, Me.c_version, Me.c_install, Me.c_av, Me.c_usb})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.Lime
        Me.L1.FullRowSelect = True
        Me.L1.Location = New System.Drawing.Point(3, 3)
        Me.L1.Name = "L1"
        Me.L1.OwnerDraw = True
        Me.L1.Scrollable = False
        Me.L1.Size = New System.Drawing.Size(1447, 589)
        Me.L1.TabIndex = 2
        Me.L1.UseCompatibleStateImageBehavior = False
        Me.L1.View = System.Windows.Forms.View.Details
        '
        'c_id
        '
        Me.c_id.Text = "Client ID"
        '
        'c_ip
        '
        Me.c_ip.Text = " IP Address"
        '
        'c_user
        '
        Me.c_user.Text = " User Name "
        '
        'c_ransomware
        '
        Me.c_ransomware.Text = " Ransomware "
        '
        'c_stub
        '
        Me.c_stub.Text = " Stub Name "
        '
        'c_country
        '
        Me.c_country.Text = " Country "
        '
        'c_os
        '
        Me.c_os.Text = " Operating System "
        '
        'c_version
        '
        Me.c_version.Text = " Version "
        '
        'c_install
        '
        Me.c_install.Text = " Install Date "
        '
        'c_av
        '
        Me.c_av.Text = " Anti Virus "
        '
        'c_usb
        '
        Me.c_usb.Text = " USB Spread "
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.Controls.Add(Me.L2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1453, 595)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Logs"
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.Black
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.L2.ForeColor = System.Drawing.Color.Lime
        Me.L2.FormattingEnabled = True
        Me.L2.IntegralHeight = False
        Me.L2.ItemHeight = 21
        Me.L2.ItemImage = Nothing
        Me.L2.Location = New System.Drawing.Point(3, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(1447, 589)
        Me.L2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.ChGroupBox3)
        Me.TabPage3.Controls.Add(Me.ChGroupBox2)
        Me.TabPage3.Controls.Add(Me.ChGroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1453, 595)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Builder"
        '
        'Button4
        '
        Me.Button4.Customization = "AGQA/wD/AP8AgAD/"
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Button4.Image = Nothing
        Me.Button4.Location = New System.Drawing.Point(982, 232)
        Me.Button4.Name = "Button4"
        Me.Button4.NoRounding = False
        Me.Button4.Size = New System.Drawing.Size(226, 44)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "H E L P"
        Me.Button4.Transparent = False
        '
        'Button1
        '
        Me.Button1.Customization = "AGQA/wD/AP8AgAD/"
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Button1.Image = Nothing
        Me.Button1.Location = New System.Drawing.Point(657, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.NoRounding = False
        Me.Button1.Size = New System.Drawing.Size(226, 44)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "B U I L D"
        Me.Button1.Transparent = False
        '
        'ChGroupBox3
        '
        Me.ChGroupBox3.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox3.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox3.Controls.Add(Me.SPUSB)
        Me.ChGroupBox3.Controls.Add(Me.ANTI_VM)
        Me.ChGroupBox3.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox3.Image = Nothing
        Me.ChGroupBox3.Location = New System.Drawing.Point(657, 25)
        Me.ChGroupBox3.Movable = True
        Me.ChGroupBox3.Name = "ChGroupBox3"
        Me.ChGroupBox3.NoRounding = False
        Me.ChGroupBox3.Sizable = True
        Me.ChGroupBox3.Size = New System.Drawing.Size(551, 144)
        Me.ChGroupBox3.SmartBounds = True
        Me.ChGroupBox3.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox3.TabIndex = 6
        Me.ChGroupBox3.Text = "MISC"
        Me.ChGroupBox3.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox3.Transparent = False
        '
        'SPUSB
        '
        Me.SPUSB.BackColor = System.Drawing.Color.Transparent
        Me.SPUSB.Checked = False
        Me.SPUSB.ForeColor = System.Drawing.Color.Black
        Me.SPUSB.Location = New System.Drawing.Point(33, 101)
        Me.SPUSB.Name = "SPUSB"
        Me.SPUSB.Size = New System.Drawing.Size(351, 14)
        Me.SPUSB.TabIndex = 1
        Me.SPUSB.Text = "USB Spread"
        '
        'ANTI_VM
        '
        Me.ANTI_VM.BackColor = System.Drawing.Color.Transparent
        Me.ANTI_VM.Checked = False
        Me.ANTI_VM.ForeColor = System.Drawing.Color.Black
        Me.ANTI_VM.Location = New System.Drawing.Point(33, 54)
        Me.ANTI_VM.Name = "ANTI_VM"
        Me.ANTI_VM.Size = New System.Drawing.Size(351, 14)
        Me.ANTI_VM.TabIndex = 0
        Me.ANTI_VM.Text = "Don't Run On Virtual Environment"
        '
        'ChGroupBox2
        '
        Me.ChGroupBox2.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox2.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox2.Controls.Add(Me.CHKDR)
        Me.ChGroupBox2.Controls.Add(Me.DRPATH)
        Me.ChGroupBox2.Controls.Add(Me.Label5)
        Me.ChGroupBox2.Controls.Add(Me.Label3)
        Me.ChGroupBox2.Controls.Add(Me.DRFOLDER)
        Me.ChGroupBox2.Controls.Add(Me.Label4)
        Me.ChGroupBox2.Controls.Add(Me.exename)
        Me.ChGroupBox2.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox2.Image = Nothing
        Me.ChGroupBox2.Location = New System.Drawing.Point(20, 232)
        Me.ChGroupBox2.Movable = True
        Me.ChGroupBox2.Name = "ChGroupBox2"
        Me.ChGroupBox2.NoRounding = False
        Me.ChGroupBox2.Sizable = True
        Me.ChGroupBox2.Size = New System.Drawing.Size(557, 271)
        Me.ChGroupBox2.SmartBounds = True
        Me.ChGroupBox2.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox2.TabIndex = 5
        Me.ChGroupBox2.Text = "Persistence"
        Me.ChGroupBox2.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox2.Transparent = False
        '
        'CHKDR
        '
        Me.CHKDR.Checked = False
        Me.CHKDR.Location = New System.Drawing.Point(22, 54)
        Me.CHKDR.MaximumSize = New System.Drawing.Size(56, 24)
        Me.CHKDR.MinimumSize = New System.Drawing.Size(56, 24)
        Me.CHKDR.Name = "CHKDR"
        Me.CHKDR.Size = New System.Drawing.Size(56, 24)
        Me.CHKDR.TabIndex = 7
        Me.CHKDR.Text = "ChOnOffBox1"
        '
        'DRPATH
        '
        Me.DRPATH.BackColor = System.Drawing.Color.Black
        Me.DRPATH.BaseColour = System.Drawing.Color.Black
        Me.DRPATH.BorderColour = System.Drawing.Color.DarkGreen
        Me.DRPATH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.DRPATH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DRPATH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DRPATH.FontColour = System.Drawing.Color.Lime
        Me.DRPATH.FormattingEnabled = True
        Me.DRPATH.Items.AddRange(New Object() {"AppData", "Temp", "UserProfile"})
        Me.DRPATH.Location = New System.Drawing.Point(126, 144)
        Me.DRPATH.Name = "DRPATH"
        Me.DRPATH.Size = New System.Drawing.Size(227, 29)
        Me.DRPATH.StartIndex = 0
        Me.DRPATH.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(19, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Directory"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(19, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sub Folder"
        '
        'DRFOLDER
        '
        Me.DRFOLDER.BackColor = System.Drawing.Color.Transparent
        Me.DRFOLDER.Colors = New Lime.Bloom(-1) {}
        Me.DRFOLDER.Customization = ""
        Me.DRFOLDER.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.DRFOLDER.Image = Nothing
        Me.DRFOLDER.Location = New System.Drawing.Point(126, 199)
        Me.DRFOLDER.MaxCharacters = 0
        Me.DRFOLDER.Name = "DRFOLDER"
        Me.DRFOLDER.NoRounding = False
        Me.DRFOLDER.Size = New System.Drawing.Size(227, 25)
        Me.DRFOLDER.TabIndex = 4
        Me.DRFOLDER.Transparent = True
        Me.DRFOLDER.UsePasswordMask = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(19, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "File Name"
        '
        'exename
        '
        Me.exename.BackColor = System.Drawing.Color.Transparent
        Me.exename.Colors = New Lime.Bloom(-1) {}
        Me.exename.Customization = ""
        Me.exename.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.exename.Image = Nothing
        Me.exename.Location = New System.Drawing.Point(126, 97)
        Me.exename.MaxCharacters = 0
        Me.exename.Name = "exename"
        Me.exename.NoRounding = False
        Me.exename.Size = New System.Drawing.Size(227, 25)
        Me.exename.TabIndex = 2
        Me.exename.Transparent = True
        Me.exename.UsePasswordMask = False
        '
        'ChGroupBox1
        '
        Me.ChGroupBox1.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox1.Controls.Add(Me.Label2)
        Me.ChGroupBox1.Controls.Add(Me.port)
        Me.ChGroupBox1.Controls.Add(Me.Label1)
        Me.ChGroupBox1.Controls.Add(Me.host)
        Me.ChGroupBox1.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox1.Image = Nothing
        Me.ChGroupBox1.Location = New System.Drawing.Point(20, 25)
        Me.ChGroupBox1.Movable = True
        Me.ChGroupBox1.Name = "ChGroupBox1"
        Me.ChGroupBox1.NoRounding = False
        Me.ChGroupBox1.Sizable = True
        Me.ChGroupBox1.Size = New System.Drawing.Size(557, 144)
        Me.ChGroupBox1.SmartBounds = True
        Me.ChGroupBox1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox1.TabIndex = 7
        Me.ChGroupBox1.Text = "Connection"
        Me.ChGroupBox1.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox1.Transparent = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(349, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Port"
        '
        'port
        '
        Me.port.BackColor = System.Drawing.Color.Transparent
        Me.port.Colors = New Lime.Bloom(-1) {}
        Me.port.Customization = ""
        Me.port.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.port.Image = Nothing
        Me.port.Location = New System.Drawing.Point(396, 71)
        Me.port.MaxCharacters = 0
        Me.port.Name = "port"
        Me.port.NoRounding = False
        Me.port.Size = New System.Drawing.Size(117, 25)
        Me.port.TabIndex = 4
        Me.port.Transparent = True
        Me.port.UsePasswordMask = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(17, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP"
        '
        'host
        '
        Me.host.BackColor = System.Drawing.Color.Transparent
        Me.host.Colors = New Lime.Bloom(-1) {}
        Me.host.Customization = ""
        Me.host.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.host.Image = Nothing
        Me.host.Location = New System.Drawing.Point(48, 71)
        Me.host.MaxCharacters = 0
        Me.host.Name = "host"
        Me.host.NoRounding = False
        Me.host.Size = New System.Drawing.Size(269, 25)
        Me.host.TabIndex = 2
        Me.host.Transparent = True
        Me.host.UsePasswordMask = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1461, 663)
        Me.Controls.Add(Me.ChTabcontrol1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lime Controller v0.4"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ChTabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ChGroupBox3.ResumeLayout(False)
        Me.ChGroupBox2.ResumeLayout(False)
        Me.ChGroupBox2.PerformLayout()
        Me.ChGroupBox1.ResumeLayout(False)
        Me.ChGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents VvvToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromDiskToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ComputerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WormSettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromDiskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UninstallToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RansomwareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DecryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisitWebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents L1 As ListView
    Friend WithEvents c_id As ColumnHeader
    Friend WithEvents c_ip As ColumnHeader
    Friend WithEvents c_user As ColumnHeader
    Friend WithEvents c_ransomware As ColumnHeader
    Friend WithEvents c_stub As ColumnHeader
    Friend WithEvents c_country As ColumnHeader
    Friend WithEvents c_os As ColumnHeader
    Friend WithEvents c_version As ColumnHeader
    Friend WithEvents c_install As ColumnHeader
    Friend WithEvents c_av As ColumnHeader
    Friend WithEvents c_usb As ColumnHeader
    Friend WithEvents ChTabcontrol1 As CHTabcontrol
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents L2 As CHListbox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ChGroupBox1 As CHGroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents port As CHTextbox
    Friend WithEvents Label1 As Label
    Friend WithEvents host As CHTextbox
    Friend WithEvents ChGroupBox2 As CHGroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DRFOLDER As CHTextbox
    Friend WithEvents Label4 As Label
    Friend WithEvents exename As CHTextbox
    Friend WithEvents DRPATH As CHCombobox
    Friend WithEvents ChGroupBox3 As CHGroupBox
    Friend WithEvents SPUSB As CHCheckbox
    Friend WithEvents ANTI_VM As CHCheckbox
    Friend WithEvents Button1 As CHButton
    Friend WithEvents CHKDR As CHOnOffBox
    Friend WithEvents Button4 As CHButton
End Class
