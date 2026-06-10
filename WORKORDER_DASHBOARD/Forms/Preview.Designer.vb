<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Preview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preview))
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.grpMaterials = New System.Windows.Forms.GroupBox()
        Me.DataGridView_Mat = New System.Windows.Forms.DataGridView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.grpWorkOrderDetails = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CancelledRemarks = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CancelledBy = New System.Windows.Forms.TextBox()
        Me.DateCancelled = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Closeby = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DateClose = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CompletedBy = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateCompleted = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateRequested = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtWorkOrderNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSeverity = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtWorkType = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txthead = New System.Windows.Forms.TextBox()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.txtreq = New System.Windows.Forms.TextBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.grpAssignedPersonnel = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPersonAssigned = New System.Windows.Forms.TextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelApproval = New System.Windows.Forms.Panel()
        Me.btnViewDelayedSummary = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.pnlFinance = New System.Windows.Forms.Panel()
        Me.lblFinanceManager = New System.Windows.Forms.Label()
        Me.lblFinanceDate = New System.Windows.Forms.Label()
        Me.lblFinanceStatus = New System.Windows.Forms.Label()
        Me.pnlSupplyChain = New System.Windows.Forms.Panel()
        Me.lblSupplyChainHead = New System.Windows.Forms.Label()
        Me.lblSupplyDate = New System.Windows.Forms.Label()
        Me.lblSupplyStatus = New System.Windows.Forms.Label()
        Me.pnlOperationDirector = New System.Windows.Forms.Panel()
        Me.lblApprovedby = New System.Windows.Forms.Label()
        Me.lblOperationDate = New System.Windows.Forms.Label()
        Me.lblOperationStatus = New System.Windows.Forms.Label()
        Me.pnlChiefEngineer = New System.Windows.Forms.Panel()
        Me.lbl_chief_OIC = New System.Windows.Forms.Label()
        Me.lblChiefDate = New System.Windows.Forms.Label()
        Me.lblChiefStatus = New System.Windows.Forms.Label()
        Me.pnlHeadSupervisor = New System.Windows.Forms.Panel()
        Me.lblcheckedByHeadSupervisor = New System.Windows.Forms.Label()
        Me.lblHeadDate = New System.Windows.Forms.Label()
        Me.lblHeadStatus = New System.Windows.Forms.Label()
        Me.lblApprovalTitle = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.pnlTitle.SuspendLayout()
        Me.pnlDetails.SuspendLayout()
        Me.grpMaterials.SuspendLayout()
        CType(Me.DataGridView_Mat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpWorkOrderDetails.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpAssignedPersonnel.SuspendLayout()
        Me.PanelApproval.SuspendLayout()
        Me.pnlFinance.SuspendLayout()
        Me.pnlSupplyChain.SuspendLayout()
        Me.pnlOperationDirector.SuspendLayout()
        Me.pnlChiefEngineer.SuspendLayout()
        Me.pnlHeadSupervisor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(1025, 51)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(364, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(241, 22)
        Me.lblTitle.TabIndex = 334
        Me.lblTitle.Text = "WORK ORDER PREVIEW"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDetails
        '
        Me.pnlDetails.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlDetails.Controls.Add(Me.grpMaterials)
        Me.pnlDetails.Controls.Add(Me.grpWorkOrderDetails)
        Me.pnlDetails.Controls.Add(Me.grpAssignedPersonnel)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetails.Location = New System.Drawing.Point(240, 51)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(785, 740)
        Me.pnlDetails.TabIndex = 352
        '
        'grpMaterials
        '
        Me.grpMaterials.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpMaterials.Controls.Add(Me.DataGridView_Mat)
        Me.grpMaterials.Controls.Add(Me.Label19)
        Me.grpMaterials.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpMaterials.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpMaterials.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.grpMaterials.Location = New System.Drawing.Point(0, 372)
        Me.grpMaterials.Name = "grpMaterials"
        Me.grpMaterials.Size = New System.Drawing.Size(785, 184)
        Me.grpMaterials.TabIndex = 426
        Me.grpMaterials.TabStop = False
        '
        'DataGridView_Mat
        '
        Me.DataGridView_Mat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Mat.Location = New System.Drawing.Point(8, 37)
        Me.DataGridView_Mat.Name = "DataGridView_Mat"
        Me.DataGridView_Mat.Size = New System.Drawing.Size(763, 137)
        Me.DataGridView_Mat.TabIndex = 423
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(3, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(779, 15)
        Me.Label19.TabIndex = 382
        Me.Label19.Text = "Materials"
        '
        'grpWorkOrderDetails
        '
        Me.grpWorkOrderDetails.Controls.Add(Me.Panel1)
        Me.grpWorkOrderDetails.Controls.Add(Me.CancelledRemarks)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label17)
        Me.grpWorkOrderDetails.Controls.Add(Me.CancelledBy)
        Me.grpWorkOrderDetails.Controls.Add(Me.DateCancelled)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label16)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label15)
        Me.grpWorkOrderDetails.Controls.Add(Me.Closeby)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label14)
        Me.grpWorkOrderDetails.Controls.Add(Me.DateClose)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label13)
        Me.grpWorkOrderDetails.Controls.Add(Me.CompletedBy)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label12)
        Me.grpWorkOrderDetails.Controls.Add(Me.DateCompleted)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label11)
        Me.grpWorkOrderDetails.Controls.Add(Me.DateRequested)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label10)
        Me.grpWorkOrderDetails.Controls.Add(Me.TxtWorkOrderNo)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label7)
        Me.grpWorkOrderDetails.Controls.Add(Me.txtSeverity)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label8)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label6)
        Me.grpWorkOrderDetails.Controls.Add(Me.txtWorkType)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label3)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label5)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label2)
        Me.grpWorkOrderDetails.Controls.Add(Me.Label1)
        Me.grpWorkOrderDetails.Controls.Add(Me.txthead)
        Me.grpWorkOrderDetails.Controls.Add(Me.txtDept)
        Me.grpWorkOrderDetails.Controls.Add(Me.txtreq)
        Me.grpWorkOrderDetails.Controls.Add(Me.txtDesc)
        Me.grpWorkOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpWorkOrderDetails.Location = New System.Drawing.Point(0, 0)
        Me.grpWorkOrderDetails.Name = "grpWorkOrderDetails"
        Me.grpWorkOrderDetails.Size = New System.Drawing.Size(785, 556)
        Me.grpWorkOrderDetails.TabIndex = 369
        Me.grpWorkOrderDetails.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(779, 17)
        Me.Panel1.TabIndex = 422
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(689, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 15)
        Me.Label18.TabIndex = 423
        Me.Label18.Text = "Status :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Location = New System.Drawing.Point(737, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 15)
        Me.lblStatus.TabIndex = 422
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(362, 17)
        Me.Label9.TabIndex = 402
        Me.Label9.Text = "WORK ORDER DETAILS"
        '
        'CancelledRemarks
        '
        Me.CancelledRemarks.BackColor = System.Drawing.Color.White
        Me.CancelledRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CancelledRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CancelledRemarks.ForeColor = System.Drawing.Color.Black
        Me.CancelledRemarks.Location = New System.Drawing.Point(568, 241)
        Me.CancelledRemarks.Multiline = True
        Me.CancelledRemarks.Name = "CancelledRemarks"
        Me.CancelledRemarks.ReadOnly = True
        Me.CancelledRemarks.Size = New System.Drawing.Size(198, 106)
        Me.CancelledRemarks.TabIndex = 419
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(450, 249)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 15)
        Me.Label17.TabIndex = 418
        Me.Label17.Text = "Cancelled Remarks"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CancelledBy
        '
        Me.CancelledBy.BackColor = System.Drawing.Color.White
        Me.CancelledBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CancelledBy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CancelledBy.ForeColor = System.Drawing.Color.Black
        Me.CancelledBy.Location = New System.Drawing.Point(567, 212)
        Me.CancelledBy.Name = "CancelledBy"
        Me.CancelledBy.ReadOnly = True
        Me.CancelledBy.Size = New System.Drawing.Size(198, 23)
        Me.CancelledBy.TabIndex = 417
        '
        'DateCancelled
        '
        Me.DateCancelled.BackColor = System.Drawing.Color.White
        Me.DateCancelled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateCancelled.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DateCancelled.ForeColor = System.Drawing.Color.Black
        Me.DateCancelled.Location = New System.Drawing.Point(567, 183)
        Me.DateCancelled.Name = "DateCancelled"
        Me.DateCancelled.ReadOnly = True
        Me.DateCancelled.Size = New System.Drawing.Size(198, 23)
        Me.DateCancelled.TabIndex = 416
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(450, 220)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 15)
        Me.Label16.TabIndex = 415
        Me.Label16.Text = "Cancelled By"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(450, 191)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 15)
        Me.Label15.TabIndex = 414
        Me.Label15.Text = "Date Cancelled"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Closeby
        '
        Me.Closeby.BackColor = System.Drawing.Color.White
        Me.Closeby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Closeby.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Closeby.ForeColor = System.Drawing.Color.Black
        Me.Closeby.Location = New System.Drawing.Point(567, 152)
        Me.Closeby.Name = "Closeby"
        Me.Closeby.ReadOnly = True
        Me.Closeby.Size = New System.Drawing.Size(198, 23)
        Me.Closeby.TabIndex = 413
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(450, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 412
        Me.Label14.Text = "Closed By"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateClose
        '
        Me.DateClose.BackColor = System.Drawing.Color.White
        Me.DateClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DateClose.ForeColor = System.Drawing.Color.Black
        Me.DateClose.Location = New System.Drawing.Point(567, 123)
        Me.DateClose.Name = "DateClose"
        Me.DateClose.ReadOnly = True
        Me.DateClose.Size = New System.Drawing.Size(198, 23)
        Me.DateClose.TabIndex = 411
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(450, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 15)
        Me.Label13.TabIndex = 410
        Me.Label13.Text = "Date Closed"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CompletedBy
        '
        Me.CompletedBy.BackColor = System.Drawing.Color.White
        Me.CompletedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompletedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CompletedBy.ForeColor = System.Drawing.Color.Black
        Me.CompletedBy.Location = New System.Drawing.Point(567, 93)
        Me.CompletedBy.Name = "CompletedBy"
        Me.CompletedBy.ReadOnly = True
        Me.CompletedBy.Size = New System.Drawing.Size(198, 23)
        Me.CompletedBy.TabIndex = 409
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(450, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 15)
        Me.Label12.TabIndex = 408
        Me.Label12.Text = "Completed By"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateCompleted
        '
        Me.DateCompleted.BackColor = System.Drawing.Color.White
        Me.DateCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateCompleted.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DateCompleted.ForeColor = System.Drawing.Color.Black
        Me.DateCompleted.Location = New System.Drawing.Point(567, 62)
        Me.DateCompleted.Name = "DateCompleted"
        Me.DateCompleted.ReadOnly = True
        Me.DateCompleted.Size = New System.Drawing.Size(198, 23)
        Me.DateCompleted.TabIndex = 407
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(450, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 15)
        Me.Label11.TabIndex = 406
        Me.Label11.Text = "Date Completed"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateRequested
        '
        Me.DateRequested.BackColor = System.Drawing.Color.White
        Me.DateRequested.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateRequested.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DateRequested.ForeColor = System.Drawing.Color.Black
        Me.DateRequested.Location = New System.Drawing.Point(128, 123)
        Me.DateRequested.Name = "DateRequested"
        Me.DateRequested.ReadOnly = True
        Me.DateRequested.Size = New System.Drawing.Size(198, 23)
        Me.DateRequested.TabIndex = 405
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(25, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 15)
        Me.Label10.TabIndex = 404
        Me.Label10.Text = "Date Requested"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtWorkOrderNo
        '
        Me.TxtWorkOrderNo.BackColor = System.Drawing.Color.White
        Me.TxtWorkOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtWorkOrderNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtWorkOrderNo.ForeColor = System.Drawing.Color.Black
        Me.TxtWorkOrderNo.Location = New System.Drawing.Point(128, 62)
        Me.TxtWorkOrderNo.Name = "TxtWorkOrderNo"
        Me.TxtWorkOrderNo.ReadOnly = True
        Me.TxtWorkOrderNo.Size = New System.Drawing.Size(198, 23)
        Me.TxtWorkOrderNo.TabIndex = 403
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(25, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 15)
        Me.Label7.TabIndex = 400
        Me.Label7.Text = "Work order Type"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSeverity
        '
        Me.txtSeverity.BackColor = System.Drawing.Color.White
        Me.txtSeverity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeverity.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtSeverity.ForeColor = System.Drawing.Color.Black
        Me.txtSeverity.Location = New System.Drawing.Point(128, 332)
        Me.txtSeverity.Name = "txtSeverity"
        Me.txtSeverity.ReadOnly = True
        Me.txtSeverity.Size = New System.Drawing.Size(288, 23)
        Me.txtSeverity.TabIndex = 399
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(25, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 15)
        Me.Label8.TabIndex = 396
        Me.Label8.Text = "Work order no. "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(25, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 395
        Me.Label6.Text = "Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWorkType
        '
        Me.txtWorkType.BackColor = System.Drawing.Color.White
        Me.txtWorkType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtWorkType.ForeColor = System.Drawing.Color.Black
        Me.txtWorkType.Location = New System.Drawing.Point(128, 303)
        Me.txtWorkType.Name = "txtWorkType"
        Me.txtWorkType.ReadOnly = True
        Me.txtWorkType.Size = New System.Drawing.Size(288, 23)
        Me.txtWorkType.TabIndex = 398
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(25, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 394
        Me.Label3.Text = "Department"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(25, 349)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 397
        Me.Label5.Text = "Severity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(25, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 393
        Me.Label2.Text = "Head Supervisor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(25, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 392
        Me.Label1.Text = "Requestor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txthead
        '
        Me.txthead.BackColor = System.Drawing.Color.White
        Me.txthead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txthead.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txthead.ForeColor = System.Drawing.Color.Black
        Me.txthead.Location = New System.Drawing.Point(128, 191)
        Me.txthead.Name = "txthead"
        Me.txthead.ReadOnly = True
        Me.txthead.Size = New System.Drawing.Size(288, 23)
        Me.txthead.TabIndex = 391
        '
        'txtDept
        '
        Me.txtDept.BackColor = System.Drawing.Color.White
        Me.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDept.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtDept.ForeColor = System.Drawing.Color.Black
        Me.txtDept.Location = New System.Drawing.Point(128, 160)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(288, 23)
        Me.txtDept.TabIndex = 390
        '
        'txtreq
        '
        Me.txtreq.BackColor = System.Drawing.Color.White
        Me.txtreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtreq.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtreq.ForeColor = System.Drawing.Color.Black
        Me.txtreq.Location = New System.Drawing.Point(128, 93)
        Me.txtreq.Name = "txtreq"
        Me.txtreq.ReadOnly = True
        Me.txtreq.Size = New System.Drawing.Size(288, 23)
        Me.txtreq.TabIndex = 389
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.Color.White
        Me.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtDesc.ForeColor = System.Drawing.Color.Black
        Me.txtDesc.Location = New System.Drawing.Point(128, 226)
        Me.txtDesc.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(288, 68)
        Me.txtDesc.TabIndex = 387
        '
        'grpAssignedPersonnel
        '
        Me.grpAssignedPersonnel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpAssignedPersonnel.Controls.Add(Me.Label4)
        Me.grpAssignedPersonnel.Controls.Add(Me.txtPersonAssigned)
        Me.grpAssignedPersonnel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpAssignedPersonnel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpAssignedPersonnel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.grpAssignedPersonnel.Location = New System.Drawing.Point(0, 556)
        Me.grpAssignedPersonnel.Name = "grpAssignedPersonnel"
        Me.grpAssignedPersonnel.Size = New System.Drawing.Size(785, 184)
        Me.grpAssignedPersonnel.TabIndex = 368
        Me.grpAssignedPersonnel.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(764, 15)
        Me.Label4.TabIndex = 382
        Me.Label4.Text = "ASSIGNED PERSONNEL"
        '
        'txtPersonAssigned
        '
        Me.txtPersonAssigned.BackColor = System.Drawing.Color.White
        Me.txtPersonAssigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPersonAssigned.ForeColor = System.Drawing.Color.Black
        Me.txtPersonAssigned.Location = New System.Drawing.Point(6, 40)
        Me.txtPersonAssigned.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPersonAssigned.Multiline = True
        Me.txtPersonAssigned.Name = "txtPersonAssigned"
        Me.txtPersonAssigned.ReadOnly = True
        Me.txtPersonAssigned.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPersonAssigned.Size = New System.Drawing.Size(764, 129)
        Me.txtPersonAssigned.TabIndex = 381
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Print.png")
        '
        'PanelApproval
        '
        Me.PanelApproval.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.PanelApproval.Controls.Add(Me.btnViewDelayedSummary)
        Me.PanelApproval.Controls.Add(Me.btnPrintPreview)
        Me.PanelApproval.Controls.Add(Me.pnlFinance)
        Me.PanelApproval.Controls.Add(Me.pnlSupplyChain)
        Me.PanelApproval.Controls.Add(Me.pnlOperationDirector)
        Me.PanelApproval.Controls.Add(Me.pnlChiefEngineer)
        Me.PanelApproval.Controls.Add(Me.pnlHeadSupervisor)
        Me.PanelApproval.Controls.Add(Me.lblApprovalTitle)
        Me.PanelApproval.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelApproval.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelApproval.Location = New System.Drawing.Point(0, 51)
        Me.PanelApproval.Name = "PanelApproval"
        Me.PanelApproval.Size = New System.Drawing.Size(240, 740)
        Me.PanelApproval.TabIndex = 353
        '
        'btnViewDelayedSummary
        '
        Me.btnViewDelayedSummary.Location = New System.Drawing.Point(12, 545)
        Me.btnViewDelayedSummary.Name = "btnViewDelayedSummary"
        Me.btnViewDelayedSummary.Size = New System.Drawing.Size(218, 45)
        Me.btnViewDelayedSummary.TabIndex = 384
        Me.btnViewDelayedSummary.Text = "View Aging Summary"
        Me.btnViewDelayedSummary.UseVisualStyleBackColor = True
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.ImageKey = "Print.png"
        Me.btnPrintPreview.ImageList = Me.ImageList1
        Me.btnPrintPreview.Location = New System.Drawing.Point(12, 605)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(218, 95)
        Me.btnPrintPreview.TabIndex = 383
        Me.btnPrintPreview.Text = "Print Preview"
        Me.btnPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintPreview.UseVisualStyleBackColor = True
        '
        'pnlFinance
        '
        Me.pnlFinance.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.pnlFinance.Controls.Add(Me.lblFinanceManager)
        Me.pnlFinance.Controls.Add(Me.lblFinanceDate)
        Me.pnlFinance.Controls.Add(Me.lblFinanceStatus)
        Me.pnlFinance.Location = New System.Drawing.Point(10, 449)
        Me.pnlFinance.Name = "pnlFinance"
        Me.pnlFinance.Size = New System.Drawing.Size(220, 79)
        Me.pnlFinance.TabIndex = 5
        '
        'lblFinanceManager
        '
        Me.lblFinanceManager.AutoSize = True
        Me.lblFinanceManager.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinanceManager.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblFinanceManager.Location = New System.Drawing.Point(10, 35)
        Me.lblFinanceManager.Name = "lblFinanceManager"
        Me.lblFinanceManager.Size = New System.Drawing.Size(107, 13)
        Me.lblFinanceManager.TabIndex = 5
        Me.lblFinanceManager.Text = "lblFinanceManager"
        '
        'lblFinanceDate
        '
        Me.lblFinanceDate.AutoSize = True
        Me.lblFinanceDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinanceDate.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblFinanceDate.Location = New System.Drawing.Point(10, 56)
        Me.lblFinanceDate.Name = "lblFinanceDate"
        Me.lblFinanceDate.Size = New System.Drawing.Size(117, 13)
        Me.lblFinanceDate.TabIndex = 2
        Me.lblFinanceDate.Text = "05/25/2026 10:15 AM"
        '
        'lblFinanceStatus
        '
        Me.lblFinanceStatus.AutoSize = True
        Me.lblFinanceStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinanceStatus.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblFinanceStatus.Location = New System.Drawing.Point(10, 10)
        Me.lblFinanceStatus.Name = "lblFinanceStatus"
        Me.lblFinanceStatus.Size = New System.Drawing.Size(112, 15)
        Me.lblFinanceStatus.TabIndex = 0
        Me.lblFinanceStatus.Text = "✓ Finance Director"
        '
        'pnlSupplyChain
        '
        Me.pnlSupplyChain.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.pnlSupplyChain.Controls.Add(Me.lblSupplyChainHead)
        Me.pnlSupplyChain.Controls.Add(Me.lblSupplyDate)
        Me.pnlSupplyChain.Controls.Add(Me.lblSupplyStatus)
        Me.pnlSupplyChain.Location = New System.Drawing.Point(10, 353)
        Me.pnlSupplyChain.Name = "pnlSupplyChain"
        Me.pnlSupplyChain.Size = New System.Drawing.Size(220, 79)
        Me.pnlSupplyChain.TabIndex = 4
        '
        'lblSupplyChainHead
        '
        Me.lblSupplyChainHead.AutoSize = True
        Me.lblSupplyChainHead.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplyChainHead.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblSupplyChainHead.Location = New System.Drawing.Point(10, 32)
        Me.lblSupplyChainHead.Name = "lblSupplyChainHead"
        Me.lblSupplyChainHead.Size = New System.Drawing.Size(113, 13)
        Me.lblSupplyChainHead.TabIndex = 4
        Me.lblSupplyChainHead.Text = "lblSupplyChainHead"
        '
        'lblSupplyDate
        '
        Me.lblSupplyDate.AutoSize = True
        Me.lblSupplyDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplyDate.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblSupplyDate.Location = New System.Drawing.Point(10, 52)
        Me.lblSupplyDate.Name = "lblSupplyDate"
        Me.lblSupplyDate.Size = New System.Drawing.Size(117, 13)
        Me.lblSupplyDate.TabIndex = 2
        Me.lblSupplyDate.Text = "05/25/2026 10:15 AM"
        '
        'lblSupplyStatus
        '
        Me.lblSupplyStatus.AutoSize = True
        Me.lblSupplyStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplyStatus.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblSupplyStatus.Location = New System.Drawing.Point(10, 10)
        Me.lblSupplyStatus.Name = "lblSupplyStatus"
        Me.lblSupplyStatus.Size = New System.Drawing.Size(122, 15)
        Me.lblSupplyStatus.TabIndex = 0
        Me.lblSupplyStatus.Text = "✓ Supply Chain Head"
        '
        'pnlOperationDirector
        '
        Me.pnlOperationDirector.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.pnlOperationDirector.Controls.Add(Me.lblApprovedby)
        Me.pnlOperationDirector.Controls.Add(Me.lblOperationDate)
        Me.pnlOperationDirector.Controls.Add(Me.lblOperationStatus)
        Me.pnlOperationDirector.Location = New System.Drawing.Point(10, 255)
        Me.pnlOperationDirector.Name = "pnlOperationDirector"
        Me.pnlOperationDirector.Size = New System.Drawing.Size(220, 79)
        Me.pnlOperationDirector.TabIndex = 3
        '
        'lblApprovedby
        '
        Me.lblApprovedby.AutoSize = True
        Me.lblApprovedby.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedby.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblApprovedby.Location = New System.Drawing.Point(10, 30)
        Me.lblApprovedby.Name = "lblApprovedby"
        Me.lblApprovedby.Size = New System.Drawing.Size(85, 13)
        Me.lblApprovedby.TabIndex = 3
        Me.lblApprovedby.Text = "lblApprovedby"
        '
        'lblOperationDate
        '
        Me.lblOperationDate.AutoSize = True
        Me.lblOperationDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperationDate.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblOperationDate.Location = New System.Drawing.Point(10, 52)
        Me.lblOperationDate.Name = "lblOperationDate"
        Me.lblOperationDate.Size = New System.Drawing.Size(117, 13)
        Me.lblOperationDate.TabIndex = 2
        Me.lblOperationDate.Text = "05/25/2026 10:15 AM"
        '
        'lblOperationStatus
        '
        Me.lblOperationStatus.AutoSize = True
        Me.lblOperationStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperationStatus.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblOperationStatus.Location = New System.Drawing.Point(10, 10)
        Me.lblOperationStatus.Name = "lblOperationStatus"
        Me.lblOperationStatus.Size = New System.Drawing.Size(126, 15)
        Me.lblOperationStatus.TabIndex = 0
        Me.lblOperationStatus.Text = "✓ Operation Director"
        '
        'pnlChiefEngineer
        '
        Me.pnlChiefEngineer.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.pnlChiefEngineer.Controls.Add(Me.lbl_chief_OIC)
        Me.pnlChiefEngineer.Controls.Add(Me.lblChiefDate)
        Me.pnlChiefEngineer.Controls.Add(Me.lblChiefStatus)
        Me.pnlChiefEngineer.Location = New System.Drawing.Point(10, 158)
        Me.pnlChiefEngineer.Name = "pnlChiefEngineer"
        Me.pnlChiefEngineer.Size = New System.Drawing.Size(220, 79)
        Me.pnlChiefEngineer.TabIndex = 2
        '
        'lbl_chief_OIC
        '
        Me.lbl_chief_OIC.AutoSize = True
        Me.lbl_chief_OIC.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_chief_OIC.ForeColor = System.Drawing.Color.Gainsboro
        Me.lbl_chief_OIC.Location = New System.Drawing.Point(12, 32)
        Me.lbl_chief_OIC.Name = "lbl_chief_OIC"
        Me.lbl_chief_OIC.Size = New System.Drawing.Size(73, 13)
        Me.lbl_chief_OIC.TabIndex = 3
        Me.lbl_chief_OIC.Text = "lbl_chief_OIC"
        '
        'lblChiefDate
        '
        Me.lblChiefDate.AutoSize = True
        Me.lblChiefDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiefDate.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblChiefDate.Location = New System.Drawing.Point(10, 52)
        Me.lblChiefDate.Name = "lblChiefDate"
        Me.lblChiefDate.Size = New System.Drawing.Size(117, 13)
        Me.lblChiefDate.TabIndex = 2
        Me.lblChiefDate.Text = "05/25/2026 10:15 AM"
        '
        'lblChiefStatus
        '
        Me.lblChiefStatus.AutoSize = True
        Me.lblChiefStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiefStatus.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblChiefStatus.Location = New System.Drawing.Point(10, 10)
        Me.lblChiefStatus.Name = "lblChiefStatus"
        Me.lblChiefStatus.Size = New System.Drawing.Size(124, 15)
        Me.lblChiefStatus.TabIndex = 0
        Me.lblChiefStatus.Text = "✓ Chief OIC Engineer"
        '
        'pnlHeadSupervisor
        '
        Me.pnlHeadSupervisor.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.pnlHeadSupervisor.Controls.Add(Me.lblcheckedByHeadSupervisor)
        Me.pnlHeadSupervisor.Controls.Add(Me.lblHeadDate)
        Me.pnlHeadSupervisor.Controls.Add(Me.lblHeadStatus)
        Me.pnlHeadSupervisor.Location = New System.Drawing.Point(10, 60)
        Me.pnlHeadSupervisor.Name = "pnlHeadSupervisor"
        Me.pnlHeadSupervisor.Size = New System.Drawing.Size(220, 79)
        Me.pnlHeadSupervisor.TabIndex = 1
        '
        'lblcheckedByHeadSupervisor
        '
        Me.lblcheckedByHeadSupervisor.AutoSize = True
        Me.lblcheckedByHeadSupervisor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcheckedByHeadSupervisor.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblcheckedByHeadSupervisor.Location = New System.Drawing.Point(12, 30)
        Me.lblcheckedByHeadSupervisor.Name = "lblcheckedByHeadSupervisor"
        Me.lblcheckedByHeadSupervisor.Size = New System.Drawing.Size(157, 13)
        Me.lblcheckedByHeadSupervisor.TabIndex = 4
        Me.lblcheckedByHeadSupervisor.Text = "lblcheckedByHeadSupervisor"
        '
        'lblHeadDate
        '
        Me.lblHeadDate.AutoSize = True
        Me.lblHeadDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadDate.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblHeadDate.Location = New System.Drawing.Point(10, 50)
        Me.lblHeadDate.Name = "lblHeadDate"
        Me.lblHeadDate.Size = New System.Drawing.Size(117, 13)
        Me.lblHeadDate.TabIndex = 2
        Me.lblHeadDate.Text = "05/25/2026 10:15 AM"
        '
        'lblHeadStatus
        '
        Me.lblHeadStatus.AutoSize = True
        Me.lblHeadStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadStatus.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblHeadStatus.Location = New System.Drawing.Point(10, 10)
        Me.lblHeadStatus.Name = "lblHeadStatus"
        Me.lblHeadStatus.Size = New System.Drawing.Size(170, 15)
        Me.lblHeadStatus.TabIndex = 0
        Me.lblHeadStatus.Text = "✓ Head Supervisor Approved"
        '
        'lblApprovalTitle
        '
        Me.lblApprovalTitle.AutoSize = True
        Me.lblApprovalTitle.ForeColor = System.Drawing.Color.White
        Me.lblApprovalTitle.Location = New System.Drawing.Point(45, 23)
        Me.lblApprovalTitle.Name = "lblApprovalTitle"
        Me.lblApprovalTitle.Size = New System.Drawing.Size(134, 20)
        Me.lblApprovalTitle.TabIndex = 0
        Me.lblApprovalTitle.Text = "APPROVAL STATUS"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1025, 791)
        Me.Controls.Add(Me.pnlDetails)
        Me.Controls.Add(Me.PanelApproval)
        Me.Controls.Add(Me.pnlTitle)
        Me.Location = New System.Drawing.Point(1041, 830)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1041, 830)
        Me.MinimizeBox = False
        Me.Name = "Preview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preview"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlDetails.ResumeLayout(False)
        Me.grpMaterials.ResumeLayout(False)
        CType(Me.DataGridView_Mat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpWorkOrderDetails.ResumeLayout(False)
        Me.grpWorkOrderDetails.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpAssignedPersonnel.ResumeLayout(False)
        Me.grpAssignedPersonnel.PerformLayout()
        Me.PanelApproval.ResumeLayout(False)
        Me.PanelApproval.PerformLayout()
        Me.pnlFinance.ResumeLayout(False)
        Me.pnlFinance.PerformLayout()
        Me.pnlSupplyChain.ResumeLayout(False)
        Me.pnlSupplyChain.PerformLayout()
        Me.pnlOperationDirector.ResumeLayout(False)
        Me.pnlOperationDirector.PerformLayout()
        Me.pnlChiefEngineer.ResumeLayout(False)
        Me.pnlChiefEngineer.PerformLayout()
        Me.pnlHeadSupervisor.ResumeLayout(False)
        Me.pnlHeadSupervisor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents grpWorkOrderDetails As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSeverity As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtWorkType As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txthead As TextBox
    Friend WithEvents txtDept As TextBox
    Friend WithEvents txtreq As TextBox
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents grpAssignedPersonnel As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPersonAssigned As TextBox
    Friend WithEvents PanelApproval As Panel
    Friend WithEvents pnlFinance As Panel
    Friend WithEvents lblFinanceDate As Label
    Friend WithEvents lblFinanceStatus As Label
    Friend WithEvents pnlSupplyChain As Panel
    Friend WithEvents lblSupplyDate As Label
    Friend WithEvents lblSupplyStatus As Label
    Friend WithEvents pnlOperationDirector As Panel
    Friend WithEvents lblOperationDate As Label
    Friend WithEvents lblOperationStatus As Label
    Friend WithEvents pnlChiefEngineer As Panel
    Friend WithEvents lblChiefDate As Label
    Friend WithEvents lblChiefStatus As Label
    Friend WithEvents pnlHeadSupervisor As Panel
    Friend WithEvents lblHeadDate As Label
    Friend WithEvents lblHeadStatus As Label
    Friend WithEvents lblApprovalTitle As Label
    Friend WithEvents TxtWorkOrderNo As TextBox
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents CompletedBy As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DateCompleted As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents DateRequested As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CancelledBy As TextBox
    Friend WithEvents DateCancelled As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Closeby As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents DateClose As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents lblcheckedByHeadSupervisor As Label
    Friend WithEvents lbl_chief_OIC As Label
    Friend WithEvents lblApprovedby As Label
    Friend WithEvents lblFinanceManager As Label
    Friend WithEvents lblSupplyChainHead As Label
    Friend WithEvents CancelledRemarks As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents grpMaterials As GroupBox
    Friend WithEvents DataGridView_Mat As DataGridView
    Friend WithEvents Label19 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnViewDelayedSummary As Button
End Class
