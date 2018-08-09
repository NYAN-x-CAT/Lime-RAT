Namespace Lime

    Public Class C_Encryption
        Public Shared Function AES_Encrypt(ByVal input As String)
            Dim AES As New Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""
            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(SB(C_Settings.EncryptionKey))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)
                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB
                Dim DESEncrypter As Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
                Dim Buffer As Byte() = SB(input)
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                Return encrypted
            Catch ex As Exception
            End Try
        End Function

        Public Shared Function AES_Decrypt(ByVal input As String)
            Dim AES As New Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New Security.Cryptography.MD5CryptoServiceProvider
            Dim decrypted As String = ""
            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(SB(C_Settings.EncryptionKey))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)
                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB
                Dim DESDecrypter As Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
                Dim Buffer As Byte() = Convert.FromBase64String(input)
                decrypted = BS(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                Return decrypted
            Catch ex As Exception
            End Try
        End Function

    End Class

End Namespace

