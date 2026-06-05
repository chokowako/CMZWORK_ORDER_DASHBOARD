Imports System.Data.SqlClient
Imports System.Data

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




        '############ WOF COLOR STATUS #####################################################################################
        'For i As Integer = 0 To DashBoard.DataGridView.Rows.Count - 1
        '    Using mycommandHead As New SqlCommand("select HeadSupervisorStatus,Notedby1Status,ApprovedByStatus,Materials_Availability_Post_Flag,ProceedWO_Flag,TagAsClose,Pk_WorkOrderNo,IsMaterialsNeeded from WorkOrderForm where Pk_WorkOrderNo = @Pk_WorkOrderNo", myConnection)
        '        mycommandHead.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '        Using myreaderHead As SqlDataReader = mycommandHead.ExecuteReader
        '            If myreaderHead.Read = True Then
        '                ' MessageBox.Show(DASHBOARD.DataGridView.Rows(i).Cells(3).Value)
        '                If myreaderHead!IsMaterialsNeeded.ToString = "Yes" Then

        '                    If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Pink
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Pending Materials"



        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Pink
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Pending Materials"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag <> 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                    End If






        '                ElseIf Convert.IsDBNull(myreaderHead!IsMaterialsNeeded) Then
        '                    If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Blue
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Approved"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "CLOSED" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"
        '                    End If



        '                ElseIf myreaderHead!IsMaterialsNeeded.ToString = "No" Then

        '                    If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Blue
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Approved"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                    ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "CLOSE" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                        DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.DarkBlue
        '                        DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Complete"
        '                    End If
        '                End If
        '            End If
        '        End Using
        '    End Using
        'Next
        ''##################################################################################################################



        ''############ FOR MATERIALS ######################################################################################

        'For i As Integer = 0 To DashBoard.DataGridView.Rows.Count - 1
        '    Using Mycommand As New SqlCommand("select a.Pk_WorkOrderNo,b.ApprovedForReleaseByStatus from RequestedMaterials a 
        '                                        INNER JOIN WorkOrderForm b on b.Pk_WorkOrderNo = a.Pk_WorkOrderNo where  a.Pk_WorkOrderNo = @Pk_WorkOrderNo", myConnection)
        '        Mycommand.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '        Using myreader = Mycommand.ExecuteReader()
        '            If myreader.Read = True Then
        '                ' MessageBox.Show("meron")

        '                Dim StockSource_EM As Integer
        '                Using MycommandStockeSourceEM As New SqlCommand("select Pk_WorkOrderNo,StockSource from RequestedMaterials  where  Pk_WorkOrderNo =@Pk_WorkOrderNo and StockSource=@StockSource", myConnection)
        '                    MycommandStockeSourceEM.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                    MycommandStockeSourceEM.Parameters.AddWithValue("@StockSource", "EM")
        '                    Using myreaderyStockSourceEM = MycommandStockeSourceEM.ExecuteReader()
        '                        If myreaderyStockSourceEM.Read = True Then
        '                            StockSource_EM = StockSource_EM + 1
        '                        End If
        '                    End Using
        '                End Using

        '                Dim StockSource_SC As Integer
        '                Using MycommandStockSourceSC As New SqlCommand("select Pk_WorkOrderNo,StockSource from RequestedMaterials  where  Pk_WorkOrderNo =@Pk_WorkOrderNo and StockSource=@StockSource", myConnection)
        '                    MycommandStockSourceSC.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                    MycommandStockSourceSC.Parameters.AddWithValue("@StockSource", "SC")
        '                    Using myreaderStockSourceSC = MycommandStockSourceSC.ExecuteReader()
        '                        If myreaderStockSourceSC.Read = True Then
        '                            StockSource_SC = StockSource_SC + 1
        '                        End If
        '                    End Using
        '                End Using

        '                Dim Matvalidatedby As Integer
        '                Using MycommandMatAvailable As New SqlCommand("select Pk_WorkOrderNo,Materials_Availability_ValidateBy from RequestedMaterials  where Materials_Availability_ValidateBy ='PENDING' and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                    MycommandMatAvailable.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                    Using myreaderMatvalidatedby = MycommandMatAvailable.ExecuteReader()
        '                        If myreaderMatvalidatedby.Read = True Then
        '                            Matvalidatedby = Matvalidatedby + 1
        '                        End If
        '                    End Using
        '                End Using



        '                Dim QTY_Available_SC_Post_Flag_1 As Integer
        '                Using MycommandQty_PostFlag_1 As New SqlCommand("select Pk_WorkOrderNo,QTY_Available_SC_Post_Flag from RequestedMaterials  where Materials_Availability_Post_Flag =1 and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                    MycommandQty_PostFlag_1.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                    Using myreaderQty_PostFlag_1 = MycommandQty_PostFlag_1.ExecuteReader()
        '                        If myreaderQty_PostFlag_1.Read = True Then
        '                            QTY_Available_SC_Post_Flag_1 = QTY_Available_SC_Post_Flag_1 + 1
        '                        End If
        '                    End Using
        '                End Using

        '                Dim QTY_Available_SC_Post_Flag_2 As Integer
        '                Using MycommandQty_PostFlag_2 As New SqlCommand("select Pk_WorkOrderNo,Materials_Availability_Post_Flag from RequestedMaterials  where Materials_Availability_Post_Flag = 2 and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                    MycommandQty_PostFlag_2.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                    Using myreaderQty_PostFlag_2 = MycommandQty_PostFlag_2.ExecuteReader()
        '                        If myreaderQty_PostFlag_2.Read = True Then
        '                            QTY_Available_SC_Post_Flag_2 = QTY_Available_SC_Post_Flag_2 + 1
        '                        End If
        '                    End Using
        '                End Using


        '                Using MycommandQty As New SqlCommand("select sum(total_Qty) as Sum_Total_Qty,sum(QTY_Recieve) as Sum_Total_Qty_Receive from RequestedMaterials  where Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                    MycommandQty.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                    Using myreaderQty = MycommandQty.ExecuteReader()
        '                        If myreaderQty.Read = True Then

        '                            Dim temp_Sum_Total_Qty = myreaderQty!Sum_Total_Qty
        '                            Dim temp_Sum_Total_Qty_Receive = myreaderQty!Sum_Total_Qty_Receive

        '                            If StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                            ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                            ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"



        '                                '----
        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "With SC"

        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "for purchase"
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                ' DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"





        '                                '----
        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"



        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"



        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"




        '                            ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                            ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                            ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                            ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive = 0 Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"




        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


        '                            ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                            ElseIf StockSource_EM = 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"
        '                            End If


        '                            DashBoard.DataGridView.Rows(i).Cells(3).ReadOnly = True

        '                        End If
        '                    End Using
        '                End Using
        '                StockSource_EM = 0
        '                StockSource_SC = 0
        '                Matvalidatedby = 0
        '                QTY_Available_SC_Post_Flag_1 = 0
        '                QTY_Available_SC_Post_Flag_2 = 0
        '            ElseIf myreader.Read = False Then
        '                ' MessageBox.Show("wala")

        '            End If
        '        End Using
        '    End Using
        'Next i
        '##################################################################################################################

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
