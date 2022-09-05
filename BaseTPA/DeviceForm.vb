Public Class DeviceForm
    Public resilt As Device
    Public Sub New(ByVal dev As Device)
        resilt = dev
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        LabelModel.Text = dev.Name
        LabelUworkMin.Text = If(dev.Uwork.Min = Double.MinValue, 0, dev.Uwork.Min)
        LabelUworkNom.Text = dev.U
        LabelUworkMax.Text = If(dev.Uwork.Max = Double.MaxValue, 0, dev.Uwork.Max)
        LabelImin.Text = If(dev.Ii.Min = Double.MinValue, 0, dev.Ii.Min)
        LabelImax.Text = If(dev.Ii.Max = Double.MaxValue, 0, dev.Ii.Max)
        LabelUImin.Text = If(dev.Ui.Min = Double.MinValue, 0, dev.Ui.Min)
        LabelUImax.Text = If(dev.Ui.Max = Double.MaxValue, 0, dev.Ui.Max)
        LabelUOmin.Text = If(dev.Uo.Min = Double.MinValue, 0, dev.Uo.Min)
        LabelUOmax.Text = If(dev.Uo.Max = Double.MaxValue, 0, dev.Uo.Max)
        LabelRmin.Text = If(dev.R.Min = Double.MinValue, 0, dev.R.Min)
        LabelRmax.Text = If(dev.R.Max = Double.MaxValue, 0, dev.R.Max)
        LabelACount.Text = dev.KontACount
        LabelAРастворMin.Text = If(dev.РастворКонтактаAMin = Double.MinValue, 0, dev.РастворКонтактаAMin)
        LabelAРастворMax.Text = If(dev.РастворКонтактаAMax = Double.MaxValue, 0, dev.РастворКонтактаAMax)
        LabelAПровалMin.Text = If(dev.ПровалКонтактаAMin = Double.MinValue, 0, dev.ПровалКонтактаAMin)
        LabelAПровалMax.Text = If(dev.ПровалКонтактаAMax = Double.MaxValue, 0, dev.ПровалКонтактаAMax)
        LabelAУсилиеНачMin.Text = If(dev.НажатиеНачAMin = Double.MinValue, 0, dev.НажатиеНачAMin)
        LabelAУсилиеНачMax.Text = If(dev.НажатиеНачAMax = Double.MaxValue, 0, dev.НажатиеНачAMax)
        LabelAУсилиеКонMin.Text = If(dev.НажатиеКонAMin = Double.MinValue, 0, dev.НажатиеКонAMin)
        LabelAУсилиеКонMax.Text = If(dev.НажатиеКонAMax = Double.MaxValue, 0, dev.НажатиеКонAMax)
        LabelBCount.Text = dev.KontBCount
        LabelBРастворMin.Text = If(dev.РастворКонтактаBMin = Double.MinValue, 0, dev.РастворКонтактаBMin)
        LabelBРастворMax.Text = If(dev.РастворКонтактаBMax = Double.MaxValue, 0, dev.РастворКонтактаBMax)
        LabelBПровалMin.Text = If(dev.ПровалКонтактаBMin = Double.MinValue, 0, dev.ПровалКонтактаBMin)
        LabelBПровалMax.Text = If(dev.ПровалКонтактаBMax = Double.MaxValue, 0, dev.ПровалКонтактаBMax)
        LabelBУсилиеНачMin.Text = If(dev.НажатиеНачBMin = Double.MinValue, 0, dev.НажатиеНачBMin)
        LabelBУсилиеНачMax.Text = If(dev.НажатиеНачBMax = Double.MaxValue, 0, dev.НажатиеНачBMax)
        LabelBУсилиеКонMin.Text = If(dev.НажатиеКонBMin = Double.MinValue, 0, dev.НажатиеКонBMin)
        LabelBУсилиеКонMax.Text = If(dev.НажатиеКонBMax = Double.MaxValue, 0, dev.НажатиеКонBMax)
        LabelCCount.Text = dev.KontBCount
        LabelCРастворMin.Text = If(dev.РастворКонтактаCMin = Double.MinValue, 0, dev.РастворКонтактаCMin)
        LabelCРастворMax.Text = If(dev.РастворКонтактаCMax = Double.MaxValue, 0, dev.РастворКонтактаCMax)
        LabelCПровалMin.Text = If(dev.ПровалКонтактаCMin = Double.MinValue, 0, dev.ПровалКонтактаCMin)
        LabelCПровалMax.Text = If(dev.ПровалКонтактаCMax = Double.MaxValue, 0, dev.ПровалКонтактаCMax)
        LabelCУсилиеНачMin.Text = If(dev.НажатиеНачCMin = Double.MinValue, 0, dev.НажатиеНачCMin)
        LabelCУсилиеНачMax.Text = If(dev.НажатиеНачCMax = Double.MaxValue, 0, dev.НажатиеНачCMax)
        LabelCУсилиеКонMin.Text = If(dev.НажатиеКонCMin = Double.MinValue, 0, dev.НажатиеКонCMin)
        LabelCУсилиеКонMax.Text = If(dev.НажатиеКонCMax = Double.MaxValue, 0, dev.НажатиеКонCMax)
        CheckBoxR.Checked = dev.РабочиеПарамерты.R
        CheckBoxI.Checked = dev.РабочиеПарамерты.I
        CheckBoxW.Checked = dev.РабочиеПарамерты.work
        CheckBoxO.Checked = dev.РабочиеПарамерты.O
        CheckBoxСостояние.Checked = dev.РабочиеПарамерты.Состояние
        CheckBoxРаствор.Checked = dev.РабочиеПарамерты.РастворКонтактов
        CheckBoxПровал.Checked = dev.РабочиеПарамерты.ПровалКонтактов
        CheckBoxНач.Checked = dev.РабочиеПарамерты.НажатиеНач
        CheckBoxКон.Checked = dev.РабочиеПарамерты.НажатиеКон
    End Sub

    Private Sub PictureBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub PictureBoxOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOk.Click
        If LabelModel.Text.Length < 1 Then
            TPA.DialogForms.Message("Невозможно создать устройство без названия.", "", TPA.DialogForms.MsgType.warning)
        ElseIf devices.ObjectInFile(LabelModel.Text) And LabelModel.Text <> resilt.Name Then
            TPA.DialogForms.Message("Устройтво уже есть в базе.", "", TPA.DialogForms.MsgType.warning)
        ElseIf CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False And _
               CheckBoxR.Checked = False Then
            TPA.DialogForms.Message("Выберите хотя бы 1 осуществляемую проверку.", "", TPA.DialogForms.MsgType.warning)
        Else
            TPA.DialogForms.WaitFormStart()
            resilt.Name = LabelModel.Text
            Try
                resilt.Uwork.Min = If(Convert.ToDouble(LabelUworkMin.Text) > 0, _
                                      Convert.ToDouble(LabelUworkMin.Text), _
                                      Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] Uwork.Min not write")
            End Try
            Try
                resilt.U = If(Convert.ToDouble(LabelUworkNom.Text) > 0, _
                              Convert.ToDouble(LabelUworkNom.Text), _
                              0)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] U not write")
            End Try
            Try
                resilt.Uwork.Max = If(Convert.ToDouble(LabelUworkMax.Text) > 0, _
                                      Convert.ToDouble(LabelUworkMax.Text), _
                                      Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] Uwork.Max not write")
            End Try
            Try
                resilt.Ii.Min = If(Convert.ToDouble(LabelImin.Text) > 0, _
                                   Convert.ToDouble(LabelImin.Text), _
                                   Double.MinValue)
                resilt.Io.Min = resilt.Ii.Min
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] I.Min not write")
            End Try
            Try
                resilt.Ii.Max = If(Convert.ToDouble(LabelImax.Text) > 0, _
                                   Convert.ToDouble(LabelImax.Text), _
                                   Double.MaxValue)
                resilt.Io.Max = resilt.Ii.Max
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] I.Max not write")
            End Try
            Try
                resilt.Ui.Min = If(Convert.ToDouble(LabelUImin.Text) > 0, _
                                   Convert.ToDouble(LabelUImin.Text), _
                                   Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] Ui.Min not write")
            End Try
            Try
                resilt.Ui.Max = If(Convert.ToDouble(LabelUImax.Text) > 0, _
                                   Convert.ToDouble(LabelUImax.Text), _
                                   If(resilt.Ui.Min = Double.MinValue, _
                                      resilt.Uwork.Min, _
                                      Double.MaxValue))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] Ui.Max not write")
            End Try
            Try
                resilt.Uo.Min = If(Convert.ToDouble(LabelUOmin.Text) > 0, _
                                   Convert.ToDouble(LabelUOmin.Text), _
                                   Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] Uo.Min not write")
            End Try
            Try
                resilt.Uo.Max = If(Convert.ToDouble(LabelUOmax.Text) > 0, _
                                   Convert.ToDouble(LabelUOmax.Text), _
                                   If(resilt.Ui.Min = Double.MinValue, _
                                      resilt.Uwork.Min, _
                                      Double.MaxValue))
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] Uo.Max not write")
            End Try
            Try
                resilt.R.Min = If(Convert.ToDouble(LabelRmin.Text) > 0, _
                                  Convert.ToDouble(LabelRmin.Text), _
                                  Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] R.Min not write")
            End Try
            Try
                resilt.R.Max = If(Convert.ToDouble(LabelRmax.Text) > 0, _
                                  Convert.ToDouble(LabelRmax.Text), _
                                  Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] R.Max not write")
            End Try
            Try
                resilt.KontACount = If(Convert.ToInt32(LabelACount.Text) > 0, _
                                       Convert.ToInt32(LabelACount.Text), _
                                       0)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] KontACount not write")
            End Try
            Try
                resilt.РастворКонтактаAMin = If(Convert.ToDouble(LabelAРастворMin.Text) > 0, _
                                                Convert.ToDouble(LabelAРастворMin.Text), _
                                                Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] РастворКонтактаAMin not write")
            End Try
            Try
                resilt.РастворКонтактаAMax = If(Convert.ToDouble(LabelAРастворMax.Text) > 0, _
                                                Convert.ToDouble(LabelAРастворMax.Text), _
                                                Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] РастворКонтактаAMax not write")
            End Try
            Try
                resilt.ПровалКонтактаAMin = If(Convert.ToDouble(LabelAПровалMin.Text) > 0, _
                                               Convert.ToDouble(LabelAПровалMin.Text), _
                                               Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] ПровалКонтактаAMin not write")
            End Try
            Try
                resilt.ПровалКонтактаAMax = If(Convert.ToDouble(LabelAПровалMax.Text) > 0, _
                                               Convert.ToDouble(LabelAПровалMax.Text), _
                                               Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] ПровалКонтактаAMax not write")
            End Try
            Try
                resilt.НажатиеНачAMin = If(Convert.ToDouble(LabelAУсилиеНачMin.Text) > 0, _
                                           Convert.ToDouble(LabelAУсилиеНачMin.Text), _
                                           Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеНачAMin not write")
            End Try
            Try
                resilt.НажатиеНачAMax = If(Convert.ToDouble(LabelAУсилиеНачMax.Text) > 0, _
                                           Convert.ToDouble(LabelAУсилиеНачMax.Text), _
                                           Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеНачAMax not write")
            End Try
            Try
                resilt.НажатиеКонAMin = If(Convert.ToDouble(LabelAУсилиеКонMin.Text) > 0, _
                                           Convert.ToDouble(LabelAУсилиеКонMin.Text), _
                                           Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеКонAMin not write")
            End Try
            Try
                resilt.НажатиеКонAMax = If(Convert.ToDouble(LabelAУсилиеКонMax.Text) > 0, _
                                           Convert.ToDouble(LabelAУсилиеКонMax.Text), _
                                           Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеКонAMax not write")
            End Try
            Try
                resilt.KontBCount = If(Convert.ToInt32(LabelBCount.Text) > 0, _
                                       Convert.ToInt32(LabelBCount.Text), _
                                       0)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] KontBCount not write")
            End Try
            Try
                resilt.РастворКонтактаBMin = If(Convert.ToDouble(LabelBРастворMin.Text) > 0, _
                                                Convert.ToDouble(LabelBРастворMin.Text), _
                                                Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] РастворКонтактаBMin not write")
            End Try
            Try
                resilt.РастворКонтактаBMax = If(Convert.ToDouble(LabelBРастворMax.Text) > 0, _
                                                Convert.ToDouble(LabelBРастворMax.Text), _
                                                Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] РастворКонтактаBMax not write")
            End Try
            Try
                resilt.ПровалКонтактаBMin = If(Convert.ToDouble(LabelBПровалMin.Text) > 0, _
                                               Convert.ToDouble(LabelBПровалMin.Text), _
                                               Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] ПровалКонтактаBMin not write")
            End Try
            Try
                resilt.ПровалКонтактаBMax = If(Convert.ToDouble(LabelBПровалMax.Text) > 0, _
                                               Convert.ToDouble(LabelBПровалMax.Text), _
                                               Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] ПровалКонтактаBMax not write")
            End Try
            Try
                resilt.НажатиеНачBMin = If(Convert.ToDouble(LabelBУсилиеНачMin.Text) > 0, _
                                           Convert.ToDouble(LabelBУсилиеНачMin.Text), _
                                           Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеНачBMin not write")
            End Try
            Try
                resilt.НажатиеНачBMax = If(Convert.ToDouble(LabelBУсилиеНачMax.Text) > 0, _
                                           Convert.ToDouble(LabelBУсилиеНачMax.Text), _
                                           Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеНачBMax not write")
            End Try
            Try
                resilt.НажатиеКонBMin = If(Convert.ToDouble(LabelBУсилиеКонMin.Text) > 0, _
                                           Convert.ToDouble(LabelBУсилиеКонMin.Text), _
                                           Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеКонBMin not write")
            End Try
            Try
                resilt.НажатиеКонBMax = If(Convert.ToDouble(LabelBУсилиеКонMax.Text) > 0, _
                                           Convert.ToDouble(LabelBУсилиеКонMax.Text), _
                                           Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеКонBMax not write")
            End Try
            Try
                resilt.KontCCount = If(Convert.ToInt32(LabelCCount.Text) > 0, _
                                       Convert.ToInt32(LabelCCount.Text), _
                                       0)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] KontCCount not write")
            End Try
            Try
                resilt.РастворКонтактаCMin = If(Convert.ToDouble(LabelCРастворMin.Text) > 0, _
                                                Convert.ToDouble(LabelCРастворMin.Text), _
                                                Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] РастворКонтактаCMin not write")
            End Try
            Try
                resilt.РастворКонтактаCMax = If(Convert.ToDouble(LabelCРастворMax.Text) > 0, _
                                                Convert.ToDouble(LabelCРастворMax.Text), _
                                                Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] РастворКонтактаCMax not write")
            End Try
            Try
                resilt.ПровалКонтактаCMin = If(Convert.ToDouble(LabelCПровалMin.Text) > 0, _
                                               Convert.ToDouble(LabelCПровалMin.Text), _
                                               Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] ПровалКонтактаCMin not write")
            End Try
            Try
                resilt.ПровалКонтактаCMax = If(Convert.ToDouble(LabelCПровалMax.Text) > 0, _
                                               Convert.ToDouble(LabelCПровалMax.Text), _
                                               Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] ПровалКонтактаCMax not write")
            End Try
            Try
                resilt.НажатиеНачCMin = If(Convert.ToDouble(LabelCУсилиеНачMin.Text) > 0, _
                                           Convert.ToDouble(LabelCУсилиеНачMin.Text), _
                                           Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеНачCMin not write")
            End Try
            Try
                resilt.НажатиеНачCMax = If(Convert.ToDouble(LabelCУсилиеНачMax.Text) > 0, _
                                           Convert.ToDouble(LabelCУсилиеНачMax.Text), _
                                           Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеНачCMax not write")
            End Try
            Try
                resilt.НажатиеКонCMin = If(Convert.ToDouble(LabelCУсилиеКонMin.Text) > 0, _
                                           Convert.ToDouble(LabelCУсилиеКонMin.Text), _
                                           Double.MinValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеКонCMin not write")
            End Try
            Try
                resilt.НажатиеКонCMax = If(Convert.ToDouble(LabelCУсилиеКонMax.Text) > 0, _
                                           Convert.ToDouble(LabelCУсилиеКонMax.Text), _
                                           Double.MaxValue)
            Catch ex As Exception
                TPA.Log.Print(TPA.Rank.WARNING, "[Setting] НажатиеКонCMax not write")
            End Try
            resilt.РабочиеПарамерты.R = CheckBoxR.Checked
            resilt.РабочиеПарамерты.I = CheckBoxI.Checked
            resilt.РабочиеПарамерты.work = CheckBoxW.Checked
            resilt.РабочиеПарамерты.O = CheckBoxO.Checked
            resilt.РабочиеПарамерты.Состояние = CheckBoxСостояние.Checked
            resilt.РабочиеПарамерты.РастворКонтактов = CheckBoxРаствор.Checked
            resilt.РабочиеПарамерты.ПровалКонтактов = CheckBoxПровал.Checked
            resilt.РабочиеПарамерты.НажатиеНач = CheckBoxНач.Checked
            resilt.РабочиеПарамерты.НажатиеКон = CheckBoxКон.Checked

            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub PanelModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelModel.Click
        TPA.Keyboard.Text(LabelModel.Text, "Модель аппарата")
    End Sub

    Private Sub PanelAПровалMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAПровалMax.Click
        TPA.Keyboard.UReal(LabelAПровалMax.Text)
    End Sub

    Private Sub PanelAПровалMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAПровалMin.Click
        TPA.Keyboard.UReal(LabelAПровалMin.Text)
    End Sub

    Private Sub PanelAРастворMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAРастворMax.Click
        TPA.Keyboard.UReal(LabelAРастворMax.Text)
    End Sub

    Private Sub PanelAРастворMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAРастворMin.Click
        TPA.Keyboard.UReal(LabelAРастворMin.Text)
    End Sub

    Private Sub PanelAУсилиеКонMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAУсилиеКонMin.Click
        TPA.Keyboard.UReal(LabelAУсилиеКонMin.Text)
    End Sub

    Private Sub PanelAУсилиеКонMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAУсилиеКонMax.Click
        TPA.Keyboard.UReal(LabelAУсилиеКонMax.Text)
    End Sub

    Private Sub PanelAУсилиеНачMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAУсилиеНачMax.Click
        TPA.Keyboard.UReal(LabelAУсилиеНачMax.Text)
    End Sub

    Private Sub PanelAУсилиеНачMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelAУсилиеНачMin.Click
        TPA.Keyboard.UReal(LabelAУсилиеНачMin.Text)
    End Sub

    Private Sub PanelBПровалMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBПровалMax.Click
        TPA.Keyboard.UReal(LabelBПровалMax.Text)
    End Sub

    Private Sub PanelBПровалMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBПровалMin.Click
        TPA.Keyboard.UReal(LabelBПровалMin.Text)
    End Sub

    Private Sub PanelBРастворMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBРастворMin.Click
        TPA.Keyboard.UReal(LabelBРастворMin.Text)
    End Sub

    Private Sub PanelBРастворMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBРастворMax.Click
        TPA.Keyboard.UReal(LabelBРастворMax.Text)
    End Sub

    Private Sub PanelBУсилиеНачMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBУсилиеНачMax.Click
        TPA.Keyboard.UReal(LabelCУсилиеНачMax.Text)
    End Sub

    Private Sub PanelBУсилиеНачMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBУсилиеНачMin.Click
        TPA.Keyboard.UReal(LabelBУсилиеНачMin.Text)
    End Sub

    Private Sub PanelBУсилиеКонMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBУсилиеКонMin.Click
        TPA.Keyboard.UReal(LabelBУсилиеКонMin.Text)
    End Sub

    Private Sub PanelBУсилиеКонMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBУсилиеКонMax.Click
        TPA.Keyboard.UReal(LabelBУсилиеКонMax.Text)
    End Sub

    Private Sub PanelCПровалMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCПровалMax.Click
        TPA.Keyboard.UReal(LabelCПровалMax.Text)
    End Sub

    Private Sub PanelCПровалMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCПровалMin.Click
        TPA.Keyboard.UReal(LabelCПровалMin.Text)
    End Sub

    Private Sub PanelCРастворMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCРастворMin.Click
        TPA.Keyboard.UReal(LabelCРастворMin.Text)
    End Sub

    Private Sub PanelCРастворMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCРастворMax.Click
        TPA.Keyboard.UReal(LabelCРастворMax.Text)
    End Sub

    Private Sub PanelCУсилиеНачMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCУсилиеНачMax.Click
        TPA.Keyboard.UReal(LabelCУсилиеНачMax.Text)
    End Sub

    Private Sub PanelCУсилиеНачMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCУсилиеНачMin.Click
        TPA.Keyboard.UReal(LabelCУсилиеНачMin.Text)
    End Sub

    Private Sub PanelCУсилиеКонMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCУсилиеКонMin.Click
        TPA.Keyboard.UReal(LabelCУсилиеКонMin.Text)
    End Sub

    Private Sub PanelCУсилиеКонMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCУсилиеКонMax.Click
        TPA.Keyboard.UReal(LabelCУсилиеКонMax.Text)
    End Sub

    Private Sub PanelImin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelImin.Click
        TPA.Keyboard.UReal(LabelImin.Text)
    End Sub

    Private Sub PanelRmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelRmin.Click
        TPA.Keyboard.UReal(LabelRmin.Text)
    End Sub

    Private Sub PanelUOmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUOmin.Click
        TPA.Keyboard.UReal(LabelUOmin.Text)
    End Sub

    Private Sub PanelUImin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUImin.Click
        TPA.Keyboard.UReal(LabelUImin.Text)
    End Sub

    Private Sub PanelImax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelImax.Click
        TPA.Keyboard.UReal(LabelImax.Text)
    End Sub

    Private Sub PanelRmax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelRmax.Click
        TPA.Keyboard.UReal(LabelRmax.Text)
    End Sub

    Private Sub PanelUOmax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUOmax.Click
        TPA.Keyboard.UReal(LabelUOmax.Text)
    End Sub

    Private Sub PanelUImax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUImax.Click
        TPA.Keyboard.UReal(LabelUImax.Text)
    End Sub

    Private Sub PanelUworkMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUworkMin.Click
        TPA.Keyboard.UReal(LabelUworkMin.Text)
    End Sub

    Private Sub PanelUworkMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUworkMax.Click
        TPA.Keyboard.UReal(LabelUworkMax.Text)
    End Sub

    Private Sub PanelUworkNom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelUworkNom.Click
        TPA.Keyboard.UReal(LabelUworkNom.Text)
    End Sub

    Private Sub PanelCCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelCCount.Click
        TPA.Keyboard.UInt(LabelCCount.Text)
    End Sub

    Private Sub PanelBCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBCount.Click
        TPA.Keyboard.UInt(LabelBCount.Text)
    End Sub

    Private Sub PanelACount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelACount.Click
        TPA.Keyboard.UInt(LabelACount.Text)
    End Sub
End Class