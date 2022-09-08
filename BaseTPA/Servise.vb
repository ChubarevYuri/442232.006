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
        Dim val As String() = New String() {"Журнал протоколов", "Настройки"}
        Select Case TPA.DialogForms.Selection(val, "Сервис")
            Case val(0)
                TPA.Log.Print(TPA.Rank.OK, "    Журнал протоколов")
                SelectReport(val(0))
            Case val(1)
                Dim password As String = ""
                TPA.Keyboard.Password(password)
                If password = Base.setting.Read("ПАРОЛЬ", "значение") Then
                    TPA.Log.Print(TPA.Rank.OK, "    Настройки")
                    setting(val(1))
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
        Dim val As String() = New String() {"Операторы", "Аппараты", "Очистить журнал протоколов", "Выйти из приложения"}
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

#Region "Аппарат"

    ''' <summary>
    ''' создание устройства
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDevice(Optional ByVal name As String = "") As Boolean
        CreateDevice = True
        Dim newObj As Boolean = True
        If Base.devices.ObjectInFile(name) Then newObj = False
        'форма ввода параметров устройства ниже
        Dim device As Device = New Device()
        If Not newObj Then device.Read(name)
        Using f = New DeviceForm(device)
            f.ShowDialog()
            If f.DialogResult = DialogResult.OK Then
                devices.Delete(name)
                f.resilt.Save()
            End If
            TPA.DialogForms.WaitFormStop()
        End Using
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

    ''' <summary>
    ''' Выбор оператора из списка, запись его в модуль Test
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MasterSelect()
        Test.master = TPA.DialogForms.Selection(Base.users.Read(), "Мастер")
        If Test.master = Nothing Then Test.master = ""
    End Sub

#End Region

    ''' <summary>
    ''' Очистка истории протоколов, сброс нумерации
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearHistory()
        If TPA.DialogForms.Message("Вы точно хотите произвести сброс журнала протоколов?" _
                                   & Chr(13) & Chr(10) & _
                                   "Журнал протоколов будет очищен безвозвратно. Восстановление очищенного журнала НЕВОЗМОЖНО.", _
                                   "Внимание", _
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
        TPA.DialogForms.WaitFormStart()
        TPA.Log.Print(TPA.Rank.MESSAGE, "Осуществлен преднамеренный выход из приложения")
        BaseForm.OperationSleep()
        TPA.DeviseInspection.stopInspection()
        Threading.Thread.Sleep(2000)
        TPA.DialogForms.WaitFormStop()
        TPA.Main.TaskBarShow()
        Application.Exit()
    End Sub

End Module
