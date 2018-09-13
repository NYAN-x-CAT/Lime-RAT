<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OnConnect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OnConnect))
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.btnUpdateStart = New MetroFramework.Controls.MetroButton()
        Me.btnUpdateStop = New MetroFramework.Controls.MetroButton()
        Me.txtPing = New MetroFramework.Controls.MetroLabel()
        Me.barPing = New MetroFramework.Controls.MetroTrackBar()
        Me.MetroTile2 = New MetroFramework.Controls.MetroTile()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.chkPWD = New MetroFramework.Controls.MetroCheckBox()
        Me.chkDE = New MetroFramework.Controls.MetroCheckBox()
        Me.CHKXMR = New MetroFramework.Controls.MetroCheckBox()
        Me.chkPers = New MetroFramework.Controls.MetroCheckBox()
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
        Me.MetroLabel1.Location = New System.Drawing.Point(23, 113)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(133, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Auto Update Clients :"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroTile1
        '
        Me.MetroTile1.Location = New System.Drawing.Point(23, 256)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(441, 10)
        Me.MetroTile1.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroTile1.TabIndex = 1
        Me.MetroTile1.Text = "  "
        Me.MetroTile1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'btnUpdateStart
        '
        Me.btnUpdateStart.Location = New System.Drawing.Point(23, 175)
        Me.btnUpdateStart.Name = "btnUpdateStart"
        Me.btnUpdateStart.Size = New System.Drawing.Size(133, 42)
        Me.btnUpdateStart.Style = MetroFramework.MetroColorStyle.Lime
        Me.btnUpdateStart.TabIndex = 2
        Me.btnUpdateStart.Text = "START"
        Me.btnUpdateStart.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'btnUpdateStop
        '
        Me.btnUpdateStop.Location = New System.Drawing.Point(216, 175)
        Me.btnUpdateStop.Name = "btnUpdateStop"
        Me.btnUpdateStop.Size = New System.Drawing.Size(133, 42)
        Me.btnUpdateStop.Style = MetroFramework.MetroColorStyle.Lime
        Me.btnUpdateStop.TabIndex = 3
        Me.btnUpdateStop.Text = "STOP"
        Me.btnUpdateStop.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'txtPing
        '
        Me.txtPing.AutoSize = True
        Me.txtPing.Location = New System.Drawing.Point(23, 309)
        Me.txtPing.Name = "txtPing"
        Me.txtPing.Size = New System.Drawing.Size(138, 19)
        Me.txtPing.Style = MetroFramework.MetroColorStyle.Lime
        Me.txtPing.TabIndex = 4
        Me.txtPing.Text = "Ping All Clients Every :"
        Me.txtPing.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'barPing
        '
        Me.barPing.BackColor = System.Drawing.Color.Transparent
        Me.barPing.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Lime_RAT.My.MySettings.Default, "PING_VALUE", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.barPing.Location = New System.Drawing.Point(71, 363)
        Me.barPing.Minimum = 10
        Me.barPing.Name = "barPing"
        Me.barPing.Size = New System.Drawing.Size(329, 23)
        Me.barPing.Style = MetroFramework.MetroColorStyle.Lime
        Me.barPing.TabIndex = 5
        Me.barPing.Text = "MetroTrackBar1"
        Me.barPing.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.barPing.Value = Global.Lime_RAT.My.MySettings.Default.PING_VALUE
        '
        'MetroTile2
        '
        Me.MetroTile2.Location = New System.Drawing.Point(23, 424)
        Me.MetroTile2.Name = "MetroTile2"
        Me.MetroTile2.Size = New System.Drawing.Size(441, 10)
        Me.MetroTile2.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroTile2.TabIndex = 1
        Me.MetroTile2.Text = "  "
        Me.MetroTile2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(23, 478)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(73, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Lime
        Me.MetroLabel3.TabIndex = 6
        Me.MetroLabel3.Text = "Auto Task :"
        Me.MetroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'chkPWD
        '
        Me.chkPWD.AutoSize = True
        Me.chkPWD.Location = New System.Drawing.Point(23, 518)
        Me.chkPWD.Name = "chkPWD"
        Me.chkPWD.Size = New System.Drawing.Size(111, 15)
        Me.chkPWD.Style = MetroFramework.MetroColorStyle.Lime
        Me.chkPWD.TabIndex = 7
        Me.chkPWD.Text = "Passowrd Stealer"
        Me.chkPWD.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chkPWD.UseVisualStyleBackColor = True
        '
        'chkDE
        '
        Me.chkDE.AutoSize = True
        Me.chkDE.Location = New System.Drawing.Point(23, 549)
        Me.chkDE.Name = "chkDE"
        Me.chkDE.Size = New System.Drawing.Size(143, 15)
        Me.chkDE.Style = MetroFramework.MetroColorStyle.Lime
        Me.chkDE.TabIndex = 8
        Me.chkDE.Text = "Download and Execute"
        Me.chkDE.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chkDE.UseVisualStyleBackColor = True
        '
        'CHKXMR
        '
        Me.CHKXMR.AutoSize = True
        Me.CHKXMR.Location = New System.Drawing.Point(23, 579)
        Me.CHKXMR.Name = "CHKXMR"
        Me.CHKXMR.Size = New System.Drawing.Size(82, 15)
        Me.CHKXMR.Style = MetroFramework.MetroColorStyle.Lime
        Me.CHKXMR.TabIndex = 9
        Me.CHKXMR.Text = "XMR Miner"
        Me.CHKXMR.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.CHKXMR.UseVisualStyleBackColor = True
        '
        'chkPers
        '
        Me.chkPers.AutoSize = True
        Me.chkPers.Location = New System.Drawing.Point(23, 609)
        Me.chkPers.Name = "chkPers"
        Me.chkPers.Size = New System.Drawing.Size(85, 15)
        Me.chkPers.Style = MetroFramework.MetroColorStyle.Lime
        Me.chkPers.TabIndex = 10
        Me.chkPers.Text = "Persistence "
        Me.chkPers.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chkPers.UseVisualStyleBackColor = True
        '
        'OnConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 669)
        Me.Controls.Add(Me.chkPers)
        Me.Controls.Add(Me.CHKXMR)
        Me.Controls.Add(Me.chkDE)
        Me.Controls.Add(Me.chkPWD)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.barPing)
        Me.Controls.Add(Me.txtPing)
        Me.Controls.Add(Me.btnUpdateStop)
        Me.Controls.Add(Me.btnUpdateStart)
        Me.Controls.Add(Me.MetroTile2)
        Me.Controls.Add(Me.MetroTile1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OnConnect"
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "OnConnect"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents chkDE As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents chkPWD As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents barPing As MetroFramework.Controls.MetroTrackBar
    Friend WithEvents txtPing As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnUpdateStop As MetroFramework.Controls.MetroButton
    Friend WithEvents btnUpdateStart As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroTile2 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents CHKXMR As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents chkPers As MetroFramework.Controls.MetroCheckBox
End Class
