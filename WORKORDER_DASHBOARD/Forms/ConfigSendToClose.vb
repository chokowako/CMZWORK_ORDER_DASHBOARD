Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Net.NetworkInformation.Ping
Imports System.Net.NetworkInformation
Imports System.Net.Http
Imports System.Net.Mail
Public Class ConfigSendToClose
    'Dim hours As Integer
    'Dim minutes As Integer
    'Dim seconds As Integer
    'Dim milliseconds As Integer
    Private Sub ConfigSendToClose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundCornes(Me)

        TxtInsertNotifyToClose_Hours.Text = My.Settings.SmsInterval_Hour
        TxtinsertNotifyToClose_Mins.Text = My.Settings.insertNotifyToClose_Mins
        TxtinsertNotifyToClose_Sec.Text = My.Settings.insertNotifyToClose_Sec
        TxtinsertNotifyToClose_Milli.Text = My.Settings.insertNotifyToClose_Milli

        TxtNotifyToClose_Hours.Text = My.Settings.NotifyToClose_Hours
        TxtNotifyToClose_Mins.Text = My.Settings.NotifyToClose_Mins
        TxtNotifyToClose_Sec.Text = My.Settings.NotifyToClose_Sec
        TxtNotifyToClose_Milli.Text = My.Settings.NotifyToClose_Milli

        TxtNotifyToCloseRecurring_Milli.Text = My.Settings.NotifyToCloseRecurring_Milli
        TxtNotifyToCloseRecurring_Hour.Text = My.Settings.NotifyToCloseRecurring_Hour
        TxtNotifyToCloseRecurring_Sec.Text = My.Settings.NotifyToCloseRecurring_Sec
        TxtNotifyToCloseRecurring_Min.Text = My.Settings.NotifyToCloseRecurring_Min


    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        My.Settings.InsertNotifyToClose_Hours = TxtInsertNotifyToClose_Hours.Text
        My.Settings.insertNotifyToClose_Mins = TxtinsertNotifyToClose_Mins.Text
        My.Settings.insertNotifyToClose_Sec = TxtinsertNotifyToClose_Sec.Text
        My.Settings.insertNotifyToClose_Milli = TxtinsertNotifyToClose_Milli.Text

        My.Settings.NotifyToClose_Hours = TxtNotifyToClose_Hours.Text
        My.Settings.NotifyToClose_Mins = TxtNotifyToClose_Mins.Text
        My.Settings.NotifyToClose_Sec = TxtNotifyToClose_Sec.Text
        My.Settings.NotifyToClose_Milli = TxtNotifyToClose_Milli.Text

        My.Settings.NotifyToCloseRecurring_Milli = TxtNotifyToCloseRecurring_Milli.Text
        My.Settings.NotifyToCloseRecurring_Hour = TxtNotifyToCloseRecurring_Hour.Text
        My.Settings.NotifyToCloseRecurring_Sec = TxtNotifyToCloseRecurring_Sec.Text
        My.Settings.NotifyToCloseRecurring_Min = TxtNotifyToCloseRecurring_Min.Text

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

            My.Settings.NotifyToCloseRecurring_Milli = ""
            My.Settings.NotifyToCloseRecurring_Hour = ""
            My.Settings.NotifyToCloseRecurring_Sec = ""
            My.Settings.NotifyToCloseRecurring_Min = ""



            TxtInsertNotifyToClose_Hours.Text = ""
            TxtinsertNotifyToClose_Mins.Text = ""
            TxtinsertNotifyToClose_Sec.Text = ""
            TxtinsertNotifyToClose_Milli.Text = ""

            TxtNotifyToClose_Hours.Text = ""
            TxtNotifyToClose_Mins.Text = ""
            TxtNotifyToClose_Sec.Text = ""
            TxtNotifyToClose_Milli.Text = ""

            TxtNotifyToCloseRecurring_Milli.Text = ""
            TxtNotifyToCloseRecurring_Hour.Text = ""
            TxtNotifyToCloseRecurring_Sec.Text = ""
            TxtNotifyToCloseRecurring_Min.Text = ""

            My.Settings.Save()
        End If
    End Sub


    ' Method to recalculate the SMS milliseconds for Check for Closing / Insert Record
    Private Sub SMS_milliseconds_for_Check_for_Closing_Insert_Record()
        Dim Insert_Record_hours As Integer = 0
        Dim Insert_Record_minutes As Integer = 0
        Dim Insert_Record_seconds As Integer = 0
        Dim Insert_Record_Sms_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(TxtInsertNotifyToClose_Hours.Text) Then
            If Integer.TryParse(TxtInsertNotifyToClose_Hours.Text, Insert_Record_hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(TxtinsertNotifyToClose_Mins.Text) Then
            If Integer.TryParse(TxtinsertNotifyToClose_Mins.Text, Insert_Record_minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(TxtinsertNotifyToClose_Sec.Text) Then
            If Integer.TryParse(TxtinsertNotifyToClose_Sec.Text, Insert_Record_seconds) = False Then
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
        Insert_Record_Sms_milliseconds = (Insert_Record_hours * 3600000) + (Insert_Record_minutes * 60000) + (Insert_Record_seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        TxtinsertNotifyToClose_Milli.Text = Insert_Record_Sms_milliseconds.ToString()
    End Sub


    ' Method to recalculate the sms milliseconds Interval for Sending Sms Notification 
    Private Sub Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
        Dim Sending_Sms_Notification_hours As Integer = 0
        Dim Sending_Sms_Notification_minutes As Integer = 0
        Dim Sending_Sms_Notification_seconds As Integer = 0
        Dim Sending_Sms_Notification_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToClose_Hours.Text) Then
            If Integer.TryParse(TxtNotifyToClose_Hours.Text, Sending_Sms_Notification_hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToClose_Mins.Text) Then
            If Integer.TryParse(TxtNotifyToClose_Mins.Text, Sending_Sms_Notification_minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToClose_Sec.Text) Then
            If Integer.TryParse(TxtNotifyToClose_Sec.Text, Sending_Sms_Notification_seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If


        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(TxtNotifyToClose_Hours.Text) AndAlso
           String.IsNullOrEmpty(TxtNotifyToClose_Mins.Text) AndAlso
           String.IsNullOrEmpty(TxtNotifyToClose_Sec.Text) Then
            TxtNotifyToClose_Milli.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Sending_Sms_Notification_milliseconds = (Sending_Sms_Notification_hours * 3600000) + (Sending_Sms_Notification_minutes * 60000) + (Sending_Sms_Notification_seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        TxtNotifyToClose_Milli.Text = Sending_Sms_Notification_milliseconds.ToString()
    End Sub




    ' Method to recalculate the sms milliseconds Interval for Recurring Notification 
    Private Sub Recalculate_sms_milliseconds_for_Recurring_Notification()
        Dim Recurring_Notification_hours As Integer = 0
        Dim Recurring_Notification_minutes As Integer = 0
        Dim Recurring_Notification_seconds As Integer = 0
        Dim Recurring_Notification_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToCloseRecurring_Hour.Text) Then
            If Integer.TryParse(TxtNotifyToCloseRecurring_Hour.Text, Recurring_Notification_hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToCloseRecurring_Min.Text) Then
            If Integer.TryParse(TxtNotifyToCloseRecurring_Min.Text, Recurring_Notification_minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(TxtNotifyToCloseRecurring_Sec.Text) Then
            If Integer.TryParse(TxtNotifyToCloseRecurring_Sec.Text, Recurring_Notification_seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If


        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(TxtNotifyToCloseRecurring_Hour.Text) AndAlso
           String.IsNullOrEmpty(TxtNotifyToCloseRecurring_Min.Text) AndAlso
           String.IsNullOrEmpty(TxtNotifyToCloseRecurring_Sec.Text) Then
            TxtNotifyToCloseRecurring_Milli.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Recurring_Notification_milliseconds = (Recurring_Notification_hours * 3600000) + (Recurring_Notification_minutes * 60000) + (Recurring_Notification_seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        TxtNotifyToCloseRecurring_Milli.Text = Recurring_Notification_milliseconds.ToString()
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

    Private Sub NotifyToClose_Hours_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToClose_Hours.TextChanged
        Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
    End Sub

    Private Sub TxtNotifyToClose_Mins_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToClose_Mins.TextChanged
        Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
    End Sub

    Private Sub TxtNotifyToClose_Sec_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToClose_Sec.TextChanged
        Recalculate_sms_milliseconds_Interval_for_Sending_Sms_Notification()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Hide()
    End Sub

    Private Sub TxtNotifyToCloseRecurring_Hour_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToCloseRecurring_Hour.TextChanged
        Recalculate_sms_milliseconds_for_Recurring_Notification()
    End Sub

    Private Sub TxtNotifyToCloseRecurring_Min_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToCloseRecurring_Min.TextChanged
        Recalculate_sms_milliseconds_for_Recurring_Notification()
    End Sub

    Private Sub TxtNotifyToCloseRecurring_Sec_TextChanged(sender As Object, e As EventArgs) Handles TxtNotifyToCloseRecurring_Sec.TextChanged
        Recalculate_sms_milliseconds_for_Recurring_Notification()
    End Sub
End Class