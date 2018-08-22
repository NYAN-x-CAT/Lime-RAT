Module FUNC
    Function GTV(ByVal n As String) As String ' Get value in my Registry Key RG
        Try
            Return Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & Main.HWID).GetValue(n, "")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function STV(ByVal n As String, ByVal t As String) ' set value in my Registry Key RG
        Try
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & Main.HWID).SetValue(n, t)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
