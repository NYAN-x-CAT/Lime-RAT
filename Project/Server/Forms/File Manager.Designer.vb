<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class File_Manager
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(File_Manager))
        Me.L1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TempToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New MetroFramework.Controls.MetroLabel()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'L1
        '
        Me.L1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.L1.Location = New System.Drawing.Point(27, 138)
        Me.L1.Name = "L1"
        Me.L1.OwnerDraw = True
        Me.L1.Size = New System.Drawing.Size(867, 343)
        Me.L1.SmallImageList = Me.ImageList1
        Me.L1.TabIndex = 4
        Me.L1.UseCompatibleStateImageBehavior = False
        Me.L1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "File Name"
        Me.ColumnHeader1.Width = 340
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "File Size"
        Me.ColumnHeader2.Width = 187
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ToolStripSeparator2, Me.GoToToolStripMenuItem, Me.ToolStripSeparator1, Me.RunToolStripMenuItem, Me.DWToolStripMenuItem, Me.UploadToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 226)
        '
        'BackToolStripMenuItem
        '
        Me.BackToolStripMenuItem.Image = CType(resources.GetObject("BackToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BackToolStripMenuItem.Name = "BackToolStripMenuItem"
        Me.BackToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.BackToolStripMenuItem.Text = "Back"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(176, 6)
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesktopToolStripMenuItem, Me.AppDataToolStripMenuItem, Me.TempToolStripMenuItem, Me.UserFolderToolStripMenuItem, Me.StartupToolStripMenuItem})
        Me.GoToToolStripMenuItem.Image = CType(resources.GetObject("GoToToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.GoToToolStripMenuItem.Text = "Go To"
        '
        'DesktopToolStripMenuItem
        '
        Me.DesktopToolStripMenuItem.Image = CType(resources.GetObject("DesktopToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DesktopToolStripMenuItem.Name = "DesktopToolStripMenuItem"
        Me.DesktopToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
        Me.DesktopToolStripMenuItem.Text = "Desktop"
        '
        'AppDataToolStripMenuItem
        '
        Me.AppDataToolStripMenuItem.Image = CType(resources.GetObject("AppDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AppDataToolStripMenuItem.Name = "AppDataToolStripMenuItem"
        Me.AppDataToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
        Me.AppDataToolStripMenuItem.Text = "AppData"
        '
        'TempToolStripMenuItem
        '
        Me.TempToolStripMenuItem.Image = CType(resources.GetObject("TempToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TempToolStripMenuItem.Name = "TempToolStripMenuItem"
        Me.TempToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
        Me.TempToolStripMenuItem.Text = "Temp"
        '
        'UserFolderToolStripMenuItem
        '
        Me.UserFolderToolStripMenuItem.Image = CType(resources.GetObject("UserFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UserFolderToolStripMenuItem.Name = "UserFolderToolStripMenuItem"
        Me.UserFolderToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
        Me.UserFolderToolStripMenuItem.Text = "User Folder"
        '
        'StartupToolStripMenuItem
        '
        Me.StartupToolStripMenuItem.Image = CType(resources.GetObject("StartupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StartupToolStripMenuItem.Name = "StartupToolStripMenuItem"
        Me.StartupToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
        Me.StartupToolStripMenuItem.Text = "Startup"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Image = CType(resources.GetObject("RunToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'DWToolStripMenuItem
        '
        Me.DWToolStripMenuItem.Image = CType(resources.GetObject("DWToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DWToolStripMenuItem.Name = "DWToolStripMenuItem"
        Me.DWToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.DWToolStripMenuItem.Text = "Download"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Image = CType(resources.GetObject("UploadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "drive.png")
        Me.ImageList1.Images.SetKeyName(1, "drive_cd.png")
        Me.ImageList1.Images.SetKeyName(2, "folder.png")
        Me.ImageList1.Images.SetKeyName(3, "application_xp.png")
        Me.ImageList1.Images.SetKeyName(4, "picture.png")
        Me.ImageList1.Images.SetKeyName(5, "page_white_text.png")
        Me.ImageList1.Images.SetKeyName(6, "cog.png")
        Me.ImageList1.Images.SetKeyName(7, "page_white_compressed.png")
        Me.ImageList1.Images.SetKeyName(8, "page_white.png")
        Me.ImageList1.Images.SetKeyName(9, "sound.png")
        Me.ImageList1.Images.SetKeyName(10, "world.png")
        Me.ImageList1.Images.SetKeyName(11, "film.png")
        Me.ImageList1.Images.SetKeyName(12, "resultset_next.png")
        Me.ImageList1.Images.SetKeyName(13, "122.ico")
        Me.ImageList1.Images.SetKeyName(14, "lok.png")
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(23, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Me
        Me.MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(667, 252)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 497)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 19)
        Me.Label2.Style = MetroFramework.MetroColorStyle.Lime
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "     "
        Me.Label2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.Label2.UseMnemonic = False
        Me.Label2.UseStyleColors = True
        '
        'File_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 539)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.L1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(896, 489)
        Me.Name = "File_Manager"
        Me.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "File_Manager"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents L1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label1 As Label
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents DWToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GoToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TempToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents UserFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents StartupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
End Class
