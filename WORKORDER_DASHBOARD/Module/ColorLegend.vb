Imports System.Data.SqlClient
Imports System.Data
Module ColorLegend
    Public FullResultTable As DataTable
    Public WorkOrderColorMap As New Dictionary(Of String, String)

    Public Sub ApplyWorkOrderColors()
        Using myConnection As New SqlConnection(connStr)
            myConnection.Open()

            For Each row As DataGridViewRow In DashBoard.DataGridView.Rows
                If row.IsNewRow Then Continue For

                Dim pkWorkOrderNo As String = row.Cells("Woms No.").Value?.ToString()
                If String.IsNullOrEmpty(pkWorkOrderNo) Then Continue For

                ' ---------------------------
                ' Check if row is a backjob
                Dim isBackJob As Integer = 0
                Using cmdBackJob As New SqlCommand("SELECT BackJob_Flag FROM WorkOrderForm WHERE Pk_WorkOrderNo=@Pk", myConnection)
                    cmdBackJob.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                    Dim result = cmdBackJob.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        isBackJob = Convert.ToInt32(result)
                    End If
                End Using

                If isBackJob = 1 Then
                    ' Row is a backjob ? handle with backjob function
                    ApplyWorkOrderColorsBackjob(row, myConnection)
                    Continue For
                End If
                ' ---------------------------

                ' Normal work order logic starts here
                Dim colorToApply As Color = Color.White
                Dim tooltipText As String = ""

                ' Get status fields
                Dim headStatus As String = ""
                Dim notedStatus As String = ""
                Dim approvedStatus As String = ""
                Dim isMatNeeded As String = ""
                Dim proceedFlag As Integer = 0

                Using cmd As New SqlCommand("
                                            SELECT 
                                            HeadSupervisorStatus, 
                                            NotedBy1Status, 
                                            ApprovedByStatus, 
                                            IsMaterialsNeeded, 
                                            ProceedWO_Flag
                                            FROM WorkOrderForm
                                            WHERE Pk_WorkOrderNo = @Pk", myConnection)

                    cmd.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            headStatus = rdr("HeadSupervisorStatus").ToString().Trim().ToUpper()
                            notedStatus = rdr("NotedBy1Status").ToString().Trim().ToUpper()
                            approvedStatus = rdr("ApprovedByStatus").ToString().Trim().ToUpper()
                            isMatNeeded = rdr("IsMaterialsNeeded").ToString().Trim().ToUpper()
                            proceedFlag = Convert.ToInt32(If(IsDBNull(rdr("ProceedWO_Flag")), 0, rdr("ProceedWO_Flag")))
                        End If
                    End Using
                End Using

                ' Check RequestedMaterials for completion
                Dim allMatReceived As Boolean = False
                Using cmdMat As New SqlCommand("
                                            SELECT 
                                                CASE WHEN COUNT(*) > 0 AND SUM(CASE WHEN Qty_Recieve >= Total_Qty THEN 1 ELSE 0 END) = COUNT(*) 
                                                 THEN 1 ELSE 0 END
                                             FROM RequestedMaterials
                                            WHERE Pk_WorkOrderNo = @Pk", myConnection)
                    cmdMat.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                    Dim result = cmdMat.ExecuteScalar()
                    allMatReceived = (Convert.ToInt32(result) = 1)
                End Using

                ' Apply priority order (highest step wins)
                If proceedFlag = 2 Then
                    colorToApply = Color.DarkBlue
                    tooltipText = "Work Order Completed"

                ElseIf proceedFlag = 1 Then
                    colorToApply = Color.Orange
                    tooltipText = "Work Order Proceeded by Chief Engineer"

                ElseIf allMatReceived Then
                    colorToApply = Color.HotPink
                    tooltipText = "Materials On Hand / Fully Received"

                ElseIf approvedStatus = "APPROVED" AndAlso isMatNeeded = "YES" Then
                    colorToApply = Color.Pink
                    tooltipText = "Approved by Operation Director (Materials Needed)"

                ElseIf approvedStatus = "APPROVED" AndAlso isMatNeeded = "NO" Then
                    colorToApply = Color.RoyalBlue
                    tooltipText = "Approved by Operation Director (No Materials Needed)"

                ElseIf isMatNeeded = "YES" AndAlso approvedStatus <> "APPROVED" Then
                    colorToApply = Color.Pink
                    tooltipText = "Materials Requested (Pending Director Approval)"

                ElseIf notedStatus = "APPROVED" Then
                    colorToApply = Color.LimeGreen
                    tooltipText = "Acknowledged by CE"

                ElseIf headStatus = "CHECKED" Then
                    colorToApply = Color.Yellow
                    tooltipText = "Checked by Head Supervisor"

                Else
                    colorToApply = Color.White
                    tooltipText = "New Work Order"
                End If

                ' === Configure column 0 as color indicator ===
                With DashBoard.DataGridView.Columns(0)
                    .Width = 15
                    .ReadOnly = True
                    .Frozen = True
                End With

                ' Deselect any current cell so column 0 is not selected
                DashBoard.DataGridView.CurrentCell = Nothing

                ' Apply color & tooltip to first cell (column 0)
                row.Cells(0).Style.BackColor = colorToApply
                row.Cells(0).Style.SelectionBackColor = colorToApply
                row.Cells(0).ToolTipText = tooltipText

            Next
        End Using




    End Sub

    Public Sub ApplyWorkOrderColorsBackjob(row As DataGridViewRow, conn As SqlConnection)

        Try
            Dim pkWorkOrderNo As String = row.Cells("Woms No.").Value?.ToString()
            If String.IsNullOrEmpty(pkWorkOrderNo) Then Return

            ' Default values
            Dim colorToApply As Color = Color.White
            Dim tooltipText As String = ""

            ' Get status fields from BackJobHistory
            Dim notedStatus As String = ""
            Dim approvedStatus As String = ""
            Dim isMatNeeded As String = ""
            Dim proceedFlag As Integer = 0

            Using cmd As New SqlCommand("
            SELECT NotedBy1Status, ApprovedByStatus, IsMaterialsNeeded, ProceedWO_Flag
            FROM BackJobHistory
            WHERE Pk_WorkOrderNo = @Pk", conn)

                cmd.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        notedStatus = rdr("NotedBy1Status").ToString().Trim().ToUpper()
                        approvedStatus = rdr("ApprovedByStatus").ToString().Trim().ToUpper()
                        isMatNeeded = rdr("IsMaterialsNeeded").ToString().Trim().ToUpper()
                        proceedFlag = Convert.ToInt32(If(IsDBNull(rdr("ProceedWO_Flag")), 0, rdr("ProceedWO_Flag")))
                    End If
                End Using
            End Using

            ' Normalize empty values
            notedStatus = If(String.IsNullOrEmpty(notedStatus), "", notedStatus)
            approvedStatus = If(String.IsNullOrEmpty(approvedStatus), "", approvedStatus)
            isMatNeeded = If(String.IsNullOrEmpty(isMatNeeded), "NO", isMatNeeded)

            ' Check BackJob_Mat for full material receipt
            Dim allMatReceived As Boolean = False
            Using cmdMat As New SqlCommand("
            SELECT CASE WHEN COUNT(*) > 0 AND SUM(CASE WHEN Qty_Recieve >= Total_Qty THEN 1 ELSE 0 END) = COUNT(*) THEN 1 ELSE 0 END
            FROM BackJob_Mat
            WHERE Pk_WorkOrderNo = @Pk", conn)

                cmdMat.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                Dim result = cmdMat.ExecuteScalar()
                allMatReceived = (Convert.ToInt32(result) = 1)
            End Using

            ' Determine color & tooltip (backjob logic)
            If proceedFlag = 2 Then
                colorToApply = Color.DarkBlue
                tooltipText = "Work Order Completed"

            ElseIf proceedFlag = 1 Then
                colorToApply = Color.Orange
                tooltipText = "Work Order Proceeded by Chief Engineer"

            ElseIf allMatReceived Then
                colorToApply = Color.HotPink
                tooltipText = "Materials On Hand / Fully Received"

            ElseIf approvedStatus = "APPROVED" AndAlso isMatNeeded = "YES" Then
                colorToApply = Color.Pink
                tooltipText = "Approved by Operation Director (Materials Needed)"

            ElseIf approvedStatus = "APPROVED" AndAlso isMatNeeded = "NO" Then
                colorToApply = Color.RoyalBlue
                tooltipText = "Approved by Operation Director (No Materials Needed)"

            ElseIf isMatNeeded = "YES" AndAlso approvedStatus <> "APPROVED" Then
                colorToApply = Color.Pink
                tooltipText = "Materials Requested (Pending Director Approval)"

            ElseIf notedStatus = "APPROVED" Then
                colorToApply = Color.LimeGreen
                tooltipText = "Acknowledged by CE"

            Else
                colorToApply = Color.White
                tooltipText = "New Work Order Back Job"
            End If

            ' Apply to column 0
            row.Cells(0).Style.BackColor = colorToApply
            row.Cells(0).Style.SelectionBackColor = colorToApply
            row.Cells(0).ToolTipText = tooltipText

        Catch ex As Exception
            MessageBox.Show("ApplyWorkOrderColorsBackjob error: " & ex.Message)
        End Try

    End Sub

    Public Sub ApplyReColors()

        ' Only apply for specific dashboards
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                For Each row As DataGridViewRow In DashBoard.DataGridView.Rows
                    If row.IsNewRow Then Continue For

                    ' Get Work Order No
                    Dim pkWorkOrderNo As String = ""
                    If DashBoard.DataGridView.Columns.Contains("Woms No.") Then
                        pkWorkOrderNo = Convert.ToString(row.Cells("Woms No.").Value).Trim()
                    Else
                        pkWorkOrderNo = Convert.ToString(row.Cells(3).Value).Trim()
                    End If
                    If String.IsNullOrWhiteSpace(pkWorkOrderNo) Then Continue For

                    ' --- BACKJOB CHECK ---
                    Using cmdBackJob As New SqlCommand("
                    SELECT BackJob_Flag 
                    FROM WorkOrderForm 
                    WHERE Pk_WorkOrderNo = @Pk", conn)

                        cmdBackJob.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                        Dim result As Object = cmdBackJob.ExecuteScalar()
                        Dim isBackJob As Integer = 0

                        If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                            isBackJob = Convert.ToInt32(result)
                        End If

                        If isBackJob > 0 Then
                            ' Call Backjob logic
                            ApplyReColorsBackjob(row, pkWorkOrderNo, conn)
                            Continue For
                        End If
                    End Using

                    ' Default color
                    Dim finalColor As Color = Color.White
                    Dim finalTooltip As String = "No materials needed"

                    ' Check if materials are needed
                    Dim materialsNeeded As Boolean = True
                    Using cmdCheck As New SqlCommand("
                    SELECT ISNULL(IsMaterialsNeeded,'Yes') 
                    FROM WorkOrderForm 
                    WHERE Pk_WorkOrderNo = @Pk", conn)

                        cmdCheck.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
                        Dim val As String = Convert.ToString(cmdCheck.ExecuteScalar()).Trim().ToUpper()
                        materialsNeeded = (val <> "NO")
                    End Using

                    If materialsNeeded Then
                        ' Load Requested Materials
                        Dim dt As New DataTable
                        Using cmd As New SqlCommand("SELECT 
                                ISNULL(Mat_Status,'') AS Mat_Status,
                                ISNULL(StockSource,'') AS StockSource,
                                ISNULL(Total_Qty, 0) As Total_Qty,
                                ISNULL(QTY_Recieve, 0) As QTY_Recieve,
                                ISNULL(QTY_Available_SC, 0) As QTY_Available_SC,
                                ISNULL(QTY_Available_SC_Post_Flag, 0) As SC_Post,
                                ISNULL(ApprovedForReleaseByStatus,'PENDING') AS ApprovedStat,
                                ISNULL(QTY_Available_SC_Release_Post_Flag, 0) AS ReleaseFlag
                            From RequestedMaterials
                            Where Pk_WorkOrderNo = @PK
                              And (CancelStatus Is NULL Or CancelStatus = '' OR CancelStatus = '0');", conn)

                            cmd.Parameters.AddWithValue("@PK", pkWorkOrderNo)
                            Using adp As New SqlDataAdapter(cmd)
                                adp.Fill(dt)
                            End Using
                        End Using

                        ' If no rows yet, keep white (not gray)
                        If dt.Rows.Count = 0 Then
                            finalColor = Color.Empty
                            finalTooltip = "No materials yet"
                        Else
                            ' Aggregate flags logic same as before
                            Dim allCancelled As Boolean = True
                            Dim allFullyServed As Boolean = True
                            Dim anyPendingToServe As Boolean = False
                            Dim anyWaitingApproval As Boolean = False
                            Dim anyApprovedForRelease As Boolean = False
                            Dim anyMaintenanceReady As Boolean = False
                            Dim anyPendingMaterials As Boolean = False

                            For Each dr As DataRow In dt.Rows
                                Dim matStatus As String = dr("Mat_Status").ToString().Trim()
                                Dim totalQty As Decimal = Val(dr("Total_Qty"))
                                Dim rec As Decimal = Val(dr("QTY_Recieve"))
                                Dim sc As Decimal = Val(dr("QTY_Available_SC"))
                                Dim scPost As Integer = Val(dr("SC_Post"))
                                Dim approved As String = dr("ApprovedStat").ToString().Trim().ToUpper()
                                If String.IsNullOrEmpty(approved) Then approved = "PENDING"
                                Dim releaseFlag As Integer = Val(dr("ReleaseFlag"))

                                If matStatus <> "CANCELLED" Then allCancelled = False
                                If rec + sc < totalQty Then allFullyServed = False
                                If rec > 0 Or sc > 0 Then anyPendingToServe = True
                                If rec = 0 AndAlso sc = 0 Then anyPendingMaterials = True

                                ' Waiting approval to release
                                If sc > 0 AndAlso scPost = 1 AndAlso approved <> "APPROVED" AndAlso releaseFlag = 0 Then
                                    anyWaitingApproval = True
                                End If
                                ' Approved for release
                                If sc > 0 AndAlso approved = "APPROVED" AndAlso releaseFlag = 0 Then
                                    anyApprovedForRelease = True
                                End If
                                ' Ready for maintenance
                                If sc > 0 AndAlso releaseFlag = 1 Then
                                    anyMaintenanceReady = True
                                End If
                            Next

                            ' SC Partial Pending Approval
                            Dim scPartialPendingApproval As Boolean = False
                            For Each dr As DataRow In dt.Rows
                                Dim approved As String = dr("ApprovedStat").ToString().Trim().ToUpper()
                                If String.IsNullOrEmpty(approved) Then approved = "PENDING"

                                If dr("StockSource").ToString().Trim() = "SC" AndAlso
                                       Val(dr("QTY_Available_SC")) > 0 AndAlso
                                       Val(dr("QTY_Recieve")) < Val(dr("Total_Qty")) AndAlso
                                       approved = "PENDING" AndAlso
                                       Val(dr("ReleaseFlag")) = 0 Then
                                    scPartialPendingApproval = True
                                    Exit For
                                End If
                            Next

                            ' FINAL DECISION
                            If allCancelled Then
                                finalColor = Color.LightGray
                                finalTooltip = "All materials cancelled"
                            ElseIf scPartialPendingApproval Then
                                finalColor = Color.Yellow
                                finalTooltip = "Waiting for approval (SC still holds quantity)"
                            ElseIf anyApprovedForRelease Then
                                finalColor = Color.LightGoldenrodYellow
                                finalTooltip = "Approved for release (awaiting issuance)"
                            ElseIf anyMaintenanceReady Then
                                finalColor = Color.Cyan
                                finalTooltip = "Materials ready for maintenance to receive"
                            ElseIf allFullyServed Then
                                finalColor = Color.DarkBlue
                                finalTooltip = "Fully served"
                            ElseIf anyWaitingApproval Then
                                finalColor = Color.Yellow
                                finalTooltip = "Waiting approval to release"
                            ElseIf anyPendingMaterials Then
                                finalColor = Color.LightPink
                                finalTooltip = "Pending materials processing"
                            ElseIf anyPendingToServe Then
                                finalColor = Color.LightBlue
                                finalTooltip = "Partially served"
                            Else
                                finalColor = Color.LightPink
                                finalTooltip = "Pending materials processing"
                            End If
                        End If
                    End If

                    ' Apply to Cell(1)
                    Dim c As DataGridViewCell = row.Cells(1)
                    c.Style.BackColor = finalColor
                    c.Style.SelectionBackColor = finalColor
                    c.ToolTipText = finalTooltip
                Next
            End Using
        Catch ex As Exception
                MessageBox.Show("ApplyReColors error: " & ex.Message)
            End Try




    End Sub
    Private Sub ApplyReColorsBackjob(row As DataGridViewRow, pkWorkOrderNo As String, conn As SqlConnection)

        ' Default color
        Dim finalColor As Color = Color.White
        Dim finalTooltip As String = "No materials needed"

        ' Check if materials are needed
        Dim materialsNeeded As Boolean = True
        Using cmdCheck As New SqlCommand("
        SELECT ISNULL(IsMaterialsNeeded,'Yes') 
        FROM BackJobHistory 
        WHERE Pk_WorkOrderNo = @Pk", conn)
            cmdCheck.Parameters.AddWithValue("@Pk", pkWorkOrderNo)
            Dim val As String = Convert.ToString(cmdCheck.ExecuteScalar()).Trim().ToUpper()
            materialsNeeded = (val <> "NO")
        End Using

        If materialsNeeded Then
            ' Load BackJob Materials
            Dim dt As New DataTable
            Using cmd As New SqlCommand("
            SELECT 
                ISNULL(Mat_Status,'') AS Mat_Status,
                ISNULL(StockSource,'') AS StockSource,
                ISNULL(Total_Qty,0) AS Total_Qty,
                ISNULL(QTY_Recieve,0) AS QTY_Recieve,
                ISNULL(QTY_Available_SC,0) AS QTY_Available_SC,
                ISNULL(QTY_Available_SC_Post_Flag,0) AS SC_Post,
                ISNULL(ApprovedForReleaseByStatus,'') AS ApprovedStat,
                ISNULL(QTY_Available_SC_Release_Post_Flag,0) AS ReleaseFlag
            FROM BackJob_Mat
            WHERE Pk_WorkOrderNo = @PK
              AND (CancelStatus IS NULL OR CancelStatus = 0);", conn)

                cmd.Parameters.AddWithValue("@PK", pkWorkOrderNo)
                Using adp As New SqlDataAdapter(cmd)
                    adp.Fill(dt)
                End Using
            End Using

            ' If no rows yet, keep white
            If dt.Rows.Count = 0 Then
                finalColor = Color.Empty
                finalTooltip = "No materials yet"
            Else
                ' Same aggregate flags logic as ApplyReColors
                Dim allCancelled As Boolean = True
                Dim allFullyServed As Boolean = True
                Dim anyPendingToServe As Boolean = False
                Dim anyWaitingApproval As Boolean = False
                Dim anyApprovedForRelease As Boolean = False
                Dim anyMaintenanceReady As Boolean = False
                Dim anyPendingMaterials As Boolean = False

                For Each dr As DataRow In dt.Rows
                    Dim matStatus As String = dr("Mat_Status").ToString().Trim()
                    Dim totalQty As Decimal = Val(dr("Total_Qty"))
                    Dim rec As Decimal = Val(dr("QTY_Recieve"))
                    Dim sc As Decimal = Val(dr("QTY_Available_SC"))
                    Dim scPost As Integer = Val(dr("SC_Post"))
                    Dim approved As String = dr("ApprovedStat").ToString().Trim().ToUpper()
                    If String.IsNullOrEmpty(approved) Then approved = "PENDING"
                    Dim releaseFlag As Integer = Val(dr("ReleaseFlag"))

                    If matStatus <> "CANCELLED" Then allCancelled = False
                    If rec + sc < totalQty Then allFullyServed = False
                    If rec > 0 Or sc > 0 Then anyPendingToServe = True
                    If rec = 0 AndAlso sc = 0 Then anyPendingMaterials = True

                    ' Waiting approval to release
                    If sc > 0 AndAlso scPost = 1 AndAlso approved <> "APPROVED" AndAlso releaseFlag = 0 Then
                        anyWaitingApproval = True
                    End If
                    ' Approved for release
                    If sc > 0 AndAlso approved = "APPROVED" AndAlso releaseFlag = 0 Then
                        anyApprovedForRelease = True
                    End If
                    ' Ready for maintenance
                    If sc > 0 AndAlso releaseFlag = 1 Then
                        anyMaintenanceReady = True
                    End If
                Next

                ' SC Partial Pending Approval
                Dim scPartialPendingApproval As Boolean = False
                For Each dr As DataRow In dt.Rows
                    Dim approved As String = dr("ApprovedStat").ToString().Trim().ToUpper()
                    If String.IsNullOrEmpty(approved) Then approved = "PENDING"

                    If dr("StockSource").ToString().Trim() = "SC" AndAlso
                       Val(dr("QTY_Available_SC")) > 0 AndAlso
                       Val(dr("QTY_Recieve")) < Val(dr("Total_Qty")) AndAlso
                       approved = "PENDING" AndAlso
                       Val(dr("ReleaseFlag")) = 0 Then
                        scPartialPendingApproval = True
                        Exit For
                    End If
                Next

                ' FINAL DECISION
                If allCancelled Then
                    finalColor = Color.LightGray
                    finalTooltip = "All materials cancelled"
                ElseIf scPartialPendingApproval Then
                    finalColor = Color.Yellow
                    finalTooltip = "Waiting for approval (SC still holds quantity)"
                ElseIf anyApprovedForRelease Then
                    finalColor = Color.LightGoldenrodYellow
                    finalTooltip = "Approved for release (awaiting issuance)"
                ElseIf anyMaintenanceReady Then
                    finalColor = Color.Cyan
                    finalTooltip = "Materials ready for maintenance to receive"
                ElseIf allFullyServed Then
                    finalColor = Color.DarkBlue
                    finalTooltip = "Fully served"
                ElseIf anyWaitingApproval Then
                    finalColor = Color.Yellow
                    finalTooltip = "Waiting approval to release"
                ElseIf anyPendingMaterials Then
                    finalColor = Color.LightPink
                    finalTooltip = "Pending materials processing"
                ElseIf anyPendingToServe Then
                    finalColor = Color.LightBlue
                    finalTooltip = "Partially served"
                Else
                    finalColor = Color.LightPink
                    finalTooltip = "Pending materials processing"
                End If
            End If

        Else
            ' IsMaterialsNeeded = No, show white
            finalColor = Color.White
            finalTooltip = "No materials needed"
        End If

        ' Apply to Cell(1)
        Dim c As DataGridViewCell = row.Cells(1)
        c.Style.BackColor = finalColor
        c.Style.SelectionBackColor = finalColor
        c.ToolTipText = finalTooltip

        ' Increase width of color indicator column
        DashBoard.DataGridView.Columns(0).Width = 15

        ' Make column 0 read-only and prevent selection highlight
        DashBoard.DataGridView.Columns(1).ReadOnly = True
        DashBoard.DataGridView.Columns(1).DefaultCellStyle.SelectionBackColor = DashBoard.DataGridView.Columns(1).DefaultCellStyle.BackColor
        DashBoard.DataGridView.Columns(1).DefaultCellStyle.SelectionForeColor = DashBoard.DataGridView.Columns(1).DefaultCellStyle.ForeColor
    End Sub

    Public Sub ApplyColorsAdditionalItem()

        ' === ADD MATERIAL APPROVAL INDICATOR ==========================================
        Using myConnection As New SqlConnection(connStr)
            myConnection.Open()


            For Each row As DataGridViewRow In DashBoard.DataGridView.Rows
                If Not row.IsNewRow Then
                    Dim wo As String = row.Cells("Woms No.").Value.ToString()
                    Dim pendingCount As Integer = 0

                    Using con As New SqlConnection(connStr)
                        con.Open()
                        Dim sql As String = "SELECT COUNT(*) FROM RequestedMaterials
                                 WHERE Pk_WorkOrderNo = @wo
                                 AND IsOriginalMaterial = 0
                                 AND (ApprovedByOPDir IS NULL OR ApprovedByOPDir = 0)"
                        Using cmd As New SqlCommand(sql, con)
                            cmd.Parameters.AddWithValue("@wo", wo)
                            pendingCount = CInt(cmd.ExecuteScalar())
                        End Using
                    End Using

                    ' Set visible marker
                    row.Cells("OPApprovalStatus").Value = "?"

                    ' Set colors
                    If pendingCount > 0 Then
                        row.Cells("OPApprovalStatus").Style.BackColor = Color.Red
                        row.Cells("OPApprovalStatus").Style.ForeColor = Color.White
                    Else
                        row.Cells("OPApprovalStatus").Style.BackColor = Color.LimeGreen
                        row.Cells("OPApprovalStatus").Style.ForeColor = Color.White
                    End If
                End If
            Next
        End Using
        ' ===============================================================================
    End Sub

End Module
