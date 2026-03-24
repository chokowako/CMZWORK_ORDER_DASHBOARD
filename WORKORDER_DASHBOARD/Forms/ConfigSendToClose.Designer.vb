<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigSendToClose
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigSendToClose))
        Me.TxtinsertNotifyToClose_Milli = New System.Windows.Forms.TextBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.TxtinsertNotifyToClose_Mins = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtinsertNotifyToClose_Sec = New System.Windows.Forms.TextBox()
        Me.TxtInsertNotifyToClose_Hours = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNotifyToClose_Mins = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtNotifyToClose_Sec = New System.Windows.Forms.TextBox()
        Me.TxtNotifyToClose_Hours = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtNotifyToClose_Milli = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtNotifyToCloseRecurring_Hour = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtNotifyToCloseRecurring_Milli = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtNotifyToCloseRecurring_Min = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtNotifyToCloseRecurring_Sec = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtinsertNotifyToClose_Milli
        '
        Me.TxtinsertNotifyToClose_Milli.Enabled = False
        Me.TxtinsertNotifyToClose_Milli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtinsertNotifyToClose_Milli.Location = New System.Drawing.Point(186, 6)
        Me.TxtinsertNotifyToClose_Milli.Name = "TxtinsertNotifyToClose_Milli"
        Me.TxtinsertNotifyToClose_Milli.ReadOnly = True
        Me.TxtinsertNotifyToClose_Milli.Size = New System.Drawing.Size(107, 20)
        Me.TxtinsertNotifyToClose_Milli.TabIndex = 184
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.ForeColor = System.Drawing.Color.Black
        Me.BtnClose.ImageKey = "close.png"
        Me.BtnClose.ImageList = Me.ImageList1
        Me.BtnClose.Location = New System.Drawing.Point(355, 402)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(76, 29)
        Me.BtnClose.TabIndex = 128
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "sms.png")
        Me.ImageList1.Images.SetKeyName(1, "email.png")
        Me.ImageList1.Images.SetKeyName(2, "reset.png")
        Me.ImageList1.Images.SetKeyName(3, "close.png")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.ForeColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(14, 350)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(417, 46)
        Me.Panel2.TabIndex = 177
        '
        'BtnSave
        '
        Me.BtnSave.ForeColor = System.Drawing.Color.Black
        Me.BtnSave.Location = New System.Drawing.Point(10, 8)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(397, 29)
        Me.BtnSave.TabIndex = 136
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(415, 24)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "NOTIFY USER TO CLOSED WORK ORDER"
        '
        'BtnReset
        '
        Me.BtnReset.BackColor = System.Drawing.Color.White
        Me.BtnReset.ForeColor = System.Drawing.Color.Black
        Me.BtnReset.ImageKey = "reset.png"
        Me.BtnReset.ImageList = Me.ImageList1
        Me.BtnReset.Location = New System.Drawing.Point(12, 402)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(76, 29)
        Me.BtnReset.TabIndex = 186
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnReset.UseVisualStyleBackColor = False
        '
        'TxtinsertNotifyToClose_Mins
        '
        Me.TxtinsertNotifyToClose_Mins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtinsertNotifyToClose_Mins.Location = New System.Drawing.Point(213, 43)
        Me.TxtinsertNotifyToClose_Mins.Name = "TxtinsertNotifyToClose_Mins"
        Me.TxtinsertNotifyToClose_Mins.Size = New System.Drawing.Size(44, 20)
        Me.TxtinsertNotifyToClose_Mins.TabIndex = 189
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(3, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 195
        Me.Label13.Text = "Input                        :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(257, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 194
        Me.Label12.Text = "Minutes"
        '
        'TxtinsertNotifyToClose_Sec
        '
        Me.TxtinsertNotifyToClose_Sec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtinsertNotifyToClose_Sec.Location = New System.Drawing.Point(307, 43)
        Me.TxtinsertNotifyToClose_Sec.Name = "TxtinsertNotifyToClose_Sec"
        Me.TxtinsertNotifyToClose_Sec.Size = New System.Drawing.Size(44, 20)
        Me.TxtinsertNotifyToClose_Sec.TabIndex = 182
        '
        'TxtInsertNotifyToClose_Hours
        '
        Me.TxtInsertNotifyToClose_Hours.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInsertNotifyToClose_Hours.Location = New System.Drawing.Point(115, 43)
        Me.TxtInsertNotifyToClose_Hours.Name = "TxtInsertNotifyToClose_Hours"
        Me.TxtInsertNotifyToClose_Hours.Size = New System.Drawing.Size(44, 20)
        Me.TxtInsertNotifyToClose_Hours.TabIndex = 187
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.TxtNotifyToClose_Mins)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.TxtNotifyToClose_Sec)
        Me.Panel5.Controls.Add(Me.TxtNotifyToClose_Hours)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.TxtNotifyToClose_Milli)
        Me.Panel5.Location = New System.Drawing.Point(14, 186)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(417, 74)
        Me.Panel5.TabIndex = 192
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(302, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "milliseconds"
        '
        'TxtNotifyToClose_Mins
        '
        Me.TxtNotifyToClose_Mins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToClose_Mins.Location = New System.Drawing.Point(217, 47)
        Me.TxtNotifyToClose_Mins.Name = "TxtNotifyToClose_Mins"
        Me.TxtNotifyToClose_Mins.Size = New System.Drawing.Size(44, 20)
        Me.TxtNotifyToClose_Mins.TabIndex = 200
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(6, 50)
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
        Me.Label16.Location = New System.Drawing.Point(261, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 203
        Me.Label16.Text = "Minutes"
        '
        'TxtNotifyToClose_Sec
        '
        Me.TxtNotifyToClose_Sec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToClose_Sec.Location = New System.Drawing.Point(311, 47)
        Me.TxtNotifyToClose_Sec.Name = "TxtNotifyToClose_Sec"
        Me.TxtNotifyToClose_Sec.Size = New System.Drawing.Size(44, 20)
        Me.TxtNotifyToClose_Sec.TabIndex = 198
        '
        'TxtNotifyToClose_Hours
        '
        Me.TxtNotifyToClose_Hours.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToClose_Hours.Location = New System.Drawing.Point(118, 47)
        Me.TxtNotifyToClose_Hours.Name = "TxtNotifyToClose_Hours"
        Me.TxtNotifyToClose_Hours.Size = New System.Drawing.Size(44, 20)
        Me.TxtNotifyToClose_Hours.TabIndex = 199
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(165, 50)
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
        Me.Label18.Location = New System.Drawing.Point(363, 50)
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
        Me.Label14.Size = New System.Drawing.Size(181, 13)
        Me.Label14.TabIndex = 196
        Me.Label14.Text = "Interval for Sending Sms Notification "
        '
        'TxtNotifyToClose_Milli
        '
        Me.TxtNotifyToClose_Milli.Enabled = False
        Me.TxtNotifyToClose_Milli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToClose_Milli.Location = New System.Drawing.Point(190, 7)
        Me.TxtNotifyToClose_Milli.Name = "TxtNotifyToClose_Milli"
        Me.TxtNotifyToClose_Milli.Size = New System.Drawing.Size(107, 20)
        Me.TxtNotifyToClose_Milli.TabIndex = 197
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(161, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 193
        Me.Label11.Text = "Hours"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(298, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 192
        Me.Label10.Text = "milliseconds"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(359, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "Seconds"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(165, 13)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "Check for Closing / Insert Record"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.BtnReset)
        Me.Panel4.Controls.Add(Me.BtnClose)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(445, 533)
        Me.Panel4.TabIndex = 166
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(284, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = "Seconds = 0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(171, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 195
        Me.Label5.Text = "Minutes = 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(65, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Hour = 0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(65, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(298, 13)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "It is advice to set the Check for Closing / Insert Record to use"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Controls.Add(Me.TxtinsertNotifyToClose_Mins)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.TxtinsertNotifyToClose_Milli)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.TxtinsertNotifyToClose_Sec)
        Me.Panel3.Controls.Add(Me.TxtInsertNotifyToClose_Hours)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(14, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(417, 74)
        Me.Panel3.TabIndex = 191
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Mobile Number"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.TxtNotifyToCloseRecurring_Min)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.TxtNotifyToCloseRecurring_Sec)
        Me.Panel1.Controls.Add(Me.TxtNotifyToCloseRecurring_Hour)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.TxtNotifyToCloseRecurring_Milli)
        Me.Panel1.Location = New System.Drawing.Point(14, 266)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 74)
        Me.Panel1.TabIndex = 197
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(302, 10)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 205
        Me.Label19.Text = "milliseconds"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(6, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 13)
        Me.Label20.TabIndex = 204
        Me.Label20.Text = "Input                        :"
        '
        'TxtNotifyToCloseRecurring_Hour
        '
        Me.TxtNotifyToCloseRecurring_Hour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToCloseRecurring_Hour.Location = New System.Drawing.Point(118, 47)
        Me.TxtNotifyToCloseRecurring_Hour.Name = "TxtNotifyToCloseRecurring_Hour"
        Me.TxtNotifyToCloseRecurring_Hour.Size = New System.Drawing.Size(44, 20)
        Me.TxtNotifyToCloseRecurring_Hour.TabIndex = 199
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(165, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 13)
        Me.Label22.TabIndex = 202
        Me.Label22.Text = "Hours"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(3, 10)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 13)
        Me.Label24.TabIndex = 196
        Me.Label24.Text = "Recurring Interval"
        '
        'TxtNotifyToCloseRecurring_Milli
        '
        Me.TxtNotifyToCloseRecurring_Milli.Enabled = False
        Me.TxtNotifyToCloseRecurring_Milli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToCloseRecurring_Milli.Location = New System.Drawing.Point(190, 7)
        Me.TxtNotifyToCloseRecurring_Milli.Name = "TxtNotifyToCloseRecurring_Milli"
        Me.TxtNotifyToCloseRecurring_Milli.Size = New System.Drawing.Size(107, 20)
        Me.TxtNotifyToCloseRecurring_Milli.TabIndex = 197
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(261, 50)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 13)
        Me.Label21.TabIndex = 203
        Me.Label21.Text = "Minutes"
        '
        'TxtNotifyToCloseRecurring_Min
        '
        Me.TxtNotifyToCloseRecurring_Min.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToCloseRecurring_Min.Location = New System.Drawing.Point(217, 47)
        Me.TxtNotifyToCloseRecurring_Min.Name = "TxtNotifyToCloseRecurring_Min"
        Me.TxtNotifyToCloseRecurring_Min.Size = New System.Drawing.Size(44, 20)
        Me.TxtNotifyToCloseRecurring_Min.TabIndex = 200
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(363, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 201
        Me.Label23.Text = "Seconds"
        '
        'TxtNotifyToCloseRecurring_Sec
        '
        Me.TxtNotifyToCloseRecurring_Sec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotifyToCloseRecurring_Sec.Location = New System.Drawing.Point(311, 47)
        Me.TxtNotifyToCloseRecurring_Sec.Name = "TxtNotifyToCloseRecurring_Sec"
        Me.TxtNotifyToCloseRecurring_Sec.Size = New System.Drawing.Size(44, 20)
        Me.TxtNotifyToCloseRecurring_Sec.TabIndex = 198
        '
        'ConfigSendToClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 443)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "ConfigSendToClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConfigSendToClose"
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtinsertNotifyToClose_Milli As TextBox
    Friend WithEvents BtnClose As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents TxtinsertNotifyToClose_Mins As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtinsertNotifyToClose_Sec As TextBox
    Friend WithEvents TxtInsertNotifyToClose_Hours As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TxtNotifyToClose_Mins As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtNotifyToClose_Sec As TextBox
    Friend WithEvents TxtNotifyToClose_Hours As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtNotifyToClose_Milli As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtNotifyToCloseRecurring_Hour As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents TxtNotifyToCloseRecurring_Milli As TextBox
    Friend WithEvents TxtNotifyToCloseRecurring_Min As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtNotifyToCloseRecurring_Sec As TextBox
    Friend WithEvents Label23 As Label
End Class
