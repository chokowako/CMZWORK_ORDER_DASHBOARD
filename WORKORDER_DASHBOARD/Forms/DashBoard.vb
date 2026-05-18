Imports System.Net
Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Net.Http
Imports System.Threading.Tasks

Public Class DashBoard
    Dim smsGatewayUrl As String = "http://" + My.Settings.GatewayIp + ":" + My.Settings.GatewayPort ' Replace with your phone IP/port
    Dim loadingDots As Integer = 0
    Dim myConnection As New SqlConnection(connStr)

    Private isLoadingDashboard As Boolean = False


    Private isSendingWorkOrder As Boolean = False
    Private isInsertingWorkOrder As Boolean = False
    Private isInserting As Boolean = False

    Private ReadOnly httpClient As New HttpClient()
    Private isProcessingSms As Boolean = False
    Private isProcessingEmail As Boolean = False

    Private Sub DateAndTime_Tick(sender As Object, e As EventArgs) Handles DateAndTime.Tick
        lblDateTime.Text = Format(Now, "Long Date") & "," & " " & TimeOfDay.ToString("h:mm:ss tt")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub
    Private Async Sub BtsStart_Click(sender As Object, e As EventArgs) Handles BtsStart.Click
        Try

            If BtsStart.ImageIndex = 0 Then
                BtsStart.ImageIndex = 3



                ' =========================
                ' LOAD DATA ON DASHBOARD
                ' =========================

                TimerWoms.Interval = My.Settings.WomsInterval_Mlli
                Await Load_Dashboard()
                TimerWoms.Start()



                ' =========================
                ' SWITCH TO STOP ICON
                ' =========================
                BtsStart.ImageIndex = 3
                ProgressBar1.Show()


                ' =========================
                ' SMS ENGINE START
                ' =========================
                lblSMSConnectionStatus.Text = "🟡 SMS Engine Starting..."
                lblSMSConnectionStatus.BackColor = Color.Goldenrod

                Await LoadPendingSmsAsync()

                TimerSMS.Interval = My.Settings.SmsInterval_milli
                TimerSMS.Start()

                lblStatus.Text = "SMS Auto Sender Running..."



                ' =========================
                ' EMAIL ENGINE START (NEW)
                ' =========================
                lblSMTPConnectionStatus.Text = "🟡 Email Engine Starting..."
                lblSMTPConnectionStatus.BackColor = Color.Goldenrod

                Await LoadPendingEmailAsync()

                TimerEmail.Interval = My.Settings.EmailInterval_Milli
                TimerEmail.Start()

                lblEmailStatus.Text = "Email Auto Sender Running..."



            ElseIf BtsStart.ImageIndex = 3 Then
                BtsStart.ImageIndex = 0



                ' =========================
                ' STOP LOAD DATA ON DASHBOARD
                ' =========================
                TimerWoms.Start()

                ' =========================
                ' STOP SMS ENGINE
                ' =========================
                TimerSMS.Stop()

                lblSMSConnectionStatus.Text = "🔴 SMS Engine Stopped"
                lblSMSConnectionStatus.BackColor = Color.Red

                lblProgress.Text = ""
                lblStatus.Text = ""

                ' =========================
                ' STOP EMAIL ENGINE (NEW)
                ' =========================
                TimerEmail.Stop()

                lblSMTPConnectionStatus.Text = "🔴 Email Engine Stopped"
                lblSMTPConnectionStatus.BackColor = Color.Red

                lblEmailProgress.Text = ""
                lblEmailStatus.Text = ""

                ProgressBar1.Hide()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ArrangeStatusLabels()

        DateAndTime.Start()

        lblConnection.Text = My.Settings.DBName
        If lblConnection.Text = "CMZWORK_ORDER_Training" Then
            lblConnection.Text = "Training Database"
            lblConnection.ForeColor = Color.Red
        ElseIf lblConnection.Text = "CMZWORK_ORDER" Then
            lblConnection.Text = "Live Database"
            lblConnection.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BtnSetupAndOption_Click(sender As Object, e As EventArgs) Handles BtnSetupAndOption.Click
        SetupAndOption.ShowDialog()
    End Sub

    Private Sub ShowSMSprogressSMS(isVisible As Boolean)
        progressSMS1.Visible = isVisible

        If isVisible Then
            progressSMS1.BringToFront()
        End If

        Application.DoEvents()

    End Sub

    Private Sub ShowEmailProgress(isVisible As Boolean)
        progressEmail1.Visible = isVisible
    End Sub

    ' =========================================================
    ' 1. LOAD DATA TO GRID (KEEP THIS) SMS
    ' =========================================================
    Private Async Function LoadPendingSmsAsync() As Task

        Try

            dgvPendingSMS.DataSource = Nothing
            dgvPendingSMS.Columns.Clear()

            Using conn As New SqlConnection(connStr)

                Await conn.OpenAsync()

                Dim query As String =
            "SELECT pk, Receiver, RecPhoneNo, Message
             FROM SmsCatcher
             WHERE smsflag IN (1,2)
             ORDER BY pk ASC"

                Using cmd As New SqlCommand(query, conn)

                    Using reader = Await cmd.ExecuteReaderAsync()

                        Dim dt As New DataTable()
                        dt.Load(reader)

                        dgvPendingSMS.DataSource = dt

                    End Using

                End Using

            End Using

            With dgvPendingSMS
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .Columns("pk").FillWeight = 10
                .Columns("Receiver").FillWeight = 10
                .Columns("RecPhoneNo").FillWeight = 10
                .Columns("Message").FillWeight = 70
                .Columns("Message").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .ClearSelection()
                .CurrentCell = Nothing
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


    ' =========================================================
    ' 2. MAIN PROCESSOR (THIS IS THE ENGINE)
    ' =========================================================
    Private Async Function ProcessPendingSmsAsync() As Task
        Try

            ShowSMSprogressSMS(True)

            Dim dt As New DataTable()

            Using conn As New SqlConnection(connStr)

                Await conn.OpenAsync()

                Dim query As String =
            "SELECT pk, RecPhoneNo, Message, smsflag
             FROM SmsCatcher
             WHERE smsflag IN (1,2)
             ORDER BY pk ASC"

                Using cmd As New SqlCommand(query, conn)

                    Using reader = Await cmd.ExecuteReaderAsync()
                        dt.Load(reader)
                    End Using

                End Using

            End Using

            If dt.Rows.Count = 0 Then

                lblProgress.Text = "📭 No Pending SMS"
                lblStatus.Text = ""
                Exit Function

            End If

            Dim total As Integer = dt.Rows.Count
            Dim count As Integer = 0

            For Each row As DataRow In dt.Rows

                Dim pk As Integer = Convert.ToInt32(row("pk"))
                Dim phone As String = row("RecPhoneNo").ToString()
                Dim msg As String = row("Message").ToString()
                Dim status As Integer = Convert.ToInt32(row("smsflag"))

                count += 1

                lblProgress.Text = $"{count}/{total}"

                ' =========================
                ' SEND SMS (NO PRE-STATUS TEXT)
                ' =========================
                Dim success As Boolean = Await SendSmsAsync(phone, msg)

                If success Then

                    Await UpdateSmsStatusAsync(pk, 0)
                    lblStatus.Text = $"✅ Sent to {phone}"

                Else

                    Await UpdateSmsStatusAsync(pk, 2)
                    lblStatus.Text = $"❌ Failed {phone}"

                End If

                Await Task.Delay(300)

            Next

            lblProgress.Text = $"✅ Completed {count}/{total}"

        Catch ex As Exception

            lblStatus.Text = ex.Message

        Finally

            ShowSMSprogressSMS(False)

        End Try


        ' AFTER PROCESS ENDS
        Await LoadPendingSmsAsync()


    End Function


    ' =========================================================
    ' 3. SMS SENDER (ONLY THIS DOES HTTP)
    ' =========================================================
    Private Async Function SendSmsAsync(ByVal mobileNo As String,
                                    ByVal message As String) As Task(Of Boolean)
        Try

            Dim baseUrl As String =
        "http://" & My.Settings.GatewayIp & ":" & My.Settings.GatewayPort

            Dim url As String =
        $"{baseUrl}/sendsms?phone={Uri.EscapeDataString(mobileNo)}" &
        $"&text={Uri.EscapeDataString(message)}" &
        $"&password={My.Settings.GatewayPassword}"

            Dim response = Await httpClient.GetAsync(url)

            Return response.IsSuccessStatusCode

        Catch
            Return False
        End Try


    End Function


    ' =========================================================
    ' 4. UPDATE DATABASE STATUS
    ' =========================================================
    Private Async Function UpdateSmsStatusAsync(pk As Integer, status As Integer) As Task

        Using conn As New SqlConnection(connStr)

            Await conn.OpenAsync()

            Dim query As String =
        "UPDATE SmsCatcher
         SET smsflag = @status,
             smsDateSend = @dateSent
         WHERE pk = @pk"

            Using cmd As New SqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@pk", pk)
                cmd.Parameters.AddWithValue("@dateSent", Date.Now)

                Await cmd.ExecuteNonQueryAsync()

            End Using

        End Using

    End Function



    ' =========================================================
    ' 5.CREATE REAL GATEWAY CHECK
    ' =========================================================
    Private Async Function IsGatewayOnlineAsync() As Task(Of Boolean)

        Try

            Dim url As String =
        $"http://{My.Settings.GatewayIp}:{My.Settings.GatewayPort}/sendsms?phone=test&text=test&password={My.Settings.GatewayPassword}"

            Dim response = Await httpClient.GetAsync(url)

            Return response.IsSuccessStatusCode

        Catch
            Return False
        End Try

    End Function



    ' =========================================================
    ' 6.TIMER FOR SMS
    ' =========================================================

    Private Async Sub TimerSMS_Tick(sender As Object, e As EventArgs) Handles TimerSMS.Tick
        If isProcessingSms Then Exit Sub

        isProcessingSms = True
        TimerSMS.Stop()

        Try

            Await LoadPendingSmsAsync()

            Dim gatewayOk As Boolean = Await IsGatewayOnlineAsync()

            If gatewayOk Then

                lblSMSConnectionStatus.Text =
            "🟢 SMS Gateway Online - Processing Queue"

                lblSMSConnectionStatus.BackColor = Color.Green

                Await ProcessPendingSmsAsync()

            Else

                lblSMSConnectionStatus.Text =
            "🔴 SMS Gateway Offline - Waiting Retry"

                lblSMSConnectionStatus.BackColor = Color.Red

            End If

        Catch ex As Exception

            lblSMSConnectionStatus.Text = "🔴 SMS System Error"
            lblSMSConnectionStatus.BackColor = Color.Red
            lblStatus.Text = ex.Message

        Finally

            isProcessingSms = False
            TimerSMS.Start()

        End Try

    End Sub





























    ' =========================================================
    ' INSERT REMINDER RECORDS
    ' =========================================================
    Private Async Function InsertReminderSMSAsync() As Task

        Try

            Using conn As New SqlConnection(connStr)

                Await conn.OpenAsync()

                Dim list As New List(Of (String, String, String, String, String))

                ' ======================================================
                ' STEP 1: BACKJOB REMINDERS
                ' ======================================================
                Dim queryBackJob As String = "
            SELECT 
                w.Pk_WorkOrderNo,
                w.RequestedBy,
                w.RequesterContactNo,
                w.Unit_Section,
                'BACKJOB' AS ReminderType
            FROM WorkOrderForm w
            INNER JOIN BackJobHistory b
                ON w.Pk_WorkOrderNo = b.Pk_WorkOrderNo
            WHERE ISNULL(w.BackJob_Flag,0) = 1
              AND UPPER(LTRIM(RTRIM(ISNULL(w.TagAsClose,'')))) = 'PENDING'
              AND b.ID = (
                    SELECT MAX(b2.ID)
                    FROM BackJobHistory b2
                    WHERE b2.Pk_WorkOrderNo = w.Pk_WorkOrderNo
              )
              AND ISNULL(b.ProceedWO_Flag,0) = 2
            "

                Using cmd As New SqlCommand(queryBackJob, conn)

                    Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()

                        While Await reader.ReadAsync()

                            list.Add((
                            reader("Pk_WorkOrderNo").ToString(),
                            reader("RequestedBy").ToString(),
                            reader("RequesterContactNo").ToString(),
                            reader("Unit_Section").ToString(),
                            "BACKJOB"
                        ))

                        End While

                    End Using

                End Using

                ' ======================================================
                ' STEP 2: NORMAL REMINDERS
                ' ======================================================
                Dim queryNormal As String = "
            SELECT 
                w.Pk_WorkOrderNo,
                w.RequestedBy,
                w.RequesterContactNo,
                w.Unit_Section,
                'NORMAL' AS ReminderType
            FROM WorkOrderForm w
            WHERE ISNULL(w.BackJob_Flag,0) = 0
              AND UPPER(LTRIM(RTRIM(ISNULL(w.TagAsClose,'')))) = 'PENDING'
              AND ISNULL(w.ProceedWO_Flag,0) = 2
            "

                Using cmd As New SqlCommand(queryNormal, conn)

                    Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()

                        While Await reader.ReadAsync()

                            list.Add((
                            reader("Pk_WorkOrderNo").ToString(),
                            reader("RequestedBy").ToString(),
                            reader("RequesterContactNo").ToString(),
                            reader("Unit_Section").ToString(),
                            "NORMAL"
                        ))

                        End While

                    End Using

                End Using

                ' ======================================================
                ' NO RECORDS
                ' ======================================================
                If list.Count = 0 Then Exit Function

                ' ======================================================
                ' STEP 3: INSERT PROCESS
                ' ======================================================
                For Each item In list

                    Dim woNo As String = item.Item1
                    Dim name As String = item.Item2
                    Dim phone As String = item.Item3
                    Dim reminderType As String = item.Item5

                    ' ==================================================
                    ' CHECK DUPLICATE ACTIVE REMINDER
                    ' ==================================================
                    Using checkCmd As New SqlCommand("
                SELECT COUNT(*)
                FROM WorkOrderNotifications
                WHERE WorkOrderNo = @WO
                  AND ReminderType = @Type
                  AND Status = 1
                ", conn)

                        checkCmd.Parameters.AddWithValue("@WO", woNo)
                        checkCmd.Parameters.AddWithValue("@Type", reminderType)

                        Dim exists As Integer =
                        Convert.ToInt32(Await checkCmd.ExecuteScalarAsync())

                        If exists > 0 Then Continue For

                    End Using

                    ' ==================================================
                    ' BUILD MESSAGE
                    ' ==================================================
                    Dim msg As String

                    If reminderType = "BACKJOB" Then

                        msg = "Good Day " & name &
                          ". Back Job is ready for closure. Work Order No: " &
                          woNo &
                          ". Kindly review and close the work order. Thank you."

                    Else

                        msg = "Good Day " & name &
                          ". Please close Work Order No: " &
                          woNo &
                          ". Thank you."

                    End If

                    ' ==================================================
                    ' INSERT REMINDER
                    ' ==================================================
                    Using insertCmd As New SqlCommand("
                INSERT INTO WorkOrderNotifications
                (
                    WorkOrderNo,
                    RecipientName,
                    PhoneNumber,
                    Message,
                    Status,
                    CreatedDate,
                    ReminderType
                )
                VALUES
                (
                    @WO,
                    @Name,
                    @Phone,
                    @Msg,
                    1,
                    @Date,
                    @Type
                )
                ", conn)

                        insertCmd.Parameters.AddWithValue("@WO", woNo)
                        insertCmd.Parameters.AddWithValue("@Name", name)
                        insertCmd.Parameters.AddWithValue("@Phone", phone)
                        insertCmd.Parameters.AddWithValue("@Msg", msg)
                        insertCmd.Parameters.AddWithValue("@Date", DateTime.Now)
                        insertCmd.Parameters.AddWithValue("@Type", reminderType)

                        Await insertCmd.ExecuteNonQueryAsync()

                    End Using

                Next

            End Using

        Catch ex As Exception

            MessageBox.Show("Insert Reminder Error: " & ex.Message)

        End Try
    End Function


    ' =========================================================
    ' CHECKBOX START / STOP
    ' =========================================================
    Private Sub chkAllowToNotify_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllowToNotify.CheckedChanged
        'THIS IS FOR NOTIFICATION

        ' THIS IS FOR NOTIFICATION

        If chkAllowToNotify.Checked Then

            ' ============================================
            ' START INSERT TIMER
            ' ============================================
            TimerReminder_insert.Interval = My.Settings.NotifyToClose_InsertRecord_Milli
            TimerReminder_insert.Start()

            ' ============================================
            ' START SMS SENDING TIMER
            ' ============================================
            Interval_for_Sending_Sms_Notification_Close.Interval = My.Settings.NotifyToCloseRecurring_Milli
            Interval_for_Sending_Sms_Notification_Close.Start()

            chkAllowToNotify.Text = "🟢 Auto Notify: ON"
            chkAllowToNotify.ForeColor = Color.Green

        Else

            ' ============================================
            ' STOP TIMERS
            ' ============================================
            TimerReminder_insert.Stop()
            Interval_for_Sending_Sms_Notification_Close.Stop()

            chkAllowToNotify.Text = "🔴 Auto Notify: OFF"
            chkAllowToNotify.ForeColor = Color.Red

        End If
    End Sub



    ' =========================================================
    ' To check if SMS Gateway is can be ping
    ' =========================================================
    Private Async Function IsSmsGatewayAccessibleAsync(ByVal url As String) As Task(Of Boolean)
        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "HEAD"
            request.Timeout = 3000
            Using response As HttpWebResponse = CType(Await request.GetResponseAsync(), HttpWebResponse)
                Return response.StatusCode = HttpStatusCode.OK
            End Using
        Catch
            Return False
        End Try
    End Function



    ' =========================================================
    ' SENDING SMS TO NOTIFY TO CLOSE
    ' =========================================================
    Private Async Function ProcessWorkOrderNotificationsAsync() As Task
        'THIS Is FOR NOTIFICATION

        Try
            'ShowSMSprogressSMS(True)

            ' 🔹 Step 1: Checking gateway
            Label1.Text = "🔄 Checking SMS gateway URL..."

            Dim smsGatewayUrl As String = "http://" & My.Settings.GatewayIp & ":" & My.Settings.GatewayPort
            Dim testUrl As String = $"{smsGatewayUrl}/sendsms?phone=test&text=test&password=" & My.Settings.GatewayPassword

            Dim isGatewayReachable As Boolean = Await IsSmsGatewayAccessibleAsync(testUrl)

            If Not isGatewayReachable Then
                Label1.Text = "⚠ Cannot send SMS. Gateway not responding."
                Exit Function
            End If

            Using conn As New SqlConnection(connStr)
                Await conn.OpenAsync()

                ' 🔹 Step 2: Get pending notifications
                Dim cmd As New SqlCommand("
                SELECT Id, PhoneNumber, Message 
                FROM WorkOrderNotifications 
                WHERE Status = 1 
                ORDER BY Id ASC
            ", conn)
                cmd.CommandTimeout = 30 ' ✅ ADD HERE

                Dim reader As SqlDataReader = Await cmd.ExecuteReaderAsync()
                Dim list As New List(Of (Integer, String, String))()

                While Await reader.ReadAsync()
                    list.Add((
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                ))
                End While

                reader.Close()

                ' 🔹 Step 3: No records
                If list.Count = 0 Then
                    Label1.Text = "📭 No WorkOrder notifications to send."
                    '  ShowSMSprogressSMS(False)
                    Exit Function
                End If

                Dim sentCount As Integer = 0

                ' 🔹 Step 4: Send SMS loop
                For Each item In list

                    Dim id = item.Item1
                    Dim phone = item.Item2
                    Dim msg = item.Item3

                    ' Update UI
                    Label1.Text = $"📤 Sending SMS to {phone}..."

                    ' Check gateway again before sending
                    If Not Await IsSmsGatewayAccessibleAsync(testUrl) Then
                        Label1.Text = "⚠ Gateway lost connection during sending."
                        Exit For
                    End If

                    ' Normalize message
                    msg = msg.Replace(vbCrLf, vbLf)

                    Dim encodedPhone = Uri.EscapeDataString(phone)
                    Dim encodedMsg = Uri.EscapeDataString(msg)

                    Dim smsSendUrl = $"{smsGatewayUrl}/sendsms?phone={encodedPhone}&text={encodedMsg}&password=" & My.Settings.GatewayPassword

                    Using httpClient As New HttpClient()
                        Dim response = Await httpClient.GetAsync(smsSendUrl)

                        If response.IsSuccessStatusCode Then

                            ' ✅ Update database as sent
                            Dim updateCmd As New SqlCommand("
                            UPDATE WorkOrderNotifications 
                            SET Status = 0, SentDate = @SentDate 
                            WHERE Id = @Id
                        ", conn)

                            updateCmd.CommandTimeout = 30 ' ✅ ADD HERE

                            updateCmd.Parameters.AddWithValue("@Id", id)
                            updateCmd.Parameters.AddWithValue("@SentDate", Date.Now)

                            Await updateCmd.ExecuteNonQueryAsync()

                            Label1.Text = $"✅ SMS sent to {phone}"

                        Else
                            Label1.Text = $"❌ Failed to send SMS to {phone}"
                        End If
                    End Using

                    sentCount += 1

                    ' Small delay to avoid flooding gateway
                    Await Task.Delay(500)

                Next

                Label1.Text = "✅ All SMS notifications processed."

            End Using

        Catch ex As Exception
            Label1.Text = "❌ Error: " & ex.Message

        Finally
            ' ShowSMSprogressSMS(False)
        End Try

    End Function



    ' =========================================================
    ' TIMER RECURRING TO NOTIFY TO CLOSE
    ' =========================================================
    Private Async Sub TimerWorkOrderNotify_Close_Tick(sender As Object, e As EventArgs) Handles Interval_for_Sending_Sms_Notification_Close.Tick

        'THIS IS FOR NOTIFICATION

        If isSendingWorkOrder Then Exit Sub

        isSendingWorkOrder = True

        Try
            Await ProcessWorkOrderNotificationsAsync()
        Finally
            isSendingWorkOrder = False
        End Try
    End Sub



    Private isSendingAllSMS As Boolean = False

    ' =========================================================
    ' TIMER INSERT TO NOTIFY TO CLOSE
    ' =========================================================
    Private Async Sub TimerReminder_insert_Tick(sender As Object, e As EventArgs) Handles TimerReminder_insert.Tick

        ' THIS IS FOR NOTIFICATION

        If isInserting Then Exit Sub

        isInserting = True
        TimerReminder_insert.Stop()

        Try

            Await InsertReminderSMSAsync()

        Catch ex As Exception

            MessageBox.Show("Timer Error: " & ex.Message)

        Finally

            isInserting = False
            TimerReminder_insert.Start()

        End Try

    End Sub




    Private Sub Panel1Status_Resize(sender As Object, e As EventArgs) Handles Panel1Status.Resize
        ArrangeStatusLabels()
    End Sub
    Private Sub ArrangeStatusLabels()

        Dim halfWidth As Integer = Panel1Status.Width \ 2
        Dim panelHeight As Integer = Panel1Status.Height

        ' LEFT LABEL (50%)
        lblSMSConnectionStatus.Width = halfWidth
        lblSMSConnectionStatus.Height = panelHeight
        lblSMSConnectionStatus.Left = 0
        lblSMSConnectionStatus.Top = 0
        lblSMSConnectionStatus.TextAlign = ContentAlignment.MiddleCenter

        ' RIGHT LABEL (50%)
        lblSMTPConnectionStatus.Width = halfWidth
        lblSMTPConnectionStatus.Height = panelHeight
        lblSMTPConnectionStatus.Left = halfWidth
        lblSMTPConnectionStatus.Top = 0
        lblSMTPConnectionStatus.TextAlign = ContentAlignment.MiddleCenter

    End Sub








    ' =========================================================
    ' 1. LOAD DATA TO GRID (KEEP THIS) EMAIL 
    ' =========================================================
    Private Async Function LoadPendingEmailAsync() As Task

        Try

            dgvPendingEmail.DataSource = Nothing
            dgvPendingEmail.Columns.Clear()

            Using conn As New SqlConnection(connStr)

                Await conn.OpenAsync()

                Dim query As String =
        "SELECT pk, Email, Receiver, EmailSubject, EmailBody
         FROM SmsCatcher
         WHERE emailflag IN (1,2)
         ORDER BY pk ASC"

                Using cmd As New SqlCommand(query, conn)

                    Using reader = Await cmd.ExecuteReaderAsync()

                        Dim dt As New DataTable()
                        dt.Load(reader)

                        dgvPendingEmail.DataSource = dt

                    End Using

                End Using

            End Using

            With dgvPendingEmail
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .Columns("pk").FillWeight = 10
                .Columns("Email").FillWeight = 20
                .Columns("Receiver").FillWeight = 20
                .Columns("EmailSubject").FillWeight = 50
                .Columns("EmailBody").FillWeight = 80
                .Columns("EmailBody").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .ClearSelection()
                .CurrentCell = Nothing
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


    ' =========================================================
    ' 2. MAIN PROCESSOR (THIS IS THE ENGINE) EMAIL
    ' =========================================================
    Private Async Function ProcessPendingEmailAsync() As Task

        Try

            ShowEmailProgress(True)

            Dim dt As New DataTable()

            Using conn As New SqlConnection(connStr)

                Await conn.OpenAsync()

                Dim query As String =
        "SELECT pk, Email, EmailSubject, EmailBody, emailflag
         FROM SmsCatcher
         WHERE emailflag IN (1,2)
         ORDER BY pk ASC"

                Using cmd As New SqlCommand(query, conn)

                    Using reader = Await cmd.ExecuteReaderAsync()
                        dt.Load(reader)
                    End Using

                End Using

            End Using

            If dt.Rows.Count = 0 Then

                lblEmailProgress.Text = "📭 No Pending Email"
                lblEmailStatus.Text = ""
                Exit Function

            End If

            Dim total As Integer = dt.Rows.Count
            Dim count As Integer = 0

            For Each row As DataRow In dt.Rows

                Dim pk As Integer = Convert.ToInt32(row("pk"))
                Dim email As String = row("Email").ToString()
                Dim subject As String = row("EmailSubject").ToString()
                Dim body As String = row("EmailBody").ToString()

                count += 1

                lblEmailProgress.Text = $"{count}/{total}"

                Dim success As Boolean = Await SendEmailAsync(email, subject, body)

                If success Then

                    Await UpdateEmailStatusAsync(pk, 0)
                    lblEmailStatus.Text = $"✅ Sent to {email}"

                Else

                    Await UpdateEmailStatusAsync(pk, 2)
                    lblEmailStatus.Text = $"❌ Failed {email}"

                End If

                Await Task.Delay(300)

            Next

            lblEmailProgress.Text = $"✅ Completed {count}/{total}"

        Catch ex As Exception

            lblEmailStatus.Text = ex.Message

        Finally

            ShowEmailProgress(False)

        End Try

        Await LoadPendingEmailAsync()

    End Function




    ' =========================================================
    ' 3. EMAL SENDER (ONLY THIS DOES HTTP) EMAIL
    ' =========================================================
    Private Async Function SendEmailAsync(email As String,
                                     subject As String,
                                     body As String) As Task(Of Boolean)

        Try

            Dim mail As New MailMessage()
            mail.From = New MailAddress(My.Settings.smtpEmail, My.Settings.smtpName)
            mail.To.Add(email)
            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = False

            Dim smtp As New SmtpClient(My.Settings.smtpServer)
            smtp.Port = My.Settings.smtpPort
            smtp.Credentials = New NetworkCredential(My.Settings.smtpEmail, My.Settings.smtpPass)
            smtp.EnableSsl = True

            Await smtp.SendMailAsync(mail)

            Return True

        Catch
            Return False
        End Try

    End Function

    ' =========================================================
    ' 4. UPDATE DATABASE STATUS EMAIL
    ' =========================================================
    Private Async Function UpdateEmailStatusAsync(pk As Integer, status As Integer) As Task

        Using conn As New SqlConnection(connStr)

            Await conn.OpenAsync()

            Dim query As String =
    "UPDATE SmsCatcher
     SET emailflag = @status,
         emailDateSend = @dateSent
     WHERE pk = @pk"

            Using cmd As New SqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@pk", pk)
                cmd.Parameters.AddWithValue("@dateSent", Date.Now)

                Await cmd.ExecuteNonQueryAsync()

            End Using

        End Using

    End Function


    ' =========================================================
    ' 5.CREATE REAL GATEWAY CHECK EMAIL
    ' =========================================================
    Private Async Function IsSMTPOnlineAsync() As Task(Of Boolean)

        Try

            Dim test As New MailMessage()
            test.From = New MailAddress(My.Settings.smtpEmail)
            test.To.Add(My.Settings.smtpEmail)
            test.Subject = "SMTP TEST"
            test.Body = "TEST"

            Dim smtp As New SmtpClient(My.Settings.smtpServer)
            smtp.Port = My.Settings.smtpPort
            smtp.Credentials = New NetworkCredential(My.Settings.smtpEmail, My.Settings.smtpPass)
            smtp.EnableSsl = True

            Await smtp.SendMailAsync(test)

            Return True

        Catch
            Return False
        End Try

    End Function



    ' =========================================================
    ' 6.TIMER FOR EMAIL
    ' =========================================================
    Private Async Sub TimerEmail_Tick(sender As Object, e As EventArgs) Handles TimerEmail.Tick
        If isProcessingEmail Then Exit Sub

        isProcessingEmail = True
        TimerEmail.Stop()

        Try

            Await LoadPendingEmailAsync()

            Dim smtpOk As Boolean = Await IsSMTPOnlineAsync()

            If smtpOk Then

                lblSMTPConnectionStatus.Text =
            "🟢 SMTP Online - Processing Queue"

                lblSMTPConnectionStatus.BackColor = Color.Green

                Await ProcessPendingEmailAsync()

            Else

                lblSMTPConnectionStatus.Text =
            "🔴 SMTP Offline - Waiting Retry"

                lblSMTPConnectionStatus.BackColor = Color.Red

            End If

        Catch ex As Exception

            lblSMTPConnectionStatus.Text = "🔴 Email System Error"
            lblSMTPConnectionStatus.BackColor = Color.Red
            lblEmailStatus.Text = ex.Message

        Finally

            isProcessingEmail = False
            TimerEmail.Start()

        End Try

    End Sub

    Private Async Sub TimerWoms_Tick(sender As Object, e As EventArgs) Handles TimerWoms.Tick
        If isLoadingDashboard Then Exit Sub

        Try

            isLoadingDashboard = True

            TimerWoms.Enabled = False

            lblStatus.Text = "Refreshing dashboard..."

            Await Load_Dashboard()

            lblStatus.Text = "Dashboard updated : " & DateTime.Now.ToString("hh:mm:ss tt")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            isLoadingDashboard = False

            TimerWoms.Enabled = True

        End Try
    End Sub
End Class
'http://192.168.60.153:8080/sendsms?phone=09950482881&text=ttt&password=m0b1l3
'"http://" + MobileReader!gateway + ":" & MobileReader!port & "/sendsms?phone=" & RecPhoneNo & "&text=" & Recmessage & "&password=" & MobileReader!password


