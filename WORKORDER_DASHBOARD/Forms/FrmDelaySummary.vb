Imports System.Data.SqlClient
Imports System.Data

Public Class FrmDelaySummary

    Public WorkOrderNo As String
    Private TimelineTop As Integer = 10

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmDelaySummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblWorkOrderNo.Text = WorkOrderNo

        LoadTimeline()

        LoadPendingMaterials()

        Dim result = GetCurrentDelayStage(WorkOrderNo, connStr)

        lblCurrentDelay.Text = result.Stage
        lblDaysDelay.Text = result.Days & " Days"
        lblResponsibleArea.Text = result.Responsible

        With txtDes
            .ReadOnly = True
            .TabStop = False
            ' .BackColor = Color.FromArgb(44, 60, 79)
            .ForeColor = Color.Black
        End With

    End Sub

    ' ======================================================
    ' SUMMARY PANEL
    ' ======================================================
    Private Function GetCurrentDelayStage(workOrderNo As String, connStr As String) As (Stage As String, Days As Integer, Responsible As String)

        Dim nowDate As DateTime = DateTime.Now

        Using conn As New SqlConnection(connStr)

            conn.Open()

            Dim sql As String = "
        SELECT *
        FROM WorkOrderForm w
        LEFT JOIN RequestedMaterials rm
            ON w.Pk_WorkOrderNo = rm.Pk_WorkOrderNo
        WHERE w.Pk_WorkOrderNo = @WO"

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@WO", workOrderNo)

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If Not dr.Read() Then
                        Return ("NOT FOUND", 0, "-")
                    End If

                    Dim registryDate As DateTime = Convert.ToDateTime(dr("RegistryDate"))

                    Dim headStatus As String = dr("HeadSupervisorStatus").ToString()
                    Dim chiefStatus As String = dr("Notedby1Status").ToString()
                    Dim opsStatus As String = dr("ApprovedByStatus").ToString()

                    Dim isMaterialsNeeded As Boolean =
                    dr("IsMaterialsNeeded").ToString().ToUpper() = "YES"


                    txtDes.Text = dr("Work_Description").ToString()
                    lblSeverity.Text = dr("Work_Description").ToString()

                    ' ======================================================
                    ' 1. HEAD SUPERVISOR
                    ' ======================================================
                    If headStatus <> "APPROVED" AndAlso headStatus <> "CHECKED" Then

                        Return ("Head Supervisor",
                            DateDiff(DateInterval.Day, registryDate, nowDate),
                            "Head Supervisor")

                    End If

                    ' ======================================================
                    ' 2. CHIEF ENGINEER
                    ' ======================================================
                    If chiefStatus <> "APPROVED" Then

                        Dim headDate As DateTime =
                        Convert.ToDateTime(dr("HeadSuperVisorTimeAndDateApprove"))

                        Return ("Chief Engineer",
                            DateDiff(DateInterval.Day, headDate, nowDate),
                            "Chief Engineer")

                    End If

                    ' ======================================================
                    ' 3. OPERATION DIRECTOR
                    ' ======================================================
                    If opsStatus <> "APPROVED" Then

                        Dim chiefDate As DateTime =
                        Convert.ToDateTime(dr("Notedby1TimeAndDate"))

                        Return ("Operation Director",
                            DateDiff(DateInterval.Day, chiefDate, nowDate),
                            "Operations")

                    End If

                    ' ======================================================
                    ' 4. SUPPLY CHAIN (ITEM-AWARE)
                    ' ======================================================
                    If isMaterialsNeeded Then

                        Dim scDt As New DataTable()

                        Using conn2 As New SqlConnection(connStr)

                            Dim sqlSC As String = "
                        SELECT
                            TimeAndDateMatRegPosted,
                            ApprovedForReleaseByTimeAndDate
                        FROM RequestedMaterials
                        WHERE Pk_WorkOrderNo = @WO
                          AND StockSource = 'SC'"

                            Using cmd2 As New SqlCommand(sqlSC, conn2)
                                cmd2.Parameters.AddWithValue("@WO", workOrderNo)

                                Dim da As New SqlDataAdapter(cmd2)
                                da.Fill(scDt)

                            End Using

                        End Using

                        If scDt.Rows.Count > 0 Then

                            Dim pendingCount As Integer =
                            scDt.AsEnumerable().
                            Count(Function(r) IsDBNull(r("ApprovedForReleaseByTimeAndDate")))

                            If pendingCount > 0 Then

                                Dim opsDate As DateTime =
                                Convert.ToDateTime(dr("ApprovedByTimeAndDate"))

                                Return ("Supply Chain",
                                    DateDiff(DateInterval.Day, opsDate, nowDate),
                                    "Supply Chain")

                            End If

                        End If

                    End If

                    ' ======================================================
                    ' 5. MAINTENANCE
                    ' ======================================================
                    Dim proceedFlag As Integer = 0

                    If Not IsDBNull(dr("ProceedWO_Flag")) Then
                        proceedFlag = Convert.ToInt32(dr("ProceedWO_Flag"))
                    End If

                    ' ======================================================
                    ' MAINTENANCE NOT STARTED (0)
                    ' ======================================================
                    If proceedFlag = 0 Then

                        Dim startDate As DateTime =
        If(IsDBNull(dr("ApprovedForReleaseByTimeAndDate")),
           registryDate,
           Convert.ToDateTime(dr("ApprovedForReleaseByTimeAndDate")))

                        Return ("Maintenance (Waiting to Start)",
            DateDiff(DateInterval.Day, startDate, nowDate),
            "Maintenance Team")

                    End If

                    ' ======================================================
                    ' MAINTENANCE IN PROGRESS (1)
                    ' ======================================================
                    If proceedFlag = 1 Then

                        Dim startDate As DateTime =
        If(IsDBNull(dr("ProceedWO_TimeAndDate")),
           nowDate,
           Convert.ToDateTime(dr("ProceedWO_TimeAndDate")))

                        Return ("Maintenance (In Progress)",
            DateDiff(DateInterval.Day, startDate, nowDate),
            "Maintenance Team")

                    End If

                    ' ======================================================
                    ' MAINTENANCE COMPLETED (2)
                    ' ======================================================
                    If proceedFlag = 2 Then
                        ' ❗ DO NOT return Maintenance anymore
                        ' 👉 MOVE TO NEXT STAGE (User Close)
                    End If



                    ' ======================================================
                    ' 6. CLOSE WORK ORDER
                    ' ======================================================
                    If dr("TagAsClose").ToString() <> "CLOSED" Then

                        Dim closeStart As DateTime =
        If(IsDBNull(dr("CompleteStatusDateAndTime")),
           nowDate,
           Convert.ToDateTime(dr("CompleteStatusDateAndTime")))

                        Return ("User Close Work Order",
            DateDiff(DateInterval.Day, closeStart, nowDate),
            "Requester")

                    End If

                    ' ======================================================
                    ' 7. COMPLETED
                    ' ======================================================
                    Return ("Completed", 0, "Done")

                End Using
            End Using
        End Using

    End Function

    ' ======================================================
    ' TIMELINE
    ' ======================================================
    Private Sub LoadTimeline()

        pnlTimeline.SuspendLayout()
        pnlTimeline.Controls.Clear()
        pnlTimeline.AutoScroll = True
        ' pnlTimeline.BackColor = Color.FromArgb(44, 60, 79)

        TimelineTop = 25

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim sql As String = "
        SELECT *
        FROM WorkOrderForm w
        LEFT JOIN RequestedMaterials rm
        ON w.Pk_WorkOrderNo = rm.Pk_WorkOrderNo
        WHERE w.Pk_WorkOrderNo = @WO"

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@WO", WorkOrderNo)

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If Not dr.Read() Then Exit Sub

                    ' ======================================================
                    ' BASE DATE
                    ' ======================================================
                    Dim registryDate As DateTime = Convert.ToDateTime(dr("RegistryDate"))

                    AddStep("Registry", registryDate, registryDate, Color.Gray)

                    ' ======================================================
                    ' HEAD
                    ' ======================================================
                    If dr("HeadSupervisorStatus").ToString() = "CHECKED" Then

                        Dim headDate As DateTime = Convert.ToDateTime(dr("HeadSuperVisorTimeAndDateApprove"))

                        AddStep("Head Supervisor",
                            registryDate,
                            headDate,
                            GetApprovalColor(DateDiff(DateInterval.Day, registryDate, headDate)))
                    Else
                        AddPendingStep("Head Supervisor")
                    End If

                    ' ======================================================
                    ' CHIEF
                    ' ======================================================
                    If dr("Notedby1Status").ToString() = "APPROVED" Then

                        Dim chiefDate As DateTime = Convert.ToDateTime(dr("Notedby1TimeAndDate"))
                        Dim headDate As DateTime = Convert.ToDateTime(dr("HeadSuperVisorTimeAndDateApprove"))

                        AddStep("Chief Engineer",
                            headDate,
                            chiefDate,
                            GetApprovalColor(DateDiff(DateInterval.Day, headDate, chiefDate)))
                    Else
                        AddPendingStep("Chief Engineer")
                    End If


                    ' ======================================================
                    ' OPERATION
                    ' ======================================================
                    If dr("ApprovedByStatus").ToString() = "APPROVED" Then

                        Dim opDate As DateTime = Convert.ToDateTime(dr("ApprovedByTimeAndDate"))
                        Dim chiefDate As DateTime = Convert.ToDateTime(dr("Notedby1TimeAndDate"))

                        AddStep("Operation Director",
                            chiefDate,
                            opDate,
                            GetApprovalColor(DateDiff(DateInterval.Day, chiefDate, opDate)))
                    Else
                        AddPendingStep("Operation Director")
                    End If


                    ' ======================================================
                    ' SUPPLY CHAIN
                    ' ======================================================

                    Dim isMaterialsNeeded As Boolean = False

                    If Not IsDBNull(dr("IsMaterialsNeeded")) Then
                        isMaterialsNeeded = dr("IsMaterialsNeeded").ToString().ToUpper() = "YES"
                    End If

                    Dim scEnd As DateTime = registryDate
                    If isMaterialsNeeded Then
                        Dim supplyStatus As String = ""
                        If Not IsDBNull(dr("ApprovedForReleaseByStatus")) Then
                            supplyStatus = dr("ApprovedForReleaseByStatus").ToString()
                        End If

                        If supplyStatus = "APPROVED" Then
                            If Not IsDBNull(dr("ApprovedForReleaseByTimeAndDate")) AndAlso Not IsDBNull(dr("ApprovedByTimeAndDate")) Then

                                Dim opDate As DateTime = Convert.ToDateTime(dr("ApprovedByTimeAndDate"))
                                Dim scDate As DateTime = Convert.ToDateTime(dr("ApprovedForReleaseByTimeAndDate"))

                                AddStep("Supply Chain", opDate, scDate, GetApprovalColor(DateDiff(DateInterval.Day, opDate, scDate)))
                                scEnd = scDate
                            Else
                                AddPendingStep("Supply Chain")
                            End If
                        Else
                            AddPendingStep("Supply Chain")
                        End If
                    Else
                        If Not IsDBNull(dr("ApprovedByTimeAndDate")) Then
                            scEnd = Convert.ToDateTime(dr("ApprovedByTimeAndDate"))
                        End If
                    End If




                    ' ======================================================
                    ' MAINTENANCE
                    ' ======================================================
                    Dim proceedFlag As Integer =
                    If(IsDBNull(dr("ProceedWO_Flag")), 0,
                    Convert.ToInt32(dr("ProceedWO_Flag")))

                    Dim proceedDate As DateTime = scEnd

                    If proceedFlag = 2 Then

                        If Not IsDBNull(dr("ProceedWO_TimeAndDate")) Then
                            proceedDate = Convert.ToDateTime(dr("ProceedWO_TimeAndDate"))
                            AddStep("Maintenance", scEnd, proceedDate, GetApprovalColor(DateDiff(DateInterval.Day, scEnd, proceedDate)))
                        Else
                            AddPendingStep("Maintenance")
                        End If
                    ElseIf proceedFlag = 1 Then
                        AddPendingStep("Maintenance - In Progress")
                    Else
                        AddPendingStep("Maintenance - Not Started")
                    End If




                    ' ======================================================
                    ' CLOSE WORK ORDER
                    ' ======================================================
                    If dr("TagAsClose").ToString() = "1" Then

                        AddStep("Close Work Order",
                            proceedDate,
                            DateTime.Now,
                            Color.LimeGreen)
                    Else
                        AddPendingStep("User Close Work Order")
                    End If

                End Using
            End Using
        End Using

        pnlTimeline.ResumeLayout()
        pnlTimeline.Invalidate()

    End Sub

    ' ======================================================
    ' UI HELPERS
    ' ======================================================
    Private Sub AddStep(title As String, startDate As DateTime, endDate As DateTime, stepColor As Color)

        Dim days As Integer = DateDiff(DateInterval.Day, startDate, endDate)

        Dim stepPanel As New Panel With {
        .Width = pnlTimeline.ClientSize.Width - 25,
        .Height = 40,
        .Left = 30,
        .Top = TimelineTop,
        .BackColor = Color.FromArgb(44, 60, 79) ' UPDATED
    }

        Dim colorBar As New Panel With {
        .Width = 8,
        .Height = stepPanel.Height,
        .Left = 0,
        .Top = 0,
        .BackColor = stepColor
    }

        Dim lbl As New Label With {
        .AutoSize = False,
        .Width = stepPanel.Width - 10,
        .Height = 40,
        .Left = 12,
        .Font = New Font("Segoe UI Semibold", 11.5F, FontStyle.Bold),
        .ForeColor = Color.White,
        .Text = $"{title} | {days} day(s)",
        .TextAlign = ContentAlignment.MiddleLeft
    }

        stepPanel.Controls.Add(colorBar)
        stepPanel.Controls.Add(lbl)

        pnlTimeline.Controls.Add(stepPanel)

        TimelineTop += 55

    End Sub

    Private Sub AddPendingStep(title As String)

        Dim stepPanel As New Panel With {
            .Width = pnlTimeline.ClientSize.Width - 25,
            .Height = 40,
            .Left = 30,
            .Top = TimelineTop,
            .BackColor = Color.DarkGoldenrod
        }

        Dim lbl As New Label With {
            .AutoSize = False,
            .Width = stepPanel.Width - 10,
            .Height = 40,
            .Font = New Font("Segoe UI Semibold", 12.5F, FontStyle.Bold),
            .ForeColor = Color.White,
            .Text = $"{title} | PENDING",
            .TextAlign = ContentAlignment.MiddleLeft
        }

        stepPanel.Controls.Add(lbl)
        pnlTimeline.Controls.Add(stepPanel)

        TimelineTop += 65

    End Sub
    Private Function GetApprovalColor(daysTaken As Integer) As Color

        If daysTaken <= 5 Then
            Return Color.LimeGreen

        ElseIf daysTaken <= 10 Then
            Return Color.OrangeRed
        Else
            Return Color.Red
        End If
    End Function
















    Private Sub LoadPendingMaterials(dt As DataTable)

        Try
            ' Clear grid first
            lstPendingMaterials_grid.Rows.Clear()
            lstPendingMaterials_grid.Columns.Clear()

            ' Create columns
            lstPendingMaterials_grid.Columns.Add("ReqMaterials", "Material Description")
            lstPendingMaterials_grid.Columns.Add("Total_Qty", "Total Qty")
            lstPendingMaterials_grid.Columns.Add("Qty_Receive", "Qty Received")

            Dim hasMaterials As Boolean = False

            For Each r As DataRow In dt.Rows

                ' Make sure material exists
                If Not IsDBNull(r("ReqMaterials")) Then

                    hasMaterials = True

                    Dim reqMaterials As String = If(IsDBNull(r("ReqMaterials")), "", r("ReqMaterials").ToString())
                    Dim totalQty As String = If(IsDBNull(r("Total_Qty")), "0", r("Total_Qty").ToString())
                    Dim qtyReceive As String = If(IsDBNull(r("Qty_Receive")), "0", r("Qty_Receive").ToString())

                    lstPendingMaterials_grid.Rows.Add(reqMaterials, totalQty, qtyReceive)

                End If

            Next

            ' If no materials found
            If Not hasMaterials Then
                lstPendingMaterials_grid.Rows.Add("No materials found", "-", "-")
            End If

            ' ================= OPTIONAL COLOR CODING =================
            For Each row As DataGridViewRow In lstPendingMaterials_grid.Rows

                Dim total As Integer = 0
                Dim received As Integer = 0

                Integer.TryParse(row.Cells("Total_Qty").Value?.ToString(), total)
                Integer.TryParse(row.Cells("Qty_Receive").Value?.ToString(), received)

                If received < total Then
                    row.DefaultCellStyle.ForeColor = Color.OrangeRed ' incomplete
                ElseIf total > 0 AndAlso received >= total Then
                    row.DefaultCellStyle.ForeColor = Color.LimeGreen ' complete
                Else
                    row.DefaultCellStyle.ForeColor = Color.White ' default
                End If

            Next

            ' Grid styling (optional but recommended)
            With lstPendingMaterials_grid
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .AllowUserToAddRows = False
                .ReadOnly = True
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                .BackgroundColor = Color.DarkGray
                .DefaultCellStyle.BackColor = Color.DarkGray
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray
                .DefaultCellStyle.SelectionForeColor = Color.White

                .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .EnableHeadersVisualStyles = False
            End With

        Catch ex As Exception
            MessageBox.Show("Error loading materials: " & ex.Message)
        End Try

    End Sub

    Private Sub LoadPendingMaterials()

        Try
            Using conn As New SqlConnection(connStr)

                Dim sql As String = "
                SELECT 
                    ReqMaterials,
                    Total_Qty,
                    QTY_Recieve
                FROM RequestedMaterials
                WHERE Pk_WorkOrderNo = @WO"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@WO", WorkOrderNo)

                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)

                    conn.Open()
                    da.Fill(dt)

                    ' Bind to grid
                    lstPendingMaterials_grid.DataSource = dt

                End Using
            End Using

            FormatMaterialsGrid()

        Catch ex As Exception
            MessageBox.Show("Error loading materials: " & ex.Message)
        End Try

    End Sub

    Private Sub FormatMaterialsGrid()

        With lstPendingMaterials_grid
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ReadOnly = True
            .AllowUserToAddRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .BackgroundColor = Color.FromArgb(44, 60, 79)
            .DefaultCellStyle.BackColor = Color.FromArgb(44, 60, 79)
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray

            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 60, 79)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .EnableHeadersVisualStyles = False
        End With

    End Sub

    Private Sub pnlTimeline_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class