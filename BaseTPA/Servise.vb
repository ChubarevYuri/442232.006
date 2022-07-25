Module Servise
    ''' <summary>
    ''' Окно Сервис
    '''     Работа с историей протоколов
    '''     Выбор оператора
    '''     Выбор Устройства
    '''     Системные настройки (под паролем)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Service()
        Dim val As String() = New String() {"История", "Оператор", "Устройство", "Настройки"}
        Select Case TPA.DialogForms.Selection(val, "Сервис")
            Case val(0)
                SelectReport(val(0))
            Case val(1)
                Test.user = TPA.DialogForms.Selection(Values.users.Read(), val(1))
            Case val(2)
                Test.device = TPA.DialogForms.Selection(Values.devices.Read(), val(2))
            Case val(3)
                Dim password As String = ""
                TPA.Keyboard.Password(password)
                If password = Values.setting.Read("ПАРОЛЬ", "значение") Then
                    setting("Настройки")
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
        Dim val As String() = New String() {"Операторы", "Устройства", "Очистить историю", "Выйти из приложения"}
        Do
            Select Case TPA.DialogForms.Selection(val, head)
                Case val(0)
                    SettingUser(val(0))
                Case val(1)
                    SettingDevice(val(1))
                Case val(2)
                    clearHistory()
                Case val(3)
                    If TPA.DialogForms.Message("Вы точно хотите закрыть приложение?", _
                                               "", _
                                               TPA.DialogForms.MsgType.warning, _
                                               True) Then
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
        Do
            Dim list As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
            TPA.DialogForms.WaitFormStart()
            Dim file As Dictionary(Of String, String) = Values.reports.ReadByParam("заголовок")
            For Each i In file
                Try
                    list.Add(i.Value, Convert.ToInt32(i.Key))
                Catch ex As Exception
                End Try
            Next
            TPA.DialogForms.WaitFormStop()
            local = TPA.DialogForms.Correct(list.Keys.ToArray, head, False, True)
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                Case TPA.resultOfCorrect.Correct
                    Report.Show(list.Item(local.Elem))
                Case TPA.resultOfCorrect.Del
                    Values.reports.Delete(list.Item(local.Elem))
            End Select
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
        If Values.devices.ObjectInFile(name) Then

            newObj = False
        Else

            newObj = True
        End If
        Dim res As String()
        'форма ввода параметров устройства ниже
        res = TPA.DialogForms.Setting(New String() {""}, _
                                      New String() {""}, _
                                      New TPA.DialogForms.ValueType() {TPA.ValueType.text}, _
                                      "Устройство")
        Try
            If (newObj And res(0).Length > 0 And (Not Values.devices.ObjectInFile(res(0)))) _
            Or ((Not newObj) And res(0).Length > 0 And (name = res(0) Or (Not Values.devices.ObjectInFile(res(0))))) Then
                'Сохранение параметров устройства сюда
            Else
                If res(0).Length > 0 Then
                    TPA.DialogForms.Message("Модель уже есть в базе.", "", TPA.DialogForms.MsgType.warning)
                Else
                    TPA.DialogForms.Message("Невозможно создать форсунку без названия.", "", TPA.DialogForms.MsgType.warning)
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
            local = TPA.DialogForms.Correct(Values.devices.Read(), head)
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                    CreateDevice()
                Case TPA.resultOfCorrect.Correct
                    CreateDevice(local.Elem)
                Case TPA.resultOfCorrect.Del
                    Values.devices.Delete(local.Elem)
            End Select
        Loop While local.FormResult <> TPA.resultOfCorrect.OK And local.FormResult <> TPA.resultOfCorrect.Cancel
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
            local = TPA.DialogForms.Correct(Values.users.Read(), head)
            Select Case local.FormResult
                Case TPA.resultOfCorrect.Add
                    CreateUser()
                Case TPA.resultOfCorrect.Correct
                    If CreateUser(local.Elem) Then Values.users.Delete(local.Elem)
                Case TPA.resultOfCorrect.Del
                    Values.users.Delete(local.Elem)
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
            If Not Values.users.ObjectInFile(user) Then
                If Values.users.Write(user, New Dictionary(Of String, String)) <> 0 Then
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
            Values.setting.Write("ПРОТОКОЛ", "номер", 0)
            Threading.Thread.Sleep(2000)
            TPA.DialogForms.WaitFormStop()
        End If
    End Sub

    ''' <summary>
    ''' Выход из приложения
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Quit()
        TPA.DeviseInspection.stopInspection()
        TPA.Main.TaskBarShow()
        Application.Exit()
    End Sub

End Module
