Imports System.Net
Imports System.Net.Sockets

Public Class S_TcpListener
    Public S As TcpListener

    Async Sub Start(ByVal Port As Integer)
        S = New TcpListener(IPAddress.Any, Port)
        S.Server.ReceiveBufferSize = 1024 * 1000
        S.Server.SendBufferSize = 1024 * 1000
        S.Server.ReceiveTimeout = -1
        S.Server.ReceiveTimeout = -1
        S.Start()

        While True
            Await Threading.Tasks.Task.Delay(1)
            If S.Pending Then
                S.BeginAcceptSocket(New AsyncCallback(AddressOf EndAccept), Nothing)
            End If
        End While

    End Sub

    Sub EndAccept(ByVal ar As IAsyncResult)
        Try
            Dim C As New S_Client(S.EndAcceptSocket(ar))
        Catch ex As Exception
        End Try
    End Sub


End Class