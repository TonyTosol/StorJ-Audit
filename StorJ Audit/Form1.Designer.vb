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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.NodeName = New System.Windows.Forms.TextBox()
        Me.UserIDBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveUserID = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
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
        Me.Button1.Location = New System.Drawing.Point(1188, 528)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 19)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Get Audits"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1188, 408)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(101, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "14002"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1188, 364)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(84, 20)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "192.168.88.240"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1188, 347)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Node IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1188, 392)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Node Port"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1261, 528)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 19)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NodeList
        '
        Me.NodeList.FormattingEnabled = True
        Me.NodeList.Location = New System.Drawing.Point(1179, 128)
        Me.NodeList.Margin = New System.Windows.Forms.Padding(2)
        Me.NodeList.Name = "NodeList"
        Me.NodeList.Size = New System.Drawing.Size(182, 212)
        Me.NodeList.TabIndex = 7
        '
        'AddNodeBtn
        '
        Me.AddNodeBtn.Location = New System.Drawing.Point(1188, 493)
        Me.AddNodeBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.AddNodeBtn.Name = "AddNodeBtn"
        Me.AddNodeBtn.Size = New System.Drawing.Size(68, 19)
        Me.AddNodeBtn.TabIndex = 8
        Me.AddNodeBtn.Text = "Add Node"
        Me.AddNodeBtn.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1261, 493)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 19)
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
        Me.NodeView.Location = New System.Drawing.Point(1, 4)
        Me.NodeView.Margin = New System.Windows.Forms.Padding(2)
        Me.NodeView.Name = "NodeView"
        Me.NodeView.ReadOnly = True
        Me.NodeView.RowHeadersWidth = 51
        Me.NodeView.RowTemplate.Height = 24
        Me.NodeView.Size = New System.Drawing.Size(1172, 552)
        Me.NodeView.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(1179, 33)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(153, 17)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Perform Discord Monitoring"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'NodeName
        '
        Me.NodeName.Location = New System.Drawing.Point(1275, 364)
        Me.NodeName.Margin = New System.Windows.Forms.Padding(2)
        Me.NodeName.Name = "NodeName"
        Me.NodeName.Size = New System.Drawing.Size(83, 20)
        Me.NodeName.TabIndex = 12
        Me.NodeName.Text = "Node 1"
        '
        'UserIDBox
        '
        Me.UserIDBox.Location = New System.Drawing.Point(1179, 103)
        Me.UserIDBox.Margin = New System.Windows.Forms.Padding(2)
        Me.UserIDBox.Name = "UserIDBox"
        Me.UserIDBox.Size = New System.Drawing.Size(112, 20)
        Me.UserIDBox.TabIndex = 13
        Me.UserIDBox.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1179, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Discord User ID"
        Me.Label3.Visible = False
        '
        'SaveUserID
        '
        Me.SaveUserID.Location = New System.Drawing.Point(1286, 103)
        Me.SaveUserID.Margin = New System.Windows.Forms.Padding(2)
        Me.SaveUserID.Name = "SaveUserID"
        Me.SaveUserID.Size = New System.Drawing.Size(56, 19)
        Me.SaveUserID.TabIndex = 15
        Me.SaveUserID.Text = "Save"
        Me.SaveUserID.UseVisualStyleBackColor = True
        Me.SaveUserID.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1177, 8)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Last Sended: Unknown"
        Me.Label4.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(1179, 64)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(170, 17)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "Log Monitoring(for this pc only)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
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
        Me.Audits.HeaderText = "Successful Audits"
        Me.Audits.MinimumWidth = 6
        Me.Audits.Name = "Audits"
        Me.Audits.ReadOnly = True
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
        '
        'ReperIngres
        '
        Me.ReperIngres.HeaderText = "Repair Ingres"
        Me.ReperIngres.Name = "ReperIngres"
        Me.ReperIngres.ReadOnly = True
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
        Me.SpaceUsed.HeaderText = "Space/Used"
        Me.SpaceUsed.Name = "SpaceUsed"
        Me.SpaceUsed.ReadOnly = True
        Me.SpaceUsed.Width = 80
        '
        'Payout
        '
        Me.Payout.HeaderText = "Payout"
        Me.Payout.Name = "Payout"
        Me.Payout.ReadOnly = True
        Me.Payout.Width = 50
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1362, 557)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SaveUserID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UserIDBox)
        Me.Controls.Add(Me.NodeName)
        Me.Controls.Add(Me.CheckBox1)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
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
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents NodeName As TextBox
    Friend WithEvents UserIDBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveUserID As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox2 As CheckBox
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
