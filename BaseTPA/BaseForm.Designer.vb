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
        Me.TimerPanel1 = New TPA.TimerPanel
        Me.ButtonBoth = New TPA.ButtonNew
        Me.PanelBothHead = New System.Windows.Forms.Panel
        Me.LabelBothHead = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelControl = New System.Windows.Forms.Panel
        Me.ButtonStop = New TPA.ButtonNew
        Me.ButtonService = New TPA.ButtonNew
        Me.ButtonReport = New TPA.ButtonNew
        Me.ButtonNew = New TPA.ButtonNew
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelBody = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelButtons = New System.Windows.Forms.Panel
        Me.ButtonUdown = New TPA.ButtonNew
        Me.ButtonUup = New TPA.ButtonNew
        Me.ButtonImax10A = New TPA.ButtonNew
        Me.ButtonImax1A = New TPA.ButtonNew
        Me.ButtonR = New TPA.ButtonNew
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DeviceValueR = New TPA.DeviceValue
        Me.DeviceValueI = New TPA.DeviceValue
        Me.DeviceValueU = New TPA.DeviceValue
        Me.LabelHead = New System.Windows.Forms.Label
        Me.TimerControl = New System.Windows.Forms.Timer
        Me.LabelUnom = New System.Windows.Forms.Label
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
        Me.PanelBoth.Location = New System.Drawing.Point(0, 310)
        Me.PanelBoth.Name = "PanelBoth"
        Me.PanelBoth.Size = New System.Drawing.Size(798, 150)
        '
        'LabelBothBody
        '
        Me.LabelBothBody.BackColor = System.Drawing.Color.LightBlue
        Me.LabelBothBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBothBody.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBothBody.Location = New System.Drawing.Point(0, 25)
        Me.LabelBothBody.Name = "LabelBothBody"
        Me.LabelBothBody.Size = New System.Drawing.Size(598, 100)
        Me.LabelBothBody.Text = "LabelBothBody"
        '
        'TimerPanel1
        '
        Me.TimerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TimerPanel1.Location = New System.Drawing.Point(0, 125)
        Me.TimerPanel1.Name = "TimerPanel1"
        Me.TimerPanel1.Size = New System.Drawing.Size(598, 25)
        Me.TimerPanel1.TabIndex = 13
        Me.TimerPanel1.Visible = False
        '
        'ButtonBoth
        '
        Me.ButtonBoth.Color = System.Drawing.Color.LimeGreen
        Me.ButtonBoth.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonBoth.Location = New System.Drawing.Point(598, 25)
        Me.ButtonBoth.MyText = "Старт"
        Me.ButtonBoth.Name = "ButtonBoth"
        Me.ButtonBoth.Size = New System.Drawing.Size(200, 125)
        Me.ButtonBoth.TabIndex = 10
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
        Me.PanelControl.Size = New System.Drawing.Size(125, 310)
        '
        'ButtonStop
        '
        Me.ButtonStop.Color = System.Drawing.Color.Red
        Me.ButtonStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStop.Location = New System.Drawing.Point(0, 235)
        Me.ButtonStop.MyText = "СТОП"
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(125, 75)
        Me.ButtonStop.TabIndex = 14
        '
        'ButtonService
        '
        Me.ButtonService.Color = System.Drawing.Color.Gainsboro
        Me.ButtonService.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonService.Location = New System.Drawing.Point(0, 165)
        Me.ButtonService.MyText = "Сервис"
        Me.ButtonService.Name = "ButtonService"
        Me.ButtonService.Size = New System.Drawing.Size(125, 70)
        Me.ButtonService.TabIndex = 13
        '
        'ButtonReport
        '
        Me.ButtonReport.Color = System.Drawing.Color.Gainsboro
        Me.ButtonReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonReport.Location = New System.Drawing.Point(0, 95)
        Me.ButtonReport.MyText = "Протокол"
        Me.ButtonReport.Name = "ButtonReport"
        Me.ButtonReport.Size = New System.Drawing.Size(125, 70)
        Me.ButtonReport.TabIndex = 12
        '
        'ButtonNew
        '
        Me.ButtonNew.Color = System.Drawing.Color.Gainsboro
        Me.ButtonNew.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonNew.Location = New System.Drawing.Point(0, 25)
        Me.ButtonNew.MyText = "Новое"
        Me.ButtonNew.Name = "ButtonNew"
        Me.ButtonNew.Size = New System.Drawing.Size(125, 70)
        Me.ButtonNew.TabIndex = 11
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
        Me.PanelBody.Controls.Add(Me.LabelUnom)
        Me.PanelBody.Controls.Add(Me.Panel1)
        Me.PanelBody.Controls.Add(Me.PanelButtons)
        Me.PanelBody.Controls.Add(Me.DeviceValueR)
        Me.PanelBody.Controls.Add(Me.DeviceValueI)
        Me.PanelBody.Controls.Add(Me.DeviceValueU)
        Me.PanelBody.Controls.Add(Me.LabelHead)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(125, 0)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(673, 310)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2, 165)
        '
        'PanelButtons
        '
        Me.PanelButtons.BackColor = System.Drawing.SystemColors.ControlText
        Me.PanelButtons.Controls.Add(Me.ButtonUdown)
        Me.PanelButtons.Controls.Add(Me.ButtonUup)
        Me.PanelButtons.Controls.Add(Me.ButtonImax10A)
        Me.PanelButtons.Controls.Add(Me.ButtonImax1A)
        Me.PanelButtons.Controls.Add(Me.ButtonR)
        Me.PanelButtons.Controls.Add(Me.Label5)
        Me.PanelButtons.Controls.Add(Me.Label4)
        Me.PanelButtons.Controls.Add(Me.Label3)
        Me.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelButtons.Location = New System.Drawing.Point(0, 190)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(673, 120)
        '
        'ButtonUdown
        '
        Me.ButtonUdown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUdown.Color = System.Drawing.Color.Gainsboro
        Me.ButtonUdown.FontSize = 36.0!
        Me.ButtonUdown.Location = New System.Drawing.Point(135, 25)
        Me.ButtonUdown.MyText = "▼"
        Me.ButtonUdown.Name = "ButtonUdown"
        Me.ButtonUdown.Size = New System.Drawing.Size(131, 95)
        Me.ButtonUdown.TabIndex = 32
        '
        'ButtonUup
        '
        Me.ButtonUup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUup.Color = System.Drawing.Color.Gainsboro
        Me.ButtonUup.FontSize = 32.0!
        Me.ButtonUup.Location = New System.Drawing.Point(1, 25)
        Me.ButtonUup.MyText = "▲"
        Me.ButtonUup.Name = "ButtonUup"
        Me.ButtonUup.Size = New System.Drawing.Size(131, 95)
        Me.ButtonUup.TabIndex = 31
        '
        'ButtonImax10A
        '
        Me.ButtonImax10A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonImax10A.Color = System.Drawing.Color.Gainsboro
        Me.ButtonImax10A.FontSize = 16.0!
        Me.ButtonImax10A.Location = New System.Drawing.Point(406, 25)
        Me.ButtonImax10A.MyText = "10 A"
        Me.ButtonImax10A.Name = "ButtonImax10A"
        Me.ButtonImax10A.Size = New System.Drawing.Size(131, 95)
        Me.ButtonImax10A.TabIndex = 30
        '
        'ButtonImax1A
        '
        Me.ButtonImax1A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonImax1A.Color = System.Drawing.Color.Gainsboro
        Me.ButtonImax1A.FontSize = 16.0!
        Me.ButtonImax1A.Location = New System.Drawing.Point(272, 25)
        Me.ButtonImax1A.MyText = "1 А"
        Me.ButtonImax1A.Name = "ButtonImax1A"
        Me.ButtonImax1A.Size = New System.Drawing.Size(131, 95)
        Me.ButtonImax1A.TabIndex = 29
        '
        'ButtonR
        '
        Me.ButtonR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonR.Color = System.Drawing.Color.Gainsboro
        Me.ButtonR.FontSize = 16.0!
        Me.ButtonR.Location = New System.Drawing.Point(543, 25)
        Me.ButtonR.MyText = "Выполнить"
        Me.ButtonR.Name = "ButtonR"
        Me.ButtonR.Size = New System.Drawing.Size(130, 95)
        Me.ButtonR.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(272, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 25)
        Me.Label5.Text = "Предел измерения"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(543, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 25)
        Me.Label4.Text = "Замер Rа"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(265, 25)
        Me.Label3.Text = "Регулировка напряжения"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DeviceValueR
        '
        Me.DeviceValueR.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.DeviceValueR.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueR.FontSize = 32.0!
        Me.DeviceValueR.Head = "R, Ом:"
        Me.DeviceValueR.Location = New System.Drawing.Point(488, 63)
        Me.DeviceValueR.Measure = ""
        Me.DeviceValueR.Name = "DeviceValueR"
        Me.DeviceValueR.Size = New System.Drawing.Size(155, 145)
        Me.DeviceValueR.TabIndex = 4
        Me.DeviceValueR.Value = "8888,8"
        '
        'DeviceValueI
        '
        Me.DeviceValueI.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.DeviceValueI.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueI.FontSize = 32.0!
        Me.DeviceValueI.Head = "I, A:"
        Me.DeviceValueI.Location = New System.Drawing.Point(259, 63)
        Me.DeviceValueI.Measure = ""
        Me.DeviceValueI.Name = "DeviceValueI"
        Me.DeviceValueI.Size = New System.Drawing.Size(155, 145)
        Me.DeviceValueI.TabIndex = 3
        Me.DeviceValueI.Value = "24,1"
        '
        'DeviceValueU
        '
        Me.DeviceValueU.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.DeviceValueU.FontColor = System.Drawing.SystemColors.ControlText
        Me.DeviceValueU.FontSize = 32.0!
        Me.DeviceValueU.Head = "    U, B"
        Me.DeviceValueU.Location = New System.Drawing.Point(30, 63)
        Me.DeviceValueU.Measure = ""
        Me.DeviceValueU.Name = "DeviceValueU"
        Me.DeviceValueU.Size = New System.Drawing.Size(155, 145)
        Me.DeviceValueU.TabIndex = 2
        Me.DeviceValueU.Value = "220"
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
        Me.TimerControl.Interval = 250
        '
        'LabelUnom
        '
        Me.LabelUnom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelUnom.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelUnom.Location = New System.Drawing.Point(30, 156)
        Me.LabelUnom.Name = "LabelUnom"
        Me.LabelUnom.Size = New System.Drawing.Size(155, 29)
        Me.LabelUnom.TextAlign = System.Drawing.ContentAlignment.TopRight
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
    Friend WithEvents DeviceValueR As TPA.DeviceValue
    Friend WithEvents DeviceValueI As TPA.DeviceValue
    Friend WithEvents DeviceValueU As TPA.DeviceValue
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents ButtonUdown As TPA.ButtonNew
    Friend WithEvents ButtonUup As TPA.ButtonNew
    Friend WithEvents ButtonImax10A As TPA.ButtonNew
    Friend WithEvents ButtonImax1A As TPA.ButtonNew
    Friend WithEvents ButtonR As TPA.ButtonNew
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TimerPanel1 As TPA.TimerPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelUnom As System.Windows.Forms.Label

End Class
