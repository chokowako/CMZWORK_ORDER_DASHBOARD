<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupAndOption
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupAndOption))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnDatabase = New System.Windows.Forms.Button()
        Me.BtnSms = New System.Windows.Forms.Button()
        Me.BtnRecurringToClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnGateway = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnDatabase, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnSms, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnRecurringToClose, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnGateway, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 55)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 181)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 55)
        Me.Panel1.TabIndex = 1
        '
        'BtnDatabase
        '
        Me.BtnDatabase.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDatabase.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDatabase.ImageIndex = 0
        Me.BtnDatabase.ImageList = Me.ImageList1
        Me.BtnDatabase.Location = New System.Drawing.Point(3, 3)
        Me.BtnDatabase.Name = "BtnDatabase"
        Me.BtnDatabase.Size = New System.Drawing.Size(194, 175)
        Me.BtnDatabase.TabIndex = 0
        Me.BtnDatabase.Text = "Datase Connection"
        Me.BtnDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnDatabase.UseVisualStyleBackColor = True
        '
        'BtnSms
        '
        Me.BtnSms.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSms.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSms.ImageKey = "sms.png"
        Me.BtnSms.ImageList = Me.ImageList1
        Me.BtnSms.Location = New System.Drawing.Point(203, 3)
        Me.BtnSms.Name = "BtnSms"
        Me.BtnSms.Size = New System.Drawing.Size(194, 175)
        Me.BtnSms.TabIndex = 1
        Me.BtnSms.Text = "Sms Configuration"
        Me.BtnSms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSms.UseVisualStyleBackColor = True
        '
        'BtnRecurringToClose
        '
        Me.BtnRecurringToClose.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRecurringToClose.ImageKey = "notification.png"
        Me.BtnRecurringToClose.ImageList = Me.ImageList1
        Me.BtnRecurringToClose.Location = New System.Drawing.Point(603, 3)
        Me.BtnRecurringToClose.Name = "BtnRecurringToClose"
        Me.BtnRecurringToClose.Size = New System.Drawing.Size(194, 175)
        Me.BtnRecurringToClose.TabIndex = 2
        Me.BtnRecurringToClose.Text = "Notification to Close"
        Me.BtnRecurringToClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnRecurringToClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRecurringToClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(800, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Set up and Option"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnGateway
        '
        Me.BtnGateway.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGateway.ImageKey = "wifi-router.png"
        Me.BtnGateway.ImageList = Me.ImageList1
        Me.BtnGateway.Location = New System.Drawing.Point(403, 3)
        Me.BtnGateway.Name = "BtnGateway"
        Me.BtnGateway.Size = New System.Drawing.Size(194, 175)
        Me.BtnGateway.TabIndex = 3
        Me.BtnGateway.Text = "Gateway Configuration"
        Me.BtnGateway.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGateway.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGateway.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "database-storage.png")
        Me.ImageList1.Images.SetKeyName(1, "sms.png")
        Me.ImageList1.Images.SetKeyName(2, "wifi-router.png")
        Me.ImageList1.Images.SetKeyName(3, "notification.png")
        '
        'SetupAndOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 236)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SetupAndOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SetupAndOption"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BtnRecurringToClose As Button
    Friend WithEvents BtnSms As Button
    Friend WithEvents BtnDatabase As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnGateway As Button
    Friend WithEvents ImageList1 As ImageList
End Class
