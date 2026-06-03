Imports Microsoft.Reporting.WinForms
Imports System.Data
Public Class FrmReportPreview

    ' Parameters

    Public WoNo As String
    Public DateRequested As String
    Public DateCompleted As String
    Public CompletedBy As String
    Public DateClosed As String
    Public ClosedBy As String
    Public DateCancelled As String
    Public CancelledBy As String
    Public WorkDescription As String
    Public CancelledRemarks As String
    Public Requester As String
    Public HeadSupervisor As String
    Public RequestedArea As String
    Public IfMatNeeded As String
    Public Status As String
    Public Notedby As String
    Public NotedbyDateTime As String
    Public Approvedby As String
    Public ApprovedDateTime As String
    Public ApprovedReleaseby As String
    Public ApprovedReleaseDateTime As String
    Public ApprovedPoby As String
    Public ApprovedPodateTime As String
    Public NotedBy_Position As String
    Public ApprovedBy_Position As String
    Public ApprovedReleaseBy_Position As String
    Public ApprovedPoBy_Position As String


    Public MaterialsTable As DataTable
    Public PersonnelTable As DataTable

    Private Sub FrmReportPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadReport()
    End Sub
    Public Sub LoadReport()

        Try
            ' =========================
            ' RESET REPORT
            ' =========================
            ReportViewer1.Reset()
            ReportViewer1.ProcessingMode = ProcessingMode.Local

            ReportViewer1.LocalReport.ReportPath =
                Application.StartupPath & "\Print\rptWorkOrderPreview.rdlc"

            ReportViewer1.LocalReport.DataSources.Clear()

            ' =========================
            ' MATERIALS DATASET
            ' =========================
            If MaterialsTable IsNot Nothing AndAlso MaterialsTable.Rows.Count > 0 Then
                ReportViewer1.LocalReport.DataSources.Add(
                    New ReportDataSource("My_Dataset_RequestedMaterials", MaterialsTable))
            End If

            ' =========================
            ' PERSONNEL DATASET
            ' =========================
            If PersonnelTable IsNot Nothing AndAlso PersonnelTable.Rows.Count > 0 Then
                ReportViewer1.LocalReport.DataSources.Add(
                    New ReportDataSource("PersonAssigned", PersonnelTable))
            End If



            ' =========================
            ' PARAMETERS (SAFE)
            ' =========================
            Dim p As New List(Of ReportParameter)

            p.Add(New ReportParameter("WoNo", SafeValue(WoNo)))
            p.Add(New ReportParameter("DateRequested", SafeValue(DateRequested)))
            p.Add(New ReportParameter("DateCompleted", SafeValue(DateCompleted)))
            p.Add(New ReportParameter("CompletedBy", SafeValue(CompletedBy)))
            p.Add(New ReportParameter("DateClosed", SafeValue(DateClosed)))
            p.Add(New ReportParameter("ClosedBy", SafeValue(ClosedBy)))
            p.Add(New ReportParameter("DateCancelled", SafeValue(DateCancelled)))
            p.Add(New ReportParameter("CancelledBy", SafeValue(CancelledBy)))

            p.Add(New ReportParameter("WorkDescription", SafeValue(WorkDescription)))
            p.Add(New ReportParameter("CancelledRemarks", SafeValue(CancelledRemarks)))
            p.Add(New ReportParameter("Requester", SafeValue(Requester)))
            p.Add(New ReportParameter("HeadSupervisor", SafeValue(HeadSupervisor)))
            p.Add(New ReportParameter("RequestedArea", SafeValue(RequestedArea)))
            p.Add(New ReportParameter("IfMatNeeded", SafeValue(IfMatNeeded)))
            p.Add(New ReportParameter("Status", SafeValue(Status)))

            p.Add(New ReportParameter("Notedby", SafeValue(Notedby)))
            p.Add(New ReportParameter("NotedbyDateTime", SafeValue(NotedbyDateTime)))
            p.Add(New ReportParameter("NotedByPosition", SafeValue(NotedBy_Position)))

            p.Add(New ReportParameter("Approvedby", SafeValue(Approvedby)))
            p.Add(New ReportParameter("ApprovedDateTime", SafeValue(ApprovedDateTime)))
            p.Add(New ReportParameter("ApprovedByPosition", SafeValue(ApprovedBy_Position)))

            p.Add(New ReportParameter("ApprovedReleaseby", SafeValue(ApprovedReleaseby)))
            p.Add(New ReportParameter("ApprovedReleaseDateTime", SafeValue(ApprovedReleaseDateTime)))
            p.Add(New ReportParameter("ApprovedReleaseByPosition", SafeValue(ApprovedReleaseBy_Position)))

            p.Add(New ReportParameter("ApprovedPoby", SafeValue(ApprovedPoby)))
            p.Add(New ReportParameter("ApprovedPodateTime", SafeValue(ApprovedPodateTime)))
            p.Add(New ReportParameter("ApprovedPoByPosition", SafeValue(ApprovedPoBy_Position)))

            ReportViewer1.LocalReport.SetParameters(p)

            ' =========================
            ' PAGE SETTINGS
            ' =========================
            Dim ps As New System.Drawing.Printing.PageSettings()
            ps.Landscape = False
            ps.PaperSize = New System.Drawing.Printing.PaperSize("A4", 827, 1170)
            ps.Margins = New System.Drawing.Printing.Margins(10, 10, 10, 10)

            ReportViewer1.SetPageSettings(ps)

            ' =========================
            ' DISPLAY SETTINGS
            ' =========================
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.PageWidth

            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Report Error: " & ex.Message)
        End Try

    End Sub

    Private Function SafeValue(val As String) As String
        If String.IsNullOrEmpty(val) Then
            Return ""
        End If
        Return val
    End Function
End Class