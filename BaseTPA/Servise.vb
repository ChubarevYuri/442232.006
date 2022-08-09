Public Module Servise
    ''' <summary>
    ''' Окно Сервис
    '''     Работа с историей протоколов
    '''     Выбор оператора
    '''     Выбор Устройства
    '''     Системные настройки (под паролем)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Service()
        Dim val As String() = New String() {"История", "Оператор", "Аппарат", "Настройки"}
        Select Case TPA.DialogForms.Selection(val, "Сервис")
            Case val(0)
                TPA.Log.Print(TPA.Rank.OK, "    История")
                SelectReport(val(0))
            Case val(1)
                TPA.Log.Print(TPA.Rank.OK, "    Оператор")
                UserSelect()
            Case val(2)
                TPA.Log.Print(TPA.Rank.OK, "    Аппарат")
                DeviceSelect()
            Case val(3)
                Dim password As String = ""
                TPA.Keyboard.Password(password)
                If password = Base.setting.Read("ПАРОЛЬ", "значение") Then
                    TPA.Log.Print(TPA.Rank.OK, "    Настройки")
                    setting(val(3))
                Else
                    TPA.Log.Print(TPA.Rank.MESSAGE, "В качестве пароля введено [" & password & "]")
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Системные настройки
    '''     Редактирование операторов
    '''     Редактирование устройств
    '''     Очистка истории
    '''     Выход из приложения
    ''' </summary>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Private Sub setting(ByRef head As String)
        Dim val As String() = New String() {"Операторы", "Аппараты", "Очистить историю", "Выйти из приложения"}
        Do
            Select Case TPA.DialogForms.Selection(val, head)
                Case val(0)
                    TPA.Log.Print(TPA.Rank.OK, "        Операторы")
                    SettingUser(val(0))
                Case val(1)
                    TPA.Log.Print(TPA.Rank.OK, "        Аппараты")
                    SettingDevice(val(1))
                Case val(2)
                    TPA.Log.Print(TPA.Rank.OK, "        Очистить историю")
                    clearHistory()
                Case val(3)
                    If TPA.DialogForms.Message("Вы точно хотите закрыть приложение?", _
                                               "", _
                                               TPA.DialogForms.MsgType.warning, _
                                               True) Then
                        TPA.Log.Print(TPA.Rank.OK, "        Выйти из приложения")
                        Quit()
                    End If
                Case Else
                    Exit Do
            End Select
        Loop
    End Sub

#Region "История"

    Private Sub SelectReport(ByRef head As String)
        Dim local As TPA.DialogForms.CorrectAnswer
        Dim list As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Dim file As Dictionary(Of String, String) = TPA.DialogForms.FilterReport(Base.reports, Base.users.Read(), Base.devices.Read())
        TPA.DialogForms.WaitFormStart()
        For Each i As KeyValuePair(Of String, String) In file
            Try
                list.Add(i.Value, Convert.ToInt32(i.Key))
            Catch ex As Exception
            End Try
        Next
        Do
            TPA.DialogForms.WaitFormStop()
            If list.Count > 0 Then
                local = TPA.DialogForms.Correct(list.Keys.ToArray, head, False, True)
                Select Case local.FormResult
                    Case TPA.resultOfCorrect.Add
                    Case TPA.resultOfCorrect.Correct
                        Report.Show(list.Item(local.Elem))
                    Case TPA.resultOfCorrect.Del
                        Base.reports.Delete(list.Item(local.Elem))
                End Select
            End If
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
    End Sub

#End Region

#Region "Устройства"

    ''' <summary>
    ''' создание устройства
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDevice(Optional ByVal name As String = "") As Boolean
        CreateDevice = True
        Dim newObj As Boolean
        If Base.devices.ObjectInFile(name) Then

            newObj = False
        Else

            newObj = True
        End If
        'форма ввода параметров устройства ниже
        Dim device As Base.DeviceStruct = If(newObj, New Base.DeviceStruct, Base.ReadDevice(name))
        Dim oldDevice As Base.DeviceStruct = device
        Dim res As Collection = New Collection()
        res.Add(device.name)
        res.Add(device.KontCount)
        res.Add(device.U)
        res.Add(device.Uvalid)
        res.Add(device.I)
        res.Add(device.Ivalid)
        res.Add(device.R)
        res.Add(device.Rvalid)
        res = TPA.DialogForms.Setting(res, _
                                      New String() {"Модель", _
                                                    "Количество контактов", _
                                                    "Номинальное напряжение, В", _
                                                    "Допуск по напряжению, В", _
                                                    "Номинальная сила тока, А", _
                                                    "Допуск по силе тока, А", _
                                                    "Номинальное сопротивление, Ом", _
                                                    "Допуск по сопротивлению, Ом"}, _
                                      New TPA.DialogForms.ValueType() {TPA.ValueType.text, _
                                                                       TPA.ValueType.uint, _
                                                                       TPA.ValueType.uint, _
                                                                       TPA.ValueType.uint, _
                                                                       TPA.ValueType.ureal, _
                                                                       TPA.ValueType.ureal, _
                                                                       TPA.ValueType.ureal, _
                                                                       TPA.ValueType.ureal}, _
                                      "Устройство")
        device.name = res(1)
        device.KontCount = res(2)
        device.U = res(3)
        device.Uvalid = res(4)
        device.I = res(5)
        device.Ivalid = res(6)
        device.R = res(7)
        device.Rvalid = res(8)
        Try
            If (newObj And device.name.Length > 0 And (Not Base.devices.ObjectInFile(device.name))) _
            Or ((Not newObj) And device.name.Length > 0 And (name = device.name Or (Not Base.devices.ObjectInFile(device.name)))) Then
                For i As Integer = 0 To device.KontCount - 1
                    res.Clear()
                    res.Add(device.РастворКонтактаMin(i))
                    res.Add(device.РастворКонтактаMax(i))
                    res.Add(device.ПровалКонтактаMin(i))
                    res.Add(device.ПровалКонтактаMax(i))
                    res.Add(device.НажатиеНачMin(i))
                    res.Add(device.НажатиеНачMax(i))
                    res.Add(device.НажатиеКонMin(i))
                    res.Add(device.НажатиеКонMax(i))
                    res = TPA.DialogForms.Setting(res, _
                                                  New String() {"Раствор контакта (min), мм", _
                                                                "Раствор контакта (max), мм", _
                                                                "Провал контакта (min), мм", _
                                                                "Провал контакта (max), мм", _
                                                                "Усилие нажатия начальное (min), кг", _
                                                                "Усилие нажатия начальное (max), кг", _
                                                                "Усилие нажатия конечное (min), кг", _
                                                                "Усилие нажатия конечное (max), кг"}, _
                                                  New TPA.DialogForms.ValueType() {TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal}, _
                                                  "Контакт " & i + 1)
                    device.РастворКонтактаMin(i) = res(1)
                    device.РастворКонтактаMax(i) = res(2)
                    device.ПровалКонтактаMin(i) = res(3)
                    device.ПровалКонтактаMax(i) = res(4)
                    device.НажатиеНачMin(i) = res(5)
                    device.НажатиеНачMax(i) = res(6)
                    device.НажатиеКонMin(i) = res(7)
                    device.НажатиеКонMax(i) = res(8)
                Next
                Base.WriteDevice(device)
            Else
                If device.name.Length > 0 Then
                    TPA.DialogForms.Message("Устройтво уже есть в базе.", "", TPA.DialogForms.MsgType.warning)
                Else
                    TPA.DialogForms.Message("Невозможно создать устройство без названия.", "", TPA.DialogForms.MsgType.warning)
                End If
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Редактирование списка устройств
    ''' </summary>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Private Sub SettingDevice(ByRef head As String)
        Dim local As TPA.DialogForms.CorrectAnswer
        Do
            local = TPA.DialogForms.Correct(Base.devices.Read(), head)
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                    CreateDevice()
                Case TPA.resultOfCorrect.Correct
                    CreateDevice(local.Elem)
                Case TPA.resultOfCorrect.Del
                    Base.devices.Delete(local.Elem)
            End Select
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
    End Sub

    ''' <summary>
    ''' Выбор устройства из списка, запись его в модуль Test
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeviceSelect()
        'Test.device.name = TPA.DialogForms.Selection(Base.devices.Read(), "Устройство")
        Test.device = Base.ReadDevice(TPA.DialogForms.Selection(Base.devices.Read(), "Устройство"))
        If Test.device.name = Nothing Then Test.device.name = ""
    End Sub

