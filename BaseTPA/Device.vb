Public Class Device
    Private _name As String = ""
    Private _num As String = ""
    Private _U As Integer = 0
    Private _Uvalid As Integer = 0
    Private _UI As Integer = 0
    Private _UO As Integer = 0
    Private _I As Double = 0
    Private _Ivalid As Double = 0
    Private _II As Integer = 0
    Private _IO As Integer = 0
    Private _R As Double = 0
    Private _Rvalid As Double = 0
    Private _Rfact As Double = 0
    Private _KontACount As Integer = 0
    Private _KontBCount As Integer = 0
    Private _KontsA As List(Of Контакт) = New List(Of Контакт)
    Private _KontsB As List(Of Контакт) = New List(Of Контакт)
    Private _РастворКонтактаAMin As Double = 0
    Private _РастворКонтактаAMax As Double = 0
    Private _РастворКонтактаBMin As Double = 0
    Private _РастворКонтактаBMax As Double = 0
    Private _ПровалКонтактаAMin As Double = 0
    Private _ПровалКонтактаAMax As Double = 0
    Private _ПровалКонтактаBMin As Double = 0
    Private _ПровалКонтактаBMax As Double = 0
    Private _НажатиеНачAMin As Double = 0
    Private _НажатиеНачAMax As Double = 0
    Private _НажатиеНачBMin As Double = 0
    Private _НажатиеНачBMax As Double = 0
    Private _НажатиеКонAMin As Double = 0
    Private _НажатиеКонAMax As Double = 0
    Private _НажатиеКонBMin As Double = 0
    Private _НажатиеКонBMax As Double = 0
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
    ''' Рабочее напряжение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property U() As Integer
        Get
            Return If(_U = Nothing, 0, If(_U > 0, _U, 0))
        End Get
        Set(ByVal value As Integer)
            _U = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Допуск по напряжению
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Uvalid() As Integer
        Get
            Return If(_Uvalid = Nothing, 0, If(_Uvalid > 0, _Uvalid, 0))
        End Get
        Set(ByVal value As Integer)
            _Uvalid = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Минимальное рабочее напряжение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Umin() As Integer
        Get
            Return If(U - Uvalid > 0, U - Uvalid, 0)
        End Get
    End Property
    ''' <summary>
    ''' Максимальное рабочее напряжение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Umax() As Integer
        Get
            Return If(U + Uvalid > 0, U + Uvalid, 0)
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат напряжения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Ustr() As String
        Get
            Return If(Umin > 0, "≤" & Umin.ToString(Base.doubleformat), "")
        End Get
    End Property
    ''' <summary>
    ''' Напряжение включения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UI() As Integer
        Get
            Return If(_UI = Nothing, 0, If(_UI > 0, _UI, 0))
        End Get
        Set(ByVal value As Integer)
            _UI = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Напряжение выключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UO() As Integer
        Get
            Return If(_UO = Nothing, 0, If(_UO > 0, _UO, 0))
        End Get
        Set(ByVal value As Integer)
            _UO = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Контроль UI
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlUI() As Boolean
        Get
            Return UI < Umin Or Umin <= 0
        End Get
    End Property
    ''' <summary>
    ''' Контроль UO
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlUO() As Boolean
        Get
            Return UO < Umin Or Umin <= 0
        End Get
    End Property
    ''' <summary>
    ''' Проверка работоспособности при минимальном напряжении
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlU() As Boolean
        Get
            Return ControlUI And ControlUO
        End Get
    End Property
    ''' <summary>
    ''' Рабочий ток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property I() As Double
        Get
            Return If(_I = Nothing, 0, If(_I > 0, _I, 0))
        End Get
        Set(ByVal value As Double)
            _I = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Допуск по току
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Ivalid() As Double
        Get
            Return If(_Ivalid = Nothing, 0, If(_Ivalid > 0, _Ivalid, 0))
        End Get
        Set(ByVal value As Double)
            _Ivalid = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Максимальный ток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Imin() As Double
        Get
            Return If(I - Ivalid > 0, I - Ivalid, 0)
        End Get
    End Property
    ''' <summary>
    ''' Максимальный ток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Imax() As Double
        Get
            Return If(I + Ivalid > 0, I + Ivalid, 0)
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат тока
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Istr() As String
        Get
            Return If(I > 0, _
                      If(Ivalid > 0, _
                         I.ToString(Base.doubleformat) & "±" & Ivalid.ToString(Base.doubleformat), _
                         "≤" & I.ToString(Base.doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Ток включения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property II() As Integer
        Get
            Return If(_II = Nothing, 0, If(_II > 0, _II, 0))
        End Get
        Set(ByVal value As Integer)
            _II = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Ток выключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IO() As Integer
        Get
            Return If(_IO = Nothing, 0, If(_IO > 0, _IO, 0))
        End Get
        Set(ByVal value As Integer)
            _IO = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Проверка тока включения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlII() As Boolean
        Get
            Return Not I > 0 Or If(Ivalid > 0, Imin <= II And II <= Imax, II <= I)
        End Get
    End Property
    ''' <summary>
    ''' Проверка тока выключения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlIO() As Boolean
        Get
            Return Not I > 0 Or If(Ivalid > 0, Imin <= IO And IO <= Imax, IO <= I)
        End Get
    End Property
    ''' <summary>
    ''' Рабочее сопротивление
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property R() As Double
        Get
            Return If(_R = Nothing, 0, If(_R > 0, _R, 0))
        End Get
        Set(ByVal value As Double)
            _R = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Допуск по сопротивлению
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Rvalid() As Double
        Get
            Return If(_Rvalid = Nothing, 0, If(_Rvalid > 0, _Rvalid, 0))
        End Get
        Set(ByVal value As Double)
            _Rvalid = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Максимальное сопротивление
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Rmin() As Double
        Get
            Return If(R - Rvalid > 0, R - Rvalid, 0)
        End Get
    End Property
    ''' <summary>
    ''' Максимальное сопротивление
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Rmax() As Double
        Get
            Return If(R + Rvalid > 0, R + Rvalid, 0)
        End Get
    End Property
    ''' <summary>
    ''' Строковый формат сопротивления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Rstr() As String
        Get
            Return If(R > 0, _
                      If(Rvalid > 0, _
                         R.ToString(Base.doubleformat) & "±" & Rvalid.ToString(Base.doubleformat), _
                         "≤" & R.ToString(Base.doubleformat)), _
                      "")
        End Get
    End Property
    ''' <summary>
    ''' Фактическое сопротивление
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Rfact() As Integer
        Get
            Return If(_Rfact = Nothing, 0, If(_Rfact > 0, _Rfact, 0))
        End Get
        Set(ByVal value As Integer)
            _Rfact = If(value = Nothing, 0, If(value > 0, value, 0))
        End Set
    End Property
    ''' <summary>
    ''' Проверка сопротивления
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ControlR() As Boolean
        Get
            Return Not R > 0 Or If(Rvalid > 0, Rmin <= Rfact And Rfact <= Rmax, Rfact <= R)
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
            Return If(j >= 0 And j < _KontsA.Count, _KontsA(j).ControlРастворКонтакта(РастворКонтактаAMin, РастворКонтактаAMax), False)
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
    ''' Полный контроль аппарата
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Control() As Boolean
        Get
            Control = ControlUO And ControlII And ControlIO And ControlR
            For j As Integer = 0 To KontACount - 1
                Control = Control And ControlA(j)
            Next
            For j As Integer = 0 To KontBCount - 1
                Control = Control And ControlB(j)
            Next
        End Get
    End Property
    ''' <summary>
    ''' Сохранение аппарата в файл "Base.devices"
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        dict.Add("U", U)
        dict.Add("Uvalid", Uvalid)
        dict.Add("I", I)
        dict.Add("Ivalid", Ivalid)
        dict.Add("R", R)
        dict.Add("Rvalid", Rvalid)
        dict.Add("KontACount", KontACount)
        dict.Add("KontBCount", KontBCount)
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
        If Base.devices.Write(Name, dict) <> 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, "Устройство " & Name & " не сохранено")
    End Sub
    Public Sub Read(ByVal _Name_ As String)
        Dim dict = devices.Read(_Name_)
        Using f = New System.IO.StreamWriter(TPA.BasePath & "dict.txt")
            For Each j In dict
                f.WriteLine(j.Key & " [" & j.Value & "]")
            Next
        End Using
        Name = _Name_
        Try
            U = Convert.ToInt32(dict("U"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[U]")
        End Try
        Try
            Uvalid = Convert.ToInt32(dict("Uvalid"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Uvalid]")
        End Try
        Try
            I = Convert.ToDouble(dict("I"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[I]")
        End Try
        Try
            Ivalid = Convert.ToDouble(dict("Ivalid"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Ivalid]")
        End Try
        Try
            R = Convert.ToDouble(dict("R"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[R]")
        End Try
        Try
            Rvalid = Convert.ToDouble(dict("Rvalid"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & Name & "[Rvalid]")
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
    End Sub
End Class

Public Class coltrolStruct
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
    Private _Состояние As Boolean = True
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
