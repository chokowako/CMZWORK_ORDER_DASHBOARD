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
    Dim gatewayConnected As Boolean = False
    Dim sendingInProgress As Boolean = False

    'Dim smtpServer As String = "smtp.gmail.com"
    'Dim smtpPort As Integer = 587
    'Dim smtpUser As String = "workordermanagementsystem@gmail.com"
    'Dim smtpPass As String = "nart gusr iqnm ixkh"
    'Dim senderName As String = "WOMS"

    Private sendingSMSInProgress As Boolean = False
    Private sendingEmailInProgress As Boolean = False



    Private WithEvents DashboardTimer As New Timer()
    Private DashboardLoading As Boolean = False



    Private Sub DateAndTime_Tick(sender As Object, e As EventArgs) Handles DateAndTime.Tick
        lblDateTime.Text = Format(Now, "Long Date") & "," & " " & TimeOfDay.ToString("h:mm:ss tt")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub
    Private Sub BtsStart_Click(sender As Object, e As EventArgs) Handles BtsStart.Click

        Try
            If BtsStart.ImageIndex = 0 Then
                BtsStart.ImageIndex = 3

                LoadPendingSMS()
                LoadPendingEmails()
                Call LoadDashboardFromTimer()

                ProgressBar1.Show()


                TimerWoms.Interval = My.Settings.WomsInterval_Mlli
                TimerWoms.Start()


                TimerCheckGateway.Interval = My.Settings.GatewayInterval_Milli
                TimerCheckGateway.Start()


                TimerSMS.Interval = My.Settings.SmsInterval_milli
                TimerSMS.Start()

                TimerEmail.Interval = My.Settings.EmailInterval_Milli
                TimerEmail.Start()


            ElseIf BtsStart.ImageIndex = 3 Then
                BtsStart.ImageIndex = 0


                TimerWoms.Stop()
                TimerCheckGateway.Stop()
                TimerSMS.Stop()
                TimerEmail.Stop()

                ProgressBar1.Hide()
                progressSMS.Hide()
                progressEmail.Hide()
                progressSMS1.Hide()
                progressEmail1.Hide()


                lblProgress.Text = "0 SMS pending"
                lblEmailProgress.Text = "0 Emails pending"

                lblStatus.Text = ""
                lblEmailStatus.Text = ""

                lblConnectionStatus.Text = "📶❌  Gateway Status: Offline"
                lblConnectionStatus.BackColor = Color.Red


            End If
        Catch ex As Exception
            MessageBox.Show("❌X" & ex.Message)
        End Try

    End Sub

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        changeDatabaseCommection.BtnExit.Text = "Close"
        changeDatabaseCommection.ShowDialog()
    End Sub

    ' Load pending SMS into DataGridView
    Private Sub LoadPendingSMS()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim query As String = "SELECT pk, RecPhoneNo, Message FROM SmsCatcher WHERE smsflag = 1 ORDER BY pk ASC"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Optional: Prevent flicker by re-binding only if changed
                If dgvPendingSMS.DataSource Is Nothing OrElse CType(dgvPendingSMS.DataSource, DataTable).Rows.Count <> table.Rows.Count Then
                    dgvPendingSMS.DataSource = table
                Else
                    ' Efficient update (optional)
                    CType(dgvPendingSMS.DataSource, DataTable).Clear()
                    For Each row As DataRow In table.Rows
                        CType(dgvPendingSMS.DataSource, DataTable).ImportRow(row)
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load pending SMS: " & ex.Message)
        End Try
    End Sub

    ' Load pending Emails into DataGridView
    Private Sub LoadPendingEmails()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT Pk_WorkOderNo as [ WOMS No.], Email as [Email Address], EmailSubject  as [Email Subject] FROM SmsCatcher WHERE emailflag = 1", conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvPendingEmail.DataSource = table
            End Using
        Catch ex As Exception
            lblEmailStatus.Text = "❌ Failed to load pending emails: " & ex.Message
        End Try
    End Sub

    ' Timer tick event to send pending SMS
    Private Async Sub TimerSMS_Tick(sender As Object, e As EventArgs) Handles TimerSMS.Tick
        If sendingSMSInProgress Then Exit Sub

        sendingSMSInProgress = True
        Try
            Await ProcessPendingSMSAsync()
            LoadPendingSMS()
        Catch ex As Exception
            lblStatus.Text = "❌ SMS Timer error: " & ex.Message
        Finally
            sendingSMSInProgress = False
        End Try
    End Sub

    ' Timer tick event to send pending Emails
    Private Async Sub TimerEmail_Tick(sender As Object, e As EventArgs) Handles TimerEmail.Tick
        If sendingEmailInProgress Then Exit Sub

        sendingEmailInProgress = True

        Try
            Await ProcessPendingEmailAsync()
            LoadPendingEmails()
        Catch ex As Exception
            lblEmailStatus.Text = "❌ Email Timer error: " & ex.Message
        Finally
            sendingEmailInProgress = False
        End Try
    End Sub

    Private Sub ShowSMSprogressSMS(isVisible As Boolean)
        progressSMS1.Visible = isVisible
    End Sub

    Private Sub ShowEmailProgressEmail(isVisible As Boolean)
        progressEmail1.Visible = isVisible
    End Sub


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
    Private Async Function IsInternetAvailableAsync() As Task(Of Boolean)
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(2)
                Dim response As HttpResponseMessage = Await client.GetAsync("https://www.google.com")
                Return response.IsSuccessStatusCode
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Async Function ProcessPendingSMSAsync() As Task
        'Try
        '    ShowSMSProgress(True)


        '    lblStatus.Text = "🔄 Checking SMS gateway URL..."

        '    Dim smsGatewayUrl As String = "http://" + My.Settings.GatewayIp + ":" + My.Settings.GatewayPort ' Replace with your phone IP/port
        '    Dim testUrl As String = $"{smsGatewayUrl}/sendsms?phone=test&text=test&password=" + My.Settings.GatewayPassword

        '    If Not Await IsSmsGatewayAccessibleAsync(testUrl) Then
        '        lblConnectionStatus.Text = "📶❌ SMS Gateway not reachable"
        '        lblConnectionStatus.BackColor = Color.Red
        '        lblStatus.Text = "⚠ Cannot send SMS. Gateway URL is not responding."
        '        ShowSMSProgress(False)
        '        Exit Function
        '    End If

        '    lblConnectionStatus.Text = "📶 SMS Gateway reachable"
        '    lblConnectionStatus.BackColor = Color.Green
        '    lblStatus.Text = "📨 Checking for pending SMS..."

        '    Using conn As New SqlConnection(connStr)
        '        Await conn.OpenAsync()

        '        Dim cmd As New SqlCommand("SELECT TOP 1 pk, RecPhoneNo, Message FROM SmsCatcher WHERE smsflag = 1", conn)
        '        Dim reader As SqlDataReader = Await cmd.ExecuteReaderAsync()

        '        If Not Await reader.ReadAsync() Then
        '            reader.Close()
        '            lblStatus.Text = "📭 No pending SMS to send."
        '            ShowSMSProgress(False)
        '            Exit Function
        '        End If

        '        Dim pk As Integer = reader.GetInt32(0)
        '        Dim phone As String = reader.GetString(1)
        '        Dim msg As String = reader.GetString(2)

        '        reader.Close()

        '        ' Recheck gateway before each message
        '        If Not Await IsSmsGatewayAccessibleAsync(testUrl) Then
        '            lblStatus.Text = "⚠ SMS Gateway lost connection during batch."
        '            lblConnectionStatus.Text = "📴 SMS Gateway not reachable"
        '            lblConnectionStatus.BackColor = Color.Red
        '            Exit Function
        '        End If


        '        lblStatus.Text = $"📤 Sending SMS to {phone}..."

        '        Dim encodedPhone As String = Uri.EscapeDataString(phone)
        '        Dim encodedMsg As String = Uri.EscapeDataString(msg)
        '        Dim smsSendUrl As String = $"{smsGatewayUrl}/sendsms?phone={encodedPhone}&text={encodedMsg}&password=" + My.Settings.GatewayPassword

        '        Using httpClient As New HttpClient()
        '            Dim response As HttpResponseMessage = Await httpClient.GetAsync(smsSendUrl)
        '            Dim responseBody As String = Await response.Content.ReadAsStringAsync()

        '            If response.IsSuccessStatusCode Then
        '                Dim updateCmd As New SqlCommand("UPDATE SmsCatcher SET smsflag = 0, smsDateSend = @smsDateSend WHERE pk = @pk", conn)
        '                updateCmd.Parameters.AddWithValue("@pk", pk)
        '                updateCmd.Parameters.AddWithValue("@smsDateSend", Format(Date.Now, "MM/dd/yyyy hh:mm :ss tt"))
        '                Await updateCmd.ExecuteNonQueryAsync()

        '                lblStatus.Text = $"✅ SMS sent to {phone}"
        '            Else
        '                lblStatus.Text = $"❌ Failed to send SMS to {phone}. Status: {response.StatusCode}, Body: {responseBody}"
        '            End If
        '        End Using
        '    End Using


        'Catch ex As Exception
        '    lblStatus.Text = "❌ Error while sending SMS: " & ex.Message
        'Finally
        '    ShowSMSProgress(False)
        'End Try


        Try
            ShowSMSprogressSMS(True)
            lblStatus.Text = "🔄 Checking SMS gateway URL..."

            Dim smsGatewayUrl As String = "http://" + My.Settings.GatewayIp + ":" + My.Settings.GatewayPort
            Dim testUrl As String = $"{smsGatewayUrl}/sendsms?phone=test&text=test&password=" + My.Settings.GatewayPassword

            ' Always base both labels on this single check
            Dim isGatewayReachable As Boolean = Await IsSmsGatewayAccessibleAsync(testUrl)

            If Not isGatewayReachable Then
                lblStatus.Text = "⚠ Cannot send SMS. Gateway URL is not responding."
                lblConnectionStatus.Text = "📶❌ SMS Gateway not reachable"
                lblConnectionStatus.BackColor = Color.Red
                ShowSMSprogressSMS(False)
                Exit Function
            Else
                lblStatus.Text = "📨 Checking for pending SMS..."
                lblConnectionStatus.Text = "📶 SMS Gateway reachable"
                lblConnectionStatus.BackColor = Color.Green
            End If
            lblStatus.Text = "📨 Checking for pending SMS..."


            Using conn As New SqlConnection(connStr)
                Await conn.OpenAsync()

                Dim smsList As New List(Of (Integer, String, String))()

                ' Load ALL pending SMS at once for progress tracking
                Dim preloadCmd As New SqlCommand("SELECT pk, RecPhoneNo, Message FROM SmsCatcher WHERE smsflag = 1 ORDER BY pk ASC", conn)
                Dim preloadReader As SqlDataReader = Await preloadCmd.ExecuteReaderAsync()

                While Await preloadReader.ReadAsync()
                    smsList.Add((preloadReader.GetInt32(0), preloadReader.GetString(1), preloadReader.GetString(2)))
                End While
                preloadReader.Close()

                If smsList.Count = 0 Then
                    lblStatus.Text = "📭 No pending SMS to send."
                    ShowSMSprogressSMS(False)
                    Exit Function
                End If

                ' Initialize progress bar
                progressSMS.Visible = True
                progressSMS.Minimum = 0
                progressSMS.Maximum = smsList.Count
                progressSMS.Value = 0

                Dim sentCount As Integer = 0

                For Each sms In smsList
                    If Not Await IsSmsGatewayAccessibleAsync(testUrl) Then
                        lblStatus.Text = "⚠ SMS Gateway lost connection during batch."
                        lblConnectionStatus.Text = "📴 SMS Gateway not reachable"
                        lblConnectionStatus.BackColor = Color.Red
                        Exit For
                    End If

                    Dim pk = sms.Item1
                    Dim phone = sms.Item2
                    Dim msg = sms.Item3

                    lblStatus.Text = $"📤 Sending SMS to {phone}..."

                    msg = msg.Replace(vbCrLf, vbLf)
                    Dim encodedPhone = Uri.EscapeDataString(phone)
                    Dim encodedMsg = Uri.EscapeDataString(msg)
                    Dim smsSendUrl = $"{smsGatewayUrl}/sendsms?phone={encodedPhone}&text={encodedMsg}&password=" + My.Settings.GatewayPassword

                    Using httpClient As New HttpClient()
                        Dim response = Await httpClient.GetAsync(smsSendUrl)
                        Dim responseBody = Await response.Content.ReadAsStringAsync()

                        If response.IsSuccessStatusCode Then
                            Dim updateCmd As New SqlCommand("UPDATE SmsCatcher SET smsflag = 0, smsDateSend = @smsDateSend WHERE pk = @pk", conn)
                            updateCmd.Parameters.AddWithValue("@pk", pk)
                            updateCmd.Parameters.AddWithValue("@smsDateSend", Format(Date.Now, "MM/dd/yyyy hh:mm:ss tt"))
                            Await updateCmd.ExecuteNonQueryAsync()

                            lblStatus.Text = $"✅ SMS sent to {phone}"
                        Else
                            lblStatus.Text = $"❌ Failed to send SMS to {phone}. Status: {response.StatusCode}"
                        End If
                    End Using

                    sentCount += 1
                    progressSMS.Value = sentCount
                    lblProgress.Text = $"Progress: {sentCount}/{smsList.Count}"

                    LoadPendingSMS()
                    Await Task.Delay(1000)
                Next

                lblProgress.Text = "✅ All SMS sent!"
                Await Task.Delay(5000)
                lblProgress.Text = "0 SMS pending"
                progressSMS.Visible = False

            End Using

        Catch ex As Exception
            lblStatus.Text = "❌ Error while sending SMS: " & ex.Message
        Finally
            ShowSMSprogressSMS(False)
        End Try
    End Function

    Private Async Function ProcessPendingEmailAsync() As Task
        'Try
        '    ShowEmailProgressEmail(True)
        '    lblEmailStatus.Text = "🔄 Checking internet connection..."

        '    If Not Await IsInternetAvailableAsync() Then
        '        lblEmailStatus.Text = "🌐❌ No internet connection. Skipping email send."
        '        ShowEmailProgressEmail(False)
        '        Exit Function
        '    End If

        '    Using conn As New SqlConnection(connStr)
        '        Await conn.OpenAsync()

        '        Dim cmd As New SqlCommand("SELECT TOP 1 pk, Email, EmailSubject, EmailBody FROM SmsCatcher WHERE emailflag = 1", conn)
        '        Dim reader As SqlDataReader = Await cmd.ExecuteReaderAsync()

        '        If Not Await reader.ReadAsync() Then
        '            reader.Close()
        '            lblEmailStatus.Text = "📭 No pending email to send."
        '            ShowEmailProgressEmail(False)
        '            Exit Function
        '        End If

        '        Dim pk As Integer = reader.GetInt32(0)
        '        Dim toAddress As String = reader.GetString(1)
        '        Dim subject As String = reader.GetString(2)
        '        Dim body As String = reader.GetString(3)

        '        reader.Close()

        '        If String.IsNullOrWhiteSpace(toAddress) Then
        '            lblEmailStatus.Text = "⚠ Cannot send email: recipient address is empty."
        '            ShowEmailProgressEmail(False)
        '            Exit Function
        '        End If

        '        lblEmailStatus.Text = $"📤 Sending email to {toAddress}..."

        '        Try
        '            Dim smtp As New SmtpClient(My.Settings.smtpServer)
        '            smtp.Credentials = New NetworkCredential(My.Settings.smtpEmail, My.Settings.smtpPass)
        '            smtp.Port = My.Settings.smtpPort
        '            smtp.EnableSsl = True

        '            Dim mail As New MailMessage()
        '            mail.From = New MailAddress(My.Settings.smtpEmail, My.Settings.smtpName)
        '            mail.To.Add(toAddress)
        '            mail.Subject = subject
        '            mail.Body = body

        '            Await smtp.SendMailAsync(mail)

        '            Dim updateCmd As New SqlCommand("UPDATE SmsCatcher SET emailflag = 0,EmailDateSend = @EmailDateSend WHERE pk = @pk", conn)
        '            updateCmd.Parameters.AddWithValue("@pk", pk)
        '            updateCmd.Parameters.AddWithValue("@EmailDateSend", Format(Date.Now, "MM/dd/yyyy hh:mm :ss tt"))
        '            Await updateCmd.ExecuteNonQueryAsync()

        '            lblEmailStatus.Text = $"✅ Email sent to {toAddress}"
        '        Catch ex As Exception
        '            lblEmailStatus.Text = $"❌ Failed to send email to {toAddress}. {ex.Message}"
        '        End Try
        '    End Using

        'Catch ex As Exception
        '    lblEmailStatus.Text = "❌ Error while sending email: " & ex.Message
        'Finally
        '    ShowEmailProgressEmail(False)
        'End Try

        Try
            ShowEmailProgressEmail(True)
            lblEmailStatus.Text = "🔄 Checking internet connection..."

            If Not Await IsInternetAvailableAsync() Then
                lblEmailStatus.Text = "🌐❌ No internet connection. Skipping email send."
                ShowEmailProgressEmail(False)
                Exit Function
            End If

            Using conn As New SqlConnection(connStr)
                Await conn.OpenAsync()

                Dim emailList As New List(Of (Integer, String, String, String))()

                Dim preloadCmd As New SqlCommand("SELECT pk, Email, EmailSubject, EmailBody FROM SmsCatcher WHERE emailflag = 1 ORDER BY pk ASC", conn)
                Dim reader As SqlDataReader = Await preloadCmd.ExecuteReaderAsync()

                While Await reader.ReadAsync()
                    Dim pk As Integer = Convert.ToInt32(reader("pk"))
                    Dim toAddress As String = reader("Email").ToString()
                    Dim subject As String = reader("EmailSubject").ToString()
                    Dim body As String = reader("EmailBody").ToString()
                    emailList.Add((pk, toAddress, subject, body))
                End While
                reader.Close()

                If emailList.Count = 0 Then
                    lblEmailStatus.Text = "📭 No pending emails to send."
                    ShowEmailProgressEmail(False)
                    Exit Function
                End If

                progressEmail.Visible = True
                progressEmail.Minimum = 0
                progressEmail.Maximum = emailList.Count
                progressEmail.Value = 0

                Dim sentCount As Integer = 0

                For Each email In emailList
                    Dim pk = email.Item1
                    Dim toAddress = email.Item2
                    Dim subject = email.Item3
                    Dim body = email.Item4

                    If String.IsNullOrWhiteSpace(toAddress) Then
                        lblEmailStatus.Text = "⚠ Cannot send email: recipient address is empty."
                        Continue For
                    End If

                    ' ✅ Update progress first for smoother experience
                    sentCount += 1
                    progressEmail.Value = sentCount
                    lblEmailProgress.Text = $"Progress: {sentCount}/{emailList.Count}"

                    lblEmailStatus.Text = $"📤 Sending email to {toAddress}..."

                    Try
                        Dim mail As New MailMessage()
                        mail.From = New MailAddress(My.Settings.smtpEmail, My.Settings.smtpName)
                        mail.To.Add(toAddress)
                        mail.Subject = subject
                        mail.Body = body
                        mail.IsBodyHtml = False

                        Dim smtp As New SmtpClient(My.Settings.smtpServer)
                        smtp.Port = My.Settings.smtpPort
                        smtp.Credentials = New NetworkCredential(My.Settings.smtpEmail, My.Settings.smtpPass)
                        smtp.EnableSsl = True

                        Await smtp.SendMailAsync(mail)

                        Dim updateCmd As New SqlCommand("UPDATE SmsCatcher SET emailflag = 0, emailDateSend = @dateSend WHERE pk = @pk", conn)
                        updateCmd.Parameters.AddWithValue("@pk", pk)
                        updateCmd.Parameters.AddWithValue("@dateSend", Date.Now)
                        Await updateCmd.ExecuteNonQueryAsync()

                        lblEmailStatus.Text = $"✅ Email sent to {toAddress}"

                        LoadPendingEmails()
                        Await Task.Delay(500)

                    Catch ex As Exception
                        lblEmailStatus.Text = $"❌ Failed to send email to {toAddress}: {ex.Message}"
                    End Try
                Next

                lblEmailProgress.Text = "✅ All emails sent!"
                Await Task.Delay(2000)
                lblEmailProgress.Text = "0 Emails pending"
                progressEmail.Visible = False
            End Using

        Catch ex As Exception
            lblEmailStatus.Text = "❌ Error while sending emails: " & ex.Message
        Finally
            ShowEmailProgressEmail(False)
        End Try
    End Function

    Private Async Sub TimerCheckGateway_Tick(sender As Object, e As EventArgs) Handles TimerCheckGateway.Tick
        Dim smsGatewayUrl As String = "http://" + My.Settings.GatewayIp + ":" + My.Settings.GatewayPort ' Replace with your phone IP/port
        Dim testUrl As String = $"{smsGatewayUrl}/sendsms?phone=test&text=test&password=" + My.Settings.GatewayPassword

        If Not Await IsGatewayAccessibleAsync(testUrl) Then
            lblConnectionStatus.Text = "📴 SMS Gateway not reachable"
            lblConnectionStatus.BackColor = Color.Red
            lblStatus.Text = "⚠ Cannot send SMS. Gateway URL is not responding."
            ShowSMSprogressSMS(False)
        End If

        lblConnectionStatus.Text = "📱 SMS Gateway reachable"
        lblConnectionStatus.BackColor = Color.Green
    End Sub

    Private Async Function IsGatewayAccessibleAsync(ByVal url As String) As Task(Of Boolean)
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

    Private Async Sub TimerWoms_Tick(sender As Object, e As EventArgs) Handles TimerWoms.Tick
        If Not DashboardLoading Then
            DashboardLoading = True
            Await Load_Dashboard()
            DashboardLoading = False
        End If
    End Sub


    Private Async Function LoadDashboardFromTimer() As Task
        Try
            DashboardLoading = True
            Await Load_Dashboard() ' This is your existing async function in the module
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard: " & ex.Message)
        Finally
            DashboardLoading = False
        End Try
    End Function

End Class
'http://192.168.60.153:8080/sendsms?phone=09950482881&text=ttt&password=m0b1l3
'"http://" + MobileReader!gateway + ":" & MobileReader!port & "/sendsms?phone=" & RecPhoneNo & "&text=" & Recmessage & "&password=" & MobileReader!password


