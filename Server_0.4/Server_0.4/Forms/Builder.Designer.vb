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
        Me.ChGroupBox3 = New Server_0._4.CHGroupBox()
        Me.USB = New Server_0._4.CHCheckbox()
        Me.ChButton1 = New Server_0._4.CHButton()
        Me.ChGroupBox2 = New Server_0._4.CHGroupBox()
        Me.DROP = New Server_0._4.CHOnOffBox()
        Me.PATH2 = New Server_0._4.CHTextbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PATH1 = New Server_0._4.CHCombobox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EXE = New Server_0._4.CHTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChGroupBox1 = New Server_0._4.CHGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PORT = New Server_0._4.CHTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HOST = New Server_0._4.CHTextbox()
        Me.ANTI = New Server_0._4.CHCheckbox()
        Me.ChGroupBox3.SuspendLayout()
        Me.ChGroupBox2.SuspendLayout()
        Me.ChGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChGroupBox3
        '
        Me.ChGroupBox3.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox3.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox3.Controls.Add(Me.ANTI)
        Me.ChGroupBox3.Controls.Add(Me.USB)
        Me.ChGroupBox3.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox3.Image = Nothing
        Me.ChGroupBox3.Location = New System.Drawing.Point(12, 454)
        Me.ChGroupBox3.Movable = True
        Me.ChGroupBox3.Name = "ChGroupBox3"
        Me.ChGroupBox3.NoRounding = False
        Me.ChGroupBox3.Sizable = True
        Me.ChGroupBox3.Size = New System.Drawing.Size(371, 151)
        Me.ChGroupBox3.SmartBounds = True
        Me.ChGroupBox3.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox3.TabIndex = 6
        Me.ChGroupBox3.Text = "MISC"
        Me.ChGroupBox3.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox3.Transparent = False
        '
        'USB
        '
        Me.USB.BackColor = System.Drawing.Color.Transparent
        Me.USB.Checked = False
        Me.USB.ForeColor = System.Drawing.Color.Black
        Me.USB.Location = New System.Drawing.Point(19, 62)
        Me.USB.Name = "USB"
        Me.USB.Size = New System.Drawing.Size(214, 14)
        Me.USB.TabIndex = 7
        Me.USB.Text = "USB Spread"
        '
        'ChButton1
        '
        Me.ChButton1.Customization = "AGQA/wD/AP8AgAD/"
        Me.ChButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton1.Image = Nothing
        Me.ChButton1.Location = New System.Drawing.Point(12, 642)
        Me.ChButton1.Name = "ChButton1"
        Me.ChButton1.NoRounding = False
        Me.ChButton1.Size = New System.Drawing.Size(371, 76)
        Me.ChButton1.TabIndex = 5
        Me.ChButton1.Text = "B u i l d"
        Me.ChButton1.Transparent = False
        '
        'ChGroupBox2
        '
        Me.ChGroupBox2.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox2.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox2.Controls.Add(Me.DROP)
        Me.ChGroupBox2.Controls.Add(Me.PATH2)
        Me.ChGroupBox2.Controls.Add(Me.Label5)
        Me.ChGroupBox2.Controls.Add(Me.PATH1)
        Me.ChGroupBox2.Controls.Add(Me.Label3)
        Me.ChGroupBox2.Controls.Add(Me.EXE)
        Me.ChGroupBox2.Controls.Add(Me.Label4)
        Me.ChGroupBox2.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox2.Image = Nothing
        Me.ChGroupBox2.Location = New System.Drawing.Point(12, 189)
        Me.ChGroupBox2.Movable = True
        Me.ChGroupBox2.Name = "ChGroupBox2"
        Me.ChGroupBox2.NoRounding = False
        Me.ChGroupBox2.Sizable = True
        Me.ChGroupBox2.Size = New System.Drawing.Size(371, 241)
        Me.ChGroupBox2.SmartBounds = True
        Me.ChGroupBox2.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox2.TabIndex = 4
        Me.ChGroupBox2.Text = "Persistence"
        Me.ChGroupBox2.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox2.Transparent = False
        '
        'DROP
        '
        Me.DROP.Checked = False
        Me.DROP.Location = New System.Drawing.Point(19, 42)
        Me.DROP.MaximumSize = New System.Drawing.Size(56, 24)
        Me.DROP.MinimumSize = New System.Drawing.Size(56, 24)
        Me.DROP.Name = "DROP"
        Me.DROP.Size = New System.Drawing.Size(56, 24)
        Me.DROP.TabIndex = 6
        Me.DROP.Text = "ChOnOffBox1"
        '
        'PATH2
        '
        Me.PATH2.BackColor = System.Drawing.Color.Transparent
        Me.PATH2.Colors = New Server_0._4.Bloom(-1) {}
        Me.PATH2.Customization = ""
        Me.PATH2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "path2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PATH2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PATH2.Image = Nothing
        Me.PATH2.Location = New System.Drawing.Point(112, 175)
        Me.PATH2.MaxCharacters = 0
        Me.PATH2.Name = "PATH2"
        Me.PATH2.NoRounding = False
        Me.PATH2.Size = New System.Drawing.Size(241, 25)
        Me.PATH2.TabIndex = 0
        Me.PATH2.Text = Global.Server_0._4.My.MySettings.Default.path2
        Me.PATH2.Transparent = True
        Me.PATH2.UsePasswordMask = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(16, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Sub Folder"
        '
        'PATH1
        '
        Me.PATH1.BackColor = System.Drawing.Color.Black
        Me.PATH1.BaseColour = System.Drawing.Color.Black
        Me.PATH1.BorderColour = System.Drawing.Color.DarkGreen
        Me.PATH1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.PATH1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PATH1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.PATH1.FontColour = System.Drawing.Color.Lime
        Me.PATH1.FormattingEnabled = True
        Me.PATH1.Items.AddRange(New Object() {"AppData", "Temp", "UserProfile"})
        Me.PATH1.Location = New System.Drawing.Point(112, 133)
        Me.PATH1.Name = "PATH1"
        Me.PATH1.Size = New System.Drawing.Size(176, 29)
        Me.PATH1.StartIndex = 0
        Me.PATH1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(16, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "File Name"
        '
        'EXE
        '
        Me.EXE.BackColor = System.Drawing.Color.Transparent
        Me.EXE.Colors = New Server_0._4.Bloom(-1) {}
        Me.EXE.Customization = ""
        Me.EXE.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "exe", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.EXE.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EXE.Image = Nothing
        Me.EXE.Location = New System.Drawing.Point(112, 86)
        Me.EXE.MaxCharacters = 0
        Me.EXE.Name = "EXE"
        Me.EXE.NoRounding = False
        Me.EXE.Size = New System.Drawing.Size(240, 25)
        Me.EXE.TabIndex = 2
        Me.EXE.Text = Global.Server_0._4.My.MySettings.Default.exe
        Me.EXE.Transparent = True
        Me.EXE.UsePasswordMask = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(16, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Directory"
        '
        'ChGroupBox1
        '
        Me.ChGroupBox1.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox1.Controls.Add(Me.Label2)
        Me.ChGroupBox1.Controls.Add(Me.PORT)
        Me.ChGroupBox1.Controls.Add(Me.Label1)
        Me.ChGroupBox1.Controls.Add(Me.HOST)
        Me.ChGroupBox1.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox1.Image = Nothing
        Me.ChGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.ChGroupBox1.Movable = True
        Me.ChGroupBox1.Name = "ChGroupBox1"
        Me.ChGroupBox1.NoRounding = False
        Me.ChGroupBox1.Sizable = True
        Me.ChGroupBox1.Size = New System.Drawing.Size(371, 152)
        Me.ChGroupBox1.SmartBounds = True
        Me.ChGroupBox1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox1.TabIndex = 3
        Me.ChGroupBox1.Text = "Connection"
        Me.ChGroupBox1.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox1.Transparent = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(17, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "PORT"
        '
        'PORT
        '
        Me.PORT.BackColor = System.Drawing.Color.Transparent
        Me.PORT.Colors = New Server_0._4.Bloom(-1) {}
        Me.PORT.Customization = ""
        Me.PORT.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PORT.Image = Nothing
        Me.PORT.Location = New System.Drawing.Point(85, 86)
        Me.PORT.MaxCharacters = 0
        Me.PORT.Name = "PORT"
        Me.PORT.NoRounding = False
        Me.PORT.Size = New System.Drawing.Size(124, 25)
        Me.PORT.TabIndex = 2
        Me.PORT.Text = "8989"
        Me.PORT.Transparent = True
        Me.PORT.UsePasswordMask = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(16, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP"
        '
        'HOST
        '
        Me.HOST.BackColor = System.Drawing.Color.Transparent
        Me.HOST.Colors = New Server_0._4.Bloom(-1) {}
        Me.HOST.Customization = ""
        Me.HOST.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Server_0._4.My.MySettings.Default, "host", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HOST.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HOST.Image = Nothing
        Me.HOST.Location = New System.Drawing.Point(84, 40)
        Me.HOST.MaxCharacters = 0
        Me.HOST.Name = "HOST"
        Me.HOST.NoRounding = False
        Me.HOST.Size = New System.Drawing.Size(268, 25)
        Me.HOST.TabIndex = 0
        Me.HOST.Text = Global.Server_0._4.My.MySettings.Default.host
        Me.HOST.Transparent = True
        Me.HOST.UsePasswordMask = False
        '
        'ANTI
        '
        Me.ANTI.BackColor = System.Drawing.Color.Transparent
        Me.ANTI.Checked = False
        Me.ANTI.ForeColor = System.Drawing.Color.Black
        Me.ANTI.Location = New System.Drawing.Point(19, 106)
        Me.ANTI.Name = "ANTI"
        Me.ANTI.Size = New System.Drawing.Size(214, 14)
        Me.ANTI.TabIndex = 8
        Me.ANTI.Text = "Anti Virtual Machine"
        '
        'Builder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(395, 782)
        Me.Controls.Add(Me.ChGroupBox3)
        Me.Controls.Add(Me.ChButton1)
        Me.Controls.Add(Me.ChGroupBox2)
        Me.Controls.Add(Me.ChGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Builder"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Builder | Lime Worm"
        Me.TopMost = True
        Me.ChGroupBox3.ResumeLayout(False)
        Me.ChGroupBox2.ResumeLayout(False)
        Me.ChGroupBox2.PerformLayout()
        Me.ChGroupBox1.ResumeLayout(False)
        Me.ChGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HOST As CHTextbox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChGroupBox1 As CHGroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PORT As CHTextbox
    Friend WithEvents ChGroupBox2 As CHGroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PATH1 As CHCombobox
    Friend WithEvents Label3 As Label
    Friend WithEvents EXE As CHTextbox
    Friend WithEvents Label4 As Label
    Friend WithEvents PATH2 As CHTextbox
    Friend WithEvents ChButton1 As CHButton
    Friend WithEvents DROP As CHOnOffBox
    Friend WithEvents ChGroupBox3 As CHGroupBox
    Friend WithEvents USB As CHCheckbox
    Friend WithEvents ANTI As CHCheckbox
End Class
