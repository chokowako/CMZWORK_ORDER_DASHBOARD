Imports System.Data.SqlClient

Module SeverityTypeModule

    Public Function GetSeverityTable() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connstring)
            conn.Open()
            Using cmd As New SqlCommand(
                "SELECT SeverityTypeID, SeverityName, Description
                 FROM SeverityType
                 ORDER BY SeverityTypeID", conn)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Sub LoadSeverityCombo(cmb As ComboBox)
        Dim dt As DataTable = GetSeverityTable()
        cmb.DataSource = dt
        cmb.DisplayMember = "SeverityName"
        cmb.ValueMember = "SeverityTypeID"
        cmb.SelectedIndex = -1
    End Sub

    Public Sub ApplySeverityColor(cmb As ComboBox)
        Select Case cmb.Text.ToUpper().Trim()
            Case "CRITICAL"
                cmb.BackColor = Color.DarkRed
                cmb.ForeColor = Color.White
            Case "MAJOR"
                cmb.BackColor = Color.Orange
                cmb.ForeColor = Color.Black
            Case "MODERATE"
                cmb.BackColor = Color.Pink
                cmb.ForeColor = Color.Black
            Case "MINOR"
                cmb.BackColor = Color.LightGreen
                cmb.ForeColor = Color.Black
            Case Else
                cmb.BackColor = SystemColors.Window
                cmb.ForeColor = SystemColors.ControlText
        End Select
    End Sub

End Module
