Imports System.ComponentModel
Imports WMPLib
Public Class About
    Dim WithEvents Player As New WMPLib.WindowsMediaPlayer

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim FN = IO.Path.GetTempPath + "\LimeRAT-MUSIC.MP3"
            If IO.File.Exists(FN) Then GoTo 1
            Dim WC As New Net.WebClient
            Dim O = WC.DownloadString("https://pastebin.com/raw/34Gqdu7K")
            Try : IO.File.WriteAllBytes(FN, Convert.FromBase64String(O)) : Catch : End Try
1:
            Player.settings.setMode("Loop", True)
            Player.URL = FN
        Catch ex As Exception
        End Try
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
        BackgroundWorker1.WorkerSupportsCancellation = True
    End Sub

    Private Sub About_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        BackgroundWorker1.CancelAsync()
        BackgroundWorker1.Dispose()
        Player.close()
    End Sub
End Class