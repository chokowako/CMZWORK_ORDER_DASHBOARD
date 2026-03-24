Imports System.Net
Imports System.Net.Mail
Public Class ConfigSmtp
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        My.Settings.smtpServer = TxtSmtpServer.Text
        My.Settings.smtpPort = TxtSmtpPort.Text

        If TxtSmtpSender.Text.Contains("@") AndAlso TxtSmtpSender.Text.Contains(".") Then
            My.Settings.smtpEmail = TxtSmtpSender.Text
        Else
            MessageBox.Show("Please enter a valid email address.")
        End If

        My.Settings.smtpName = txtSmtpName.Text
        My.Settings.smtpPass = TxtSmtpPassword.Text

        My.Settings.EmailInterval_Hour = txtEmailInterval_Hour.Text
        My.Settings.EmailInterval_Mins = txtEmailInterval_Mins.Text
        My.Settings.EmailInterval_Sec = txtEmailInterval_Sec.Text
        My.Settings.EmailInterval_Milli = txtEmailInterval_Mili.Text

        My.Settings.Save()
        MsgBox("Your Gateway configuration has saved!", MsgBoxStyle.Information, MsgBoxResult.Ok)
    End Sub
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Dim result As DialogResult = MessageBox.Show("are you want to reset the Smtp Server connection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            My.Settings.smtpServer = ""
            My.Settings.smtpPort = ""
            My.Settings.smtpEmail = ""
            My.Settings.smtpName = "'"
            My.Settings.smtpPass = ""

            My.Settings.EmailInterval_Hour = ""
            My.Settings.EmailInterval_Mins = ""
            My.Settings.EmailInterval_Sec = ""
            My.Settings.EmailInterval_Milli = ""


            TxtSmtpServer.Text = ""
            TxtSmtpPort.Text = ""
            TxtSmtpSender.Text = ""
            txtSmtpName.Text = ""
            TxtSmtpPassword.Text = ""

            txtEmailInterval_Hour.Text = ""
            txtEmailInterval_Mins.Text = ""
            txtEmailInterval_Sec.Text = ""
            txtEmailInterval_Mili.Text = ""

            My.Settings.Save()
        End If
    End Sub
    Private Sub ConfigSmtp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundCornes(Me)
        TxtSmtpServer.Text = My.Settings.smtpServer
        TxtSmtpPort.Text = My.Settings.smtpPort
        TxtSmtpSender.Text = My.Settings.smtpEmail
        txtSmtpName.Text = My.Settings.smtpName
        TxtSmtpPassword.Text = My.Settings.smtpPass


        txtEmailInterval_Hour.Text = My.Settings.EmailInterval_Hour
        txtEmailInterval_Mins.Text = My.Settings.EmailInterval_Mins
        txtEmailInterval_Sec.Text = My.Settings.EmailInterval_Sec
        txtEmailInterval_Mili.Text = My.Settings.EmailInterval_Milli

    End Sub
    Private Sub roundCornes(obj As Form)
        obj.FormBorderStyle = FormBorderStyle.None
        'obj.BackColor = Color.Yellow

        Dim DGP As New Drawing2D.GraphicsPath
        DGP.StartFigure()

        'TOP LEFT CORNER
        DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        DGP.AddLine(40, 0, obj.Width - 40, 0)

        'TOP RIGHT CORNER
        DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)

        'BOTTOM RIGHT CORNER
        DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)

        'BOTTOM LEFT CORNER
        DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        obj.Region = New Region(DGP)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Hide()

    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim smtpServer As String = TxtSmtpServer.Text.Trim()
        Dim smtpPort As Integer
        If Not Integer.TryParse(TxtSmtpPort.Text.Trim(), smtpPort) Then
            MessageBox.Show("Invalid port number.")
            Return
        End If

        Dim senderEmail As String = TxtSmtpSender.Text.Trim()
        Dim senderPassword As String = TxtSmtpPassword.Text
        Dim receiverEmail As String = txtReceiverEmail.Text.Trim()

        Try
            Dim client As New SmtpClient(smtpServer)
            client.Port = smtpPort
            client.Credentials = New NetworkCredential(senderEmail, senderPassword)
            client.EnableSsl = True

            Dim mail As New MailMessage()
            mail.From = New MailAddress(senderEmail)
            mail.To.Add(receiverEmail)
            mail.Subject = "SMTP Test"
            mail.Body = "This is a test email sent from VB.NET."

            client.Send(mail)

            MessageBox.Show("Test email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "SMTP Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmailInterval_Sec_TextChanged(sender As Object, e As EventArgs) Handles txtEmailInterval_Sec.TextChanged
        Recalculate_Smtp_Milliseconds()
    End Sub


    Private Sub Recalculate_Smtp_Milliseconds()
        Dim hours As Integer = 0
        Dim minutes As Integer = 0
        Dim seconds As Integer = 0
        Dim Gateway_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(txtEmailInterval_Hour.Text) Then
            If Integer.TryParse(txtEmailInterval_Hour.Text, hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(txtEmailInterval_Mins.Text) Then
            If Integer.TryParse(txtEmailInterval_Mins.Text, minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(txtEmailInterval_Sec.Text) Then
            If Integer.TryParse(txtEmailInterval_Sec.Text, seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If



        ' Calculate the total milliseconds based on the entered values
        Gateway_milliseconds = (hours * 3600000) + (minutes * 60000) + (seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        txtEmailInterval_Mili.Text = Gateway_milliseconds.ToString()
    End Sub

    Private Sub txtEmailInterval_Mins_TextChanged(sender As Object, e As EventArgs) Handles txtEmailInterval_Mins.TextChanged
        Recalculate_Smtp_Milliseconds()
    End Sub

    Private Sub txtEmailInterval_Hour_TextChanged(sender As Object, e As EventArgs) Handles txtEmailInterval_Hour.TextChanged
        Recalculate_Smtp_Milliseconds()
    End Sub
End Class