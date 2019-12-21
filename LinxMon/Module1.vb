
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1
    Private Sender As New HttpSender("http://95.216.196.150:5000/monitoring/") ''\/("http://95.216.196.150:5000/monitoring/")/\

    Private LocalID As String = ""
    Private UserID As String = ""
    Private NodeAddress As String = ""
    Private NodeName As String = ""
    Sub Main(args As String())
        NodeAddress = args(0)
        NodeName = args(1)
        UserID = args(2)
        Monitoring()

    End Sub

    Private Sub Monitoring()
        Dim sendObject As New Nodes
        sendObject.UserID = UserID
        sendObject.UnicID = LocalID

        Try



            Dim satelite As HttpWebRequest

            Dim sateliteresponce As HttpWebResponse = Nothing
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader



            Dim TotalegressCount As Long = 0
            Dim TotalingressCount As Long = 0
            Dim TotalrepairDownCount As Long = 0
            Dim TotalrepairUpCount As Long = 0






            Dim list As New List(Of Object)
            satelite = DirectCast(WebRequest.Create("http://" & NodeAddress & "/api/dashboard"), HttpWebRequest)

            sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
            reader = New StreamReader(sateliteresponce.GetResponseStream())
            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            list.AddRange((JObject.Parse(rawresp)("data")("satellites")))
            LocalID = JObject.Parse(rawresp)("data")("nodeID")
            sendObject.UnicID = LocalID
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

                request = DirectCast(WebRequest.Create("http://" & NodeAddress & "/api/satellite/" & obj), HttpWebRequest)

                response = DirectCast(request.GetResponse(), HttpWebResponse)
                reader = New StreamReader(response.GetResponseStream())
                rawresp = reader.ReadToEnd()

                Dim Audits = ((JObject.Parse(rawresp)("data")("audit")("successCount"))).ToString
                Dim TotalAudits = ((JObject.Parse(rawresp)("data")("audit")("totalCount"))).ToString

                Dim Uptime = ((JObject.Parse(rawresp)("data")("uptime")("successCount"))).ToString
                Dim TotalUptime = ((JObject.Parse(rawresp)("data")("uptime")("totalCount"))).ToString



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

                NodeegressCount = NodeegressCount + egressCount
                NodeingressCount = NodeingressCount + ingressCount
                NoderepairDownCount = NoderepairDownCount + repairDownCount
                NoderepairUpCount = NoderepairUpCount + repairUpCount

            Next
            TotalegressCount = TotalegressCount + NodeegressCount
            TotalingressCount = TotalingressCount + NodeingressCount
            TotalrepairDownCount = TotalrepairDownCount + NoderepairDownCount
            TotalrepairUpCount = TotalrepairUpCount + NoderepairUpCount
            Dim tmpnode As New Node With {.Name = NodeName,
                                                    .Status = "OK",
                                                    .TotalBandwidth = Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 1),
                                                    .EgressBandwidth = Math.Round(NodeegressCount / 1000000000, 1),
                                                    .IngressBandwidth = Math.Round(NodeingressCount / 1000000000, 1)}

            sendObject.Nodes.AddItemToArray(tmpnode)
            sendObject.LiveNodeCount = sendObject.LiveNodeCount + 1
        Catch ex As Exception

        End Try


        Dim resultJson = JsonHelper.FromClass(sendObject)
        Dim result = Sender.postData(resultJson)










    End Sub
End Module

