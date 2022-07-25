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
        Me.LabelBothBdy = New System.Windows.Forms.Label
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
        Me.LabelHead = New System.Windows.Forms.Label
        Me.TimerControl = New System.Windows.Forms.Timer
        Me.PanelBoth.SuspendLayout()
        Me.PanelBothHead.SuspendLayout()
        Me.PanelControl.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBoth
        '
        Me.PanelBoth.BackColor = System.Drawing.SystemColors.Desktop
        Me.PanelBoth.Controls.Add(Me.LabelBothBdy)
        Me.PanelBoth.Controls.Add(Me.TimerPanel1)
        Me.PanelBoth.Controls.Add(Me.ButtonBoth)
        Me.PanelBoth.Controls.Add(Me.PanelBothHead)
        Me.PanelBoth.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBoth.Location = New System.Drawing.Point(0, 360)
        Me.PanelBoth.Name = "PanelBoth"
        Me.PanelBoth.Size = New System.Drawing.Size(800, 100)
        '
        'LabelBothBdy
        '
        Me.LabelBothBdy.BackColor = System.Drawing.Color.LightBlue
        Me.LabelBothBdy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBothBdy.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBothBdy.Location = New System.Drawing.Point(0, 25)
        Me.LabelBothBdy.Name = "LabelBothBdy"
        Me.LabelBothBdy.Size = New System.Drawing.Size(650, 50)
        Me.LabelBothBdy.Text = "LabelBothBody"
        '
        'TimerPanel1
        '
        Me.TimerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TimerPanel1.Location = New System.Drawing.Point(0, 75)
        Me.TimerPanel1.Name = "TimerPanel1"
        Me.TimerPanel1.Size = New System.Drawing.Size(650, 25)
        Me.TimerPanel1.TabIndex = 13
        '
        'ButtonBoth
        '
        Me.ButtonBoth.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonBoth.Location = New System.Drawing.Point(650, 25)
        Me.ButtonBoth.Name = "ButtonBoth"
        Me.ButtonBoth.Size = New System.Drawing.Size(150, 75)
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
        Me.PanelBothHead.Size = New System.Drawing.Size(800, 25)
        '
        'LabelBothHead
        '
        Me.LabelBothHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBothHead.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBothHead.ForeColor = System.Drawing.Color.White
        Me.LabelBothHead.Location = New System.Drawing.Point(138, 0)
        Me.LabelBothHead.Name = "LabelBothHead"
        Me.LabelBothHead.Size = New System.Drawing.Size(662, 25)
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
        Me.PanelControl.Size = New System.Drawing.Size(125, 360)
        '
        'ButtonStop
        '
        Me.ButtonStop.Color = System.Drawing.Color.Red
        Me.ButtonStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStop.Location = New System.Drawing.Point(0, 250)
        Me.ButtonStop.MyText = "СТОП"
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(125, 110)
        Me.ButtonStop.TabIndex = 14
        '
        'ButtonService
        '
        Me.ButtonService.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonService.Location = New System.Drawing.Point(0, 175)
        Me.ButtonService.MyText = "Сервис"
        Me.ButtonService.Name = "ButtonService"
        Me.ButtonService.Size = New System.Drawing.Size(125, 75)
        Me.ButtonService.TabIndex = 13
        '
        'ButtonReport
        '
        Me.ButtonReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonReport.Location = New System.Drawing.Point(0, 100)
        Me.ButtonReport.MyText = "Протокол"
        Me.ButtonReport.Name = "ButtonReport"
        Me.ButtonReport.Size = New System.Drawing.Size(125, 75)
        Me.ButtonReport.TabIndex = 12
        '
        'ButtonNew
        '
        Me.ButtonNew.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonNew.Location = New System.Drawing.Point(0, 25)
        Me.ButtonNew.MyText = "Новое"
        Me.ButtonNew.Name = "ButtonNew"
        Me.ButtonNew.Size = New System.Drawing.Size(125, 75)
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
        Me.PanelBody.Controls.Add(Me.LabelHead)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(125, 0)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(675, 360)
        '
        'LabelHead
        '
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(0, 0)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(675, 25)
        Me.LabelHead.Text = "Управление"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TimerControl
        '
        Me.TimerControl.Enabled = True
        Me.TimerControl.Interval = 50
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 460)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBoth As System.Windows.Forms.Panel
    Friend WithEvents PanelControl As System.Windows.Forms.Panel
    Friend WithEvents PanelBothHead As System.Windows.Forms.Panel
    Friend WithEvents LabelBothHead As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelBothBdy As System.Windows.Forms.Label
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

End Class
