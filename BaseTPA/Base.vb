Module Base
    Public ReadOnly setting As TPA.Ini = New TPA.Ini()
    Public ReadOnly users As TPA.Ini = New TPA.Ini("user")
    Public ReadOnly devices As TPA.Ini = New TPA.Ini("device")
    Public ReadOnly reports As TPA.Ini = New TPA.Ini("report")

    Public Const doubleformat As String = "#0.0"

#Region "device"
    ''' <summary>
    ''' Контактор
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure DeviceStruct
        Private _name As String
        ''' <summary>
        ''' Модель устройства
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property name() As String
            Get
                Try
                    Return If(_name.Length > 0, _name, "")
                Catch ex As Exception
                    Return ""
                End Try
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Private _num As String
        ''' <summary>
        ''' Идентификатор устройства
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property num() As String
            Get
                If _num = Nothing Then Return ""
                Return _num
            End Get
            Set(ByVal value As String)
                _num = value
            End Set
        End Property
        Private _U As Integer
        ''' <summary>
        ''' Рабочее напряжение
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property U() As Integer
            Get
                Return _U
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                _U = value
            End Set
        End Property
        Private _Uvalid As Integer
        ''' <summary>
        ''' Допуск понапряжению
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Uvalid() As Integer
            Get
                Return _Uvalid
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value *= -1
                _Uvalid = value
            End Set
        End Property
        ''' <summary>
        ''' Напряжение с допуском
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Ustring() As String
            Get
                Return U & "±" & Uvalid
            End Get
        End Property
        ''' <summary>
        ''' Минимально допустимое напряжение
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Umin() As Integer
            Get
                Return Math.Max(U - Uvalid, 0)
            End Get
        End Property
        Private _UI As Integer
        ''' <summary>
        ''' Напряжение включения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UI() As Integer
            Get
                Return _UI
            End Get
            Set(ByVal value As Integer)
                _UI = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки напряжения включения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property UIcontrol() As Boolean
            Get
                Return UI <= U - Uvalid
            End Get
        End Property
        Private _UO As Integer
        ''' <summary>
        ''' Напряжение отключения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UO() As Integer
            Get
                Return _UO
            End Get
            Set(ByVal value As Integer)
                _UO = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки напряжения отключения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property UOcontrol() As Boolean
            Get
                Return UO <= U - Uvalid And UO < UI
            End Get
        End Property

        Private _I As Double
        ''' <summary>
        ''' Рабочая сила тока
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property I() As Double
            Get
                Return _I
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _I = value
            End Set
        End Property
        Private _Ivalid As Double
        ''' <summary>
        ''' Допуск по силе тока
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Ivalid() As Double
            Get
                Return _Ivalid
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value *= -1
                _Ivalid = value
            End Set
        End Property
        ''' <summary>
        ''' Сила тока с допуском
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Istring() As String
            Get
                If I > 0 Then
                    If Ivalid > 0 Then
                        Return I.ToString(Base.doubleformat) & "±" & Ivalid.ToString(Base.doubleformat)
                    Else
                        Return "≤" & I.ToString(Base.doubleformat)
                    End If
                End If
                Return ""
            End Get
        End Property
        Private _II As Integer
        ''' <summary>
        ''' Сила тока включения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property II() As Integer
            Get
                Return _II
            End Get
            Set(ByVal value As Integer)
                _II = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки силы тока включения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IIcontrol() As Boolean
            Get
                If Ivalid > 0 Then
                    Return I - Ivalid <= II And II <= I + Ivalid
                Else
                    Return II <= I + Ivalid
                End If
            End Get
        End Property
        Private _IO As Integer
        ''' <summary>
        ''' Сила тока отключения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IO() As Integer
            Get
                Return _IO
            End Get
            Set(ByVal value As Integer)
                _IO = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки силы тока отключения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IOcontrol() As Boolean
            Get
                Return I - Ivalid <= IO And IO <= I + Ivalid
            End Get
        End Property

        Private _R As Double
        ''' <summary>
        ''' Сопротивление блока катушек
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property R() As Double
            Get
                Return _R
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _R = value
            End Set
        End Property
        Private _Rvalid As Double
        ''' <summary>
        ''' Допуск по сопротивлению блока катушек
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Rvalid() As Double
            Get
                Return _Rvalid
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value *= -1
                _Rvalid = value
            End Set
        End Property
        ''' <summary>
        ''' Сопротивление катушек с допуском
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Rstring() As String
            Get
                Return R.ToString(Base.doubleformat) & "±" & Rvalid.ToString(Base.doubleformat)
            End Get
        End Property
        Private _Rfact As Double
        ''' <summary>
        ''' Фактическое сопротивление катушек
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Rfact() As Double
            Get
                Return _Rfact
            End Get
            Set(ByVal value As Double)
                _Rfact = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки силы тока отключения
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Rcontrol() As Boolean
            Get
                Return R - Rvalid <= Rfact And Rfact <= R + Rvalid
            End Get
        End Property
        ''' <summary>
        ''' Контроль работоспособности при Umin
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property РаботоспособностьПриUmin() As Boolean
            Get
                Return UIcontrol And UOcontrol
            End Get
        End Property

        Private _KontCount As Integer
        ''' <summary>
        ''' Количество контакторов
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property KontCount() As Integer
            Get
                Return _KontCount
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then value = 1
                _KontCount = value
                Dim __konts As KontStruct() = _Konts
                ReDim _Konts(value - 1)
                Dim nk As List(Of KontStruct) = New List(Of KontStruct)
                For i As Integer = 0 To _Konts.Length - 1
                    Try
                        nk.Add(__konts(i))
                    Catch ex As Exception
                        nk.Add(New KontStruct)
                    End Try
                Next
                _Konts = nk.ToArray
            End Set
        End Property

        Private _Konts As KontStruct()
        ''' <summary>
        ''' Минимальный раствор контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property РастворКонтактаMin(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).РастворКонтактаMin
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).РастворКонтактаMin = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Максимальный раствор контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property РастворКонтактаMax(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).РастворКонтактаMax
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).РастворКонтактаMax = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Раствор контакта формата [min..max]
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property РастворКонтактаMinMaxString(ByVal i As Integer) As String
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).РастворКонтактаMinMaxString
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return Nothing
                End If
            End Get
        End Property
        ''' <summary>
        ''' Фактический раствор контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property РастворКонтактаFact(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).РастворКонтактаFact
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).РастворКонтактаFact = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки раствора контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property РастворКонтактаControl(ByVal i As Integer) As Boolean
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).РастворКонтактаControl
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return False
                End If
            End Get
        End Property
        ''' <summary>
        ''' Минимальный провал контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ПровалКонтактаMin(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).ПровалКонтактаMin
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).ПровалКонтактаMin = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Максимальный провал контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ПровалКонтактаMax(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).ПровалКонтактаMax
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).ПровалКонтактаMax = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Провал контакта формата [min..max]
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ПровалКонтактаMinMaxString(ByVal i As Integer) As String
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).ПровалКонтактаMinMaxString
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return Nothing
                End If
            End Get
        End Property
        ''' <summary>
        ''' Фактический провал контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ПровалКонтактаFact(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).ПровалКонтактаFact
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).ПровалКонтактаFact = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки провала контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ПровалКонтактаControl(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).ПровалКонтактаControl
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
        End Property
        ''' <summary>
        ''' Минимальное усилие начала нажатия
        ''' </summary>
        ''' <param name="i">номер контактора (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеНачMin(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеНачMin
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).НажатиеНачMin = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Максимальное усилие начала нажатия
        ''' </summary>
        ''' <param name="i">номер контактора (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеНачMax(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеНачMax
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).НажатиеНачMax = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Усилие начала нажатия формата [min..max]
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеНачMinMaxString(ByVal i As Integer) As String
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеНачMinMaxString
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return Nothing
                End If
            End Get
        End Property
        ''' <summary>
        ''' Фактическое усилие начала нажатия
        ''' </summary>
        ''' <param name="i">номер контактора (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеНачFact(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеНачFact
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).НажатиеНачFact = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки начала нажатия
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеНачControl(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеНачControl
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
        End Property
        ''' <summary>
        ''' Минимальное усилие конца нажатия
        ''' </summary>
        ''' <param name="i">номер контактора (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеКонMin(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеКонMin
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).НажатиеКонMin = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Максимальное усилие конца нажатия
        ''' </summary>
        ''' <param name="i">номер контактора (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеКонMax(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеКонMax
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).НажатиеКонMax = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Усилие конца нажатия формата [min..max]
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеКонMinMaxString(ByVal i As Integer) As String
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеКонMinMaxString
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return Nothing
                End If
            End Get
        End Property
        ''' <summary>
        ''' Фактическое усилие конца нажатия
        ''' </summary>
        ''' <param name="i">номер контактора (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеКонFact(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеКонFact
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
            Set(ByVal value As Double)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).НажатиеКонFact = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки конца нажатия
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеКонControl(ByVal i As Integer) As Double
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).НажатиеКонControl
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return 0
                End If
            End Get
        End Property
        ''' <summary>
        ''' Визуальная оценка состояния контакта
        ''' </summary>
        ''' <param name="i">номер контакта (с нуля)</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Состояние(ByVal i As Integer) As Boolean
            Get
                If i >= 0 And i < _Konts.Length Then
                    Return _Konts(i).Состояние
                Else
                    TPA.Log.Print(TPA.Rank.EXCEPT, "Выход за пределы диапазона [i=" & i & "; Konts(" & _Konts.Length & ")")
                    Return False
                End If
            End Get
            Set(ByVal value As Boolean)
                If i >= 0 And i < _Konts.Length Then
                    _Konts(i).Состояние = value
                End If
            End Set
        End Property
        Private _ControlsParameters As coltrolStruct
        ''' <summary>
        ''' Проверяемые параметры
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ControlsParameters() As coltrolStruct
            Get
                Return _ControlsParameters
            End Get
            Set(ByVal value As coltrolStruct)
                _ControlsParameters = value
                For j = 0 To KontCount - 1
                    _Konts(j).ControlsParameters = value
                Next
            End Set
        End Property
        ''' <summary>
        ''' Допуск по всем параметрам
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FillControl() As Boolean
            Get
                FillControl = True
                If Not _Konts Is Nothing Then
                    For Each j In _Konts
                        FillControl = FillControl And j.FillControl
                    Next
                End If
                If ControlsParameters.R Then FillControl = FillControl And Rcontrol
                FillControl = FillControl And UIcontrol And UOcontrol And IIcontrol And IOcontrol And РаботоспособностьПриUmin
            End Get
        End Property
    End Structure
    ''' <summary>
    ''' Контакт контактора
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure KontStruct
        Private _РастворКонтактаMin As Double
        Private _РастворКонтактаMax As Double
        Private _РастворКонтактаFact As Double
        ''' <summary>
        ''' Минимальный растрор контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property РастворКонтактаMin() As Double
            Get
                Return Math.Min(_РастворКонтактаMin, _РастворКонтактаMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _РастворКонтактаMin = value
            End Set
        End Property
        ''' <summary>
        ''' Максимальный раствор контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property РастворКонтактаMax() As Double
            Get
                Return Math.Max(_РастворКонтактаMin, _РастворКонтактаMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _РастворКонтактаMax = value
            End Set
        End Property
        ''' <summary>
        ''' Раствор контакта формата [min..max]
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property РастворКонтактаMinMaxString() As String
            Get
                Return РастворКонтактаMin.ToString(Base.doubleformat) & ".." & РастворКонтактаMax.ToString(Base.doubleformat)
            End Get
        End Property
        ''' <summary>
        ''' Фактический раствор контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property РастворКонтактаFact() As Double
            Get
                Return _РастворКонтактаFact
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _РастворКонтактаFact = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки раствора контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property РастворКонтактаControl() As Boolean
            Get
                Return РастворКонтактаMin <= РастворКонтактаFact And РастворКонтактаFact <= РастворКонтактаMax
            End Get
        End Property
        Private _ПровалКонтактаMin As Double
        Private _ПровалКонтактаMax As Double
        Private _ПровалКонтактаFact As Double
        ''' <summary>
        ''' Минимальный провал контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ПровалКонтактаMin() As Double
            Get
                Return Math.Min(_ПровалКонтактаMin, _ПровалКонтактаMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _ПровалКонтактаMin = value
            End Set
        End Property
        ''' <summary>
        ''' Максимальный провал контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ПровалКонтактаMax() As Double
            Get
                Return Math.Max(_ПровалКонтактаMin, _ПровалКонтактаMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _ПровалКонтактаMax = value
            End Set
        End Property
        ''' <summary>
        ''' Провал контакта формата [min..max]
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ПровалКонтактаMinMaxString() As String
            Get
                Return ПровалКонтактаMin.ToString(Base.doubleformat) & ".." & ПровалКонтактаMax.ToString(Base.doubleformat)
            End Get
        End Property
        ''' <summary>
        ''' Фактический провал контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ПровалКонтактаFact() As Double
            Get
                Return _ПровалКонтактаFact
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _ПровалКонтактаFact = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки провала контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ПровалКонтактаControl() As Boolean
            Get
                Return ПровалКонтактаMin <= ПровалКонтактаFact And ПровалКонтактаFact <= ПровалКонтактаMax
            End Get
        End Property
        Private _НажатиеНачMin As Double
        Private _НажатиеНачMax As Double
        Private _НажатиеНачFact As Double
        ''' <summary>
        ''' Минимальное усилие начала нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеНачMin() As Double
            Get
                Return Math.Min(_НажатиеНачMin, _НажатиеНачMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _НажатиеНачMin = value
            End Set
        End Property
        ''' <summary>
        ''' Максимальное усилие начала нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеНачMax() As Double
            Get
                Return Math.Max(_НажатиеНачMin, _НажатиеНачMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _НажатиеНачMax = value
            End Set
        End Property
        ''' <summary>
        ''' Усилие начала нажатия формата [min..max]
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеНачMinMaxString() As String
            Get
                Return НажатиеНачMin.ToString(Base.doubleformat) & ".." & НажатиеНачMax.ToString(Base.doubleformat)
            End Get
        End Property
        ''' <summary>
        ''' Фактическое усилие начала нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеНачFact() As Double
            Get
                Return _НажатиеНачFact
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _НажатиеНачFact = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки усилия начала нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеНачControl() As Boolean
            Get
                Return НажатиеНачMin <= НажатиеНачFact And НажатиеНачFact <= НажатиеНачMax
            End Get
        End Property
        Private _НажатиеКонMin As Double
        Private _НажатиеКонMax As Double
        Private _НажатиеКонFact As Double
        ''' <summary>
        ''' Минимальное усилие конца нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеКонMin() As Double
            Get
                Return Math.Min(_НажатиеКонMin, _НажатиеКонMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _НажатиеКонMin = value
            End Set
        End Property
        ''' <summary>
        ''' Максимальное усилие конца нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеКонMax() As Double
            Get
                Return Math.Max(_НажатиеКонMin, _НажатиеКонMax)
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _НажатиеКонMax = value
            End Set
        End Property
        ''' <summary>
        ''' Усилие конца нажатия формата [min..max]
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеКонMinMaxString() As String
            Get
                Return НажатиеКонMin.ToString(Base.doubleformat) & ".." & НажатиеКонMax.ToString(Base.doubleformat)
            End Get
        End Property
        ''' <summary>
        ''' Фактическое усилие конца нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property НажатиеКонFact() As Double
            Get
                Return _НажатиеКонFact
            End Get
            Set(ByVal value As Double)
                If value < 0 Then value = 0
                _НажатиеКонFact = value
            End Set
        End Property
        ''' <summary>
        ''' Результат проверки усилия конца нажатия
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property НажатиеКонControl() As Boolean
            Get
                Return НажатиеКонMin <= НажатиеКонFact And НажатиеКонFact <= НажатиеКонMax
            End Get
        End Property
        Private _Состояние As Boolean
        ''' <summary>
        ''' Визуальная оценка состояния контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Состояние() As Boolean
            Get
                Return _Состояние
            End Get
            Set(ByVal value As Boolean)
                _Состояние = value
            End Set
        End Property
        Private _ControlsParameters As coltrolStruct
        ''' <summary>
        ''' Проверяемые параметры
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ControlsParameters() As coltrolStruct
            Get
                Return _ControlsParameters
            End Get
            Set(ByVal value As coltrolStruct)
                _ControlsParameters = value
            End Set
        End Property
        ''' <summary>
        ''' допуск по всем параметрам контакта
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FillControl() As Boolean
            Get
                FillControl = True
                If ControlsParameters.РастворКонтактов Then FillControl = FillControl And РастворКонтактаControl
                If ControlsParameters.ПровалКонтактов Then FillControl = FillControl And ПровалКонтактаControl
                If ControlsParameters.НажатиеНач Then FillControl = FillControl And НажатиеНачControl
                If ControlsParameters.НажатиеКон Then FillControl = FillControl And НажатиеКонControl
                If ControlsParameters.Состояние Then FillControl = FillControl And Состояние
            End Get
        End Property
    End Structure

    Public Function ReadDevice(ByVal name As String) As DeviceStruct
        Dim dict = devices.Read(name)
        ReadDevice = New DeviceStruct
        ReadDevice.name = name
        Try
            ReadDevice.U = Convert.ToInt32(dict("U"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[U]")
        End Try
        Try
            ReadDevice.Uvalid = Convert.ToInt32(dict("Uvalid"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[Uvalid]")
        End Try
        Try
            ReadDevice.I = Convert.ToDouble(dict("I"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[I]")
        End Try
        Try
            ReadDevice.Ivalid = Convert.ToDouble(dict("Ivalid"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[Ivalid]")
        End Try
        Try
            ReadDevice.R = Convert.ToDouble(dict("R"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[R]")
        End Try
        Try
            ReadDevice.Rvalid = Convert.ToDouble(dict("Rvalid"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[Rvalid]")
        End Try
        Try
            ReadDevice.KontCount = Convert.ToInt32(dict("KontCount"))
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[KontCount]")
        End Try
        For i As Integer = 0 To ReadDevice.KontCount - 1
            Try
                ReadDevice.РастворКонтактаMin(i) = Convert.ToDouble(dict("РастворКонтактаMin(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[РастворКонтактаMin(" & i & ")]")
            End Try
            Try
                ReadDevice.РастворКонтактаMax(i) = Convert.ToDouble(dict("РастворКонтактаMax(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[РастворКонтактаMax(" & i & ")]")
            End Try
            Try
                ReadDevice.ПровалКонтактаMin(i) = Convert.ToDouble(dict("ПровалКонтактаMin(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[ПровалКонтактаMin(" & i & ")]")
            End Try
            Try
                ReadDevice.ПровалКонтактаMax(i) = Convert.ToDouble(dict("ПровалКонтактаMax(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[ПровалКонтактаMax(" & i & ")]")
            End Try
            Try
                ReadDevice.НажатиеНачMin(i) = Convert.ToDouble(dict("НажатиеНачMin(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[НажатиеНачMin(" & i & ")]")
            End Try
            Try
                ReadDevice.НажатиеНачMax(i) = Convert.ToDouble(dict("НажатиеНачMax(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[НажатиеНачMax(" & i & ")]")
            End Try
            Try
                ReadDevice.НажатиеКонMin(i) = Convert.ToDouble(dict("НажатиеКонMin(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[НажатиеКонMin(" & i & ")]")
            End Try
            Try
                ReadDevice.НажатиеКонMax(i) = Convert.ToDouble(dict("НажатиеКонMax(" & i & ")"))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "Ошибка чтения устройства: " & name & "[НажатиеКонMax(" & i & ")]")
            End Try
        Next
    End Function

    Public Sub WriteDevice(ByVal device As DeviceStruct)
        Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
        dict.Add("U", device.U)
        dict.Add("Uvalid", device.Uvalid)
        dict.Add("I", device.I)
        dict.Add("Ivalid", device.Ivalid)
        dict.Add("R", device.R)
        dict.Add("Rvalid", device.Rvalid)
        dict.Add("KontCount", device.KontCount)
        For i As Integer = 0 To device.KontCount - 1
            dict.Add("РастворКонтактаMin(" & i & ")", device.РастворКонтактаMin(i))
            dict.Add("РастворКонтактаMax(" & i & ")", device.РастворКонтактаMax(i))
            dict.Add("ПровалКонтактаMin(" & i & ")", device.ПровалКонтактаMin(i))
            dict.Add("ПровалКонтактаMax(" & i & ")", device.ПровалКонтактаMax(i))
            dict.Add("НажатиеНачMin(" & i & ")", device.НажатиеНачMin(i))
            dict.Add("НажатиеНачMax(" & i & ")", device.НажатиеНачMax(i))
            dict.Add("НажатиеКонMin(" & i & ")", device.НажатиеКонMin(i))
            dict.Add("НажатиеКонMax(" & i & ")", device.НажатиеКонMax(i))
        Next
        If Base.devices.Write(device.name, dict) <> 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, "Устройство " & device.name & " не сохранено")
    End Sub
#End Region

    ''' <summary>
    ''' Считывает время ожидания операции
    ''' </summary>
    ''' <param name="_step"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadTimeToSleep(ByVal _step As Steps) As Integer
        Dim val As String
        Select Case _step
            Case Steps.Start
                val = "Start"
            Case Steps.UIWait
                val = "UIWait"
            Case Steps.UIcontrol
                val = "UIcontrol"
            Case Steps.RWait
                val = "RWait"
            Case Steps.Rcontrol
                val = "Rcontrol"
            Case Steps.Result
                val = "Result"
            Case Steps.MechanicalControl
                val = "MechanicalControl"
            Case Else
                val = ""
        End Select
        Try
            ReadTimeToSleep = Convert.ToInt32(setting.Read("ТАЙМЕР", val)) * 60
        Catch ex As Exception
            ReadTimeToSleep = 600
        End Try
        If ReadTimeToSleep <= 0 Then ReadTimeToSleep = 600
    End Function

    Public Enum Steps
        Sleep
        Start
        UIWait
        UIcontrol
        RWait
        Rcontrol
        MechanicalControl
        Result
    End Enum

    Public Structure coltrolStruct
        Public R As Boolean
        Public РастворКонтактов As Boolean
        Public ПровалКонтактов As Boolean
        Public НажатиеНач As Boolean
        Public НажатиеКон As Boolean
        Public Состояние As Boolean
    End Structure

#Region "Rобр"
    Public ReadOnly Property Rобр1() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр1"))
            Catch ex As Exception
                Return 100.51
            End Try
        End Get
    End Property

    Public ReadOnly Property Rобр2() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр2"))
            Catch ex As Exception
                Return 998
            End Try
        End Get
    End Property

    Public ReadOnly Property Rобр3() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр3"))
            Catch ex As Exception
                Return 10030
            End Try
        End Get
    End Property

    Public ReadOnly Property Rобр4() As Double
        Get
            Try
                Return Convert.ToDouble(setting.Read("СТЕНД", "Rобр4"))
            Catch ex As Exception
                Return 99767
            End Try
        End Get
    End Property
#End Region
End Module
