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


        Dim textLegend_New As New DataGridViewTextBoxColumn
        With textLegend_New
            .HeaderText = ""
            .Name = ""
            .Width = 5
            .FillWeight = 7
            .ToolTipText = "WOF Status"
            DashBoard.DataGridView.Columns.Add(textLegend_New)
        End With



        Dim textLegend_Materials As New DataGridViewTextBoxColumn
        With textLegend_Materials
            .HeaderText = ""
            .Name = ""
            .Width = 5
            .FillWeight = 7
            .ToolTipText = "Materials Status"
            DashBoard.DataGridView.Columns.Add(textLegend_Materials)
        End With



        'For Button inside Work Order 
        Dim btnView As New DataGridViewButtonColumn
        With btnView
            .HeaderText = "Detail"
            .Text = "      View       "
            .Name = "View"
            .UseColumnTextForButtonValue = True
            .Width = 300
            .DefaultCellStyle.Padding = New Padding(5)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Font = New Font("Segoe UI", 8, FontStyle.Regular)
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DashBoard.DataGridView.Columns.Add(btnView)
        End With





        Try
            Using Mycommand1 As New SqlCommand("select a.PK_WorkOrderNo,a.Work_Description,a.Status,a.RegistryDate,
                                            a.RequestedBy,
                                            a.Unit_Section,
                                            a.HeadSupervisor from WorkOrderForm a order by PK_WorkOrderNo", myConnection)
                Mycommand1.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(Mycommand1)
                    Using ds As New DataSet()
                        sda.Fill(ds)
                        'Set AutoGenerateColumns False
                        DashBoard.DataGridView.AutoGenerateColumns = False
                        DashBoard.DataGridView.ColumnCount = 10
                        DashBoard.DataGridView.RowTemplate.Height = 30

                        DashBoard.DataGridView.Columns(3).Name = "Pk_WorkOrderNo"
                        DashBoard.DataGridView.Columns(3).HeaderText = "Work Order No."
                        DashBoard.DataGridView.Columns(3).DataPropertyName = "Pk_WorkOrderNo"
                        ' DASHBOARD.DataGridView.Columns(3).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.Columns(4).Name = "Status"
                        DashBoard.DataGridView.Columns(4).HeaderText = "Status"
                        DashBoard.DataGridView.Columns(4).DataPropertyName = "Status"
                        ' DASHBOARD.DataGridView.Columns(4).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.Columns(5).Name = "Work_Description"
                        DashBoard.DataGridView.Columns(5).HeaderText = "Work Description"
                        DashBoard.DataGridView.Columns(5).DataPropertyName = "Work_Description"
                        ' DASHBOARD.DataGridView.Columns(3).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.Columns(6).Name = "RegistryDate"
                        DashBoard.DataGridView.Columns(6).HeaderText = "RegistryDate"
                        DashBoard.DataGridView.Columns(6).DataPropertyName = "RegistryDate"
                        ' DASHBOARD.DataGridView.Columns(4).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.Columns(7).Name = "Requested by"
                        DashBoard.DataGridView.Columns(7).HeaderText = "Requested by"
                        DashBoard.DataGridView.Columns(7).DataPropertyName = "RequestedBy"
                        'DASHBOARD.DataGridView.Columns(4).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.Columns(8).Name = "Unit_Section"
                        DashBoard.DataGridView.Columns(8).HeaderText = "Unit Section"
                        DashBoard.DataGridView.Columns(8).DataPropertyName = "Unit_Section"
                        'DASHBOARD.DataGridView.Columns(4).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.Columns(9).Name = "checked by"
                        DashBoard.DataGridView.Columns(9).HeaderText = "checked by"
                        DashBoard.DataGridView.Columns(9).DataPropertyName = "HeadSupervisor"
                        'DASHBOARD.DataGridView.Columns(4).Width = 75  '// Or whatever width works well For abbrev

                        DashBoard.DataGridView.DataSource = ds.Tables(0)


                        '✅ REMOVE DEFAULT SELECTION
                        If DashBoard.DataGridView.Rows.Count > 0 Then
                            DashBoard.DataGridView.ClearSelection()
                            DashBoard.DataGridView.CurrentCell = Nothing
                        End If



                    End Using
                End Using
            End Using
            DashBoard.DataGridView.ClearSelection()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
            ' myconnection.Close()
            ' myconnection.Dispose()
        End Try


        '############ WOF COLOR STATUS #####################################################################################
        For i As Integer = 0 To DashBoard.DataGridView.Rows.Count - 1
            Using mycommandHead As New SqlCommand("select HeadSupervisorStatus,Notedby1Status,ApprovedByStatus,Materials_Availability_Post_Flag,ProceedWO_Flag,TagAsClose,Pk_WorkOrderNo,IsMaterialsNeeded from WorkOrderForm where Pk_WorkOrderNo = @Pk_WorkOrderNo", myConnection)
                mycommandHead.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                Using myreaderHead As SqlDataReader = mycommandHead.ExecuteReader
                    If myreaderHead.Read = True Then
                        ' MessageBox.Show(DASHBOARD.DataGridView.Rows(i).Cells(3).Value)
                        If myreaderHead!IsMaterialsNeeded.ToString = "Yes" Then

                            If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Pink
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Pending Materials"



                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Pink
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Pending Materials"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag <> 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

                                'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
                            End If






                        ElseIf Convert.IsDBNull(myreaderHead!IsMaterialsNeeded) Then
                            If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Blue
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Approved"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "CLOSED" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"
                            End If



                        ElseIf myreaderHead!IsMaterialsNeeded.ToString = "No" Then

                            If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Blue
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Approved"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


                            ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "CLOSE" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
                                DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.DarkBlue
                                DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Complete"
                            End If
                        End If
                    End If
                End Using
            End Using
        Next
        '##################################################################################################################



        '############ FOR MATERIALS ######################################################################################

        For i As Integer = 0 To DashBoard.DataGridView.Rows.Count - 1
            Using Mycommand As New SqlCommand("select a.Pk_WorkOrderNo,b.ApprovedForReleaseByStatus from RequestedMaterials a 
                                                INNER JOIN WorkOrderForm b on b.Pk_WorkOrderNo = a.Pk_WorkOrderNo where  a.Pk_WorkOrderNo = @Pk_WorkOrderNo", myConnection)
                Mycommand.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                Using myreader = Mycommand.ExecuteReader()
                    If myreader.Read = True Then
                        ' MessageBox.Show("meron")

                        Dim StockSource_EM As Integer
                        Using MycommandStockeSourceEM As New SqlCommand("select Pk_WorkOrderNo,StockSource from RequestedMaterials  where  Pk_WorkOrderNo =@Pk_WorkOrderNo and StockSource=@StockSource", myConnection)
                            MycommandStockeSourceEM.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                            MycommandStockeSourceEM.Parameters.AddWithValue("@StockSource", "EM")
                            Using myreaderyStockSourceEM = MycommandStockeSourceEM.ExecuteReader()
                                If myreaderyStockSourceEM.Read = True Then
                                    StockSource_EM = StockSource_EM + 1
                                End If
                            End Using
                        End Using

                        Dim StockSource_SC As Integer
                        Using MycommandStockSourceSC As New SqlCommand("select Pk_WorkOrderNo,StockSource from RequestedMaterials  where  Pk_WorkOrderNo =@Pk_WorkOrderNo and StockSource=@StockSource", myConnection)
                            MycommandStockSourceSC.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                            MycommandStockSourceSC.Parameters.AddWithValue("@StockSource", "SC")
                            Using myreaderStockSourceSC = MycommandStockSourceSC.ExecuteReader()
                                If myreaderStockSourceSC.Read = True Then
                                    StockSource_SC = StockSource_SC + 1
                                End If
                            End Using
                        End Using

                        Dim Matvalidatedby As Integer
                        Using MycommandMatAvailable As New SqlCommand("select Pk_WorkOrderNo,Materials_Availability_ValidateBy from RequestedMaterials  where Materials_Availability_ValidateBy ='PENDING' and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
                            MycommandMatAvailable.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                            Using myreaderMatvalidatedby = MycommandMatAvailable.ExecuteReader()
                                If myreaderMatvalidatedby.Read = True Then
                                    Matvalidatedby = Matvalidatedby + 1
                                End If
                            End Using
                        End Using



                        Dim QTY_Available_SC_Post_Flag_1 As Integer
                        Using MycommandQty_PostFlag_1 As New SqlCommand("select Pk_WorkOrderNo,QTY_Available_SC_Post_Flag from RequestedMaterials  where Materials_Availability_Post_Flag =1 and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
                            MycommandQty_PostFlag_1.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                            Using myreaderQty_PostFlag_1 = MycommandQty_PostFlag_1.ExecuteReader()
                                If myreaderQty_PostFlag_1.Read = True Then
                                    QTY_Available_SC_Post_Flag_1 = QTY_Available_SC_Post_Flag_1 + 1
                                End If
                            End Using
                        End Using

                        Dim QTY_Available_SC_Post_Flag_2 As Integer
                        Using MycommandQty_PostFlag_2 As New SqlCommand("select Pk_WorkOrderNo,Materials_Availability_Post_Flag from RequestedMaterials  where Materials_Availability_Post_Flag = 2 and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
                            MycommandQty_PostFlag_2.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                            Using myreaderQty_PostFlag_2 = MycommandQty_PostFlag_2.ExecuteReader()
                                If myreaderQty_PostFlag_2.Read = True Then
                                    QTY_Available_SC_Post_Flag_2 = QTY_Available_SC_Post_Flag_2 + 1
                                End If
                            End Using
                        End Using


                        Using MycommandQty As New SqlCommand("select sum(total_Qty) as Sum_Total_Qty,sum(QTY_Recieve) as Sum_Total_Qty_Receive from RequestedMaterials  where Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
                            MycommandQty.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
                            Using myreaderQty = MycommandQty.ExecuteReader()
                                If myreaderQty.Read = True Then

                                    Dim temp_Sum_Total_Qty = myreaderQty!Sum_Total_Qty
                                    Dim temp_Sum_Total_Qty_Receive = myreaderQty!Sum_Total_Qty_Receive

                                    If StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

                                    ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

                                    ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"



                                        '----
                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "With SC"

                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "for purchase"
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        ' DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"





                                        '----
                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"



                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"



                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"




                                    ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

                                    ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

                                    ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

                                    ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive = 0 Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"




                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


                                    ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
                                        DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
                                        DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


                                    ElseIf StockSource_EM = 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
                                        'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"
                                    End If


                                    DashBoard.DataGridView.Rows(i).Cells(3).ReadOnly = True

                                End If
                            End Using
                        End Using
                        StockSource_EM = 0
                        StockSource_SC = 0
                        Matvalidatedby = 0
                        QTY_Available_SC_Post_Flag_1 = 0
                        QTY_Available_SC_Post_Flag_2 = 0
                    ElseIf myreader.Read = False Then
                        ' MessageBox.Show("wala")

                    End If
                End Using
            End Using
        Next i
        '##################################################################################################################





        'Try
        '    ' 1. Fetch data on background thread
        '    Dim dt As DataTable = Await Task.Run(Function()
        '                                             Dim table As New DataTable()

        '                                             Using conn As New SqlConnection(connStr)
        '                                                 conn.Open()
        '                                                 Using cmd As New SqlCommand("
        '                                                 SELECT a.PK_WorkOrderNo, a.Work_Description, a.Status, a.RegistryDate,
        '                                                        a.RequestedBy, a.Unit_Section, a.HeadSupervisor
        '                                                 FROM WorkOrderForm a
        '                                                 ORDER BY PK_WorkOrderNo", conn)
        '                                                     Using adapter As New SqlDataAdapter(cmd)
        '                                                         adapter.Fill(table)
        '                                                     End Using
        '                                                 End Using
        '                                             End Using

        '                                             Return table
        '                                         End Function)




        '    ' 2. Update UI on main thread
        '    DashBoard.DataGridView.BeginInvoke(Sub()
        '                                           Dim dgv = DashBoard.DataGridView

        '                                           dgv.SuspendLayout()

        '                                           ' Only add custom columns if they aren't already there
        '                                           If dgv.Columns.Count = 0 Then
        '                                               ' Custom color/status columns
        '                                               dgv.Columns.Add(New DataGridViewTextBoxColumn With {
        '                                               .HeaderText = "", .Name = "StatusColor1", .Width = 5, .FillWeight = 7,
        '                                               .ToolTipText = "WOF Status"
        '                                           })
        '                                               dgv.Columns.Add(New DataGridViewTextBoxColumn With {
        '                                               .HeaderText = "", .Name = "StatusColor2", .Width = 5, .FillWeight = 7,
        '                                               .ToolTipText = "Materials Status"
        '                                           })

        '                                               ' Button Column
        '                                               dgv.Columns.Add(New DataGridViewButtonColumn With {
        '                                               .HeaderText = "Detail",
        '                                               .Text = "      View       ",
        '                                               .Name = "View",
        '                                               .UseColumnTextForButtonValue = True,
        '                                               .Width = 300,
        '                                               .DefaultCellStyle = New DataGridViewCellStyle With {
        '                                                   .Padding = New Padding(5),
        '                                                   .Alignment = DataGridViewContentAlignment.MiddleCenter,
        '                                                   .Font = New Font("Segoe UI", 8, FontStyle.Regular)
        '                                               }
        '                                           })

        '                                               ' Predefine the rest of the columns
        '                                               dgv.AutoGenerateColumns = False
        '                                               dgv.RowTemplate.Height = 30
        '                                               dgv.ColumnCount = 10

        '                                               dgv.Columns(3).Name = "Pk_WorkOrderNo"
        '                                               dgv.Columns(3).HeaderText = "Work Order No."
        '                                               dgv.Columns(3).DataPropertyName = "Pk_WorkOrderNo"

        '                                               dgv.Columns(4).Name = "Status"
        '                                               dgv.Columns(4).HeaderText = "Status"
        '                                               dgv.Columns(4).DataPropertyName = "Status"

        '                                               dgv.Columns(5).Name = "Work_Description"
        '                                               dgv.Columns(5).HeaderText = "Work Description"
        '                                               dgv.Columns(5).DataPropertyName = "Work_Description"

        '                                               dgv.Columns(6).Name = "RegistryDate"
        '                                               dgv.Columns(6).HeaderText = "RegistryDate"
        '                                               dgv.Columns(6).DataPropertyName = "RegistryDate"

        '                                               dgv.Columns(7).Name = "Requested by"
        '                                               dgv.Columns(7).HeaderText = "Requested by"
        '                                               dgv.Columns(7).DataPropertyName = "RequestedBy"

        '                                               dgv.Columns(8).Name = "Unit_Section"
        '                                               dgv.Columns(8).HeaderText = "Unit Section"
        '                                               dgv.Columns(8).DataPropertyName = "Unit_Section"

        '                                               dgv.Columns(9).Name = "checked by"
        '                                               dgv.Columns(9).HeaderText = "checked by"
        '                                               dgv.Columns(9).DataPropertyName = "HeadSupervisor"
        '                                           End If

        '                                           ' Delay slightly to let UI repaint
        '                                           Task.Delay(50).Wait()

        '                                           dgv.DataSource = Nothing
        '                                           dgv.DataSource = dt
        '                                           dgv.ClearSelection()

        '                                           '############ WOF COLOR STATUS #####################################################################################
        '                                           For i As Integer = 0 To DashBoard.DataGridView.Rows.Count - 1
        '                                               Using mycommandHead As New SqlCommand("select HeadSupervisorStatus,Notedby1Status,ApprovedByStatus,Materials_Availability_Post_Flag,ProceedWO_Flag,TagAsClose,Pk_WorkOrderNo,IsMaterialsNeeded from WorkOrderForm where Pk_WorkOrderNo = @Pk_WorkOrderNo", myConnection)
        '                                                   mycommandHead.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                   Using myreaderHead As SqlDataReader = mycommandHead.ExecuteReader
        '                                                       If myreaderHead.Read = True Then
        '                                                           ' MessageBox.Show(DASHBOARD.DataGridView.Rows(i).Cells(3).Value)
        '                                                           If myreaderHead!IsMaterialsNeeded.ToString = "Yes" Then

        '                                                               If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Pink
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Pending Materials"



        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Pink
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Pending Materials"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag = 1 And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!Materials_Availability_Post_Flag <> 0 And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                                                                   'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                   'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                                               End If






        '                                                           ElseIf Convert.IsDBNull(myreaderHead!IsMaterialsNeeded) Then
        '                                                               If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Blue
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Approved"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "CLOSED" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"
        '                                                               End If



        '                                                           ElseIf myreaderHead!IsMaterialsNeeded.ToString = "No" Then

        '                                                               If myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "PENDING" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Yellow
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "New"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "PENDING" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Green
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Acknowledged"

        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 0 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Blue
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Approved"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 1 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "PENDING" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.Orange
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "In-Process"


        '                                                               ElseIf myreaderHead!HeadSupervisorStatus = "CHECKED" And myreaderHead!Notedby1Status = "APPROVED" And myreaderHead!ApprovedByStatus = "APPROVED" And myreaderHead!proceedWO_flag = 2 And myreaderHead!TagAsClose = "CLOSE" And myreaderHead!Pk_WorkOrderNo = DashBoard.DataGridView.Rows(i).Cells(3).Value Then
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).Style.BackColor = Color.DarkBlue
        '                                                                   DashBoard.DataGridView.Rows(i).Cells(0).ToolTipText = "Complete"
        '                                                               End If
        '                                                           End If
        '                                                       End If
        '                                                   End Using
        '                                               End Using
        '                                           Next
        '                                           '##################################################################################################################



        '                                           '############ FOR MATERIALS ######################################################################################

        '                                           For i As Integer = 0 To DashBoard.DataGridView.Rows.Count - 1
        '                                               Using Mycommand As New SqlCommand("select a.Pk_WorkOrderNo,b.ApprovedForReleaseByStatus from RequestedMaterials a 
        '                                                                                   INNER JOIN WorkOrderForm b on b.Pk_WorkOrderNo = a.Pk_WorkOrderNo where  a.Pk_WorkOrderNo = @Pk_WorkOrderNo", myConnection)
        '                                                   Mycommand.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                   Using myreader = Mycommand.ExecuteReader()
        '                                                       If myreader.Read = True Then
        '                                                           ' MessageBox.Show("meron")

        '                                                           Dim StockSource_EM As Integer
        '                                                           Using MycommandStockeSourceEM As New SqlCommand("select Pk_WorkOrderNo,StockSource from RequestedMaterials  where  Pk_WorkOrderNo =@Pk_WorkOrderNo and StockSource=@StockSource", myConnection)
        '                                                               MycommandStockeSourceEM.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                               MycommandStockeSourceEM.Parameters.AddWithValue("@StockSource", "EM")
        '                                                               Using myreaderyStockSourceEM = MycommandStockeSourceEM.ExecuteReader()
        '                                                                   If myreaderyStockSourceEM.Read = True Then
        '                                                                       StockSource_EM = StockSource_EM + 1
        '                                                                   End If
        '                                                               End Using
        '                                                           End Using

        '                                                           Dim StockSource_SC As Integer
        '                                                           Using MycommandStockSourceSC As New SqlCommand("select Pk_WorkOrderNo,StockSource from RequestedMaterials  where  Pk_WorkOrderNo =@Pk_WorkOrderNo and StockSource=@StockSource", myConnection)
        '                                                               MycommandStockSourceSC.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                               MycommandStockSourceSC.Parameters.AddWithValue("@StockSource", "SC")
        '                                                               Using myreaderStockSourceSC = MycommandStockSourceSC.ExecuteReader()
        '                                                                   If myreaderStockSourceSC.Read = True Then
        '                                                                       StockSource_SC = StockSource_SC + 1
        '                                                                   End If
        '                                                               End Using
        '                                                           End Using

        '                                                           Dim Matvalidatedby As Integer
        '                                                           Using MycommandMatAvailable As New SqlCommand("select Pk_WorkOrderNo,Materials_Availability_ValidateBy from RequestedMaterials  where Materials_Availability_ValidateBy ='PENDING' and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                                                               MycommandMatAvailable.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                               Using myreaderMatvalidatedby = MycommandMatAvailable.ExecuteReader()
        '                                                                   If myreaderMatvalidatedby.Read = True Then
        '                                                                       Matvalidatedby = Matvalidatedby + 1
        '                                                                   End If
        '                                                               End Using
        '                                                           End Using



        '                                                           Dim QTY_Available_SC_Post_Flag_1 As Integer
        '                                                           Using MycommandQty_PostFlag_1 As New SqlCommand("select Pk_WorkOrderNo,QTY_Available_SC_Post_Flag from RequestedMaterials  where Materials_Availability_Post_Flag =1 and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                                                               MycommandQty_PostFlag_1.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                               Using myreaderQty_PostFlag_1 = MycommandQty_PostFlag_1.ExecuteReader()
        '                                                                   If myreaderQty_PostFlag_1.Read = True Then
        '                                                                       QTY_Available_SC_Post_Flag_1 = QTY_Available_SC_Post_Flag_1 + 1
        '                                                                   End If
        '                                                               End Using
        '                                                           End Using

        '                                                           Dim QTY_Available_SC_Post_Flag_2 As Integer
        '                                                           Using MycommandQty_PostFlag_2 As New SqlCommand("select Pk_WorkOrderNo,Materials_Availability_Post_Flag from RequestedMaterials  where Materials_Availability_Post_Flag = 2 and Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                                                               MycommandQty_PostFlag_2.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                               Using myreaderQty_PostFlag_2 = MycommandQty_PostFlag_2.ExecuteReader()
        '                                                                   If myreaderQty_PostFlag_2.Read = True Then
        '                                                                       QTY_Available_SC_Post_Flag_2 = QTY_Available_SC_Post_Flag_2 + 1
        '                                                                   End If
        '                                                               End Using
        '                                                           End Using


        '                                                           Using MycommandQty As New SqlCommand("select sum(total_Qty) as Sum_Total_Qty,sum(QTY_Recieve) as Sum_Total_Qty_Receive from RequestedMaterials  where Pk_WorkOrderNo =@Pk_WorkOrderNo", myConnection)
        '                                                               MycommandQty.Parameters.AddWithValue("@Pk_WorkOrderNo", DashBoard.DataGridView.Rows(i).Cells(3).Value)
        '                                                               Using myreaderQty = MycommandQty.ExecuteReader()
        '                                                                   If myreaderQty.Read = True Then

        '                                                                       Dim temp_Sum_Total_Qty = myreaderQty!Sum_Total_Qty
        '                                                                       Dim temp_Sum_Total_Qty_Receive = myreaderQty!Sum_Total_Qty_Receive

        '                                                                       If StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                                                                       ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                                                                       ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"



        '                                                                           '----
        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "With SC"

        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "for purchase"
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           ' DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"





        '                                                                           '----
        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"



        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 1 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "PENDING" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"



        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And myreader!ApprovedForReleaseByStatus = "APPROVED" And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"




        '                                                                       ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                                                                       ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                                                                       ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                                                                       ElseIf StockSource_EM > 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive = 0 Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC > 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Yellow
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "For Release"




        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"

        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"


        '                                                                       ElseIf StockSource_EM <> 0 And StockSource_SC <> 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 1 And QTY_Available_SC_Post_Flag_2 = 1 And temp_Sum_Total_Qty = temp_Sum_Total_Qty_Receive Then
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.Pink
        '                                                                           DashBoard.DataGridView.Rows(i).Cells(1).ToolTipText = "with SC"


        '                                                                       ElseIf StockSource_EM = 0 And StockSource_SC = 0 And Matvalidatedby = 0 And QTY_Available_SC_Post_Flag_1 = 0 And QTY_Available_SC_Post_Flag_2 = 0 And temp_Sum_Total_Qty <> temp_Sum_Total_Qty_Receive Then
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).Style.BackColor = Color.DarkBlue
        '                                                                           'DASHBOARD.DataGridView.Rows(i).Cells(1).ToolTipText = "Complete"
        '                                                                       End If

        '                                                                       DashBoard.DataGridView.Rows(i).Cells(3).ReadOnly = True

        '                                                                   End If
        '                                                               End Using
        '                                                           End Using
        '                                                           StockSource_EM = 0
        '                                                           StockSource_SC = 0
        '                                                           Matvalidatedby = 0
        '                                                           QTY_Available_SC_Post_Flag_1 = 0
        '                                                           QTY_Available_SC_Post_Flag_2 = 0
        '                                                       ElseIf myreader.Read = False Then
        '                                                           ' MessageBox.Show("wala")

        '                                                       End If
        '                                                   End Using
        '                                               End Using
        '                                           Next i
        '                                           '##################################################################################################################


        '                                           dgv.ResumeLayout()
        '                                       End Sub)

        'Catch ex As Exception
        '    MessageBox.Show("Dashboard Load Failed: " & ex.Message)
        'End Try



    End Function








End Module
