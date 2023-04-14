<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTankSelect
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTankSelect))
        Me.grpTankStatus = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmdTank5 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmdTank1 = New System.Windows.Forms.Button()
        Me.cmdTank2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.StatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTank = New System.Windows.Forms.Label()
        Me.lblSelTank = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblAnalysis1 = New System.Windows.Forms.Label()
        Me.lblAnalysis2 = New System.Windows.Forms.Label()
        Me.grpTankStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpTankStatus
        '
        Me.grpTankStatus.Controls.Add(Me.TextBox1)
        Me.grpTankStatus.Controls.Add(Me.Label18)
        Me.grpTankStatus.Controls.Add(Me.Label16)
        Me.grpTankStatus.Controls.Add(Me.Label17)
        Me.grpTankStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTankStatus.Location = New System.Drawing.Point(186, 156)
        Me.grpTankStatus.Name = "grpTankStatus"
        Me.grpTankStatus.Size = New System.Drawing.Size(260, 311)
        Me.grpTankStatus.TabIndex = 49
        Me.grpTankStatus.TabStop = False
        Me.grpTankStatus.Text = "Tank Selection"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 25)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(248, 146)
        Me.TextBox1.TabIndex = 16
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(78, 264)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 20)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Tank 5 Status"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(78, 226)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 20)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Tank 2 Status"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(78, 188)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 20)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Tank 1 Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(476, 488)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "K2-Tank 5"
        Me.Label15.Visible = False
        '
        'cmdTank5
        '
        Me.cmdTank5.Location = New System.Drawing.Point(418, 482)
        Me.cmdTank5.Name = "cmdTank5"
        Me.cmdTank5.Size = New System.Drawing.Size(43, 32)
        Me.cmdTank5.TabIndex = 11
        Me.cmdTank5.Text = "On"
        Me.cmdTank5.UseVisualStyleBackColor = True
        Me.cmdTank5.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(343, 488)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "K1-Tank 2"
        Me.Label12.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(201, 488)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "K0-Tank 1"
        Me.Label14.Visible = False
        '
        'cmdTank1
        '
        Me.cmdTank1.Location = New System.Drawing.Point(152, 482)
        Me.cmdTank1.Name = "cmdTank1"
        Me.cmdTank1.Size = New System.Drawing.Size(43, 32)
        Me.cmdTank1.TabIndex = 3
        Me.cmdTank1.Text = "On"
        Me.cmdTank1.UseVisualStyleBackColor = True
        Me.cmdTank1.Visible = False
        '
        'cmdTank2
        '
        Me.cmdTank2.Location = New System.Drawing.Point(285, 482)
        Me.cmdTank2.Name = "cmdTank2"
        Me.cmdTank2.Size = New System.Drawing.Size(43, 32)
        Me.cmdTank2.TabIndex = 2
        Me.cmdTank2.Text = "On"
        Me.cmdTank2.UseVisualStyleBackColor = True
        Me.cmdTank2.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(218, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(228, 37)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Tank Selection"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(225, 520)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(208, 39)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Cancel Tank Request"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'StatusTimer
        '
        Me.StatusTimer.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(213, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 20)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Requested Tank #: "
        '
        'lblTank
        '
        Me.lblTank.AutoSize = True
        Me.lblTank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTank.Location = New System.Drawing.Point(389, 86)
        Me.lblTank.Name = "lblTank"
        Me.lblTank.Size = New System.Drawing.Size(29, 20)
        Me.lblTank.TabIndex = 53
        Me.lblTank.Text = "00"
        '
        'lblSelTank
        '
        Me.lblSelTank.AutoSize = True
        Me.lblSelTank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelTank.Location = New System.Drawing.Point(389, 115)
        Me.lblSelTank.Name = "lblSelTank"
        Me.lblSelTank.Size = New System.Drawing.Size(29, 20)
        Me.lblSelTank.TabIndex = 55
        Me.lblSelTank.Text = "00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(213, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 20)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Current Tank #: "
        '
        'LoadTimer
        '
        '
        'lblAnalysis1
        '
        Me.lblAnalysis1.AutoSize = True
        Me.lblAnalysis1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnalysis1.Location = New System.Drawing.Point(450, 86)
        Me.lblAnalysis1.Name = "lblAnalysis1"
        Me.lblAnalysis1.Size = New System.Drawing.Size(49, 20)
        Me.lblAnalysis1.TabIndex = 56
        Me.lblAnalysis1.Text = "0.0%"
        '
        'lblAnalysis2
        '
        Me.lblAnalysis2.AutoSize = True
        Me.lblAnalysis2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnalysis2.Location = New System.Drawing.Point(450, 115)
        Me.lblAnalysis2.Name = "lblAnalysis2"
        Me.lblAnalysis2.Size = New System.Drawing.Size(49, 20)
        Me.lblAnalysis2.TabIndex = 57
        Me.lblAnalysis2.Text = "0.0%"
        '
        'frmTankSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 586)
        Me.Controls.Add(Me.lblAnalysis2)
        Me.Controls.Add(Me.lblAnalysis1)
        Me.Controls.Add(Me.lblSelTank)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTank)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.grpTankStatus)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmdTank5)
        Me.Controls.Add(Me.cmdTank2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdTank1)
        Me.Controls.Add(Me.Label14)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTankSelect"
        Me.Text = "frmTankSelect"
        Me.grpTankStatus.ResumeLayout(False)
        Me.grpTankStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpTankStatus As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmdTank5 As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmdTank1 As Button
    Friend WithEvents cmdTank2 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents cmdExit As Button
    Friend WithEvents StatusTimer As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTank As Label
    Friend WithEvents lblSelTank As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LoadTimer As Timer
    Friend WithEvents lblAnalysis1 As Label
    Friend WithEvents lblAnalysis2 As Label
End Class
