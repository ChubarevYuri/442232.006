Public Class OperationsForm

    Public result As coltrolStruct
    Private ReadOnly Property allTrue() As Boolean
        Get
            If PanelO.Enabled Then
                If Not result.O Then Return False
            End If
            If PanelI.Enabled Then
                If Not result.I Then Return False
            End If
            If PanelW.Enabled Then
                If Not result.work Then Return False
            End If
            If PanelR.Enabled Then
                If Not result.R Then Return False
            End If
            If PanelСостояние.Enabled Then
                If Not result.Состояние Then Return False
            End If
            If PanelРаствор.Enabled Then
                If Not result.РастворКонтактов Then Return False
            End If
            If PanelПровал.Enabled Then
                If Not result.ПровалКонтактов Then Return False
            End If
            If PanelНач.Enabled Then
                If Not result.НажатиеНач Then Return False
            End If
            If PanelКон.Enabled Then
                If Not result.НажатиеКон Then Return False
            End If
            Return True
        End Get
    End Property

    Public Sub New(ByVal par As coltrolStruct)
        result = par
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

        If result.O Then
            PictureBoxO.Image = My.Resources.Resource._true
        Else
            PictureBoxO.Image = My.Resources.Resource._false
            PanelO.Enabled = False
        End If

        If result.I Then
            PictureBoxI.Image = My.Resources.Resource._true
        Else
            PictureBoxI.Image = My.Resources.Resource._false
            PanelI.Enabled = False
        End If

        If result.work Then
            PictureBoxW.Image = My.Resources.Resource._true
        Else
            PictureBoxW.Image = My.Resources.Resource._false
            PanelW.Enabled = False
        End If

        If result.R Then
            PictureBoxR.Image = My.Resources.Resource._true
        Else
            PictureBoxR.Image = My.Resources.Resource._false
            PanelR.Enabled = False
        End If

        If result.Состояние Then
            PictureBoxСостояние.Image = My.Resources.Resource._true
        Else
            PictureBoxСостояние.Image = My.Resources.Resource._false
            PanelСостояние.Enabled = False
        End If

        If result.РастворКонтактов Then
            PictureBoxРаствор.Image = My.Resources.Resource._true
        Else
            PictureBoxРаствор.Image = My.Resources.Resource._false
            PanelРаствор.Enabled = False
        End If

        If result.ПровалКонтактов Then
            PictureBoxПровал.Image = My.Resources.Resource._true
        Else
            PictureBoxПровал.Image = My.Resources.Resource._false
            PanelПровал.Enabled = False
        End If

        If result.НажатиеНач Then
            PictureBoxНач.Image = My.Resources.Resource._true
        Else
            PictureBoxНач.Image = My.Resources.Resource._false
            PanelНач.Enabled = False
        End If

        If result.НажатиеКон Then
            PictureBoxКон.Image = My.Resources.Resource._true
        Else
            PictureBoxКон.Image = My.Resources.Resource._false
            PanelКон.Enabled = False
        End If
        PictureBoxAll.Image = My.Resources.Resource._true
        TPA.DialogForms.WaitFormStop()
    End Sub

    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub PanelСостояние_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelСостояние.Click, PictureBoxСостояние.Click
        result.Состояние = Not result.Состояние
        PictureBoxСостояние.Image = If(result.Состояние, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelРаствор_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelРаствор.Click, PictureBoxРаствор.Click
        result.РастворКонтактов = Not result.РастворКонтактов
        PictureBoxРаствор.Image = If(result.РастворКонтактов, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelПровал_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelПровал.Click, PictureBoxПровал.Click
        result.ПровалКонтактов = Not result.ПровалКонтактов
        PictureBoxПровал.Image = If(result.ПровалКонтактов, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelНач_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelНач.Click, PictureBoxНач.Click
        result.НажатиеНач = Not result.НажатиеНач
        PictureBoxНач.Image = If(result.НажатиеНач, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelКон_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelКон.Click, PictureBoxКон.Click
        result.НажатиеКон = Not result.НажатиеКон
        PictureBoxКон.Image = If(result.НажатиеКон, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelR.Click, PictureBoxR.Click
        result.R = Not result.R
        PictureBoxR.Image = If(result.R, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelO.Click, PictureBoxO.Click
        result.O = Not result.O
        PictureBoxO.Image = If(result.O, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelW.Click, PictureBoxW.Click
        result.work = Not result.work
        PictureBoxW.Image = If(result.work, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelI.Click, PictureBoxI.Click
        result.I = Not result.I
        PictureBoxI.Image = If(result.I, My.Resources.Resource._true, My.Resources.Resource._false)
        PictureBoxAll.Image = If(allTrue, My.Resources.Resource._true, My.Resources.Resource._false)
    End Sub

    Private Sub PanelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAll.Click, PictureBoxAll.Click
        If allTrue Then
            If PanelI.Enabled Then
                result.I = False
                PictureBoxI.Image = My.Resources.Resource._false
            End If
            If PanelW.Enabled Then
                result.work = False
                PictureBoxW.Image = My.Resources.Resource._false
            End If
            If PanelO.Enabled Then
                result.O = False
                PictureBoxO.Image = My.Resources.Resource._false
            End If
            If PanelR.Enabled Then
                result.R = False
                PictureBoxR.Image = My.Resources.Resource._false
            End If
            If PanelСостояние.Enabled Then
                result.Состояние = False
                PictureBoxСостояние.Image = My.Resources.Resource._false
            End If
            If PanelРаствор.Enabled Then
                result.РастворКонтактов = False
                PictureBoxРаствор.Image = My.Resources.Resource._false
            End If
            If PanelПровал.Enabled Then
                result.ПровалКонтактов = False
                PictureBoxПровал.Image = My.Resources.Resource._false
            End If
            If PanelНач.Enabled Then
                result.НажатиеНач = False
                PictureBoxНач.Image = My.Resources.Resource._false
            End If
            If PanelКон.Enabled Then
                result.НажатиеКон = False
                PictureBoxКон.Image = My.Resources.Resource._false
            End If
            PictureBoxAll.Image = My.Resources.Resource._false
        Else
            If PanelO.Enabled Then
                result.O = True
                PictureBoxO.Image = My.Resources.Resource._true
            End If
            If PanelI.Enabled Then
                result.I = True
                PictureBoxI.Image = My.Resources.Resource._true
            End If
            If PanelW.Enabled Then
                result.work = True
                PictureBoxW.Image = My.Resources.Resource._true
            End If
            If PanelR.Enabled Then
                result.R = True
                PictureBoxR.Image = My.Resources.Resource._true
            End If
            If PanelСостояние.Enabled Then
                result.Состояние = True
                PictureBoxСостояние.Image = My.Resources.Resource._true
            End If
            If PanelРаствор.Enabled Then
                result.РастворКонтактов = True
                PictureBoxРаствор.Image = My.Resources.Resource._true
            End If
            If PanelПровал.Enabled Then
                result.ПровалКонтактов = True
                PictureBoxПровал.Image = My.Resources.Resource._true
            End If
            If PanelНач.Enabled Then
                result.НажатиеНач = True
                PictureBoxНач.Image = My.Resources.Resource._true
            End If
            If PanelКон.Enabled Then
                result.НажатиеКон = True
                PictureBoxКон.Image = My.Resources.Resource._true
            End If
            PictureBoxAll.Image = My.Resources.Resource._true
        End If
    End Sub
End Class