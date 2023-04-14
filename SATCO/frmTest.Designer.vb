<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTest
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
        Me.components = New System.ComponentModel.Container()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.cmdZero = New System.Windows.Forms.Button()
        Me.cmdRead = New System.Windows.Forms.Button()
        Me.grpLoadControl = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmdH2OOn = New System.Windows.Forms.Button()
        Me.cmdH2OOff = New System.Windows.Forms.Button()
        Me.cmdGate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdRedON = New System.Windows.Forms.Button()
        Me.cmdGreenON = New System.Windows.Forms.Button()
        Me.cmdSAON = New System.Windows.Forms.Button()
        Me.cmdUCON = New System.Windows.Forms.Button()
        Me.cmdUCOff = New System.Windows.Forms.Button()
        Me.cmdSAOff = New System.Windows.Forms.Button()
        Me.grpLoadStatus = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ScaleCom = New System.IO.Ports.SerialPort(Me.components)
        Me.Status = New System.Windows.Forms.TextBox()
        Me.Scale1Check = New System.Windows.Forms.Timer(Me.components)
        Me.grpTankStatus = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmdTank5 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmdTank1 = New System.Windows.Forms.Button()
        Me.cmdTank2 = New System.Windows.Forms.Button()
        Me.TankStatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grpLoadControl.SuspendLayout()
        Me.grpLoadStatus.SuspendLayout()
        Me.grpTankStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(133, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(486, 37)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Scale and System Status/Control"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtWeight)
        Me.GroupBox1.Controls.Add(Me.cmdZero)
        Me.GroupBox1.Controls.Add(Me.cmdRead)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 168)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scale Display and Zero"
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(141, 55)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(86, 26)
        Me.txtWeight.TabIndex = 2
        '
        'cmdZero
        '
        Me.cmdZero.Location = New System.Drawing.Point(22, 106)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(106, 39)
        Me.cmdZero.TabIndex = 1
        Me.cmdZero.Text = "Zero Scale"
        Me.cmdZero.UseVisualStyleBackColor = True
        '
        'cmdRead
        '
        Me.cmdRead.Location = New System.Drawing.Point(22, 48)
        Me.cmdRead.Name = "cmdRead"
        Me.cmdRead.Size = New System.Drawing.Size(106, 39)
        Me.cmdRead.TabIndex = 0
        Me.cmdRead.Text = "Read Scale"
        Me.cmdRead.UseVisualStyleBackColor = True
        '
        'grpLoadControl
        '
        Me.grpLoadControl.Controls.Add(Me.Label20)
        Me.grpLoadControl.Controls.Add(Me.cmdH2OOn)
        Me.grpLoadControl.Controls.Add(Me.cmdH2OOff)
        Me.grpLoadControl.Controls.Add(Me.cmdGate)
        Me.grpLoadControl.Controls.Add(Me.Label4)
        Me.grpLoadControl.Controls.Add(Me.Label3)
        Me.grpLoadControl.Controls.Add(Me.Label2)
        Me.grpLoadControl.Controls.Add(Me.Label1)
        Me.grpLoadControl.Controls.Add(Me.cmdRedON)
        Me.grpLoadControl.Controls.Add(Me.cmdGreenON)
        Me.grpLoadControl.Controls.Add(Me.cmdSAON)
        Me.grpLoadControl.Controls.Add(Me.cmdUCON)
        Me.grpLoadControl.Controls.Add(Me.cmdUCOff)
        Me.grpLoadControl.Controls.Add(Me.cmdSAOff)
        Me.grpLoadControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoadControl.Location = New System.Drawing.Point(33, 287)
        Me.grpLoadControl.Name = "grpLoadControl"
        Me.grpLoadControl.Size = New System.Drawing.Size(260, 284)
        Me.grpLoadControl.TabIndex = 44
        Me.grpLoadControl.TabStop = False
        Me.grpLoadControl.Text = "Trailer Load Control"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(141, 196)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 20)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "K2-H2O Enable"
        '
        'cmdH2OOn
        '
        Me.cmdH2OOn.Location = New System.Drawing.Point(83, 190)
        Me.cmdH2OOn.Name = "cmdH2OOn"
        Me.cmdH2OOn.Size = New System.Drawing.Size(43, 32)
        Me.cmdH2OOn.TabIndex = 12
        Me.cmdH2OOn.Text = "On"
        Me.cmdH2OOn.UseVisualStyleBackColor = True
        '
        'cmdH2OOff
        '
        Me.cmdH2OOff.Location = New System.Drawing.Point(20, 190)
        Me.cmdH2OOff.Name = "cmdH2OOff"
        Me.cmdH2OOff.Size = New System.Drawing.Size(43, 32)
        Me.cmdH2OOff.TabIndex = 11
        Me.cmdH2OOff.Text = "Off"
        Me.cmdH2OOff.UseVisualStyleBackColor = True
        '
        'cmdGate
        '
        Me.cmdGate.Location = New System.Drawing.Point(67, 229)
        Me.cmdGate.Name = "cmdGate"
        Me.cmdGate.Size = New System.Drawing.Size(106, 39)
        Me.cmdGate.TabIndex = 10
        Me.cmdGate.Text = "Open Gate"
        Me.cmdGate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(141, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "K1-UC Enable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(141, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "K0-SA Enable"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "K6-Green Light"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(141, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "K6-Red Light"
        '
        'cmdRedON
        '
        Me.cmdRedON.Location = New System.Drawing.Point(83, 38)
        Me.cmdRedON.Name = "cmdRedON"
        Me.cmdRedON.Size = New System.Drawing.Size(43, 32)
        Me.cmdRedON.TabIndex = 5
        Me.cmdRedON.Text = "On"
        Me.cmdRedON.UseVisualStyleBackColor = True
        '
        'cmdGreenON
        '
        Me.cmdGreenON.Location = New System.Drawing.Point(83, 76)
        Me.cmdGreenON.Name = "cmdGreenON"
        Me.cmdGreenON.Size = New System.Drawing.Size(43, 32)
        Me.cmdGreenON.TabIndex = 4
        Me.cmdGreenON.Text = "On"
        Me.cmdGreenON.UseVisualStyleBackColor = True
        '
        'cmdSAON
        '
        Me.cmdSAON.Location = New System.Drawing.Point(83, 114)
        Me.cmdSAON.Name = "cmdSAON"
        Me.cmdSAON.Size = New System.Drawing.Size(43, 32)
        Me.cmdSAON.TabIndex = 3
        Me.cmdSAON.Text = "On"
        Me.cmdSAON.UseVisualStyleBackColor = True
        '
        'cmdUCON
        '
        Me.cmdUCON.Location = New System.Drawing.Point(83, 152)
        Me.cmdUCON.Name = "cmdUCON"
        Me.cmdUCON.Size = New System.Drawing.Size(43, 32)
        Me.cmdUCON.TabIndex = 2
        Me.cmdUCON.Text = "On"
        Me.cmdUCON.UseVisualStyleBackColor = True
        '
        'cmdUCOff
        '
        Me.cmdUCOff.Location = New System.Drawing.Point(20, 152)
        Me.cmdUCOff.Name = "cmdUCOff"
        Me.cmdUCOff.Size = New System.Drawing.Size(43, 32)
        Me.cmdUCOff.TabIndex = 1
        Me.cmdUCOff.Text = "Off"
        Me.cmdUCOff.UseVisualStyleBackColor = True
        '
        'cmdSAOff
        '
        Me.cmdSAOff.Location = New System.Drawing.Point(20, 114)
        Me.cmdSAOff.Name = "cmdSAOff"
        Me.cmdSAOff.Size = New System.Drawing.Size(43, 32)
        Me.cmdSAOff.TabIndex = 0
        Me.cmdSAOff.Text = "Off"
        Me.cmdSAOff.UseVisualStyleBackColor = True
        '
        'grpLoadStatus
        '
        Me.grpLoadStatus.Controls.Add(Me.Label19)
        Me.grpLoadStatus.Controls.Add(Me.Label11)
        Me.grpLoadStatus.Controls.Add(Me.Label10)
        Me.grpLoadStatus.Controls.Add(Me.Label9)
        Me.grpLoadStatus.Controls.Add(Me.Label8)
        Me.grpLoadStatus.Controls.Add(Me.Label7)
        Me.grpLoadStatus.Controls.Add(Me.Label6)
        Me.grpLoadStatus.Controls.Add(Me.Label5)
        Me.grpLoadStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoadStatus.Location = New System.Drawing.Point(312, 99)
        Me.grpLoadStatus.Name = "grpLoadStatus"
        Me.grpLoadStatus.Size = New System.Drawing.Size(272, 381)
        Me.grpLoadStatus.TabIndex = 45
        Me.grpLoadStatus.TabStop = False
        Me.grpLoadStatus.Text = "Trailer Load Status"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(81, 337)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(172, 20)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "PB3-H2O Driver Ready"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(81, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(182, 20)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "PA3-Rail Switch Position"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(81, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 20)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "PB1-North Gangway"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(81, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(158, 20)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "PA1-South Gangway"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(81, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "PA2-SA Arm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(81, 298)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "PB2-UC Arm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(81, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "PA0-SA Driver Ready"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "PB0-UC Driver Ready"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(409, 496)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 39)
        Me.cmdExit.TabIndex = 46
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GateTimer
        '
        Me.GateTimer.Interval = 500
        '
        'StatusTimer
        '
        Me.StatusTimer.Interval = 1000
        '
        'ScaleCom
        '
        '
        'Status
        '
        Me.Status.Location = New System.Drawing.Point(312, 586)
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Size = New System.Drawing.Size(473, 20)
        Me.Status.TabIndex = 47
        '
        'Scale1Check
        '
        '
        'grpTankStatus
        '
        Me.grpTankStatus.Controls.Add(Me.Label18)
        Me.grpTankStatus.Controls.Add(Me.Label16)
        Me.grpTankStatus.Controls.Add(Me.Label17)
        Me.grpTankStatus.Controls.Add(Me.Label15)
        Me.grpTankStatus.Controls.Add(Me.cmdTank5)
        Me.grpTankStatus.Controls.Add(Me.Label12)
        Me.grpTankStatus.Controls.Add(Me.Label14)
        Me.grpTankStatus.Controls.Add(Me.cmdTank1)
        Me.grpTankStatus.Controls.Add(Me.cmdTank2)
        Me.grpTankStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTankStatus.Location = New System.Drawing.Point(607, 99)
        Me.grpTankStatus.Name = "grpTankStatus"
        Me.grpTankStatus.Size = New System.Drawing.Size(260, 311)
        Me.grpTankStatus.TabIndex = 48
        Me.grpTankStatus.TabStop = False
        Me.grpTankStatus.Text = "Tank Selection"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(78, 264)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(150, 20)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "PA2 - Tank 5 Ready"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(78, 226)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(150, 20)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "PA1 - Tank 2 Ready"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(78, 188)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(150, 20)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "PA0 - Tank 1 Ready"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(138, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 20)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "K2-Tank 5"
        '
        'cmdTank5
        '
        Me.cmdTank5.Location = New System.Drawing.Point(80, 125)
        Me.cmdTank5.Name = "cmdTank5"
        Me.cmdTank5.Size = New System.Drawing.Size(43, 32)
        Me.cmdTank5.TabIndex = 11
        Me.cmdTank5.Text = "On"
        Me.cmdTank5.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(138, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 20)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "K1-Tank 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(138, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 20)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "K0-Tank 1"
        '
        'cmdTank1
        '
        Me.cmdTank1.Location = New System.Drawing.Point(80, 48)
        Me.cmdTank1.Name = "cmdTank1"
        Me.cmdTank1.Size = New System.Drawing.Size(43, 32)
        Me.cmdTank1.TabIndex = 3
        Me.cmdTank1.Text = "On"
        Me.cmdTank1.UseVisualStyleBackColor = True
        '
        'cmdTank2
        '
        Me.cmdTank2.Location = New System.Drawing.Point(80, 86)
        Me.cmdTank2.Name = "cmdTank2"
        Me.cmdTank2.Size = New System.Drawing.Size(43, 32)
        Me.cmdTank2.TabIndex = 2
        Me.cmdTank2.Text = "On"
        Me.cmdTank2.UseVisualStyleBackColor = True
        '
        'TankStatusTimer
        '
        Me.TankStatusTimer.Interval = 1000
        '
        'LoadTimer
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(150, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 34)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 618)
        Me.Controls.Add(Me.grpTankStatus)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.grpLoadStatus)
        Me.Controls.Add(Me.grpLoadControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpLoadControl.ResumeLayout(False)
        Me.grpLoadControl.PerformLayout()
        Me.grpLoadStatus.ResumeLayout(False)
        Me.grpLoadStatus.PerformLayout()
        Me.grpTankStatus.ResumeLayout(False)
        Me.grpTankStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents cmdRead As System.Windows.Forms.Button
    Friend WithEvents grpLoadControl As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGate As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdRedON As System.Windows.Forms.Button
    Friend WithEvents cmdGreenON As System.Windows.Forms.Button
    Friend WithEvents cmdSAON As System.Windows.Forms.Button
    Friend WithEvents cmdUCON As System.Windows.Forms.Button
    Friend WithEvents cmdUCOff As System.Windows.Forms.Button
    Friend WithEvents cmdSAOff As System.Windows.Forms.Button
    Friend WithEvents grpLoadStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents GateTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusTimer As System.Windows.Forms.Timer
    Friend WithEvents ScaleCom As System.IO.Ports.SerialPort
    Friend WithEvents Status As System.Windows.Forms.TextBox
    Friend WithEvents Scale1Check As System.Windows.Forms.Timer
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
    Friend WithEvents TankStatusTimer As Timer
    Friend WithEvents LoadTimer As Timer
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cmdH2OOn As Button
    Friend WithEvents cmdH2OOff As Button
    Friend WithEvents Button1 As Button
End Class
