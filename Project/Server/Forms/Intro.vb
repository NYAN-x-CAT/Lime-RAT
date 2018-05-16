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
                IO.File.WriteAllBytes(Application.StartupPath & "\Misc\GIO.dat", My.Resources.GIO)
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

#If DEBUG Then
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
    End Sub
End Class