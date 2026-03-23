Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Net.NetworkInformation.Ping
Imports System.Net.NetworkInformation
Imports System.Net.Http
Imports System.Net.Mail
Public Class ConfigSms
    Dim hours As Integer
    Dim minutes As Integer
    Dim seconds As Integer
    Dim milliseconds As Integer
    Private Sub TestSms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundCornes(Me)
        TxtGatewayIp.Text = My.Settings.GatewayIp
        TxtGatewayPort.Text = My.Settings.GatewayPort
        TxtGatewayPassword.Text = My.Settings.GatewayPassword

        txtSmsInterval_Hour.Text = My.Settings.SmsInterval_Hour
        txtSmsInterval_Mins.Text = My.Settings.SmsInterval_Mins
        txtSmsInterval_Sec.Text = My.Settings.SmsInterval_sec
        txtSmsInterval_Mil.Text = My.Settings.SmsInterval_milli


        txtGatewayInterval_Hour.Text = My.Settings.GatewayInterval_Hour
        txtGatewyInterval_Mins.Text = My.Settings.GatewayInterval_Mins
        txtGatewayInterval_Sec.Text = My.Settings.GatewayInterval_Sec
        txtGatewayInterval_Milli.Text = My.Settings.GatewayInterval_Milli

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.Settings.GatewayIp = TxtGatewayIp.Text
        My.Settings.GatewayPort = TxtGatewayPort.Text
        My.Settings.GatewayPassword = TxtGatewayPassword.Text

        My.Settings.SmsInterval_Hour = txtSmsInterval_Hour.Text
        My.Settings.SmsInterval_Mins = txtSmsInterval_Mins.Text
        My.Settings.SmsInterval_sec = txtSmsInterval_Sec.Text
        My.Settings.SmsInterval_milli = txtSmsInterval_Mil.Text

        My.Settings.GatewayInterval_Hour = txtGatewayInterval_Hour.Text
        My.Settings.GatewayInterval_Mins = txtGatewyInterval_Mins.Text
        My.Settings.GatewayInterval_Sec = txtGatewayInterval_Sec.Text
        My.Settings.GatewayInterval_Milli = txtGatewayInterval_Milli.Text

        My.Settings.Save()
        MsgBox("Your Gateway configuration has saved!", MsgBoxStyle.Information, MsgBoxResult.Ok)
    End Sub



    Public Function CanPingGateway(ipAddress As String) As Boolean
        Try
            Dim ping As New Ping()
            Dim reply = ping.Send(ipAddress, 1000) ' Timeout = 1 second
            Return reply.Status = IPStatus.Success
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetGatewayIP() As String
        Dim uri As New Uri("http://" & TxtGatewayIp.Text + ":" + TxtGatewayPort.Text)
        Return uri.Host ' e.g., "192.168.1.50"
    End Function

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Hide()
    End Sub
    Private Function IsMobileReachable() As Boolean
        Try
            Dim pinger As New Ping()
            Dim reply = pinger.Send(My.Settings.GatewayIp, 1000)
            Dim success = reply.Status = IPStatus.Success
            ' UpdateConnectionStatus(success)
            Return success
        Catch
            ' UpdateConnectionStatus(False)
            Return False
        End Try
    End Function


    Private Sub btnSend_Click_1(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim gatewayIP = GetGatewayIP()
        Dim isOnline = CanPingGateway(gatewayIP)
        ' UpdatePingStatusIndicator(isOnline)

        If Not isOnline Then
            MessageBox.Show("Not connected")
        Else
            MessageBox.Show("connected")
            Try
                ' Example using Twilio or generic HTTP SMS API
                Dim url As String = "http://" & TxtGatewayIp.Text + ":" + TxtGatewayPort.Text + "/sendsms?phone=" + TxtNum.Text + "&text=" + TxtMessage.Text + "&password=" + "m0b1l3"
                Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                Dim resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)

                Using reader As New StreamReader(resp.GetResponseStream())
                    Dim responseText As String = reader.ReadToEnd()
                    ' Optionally parse and verify success
                End Using

            Catch ex As Exception
                MessageBox.Show("SMS Error: " & ex.Message)
            End Try
        End If
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



    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Dim result As DialogResult = MessageBox.Show("are you want to reset the SMS Configuration connection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            My.Settings.GatewayIp = ""
            My.Settings.GatewayPort = ""
            My.Settings.GatewayPassword = ""

            My.Settings.SmsInterval_Hour = ""
            My.Settings.SmsInterval_Mins = ""
            My.Settings.SmsInterval_sec = ""
            My.Settings.SmsInterval_milli = ""

            My.Settings.GatewayInterval_Hour = ""
            My.Settings.GatewayInterval_Mins = ""
            My.Settings.GatewayInterval_Sec = ""
            My.Settings.GatewayInterval_Milli = ""

            TxtGatewayIp.Text = ""
            TxtGatewayPort.Text = ""
            TxtGatewayPassword.Text = ""

            txtSmsInterval_Hour.Text = ""
            txtSmsInterval_Mins.Text = ""
            txtSmsInterval_Sec.Text = ""
            txtSmsInterval_Mil.Text = ""

            txtGatewayInterval_Hour.Text = ""
            txtGatewyInterval_Mins.Text = ""
            txtGatewayInterval_Sec.Text = ""
            txtGatewayInterval_Milli.Text = ""

            My.Settings.Save()
        End If
    End Sub

    Private Sub txtSmsInterval_Hour_TextChanged(sender As Object, e As EventArgs) Handles txtSmsInterval_Hour.TextChanged
        Recalculate_SMS_Milliseconds()

    End Sub
    Private Sub txtSmsInterval_Mins_TextChanged(sender As Object, e As EventArgs) Handles txtSmsInterval_Mins.TextChanged
        Recalculate_SMS_Milliseconds()
    End Sub

    ' Event handler for when the text changes in txtSmsInterval_Sec
    Private Sub txtSmsInterval_Sec_TextChanged(sender As Object, e As EventArgs) Handles txtSmsInterval_Sec.TextChanged
        Recalculate_SMS_Milliseconds()
    End Sub

    ' Method to recalculate the SMS milliseconds
    Private Sub Recalculate_SMS_Milliseconds()
        Dim hours As Integer = 0
        Dim minutes As Integer = 0
        Dim seconds As Integer = 0
        Dim Sms_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(txtSmsInterval_Hour.Text) Then
            If Integer.TryParse(txtSmsInterval_Hour.Text, hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(txtSmsInterval_Mins.Text) Then
            If Integer.TryParse(txtSmsInterval_Mins.Text, minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(txtSmsInterval_Sec.Text) Then
            If Integer.TryParse(txtSmsInterval_Sec.Text, seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If

        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(txtSmsInterval_Hour.Text) AndAlso
           String.IsNullOrEmpty(txtSmsInterval_Mins.Text) AndAlso
           String.IsNullOrEmpty(txtSmsInterval_Sec.Text) Then
            txtSmsInterval_Mil.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Sms_milliseconds = (hours * 3600000) + (minutes * 60000) + (seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        txtSmsInterval_Mil.Text = Sms_milliseconds.ToString()
    End Sub


    ' Method to recalculate the Gateway milliseconds
    Private Sub Recalculate_GAteway_Milliseconds()
        Dim hours As Integer = 0
        Dim minutes As Integer = 0
        Dim seconds As Integer = 0
        Dim Gateway_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(txtGatewayInterval_Hour.Text) Then
            If Integer.TryParse(txtGatewayInterval_Hour.Text, hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(txtGatewyInterval_Mins.Text) Then
            If Integer.TryParse(txtGatewyInterval_Mins.Text, minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(txtGatewayInterval_Sec.Text) Then
            If Integer.TryParse(txtGatewayInterval_Sec.Text, seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If


        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(txtGatewayInterval_Hour.Text) AndAlso
           String.IsNullOrEmpty(txtGatewyInterval_Mins.Text) AndAlso
           String.IsNullOrEmpty(txtGatewayInterval_Sec.Text) Then
            txtSmsInterval_Mil.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Gateway_milliseconds = (hours * 3600000) + (minutes * 60000) + (seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        txtGatewayInterval_Milli.Text = Gateway_milliseconds.ToString()
    End Sub

    Private Sub txtGatewayInterval_Hour_TextChanged(sender As Object, e As EventArgs) Handles txtGatewayInterval_Hour.TextChanged
        Recalculate_GAteway_Milliseconds()
    End Sub

    Private Sub txtGatewyInterval_Mins_TextChanged(sender As Object, e As EventArgs) Handles txtGatewyInterval_Mins.TextChanged
        Recalculate_GAteway_Milliseconds()
    End Sub

    Private Sub txtGatewayInterval_Sec_TextChanged(sender As Object, e As EventArgs) Handles txtGatewayInterval_Sec.TextChanged
        Recalculate_GAteway_Milliseconds()
    End Sub

End Class