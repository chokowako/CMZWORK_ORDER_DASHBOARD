Public Class SetupAndOption
    Private Sub BtnDatabase_Click(sender As Object, e As EventArgs) Handles BtnDatabase.Click
        changeDatabaseCommection.ShowDialog()

    End Sub
    Private Sub BtnSms_Click(sender As Object, e As EventArgs) Handles BtnSms.Click
        ConfigSms.ShowDialog()

    End Sub

    Private Sub BtnGateway_Click(sender As Object, e As EventArgs) Handles BtnGateway.Click
        ConfigSmtp.ShowDialog()

    End Sub

    Private Sub BtnRecurringToClose_Click(sender As Object, e As EventArgs) Handles BtnRecurringToClose.Click
        ConfigSendToClose.Show()

    End Sub
End Class