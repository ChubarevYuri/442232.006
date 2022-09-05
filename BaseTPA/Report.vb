Module Report

    ''' <summary>
    ''' true - "норма"
    ''' false = "не соотв."
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function boolToStr(ByVal val As Boolean) As String
        Return If(val, "соответствует", "не соответствует")
    End Function

    Private _report As New TPA.Report()

    Public Sub Create(ByVal num As Integer, ByVal device As Device, ByVal user As String, ByVal master As String, ByVal timeStart As DateTime)
        TPA.Log.Print(TPA.Rank.OK, "Вывод протокола № " & num)
        _report = New TPA.Report()
        Dim tableNum As Integer = 0
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
        _report.Line(New TPA.Line("Аппарат: " & If(device.Name.Length > 0, _
                                                      device.Name, _
                                                      "_____________________") & _
                                                      If(device.Num.Length > 0, " № " & device.Num, ""), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        'тело
        Dim table As New Collection
        If device.РабочиеПарамерты.I Or device.РабочиеПарамерты.O Or device.РабочиеПарамерты.R Or device.РабочиеПарамерты.work Then
            tableNum += 1
            _report.Line(New TPA.Line(tableNum & ". Общие параметры"))

            If device.РабочиеПарамерты.work Then _
            table.Add(New TPA.Line() {New TPA.Line("Вкл. при U мин", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line("---", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line("раб.", _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.UworkMaxMinStr.Length > 0, If(device.Uwork.Control, "раб.", "не раб."), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.UworkMaxMinStr.Length > 0, boolToStr(device.Uwork.Control), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None)})
            If device.РабочиеПарамерты.I Or device.РабочиеПарамерты.work Then _
            table.Add(New TPA.Line() {New TPA.Line("Напряжение вкл.", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.Uiei, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.UiMaxMinStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.UiFactStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.UiMaxMinStr.Length > 0, boolToStr(device.Ui.Control), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None)})
            If device.РабочиеПарамерты.I Or device.РабочиеПарамерты.work Then _
            table.Add(New TPA.Line() {New TPA.Line("Ток включения", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.Iei, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.IMaxMinStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.IiFactStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.IMaxMinStr.Length > 0, boolToStr(device.Ii.Control), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None)})
            If device.РабочиеПарамерты.O Then _
            table.Add(New TPA.Line() {New TPA.Line("Напряжение откл.", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.Uoei, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.UoMaxMinStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.UoFactStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.UoMaxMinStr.Length > 0, boolToStr(device.Uo.Control), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None)})
            If device.РабочиеПарамерты.O Then _
            table.Add(New TPA.Line() {New TPA.Line("Ток выключения", _
                                                   TPA.Line.Align.Left, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.Iei, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.IMaxMinStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(device.IoFactStr, _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None), _
                                      New TPA.Line(If(device.IMaxMinStr.Length > 0, boolToStr(device.Io.Control), ""), _
                                                   TPA.Line.Align.Center, _
                                                   TPA.Line.StyleLine.None)})
            If device.РабочиеПарамерты.R Then _
                table.Add(New TPA.Line() {New TPA.Line("Ra катушки", _
                                                       TPA.Line.Align.Left, _
                                                       TPA.Line.StyleLine.None), _
                                          New TPA.Line(device.Rei, _
                                                       TPA.Line.Align.Center, _
                                                       TPA.Line.StyleLine.None), _
                                          New TPA.Line(device.RMaxMinStr, _
                                                       TPA.Line.Align.Center, _
                                                       TPA.Line.StyleLine.None), _
                                          New TPA.Line(device.RFactStr, _
                                                       TPA.Line.Align.Center, _
                                                       TPA.Line.StyleLine.None), _
                                          New TPA.Line(If(device.RMaxMinStr.Length > 0, boolToStr(device.R.Control), ""), _
                                                       TPA.Line.Align.Center, _
                                                       TPA.Line.StyleLine.None)})
            _report.Table(New TPA.Line() {New TPA.Line("Параметр", _
                                                       TPA.Line.Align.Center, _
                                                       TPA.Line.StyleLine.None, _
                                                       True), _
                                          New TPA.Line("ед.из.", _
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
                     New Integer() {10, 3, 5, 4, 8})
        End If
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
                _report.Line(New TPA.Line(tableNum & ". Контакт главной цепи замыкающий № " & (i + 1)))
                table = New Collection
                If device.РабочиеПарамерты.Состояние Then
                    table.Add(New TPA.Line() {New TPA.Line("Состояние контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("---", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("норма", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.СостояниеA(i), "норма", "не норма"), _
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
                                              New TPA.Line("ед.из.", _
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
                         New Integer() {10, 3, 5, 4, 8})
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
                _report.Line(New TPA.Line(tableNum & ". Контакт главной цепи размыкающий № " & (i + 1)))
                table = New Collection
                If device.РабочиеПарамерты.Состояние Then
                    table.Add(New TPA.Line() {New TPA.Line("Состояние контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("---", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("норма", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.СостояниеB(i), "норма", "не норма"), _
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
                                              New TPA.Line("ед.из.", _
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
                         New Integer() {10, 3, 5, 4, 8})
            End If
        Next
        For i As Integer = 0 To device.KontCCount - 1
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
                _report.Line(New TPA.Line(tableNum & ". Контакт вспомогательной цепи № " & (i + 1)))
                table = New Collection
                If device.РабочиеПарамерты.Состояние Then
                    table.Add(New TPA.Line() {New TPA.Line("Состояние контакта", _
                                                           TPA.Line.Align.Left, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("---", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line("норма", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.СостояниеC(i), "норма", "не норма"), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(boolToStr(device.СостояниеC(i)), _
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
                                              New TPA.Line(device.РастворКонтактаCstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.РастворКонтактаCFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.РастворКонтактаCMax > 0, boolToStr(device.ControlРастворКонтактаC(i)), ""), _
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
                                              New TPA.Line(device.ПровалКонтактаCstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.ПровалКонтактаCFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.ПровалКонтактаCMax > 0, boolToStr(device.ControlПровалКонтактаC(i)), ""), _
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
                                              New TPA.Line(device.НажатиеНачCstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеНачCFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеНачCMax > 0, boolToStr(device.ControlНажатиеНачC(i)), ""), _
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
                                              New TPA.Line(device.НажатиеКонCstr, _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(device.НажатиеКонCFact(i).ToString(Base.doubleformat), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None), _
                                              New TPA.Line(If(device.НажатиеКонCMax > 0, boolToStr(device.ControlНажатиеКонC(i)), ""), _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None)})
                End If
                _report.Table(New TPA.Line() {New TPA.Line("Параметр", _
                                                           TPA.Line.Align.Center, _
                                                           TPA.Line.StyleLine.None, _
                                                           True), _
                                              New TPA.Line("ед.из.", _
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
                         New Integer() {10, 3, 5, 4, 8})
            End If
        Next
        'подвал
        _report.Line("")
        _report.ReserveLines(7)
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
        _report.Line(New TPA.Line() {New TPA.Line("Оператор: ", _
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
        _report.Line("")
        _report.Line(New TPA.Line() {New TPA.Line("Мастер: ", _
                                                  TPA.Line.Align.Left, _
                                                  TPA.Line.StyleLine.None), _
                                       New TPA.Line("", _
                                           TPA.Line.Align.Center, _
                                           TPA.Line.StyleLine.FillUnderline), _
                                       New TPA.Line("/ " & master, _
                                                    TPA.Line.Align.Left, _
                                                    TPA.Line.StyleLine.FillUnderline), _
                                       New TPA.Line("/", _
                                                    TPA.Line.Align.Center, _
                                                    TPA.Line.StyleLine.FillUnderline)}, _
                 New Integer() {34, 14, 24})
        '_report.Line(New TPA.Line("___ __________ 20___ г.", _
        '                          TPA.Line.Align.Right, _
        '                          TPA.Line.StyleLine.None))
    End Sub


    Public Sub Save(ByVal num As Integer, ByVal device As Device, ByVal user As String, ByVal master As String, ByVal timeStart As DateTime)
        TPA.Log.Print(TPA.Rank.OK, "Сохранение протокола № " & num)
        Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim message As String = ""
        dict.Add("заголовок", "№" & num & " (" & _
                 If(device.Name.Length > 0, device.Name & " ", "") & _
                 If(device.Num.Length > 0, "<" & device.Num & "> ", "") & _
                 If(user.Length > 0, user & " ", "") & _
                 timeStart.ToString("dd.MM.yyyy HH:mm") & " " & _
                 boolToStr(device.Control) & ")")
        dict.Add("User", user)
        dict.Add("Master", master)
        dict.Add("Time", timeStart)
        dict.Add("Name", device.Name)
        dict.Add("Num", device.Num)
        dict.Add("РабочиеПарамерты.I", device.РабочиеПарамерты.I)
        dict.Add("РабочиеПарамерты.O", device.РабочиеПарамерты.O)
        dict.Add("РабочиеПарамерты.work", device.РабочиеПарамерты.work)
        dict.Add("РабочиеПарамерты.R", device.РабочиеПарамерты.R)
        dict.Add("РабочиеПарамерты.Состояние", device.РабочиеПарамерты.Состояние)
        dict.Add("РабочиеПарамерты.РастворКонтактов", device.РабочиеПарамерты.РастворКонтактов)
        dict.Add("РабочиеПарамерты.ПровалКонтактов", device.РабочиеПарамерты.ПровалКонтактов)
        dict.Add("РабочиеПарамерты.НажатиеНач", device.РабочиеПарамерты.НажатиеНач)
        dict.Add("РабочиеПарамерты.НажатиеКон", device.РабочиеПарамерты.НажатиеКон)
        dict.Add("UworkMin", device.Uwork.Min)
        dict.Add("UworkMax", device.Uwork.Max)
        dict.Add("UworkFact", device.Uwork.Fact)
        dict.Add("UiMin", device.Ui.Min)
        dict.Add("UiMax", device.Ui.Max)
        dict.Add("UiFact", device.Ui.Fact)
        dict.Add("UoMin", device.Uo.Min)
        dict.Add("UoMax", device.Uo.Max)
        dict.Add("UoFact", device.Uo.Fact)
        dict.Add("IiMin", device.Ii.Min)
        dict.Add("IiMax", device.Ii.Max)
        dict.Add("IiFact", device.Ii.Fact)
        dict.Add("IoMin", device.Io.Min)
        dict.Add("IoMax", device.Io.Max)
        dict.Add("IoFact", device.Io.Fact)
        dict.Add("RMin", device.R.Min)
        dict.Add("RMax", device.R.Max)
        dict.Add("RFact", device.R.Fact)
        dict.Add("KontACount", device.KontACount)
        dict.Add("KontBCount", device.KontBCount)
        dict.Add("KontCCount", device.KontCCount)
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
        dict.Add("РастворКонтактаCMin", device.РастворКонтактаCMin)
        dict.Add("РастворКонтактаCMax", device.РастворКонтактаCMax)
        dict.Add("ПровалКонтактаCMin", device.ПровалКонтактаCMin)
        dict.Add("ПровалКонтактаCMax", device.ПровалКонтактаCMax)
        dict.Add("НажатиеНачCMin", device.НажатиеНачCMin)
        dict.Add("НажатиеНачCMax", device.НажатиеНачCMax)
        dict.Add("НажатиеКонCMin", device.НажатиеКонCMin)
        dict.Add("НажатиеКонCMax", device.НажатиеКонCMax)
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
        For i As Integer = 0 To device.KontCCount - 1
            dict.Add("СостояниеC(" & i & ")", device.СостояниеC(i))
            dict.Add("РастворКонтактаCFact(" & i & ")", device.РастворКонтактаCFact(i))
            dict.Add("ПровалКонтактаCFact(" & i & ")", device.ПровалКонтактаCFact(i))
            dict.Add("НажатиеНачCFact(" & i & ")", device.НажатиеНачCFact(i))
            dict.Add("НажатиеКонCFact(" & i & ")", device.НажатиеКонCFact(i))
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
            Dim master As String = ""
            Dim timeStart As DateTime = Now
            Dim device As Device = New Device()
            key = "РабочиеПарамерты.I"
            Try
                device.РабочиеПарамерты.I = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.I = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.O"
            Try
                device.РабочиеПарамерты.O = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.O = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.work"
            Try
                device.РабочиеПарамерты.work = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.work = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РабочиеПарамерты.R"
            Try
                device.РабочиеПарамерты.R = Convert.ToBoolean(dict(key))
            Catch ex As Exception
                device.РабочиеПарамерты.R = True
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
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
            key = "Master"
            Try
                master = dict(key)
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
            key = "UworkMin"
            Try
                device.Uwork.Min = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Uwork.Min = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UworkMax"
            Try
                device.Uwork.Max = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Uwork.Max = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UworkFact"
            Try
                device.Uwork.Fact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Uwork.Fact = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UiMin"
            Try
                device.Ui.Min = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ui.Min = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UiMax"
            Try
                device.Ui.Max = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ui.Max = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UiFact"
            Try
                device.Ui.Fact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ui.Fact = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UoMin"
            Try
                device.Uo.Min = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Uo.Min = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UoMax"
            Try
                device.Uo.Max = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Uo.Max = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "UoFact"
            Try
                device.Uo.Fact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Uo.Fact = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IiMin"
            Try
                device.Ii.Min = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ii.Min = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IiMax"
            Try
                device.Ii.Max = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ii.Max = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IiFact"
            Try
                device.Ii.Fact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Ii.Fact = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IoMin"
            Try
                device.Io.Min = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Io.Min = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IoMax"
            Try
                device.Io.Max = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Io.Max = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "IoFact"
            Try
                device.Io.Fact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.Io.Fact = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "RMin"
            Try
                device.R.Min = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.R.Min = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "RMax"
            Try
                device.R.Max = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.R.Max = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "RFact"
            Try
                device.R.Fact = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.R.Fact = 0
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
            key = "KontCCount"
            Try
                device.KontCCount = Convert.ToInt32(dict(key))
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
            key = "РастворКонтактаCMin"
            Try
                device.РастворКонтактаCMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.РастворКонтактаCMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "РастворКонтактаCMax"
            Try
                device.РастворКонтактаCMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.РастворКонтактаCMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ПровалКонтактаCMin"
            Try
                device.ПровалКонтактаCMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.ПровалКонтактаCMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "ПровалКонтактаCMax"
            Try
                device.ПровалКонтактаCMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.ПровалКонтактаCMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеНачCMin"
            Try
                device.НажатиеНачCMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеНачCMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеНачCMax"
            Try
                device.НажатиеНачCMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеНачCMax = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеКонCMin"
            Try
                device.НажатиеКонCMin = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеКонCMin = 0
                TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
            End Try
            key = "НажатиеКонCMax"
            Try
                device.НажатиеКонCMax = Convert.ToDouble(dict(key))
            Catch ex As Exception
                device.НажатиеКонCMax = 0
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
            For i As Integer = 0 To device.KontCCount - 1
                key = "СостояниеC(" & i & ")"
                Try
                    device.СостояниеC(i) = Convert.ToBoolean(dict(key))
                Catch ex As Exception
                    device.СостояниеC(i) = False
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "РастворКонтактаCFact(" & i & ")"
                Try
                    device.РастворКонтактаCFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.РастворКонтактаCFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "ПровалКонтактаCFact(" & i & ")"
                Try
                    device.ПровалКонтактаCFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.ПровалКонтактаCFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеНачCFact(" & i & ")"
                Try
                    device.НажатиеНачCFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеНачCFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
                key = "НажатиеКонCFact(" & i & ")"
                Try
                    device.НажатиеКонCFact(i) = Convert.ToDouble(dict(key))
                Catch ex As Exception
                    device.НажатиеКонCFact(i) = 0
                    TPA.Log.Print(TPA.Rank.WARNING, "В протоколе №" & num & " не прочитано поле [" & key & "]")
                End Try
            Next
            Create(num, device, user, master, timeStart)
            TPA.WaitFormStop()
            TPA.DialogForms.Report(_report, _
                                   "Протокол" & If(device.Name.Length > 0, _
                                                   " " & device.Name, _
                                                   "") & If(device.Num.Length > 0, _
                                                            " " & device.Num, _
                                                            ""))
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
    Public Function Show(ByVal user As String, ByVal master As String, ByVal device As Device, ByVal timeStart As DateTime) As Boolean
        Create(readNum, device, user, master, timeStart)
        Show = TPA.DialogForms.Report(_report, _
                                   "Протокол" & If(device.Name.Length > 0, _
                                                   " " & device.Name, _
                                                   "") & If(device.Num.Length > 0, _
                                                            " " & device.Num, _
                                                            ""))
        If Show Then
            Save(readNum, device, user, master, timeStart)
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
