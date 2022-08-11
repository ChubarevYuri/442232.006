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

    Public Sub Create(ByVal num As Integer, ByVal device As Device, ByVal user As String, ByVal timeStart As DateTime)
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
        _report.Line(New TPA.Line("Аппарат: " & If(device.name.Length > 0, _
                                                      device.name, _
                                                      "_____________________") & _
                                                      If(device.num.Length > 0, " № " & device.num, ""), _
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
                                  New TPA.Line(device.Ustr, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.UI.ToString, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, boolToStr(device.ControlUI), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        table.Add(New TPA.Line() {New TPA.Line("Напряжение отключения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("В", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.Ustr, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.UO.ToString, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, boolToStr(device.ControlUO), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        table.Add(New TPA.Line() {New TPA.Line("Ток включения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("А", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.Istr, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.II.ToString(Base.doubleformat), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.I > 0, boolToStr(device.ControlII), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        table.Add(New TPA.Line() {New TPA.Line("Ток выключения", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("А", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.Istr, _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(device.IO.ToString(Base.doubleformat), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.I > 0, boolToStr(device.ControlIO), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None)})
        If device.РабочиеПарамерты.R Then
            table.Add(New TPA.Line() {New TPA.Line("Сопротивление блока катушек", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line("Ом", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.R > 0, device.Rstr, ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.Rfact.ToString(Base.doubleformat), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.R > 0, boolToStr(device.ControlR), ""), _
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
                                  New TPA.Line(If(device.U > 0, If(device.ControlU, "раб.", "не раб."), ""), _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line(If(device.U > 0, boolToStr(device.ControlU), ""), _
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
                 New Integer() {13, 4, 5, 4, 5})
        For i As Integer = 0 To device.KontACount - 1
            If device.РабочиеПарамерты.РастворКонтактов Or _
               device.РабочиеПарамерты.ПровалКонтактов Or _
               device.РабочиеПарамерты.НажатиеНач Or _
               device.РабочиеПарамерты.НажатиеКон Or _
               device.РабочиеПарамерты.Состояние Then
                tableNum += 1
                _report.Line("")
                Dim rows As Integer = 2 + _
                                      If(device.РабочиеПарамерты.РастворКонтактов, 1, 0) + _
                                      If(device.РабочиеПарамерты.ПровалКонтактов, 1, 0) + _
                                      If(device.РабочиеПарамерты.НажатиеНач, 1, 0) + _
                                      If(device.РабочиеПарамерты.НажатиеКон, 1, 0) + _
                                      If(device.РабочиеПарамерты.Состояние, 1, 0)
                _report.ReserveLines(rows)
                _report.Line(New TPA.Line(tableNum & ". Контакт силовой № " & (i + 1)))
                table = New Collection
                If device.РабочиеПарамерты.Состояние Then
                    table.Add(New TPA.Line() {New TPA.Line("Состояние контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("---", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("испр.", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.СостояниеA(i), "испр.", "неиспр."), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(boolToStr(device.СостояниеA(i)), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.РастворКонтактов Then
                    table.Add(New TPA.Line() {New TPA.Line("Раствор контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("мм", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.РастворКонтактаAstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.РастворКонтактаAFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.РастворКонтактаAMax > 0, boolToStr(device.ControlРастворКонтактаA(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.ПровалКонтактов Then
                    table.Add(New TPA.Line() {New TPA.Line("Провал контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("мм", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.ПровалКонтактаAstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.ПровалКонтактаAFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.ПровалКонтактаAMax > 0, boolToStr(device.ControlПровалКонтактаA(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.НажатиеНач Then
                    table.Add(New TPA.Line() {New TPA.Line("Нажатие (начальное)", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("Н", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеНачAstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеНачAFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеНачAMax > 0, boolToStr(device.ControlНажатиеНачA(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.НажатиеКон Then
                    table.Add(New TPA.Line() {New TPA.Line("Нажатие (конечное)", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("Н", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеКонAstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеКонAFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеКонAMax > 0, boolToStr(device.ControlНажатиеКонA(i)), ""), _
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
                         New Integer() {13, 4, 5, 4, 5})
            End If
        Next
        For i As Integer = 0 To device.KontBCount - 1
            If device.РабочиеПарамерты.РастворКонтактов Or _
               device.РабочиеПарамерты.ПровалКонтактов Or _
               device.РабочиеПарамерты.НажатиеНач Or _
               device.РабочиеПарамерты.НажатиеКон Or _
               device.РабочиеПарамерты.Состояние Then
                tableNum += 1
                _report.Line("")
                Dim rows As Integer = 2 + _
                                      If(device.РабочиеПарамерты.РастворКонтактов, 1, 0) + _
                                      If(device.РабочиеПарамерты.ПровалКонтактов, 1, 0) + _
                                      If(device.РабочиеПарамерты.НажатиеНач, 1, 0) + _
                                      If(device.РабочиеПарамерты.НажатиеКон, 1, 0) + _
                                      If(device.РабочиеПарамерты.Состояние, 1, 0)
                _report.ReserveLines(rows)
                _report.Line(New TPA.Line(tableNum & ". Контакт вспомогательный № " & (i + 1)))
                table = New Collection
                If device.РабочиеПарамерты.Состояние Then
                    table.Add(New TPA.Line() {New TPA.Line("Состояние контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("---", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("испр.", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.СостояниеB(i), "испр.", "неиспр."), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(boolToStr(device.СостояниеB(i)), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.РастворКонтактов Then
                    table.Add(New TPA.Line() {New TPA.Line("Раствор контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("мм", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.РастворКонтактаBstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.РастворКонтактаBFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.РастворКонтактаBMax > 0, boolToStr(device.ControlРастворКонтактаB(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.ПровалКонтактов Then
                    table.Add(New TPA.Line() {New TPA.Line("Провал контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("мм", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.ПровалКонтактаBstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.ПровалКонтактаBFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.ПровалКонтактаBMax > 0, boolToStr(device.ControlПровалКонтактаB(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.НажатиеНач Then
                    table.Add(New TPA.Line() {New TPA.Line("Нажатие (начальное)", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("Н", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеНачBstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеНачBFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеНачBMax > 0, boolToStr(device.ControlНажатиеНачB(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                If device.РабочиеПарамерты.НажатиеКон Then
                    table.Add(New TPA.Line() {New TPA.Line("Нажатие (конечное)", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("Н", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеКонBstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеКонBFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеКонBMax > 0, boolToStr(device.ControlНажатиеКонB(i)), ""), _
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
                         New Integer() {13, 4, 5, 4, 5})
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
                 New Integer() {34, 14, 24})
        _report.Line(New TPA.Line("___ __________ 20___ г.", _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        _report.Line("")
        _report.ReserveLines(6)
        _report.Line(New TPA.Line() {New TPA.Line("Заключение: ", _
                                                  TPA.Line.Align.Left, _
                                                  TPA.Line.StyleLine.None), _
                                       New TPA.Line("", _
                                                    TPA.Line.Align.Left, _
                                                    TPA.Line.StyleLine.FillUnderline)}, _
                 New Integer() {2, 9})
        _report.Line(New TPA.Line("", _
                                  TPA.Line.Align.Left, _
                                  TPA.Line.StyleLine.FillUnderline))
        _report.Line(New TPA.Line("", _
                                  TPA.Line.Align.Left, _
                                  TPA.Line.StyleLine.FillUnderline))
        _report.Line("")
        _report.Line(New TPA.Line() {New TPA.Line("", _
                                                  TPA.Line.Align.Left, _
                                                  TPA.Line.StyleLine.None), _
                                       New TPA.Line("", _
                                           TPA.Line.Align.Center, _
                                           TPA.Line.StyleLine.FillUnderline), _
                                       New TPA.Line("/ ", _
                                                    TPA.Line.Align.Left, _
                                                    TPA.Line.StyleLine.FillUnderline), _
                                       New TPA.Line("/", _
                                                    TPA.Line.Align.Center, _
                                                    TPA.Line.StyleLine.FillUnderline)}, _
                 New Integer() {34, 14, 24})
        _report.Line(New TPA.Line("___ __________ 20___ г.", _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
    End Sub


    Public Sub Save(ByVal num As Integer, ByVal device As Device, ByVal user As String, ByVal timeStart As DateTime)
        Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim message As String = ""
        dict.Add("заголовок", "№" & num & " (" & _
                 If(device.Name.Length > 0, device.Name & " ", "") & _
                 If(device.Num.Length > 0, "<" & device.Num & "> ", "") & _
                 If(user.Length > 0, user & " ", "") & _
                 timeStart.ToString("dd.MM.yyyy HH:mm") & " " & _
                 boolToStr(device.Control) & ")")
        dict.Add("User", user)
        dict.Add("Time", timeStart)
        dict.Add("Name", device.name)
        dict.Add("Num", device.num)
        dict.Add("РабочиеПарамерты.R", device.РабочиеПарамерты.R)
        dict.Add("РабочиеПарамерты.Состояние", device.РабочиеПарамерты.Состояние)
        dict.Add("РабочиеПарамерты.РастворКонтактов", device.РабочиеПарамерты.РастворКонтактов)
        dict.Add("РабочиеПарамерты.ПровалКонтактов", device.РабочиеПарамерты.ПровалКонтактов)
        dict.Add("РабочиеПарамерты.НажатиеНач", device.РабочиеПарамерты.НажатиеНач)
        dict.Add("РабочиеПарамерты.НажатиеКон", device.РабочиеПарамерты.НажатиеКон)
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
        dict.Add("KontACount", device.KontACount)
        dict.Add("KontBCount", device.KontBCount)
        dict.Add("РастворКонтактаAMin", device.РастворКонтактаAMin)
        dict.Add("РастворКонтактаAMax", device.РастворКонтактаAMax)
        dict.Add("ПровалКонтактаAMin", device.ПровалКонтактаAMin)
        dict.Add("ПровалКонтактаAMax", device.ПровалКонтактаAMax)
        dict.Add("НажатиеНачAMin", device.НажатиеНачAMin)
        dict.Add("НажатиеНачAMax", device.НажатиеНачAMax)
        dict.Add("НажатиеКонAMin", device.НажатиеКонAMin)
        dict.Add("НажатиеКонAMax", device.НажатиеКонAMax)
        dict.Add("РастворКонтактаBMin", device.РастворКонтактаBMin)
        dict.Add("РастворКонтактаBMax", device.РастворКонтактаBMax)
        dict.Add("ПровалКонтактаBMin", device.ПровалКонтактаBMin)
        dict.Add("ПровалКонтактаBMax", device.ПровалКонтактаBMax)
        dict.Add("НажатиеНачBMin", device.НажатиеНачBMin)
        dict.Add("НажатиеНачBMax", device.НажатиеНачBMax)
        dict.Add("НажатиеКонBMin", device.НажатиеКонBMin)
        dict.Add("НажатиеКонBMax", device.НажатиеКонBMax)
        For i As Integer = 0 To device.KontACount - 1
            dict.Add("СостояниеA(" & i & ")", device.СостояниеA(i))
            dict.Add("РастворКонтактаAFact(" & i & ")", device.РастворКонтактаAFact(i))
            dict.Add("ПровалКонтактаAFact(" & i & ")", device.ПровалКонтактаAFact(i))
            dict.Add("НажатиеНачAFact(" & i & ")", device.НажатиеНачAFact(i))
            dict.Add("НажатиеКонAFact(" & i & ")", device.НажатиеКонAFact(i))
        Next
        For i As Integer = 0 To device.KontBCount - 1
            dict.Add("СостояниеB(" & i & ")", device.СостояниеB(i))
            dict.Add("РастворКонтактаBFact(" & i & ")", device.РастворКонтактаBFact(i))
            dict.Add("ПровалКонтактаBFact(" & i & ")", device.ПровалКонтактаBFact(i))
            dict.Add("НажатиеНачBFact(" & i & ")", device.НажатиеНачBFact(i))
            dict.Add("НажатиеКонBFact(" & i & ")", device.НажатиеКонBFact(i))
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
        TPA.DialogForms.WaitFormStart()
        Dim dict As Dictionary(Of String, String) = Base.reports.Read(num)
        If dict.Count > 0 Then
            Dim key As String
            Dim user As String = ""
            Dim timeStart As DateTime = Now
            Dim device As Device = New Device()
            key = "РабочиеПарамерты.Состояние"
            Try
                device.РабочиеПарамерты.Состояние = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.Состояние = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.РастворКонтактов"
            Try
                device.РабочиеПарамерты.РастворКонтактов = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.РастворКонтактов = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.ПровалКонтактов"
            Try
                device.РабочиеПарамерты.ПровалКонтактов = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.ПровалКонтактов = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.НажатиеНач"
            Try
                device.РабочиеПарамерты.НажатиеНач = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.НажатиеНач = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.НажатиеКон"
            Try
                device.РабочиеПарамерты.НажатиеКон = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.НажатиеКон = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.R"
            Try
                device.РабочиеПарамерты.R = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.R = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
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
                device.Name = dict(key)
            Catch ex As Exception
                device.Name = ""
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "Num"
            Try
                device.Num = dict(key)
            Catch ex As Exception
                device.Num = ""
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
                device.II = 0
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
            key = "KontACount"
            Try
                device.KontACount = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.KontACount = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "KontBCount"
            Try
                device.KontBCount = Convert.ToInt32(dict(key))
            Catch ex As Exception
                device.KontBCount = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РастворКонтактаAMin"
            Try
                device.РастворКонтактаAMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.РастворКонтактаAMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РастворКонтактаAMax"
            Try
                device.РастворКонтактаAMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.РастворКонтактаAMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ПровалКонтактаAMin"
            Try
                device.ПровалКонтактаAMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.ПровалКонтактаAMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ПровалКонтактаAMax"
            Try
                device.ПровалКонтактаAMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.ПровалКонтактаAMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеНачAMin"
            Try
                device.НажатиеНачAMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеНачAMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеНачAMax"
            Try
                device.НажатиеНачAMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеНачAMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеКонAMin"
            Try
                device.НажатиеКонAMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеКонAMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеКонAMax"
            Try
                device.НажатиеКонAMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеКонAMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РастворКонтактаBMin"
            Try
                device.РастворКонтактаBMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.РастворКонтактаBMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РастворКонтактаBMax"
            Try
                device.РастворКонтактаBMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.РастворКонтактаBMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ПровалКонтактаBMin"
            Try
                device.ПровалКонтактаBMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.ПровалКонтактаBMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ПровалКонтактаBMax"
            Try
                device.ПровалКонтактаBMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.ПровалКонтактаBMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеНачBMin"
            Try
                device.НажатиеНачBMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеНачBMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеНачBMax"
            Try
                device.НажатиеНачBMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеНачBMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеКонBMin"
            Try
                device.НажатиеКонBMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеКонBMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеКонBMax"
            Try
                device.НажатиеКонBMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеКонBMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            For i As Integer = 0 To device.KontACount - 1
                key = "СостояниеA(" & i & ")"
                Try
                    device.СостояниеA(i) = Convert.ToBoolean(dict(key))
                Catch ex As Exception
                    device.СостояниеA(i) = False
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "РастворКонтактаAFact(" & i & ")"
                Try
                    device.РастворКонтактаAFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.РастворКонтактаAFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "ПровалКонтактаAFact(" & i & ")"
                Try
                    device.ПровалКонтактаAFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.ПровалКонтактаAFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеНачAFact(" & i & ")"
                Try
                    device.НажатиеНачAFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеНачAFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеКонAFact(" & i & ")"
                Try
                    device.НажатиеКонAFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеКонAFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
            Next
            For i As Integer = 0 To device.KontBCount - 1
                key = "СостояниеB(" & i & ")"
                Try
                    device.СостояниеB(i) = Convert.ToBoolean(dict(key))
                Catch ex As Exception
                    device.СостояниеB(i) = False
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "РастворКонтактаBFact(" & i & ")"
                Try
                    device.РастворКонтактаBFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.РастворКонтактаBFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "ПровалКонтактаBFact(" & i & ")"
                Try
                    device.ПровалКонтактаBFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.ПровалКонтактаBFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеНачBFact(" & i & ")"
                Try
                    device.НажатиеНачBFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеНачBFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеКонBFact(" & i & ")"
                Try
                    device.НажатиеКонBFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеКонBFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
            Next
            Create(num, device, user, timeStart)
            TPA.WaitFormStop()
            TPA.DialogForms.Report(_report)
        End If
        TPA.WaitFormStop()
    End Sub

    ''' <summary>
    ''' Отображение протокола с параметров
    ''' </summary>
    ''' <param name="user"></param>
    ''' <param name="device"></param>
    ''' <param name="timeStart"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Show(ByVal user As String, ByVal device As Device, ByVal timeStart As DateTime) As Boolean
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
