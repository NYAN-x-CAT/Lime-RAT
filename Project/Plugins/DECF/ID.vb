
Public Class C_ID

        Public Shared Function Bot()
            Try
                Return UserName() & "_" & HWID()
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Public Shared Function UserName()
            Try
                Return Environment.UserName
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Public Shared Function HWID() As String
            Try
                Dim tohash As String = Identifier("Win32_Processor", "ProcessorId")
                tohash += "-" & Identifier("Win32_BIOS", "SerialNumber")
                tohash += "-" & Identifier("Win32_BaseBoard", "SerialNumber")
                tohash += "-" & Identifier("Win32_VideoController", "Name")
                Return MD5HASH(tohash)
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

        Private Shared Function Identifier(ByVal wmiClass As String, ByVal wmiProperty As String) As String
            Try
                Dim result As String = ""
                Dim mc As Management.ManagementClass = New Management.ManagementClass(wmiClass)
                Dim moc As Management.ManagementObjectCollection = mc.GetInstances()
                For Each mo As Management.ManagementObject In moc
                    If result = "" Then
                        Try
                            result = mo(wmiProperty).ToString()
                            Exit For
                        Catch
                        End Try
                    End If
                Next
                Return result
            Catch ex As Exception
                Return "Error"
            End Try
        End Function

    Public Shared Function MD5HASH(ByVal input As String) As String
        Try
            Dim md5 As Security.Cryptography.MD5CryptoServiceProvider = New Security.Cryptography.MD5CryptoServiceProvider()
            Dim temp As Byte() = md5.ComputeHash(Text.Encoding.UTF8.GetBytes(input))
            Dim sb As Text.StringBuilder = New Text.StringBuilder()
            For i As Integer = 10 To temp.Length - 1
                sb.Append(temp(i).ToString("x2"))
            Next
            Return sb.ToString().ToUpper()
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function Privileges() As Boolean
        Try
            Dim id As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
            Dim p As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(id)
            If p.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
