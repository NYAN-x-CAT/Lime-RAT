Public Class Intro

#Region "Sub New"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try

            If Not IO.Directory.Exists(Application.StartupPath + "\Misc") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\Misc")
            End If

            If Not IO.File.Exists(Application.StartupPath & "\Misc\GIO.dat") Then
                IO.File.WriteAllBytes(Application.StartupPath & "\Misc\GeoIP.dat", My.Resources.GeoIP)
            End If

            If Not IO.Directory.Exists(Application.StartupPath + "\Misc" + "\Wallpaper") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\Misc" + "\Wallpaper")
            End If

            If Not IO.File.Exists(Application.StartupPath + "\Misc" + "\Wallpaper" + "\" + "Lime's wallpaper.jpg") Then
                My.Resources.Lime_s_wallpaper.Save(Application.StartupPath + "\Misc" + "\Wallpaper" + "\" + "Lime's wallpaper.jpg", Imaging.ImageFormat.Jpeg)
            End If

            If Not IO.Directory.Exists(Application.StartupPath + "\Misc" + "\Stub") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\Misc" + "\Stub")
            End If

            If Not IO.Directory.Exists(Application.StartupPath + "\Misc" + "\Plugins") Then
                IO.Directory.CreateDirectory(Application.StartupPath + "\Misc" + "\Plugins")
                MsgBox("Missing Plugins!")
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If GTV("Read") <> "1" Then

            Try
                Process.Start(Windows.Forms.Application.StartupPath + "\MISC\Support\Guidance.html")
                STV("Read", "1")
            Catch : End Try
        End If
#If DEBUG Then
        S_Settings.PORT = 8989
        S_Settings.EncryptionKey = "NYANCAT"
        Main.Show()
        Hide()
#Else
        Try
            If MetroTextBox1.Text <> String.Empty AndAlso MetroTextBox2.Text <> String.Empty Then
                S_Settings.PORT = MetroTextBox1.Text
                S_Settings.EncryptionKey = MetroTextBox2.Text
                My.Settings.Save()
                Main.Show()
                Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
#End If
    End Sub

    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "LimeRAT @" + Environment.UserName
        '#If Not DEBUG Then
        '                MsgBox("Beta Tester Version")
        '#End If
    End Sub
End Class