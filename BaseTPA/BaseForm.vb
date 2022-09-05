Public Class BaseForm
    Public firstStart As Boolean = True
    Private _operation As Base.Steps = Base.Steps.Sleep
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
                nextStep = value
                TimerPanel1.Start(Base.ReadTimeToSleep(Operation))
                Select Case value
                    Case Steps.Sleep
                        OperationSleep()
                    Case Steps.Start
                        operationStart()
                    Case Steps.UIWait
                        OperationUIWait()
                    Case Steps.UIcontrolI
                        OperatonUIControlI()
                    Case Steps.UIcontrolW
                        OperatonUIControlW()
                    Case Steps.UIcontrolO
                        OperatonUIControlO()
                    Case Steps.RWait
                        OperationRWait()
                    Case Steps.Rcontrol
                        OperatonRControl()
                    Case Steps.Состояние
                        OperationСостояние()
                    Case Steps.Раствор
                        OperationРаствор()
                    Case Steps.Провал
                        OperationПровал()
                    Case Steps.Нач
                        OperationНач()
                    Case Steps.Кон
                        OperationКон()
                    Case Steps.Result
                        OperationResult()
                End Select
                ResetElements()
            End If
        End Set
    End Property

#Region "operations"

    Private ButtonBothText As String = "Старт"
    Private ButtonBothVisible As Boolean = True
    Private LabelBothHeadText As String = "Стенд остановлен"
    Private LabelBothBodyText As String = "Для начала испытания нажмите 'Старт'"


    Private nextStep As Base.Steps = Base.Steps.Sleep

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub OperationSleep()
        Test.U = 0
        Test.Urec = 0
        Test.A1using = False
        Test.RreadStop()
        ButtonReport.Enabled = True
        ButtonService.Enabled = True
        ButtonNew.Enabled = True
        ButtonUup.Enabled = True
        ButtonUdown.Enabled = True
        ButtonImax1A.Enabled = True
        ButtonImax10A.Enabled = True
        ButtonR.Enabled = True
        ButtonBothText = "Старт"
        ButtonBothVisible = True
        LabelBothHeadText = "Стенд остановлен"
        LabelBothBodyText = If(Not firstStart, "Для запуска нового испытания нажните 'Новое'. ", "") & "Для начала испытания нажмите 'Старт'"
        TPA.DialogForms.WaitFormStop()
    End Sub

    ''' <summary>
    ''' при новом испытании опросить имя, устройство, проверяемые параметры и запустить проверку, если что-то не заполнено, то выйти в sleep
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub operationStart()
        ButtonReport.Enabled = False
        ButtonService.Enabled = False
        ButtonNew.Enabled = False
        ButtonUup.Enabled = False
        ButtonUdown.Enabled = False
        ButtonImax1A.Enabled = False
        ButtonImax10A.Enabled = False
        ButtonR.Enabled = False
        ButtonBothText = "Далее"
        ButtonBothVisible = False
        LabelBothHeadText = ""
        LabelBothBodyText = ""
        If firstStart Then
            If devices.Read().Count = 0 Then
                TPA.DialogForms.Message("Запуск проверки невозможен." & Chr(13) & Chr(10) & "Отсутствует список аппаратов.", _
                                        "Ошибка!", _
                                        TPA.DialogForms.MsgType.except)
                Operation = Steps.Sleep
                Exit Sub
            End If
            If users.Read().Count = 0 Then
                TPA.DialogForms.Message("Запуск проверки невозможен." & Chr(13) & Chr(10) & "Отсутствует список операторов.", _
                                        "Ошибка!", _
                                        TPA.DialogForms.MsgType.except)
                Operation = Steps.Sleep
                Exit Sub
            End If
            Test.device = New Device()
            Test.user = ""
            Test.master = ""
            Test.timeStart = Now
            Servise.DeviceSelect()
            TPA.DialogForms.WaitFormStart()
            If Test.device.Name.Length <= 0 Then
                Operation = Steps.Sleep
                Exit Sub
            End If
            Servise.UserSelect()
            TPA.DialogForms.WaitFormStart()
            If Test.user.Length <= 0 Then
                Operation = Steps.Sleep
                Exit Sub
            End If
            Servise.MasterSelect()
            TPA.DialogForms.WaitFormStart()
            Test.device.Num = ""
            TPA.Keyboard.SerialNum(Test.device.Num, "Номер аппарата")
            TPA.DialogForms.WaitFormStart()
            firstStart = False
        End If
        Dim dev As Device = New Device
        If devices.ObjectInFile(Test.device.Name) Then
            dev.Read(Test.device.Name)
        End If
        Using f As New OperationsForm(dev.РабочиеПарамерты)
            f.ShowDialog()
            Test.device.РабочиеПарамерты = f.result
        End Using
        TPA.DialogForms.WaitFormStart()
        uifinish = False
        nextStep = Steps.RWait
    End Sub

    ''' <summary>
    ''' Подготовка проверки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationUIWait()
        If Test.device.РабочиеПарамерты.work Or Test.device.РабочиеПарамерты.I Or Test.device.РабочиеПарамерты.O Then
            Test.A1using = If(Test.device.Ii.Max > 0 And Test.device.Ii.Max < Double.MaxValue, _
                                  Test.device.Ii.Max < 0.75, _
                                  If(Test.device.Uwork.Max > 0 _
                                     And Test.device.Uwork.Max < Double.MaxValue _
                                     And Test.device.R.Min > 0, _
                                    Test.device.Ui.Max / Test.device.R.Min < 0.75, _
                                     False))
            U = 0
            Test.RreadStop()
            ButtonBothVisible = True
            LabelBothHeadText = "Подготовка к испытанию"
            LabelBothBodyText = If(Test.device.РабочиеПарамерты.R, _
                                   "ОТКЛЮЧИТЕ щупы 'Сопротивление Ra'" & Chr(13) & Chr(10), _
                                   "") & _
                                "Подключите щупы 'U вых' к катушке аппарата." & Chr(13) & Chr(10) & _
                                "Подключите щупы 'Контроль контакта' к выводам силовой цепи аппарата."
            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Присоедините контакты 'U вых' к катушке аппарата." & Chr(13) & Chr(10) & "Присоедините контакты 'Контроль контакта' к силовой цепи аппарата.", "Подготовка к испытанию")
        Else
            nextStep = Steps.Состояние
        End If
    End Sub

    ''' <summary>
    ''' проверка электрической части
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperatonUIControlI()
        нормальноЗамкнутыйКонтакт = Test.IOnow
        Test._IO = нормальноЗамкнутыйКонтакт
        If Test.device.РабочиеПарамерты.I Then
            ButtonBothVisible = False
            LabelBothHeadText = "Контроль включения"
            LabelBothBodyText = "Дождитесь завершения замера"
            U = 0
            Dim val As Double = Test.device.Ui.Max
            Try
                val *= Convert.ToDouble(setting.Read("СТЕНД", "U rec step"))
            Catch ex As Exception
                val *= 27
            End Try
            TPA.DeviseInspection.AddCommand(_UImeter.out7(True))
            TPA.DeviseInspection.AddCommand(_UImeter.ПределРегулирования(val))
            Try
                TPA.DeviseInspection.AddCommand(_UImeter.ВремяРегулирования(Convert.ToInt32(setting.Read("СТЕНД", "U speed"))))
            Catch ex As Exception
                TPA.DeviseInspection.AddCommand(_UImeter.ВремяРегулирования(20))
            End Try
            TPA.DeviseInspection.AddCommand(_UImeter.СтартРегулирования)
            Dim _th As New Threading.Thread(AddressOf UIControlIwait)
            _th.Priority = Threading.ThreadPriority.Normal
            TPA.DialogForms.WaitFormStop()
            _th.Start()
        Else
            nextStep = Steps.UIcontrolO
        End If
    End Sub

    Private Sub UIControlIwait()
        Dim timestop As DateTime
        Try
            timestop = Now.AddSeconds(Convert.ToInt32(setting.Read("СТЕНД", "U speed") * 1.5))
        Catch ex As Exception
            timestop = Now.AddSeconds(30)
        End Try
        Do While Now < timestop And Test.IOnow = нормальноЗамкнутыйКонтакт
            Threading.Thread.Sleep(50)
        Loop
        If Test.IOnow = нормальноЗамкнутыйКонтакт Then
            Test.device.Ui.Fact = Double.MaxValue
            Test.device.Ii.Fact = Double.MaxValue
            ButtonBothVisible = True
            LabelBothHeadText = "Ошибка включения"
            LabelBothBodyText = "Аппарат не включился при U = " & Test.U.ToString("#0.0")
            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Аппарат не включился при U = " & Test.U.ToString("#0.0"), _
            '                        "Ошибка включения", _
            '                        TPA.DialogForms.MsgType.warning)
        Else
            Test.device.Ui.Fact = Test.U
            Test.device.Ii.Fact = autoIcontrol()
            ButtonBothVisible = True
            LabelBothHeadText = "Параметры включения"
            LabelBothBodyText = "Напряжение включения " & Test.device.UiFactStr & " " & Test.device.Uiei & " при допустимом " & Test.device.UiMaxMinStr & " " & Test.device.Uiei & _
                                Chr(13) & Chr(10) & _
                                "Ток включения " & Test.device.IiFactStr & " " & Test.device.Iei & " при допустимом " & Test.device.IMaxMinStr & " " & Test.device.Iei

            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Напряжение включения " & Test.device.UiFactStr & " " & Test.device.Uiei & " при допустимом " & Test.device.UiMaxMinStr & " " & Test.device.Uiei & _
            '                        Chr(13) & Chr(10) & _
            '                        "Ток включения " & Test.device.IiFactStr & " " & Test.device.Iei & " при допустимом " & Test.device.IMaxMinStr & " " & Test.device.Iei, _
            '                        "Параметры включения", _
            '                        If(Test.device.Ii.Control And Test.device.Ui.Control, _
            '                           TPA.DialogForms.MsgType.message, _
            '                           TPA.DialogForms.MsgType.warning))
        End If
    End Sub

    ''' <summary>
    ''' проверка электрической части
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperatonUIControlW()
        If Test.device.РабочиеПарамерты.work Then
            ButtonBothVisible = False
            LabelBothHeadText = "Контроль срабатывания при U min"
            LabelBothBodyText = "Дождитесь завершения замера"
            Dim val As Double = Test.device.Ui.Max
            Try
                val *= Convert.ToDouble(setting.Read("СТЕНД", "U rec step (*)"))
            Catch ex As Exception
                val *= 28
            End Try
            Try
                val += Convert.ToDouble(setting.Read("СТЕНД", "U rec step (+)"))
            Catch ex As Exception
                val += 5
            End Try
            U = val
            Threading.Thread.Sleep(1500)
            If Test.IOnow <> нормальноЗамкнутыйКонтакт And TPA.DialogForms.Message("Убедитесь, что якорь плотно прижат к катушке. Если это так, то нажмите 'V', иначе 'X'", "Контроль включения", TPA.DialogForms.MsgType.message, True) Then
                Test.device.Uwork.Fact = Test.device.Uwork.Max
                Test.device.Ui.Fact = Test.U
                Test.device.Ii.Fact = Test.I
                ButtonBothVisible = True
                LabelBothHeadText = "Контроль срабатывания при U min"
                LabelBothBodyText = "Включение в норме"
                TPA.DialogForms.WaitFormStop()
            Else
                Test.device.Uwork.Fact = If(Test.device.Uwork.Max < Double.MaxValue, Double.MaxValue, Double.MinValue)
                Test.device.Ui.Fact = Double.MaxValue
                Test.device.Ii.Fact = 0
                ButtonBothVisible = True
                LabelBothHeadText = "Контроль срабатывания при U min"
                LabelBothBodyText = "Включения не произошло"
                TPA.DialogForms.WaitFormStop()
            End If
            U = 0
        Else
            nextStep = Steps.UIcontrolI
        End If
    End Sub

    ''' <summary>
    ''' проверка электрической части
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperatonUIControlO()
        If Test.device.РабочиеПарамерты.O Then
            ButtonBothVisible = False
            LabelBothHeadText = "Контроль отключения"
            LabelBothBodyText = "Дождитесь завершения замера"
            Dim val As Double = If(Test.device.U > Test.device.Uo.Max, Test.device.U, Test.device.Uo.Max * 1.1)
            Try
                val *= Convert.ToDouble(setting.Read("СТЕНД", "U rec step (*)"))
            Catch ex As Exception
                val *= 28
            End Try
            Try
                val += Convert.ToDouble(setting.Read("СТЕНД", "U rec step (+)"))
            Catch ex As Exception
                val += 5
            End Try
            U = val
            TPA.DeviseInspection.AddCommand(_UImeter.out7(True))
            TPA.DeviseInspection.AddCommand(_UImeter.ПределРегулирования(0))
            Try
                TPA.DeviseInspection.AddCommand(_UImeter.ВремяРегулирования(Convert.ToInt32(setting.Read("СТЕНД", "U speed"))))
            Catch ex As Exception
                TPA.DeviseInspection.AddCommand(_UImeter.ВремяРегулирования(20))
            End Try
            TPA.DeviseInspection.AddCommand(_UImeter.СтартРегулирования)
            Threading.Thread.Sleep(500)
            Dim _th As New Threading.Thread(AddressOf UIControlOwait)
            _th.Priority = Threading.ThreadPriority.Normal
            Threading.Thread.Sleep(500)
            TPA.DialogForms.WaitFormStop()
            _th.Start()
        Else
            nextStep = Steps.Состояние
        End If
    End Sub

    Private Sub UIControlOwait()
        Dim timestop As DateTime
        Try
            timestop = Now.AddSeconds(Convert.ToInt32(setting.Read("СТЕНД", "U speed") * 1.5))
        Catch ex As Exception
            timestop = Now.AddSeconds(30)
        End Try
        Do While Now < timestop And Test.IOnow <> нормальноЗамкнутыйКонтакт
            Threading.Thread.Sleep(50)
        Loop
        If Test.IOnow <> нормальноЗамкнутыйКонтакт Then
            Test.device.Uo.Fact = Double.MaxValue
            Test.device.Io.Fact = Double.MaxValue
            Test.device.Ii.Fact = 0
            ButtonBothVisible = True
            LabelBothHeadText = "Ошибка отключения"
            LabelBothBodyText = "Аппарат не отключился при U = " & Test.U.ToString("#0.0")
            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Аппарат не отключился при U = " & Test.U.ToString("#0.0"), _
            '                        "Ошибка отключения", _
            '                        TPA.DialogForms.MsgType.warning)
        Else
            Test.device.Uo.Fact = Test.U
            Test.device.Io.Fact = autoIcontrol()
            'Test.device.Ii.Fact = 0
            ButtonBothVisible = True
            LabelBothHeadText = "Параметры отключения"
            LabelBothBodyText = "Напряжение отключения " & Test.device.UoFactStr & " " & Test.device.Uoei & " при допустимом " & Test.device.UoMaxMinStr & " " & Test.device.Uoei & _
                                    Chr(13) & Chr(10) & _
                                    "Ток отключения " & Test.device.IoFactStr & " " & Test.device.Iei & " при допустимом " & Test.device.IMaxMinStr & " " & Test.device.Iei
            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Напряжение отключения " & Test.device.UoFactStr & " " & Test.device.Uoei & " при допустимом " & Test.device.UoMaxMinStr & " " & Test.device.Uoei & _
            '                        Chr(13) & Chr(10) & _
            '                        "Ток отключения " & Test.device.IoFactStr & " " & Test.device.Iei & " при допустимом " & Test.device.IMaxMinStr & " " & Test.device.Iei, _
            '                        "Параметры отключения", _
            '                        If(Test.device.Io.Control And Test.device.Uo.Control, _
            '                           TPA.DialogForms.MsgType.message, _
            '                           TPA.DialogForms.MsgType.warning))
        End If
    End Sub

    Private Function autoIcontrol() As Double
        If Test.I < 0.75 And Test.A1using = False Then
            Test.A1using = True
            Threading.Thread.Sleep(1000)
            autoIcontrol = Test.I
            Test.A1using = False
        Else
            autoIcontrol = Test.I
        End If
    End Function

    ''' <summary>
    ''' Подготовка проверки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationRWait()
        If Test.device.РабочиеПарамерты.R Then
            R = 0
            U = 0
            Test.A1using = False
            ButtonBothVisible = True
            LabelBothHeadText = "Подготовка к испытанию"
            LabelBothBodyText = "Подключите щупы 'Сопротивление Ra' к катушке аппарата."
            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Присоедините контакты 'Сопротивление Ra' к катушке аппарата." & _
            '                        Chr(13) & Chr(10) & _
            '                        "Другие контакты должны быть отключены.", "Подготовка к испытанию")
        Else
            nextStep = Steps.UIWait
        End If
    End Sub

    ''' <summary>
    ''' проверка сопротивления
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperatonRControl()
        If Test.device.РабочиеПарамерты.R Then
            ButtonBothVisible = False
            LabelBothHeadText = "Контроль активного сопротивления"
            LabelBothBodyText = "Дождитесь завершения замера"
            _Rread()
            Test.device.R.Fact = Test.R
            ButtonBothVisible = True
            LabelBothHeadText = "Контроль активного сопротивления"
            LabelBothBodyText = "Активное сопротивление катушки " & Test.device.RFactStr & " " & Test.device.Rei & " при допустимом " & Test.device.RMaxMinStr & " " & Test.device.Rei
            TPA.DialogForms.WaitFormStop()
            'TPA.DialogForms.Message("Активное сопротивление катушки " & Test.device.RFactStr & " " & Test.device.Rei & " при допустимом " & Test.device.RMaxMinStr & " " & Test.device.Rei, _
            '                            "Контроль активного сопротивления", _
            '                            If(Test.device.R.Control, _
            '                               TPA.DialogForms.MsgType.message, _
            '                               TPA.DialogForms.MsgType.warning))
        Else
            nextStep = Steps.UIWait
        End If
    End Sub

    ''' <summary>
    ''' самостоятельные замеры и их ввод
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationСостояние()
        If Test.device.РабочиеПарамерты.Состояние And (Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0) Then
            ButtonBothVisible = True
            ButtonBothText = "Ввод"
            LabelBothHeadText = "Контролируемые параметры"
            LabelBothBodyText = "Проведите визуальный осмотр каждого контакта и укажите их состояние (V - норма, X- не норма)"
            Test.RreadStop()
            U = 0
            Test.A1using = False
            TPA.DialogForms.WaitFormStop()
        Else
            nextStep = Steps.Раствор
        End If
    End Sub

    ''' <summary>
    ''' самостоятельные замеры и их ввод
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationРаствор()
        If Test.device.РабочиеПарамерты.РастворКонтактов And (Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0) Then
            ButtonBothVisible = True
            ButtonBothText = "Ввод"
            LabelBothHeadText = "Контролируемые параметры"
            LabelBothBodyText = "Проведите замер раствора каждого контакта и внесите эти данные"
            Test.RreadStop()
            U = 0
            Test.A1using = False
            TPA.DialogForms.WaitFormStop()
        Else
            nextStep = Steps.Провал
        End If
    End Sub

    ''' <summary>
    ''' самостоятельные замеры и их ввод
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationПровал()
        If Test.device.РабочиеПарамерты.ПровалКонтактов And (Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0) Then
            ButtonBothVisible = True
            ButtonBothText = "Ввод"
            LabelBothHeadText = "Контролируемые параметры"
            LabelBothBodyText = "Проведите замер провала каждого контакта и внесите эти данные"
            Test.RreadStop()
            U = 0
            Test.A1using = False
            TPA.DialogForms.WaitFormStop()
        Else
            nextStep = Steps.Нач
        End If
    End Sub

    ''' <summary>
    ''' самостоятельные замеры и их ввод
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationНач()
        If Test.device.РабочиеПарамерты.НажатиеНач And (Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0) Then
            ButtonBothVisible = True
            ButtonBothText = "Ввод"
            LabelBothHeadText = "Контролируемые параметры"
            LabelBothBodyText = "Проведите замер усилия нажатия (начального) каждого контакта и внесите эти данные"
            Test.RreadStop()
            U = 0
            Test.A1using = False
            TPA.DialogForms.WaitFormStop()
        Else
            nextStep = Steps.Кон
        End If
    End Sub

    ''' <summary>
    ''' самостоятельные замеры и их ввод
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationКон()
        If Test.device.РабочиеПарамерты.НажатиеКон And (Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0) Then
            ButtonBothVisible = True
            ButtonBothText = "Ввод"
            LabelBothHeadText = "Контролируемые параметры"
            LabelBothBodyText = "Проведите замер усилия нажатия (конечного) каждого контакта и внесите эти данные"
            Test.RreadStop()
            U = 0
            Test.A1using = False
            TPA.DialogForms.WaitFormStop()
        Else
            nextStep = Steps.Result
        End If
    End Sub

    Private Sub writeСостояние()
        If Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0 Then
            RreadStop()
            TPA.DeviseInspection.stopInspection()
            Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Boolean
            Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                If i < Test.device.KontACount Then
                    all(i) = Test.device.СостояниеA(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    all(i) = Test.device.СостояниеB(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount
                Else
                    all(i) = Test.device.СостояниеC(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount
                End If
            Next
            all = TPA.DialogForms.Setting(all, head, "Состояние контактов")
            TPA.DialogForms.WaitFormStart()
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                If i < Test.device.KontACount Then
                    Test.device.СостояниеA(i) = all(i)
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    Test.device.СостояниеB(i - Test.device.KontACount) = all(i)
                Else
                    Test.device.СостояниеC(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                End If
            Next
            TPA.DeviseInspection.startInspection()
        End If
        nextStep = Steps.Раствор
    End Sub

    Private Sub writeРаствор()
        If Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0 Then
            RreadStop()
            TPA.DeviseInspection.stopInspection()
            Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
            Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
            Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                type(i) = TPA.ValueType.ureal
                If i < Test.device.KontACount Then
                    all(i) = Test.device.РастворКонтактаAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", мм"
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    all(i) = Test.device.РастворКонтактаBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", мм"
                Else
                    all(i) = Test.device.РастворКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", мм"
                End If
            Next
            all = TPA.DialogForms.Setting(all, head, type, "Раствор контактов")
            TPA.DialogForms.WaitFormStart()
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                If i < Test.device.KontACount Then
                    Test.device.РастворКонтактаAFact(i) = all(i)
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    Test.device.РастворКонтактаBFact(i - Test.device.KontACount) = all(i)
                Else
                    Test.device.РастворКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                End If
            Next
            TPA.DeviseInspection.startInspection()
        End If
        nextStep = Steps.Провал
    End Sub

    Private Sub writeПровал()
        If Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0 Then
            RreadStop()
            TPA.DeviseInspection.stopInspection()
            Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
            Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
            Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                type(i) = TPA.ValueType.ureal
                If i < Test.device.KontACount Then
                    all(i) = Test.device.ПровалКонтактаAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", мм"
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    all(i) = Test.device.ПровалКонтактаBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", мм"
                Else
                    all(i) = Test.device.ПровалКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", мм"
                End If
            Next
            all = TPA.DialogForms.Setting(all, head, type, "Провал контактов")
            TPA.DialogForms.WaitFormStart()
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                If i < Test.device.KontACount Then
                    Test.device.ПровалКонтактаAFact(i) = all(i)
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    Test.device.ПровалКонтактаBFact(i - Test.device.KontACount) = all(i)
                Else
                    Test.device.ПровалКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                End If
            Next
            TPA.DeviseInspection.startInspection()
        End If
        nextStep = Steps.Нач
    End Sub

    Private Sub writeНач()
        If Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0 Then
            RreadStop()
            TPA.DeviseInspection.stopInspection()
            Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
            Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
            Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                type(i) = TPA.ValueType.ureal
                If i < Test.device.KontACount Then
                    all(i) = Test.device.НажатиеНачAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", Н"
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    all(i) = Test.device.НажатиеНачBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", Н"
                Else
                    all(i) = Test.device.НажатиеНачCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", Н"
                End If
            Next
            all = TPA.DialogForms.Setting(all, head, type, "Усилие нажатия (начальное)")
            TPA.DialogForms.WaitFormStart()
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                If i < Test.device.KontACount Then
                    Test.device.НажатиеНачAFact(i) = all(i)
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    Test.device.НажатиеНачBFact(i - Test.device.KontACount) = all(i)
                Else
                    Test.device.НажатиеНачCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                End If
            Next
            TPA.DeviseInspection.startInspection()
        End If
        nextStep = Steps.Кон
    End Sub

    Private Sub writeКон()
        If Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0 Then
            RreadStop()
            TPA.DeviseInspection.stopInspection()
            Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
            Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
            Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                type(i) = TPA.ValueType.ureal
                If i < Test.device.KontACount Then
                    all(i) = Test.device.НажатиеКонAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", Н"
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    all(i) = Test.device.НажатиеКонBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", Н"
                Else
                    all(i) = Test.device.НажатиеКонCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", Н"
                End If
            Next
            all = TPA.DialogForms.Setting(all, head, type, "Усилие нажатия (конечное)")
            TPA.DialogForms.WaitFormStart()
            For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                If i < Test.device.KontACount Then
                    Test.device.НажатиеКонAFact(i) = all(i)
                ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                    Test.device.НажатиеКонBFact(i - Test.device.KontACount) = all(i)
                Else
                    Test.device.НажатиеКонCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                End If
            Next
            TPA.DeviseInspection.startInspection()
        End If
        nextStep = Steps.Result
    End Sub

    Private Sub MechanicalVals()
        If Test.device.KontACount > 0 Or Test.device.KontBCount > 0 Or Test.device.KontCCount > 0 Then
            If Test.device.РабочиеПарамерты.Состояние Then
                Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Boolean
                Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
                For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    If i < Test.device.KontACount Then
                        all(i) = Test.device.СостояниеA(i)
                        head(i) = "Контакт главной цепи замыкающий № " & i + 1
                    ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                        all(i) = Test.device.СостояниеB(i - Test.device.KontACount)
                        head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount
                    Else
                        all(i) = Test.device.СостояниеC(i - Test.device.KontACount - Test.device.KontBCount)
                        head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount
                    End If
                Next
                TPA.DialogForms.Message("Проведите визуальный осмотр каждого контакта и укажите их состояние (V - норма, X- не норма)", "Информация")
                all = TPA.DialogForms.Setting(all, head, "Состояние контактов")
                For i As Integer = 0 To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    If i < Test.device.KontACount Then
                        Test.device.СостояниеA(i) = all(i)
                    ElseIf i < Test.device.KontACount + Test.device.KontBCount Then
                        Test.device.СостояниеB(i - Test.device.KontACount) = all(i)
                    Else
                        Test.device.СостояниеC(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                    End If
                Next
            End If
            If Test.device.РабочиеПарамерты.РастворКонтактов Then
                Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.РастворКонтактаAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", мм"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.РастворКонтактаBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", мм"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    all(i) = Test.device.РастворКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", мм"
                    type(i) = TPA.ValueType.ureal
                Next
                TPA.DialogForms.Message("Проведите замер раствора каждого контакта и внесите эти данные", "Информация")
                all = TPA.DialogForms.Setting(all, head, type, "Раствор контактов")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.РастворКонтактаAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.РастворКонтактаBFact(i - Test.device.KontACount) = all(i)
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    Test.device.РастворКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.ПровалКонтактов Then
                Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.ПровалКонтактаAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", мм"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.ПровалКонтактаBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", мм"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    all(i) = Test.device.ПровалКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", мм"
                    type(i) = TPA.ValueType.ureal
                Next
                TPA.DialogForms.Message("Проведите замер провала каждого контакта и внесите эти данные", "Информация")
                all = TPA.DialogForms.Setting(all, head, type, "Провал контактов")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.ПровалКонтактаAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.ПровалКонтактаBFact(i - Test.device.KontACount) = all(i)
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    Test.device.ПровалКонтактаCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.НажатиеНач Then
                Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.НажатиеНачAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", Н"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.НажатиеНачBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", Н"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    all(i) = Test.device.НажатиеНачBFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", Н"
                    type(i) = TPA.ValueType.ureal
                Next
                TPA.DialogForms.Message("Проведите замер усилия нажатия (начального) каждого контакта и внесите эти данные", "Информация")
                all = TPA.DialogForms.Setting(all, head, type, "Усилие нажатия (начальное)")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.НажатиеНачAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.НажатиеНачBFact(i - Test.device.KontACount) = all(i)
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    Test.device.НажатиеНачCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                Next
            End If
            If Test.device.РабочиеПарамерты.НажатиеКон Then
                Dim all(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As Double
                Dim head(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As String
                Dim type(Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1) As TPA.ValueType
                For i As Integer = 0 To Test.device.KontACount - 1
                    all(i) = Test.device.НажатиеКонAFact(i)
                    head(i) = "Контакт главной цепи замыкающий № " & i + 1 & ", Н"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    all(i) = Test.device.НажатиеКонBFact(i - Test.device.KontACount)
                    head(i) = "Контакт главной цепи размыкающий № " & i + 1 - Test.device.KontACount & ", Н"
                    type(i) = TPA.ValueType.ureal
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    all(i) = Test.device.НажатиеКонCFact(i - Test.device.KontACount - Test.device.KontBCount)
                    head(i) = "Контакт вспомогательной цепи № " & i + 1 - Test.device.KontACount - Test.device.KontBCount & ", Н"
                    type(i) = TPA.ValueType.ureal
                Next
                TPA.DialogForms.Message("Проведите замер усилия нажатия (конечного) каждого контакта и внесите эти данные", "Информация")
                all = TPA.DialogForms.Setting(all, head, type, "Усилие нажатия (конечное)")
                For i As Integer = 0 To Test.device.KontACount - 1
                    Test.device.НажатиеКонAFact(i) = all(i)
                Next
                For i As Integer = Test.device.KontACount To Test.device.KontACount + Test.device.KontBCount - 1
                    Test.device.НажатиеКонBFact(i - Test.device.KontACount) = all(i)
                Next
                For i As Integer = Test.device.KontACount + Test.device.KontBCount To Test.device.KontACount + Test.device.KontBCount + Test.device.KontCCount - 1
                    Test.device.НажатиеКонCFact(i - Test.device.KontACount - Test.device.KontBCount) = all(i)
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Вывод результата проверки
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OperationResult()
        Dim _cc As Integer = 0
        If Test.device.РабочиеПарамерты.I Then _cc += 1
        If Test.device.РабочиеПарамерты.work Then _cc += 1
        If Test.device.РабочиеПарамерты.O Then _cc += 1
        If Test.device.РабочиеПарамерты.R Then _cc += 1
        If Test.device.РабочиеПарамерты.НажатиеКон Then _cc += 1
        If Test.device.РабочиеПарамерты.НажатиеНач Then _cc += 1
        If Test.device.РабочиеПарамерты.Состояние Then _cc += 1
        If Test.device.РабочиеПарамерты.РастворКонтактов Then _cc += 1
        If Test.device.РабочиеПарамерты.ПровалКонтактов Then _cc += 1
        If _cc > 1 Then
            TPA.DialogForms.WaitFormStart()
            ButtonBothVisible = False
            LabelBothHeadText = ""
            LabelBothBodyText = ""
            U = 0
            Test.A1using = False
            Report.Save(Report.readNum, Test.device, Test.user, Test.master, Test.timeStart)
            newReport = False
            Report.Show(Report.readNum)
        End If
        nextStep = Steps.Sleep
    End Sub
#End Region

    Dim _uo As Double = 0
    Dim _io As Double = 0
    Dim нормальноЗамкнутыйКонтакт As Boolean = False
    Dim uifinish As Boolean = False
    Private Sub ResetElements()
        If Test.U > 0 Then
            DeviceValueU.Value = Test.U.ToString("F1")
        Else
            DeviceValueU.Value = "---"
        End If
        If Test.I < 1 Then
            DeviceValueI.Head = "    I, мА"

            DeviceValueI.Value = If(Test.I > 0, (Test.I * 1000).ToString("F0"), "---")
        Else
            DeviceValueI.Head = "    I, A"
            DeviceValueI.Value = Test.I.ToString("F1")
        End If
        If Test.R < 100 Then
            DeviceValueR.Head = "   R, Ом"
            DeviceValueR.Value = If(Test.R > 0, Test.R.ToString("F1"), "---")
        ElseIf Test.R < 1000 Then
            DeviceValueR.Head = "   R, Ом"
            DeviceValueR.Value = Test.R.ToString("F0")
        Else
            DeviceValueR.Head = "   R, кОм"
            DeviceValueR.Value = (Test.R / 1000).ToString("F")
        End If
        If TimerPanel1.Visible Then
            If TimerPanel1.finish Then
                Operation = Steps.Sleep
            End If
        End If
        ButtonImax1A.Color = If(Test.A1using, Color.LimeGreen, Color.Gainsboro)
        ButtonImax10A.Color = If(Test.A1using, Color.Gainsboro, Color.LimeGreen)
        ButtonBoth.MyText = ButtonBothText
        ButtonBoth.Visible = ButtonBothVisible
        LabelBothHead.Text = LabelBothHeadText
        LabelBothBody.Text = LabelBothBodyText
        Operation = nextStep
    End Sub

    Public Sub New()
        TPA.DialogForms.WaitFormStart()
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        newReport = True
        TPA.TaskBarHide()
        Test.start()
        Threading.Thread.Sleep(2000)
        OperationSleep()
        ResetElements()
        TPA.DialogForms.WaitFormStop()
    End Sub

    Private Sub ButtonReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReport.Click
        TPA.DialogForms.WaitFormStart()
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [Протокол]")
        Dim tce As Boolean = TimerControl.Enabled
        TimerControl.Enabled = False
        If Report.Show(Test.user, Test.master, Test.device, Test.timeStart) Then
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
        If Operation = Steps.Sleep Then OperationSleep()
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
        TPA.DialogForms.WaitFormStart()
        If Operation = Steps.Result Then
            Operation = Steps.Sleep
        ElseIf Operation = Steps.Состояние Then
            writeСостояние()
        ElseIf Operation = Steps.Раствор Then
            writeРаствор()
        ElseIf Operation = Steps.Провал Then
            writeПровал()
        ElseIf Operation = Steps.Нач Then
            writeНач()
        ElseIf Operation = Steps.Кон Then
            writeКон()
        Else
            Operation += 1
        End If
    End Sub

    Private Sub TimerControl_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerControl.Tick
        ResetElements()
    End Sub

    Private Sub ButtonR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonR.Click
        _Rread()
    End Sub

    Private Sub _Rread()
        TimerControl.Enabled = False
        ButtonR.Color = Color.LimeGreen
        ButtonR.Update()
        Test.RreadStart()
        Dim stoped As DateTime = Now.AddMilliseconds(10000)
        Do While (Test.R = 0 Or Test.R = 50000) And stoped > Now
            Threading.Thread.Sleep(50)
        Loop
        ButtonR.Color = Color.Gainsboro
        Test.RreadStop()
        TimerControl.Enabled = True
        ResetElements()
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
        Test.UrecBoth(True)
    End Sub

    Private Sub ButtonUup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUup.Click
        TPA.Log.Print(TPA.Rank.OK, "Нажата кнопка [U up]")
        Test.UrecTop(True)
    End Sub

    Private Sub DeviceValueU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceValueU.Click
        If Operation = Steps.Sleep Then
            Dim u As Double = Convert.ToDouble(setting.Read("СТЕНД", "U rec step (*)"))
            Dim ukey As String = Test.U.ToString("#0.0")
            TPA.Keyboard.UReal(ukey, "Установка напряжения")
            Try
                u *= Convert.ToDouble(ukey)
                u += Convert.ToDouble(setting.Read("СТЕНД", "U rec step (+)"))
                Test.Urec = u
                TPA.Log.Print(TPA.Rank.OK, "Установлено U = " & u)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.OK, "Установка точного U не утановлена")
            End Try
        End If
    End Sub
End Class
