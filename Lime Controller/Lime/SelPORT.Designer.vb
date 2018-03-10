<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelPORT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelPORT))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChButton2 = New Lime.CHButton()
        Me.ChSeparator1 = New Lime.CHSeparator()
        Me.ChButton1 = New Lime.CHButton()
        Me.ChTextbox1 = New Lime.CHTextbox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(28, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PORT "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(85, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 24)
        Me.Label1.TabIndex = 5
        '
        'ChButton2
        '
        Me.ChButton2.Customization = "AGQA/wD/AP8AgAD/"
        Me.ChButton2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton2.Image = Nothing
        Me.ChButton2.Location = New System.Drawing.Point(220, 193)
        Me.ChButton2.Name = "ChButton2"
        Me.ChButton2.NoRounding = False
        Me.ChButton2.Size = New System.Drawing.Size(152, 40)
        Me.ChButton2.TabIndex = 2
        Me.ChButton2.Text = "Exit"
        Me.ChButton2.Transparent = False
        '
        'ChSeparator1
        '
        Me.ChSeparator1.Colors = New Lime.Bloom(-1) {}
        Me.ChSeparator1.Customization = ""
        Me.ChSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChSeparator1.Image = Nothing
        Me.ChSeparator1.Location = New System.Drawing.Point(12, 60)
        Me.ChSeparator1.Name = "ChSeparator1"
        Me.ChSeparator1.NoRounding = False
        Me.ChSeparator1.Size = New System.Drawing.Size(376, 23)
        Me.ChSeparator1.TabIndex = 7
        Me.ChSeparator1.Text = "ChSeparator1"
        Me.ChSeparator1.Transparent = False
        '
        'ChButton1
        '
        Me.ChButton1.Customization = "AGQA/wD/AP8AgAD/"
        Me.ChButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton1.Image = Nothing
        Me.ChButton1.Location = New System.Drawing.Point(33, 193)
        Me.ChButton1.Name = "ChButton1"
        Me.ChButton1.NoRounding = False
        Me.ChButton1.Size = New System.Drawing.Size(152, 40)
        Me.ChButton1.TabIndex = 1
        Me.ChButton1.Text = "Start"
        Me.ChButton1.Transparent = False
        '
        'ChTextbox1
        '
        Me.ChTextbox1.BackColor = System.Drawing.Color.Transparent
        Me.ChTextbox1.Colors = New Lime.Bloom(-1) {}
        Me.ChTextbox1.Customization = ""
        Me.ChTextbox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChTextbox1.Image = Nothing
        Me.ChTextbox1.Location = New System.Drawing.Point(100, 125)
        Me.ChTextbox1.MaxCharacters = 0
        Me.ChTextbox1.Name = "ChTextbox1"
        Me.ChTextbox1.NoRounding = False
        Me.ChTextbox1.Size = New System.Drawing.Size(272, 25)
        Me.ChTextbox1.TabIndex = 0
        Me.ChTextbox1.Transparent = True
        Me.ChTextbox1.UsePasswordMask = False
        '
        'SelPORT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(400, 300)
        Me.Controls.Add(Me.ChButton2)
        Me.Controls.Add(Me.ChSeparator1)
        Me.Controls.Add(Me.ChButton1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChTextbox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 300)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "SelPORT"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelPORT"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChButton1 As CHButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ChTextbox1 As CHTextbox
    Friend WithEvents ChSeparator1 As CHSeparator
    Friend WithEvents ChButton2 As CHButton
End Class
