Module Func
    Public Function siz(ByVal Size As String) As String
        If Size.Length < 4 Then
            Return Size & " Bytes"
            Exit Function
        End If
        Dim s As String = Size / 1024
        Dim F As String = " KB"
        Dim ss As Integer
        If InStr(s, ".") > 0 Then
            Dim j As Array = Split(s, ".")
            s = j(0)
            If j(1).ToString.Length > 3 Then
                ss = Mid(j(1), 1, 3)
            Else
                ss = j(1)
            End If
        End If
        If s.Length > 3 Then
            s = s / 1024
            F = " MB"
            If InStr(s, ".") > 0 Then
                Dim j As Array = Split(s, ".")
                s = j(0)
                If j(1).ToString.Length > 3 Then
                    ss = Mid(j(1), 1, 3)
                Else
                    ss = j(1)
                End If
            End If
        End If
        If s.Length > 3 Then
            s = s / 1024
            F = " GB"
            If InStr(s, ".") > 0 Then
                Dim j As Array = Split(s, ".")
                s = j(0)
                If j(1).ToString.Length > 3 Then
                    ss = Mid(j(1), 1, 3)
                Else
                    ss = j(1)
                End If
            End If
        End If
        Return s & "." & ss & F
    End Function
    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function
    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function
    Function fx(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
        Dim a As New List(Of Byte())
        Dim M As New IO.MemoryStream
        Dim MM As New IO.MemoryStream
        Dim T As String() = Split(BS(b), WRD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function
End Module
