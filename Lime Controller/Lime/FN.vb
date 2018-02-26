Public Class FN
    Public Shared Function GS(ByVal B() As Byte) As String
        Return Text.Encoding.Default.GetString(B)
    End Function

    Public Shared Function GB(ByVal S As String) As Byte()
        Return Text.Encoding.Default.GetBytes(S)
    End Function
End Class
