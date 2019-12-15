Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Sender As New HttpSender("http://95.216.196.150:5000/monitoring/")
    Private NodesList As New List(Of String)
    Private MonitoringStatus As Boolean = False
    Private LocalID As String = ""
    Private MeCloasing As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetData()
    End Sub
    Private Sub Monitoring()
        Dim sendObject As New Nodes
        sendObject.UserID = My.Settings.UserID
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
            For Each NodeAndName As String In NodesList
                Dim NodeAndNameArray = NodeAndName.Split("-")
                Dim node = NodeAndNameArray(0)
                Try


                    Dim list As New List(Of Object)
                    satelite = DirectCast(WebRequest.Create("http://" & node & "/api/dashboard"), HttpWebRequest)
                    satelite.Timeout = 500
                    sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
                    reader = New StreamReader(sateliteresponce.GetResponseStream())
                    Dim rawresp As String
                    rawresp = reader.ReadToEnd()
                    list.AddRange((JObject.Parse(rawresp)("data")("satellites")))


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
                        request.Timeout = 500
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
                    Dim tmpnode As New Node With {.Name = NodeAndName,
                                                    .Status = "OK",
                                                    .TotalBandwidth = Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 2)}
                    sendObject.Nodes.AddItemToArray(tmpnode)
                    sendObject.LiveNodeCount = sendObject.LiveNodeCount + 1
                Catch ex As Exception

                End Try

            Next
            Dim resultJson = JsonHelper.FromClass(sendObject)
            Dim result = Sender.postData(resultJson)
        Catch ex As Exception
        End Try
        If MonitoringStatus Then
            For i As Integer = 0 To 600
                Threading.Thread.Sleep(1000)
                ''Need to monitor application exit
                If MeCloasing Then
                    Exit Sub
                End If
            Next
            Dim NewMonitor As Threading.Thread = New Threading.Thread(AddressOf Monitoring)
            NewMonitor.Start()
        End If






    End Sub
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        ' When the application is exiting, write the application data to the 
        ' user file and close it.
        MeCloasing = True
    End Sub
    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
        "{impersonationLevel=impersonate}!\\" &
        computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
        "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
        cpu_ids.Substring(2)

        Return cpu_ids
    End Function
    Private Sub GetData()
        Dim sendObject As New Nodes

        Try
            NodeView.Rows.Clear()


            Dim satelite As HttpWebRequest

            Dim sateliteresponce As HttpWebResponse = Nothing
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader



            Dim TotalegressCount As Long = 0
            Dim TotalingressCount As Long = 0
            Dim TotalrepairDownCount As Long = 0
            Dim TotalrepairUpCount As Long = 0
            For Each NodeAndName As String In NodeList.Items
                Dim NodeAndNameArray = NodeAndName.Split("-")
                Dim node = NodeAndNameArray(0)
                Try


                    Dim list As New List(Of Object)
                    satelite = DirectCast(WebRequest.Create("http://" & Node & "/api/dashboard"), HttpWebRequest)
                    satelite.Timeout = 500
                    sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
                    reader = New StreamReader(sateliteresponce.GetResponseStream())
                    Dim rawresp As String
                    rawresp = reader.ReadToEnd()
                    list.AddRange((JObject.Parse(rawresp)("data")("satellites")))


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

                        request = DirectCast(WebRequest.Create("http://" & Node & "/api/satellite/" & obj), HttpWebRequest)
                        request.Timeout = 500
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
                        NodeView.Rows.Add({Node, id.GetValue("url"), Audits & "/" & TotalAudits, Uptime & "/" & TotalUptime, Math.Round(egressCount / 1000000000, 2), Math.Round(ingressCount / 1000000000, 2), Math.Round(repairUpCount / 1000000000, 3), Math.Round((repairDownCount + repairUpCount + ingressCount + egressCount) / 1000000000, 2)})

                    Next
                    TotalegressCount = TotalegressCount + NodeegressCount
                    TotalingressCount = TotalingressCount + NodeingressCount
                    TotalrepairDownCount = TotalrepairDownCount + NoderepairDownCount
                    TotalrepairUpCount = TotalrepairUpCount + NoderepairUpCount
                    NodeView.Rows.Add({"Node Total", "", "", "", Math.Round(NodeegressCount / 1000000000, 2), Math.Round(NodeingressCount / 1000000000, 2), Math.Round(NoderepairUpCount / 1000000000, 2), Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 2)})

                Catch ex As Exception
                    NodeView.Rows(NodeView.Rows.Add({Node, "Node not responding", "", "", "", "", ""})).DefaultCellStyle.BackColor = Color.Red

                End Try

            Next
            NodeView.Rows.Add({"All Total", "", "", "", Math.Round(TotalegressCount / 1000000000, 2), Math.Round(TotalingressCount / 1000000000, 2), Math.Round(TotalrepairUpCount / 1000000000, 2), Math.Round((TotalegressCount + TotalingressCount + TotalrepairDownCount + TotalrepairUpCount) / 1000000000, 2)})
        Catch ex As Exception
            NodeView.Rows(NodeView.Rows.Add({"Some big error", "Node not responding", "", "", "", "", ""})).DefaultCellStyle.BackColor = Color.Red
        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NodeView.Rows.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim list() As String = My.Settings.NodeList.Split(",")
        UserIDBox.Text = My.Settings.UserID
        LocalID = CpuId()
        For Each item As String In list
            If item <> "" Then
                NodeList.Items.Add(item)
                NodesList.Add(item)
            End If
        Next
        CheckBox1.Checked = My.Settings.Monitoring
        MonitoringStatus = My.Settings.Monitoring
        If MonitoringStatus Then

            Dim NewMonitor As Threading.Thread = New Threading.Thread(AddressOf Monitoring)
            NewMonitor.Start()
        End If
    End Sub

    Private Sub AddNodeBtn_Click(sender As Object, e As EventArgs) Handles AddNodeBtn.Click
        If NodeList.Items.Contains(NodeName.Text) Then
            MsgBox("Name exist, Change name")
            Exit Sub
        End If

        If Not NodeList.Items.Contains(TextBox3.Text & ":" & TextBox2.Text & "-" & NodeName.Text) Then
            NodeList.Items.Add(TextBox3.Text & ":" & TextBox2.Text & "-" & NodeName.Text)
            My.Settings.NodeList = My.Settings.NodeList & "," & TextBox3.Text & ":" & TextBox2.Text & "-" & NodeName.Text
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.Monitoring = CheckBox1.Checked
        MonitoringStatus = CheckBox1.Checked
        My.Settings.Save()
    End Sub

    Private Sub SaveUserID_Click(sender As Object, e As EventArgs) Handles SaveUserID.Click

        My.Settings.UserID = UserIDBox.Text
        My.Settings.Save()

    End Sub
End Class


