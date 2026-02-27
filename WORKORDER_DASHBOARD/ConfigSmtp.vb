Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Net.NetworkInformation.Ping
Imports System.Net.NetworkInformation
Imports System.Net.Http
Imports System.Net.Mail
Public Class ConfigSms
    Private Sub TestSms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtGatewayIp.Text = My.Settings.GatewayIp
        TxtGatewayPort.Text = My.Settings.GatewayPort
        TxtGatewayPassword.Text = My.Settings.GatewayPassword
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.Settings.GatewayIp = TxtGatewayIp.Text
        My.Settings.GatewayPort = TxtGatewayPort.Text
        My.Settings.GatewayPassword = TxtGatewayPassword.Text
        My.Settings.Save()
        MsgBox("Your Gateway configuration has saved!", MsgBoxStyle.Information, MsgBoxResult.Ok)
    End Sub



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
        Dim uri As New Uri("http://" & TxtGatewayIp.Text + ":" + TxtGatewayPort.Text)
        Return uri.Host ' e.g., "192.168.1.50"
    End Function
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim gatewayIP = GetGatewayIP()
        Dim isOnline = CanPingGateway(gatewayIP)
        ' UpdatePingStatusIndicator(isOnline)

        If Not isOnline Then
            MessageBox.Show("Not connected")
        Else
            MessageBox.Show("connected")
            Try
                ' Example using Twilio or generic HTTP SMS API
                Dim url As String = "http://" & TxtGatewayIp.Text + ":" + TxtGatewayPort.Text + "/sendsms?phone=" + TxtNum.Text + "&text=" + TxtMessage.Text + "&password=" + "m0b1l3"
                Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                Dim resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)

                Using reader As New StreamReader(resp.GetResponseStream())
                    Dim responseText As String = reader.ReadToEnd()
                    ' Optionally parse and verify success
                End Using

            Catch ex As Exception
                MessageBox.Show("SMS Error: " & ex.Message)
            End Try

        End If

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class