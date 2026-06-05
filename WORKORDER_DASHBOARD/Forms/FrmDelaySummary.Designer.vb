<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDelaySummary
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
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDelayInfo = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWorkOrderNo = New System.Windows.Forms.Label()
        Me.lblCurrentDelay = New System.Windows.Forms.Label()
        Me.lblDaysDelay = New System.Windows.Forms.Label()
        Me.lblResponsibleArea = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlTimeline = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lstPendingMaterials_grid = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlTitle.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpDelayInfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.lstPendingMaterials_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(1025, 44)
        Me.pnlTitle.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1025, 44)
        Me.lblTitle.TabIndex = 334
        Me.lblTitle.Text = "WORK ORDER PREVIEW"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(902, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 35)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Button1"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpDelayInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlTimeline, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 44)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1025, 697)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'grpDelayInfo
        '
        Me.grpDelayInfo.Controls.Add(Me.txtDes)
        Me.grpDelayInfo.Controls.Add(Me.Label4)
        Me.grpDelayInfo.Controls.Add(Me.Label3)
        Me.grpDelayInfo.Controls.Add(Me.Label2)
        Me.grpDelayInfo.Controls.Add(Me.Label1)
        Me.grpDelayInfo.Controls.Add(Me.lblWorkOrderNo)
        Me.grpDelayInfo.Controls.Add(Me.lblCurrentDelay)
        Me.grpDelayInfo.Controls.Add(Me.lblDaysDelay)
        Me.grpDelayInfo.Controls.Add(Me.lblResponsibleArea)
        Me.grpDelayInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDelayInfo.Location = New System.Drawing.Point(3, 3)
        Me.grpDelayInfo.Name = "grpDelayInfo"
        Me.grpDelayInfo.Size = New System.Drawing.Size(404, 691)
        Me.grpDelayInfo.TabIndex = 12
        Me.grpDelayInfo.TabStop = False
        Me.grpDelayInfo.Text = "Delay Information"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Responsible Person   -"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Days Delay                -"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Current Delay            -"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Work Order No.         -"
        '
        'lblWorkOrderNo
        '
        Me.lblWorkOrderNo.AutoSize = True
        Me.lblWorkOrderNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkOrderNo.Location = New System.Drawing.Point(172, 48)
        Me.lblWorkOrderNo.Name = "lblWorkOrderNo"
        Me.lblWorkOrderNo.Size = New System.Drawing.Size(106, 17)
        Me.lblWorkOrderNo.TabIndex = 3
        Me.lblWorkOrderNo.Text = "Work Order No."
        '
        'lblCurrentDelay
        '
        Me.lblCurrentDelay.AutoSize = True
        Me.lblCurrentDelay.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentDelay.Location = New System.Drawing.Point(172, 84)
        Me.lblCurrentDelay.Name = "lblCurrentDelay"
        Me.lblCurrentDelay.Size = New System.Drawing.Size(93, 17)
        Me.lblCurrentDelay.TabIndex = 4
        Me.lblCurrentDelay.Text = "Current Delay"
        '
        'lblDaysDelay
        '
        Me.lblDaysDelay.AutoSize = True
        Me.lblDaysDelay.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaysDelay.Location = New System.Drawing.Point(172, 122)
        Me.lblDaysDelay.Name = "lblDaysDelay"
        Me.lblDaysDelay.Size = New System.Drawing.Size(92, 17)
        Me.lblDaysDelay.TabIndex = 5
        Me.lblDaysDelay.Text = "Days Delayed"
        '
        'lblResponsibleArea
        '
        Me.lblResponsibleArea.AutoSize = True
        Me.lblResponsibleArea.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsibleArea.Location = New System.Drawing.Point(172, 156)
        Me.lblResponsibleArea.Name = "lblResponsibleArea"
        Me.lblResponsibleArea.Size = New System.Drawing.Size(114, 17)
        Me.lblResponsibleArea.TabIndex = 6
        Me.lblResponsibleArea.Text = "Responsible Area"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 741)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1025, 50)
        Me.Panel1.TabIndex = 17
        '
        'pnlTimeline
        '
        Me.pnlTimeline.AutoScroll = True
        Me.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTimeline.Location = New System.Drawing.Point(413, 3)
        Me.pnlTimeline.Name = "pnlTimeline"
        Me.pnlTimeline.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlTimeline.Size = New System.Drawing.Size(609, 691)
        Me.pnlTimeline.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lstPendingMaterials_grid)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 423)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1025, 318)
        Me.Panel2.TabIndex = 19
        '
        'lstPendingMaterials_grid
        '
        Me.lstPendingMaterials_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lstPendingMaterials_grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPendingMaterials_grid.Location = New System.Drawing.Point(0, 32)
        Me.lstPendingMaterials_grid.Name = "lstPendingMaterials_grid"
        Me.lstPendingMaterials_grid.Size = New System.Drawing.Size(1025, 286)
        Me.lstPendingMaterials_grid.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1025, 32)
        Me.Panel3.TabIndex = 20
        '
        'txtDes
        '
        Me.txtDes.Location = New System.Drawing.Point(9, 200)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.ReadOnly = True
        Me.txtDes.Size = New System.Drawing.Size(352, 127)
        Me.txtDes.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Materials"
        '
        'FrmDelaySummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 791)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmDelaySummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delay Summary"
        Me.pnlTitle.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpDelayInfo.ResumeLayout(False)
        Me.grpDelayInfo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.lstPendingMaterials_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitle As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grpDelayInfo As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblWorkOrderNo As Label
    Friend WithEvents lblCurrentDelay As Label
    Friend WithEvents lblDaysDelay As Label
    Friend WithEvents lblResponsibleArea As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlTimeline As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lstPendingMaterials_grid As DataGridView
    Friend WithEvents txtDes As TextBox
    Friend WithEvents Label5 As Label
End Class
