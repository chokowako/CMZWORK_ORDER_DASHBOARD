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
        LoadDelaySummary()
        LoadTimeline()

        LoadPendingMaterials()

        With txtDes
            .ReadOnly = True
            .TabStop = False
            .BackColor = Color.FromArgb(44, 60, 79)
            .ForeColor = Color.White
        End With

    End Sub

    ' ======================================================
    ' SUMMARY PANEL
    ' ======================================================
    Private Sub LoadDelaySummary()

        Try
            Using conn As New SqlConnection(connStr)

                Dim sql As String = "
                SELECT
                    w.RegistryDate,w.Work_Description,
                    w.HeadSupervisorStatus,
                    w.Notedby1Status,
                    w.ApprovedByStatus,
                    w.ApprovedForReleaseByStatus,
                    w.PR_Acknowledge_Flag,
                    w.PR_ApproveToPurchaseByFM_Flag,
                    w.IsMaterialsNeeded,
                    rm.StockSource,
                    rm.Materials_Availability_Post_Flag
                FROM WorkOrderForm w
                LEFT JOIN RequestedMaterials rm 
                    ON w.Pk_WorkOrderNo = rm.Pk_WorkOrderNo
                WHERE w.Pk_WorkOrderNo = @WO"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@WO", WorkOrderNo)
                    conn.Open()

                    Using dr As SqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            Dim registryDate As DateTime = Convert.ToDateTime(dr("RegistryDate"))
                            Dim daysDelay As Integer = DateDiff(DateInterval.Day, registryDate, DateTime.Now)



                            ' ================= HEAD =================
                            If dr("HeadSupervisorStatus").ToString() <> "APPROVED" AndAlso
                               dr("HeadSupervisorStatus").ToString() <> "CHECKED" Then

                                lblCurrentDelay.Text = "Waiting for Head Supervisor Approval"
                                lblResponsibleArea.Text = "Head Supervisor"
                                lblDaysDelay.Text = daysDelay & " Days"
                                txtDes.Text = dr("Work_Description").ToString()
                                Exit Sub
                            End If

                            ' ================= CHIEF =================
                            If dr("Notedby1Status").ToString() <> "APPROVED" Then

                                lblCurrentDelay.Text = "Waiting for Chief Engineer Approval"
                                lblResponsibleArea.Text = "Chief Engineer"
                                lblDaysDelay.Text = daysDelay & " Days"
                                txtDes.Text = dr("Work_Description").ToString()
                                Exit Sub
                            End If

                            ' ================= OPERATION =================
                            If dr("ApprovedByStatus").ToString() <> "APPROVED" Then

                                lblCurrentDelay.Text = "Waiting for Operation Director Approval"
                                lblResponsibleArea.Text = "Operation Director"
                                lblDaysDelay.Text = daysDelay & " Days"
                                txtDes.Text = dr("Work_Description").ToString()
                                Exit Sub
                            End If

                            ' ================= SUPPLY CHAIN =================
                            Dim supplyActive As Boolean =
                                dr("IsMaterialsNeeded").ToString().ToUpper() = "YES" AndAlso
                                dr("ApprovedForReleaseByStatus").ToString() = "APPROVED" AndAlso
                                dr("StockSource").ToString().ToUpper() = "SC"
                            txtDes.Text = dr("Work_Description").ToString()

                            If supplyActive Then

                                If dr("Materials_Availability_Post_Flag").ToString() <> "1" Then

                                    lblCurrentDelay.Text = "Waiting for Supply Chain / Materials Processing"
                                    lblResponsibleArea.Text = "Supply Chain"
                                    lblDaysDelay.Text = daysDelay & " Days"
                                    txtDes.Text = dr("Work_Description").ToString()
                                    Exit Sub

                                End If

                            End If

                            ' ================= FINANCE =================
                            If dr("PR_Acknowledge_Flag").ToString() = "1" Then

                                If dr("PR_ApproveToPurchaseByFM_Flag").ToString() <> "APPROVED" Then

                                    lblCurrentDelay.Text = "Waiting for Finance Approval"
                                    lblResponsibleArea.Text = "Finance"
                                    lblDaysDelay.Text = daysDelay & " Days"
                                    txtDes.Text = dr("Work_Description").ToString()
                                    Exit Sub

                                End If

                            End If

                            lblCurrentDelay.Text = "No Delay Detected"
                            lblResponsibleArea.Text = "Completed"
                            lblDaysDelay.Text = daysDelay & " Days"
                            txtDes.Text = dr("Work_Description").ToString()

                        Else

                            lblCurrentDelay.Text = "Work Order Not Found"
                            lblResponsibleArea.Text = "-"
                            lblDaysDelay.Text = "-"

                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    ' ======================================================
    ' TIMELINE
    ' ======================================================
    Private Sub LoadTimeline()

        pnlTimeline.SuspendLayout()
        pnlTimeline.Controls.Clear()
        pnlTimeline.AutoScroll = True
        pnlTimeline.BackColor = Color.FromArgb(44, 60, 79)

        TimelineTop = 10

        Using conn As New SqlConnection(connStr)

            conn.Open()

            Dim sql As String = "SELECT 
                                w.RegistryDate,
                                w.HeadSuperVisorTimeAndDateApprove AS HeadTime,
                                w.Notedby1TimeAndDate AS ChiefTime,
                                w.ApprovedByTimeAndDate AS OpTime,
                                w.ApprovedForReleaseByTimeAndDate AS SupplyTime,
                                w.PR_ApproveToPurchaseByFMDateAndTime AS FinanceTime,

                                w.HeadSupervisorStatus,
                                w.Notedby1Status,
                                w.ApprovedByStatus,
                                w.ApprovedForReleaseByStatus,
                                w.PR_Acknowledge_Flag,

                                w.IsMaterialsNeeded,

                                rm.StockSource,
                                rm.Materials_Availability_Post_Flag,

                                rm.TimeAndDateMatRegPosted,
                                rm.TimeAndDate_Materials_Availability_Update,
                                rm.ApprovedForReleaseByTimeAndDate AS MaterialReleaseTime

                            FROM WorkOrderForm w
                            LEFT JOIN RequestedMaterials rm
                                ON w.Pk_WorkOrderNo = rm.Pk_WorkOrderNo
                            WHERE w.Pk_WorkOrderNo = @WO"

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@WO", WorkOrderNo)

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If Not dr.Read() Then Exit Sub
                    Dim registryDate As DateTime = Convert.ToDateTime(dr("RegistryDate"))


                    ' ================= REGISTRY =================
                    AddStep("Registry", registryDate, registryDate, Color.Gray)


                    ' ================= HEAD =================
                    If Not IsDBNull(dr("HeadTime")) Then
                        AddStep("Head Supervisor", registryDate, Convert.ToDateTime(dr("HeadTime")), Color.LimeGreen)
                    Else
                        AddPendingStep("Head Supervisor")
                    End If


                    ' ================= CHIEF =================
                    If Not IsDBNull(dr("ChiefTime")) Then
                        AddStep("Chief Engineer", registryDate, Convert.ToDateTime(dr("ChiefTime")), Color.LimeGreen)
                    Else
                        AddPendingStep("Chief Engineer")
                    End If


                    ' ================= OPERATION =================
                    If Not IsDBNull(dr("OpTime")) Then
                        AddStep("Operation Director", registryDate, Convert.ToDateTime(dr("OpTime")), Color.LimeGreen)
                    Else
                        AddPendingStep("Operation Director")
                    End If


                    ' ================= MATERIALS STAGE (NEW IMPORTANT LAYER) =================
                    If dr("IsMaterialsNeeded").ToString().ToUpper() = "YES" Then

                        If Not IsDBNull(dr("TimeAndDateMatRegPosted")) Then
                            Dim matStart As DateTime =
                             Convert.ToDateTime(dr("TimeAndDateMatRegPosted"))

                            If Not IsDBNull(dr("TimeAndDate_Materials_Availability_Update")) Then
                                Dim matEnd As DateTime =
                                Convert.ToDateTime(dr("TimeAndDate_Materials_Availability_Update"))
                                AddStep("Materials - Available / Confirmed",
                                 matStart,
                                 matEnd,
                                Color.LimeGreen)
                            Else
                                AddStep("Materials - WAITING / STOCK CHECK (COMMON DELAY SOURCE)",
                                matStart,
                                DateTime.Now,
                                Color.OrangeRed)
                            End If
                        Else
                            AddPendingStep("Materials Request")
                        End If
                    End If



                    ' ================= SUPPLY CHAIN =================
                    Dim supplyActive As Boolean =
                        dr("IsMaterialsNeeded").ToString().ToUpper() = "YES" AndAlso
                        dr("StockSource").ToString().ToUpper() = "SC"

                    If supplyActive Then
                        If Not IsDBNull(dr("TimeAndDate_Materials_Availability_Update")) Then

                            Dim scStart As DateTime =
                            Convert.ToDateTime(dr("TimeAndDate_Materials_Availability_Update"))

                            If Not IsDBNull(dr("MaterialReleaseTime")) Then

                                Dim scEnd As DateTime =
                                Convert.ToDateTime(dr("MaterialReleaseTime"))

                                AddStep("Supply Chain",
                                scStart,
                                scEnd,
                                Color.LimeGreen)
                            Else

                                AddStep("Supply Chain - Waiting For Release",
                             scStart,
                             DateTime.Now,
                             Color.OrangeRed)
                            End If
                        Else
                            AddPendingStep("Supply Chain")
                        End If
                    End If




                    ' ================= FINANCE =================
                    If dr("PR_Acknowledge_Flag").ToString() = "1" Then
                        If Not IsDBNull(dr("FinanceTime")) Then
                            AddStep("Finance", registryDate, Convert.ToDateTime(dr("FinanceTime")), Color.LimeGreen)
                        Else
                            AddPendingStep("Finance")
                        End If
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
        .Width = pnlTimeline.ClientSize.Width - 30,
        .Height = 55,
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
        .Height = 55,
        .Left = 12,
        .ForeColor = Color.White,
        .Text = $"{title} | {days} day(s)",
        .TextAlign = ContentAlignment.MiddleLeft
    }

        stepPanel.Controls.Add(colorBar)
        stepPanel.Controls.Add(lbl)

        pnlTimeline.Controls.Add(stepPanel)

        TimelineTop += 65

    End Sub

    Private Sub AddPendingStep(title As String)

        Dim stepPanel As New Panel With {
            .Width = pnlTimeline.ClientSize.Width - 30,
            .Height = 55,
            .Left = 30,
            .Top = TimelineTop,
            .BackColor = Color.DarkGoldenrod
        }

        Dim lbl As New Label With {
            .AutoSize = False,
            .Width = stepPanel.Width - 10,
            .Height = 55,
            .ForeColor = Color.White,
            .Text = $"{title} | PENDING",
            .TextAlign = ContentAlignment.MiddleLeft
        }

        stepPanel.Controls.Add(lbl)
        pnlTimeline.Controls.Add(stepPanel)

        TimelineTop += 65

    End Sub

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

                .BackgroundColor = Color.FromArgb(44, 60, 79)
                .DefaultCellStyle.BackColor = Color.FromArgb(44, 60, 79)
                .DefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray
                .DefaultCellStyle.SelectionForeColor = Color.White

                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 60, 79)
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

End Class