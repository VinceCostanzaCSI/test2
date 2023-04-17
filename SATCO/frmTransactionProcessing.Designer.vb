<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransactionProcessing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransactionProcessing))
        Me.lblFilling = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCarrier = New System.Windows.Forms.TextBox()
        Me.txtDriverName = New System.Windows.Forms.TextBox()
        Me.txtDriverId = New System.Windows.Forms.TextBox()
        Me.txtCardId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.cboCode = New System.Windows.Forms.ComboBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.txtConsignee = New System.Windows.Forms.TextBox()
        Me.lblNSF = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSeal4 = New System.Windows.Forms.Label()
        Me.lblSeal3 = New System.Windows.Forms.Label()
        Me.lblSeal2 = New System.Windows.Forms.Label()
        Me.lblSeal1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblH2O = New System.Windows.Forms.Label()
        Me.txtH2OTarget = New System.Windows.Forms.TextBox()
        Me.txtSeal4 = New System.Windows.Forms.TextBox()
        Me.txtSeal3 = New System.Windows.Forms.TextBox()
        Me.txtSeal2 = New System.Windows.Forms.TextBox()
        Me.txtSeal1 = New System.Windows.Forms.TextBox()
        Me.txtTrailer = New System.Windows.Forms.TextBox()
        Me.txtVehicle = New System.Windows.Forms.TextBox()
        Me.txtTargetWt = New System.Windows.Forms.TextBox()
        Me.txtDisplayTarget = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblDesc4 = New System.Windows.Forms.Label()
        Me.txtDescription4 = New System.Windows.Forms.TextBox()
        Me.cboCommodity = New System.Windows.Forms.ComboBox()
        Me.txtDescription3 = New System.Windows.Forms.TextBox()
        Me.txtDescription2 = New System.Windows.Forms.TextBox()
        Me.txtDescription1 = New System.Windows.Forms.TextBox()
        Me.txtTank = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblDesc3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtReleaseNumber = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Demo = New System.Windows.Forms.GroupBox()
        Me.chkH2ODR = New System.Windows.Forms.CheckBox()
        Me.chkUCDR = New System.Windows.Forms.CheckBox()
        Me.chkLoadingArm = New System.Windows.Forms.CheckBox()
        Me.chkSADR = New System.Windows.Forms.CheckBox()
        Me.chkPlatform = New System.Windows.Forms.CheckBox()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.txtTare = New System.Windows.Forms.TextBox()
        Me.txtGross = New System.Windows.Forms.TextBox()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtInTime = New System.Windows.Forms.TextBox()
        Me.txtOutTime = New System.Windows.Forms.TextBox()
        Me.GrossBox = New System.Windows.Forms.TextBox()
        Me.TareBox = New System.Windows.Forms.TextBox()
        Me.NetBox = New System.Windows.Forms.TextBox()
        Me.TonBox = New System.Windows.Forms.TextBox()
        Me.FrameFilling = New System.Windows.Forms.GroupBox()
        Me.FrameWaiting = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.FramePullOnScale = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RedLight = New System.Windows.Forms.PictureBox()
        Me.GreenLight = New System.Windows.Forms.PictureBox()
        Me.Status = New System.Windows.Forms.TextBox()
        Me.FrameTareWeight = New System.Windows.Forms.GroupBox()
        Me.lblDriverReady = New System.Windows.Forms.Label()
        Me.FramePlatform = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FramePaused = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.PlatformTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Scale1Box = New System.Windows.Forms.TextBox()
        Me.Scale1Check = New System.Windows.Forms.Timer(Me.components)
        Me.WatchDogTimer = New System.Windows.Forms.Timer(Me.components)
        Me.txtWD = New System.Windows.Forms.TextBox()
        Me.cmdWD = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ScaleCom = New System.IO.Ports.SerialPort(Me.components)
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.InputTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblSA = New System.Windows.Forms.Label()
        Me.lblUC = New System.Windows.Forms.Label()
        Me.lblNetCapacity = New System.Windows.Forms.Label()
        Me.txtNetCapacity = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.MaxWeightBox = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.LoadStatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TankRequestTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblWater = New System.Windows.Forms.Label()
        Me.grpLoadStatus = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TruckImage = New System.Windows.Forms.PictureBox()
        Me.MyVerticalProgessBar1 = New SATCO.MyVerticalProgessBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Demo.SuspendLayout()
        Me.FrameFilling.SuspendLayout()
        Me.FrameWaiting.SuspendLayout()
        Me.FramePullOnScale.SuspendLayout()
        CType(Me.RedLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GreenLight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FrameTareWeight.SuspendLayout()
        Me.FramePlatform.SuspendLayout()
        Me.FramePaused.SuspendLayout()
        Me.grpLoadStatus.SuspendLayout()
        CType(Me.TruckImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFilling
        '
        Me.lblFilling.AutoSize = True
        Me.lblFilling.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilling.ForeColor = System.Drawing.Color.Red
        Me.lblFilling.Location = New System.Drawing.Point(190, 20)
        Me.lblFilling.Name = "lblFilling"
        Me.lblFilling.Size = New System.Drawing.Size(128, 37)
        Me.lblFilling.TabIndex = 0
        Me.lblFilling.Text = "Filling !"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCarrier)
        Me.GroupBox1.Controls.Add(Me.txtDriverName)
        Me.GroupBox1.Controls.Add(Me.txtDriverId)
        Me.GroupBox1.Controls.Add(Me.txtCardId)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(28, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 99)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Driver"
        '
        'txtCarrier
        '
        Me.txtCarrier.Enabled = False
        Me.txtCarrier.Location = New System.Drawing.Point(368, 62)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.Size = New System.Drawing.Size(428, 26)
        Me.txtCarrier.TabIndex = 7
        '
        'txtDriverName
        '
        Me.txtDriverName.Enabled = False
        Me.txtDriverName.Location = New System.Drawing.Point(368, 22)
        Me.txtDriverName.Name = "txtDriverName"
        Me.txtDriverName.Size = New System.Drawing.Size(428, 26)
        Me.txtDriverName.TabIndex = 6
        '
        'txtDriverId
        '
        Me.txtDriverId.Enabled = False
        Me.txtDriverId.Location = New System.Drawing.Point(108, 62)
        Me.txtDriverId.Name = "txtDriverId"
        Me.txtDriverId.Size = New System.Drawing.Size(129, 26)
        Me.txtDriverId.TabIndex = 5
        Me.txtDriverId.Tag = "Driver ID"
        '
        'txtCardId
        '
        Me.txtCardId.Enabled = False
        Me.txtCardId.Location = New System.Drawing.Point(108, 22)
        Me.txtCardId.Name = "txtCardId"
        Me.txtCardId.Size = New System.Drawing.Size(129, 26)
        Me.txtCardId.TabIndex = 4
        Me.txtCardId.Tag = "Card ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(295, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Carrier:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(295, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Card #:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.txtPO)
        Me.GroupBox2.Controls.Add(Me.cboCode)
        Me.GroupBox2.Controls.Add(Me.txtDestination)
        Me.GroupBox2.Controls.Add(Me.txtConsignee)
        Me.GroupBox2.Controls.Add(Me.lblNSF)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(28, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(829, 105)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consignee"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(53, 67)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(38, 20)
        Me.Label39.TabIndex = 13
        Me.Label39.Text = "PO:"
        '
        'txtPO
        '
        Me.txtPO.Enabled = False
        Me.txtPO.Location = New System.Drawing.Point(108, 64)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(176, 26)
        Me.txtPO.TabIndex = 12
        Me.txtPO.Tag = "Driver ID"
        '
        'cboCode
        '
        Me.cboCode.Enabled = False
        Me.cboCode.FormattingEnabled = True
        Me.cboCode.Location = New System.Drawing.Point(108, 28)
        Me.cboCode.Name = "cboCode"
        Me.cboCode.Size = New System.Drawing.Size(129, 28)
        Me.cboCode.TabIndex = 11
        Me.cboCode.Tag = "Consignee"
        '
        'txtDestination
        '
        Me.txtDestination.Enabled = False
        Me.txtDestination.Location = New System.Drawing.Point(428, 64)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(368, 26)
        Me.txtDestination.TabIndex = 10
        '
        'txtConsignee
        '
        Me.txtConsignee.Enabled = False
        Me.txtConsignee.Location = New System.Drawing.Point(428, 30)
        Me.txtConsignee.Name = "txtConsignee"
        Me.txtConsignee.Size = New System.Drawing.Size(368, 26)
        Me.txtConsignee.TabIndex = 8
        '
        'lblNSF
        '
        Me.lblNSF.AutoSize = True
        Me.lblNSF.Location = New System.Drawing.Point(243, 31)
        Me.lblNSF.Name = "lblNSF"
        Me.lblNSF.Size = New System.Drawing.Size(44, 20)
        Me.lblNSF.TabIndex = 7
        Me.lblNSF.Text = "NSF"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(317, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Destination:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(317, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Code:"
        '
        'lblSeal4
        '
        Me.lblSeal4.AutoSize = True
        Me.lblSeal4.Location = New System.Drawing.Point(629, 67)
        Me.lblSeal4.Name = "lblSeal4"
        Me.lblSeal4.Size = New System.Drawing.Size(55, 20)
        Me.lblSeal4.TabIndex = 13
        Me.lblSeal4.Tag = "Seal4"
        Me.lblSeal4.Text = "Seal4"
        '
        'lblSeal3
        '
        Me.lblSeal3.AutoSize = True
        Me.lblSeal3.Location = New System.Drawing.Point(413, 66)
        Me.lblSeal3.Name = "lblSeal3"
        Me.lblSeal3.Size = New System.Drawing.Size(55, 20)
        Me.lblSeal3.TabIndex = 12
        Me.lblSeal3.Tag = "Seal3"
        Me.lblSeal3.Text = "Seal3"
        '
        'lblSeal2
        '
        Me.lblSeal2.AutoSize = True
        Me.lblSeal2.Location = New System.Drawing.Point(213, 64)
        Me.lblSeal2.Name = "lblSeal2"
        Me.lblSeal2.Size = New System.Drawing.Size(55, 20)
        Me.lblSeal2.TabIndex = 9
        Me.lblSeal2.Tag = "Seal2"
        Me.lblSeal2.Text = "Seal2"
        '
        'lblSeal1
        '
        Me.lblSeal1.AutoSize = True
        Me.lblSeal1.Location = New System.Drawing.Point(10, 66)
        Me.lblSeal1.Name = "lblSeal1"
        Me.lblSeal1.Size = New System.Drawing.Size(55, 20)
        Me.lblSeal1.TabIndex = 8
        Me.lblSeal1.Tag = "Seal1"
        Me.lblSeal1.Text = "Seal1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblH2O)
        Me.GroupBox3.Controls.Add(Me.txtH2OTarget)
        Me.GroupBox3.Controls.Add(Me.txtSeal4)
        Me.GroupBox3.Controls.Add(Me.txtSeal3)
        Me.GroupBox3.Controls.Add(Me.txtSeal2)
        Me.GroupBox3.Controls.Add(Me.txtSeal1)
        Me.GroupBox3.Controls.Add(Me.lblSeal4)
        Me.GroupBox3.Controls.Add(Me.txtTrailer)
        Me.GroupBox3.Controls.Add(Me.lblSeal3)
        Me.GroupBox3.Controls.Add(Me.txtVehicle)
        Me.GroupBox3.Controls.Add(Me.txtTargetWt)
        Me.GroupBox3.Controls.Add(Me.txtDisplayTarget)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.lblSeal2)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label37)
        Me.GroupBox3.Controls.Add(Me.lblSeal1)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(28, 320)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(829, 99)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Vehicle"
        '
        'lblH2O
        '
        Me.lblH2O.AutoSize = True
        Me.lblH2O.Location = New System.Drawing.Point(213, 26)
        Me.lblH2O.Name = "lblH2O"
        Me.lblH2O.Size = New System.Drawing.Size(107, 20)
        Me.lblH2O.TabIndex = 21
        Me.lblH2O.Text = "H2O Target:"
        '
        'txtH2OTarget
        '
        Me.txtH2OTarget.Enabled = False
        Me.txtH2OTarget.Location = New System.Drawing.Point(321, 23)
        Me.txtH2OTarget.Name = "txtH2OTarget"
        Me.txtH2OTarget.Size = New System.Drawing.Size(68, 26)
        Me.txtH2OTarget.TabIndex = 20
        Me.txtH2OTarget.Tag = "Target Weight"
        '
        'txtSeal4
        '
        Me.txtSeal4.Enabled = False
        Me.txtSeal4.Location = New System.Drawing.Point(690, 61)
        Me.txtSeal4.MaxLength = 12
        Me.txtSeal4.Name = "txtSeal4"
        Me.txtSeal4.Size = New System.Drawing.Size(136, 26)
        Me.txtSeal4.TabIndex = 19
        Me.txtSeal4.Tag = "Seal 4"
        '
        'txtSeal3
        '
        Me.txtSeal3.Enabled = False
        Me.txtSeal3.Location = New System.Drawing.Point(474, 61)
        Me.txtSeal3.MaxLength = 12
        Me.txtSeal3.Name = "txtSeal3"
        Me.txtSeal3.Size = New System.Drawing.Size(136, 26)
        Me.txtSeal3.TabIndex = 18
        Me.txtSeal3.Tag = "Seal 3"
        '
        'txtSeal2
        '
        Me.txtSeal2.Enabled = False
        Me.txtSeal2.Location = New System.Drawing.Point(271, 61)
        Me.txtSeal2.MaxLength = 12
        Me.txtSeal2.Name = "txtSeal2"
        Me.txtSeal2.Size = New System.Drawing.Size(136, 26)
        Me.txtSeal2.TabIndex = 17
        Me.txtSeal2.Tag = "Seal 2"
        '
        'txtSeal1
        '
        Me.txtSeal1.Enabled = False
        Me.txtSeal1.Location = New System.Drawing.Point(68, 63)
        Me.txtSeal1.MaxLength = 12
        Me.txtSeal1.Name = "txtSeal1"
        Me.txtSeal1.Size = New System.Drawing.Size(136, 26)
        Me.txtSeal1.TabIndex = 16
        Me.txtSeal1.Tag = "Seal 1"
        '
        'txtTrailer
        '
        Me.txtTrailer.Enabled = False
        Me.txtTrailer.Location = New System.Drawing.Point(690, 23)
        Me.txtTrailer.Name = "txtTrailer"
        Me.txtTrailer.Size = New System.Drawing.Size(133, 26)
        Me.txtTrailer.TabIndex = 15
        Me.txtTrailer.Tag = "Trailer"
        '
        'txtVehicle
        '
        Me.txtVehicle.Enabled = False
        Me.txtVehicle.Location = New System.Drawing.Point(474, 23)
        Me.txtVehicle.Name = "txtVehicle"
        Me.txtVehicle.Size = New System.Drawing.Size(135, 26)
        Me.txtVehicle.TabIndex = 14
        Me.txtVehicle.Tag = "Vehicle"
        '
        'txtTargetWt
        '
        Me.txtTargetWt.Enabled = False
        Me.txtTargetWt.Location = New System.Drawing.Point(134, 46)
        Me.txtTargetWt.Name = "txtTargetWt"
        Me.txtTargetWt.Size = New System.Drawing.Size(67, 26)
        Me.txtTargetWt.TabIndex = 13
        Me.txtTargetWt.Visible = False
        '
        'txtDisplayTarget
        '
        Me.txtDisplayTarget.Enabled = False
        Me.txtDisplayTarget.Location = New System.Drawing.Point(134, 20)
        Me.txtDisplayTarget.Name = "txtDisplayTarget"
        Me.txtDisplayTarget.Size = New System.Drawing.Size(74, 26)
        Me.txtDisplayTarget.TabIndex = 11
        Me.txtDisplayTarget.Tag = "Target Weight"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(629, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 20)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Trailer:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(401, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 20)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Vehicle:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(35, 26)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(93, 20)
        Me.Label37.TabIndex = 10
        Me.Label37.Text = "Target Wt:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(35, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 20)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Target Wt:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblDesc4)
        Me.GroupBox4.Controls.Add(Me.txtDescription4)
        Me.GroupBox4.Controls.Add(Me.cboCommodity)
        Me.GroupBox4.Controls.Add(Me.txtDescription3)
        Me.GroupBox4.Controls.Add(Me.txtDescription2)
        Me.GroupBox4.Controls.Add(Me.txtDescription1)
        Me.GroupBox4.Controls.Add(Me.txtTank)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.lblDesc3)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(28, 425)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(829, 123)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Commodity"
        '
        'lblDesc4
        '
        Me.lblDesc4.AutoSize = True
        Me.lblDesc4.Location = New System.Drawing.Point(517, 90)
        Me.lblDesc4.Name = "lblDesc4"
        Me.lblDesc4.Size = New System.Drawing.Size(120, 20)
        Me.lblDesc4.TabIndex = 24
        Me.lblDesc4.Text = "Description 4:"
        '
        'txtDescription4
        '
        Me.txtDescription4.Enabled = False
        Me.txtDescription4.Location = New System.Drawing.Point(643, 87)
        Me.txtDescription4.MaxLength = 12
        Me.txtDescription4.Name = "txtDescription4"
        Me.txtDescription4.Size = New System.Drawing.Size(153, 26)
        Me.txtDescription4.TabIndex = 23
        '
        'cboCommodity
        '
        Me.cboCommodity.Enabled = False
        Me.cboCommodity.FormattingEnabled = True
        Me.cboCommodity.Location = New System.Drawing.Point(108, 23)
        Me.cboCommodity.Name = "cboCommodity"
        Me.cboCommodity.Size = New System.Drawing.Size(107, 28)
        Me.cboCommodity.TabIndex = 22
        Me.cboCommodity.Tag = "Commodity ID"
        '
        'txtDescription3
        '
        Me.txtDescription3.Enabled = False
        Me.txtDescription3.Location = New System.Drawing.Point(359, 87)
        Me.txtDescription3.MaxLength = 12
        Me.txtDescription3.Name = "txtDescription3"
        Me.txtDescription3.Size = New System.Drawing.Size(152, 26)
        Me.txtDescription3.TabIndex = 21
        '
        'txtDescription2
        '
        Me.txtDescription2.Enabled = False
        Me.txtDescription2.Location = New System.Drawing.Point(457, 55)
        Me.txtDescription2.MaxLength = 12
        Me.txtDescription2.Name = "txtDescription2"
        Me.txtDescription2.Size = New System.Drawing.Size(339, 26)
        Me.txtDescription2.TabIndex = 20
        '
        'txtDescription1
        '
        Me.txtDescription1.Enabled = False
        Me.txtDescription1.Location = New System.Drawing.Point(457, 23)
        Me.txtDescription1.Name = "txtDescription1"
        Me.txtDescription1.Size = New System.Drawing.Size(339, 26)
        Me.txtDescription1.TabIndex = 19
        '
        'txtTank
        '
        Me.txtTank.Enabled = False
        Me.txtTank.Location = New System.Drawing.Point(108, 65)
        Me.txtTank.Name = "txtTank"
        Me.txtTank.Size = New System.Drawing.Size(88, 26)
        Me.txtTank.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(213, 68)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 20)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "EVOQUA"
        Me.Label20.Visible = False
        '
        'lblDesc3
        '
        Me.lblDesc3.AutoSize = True
        Me.lblDesc3.Location = New System.Drawing.Point(233, 90)
        Me.lblDesc3.Name = "lblDesc3"
        Me.lblDesc3.Size = New System.Drawing.Size(120, 20)
        Me.lblDesc3.TabIndex = 17
        Me.lblDesc3.Text = "Description 3:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(331, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 20)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Description 2:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(331, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 20)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Description 1:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(35, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 20)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Tank:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(35, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 20)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "ID:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtReleaseNumber)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(0, 119)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(344, 54)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'txtReleaseNumber
        '
        Me.txtReleaseNumber.Enabled = False
        Me.txtReleaseNumber.Location = New System.Drawing.Point(188, 14)
        Me.txtReleaseNumber.Name = "txtReleaseNumber"
        Me.txtReleaseNumber.Size = New System.Drawing.Size(143, 26)
        Me.txtReleaseNumber.TabIndex = 17
        Me.txtReleaseNumber.Tag = "Release Number"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(35, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(147, 20)
        Me.Label28.TabIndex = 15
        Me.Label28.Text = "Release Number:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(904, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 24)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Date:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(904, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 24)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "Time In:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(904, 90)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 24)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "Time Out:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(643, 554)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 20)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "Gross Weight:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(643, 578)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(111, 20)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "Tare Weight:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(643, 603)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 20)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Net Weight:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(643, 629)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(86, 20)
        Me.Label27.TabIndex = 25
        Me.Label27.Text = "Net Tons:"
        '
        'Demo
        '
        Me.Demo.Controls.Add(Me.chkH2ODR)
        Me.Demo.Controls.Add(Me.chkUCDR)
        Me.Demo.Controls.Add(Me.chkLoadingArm)
        Me.Demo.Controls.Add(Me.chkSADR)
        Me.Demo.Controls.Add(Me.chkPlatform)
        Me.Demo.Controls.Add(Me.txtWeight)
        Me.Demo.Controls.Add(Me.txtTare)
        Me.Demo.Controls.Add(Me.txtGross)
        Me.Demo.Location = New System.Drawing.Point(12, 2)
        Me.Demo.Name = "Demo"
        Me.Demo.Size = New System.Drawing.Size(232, 123)
        Me.Demo.TabIndex = 26
        Me.Demo.TabStop = False
        Me.Demo.Text = "Demo Mode"
        Me.Demo.Visible = False
        '
        'chkH2ODR
        '
        Me.chkH2ODR.AutoSize = True
        Me.chkH2ODR.Location = New System.Drawing.Point(118, 78)
        Me.chkH2ODR.Name = "chkH2ODR"
        Me.chkH2ODR.Size = New System.Drawing.Size(113, 17)
        Me.chkH2ODR.TabIndex = 44
        Me.chkH2ODR.Text = "H2O Driver Ready"
        Me.chkH2ODR.UseVisualStyleBackColor = True
        '
        'chkUCDR
        '
        Me.chkUCDR.AutoSize = True
        Me.chkUCDR.Location = New System.Drawing.Point(118, 47)
        Me.chkUCDR.Name = "chkUCDR"
        Me.chkUCDR.Size = New System.Drawing.Size(106, 17)
        Me.chkUCDR.TabIndex = 43
        Me.chkUCDR.Text = "UC Driver Ready"
        Me.chkUCDR.UseVisualStyleBackColor = True
        '
        'chkLoadingArm
        '
        Me.chkLoadingArm.AutoSize = True
        Me.chkLoadingArm.Location = New System.Drawing.Point(6, 78)
        Me.chkLoadingArm.Name = "chkLoadingArm"
        Me.chkLoadingArm.Size = New System.Drawing.Size(85, 17)
        Me.chkLoadingArm.TabIndex = 42
        Me.chkLoadingArm.Text = "Loading Arm"
        Me.chkLoadingArm.UseVisualStyleBackColor = True
        '
        'chkSADR
        '
        Me.chkSADR.AutoSize = True
        Me.chkSADR.Location = New System.Drawing.Point(118, 19)
        Me.chkSADR.Name = "chkSADR"
        Me.chkSADR.Size = New System.Drawing.Size(105, 17)
        Me.chkSADR.TabIndex = 41
        Me.chkSADR.Text = "SA Driver Ready"
        Me.chkSADR.UseVisualStyleBackColor = True
        '
        'chkPlatform
        '
        Me.chkPlatform.AutoSize = True
        Me.chkPlatform.Location = New System.Drawing.Point(6, 54)
        Me.chkPlatform.Name = "chkPlatform"
        Me.chkPlatform.Size = New System.Drawing.Size(69, 17)
        Me.chkPlatform.TabIndex = 40
        Me.chkPlatform.Text = "Platforms"
        Me.chkPlatform.UseVisualStyleBackColor = True
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(143, 93)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(88, 20)
        Me.txtWeight.TabIndex = 39
        '
        'txtTare
        '
        Me.txtTare.Location = New System.Drawing.Point(55, 93)
        Me.txtTare.Name = "txtTare"
        Me.txtTare.Size = New System.Drawing.Size(88, 20)
        Me.txtTare.TabIndex = 38
        '
        'txtGross
        '
        Me.txtGross.Location = New System.Drawing.Point(6, 23)
        Me.txtGross.Name = "txtGross"
        Me.txtGross.Size = New System.Drawing.Size(88, 20)
        Me.txtGross.TabIndex = 37
        Me.txtGross.Text = "0"
        '
        'cmdEdit
        '
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(935, 134)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(175, 57)
        Me.cmdEdit.TabIndex = 27
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(935, 221)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(175, 56)
        Me.cmdCancel.TabIndex = 28
        Me.cmdCancel.Text = "Cancel Fill"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdContinue
        '
        Me.cmdContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdContinue.Location = New System.Drawing.Point(935, 309)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.Size = New System.Drawing.Size(175, 56)
        Me.cmdContinue.TabIndex = 29
        Me.cmdContinue.Text = "Continue Filling"
        Me.cmdContinue.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(935, 401)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(175, 60)
        Me.cmdPrint.TabIndex = 30
        Me.cmdPrint.Text = "Complete / Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'txtDate
        '
        Me.txtDate.Enabled = False
        Me.txtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(991, 27)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(109, 26)
        Me.txtDate.TabIndex = 22
        '
        'txtInTime
        '
        Me.txtInTime.Enabled = False
        Me.txtInTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInTime.Location = New System.Drawing.Point(1012, 59)
        Me.txtInTime.Name = "txtInTime"
        Me.txtInTime.Size = New System.Drawing.Size(88, 26)
        Me.txtInTime.TabIndex = 31
        '
        'txtOutTime
        '
        Me.txtOutTime.Enabled = False
        Me.txtOutTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutTime.Location = New System.Drawing.Point(1012, 90)
        Me.txtOutTime.Name = "txtOutTime"
        Me.txtOutTime.Size = New System.Drawing.Size(88, 26)
        Me.txtOutTime.TabIndex = 32
        '
        'GrossBox
        '
        Me.GrossBox.Enabled = False
        Me.GrossBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrossBox.Location = New System.Drawing.Point(772, 554)
        Me.GrossBox.Name = "GrossBox"
        Me.GrossBox.Size = New System.Drawing.Size(88, 26)
        Me.GrossBox.TabIndex = 33
        '
        'TareBox
        '
        Me.TareBox.Enabled = False
        Me.TareBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TareBox.Location = New System.Drawing.Point(772, 578)
        Me.TareBox.Name = "TareBox"
        Me.TareBox.Size = New System.Drawing.Size(88, 26)
        Me.TareBox.TabIndex = 34
        '
        'NetBox
        '
        Me.NetBox.Enabled = False
        Me.NetBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetBox.Location = New System.Drawing.Point(772, 603)
        Me.NetBox.Name = "NetBox"
        Me.NetBox.Size = New System.Drawing.Size(88, 26)
        Me.NetBox.TabIndex = 35
        '
        'TonBox
        '
        Me.TonBox.Enabled = False
        Me.TonBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TonBox.Location = New System.Drawing.Point(772, 629)
        Me.TonBox.Name = "TonBox"
        Me.TonBox.Size = New System.Drawing.Size(88, 26)
        Me.TonBox.TabIndex = 36
        '
        'FrameFilling
        '
        Me.FrameFilling.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FrameFilling.Controls.Add(Me.lblFilling)
        Me.FrameFilling.Location = New System.Drawing.Point(1133, 509)
        Me.FrameFilling.Name = "FrameFilling"
        Me.FrameFilling.Size = New System.Drawing.Size(563, 71)
        Me.FrameFilling.TabIndex = 38
        Me.FrameFilling.TabStop = False
        Me.FrameFilling.Visible = False
        '
        'FrameWaiting
        '
        Me.FrameWaiting.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FrameWaiting.Controls.Add(Me.Label29)
        Me.FrameWaiting.Location = New System.Drawing.Point(1133, 333)
        Me.FrameWaiting.Name = "FrameWaiting"
        Me.FrameWaiting.Size = New System.Drawing.Size(563, 71)
        Me.FrameWaiting.TabIndex = 39
        Me.FrameWaiting.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(106, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(371, 37)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "PLEASE EXIT SCALE !"
        '
        'FramePullOnScale
        '
        Me.FramePullOnScale.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FramePullOnScale.Controls.Add(Me.Label10)
        Me.FramePullOnScale.Location = New System.Drawing.Point(1133, 422)
        Me.FramePullOnScale.Name = "FramePullOnScale"
        Me.FramePullOnScale.Size = New System.Drawing.Size(597, 71)
        Me.FramePullOnScale.TabIndex = 43
        Me.FramePullOnScale.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(29, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(502, 37)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "      PLEASE PULL ON SCALE !"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RedLight
        '
        Me.RedLight.Image = CType(resources.GetObject("RedLight.Image"), System.Drawing.Image)
        Me.RedLight.Location = New System.Drawing.Point(52, 609)
        Me.RedLight.Name = "RedLight"
        Me.RedLight.Size = New System.Drawing.Size(54, 52)
        Me.RedLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RedLight.TabIndex = 39
        Me.RedLight.TabStop = False
        '
        'GreenLight
        '
        Me.GreenLight.Image = CType(resources.GetObject("GreenLight.Image"), System.Drawing.Image)
        Me.GreenLight.Location = New System.Drawing.Point(52, 609)
        Me.GreenLight.Name = "GreenLight"
        Me.GreenLight.Size = New System.Drawing.Size(54, 52)
        Me.GreenLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GreenLight.TabIndex = 40
        Me.GreenLight.TabStop = False
        '
        'Status
        '
        Me.Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.Location = New System.Drawing.Point(192, 682)
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Size = New System.Drawing.Size(668, 26)
        Me.Status.TabIndex = 41
        Me.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrameTareWeight
        '
        Me.FrameTareWeight.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FrameTareWeight.Controls.Add(Me.lblDriverReady)
        Me.FrameTareWeight.Location = New System.Drawing.Point(1133, 243)
        Me.FrameTareWeight.Name = "FrameTareWeight"
        Me.FrameTareWeight.Size = New System.Drawing.Size(623, 71)
        Me.FrameTareWeight.TabIndex = 42
        Me.FrameTareWeight.TabStop = False
        Me.FrameTareWeight.Visible = False
        '
        'lblDriverReady
        '
        Me.lblDriverReady.AutoSize = True
        Me.lblDriverReady.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDriverReady.ForeColor = System.Drawing.Color.Red
        Me.lblDriverReady.Location = New System.Drawing.Point(16, 16)
        Me.lblDriverReady.Name = "lblDriverReady"
        Me.lblDriverReady.Size = New System.Drawing.Size(521, 37)
        Me.lblDriverReady.TabIndex = 0
        Me.lblDriverReady.Text = "WAITING FOR DRIVER READY !"
        '
        'FramePlatform
        '
        Me.FramePlatform.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FramePlatform.Controls.Add(Me.Label11)
        Me.FramePlatform.Location = New System.Drawing.Point(1133, 156)
        Me.FramePlatform.Name = "FramePlatform"
        Me.FramePlatform.Size = New System.Drawing.Size(563, 71)
        Me.FramePlatform.TabIndex = 44
        Me.FramePlatform.TabStop = False
        Me.FramePlatform.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(132, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(340, 37)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "CLEAR PLATFORM !"
        '
        'LoadTimer
        '
        Me.LoadTimer.Interval = 500
        '
        'FramePaused
        '
        Me.FramePaused.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FramePaused.Controls.Add(Me.Label30)
        Me.FramePaused.Location = New System.Drawing.Point(1133, 590)
        Me.FramePaused.Name = "FramePaused"
        Me.FramePaused.Size = New System.Drawing.Size(563, 71)
        Me.FramePaused.TabIndex = 48
        Me.FramePaused.TabStop = False
        Me.FramePaused.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(190, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(232, 37)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Filling Paused"
        '
        'PlatformTimer
        '
        Me.PlatformTimer.Interval = 1000
        '
        'Scale1Box
        '
        Me.Scale1Box.Enabled = False
        Me.Scale1Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Scale1Box.Location = New System.Drawing.Point(138, 636)
        Me.Scale1Box.Name = "Scale1Box"
        Me.Scale1Box.Size = New System.Drawing.Size(88, 26)
        Me.Scale1Box.TabIndex = 49
        '
        'Scale1Check
        '
        '
        'WatchDogTimer
        '
        Me.WatchDogTimer.Interval = 5000
        '
        'txtWD
        '
        Me.txtWD.Location = New System.Drawing.Point(91, 674)
        Me.txtWD.Name = "txtWD"
        Me.txtWD.Size = New System.Drawing.Size(39, 20)
        Me.txtWD.TabIndex = 50
        Me.txtWD.Visible = False
        '
        'cmdWD
        '
        Me.cmdWD.Location = New System.Drawing.Point(38, 675)
        Me.cmdWD.Name = "cmdWD"
        Me.cmdWD.Size = New System.Drawing.Size(47, 19)
        Me.cmdWD.TabIndex = 51
        Me.cmdWD.Text = "WDog"
        Me.cmdWD.UseVisualStyleBackColor = True
        Me.cmdWD.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(134, 610)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(96, 20)
        Me.Label31.TabIndex = 52
        Me.Label31.Text = "Scale Wgt."
        '
        'ScaleCom
        '
        Me.ScaleCom.ReceivedBytesThreshold = 50
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(49, 41)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 20)
        Me.Label32.TabIndex = 53
        Me.Label32.Text = "Driver Ready"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(49, 79)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(115, 20)
        Me.Label33.TabIndex = 54
        Me.Label33.Text = "N  Platform S"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(49, 115)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(110, 20)
        Me.Label34.TabIndex = 55
        Me.Label34.Text = "Loading Arm"
        '
        'InputTimer
        '
        Me.InputTimer.Interval = 1000
        '
        'lblSA
        '
        Me.lblSA.AutoSize = True
        Me.lblSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSA.Location = New System.Drawing.Point(12, 18)
        Me.lblSA.Name = "lblSA"
        Me.lblSA.Size = New System.Drawing.Size(33, 20)
        Me.lblSA.TabIndex = 56
        Me.lblSA.Text = "SA"
        '
        'lblUC
        '
        Me.lblUC.AutoSize = True
        Me.lblUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUC.Location = New System.Drawing.Point(161, 18)
        Me.lblUC.Name = "lblUC"
        Me.lblUC.Size = New System.Drawing.Size(34, 20)
        Me.lblUC.TabIndex = 57
        Me.lblUC.Text = "UC"
        '
        'lblNetCapacity
        '
        Me.lblNetCapacity.AutoSize = True
        Me.lblNetCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetCapacity.Location = New System.Drawing.Point(452, 596)
        Me.lblNetCapacity.Name = "lblNetCapacity"
        Me.lblNetCapacity.Size = New System.Drawing.Size(116, 20)
        Me.lblNetCapacity.TabIndex = 58
        Me.lblNetCapacity.Text = "Net Capacity:"
        '
        'txtNetCapacity
        '
        Me.txtNetCapacity.AutoSize = True
        Me.txtNetCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetCapacity.Location = New System.Drawing.Point(470, 616)
        Me.txtNetCapacity.Name = "txtNetCapacity"
        Me.txtNetCapacity.Size = New System.Drawing.Size(59, 20)
        Me.txtNetCapacity.TabIndex = 59
        Me.txtNetCapacity.Text = "20000"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'MaxWeightBox
        '
        Me.MaxWeightBox.Enabled = False
        Me.MaxWeightBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxWeightBox.Location = New System.Drawing.Point(1027, 675)
        Me.MaxWeightBox.Name = "MaxWeightBox"
        Me.MaxWeightBox.Size = New System.Drawing.Size(88, 26)
        Me.MaxWeightBox.TabIndex = 60
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(944, 678)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(83, 20)
        Me.Label38.TabIndex = 61
        Me.Label38.Text = "Max Wgt:"
        '
        'LoadStatusTimer
        '
        Me.LoadStatusTimer.Interval = 10000
        '
        'TankRequestTimer
        '
        Me.TankRequestTimer.Interval = 30000
        '
        'lblWater
        '
        Me.lblWater.AutoSize = True
        Me.lblWater.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWater.Location = New System.Drawing.Point(85, 18)
        Me.lblWater.Name = "lblWater"
        Me.lblWater.Size = New System.Drawing.Size(45, 20)
        Me.lblWater.TabIndex = 62
        Me.lblWater.Text = "H2O"
        '
        'grpLoadStatus
        '
        Me.grpLoadStatus.Controls.Add(Me.Label19)
        Me.grpLoadStatus.Controls.Add(Me.lblWater)
        Me.grpLoadStatus.Controls.Add(Me.lblUC)
        Me.grpLoadStatus.Controls.Add(Me.lblSA)
        Me.grpLoadStatus.Controls.Add(Me.Label34)
        Me.grpLoadStatus.Controls.Add(Me.Label33)
        Me.grpLoadStatus.Controls.Add(Me.Label32)
        Me.grpLoadStatus.Location = New System.Drawing.Point(900, 476)
        Me.grpLoadStatus.Name = "grpLoadStatus"
        Me.grpLoadStatus.Size = New System.Drawing.Size(210, 179)
        Me.grpLoadStatus.TabIndex = 63
        Me.grpLoadStatus.TabStop = False
        Me.grpLoadStatus.Text = "Control Status"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(51, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(153, 20)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "H2O Driver Ready"
        '
        'TruckImage
        '
        Me.TruckImage.Image = CType(resources.GetObject("TruckImage.Image"), System.Drawing.Image)
        Me.TruckImage.Location = New System.Drawing.Point(275, 578)
        Me.TruckImage.Name = "TruckImage"
        Me.TruckImage.Size = New System.Drawing.Size(363, 104)
        Me.TruckImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TruckImage.TabIndex = 64
        Me.TruckImage.TabStop = False
        Me.TruckImage.Visible = False
        '
        'MyVerticalProgessBar1
        '
        Me.MyVerticalProgessBar1.Location = New System.Drawing.Point(378, 578)
        Me.MyVerticalProgessBar1.Name = "MyVerticalProgessBar1"
        Me.MyVerticalProgessBar1.Size = New System.Drawing.Size(247, 68)
        Me.MyVerticalProgessBar1.TabIndex = 47
        '
        'frmTransactionProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1166, 711)
        Me.Controls.Add(Me.grpLoadStatus)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.MaxWeightBox)
        Me.Controls.Add(Me.txtNetCapacity)
        Me.Controls.Add(Me.lblNetCapacity)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.cmdWD)
        Me.Controls.Add(Me.txtWD)
        Me.Controls.Add(Me.FrameTareWeight)
        Me.Controls.Add(Me.FramePullOnScale)
        Me.Controls.Add(Me.Scale1Box)
        Me.Controls.Add(Me.FramePaused)
        Me.Controls.Add(Me.MyVerticalProgessBar1)
        Me.Controls.Add(Me.FrameWaiting)
        Me.Controls.Add(Me.FrameFilling)
        Me.Controls.Add(Me.FramePlatform)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.RedLight)
        Me.Controls.Add(Me.TonBox)
        Me.Controls.Add(Me.NetBox)
        Me.Controls.Add(Me.TareBox)
        Me.Controls.Add(Me.GrossBox)
        Me.Controls.Add(Me.txtOutTime)
        Me.Controls.Add(Me.txtInTime)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.Demo)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GreenLight)
        Me.Controls.Add(Me.TruckImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTransactionProcessing"
        Me.Text = "frmTransactionProcessing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Demo.ResumeLayout(False)
        Me.Demo.PerformLayout()
        Me.FrameFilling.ResumeLayout(False)
        Me.FrameFilling.PerformLayout()
        Me.FrameWaiting.ResumeLayout(False)
        Me.FrameWaiting.PerformLayout()
        Me.FramePullOnScale.ResumeLayout(False)
        Me.FramePullOnScale.PerformLayout()
        CType(Me.RedLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GreenLight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FrameTareWeight.ResumeLayout(False)
        Me.FrameTareWeight.PerformLayout()
        Me.FramePlatform.ResumeLayout(False)
        Me.FramePlatform.PerformLayout()
        Me.FramePaused.ResumeLayout(False)
        Me.FramePaused.PerformLayout()
        Me.grpLoadStatus.ResumeLayout(False)
        Me.grpLoadStatus.PerformLayout()
        CType(Me.TruckImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFilling As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCarrier As System.Windows.Forms.TextBox
    Friend WithEvents txtDriverName As System.Windows.Forms.TextBox
    Friend WithEvents txtDriverId As System.Windows.Forms.TextBox
    Friend WithEvents txtCardId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents txtConsignee As System.Windows.Forms.TextBox
    Friend WithEvents lblSeal2 As System.Windows.Forms.Label
    Friend WithEvents lblSeal1 As System.Windows.Forms.Label
    Friend WithEvents lblNSF As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTrailer As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicle As System.Windows.Forms.TextBox
    Friend WithEvents txtTargetWt As System.Windows.Forms.TextBox
    Friend WithEvents txtDisplayTarget As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCommodity As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTank As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblDesc3 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReleaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Demo As System.Windows.Forms.GroupBox
    Friend WithEvents chkLoadingArm As System.Windows.Forms.CheckBox
    Friend WithEvents chkSADR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPlatform As System.Windows.Forms.CheckBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtTare As System.Windows.Forms.TextBox
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdContinue As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtInTime As System.Windows.Forms.TextBox
    Friend WithEvents txtOutTime As System.Windows.Forms.TextBox
    Friend WithEvents GrossBox As System.Windows.Forms.TextBox
    Friend WithEvents TareBox As System.Windows.Forms.TextBox
    Friend WithEvents NetBox As System.Windows.Forms.TextBox
    Friend WithEvents TonBox As System.Windows.Forms.TextBox
    Friend WithEvents FrameFilling As System.Windows.Forms.GroupBox
    Friend WithEvents RedLight As System.Windows.Forms.PictureBox
    Friend WithEvents GreenLight As System.Windows.Forms.PictureBox
    Friend WithEvents Status As System.Windows.Forms.TextBox
    Friend WithEvents FrameWaiting As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents FramePullOnScale As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FrameTareWeight As System.Windows.Forms.GroupBox
    Friend WithEvents lblDriverReady As System.Windows.Forms.Label
    Friend WithEvents FramePlatform As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LoadTimer As System.Windows.Forms.Timer
    Friend WithEvents MyVerticalProgessBar1 As SATCO.MyVerticalProgessBar
    Friend WithEvents FramePaused As System.Windows.Forms.GroupBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents PlatformTimer As System.Windows.Forms.Timer
    Friend WithEvents Scale1Box As System.Windows.Forms.TextBox
    Friend WithEvents Scale1Check As System.Windows.Forms.Timer
    Friend WithEvents WatchDogTimer As System.Windows.Forms.Timer
    Friend WithEvents txtWD As System.Windows.Forms.TextBox
    Friend WithEvents cmdWD As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ScaleCom As System.IO.Ports.SerialPort
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents InputTimer As System.Windows.Forms.Timer
    Friend WithEvents lblSA As System.Windows.Forms.Label
    Friend WithEvents lblUC As System.Windows.Forms.Label
    Friend WithEvents lblSeal4 As System.Windows.Forms.Label
    Friend WithEvents lblSeal3 As System.Windows.Forms.Label
    Friend WithEvents txtSeal4 As System.Windows.Forms.TextBox
    Friend WithEvents txtSeal3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSeal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSeal1 As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblNetCapacity As System.Windows.Forms.Label
    Friend WithEvents txtNetCapacity As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents MaxWeightBox As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents LoadStatusTimer As Timer
    Friend WithEvents txtPO As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents TankRequestTimer As Timer
    Friend WithEvents txtDescription4 As TextBox
    Friend WithEvents lblDesc4 As Label
    Friend WithEvents chkH2ODR As CheckBox
    Friend WithEvents chkUCDR As CheckBox
    Friend WithEvents lblH2O As Label
    Friend WithEvents txtH2OTarget As TextBox
    Friend WithEvents lblWater As Label
    Friend WithEvents grpLoadStatus As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TruckImage As PictureBox
End Class
