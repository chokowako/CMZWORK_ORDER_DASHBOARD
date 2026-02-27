Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Net.NetworkInformation.Ping
Imports System.Net.NetworkInformation
Imports System.Net.Http

Module CheckAndSendModule
    Dim smsGatewayUrl As String = "http://192.168.60.153:8080" ' Replace with your phone IP/port

    Public Function CanPingGateway(ipAddress As String) As Boolean
        Try
            Dim ping As New Ping()
            Dim reply = ping.Send(ipAddress, 1000) ' Timeout = 1 second
            Return reply.Status = IPStatus.Success
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetGatewayIP() As String
        Dim uri As New Uri(smsGatewayUrl)
        Return uri.Host ' e.g., "192.168.1.50"
    End Function

    Public Sub UpdatePingStatusIndicator(isOnline As Boolean)
        If isOnline Then
            DashBoard.lblConnectionStatus.BackColor = Color.Green
            DashBoard.lblConnectionStatus.Text = "Gateway Status: Online"
        Else
            DashBoard.lblConnectionStatus.BackColor = Color.Red
            DashBoard.lblConnectionStatus.Text = "Gateway Status: Offline"
        End If
    End Sub

    Public Async Function SendSmsViaHttp(phone As String, message As String, pk As String) As Task(Of Boolean)
        Try
            Dim temp = pk
            Dim client As New HttpClient()
            Dim requestUri = smsGatewayUrl + "/sendsms?phone=" + phone + "&text=" + message + "&password=" + "m0b1l3"
            Dim response = Await client.GetAsync(requestUri)

            If response.IsSuccessStatusCode Then
                Return True
            Else
                'MessageBox.Show("SMS send failed: " & response.StatusCode.ToString(), "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

        Catch ex As Exception
            'MessageBox.Show("Error sending SMS: " & ex.Message, "Gateway Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


End Module
