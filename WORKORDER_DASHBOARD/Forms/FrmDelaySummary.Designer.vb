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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDelaySummary))
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lstPendingMaterials_grid = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDelayInfo = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSeverity = New System.Windows.Forms.Label()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWorkOrderNo = New System.Windows.Forms.Label()
        Me.lblCurrentDelay = New System.Windows.Forms.Label()
        Me.lblDaysDelay = New System.Windows.Forms.Label()
        Me.lblResponsibleArea = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlTimeline = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.lstPendingMaterials_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpDelayInfo.SuspendLayout()
        Me.Panel4.SuspendLayout()
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
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageKey = "closeWo.png"
        Me.btnClose.ImageList = Me.ImageList1
        Me.btnClose.Location = New System.Drawing.Point(893, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 35)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "closeWo.png")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 741)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1025, 50)
        Me.Panel1.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lstPendingMaterials_grid)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 509)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(6)
        Me.Panel2.Size = New System.Drawing.Size(1025, 232)
        Me.Panel2.TabIndex = 19
        '
        'lstPendingMaterials_grid
        '
        Me.lstPendingMaterials_grid.BackgroundColor = System.Drawing.Color.DarkGray
        Me.lstPendingMaterials_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lstPendingMaterials_grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPendingMaterials_grid.Location = New System.Drawing.Point(6, 38)
        Me.lstPendingMaterials_grid.Name = "lstPendingMaterials_grid"
        Me.lstPendingMaterials_grid.Size = New System.Drawing.Size(1013, 188)
        Me.lstPendingMaterials_grid.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(6, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1013, 32)
        Me.Panel3.TabIndex = 20
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpDelayInfo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 44)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1025, 465)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'grpDelayInfo
        '
        Me.grpDelayInfo.Controls.Add(Me.Label6)
        Me.grpDelayInfo.Controls.Add(Me.lblSeverity)
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
        Me.grpDelayInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDelayInfo.Location = New System.Drawing.Point(515, 3)
        Me.grpDelayInfo.Name = "grpDelayInfo"
        Me.grpDelayInfo.Size = New System.Drawing.Size(507, 459)
        Me.grpDelayInfo.TabIndex = 23
        Me.grpDelayInfo.TabStop = False
        Me.grpDelayInfo.Text = "Delay Information"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(15, 366)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 21)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Severity                         -"
        '
        'lblSeverity
        '
        Me.lblSeverity.AutoSize = True
        Me.lblSeverity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeverity.Location = New System.Drawing.Point(213, 366)
        Me.lblSeverity.Name = "lblSeverity"
        Me.lblSeverity.Size = New System.Drawing.Size(0, 21)
        Me.lblSeverity.TabIndex = 16
        '
        'txtDes
        '
        Me.txtDes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDes.Location = New System.Drawing.Point(18, 222)
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.ReadOnly = True
        Me.txtDes.Size = New System.Drawing.Size(465, 119)
        Me.txtDes.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(14, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 21)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Responsible Person   -"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(14, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 21)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Days Delay                   -"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(14, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Current Delay              -"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 21)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Work Order No.           -"
        '
        'lblWorkOrderNo
        '
        Me.lblWorkOrderNo.AutoSize = True
        Me.lblWorkOrderNo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkOrderNo.Location = New System.Drawing.Point(198, 52)
        Me.lblWorkOrderNo.Name = "lblWorkOrderNo"
        Me.lblWorkOrderNo.Size = New System.Drawing.Size(0, 21)
        Me.lblWorkOrderNo.TabIndex = 3
        '
        'lblCurrentDelay
        '
        Me.lblCurrentDelay.AutoSize = True
        Me.lblCurrentDelay.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentDelay.Location = New System.Drawing.Point(198, 88)
        Me.lblCurrentDelay.Name = "lblCurrentDelay"
        Me.lblCurrentDelay.Size = New System.Drawing.Size(0, 21)
        Me.lblCurrentDelay.TabIndex = 4
        '
        'lblDaysDelay
        '
        Me.lblDaysDelay.AutoSize = True
        Me.lblDaysDelay.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaysDelay.Location = New System.Drawing.Point(198, 126)
        Me.lblDaysDelay.Name = "lblDaysDelay"
        Me.lblDaysDelay.Size = New System.Drawing.Size(0, 21)
        Me.lblDaysDelay.TabIndex = 5
        '
        'lblResponsibleArea
        '
        Me.lblResponsibleArea.AutoSize = True
        Me.lblResponsibleArea.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsibleArea.Location = New System.Drawing.Point(198, 160)
        Me.lblResponsibleArea.Name = "lblResponsibleArea"
        Me.lblResponsibleArea.Size = New System.Drawing.Size(0, 21)
        Me.lblResponsibleArea.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pnlTimeline)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(506, 459)
        Me.Panel4.TabIndex = 0
        '
        'pnlTimeline
        '
        Me.pnlTimeline.AutoScroll = True
        Me.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTimeline.Location = New System.Drawing.Point(0, 18)
        Me.pnlTimeline.Name = "pnlTimeline"
        Me.pnlTimeline.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlTimeline.Size = New System.Drawing.Size(506, 441)
        Me.pnlTimeline.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Timeline Summary"
        '
        'FrmDelaySummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 791)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1041, 830)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1041, 830)
        Me.Name = "FrmDelaySummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delay Summary"
        Me.pnlTitle.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.lstPendingMaterials_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpDelayInfo.ResumeLayout(False)
        Me.grpDelayInfo.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitle As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lstPendingMaterials_grid As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grpDelayInfo As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSeverity As Label
    Friend WithEvents txtDes As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblWorkOrderNo As Label
    Friend WithEvents lblCurrentDelay As Label
    Friend WithEvents lblDaysDelay As Label
    Friend WithEvents lblResponsibleArea As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pnlTimeline As Panel
    Friend WithEvents Label7 As Label
End Class
