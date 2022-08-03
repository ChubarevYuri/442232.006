Module Report

    ''' <summary>
    ''' true - "норма"
    ''' false = "не соотв."
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function boolToStr(ByVal val As Boolean) As String
        Return If(val, "норма", "не соотв.")
    End Function

    Private _report As New TPA.Report()

    Public Sub Create(ByVal num As Integer, ByVal device As Base.DeviceStruct, ByVal user As String, ByVal timeStart As DateTime)
        _report = New TPA.Report()
        Dim tableNum As Integer = 1
        'чердак
        _report.Line(New TPA.Line(Base.setting.Read("ПРОТОКОЛ", _
                                                      "компания"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None, _
                                  10, _
                                  False))
        _report.Line(New TPA.Line(Base.setting.Read("ПРОТОКОЛ", _
                                                      "филиал"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None, _
                                  10, _
                                  False))
        Dim text As String = "Протокол испытания №"
        If num > 0 Then
            text &= num
        Else
            text &= "___"
        End If
        _report.Line(New TPA.Line(text, _
                                  0, 0, 1, _
                                  TPA.Line.Align.Center, _
                                  TPA.Line.StyleLine.None, _
                                  True))
        _report.Line(New TPA.Line("Дата и время испытания: " & timeStart.ToString("dd.MM.yyyy HH:mm"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        _report.Line(New TPA.Line("Испытательный стенд: " & Base.setting.Read("ПРОТОКОЛ", _
                                                                                "стенд"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        _report.Line(New TPA.Line("Устройство: " & If(device.name.Length > 0, _
                                                      device.name, _
                                                      "_____________________"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        'тело
        _report.Line(New TPA.Line(tableNum & ". Общие параметры"))
        Dim table As New Collection

        table.Add(New TPA.Line() {New TPA.Line("Напряжение включения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("В", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, "≤" & device.Umin, ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.UI.ToString, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, boolToStr(device.UIcontrol), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        table.Add(New TPA.Line() {New TPA.Line("Напряжение отключения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("В", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, "≤" & device.Umin, ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.UO.ToString, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, boolToStr(device.UOcontrol), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        table.Add(New TPA.Line() {New TPA.Line("Ток включения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("А", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.I > 0, device.Istring, ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.II.ToString(Base.doubleformat), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.I > 0, boolToStr(device.IIcontrol), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        table.Add(New TPA.Line() {New TPA.Line("Ток выключения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("А", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.I > 0, device.Istring, ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.IO.ToString(Base.doubleformat), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.I > 0, boolToStr(device.IOcontrol), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        If device.ControlsParameters.R Then
            table.Add(New TPA.Line() {New TPA.Line("Сопротивление блока катушек", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line("Ом", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.R > 0, device.Rstring, ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.Rfact.ToString(Base.doubleformat), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.R > 0, boolToStr(device.Rcontrol), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None)})
        End If
        table.Add(New TPA.Line() {New TPA.Line("Работоспособность при U min", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("---", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("раб.", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, If(device.РаботоспособностьПриUmin, "раб.", "не раб."), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, boolToStr(device.РаботоспособностьПриUmin), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        _report.Table(New TPA.Line() {New TPA.Line("Параметр", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None, _
                                                   True), _
                                      New TPA.Line("Ед.изм.", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None, _
                                                   True), _
                                      New TPA.Line("Норма", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None, _
                                                   True), _
                                      New TPA.Line("Факт", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None, _
                                                           True), _
                                      New TPA.Line("Результат", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None, _
                                                   True)}, _
                 table, _
                 New Integer() {3, 1, 1, 1, 1})
        For i As Integer = 0 To device.KontCount - 1
            If device.ControlsParameters.РастворКонтактов Or device.ControlsParameters.ПровалКонтактов Or device.ControlsParameters.НажатиеНач Or device.ControlsParameters.НажатиеКон Or device.ControlsParameters.Состояние Then
                tableNum += 1
                _report.Line("")
                _report.Line(New TPA.Line(tableNum & ". Контакт № " & (i + 1)))
                table = New Collection
                If device.ControlsParameters.Состояние Then
                    table.Add(New TPA.Line() {New TPA.Line("Состояние контактов", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("---", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("испр.", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.Состояние(i), "испр.", "неиспр."), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(boolToStr(device.Состояние(i)), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.ControlsParameters.РастворКонтактов Then
                    table.Add(New TPA.Line() {New TPA.Line("Раствор контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("мм", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.РастворКонтактаMax(i) > 0, device.РастворКонтактаMinMaxString(i), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.РастворКонтактаFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.РастворКонтактаMax(i) > 0, boolToStr(device.РастворКонтактаControl(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.ControlsParameters.ПровалКонтактов Then
                    table.Add(New TPA.Line() {New TPA.Line("Провал контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("мм", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.ПровалКонтактаMax(i) > 0, device.ПровалКонтактаMinMaxString(i), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.ПровалКонтактаFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.ПровалКонтактаMax(i) > 0, boolToStr(device.ПровалКонтактаControl(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.ControlsParameters.НажатиеНач Then
                    table.Add(New TPA.Line() {New TPA.Line("Нажатие на мостик (начальное)", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("кг", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеНачMax(i) > 0, device.НажатиеНачMinMaxString(i), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеНачFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеНачMax(i) > 0, boolToStr(device.НажатиеНачControl(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.ControlsParameters.НажатиеКон Then
                    table.Add(New TPA.Line() {New TPA.Line("Нажатие на мостик (конечное)", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("кг", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеКонMax(i) > 0, device.НажатиеКонMinMaxString(i), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеКонFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеКонMax(i) > 0, boolToStr(device.НажатиеКонControl(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                _report.Table(New TPA.Line() {New TPA.Line("Параметр", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None, _
                                                           True), _
                                              New TPA.Line("Ед.изм.", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None, _
                                                           True), _
                                              New TPA.Line("Норма", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None, _
                                                           True), _
                                              New TPA.Line("Факт", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None, _
                                                                   True), _
                                              New TPA.Line("Результат", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None, _
                                                           True)}, _
                         table, _
                         New Integer() {3, 1, 1, 1, 1})
            End If
        Next
        'подвал
        _report.Line("")
        _report.Line(New TPA.Line() {New TPA.Line("Испытания провёл: ", _
                                                  TPA.Line.Align.Left, _
                                                  TPA.Line.StyleLine.None), _
                                       New TPA.Line("", _
                                           TPA.Line.Align.Center, _
                                           TPA.Line.StyleLine.FillUnderline), _
                                       New TPA.Line("/ " & user, _
                                                    TPA.Line.Align.Left, _
                                                    TPA.Line.StyleLine.FillUnderline), _
                                       New TPA.Line("/", _
                                                    TPA.Line.Align.Center, _
                                                    TPA.Line.StyleLine.FillUnderline)}, _
                 New Integer() {39, 14, 24})
        _report.Line(New TPA.Line("___ __________ 20___ г.", _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        _report.Line("")
        _report.Line(New TPA.Line() {New TPA.Line("Заключение: ", _
                                                  TPA.Line.Align.Left, _
                                                  TPA.Line.StyleLine.None), _
                                       New TPA.Line("", _
                                                    TPA.Line.Align.Left, _
                                                    TPA.Line.StyleLine.FillUnderline)}, _
                 New Integer() {1, 5})
        _report.Line(New TPA.Line("", _
                                  TPA.Line.Align.Left, _
                                  TPA.Line.StyleLine.FillUnderline))
        _report.Line(New TPA.Line("", _
                                  TPA.Line.Align.Left, _
                                  TPA.Line.StyleLine.FillUnderline))
    End Sub


    Public Sub Save(ByVal num As Integer, ByVal device As Base.DeviceStruct, ByVal user As String, ByVal timeStart As DateTime)
        Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim message As String = ""
        dict.Add("заголовок", "№" & num & " (" & If(user.Length > 0, user & " ", "") & timeStart.ToString("dd.MM.yyyy HH:mm") & " " & boolToStr(device.FillControl) & ")")
        dict.Add("User", user)
        dict.Add("Time", timeStart)
        dict.Add("Name", device.name)
        dict.Add("ControlsParameters.R", device.ControlsParameters.R)
        dict.Add("ControlsParameters.Состояние", device.ControlsParameters.Состояние)
        dict.Add("ControlsParameters.РастворКонтактов", device.ControlsParameters.РастворКонтактов)
        dict.Add("ControlsParameters.ПровалКонтактов", device.ControlsParameters.ПровалКонтактов)
        dict.Add("ControlsParameters.НажатиеНач", device.ControlsParameters.НажатиеНач)
        dict.Add("ControlsParameters.НажатиеКон", device.ControlsParameters.НажатиеКон)
        dict.Add("U", device.U)
        dict.Add("Uvalid", device.Uvalid)
        dict.Add("UI", device.UI)
        dict.Add("UO", device.UO)
        dict.Add("I", device.I)
        dict.Add("Ivalid", device.Ivalid)
        dict.Add("II", device.II)
        dict.Add("IO", device.IO)
        dict.Add("R", device.R)
        dict.Add("Rvalid", device.Rvalid)
        dict.Add("Rfact", device.Rfact)
        dict.Add("KontCount", device.KontCount)
        For i As Integer = 0 To device.KontCount - 1
            Dim b As Boolean = device.Состояние(i)
            dict.Add("Состояние(" & i & ")", device.Состояние(i))
            dict.Add("РастворКонтактаMin(" & i & ")", device.РастворКонтактаMin(i))
            dict.Add("РастворКонтактаMax(" & i & ")", device.РастворКонтактаMax(i))
            dict.Add("РастворКонтактаFact(" & i & ")", device.РастворКонтактаFact(i))
            dict.Add("ПровалКонтактаMin(" & i & ")", device.ПровалКонтактаMin(i))
            dict.Add("ПровалКонтактаMax(" & i & ")", device.ПровалКонтактаMax(i))
            dict.Add("ПровалКонтактаFact(" & i & ")", device.ПровалКонтактаFact(i))
            dict.Add("НажатиеНачMin(" & i & ")", device.НажатиеНачMin(i))
            dict.Add("НажатиеНачMax(" & i & ")", device.НажатиеНачMax(i))
            dict.Add("НажатиеНачFact(" & i & ")", device.НажатиеНачFact(i))
            dict.Add("НажатиеКонMin(" & i & ")", device.НажатиеКонMin(i))
            dict.Add("НажатиеКонMax(" & i & ")", device.НажатиеКонMax(i))
            dict.Add("НажатиеКонFact(" & i & ")", device.НажатиеКонFact(i))
        Next
        Base.reports.Write(num, dict)
    End Sub

#Region "Show"

    ''' <summary>
    ''' отображение протокола из базы
    ''' </summary>
    ''' <param name="num"></param>
    ''' <remarks></remarks>
    Public Sub Show(ByVal num As Integer)
        Dim dict As Dictionary(Of String, String) = Base.reports.Read(num)
        If dict.Count > 0 Then
            Dim key As String
            Dim user As String = ""
            Dim timeStart As DateTime = Now
            Dim device As Base.DeviceStruct = New Base.DeviceStruct
            Dim control As Base.coltrolStruct = New Base.coltrolStruct
            key = "ControlsParameters.Состояние"
            Try
                control.Состояние = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                control.Состояние = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ControlsParameters.РастворКонтактов"
            Try
                control.РастворКонтактов = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                control.РастворКонтактов = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ControlsParameters.ПровалКонтактов"
            Try
                control.ПровалКонтактов = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                control.ПровалКонтактов = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ControlsParameters.НажатиеНач"
            Try
                control.НажатиеНач = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                control.НажатиеНач = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ControlsParameters.НажатиеКон"
            Try
                control.НажатиеКон = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                control.НажатиеКон = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ControlsParameters.R"
            Try
                control.R = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                control.R = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            device.ControlsParameters = control
            key = "User"
            Try
                user = dict(key)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Time"
            Try
                timeStart = Convert.ToDateTime(dict(key))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Name"
            Try
                device.name = dict(key)
            Catch ex As Exception
                device.name = ""
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "U"
            Try
                device.U = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.U = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Uvalid"
            Try
                device.Uvalid = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.Uvalid = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UI"
            Try
                device.UI = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.UI = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UO"
            Try
                device.UO = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.UO = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "I"
            Try
                device.I = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.I = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Ivalid"
            Try
                device.Ivalid = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ivalid = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "II"
            Try
                device.II = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.II =0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IO"
            Try
                device.IO = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.IO = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "R"
            Try
                device.R = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.R = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Rvalid"
            Try
                device.Rvalid = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Rvalid = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Rfact"
            Try
                device.Rfact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Rfact = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "KontCount"
            Try
                device.KontCount = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.KontCount = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            For i As Integer = 0 To device.KontCount - 1
                key = "Состояние(" & i & ")"
                Try
                    device.Состояние(i) = Convert.ToBoolean(dict(key))
                Catch ex As Exception
                    device.Состояние(i) = False
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "РастворКонтактаMin(" & i & ")"
                Try
                    device.РастворКонтактаMin(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.РастворКонтактаMin(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "РастворКонтактаMax(" & i & ")"
                Try
                    device.РастворКонтактаMax(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.РастворКонтактаMax(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "РастворКонтактаFact(" & i & ")"
                Try
                    device.РастворКонтактаFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.РастворКонтактаFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "ПровалКонтактаMin(" & i & ")"
                Try
                    device.ПровалКонтактаMin(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.ПровалКонтактаMin(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "ПровалКонтактаMax(" & i & ")"
                Try
                    device.ПровалКонтактаMax(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.ПровалКонтактаMax(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "ПровалКонтактаFact(" & i & ")"
                Try
                    device.ПровалКонтактаFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.ПровалКонтактаFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеНачMin(" & i & ")"
                Try
                    device.НажатиеНачMin(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеНачMin(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеНачMax(" & i & ")"
                Try
                    device.НажатиеНачMax(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеНачMax(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеНачFact(" & i & ")"
                Try
                    device.НажатиеНачFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеНачFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеКонMin(" & i & ")"
                Try
                    device.НажатиеКонMin(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеКонMin(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеКонMax(" & i & ")"
                Try
                    device.НажатиеКонMax(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеКонMax(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеКонFact(" & i & ")"
                Try
                    device.НажатиеКонFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеКонFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
            Next
            Create(readNum, device, user, timeStart)
            TPA.DialogForms.Report(_report)
        End If
    End Sub

    ''' <summary>
    ''' Отображение протокола с параметров
    ''' </summary>
    ''' <param name="user"></param>
    ''' <param name="device"></param>
    ''' <param name="timeStart"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Show(ByVal user As String, ByVal device As Base.DeviceStruct, ByVal timeStart As DateTime) As Boolean
        Create(readNum, device, user, timeStart)
        Show = TPA.DialogForms.Report(_report)
        If Show Then
            Save(readNum, device, user, timeStart)
        End If
    End Function

#End Region

    ''' <summary>
    ''' чтение номера очередного протокола
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property readNum() As Integer
        Get
            Try
                readNum = Convert.ToInt32(Base.setting.Read("ПРОТОКОЛ", "номер"))
            Catch ex As Exception
                readNum = 1
            End Try
        End Get
    End Property

    ''' <summary>
    ''' Генерация номера нового протокола
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function nextNum() As Integer
        nextNum = readNum
        If nextNum > 20000 Then nextNum = 0
        nextNum += 1
        Base.setting.Write("ПРОТОКОЛ", "номер", nextNum)
    End Function

    Public Property newReport() As Boolean
        Get
            Try
                Return Convert.ToBoolean(Base.setting.Read("ПРОТОКОЛ", "newReport"))
            Catch ex As Exception
                Return True
            End Try
        End Get
        Set(ByVal value As Boolean)
            If Not newReport And value Then Report.nextNum()
            Base.setting.Write("ПРОТОКОЛ", "newReport", value)
        End Set
    End Property
End Module
