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
        Me.txtSmsInterval_Mil = New System.Windows.Forms.TextBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.txtSmsInterval_Mins = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSmsInterval_Sec = New System.Windows.Forms.TextBox()
        Me.txtSmsInterval_Hour = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtGatewyInterval_Mins = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtGatewayInterval_Sec = New System.Windows.Forms.TextBox()
        Me.txtGatewayInterval_Hour = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGatewayInterval_Milli = New System.Windows.Forms.TextBox()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSmsInterval_Mil
        '
        Me.txtSmsInterval_Mil.Enabled = False
        Me.txtSmsInterval_Mil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSmsInterval_Mil.Location = New System.Drawing.Point(186, 6)
        Me.txtSmsInterval_Mil.Name = "txtSmsInterval_Mil"
        Me.txtSmsInterval_Mil.ReadOnly = True
        Me.txtSmsInterval_Mil.Size = New System.Drawing.Size(107, 20)
        Me.txtSmsInterval_Mil.TabIndex = 184
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.ForeColor = System.Drawing.Color.Black
        Me.BtnClose.ImageKey = "close.png"
        Me.BtnClose.ImageList = Me.ImageList1
        Me.BtnClose.Location = New System.Drawing.Point(355, 492)
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
        Me.Panel2.Location = New System.Drawing.Point(10, 371)
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
        Me.BtnReset.Location = New System.Drawing.Point(10, 492)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(76, 29)
        Me.BtnReset.TabIndex = 186
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnReset.UseVisualStyleBackColor = False
        '
        'txtSmsInterval_Mins
        '
        Me.txtSmsInterval_Mins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSmsInterval_Mins.Location = New System.Drawing.Point(213, 43)
        Me.txtSmsInterval_Mins.Name = "txtSmsInterval_Mins"
        Me.txtSmsInterval_Mins.Size = New System.Drawing.Size(44, 20)
        Me.txtSmsInterval_Mins.TabIndex = 189
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
        'txtSmsInterval_Sec
        '
        Me.txtSmsInterval_Sec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSmsInterval_Sec.Location = New System.Drawing.Point(307, 43)
        Me.txtSmsInterval_Sec.Name = "txtSmsInterval_Sec"
        Me.txtSmsInterval_Sec.Size = New System.Drawing.Size(44, 20)
        Me.txtSmsInterval_Sec.TabIndex = 182
        '
        'txtSmsInterval_Hour
        '
        Me.txtSmsInterval_Hour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSmsInterval_Hour.Location = New System.Drawing.Point(115, 43)
        Me.txtSmsInterval_Hour.Name = "txtSmsInterval_Hour"
        Me.txtSmsInterval_Hour.Size = New System.Drawing.Size(44, 20)
        Me.txtSmsInterval_Hour.TabIndex = 187
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.txtGatewyInterval_Mins)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.txtGatewayInterval_Sec)
        Me.Panel5.Controls.Add(Me.txtGatewayInterval_Hour)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.txtGatewayInterval_Milli)
        Me.Panel5.Location = New System.Drawing.Point(10, 280)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(417, 74)
        Me.Panel5.TabIndex = 192
        '
        'txtGatewyInterval_Mins
        '
        Me.txtGatewyInterval_Mins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGatewyInterval_Mins.Location = New System.Drawing.Point(217, 47)
        Me.txtGatewyInterval_Mins.Name = "txtGatewyInterval_Mins"
        Me.txtGatewyInterval_Mins.Size = New System.Drawing.Size(44, 20)
        Me.txtGatewyInterval_Mins.TabIndex = 200
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
        'txtGatewayInterval_Sec
        '
        Me.txtGatewayInterval_Sec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGatewayInterval_Sec.Location = New System.Drawing.Point(311, 47)
        Me.txtGatewayInterval_Sec.Name = "txtGatewayInterval_Sec"
        Me.txtGatewayInterval_Sec.Size = New System.Drawing.Size(44, 20)
        Me.txtGatewayInterval_Sec.TabIndex = 198
        '
        'txtGatewayInterval_Hour
        '
        Me.txtGatewayInterval_Hour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGatewayInterval_Hour.Location = New System.Drawing.Point(119, 43)
        Me.txtGatewayInterval_Hour.Name = "txtGatewayInterval_Hour"
        Me.txtGatewayInterval_Hour.Size = New System.Drawing.Size(44, 20)
        Me.txtGatewayInterval_Hour.TabIndex = 199
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
        'txtGatewayInterval_Milli
        '
        Me.txtGatewayInterval_Milli.Enabled = False
        Me.txtGatewayInterval_Milli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGatewayInterval_Milli.Location = New System.Drawing.Point(190, 7)
        Me.txtGatewayInterval_Milli.Name = "txtGatewayInterval_Milli"
        Me.txtGatewayInterval_Milli.Size = New System.Drawing.Size(107, 20)
        Me.txtGatewayInterval_Milli.TabIndex = 197
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
        Me.Label8.Location = New System.Drawing.Point(-1, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(165, 13)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "Check for Closing / Insert Record"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
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
        Me.Label6.Location = New System.Drawing.Point(284, 83)
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
        Me.Label5.Location = New System.Drawing.Point(171, 83)
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
        Me.Label3.Location = New System.Drawing.Point(65, 83)
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
        Me.Panel3.Controls.Add(Me.txtSmsInterval_Mins)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txtSmsInterval_Mil)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtSmsInterval_Sec)
        Me.Panel3.Controls.Add(Me.txtSmsInterval_Hour)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(14, 145)
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
        'ConfigSendToClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 531)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "ConfigSendToClose"
        Me.Text = "ConfigSendToClose"
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSmsInterval_Mil As TextBox
    Friend WithEvents BtnClose As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents txtSmsInterval_Mins As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSmsInterval_Sec As TextBox
    Friend WithEvents txtSmsInterval_Hour As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtGatewyInterval_Mins As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtGatewayInterval_Sec As TextBox
    Friend WithEvents txtGatewayInterval_Hour As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtGatewayInterval_Milli As TextBox
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
End Class
