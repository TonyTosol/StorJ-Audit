﻿Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports TaskScheduler.TaskScheduler

Public Class Form1
    Private Sender As New HttpSender("http://95.216.196.150:5000/monitoring/") ''\/("http://95.216.196.150:5000/monitoring/")/\
    Private RaportSender As New HttpSender("http://localhost:6000/raport/")
    Private NodesList As New List(Of String)
    Private MonitoringStatus As Boolean = False
    Private LogMonitoring As Boolean = False
    Private LocalID As String = ""
    Private MeCloasing As Boolean = False
    Private Delegate Sub SendedUpdate(last As String)
    Private _taskScheduler As TaskScheduler.TaskScheduler
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetData()
    End Sub
    Private Sub UpdateLastSended(lastsend As String)
        If Me.InvokeRequired Then
            Me.Invoke(New SendedUpdate(AddressOf UpdateLastSended), lastsend)
        Else

            Label4.Text = lastsend
        End If

    End Sub


    'Private Sub Monitoring()
    '    Dim sendObject As New Nodes
    '    sendObject.UserID = My.Settings.UserID
    '    sendObject.UnicID = My.Settings.UserID & LocalID

    '    Try



    '        Dim satelite As HttpWebRequest

    '        Dim sateliteresponce As HttpWebResponse = Nothing
    '        Dim request As HttpWebRequest
    '        Dim response As HttpWebResponse = Nothing
    '        Dim reader As StreamReader



    '        Dim TotalegressCount As Long = 0
    '        Dim TotalingressCount As Long = 0
    '        Dim TotalrepairDownCount As Long = 0
    '        Dim TotalrepairUpCount As Long = 0
    '        Dim TotalstorageDaily As Long = 0
    '        Dim TotalSpace As Long = 0
    '        Dim TotalUsedSpace As Long = 0
    '        For Each NodeAndName As String In NodesList
    '            Dim NodeAndNameArray = NodeAndName.Split("-")
    '            Dim node = NodeAndNameArray(0)
    '            Dim NodeStatus As String = ""
    '            Try
    '                If NodeAndNameArray.Count = 3 And LogMonitoring Then
    '                    If NodeAndNameArray(2).Count > 0 Then



    '                        Dim text As List(Of String) = File.ReadLines(NodeAndNameArray(2)).Reverse().Take(100).ToList()

    '                        For Each line As String In text

    '                            If line.Contains("rejected") Then
    '                                NodeStatus = "Rejected reads contained"
    '                            End If
    '                        Next
    '                        If NodeStatus = "" Then NodeStatus = "OK"

    '                    Else
    '                        NodeStatus = "OK"
    '                    End If
    '                Else
    '                    NodeStatus = "OK"
    '                End If

    '            Catch ex As Exception
    '                NodeStatus = "Cant read Log file"
    '                MsgBox(ex.Message)
    '            End Try
    '            Try



    '                Dim list As New List(Of Object)
    '                satelite = DirectCast(WebRequest.Create("http://" & node & "/api/sno"), HttpWebRequest)

    '                sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
    '                reader = New StreamReader(sateliteresponce.GetResponseStream())
    '                Dim rawresp As String
    '                rawresp = reader.ReadToEnd()
    '                list.AddRange((JObject.Parse(rawresp)("satellites")))
    '                Dim Space As Long = JObject.Parse(rawresp)("diskSpace")("available")
    '                Dim UsedSpace As Long = JObject.Parse(rawresp)("diskSpace")("used")

    '                TotalSpace = TotalSpace + Space
    '                TotalUsedSpace = TotalUsedSpace + UsedSpace

    '                Dim egressCount As Long = 0
    '                Dim ingressCount As Long = 0
    '                Dim repairDownCount As Long = 0
    '                Dim repairUpCount As Long = 0
    '                Dim storageDaily As Long = 0

    '                Dim NodeegressCount As Long = 0
    '                Dim NodeingressCount As Long = 0
    '                Dim NoderepairDownCount As Long = 0
    '                Dim NoderepairUpCount As Long = 0


    '                For Each id As JObject In list
    '                    egressCount = 0
    '                    ingressCount = 0
    '                    repairDownCount = 0
    '                    repairUpCount = 0
    '                    Dim obj As String = (id.GetValue("id"))

    '                    request = DirectCast(WebRequest.Create("http://" & node & "/api/sno/satellite/" & obj), HttpWebRequest)

    '                    response = DirectCast(request.GetResponse(), HttpWebResponse)
    '                    reader = New StreamReader(response.GetResponseStream())
    '                    rawresp = reader.ReadToEnd()

    '                    Dim Audits = ((JObject.Parse(rawresp)("audit")("successCount"))).ToString
    '                    Dim TotalAudits = ((JObject.Parse(rawresp)("audit")("totalCount"))).ToString

    '                    Dim Uptime = ((JObject.Parse(rawresp)("uptime")("successCount"))).ToString
    '                    Dim TotalUptime = ((JObject.Parse(rawresp)("uptime")("totalCount"))).ToString



    '                    For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("bandwidthDaily").ToString)
    '                        Dim egressObject = values("egress")("usage")
    '                        Dim ingressObject = values("ingress")("usage")
    '                        Dim repairDownObject = values("ingress")("repair")
    '                        Dim repairUpObject = values("egress")("repair")
    '                        egressCount = egressCount + CLng(egressObject)
    '                        ingressCount = ingressCount + CLng(ingressObject)
    '                        repairDownCount = repairDownCount + CLng(repairDownObject)
    '                        repairUpCount = repairUpCount + CLng(repairUpObject)

    '                    Next
    '                    Try


    '                        For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("storageDaily").ToString)


    '                            storageDaily = storageDaily + CLng(values("atRestTotal"))

    '                        Next
    '                    Catch ex As Exception

    '                    End Try
    '                    NodeegressCount = NodeegressCount + egressCount
    '                    NodeingressCount = NodeingressCount + ingressCount
    '                    NoderepairDownCount = NoderepairDownCount + repairDownCount
    '                    NoderepairUpCount = NoderepairUpCount + repairUpCount

    '                Next
    '                TotalegressCount = TotalegressCount + NodeegressCount
    '                TotalingressCount = TotalingressCount + NodeingressCount
    '                TotalrepairDownCount = TotalrepairDownCount + NoderepairDownCount
    '                TotalrepairUpCount = TotalrepairUpCount + NoderepairUpCount
    '                TotalstorageDaily = TotalstorageDaily + storageDaily
    '                Dim tmpnode As New Node With {.Name = NodeAndNameArray(1),
    '                                                .Status = NodeStatus,
    '                                                .TotalBandwidth = Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 1),
    '                                                .EgressBandwidth = Math.Round(NodeegressCount / 1000000000, 1),
    '                                                .IngressBandwidth = Math.Round(NodeingressCount / 1000000000, 1),
    '                                                .storageDaily = Math.Round(TotalstorageDaily / 720000000000000, 3)}

    '                sendObject.Nodes.AddItemToArray(tmpnode)
    '                sendObject.LiveNodeCount = sendObject.LiveNodeCount + 1
    '            Catch ex As Exception

    '            End Try

    '        Next
    '        Dim resultJson = JsonHelper.FromClass(sendObject)

    '        Dim result = Sender.postData(resultJson)
    '        If result Then
    '            UpdateLastSended("Last Sended " & DateTime.Now)
    '        Else
    '            UpdateLastSended("Error sending")
    '        End If
    '    Catch ex As Exception
    '        UpdateLastSended("Error sending")
    '    End Try
    '    If MonitoringStatus Then
    '        For i As Integer = 0 To 599
    '            Threading.Thread.Sleep(1000)
    '            ''Need to monitor application exit
    '            If MeCloasing Then
    '                Exit Sub
    '            End If
    '        Next
    '        Dim NewMonitor As Threading.Thread = New Threading.Thread(AddressOf Monitoring)
    '        NewMonitor.Start()
    '    End If






    'End Sub



    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        ' When the application is exiting, write the application data to the 
        ' user file and close it.
        Try
            _taskScheduler.Enabled = False
            _taskScheduler.TriggerItems.Clear()
        Catch ex As Exception

        End Try

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

            Dim payoutRequest As HttpWebRequest
            Dim payoutResponce As HttpWebResponse = Nothing
            Dim satelite As HttpWebRequest

            Dim sateliteresponce As HttpWebResponse = Nothing
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader



            Dim TotalegressCount As Long = 0
            Dim TotalingressCount As Long = 0
            Dim TotalrepairDownCount As Long = 0
            Dim TotalrepairUpCount As Long = 0
            Dim TotalstorageDaily As Long = 0

            Dim TotalSpace As Long = 0
            Dim TotalUsedSpace As Long = 0
            Dim Totalpayout As Long = 0

            For Each NodeAndName As String In NodeList.Items
                Dim NodeAndNameArray = NodeAndName.Split("-")
                Dim node = NodeAndNameArray(0)
                Try
                    Dim NodePayout As Long = 0
                    Dim rawresp As String
                    Try



                        payoutRequest = DirectCast(WebRequest.Create("http://" & node & "/api/sno/estimated-payout"), HttpWebRequest)
                        payoutResponce = DirectCast(payoutRequest.GetResponse(), HttpWebResponse)
                        reader = New StreamReader(payoutResponce.GetResponseStream())

                        rawresp = reader.ReadToEnd()
                        NodePayout = JObject.Parse(rawresp)("currentMonth")("payout")
                        Totalpayout = Totalpayout + NodePayout

                    Catch ex As Exception

                    End Try

                    Dim list As New List(Of Object)
                    satelite = DirectCast(WebRequest.Create("http://" & node & "/api/sno"), HttpWebRequest)
                    '' satelite.Timeout = 500
                    sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
                    reader = New StreamReader(sateliteresponce.GetResponseStream())

                    rawresp = reader.ReadToEnd()
                    list.AddRange((JObject.Parse(rawresp)("satellites")))

                    Dim Space As Long = JObject.Parse(rawresp)("diskSpace")("available")
                    Dim UsedSpace As Long = JObject.Parse(rawresp)("diskSpace")("used")

                    TotalSpace = TotalSpace + Space
                    TotalUsedSpace = TotalUsedSpace + UsedSpace


                    Dim egressCount As Long = 0
                    Dim ingressCount As Long = 0
                    Dim repairDownCount As Long = 0
                    Dim repairUpCount As Long = 0
                    Dim storageDaily As Long = 0

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

                        request = DirectCast(WebRequest.Create("http://" & node & "/api/sno/satellite/" & obj), HttpWebRequest)
                        '' request.Timeout = 500
                        response = DirectCast(request.GetResponse(), HttpWebResponse)
                        reader = New StreamReader(response.GetResponseStream())
                        rawresp = reader.ReadToEnd()

                        Dim Audits = ((JObject.Parse(rawresp)("audit")("successCount"))).ToString
                        Dim TotalAudits = ((JObject.Parse(rawresp)("audit")("totalCount"))).ToString

                        Dim Uptime = ((JObject.Parse(rawresp)("uptime")("successCount"))).ToString
                        Dim TotalUptime = ((JObject.Parse(rawresp)("uptime")("totalCount"))).ToString


                        Try


                            For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("bandwidthDaily").ToString)
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
                        Try


                            For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("storageDaily").ToString)


                                storageDaily = storageDaily + CLng(values("atRestTotal"))


                            Next
                        Catch ex As Exception

                        End Try
                        NodeegressCount = NodeegressCount + egressCount
                        NodeingressCount = NodeingressCount + ingressCount
                        NoderepairDownCount = NoderepairDownCount + repairDownCount
                        NoderepairUpCount = NoderepairUpCount + repairUpCount
                        Dim row As Integer = NodeView.Rows.Add({node, id.GetValue("url"), Audits, Math.Round(egressCount / 1000000000, 2), Math.Round(ingressCount / 1000000000, 2), Math.Round(repairUpCount / 1000000000, 3), Math.Round(repairDownCount / 1000000000, 3), Math.Round((repairDownCount + repairUpCount + ingressCount + egressCount) / 1000000000, 2)})

                        If Audits > 99 Then

                            NodeView.Rows(row).Cells(2).Style.BackColor = Color.GreenYellow
                        End If
                    Next
                    TotalegressCount = TotalegressCount + NodeegressCount
                    TotalingressCount = TotalingressCount + NodeingressCount
                    TotalrepairDownCount = TotalrepairDownCount + NoderepairDownCount
                    TotalrepairUpCount = TotalrepairUpCount + NoderepairUpCount
                    TotalstorageDaily = TotalstorageDaily + storageDaily
                    NodeView.Rows.Add({"Node Total", "", "", Math.Round(NodeegressCount / 1000000000, 2), Math.Round(NodeingressCount / 1000000000, 2), Math.Round(NoderepairUpCount / 1000000000, 2), Math.Round(NoderepairDownCount / 1000000000, 2), Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 2), Math.Round(storageDaily / 720000000000000, 3), Math.Round(Space / 1000000000) & "/" & Math.Round(UsedSpace / 1000000000), NodePayout / 100})

                Catch ex As Exception
                    NodeView.Rows(NodeView.Rows.Add({node, "Node not responding", "", "", "", ""})).DefaultCellStyle.BackColor = Color.Red

                End Try

            Next
            NodeView.Rows.Add({"All Total", "", "", Math.Round(TotalegressCount / 1000000000, 2), Math.Round(TotalingressCount / 1000000000, 2), Math.Round(TotalrepairUpCount / 1000000000, 2), Math.Round(TotalrepairDownCount / 1000000000, 2), Math.Round((TotalegressCount + TotalingressCount + TotalrepairDownCount + TotalrepairUpCount) / 1000000000, 2), Math.Round(TotalstorageDaily / 720000000000000, 3), Math.Round(TotalSpace / 1000000000) & "/" & Math.Round(TotalUsedSpace / 1000000000), Totalpayout / 100})
        Catch ex As Exception
            NodeView.Rows(NodeView.Rows.Add({"Some big error", "Node not responding", "", "", "", ""})).DefaultCellStyle.BackColor = Color.Red
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
        CheckBox2.Checked = My.Settings.LogMonitoring
        MonitoringStatus = My.Settings.Monitoring
        LogMonitoring = My.Settings.LogMonitoring
        'If MonitoringStatus Then

        '    Dim NewMonitor As Threading.Thread = New Threading.Thread(AddressOf Monitoring)
        '    NewMonitor.Start()
        '    SetShadowScheduler()
        'End If

    End Sub
    'Private Sub SetShadowScheduler()
    '    _taskScheduler = New TaskScheduler.TaskScheduler
    '    _taskScheduler.SynchronizingObject = Me
    '    Dim triggerItem As TriggerItem = New TaskScheduler.TaskScheduler.TriggerItem
    '    triggerItem.Tag = "Clear"
    '    triggerItem.StartDate = DateTime.Now
    '    triggerItem.EndDate = DateTime.Now.AddYears(10)
    '    Dim tzi As TimeZoneInfo = TimeZoneInfo.Local
    '    Dim offset As TimeSpan = tzi.BaseUtcOffset
    '    Dim datetime1 As New DateTime(2019, 12, 1, 23, 58, 0)

    '    Dim month As Byte
    '    For month = 0 To 12 - 1 Step month + 1
    '        triggerItem.TriggerSettings.Monthly.Month(month) = True
    '    Next

    '    ' Set active Days (0..30 = Days, 31=last Day) for monthly trigger
    '    triggerItem.TriggerSettings.Monthly.DaysOfMonth(31) = True


    '    triggerItem.TriggerTime = datetime1

    '    AddHandler triggerItem.OnTrigger, New TaskScheduler.TaskScheduler.TriggerItem.OnTriggerEventHandler(AddressOf Trigger)
    '    triggerItem.Enabled = True
    '    _taskScheduler.AddTrigger(triggerItem)
    '    _taskScheduler.Enabled = True
    'End Sub
    Private Sub Trigger(sender As Object, e As TaskScheduler.TaskScheduler.OnTriggerEventArgs)
        Dim sendObject As New Nodes
        sendObject.UserID = My.Settings.UserID
        sendObject.UnicID = My.Settings.UserID & LocalID

        Try



            Dim satelite As HttpWebRequest
            Dim payoutRequest As HttpWebRequest
            Dim payoutResponce As HttpWebResponse = Nothing
            Dim sateliteresponce As HttpWebResponse = Nothing
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader



            Dim TotalegressCount As Long = 0
            Dim TotalingressCount As Long = 0
            Dim TotalrepairDownCount As Long = 0
            Dim TotalrepairUpCount As Long = 0
            Dim TotalstorageDaily As Long = 0
            Dim Totalpayout As Long = 0

            For Each NodeAndName As String In NodesList
                Dim NodeAndNameArray = NodeAndName.Split("-")
                Dim node = NodeAndNameArray(0)
                Try
                    TotalstorageDaily = 0
                    Dim NodePayout As Long = 0
                    Dim rawresp As String
                    Try



                        payoutRequest = DirectCast(WebRequest.Create("http://" & node & "/api/sno/estimated-payout"), HttpWebRequest)
                        payoutResponce = DirectCast(payoutRequest.GetResponse(), HttpWebResponse)
                        reader = New StreamReader(payoutResponce.GetResponseStream())

                        rawresp = reader.ReadToEnd()
                        NodePayout = JObject.Parse(rawresp)("currentMonth")("payout")
                        Totalpayout = Totalpayout + NodePayout

                    Catch ex As Exception

                End Try

                Dim list As New List(Of Object)
                    satelite = DirectCast(WebRequest.Create("http://" & node & "/api/sno"), HttpWebRequest)

                    sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
                    reader = New StreamReader(sateliteresponce.GetResponseStream())

                    rawresp = reader.ReadToEnd()
                    list.AddRange((JObject.Parse(rawresp)("data")("satellites")))



                    Dim egressCount As Long = 0
                    Dim ingressCount As Long = 0
                    Dim repairDownCount As Long = 0
                    Dim repairUpCount As Long = 0
                    Dim storageDaily As Long = 0

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

                        request = DirectCast(WebRequest.Create("http://" & node & "/api/sno/satellite/" & obj), HttpWebRequest)

                        response = DirectCast(request.GetResponse(), HttpWebResponse)
                        reader = New StreamReader(response.GetResponseStream())
                        rawresp = reader.ReadToEnd()

                        Dim Audits = ((JObject.Parse(rawresp)("audit")("successCount"))).ToString
                        Dim TotalAudits = ((JObject.Parse(rawresp)("audit")("totalCount"))).ToString

                        Dim Uptime = ((JObject.Parse(rawresp)("uptime")("successCount"))).ToString
                        Dim TotalUptime = ((JObject.Parse(rawresp)("uptime")("totalCount"))).ToString



                        For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("bandwidthDaily").ToString)
                            Dim egressObject = values("egress")("usage")
                            Dim ingressObject = values("ingress")("usage")
                            Dim repairDownObject = values("ingress")("repair")
                            Dim repairUpObject = values("egress")("repair")
                            egressCount = egressCount + CLng(egressObject)
                            ingressCount = ingressCount + CLng(ingressObject)
                            repairDownCount = repairDownCount + CLng(repairDownObject)
                            repairUpCount = repairUpCount + CLng(repairUpObject)

                        Next
                        Try


                            For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("storageDaily").ToString)


                                storageDaily = storageDaily + CLng(values("atRestTotal"))

                            Next
                        Catch ex As Exception

                        End Try

                        NodeegressCount = NodeegressCount + egressCount
                        NodeingressCount = NodeingressCount + ingressCount
                        NoderepairDownCount = NoderepairDownCount + repairDownCount
                        NoderepairUpCount = NoderepairUpCount + repairUpCount

                    Next
                    TotalegressCount = TotalegressCount + NodeegressCount
                    TotalingressCount = TotalingressCount + NodeingressCount
                    TotalrepairDownCount = TotalrepairDownCount + NoderepairDownCount
                    TotalrepairUpCount = TotalrepairUpCount + NoderepairUpCount
                    TotalstorageDaily = TotalstorageDaily + storageDaily
                    Dim tmpnode As New Node With {.Name = NodeAndNameArray(1),
                                                    .Status = "OK",
                                                    .TotalBandwidth = Math.Round((NodeegressCount + NodeingressCount + NoderepairUpCount + NoderepairDownCount) / 1000000000, 1),
                                                    .EgressBandwidth = Math.Round(NodeegressCount / 1000000000, 1),
                                                    .IngressBandwidth = Math.Round(NodeingressCount / 1000000000, 1),
                                                    .storageDaily = Math.Round(TotalstorageDaily / 720000000000000, 3)}


                    sendObject.Nodes.AddItemToArray(tmpnode)
                    sendObject.LiveNodeCount = sendObject.LiveNodeCount + 1
                Catch ex As Exception

                End Try

            Next
            Dim resultJson = JsonHelper.FromClass(sendObject)

            Dim result = RaportSender.postData(resultJson)
            If result Then
                UpdateLastSended("Last Sended " & DateTime.Now)
            Else
                UpdateLastSended("Error sending")
            End If
        Catch ex As Exception
            UpdateLastSended("Error sending")
        End Try
    End Sub

    Private Sub AddNodeBtn_Click(sender As Object, e As EventArgs) Handles AddNodeBtn.Click
        If NodeList.Items.Contains(NodeName.Text) Then
            MsgBox("Name exist, Change name")
            Exit Sub
        End If

        If Not NodeList.Items.Contains(TextBox3.Text & ":" & TextBox2.Text & "-" & NodeName.Text) Then
            NodeList.Items.Add(TextBox3.Text & ":" & TextBox2.Text & "-" & NodeName.Text & "-" & "nologpathanymore")
            My.Settings.NodeList = My.Settings.NodeList & "," & TextBox3.Text & ":" & TextBox2.Text & "-" & NodeName.Text & "-" & "Nologpathanymore"
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

    Private Sub LogConfigBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        My.Settings.LogMonitoring = CheckBox2.Checked
        My.Settings.Save()
        LogMonitoring = CheckBox2.Checked
    End Sub



    Private Sub NodeView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles NodeView.CellContentClick
        If e.ColumnIndex = 0 Then
            Process.Start("Http://" & NodeView.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub


End Class


