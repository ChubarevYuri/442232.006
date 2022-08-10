Public Class BaseForm

    Private LabelBothHeadText As String() = New String() {"Стенд остановлен", _
                                                          "Начало испытания", _
                                                          "Подготовка", _
                                                          "Выполнение замера", _
                                                          "Подготовка", _
                                                          "Выполнение замера", _
                                                          "Выполните измерения", _
                                                          "Испытание завершено"}
    Private LabelBothBodyText As String() = New String() {"Если начинаете проверку нового устройства, то наж- мите 'Новая'. Для начала проверки нажмите 'Старт'.", _
                                                          "Выберите запрашиваемые параметры.", _
                                                          "Установите щупы для замера тока/напряжения", _
                                                          "Дождитесь завершения замера.", _
                                                          "Отключите щупы для замера тока/напряжения. Установите щупы для замера сопротивления", _
                                                          "Дождитесь завершения замера.", _
                                                          "Отключите щупы. Произведите замер параметров и введите их.", _
                                                          ""}

    Public firstStart As Boolean = True
    Private _operation As Base.Steps = Base.Steps.sleep
    ''' <summary>
    ''' Выполняемая операция
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Operation() As Base.Steps
        Get
            Return _operation
        End Get
        Set(ByVal value As Steps)
            If value <> _operation Then
                TPA.Log.Print(TPA.Rank.OK, "Начат этап " & _operation)
                _operation = value
                TimerPanel1.Start(Base.ReadTimeToSleep(Operation))
                Select Case value
                    Case Steps.Sleep
                        OperationSleep()
                    Case Steps.Start
                        operationStart()
                    Case Steps.UIWait
                        OperationUIWait()
                    Case Steps.UIcontrol
                        OperatonUIControl()
                    Case Steps.RWait
                        OperationRWait()
                    Case Steps.Rcontrol
                        OperatonRControl()
                    Case Steps.MechanicalControl
                        OperationMechanicalControl()
                    Case Steps.Result
                        OperationResult()
                End Select
                ResetElements()
            End If
        End Set
    End Property

