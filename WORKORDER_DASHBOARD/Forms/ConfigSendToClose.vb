Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Net.NetworkInformation.Ping
Imports System.Net.NetworkInformation
Imports System.Net.Http
Imports System.Net.Mail\
Public Class ConfigSendToClose
    Dim hours As Integer
    Dim minutes As Integer
    Dim seconds As Integer
    Dim milliseconds As Integer
    Private Sub ConfigSendToClose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundCornes(Me)

        TxtInsertNotifyToClose_Hours.Text = My.Settings.SmsInterval_Hour
        TxtinsertNotifyToClose_Mins.Text = My.Settings.SmsInterval_Mins
        TxtinsertNotifyToClose_Sec.Text = My.Settings.SmsInterval_sec
        TxtinsertNotifyToClose_Milli.Text = My.Settings.SmsInterval_milli

        NotifyToClose_Hours.Text = My.Settings.GatewayInterval_Hour
        TxtNotifyToClose_Mins.Text = My.Settings.GatewayInterval_Mins
        TxtNotifyToClose_Sec.Text = My.Settings.GatewayInterval_Sec
        TxtNotifyToClose_Milli.Text = My.Settings.GatewayInterval_Milli
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click


        My.Settings.SmsInterval_Hour = TxtInsertNotifyToClose_Hours.Text
        My.Settings.SmsInterval_Mins = TxtinsertNotifyToClose_Mins.Text
        My.Settings.SmsInterval_sec = TxtinsertNotifyToClose_Sec.Text
        My.Settings.SmsInterval_milli = TxtinsertNotifyToClose_Milli.Text

        My.Settings.GatewayInterval_Hour = NotifyToClose_Hours.Text
        My.Settings.GatewayInterval_Mins = TxtNotifyToClose_Mins.Text
        My.Settings.GatewayInterval_Sec = TxtNotifyToClose_Sec.Text
        My.Settings.GatewayInterval_Milli = TxtNotifyToClose_Milli.Text

        My.Settings.Save()
        MsgBox("Your Gateway configuration has saved!", MsgBoxStyle.Information, MsgBoxResult.Ok)
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

            My.Settings.InsertNotifyToClose_Hours = ""
            My.Settings.insertNotifyToClose_Mins = ""
            My.Settings.insertNotifyToClose_Sec = ""
            My.Settings.insertNotifyToClose_Milli = ""

            My.Settings.NotifyToClose_Hours = ""
            My.Settings.NotifyToClose_Mins = ""
            My.Settings.NotifyToClose_Sec = ""
            My.Settings.NotifyToClose_Milli = ""



            TxtInsertNotifyToClose_Hours.Text = ""
            TxtinsertNotifyToClose_Mins.Text = ""
            TxtinsertNotifyToClose_Sec.Text = ""
            TxtinsertNotifyToClose_Milli.Text = ""

            NotifyToClose_Hours.Text = ""
            TxtNotifyToClose_Mins.Text = ""
            TxtNotifyToClose_Sec.Text = ""
            TxtNotifyToClose_Milli.Text = ""

            My.Settings.Save()
        End If
    End Sub


    ' Method to recalculate the SMS milliseconds for Check for Closing / Insert Record
    Private Sub SMS_milliseconds_for_Check_for_Closing_Insert_Record()
        Dim hours As Integer = 0
        Dim minutes As Integer = 0
        Dim seconds As Integer = 0
        Dim Sms_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(TxtInsertNotifyToClose_Hours.Text) Then
            If Integer.TryParse(TxtInsertNotifyToClose_Hours.Text, hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(TxtinsertNotifyToClose_Mins.Text) Then
            If Integer.TryParse(TxtinsertNotifyToClose_Mins.Text, minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(TxtinsertNotifyToClose_Sec.Text) Then
            If Integer.TryParse(TxtinsertNotifyToClose_Sec.Text, seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If

        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(TxtInsertNotifyToClose_Hours.Text) AndAlso
           String.IsNullOrEmpty(TxtinsertNotifyToClose_Mins.Text) AndAlso
           String.IsNullOrEmpty(TxtinsertNotifyToClose_Sec.Text) Then
            TxtinsertNotifyToClose_Milli.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Sms_milliseconds = (hours * 3600000) + (minutes * 60000) + (seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        TxtinsertNotifyToClose_Milli.Text = Sms_milliseconds.ToString()
    End Sub


    ' Method to recalculate the sms milliseconds Interval for Sending Sms Notification 
    Private Sub Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
        Dim hours As Integer = 0
        Dim minutes As Integer = 0
        Dim seconds As Integer = 0
        Dim Gateway_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(NotifyToClose_Hours.Text) Then
            If Integer.TryParse(NotifyToClose_Hours.Text, hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToClose_Mins.Text) Then
            If Integer.TryParse(TxtNotifyToClose_Mins.Text, minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToClose_Sec.Text) Then
            If Integer.TryParse(TxtNotifyToClose_Sec.Text, seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If


        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(NotifyToClose_Hours.Text) AndAlso
           String.IsNullOrEmpty(TxtNotifyToClose_Mins.Text) AndAlso
           String.IsNullOrEmpty(TxtNotifyToClose_Sec.Text) Then
            TxtNotifyToClose_Milli.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Gateway_milliseconds = (hours * 3600000) + (minutes * 60000) + (seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        TxtNotifyToClose_Milli.Text = Gateway_milliseconds.ToString()
    End Sub



    Private Sub TxtInsertNotifyToClose_Hours_TextChanged(sender As Object, e As EventArgs) Handles TxtInsertNotifyToClose_Hours.TextChanged
        SMS_milliseconds_for_Check_for_Closing_Insert_Record()
    End Sub

    Private Sub TxtinsertNotifyToClose_Mins_TextChanged(sender As Object, e As EventArgs) Handles TxtinsertNotifyToClose_Mins.TextChanged
        SMS_milliseconds_for_Check_for_Closing_Insert_Record()
    End Sub

    Private Sub TxtinsertNotifyToClose_Sec_TextChanged(sender As Object, e As EventArgs) Handles TxtinsertNotifyToClose_Sec.TextChanged
        SMS_milliseconds_for_Check_for_Closing_Insert_Record()
    End Sub

    Private Sub NotifyToClose_Hours_TextChanged(sender As Object, e As EventArgs) Handles NotifyToClose_Hours.TextChanged
        Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
    End Sub

    Private Sub TxtNotifyToClose_Mins_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToClose_Mins.TextChanged
        Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
    End Sub

    Private Sub TxtNotifyToClose_Sec_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToClose_Sec.TextChanged
        Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
    End Sub
End Class