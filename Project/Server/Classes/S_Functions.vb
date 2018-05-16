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
            Return ""
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
        Return Text.Encoding.Default.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return Text.Encoding.Default.GetString(b)
    End Function

    Function fx(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
        Dim a As New List(Of Byte())
        Dim M As New MemoryStream
        Dim MM As New MemoryStream
        Dim T As String() = Split(BS(b), WRD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length))
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

End Module
