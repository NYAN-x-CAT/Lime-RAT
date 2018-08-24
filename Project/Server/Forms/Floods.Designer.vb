<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Floods
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
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.Flood_Host = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.Flood_Time = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.Flood_Threads = New MetroFramework.Controls.MetroTextBox()
        Me.Flood_Attack = New MetroFramework.Controls.MetroComboBox()
        Me.Flood_Type = New MetroFramework.Controls.MetroLabel()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Me
        Me.MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Flood_Host
        '
        Me.Flood_Host.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.Flood_Host.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Flood_Host.Location = New System.Drawing.Point(137, 198)
        Me.Flood_Host.Name = "Flood_Host"
        Me.Flood_Host.Size = New System.Drawing.Size(581, 36)
        Me.Flood_Host.Style = MetroFramework.MetroColorStyle.Lime
        Me.Flood_Host.TabIndex = 5
        Me.Flood_Host.Text = "Google.com"
        Me.Flood_Host.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel5.Location = New System.Drawing.Point(36, 203)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(38, 19)
        Me.MetroLabel5.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel5.TabIndex = 6
        Me.MetroLabel5.Text = "Host"
        Me.MetroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel1.Location = New System.Drawing.Point(302, 275)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(99, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel1.TabIndex = 8
        Me.MetroLabel1.Text = "Time [minutes]"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Flood_Time
        '
        Me.Flood_Time.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.Flood_Time.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Flood_Time.Location = New System.Drawing.Point(467, 270)
        Me.Flood_Time.Name = "Flood_Time"
        Me.Flood_Time.Size = New System.Drawing.Size(92, 36)
        Me.Flood_Time.Style = MetroFramework.MetroColorStyle.Lime
        Me.Flood_Time.TabIndex = 7
        Me.Flood_Time.Text = "5"
        Me.Flood_Time.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel2.Location = New System.Drawing.Point(36, 275)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(57, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel2.TabIndex = 10
        Me.MetroLabel2.Text = "Threads"
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Flood_Threads
        '
        Me.Flood_Threads.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.Flood_Threads.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Flood_Threads.Location = New System.Drawing.Point(137, 270)
        Me.Flood_Threads.Name = "Flood_Threads"
        Me.Flood_Threads.Size = New System.Drawing.Size(92, 36)
        Me.Flood_Threads.Style = MetroFramework.MetroColorStyle.Lime
        Me.Flood_Threads.TabIndex = 9
        Me.Flood_Threads.Text = "2"
        Me.Flood_Threads.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Flood_Attack
        '
        Me.Flood_Attack.FormattingEnabled = True
        Me.Flood_Attack.ItemHeight = 23
        Me.Flood_Attack.Items.AddRange(New Object() {"Slowloris"})
        Me.Flood_Attack.Location = New System.Drawing.Point(137, 132)
        Me.Flood_Attack.Name = "Flood_Attack"
        Me.Flood_Attack.Size = New System.Drawing.Size(156, 29)
        Me.Flood_Attack.Style = MetroFramework.MetroColorStyle.Lime
        Me.Flood_Attack.TabIndex = 11
        Me.Flood_Attack.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Flood_Type
        '
        Me.Flood_Type.AutoSize = True
        Me.Flood_Type.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.Flood_Type.Location = New System.Drawing.Point(36, 132)
        Me.Flood_Type.Name = "Flood_Type"
        Me.Flood_Type.Size = New System.Drawing.Size(48, 19)
        Me.Flood_Type.Style = MetroFramework.MetroColorStyle.Lime
        Me.Flood_Type.TabIndex = 12
        Me.Flood_Type.Text = "Attack"
        Me.Flood_Type.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroTile1
        '
        Me.MetroTile1.Location = New System.Drawing.Point(573, 359)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(145, 40)
        Me.MetroTile1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroTile1.TabIndex = 13
        Me.MetroTile1.Text = "Start Attack"
        Me.MetroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Floods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MetroTile1)
        Me.Controls.Add(Me.Flood_Type)
        Me.Controls.Add(Me.Flood_Attack)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.Flood_Threads)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.Flood_Time)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.Flood_Host)
        Me.Name = "Floods"
        Me.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "Floods"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents Flood_Host As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Flood_Threads As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Flood_Time As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Flood_Type As MetroFramework.Controls.MetroLabel
    Friend WithEvents Flood_Attack As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
End Class
