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
        Me.BuilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoteDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RansomwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecryptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControllerOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ChTabcontrol1 = New Server_0._4.CHTabcontrol()
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
        Me.Rans = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PING = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.L2 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ChTabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuilderToolStripMenuItem, Me.ToolStripSeparator2, Me.RemoteDesktopToolStripMenuItem, Me.RansomwareToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.ControllerOptionsToolStripMenuItem, Me.RunAFileToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(232, 226)
        '
        'BuilderToolStripMenuItem
        '
        Me.BuilderToolStripMenuItem.Name = "BuilderToolStripMenuItem"
        Me.BuilderToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.BuilderToolStripMenuItem.Text = "Builder"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(228, 6)
        '
        'RemoteDesktopToolStripMenuItem
        '
        Me.RemoteDesktopToolStripMenuItem.Name = "RemoteDesktopToolStripMenuItem"
        Me.RemoteDesktopToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.RemoteDesktopToolStripMenuItem.Text = "Remote Desktop"
        '
        'RansomwareToolStripMenuItem
        '
        Me.RansomwareToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EncryptToolStripMenuItem, Me.DecryptionToolStripMenuItem})
        Me.RansomwareToolStripMenuItem.Name = "RansomwareToolStripMenuItem"
        Me.RansomwareToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.RansomwareToolStripMenuItem.Text = "Ransomware"
        '
        'EncryptToolStripMenuItem
        '
        Me.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem"
        Me.EncryptToolStripMenuItem.Size = New System.Drawing.Size(183, 30)
        Me.EncryptToolStripMenuItem.Text = "Encrypt"
        '
        'DecryptionToolStripMenuItem
        '
        Me.DecryptionToolStripMenuItem.Name = "DecryptionToolStripMenuItem"
        Me.DecryptionToolStripMenuItem.Size = New System.Drawing.Size(183, 30)
        Me.DecryptionToolStripMenuItem.Text = "Decryption"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'ControllerOptionsToolStripMenuItem
        '
        Me.ControllerOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem, Me.RestartToolStripMenuItem, Me.CloseToolStripMenuItem, Me.UninstallToolStripMenuItem})
        Me.ControllerOptionsToolStripMenuItem.Name = "ControllerOptionsToolStripMenuItem"
        Me.ControllerOptionsToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.ControllerOptionsToolStripMenuItem.Text = "Controller Options"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiskToolStripMenuItem, Me.FromURLToolStripMenuItem})
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'DiskToolStripMenuItem
        '
        Me.DiskToolStripMenuItem.Name = "DiskToolStripMenuItem"
        Me.DiskToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.DiskToolStripMenuItem.Text = "From Disk"
        '
        'FromURLToolStripMenuItem
        '
        Me.FromURLToolStripMenuItem.Name = "FromURLToolStripMenuItem"
        Me.FromURLToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.FromURLToolStripMenuItem.Text = "From URL"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'UninstallToolStripMenuItem
        '
        Me.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem"
        Me.UninstallToolStripMenuItem.Size = New System.Drawing.Size(163, 30)
        Me.UninstallToolStripMenuItem.Text = "Uninstall"
        '
        'RunAFileToolStripMenuItem
        '
        Me.RunAFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem, Me.FromURLToolStripMenuItem1})
        Me.RunAFileToolStripMenuItem.Name = "RunAFileToolStripMenuItem"
        Me.RunAFileToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.RunAFileToolStripMenuItem.Text = "Run a File"
        '
        'FromDiskToolStripMenuItem
        '
        Me.FromDiskToolStripMenuItem.Name = "FromDiskToolStripMenuItem"
        Me.FromDiskToolStripMenuItem.Size = New System.Drawing.Size(177, 30)
        Me.FromDiskToolStripMenuItem.Text = "From Disk"
        '
        'FromURLToolStripMenuItem1
        '
        Me.FromURLToolStripMenuItem1.Name = "FromURLToolStripMenuItem1"
        Me.FromURLToolStripMenuItem1.Size = New System.Drawing.Size(177, 30)
        Me.FromURLToolStripMenuItem1.Text = "From URL"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(228, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ChTabcontrol1
        '
        Me.ChTabcontrol1.Controls.Add(Me.TabPage1)
        Me.ChTabcontrol1.Controls.Add(Me.TabPage2)
        Me.ChTabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChTabcontrol1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ChTabcontrol1.GlowColor = System.Drawing.Color.Empty
        Me.ChTabcontrol1.ItemSize = New System.Drawing.Size(80, 30)
        Me.ChTabcontrol1.Location = New System.Drawing.Point(0, 0)
        Me.ChTabcontrol1.Name = "ChTabcontrol1"
        Me.ChTabcontrol1.SelectedIndex = 0
        Me.ChTabcontrol1.Size = New System.Drawing.Size(1263, 472)
        Me.ChTabcontrol1.TabIndex = 0
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
        Me.TabPage1.Size = New System.Drawing.Size(1255, 434)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bots"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1000, 270)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 401)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1249, 30)
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
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.IP, Me.USER, Me.EXE_NAME, Me.VER, Me.OS, Me.INDATE, Me.Rans, Me.PING})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L1.ForeColor = System.Drawing.Color.Lime
        Me.L1.FullRowSelect = True
        Me.L1.Location = New System.Drawing.Point(3, 3)
        Me.L1.Name = "L1"
        Me.L1.OwnerDraw = True
        Me.L1.Size = New System.Drawing.Size(1249, 428)
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
        'Rans
        '
        Me.Rans.Text = " Ransomware Status "
        Me.Rans.Width = 205
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
        Me.TabPage2.Size = New System.Drawing.Size(1255, 434)
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
        Me.L2.Location = New System.Drawing.Point(3, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(1249, 428)
        Me.L2.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1263, 472)
        Me.Controls.Add(Me.ChTabcontrol1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ChTabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChTabcontrol1 As CHTabcontrol
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
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BuilderToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
