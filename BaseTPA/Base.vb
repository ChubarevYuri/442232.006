Module Base
    Public ReadOnly setting As TPA.Ini = New TPA.Ini()
    Public ReadOnly users As TPA.Ini = New TPA.Ini("user")
    Public ReadOnly devices As TPA.Ini = New TPA.Ini("device")
    Public ReadOnly reports As TPA.Ini = New TPA.Ini("report")

    Public Const doubleformat As String = "#0.0"
    ''' <summary>
    ''' Считывает время ожидания операции
    ''' </summary>
    ''' <param name="_step"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadTimeToSleep(ByVal _step As Steps) As Integer
        Dim val As String
        Select Case _step
            Case Steps.Start
                val = "Start"
            Case Steps.UIWait
                val = "UIWait"
            Case Steps.UIcontrol
                val = "UIcontrol"
            Case Steps.RWait
                val = "RWait"
            Case Steps.Rcontrol
                val = "Rcontrol"
            Case Steps.Result
                val = "Result"
            Case Steps.MechanicalControl
                val = "MechanicalControl"
            Case Else
                val = ""
        End Select
        Try
            ReadTimeToSleep = Convert.ToInt32(setting.Read("ТАЙМЕР", val)) * 60
        Catch ex As Exception
            ReadTimeToSleep = 600
        End Try
        If ReadTimeToSleep <= 0 Then ReadTimeToSleep = 600
    End Function

    Public Enum Steps
        Sleep
        Start
        UIWait
        UIcontrol
        RWait
        Rcontrol
        MechanicalControl
        Result
    End Enum

    Public Structure coltrolStruct
        Public R As Boolean
        Public РастворКонтактов As Boolean
        Public ПровалКонтактов As Boolean
        Public НажатиеНач As Boolean
        Public НажатиеКон As Boolean
        Public Состояние As Boolean
    End Structure

#Region "Rобр"
    Public ReadOnly Property Rобр1() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр1"))
            Catch ex As Exception
                Return 100.51
            End Try
        End Get
    End Property

    Public ReadOnly Property Rобр2() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр2"))
            Catch ex As Exception
                Return 998
            End Try
        End Get
    End Property

    Public ReadOnly Property Rобр3() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр3"))
            Catch ex As Exception
                Return 10030
            End Try
        End Get
    End Property

    Public ReadOnly Property Rобр4() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр4"))
            Catch ex As Exception
                Return 99767
            End Try
        End Get
    End Property
#End Region
End Module