#End Region

#Region "Операторы"

    ''' <summary>
    ''' Редактирование списка пользователей
    ''' </summary>
    ''' <param name="head"></param>
    ''' <remarks></remarks>
    Private Sub SettingUser(ByRef head As String)
        Dim local As TPA.DialogForms.CorrectAnswer
        Do
            local = TPA.DialogForms.Correct(Base.users.Read(), head)
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                    CreateUser()
                Case TPA.resultOfCorrect.Correct
                    If CreateUser(local.Elem) Then Base.users.Delete(local.Elem)
                Case TPA.resultOfCorrect.Del
                    Base.users.Delete(local.Elem)
            End Select
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
    End Sub

    ''' <summary>
    ''' Создание нового пользователя
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateUser(Optional ByVal user As String = "") As Boolean
        CreateUser = True
        TPA.Keyboard.Text(user, "Фамилия И.О.")
        If user.Length < 3 Then
            TPA.DialogForms.Message("Придумайте что-нибудь поинтереснее.", "", TPA.DialogForms.MsgType.warning)
            CreateUser = False
        Else
            If Not Base.users.ObjectInFile(user) Then
                If Base.users.Write(user, New Dictionary(Of String, String)) <> 0 Then
                    TPA.Log.Print(TPA.Rank.EXCEPT, _
                                  "Оператор " & user & " не добавлен")
                    CreateUser = False
                End If
            Else
                TPA.DialogForms.Message("Оператор с таким именем был создан ранее.", "", TPA.DialogForms.MsgType.warning)
                CreateUser = False
            End If
        End If
    End Function

    ''' <summary>
    ''' Выбор оператора из списка, запись его в модуль Test
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UserSelect()
        Test.user = TPA.DialogForms.Selection(Base.users.Read(), "Оператор")
        If Test.user = Nothing Then Test.user = ""
    End Sub

#End Region

    ''' <summary>
    ''' Очистка истории протоколов, сброс нумерации
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearHistory()
        If TPA.DialogForms.Message("Вы точно хотите произвести сброс протоколов?", _
                                   "", _
                                   TPA.DialogForms.MsgType.warning, _
                                   True) Then
            TPA.DialogForms.WaitFormStart()
            Dim f = New System.IO.FileInfo(TPA.BasePath & "property\report.ini")
            f.Delete()
            Base.setting.Write("ПРОТОКОЛ", "номер", 1)
            Base.setting.Write("ПРОТОКОЛ", "newReport", True)
            Threading.Thread.Sleep(2000)
            TPA.Log.Print(TPA.Rank.OK, "Сброс истории выполнен")
            TPA.DialogForms.WaitFormStop()
        End If
    End Sub

    ''' <summary>
    ''' Выход из приложения
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Quit()
        TPA.Log.Print(TPA.Rank.MESSAGE, "Осуществлен преднамеренный выход из приложения")
        TPA.DeviseInspection.stopInspection()
        TPA.Main.TaskBarShow()
        Application.Exit()
    End Sub

End Module
