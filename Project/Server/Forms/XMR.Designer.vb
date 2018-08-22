<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XMR
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
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.txtPASS = New MetroFramework.Controls.MetroTextBox()
        Me.txtUSER = New MetroFramework.Controls.MetroTextBox()
        Me.txtCPU = New MetroFramework.Controls.MetroTextBox()
        Me.txtURL = New MetroFramework.Controls.MetroTextBox()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.chk = New MetroFramework.Controls.MetroCheckBox()
        Me.chkPass = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Me
        Me.MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel1.Location = New System.Drawing.Point(43, 130)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(62, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Threads"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.MetroLabel1, "set process priority (0 idle, 2 normal to 5 highest)")
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel2.Location = New System.Drawing.Point(43, 206)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(35, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "URL"
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.MetroLabel2, "URL of mining server")
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel3.Location = New System.Drawing.Point(43, 284)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(76, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel3.TabIndex = 4
        Me.MetroLabel3.Text = "Username"
        Me.MetroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.MetroLabel3, "username for mining server")
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel4.Location = New System.Drawing.Point(43, 363)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(73, 19)
        Me.MetroLabel4.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel4.TabIndex = 12
        Me.MetroLabel4.Text = "Password"
        Me.MetroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.MetroLabel4, "username for mining server")
        '
        'txtPASS
        '
        Me.txtPASS.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime_RAT.My.MySettings.Default, "xmrpass", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtPASS.Enabled = False
        Me.txtPASS.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtPASS.FontWeight = MetroFramework.MetroTextBoxWeight.Light
        Me.txtPASS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPASS.Location = New System.Drawing.Point(184, 363)
        Me.txtPASS.Name = "txtPASS"
        Me.txtPASS.Size = New System.Drawing.Size(349, 36)
        Me.txtPASS.Style = MetroFramework.MetroColorStyle.Lime
        Me.txtPASS.TabIndex = 13
        Me.txtPASS.Text = Global.Lime_RAT.My.MySettings.Default.xmrpass
        Me.txtPASS.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.txtPASS, "username for mining server")
        '
        'txtUSER
        '
        Me.txtUSER.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime_RAT.My.MySettings.Default, "xmruser", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtUSER.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtUSER.FontWeight = MetroFramework.MetroTextBoxWeight.Light
        Me.txtUSER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtUSER.Location = New System.Drawing.Point(184, 284)
        Me.txtUSER.Name = "txtUSER"
        Me.txtUSER.Size = New System.Drawing.Size(543, 36)
        Me.txtUSER.Style = MetroFramework.MetroColorStyle.Lime
        Me.txtUSER.TabIndex = 11
        Me.txtUSER.Text = Global.Lime_RAT.My.MySettings.Default.xmruser
        Me.txtUSER.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.txtUSER, "username for mining server")
        '
        'txtCPU
        '
        Me.txtCPU.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime_RAT.My.MySettings.Default, "xmrcpu", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtCPU.Enabled = False
        Me.txtCPU.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtCPU.FontWeight = MetroFramework.MetroTextBoxWeight.Light
        Me.txtCPU.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCPU.Location = New System.Drawing.Point(184, 130)
        Me.txtCPU.Name = "txtCPU"
        Me.txtCPU.Size = New System.Drawing.Size(56, 36)
        Me.txtCPU.Style = MetroFramework.MetroColorStyle.Lime
        Me.txtCPU.TabIndex = 10
        Me.txtCPU.Text = Global.Lime_RAT.My.MySettings.Default.xmrcpu
        Me.txtCPU.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.txtCPU, "number of miner threads")
        '
        'txtURL
        '
        Me.txtURL.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Lime_RAT.My.MySettings.Default, "xmrurl", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtURL.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtURL.FontWeight = MetroFramework.MetroTextBoxWeight.Light
        Me.txtURL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtURL.Location = New System.Drawing.Point(184, 206)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(543, 36)
        Me.txtURL.Style = MetroFramework.MetroColorStyle.Lime
        Me.txtURL.TabIndex = 9
        Me.txtURL.Text = Global.Lime_RAT.My.MySettings.Default.xmrurl
        Me.txtURL.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroToolTip1.SetToolTip(Me.txtURL, "URL of mining server")
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(168, 499)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(191, 45)
        Me.MetroButton1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroButton1.TabIndex = 6
        Me.MetroButton1.Text = "Send Miner"
        Me.MetroButton1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(536, 499)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(191, 45)
        Me.MetroButton2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroButton2.TabIndex = 7
        Me.MetroButton2.Text = "Kill Current Miner"
        Me.MetroButton2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'chk
        '
        Me.chk.AutoSize = True
        Me.chk.Checked = True
        Me.chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk.FontSize = MetroFramework.MetroLinkSize.Medium
        Me.chk.FontWeight = MetroFramework.MetroLinkWeight.Bold
        Me.chk.Location = New System.Drawing.Point(285, 130)
        Me.chk.Name = "chk"
        Me.chk.Size = New System.Drawing.Size(53, 19)
        Me.chk.Style = MetroFramework.MetroColorStyle.Lime
        Me.chk.TabIndex = 8
        Me.chk.Text = "50%"
        Me.chk.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chk.UseVisualStyleBackColor = True
        '
        'chkPass
        '
        Me.chkPass.AutoSize = True
        Me.chkPass.Checked = True
        Me.chkPass.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPass.FontSize = MetroFramework.MetroLinkSize.Medium
        Me.chkPass.FontWeight = MetroFramework.MetroLinkWeight.Bold
        Me.chkPass.Location = New System.Drawing.Point(567, 363)
        Me.chkPass.Name = "chkPass"
        Me.chkPass.Size = New System.Drawing.Size(160, 19)
        Me.chkPass.Style = MetroFramework.MetroColorStyle.Lime
        Me.chkPass.TabIndex = 14
        Me.chkPass.Text = "Use Client ID as pwd"
        Me.chkPass.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chkPass.UseVisualStyleBackColor = True
        '
        'MetroPanel1
        '
        Me.MetroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(23, 100)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(834, 481)
        Me.MetroPanel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroPanel1.TabIndex = 15
        Me.MetroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'XMR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 604)
        Me.Controls.Add(Me.chkPass)
        Me.Controls.Add(Me.txtPASS)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.txtUSER)
        Me.Controls.Add(Me.txtCPU)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.chk)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Name = "XMR"
        Me.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.SystemShadow
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "XMR CPU Mining"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents chk As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents txtCPU As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtURL As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtUSER As MetroFramework.Controls.MetroTextBox
    Friend WithEvents chkPass As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents txtPASS As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
End Class
