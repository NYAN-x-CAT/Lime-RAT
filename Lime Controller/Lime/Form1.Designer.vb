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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.L2 = New System.Windows.Forms.ListBox()
        Me.PasswordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuilderToolStripMenuItem, Me.ToolStripSeparator1, Me.RansomwareToolStripMenuItem, Me.PasswordsToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.VvvToolStripMenuItem, Me.VisitWebsiteToolStripMenuItem, Me.ComputerToolStripMenuItem, Me.WormSettingToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(199, 319)
        '
        'BuilderToolStripMenuItem
        '
        Me.BuilderToolStripMenuItem.Name = "BuilderToolStripMenuItem"
        Me.BuilderToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.BuilderToolStripMenuItem.Text = "Builder"
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 633)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1461, 30)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(180, 25)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.L1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.L2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1461, 663)
        Me.SplitContainer1.SplitterDistance = 461
        Me.SplitContainer1.TabIndex = 0
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.c_id, Me.c_ip, Me.c_user, Me.c_ransomware, Me.c_stub, Me.c_country, Me.c_os, Me.c_version, Me.c_install, Me.c_av, Me.c_usb})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.Lime
        Me.L1.FullRowSelect = True
        Me.L1.Location = New System.Drawing.Point(0, 0)
        Me.L1.Name = "L1"
        Me.L1.Scrollable = False
        Me.L1.Size = New System.Drawing.Size(1461, 461)
        Me.L1.TabIndex = 1
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
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1174, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(287, 198)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.L2.Dock = System.Windows.Forms.DockStyle.Left
        Me.L2.ForeColor = System.Drawing.Color.Gainsboro
        Me.L2.FormattingEnabled = True
        Me.L2.ItemHeight = 20
        Me.L2.Items.AddRange(New Object() {"#Logs", ""})
        Me.L2.Location = New System.Drawing.Point(0, 0)
        Me.L2.Name = "L2"
        Me.L2.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.L2.Size = New System.Drawing.Size(1165, 198)
        Me.L2.TabIndex = 2
        '
        'PasswordsToolStripMenuItem
        '
        Me.PasswordsToolStripMenuItem.Name = "PasswordsToolStripMenuItem"
        Me.PasswordsToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.PasswordsToolStripMenuItem.Text = "Passwords"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1461, 663)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lime Controller v0.3"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BuilderToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents L1 As ListView
    Friend WithEvents c_id As ColumnHeader
    Friend WithEvents c_ip As ColumnHeader
    Friend WithEvents c_user As ColumnHeader
    Friend WithEvents c_stub As ColumnHeader
    Friend WithEvents c_country As ColumnHeader
    Friend WithEvents c_os As ColumnHeader
    Friend WithEvents c_version As ColumnHeader
    Friend WithEvents c_install As ColumnHeader
    Friend WithEvents c_av As ColumnHeader
    Friend WithEvents c_usb As ColumnHeader
    Friend WithEvents L2 As ListBox
    Friend WithEvents c_ransomware As ColumnHeader
    Friend WithEvents DetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RansomwareToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DecryptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents VisitWebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasswordsToolStripMenuItem As ToolStripMenuItem
End Class
