Imports System.ComponentModel
Imports WMPLib
Public Class About
    Dim WithEvents Player As New WMPLib.WindowsMediaPlayer

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Player.settings.setMode("Loop", True)
            Player.URL = "https://content-na.drive.amazonaws.com/v2/download/presigned/5ujSnRHmaF6f3B0VjagP_7lcSdDX-5Z051xMafyGRMUeJxFPc?download=true"
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