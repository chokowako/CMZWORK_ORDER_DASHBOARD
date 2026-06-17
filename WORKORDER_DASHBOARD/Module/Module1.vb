Imports System.Data.SqlClient

Module Module1
    Dim result As String
    ' Dim Temp_WorkOrder As String
    Public myconnection As New SqlConnection
    Public temp_workorder As String
    Public connStr As String = "Server='" & My.Settings.ServerName & "';
        Database='" & My.Settings.DBName & "';
        User Id='" & My.Settings.DBUsername & "';
        Password='" & My.Settings.DBPassword & "';
        MultipleActiveResultSets=true;Integrated Security=True;Persist Security Info=False;Trusted_Connection=false;Encrypt=False;TrustServerCertificate=True;"

    Public pageSize As Integer = 100
    Public currentPage As Integer = 1
    Public totalRecords As Integer = 0

    Public Async Function Load_Dashboard_Pagination() As Task

        Dim dt As New DataTable()
        Dim offset As Integer = (currentPage - 1) * pageSize

        Try
            ' =========================
            ' GET DATA (PAGINATION)
            ' =========================
            Using con As New SqlConnection(connStr)
                Await con.OpenAsync()

                Dim sql As String =
            "SELECT 
                PK_WorkOrderNo as [Woms No.],
                Work_Description as [Work Description],
                Status,
                RegistryDate as [Registry Date],
                RequestedBy as [Requested By],
                Unit_Section as [Unit Section],
                HeadSupervisor as [Head Supervisor]
            FROM WorkOrderForm
            ORDER BY PK_WorkOrderNo
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY;

            SELECT COUNT(*) FROM WorkOrderForm;"

                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Offset", offset)
                    cmd.Parameters.AddWithValue("@PageSize", pageSize)

                    Using da As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        da.Fill(ds)

                        dt = ds.Tables(0)
                        totalRecords = Convert.ToInt32(ds.Tables(1).Rows(0)(0))
                    End Using
                End Using
            End Using

            ' =========================
            ' GRID REFERENCE
            ' =========================
            Dim grid As DataGridView = DashBoard.DataGridView

            ' =========================
            ' RESET GRID
            ' =========================
            grid.DataSource = Nothing
            grid.Columns.Clear()

            ' =========================
            ' LEGEND COLUMN 1
            ' =========================
            Dim legend1 As New DataGridViewTextBoxColumn With {
            .HeaderText = "",
            .Name = "Legend1",
            .Width = 20,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .ReadOnly = True
        }

            ' =========================
            ' LEGEND COLUMN 2
            ' =========================
            Dim legend2 As New DataGridViewTextBoxColumn With {
            .HeaderText = "",
            .Name = "Legend2",
            .Width = 20,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .ReadOnly = True
        }

            grid.Columns.Add(legend1)
            grid.Columns.Add(legend2)

            ' =========================
            ' BUTTON COLUMN
            ' =========================
            Dim btnView As New DataGridViewButtonColumn With {
            .HeaderText = "Detail",
            .Name = "View",
            .Text = "View",
            .UseColumnTextForButtonValue = True,
            .Width = 70,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

            grid.Columns.Add(btnView)

            ' =========================
            ' BIND DATA
            ' =========================
            grid.DataSource = dt

            ' =========================
            ' GRID SETTINGS (STABLE)
            ' =========================
            With grid
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .ReadOnly = True
                .MultiSelect = True
                .RowHeadersVisible = False
                .RowTemplate.Height = 40

                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                .ColumnHeadersHeight = 30

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                .CellBorderStyle = DataGridViewCellBorderStyle.None
            End With

            ' =========================
            ' FORCE COLUMN WIDTHS (IMPORTANT)
            ' =========================
            If grid.Columns.Contains("Woms No.") Then grid.Columns("Woms No.").Width = 120
            If grid.Columns.Contains("Work Description") Then grid.Columns("Work Description").Width = 450
            If grid.Columns.Contains("Status") Then grid.Columns("Status").Width = 100
            If grid.Columns.Contains("Registry Date") Then grid.Columns("Registry Date").Width = 120
            If grid.Columns.Contains("Requested By") Then grid.Columns("Requested By").Width = 120
            If grid.Columns.Contains("Unit Section") Then grid.Columns("Unit Section").Width = 120
            If grid.Columns.Contains("Head Supervisor") Then grid.Columns("Head Supervisor").Width = 120

            ' Wrap description
            If grid.Columns.Contains("Work Description") Then
                grid.Columns("Work Description").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End If

            ' Date format
            If grid.Columns.Contains("Registry Date") Then
                grid.Columns("Registry Date").DefaultCellStyle.Format = "MMM dd, yyyy"
            End If

            ' =========================
            ' MOVE BUTTON AFTER LEGENDS
            ' =========================
            grid.Columns("View").DisplayIndex = 2

            ' =========================
            ' PAGINATION LABEL
            ' =========================
            Dim maxPage As Integer = CInt(Math.Ceiling(totalRecords / CDbl(pageSize)))

            DashBoard.lblWomstitle.Text =
            $"Page {currentPage} / {maxPage} | Total Records: {totalRecords:N0}"

            ' =========================
            ' CLEAN SELECTION
            ' =========================
            grid.ClearSelection()
            grid.CurrentCell = Nothing

        Catch ex As Exception
            MessageBox.Show("Pagination Error: " & ex.Message)
        End Try

        ApplyWorkOrderColors()
        ApplyReColors()
    End Function



    Public Async Function Load_Dashboard() As Task

        Dim myConnection As New SqlConnection(connStr)
        Await myConnection.OpenAsync()

        DashBoard.DataGridView.DataSource = Nothing
        DashBoard.DataGridView.Refresh()
        DashBoard.DataGridView.Columns.Clear()


        ' =====================================================
        ' LEGEND COLUMN 1 (WOF Status)
        ' =====================================================

        Dim textLegend_New As New DataGridViewTextBoxColumn
        With textLegend_New
            .HeaderText = ""
            .Name = "LegendMaterials"
            .Width = 20
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .ReadOnly = True
        End With
        DashBoard.DataGridView.Columns.Add(textLegend_New)


        ' =====================================================
        ' LEGEND COLUMN 2 (Materials Status)
        ' =====================================================
        Dim textLegend_Materials As New DataGridViewTextBoxColumn
        With textLegend_Materials
            .HeaderText = ""
            .Name = "LegendMaterials"
            .Width = 20
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .ReadOnly = True
        End With
        DashBoard.DataGridView.Columns.Add(textLegend_Materials)


        ' =====================================================
        ' VIEW BUTTON (DETAIL)
        ' =====================================================
        Dim btnView As New DataGridViewButtonColumn

        With btnView
            .HeaderText = "Detail"
            .Name = "View"
            .Text = "View"
            .UseColumnTextForButtonValue = True

            ' ✔ SMALL SIZE
            .Width = 70
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            ' ✔ CLEAN LOOK
            .DefaultCellStyle.Padding = New Padding(2)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font("Segoe UI", 8, FontStyle.Regular)

        End With

        DashBoard.DataGridView.Columns.Add(btnView)
        DashBoard.DataGridView.Columns("View").DisplayIndex = 2




        Try

            Using Mycommand1 As New SqlCommand("
            SELECT 
                a.PK_WorkOrderNo as [Woms No.],
                a.Work_Description as [Work Description],
                a.Status,
                a.RegistryDate as [Registry Date],
                a.RequestedBy as [Requested By],
                a.Unit_Section as [Unit Section],
                a.HeadSupervisor  as [Head Supervisor]
            FROM WorkOrderForm a
            ORDER BY a.PK_WorkOrderNo", myConnection)

                Using sda As New SqlDataAdapter(Mycommand1)
                    Dim dt As New DataTable()
                    sda.Fill(dt)

                    DashBoard.DataGridView.AutoGenerateColumns = True
                    DashBoard.DataGridView.DataSource = dt

                    ' =========================
                    ' FORMAT COLUMNS
                    ' =========================
                    With DashBoard.DataGridView

                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                        .AllowUserToAddRows = False
                        .ReadOnly = True
                        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .CellBorderStyle = DataGridViewCellBorderStyle.None
                        .MultiSelect = True
                        .RowHeadersVisible = False
                        .RowTemplate.Height = 40

                        ' Header Height
                        .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                        .ColumnHeadersHeight = 30
                    End With

                    ' =========================
                    ' COLUMN WIDTHS
                    ' =========================
                    With DashBoard.DataGridView

                        .Columns("Woms No.").Width = 120
                        .Columns("Work Description").Width = 450
                        .Columns("Status").Width = 100
                        .Columns("Registry Date").Width = 120
                        .Columns("Requested By").Width = 120
                        .Columns("Unit Section").Width = 120
                        .Columns("Head Supervisor").Width = 120

                        .Columns("Work Description").DefaultCellStyle.WrapMode =
                        DataGridViewTriState.True
                    End With

                    ' =========================
                    ' DATE FORMAT
                    ' =========================
                    If DashBoard.DataGridView.Columns.Contains("RegistryDate") Then
                        DashBoard.DataGridView.Columns("RegistryDate").DefaultCellStyle.Format = "MMM dd, yyyy"
                    End If


                    ' =========================
                    ' TOTAL RECORDS
                    ' =========================
                    Dim totalRecords As Integer = dt.Rows.Count
                    DashBoard.lblWomstitle.Text =
                    $"Work Order List | Total Records: {totalRecords:N0}"

                    ' =========================
                    ' CLEAN SELECTION
                    ' =========================
                    DashBoard.DataGridView.ClearSelection()
                    DashBoard.DataGridView.CurrentCell = Nothing

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        End Try

        ApplyWorkOrderColors()
        ApplyReColors()

        'CountAllMaterialColorsFromData()




    End Function


    Public Async Function Load_Delay_Aging() As Task

        DashBoard.DataGridView_delayed.DataSource = Nothing
        DashBoard.DataGridView_delayed.Refresh()
        DashBoard.DataGridView_delayed.Columns.Clear()

        Dim dt As New DataTable()

        Using conn As New SqlConnection(connStr)
            Await conn.OpenAsync()

            Dim sql As String = "SELECT 
                                DelayRange,
                                COUNT(*) AS TotalDelayed
                            FROM (
                                SELECT 
                                    CASE 
                                        WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 0 AND 10 THEN '1-10 Days'
                                        WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 11 AND 30 THEN '11-30 Days'
                                        WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 31 AND 50 THEN '31-50 Days'
                                        WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 51 AND 100 THEN '51-100 Days'
                                        ELSE '100+ Days'
                                    END AS DelayRange

                                FROM WorkOrderForm
                                WHERE Status <> 'Completed'
                            ) T
                            GROUP BY DelayRange
                            ORDER BY 
                                CASE DelayRange
                                    WHEN '1-10 Days' THEN 1
                                    WHEN '11-30 Days' THEN 2
                                    WHEN '31-50 Days' THEN 3
                                    WHEN '51-100 Days' THEN 4
                                    ELSE 5 END "

            Using cmd As New SqlCommand(sql, conn)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    ' FORMAT COLUMNS
                    ' =========================
                    With DashBoard.DataGridView_delayed

                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                        .AllowUserToAddRows = False
                        .ReadOnly = True
                        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .CellBorderStyle = DataGridViewCellBorderStyle.None
                        .MultiSelect = True
                        .RowHeadersVisible = False
                        .RowTemplate.Height = 40
                    End With

                End Using
            End Using
        End Using

        ' Bind data
        DashBoard.DataGridView_delayed.DataSource = dt

        ' =====================================
        ' ADD VIEW BUTTON COLUMN
        ' =====================================
        If Not DashBoard.DataGridView_delayed.Columns.Contains("View") Then

            Dim btnView As New DataGridViewButtonColumn

            With btnView
                .HeaderText = "Detail"
                .Name = "View"
                .Text = "      View       "
                .UseColumnTextForButtonValue = True
                .Width = 120
                .DefaultCellStyle.Padding = New Padding(5)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Font = New Font("Segoe UI", 8, FontStyle.Regular)
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            DashBoard.DataGridView_delayed.Columns.Add(btnView)

            ' Make button first column
            DashBoard.DataGridView_delayed.Columns("View").DisplayIndex = 0

        End If

        ' =====================================
        ' REMOVE DEFAULT SELECTION
        ' =====================================
        DashBoard.DataGridView_delayed.ClearSelection()
        DashBoard.DataGridView_delayed.CurrentCell = Nothing


    End Function

    Public Async Function Load_Delay_Aging_Chart() As Task

        Dim dt As New DataTable()

        Using conn As New SqlConnection(connStr)
            Await conn.OpenAsync()

            Dim sql As String = "SELECT 
    DelayRange,
    COUNT(*) AS TotalDelayed
FROM (
    SELECT 
        CASE 
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 0 AND 10 THEN '1-10 Days'
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 11 AND 30 THEN '11-30 Days'
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 31 AND 50 THEN '31-50 Days'
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 51 AND 100 THEN '51-100 Days'
            ELSE '100+ Days'
        END AS DelayRange,

        CASE 
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 0 AND 10 THEN 1
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 11 AND 30 THEN 2
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 31 AND 50 THEN 3
            WHEN DATEDIFF(DAY, RegistryDate, GETDATE()) BETWEEN 51 AND 100 THEN 4
            ELSE 5
        END AS SortOrder

    FROM WorkOrderForm
    WHERE Status <> 'Completed'
) AS T
GROUP BY DelayRange, SortOrder
ORDER BY SortOrder
        "

            Using cmd As New SqlCommand(sql, conn)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        ' =========================
        ' BIND TO CHART
        ' =========================
        With DashBoard.ChartDelayAging
            .Series.Clear()
            .ChartAreas(0).BackColor = Color.FromArgb(44, 60, 79)
            .BackColor = Color.FromArgb(44, 60, 79)

            Dim series As New DataVisualization.Charting.Series("Delayed Aging")
            series.ChartType = DataVisualization.Charting.SeriesChartType.Column
            series.IsValueShownAsLabel = True
            series.LabelForeColor = Color.White
            series.Font = New Font("Segoe UI", 9, FontStyle.Bold)

            For Each row As DataRow In dt.Rows

                Dim range As String = row("DelayRange").ToString()
                Dim value As Integer = Convert.ToInt32(row("TotalDelayed"))

                Dim pointIndex As Integer = series.Points.AddXY(range, value)

                ' =========================
                ' COLOR DESIGN (IMPORTANT)
                ' =========================
                Select Case range

                    Case "1-10 Days"
                        series.Points(pointIndex).Color = Color.RoyalBlue

                    Case "11-30 Days"
                        series.Points(pointIndex).Color = Color.Gold

                    Case "31-50 Days"
                        series.Points(pointIndex).Color = Color.Orange

                    Case "51-100 Days"
                        series.Points(pointIndex).Color = Color.OrangeRed

                    Case "100+ Days"
                        series.Points(pointIndex).Color = Color.DarkRed

                End Select

            Next

            .Series.Add(series)

            ' =========================
            ' AXIS DESIGN
            ' =========================
            With .ChartAreas(0)
                .AxisX.LabelStyle.ForeColor = Color.White
                .AxisY.LabelStyle.ForeColor = Color.White
                .AxisX.MajorGrid.LineColor = Color.DimGray
                .AxisY.MajorGrid.LineColor = Color.DimGray
            End With

            .ChartAreas(0).BackColor = Color.FromArgb(44, 60, 79)
            .Legends(0).Enabled = False
        End With

    End Function



End Module