#Region "operations"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationSleep()

    End Sub

    ''' <summary>
    ''' при новом испытании опросить имя, устройство, проверяемые параметры и запустить проверку, если что-то не заполнено, то выйти в sleep
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub operationStart()
        If firstStart Then
            Test.device = New Device()
            Test.user = ""
            Test.timeStart = Now
            Servise.UserSelect()
            If Test.user.Length > 0 Then
                Servise.DeviceSelect()
                If Test.device.name.Length > 0 Then
                    Test.device.num = ""
                    TPA.Keyboard.Text(Test.device.num, "Номер аппарата")
                    Dim params As String() = New String() {"Сопротивление блока катушек", _
                                                           "Состояние контактов", _
                                                           "Раствор контактов", _
                                                           "Провал контактов", _
                                                           "Усилие нажатия (начальное)", _
                                                           "Усилие нажатия (конечное)"}
                    Dim bool = TPA.DialogForms.Setting(New Boolean() {True, True, True, True, True, True}, _
                                                       params, _
                                                       "Измеряемые параметры")
                    Dim msgBool As String = ""
                    For j = 0 To bool.Length - 1
                        If bool(j) Then
                            If msgBool.Length > 0 Then msgBool &= "; "
                            msgBool &= params(j)
                        End If
                    Next
                    TPA.Log.Print(TPA.Rank.OK, "Выбрано: " & Test.user & ", " & Test.device.name & " (" & If(msgBool.Length > 0, msgBool, "без параметров") & ")")
                    Dim par As Base.coltrolStruct = New Base.coltrolStruct
                    Test.device.РабочиеПарамерты.R = bool(0)
                    Test.device.РабочиеПарамерты.Состояние = bool(1)
                    Test.device.РабочиеПарамерты.РастворКонтактов = bool(2)
                    Test.device.РабочиеПарамерты.ПровалКонтактов = bool(3)
                    Test.device.РабочиеПарамерты.НажатиеНач = bool(4)
                    Test.device.РабочиеПарамерты.НажатиеКон = bool(5)
                    firstStart = False
                    R = 0
                    U = 0
                    Operation = Steps.UIWait
                Else
                    Operation = Steps.Sleep
                End If
            Else
                Operation = Steps.Sleep
            End If
        Else
            R = 0
            U = 0
            Operation = Steps.UIWait
        End If
    End Sub

    ''' <summary>
    ''' Подготовка проверки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationUIWait()
        Test.A1using = If(Test.device.name.Length > 0 And Test.device.I + Test.device.Ivalid < 9, True, False)
    End Sub

    ''' <summary>
    ''' проверка электрической части
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperatonUIControl()
        Test.U = 0
        uifinish = False
    End Sub

    ''' <summary>
    ''' Подготовка проверки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationRWait()

    End Sub

    ''' <summary>
    ''' проверка сопротивления
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperatonRControl()
        U = 0
        Threading.Thread.Sleep(500)
        Test.RreadStart()
    End Sub

    ''' <summary>
    ''' самостоятельные замеры и их ввод
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationMechanicalControl()
        If Test.device.KontACount > 1 Or Test.device.KontBCount > 1 Then
            If Test.device.РабочиеПарамерты.Состояние Then
                Dim all(Test.device.KontACount + Test.device.KontBCount - 1) As Boolean
                Dim head(Test.device.KontACount + Test.device.KontBCount - 1) As String
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.СостояниеA(i)
                    head(i) = "Контакт силовой № " & i + 1
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.СостояниеB(i - Test.device.KontACount)
                    head(i) = "Контакт вспомогательный № " & i + 1 - Test.device.KontACount
                Next
                all = TPA.DialogForms.Setting(all, head, "Состояние контактов")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.СостояниеA(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.СостояниеA(i - Test.device.KontACount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.РастворКонтактов Then
                Dim all(Test.device.KontACount + Test.device.KontBCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount - 1) As TPA.DialogForms.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.РастворКонтактаAFact(i)
                    head(i) = "Контакт силовой № " & i + 1
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.РастворКонтактаBFact(i - Test.device.KontACount)
                    head(i) = "Контакт вспомогательный № " & i + 1 - Test.device.KontACount
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                all = TPA.DialogForms.Setting(all, head, type, "Растворы контактов")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.РастворКонтактаAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.РастворКонтактаBFact(i - Test.device.KontACount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.ПровалКонтактов Then
                Dim all(Test.device.KontACount + Test.device.KontBCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount - 1) As TPA.DialogForms.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.ПровалКонтактаAFact(i)
                    head(i) = "Контакт силовой № " & i + 1
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.ПровалКонтактаBFact(i - Test.device.KontACount)
                    head(i) = "Контакт вспомогательный № " & i + 1 - Test.device.KontACount
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                all = TPA.DialogForms.Setting(all, head, type, "Провалы контактов")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.ПровалКонтактаAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.ПровалКонтактаBFact(i - Test.device.KontACount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.НажатиеНач Then
                Dim all(Test.device.KontACount + Test.device.KontBCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount - 1) As TPA.DialogForms.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.НажатиеНачAFact(i)
                    head(i) = "Контакт силовой № " & i + 1
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount - 1
                    all(i) = Test.device.НажатиеНачAFact(i - Test.device.KontACount)
                    head(i) = "Контакт вспомогательный № " & i + 1 - Test.device.KontACount
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                all = TPA.DialogForms.Setting(all, head, type, "Усилие нажатия (начальное)")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.НажатиеНачAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.НажатиеНачBFact(i - Test.device.KontACount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.НажатиеКон Then
                Dim all(Test.device.KontACount + Test.device.KontBCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount - 1) As TPA.DialogForms.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.НажатиеКонAFact(i)
                    head(i) = "Контакт силовой № " & i + 1
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.НажатиеКонBFact(i - Test.device.KontACount)
                    head(i) = "Контакт силовой № " & i + 1 - Test.device.KontACount
                    type(i) = TPA.DialogForms.ValueType.ureal
                Next
                all = TPA.DialogForms.Setting(all, head, type, "Усилие нажатия (конечное)")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.НажатиеКонAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.НажатиеКонBFact(i - Test.device.KontACount) = all(i)
                Next
            End If
        End If
        Operation = Steps.Result
    End Sub

    ''' <summary>
    ''' Вывод результата проверки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationResult()
        TPA.DialogForms.WaitFormStart()
        Report.Save(Report.readNum, Test.device, Test.user, Test.timeStart)
        newReport = False
        TPA.DialogForms.WaitFormStop()
        Report.Show(Report.readNum)
        Operation = Steps.Sleep
    End Sub
#End Region

    Dim uifinish As Boolean = False
    Private Sub ResetElements()
        DeviceValueU.Value = Test.U
        DeviceValueI.Value = Test.I.ToString(doubleformat)
        DeviceValueR.Value = Test.R.ToString(doubleformat)
        If Operation = Steps.Sleep And firstStart Then
            LabelBothBody.Text = "Для начала проверки нажмите 'Старт'."
        Else
            Try
                LabelBothBody.Text = LabelBothBodyText(Operation)
            Catch ex As Exception
                LabelBothBody.Text = ""
            End Try
        End If
        Try
            LabelBothHead.Text = LabelBothHeadText(Operation)
        Catch ex As Exception
            LabelBothHead.Text = ""
        End Try
        DeviceValueModel.Value = Test.device.name
        DeviceValueUser.Value = Test.user
        If firstStart And Operation = Steps.Sleep Then
            TimerPanel1.Visible = False
        ElseIf (Not firstStart) And Operation = Steps.Sleep Then
            If TimerPanel1.finish Then
                firstStart = True
                TimerPanel1.Visible = False
            Else
                TimerPanel1.Visible = True
            End If
        Else
            TimerPanel1.Visible = True
        End If
        If TimerPanel1.Visible Then
            If TimerPanel1.finish Then
                Operation = Steps.Sleep
            End If
        End If
        If Operation = Steps.Sleep Or Operation = Steps.MechanicalControl Or Operation = Steps.RWait Or Operation = Steps.UIWait Then

            ButtonBoth.Visible = True
        Else
            ButtonBoth.Visible = False
        End If
        If Operation = Base.Steps.Sleep Then
            ButtonReport.Enabled = True
            ButtonService.Enabled = True
            ButtonNew.Enabled = True
            ButtonUup.Enabled = True
            ButtonUdown.Enabled = True
            ButtonSaveI.Enabled = True
            ButtonSaveO.Enabled = True
            ButtonSaveR.Enabled = True
            ButtonImax1A.Enabled = True
            ButtonImax10A.Enabled = True
            ButtonR.Enabled = True
            ButtonBoth.MyText = "Старт"
        Else
            ButtonReport.Enabled = False
            ButtonService.Enabled = False
            ButtonNew.Enabled = False
            ButtonUup.Enabled = False
            ButtonUdown.Enabled = False
            ButtonSaveI.Enabled = False
            ButtonSaveO.Enabled = False
            ButtonSaveR.Enabled = False
            ButtonImax1A.Enabled = False
            ButtonImax10A.Enabled = False
            ButtonR.Enabled = False
            ButtonBoth.MyText = "Далее"
        End If
        If Operation = Steps.Rcontrol Then
            _ButtonR_Click_Bool = True
        ElseIf Operation <> Steps.Sleep Then
            _ButtonR_Click_Bool = False
        End If
        ButtonR.Color = If(ButtonR_Click_Bool, Color.LimeGreen, Color.Silver)
        ButtonImax1A.Color = If(Test.A1using, Color.LimeGreen, Color.Silver)
        ButtonImax10A.Color = If(Test.A1using, Color.Silver, Color.LimeGreen)
        'записи в тест
        If Operation = Steps.Rcontrol And Test.Ron And Test.R > 0 And Test.R <> Integer.MaxValue Then
            Test.device.Rfact = R
            Test.RreadStop()
            Operation = Steps.MechanicalControl
        End If
        If Operation = Steps.UIcontrol Then
            If uifinish Then
                If Test.device.РабочиеПарамерты.R Then
                    Operation = Steps.RWait
                Else
                    Operation = Steps.MechanicalControl
                End If
            End If
            Select Case Test.IO
                Case IOstat.Close_Close
                    Test.UrecTop()
                Case IOstat.Open_Open
                    Test.UrecBoth()
                Case IOstat.Close_Open
                    Test.device.UI = Test.U
                    Test.device.II = Test.I
                Case IOstat.Open_Close
                    Test.device.UO = Test.U
                    Test.device.IO = Test.I
                    uifinish = True
            End Select
        End If
    End Sub

    Public Sub New()
        TPA.DialogForms.WaitFormStart()
        TPA.TaskBarHide()
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        newReport = True
        Test.start()
        Threading.Thread.Sleep(2000)
        Test.U = 0
        ResetElements()
        TPA.DialogForms.WaitFormStop()
    End Sub

    Private Sub ButtonReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReport.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [Протокол]")
        Dim tce As Boolean = TimerControl.Enabled
        TimerControl.Enabled = False
        If Report.Show(Test.user, Test.device, Test.timeStart) Then
            newReport = False
            TPA.Log.Print(TPA.Rank.OK, "Протокол сохранен на Flash")
        End If
        TimerControl.Enabled = tce
        ResetElements()
    End Sub

    Private Sub ButtonService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonService.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [Сервис]")
        Dim tce As Boolean = TimerControl.Enabled
        TimerControl.Enabled = False
        Servise.Service()
        TimerControl.Enabled = tce
        ResetElements()
    End Sub

    Private Sub ButtonStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [СТОП]")
        Operation = Steps.Sleep
    End Sub

    Private Sub ButtonNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNew.Click
        TPA.DialogForms.WaitFormStart()
        'действия при генерации нового испытания
        Dim tce As Boolean = TimerControl.Enabled
        TimerControl.Enabled = False
        Test.device = New Device()
        firstStart = True
        newReport = True
        Threading.Thread.Sleep(1000)
        TPA.Log.Print(TPA.Rank.OK, "Выполнена генерация нового испытания")
        TimerControl.Enabled = tce
        TPA.DialogForms.WaitFormStop()
    End Sub

    Private Sub ButtonBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBoth.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка 'Далее'")
        Select Case Operation
            Case Steps.Sleep
                Operation = Steps.Start
            Case Steps.Start
                Operation = Steps.UIWait
            Case Steps.UIWait
                Operation = Steps.UIcontrol
            Case Steps.UIcontrol
                Operation = If(Test.device.РабочиеПарамерты.R, Steps.RWait, Steps.MechanicalControl)
            Case Steps.RWait
                Operation = Steps.Rcontrol
            Case Steps.Rcontrol
                Operation = Steps.MechanicalControl
            Case Steps.MechanicalControl
                Operation = Steps.Result
            Case Steps.Result
                Operation = Steps.Sleep
        End Select
    End Sub

    Private Sub TimerControl_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerControl.Tick
        ResetElements()
    End Sub

    Private Sub DeviceValueUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceValueUser.Click
        If Operation = Steps.Sleep And firstStart Then
            Dim tce As Boolean = TimerControl.Enabled
            TimerControl.Enabled = False
            Servise.UserSelect()
            TimerControl.Enabled = tce
            TPA.Log.Print(TPA.Rank.OK, "Выбран оператор " & Test.user)
            ResetElements()
        End If
    End Sub

    Private Sub DeviceValueModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceValueModel.Click
        If Operation = Steps.Sleep And firstStart Then
            Dim tce As Boolean = TimerControl.Enabled
            TimerControl.Enabled = False
            Servise.DeviceSelect()
            TimerControl.Enabled = tce
            TPA.Log.Print(TPA.Rank.OK, "Выбрано устройство " & Test.device.name)
            ResetElements()
        End If
    End Sub

    Private Sub ButtonR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonR.Click
        ButtonR_Click_Bool = Not ButtonR_Click_Bool
    End Sub
    Private _ButtonR_Click_Bool As Boolean = False
    Private Property ButtonR_Click_Bool() As Boolean
        Get
            Return _ButtonR_Click_Bool
        End Get
        Set(ByVal value As Boolean)
            TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [" & If(value, "ВКЛ", "ВЫКЛ") & " режим замера R]")
            If value Then
                ButtonR.Color = Color.LimeGreen
                Test.RreadStart()
            Else
                ButtonR.Color = Color.Silver
                Test.RreadStop()
            End If
            _ButtonR_Click_Bool = value
        End Set
    End Property

    Private Sub ButtonSaveI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveI.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [зап. ВКЛ]")
        If Not ButtonR_Click_Bool Then
            Test.device.II = Test.I
            Test.device.UI = Test.U
        End If
    End Sub

    Private Sub ButtonSaveO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveO.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [зап. ВЫКЛ]")
        If Not ButtonR_Click_Bool Then
            Test.device.IO = Test.I
            Test.device.UO = Test.U
        End If
    End Sub

    Private Sub ButtonSaveR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveR.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [зап. R]")
        If ButtonR_Click_Bool Then Test.device.Rfact = Test.R
    End Sub

    Private Sub ButtonImax1A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImax1A.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [1 A]")
        Test.A1using = True
    End Sub

    Private Sub ButtonImax10A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImax10A.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [10 A]")
        Test.A1using = False
    End Sub

    Private Sub ButtonUdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUdown.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [U down]")
        Test.UrecBoth()
    End Sub

    Private Sub ButtonUup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUup.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [U up]")
        Test.UrecTop()
    End Sub
End Class
