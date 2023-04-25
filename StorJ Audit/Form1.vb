Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Form1

    Private NodesList As New List(Of String)
    Private MonitoringStatus As Boolean = False
    Private LogMonitoring As Boolean = False
    Private LocalID As String = ""
    Private MeCloasing As Boolean = False
    Private Delegate Sub SendedUpdate(last As String)
    ''Private _taskScheduler As TaskScheduler.TaskScheduler
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetData("currentMonth")
    End Sub







    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
        ' When the application is exiting, write the application data to the 
        ' user file and close it.
        Try
            '' _taskScheduler.Enabled = False
            ''_taskScheduler.TriggerItems.Clear()
        Catch ex As Exception

        End Try

        MeCloasing = True
    End Sub

    Private Sub GetData(month As String)
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

            Dim TodalUsedUS2 As Long = 0
            Dim TotalUsedSaltlake As Long = 0
            Dim TotalUsedAP1 As Long = 0
            Dim TotalUsedUS1 As Long = 0
            Dim TotalUsedEU1 As Long = 0
            Dim TotalUsedEUNorth As Long = 0

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
                        NodePayout = JObject.Parse(rawresp)(month)("payout")
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

                    'For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("storageDaily").ToString)


                    '    storageDaily = storageDaily + CLng(values("atRestTotal"))


                    'Next




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
                        Dim SatUsedspace As String = (id.GetValue("currentStorageUsed"))

                        request = DirectCast(WebRequest.Create("http://" & node & "/api/sno/satellite/" & obj), HttpWebRequest)
                        '' request.Timeout = 500
                        response = DirectCast(request.GetResponse(), HttpWebResponse)
                        reader = New StreamReader(response.GetResponseStream())
                        rawresp = reader.ReadToEnd()

                        Dim Audits As Integer = 0 ''= ((JObject.Parse(rawresp)("audit")("successCount"))).ToString
                        Dim TotalAudits As Integer = 0 ''= ((JObject.Parse(rawresp)("audit")("totalCount"))).ToString

                        'Dim Uptime As String '' = ((JObject.Parse(rawresp)("uptime")("successCount"))).ToString
                        'Dim TotalUptime As String '' = ((JObject.Parse(rawresp)("uptime")("totalCount"))).ToString
                        Select Case (id.GetValue("id"))
                            Case "12tRQrMTWUWwzwGh18i7Fqs67kmdhH9t6aToeiwbo5mfS2rUmo"
                                TodalUsedUS2 = TodalUsedUS2 + SatUsedspace
                            Case "1wFTAgs9DP5RSnCqKV1eLf6N9wtk4EAtmN5DpSxcs8EjT69tGE"
                                TotalUsedSaltlake = TotalUsedSaltlake + SatUsedspace
                            Case "121RTSDpyNZVcEU84Ticf2L1ntiuUimbWgfATz21tuvgk3vzoA6"
                                TotalUsedAP1 = TotalUsedAP1 + SatUsedspace
                            Case "12EayRS2V1kEsWESU9QMRseFhdxYxKicsiFmxrsLZHeLUtdps3S"
                                TotalUsedUS1 = TotalUsedUS1 + SatUsedspace
                            Case "12L9ZFwhzVpuEKMUNUqkaTLGzwY9G24tbiigLiXpmZWKwmcNDDs"
                                TotalUsedEU1 = TotalUsedEU1 + SatUsedspace
                            Case "12rfG3sh9NCWiX3ivPjq2HtdLmbqCrvHVEzJubnzFzosMuawymB"
                                TotalUsedEUNorth = TotalUsedEUNorth + SatUsedspace
                        End Select

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
                            For Each values As Object In JsonConvert.DeserializeObject(Of List(Of Object))(JObject.Parse(rawresp)("auditHistory")("windows").ToString)
                                Dim aud = values("onlineCount")
                                Dim totalaud = values("totalCount")
                                Audits = Audits + CInt(aud)
                                TotalAudits = TotalAudits + CInt(totalaud)
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
                        Dim row As Integer = NodeView.Rows.Add({node, id.GetValue("url"), Audits & "/" & TotalAudits, Math.Round(egressCount / 1000000000, 2), Math.Round(ingressCount / 1000000000, 2), Math.Round(repairUpCount / 1000000000, 3), Math.Round(repairDownCount / 1000000000, 3), Math.Round((repairDownCount + repairUpCount + ingressCount + egressCount) / 1000000000, 2), "", Math.Round(SatUsedspace / 1000000000)})

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

            NodeView.Rows.Add({"US2 space Total", "", "", "", "", "", "", "", "", Math.Round(TodalUsedUS2 / 1000000000), ""})
            NodeView.Rows.Add({"Saltlake space Total", "", "", "", "", "", "", "", "", Math.Round(TotalUsedSaltlake / 1000000000), ""})
            NodeView.Rows.Add({"AP1 space Total", "", "", "", "", "", "", "", "", Math.Round(TotalUsedAP1 / 1000000000), ""})
            NodeView.Rows.Add({"US1 space Total", "", "", "", "", "", "", "", "", Math.Round(TotalUsedUS1 / 1000000000), ""})
            NodeView.Rows.Add({"EU1 space Total", "", "", "", "", "", "", "", "", Math.Round(TotalUsedEU1 / 1000000000), ""})
            NodeView.Rows.Add({"EU North space Total", "", "", "", "", "", "", "", "", Math.Round(TotalUsedEUNorth / 1000000000), ""})
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
        For Each item As String In list
            If item <> "" Then
                NodeList.Items.Add(item)
                NodesList.Add(item)
            End If
        Next



        'If MonitoringStatus Then

        '    Dim NewMonitor As Threading.Thread = New Threading.Thread(AddressOf Monitoring)
        '    NewMonitor.Start()
        '    SetShadowScheduler()
        'End If

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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

        My.Settings.Save()
    End Sub

    Private Sub SaveUserID_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub LogConfigBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub NodeView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles NodeView.CellContentClick
        If e.ColumnIndex = 0 Then
            Process.Start("Http://" & NodeView.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GetData("previousMonth")


        'NodeView.Rows.Clear()
        'For Each data As String In GetDriveTemp()
        '    NodeView.Rows.Add(data)
        'Next
        'NodeView.Rows.Add()
    End Sub
    Const TEMPERATURE_ATTRIBUTE As Byte = 194
    Public Function GetDriveTemp() As List(Of String)
        Dim retval As New List(Of String)
        Try
            Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData")
            'loop through all the hard disks
            For Each queryObj As ManagementObject In searcher.[Get]()
                Dim arrVendorSpecific As Byte() = DirectCast(queryObj.GetPropertyValue("VendorSpecific"), Byte())
                'Find the temperature attribute
                Dim tempIndex As Integer = Array.IndexOf(arrVendorSpecific, TEMPERATURE_ATTRIBUTE)
                retval.Add(arrVendorSpecific(tempIndex + 5))
            Next
        Catch err As ManagementException
            MsgBox("An error occurred while querying for WMI data: " + err.Message)
        End Try
        Return retval
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sendObject As New Nodes

        Try



            Dim satelite As HttpWebRequest
            Dim sateliteresponce As HttpWebResponse = Nothing
            Dim reader As StreamReader




            For Each NodeAndName As String In NodeList.Items
                Dim NodeAndNameArray = NodeAndName.Split("-")
                Dim node = NodeAndNameArray(0)
                Try

                    Dim rawresp As String


                    Dim list As New List(Of Object)
                    satelite = DirectCast(WebRequest.Create("http://" & node & "/api/sno"), HttpWebRequest)
                    '' satelite.Timeout = 500
                    sateliteresponce = DirectCast(satelite.GetResponse(), HttpWebResponse)
                    reader = New StreamReader(sateliteresponce.GetResponseStream())

                    rawresp = reader.ReadToEnd()
                    Dim NodeID As String = JObject.Parse(rawresp)("nodeID")
                    If NodeID IsNot Nothing Then
                        If String.Compare(NodeID, TextBox1.Text) = 0 Then
                            Dim nodeMessage As New NodeMsg
                            nodeMessage.link = node
                            nodeMessage.Show()
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                    '' MsgBox(ex)
                End Try
            Next
        Catch ex As Exception
            ''MsgBox(ex)
        End Try
        MsgBox("Node not found or not respond, check node service.")
    End Sub
End Class


