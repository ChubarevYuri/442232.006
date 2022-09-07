Module Test
    Public user As String = ""
    Public master As String = ""
    Public device As Device = New Device()
    Public timeStart As DateTime = Now

#Region "UI"

    Friend _UImeter As TPA.БФУ_GB106v2 = New TPA.БФУ_GB106v2(_UImeterAddres, _UImeterName, writeTimeout:=200)
    Private ReadOnly Property _UImeterAddres() As Integer
        Get
            Try
                Return Convert.ToInt32(Base.setting.Read("СТЕНД", "UI"))
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property
    Private ReadOnly Property _UImeterName() As String
        Get
            _UImeterName = Base.setting.Read("СТЕНД", "порт")
            Return If(_UImeterName.Length > 0, _UImeterName, "COM4")
        End Get
    End Property
    Private _firstStartInspection As Boolean = True
    Public Sub start()
        If _firstStartInspection Then
            _UImeter.ОПРОСдискреты = True
            _UImeter.ОПРОСAin2 = True
            _UImeter.ОПРОСAin3 = True
            _UImeter.ОПРОСAin4 = True
            U = 0
            A1using = False
            TPA.DeviseInspection.addDevice(_UImeter)
            _firstStartInspection = False
        End If
        TPA.DeviseInspection.startInspection()
    End Sub
#End Region

#Region "R"
    Friend R As Double = 0
    Private _Rmeter As TPA.КМФ_1115_омметр = New TPA.КМФ_1115_омметр(_RmeterAddres, _RmeterName, writeTimeout:=100, readTimeout:=500)
    Private ReadOnly Property _RmeterAddres() As Integer
        Get
            Try
                Return Convert.ToInt32(Base.setting.Read("СТЕНД", "R"))
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property
    Private ReadOnly Property _RmeterName() As String
        Get
            _RmeterName = Base.setting.Read("СТЕНД", "порт")
            Return If(_RmeterName.Length > 0, _RmeterName, "COM4")
        End Get
    End Property

    Private RreadOn As Boolean = False
    ''' <summary>
    ''' Работает ли процесс чтения R
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property Ron() As Boolean
        Get
            Return RreadOn
        End Get
    End Property
    ''' <summary>
    ''' Запуск процесса считывания R
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RreadStart()
        U = 0
        R = 0
        Threading.Thread.Sleep(300)
        _Rmeter.Rобр = New Double() {Base.Rобр1, Base.Rобр2, Base.Rобр3, Base.Rобр4}
        TPA.DeviseInspection.stopInspection()
        RreadOn = True
        Threading.Thread.Sleep(50)
        Try
            Dim res = _Rmeter.val(2000)
            If res = Double.MinValue Then
                BaseForm.TimerControl.Enabled = False
                TPA.DialogForms.Message("Перед измерением сопротивления отключите источник от устройства!", "АВАРИЯ", TPA.MsgType.except)
                TPA.Log.Print(TPA.Rank.MESSAGE, "Замер сопротивления при подключенном напряжении")
                BaseForm.TimerControl.Enabled = True
            ElseIf res = -1 Then
                R = -1
                TPA.Log.Print(TPA.Rank.MESSAGE, "Замер сопротивления не выполнен")
            ElseIf res = 0 Then
                R = 0
                TPA.DialogForms.Message("Значение вне диапазона 10 Ом - 50 кОм", "АВАРИЯ", TPA.MsgType.except)
            ElseIf res = Double.MaxValue Then
                R = 0
                TPA.DialogForms.Message("Значение вне диапазона 10 Ом - 50 кОм", "АВАРИЯ", TPA.MsgType.except)
            Else
                R = res
            End If
        Catch ex As Exception
            TPA.Log.Print(TPA.Rank.EXCEPT, "Ошибка чтения R [Test Sub Rread()]")
        End Try
        RreadOn = False
        start()
        U = _Urec
    End Sub

