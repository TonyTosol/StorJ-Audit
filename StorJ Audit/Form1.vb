Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim list As New List(Of Object)
            Dim satelite As HttpWebRequest
            Dim sateliteresponce As HttpWebResponse = Nothing
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader

            satelite = DirectCast(WebRequest.Create("http://" & TextBox3.Text & ":" & TextBox2.Text & "/api/dashboard"), HttpWebRequest)
            sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
            reader = New StreamReader(sateliteresponce.GetResponseStream())
            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            list.AddRange((JObject.Parse(rawresp)("data")("satellites")))

            Dim egressCount As Long = 0
            Dim ingressCount As Long = 0
            Dim repairDownCount As Long = 0
            Dim repairUpCount As Long = 0

            For Each id As JObject In list
                Dim obj As String = (id.GetValue("id"))
                request = DirectCast(WebRequest.Create("http://" & TextBox3.Text & ":" & TextBox2.Text & "/api/satellite/" & obj), HttpWebRequest)
                response = DirectCast(request.GetResponse(), HttpWebResponse)
                reader = New StreamReader(response.GetResponseStream())
                rawresp = reader.ReadToEnd()
                TextBox1.Text = TextBox1.Text & ((JObject.Parse(rawresp)("data")("audit"))).ToString & vbNewLine


                For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("data")("bandwidthDaily").ToString)
                    Dim egressObject = values("egress")("usage")
                    Dim ingressObject = values("ingress")("usage")
                    Dim repairDownObject = values("ingress")("repair")
                    Dim repairUpObject = values("egress")("repair")
                    egressCount = egressCount + CLng(egressObject)
                    ingressCount = ingressCount + CLng(ingressObject)
                    repairDownCount = repairDownCount + CLng(repairDownObject)
                    repairUpCount = repairUpCount + CLng(repairUpObject)

                Next

            Next
            TextBox1.Text = TextBox1.Text & "Upload: " & Math.Round(egressCount / 1073741824, 2) & vbNewLine
            TextBox1.Text = TextBox1.Text & "Download: " & Math.Round(ingressCount / 1073741824, 2) & vbNewLine
            TextBox1.Text = TextBox1.Text & "Repair Download: " & Math.Round(repairDownCount / 1073741824, 2) & vbNewLine
            TextBox1.Text = TextBox1.Text & "Repair Upload: " & Math.Round(repairUpCount / 1073741824, 3) & vbNewLine
            TextBox1.Text = TextBox1.Text & "Total: " & Math.Round((repairDownCount + repairUpCount + ingressCount + egressCount) / 1073741824, 2) & vbNewLine
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
    End Sub
End Class


