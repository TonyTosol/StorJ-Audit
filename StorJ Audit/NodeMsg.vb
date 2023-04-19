Public Class NodeMsg
    Public link As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub NodeSearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LinkLabel1.Text = "http://" & link
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.LinkVisited = True

        System.Diagnostics.Process.Start("http://" & link)
    End Sub
End Class