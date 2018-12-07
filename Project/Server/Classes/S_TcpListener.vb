Imports System.Net
Imports System.Net.Sockets

Public Class S_TcpListener
    Public S As TcpListener
    Public allDone As New Threading.ManualResetEvent(False)

    Async Sub Start(ByVal Port As Integer)
        S = New TcpListener(IPAddress.Any, Port)
        S.Server.ReceiveBufferSize = 1024 * 500
        S.Server.SendBufferSize = 1024 * 500
        S.Server.ReceiveTimeout = -1
        S.Server.ReceiveTimeout = -1
        S.Start()

        While True
            Threading.Thread.Sleep(1)
            If S.Pending Then
                allDone.Reset()
                S.BeginAcceptSocket(New AsyncCallback(AddressOf EndAccept), S)
                allDone.WaitOne()
            End If
        End While

    End Sub

    Sub EndAccept(ByVal ar As IAsyncResult)
        Try
            Dim C As New S_Client(S.EndAcceptSocket(ar))
        Catch ex As Exception
        End Try
        allDone.Set()
    End Sub


End Class