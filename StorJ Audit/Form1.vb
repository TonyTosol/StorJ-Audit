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

            satelite = DirectCast(WebRequest.Create("http://" & NodeList.Items(0) & "/api/dashboard"), HttpWebRequest)
            sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
            reader = New StreamReader(sateliteresponce.GetResponseStream())
            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            list.AddRange((JObject.Parse(rawresp)("data")("satellites")))

            Dim TotalegressCount As Long = 0
            Dim TotalingressCount As Long = 0
            Dim TotalrepairDownCount As Long = 0
            Dim TotalrepairUpCount As Long = 0
            For Each node As String In NodeList.Items



                Dim egressCount As Long = 0
                Dim ingressCount As Long = 0
                Dim repairDownCount As Long = 0
                Dim repairUpCount As Long = 0

                Dim NodeegressCount As Long = 0
                Dim NodeingressCount As Long = 0
                Dim NoderepairDownCount As Long = 0
                Dim NoderepairUpCount As Long = 0

                For Each id As JObject In list
                    egressCount = 0
                    ingressCount = 0
                    repairDownCount = 0
                    repairUpCount = 0
                    Dim obj As String = (id.GetValue("id"))

                    request = DirectCast(WebRequest.Create("http://" & node & "/api/satellite/" & obj), HttpWebRequest)
                    response = DirectCast(request.GetResponse(), HttpWebResponse)
                    reader = New StreamReader(response.GetResponseStream())
                    rawresp = reader.ReadToEnd()

                    Dim Audits = ((JObject.Parse(rawresp)("data")("audit")("successCount"))).ToString
                    Dim TotalAudits = ((JObject.Parse(rawresp)("data")("audit")("totalCount"))).ToString

                    Dim Uptime = ((JObject.Parse(rawresp)("data")("uptime")("successCount"))).ToString
                    Dim TotalUptime = ((JObject.Parse(rawresp)("data")("uptime")("totalCount"))).ToString
                    Try


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
                    Catch ex As Exception

                    End Try
                    NodeegressCount = NodeegressCount + egressCount
                    NodeingressCount = NodeingressCount + ingressCount
                    NoderepairDownCount = NoderepairDownCount + repairDownCount
                    NoderepairUpCount = NoderepairUpCount + repairUpCount
                    NodeView.Rows.Add({node, id.GetValue("url"), Audits & "/" & TotalAudits, Uptime & "/" & TotalUptime, Math.Round(egressCount / 1000000000, 2), Math.Round(ingressCount / 1000000000, 2), Math.Round(repairUpCount / 1000000000, 3), Math.Round((repairDownCount + repairUpCount + ingressCount + egressCount) / 1000000000, 2)})

                Next
                TotalegressCount = TotalegressCount + NodeegressCount
                TotalingressCount = TotalingressCount + NodeingressCount
                TotalrepairDownCount = TotalrepairDownCount + NoderepairDownCount
                TotalrepairUpCount = TotalrepairUpCount + NoderepairUpCount
                NodeView.Rows.Add({"Node Total", "", "", "", Math.Round(NodeegressCount / 1000000000, 2), Math.Round(NodeingressCount / 1000000000, 2), Math.Round(NoderepairUpCount / 1000000000, 2), Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 2)})
            Next
            NodeView.Rows.Add({"All Total", "", "", "", Math.Round(TotalegressCount / 1000000000, 2), Math.Round(TotalingressCount / 1000000000, 2), Math.Round(TotalrepairUpCount / 1000000000, 2), Math.Round((TotalegressCount + TotalingressCount + TotalrepairDownCount + TotalrepairUpCount) / 1000000000, 2)})
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NodeView.Rows.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim list() As String = My.Settings.NodeList.Split(",")

        For Each item As String In list
            If item <> "" Then NodeList.Items.Add(item)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not NodeList.Items.Contains(TextBox3.Text & ":" & TextBox2.Text) Then
            NodeList.Items.Add(TextBox3.Text & ":" & TextBox2.Text)
            My.Settings.NodeList = My.Settings.NodeList & "," & TextBox3.Text & ":" & TextBox2.Text
            My.Settings.Save()
        Else
            MsgBox("Node Exists in the list")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NodeList.Items.Remove(NodeList.SelectedItem)
        My.Settings.NodeList = ""
        For Each nodeitem As String In NodeList.Items
            My.Settings.NodeList = My.Settings.NodeList & nodeitem & ","
        Next
        My.Settings.Save()
    End Sub


End Class


