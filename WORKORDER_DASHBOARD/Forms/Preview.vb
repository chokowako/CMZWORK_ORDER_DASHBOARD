Imports System.Data.SqlClient
Imports System.Data

Public Class Preview


    Private HeadStatus As String
    Private Headby As String
    Private HeadPosition As String
    Private HeadDate As String

    Private ChiefStatus As String
    Private Chiefby As String
    Private ChiefPosition As String
    Private ChiefDate As String

    Private OperationStatus As String
    Private Operationby As String
    Private OperationPosition As String
    Private OperationDate As String

    Private SupplyStatus As String
    Private Supplyby As String
    Private SupplyPosition As String
    Private SupplyDate As String

    Private FinanceStatus As String
    Private Financeby As String
    Private FinancePosition As String
    Private FinanceDate As String

    'Private IsMaterialsNeeded As Boolean
    Private IsPORequired As Boolean
    Private MaterialsDecision As String = ""
    Private isMaterialsYes As Boolean = False
    Private IsSupplyChainRequired As Boolean = False


    Private Sub Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CenterTitle()

        LoadApprovalStatus(TxtWorkOrderNo.Text)

        LoadWorkOrderDetails(TxtWorkOrderNo.Text)

        UpdateWorkflowStatus()

        LoadMaterials(TxtWorkOrderNo.Text)


        lblHeadDate.Text = HeadDate
        lblcheckedByHeadSupervisor.Text = Headby

        lbl_chief_OIC.Text = Chiefby
        lblChiefDate.Text = ChiefDate

        lblApprovedby.Text = Operationby
        lblOperationDate.Text = OperationDate

        lblFinanceManager.Text = Financeby
        lblFinanceDate.Text = FinanceDate
    End Sub

    Private Sub CenterTitle()
        lblTitle.Left = (Me.ClientSize.Width - lblTitle.Width) \ 2
        lblTitle.Top = 10
    End Sub
    Private Sub Preview_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterTitle()
    End Sub
    Private Sub ReadOnlyTextBox_Enter(sender As Object, e As EventArgs)
        Me.ActiveControl = Nothing
    End Sub

    Private Sub LoadApprovalStatus(workOrderNo As String)

        Dim sql As String = "
    SELECT 

        HeadSupervisorStatus,
        HeadSupervisor,
        HeadSuperVisorTimeAndDateApprove,

        Notedby1Status,
        Notedby1,
        Notedby1TimeAndDate,

        ApprovedByStatus,
        ApprovedBy,
        ApprovedByTimeAndDate,

        ApprovedForReleaseByStatus,
        ApprovedForReleaseBy,
        ApprovedForReleaseByTimeAndDate,

        PR_ApproveToPurchaseByFM_Flag,
	    PR_ApproveToPurchaseByFM,
        PR_ApproveToPurchaseByFMDateAndTime

    FROM WorkOrderForm
    WHERE Pk_WorkOrderNo = @WorkOrderNo"

        Using conn As New SqlConnection(connStr)
            Using cmd As New SqlCommand(sql, conn)

                cmd.Parameters.AddWithValue("@WorkOrderNo", workOrderNo)

                conn.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then

                        HeadStatus = dr("HeadSupervisorStatus").ToString()
                        Headby = If(IsDBNull(dr("HeadSupervisor")), "", dr("HeadSupervisor").ToString())
                        HeadPosition = GetPosition(Headby)
                        HeadDate = If(IsDBNull(dr("HeadSuperVisorTimeAndDateApprove")), "", Convert.ToDateTime(dr("HeadSuperVisorTimeAndDateApprove")).ToString("MMM dd, yyyy hh:mm tt"))

                        ChiefStatus = dr("Notedby1Status").ToString()
                        Chiefby = If(IsDBNull(dr("Notedby1")), "", dr("Notedby1").ToString())
                        ChiefPosition = GetPosition(Chiefby)
                        ChiefDate = If(IsDBNull(dr("Notedby1TimeAndDate")), "", Convert.ToDateTime(dr("Notedby1TimeAndDate")).ToString("MMM dd, yyyy hh:mm tt"))

                        OperationStatus = dr("ApprovedByStatus").ToString()
                        Operationby = If(IsDBNull(dr("ApprovedBy")), "", dr("ApprovedBy").ToString())
                        OperationPosition = GetPosition(Operationby)
                        OperationDate = If(IsDBNull(dr("ApprovedByTimeAndDate")), "", Convert.ToDateTime(dr("ApprovedByTimeAndDate")).ToString("MMM dd, yyyy hh:mm tt"))

                        SupplyStatus = dr("ApprovedForReleaseByStatus").ToString()
                        Supplyby = If(IsDBNull(dr("ApprovedForReleaseBy")), "", dr("ApprovedForReleaseBy").ToString())
                        SupplyPosition = GetPosition(Supplyby)
                        SupplyDate = If(IsDBNull(dr("ApprovedForReleaseByTimeAndDate")), "", Convert.ToDateTime(dr("ApprovedForReleaseByTimeAndDate")).ToString("MMM dd, yyyy hh:mm tt"))

                        FinanceStatus = dr("PR_ApproveToPurchaseByFM_Flag").ToString()
                        Financeby = If(IsDBNull(dr("PR_ApproveToPurchaseByFM")), "", dr("PR_ApproveToPurchaseByFM").ToString())
                        FinancePosition = GetPosition(Financeby)
                        FinanceDate = If(IsDBNull(dr("PR_ApproveToPurchaseByFMDateAndTime")), "", Convert.ToDateTime(dr("PR_ApproveToPurchaseByFMDateAndTime")).ToString("MMM dd, yyyy hh:mm tt"))

                    End If
                End Using

            End Using
        End Using
    End Sub

    Private Function GetPosition(fullname As String) As String

        Dim position As String = ""
        Try

            Using conn As New SqlConnection(connStr)

                Dim sql As String =
                "SELECT Position
                 FROM UserAccount
                 WHERE Fullname = @Fullname"

                Using cmd As New SqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@Fullname", fullname)

                    conn.Open()

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        position = result.ToString()
                    End If

                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return position

    End Function
    Private Sub UpdateWorkflowStatus()


        lblSupplyChainHead.Text = ""
        lblSupplyDate.Text = ""

        lblFinanceManager.Text = ""
        lblFinanceDate.Text = ""


        ' ========================
        ' RESET ALL
        ' ========================
        SetApprovalStatus(lblHeadStatus, HeadPosition, "WAITING")
        SetApprovalStatus(lblChiefStatus, ChiefPosition, "WAITING")
        SetApprovalStatus(lblOperationStatus, OperationPosition, "WAITING")
        SetApprovalStatus(lblSupplyStatus, SupplyPosition, "WAITING")
        SetApprovalStatus(lblFinanceStatus, FinancePosition, "WAITING")

        ' ========================
        ' HEAD SUPERVISOR
        ' ========================
        If HeadStatus <> "APPROVED" AndAlso HeadStatus <> "CHECKED" AndAlso HeadStatus <> "1" Then
            SetApprovalStatus(lblHeadStatus, HeadPosition, "PENDING")
            Exit Sub
        End If

        SetApprovalStatus(lblHeadStatus, HeadPosition, "APPROVED")

        ' ========================
        ' CHIEF ENGINEER
        ' ========================
        If ChiefStatus <> "APPROVED" AndAlso ChiefStatus <> "1" Then
            SetApprovalStatus(lblChiefStatus, ChiefPosition, "PENDING")
            Exit Sub
        End If

        SetApprovalStatus(lblChiefStatus, ChiefPosition, "APPROVED")

        ' ========================
        ' OPERATION DIRECTOR
        ' ========================
        If OperationStatus <> "APPROVED" AndAlso OperationStatus <> "1" Then
            SetApprovalStatus(lblOperationStatus, OperationPosition, "PENDING")
            Exit Sub
        End If

        SetApprovalStatus(lblOperationStatus, OperationPosition, "APPROVED")




        ' ========================
        ' SUPPLY CHAIN
        ' ========================

        '1. HARD STOP: NO MATERIALS NEEDED
        If MaterialsDecision = "NO" OrElse MaterialsDecision = "0" OrElse MaterialsDecision = "" Then

            SetApprovalStatus(lblSupplyStatus, "Supply Chain", "NOT REQUIRED")

            lblSupplyChainHead.Text = "⛔ Supply Chain (No Materials Required)"
            lblSupplyDate.Text = ""

            Exit Sub
        End If

        '2. CHECK IF SC IS REQUIRED (based on materials list)
        If Not IsSupplyChainRequired Then

            SetApprovalStatus(lblSupplyStatus, "Supply Chain", "NOT REQUIRED")

            lblSupplyChainHead.Text = "⛔ Supply Chain (Not Applicable)"
            lblSupplyDate.Text = ""

            Exit Sub
        End If


        '3. VALID SUPPLY CHAIN FLOW
        lblSupplyChainHead.Text = If(String.IsNullOrEmpty(Supplyby), "PENDING", Supplyby)
        lblSupplyDate.Text = SupplyDate

        If SupplyStatus = "APPROVED" OrElse SupplyStatus = "1" Then

            SetApprovalStatus(lblSupplyStatus, SupplyPosition, "APPROVED")

        Else

            SetApprovalStatus(lblSupplyStatus, SupplyPosition, "PENDING")

            Exit Sub

        End If




        ' ========================
        ' FINANCE (ONLY IF PO REQUIRED)
        ' ========================
        If Not IsPORequired Then

            SetApprovalStatus(lblFinanceStatus, FinancePosition, "NOT REQUIRED")
            lblFinanceStatus.ForeColor = Color.Gray
            lblFinanceStatus.Text = "⛔ Finance (No PO Required)"

            Exit Sub

        End If

        If FinanceStatus = "1" Or FinanceStatus = "APPROVED" Then
            SetApprovalStatus(lblFinanceStatus, FinancePosition, "APPROVED")
        Else
            SetApprovalStatus(lblFinanceStatus, FinancePosition, "PENDING")
            Exit Sub
        End If

    End Sub


    ' =========================================================
    ' MAIN FUNCTION: SET APPROVAL DISPLAY
    ' =========================================================
    Private Sub SetApprovalStatus(lbl As Label,
                              approverName As String,
                              status As String)

        Dim s As String = If(status, "").Trim().ToUpper()

        Select Case s

            Case "APPROVED", "CHECKED", "1"
                lbl.Text = "✔ " & approverName
                lbl.ForeColor = Color.LimeGreen

            Case "PENDING"
                lbl.Text = "⏳ " & approverName
                lbl.ForeColor = Color.Goldenrod

            Case Else
                lbl.Text = "⌛ " & approverName
                lbl.ForeColor = Color.Silver

        End Select
    End Sub



    Private Sub LoadWorkOrderDetails(workOrderNo As String)
        Try
            Dim sql As String = "
        SELECT
            w.RequestedBy,
            w.RegistryDate,
            w.Unit_Section,
            w.HeadSupervisor,
            w.Work_Description,
            w.IsMaterialsNeeded,
            w.PO_Acknowledge_Flag,

            CASE
                WHEN w.isCorrectiveMaintenance = 1 THEN 'Corrective Maintenance'
                WHEN w.isFacilitiesMaintenance = 1 THEN 'Facilities Maintenance'
                WHEN w.isPreventiveMaintenance = 1 THEN 'Preventive Maintenance'
                WHEN w.isProjectManagement = 1 THEN 'Project Management'
                ELSE 'N/A'
            END AS WorkOrderType,

            ISNULL(st.SeverityName, 'N/A') AS SeverityType,

            w.Status,
            w.CompleteStatusDateAndTime,
            w.TagAsCompleteBy,
            w.CloseStatusDateAndTime,
            w.TagAsCloseBy,
            w.CancelDate,
            w.CancelBy,
            w.CancelRemarks,

            ISNULL(
                STUFF(
                    (
                        SELECT CHAR(13) + CHAR(10) +
                               pa.Fullname + ' - ' +
                               pa.Position + ' - ' +
                               pa.ContactNo
                        FROM PersonAssigned pa
                        WHERE pa.Pk_WorkOrderNo = w.Pk_WorkOrderNo
                        FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)')
                ,1,2,'')
            ,'Unassigned') AS AssignedPersonnel

        FROM WorkOrderForm w
        LEFT JOIN SeverityType st
            ON w.SeverityType = st.SeverityTypeID
        WHERE w.Pk_WorkOrderNo = @WorkOrderNo"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@WorkOrderNo", workOrderNo)
                    conn.Open()

                    Using dr As SqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            txtreq.Text = dr("RequestedBy").ToString()
                            DateRequested.Text = dr("RegistryDate").ToString()
                            txtDept.Text = dr("Unit_Section").ToString()
                            txthead.Text = dr("HeadSupervisor").ToString()
                            txtDesc.Text = dr("Work_Description").ToString()
                            txtWorkType.Text = dr("WorkOrderType").ToString()
                            txtSeverity.Text = dr("SeverityType").ToString()

                            lblStatus.Text = dr("Status").ToString()

                            DateCompleted.Text = If(IsDBNull(dr("CompleteStatusDateAndTime")), "", dr("CompleteStatusDateAndTime").ToString())
                            If DateCompleted.Text.ToUpper() = "PENDING" Then DateCompleted.Text = ""

                            CompletedBy.Text = If(IsDBNull(dr("TagAsCompleteBy")), "", dr("TagAsCompleteBy").ToString())
                            If CompletedBy.Text.ToUpper() = "PENDING" Then CompletedBy.Text = ""

                            DateClose.Text = If(IsDBNull(dr("CloseStatusDateAndTime")), "", dr("CloseStatusDateAndTime").ToString())
                            If DateClose.Text.ToUpper() = "PENDING" Then DateClose.Text = ""

                            Closeby.Text = If(IsDBNull(dr("TagAsCloseBy")), "", dr("TagAsCloseBy").ToString())
                            If Closeby.Text.ToUpper() = "PENDING" Then Closeby.Text = ""

                            DateCancelled.Text = If(IsDBNull(dr("CancelDate")), "", dr("CancelDate").ToString())
                            If DateCancelled.Text.ToUpper() = "PENDING" Then DateCancelled.Text = ""

                            CancelledBy.Text = If(IsDBNull(dr("CancelBy")), "", dr("CancelBy").ToString())
                            If CancelledBy.Text.ToUpper() = "PENDING" Then CancelledBy.Text = ""

                            CancelledRemarks.Text = If(IsDBNull(dr("CancelRemarks")), "", dr("CancelRemarks").ToString())
                            If CancelledRemarks.Text.ToUpper() = "PENDING" Then CancelledRemarks.Text = ""

                            txtPersonAssigned.Text = dr("AssignedPersonnel").ToString()

                            '========================
                            ' MATERIALS DECISION
                            '========================
                            Dim rawMat As String = If(IsDBNull(dr("IsMaterialsNeeded")), "", dr("IsMaterialsNeeded").ToString())
                            MaterialsDecision = rawMat.Trim().ToUpper()

                            isMaterialsYes = (MaterialsDecision = "YES" OrElse MaterialsDecision = "1" OrElse MaterialsDecision = "TRUE")

                            '========================
                            ' PO FLAG
                            '========================
                            Dim poFlag As String = If(IsDBNull(dr("PO_Acknowledge_Flag")), "", dr("PO_Acknowledge_Flag").ToString().Trim().ToUpper())
                            IsPORequired = (poFlag = "1" OrElse poFlag = "TRUE" OrElse poFlag = "YES" OrElse poFlag = "APPROVED")

                            '========================
                            ' CHECK SC MATERIALS (SUPPLY CHAIN RULE)
                            '========================
                            IsSupplyChainRequired = False

                            Using conn2 As New SqlConnection(connStr)

                                Dim sqlSC As String = "
                                SELECT COUNT(*)
                                FROM RequestedMaterials
                                WHERE Pk_WorkOrderNo = @WorkOrderNo
                                  AND StockSource = 'SC'"

                                Using cmd2 As New SqlCommand(sqlSC, conn2)
                                    cmd2.Parameters.AddWithValue("@WorkOrderNo", workOrderNo)
                                    conn2.Open()

                                    Dim scCount As Integer = Convert.ToInt32(cmd2.ExecuteScalar())
                                    IsSupplyChainRequired = (scCount > 0)

                                End Using
                            End Using

                        Else
                            MessageBox.Show("Work Order not found.", "Preview", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading work order details: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadMaterials(workOrderNo As String)

        Try

            Dim dt As New DataTable()

            Using conn As New SqlConnection(connStr)

                Dim sql As String = "
            SELECT
                ItemNo,
                ReqMaterials,
                Total_Qty,
                Unit,
                MaterialsAvailable,
                StockSource,
                Mat_Status
            FROM RequestedMaterials
            WHERE Pk_WorkOrderNo = @WorkOrderNo
            ORDER BY ItemNo"

                Using cmd As New SqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@WorkOrderNo", workOrderNo)

                    Using da As New SqlDataAdapter(cmd)

                        da.Fill(dt)

                    End Using

                End Using

            End Using

            DataGridView_Mat.DataSource = dt

        Catch ex As Exception

            MessageBox.Show("Error loading materials: " & ex.Message)

        End Try

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click

        '================ Load Materials into a DataTable  ================
        Dim dt_Materials As New DataTable
        Try
            Using myconnection As New SqlConnection(connStr)
                myconnection.Open()

                Using mycommand2 As New SqlCommand("
            SELECT a.ItemNo, a.Pk_WorkOrderNo, a.ReqMaterials,
                   a.Total_Qty, a.Unit, a.MaterialsAvailable, a.StockSource, a.Mat_Status
            FROM RequestedMaterials a
            WHERE a.Pk_WorkOrderNo = @Pk_WorkOrderNo order by a.ItemNo", myconnection)

                    mycommand2.Parameters.AddWithValue("@Pk_WorkOrderNo", TxtWorkOrderNo.Text)

                    Dim myadapter As New SqlDataAdapter(mycommand2)
                    myadapter.Fill(dt_Materials)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading materials for report: " & ex.Message)
        End Try



        '================ LOAD PERSON ASSIGNED ==================
        Dim dt_Personnel As New DataTable()

        Try
            Using con As New SqlConnection(connStr)
                con.Open()

                Using cmd As New SqlCommand("SELECT a.Pk_PersonAssign, a.Fullname, b.Position, a.Department, a.ContactNo
                                            FROM PersonAssigned a
			                                INNER JOIN Maintenance b on b.Pk_Maintenance=a.Pk_PersonAssign
                                            WHERE a.Pk_WorkOrderNo = @Pk_WorkOrderNo", con)

                    cmd.Parameters.AddWithValue("@Pk_WorkOrderNo", TxtWorkOrderNo.Text)

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt_Personnel)
                    End Using

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading personnel: " & ex.Message)
        End Try





        Try
            Dim frm As New FrmReportPreview()

            '--- Send each parameter individually ---
            frm.WoNo = TxtWorkOrderNo.Text
            frm.DateRequested = DateRequested.Text
            frm.DateCompleted = DateCompleted.Text
            frm.CompletedBy = CompletedBy.Text
            frm.DateClosed = DateClose.Text
            frm.ClosedBy = Closeby.Text
            frm.DateCancelled = DateCancelled.Text
            frm.CancelledBy = CancelledBy.Text


            frm.WorkDescription = txtDesc.Text
            frm.CancelledRemarks = CancelledRemarks.Text
            frm.Requester = txtreq.Text
            frm.HeadSupervisor = txthead.Text
            frm.RequestedArea = txtDept.Text

            frm.IfMatNeeded = "Materials needed:" & " " & "angel"

            frm.Status = lblStatus.Text
            frm.Notedby = lbl_chief_OIC.Text
            frm.NotedbyDateTime = lblcheckedByHeadSupervisor.Text

            frm.Approvedby = lblApprovedby.Text
            frm.ApprovedDateTime = lblOperationDate.Text

            frm.ApprovedReleaseby = lblSupplyChainHead.Text
            frm.ApprovedReleaseDateTime = lblSupplyDate.Text


            frm.ApprovedPoby = lblFinanceManager.Text
            frm.ApprovedPodateTime = lblFinanceDate.Text


            frm.NotedBy_Position = lblChiefStatus.Text
            frm.ApprovedBy_Position = lblOperationStatus.Text
            frm.ApprovedReleaseBy_Position = lblSupplyStatus.Text
            frm.ApprovedPoBy_Position = lblFinanceStatus.Text



            '--- Step 2: Send Materials DataTable ---
            frm.MaterialsTable = dt_Materials
            frm.PersonnelTable = dt_Personnel

            frm.ShowDialog()
            frm.Dispose()
        Catch ex As Exception
            MessageBox.Show("Error opening print preview: " & ex.Message)
        End Try

    End Sub

    Private Sub btnViewDelayedSummary_Click(sender As Object, e As EventArgs) Handles btnViewDelayedSummary.Click
        Dim frm As New FrmDelaySummary

        frm.WorkOrderNo = TxtWorkOrderNo.Text

        frm.ShowDialog(Me)

    End Sub
End Class

