<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Builder
    Inherits System.Windows.Forms.Form

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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ANTI_VM = New System.Windows.Forms.CheckBox()
        Me.SPUSB = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DRFOLDER = New System.Windows.Forms.TextBox()
        Me.DRPATH = New System.Windows.Forms.ComboBox()
        Me.CHKDR = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.exename = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.port = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.host = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button2.Location = New System.Drawing.Point(257, 641)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 56)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ANTI_VM
        '
        Me.ANTI_VM.AutoSize = True
        Me.ANTI_VM.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.ANTI_VM.Location = New System.Drawing.Point(19, 82)
        Me.ANTI_VM.Name = "ANTI_VM"
        Me.ANTI_VM.Size = New System.Drawing.Size(274, 24)
        Me.ANTI_VM.TabIndex = 13
        Me.ANTI_VM.Text = "Don't Run On Virtual Environment"
        Me.ANTI_VM.UseVisualStyleBackColor = True
        '
        'SPUSB
        '
        Me.SPUSB.AutoSize = True
        Me.SPUSB.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.SPUSB.Location = New System.Drawing.Point(19, 41)
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
        Me.Button1.Location = New System.Drawing.Point(12, 641)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 56)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Build"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ANTI_VM)
        Me.GroupBox3.Controls.Add(Me.SPUSB)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox3.Location = New System.Drawing.Point(12, 450)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 147)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MISC"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label7.Location = New System.Drawing.Point(15, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Sub Folder"
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 221)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Drop File"
        '
        'DRFOLDER
        '
        Me.DRFOLDER.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.DRFOLDER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DRFOLDER.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "folder", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DRFOLDER.ForeColor = System.Drawing.Color.Lime
        Me.DRFOLDER.Location = New System.Drawing.Point(133, 161)
        Me.DRFOLDER.Name = "DRFOLDER"
        Me.DRFOLDER.Size = New System.Drawing.Size(222, 26)
        Me.DRFOLDER.TabIndex = 13
        Me.DRFOLDER.Text = Global.Lime.My.MySettings.Default.folder
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
        Me.CHKDR.Location = New System.Drawing.Point(19, 36)
        Me.CHKDR.Name = "CHKDR"
        Me.CHKDR.Size = New System.Drawing.Size(22, 21)
        Me.CHKDR.TabIndex = 10
        Me.CHKDR.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label6.Location = New System.Drawing.Point(15, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "File Name"
        '
        'exename
        '
        Me.exename.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.exename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.exename.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime.My.MySettings.Default, "lexe", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.exename.ForeColor = System.Drawing.Color.Lime
        Me.exename.Location = New System.Drawing.Point(133, 67)
        Me.exename.Name = "exename"
        Me.exename.Size = New System.Drawing.Size(222, 26)
        Me.exename.TabIndex = 1
        Me.exename.Text = Global.Lime.My.MySettings.Default.lexe
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label8.Location = New System.Drawing.Point(15, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Directory"
        '
        'port
        '
        Me.port.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.port.ForeColor = System.Drawing.Color.Lime
        Me.port.Location = New System.Drawing.Point(133, 73)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(222, 26)
        Me.port.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.port)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.host)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox1.Location = New System.Drawing.Point(12, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 136)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label1.Location = New System.Drawing.Point(15, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pastebin URL"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label2.Location = New System.Drawing.Point(15, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port"
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button4.Location = New System.Drawing.Point(12, 703)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(379, 40)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "H E L P"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Builder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(403, 786)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.Color.Coral
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Builder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Builder"
        Me.TopMost = True
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents ANTI_VM As CheckBox
    Friend WithEvents SPUSB As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DRFOLDER As TextBox
    Friend WithEvents DRPATH As ComboBox
    Friend WithEvents CHKDR As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents exename As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents port As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents host As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button4 As Button
End Class
