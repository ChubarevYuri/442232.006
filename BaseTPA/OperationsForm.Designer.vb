<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class OperationsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperationsForm))
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.PictureBoxOk = New System.Windows.Forms.PictureBox
        Me.PictureBoxCancel = New System.Windows.Forms.PictureBox
        Me.LabelHead = New System.Windows.Forms.Label
        Me.PanelAll = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBoxAll = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel24 = New System.Windows.Forms.Panel
        Me.PanelR = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBoxR = New System.Windows.Forms.PictureBox
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.PanelКон = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBoxКон = New System.Windows.Forms.PictureBox
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.PanelНач = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBoxНач = New System.Windows.Forms.PictureBox
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.PanelПровал = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBoxПровал = New System.Windows.Forms.PictureBox
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.PanelРаствор = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBoxРаствор = New System.Windows.Forms.PictureBox
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.PanelСостояние = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBoxСостояние = New System.Windows.Forms.PictureBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PanelO = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBoxO = New System.Windows.Forms.PictureBox
        Me.Panel20 = New System.Windows.Forms.Panel
        Me.PanelW = New System.Windows.Forms.Panel
        Me.PictureBoxW = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel22 = New System.Windows.Forms.Panel
        Me.PanelI = New System.Windows.Forms.Panel
        Me.PictureBoxI = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.PanelHead.SuspendLayout()
        Me.PanelAll.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.PanelR.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.PanelКон.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.PanelНач.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.PanelПровал.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.PanelРаствор.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.PanelСостояние.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanelO.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.PanelW.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.PanelI.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHead
        '
        Me.PanelHead.BackColor = System.Drawing.Color.Black
        Me.PanelHead.Controls.Add(Me.PictureBoxOk)
        Me.PanelHead.Controls.Add(Me.PictureBoxCancel)
        Me.PanelHead.Controls.Add(Me.LabelHead)
        Me.PanelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelHead.Name = "PanelHead"
        Me.PanelHead.Size = New System.Drawing.Size(798, 80)
        '
        'PictureBoxOk
        '
        Me.PictureBoxOk.BackColor = System.Drawing.Color.Black
        Me.PictureBoxOk.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBoxOk.Image = CType(resources.GetObject("PictureBoxOk.Image"), System.Drawing.Image)
        Me.PictureBoxOk.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxOk.Name = "PictureBoxOk"
        Me.PictureBoxOk.Size = New System.Drawing.Size(80, 80)
        Me.PictureBoxOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PictureBoxCancel
        '
        Me.PictureBoxCancel.BackColor = System.Drawing.Color.Black
        Me.PictureBoxCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxCancel.Location = New System.Drawing.Point(718, 0)
        Me.PictureBoxCancel.Name = "PictureBoxCancel"
        Me.PictureBoxCancel.Size = New System.Drawing.Size(80, 80)
        Me.PictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'LabelHead
        '
        Me.LabelHead.BackColor = System.Drawing.Color.Black
        Me.LabelHead.Font = New System.Drawing.Font("Arial", 23.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHead.ForeColor = System.Drawing.Color.White
        Me.LabelHead.Location = New System.Drawing.Point(80, 20)
        Me.LabelHead.Name = "LabelHead"
        Me.LabelHead.Size = New System.Drawing.Size(640, 40)
        Me.LabelHead.Text = "Выберите контролируемые параметры"
        Me.LabelHead.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelAll
        '
        Me.PanelAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelAll.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelAll.Controls.Add(Me.Label1)
        Me.PanelAll.Controls.Add(Me.PictureBoxAll)
        Me.PanelAll.Location = New System.Drawing.Point(3, 3)
        Me.PanelAll.Name = "PanelAll"
        Me.PanelAll.Size = New System.Drawing.Size(156, 54)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 54)
        Me.Label1.Text = "ВСЕ"
        '
        'PictureBoxAll
        '
        Me.PictureBoxAll.BackColor = System.Drawing.Color.White
        Me.PictureBoxAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxAll.Location = New System.Drawing.Point(92, 0)
        Me.PictureBoxAll.Name = "PictureBoxAll"
        Me.PictureBoxAll.Size = New System.Drawing.Size(64, 54)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PanelAll)
        Me.Panel2.Location = New System.Drawing.Point(9, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(162, 60)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(47, 98)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(706, 342)
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.Panel22)
        Me.Panel3.Controls.Add(Me.Panel24)
        Me.Panel3.Controls.Add(Me.Panel20)
        Me.Panel3.Controls.Add(Me.Panel16)
        Me.Panel3.Controls.Add(Me.Panel14)
        Me.Panel3.Controls.Add(Me.Panel12)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(700, 336)
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.PanelR)
        Me.Panel24.Location = New System.Drawing.Point(133, 72)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(295, 60)
        '
        'PanelR
        '
        Me.PanelR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelR.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelR.Controls.Add(Me.Label2)
        Me.PanelR.Controls.Add(Me.PictureBoxR)
        Me.PanelR.Location = New System.Drawing.Point(3, 3)
        Me.PanelR.Name = "PanelR"
        Me.PanelR.Size = New System.Drawing.Size(289, 54)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(225, 54)
        Me.Label2.Text = "Активное сопротивление"
        '
        'PictureBoxR
        '
        Me.PictureBoxR.BackColor = System.Drawing.Color.White
        Me.PictureBoxR.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxR.Location = New System.Drawing.Point(225, 0)
        Me.PictureBoxR.Name = "PictureBoxR"
        Me.PictureBoxR.Size = New System.Drawing.Size(64, 54)
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.PanelКон)
        Me.Panel16.Location = New System.Drawing.Point(484, 270)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(210, 60)
        '
        'PanelКон
        '
        Me.PanelКон.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelКон.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelКон.Controls.Add(Me.Label9)
        Me.PanelКон.Controls.Add(Me.PictureBoxКон)
        Me.PanelКон.Location = New System.Drawing.Point(3, 3)
        Me.PanelКон.Name = "PanelКон"
        Me.PanelКон.Size = New System.Drawing.Size(204, 54)
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 54)
        Me.Label9.Text = "Усилие наж. (конечное)"
        '
        'PictureBoxКон
        '
        Me.PictureBoxКон.BackColor = System.Drawing.Color.White
        Me.PictureBoxКон.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxКон.Location = New System.Drawing.Point(140, 0)
        Me.PictureBoxКон.Name = "PictureBoxКон"
        Me.PictureBoxКон.Size = New System.Drawing.Size(64, 54)
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.PanelНач)
        Me.Panel14.Location = New System.Drawing.Point(484, 204)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(210, 60)
        '
        'PanelНач
        '
        Me.PanelНач.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelНач.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelНач.Controls.Add(Me.Label8)
        Me.PanelНач.Controls.Add(Me.PictureBoxНач)
        Me.PanelНач.Location = New System.Drawing.Point(3, 3)
        Me.PanelНач.Name = "PanelНач"
        Me.PanelНач.Size = New System.Drawing.Size(204, 54)
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 54)
        Me.Label8.Text = "Усилие наж. (начальное)"
        '
        'PictureBoxНач
        '
        Me.PictureBoxНач.BackColor = System.Drawing.Color.White
        Me.PictureBoxНач.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxНач.Location = New System.Drawing.Point(140, 0)
        Me.PictureBoxНач.Name = "PictureBoxНач"
        Me.PictureBoxНач.Size = New System.Drawing.Size(64, 54)
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.PanelПровал)
        Me.Panel12.Location = New System.Drawing.Point(484, 138)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(210, 60)
        '
        'PanelПровал
        '
        Me.PanelПровал.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelПровал.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelПровал.Controls.Add(Me.Label7)
        Me.PanelПровал.Controls.Add(Me.PictureBoxПровал)
        Me.PanelПровал.Location = New System.Drawing.Point(3, 3)
        Me.PanelПровал.Name = "PanelПровал"
        Me.PanelПровал.Size = New System.Drawing.Size(204, 54)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 54)
        Me.Label7.Text = "Провал"
        '
        'PictureBoxПровал
        '
        Me.PictureBoxПровал.BackColor = System.Drawing.Color.White
        Me.PictureBoxПровал.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxПровал.Location = New System.Drawing.Point(140, 0)
        Me.PictureBoxПровал.Name = "PictureBoxПровал"
        Me.PictureBoxПровал.Size = New System.Drawing.Size(64, 54)
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.PanelРаствор)
        Me.Panel10.Location = New System.Drawing.Point(484, 72)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(210, 60)
        '
        'PanelРаствор
        '
        Me.PanelРаствор.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelРаствор.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelРаствор.Controls.Add(Me.Label6)
        Me.PanelРаствор.Controls.Add(Me.PictureBoxРаствор)
        Me.PanelРаствор.Location = New System.Drawing.Point(3, 3)
        Me.PanelРаствор.Name = "PanelРаствор"
        Me.PanelРаствор.Size = New System.Drawing.Size(204, 54)
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 54)
        Me.Label6.Text = "Раствор"
        '
        'PictureBoxРаствор
        '
        Me.PictureBoxРаствор.BackColor = System.Drawing.Color.White
        Me.PictureBoxРаствор.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxРаствор.Location = New System.Drawing.Point(140, 0)
        Me.PictureBoxРаствор.Name = "PictureBoxРаствор"
        Me.PictureBoxРаствор.Size = New System.Drawing.Size(64, 54)
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.PanelСостояние)
        Me.Panel8.Location = New System.Drawing.Point(484, 6)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(210, 60)
        '
        'PanelСостояние
        '
        Me.PanelСостояние.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelСостояние.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelСостояние.Controls.Add(Me.Label5)
        Me.PanelСостояние.Controls.Add(Me.PictureBoxСостояние)
        Me.PanelСостояние.Location = New System.Drawing.Point(3, 3)
        Me.PanelСостояние.Name = "PanelСостояние"
        Me.PanelСостояние.Size = New System.Drawing.Size(204, 54)
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 54)
        Me.Label5.Text = "Состояние"
        '
        'PictureBoxСостояние
        '
        Me.PictureBoxСостояние.BackColor = System.Drawing.Color.White
        Me.PictureBoxСостояние.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxСостояние.Location = New System.Drawing.Point(140, 0)
        Me.PictureBoxСостояние.Name = "PictureBoxСостояние"
        Me.PictureBoxСостояние.Size = New System.Drawing.Size(64, 54)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PanelO)
        Me.Panel4.Location = New System.Drawing.Point(133, 270)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(295, 60)
        '
        'PanelO
        '
        Me.PanelO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelO.Controls.Add(Me.Label3)
        Me.PanelO.Controls.Add(Me.PictureBoxO)
        Me.PanelO.Location = New System.Drawing.Point(3, 3)
        Me.PanelO.Name = "PanelO"
        Me.PanelO.Size = New System.Drawing.Size(289, 54)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(225, 54)
        Me.Label3.Text = "Отключение аппарата"
        '
        'PictureBoxO
        '
        Me.PictureBoxO.BackColor = System.Drawing.Color.White
        Me.PictureBoxO.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxO.Location = New System.Drawing.Point(225, 0)
        Me.PictureBoxO.Name = "PictureBoxO"
        Me.PictureBoxO.Size = New System.Drawing.Size(64, 54)
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.PanelW)
        Me.Panel20.Location = New System.Drawing.Point(133, 138)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(295, 60)
        '
        'PanelW
        '
        Me.PanelW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelW.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelW.Controls.Add(Me.Label10)
        Me.PanelW.Controls.Add(Me.PictureBoxW)
        Me.PanelW.Location = New System.Drawing.Point(3, 3)
        Me.PanelW.Name = "PanelW"
        Me.PanelW.Size = New System.Drawing.Size(289, 54)
        '
        'PictureBoxW
        '
        Me.PictureBoxW.BackColor = System.Drawing.Color.White
        Me.PictureBoxW.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxW.Location = New System.Drawing.Point(225, 0)
        Me.PictureBoxW.Name = "PictureBoxW"
        Me.PictureBoxW.Size = New System.Drawing.Size(64, 54)
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(225, 54)
        Me.Label10.Text = "Работоспособность при Umin"
        '
        'Panel22
        '
        Me.Panel22.Controls.Add(Me.PanelI)
        Me.Panel22.Location = New System.Drawing.Point(133, 204)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(295, 60)
        '
        'PanelI
        '
        Me.PanelI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelI.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelI.Controls.Add(Me.Label11)
        Me.PanelI.Controls.Add(Me.PictureBoxI)
        Me.PanelI.Location = New System.Drawing.Point(3, 3)
        Me.PanelI.Name = "PanelI"
        Me.PanelI.Size = New System.Drawing.Size(289, 54)
        '
        'PictureBoxI
        '
        Me.PictureBoxI.BackColor = System.Drawing.Color.White
        Me.PictureBoxI.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxI.Location = New System.Drawing.Point(225, 0)
        Me.PictureBoxI.Name = "PictureBoxI"
        Me.PictureBoxI.Size = New System.Drawing.Size(64, 54)
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(225, 54)
        Me.Label11.Text = "Момент включения аппарата"
        '
        'OperationsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(798, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OperationsForm"
        Me.Text = "OperationsForm"
        Me.PanelHead.ResumeLayout(False)
        Me.PanelAll.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.PanelR.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.PanelКон.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.PanelНач.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.PanelПровал.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.PanelРаствор.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.PanelСостояние.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.PanelO.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.PanelW.ResumeLayout(False)
        Me.Panel22.ResumeLayout(False)
        Me.PanelI.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxOk As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents LabelHead As System.Windows.Forms.Label
    Friend WithEvents PanelAll As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxAll As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PanelO As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxO As System.Windows.Forms.PictureBox
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents PanelКон As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxКон As System.Windows.Forms.PictureBox
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents PanelНач As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxНач As System.Windows.Forms.PictureBox
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents PanelПровал As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxПровал As System.Windows.Forms.PictureBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents PanelРаствор As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxРаствор As System.Windows.Forms.PictureBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents PanelСостояние As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxСостояние As System.Windows.Forms.PictureBox
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents PanelR As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxR As System.Windows.Forms.PictureBox
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents PanelI As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxI As System.Windows.Forms.PictureBox
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents PanelW As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxW As System.Windows.Forms.PictureBox
End Class
