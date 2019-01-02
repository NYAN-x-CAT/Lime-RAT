<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Intro
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Intro))
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox2 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MetroPanel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Me
        Me.MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroButton1
        '
        Me.MetroButton1.Highlight = True
        Me.MetroButton1.Location = New System.Drawing.Point(30, 325)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(336, 37)
        Me.MetroButton1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroButton1.TabIndex = 0
        Me.MetroButton1.Text = "Start"
        Me.MetroButton1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton1.UseMnemonic = False
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel1.Location = New System.Drawing.Point(20, 29)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(43, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = "PORT"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroTextBox2
        '
        Me.MetroTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime_RAT.My.MySettings.Default, "Encryption", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.MetroTextBox2.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.MetroTextBox2.Location = New System.Drawing.Point(131, 237)
        Me.MetroTextBox2.Name = "MetroTextBox2"
        Me.MetroTextBox2.Size = New System.Drawing.Size(225, 36)
        Me.MetroTextBox2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroTextBox2.TabIndex = 4
        Me.MetroTextBox2.Text = Global.Lime_RAT.My.MySettings.Default.Encryption
        Me.MetroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel2.Location = New System.Drawing.Point(20, 241)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(58, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel2.TabIndex = 3
        Me.MetroLabel2.Text = "AES Key"
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroPanel1
        '
        Me.MetroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle
        Me.MetroPanel1.Controls.Add(Me.MetroButton2)
        Me.MetroPanel1.Controls.Add(Me.ListBox1)
        Me.MetroPanel1.Controls.Add(Me.MetroButton1)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel2)
        Me.MetroPanel1.Controls.Add(Me.MetroTextBox2)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel1)
        Me.MetroPanel1.Controls.Add(Me.MetroTextBox1)
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(23, 109)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(399, 439)
        Me.MetroPanel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroPanel1.TabIndex = 5
        Me.MetroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'MetroButton2
        '
        Me.MetroButton2.Highlight = True
        Me.MetroButton2.Location = New System.Drawing.Point(286, 25)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(70, 37)
        Me.MetroButton2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroButton2.TabIndex = 6
        Me.MetroButton2.Text = "Add"
        Me.MetroButton2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton2.UseMnemonic = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(131, 92)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(115, 120)
        Me.ListBox1.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 34)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(149, 30)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.MetroTextBox1.Location = New System.Drawing.Point(131, 26)
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.Size = New System.Drawing.Size(115, 36)
        Me.MetroTextBox1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroTextBox1.TabIndex = 2
        Me.MetroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Intro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 571)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Intro"
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "LimeRAT"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox2 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
End Class
