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
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.Flood_Attack = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.Flood_Threads = New System.Windows.Forms.NumericUpDown()
        Me.Flood_Time = New System.Windows.Forms.NumericUpDown()
        Me.Flood_Port = New System.Windows.Forms.NumericUpDown()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flood_Threads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flood_Time, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flood_Port, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Flood_Attack
        '
        Me.Flood_Attack.FormattingEnabled = True
        Me.Flood_Attack.ItemHeight = 23
        Me.Flood_Attack.Items.AddRange(New Object() {"Slowloris", "ARME", "UDP"})
        Me.Flood_Attack.Location = New System.Drawing.Point(137, 132)
        Me.Flood_Attack.Name = "Flood_Attack"
        Me.Flood_Attack.Size = New System.Drawing.Size(156, 29)
        Me.Flood_Attack.Style = MetroFramework.MetroColorStyle.Lime
        Me.Flood_Attack.TabIndex = 11
        Me.Flood_Attack.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel6
        '
        Me.MetroLabel6.AutoSize = True
        Me.MetroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel6.Location = New System.Drawing.Point(36, 132)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(48, 19)
        Me.MetroLabel6.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel6.TabIndex = 12
        Me.MetroLabel6.Text = "Attack"
        Me.MetroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark
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
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel3.Location = New System.Drawing.Point(366, 132)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(35, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel3.TabIndex = 15
        Me.MetroLabel3.Text = "Port"
        Me.MetroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroLabel3.Visible = False
        '
        'Flood_Threads
        '
        Me.Flood_Threads.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Flood_Threads.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Flood_Threads.ForeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Flood_Threads.Location = New System.Drawing.Point(137, 275)
        Me.Flood_Threads.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.Flood_Threads.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Flood_Threads.Name = "Flood_Threads"
        Me.Flood_Threads.Size = New System.Drawing.Size(81, 22)
        Me.Flood_Threads.TabIndex = 17
        Me.Flood_Threads.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Flood_Time
        '
        Me.Flood_Time.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Flood_Time.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Flood_Time.ForeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Flood_Time.Location = New System.Drawing.Point(467, 275)
        Me.Flood_Time.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Flood_Time.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Flood_Time.Name = "Flood_Time"
        Me.Flood_Time.Size = New System.Drawing.Size(81, 22)
        Me.Flood_Time.TabIndex = 18
        Me.Flood_Time.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Flood_Port
        '
        Me.Flood_Port.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Flood_Port.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Flood_Port.ForeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Flood_Port.Location = New System.Drawing.Point(467, 134)
        Me.Flood_Port.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Flood_Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Flood_Port.Name = "Flood_Port"
        Me.Flood_Port.Size = New System.Drawing.Size(81, 22)
        Me.Flood_Port.TabIndex = 19
        Me.Flood_Port.Value = New Decimal(New Integer() {80, 0, 0, 0})
        Me.Flood_Port.Visible = False
        '
        'Floods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Flood_Port)
        Me.Controls.Add(Me.Flood_Time)
        Me.Controls.Add(Me.Flood_Threads)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroTile1)
        Me.Controls.Add(Me.MetroLabel6)
        Me.Controls.Add(Me.Flood_Attack)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.Flood_Host)
        Me.Name = "Floods"
        Me.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "Floods"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flood_Threads, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flood_Time, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flood_Port, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents Flood_Host As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel6 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Flood_Attack As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Flood_Port As NumericUpDown
    Friend WithEvents Flood_Time As NumericUpDown
    Friend WithEvents Flood_Threads As NumericUpDown
End Class
