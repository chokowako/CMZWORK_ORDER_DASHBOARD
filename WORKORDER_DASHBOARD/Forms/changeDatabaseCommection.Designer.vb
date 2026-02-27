<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class changeDatabaseCommection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(changeDatabaseCommection))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pictureHeader = New System.Windows.Forms.PictureBox()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.txtDbpassword = New System.Windows.Forms.TextBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.txtDbUsername = New System.Windows.Forms.TextBox()
        Me.BtnConfigSmtp = New System.Windows.Forms.Button()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.BtnConfigSms = New System.Windows.Forms.Button()
        Me.txtServername = New System.Windows.Forms.TextBox()
        Me.DbPassword = New System.Windows.Forms.Label()
        Me.DbUsername = New System.Windows.Forms.Label()
        Me.lblDbName = New System.Windows.Forms.Label()
        Me.lblServerName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtWomsInterval_Mins = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtWomsInterval_sec = New System.Windows.Forms.TextBox()
        Me.txtWomsInterval_Hour = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtWomsInterval_Milli = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.pictureHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(355, 24)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "CHANGE DATABASE CONNECTION"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "close.png")
        Me.ImageList1.Images.SetKeyName(1, "closeRed.png")
        Me.ImageList1.Images.SetKeyName(2, "sms.png")
        Me.ImageList1.Images.SetKeyName(3, "email.png")
        Me.ImageList1.Images.SetKeyName(4, "reset.png")
        '
        'pictureHeader
        '
        Me.pictureHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pictureHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pictureHeader.Location = New System.Drawing.Point(0, 0)
        Me.pictureHeader.Name = "pictureHeader"
        Me.pictureHeader.Size = New System.Drawing.Size(445, 50)
        Me.pictureHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureHeader.TabIndex = 143
        Me.pictureHeader.TabStop = False
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(14, 394)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(417, 23)
        Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressBar.TabIndex = 210
        '
        'txtDbpassword
        '
        Me.txtDbpassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WORKORDER_DASHBOARD.My.MySettings.Default, "DBPassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDbpassword.Location = New System.Drawing.Point(135, 139)
        Me.txtDbpassword.Name = "txtDbpassword"
        Me.txtDbpassword.Size = New System.Drawing.Size(288, 20)
        Me.txtDbpassword.TabIndex = 204
        Me.txtDbpassword.Text = Global.WORKORDER_DASHBOARD.My.MySettings.Default.DBPassword
        '
        'BtnReset
        '
        Me.BtnReset.BackColor = System.Drawing.Color.White
        Me.BtnReset.ForeColor = System.Drawing.Color.Black
        Me.BtnReset.ImageKey = "reset.png"
        Me.BtnReset.ImageList = Me.ImageList1
        Me.BtnReset.Location = New System.Drawing.Point(14, 423)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(79, 44)
        Me.BtnReset.TabIndex = 211
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnReset.UseVisualStyleBackColor = False
        '
        'txtDbUsername
        '
        Me.txtDbUsername.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WORKORDER_DASHBOARD.My.MySettings.Default, "DBUsername", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDbUsername.Location = New System.Drawing.Point(135, 113)
        Me.txtDbUsername.Name = "txtDbUsername"
        Me.txtDbUsername.Size = New System.Drawing.Size(288, 20)
        Me.txtDbUsername.TabIndex = 202
        Me.txtDbUsername.Text = Global.WORKORDER_DASHBOARD.My.MySettings.Default.DBUsername
        '
        'BtnConfigSmtp
        '
        Me.BtnConfigSmtp.BackColor = System.Drawing.Color.White
        Me.BtnConfigSmtp.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigSmtp.ImageKey = "email.png"
        Me.BtnConfigSmtp.ImageList = Me.ImageList1
        Me.BtnConfigSmtp.Location = New System.Drawing.Point(320, 423)
        Me.BtnConfigSmtp.Name = "BtnConfigSmtp"
        Me.BtnConfigSmtp.Size = New System.Drawing.Size(111, 44)
        Me.BtnConfigSmtp.TabIndex = 203
        Me.BtnConfigSmtp.Text = "Config SMTP"
        Me.BtnConfigSmtp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConfigSmtp.UseVisualStyleBackColor = False
        '
        'txtDbName
        '
        Me.txtDbName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WORKORDER_DASHBOARD.My.MySettings.Default, "DBName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDbName.Location = New System.Drawing.Point(135, 87)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(288, 20)
        Me.txtDbName.TabIndex = 200
        Me.txtDbName.Text = Global.WORKORDER_DASHBOARD.My.MySettings.Default.DBName
        '
        'BtnConfigSms
        '
        Me.BtnConfigSms.BackColor = System.Drawing.Color.White
        Me.BtnConfigSms.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigSms.ImageKey = "sms.png"
        Me.BtnConfigSms.ImageList = Me.ImageList1
        Me.BtnConfigSms.Location = New System.Drawing.Point(204, 423)
        Me.BtnConfigSms.Name = "BtnConfigSms"
        Me.BtnConfigSms.Size = New System.Drawing.Size(109, 44)
        Me.BtnConfigSms.TabIndex = 201
        Me.BtnConfigSms.Text = "Config SMS"
        Me.BtnConfigSms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConfigSms.UseVisualStyleBackColor = False
        '
        'txtServername
        '
        Me.txtServername.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WORKORDER_DASHBOARD.My.MySettings.Default, "ServerName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtServername.Location = New System.Drawing.Point(135, 61)
        Me.txtServername.Name = "txtServername"
        Me.txtServername.Size = New System.Drawing.Size(288, 20)
        Me.txtServername.TabIndex = 199
        Me.txtServername.Text = Global.WORKORDER_DASHBOARD.My.MySettings.Default.ServerName
        '
        'DbPassword
        '
        Me.DbPassword.AutoSize = True
        Me.DbPassword.BackColor = System.Drawing.Color.Transparent
        Me.DbPassword.ForeColor = System.Drawing.Color.White
        Me.DbPassword.Location = New System.Drawing.Point(17, 146)
        Me.DbPassword.Name = "DbPassword"
        Me.DbPassword.Size = New System.Drawing.Size(104, 13)
        Me.DbPassword.TabIndex = 208
        Me.DbPassword.Text = "Database password:"
        '
        'DbUsername
        '
        Me.DbUsername.AutoSize = True
        Me.DbUsername.BackColor = System.Drawing.Color.Transparent
        Me.DbUsername.ForeColor = System.Drawing.Color.White
        Me.DbUsername.Location = New System.Drawing.Point(17, 120)
        Me.DbUsername.Name = "DbUsername"
        Me.DbUsername.Size = New System.Drawing.Size(108, 13)
        Me.DbUsername.TabIndex = 207
        Me.DbUsername.Text = "Database user name:"
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.BackColor = System.Drawing.Color.Transparent
        Me.lblDbName.ForeColor = System.Drawing.Color.White
        Me.lblDbName.Location = New System.Drawing.Point(17, 94)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.Size = New System.Drawing.Size(87, 13)
        Me.lblDbName.TabIndex = 206
        Me.lblDbName.Text = "Database Name:"
        '
        'lblServerName
        '
        Me.lblServerName.AutoSize = True
        Me.lblServerName.BackColor = System.Drawing.Color.Transparent
        Me.lblServerName.ForeColor = System.Drawing.Color.White
        Me.lblServerName.Location = New System.Drawing.Point(17, 68)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(72, 13)
        Me.lblServerName.TabIndex = 205
        Me.lblServerName.Text = "Server Name:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnConnect)
        Me.Panel1.Controls.Add(Me.btnTestConnection)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(14, 172)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 110)
        Me.Panel1.TabIndex = 209
        '
        'btnConnect
        '
        Me.btnConnect.ForeColor = System.Drawing.Color.Black
        Me.btnConnect.Location = New System.Drawing.Point(10, 8)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(397, 29)
        Me.btnConnect.TabIndex = 136
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.ForeColor = System.Drawing.Color.Black
        Me.btnTestConnection.Location = New System.Drawing.Point(10, 41)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(397, 29)
        Me.btnTestConnection.TabIndex = 127
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.ForeColor = System.Drawing.Color.Black
        Me.BtnExit.ImageList = Me.ImageList1
        Me.BtnExit.Location = New System.Drawing.Point(10, 74)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(397, 29)
        Me.BtnExit.TabIndex = 128
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.txtWomsInterval_Mins)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.txtWomsInterval_sec)
        Me.Panel5.Controls.Add(Me.txtWomsInterval_Hour)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.txtWomsInterval_Milli)
        Me.Panel5.Location = New System.Drawing.Point(14, 288)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(417, 65)
        Me.Panel5.TabIndex = 212
        '
        'txtWomsInterval_Mins
        '
        Me.txtWomsInterval_Mins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWomsInterval_Mins.Location = New System.Drawing.Point(211, 33)
        Me.txtWomsInterval_Mins.Name = "txtWomsInterval_Mins"
        Me.txtWomsInterval_Mins.Size = New System.Drawing.Size(44, 20)
        Me.txtWomsInterval_Mins.TabIndex = 200
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(5, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 13)
        Me.Label15.TabIndex = 204
        Me.Label15.Text = "Input                        :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(255, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 203
        Me.Label16.Text = "Minutes"
        '
        'txtWomsInterval_sec
        '
        Me.txtWomsInterval_sec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWomsInterval_sec.Location = New System.Drawing.Point(305, 33)
        Me.txtWomsInterval_sec.Name = "txtWomsInterval_sec"
        Me.txtWomsInterval_sec.Size = New System.Drawing.Size(44, 20)
        Me.txtWomsInterval_sec.TabIndex = 198
        '
        'txtWomsInterval_Hour
        '
        Me.txtWomsInterval_Hour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWomsInterval_Hour.Location = New System.Drawing.Point(113, 33)
        Me.txtWomsInterval_Hour.Name = "txtWomsInterval_Hour"
        Me.txtWomsInterval_Hour.Size = New System.Drawing.Size(44, 20)
        Me.txtWomsInterval_Hour.TabIndex = 199
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(159, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 202
        Me.Label17.Text = "Hours"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(357, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 201
        Me.Label18.Text = "Seconds"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(3, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 196
        Me.Label14.Text = "WOMS  Interval    :"
        '
        'txtWomsInterval_Milli
        '
        Me.txtWomsInterval_Milli.Enabled = False
        Me.txtWomsInterval_Milli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWomsInterval_Milli.Location = New System.Drawing.Point(113, 7)
        Me.txtWomsInterval_Milli.Name = "txtWomsInterval_Milli"
        Me.txtWomsInterval_Milli.Size = New System.Drawing.Size(107, 20)
        Me.txtWomsInterval_Milli.TabIndex = 197
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(14, 359)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(417, 29)
        Me.btnSave.TabIndex = 213
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'changeDatabaseCommection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(445, 478)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.txtDbpassword)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.txtDbUsername)
        Me.Controls.Add(Me.BtnConfigSmtp)
        Me.Controls.Add(Me.txtDbName)
        Me.Controls.Add(Me.BtnConfigSms)
        Me.Controls.Add(Me.txtServername)
        Me.Controls.Add(Me.DbPassword)
        Me.Controls.Add(Me.DbUsername)
        Me.Controls.Add(Me.lblDbName)
        Me.Controls.Add(Me.lblServerName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pictureHeader)
        Me.MaximizeBox = False
        Me.Name = "changeDatabaseCommection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order Dashboard"
        CType(Me.pictureHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents pictureHeader As PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents txtDbpassword As TextBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents txtDbUsername As TextBox
    Friend WithEvents BtnConfigSmtp As Button
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents BtnConfigSms As Button
    Friend WithEvents txtServername As TextBox
    Friend WithEvents DbPassword As Label
    Friend WithEvents DbUsername As Label
    Friend WithEvents lblDbName As Label
    Friend WithEvents lblServerName As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtWomsInterval_Mins As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtWomsInterval_sec As TextBox
    Friend WithEvents txtWomsInterval_Hour As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtWomsInterval_Milli As TextBox
    Friend WithEvents btnSave As Button
End Class
