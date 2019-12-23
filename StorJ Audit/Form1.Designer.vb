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
        Me.Node = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satellite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Audits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Egress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepeirEgress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalBandwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.NodeName = New System.Windows.Forms.TextBox()
        Me.UserIDBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveUserID = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.NodeView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1327, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Get Audits"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1327, 549)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(133, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "14002"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1327, 494)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(110, 22)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "192.168.88.240"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1327, 474)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Node IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1327, 529)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Node Port"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1424, 648)
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
        Me.NodeList.Location = New System.Drawing.Point(1311, 168)
        Me.NodeList.Name = "NodeList"
        Me.NodeList.Size = New System.Drawing.Size(241, 292)
        Me.NodeList.TabIndex = 7
        '
        'AddNodeBtn
        '
        Me.AddNodeBtn.Location = New System.Drawing.Point(1327, 604)
        Me.AddNodeBtn.Name = "AddNodeBtn"
        Me.AddNodeBtn.Size = New System.Drawing.Size(91, 23)
        Me.AddNodeBtn.TabIndex = 8
        Me.AddNodeBtn.Text = "Add Node"
        Me.AddNodeBtn.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1424, 604)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Delete Node"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'NodeView
        '
        Me.NodeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NodeView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Node, Me.Satellite, Me.Audits, Me.Egress, Me.Ingress, Me.RepeirEgress, Me.TotalBandwidth})
        Me.NodeView.Location = New System.Drawing.Point(1, 5)
        Me.NodeView.Name = "NodeView"
        Me.NodeView.RowHeadersWidth = 51
        Me.NodeView.RowTemplate.Height = 24
        Me.NodeView.Size = New System.Drawing.Size(1304, 679)
        Me.NodeView.TabIndex = 10
        '
        'Node
        '
        Me.Node.HeaderText = "Node"
        Me.Node.MinimumWidth = 6
        Me.Node.Name = "Node"
        Me.Node.ReadOnly = True
        Me.Node.Width = 150
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
        Me.Audits.Width = 125
        '
        'Egress
        '
        Me.Egress.HeaderText = "Egress"
        Me.Egress.MinimumWidth = 6
        Me.Egress.Name = "Egress"
        Me.Egress.ReadOnly = True
        Me.Egress.Width = 125
        '
        'Ingress
        '
        Me.Ingress.HeaderText = "Ingress"
        Me.Ingress.MinimumWidth = 6
        Me.Ingress.Name = "Ingress"
        Me.Ingress.ReadOnly = True
        Me.Ingress.Width = 125
        '
        'RepeirEgress
        '
        Me.RepeirEgress.HeaderText = "Repeir Egress"
        Me.RepeirEgress.MinimumWidth = 6
        Me.RepeirEgress.Name = "RepeirEgress"
        Me.RepeirEgress.ReadOnly = True
        Me.RepeirEgress.Width = 125
        '
        'TotalBandwidth
        '
        Me.TotalBandwidth.HeaderText = "Total Bandwidth"
        Me.TotalBandwidth.MinimumWidth = 6
        Me.TotalBandwidth.Name = "TotalBandwidth"
        Me.TotalBandwidth.ReadOnly = True
        Me.TotalBandwidth.Width = 125
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(1327, 82)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(202, 21)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Perform Discord Monitoring"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'NodeName
        '
        Me.NodeName.Location = New System.Drawing.Point(1443, 494)
        Me.NodeName.Name = "NodeName"
        Me.NodeName.Size = New System.Drawing.Size(109, 22)
        Me.NodeName.TabIndex = 12
        Me.NodeName.Text = "Node 1"
        '
        'UserIDBox
        '
        Me.UserIDBox.Location = New System.Drawing.Point(1311, 130)
        Me.UserIDBox.Name = "UserIDBox"
        Me.UserIDBox.Size = New System.Drawing.Size(148, 22)
        Me.UserIDBox.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1311, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Discord User ID"
        '
        'SaveUserID
        '
        Me.SaveUserID.Location = New System.Drawing.Point(1466, 130)
        Me.SaveUserID.Name = "SaveUserID"
        Me.SaveUserID.Size = New System.Drawing.Size(75, 23)
        Me.SaveUserID.TabIndex = 15
        Me.SaveUserID.Text = "Save"
        Me.SaveUserID.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1311, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Last Sended: Unknown"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1582, 685)
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
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Storj Audit and Monitoring"
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
    Friend WithEvents Node As DataGridViewTextBoxColumn
    Friend WithEvents Satellite As DataGridViewTextBoxColumn
    Friend WithEvents Audits As DataGridViewTextBoxColumn
    Friend WithEvents Egress As DataGridViewTextBoxColumn
    Friend WithEvents Ingress As DataGridViewTextBoxColumn
    Friend WithEvents RepeirEgress As DataGridViewTextBoxColumn
    Friend WithEvents TotalBandwidth As DataGridViewTextBoxColumn
End Class
