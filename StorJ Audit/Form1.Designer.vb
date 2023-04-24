<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.NodeList = New System.Windows.Forms.ListBox()
        Me.AddNodeBtn = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.NodeView = New System.Windows.Forms.DataGridView()
        Me.NodeName = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Node = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Satellite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Audits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Egress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepeirEgress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReperIngres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalBandwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorageUsed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpaceUsed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Payout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.NodeView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1588, 610)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Get data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1584, 502)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(133, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "14002"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1584, 448)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(111, 22)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "192.168.88.240"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1584, 427)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Node IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1584, 482)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Node Port"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1685, 610)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NodeList
        '
        Me.NodeList.FormattingEnabled = True
        Me.NodeList.ItemHeight = 16
        Me.NodeList.Location = New System.Drawing.Point(1572, 158)
        Me.NodeList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NodeList.Name = "NodeList"
        Me.NodeList.Size = New System.Drawing.Size(241, 260)
        Me.NodeList.TabIndex = 7
        '
        'AddNodeBtn
        '
        Me.AddNodeBtn.Location = New System.Drawing.Point(1588, 567)
        Me.AddNodeBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AddNodeBtn.Name = "AddNodeBtn"
        Me.AddNodeBtn.Size = New System.Drawing.Size(91, 23)
        Me.AddNodeBtn.TabIndex = 8
        Me.AddNodeBtn.Text = "Add Node"
        Me.AddNodeBtn.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1685, 567)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Delete Node"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'NodeView
        '
        Me.NodeView.AllowUserToAddRows = False
        Me.NodeView.AllowUserToDeleteRows = False
        Me.NodeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NodeView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Node, Me.Satellite, Me.Audits, Me.Egress, Me.Ingress, Me.RepeirEgress, Me.ReperIngres, Me.TotalBandwidth, Me.StorageUsed, Me.SpaceUsed, Me.Payout})
        Me.NodeView.Location = New System.Drawing.Point(1, 5)
        Me.NodeView.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NodeView.Name = "NodeView"
        Me.NodeView.ReadOnly = True
        Me.NodeView.RowHeadersWidth = 51
        Me.NodeView.RowTemplate.Height = 24
        Me.NodeView.Size = New System.Drawing.Size(1563, 679)
        Me.NodeView.TabIndex = 10
        '
        'NodeName
        '
        Me.NodeName.Location = New System.Drawing.Point(1700, 448)
        Me.NodeName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NodeName.Name = "NodeName"
        Me.NodeName.Size = New System.Drawing.Size(109, 22)
        Me.NodeName.TabIndex = 12
        Me.NodeName.Text = "Node 1"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1588, 649)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 23)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Previus Month"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1572, 41)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(237, 59)
        Me.TextBox1.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1581, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Node ID"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1572, 104)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(91, 23)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "Search"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Node
        '
        Me.Node.HeaderText = "Node"
        Me.Node.MinimumWidth = 6
        Me.Node.Name = "Node"
        Me.Node.ReadOnly = True
        Me.Node.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Node.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Node.Width = 125
        '
        'Satellite
        '
        Me.Satellite.HeaderText = "Satellite"
        Me.Satellite.MinimumWidth = 6
        Me.Satellite.Name = "Satellite"
        Me.Satellite.ReadOnly = True
        Me.Satellite.Width = 175
        '
        'Audits
        '
        Me.Audits.HeaderText = "Success Audits/Total(last 30 days)"
        Me.Audits.MinimumWidth = 6
        Me.Audits.Name = "Audits"
        Me.Audits.ReadOnly = True
        Me.Audits.Width = 125
        '
        'Egress
        '
        Me.Egress.HeaderText = "Egress"
        Me.Egress.MinimumWidth = 6
        Me.Egress.Name = "Egress"
        Me.Egress.ReadOnly = True
        Me.Egress.Width = 60
        '
        'Ingress
        '
        Me.Ingress.HeaderText = "Ingress"
        Me.Ingress.MinimumWidth = 6
        Me.Ingress.Name = "Ingress"
        Me.Ingress.ReadOnly = True
        Me.Ingress.Width = 60
        '
        'RepeirEgress
        '
        Me.RepeirEgress.HeaderText = "Repair Egress"
        Me.RepeirEgress.MinimumWidth = 6
        Me.RepeirEgress.Name = "RepeirEgress"
        Me.RepeirEgress.ReadOnly = True
        Me.RepeirEgress.Width = 125
        '
        'ReperIngres
        '
        Me.ReperIngres.HeaderText = "Repair Ingres"
        Me.ReperIngres.MinimumWidth = 6
        Me.ReperIngres.Name = "ReperIngres"
        Me.ReperIngres.ReadOnly = True
        Me.ReperIngres.Width = 125
        '
        'TotalBandwidth
        '
        Me.TotalBandwidth.HeaderText = "Total Bandwidth"
        Me.TotalBandwidth.MinimumWidth = 6
        Me.TotalBandwidth.Name = "TotalBandwidth"
        Me.TotalBandwidth.ReadOnly = True
        Me.TotalBandwidth.Width = 80
        '
        'StorageUsed
        '
        Me.StorageUsed.HeaderText = "TB*Month"
        Me.StorageUsed.MinimumWidth = 6
        Me.StorageUsed.Name = "StorageUsed"
        Me.StorageUsed.ReadOnly = True
        Me.StorageUsed.Width = 80
        '
        'SpaceUsed
        '
        Me.SpaceUsed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SpaceUsed.HeaderText = "Space/Used"
        Me.SpaceUsed.MinimumWidth = 6
        Me.SpaceUsed.Name = "SpaceUsed"
        Me.SpaceUsed.ReadOnly = True
        Me.SpaceUsed.Width = 113
        '
        'Payout
        '
        Me.Payout.HeaderText = "Payout"
        Me.Payout.MinimumWidth = 6
        Me.Payout.Name = "Payout"
        Me.Payout.ReadOnly = True
        Me.Payout.Width = 50
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1816, 686)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.NodeName)
        Me.Controls.Add(Me.NodeView)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.AddNodeBtn)
        Me.Controls.Add(Me.NodeList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Storagnode remote stat monitoring"
        CType(Me.NodeView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents NodeList As ListBox
    Friend WithEvents AddNodeBtn As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents NodeView As DataGridView
    Friend WithEvents NodeName As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Node As DataGridViewLinkColumn
    Friend WithEvents Satellite As DataGridViewTextBoxColumn
    Friend WithEvents Audits As DataGridViewTextBoxColumn
    Friend WithEvents Egress As DataGridViewTextBoxColumn
    Friend WithEvents Ingress As DataGridViewTextBoxColumn
    Friend WithEvents RepeirEgress As DataGridViewTextBoxColumn
    Friend WithEvents ReperIngres As DataGridViewTextBoxColumn
    Friend WithEvents TotalBandwidth As DataGridViewTextBoxColumn
    Friend WithEvents StorageUsed As DataGridViewTextBoxColumn
    Friend WithEvents SpaceUsed As DataGridViewTextBoxColumn
    Friend WithEvents Payout As DataGridViewTextBoxColumn
End Class
