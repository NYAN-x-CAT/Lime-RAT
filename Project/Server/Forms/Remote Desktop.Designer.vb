<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Remote_Desktop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Remote_Desktop))
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.chkKey = New MetroFramework.Controls.MetroCheckBox()
        Me.CHKmouse = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.Combo_quality = New MetroFramework.Controls.MetroComboBox()
        Me.Combo_size = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.P1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel1.SuspendLayout()
        CType(Me.P1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.chkKey)
        Me.MetroPanel1.Controls.Add(Me.CHKmouse)
        Me.MetroPanel1.Controls.Add(Me.MetroButton2)
        Me.MetroPanel1.Controls.Add(Me.MetroButton1)
        Me.MetroPanel1.Controls.Add(Me.Combo_quality)
        Me.MetroPanel1.Controls.Add(Me.Combo_size)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel2)
        Me.MetroPanel1.Controls.Add(Me.MetroLabel1)
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(23, 101)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(813, 69)
        Me.MetroPanel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroPanel1.TabIndex = 0
        Me.MetroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'chkKey
        '
        Me.chkKey.AutoSize = True
        Me.chkKey.Location = New System.Drawing.Point(469, 42)
        Me.chkKey.Name = "chkKey"
        Me.chkKey.Size = New System.Drawing.Size(73, 15)
        Me.chkKey.Style = MetroFramework.MetroColorStyle.Lime
        Me.chkKey.TabIndex = 5
        Me.chkKey.Text = "Keyboard"
        Me.chkKey.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chkKey.UseVisualStyleBackColor = True
        '
        'CHKmouse
        '
        Me.CHKmouse.AutoSize = True
        Me.CHKmouse.Location = New System.Drawing.Point(469, 12)
        Me.CHKmouse.Name = "CHKmouse"
        Me.CHKmouse.Size = New System.Drawing.Size(59, 15)
        Me.CHKmouse.Style = MetroFramework.MetroColorStyle.Lime
        Me.CHKmouse.TabIndex = 3
        Me.CHKmouse.Text = "Mouse"
        Me.CHKmouse.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.CHKmouse.UseVisualStyleBackColor = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(700, 12)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(90, 29)
        Me.MetroButton2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroButton2.TabIndex = 4
        Me.MetroButton2.Text = "Save"
        Me.MetroButton2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(581, 12)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(90, 29)
        Me.MetroButton1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroButton1.TabIndex = 1
        Me.MetroButton1.Text = "Start"
        Me.MetroButton1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Combo_quality
        '
        Me.Combo_quality.FormattingEnabled = True
        Me.Combo_quality.ItemHeight = 23
        Me.Combo_quality.Items.AddRange(New Object() {"50", "60", "70", "80", "90", "100"})
        Me.Combo_quality.Location = New System.Drawing.Point(343, 12)
        Me.Combo_quality.Name = "Combo_quality"
        Me.Combo_quality.Size = New System.Drawing.Size(86, 29)
        Me.Combo_quality.Style = MetroFramework.MetroColorStyle.Lime
        Me.Combo_quality.TabIndex = 3
        Me.Combo_quality.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Combo_size
        '
        Me.Combo_size.FormattingEnabled = True
        Me.Combo_size.ItemHeight = 23
        Me.Combo_size.Location = New System.Drawing.Point(72, 12)
        Me.Combo_size.Name = "Combo_size"
        Me.Combo_size.Size = New System.Drawing.Size(139, 29)
        Me.Combo_size.Style = MetroFramework.MetroColorStyle.Lime
        Me.Combo_size.TabIndex = 1
        Me.Combo_size.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel2.Location = New System.Drawing.Point(235, 19)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(69, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "Quality%"
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel1.Location = New System.Drawing.Point(8, 19)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(44, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = " Size "
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'P1
        '
        Me.P1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P1.ErrorImage = Nothing
        Me.P1.InitialImage = Nothing
        Me.P1.Location = New System.Drawing.Point(31, 198)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(805, 402)
        Me.P1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.P1.TabIndex = 1
        Me.P1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Me
        Me.MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroLabel3.Location = New System.Drawing.Point(20, 627)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(17, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel3.TabIndex = 2
        Me.MetroLabel3.Text = "  "
        Me.MetroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Remote_Desktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 666)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.P1)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(782, 666)
        Me.Name = "Remote_Desktop"
        Me.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "Remote_Desktop"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        CType(Me.P1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents Combo_quality As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Combo_size As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents P1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents CHKmouse As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents chkKey As MetroFramework.Controls.MetroCheckBox
End Class
