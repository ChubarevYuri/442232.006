Module Report

#Region "Параметры для протокола"

    Private timeStart As Date = Now
    Private device As String = ""
    Private testType As String = ""
    Private user As String = ""

#End Region

    Private _report As New TPA.Report()

    Public Sub Create(ByRef num As Integer)
        _report = New TPA.Report()
        'чердак
        _report.Line(New TPA.Line(Values.setting.Read("ПРОТОКОЛ", _
                                                      "компания"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None, _
                                  10, _
                                  False))
        _report.Line(New TPA.Line(Values.setting.Read("ПРОТОКОЛ", _
                                                      "филиал"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None, _
                                  10, _
                                  False))
        Dim text As String = "Протокол №"
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
        _report.Line(New TPA.Line(testType & " испытания " & device, _
                                  TPA.Line.Align.Center, _
                                  TPA.Line.StyleLine.None, _
                                  True))
        _report.Line(New TPA.Line("Дата и время испытания: " & timeStart.ToString("dd.MM.yyyy HH:mm"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        _report.Line(New TPA.Line("Испытательный стенд: " & Values.setting.Read("ПРОТОКОЛ", _
                                                                                "стенд"), _
                                  TPA.Line.Align.Right, _
                                  TPA.Line.StyleLine.None))
        'тело
        Dim table As New Collection

        table.Add(New TPA.Line() {New TPA.Line("Параметр 0", _
                                               TPA.Line.Align.Left, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("ед.и 0", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("0..0", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("0,00", _
                                               TPA.Line.Align.Center, _
                                               TPA.Line.StyleLine.None), _
                                  New TPA.Line("ok", _
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

    Public Sub Save()

    End Sub

    Public Sub Read()

    End Sub

#Region "Show"

    Public Sub Show(ByVal num As Integer)

    End Sub

    Public Sub Show()

    End Sub

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
                readNum = Convert.ToInt32(Values.setting.Read("ПРОТОКОЛ", "номер"))
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
        Values.setting.Write("ПРОТОКОЛ", "номер", nextNum)
    End Function

End Module
