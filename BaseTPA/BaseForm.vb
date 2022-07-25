Public Class BaseForm

    Public firstStart As Boolean = True
    Public newReport As Boolean = True

    Public Sub New()
        TPA.TaskBarHide()
        ' Этот вызов необходим конструктору форм Windows.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        ResetElements()
    End Sub

    Private Sub ButtonReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReport.Click
        Report.Show()
    End Sub

    Private Sub ButtonService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonService.Click
        Servise.Service()
    End Sub

    Private Sub ButtonStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click

    End Sub

    Private Sub ButtonNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNew.Click

    End Sub

    Private Sub ButtonBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBoth.Click

    End Sub

    Private Sub TimerControl_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerControl.Tick
        ResetElements()
    End Sub

    Private Sub ResetElements()

    End Sub

End Class
