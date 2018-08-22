Namespace Lime

    Public Class C_Nosleep

        'https://www.codeproject.com/Articles/290253/Give-your-computer-Sleep-Apnea-Dont-let-it-go-to-s
        Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esflags As EXECUTION_STATE) As EXECUTION_STATE
        Enum EXECUTION_STATE
            ES_SYSTEM_REQUIRED = &H1
            ES_DISPLAY_REQUIRED = &H2
            ES_CONTINUOUS = &H80000000
        End Enum
        ' Call API - force no sleep and no display turn off
        Public Shared Function No_Sleep() As EXECUTION_STATE
            Return SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or
       EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_DISPLAY_REQUIRED)
        End Function

    End Class


End Namespace