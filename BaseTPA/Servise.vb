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
            If list.Count > 0 Then
                TPA.DialogForms.WaitFormStart()
                local = TPA.DialogForms.Correct(list.Keys.ToArray, head, False, True)
                TPA.DialogForms.WaitFormStart()
                Select Case local.FormResult
                    Case TPA.resultOfCorrect.Add
                    Case TPA.resultOfCorrect.Correct
                        Report.Show(list.Item(local.Elem))
                    Case TPA.resultOfCorrect.Del
                        Base.reports.Delete(list.Item(local.Elem))
                        list.Remove(local.Elem)
                End Select
            End If
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
        TPA.DialogForms.WaitFormStop()
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
        TPA.WaitFormStart()
        CreateDevice = True
        Dim newObj As Boolean = True
        If Base.devices.ObjectInFile(name) Then newObj = False
        'форма ввода параметров устройства ниже
        'Dim device As Device = If(newObj, New Device(), Base.ReadDevice(name))
        Dim device As Device = New Device()
        If Not newObj Then device.Read(name)
        Dim oldDevice As Device = device
        Dim res As Collection = New Collection()
        res.Add(device.Name)
        res.Add(device.KontACount)
        res.Add(device.KontBCount)
        res.Add(device.U)
        res.Add(device.Uvalid)
        res.Add(device.I)
        res.Add(device.Ivalid)
        res.Add(device.R)
        res.Add(device.Rvalid)
        res = TPA.DialogForms.Setting(res, _
                                      New String() {"Модель", _
                                                    "Количество силовых контактов", _
                                                    "Количество вспомогательных контактов", _
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
                                                                       TPA.ValueType.uint, _
                                                                       TPA.ValueType.ureal, _
                                                                       TPA.ValueType.ureal, _
                                                                       TPA.ValueType.ureal, _
                                                                       TPA.ValueType.ureal}, _
                                      "Аппарат")
        device.Name = res(1)
        device.KontACount = res(2)
        device.KontBCount = res(3)
        device.U = res(4)
        device.Uvalid = res(5)
        device.I = res(6)
        device.Ivalid = res(7)
        device.R = res(8)
        device.Rvalid = res(9)
        Try
            If (newObj And device.Name.Length > 0 And (Not Base.devices.ObjectInFile(device.Name))) _
            Or ((Not newObj) And device.Name.Length > 0 And (name = device.Name Or (Not Base.devices.ObjectInFile(device.Name)))) Then
                If device.KontACount > 0 Then
                    res.Clear()
                    res.Add(device.РастворКонтактаAMin)
                    res.Add(device.РастворКонтактаAMax)
                    res.Add(device.ПровалКонтактаAMin)
                    res.Add(device.ПровалКонтактаAMax)
                    res.Add(device.НажатиеНачAMin)
                    res.Add(device.НажатиеНачAMax)
                    res.Add(device.НажатиеКонAMin)
                    res.Add(device.НажатиеКонAMax)
                    res = TPA.DialogForms.Setting(res, _
                                                  New String() {"Раствор контакта (min), мм", _
                                                                "Раствор контакта (max), мм", _
                                                                "Провал контакта (min), мм", _
                                                                "Провал контакта (max), мм", _
                                                                "Усилие нажатия начальное (min), Н", _
                                                                "Усилие нажатия начальное (max), Н", _
                                                                "Усилие нажатия конечное (min), Н", _
                                                                "Усилие нажатия конечное (max), Н"}, _
                                                  New TPA.DialogForms.ValueType() {TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal}, _
                                                  "Контакт силовой")
                    device.РастворКонтактаAMin = res(1)
                    device.РастворКонтактаAMax = res(2)
                    device.ПровалКонтактаAMin = res(3)
                    device.ПровалКонтактаAMax = res(4)
                    device.НажатиеНачAMin = res(5)
                    device.НажатиеНачAMax = res(6)
                    device.НажатиеКонAMin = res(7)
                    device.НажатиеКонAMax = res(8)
                End If
                If device.KontBCount > 0 Then
                    res.Clear()
                    res.Add(device.РастворКонтактаBMin)
                    res.Add(device.РастворКонтактаBMax)
                    res.Add(device.ПровалКонтактаBMin)
                    res.Add(device.ПровалКонтактаBMax)
                    res.Add(device.НажатиеНачBMin)
                    res.Add(device.НажатиеНачBMax)
                    res.Add(device.НажатиеКонBMin)
                    res.Add(device.НажатиеКонBMax)
                    res = TPA.DialogForms.Setting(res, _
                                                  New String() {"Раствор контакта (min), мм", _
                                                                "Раствор контакта (max), мм", _
                                                                "Провал контакта (min), мм", _
                                                                "Провал контакта (max), мм", _
                                                                "Усилие нажатия начальное (min), Н", _
                                                                "Усилие нажатия начальное (max), Н", _
                                                                "Усилие нажатия конечное (min), Н", _
                                                                "Усилие нажатия конечное (max), Н"}, _
                                                  New TPA.DialogForms.ValueType() {TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal, _
                                                                                   TPA.ValueType.ureal}, _
                                                  "Контакт вспомогательный")
                    device.РастворКонтактаBMin = res(1)
                    device.РастворКонтактаBMax = res(2)
                    device.ПровалКонтактаBMin = res(3)
                    device.ПровалКонтактаBMax = res(4)
                    device.НажатиеНачBMin = res(5)
                    device.НажатиеНачBMax = res(6)
                    device.НажатиеКонBMin = res(7)
                    device.НажатиеКонBMax = res(8)
                End If
                device.Save()
            Else
                If device.Name.Length > 0 Then
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
            TPA.DialogForms.WaitFormStart()
            local = TPA.DialogForms.Correct(Base.devices.Read(), head)
            TPA.DialogForms.WaitFormStart()
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                    CreateDevice()
                Case TPA.resultOfCorrect.Correct
                    CreateDevice(local.Elem)
                Case TPA.resultOfCorrect.Del
                    Base.devices.Delete(local.Elem)
            End Select
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
        TPA.DialogForms.WaitFormStop()
    End Sub

    ''' <summary>
    ''' Выбор устройства из списка, запись его в модуль Test
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeviceSelect()
        Test.device.Read(TPA.DialogForms.Selection(Base.devices.Read(), "Аппарат"))
        If Test.device.Name = Nothing Then Test.device.Name = ""
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
            TPA.DialogForms.WaitFormStart()
            local = TPA.DialogForms.Correct(Base.users.Read(), head)
            TPA.DialogForms.WaitFormStart()
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                    CreateUser()
                Case TPA.resultOfCorrect.Correct
                    If CreateUser(local.Elem) Then Base.users.Delete(local.Elem)
                Case TPA.resultOfCorrect.Del
                    Base.users.Delete(local.Elem)
            End Select
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
        TPA.DialogForms.WaitFormStop()
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
