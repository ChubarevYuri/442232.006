Module Test
    Public user As String = ""
    Public device As Base.DeviceStruct
    Public timeStart As DateTime = Now

    ''' <summary>
    ''' Настройка предела измерения тока
    ''' </summary>
    ''' <param name="limit">Максимальная сила тока</param>
    ''' <returns>Сообщение о выполнении команды</returns>
    ''' <remarks></remarks>
    Public Function ILimit(ByVal limit As Double) As Boolean
        If limit <= 1 Then
        Else
        End If
        Return True
    End Function

#Region "UI"

    Private _UImeter As TPA.БФУ_GB106v2 = New TPA.БФУ_GB106v2(_UImeterAddres, _UImeterName, writeTimeout:=200)
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
            _UImeter.ОПРОСAin1 = True
            _UImeter.ОПРОСAin2 = True
            _UImeter.ОПРОСAin3 = True
            TPA.DeviseInspection.addDevice(_UImeter)
            _firstStartInspection = False
        End If
        TPA.DeviseInspection.startInspection()
    End Sub
#End Region

#Region "R"
    Friend R As Double = 0
    Private _Rmeter As TPA.КМФ_1115_омметр = New TPA.КМФ_1115_омметр(_RmeterAddres, _RmeterName, writeTimeout:=200)
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

    ''' <summary>
    ''' Сопротивление
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Rread()
        Do
            Dim res
            Try
                res = _Rmeter.val
                If res = Nothing Then
                    TPA.DialogForms.Message("Перед измерением сопротивления отключите источник от устройства!", "АВАРИЯ", TPA.MsgType.except)
                    TPA.Log.Print(TPA.Rank.MESSAGE, "Замер сопротивления при подключенном напряжении")
                Else
                    If res = Integer.MinValue Then TPA.Log.Print(TPA.Rank.WARNING, "Сопротивление не прочитано, наверное недостаточно времени")
                    If res > 0 And res < Int32.MaxValue Then
                        R = res
                    Else
                    End If
                End If
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.EXCEPT, "Ошибка чтения R [Test Sub Rread()]")
            End Try
        Loop
    End Sub

    Private thread As Threading.Thread
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
        If Not RreadOn Then
            TPA.DeviseInspection.stopInspection()
            thread = New Threading.Thread(AddressOf Rread)
            thread.Priority = Threading.ThreadPriority.Normal
            thread.Start()
            RreadOn = True
        End If
    End Sub

    ''' <summary>
    ''' Прекращение процесса считывания R
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RreadStop()
        If RreadOn Then
            thread.Abort()
            RreadOn = False
            start()
        End If
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
    Public Sub UrecBoth()
        Try
            Urec -= Convert.ToDouble(setting.Read("СТЕНД", "U rec step"))
        Catch ex As Exception
            Urec -= 1
        End Try
        U = Urec
    End Sub
    ''' <summary>
    ''' повысить напряжение
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UrecTop()
        Try
            Urec += Convert.ToDouble(setting.Read("СТЕНД", "U rec step"))
        Catch ex As Exception
            Urec += 1
        End Try
        U = Urec
    End Sub
    ''' <summary>
    ''' Напряжение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property U() As Integer
        Get
            Try
                Dim res As TPA.DeviseInspection.ResultType = TPA.DeviseInspection.result(_UImeterAddres)
                If res.err.Length > 0 Then TPA.Log.Print(TPA.Rank.EXCEPT, res.err)
                Dim answer As Dictionary(Of String, Object) = res.answer
                Dim Udouble As Double = answer(setting.Read("СТЕНД", "Uchannel"))
                Try
                    Udouble *= Convert.ToDouble(setting.Read("СТЕНД", "U (*)"))
                Catch ex As Exception
                End Try
                Try
                    Udouble += Convert.ToDouble(setting.Read("СТЕНД", "U (+)"))
                Catch ex As Exception
                End Try
                U = Udouble
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.EXCEPT, "Ошибка чтения U [Test Property U() As Integer]")
                U = 0
            End Try
        End Get
        Set(ByVal value As Integer)

            TPA.Log.Print(TPA.Rank.OK, "U(0..4095)=" & value)
            TPA.DeviseInspection.AddCommand(_UImeter.Регулятор(value))
        End Set
    End Property

    Public Enum IOstat
        Close_Close
        Close_Open
        Open_Close
        Open_Open
    End Enum

    Private _IO As Boolean = False
    ''' <summary>
    ''' состояние контакта в текущий момент
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IOnow() As Boolean
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
