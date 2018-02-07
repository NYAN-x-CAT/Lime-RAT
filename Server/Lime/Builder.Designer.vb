<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Builder
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DRPATH = New System.Windows.Forms.ComboBox()
        Me.CHKDR = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ANTI_VM = New System.Windows.Forms.CheckBox()
        Me.SPDRIVER = New System.Windows.Forms.CheckBox()
        Me.SPUSB = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DRFOLDER = New System.Windows.Forms.TextBox()
        Me.exename = New System.Windows.Forms.TextBox()
        Me.host2 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.port = New System.Windows.Forms.TextBox()
        Me.vn = New System.Windows.Forms.TextBox()
        Me.host = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label1.Location = New System.Drawing.Point(22, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DNS - IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label2.Location = New System.Drawing.Point(22, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label3.Location = New System.Drawing.Point(22, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Controller ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.host2)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.port)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.vn)
        Me.GroupBox1.Controls.Add(Me.host)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 271)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button3.Location = New System.Drawing.Point(26, 197)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 37)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Mutex"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label5.Location = New System.Drawing.Point(22, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Backup DNS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.DRFOLDER)
        Me.GroupBox2.Controls.Add(Me.DRPATH)
        Me.GroupBox2.Controls.Add(Me.CHKDR)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.exename)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox2.Location = New System.Drawing.Point(12, 317)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 221)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Drop File"
        '
        'DRPATH
        '
        Me.DRPATH.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.DRPATH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DRPATH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DRPATH.ForeColor = System.Drawing.Color.Lime
        Me.DRPATH.FormattingEnabled = True
        Me.DRPATH.Items.AddRange(New Object() {"AppData", "Temp", "UserProfile"})
        Me.DRPATH.Location = New System.Drawing.Point(133, 114)
        Me.DRPATH.Name = "DRPATH"
        Me.DRPATH.Size = New System.Drawing.Size(222, 28)
        Me.DRPATH.TabIndex = 11
        '
        'CHKDR
        '
        Me.CHKDR.AutoSize = True
        Me.CHKDR.Location = New System.Drawing.Point(26, 36)
        Me.CHKDR.Name = "CHKDR"
        Me.CHKDR.Size = New System.Drawing.Size(22, 21)
        Me.CHKDR.TabIndex = 10
        Me.CHKDR.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label6.Location = New System.Drawing.Point(22, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "File Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label8.Location = New System.Drawing.Point(22, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Directory"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.ANTI_VM)
        Me.GroupBox3.Controls.Add(Me.SPDRIVER)
        Me.GroupBox3.Controls.Add(Me.SPUSB)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox3.Location = New System.Drawing.Point(12, 573)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 202)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MISC"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(158, 140)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(67, 26)
        Me.NumericUpDown1.TabIndex = 17
        Me.NumericUpDown1.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label4.Location = New System.Drawing.Point(22, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Sleep in seconds"
        '
        'ANTI_VM
        '
        Me.ANTI_VM.AutoSize = True
        Me.ANTI_VM.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.ANTI_VM.Location = New System.Drawing.Point(26, 107)
        Me.ANTI_VM.Name = "ANTI_VM"
        Me.ANTI_VM.Size = New System.Drawing.Size(274, 24)
        Me.ANTI_VM.TabIndex = 13
        Me.ANTI_VM.Text = "Don't Run On Virtual Environment"
        Me.ANTI_VM.UseVisualStyleBackColor = True
        '
        'SPDRIVER
        '
        Me.SPDRIVER.AutoSize = True
        Me.SPDRIVER.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.SPDRIVER.Location = New System.Drawing.Point(26, 74)
        Me.SPDRIVER.Name = "SPDRIVER"
        Me.SPDRIVER.Size = New System.Drawing.Size(182, 24)
        Me.SPDRIVER.TabIndex = 12
        Me.SPDRIVER.Text = "Spread Local Drivers"
        Me.SPDRIVER.UseVisualStyleBackColor = True
        '
        'SPUSB
        '
        Me.SPUSB.AutoSize = True
        Me.SPUSB.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.SPUSB.Location = New System.Drawing.Point(26, 41)
        Me.SPUSB.Name = "SPUSB"
        Me.SPUSB.Size = New System.Drawing.Size(125, 24)
        Me.SPUSB.TabIndex = 11
        Me.SPUSB.Text = "Spread USB"
        Me.SPUSB.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button1.Location = New System.Drawing.Point(12, 811)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 56)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Build"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button2.Location = New System.Drawing.Point(257, 811)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 56)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label7.Location = New System.Drawing.Point(22, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Sub Folder"
        '
        'DRFOLDER
        '
        Me.DRFOLDER.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.DRFOLDER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DRFOLDER.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "subfolder", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DRFOLDER.ForeColor = System.Drawing.Color.Lime
        Me.DRFOLDER.Location = New System.Drawing.Point(133, 161)
        Me.DRFOLDER.Name = "DRFOLDER"
        Me.DRFOLDER.Size = New System.Drawing.Size(222, 26)
        Me.DRFOLDER.TabIndex = 13
        Me.DRFOLDER.Text = Global.Lime.My.MySettings.Default.subfolder
        '
        'exename
        '
        Me.exename.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.exename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.exename.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "exename", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.exename.ForeColor = System.Drawing.Color.Lime
        Me.exename.Location = New System.Drawing.Point(133, 67)
        Me.exename.Name = "exename"
        Me.exename.Size = New System.Drawing.Size(222, 26)
        Me.exename.TabIndex = 1
        Me.exename.Text = Global.Lime.My.MySettings.Default.exename
        '
        'host2
        '
        Me.host2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.host2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.host2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "host2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.host2.ForeColor = System.Drawing.Color.Lime
        Me.host2.Location = New System.Drawing.Point(133, 74)
        Me.host2.Name = "host2"
        Me.host2.Size = New System.Drawing.Size(222, 26)
        Me.host2.TabIndex = 9
        Me.host2.Text = Global.Lime.My.MySettings.Default.host2
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "mutex", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBox2.ForeColor = System.Drawing.Color.Lime
        Me.TextBox2.Location = New System.Drawing.Point(133, 203)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(222, 26)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = Global.Lime.My.MySettings.Default.mutex
        '
        'port
        '
        Me.port.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.port.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "port", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.port.ForeColor = System.Drawing.Color.Lime
        Me.port.Location = New System.Drawing.Point(133, 117)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(222, 26)
        Me.port.TabIndex = 3
        Me.port.Text = Global.Lime.My.MySettings.Default.port
        '
        'vn
        '
        Me.vn.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.vn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vn.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "id", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.vn.ForeColor = System.Drawing.Color.Lime
        Me.vn.Location = New System.Drawing.Point(133, 160)
        Me.vn.Name = "vn"
        Me.vn.Size = New System.Drawing.Size(222, 26)
        Me.vn.TabIndex = 5
        Me.vn.Text = Global.Lime.My.MySettings.Default.id
        '
        'host
        '
        Me.host.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.host.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.host.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "host", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.host.ForeColor = System.Drawing.Color.Lime
        Me.host.Location = New System.Drawing.Point(133, 30)
        Me.host.Name = "host"
        Me.host.Size = New System.Drawing.Size(222, 26)
        Me.host.TabIndex = 1
        Me.host.Text = Global.Lime.My.MySettings.Default.host
        '
        'Builder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(403, 897)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Builder"
        Me.Opacity = 0.95R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Builder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents host As TextBox
    Friend WithEvents port As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents vn As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DRPATH As ComboBox
    Friend WithEvents CHKDR As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents exename As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents SPDRIVER As CheckBox
    Friend WithEvents SPUSB As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents host2 As TextBox
    Friend WithEvents ANTI_VM As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DRFOLDER As TextBox
End Class
