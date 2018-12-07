Imports System.ComponentModel

Public Class Keylogger
    Public M As Main
    Public C As S_Client

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs)
        C.BeginSend("KL")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not C.IsConnected Then
            Me.Close()
        End If
    End Sub

    Private Sub Keylogger_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        C.BeginSend("Close")
    End Sub
End Class