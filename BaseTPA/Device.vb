Public Class Device
    Private _name As String = ""
    Private _num As String = ""
    Private _U As Double = 0
    ''' <summary>
    ''' Напряжение включения
    ''' </summary>
    ''' <remarks></remarks>
    Public Ui As New TPA.ParamValue
    ''' <summary>
    ''' напряжение выключения
    ''' </summary>
    ''' <remarks></remarks>
    Public Uo As New TPA.ParamValue
    ''' <summary>
    ''' Напряжение номинальное
    ''' </summary>
    ''' <remarks></remarks>
    Public Uwork As New TPA.ParamValue
    ''' <summary>
    ''' Ток включения
    ''' </summary>
    ''' <remarks></remarks>
    Public Ii As New TPA.ParamValue
    ''' <summary>
    ''' Ток выключения
    ''' </summary>
    ''' <remarks></remarks>
    Public Io As New TPA.ParamValue
    ''' <summary>
    ''' Сопротивление
    ''' </summary>
    ''' <remarks></remarks>
    Public R As New TPA.ParamValue
    Private _KontACount As Integer = 0
    Private _KontBCount As Integer = 0
    Private _KontCCount As Integer = 0
    Private _KontsA As List(Of Контакт) = New List(Of Контакт)
    Private _KontsB As List(Of Контакт) = New List(Of Контакт)
    Private _KontsC As List(Of Контакт) = New List(Of Контакт)
    Private _РастворКонтактаAMin As Double = 0
    Private _РастворКонтактаAMax As Double = 0
    Private _РастворКонтактаBMin As Double = 0
    Private _РастворКонтактаBMax As Double = 0
    Private _РастворКонтактаCMin As Double = 0
    Private _РастворКонтактаCMax As Double = 0
    Private _ПровалКонтактаAMin As Double = 0
    Private _ПровалКонтактаAMax As Double = 0
    Private _ПровалКонтактаBMin As Double = 0
    Private _ПровалКонтактаBMax As Double = 0
    Private _ПровалКонтактаCMin As Double = 0
    Private _ПровалКонтактаCMax As Double = 0
    Private _НажатиеНачAMin As Double = 0
    Private _НажатиеНачAMax As Double = 0
    Private _НажатиеНачBMin As Double = 0
    Private _НажатиеНачBMax As Double = 0
    Private _НажатиеНачCMin As Double = 0
    Private _НажатиеНачCMax As Double = 0
    Private _НажатиеКонAMin As Double = 0
    Private _НажатиеКонAMax As Double = 0
    Private _НажатиеКонBMin As Double = 0
    Private _НажатиеКонBMax As Double = 0
    Private _НажатиеКонCMin As Double = 0
    Private _НажатиеКонCMax As Double = 0
    Public РабочиеПарамерты As coltrolStruct = New coltrolStruct()
    ''' <summary>
    ''' Модель аппарата
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return If(_name = Nothing, "", _name)
        End Get
        Set(ByVal value As String)
            _name = If(value = Nothing, "", value)
        End Set
    End Property
    ''' <summary>
    ''' id аппарата
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Num() As String
        Get
            Return If(_num = Nothing, "", _num)
        End Get
        Set(ByVal value As String)
            _num = If(value = Nothing, "", value)
        End Set
    End Property
    ''' <summary>
    ''' Номинальное напряжение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property U() As Double
        Get
            Return _U
        End Get
        Set(ByVal value As Double)
            If value < 0 Then value = 0
            _U = value
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат напряжения включения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UiMaxMinStr() As String
        Get
            If Ui.Min <= 0 And Ui.Max = Double.MaxValue Then
                Return ""
            ElseIf Ui.Min <= 0 Then
                Return "≤" & Ui.Max.ToString(Base.doubleformat)
            ElseIf Ui.Max = Double.MaxValue Then
                Return "≥" & Ui.Min.ToString(Base.doubleformat)
            Else
                Return Ui.Min.ToString(Base.doubleformat) & " .. " & Ui.Max.ToString(Base.doubleformat)
            End If
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат напряжения включения фактического
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UiFactStr() As String
        Get
            Return Ui.Fact.ToString(Base.doubleformat)
        End Get
    End Property
    ''' <summary>
    ''' В
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Uiei() As String
        Get
            Return "В"
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат напряжения выключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UoMaxMinStr() As String
        Get
            If Uo.Min <= 0 And Uo.Max = Double.MaxValue Then
                Return ""
            ElseIf Uo.Min <= 0 Then
                Return "≤" & Uo.Max.ToString(Base.doubleformat)
            ElseIf Uo.Max = Double.MaxValue Then
                Return "≥" & Uo.Min.ToString(Base.doubleformat)
            Else
                Return Uo.Min.ToString(Base.doubleformat) & " .. " & Uo.Max.ToString(Base.doubleformat)
            End If
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат напряжения выключения фактического
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UoFactStr() As String
        Get
            Return Uo.Fact.ToString(Base.doubleformat)
        End Get
    End Property
    ''' <summary>
    ''' В
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Uoei() As String
        Get
            Return "В"
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат напряжения рабочего
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UworkMaxMinStr() As String
        Get
            If Uwork.Min <= 0 And Uwork.Max = Double.MaxValue Then
                Return ""
            ElseIf Uwork.Min <= 0 Then
                Return "≤" & Uwork.Max.ToString(Base.doubleformat)
            ElseIf Uwork.Max = Double.MaxValue Then
                Return "≥" & Uwork.Min.ToString(Base.doubleformat)
            Else
                Return Uwork.Min.ToString(Base.doubleformat) & " .. " & Uwork.Max.ToString(Base.doubleformat)
            End If
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат напряжения рабочего фактического
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UworkFactStr() As String
        Get
            Return Uwork.Fact.ToString(Base.doubleformat)
        End Get
    End Property
    ''' <summary>
    ''' В
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Uworkei() As String
        Get
            Return "В"
        End Get
    End Property
    Public ReadOnly Property IMaxMinStr() As String
        Get
            If Ii.Min <= 0 And Ii.Max = Double.MaxValue Then
                Return ""
            ElseIf Ii.Min <= 0 Then
                Return "≤" & If(Ii.Max < 1, _
                                (Ii.Max * 1000).ToString("#0"), _
                                Ii.Max.ToString("#0.00"))
            ElseIf Ii.Max = Double.MaxValue Then
                Return "≥" & If(Ii.Min < 1, _
                                (Ii.Min * 1000).ToString("#0"), _
                                Ii.Min.ToString("#0.00"))
            Else
                Return If(Ii.Max < 1, _
                          (Ii.Min * 1000).ToString("#0"), _
                          Ii.Min.ToString("#0.00")) & " .. " & _
                       If(Ii.Max < 1, _
                          (Ii.Max * 1000).ToString("#0"), _
                          Ii.Max.ToString("#0.00"))
            End If
        End Get
    End Property
    ''' <summary>
    ''' Строковыйй формат фактического тока включения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IiFactStr() As String
        Get
            Return If(If(Ii.Max = Double.MaxValue, _
                         Ii.Min < 1, _
                         Ii.Max < 1), _
                      (Ii.Fact * 1000).ToString("#0"), _
                      Ii.Fact.ToString("#0.00"))
        End Get
    End Property
    ''' <summary>
    ''' Строковыйй формат фактического тока выключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IoFactStr() As String
        Get
            Return If(If(Io.Max = Double.MaxValue, _
                         Io.Min < 1, _
                         Io.Max < 1), _
                      (Io.Fact * 1000).ToString("#0"), _
                      Io.Fact.ToString("#0.00"))
        End Get
    End Property
    ''' <summary>
    ''' A or mA от диапазона
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Iei() As String
        Get
            Return If(If(Ii.Max = Double.MaxValue, _
                         Ii.Min < 1, _
                         Ii.Max < 1), _
                      "мА", _
                      "А")
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат сопротивления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RMaxMinStr() As String
        Get
            If R.Min <= 0 And R.Max = Double.MaxValue Then
                Return ""
            ElseIf R.Min <= 0 Then
                Return "≤" & If(R.Max < 100, _
                                R.Max.ToString("#0.0"), _
                                If(R.Max < 1000, _
                                   R.Max.ToString("#0"), _
                                   (R.Max / 1000).ToString("#0.00")))
            ElseIf R.Max = Double.MaxValue Then
                Return "≥" & If(R.Min < 100, _
                                R.Min.ToString("#0.0"), _
                                If(R.Min < 1000, _
                                   R.Min.ToString("#0"), _
                                   (R.Min / 1000).ToString("#0.00")))
            Else
                Return If(R.Max < 100, _
                          R.Min.ToString("#0.0"), _
                          If(R.Max < 1000, _
                             R.Min.ToString("#0"), _
                             (R.Min / 1000).ToString("#0.00"))) & " .. " & _
                          If(R.Max < 100, _
                             R.Max.ToString("#0.0"), _
                             If(R.Max < 1000, _
                                R.Max.ToString("#0"), _
                                (R.Max / 1000).ToString("#0.00")))
            End If
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат фактического сопротивления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RFactStr() As String
        Get
            If If(R.Max = Double.MaxValue, R.Min < 100, R.Max < 100) Then
                Return R.Fact.ToString("F1")
            ElseIf If(R.Max = Double.MaxValue, R.Min < 1000, R.Max < 1000) Then
                Return R.Fact.ToString("F0")
            Else
                Return (R.Fact / 1000).ToString("F")
            End If
        End Get
    End Property
    ''' <summary>
    ''' Ом or кОм от диапазона
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Rei() As String
        Get
            Return If(If(R.Max = Double.MaxValue, _
                         R.Min < 1000, _
                         R.Max < 1000), _
                      "Ом", _
                      "кОм")
        End Get
    End Property
    ''' <summary>
    ''' Количество контактов типа A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KontACount() As Integer
        Get
            Return If(_KontACount = Nothing, 0, If(_KontACount > 0, _KontACount, 0))
        End Get
        Set(ByVal value As Integer)
            _KontACount = If(value = Nothing, 0, If(value > 0, value, 0))
            Do While _KontACount > _KontsA.Count
                _KontsA.Add(New Контакт())
            Loop
            Do While _KontACount < _KontsA.Count
                _KontsA.RemoveAt(_KontsA.Count - 1)
            Loop
        End Set
    End Property
    ''' <summary>
    ''' Количество контактов типа B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KontBCount() As Integer
        Get
            Return If(_KontBCount = Nothing, 0, If(_KontBCount > 0, _KontBCount, 0))
        End Get
        Set(ByVal value As Integer)
            _KontBCount = If(value = Nothing, 0, If(value > 0, value, 0))
            Do While _KontBCount > _KontsB.Count
                _KontsB.Add(New Контакт())
            Loop
            Do While _KontBCount < _KontsB.Count
                _KontsB.RemoveAt(_KontsB.Count - 1)
            Loop
        End Set
    End Property
    ''' <summary>
    ''' Количество контактов типа C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KontCCount() As Integer
        Get
            Return If(_KontCCount = Nothing, 0, If(_KontCCount > 0, _KontCCount, 0))
        End Get
        Set(ByVal value As Integer)
            _KontCCount = If(value = Nothing, 0, If(value > 0, value, 0))
            Do While _KontCCount > _KontsC.Count
                _KontsC.Add(New Контакт())
            Loop
            Do While _KontCCount < _KontsC.Count
                _KontsC.RemoveAt(_KontsC.Count - 1)
            Loop
        End Set
    End Property
    ''' <summary>
    ''' Раствор Контакта тип А min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаAMin() As Double
        Get
            Return If(_РастворКонтактаAMin = Nothing, _
                      0, _
                      If(Math.Min(_РастворКонтактаAMin, _РастворКонтактаAMax) > 0, _
                         Math.Min(_РастворКонтактаAMin, _РастворКонтактаAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _РастворКонтактаAMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Раствор Контакта тип А max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаAMax() As Double
        Get
            Return If(_РастворКонтактаAMax = Nothing, _
                      0, _
                      If(Math.Max(_РастворКонтактаAMin, _РастворКонтактаAMax) > 0, _
                         Math.Max(_РастворКонтактаAMin, _РастворКонтактаAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _РастворКонтактаAMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат раствора контакта тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property РастворКонтактаAstr() As String
        Get
            Return If(РастворКонтактаAMax > 0, _
                      If(РастворКонтактаAMin > 0, _
                         РастворКонтактаAMin.ToString(doubleformat) & " .. " & РастворКонтактаAMax.ToString(doubleformat), _
                         "≥" & РастворКонтактаAMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактический Раствор Контакта тип A
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаAFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).РастворКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsA.Count Then
                _KontsA(j).РастворКонтакта = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "РастворКонтактаAFact[" & j & "] вне предела диапазона 0 .. " & _KontsA.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Раствота Контакта тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlРастворКонтактаA(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j <= _KontsA.Count, _KontsA(j).ControlРастворКонтакта(РастворКонтактаAMin, РастворКонтактаAMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Раствор Контакта тип B min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаBMin() As Double
        Get
            Return If(_РастворКонтактаBMin = Nothing, _
                      0, _
                      If(Math.Min(_РастворКонтактаBMin, _РастворКонтактаBMax) > 0, _
                         Math.Min(_РастворКонтактаBMin, _РастворКонтактаBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _РастворКонтактаBMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Раствор Контакта тип B max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаBMax() As Double
        Get
            Return If(_РастворКонтактаBMax = Nothing, _
                      0, _
                      If(Math.Max(_РастворКонтактаBMin, _РастворКонтактаBMax) > 0, _
                         Math.Max(_РастворКонтактаBMin, _РастворКонтактаBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _РастворКонтактаBMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат раствора контакта тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property РастворКонтактаBstr() As String
        Get
            Return If(РастворКонтактаBMax > 0, _
                      If(РастворКонтактаBMin > 0, _
                         РастворКонтактаBMin.ToString(doubleformat) & " .. " & РастворКонтактаBMax.ToString(doubleformat), _
                         "≥" & РастворКонтактаBMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактический Раствор Контакта тип B
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаBFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).РастворКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsB.Count Then
                _KontsB(j).РастворКонтакта = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "РастворКонтактаBFact[" & j & "] вне предела диапазона 0 .. " & _KontsB.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Раствота Контакта тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlРастворКонтактаB(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).ControlРастворКонтакта(РастворКонтактаBMin, РастворКонтактаBMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Раствор Контакта тип C min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаCMin() As Double
        Get
            Return If(_РастворКонтактаCMin = Nothing, _
                      0, _
                      If(Math.Min(_РастворКонтактаCMin, _РастворКонтактаCMax) > 0, _
                         Math.Min(_РастворКонтактаCMin, _РастворКонтактаCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _РастворКонтактаCMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Раствор Контакта тип C max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаCMax() As Double
        Get
            Return If(_РастворКонтактаCMax = Nothing, _
                      0, _
                      If(Math.Max(_РастворКонтактаCMin, _РастворКонтактаCMax) > 0, _
                         Math.Max(_РастворКонтактаCMin, _РастворКонтактаCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _РастворКонтактаCMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат раствора контакта тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property РастворКонтактаCstr() As String
        Get
            Return If(РастворКонтактаCMax > 0, _
                      If(РастворКонтактаCMin > 0, _
                         РастворКонтактаCMin.ToString(doubleformat) & " .. " & РастворКонтактаCMax.ToString(doubleformat), _
                         "≥" & РастворКонтактаCMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактический Раствор Контакта тип C
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property РастворКонтактаCFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).РастворКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsC.Count Then
                _KontsC(j).РастворКонтакта = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "РастворКонтактаCFact[" & j & "] вне предела диапазона 0 .. " & _KontsC.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Раствота Контакта тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlРастворКонтактаC(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).ControlРастворКонтакта(РастворКонтактаCMin, РастворКонтактаCMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Провал Контакта тип А min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаAMin() As Double
        Get
            Return If(_ПровалКонтактаAMin = Nothing, _
                      0, _
                      If(Math.Min(_ПровалКонтактаAMin, _ПровалКонтактаAMax) > 0, _
                         Math.Min(_ПровалКонтактаAMin, _ПровалКонтактаAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _ПровалКонтактаAMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Провал Контакта тип А max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаAMax() As Double
        Get
            Return If(_ПровалКонтактаAMax = Nothing, _
                      0, _
                      If(Math.Max(_ПровалКонтактаAMin, _ПровалКонтактаAMax) > 0, _
                         Math.Max(_ПровалКонтактаAMin, _ПровалКонтактаAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _ПровалКонтактаAMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат провала контакта тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ПровалКонтактаAstr() As String
        Get
            Return If(ПровалКонтактаAMax > 0, _
                      If(ПровалКонтактаAMin > 0, _
                         ПровалКонтактаAMin.ToString(doubleformat) & " .. " & ПровалКонтактаAMax.ToString(doubleformat), _
                         "≥" & ПровалКонтактаAMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактический Провал Контакта тип A
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаAFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).ПровалКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsA.Count Then
                _KontsA(j).ПровалКонтакта = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "ПровалКонтактаAFact[" & j & "] вне предела диапазона 0 .. " & _KontsA.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Раствота Контакта тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlПровалКонтактаA(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).ControlПровалКонтакта(ПровалКонтактаAMin, ПровалКонтактаAMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Провал Контакта тип B min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаBMin() As Double
        Get
            Return If(_ПровалКонтактаBMin = Nothing, _
                      0, _
                      If(Math.Min(_ПровалКонтактаBMin, _ПровалКонтактаBMax) > 0, _
                         Math.Min(_ПровалКонтактаBMin, _ПровалКонтактаBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _ПровалКонтактаBMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Провал Контакта тип B max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаBMax() As Double
        Get
            Return If(_ПровалКонтактаBMax = Nothing, _
                      0, _
                      If(Math.Max(_ПровалКонтактаBMin, _ПровалКонтактаBMax) > 0, _
                         Math.Max(_ПровалКонтактаBMin, _ПровалКонтактаBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _ПровалКонтактаBMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат провала контакта тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ПровалКонтактаBstr() As String
        Get
            Return If(ПровалКонтактаBMax > 0, _
                      If(ПровалКонтактаBMin > 0, _
                         ПровалКонтактаBMin.ToString(doubleformat) & " .. " & ПровалКонтактаBMax.ToString(doubleformat), _
                         "≥" & ПровалКонтактаBMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактический Провал Контакта тип B
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаBFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).ПровалКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsB.Count Then
                _KontsB(j).ПровалКонтакта = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "ПровалКонтактаBFact[" & j & "] вне предела диапазона 0 .. " & _KontsB.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Раствота Контакта тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlПровалКонтактаB(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).ControlПровалКонтакта(ПровалКонтактаBMin, ПровалКонтактаBMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Провал Контакта тип C min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаCMin() As Double
        Get
            Return If(_ПровалКонтактаCMin = Nothing, _
                      0, _
                      If(Math.Min(_ПровалКонтактаCMin, _ПровалКонтактаCMax) > 0, _
                         Math.Min(_ПровалКонтактаCMin, _ПровалКонтактаCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _ПровалКонтактаCMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Провал Контакта тип C max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаCMax() As Double
        Get
            Return If(_ПровалКонтактаCMax = Nothing, _
                      0, _
                      If(Math.Max(_ПровалКонтактаCMin, _ПровалКонтактаCMax) > 0, _
                         Math.Max(_ПровалКонтактаCMin, _ПровалКонтактаCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _ПровалКонтактаCMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат провала контакта тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ПровалКонтактаCstr() As String
        Get
            Return If(ПровалКонтактаCMax > 0, _
                      If(ПровалКонтактаCMin > 0, _
                         ПровалКонтактаCMin.ToString(doubleformat) & " .. " & ПровалКонтактаCMax.ToString(doubleformat), _
                         "≥" & ПровалКонтактаCMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактический Провал Контакта тип C
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ПровалКонтактаCFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).ПровалКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsC.Count Then
                _KontsC(j).ПровалКонтакта = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "ПровалКонтактаCFact[" & j & "] вне предела диапазона 0 .. " & _KontsC.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Раствота Контакта тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlПровалКонтактаC(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).ControlПровалКонтакта(ПровалКонтактаCMin, ПровалКонтактаCMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Нажание Контакта (Нач) тип А min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачAMin() As Double
        Get
            Return If(_НажатиеНачAMin = Nothing, _
                      0, _
                      If(Math.Min(_НажатиеНачAMin, _НажатиеНачAMax) > 0, _
                         Math.Min(_НажатиеНачAMin, _НажатиеНачAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеНачAMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Нажание Контакта (Нач) тип А max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачAMax() As Double
        Get
            Return If(_НажатиеНачAMax = Nothing, _
                      0, _
                      If(Math.Max(_НажатиеНачAMin, _НажатиеНачAMax) > 0, _
                         Math.Max(_НажатиеНачAMin, _НажатиеНачAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеНачAMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат нажатия (нач) контакта тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property НажатиеНачAstr() As String
        Get
            Return If(НажатиеНачAMax > 0, _
                      If(НажатиеНачAMin > 0, _
                         НажатиеНачAMin.ToString(doubleformat) & " .. " & НажатиеНачAMax.ToString(doubleformat), _
                         "≥" & НажатиеНачAMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое Нажание Контакта (Нач) тип A
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачAFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).НажатиеНач, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsA.Count Then
                _KontsA(j).НажатиеНач = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "НажатиеНачAFact[" & j & "] вне предела диапазона 0 .. " & _KontsA.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Нажания Контакта (Нач) тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlНажатиеНачA(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).ControlНажатиеНач(НажатиеНачAMin, НажатиеНачAMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Нажание Контакта (Нач) тип B min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачBMin() As Double
        Get
            Return If(_НажатиеНачBMin = Nothing, _
                      0, _
                      If(Math.Min(_НажатиеНачBMin, _НажатиеНачBMax) > 0, _
                         Math.Min(_НажатиеНачBMin, _НажатиеНачBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеНачBMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Нажание Контакта (Нач) тип B max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачBMax() As Double
        Get
            Return If(_НажатиеНачBMax = Nothing, _
                      0, _
                      If(Math.Max(_НажатиеНачBMin, _НажатиеНачBMax) > 0, _
                         Math.Max(_НажатиеНачBMin, _НажатиеНачBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеНачBMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат нажатия (нач) контакта тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property НажатиеНачBstr() As String
        Get
            Return If(НажатиеНачBMax > 0, _
                      If(НажатиеНачBMin > 0, _
                         НажатиеНачBMin.ToString(doubleformat) & " .. " & НажатиеНачBMax.ToString(doubleformat), _
                         "≥" & НажатиеНачBMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое Нажание Контакта (Нач) тип B
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачBFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).НажатиеНач, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsB.Count Then
                _KontsB(j).НажатиеНач = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "НажатиеНачBFact[" & j & "] вне предела диапазона 0 .. " & _KontsB.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Нажания Контакта (Нач) тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlНажатиеНачB(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).ControlНажатиеНач(НажатиеНачBMin, НажатиеНачBMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Нажание Контакта (Нач) тип C min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачCMin() As Double
        Get
            Return If(_НажатиеНачCMin = Nothing, _
                      0, _
                      If(Math.Min(_НажатиеНачCMin, _НажатиеНачCMax) > 0, _
                         Math.Min(_НажатиеНачCMin, _НажатиеНачCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеНачCMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Нажание Контакта (Нач) тип C max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачCMax() As Double
        Get
            Return If(_НажатиеНачCMax = Nothing, _
                      0, _
                      If(Math.Max(_НажатиеНачCMin, _НажатиеНачCMax) > 0, _
                         Math.Max(_НажатиеНачCMin, _НажатиеНачCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеНачCMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат нажатия (нач) контакта тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property НажатиеНачCstr() As String
        Get
            Return If(НажатиеНачAMax > 0, _
                      If(НажатиеНачCMin > 0, _
                         НажатиеНачCMin.ToString(doubleformat) & " .. " & НажатиеНачCMax.ToString(doubleformat), _
                         "≥" & НажатиеНачCMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое Нажание Контакта (Нач) тип C
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеНачCFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).НажатиеНач, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsC.Count Then
                _KontsC(j).НажатиеНач = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "НажатиеНачCFact[" & j & "] вне предела диапазона 0 .. " & _KontsC.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Нажания Контакта (Нач) тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlНажатиеНачC(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).ControlНажатиеНач(НажатиеНачCMin, НажатиеНачCMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Нажание Контакта (Кон) тип А min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонAMin() As Double
        Get
            Return If(_НажатиеКонAMin = Nothing, _
                      0, _
                      If(Math.Min(_НажатиеКонAMin, _НажатиеКонAMax) > 0, _
                         Math.Min(_НажатиеКонAMin, _НажатиеКонAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеКонAMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Нажание Контакта (Кон) тип А max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонAMax() As Double
        Get
            Return If(_НажатиеКонAMax = Nothing, _
                      0, _
                      If(Math.Max(_НажатиеКонAMin, _НажатиеКонAMax) > 0, _
                         Math.Max(_НажатиеКонAMin, _НажатиеКонAMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеКонAMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат нажатия (кон) контакта тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property НажатиеКонAstr() As String
        Get
            Return If(НажатиеКонAMax > 0, _
                      If(НажатиеКонAMin > 0, _
                         НажатиеКонAMin.ToString(doubleformat) & " .. " & НажатиеКонAMax.ToString(doubleformat), _
                         "≥" & НажатиеКонAMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое Нажание Контакта (Кон) тип A
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонAFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).НажатиеКон, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsA.Count Then
                _KontsA(j).НажатиеКон = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "НажатиеКонAFact[" & j & "] вне предела диапазона 0 .. " & _KontsA.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Нажания Контакта (Кон) тип A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlНажатиеКонA(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).ControlНажатиеКон(НажатиеКонAMin, НажатиеКонAMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Нажание Контакта (Кон) тип B min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонBMin() As Double
        Get
            Return If(_НажатиеКонBMin = Nothing, _
                      0, _
                      If(Math.Min(_НажатиеКонBMin, _НажатиеКонBMax) > 0, _
                         Math.Min(_НажатиеКонBMin, _НажатиеКонBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеКонBMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Нажание Контакта (Кон) тип B max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонBMax() As Double
        Get
            Return If(_НажатиеКонBMax = Nothing, _
                      0, _
                      If(Math.Max(_НажатиеКонBMin, _НажатиеКонBMax) > 0, _
                         Math.Max(_НажатиеКонBMin, _НажатиеКонBMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеКонBMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат нажатия (кон) контакта тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property НажатиеКонBstr() As String
        Get
            Return If(НажатиеКонBMax > 0, _
                      If(НажатиеКонBMin > 0, _
                         НажатиеКонBMin.ToString(doubleformat) & " .. " & НажатиеКонBMax.ToString(doubleformat), _
                         "≥" & НажатиеКонBMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое Нажание Контакта (Кон) тип B
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонBFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).НажатиеКон, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsB.Count Then
                _KontsB(j).НажатиеКон = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "НажатиеКонBFact[" & j & "] вне предела диапазона 0 .. " & _KontsB.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Нажания Контакта (Кон) тип B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlНажатиеКонB(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).ControlНажатиеКон(НажатиеКонBMin, НажатиеКонBMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Нажание Контакта (Кон) тип C min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонCMin() As Double
        Get
            Return If(_НажатиеКонCMin = Nothing, _
                      0, _
                      If(Math.Min(_НажатиеКонCMin, _НажатиеКонCMax) > 0, _
                         Math.Min(_НажатиеКонCMin, _НажатиеКонCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеКонCMin = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Нажание Контакта (Кон) тип C max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонCMax() As Double
        Get
            Return If(_НажатиеКонCMax = Nothing, _
                      0, _
                      If(Math.Max(_НажатиеКонCMin, _НажатиеКонCMax) > 0, _
                         Math.Max(_НажатиеКонCMin, _НажатиеКонCMax), _
                         0))
        End Get
        Set(ByVal value As Double)
            _НажатиеКонCMax = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Строковый формат нажатия (кон) контакта тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property НажатиеКонCstr() As String
        Get
            Return If(НажатиеКонCMax > 0, _
                      If(НажатиеКонCMin > 0, _
                         НажатиеКонCMin.ToString(doubleformat) & " .. " & НажатиеКонCMax.ToString(doubleformat), _
                         "≥" & НажатиеКонCMax.ToString(doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое Нажание Контакта (Кон) тип C
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property НажатиеКонCFact(ByVal j As Integer) As Double
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).НажатиеКон, 0)
        End Get
        Set(ByVal value As Double)
            If j >= 0 And j < _KontsC.Count Then
                _KontsC(j).НажатиеКон = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "НажатиеКонCFact[" & j & "] вне предела диапазона 0 .. " & _KontsC.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль Нажания Контакта (Кон) тип C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlНажатиеКонC(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).ControlНажатиеКон(НажатиеКонCMin, НажатиеКонCMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Состояние контакта тип A
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property СостояниеA(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).Состояние, False)
        End Get
        Set(ByVal value As Boolean)
            If j >= 0 And j < _KontsA.Count Then
                _KontsA(j).Состояние = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "СостояниеA[" & j & "] вне предела диапазона 0 .. " & _KontsA.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Состояние контакта тип B
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property СостояниеB(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).Состояние, False)
        End Get
        Set(ByVal value As Boolean)
            If j >= 0 And j < _KontsB.Count Then
                _KontsB(j).Состояние = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "СостояниеB[" & j & "] вне предела диапазона 0 .. " & _KontsB.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Состояние контакта тип C
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property СостояниеC(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).Состояние, False)
        End Get
        Set(ByVal value As Boolean)
            If j >= 0 And j < _KontsC.Count Then
                _KontsC(j).Состояние = value
            Else
                TPA.Log.Print(TPA.Rank.EXCEPT, "СостояниеC[" & j & "] вне предела диапазона 0 .. " & _KontsC.Count - 1)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Контроль контакта тип A
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlA(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).Control(РабочиеПарамерты, _
                                                                       РастворКонтактаAMin, _
                                                                       РастворКонтактаAMax, _
                                                                       ПровалКонтактаAMin, _
                                                                       ПровалКонтактаAMax, _
                                                                       НажатиеНачAMin, _
                                                                       НажатиеНачAMax, _
                                                                       НажатиеКонAMin, _
                                                                       НажатиеКонAMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Контроль контакта тип B
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlB(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsB.Count, _KontsB(j).Control(РабочиеПарамерты, _
                                                                       РастворКонтактаBMin, _
                                                                       РастворКонтактаBMax, _
                                                                       ПровалКонтактаBMin, _
                                                                       ПровалКонтактаBMax, _
                                                                       НажатиеНачBMin, _
                                                                       НажатиеНачBMax, _
                                                                       НажатиеКонBMin, _
                                                                       НажатиеКонBMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Контроль контакта тип C
    ''' </summary>
    ''' <param name="j"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlC(ByVal j As Integer) As Boolean
        Get
            Return If(j >= 0 And j < _KontsC.Count, _KontsC(j).Control(РабочиеПарамерты, _
                                                                       РастворКонтактаCMin, _
                                                                       РастворКонтактаCMax, _
                                                                       ПровалКонтактаCMin, _
                                                                       ПровалКонтактаCMax, _
                                                                       НажатиеНачCMin, _
                                                                       НажатиеНачCMax, _
                                                                       НажатиеКонCMin, _
                                                                       НажатиеКонCMax), False)
        End Get
    End Property
    ''' <summary>
    ''' Полный контроль аппарата
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Control() As Boolean
        Get
            Control = (Uwork.Control Or Not РабочиеПарамерты.work) _
            And (Ui.Control Or Not РабочиеПарамерты.I) _
            And (Uo.Control Or Not РабочиеПарамерты.O) _
            And (Ii.Control Or Not РабочиеПарамерты.I) _
            And (Io.Control Or Not РабочиеПарамерты.O) _
            And (R.Control Or Not РабочиеПарамерты.R)
            For j As Integer = 0 To KontACount - 1
                Control = Control And ControlA(j)
            Next
            For j As Integer = 0 To KontBCount - 1
                Control = Control And ControlB(j)
            Next
            For j As Integer = 0 To KontCCount - 1
                Control = Control And ControlC(j)
            Next
        End Get
    End Property
    Public endW As Boolean = False
    Public endСост As Boolean = False
    ''' <summary>
    ''' Сохранение аппарата в файл "Base.devices"
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        dict.Add("U", U)
        dict.Add("UworkMin", Uwork.Min)
        dict.Add("UworkMax", Uwork.Max)
        dict.Add("UiMin", Ui.Min)
        dict.Add("UiMax", Ui.Max)
        dict.Add("UoMin", Uo.Min)
        dict.Add("UoMax", Uo.Max)
        dict.Add("IiMin", Ii.Min)
        dict.Add("IiMax", Ii.Max)
        dict.Add("IoMin", Io.Min)
        dict.Add("IoMax", Io.Max)
        dict.Add("RMin", R.Min)
        dict.Add("RMax", R.Max)
        dict.Add("KontACount", KontACount)
        dict.Add("KontBCount", KontBCount)
        dict.Add("KontCCount", KontCCount)
        dict.Add("РастворКонтактаAMin", РастворКонтактаAMin)
        dict.Add("РастворКонтактаAMax", РастворКонтактаAMax)
        dict.Add("ПровалКонтактаAMin", ПровалКонтактаAMin)
        dict.Add("ПровалКонтактаAMax", ПровалКонтактаAMax)
        dict.Add("НажатиеНачAMin", НажатиеНачAMin)
        dict.Add("НажатиеНачAMax", НажатиеНачAMax)
        dict.Add("НажатиеКонAMin", НажатиеКонAMin)
        dict.Add("НажатиеКонAMax", НажатиеКонAMax)
        dict.Add("РастворКонтактаBMin", РастворКонтактаBMin)
        dict.Add("РастворКонтактаBMax", РастворКонтактаBMax)
        dict.Add("ПровалКонтактаBMin", ПровалКонтактаBMin)
        dict.Add("ПровалКонтактаBMax", ПровалКонтактаBMax)
        dict.Add("НажатиеНачBMin", НажатиеНачBMin)
        dict.Add("НажатиеНачBMax", НажатиеНачBMax)
        dict.Add("НажатиеКонBMin", НажатиеКонBMin)
        dict.Add("НажатиеКонBMax", НажатиеКонBMax)
        dict.Add("РастворКонтактаCMin", РастворКонтактаCMin)
        dict.Add("РастворКонтактаCMax", РастворКонтактаCMax)
        dict.Add("ПровалКонтактаCMin", ПровалКонтактаCMin)
        dict.Add("ПровалКонтактаCMax", ПровалКонтактаCMax)
        dict.Add("НажатиеНачCMin", НажатиеНачCMin)
        dict.Add("НажатиеНачCMax", НажатиеНачCMax)
        dict.Add("НажатиеКонCMin", НажатиеКонCMin)
        dict.Add("НажатиеКонCMax", НажатиеКонCMax)
        dict.Add("РабочиеПарамерты.I", РабочиеПарамерты.I)
        dict.Add("РабочиеПарамерты.O", РабочиеПарамерты.O)
        dict.Add("РабочиеПарамерты.R", РабочиеПарамерты.R)
        dict.Add("РабочиеПарамерты.work", РабочиеПарамерты.work)
        dict.Add("РабочиеПарамерты.Состояние", РабочиеПарамерты.Состояние)
        dict.Add("РабочиеПарамерты.РастворКонтактов", РабочиеПарамерты.РастворКонтактов)
        dict.Add("РабочиеПарамерты.ПровалКонтактов", РабочиеПарамерты.ПровалКонтактов)
        dict.Add("РабочиеПарамерты.НажатиеНач", РабочиеПарамерты.НажатиеНач)
        dict.Add("РабочиеПарамерты.НажатиеКон", РабочиеПарамерты.НажатиеКон)
        If Base.devices.Write(Name, dict) <> 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, "Устройство " & Name & " не сохранено")
    End Sub
    Public Sub Read(ByVal _Name_ As String)
        Dim dict = devices.Read(_Name_)
        Name = _Name_
        Try
            U = Convert.ToDouble(dict("U"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[U]")
        End Try
        Try
            Uwork.Min = Convert.ToDouble(dict("UworkMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Uwork.Min]")
        End Try
        Try
            Uwork.Max = Convert.ToDouble(dict("UworkMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Uwork.Max]")
        End Try
        Try
            Ui.Min = Convert.ToDouble(dict("UiMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Ui.Min]")
        End Try
        Try
            Ui.Max = Convert.ToDouble(dict("UiMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Ui.Max]")
        End Try
        Try
            Uo.Min = Convert.ToDouble(dict("UoMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Uo.Min]")
        End Try
        Try
            Uo.Max = Convert.ToDouble(dict("UoMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Uo.Max]")
        End Try
        Try
            Ii.Min = Convert.ToDouble(dict("IiMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Ii.Min]")
        End Try
        Try
            Ii.Max = Convert.ToDouble(dict("IiMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Ii.Max]")
        End Try
        Try
            Io.Min = Convert.ToDouble(dict("IoMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Io.Min]")
        End Try
        Try
            Io.Max = Convert.ToDouble(dict("IoMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Io.Max]")
        End Try
        Try
            R.Min = Convert.ToDouble(dict("RMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[R.Min]")
        End Try
        Try
            R.Max = Convert.ToDouble(dict("RMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[R.Max]")
        End Try
        Try
            KontACount = Convert.ToInt32(dict("KontACount"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[KontACount]")
        End Try
        Try
            KontBCount = Convert.ToInt32(dict("KontBCount"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[KontBCount]")
        End Try
        Try
            KontCCount = Convert.ToInt32(dict("KontCCount"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[KontCCount]")
        End Try
        Try
            РастворКонтактаAMin = Convert.ToDouble(dict("РастворКонтактаAMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РастворКонтактаAMin]")
        End Try
        Try
            РастворКонтактаAMax = Convert.ToDouble(dict("РастворКонтактаAMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РастворКонтактаAMax]")
        End Try
        Try
            ПровалКонтактаAMin = Convert.ToDouble(dict("ПровалКонтактаAMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[ПровалКонтактаAMin]")
        End Try
        Try
            ПровалКонтактаAMax = Convert.ToDouble(dict("ПровалКонтактаAMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[ПровалКонтактаAMax]")
        End Try
        Try
            НажатиеНачAMin = Convert.ToDouble(dict("НажатиеНачAMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеНачAMin]")
        End Try
        Try
            НажатиеНачAMax = Convert.ToDouble(dict("НажатиеНачAMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеНачAMax]")
        End Try
        Try
            НажатиеКонAMin = Convert.ToDouble(dict("НажатиеКонAMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеКонAMin]")
        End Try
        Try
            НажатиеКонAMax = Convert.ToDouble(dict("НажатиеКонAMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеКонAMax]")
        End Try
        Try
            РастворКонтактаBMin = Convert.ToDouble(dict("РастворКонтактаBMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РастворКонтактаBMin]")
        End Try
        Try
            РастворКонтактаBMax = Convert.ToDouble(dict("РастворКонтактаBMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РастворКонтактаBMax]")
        End Try
        Try
            ПровалКонтактаBMin = Convert.ToDouble(dict("ПровалКонтактаBMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[ПровалКонтактаBMin]")
        End Try
        Try
            ПровалКонтактаBMax = Convert.ToDouble(dict("ПровалКонтактаBMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[ПровалКонтактаBMax]")
        End Try
        Try
            НажатиеНачBMin = Convert.ToDouble(dict("НажатиеНачBMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеНачBMin]")
        End Try
        Try
            НажатиеНачBMax = Convert.ToDouble(dict("НажатиеНачBMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеНачBMax]")
        End Try
        Try
            НажатиеКонBMin = Convert.ToDouble(dict("НажатиеКонBMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеКонBMin]")
        End Try
        Try
            НажатиеКонBMax = Convert.ToDouble(dict("НажатиеКонBMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеКонBMax]")
        End Try
        Try
            РастворКонтактаCMin = Convert.ToDouble(dict("РастворКонтактаCMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РастворКонтактаCMin]")
        End Try
        Try
            РастворКонтактаCMax = Convert.ToDouble(dict("РастворКонтактаCMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РастворКонтактаCMax]")
        End Try
        Try
            ПровалКонтактаCMin = Convert.ToDouble(dict("ПровалКонтактаCMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[ПровалКонтактаCMin]")
        End Try
        Try
            ПровалКонтактаCMax = Convert.ToDouble(dict("ПровалКонтактаCMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[ПровалКонтактаCMax]")
        End Try
        Try
            НажатиеНачCMin = Convert.ToDouble(dict("НажатиеНачCMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеНачCMin]")
        End Try
        Try
            НажатиеНачCMax = Convert.ToDouble(dict("НажатиеНачCMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеНачCMax]")
        End Try
        Try
            НажатиеКонCMin = Convert.ToDouble(dict("НажатиеКонCMin"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеКонCMin]")
        End Try
        Try
            НажатиеКонCMax = Convert.ToDouble(dict("НажатиеКонCMax"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[НажатиеКонCMax]")
        End Try
        Try
            РабочиеПарамерты.I = Convert.ToBoolean(dict("РабочиеПарамерты.I"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.I]")
        End Try
        Try
            РабочиеПарамерты.O = Convert.ToBoolean(dict("РабочиеПарамерты.O"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.O]")
        End Try
        Try
            РабочиеПарамерты.R = Convert.ToBoolean(dict("РабочиеПарамерты.R"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.R]")
        End Try
        Try
            РабочиеПарамерты.work = Convert.ToBoolean(dict("РабочиеПарамерты.work"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.work]")
        End Try
        Try
            РабочиеПарамерты.Состояние = Convert.ToBoolean(dict("РабочиеПарамерты.Состояние"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.Состояние]")
        End Try
        Try
            РабочиеПарамерты.РастворКонтактов = Convert.ToBoolean(dict("РабочиеПарамерты.РастворКонтактов"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.РастворКонтактов]")
        End Try
        Try
            РабочиеПарамерты.ПровалКонтактов = Convert.ToBoolean(dict("РабочиеПарамерты.ПровалКонтактов"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.ПровалКонтактов]")
        End Try
        Try
            РабочиеПарамерты.НажатиеНач = Convert.ToBoolean(dict("РабочиеПарамерты.НажатиеНач"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.НажатиеНач]")
        End Try
        Try
            РабочиеПарамерты.НажатиеКон = Convert.ToBoolean(dict("РабочиеПарамерты.НажатиеКон"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[РабочиеПарамерты.НажатиеКон]")
        End Try
    End Sub
End Class

Public Class coltrolStruct
    Public I As Boolean = True
    Public O As Boolean = True
    Public work As Boolean = True
    Public R As Boolean = True
    Public РастворКонтактов As Boolean = True
    Public ПровалКонтактов As Boolean = True
    Public НажатиеНач As Boolean = True
    Public НажатиеКон As Boolean = True
    Public Состояние As Boolean = True
    Public Sub New()

    End Sub
End Class

Public Class Контакт
    Private _РастворКонтакта As Double = 0
    Private _ПровалКонтакта As Double = 0
    Private _НажатиеНач As Double = 0
    Private _НажатиеКон As Double = 0
    Private _Состояние As Boolean = Nothing
    Public Property РастворКонтакта() As Double
        Get
            Return If(_РастворКонтакта > 0, _РастворКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            _РастворКонтакта = If(value > 0, value, 0)
        End Set
    End Property
    Public Property ПровалКонтакта() As Double
        Get
            Return If(_ПровалКонтакта > 0, _ПровалКонтакта, 0)
        End Get
        Set(ByVal value As Double)
            _ПровалКонтакта = If(value > 0, value, 0)
        End Set
    End Property
    Public Property НажатиеНач() As Double
        Get
            Return If(_НажатиеНач > 0, _НажатиеНач, 0)
        End Get
        Set(ByVal value As Double)
            _НажатиеНач = If(value > 0, value, 0)
        End Set
    End Property
    Public Property НажатиеКон() As Double
        Get
            Return If(_НажатиеКон > 0, _НажатиеКон, 0)
        End Get
        Set(ByVal value As Double)
            _НажатиеКон = If(value > 0, value, 0)
        End Set
    End Property
    Public Property Состояние() As Boolean
        Get
            Return _Состояние
        End Get
        Set(ByVal value As Boolean)
            _Состояние = If(value = Nothing, False, value)
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal РастворКонтактаFact As Double, _
                   ByVal ПровалКонтактаFact As Double, _
                   ByVal НажатиеНачFact As Double, _
                   ByVal НажатиеКонFact As Double, _
                   ByVal _Состояние_ As Boolean)
        РастворКонтакта = РастворКонтактаFact
        ПровалКонтакта = ПровалКонтактаFact
        НажатиеНач = НажатиеНачFact
        НажатиеКон = НажатиеКонFact
        Состояние = _Состояние_
    End Sub

    Public Function Control(ByVal ControlParams As coltrolStruct, _
                            ByVal РастворКонтактаMin As Double, ByVal РастворКонтактаMax As Double, _
                            ByVal ПровалКонтактаMin As Double, ByVal ПровалКонтактаMax As Double, _
                            ByVal НажатиеНачMin As Double, ByVal НажатиеНачMax As Double, _
                            ByVal НажатиеКонMin As Double, ByVal НажатиеКонMax As Double) As Boolean
        Return (Not ControlParams.РастворКонтактов Or ControlРастворКонтакта(РастворКонтактаMin, _
                                                                             РастворКонтактаMax)) And _
               (Not ControlParams.ПровалКонтактов Or ControlПровалКонтакта(ПровалКонтактаMin, _
                                                                           ПровалКонтактаMax)) And _
               (Not ControlParams.НажатиеНач Or ControlНажатиеНач(НажатиеНачMin, _
                                                                  НажатиеНачMax)) And _
               (Not ControlParams.НажатиеКон Or ControlНажатиеКон(НажатиеКонMin, _
                                                                  НажатиеКонMax)) And _
               (Not ControlParams.Состояние Or Состояние)
    End Function

    Public Function ControlРастворКонтакта(ByVal Min As Double, _
                                           ByVal Max As Double) As Boolean
        Return _Control(Min, Max, РастворКонтакта)
    End Function

    Public Function ControlПровалКонтакта(ByVal Min As Double, _
                                          ByVal Max As Double) As Boolean
        Return _Control(Min, Max, ПровалКонтакта)
    End Function

    Public Function ControlНажатиеНач(ByVal Min As Double, _
                                      ByVal Max As Double) As Boolean
        Return _Control(Min, Max, НажатиеНач)
    End Function

    Public Function ControlНажатиеКон(ByVal Min As Double, _
                                      ByVal Max As Double) As Boolean
        Return _Control(Min, Max, НажатиеКон)
    End Function

    Private Function _Control(ByVal Min As Double, _
                              ByVal Max As Double, _
                              ByVal Fact As Double) As Boolean
        Return (Max <= 0) Or (Min <= Fact And _
                              Fact <= Max)
    End Function
End Class
