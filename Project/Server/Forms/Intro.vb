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
        '  S_Settings.PORT = 8989
        S_Settings.EncryptionKey = "NYANCAT"
        Main.Show()
        Hide()
#Else
        Try
            If S_Settings.PORT.Count > 0 AndAlso MetroTextBox2.Text <> String.Empty Then
                S_Settings.EncryptionKey = MetroTextBox2.Text
                My.Settings.Save()
                Main.Show()
                Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
#End If

        Try
            Dim myWriter As New IO.StreamWriter("MISC/PORTS.dat")
            For Each i In S_Settings.PORT.ToList
                myWriter.WriteLine(i)
            Next
            myWriter.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "LimeRAT @" + Environment.UserName

        Try
            If IO.File.Exists("MISC/PORTS.dat") Then
                Dim TheList() As String = IO.File.ReadAllLines("MISC/PORTS.dat")
                For Each line As String In TheList
                    S_Settings.PORT.Add(line)
                    ListBox1.Items.Add(line)
                Next
            End If
        Catch ex As Exception
        End Try

        Try
            If GTV("READPORTMSG") = Nothing Then
                MsgBox("New PORT system. You need to create 1 pastebin and insert you ports like this  127.0.0.1:8989:7878:5656", MsgBoxStyle.Information)
                STV("READPORTMSG", "1")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            If Not S_Settings.PORT.Contains(MetroTextBox1.Text) AndAlso MetroTextBox1.Text <= 65535 Then
                ListBox1.Items.Add(MetroTextBox1.Text)
                S_Settings.PORT.Add(MetroTextBox1.Text)
                MetroTextBox1.Text = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            For Each item In ListBox1.SelectedItems
                ListBox1.Items.Remove(item)
                S_Settings.PORT.Remove(item)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class