#End Region

    ''' <summary>
    ''' Сила тока
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property I() As Double
        Get
            Try
                Dim res As TPA.DeviseInspection.ResultType = TPA.DeviseInspection.result(_UImeterAddres)
                If res.err.Length > 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, res.err)
                Dim answer As Dictionary(Of String, Object) = res.answer
                If A1using Then
                    I = answer(setting.Read("СТЕНД", "I1Achannel"))
                    Try
                        I *= Convert.ToDouble(setting.Read("СТЕНД", "I1A (*)"))
                    Catch ex As Exception
                    End Try
                    Try
                        I += Convert.ToDouble(setting.Read("СТЕНД", "I1A (+)"))
                    Catch ex As Exception
                    End Try
                Else
                    I = answer(setting.Read("СТЕНД", "I10Achannel"))
                    Try
                        I *= Convert.ToDouble(setting.Read("СТЕНД", "I10A (*)"))
                    Catch ex As Exception
                    End Try
                    Try
                        I += Convert.ToDouble(setting.Read("СТЕНД", "I10A (+)"))
                    Catch ex As Exception
                    End Try
                End If
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.EXCEPT, "Ошибка чтения I [Test Property I() As Double]")
                Return 0
            End Try
        End Get
    End Property

    Private _Urec As Integer = 0
    Public Property Urec() As Integer
        Get
            Return _Urec
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            If value > 4095 Then value = 4095
            U = value
            _Urec = value
        End Set
    End Property
    ''' <summary>
    ''' понизить напряжение
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UrecBoth(Optional ByVal mech As Boolean = False)
        Dim corr As Double = 0
        Try
            corr = Convert.ToDouble(setting.Read("СТЕНД", "U rec step (*)"))
            Try
                corr *= If(mech, Convert.ToDouble(setting.Read("СТЕНД", "U rec mech")), Convert.ToDouble(setting.Read("СТЕНД", "U rec auto")))
            Catch ex As Exception

            End Try
        Catch ex As Exception
            corr = 1
        End Try
        Urec -= corr
    End Sub
    ''' <summary>
    ''' повысить напряжение
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UrecTop(Optional ByVal mech As Boolean = False)
        Dim corr As Double = 0
        Try
            corr = Convert.ToDouble(setting.Read("СТЕНД", "U rec step (*)"))
            Try
                corr *= If(mech, Convert.ToDouble(setting.Read("СТЕНД", "U rec mech")), Convert.ToDouble(setting.Read("СТЕНД", "U rec auto")))
            Catch ex As Exception

            End Try
        Catch ex As Exception
            corr = 1
        End Try
        Urec += corr
    End Sub
    ''' <summary>
    ''' Напряжение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property U() As Double
        Get
            Try
                Dim res As TPA.DeviseInspection.ResultType = TPA.DeviseInspection.result(_UImeterAddres)
                If res.err.Length > 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, res.err)
                Dim answer As Dictionary(Of String, Object) = res.answer
                U = answer(setting.Read("СТЕНД", "Uchannel"))
                Try
                    U *= Convert.ToDouble(setting.Read("СТЕНД", "U (*)"))
                Catch ex As Exception
                End Try
                Try
                    U += Convert.ToDouble(setting.Read("СТЕНД", "U (+)"))
                Catch ex As Exception
                End Try
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.EXCEPT, "Ошибка чтения U")
                U = 0
            End Try
        End Get
        Set(ByVal value As Double)
            TPA.Log.Print(TPA.Rank.OK, "U(0..4095)=" & value)
            If value > 0 Then
                If Not _open7 Then
                    TPA.DeviseInspection.AddCommand(_UImeter.out7(True))
                    _open7 = True
                End If
            Else
                TPA.DeviseInspection.AddCommand(_UImeter.out7(False))
                _open7 = False
            End If
            TPA.DeviseInspection.AddCommand(_UImeter.Регулятор(Convert.ToInt32(value)))
        End Set
    End Property

    Private _open7 As Boolean = False

    Public Enum IOstat
        Close_Close
        Close_Open
        Open_Close
        Open_Open
    End Enum

    Friend _IO As Boolean = False
    ''' <summary>
    ''' состояние контакта в текущий момент
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IOnow() As Boolean
        Try
            Dim res As TPA.DeviseInspection.ResultType = TPA.DeviseInspection.result(_UImeterAddres)
            If res.err.Length > 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, res.err)
            Dim answer As Dictionary(Of String, Object) = res.answer
            Dim IOall As KeyValuePair(Of Boolean(), Boolean()) = answer("Дискреты")
            Return IOall.Key(3)
        Catch ex As Exception
            Return _IO
        End Try
    End Function
    ''' <summary>
    ''' Close_Close - закрыт
    ''' Close_Open - открылся
    ''' Open_Close - закрылся
    ''' Open_Open - открыт
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IO() As IOstat
        Get
            IO = 0
            Dim _IOnow As Boolean = IOnow()
            IO += If(_IO, 2, 0)
            IO += If(_IOnow, 1, 0)
            _IO = _IOnow
        End Get
    End Property

    ''' <summary>
    ''' True - 1A max
    ''' False - 10A max
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property A1using() As Boolean
        Get
            Try
                Dim res As TPA.DeviseInspection.ResultType = TPA.DeviseInspection.result(_UImeterAddres)
                If res.err.Length > 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, res.err)
                Dim answer As Dictionary(Of String, Object) = res.answer
                Dim IOall As KeyValuePair(Of Boolean(), Boolean()) = answer("Дискреты")
                Return IOall.Value(7)
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(ByVal value As Boolean)
            TPA.Log.Print(TPA.Rank.OK, "Переключение замера напряжения в режим " & If(value, "1 A", "10 A"))
            TPA.DeviseInspection.AddCommand(_UImeter.out8(value))
        End Set
    End Property

End Module
