<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class BaseForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Требуется для конструктора Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора Windows Forms
    'Для ее изменения используйте конструктор Windows Forms.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelBoth = New System.Windows.Forms.Panel
        Me.LabelBothBody = New System.Windows.Forms.Label
        Me.PanelBothHead = New System.Windows.Forms.Panel
        Me.LabelBothHead = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelControl = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelBody = New System.Windows.Forms.Panel
        Me.PanelButtons = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LabelHead = New System.Windows.Forms.Label
        Me.TimerControl = New System.Windows.Forms.Timer
        Me.ButtonSaveR = New TPA.ButtonNew
        Me.ButtonSaveO = New TPA.ButtonNew
        Me.ButtonSaveI = New TPA.ButtonNew
        Me.ButtonUdown = New TPA.ButtonNew
        Me.ButtonUup = New TPA.ButtonNew
        Me.ButtonImax10A = New TPA.ButtonNew
        Me.ButtonImax1A = New TPA.ButtonNew
        Me.ButtonR = New TPA.ButtonNew
        Me.DeviceValueUser = New TPA.DeviceValue
        Me.DeviceValueR = New TPA.DeviceValue
        Me.DeviceValueI = New TPA.DeviceValue
        Me.DeviceValueU = New TPA.DeviceValue
        Me.DeviceValueModel = New TPA.DeviceValue
        Me.ButtonStop = New TPA.ButtonNew
        Me.ButtonService = New TPA.ButtonNew
        Me.ButtonReport = New TPA.ButtonNew
        Me.ButtonNew = New TPA.ButtonNew
        Me.TimerPanel1 = New TPA.TimerPanel
        Me.ButtonBoth = New TPA.ButtonNew
        Me.PanelBoth.SuspendLayout()
        Me.PanelBothHead.SuspendLayout()
        Me.PanelControl.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.PanelButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBoth
        '
        Me.PanelBoth.BackColor = System.Drawing.SystemColors.Desktop
        Me.PanelBoth.Controls.Add(Me.LabelBothBody)
        Me.PanelBoth.Controls.Add(Me.TimerPanel1)
        Me.PanelBoth.Controls.Add(Me.ButtonBoth)
        Me.PanelBoth.Controls.Add(Me.PanelBothHead)
        Me.PanelBoth.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBoth.Location = New System.Drawing.Point(0, 350)
        Me.PanelBoth.Name = "PanelBoth"
        Me.PanelBoth.Size = New System.Drawing.Size(798, 110)
        '
        'LabelBothBody
        '
        Me.LabelBothBody.BackColor = System.Drawing.Color.LightBlue
        Me.LabelBothBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBothBody.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBothBody.Location = New System.Drawing.Point(0, 25)
        Me.LabelBothBody.Name = "LabelBothBody"
        Me.LabelBothBody.Size = New System.Drawing.Size(598, 60)
        Me.LabelBothBody.Text = "LabelBothBody"
        '
        'PanelBothHead
        '
        Me.PanelBothHead.BackColor = System.Drawing.Color.Black
        Me.PanelBothHead.Controls.Add(Me.LabelBothHead)
        Me.PanelBothHead.Controls.Add(Me.Label1)
        Me.PanelBothHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBothHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelBothHead.Name = "PanelBothHead"
        Me.PanelBothHead.Size = New System.Drawing.Size(798, 25)
        '
        'LabelBothHead
        '
        Me.LabelBothHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBothHead.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBothHead.ForeColor = System.Drawing.Color.White
        Me.LabelBothHead.Location = New System.Drawing.Point(138, 0)
        Me.LabelBothHead.Name = "LabelBothHead"
        Me.LabelBothHead.Size = New System.Drawing.Size(660, 25)
        Me.LabelBothHead.Text = "LabelBothHead"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 25)
        Me.Label1.Text = "Информация:"
        '
        'PanelControl
        '
        Me.PanelControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelControl.Controls.Add(Me.ButtonStop)
        Me.PanelControl.Controls.Add(Me.ButtonService)
        Me.PanelControl.Controls.Add(Me.ButtonReport)
        Me.PanelControl.Controls.Add(Me.ButtonNew)
        Me.PanelControl.Controls.Add(Me.Label2)
        Me.PanelControl.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl.Name = "PanelControl"
        Me.PanelControl.Size = New System.Drawing.Size(125, 350)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 25)
        Me.Label2.Text = "Система"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelBody.Controls.Add(Me.PanelButtons)
        Me.PanelBody.Controls.Add(Me.DeviceValueUser)
        Me.PanelBody.Controls.Add(Me.DeviceValueR)
        Me.PanelBody.Controls.Add(Me.DeviceValueI)
        Me.PanelBody.Controls.Add(Me.DeviceValueU)
        Me.PanelBody.Controls.Add(Me.DeviceValueModel)
        Me.PanelBody.Controls.Add(Me.LabelHead)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(125, 0)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(673, 350)
        '
        'PanelButtons
        '
        Me.PanelButtons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButtons.BackColor = System.Drawing.SystemColors.ControlText
        Me.PanelButtons.Controls.Add(Me.ButtonSaveR)
        Me.PanelButtons.Controls.Add(Me.ButtonSaveO)
        Me.PanelButtons.Controls.Add(Me.ButtonSaveI)
        Me.PanelButtons.Controls.Add(Me.Label6)
        Me.PanelButtons.Controls.Add(Me.ButtonUdown)
        Me.PanelButtons.Controls.Add(Me.ButtonUup)
        Me.PanelButtons.Controls.Add(Me.ButtonImax10A)
        Me.PanelButtons.Controls.Add(Me.ButtonImax1A)
        Me.PanelButtons.Controls.Add(Me.ButtonR)
        Me.PanelButtons.Controls.Add(Me.Label5)
        Me.PanelButtons.Controls.Add(Me.Label4)
        Me.PanelButtons.Controls.Add(Me.Label3)
        Me.PanelButtons.Location = New System.Drawing.Point(0, 250)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(673, 100)
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(151, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(225, 25)
        Me.Label6.Text = "Записать знач-я"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(377, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 25)
        Me.Label5.Text = "Предел изм."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(526, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 25)
        Me.Label4.Text = "Реж. замера R"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 25)
        Me.Label3.Text = "Регулировка U"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelHead
        '
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(0, 0)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(673, 25)
        Me.LabelHead.Text = "Показания"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TimerControl
        '
        Me.TimerControl.Enabled = True
        '
        'ButtonSaveR
        '
        Me.ButtonSaveR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSaveR.Color = System.Drawing.Color.Silver
        Me.ButtonSaveR.Location = New System.Drawing.Point(301, 25)
        Me.ButtonSaveR.MyText = "R"
        Me.ButtonSaveR.Name = "ButtonSaveR"
        Me.ButtonSaveR.Size = New System.Drawing.Size(73, 75)
        Me.ButtonSaveR.TabIndex = 35
        '
        'ButtonSaveO
        '
        Me.ButtonSaveO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSaveO.Color = System.Drawing.Color.Silver
        Me.ButtonSaveO.Location = New System.Drawing.Point(226, 25)
        Me.ButtonSaveO.MyText = "ОТКЛ"
        Me.ButtonSaveO.Name = "ButtonSaveO"
        Me.ButtonSaveO.Size = New System.Drawing.Size(73, 75)
        Me.ButtonSaveO.TabIndex = 34
        '
        'ButtonSaveI
        '
        Me.ButtonSaveI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSaveI.Color = System.Drawing.Color.Silver
        Me.ButtonSaveI.Location = New System.Drawing.Point(151, 25)
        Me.ButtonSaveI.MyText = "ВКЛ"
        Me.ButtonSaveI.Name = "ButtonSaveI"
        Me.ButtonSaveI.Size = New System.Drawing.Size(73, 75)
        Me.ButtonSaveI.TabIndex = 33
        '
        'ButtonUdown
        '
        Me.ButtonUdown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUdown.Color = System.Drawing.Color.Silver
        Me.ButtonUdown.FontSize = 36.0!
        Me.ButtonUdown.Location = New System.Drawing.Point(75, 25)
        Me.ButtonUdown.MyText = "▼"
        Me.ButtonUdown.Name = "ButtonUdown"
        Me.ButtonUdown.Size = New System.Drawing.Size(73, 75)
        Me.ButtonUdown.TabIndex = 32
        '
        'ButtonUup
        '
        Me.ButtonUup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUup.Color = System.Drawing.Color.Silver
        Me.ButtonUup.FontSize = 32.0!
        Me.ButtonUup.Location = New System.Drawing.Point(0, 25)
        Me.ButtonUup.MyText = "▲"
        Me.ButtonUup.Name = "ButtonUup"
        Me.ButtonUup.Size = New System.Drawing.Size(73, 75)
        Me.ButtonUup.TabIndex = 31
        '
        'ButtonImax10A
        '
        Me.ButtonImax10A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonImax10A.Color = System.Drawing.Color.Silver
        Me.ButtonImax10A.FontSize = 16.0!
        Me.ButtonImax10A.Location = New System.Drawing.Point(451, 25)
        Me.ButtonImax10A.MyText = "10A"
        Me.ButtonImax10A.Name = "ButtonImax10A"
        Me.ButtonImax10A.Size = New System.Drawing.Size(72, 75)
        Me.ButtonImax10A.TabIndex = 30
        '
        'ButtonImax1A
        '
        Me.ButtonImax1A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonImax1A.Color = System.Drawing.Color.Silver
        Me.ButtonImax1A.FontSize = 16.0!
        Me.ButtonImax1A.Location = New System.Drawing.Point(377, 25)
        Me.ButtonImax1A.MyText = "1A"
        Me.ButtonImax1A.Name = "ButtonImax1A"
        Me.ButtonImax1A.Size = New System.Drawing.Size(72, 75)
        Me.ButtonImax1A.TabIndex = 29
        '
        'ButtonR
        '
        Me.ButtonR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonR.Color = System.Drawing.Color.Silver
        Me.ButtonR.FontSize = 16.0!
        Me.ButtonR.Location = New System.Drawing.Point(526, 25)
        Me.ButtonR.MyText = "Начать"
        Me.ButtonR.Name = "ButtonR"
        Me.ButtonR.Size = New System.Drawing.Size(147, 75)
        Me.ButtonR.TabIndex = 28
        '
        'DeviceValueUser
        '
        Me.DeviceValueUser.Color = System.Drawing.SystemColors.ControlLight
        Me.DeviceValueUser.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueUser.FontSize = 18.0!
        Me.DeviceValueUser.Head = "Оператор"
        Me.DeviceValueUser.Location = New System.Drawing.Point(353, 25)
        Me.DeviceValueUser.Measure = " "
        Me.DeviceValueUser.Name = "DeviceValueUser"
        Me.DeviceValueUser.Size = New System.Drawing.Size(300, 80)
        Me.DeviceValueUser.TabIndex = 5
        Me.DeviceValueUser.Value = "Фамилия И.О."
        '
        'DeviceValueR
        '
        Me.DeviceValueR.Color = System.Drawing.SystemColors.ControlLight
        Me.DeviceValueR.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueR.FontSize = 32.0!
        Me.DeviceValueR.Head = "R"
        Me.DeviceValueR.Location = New System.Drawing.Point(498, 105)
        Me.DeviceValueR.Measure = "Ом"
        Me.DeviceValueR.Name = "DeviceValueR"
        Me.DeviceValueR.Size = New System.Drawing.Size(155, 145)
        Me.DeviceValueR.TabIndex = 4
        Me.DeviceValueR.Value = "8888,8"
        '
        'DeviceValueI
        '
        Me.DeviceValueI.Color = System.Drawing.SystemColors.ControlLight
        Me.DeviceValueI.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueI.FontSize = 32.0!
        Me.DeviceValueI.Head = "I"
        Me.DeviceValueI.Location = New System.Drawing.Point(259, 105)
        Me.DeviceValueI.Measure = "А"
        Me.DeviceValueI.Name = "DeviceValueI"
        Me.DeviceValueI.Size = New System.Drawing.Size(155, 145)
        Me.DeviceValueI.TabIndex = 3
        Me.DeviceValueI.Value = "24,1"
        '
        'DeviceValueU
        '
        Me.DeviceValueU.Color = System.Drawing.SystemColors.ControlLight
        Me.DeviceValueU.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueU.FontSize = 32.0!
        Me.DeviceValueU.Head = "U"
        Me.DeviceValueU.Location = New System.Drawing.Point(20, 105)
        Me.DeviceValueU.Measure = "В"
        Me.DeviceValueU.Name = "DeviceValueU"
        Me.DeviceValueU.Size = New System.Drawing.Size(155, 145)
        Me.DeviceValueU.TabIndex = 2
        Me.DeviceValueU.Value = "220"
        '
        'DeviceValueModel
        '
        Me.DeviceValueModel.Color = System.Drawing.SystemColors.ControlLight
        Me.DeviceValueModel.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueModel.FontSize = 18.0!
        Me.DeviceValueModel.Head = "Модель"
        Me.DeviceValueModel.Location = New System.Drawing.Point(20, 25)
        Me.DeviceValueModel.Measure = " "
        Me.DeviceValueModel.Name = "DeviceValueModel"
        Me.DeviceValueModel.Size = New System.Drawing.Size(305, 80)
        Me.DeviceValueModel.TabIndex = 1
        Me.DeviceValueModel.Value = "контактор КМ2334-23М4"
        '
        'ButtonStop
        '
        Me.ButtonStop.Color = System.Drawing.Color.Red
        Me.ButtonStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStop.Location = New System.Drawing.Point(0, 250)
        Me.ButtonStop.MyText = "СТОП"
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(125, 100)
        Me.ButtonStop.TabIndex = 14
        '
        'ButtonService
        '
        Me.ButtonService.Color = System.Drawing.Color.Silver
        Me.ButtonService.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonService.Location = New System.Drawing.Point(0, 175)
        Me.ButtonService.MyText = "Сервис"
        Me.ButtonService.Name = "ButtonService"
        Me.ButtonService.Size = New System.Drawing.Size(125, 75)
        Me.ButtonService.TabIndex = 13
        '
        'ButtonReport
        '
        Me.ButtonReport.Color = System.Drawing.Color.Silver
        Me.ButtonReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonReport.Location = New System.Drawing.Point(0, 100)
        Me.ButtonReport.MyText = "Протокол"
        Me.ButtonReport.Name = "ButtonReport"
        Me.ButtonReport.Size = New System.Drawing.Size(125, 75)
        Me.ButtonReport.TabIndex = 12
        '
        'ButtonNew
        '
        Me.ButtonNew.Color = System.Drawing.Color.Silver
        Me.ButtonNew.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonNew.Location = New System.Drawing.Point(0, 25)
        Me.ButtonNew.MyText = "Новое"
        Me.ButtonNew.Name = "ButtonNew"
        Me.ButtonNew.Size = New System.Drawing.Size(125, 75)
        Me.ButtonNew.TabIndex = 11
        '
        'TimerPanel1
        '
        Me.TimerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TimerPanel1.Location = New System.Drawing.Point(0, 85)
        Me.TimerPanel1.Name = "TimerPanel1"
        Me.TimerPanel1.Size = New System.Drawing.Size(598, 25)
        Me.TimerPanel1.TabIndex = 13
        '
        'ButtonBoth
        '
        Me.ButtonBoth.Color = System.Drawing.Color.Silver
        Me.ButtonBoth.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonBoth.Location = New System.Drawing.Point(598, 25)
        Me.ButtonBoth.MyText = "Старт"
        Me.ButtonBoth.Name = "ButtonBoth"
        Me.ButtonBoth.Size = New System.Drawing.Size(200, 85)
        Me.ButtonBoth.TabIndex = 10
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(798, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelControl)
        Me.Controls.Add(Me.PanelBoth)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BaseForm"
        Me.Text = "Устройство"
        Me.PanelBoth.ResumeLayout(False)
        Me.PanelBothHead.ResumeLayout(False)
        Me.PanelControl.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.PanelButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBoth As System.Windows.Forms.Panel
    Friend WithEvents PanelControl As System.Windows.Forms.Panel
    Friend WithEvents PanelBothHead As System.Windows.Forms.Panel
    Friend WithEvents LabelBothHead As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelBothBody As System.Windows.Forms.Label
    Friend WithEvents PanelBody As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents ButtonBoth As TPA.ButtonNew
    Friend WithEvents ButtonStop As TPA.ButtonNew
    Friend WithEvents ButtonService As TPA.ButtonNew
    Friend WithEvents ButtonReport As TPA.ButtonNew
    Friend WithEvents ButtonNew As TPA.ButtonNew
    Friend WithEvents TimerControl As System.Windows.Forms.Timer
    Friend WithEvents TimerPanel1 As TPA.TimerPanel
    Friend WithEvents DeviceValueR As TPA.DeviceValue
    Friend WithEvents DeviceValueI As TPA.DeviceValue
    Friend WithEvents DeviceValueU As TPA.DeviceValue
    Friend WithEvents DeviceValueModel As TPA.DeviceValue
    Friend WithEvents DeviceValueUser As TPA.DeviceValue
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents ButtonSaveR As TPA.ButtonNew
    Friend WithEvents ButtonSaveO As TPA.ButtonNew
    Friend WithEvents ButtonSaveI As TPA.ButtonNew
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonUdown As TPA.ButtonNew
    Friend WithEvents ButtonUup As TPA.ButtonNew
    Friend WithEvents ButtonImax10A As TPA.ButtonNew
    Friend WithEvents ButtonImax1A As TPA.ButtonNew
    Friend WithEvents ButtonR As TPA.ButtonNew
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
