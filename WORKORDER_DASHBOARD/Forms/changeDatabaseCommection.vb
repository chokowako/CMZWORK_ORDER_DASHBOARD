Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class changeDatabaseCommection
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As Integer) As IntPtr
    End Function

    Private Const PBM_SETMARQUEE As Integer = &H40A
    Private Const PBM_SETMARQUEE_SPEED As Integer = &H2A3 ' Not officially documented, fallback to standard below


    Private Sub changeDatabaseCommection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundCornes(Me)
        txtServername.Text = My.Settings.ServerName
        txtDbName.Text = My.Settings.DBName
        txtDbUsername.Text = My.Settings.DBUsername
        txtDbpassword.Text = My.Settings.DBPassword

        txtWomsInterval_Hour.Text = My.Settings.WomsInterval_Hours
        txtWomsInterval_Mins.Text = My.Settings.WomsInterval_Mins
        txtWomsInterval_sec.Text = My.Settings.WomsInterval_Sec
        txtWomsInterval_Milli.Text = My.Settings.WomsInterval_Mlli

        Me.Text = "Database Connection Checker"
    End Sub
    Private Sub ConnectionSetup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = "🔄 Automatically checking connection..."
        progressBar.Visible = False ' Don’t show during auto-check

        If CheckDatabaseConnection() Then
            Me.Text = "✅ Connection successful (auto)."
            DashBoard.Show()
            'Me.Hide()
        Else
            Me.Text = "❌ Auto connection failed. Please check manually."
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

    Private Function BuildConnectionString() As String
        Return $"Server={My.Settings.ServerName};Database={My.Settings.DBName};User ID={My.Settings.DBUsername};Password={My.Settings.DBPassword};MultipleActiveResultSets=true;Integrated Security=True;Persist Security Info=False;Trusted_Connection=false;Encrypt=False;TrustServerCertificate=True"
    End Function

    Private Function CheckDatabaseConnection() As Boolean
        Try
            Using conn As New SqlConnection(BuildConnectionString())
                conn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function




    Private Sub BtnReset_Click_1(sender As Object, e As EventArgs) Handles BtnReset.Click
        Dim result As DialogResult = MessageBox.Show("are you want to reset the Database Connection Server connection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            My.Settings.ServerName = ""
            My.Settings.DBName = ""
            My.Settings.DBUsername = ""
            My.Settings.DBPassword = ""

            My.Settings.WomsInterval_Hours = ""
            My.Settings.WomsInterval_Mins = ""
            My.Settings.WomsInterval_Sec = ""
            My.Settings.WomsInterval_Mlli = ""


            txtServername.Text = ""
            txtDbName.Text = ""
            txtDbUsername.Text = ""
            txtDbpassword.Text = ""

            txtWomsInterval_Hour.Text = ""
            txtWomsInterval_Mins.Text = ""
            txtWomsInterval_sec.Text = ""
            txtWomsInterval_Milli.Text = ""

            My.Settings.Save()
        End If
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        My.Settings.ServerName = txtServername.Text
        My.Settings.DBName = txtDbName.Text
        My.Settings.DBUsername = txtDbUsername.Text
        My.Settings.DBPassword = txtDbpassword.Text
        My.Settings.Save()
        MsgBox("Your server configuration has saved!", MsgBoxStyle.Information, MsgBoxResult.Ok)
    End Sub

    Private Async Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Me.Text = "🔄 Checking connection..."
        progressBar.Style = ProgressBarStyle.Marquee
        progressBar.Visible = True
        SendMessage(progressBar.Handle, PBM_SETMARQUEE, 1, 10) ' 50 = speed (lower is faster)

        Dim isConnected As Boolean = Await Task.Run(Function() CheckDatabaseConnection())

        progressBar.Visible = False

        If isConnected Then
            Me.Text = "✅ Connection successful (manual)."
            MessageBox.Show("Connection test passed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Do NOT show Form2
        Else
            Me.Text = "❌ Connection failed."
            MessageBox.Show("Connection test failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.WomsInterval_Hours = txtWomsInterval_Hour.Text
        My.Settings.WomsInterval_Mins = txtWomsInterval_Mins.Text
        My.Settings.WomsInterval_Sec = txtWomsInterval_sec.Text
        My.Settings.WomsInterval_Mlli = txtWomsInterval_Milli.Text
        My.Settings.Save()
        MsgBox("Your server configuration has saved!", MsgBoxStyle.Information, MsgBoxResult.Ok)
    End Sub

    Private Sub txtWomsInterval_Hour_TextChanged(sender As Object, e As EventArgs) Handles txtWomsInterval_Hour.TextChanged
        Recalculate_Woms_Milliseconds
    End Sub

    Private Sub txtWomsInterval_Mins_TextChanged(sender As Object, e As EventArgs) Handles txtWomsInterval_Mins.TextChanged
        Recalculate_Woms_Milliseconds
    End Sub

    Private Sub txtWomsInterval_sec_TextChanged(sender As Object, e As EventArgs) Handles txtWomsInterval_sec.TextChanged
        Recalculate_Woms_Milliseconds
    End Sub

    Private Sub Recalculate_Woms_Milliseconds()
        Dim hours As Integer = 0
        Dim minutes As Integer = 0
        Dim seconds As Integer = 0
        Dim Gateway_milliseconds As Integer

        ' Check if txtSmsInterval_Hour is not empty
        If Not String.IsNullOrEmpty(txtWomsInterval_Hour.Text) Then
            If Integer.TryParse(txtWomsInterval_Hour.Text, hours) = False Then
                MessageBox.Show("Invalid input for hours.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Mins is not empty
        If Not String.IsNullOrEmpty(txtWomsInterval_Mins.Text) Then
            If Integer.TryParse(txtWomsInterval_Mins.Text, minutes) = False Then
                MessageBox.Show("Invalid input for minutes.")
                Return
            End If
        End If

        ' Check if txtSmsInterval_Sec is not empty
        If Not String.IsNullOrEmpty(txtWomsInterval_sec.Text) Then
            If Integer.TryParse(txtWomsInterval_sec.Text, seconds) = False Then
                MessageBox.Show("Invalid input for seconds.")
                Return
            End If
        End If


        ' If all fields are empty, show an error message
        If String.IsNullOrEmpty(txtWomsInterval_Hour.Text) AndAlso
           String.IsNullOrEmpty(txtWomsInterval_Mins.Text) AndAlso
           String.IsNullOrEmpty(txtWomsInterval_sec.Text) Then
            txtWomsInterval_Milli.Text = "" ' Clear the output if no input
            Return
        End If

        ' Calculate the total milliseconds based on the entered values
        Gateway_milliseconds = (hours * 3600000) + (minutes * 60000) + (seconds * 1000)

        ' Display the result in txtSmsInterval_Mil
        txtWomsInterval_Milli.Text = Gateway_milliseconds.ToString()
    End Sub



    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        If BtnExit.Text = "Exit" Then
            End
        ElseIf BtnExit.Text = "Close" Then
            Me.Hide()

        End If
    End Sub
End Class