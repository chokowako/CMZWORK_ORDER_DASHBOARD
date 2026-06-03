Imports System.Data.SqlClient
Public Class FrmDelayAgingList
    Public Property SelectedDelayRange As String
    Private Async Sub FrmDelayAgingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadDelayAgingList()
    End Sub
    Public Async Function LoadDelayAgingList() As Task

        Dim dt As New DataTable()

        Using conn As New SqlConnection(connStr)

            Await conn.OpenAsync()

            Dim sql As String = "
        SELECT

            CASE
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 0 AND 10 THEN '1-10 Days'
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 11 AND 30 THEN '11-30 Days'
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 31 AND 50 THEN '31-50 Days'
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 51 AND 100 THEN '51-100 Days'
                ELSE '100+ Days'
            END AS DelayRange,

            Pk_WorkOrderNo,
            Work_Description,
            Status,
            RegistryDate,
            RequestedBy,
            Unit_Section,

            DATEDIFF(DAY, RegistryDate, GETDATE()) AS AgingDays,

            CASE
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 0 AND 10 THEN 1
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 11 AND 30 THEN 2
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 31 AND 50 THEN 3
                WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 51 AND 100 THEN 4
                ELSE 5
            END AS SortOrder

        FROM WorkOrderForm
        WHERE Status <> 'Completed'
        "

            Select Case SelectedDelayRange

                Case "1-10 Days"
                    sql &= " AND DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 0 AND 10"

                Case "11-30 Days"
                    sql &= " AND DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 11 AND 30"

                Case "31-50 Days"
                    sql &= " AND DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 31 AND 50"

                Case "51-100 Days"
                    sql &= " AND DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 51 AND 100"

                Case "100+ Days"
                    sql &= " AND DATEDIFF(DAY, RegistryDate, GETDATE()) > 100"

            End Select

            sql &= "
        ORDER BY SortOrder, AgingDays
        "

            Using cmd As New SqlCommand(sql, conn)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

        End Using

        ' =========================
        ' BIND DATA
        ' =========================
        DataGridView1.DataSource = dt


        ' =========================
        ' ADD BUTTON COLUMN FIRST
        ' =========================
        If Not DataGridView1.Columns.Contains("btnView") Then

            Dim btn As New DataGridViewButtonColumn()

            btn.Name = "btnView"
            btn.HeaderText = ""
            btn.Text = "View"
            btn.UseColumnTextForButtonValue = True
            btn.Width = 70

            DataGridView1.Columns.Insert(0, btn)

        End If

        ' =========================
        ' GRID SETTINGS (IMPORTANT)
        ' =========================
        With DataGridView1

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False

            .RowTemplate.Height = 45
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        End With

        ' =========================
        ' COLUMN WIDTHS
        ' =========================
        With DataGridView1

            .Columns("DelayRange").Width = 120
            .Columns("Pk_WorkOrderNo").Width = 120
            .Columns("Status").Width = 100
            .Columns("RegistryDate").Width = 120
            .Columns("AgingDays").Width = 90
            .Columns("RequestedBy").Width = 120
            .Columns("Unit_Section").Width = 120

            ' ⭐ MAIN FOCUS COLUMN
            .Columns("Work_Description").Width = 450
            .Columns("Work_Description").DefaultCellStyle.WrapMode =
            DataGridViewTriState.True

        End With

        ' =========================
        ' FORMAT DATE
        ' =========================
        If DataGridView1.Columns.Contains("RegistryDate") Then
            DataGridView1.Columns("RegistryDate").DefaultCellStyle.Format = "MMM dd, yyyy"
        End If

        ' =========================
        ' HIDE TECHNICAL COLUMN
        ' =========================
        If DataGridView1.Columns.Contains("SortOrder") Then
            DataGridView1.Columns("SortOrder").Visible = False
        End If

        ' =========================
        ' TITLE
        ' =========================
        lblTitle.Text =
        $"{SelectedDelayRange} Delayed Work Orders : {dt.Rows.Count:N0} Records"

        ' =========================
        ' CLEAN SELECTION
        ' =========================
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Function


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub

        ' CHECK BUTTON COLUMN BY NAME
        If DataGridView1.Columns(e.ColumnIndex).Name = "btnView" Then

            Dim workOrderNo As String =
            DataGridView1.Rows(e.RowIndex).Cells("Pk_WorkOrderNo").Value.ToString()

            Dim frm As New Preview
            frm.TxtWorkOrderNo.Text = workOrderNo
            frm.ShowDialog(Me)

        End If
    End Sub
End Class