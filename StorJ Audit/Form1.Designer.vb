<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.NodeList = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.NodeView = New System.Windows.Forms.DataGridView()
        Me.Node = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satellite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Audits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uptime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Upload = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Download = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepearUpload = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalBandwidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.NodeView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1327, 535)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Get Audits"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1327, 436)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(133, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "14002"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1327, 381)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(133, 22)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "192.168.88.240"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1327, 361)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Node IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1327, 416)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Node Port"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1327, 564)
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
        Me.NodeList.Location = New System.Drawing.Point(1327, 27)
        Me.NodeList.Name = "NodeList"
        Me.NodeList.Size = New System.Drawing.Size(188, 292)
        Me.NodeList.TabIndex = 7
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1327, 491)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Add Node"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1424, 491)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Delete Node"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'NodeView
        '
        Me.NodeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NodeView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Node, Me.Satellite, Me.Audits, Me.Uptime, Me.Upload, Me.Download, Me.RepearUpload, Me.TotalBandwidth})
        Me.NodeView.Location = New System.Drawing.Point(1, 5)
        Me.NodeView.Name = "NodeView"
        Me.NodeView.RowHeadersWidth = 51
        Me.NodeView.RowTemplate.Height = 24
        Me.NodeView.Size = New System.Drawing.Size(1304, 678)
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
        Me.Audits.HeaderText = "Audits"
        Me.Audits.MinimumWidth = 6
        Me.Audits.Name = "Audits"
        Me.Audits.ReadOnly = True
        '
        'Uptime
        '
        Me.Uptime.HeaderText = "Uptime"
        Me.Uptime.MinimumWidth = 6
        Me.Uptime.Name = "Uptime"
        Me.Uptime.ReadOnly = True
        '
        'Upload
        '
        Me.Upload.HeaderText = "Upload"
        Me.Upload.MinimumWidth = 6
        Me.Upload.Name = "Upload"
        Me.Upload.ReadOnly = True
        '
        'Download
        '
        Me.Download.HeaderText = "Download"
        Me.Download.MinimumWidth = 6
        Me.Download.Name = "Download"
        Me.Download.ReadOnly = True
        '
        'RepearUpload
        '
        Me.RepearUpload.HeaderText = "RepearUpload"
        Me.RepearUpload.MinimumWidth = 6
        Me.RepearUpload.Name = "RepearUpload"
        Me.RepearUpload.ReadOnly = True
        '
        'TotalBandwidth
        '
        Me.TotalBandwidth.HeaderText = "Total Bandwidth"
        Me.TotalBandwidth.MinimumWidth = 6
        Me.TotalBandwidth.Name = "TotalBandwidth"
        Me.TotalBandwidth.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1527, 685)
        Me.Controls.Add(Me.NodeView)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.NodeList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Node values Agregator"
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
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents NodeView As DataGridView
    Friend WithEvents Node As DataGridViewTextBoxColumn
    Friend WithEvents Satellite As DataGridViewTextBoxColumn
    Friend WithEvents Audits As DataGridViewTextBoxColumn
    Friend WithEvents Uptime As DataGridViewTextBoxColumn
    Friend WithEvents Upload As DataGridViewTextBoxColumn
    Friend WithEvents Download As DataGridViewTextBoxColumn
    Friend WithEvents RepearUpload As DataGridViewTextBoxColumn
    Friend WithEvents TotalBandwidth As DataGridViewTextBoxColumn
End Class
