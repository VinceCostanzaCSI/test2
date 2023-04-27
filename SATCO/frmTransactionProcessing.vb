Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class frmTransactionProcessing
    Private SQL As New SQLControl

    Dim MaterialType As Integer
    Dim TankMaterial As Integer
    Dim ActiveScale As Integer
    Dim GrossWt As Integer
    Dim TareWt As Integer
    Dim cmdCancelFlag As Integer
    Dim cmdContinueFlag As Integer
    Dim cmdPrintFlag As Integer
    Dim TareSet As Integer
    Dim CurrentTarget As Integer
    Dim Keyboard As clsKeyboard
    Dim DriverReady As Boolean
    Dim PauseMode As Boolean
    Dim TransactionComplete As Boolean
    Dim PrintButtonPressed As Boolean
    Dim ScalePort As String
    Dim ScaleWeight1 As Integer
    Dim AutoPause As Boolean = False
    Dim LoadID As Integer
    Dim DemoDR As Boolean
    Dim H2OWeight As Integer
    Dim WaterFill As Boolean
    Dim H2OFlow As Integer
    Dim PlatformUpCounter As Integer = 0
    Dim availableSerialPorts As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.Ports.SerialPortNames

    Delegate Sub SetTextCallBack(ByVal [text] As String)

    Private Sub frmTransactionProcessing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'AddLogEntry ("frmTransactionProcessing_Load")
        CenterForm(Me)
        LoadTimer.Enabled = True
        MyVerticalProgessBar1.Maximum = 100
        chkSADR.Checked = False
        chkUCDR.Checked = False
        chkH2ODR.Checked = False
        DemoDR = False
        chkLoadingArm.Checked = False
        chkPlatform.Checked = False
        txtH2OTarget.Visible = False
        lblH2O.Visible = False

    End Sub

    Private Sub LoadTimer_Tick(sender As System.Object, e As System.EventArgs) Handles LoadTimer.Tick
        LoadTimer.Enabled = False
        Control.CameraOn()
        GetStarted()
    End Sub

    Private Sub GetStarted()
        Dim Process As clsProcess
        Dim Tank As clsTank
        Dim SysOptions As clsSystem
        ' Dim Carrier As clscarrier
        Dim MaxWeight As Double
        Dim Carrier As clsCarrier

        TareSet = False
        PauseMode = False
        TransactionComplete = False
        PrintButtonPressed = False
        cmdEdit.Enabled = False
        cmdCancel.Enabled = True
        cmdContinue.Enabled = False
        cmdPrint.Text = "Complete / Print"
        cmdPrint.Enabled = False
        cmdCancelFlag = False
        WaterFill = False

        Try
            '---For Demo mode ----
            'undo commented line below and change clscontrol.displayedweight
            'Demo.Visible = True

            SysOptions = New clsSystem
            'Read from database for DriverInfo, MosaicCOA and BrenntagCOA
            SysOptions.GetCurrentRecord()

            If RailMode Then
                If SADriver Then
                    ActiveScale = 0
                Else
                    ActiveScale = 1
                End If
            Else
                If SysOptions.ScaleNumber <> 1 And SysOptions.ScaleNumber <> 2 Then
                    AddLogEntry("Scale has not been set")
                    MsgBox("The Scale ID has not been set !", vbOKOnly, "Scale Error")
                    'AddLogEntry ("Unload frmTransactionProcessing")
                    Control.CameraOff()
                    Me.Close()
                    'AddLogEntry ("frmTransactionProcessing - Loading frmCardId")
                    frmCardID.MdiParent = frmMain
                    frmCardID.Show()
                Else
                    ActiveScale = SysOptions.ScaleNumber - 1
                    AddLogEntry("Active Scale = " & Str(SysOptions.ScaleNumber))
                    ScalePort = SysOptions.ScalePort
                End If
                If SysOptions.ScaleNumber = 2 Then
                    lblSA.Text = "BT"
                    lblUC.Text = "MO"
                Else
                    lblSA.Text = "SA"
                    lblUC.Text = "UC"
                End If

                AddLogEntry("Set Traffic Light RED")
                RedLight.Visible = True
                GreenLight.Visible = False
                Control.SetTrafficLightRed()

                H2OFlow = Val(SysOptions.H2OFlow)

            End If

            SetupCom()

            Process = New clsProcess
            Tank = New clsTank

            TruckImage.Visible = False

            'AddLogEntry ("frmTransactionProcessing - Retrieve variables")
            txtDate.Text = Process.ProcessDate ' & " " & Format(Now, "hh:mm tt")
            txtInTime.Text = Format(Now, "HH:mm") 'Process.ProcessTime
            txtCardId.Text = Process.CardId
            txtDriverId.Text = Process.DriverId
            txtDriverName.Text = Process.DriverName
            txtCarrier.Text = Process.Carrier
            txtPO.Text = Process.PO
            'Stop
            Carrier = New clsCarrier
            If Carrier.FindRecord(txtCarrier.Text) = True Then
                AddLogEntry("Carrier MaxLoad set to: " & Carrier.MaxLoad)
                CarrierMaxWeight = Carrier.MaxLoad
                MaxWeightBox.Text = CarrierMaxWeight
            Else
                AddLogEntry("Carrier not found to get maxload. Setting Default = " & SysOptions.MaxFillWeight)
                MaxWeightBox.Text = SysOptions.MaxFillWeight
                ' MaxWeightBox.BackColor = Color.Red
                'MaxWeightBox.ForeColor = Color.White
            End If
            Carrier = Nothing
            cboCode.Text = Process.Code
            txtConsignee.Text = Process.Consignee
            txtDestination.Text = Process.Destination
            If MosaicDriver = True Then
                lblNetCapacity.Visible = False
                txtNetCapacity.Visible = False
            Else
                lblNetCapacity.Visible = True
                txtNetCapacity.Visible = True
            End If
            txtNetCapacity.Text = Process.NetCapacity
            txtTargetWt.Text = Process.TargetWt
            txtDisplayTarget.Text = Process.DisplayTarget
            CurrentTarget = Val(txtTargetWt.Text)
            txtVehicle.Text = Process.Vehicle
            txtTrailer.Text = Process.Trailer
            cboCommodity.Text = Process.Commodity
            txtDescription1.Text = Process.Description1
            txtDescription2.Text = Process.Description2
            txtDescription3.Text = Process.Description3
            txtDescription4.Text = Process.Description4
            txtReleaseNumber.Text = Process.ReleaseNumber
            txtSeal1.Text = Process.Seal1
            txtSeal2.Text = Process.Seal2
            txtSeal3.Text = Process.Seal3
            txtSeal4.Text = Process.Seal4
            lblNSF.Visible = False

            If NSFLoad = True Then
                lblNSF.Visible = True

            End If
            If BrenntagDriver = True Then
                lblNSF.Visible = True
                lblNSF.Text = "NSF"

                If Brenntag25 = True Then
                    txtH2OTarget.Visible = True
                    lblH2O.Visible = True
                    lblWater.Visible = True
                End If
                If BrenntagSplit = True Then
                    Status.Text = "SPLIT LOAD"
                End If
            End If

            'Set Process = Nothing

            If UCase(Mid(cboCode.Text, 1, 2)) = "SA" Then
                MaterialType = 1
                TankMaterial = 0
                LoadID = 1
                lblDesc3.Text = "Gravity: "
                lblDesc4.Text = "Iron: "
            End If
            If UCase(Mid(cboCode.Text, 1, 2)) = "UC" Then
                MaterialType = 2
                TankMaterial = 1
                LoadID = 2
            End If
            If UCase(Mid(cboCode.Text, 1, 2)) = "MO" Then
                MaterialType = 2
                TankMaterial = 2
                LoadID = 3
            End If
            If UCase(Mid(cboCode.Text, 1, 2)) = "BN" Then
                MaterialType = 1
                TankMaterial = 3
                LoadID = 4
            End If
            Tank.GetFillTank(ActiveScale, TankMaterial)

            Tank.FindRecord(Tank.Id)
            txtTank.Text = Tank.Id
            Tank = Nothing

            If RailMode Then
                grpLoadStatus.Visible = False
                TruckImage.Visible = False
                MyVerticalProgessBar1.Visible = False
                GrossBox.Visible = False
                TareBox.Visible = False
                NetBox.Visible = False
                TonBox.Visible = False
                Label24.Visible = False
                Label25.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                lblNetCapacity.Visible = False
                txtNetCapacity.Visible = False
                If SADriver Then
                    Label10.Text = "Waiting for Acid FlowMeter Data"
                Else
                    Label10.Text = "Waiting for Caustic FlowMeter Data"
                End If
                FrameWaiting.Visible = False
                FramePullOnScale.Visible = True
                FramePullOnScale.Left = 214
                FramePullOnScale.Top = 14
                Me.Refresh()

                'Turn on the FlowMeter Reading
                AddLogEntry("Check for FlowMeter data")
                Scale1Check.Enabled = True
                Delay(500)
                Do While ScaleWeight1 < SysOptions.MinFillWeight And cmdCancelFlag = False
                    Application.DoEvents()   'Wait for valid Flowmeter reading
                Loop
                If cmdCancelFlag = False Then


                    cmdCancel.Enabled = False
                    cmdContinue.Enabled = False
                    cmdEdit.Enabled = False
                    cmdPrint.Enabled = True
                    FramePlatform.Visible = False

                    Label10.Text = "Ready to Print BOL"
                    'LoadStatus(LoadID, True, "Waiting to Print Ticket", txtTank.Text, GrossBox.Text)
                    Do While TransactionComplete = False
                        Application.DoEvents()    'Wait until the driver prints the ticket
                    Loop
                    AddLogEntry("TransactionComplete equal to true")
                    'cmdPrint.Enabled = False

                    Delay(2000)
                    AddLogEntry("Have Truck Exit Scale")
                    'LoadStatus(LoadID, False, "Waiting for Truck to Exit Scale", txtTank.Text, GrossBox.Text)

                    TransactionComplete = False

                    'Stop Monitor Inputs
                    InputTimer.Enabled = False

                End If

                ' ----- END THE FILL CYCLE -----

                Process = Nothing
                LoadStatus(LoadID, False, "Filling Cycle Complete", txtTank.Text, GrossBox.Text)
                AddLogEntry("Unloading frmTransactionProcessing")
                Control.CameraOff()
                If ScaleCom.IsOpen Then
                    AddLogEntry("Closing Scale Serial port ")
                    ScaleCom.Close()
                End If

                Me.Close()
                AddLogEntry("frmTransactionProcessing - Loading frmCardId")
                frmCardID.MdiParent = frmMain
                frmCardID.Show()
                Exit Sub
            End If


            LoadStatus(LoadID, False, "Starting Fill Cycle", txtTank.Text, GrossBox.Text)

            ' ----- START THE FILL CYCLE -----
            If cmdCancelFlag = False Then
                AddLogEntry("Start the FILL CYCLE")
                TransactionComplete = False

                'Turn on the Scale1 Reading
                AddLogEntry("Check for Zero weight before proceeding")
                Scale1Check.Enabled = True
                Delay(500)
                ' ----- Make sure the weight isnt > 350 lbs -----
                Dim ZeroWeight As Integer = Control.DisplayedWeight

                'Put this in a loop until scale is < 100
                '-------------------------------
                Do While Val(Control.DisplayedWeight) > 350
                    If MsgBox("Please Clear the Scale first or Call SATCO Representative", vbOKCancel, "Zero Scale Error") = vbCancel Then
                        TransactionComplete = False
                        ' ----- END THE FILL CYCLE -----

                        Process = Nothing

                        AddLogEntry("Unloading frmTransactionProcessing")
                        Control.CameraOff()
                        If ScaleCom.IsOpen Then
                            AddLogEntry("Closing Scale Serial port ")
                            ScaleCom.Close()
                        End If
                        Me.Close()
                        AddLogEntry("frmTransactionProcessing - Loading frmCardId")
                        frmCardID.MdiParent = frmMain
                        frmCardID.Show()
                    End If
                Loop
                '--------------------------------

                Do While Val(Control.DisplayedWeight) > 100
                    If MsgBox("Are you sure you want to zero the scale ?", vbOKCancel, "Zero Scale Error") = vbCancel Then
                        cmdCancel.PerformClick()
                        Exit Do
                    Else
                        Control.ZeroScale()
                    End If
                Loop
                'AddLogEntry("Control Control.ZeroScale")
                'Control.ZeroScale()
                GrossWt = Val(Control.DisplayedWeight)
                GrossBox.Text = GrossWt
                AddLogEntry("Scale Weight: " & GrossWt)
                If cmdCancelFlag = False Then

                    'Monitor Inputs
                    InputTimer.Enabled = True

                    'AddLogEntry("Have Truck Pull On Scale")
                    HaveTruckPullOnScale()
                    If cmdCancelFlag = False Then
                        AddLogEntry("Get Truck Tare Weight")
                        GetTruckTareWeight()

                        If BrenntagDriver = True Then
                            txtTargetWt.Text = txtTargetWt.Text + TareWt  'We started out with a net weight value
                            If txtTargetWt.Text > MaxWeightBox.Text Then
                                txtTargetWt.Text = MaxWeightBox.Text
                            End If
                        End If

                        'Calculate new Cutoff weight if Brenntag or SA Driver
                        If BrenntagDriver = True Or SADriver = True Then
                            Dim NetTest As Integer = Val(txtTargetWt.Text) - TareWt
                            If NetTest > Val(Process.NetCapacity) Then
                                txtTargetWt.Text = (Val(Process.NetCapacity) + TareWt)
                                AddLogEntry("Capacity less than Requested target")
                                AddLogEntry("New Target Adjusted to " & txtTargetWt.Text)
                            End If

                            txtTargetWt.Text = txtTargetWt.Text - Val(Process.FreeFlow)
                            AddLogEntry("FreeFLow: " & Process.FreeFlow)
                            AddLogEntry("Target Adjusted for FreeFLow: " & txtTargetWt.Text)

                            MaxWeight = Val(MaxWeightBox.Text) - Process.FreeFlow
                            AddLogEntry("Calculating MaxWeight (Max - FreeFlow) = " & MaxWeight)

                            If Val(txtTargetWt.Text) > MaxWeight Then
                                txtTargetWt.Text = MaxWeight
                                AddLogEntry("New Target Adjusted to " & txtTargetWt.Text)
                            End If
                            txtDisplayTarget.Text = txtTargetWt.Text

                            If Brenntag25 = True Then
                                'Find two cutoff weights if 25% Caustic (H2O and Caustic)
                                'H2O cutoff = Net/2 + Tare - H2OFlow
                                txtH2OTarget.Text = Str(((Val(txtDisplayTarget.Text) - TareWt) / 2) + TareWt)
                                AddLogEntry("H2O Target set to " & txtH2OTarget.Text)
                                AddLogEntry("Using H2O Freeflow as " & H2OFlow)
                                txtH2OTarget.Text = Val(txtH2OTarget.Text) - H2OFlow
                                AddLogEntry("H2O Target adjusted for FreeFlow: " & txtH2OTarget.Text)

                            End If
                        End If

                        If MosaicDriver = True Then
                            Dim NetTest As Integer = Val(txtTargetWt.Text) - TareWt
                            If NetTest > Val(Process.MOCapacity) Then
                                'Change Target to MOCapacity
                                txtTargetWt.Text = Val(Process.MOCapacity) + TareWt
                                AddLogEntry("Capacity less than Requested target")
                                AddLogEntry("New Target Adjusted to " & txtTargetWt.Text)
                            Else
                                AddLogEntry("Target OK to leave:" & txtTargetWt.Text) '
                            End If

                            txtTargetWt.Text = txtTargetWt.Text - Val(Process.FreeFlow)
                            AddLogEntry("FreeFLow: " & Process.FreeFlow)
                            AddLogEntry("Target Adjusted for FreeFLow: " & txtTargetWt.Text)

                            MaxWeight = Val(MaxWeightBox.Text) - Val(Process.FreeFlow)
                            AddLogEntry("Calculating MaxWeight (Max - FreeFlow) = " & MaxWeight)

                            If Val(txtTargetWt.Text) > MaxWeight Then
                                txtTargetWt.Text = MaxWeight
                                AddLogEntry("New target over MaxFill")
                                AddLogEntry("New Target Adjusted to " & txtTargetWt.Text)
                            End If
                            txtDisplayTarget.Text = txtTargetWt.Text
                        End If

                        If cmdCancelFlag = False Then
                            AddLogEntry("FillTruck")
                            LoadStatus(LoadID, True, "Filling Truck", txtTank.Text, Scale1Box.Text)
                            LoadStatusTimer.Enabled = True 'update load status every 10 seconds
                            If Brenntag25 = True Then
                                FillTruckH2O()
                                AddLogEntry("Weight Has Hit Target for H2O")
                                H2OHasHitTarget()
                                AddLogEntry("Now waiting for Brenntag Driver Ready")
                                Status.Text = "Now waiting for Brenntag Driver Ready"
                                GetBrenntagDR()

                            End If
                            FillTruck()
                            LoadStatusTimer.Enabled = False
                            AddLogEntry("Weight Has Hit Target")
                            WeightHasHitTarget()
                            AddLogEntry("Wait For Platforms To Clear")
                            WaitForPlatformsToClear()
                            AddLogEntry("Waiting for TransactionComplete = True")
                            LoadStatus(LoadID, True, "Waiting to Print Ticket", txtTank.Text, GrossBox.Text)
                            Do While TransactionComplete = False
                                Application.DoEvents()    'Wait until the driver prints the ticket
                            Loop
                            AddLogEntry("TransactionComplete equal to true")
                            'cmdPrint.Enabled = False
                        End If
                    End If
                End If
            End If
            Delay(2000)
            AddLogEntry("Have Truck Exit Scale")
            LoadStatus(LoadID, False, "Waiting for Truck to Exit Scale", txtTank.Text, GrossBox.Text)
            HaveTruckExitScale()
            TransactionComplete = False

            'Stop Monitor Inputs
            InputTimer.Enabled = False

            ' ----- END THE FILL CYCLE -----

            Process = Nothing
            LoadStatus(LoadID, False, "Filling Cycle Complete", txtTank.Text, GrossBox.Text)

            AddLogEntry("Unloading frmTransactionProcessing")
            Control.CameraOff()
            If ScaleCom.IsOpen Then
                AddLogEntry("Closing Scale Serial port ")
                ScaleCom.Close()
            End If

            Me.Close()
            AddLogEntry("frmTransactionProcessing - Loading frmCardId")
            frmCardID.MdiParent = frmMain
            frmCardID.Show()
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'Stop
        AutoPause = False
        If lblWater.ForeColor = Color.Red Then
            PauseFillH2O()
        Else
            PauseFill()
        End If

    End Sub

    Private Sub PauseFill()
        If TareSet = False Then
            AddLogEntry("TareSet = False")
            cmdCancelFlag = True

        Else
            AddLogEntry("TareSet = True")
            ' ----- Disable the ready switch -----
            If MaterialType = 1 Then
                AddLogEntry("Control Control.SADisable")
                Control.SADisable()
                lblSA.ForeColor = Color.Black
            Else
                AddLogEntry("Control Control.UCDisable")
                Control.UCDisable()
                lblUC.ForeColor = Color.Black
            End If

            ' ----- Enable proper buttons -----
            cmdCancel.Enabled = False
            cmdEdit.Enabled = True
            cmdContinue.Enabled = True
            cmdPrint.Enabled = True

            FrameFilling.Visible = False
            FramePaused.Visible = True
            FramePaused.Left = 214
            FramePaused.Top = 14
        End If
        Status.Text = "Pause Filling"

    End Sub

    Private Sub PauseFillH2O()
        If TareSet = False Then
            AddLogEntry("TareSet = False")
            cmdCancelFlag = True

        Else
            AddLogEntry("TareSet = True")
            ' ----- Disable the ready switch -----

            AddLogEntry("Control Control.H2ODisable")
            Control.H2ODisable()
            lblWater.ForeColor = Color.Black

            ' ----- Enable proper buttons -----
            cmdCancel.Enabled = False
            cmdEdit.Enabled = True
            cmdContinue.Enabled = True
            cmdPrint.Enabled = True

            FrameFilling.Visible = False
            FramePaused.Visible = True
            FramePaused.Left = 214
            FramePaused.Top = 14
        End If
        Status.Text = "Pause Filling H2O"

    End Sub

    Private Sub cmdContinue_Click(sender As System.Object, e As System.EventArgs) Handles cmdContinue.Click
        AddLogEntry("frmTransactionProcessing - cmdContinue_Click")

        If WaterFill = True Then
            ContinueFillH2O()
        Else
            ContinueFill()
        End If

    End Sub

    Private Sub ContinueFill()
        Dim Commodity As clsCommodity

        AutoPause = False
        'AddLogEntry ("frmTransactionProcessing - cmdContinue_Click")
        ' ----- Enable proper buttons -----
        cmdCancel.Enabled = True
        If TareSet = True Then
            cmdEdit.Enabled = False
        End If
        cmdContinue.Enabled = False
        cmdPrint.Enabled = False

        AddLogEntry("Current Weight = " & CurrentTarget & "  Target = " & txtDisplayTarget.Text)
        If CurrentTarget <> Val(txtDisplayTarget.Text) Then
            Commodity = New clsCommodity
            Commodity.FindRecord(cboCommodity.Text)
            txtTargetWt.Text = Val(txtDisplayTarget.Text) '- Commodity.VariableWt
            AddLogEntry("New Target Set to " & txtTargetWt.Text)
            Commodity = Nothing
        End If

        If MaterialType = 1 Then  'SA or BN
            AddLogEntry("Control Control.SAEnable")
            Control.SAEnable()
            lblSA.ForeColor = Color.Red
        Else
            AddLogEntry("Control Control.UCEnable")
            Control.UCEnable()
            lblUC.ForeColor = Color.Red
        End If

        FramePaused.Visible = False
        lblFilling.Text = "Filling"
        FrameFilling.Visible = True
        FrameFilling.Left = 214
        FrameFilling.Top = 14
        Status.Text = "Continue Filling"
        PauseMode = False

    End Sub

    Private Sub ContinueFillH2O()
        'Dim Commodity As clsCommodity

        AutoPause = False
        'AddLogEntry ("frmTransactionProcessing - cmdContinue_Click")
        ' ----- Enable proper buttons -----
        cmdCancel.Enabled = True
        If TareSet = True Then
            cmdEdit.Enabled = False
        End If
        cmdContinue.Enabled = False
        cmdPrint.Enabled = False

        AddLogEntry("Control Control.H2OEnable")
        Control.H2OEnable()
        lblWater.ForeColor = Color.Red

        FramePaused.Visible = False
        lblFilling.Text = "Filling H2O"
        FrameFilling.Visible = True
        FrameFilling.Left = 214
        FrameFilling.Top = 14
        Status.Text = "Continue Filling H2O"
        PauseMode = False

    End Sub

    Private Sub LoadStatus(ByVal ID As Integer, Loading As Boolean, Status As String, Tank As String, Scale As String)
        Try
            SQL.RunQuery("Update Loader set Loading = '" & Loading & "', Status = '" & Status & "', Tank = '" & Tank & "', Scale = '" & Scale & "' where ID = '" & ID & "'")
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Private Sub cmdPrint_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrint.Click

        Try
            If cmdPrint.Text = "Reprint" Then
                PrintLastTicket()
            Else
                'First make sure Gross > Tare (maybe truck pulled off scale)
                GrossWt = Val(Control.DisplayedWeight)
                GrossBox.Text = GrossWt
                If Val(GrossBox.Text) + 400 < Val(TareBox.Text) Then
                    AddLogEntry("Cannot Print BOL because Gross < Tare")
                    MsgBox("Cannot print ticket because scale is weighing less than tare weight")
                Else
                    AddLogEntry("frmTransactionProcessing - cmdPrint_Click")
                    cmdCancel.Enabled = False
                    cmdContinue.Enabled = False
                    'cmdPrint.Enabled = False
                    cmdPrint.Text = "Reprint"
                    cmdEdit.Enabled = False
                    GrossWt = Val(Control.DisplayedWeight)
                    GrossBox.Text = GrossWt
                    SavePrint()
                    FramePaused.Visible = False
                    TransactionComplete = True
                    AddLogEntry("TransactionComplete set to TRUE")
                End If
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SavePrint()
        Try
            Dim Transaction As clsTransaction
            Dim Consignee As clsConsignee
            Dim SysOptions As clsSystem
            'Dim Ticket As clsTicket
            Dim TransId As Long
            Dim Tank As clsTank
            Dim Mosaic As clsMosaic
            Dim Brenntag As clsBrenntag
            Dim SA As clsSA
            Dim iLoop As Integer
            Dim TicketLoop As Integer
            'Dim PrintCOA As Boolean
            Dim MosaicProduct As String = ""
            'Dim MosaicFreight As String

            AddLogEntry("frmTransactionProcessing - SavePrint")
            Transaction = New clsTransaction
            Consignee = New clsConsignee
            SysOptions = New clsSystem
            Tank = New clsTank

            ' ----- Get Tank Level -----
            Tank.GetFillTank(ActiveScale, TankMaterial)
            Tank.FindRecord(Tank.Id)
            AddLogEntry("Updating Tank Level for Tank " & Tank.Id & "  Current Level " & Tank.CurrentLevel)
            If Brenntag25 = True Then
                Tank.CurrentLevel = Format(Tank.CurrentLevel - ((Val(GrossWt) / 2000) - (H2OWeight / 2000)), "#####.##")
            Else
                Tank.CurrentLevel = Format(Tank.CurrentLevel - ((Val(GrossWt) / 2000) - (Val(TareWt) / 2000)), "#####.##")
            End If

            If Tank.CurrentLevel < 0 Then Tank.CurrentLevel = 0
            AddLogEntry("New Level for Tank " & Tank.Id & "  Current Level " & Tank.CurrentLevel)
            Transaction.TankLevel = Tank.CurrentLevel

            ' ----- Add Transaction Record ----
            Transaction.ScaleNumber = SysOptions.ScaleNumber
            Transaction.Id = Consignee.GetNextTransNumber(cboCode.Text)
            AddLogEntry("Transaction Id will be: " & Transaction.Id)
            Transaction.InTime = Mid(txtInTime.Text, 1, 5)

            txtOutTime.Text = Format(Now, "HH:mm")
            If Mid(txtOutTime.Text, 1, 5) = "00:00" Then
                txtOutTime.Text = "00:01"
            End If
            Transaction.OutTime = Mid(txtOutTime.Text, 1, 5)
            Transaction.TDate = Format(Now, "MM/dd/yyyy") & " " & Mid(txtOutTime.Text, 1, 5)
            Transaction.DriverId = txtDriverId.Text
            Transaction.Code = cboCode.Text
            Transaction.VehicleID = txtVehicle.Text
            Transaction.TrailerID = txtTrailer.Text
            Transaction.FillWt = Val(txtTargetWt.Text)
            Transaction.Adjustment = ""
            Transaction.Commodity = cboCommodity.Text
            Transaction.Gross = Val(GrossWt)
            Transaction.Tare = Val(TareWt)
            Transaction.Net = Val(GrossWt) - Val(TareWt)
            Transaction.ReleaseNumber = txtReleaseNumber.Text
            Transaction.TankId = Tank.Id
            Transaction.PO = txtPO.Text
            Transaction.Adjustment = "0"

            If Mid(cboCode.Text, 1, 2) = "SA" Then
                Transaction.Analysis = txtDescription2.Text
                Transaction.Desc3 = txtDescription3.Text
                Transaction.Desc4 = txtDescription4.Text
            End If
            If Val(cboCode.Text) >= 1 Or Mid(cboCode.Text, 1, 2) = "UC" Then
                Transaction.Analysis = txtDescription3.Text
            End If
            If Mid(cboCode.Text, 1, 2) = "MO" Then
                Transaction.Analysis = "32%"
            End If
            If Mid(cboCode.Text, 1, 2) = "BN" Then
                Transaction.Adjustment = BrenntagPCName
                If Brenntag25 = True Then
                    Transaction.Analysis = "25%"
                    Transaction.Desc4 = Trim(Str(H2OWeight - Val(TareWt)))
                    Transaction.Desc5 = Trim(Str(Val(GrossWt) - H2OWeight))
                Else
                    Transaction.Analysis = "50%"
                    Transaction.Desc5 = Trim(Str(Val(GrossWt) - Val(TareWt)))
                End If

            End If

            Transaction.Seal1 = txtSeal1.Text & ""
            Transaction.Seal2 = txtSeal2.Text & ""
            Transaction.Seal3 = txtSeal3.Text & ""
            Transaction.Seal4 = txtSeal4.Text & ""

            'Stop
            TransId = Transaction.AddRecord
            AddLogEntry("Transaction Added " & Transaction.Id)
            'AddLogEntry("AddRecord routine returned: " & TransId)
            ' ----- Transaction Record added ----

            ' ----- Update Code Record -----
            Consignee.FindRecord(cboCode.Text)
            AddLogEntry("Updating amount used for Code " & Consignee.Id)
            Consignee.Used = Consignee.Used + ((Val(GrossWt) / 2000) - (Val(TareWt) / 2000))
            Consignee.UpdateUsed(cboCode.Text)
            Consignee = Nothing

            ' ----- Update Tank Record -----
            Tank.UpdateRecord(Tank.Id)
            Tank = Nothing
            '  --- Tank Updated ----

            NewPrinterID = Transaction.Id
            NewPrinterCode = Transaction.Code
            'AddLogEntry("NewPrinterID = " & NewPrinterID)
            'AddLogEntry("NewPrinterCode = " & NewPrinterCode)

            Mosaic = New clsMosaic
            '------ DeActivate Release number if Mosaic Driver -----
            If MosaicDriver = True Then
                Mosaic.FindRecord(Transaction.ReleaseNumber)
                AddLogEntry("Deactivating MO Order Number " & Transaction.ReleaseNumber)
                Mosaic.UpdateActivity(Transaction.ReleaseNumber, False)
            End If

            Brenntag = New clsBrenntag
            '------ DeActivate Release number if Brenntag Driver -----
            If BrenntagDriver = True Then
                Brenntag.FindRecord(Transaction.ReleaseNumber)
                AddLogEntry("Deactivating BGM Order Number " & Transaction.ReleaseNumber)
                Brenntag.UpdateActivity(Transaction.ReleaseNumber, False)
            End If

            SA = New clsSA
            '------ DeActivate Release number if SA Driver -----
            If SADriver = True Then
                SA.FindRecord(Transaction.ReleaseNumber)
                AddLogEntry("Deactivating SA Order Number " & Transaction.ReleaseNumber)
                SA.UpdateActivity(Transaction.ReleaseNumber, False)
            End If


            Transaction = Nothing

            'Ticket Print Area
            AddLogEntry("Now Printing Tickets")

            If Mid(cboCode.Text, 1, 2) = "SA" Then
                TicketLoop = SysOptions.SANumberOfTickets
            End If
            If Val(cboCode.Text) >= 1 Or Mid(cboCode.Text, 1, 2) = "UC" Then
                TicketLoop = SysOptions.UMOumberOfTickets
            End If
            If Mid(cboCode.Text, 1, 2) = "MO" Then
                TicketLoop = SysOptions.MONumberOfTickets
            End If
            If Mid(cboCode.Text, 1, 2) = "BN" Then
                TicketLoop = SysOptions.BNNumberOfTickets
            End If

            For iLoop = 1 To TicketLoop   'SysOptions.NumberOfTickets
                PrintLastTicket()
            Next iLoop

            If SysOptions.HazmatActive = 0 And Mid(cboCode.Text, 1, 2) = "SA" Then
                PrintExcel("Q074 Hazmat.xls")
            End If

            'Brenntag check
            If BrenntagDriver = True Then
                If Len(Brenntag.Notes) > 3 Then
                    PrintBNNotes("Brenntag Notes.doc")
                End If
                If Brenntag25 = True Then
                    PrintBNCoA25("Brenntag CoA 25.doc")
                Else
                    PrintBNCoA50("Brenntag CoA 50.doc")
                End If

            End If

            Mosaic = Nothing
            Brenntag = Nothing
            SysOptions = Nothing

        Catch ex As Exception
            AddLogEntry(ex.Message)
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ShutOffMessages()
        'AddLogEntry("frmTransactionProcessing - ShutOffMessages")
        FrameWaiting.Visible = False
        FramePlatform.Visible = False
        FramePullOnScale.Visible = False
        FrameTareWeight.Visible = False

    End Sub

    Private Sub HaveTruckPullOnScale()

        Dim CurrentWeight As String
        Dim WaitCounter As Integer

        AddLogEntry("Have Truck Pull On Scale - Setting traffic light GREEN")
        RedLight.Visible = False
        GreenLight.Visible = True
        Control.SetTrafficLightGreen()
        ShutOffMessages()
        FramePullOnScale.Visible = True
        FramePullOnScale.Left = 214
        FramePullOnScale.Top = 14

        CurrentWeight = Control.DisplayedWeight
        'AddLogEntry("CurrentWeight = " & CurrentWeight)
        WaitCounter = 0
        Do While Val(CurrentWeight) < 500 And cmdCancelFlag = False
            WaitCounter = WaitCounter + 1
            If WaitCounter > 30 Then
                'AddLogEntry("Waiting Weight = " & CurrentWeight)
                WaitCounter = 0
            End If
            Application.DoEvents()

            Delay(500)
            CurrentWeight = Control.DisplayedWeight
        Loop
        AddLogEntry("Scale Weight now = " & CurrentWeight)
        TruckImage.Visible = True
        FramePullOnScale.Visible = False

    End Sub

    Private Sub HaveTruckExitScale()

        Dim CurrentWeight As String
        Dim WaitCounter As Integer

        AddLogEntry("Have Truck Exit Scale - Setting traffic light GREEN")
        RedLight.Visible = False
        GreenLight.Visible = True
        Control.SetTrafficLightGreen()
        ShutOffMessages()
        FrameWaiting.Visible = True
        FrameWaiting.Left = 214
        FrameWaiting.Top = 14

        CurrentWeight = Control.DisplayedWeight
        AddLogEntry("CurrentWeight = " & CurrentWeight)
        Do While Val(CurrentWeight) > 500
            WaitCounter = WaitCounter + 1
            If WaitCounter > 30 Then
                'AddLogEntry("Waiting Weight = " & CurrentWeight)
                WaitCounter = 0
            End If
            Application.DoEvents()

            Delay(1500)
            CurrentWeight = Control.DisplayedWeight
        Loop
        AddLogEntry("Scale Weight now = " & CurrentWeight)
        MyVerticalProgessBar1.Value = MyVerticalProgessBar1.Minimum
        TruckImage.Visible = False
        FrameWaiting.Visible = False
        'txtOutTime.Text = Format(Now, "HH:mm")

    End Sub

    Private Sub GetTruckTareWeight()

        Dim DriverReady As Boolean
        Dim SysOptions As clsSystem
        Dim Response As String


        ShutOffMessages()
        If Brenntag25 = True Then
            lblDriverReady.Text = "WAITING FOR H2O DRIVER READY !"
            AddLogEntry("Waiting for H2O Driver Ready to capture Tare")
        Else
            lblDriverReady.Text = "WAITING FOR DRIVER READY !"
            AddLogEntry("Waiting for Driver Ready to capture Tare")
        End If
        FrameTareWeight.Visible = True
        FrameTareWeight.Left = 214
        FrameTareWeight.Top = 14
        'Me.Refresh()

        SysOptions = New clsSystem

        Do While TareSet = False And cmdCancelFlag = False
            If MaterialType = 1 Then  'SA or BN
                If Brenntag25 = True Then
                    DriverReady = Control.H2ODriverReady
                    DemoDR = chkH2ODR.Checked
                Else
                    DriverReady = Control.SADriverReady
                    DemoDR = chkSADR.Checked
                End If
            Else
                DriverReady = Control.UCDriverReady
                DemoDR = chkUCDR.Checked
            End If

            Application.DoEvents()

            Delay(500)

            If DriverReady = True Or DemoDR = True Then
                'If DemoDR = True Then
                AddLogEntry("Driver Ready is TRUE - Setting traffic light RED")
                'chkSADR.Checked = True
                RedLight.Visible = True
                GreenLight.Visible = False
                Control.SetTrafficLightRed()
                TareWt = Val(Control.DisplayedWeight)
                TareBox.Text = TareWt
                AddLogEntry("TareWt = " & Str(TareWt))
                If TareWt < SysOptions.TareWeightLow Or TareWt > SysOptions.TareWeightHigh Then
                    If BrenntagDriver = True And BrenntagSplit = True Then
                        AddLogEntry("TareWt out of tolerance but ignored because of SPLIT LOAD")
                        cmdEdit.Enabled = False
                        cmdCancel.Enabled = True
                        TareSet = True
                        cmdCancel.Text = "Pause Fill"
                        If MaterialType = 1 Then  'SA or BN
                            If Brenntag25 = True Then
                                If Control.SALoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = False Then
                                    AddLogEntry("Control Control.H2OEnable")
                                    Control.H2OEnable()
                                    lblWater.ForeColor = Color.Red
                                End If
                            Else
                                If Control.SALoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = False Then
                                    AddLogEntry("Control Control.SAEnable")
                                    Control.SAEnable()
                                    lblSA.ForeColor = Color.Red
                                End If
                            End If
                        Else
                            If Control.UCLoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = False Then
                                AddLogEntry("Control Control.UCEnable")
                                Control.UCEnable()
                                lblUC.ForeColor = Color.Red
                            End If

                        End If
                    Else
                        AddLogEntry("TareWt is out of tolerance")
                        ShutOffMessages()
                        Response = MsgBox("Tare weight of " & Format(TareWt, "#####0") & " is out of tolerance! Cancel Fill?", vbYesNo + vbCritical + vbDefaultButton2, "Tare Weight Error")
                        If Response = vbYes Then
                            cmdCancelFlag = True
                        End If
                        lblDriverReady.Text = "WAITING FOR DRIVER READY !"
                        FrameTareWeight.Visible = True
                        FrameTareWeight.Left = 214
                        FrameTareWeight.Top = 14
                        'Me.Refresh()
                    End If
                Else
                    AddLogEntry("TareWt is in tolerance")
                    cmdEdit.Enabled = False
                    cmdCancel.Enabled = True
                    TareSet = True
                    cmdCancel.Text = "Pause Fill"
                    If MaterialType = 1 Then  'SA or BN
                        If Brenntag25 = True Then
                            If Control.SALoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = True Then
                                AddLogEntry("Control Control.H2OEnable")
                                Control.H2OEnable()
                                lblWater.ForeColor = Color.Red
                            End If
                        Else
                            If Control.SALoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = True Then
                                AddLogEntry("Control Control.SAEnable")
                                Control.SAEnable()
                                lblSA.ForeColor = Color.Red
                            End If
                        End If
                    Else
                        If Control.UCLoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = True Then
                            AddLogEntry("Control Control.UCEnable")
                            Control.UCEnable()
                            lblUC.ForeColor = Color.Red
                        End If
                    End If
                End If

            End If
        Loop

        FrameTareWeight.Visible = False
        SysOptions = Nothing

    End Sub

    Private Sub GetBrenntagDR()

        Dim DriverReady As Boolean
        TareSet = False
        lblDriverReady.Text = "WAITING FOR DRIVER READY !"
        FrameTareWeight.Visible = True
        FrameTareWeight.Left = 214
        FrameTareWeight.Top = 14

        Do While TareSet = False And cmdCancelFlag = False

            DriverReady = Control.SADriverReady
            DemoDR = chkSADR.Checked

            Application.DoEvents()

            Delay(500)

            If DriverReady = True Or DemoDR = True Then  '
                cmdEdit.Enabled = False
                cmdCancel.Enabled = True
                TareSet = True
                cmdCancel.Text = "Pause Fill"
                H2OWeight = Val(Control.DisplayedWeight)

                AddLogEntry("Control Control.SAEnable")
                Control.SAEnable()
                lblSA.ForeColor = Color.Red
            End If
        Loop

        FrameWaiting.Visible = False

    End Sub

    Private Sub FillTruck()

        Dim SysOptions As clsSystem
        Dim MaxWeight As Long
        Dim ProgressGross As Long
        Dim ScaleReadDelay As Integer

        'AddLogEntry ("frmTransactionProcessing - FillTruck()")
        ShutOffMessages()
        lblFilling.Text = "Filling"
        FrameFilling.Visible = True
        FrameFilling.Left = 214
        FrameFilling.Top = 14
        Status.Text = "Now Filling Truck"
        WaterFill = False

        MyVerticalProgessBar1.Visible = True
        TruckImage.Visible = True
        MyVerticalProgessBar1.Maximum = Val(txtTargetWt.Text) \ 100
        If Val(txtTargetWt.Text) > TareWt Then
            MyVerticalProgessBar1.Minimum = TareWt \ 100
        End If

        SysOptions = New clsSystem
        If MosaicDriver = True Then
            'MaxWeight = SysOptions.MOMaxFillWeight
            MaxWeight = Val(MaxWeightBox.Text)
        Else
            'MaxWeight = SysOptions.MaxFillWeight
            MaxWeight = Val(MaxWeightBox.Text)
        End If
        ScaleReadDelay = SysOptions.ReadDelay
        'AddLogEntry ("MaxWeight = " & MaxWeight)
        SysOptions = Nothing

        AddLogEntry("Enter FILL LOOP")
        'AddLogEntry("Starting Watchdog Timer")
        'Send WD command to ADU
        If Demo.Visible = False Then
            Control.SetWatchDog(2)  'Turn on for 10s time
            WatchDogTimer.Enabled = True
        End If
        AutoPause = True

        AddLogEntry("Scale Weight: " & GrossWt & "  TargetWt: " & txtTargetWt.Text)
        Do While (GrossWt < Val(txtTargetWt.Text)) And (GrossWt < MaxWeight)
            Application.DoEvents()
            Control.ReadWatchDog()
            If TransactionComplete Then
                AddLogEntry("TransactionComplete - Exiting Fill Loop")
                Exit Do
            End If
            If cmdCancelFlag = True Then
                AddLogEntry("Cancel button Pressed - Exiting Fill Loop")
                Exit Do
            End If
            GrossWt = Val(Control.DisplayedWeight)
            GrossBox.Text = GrossWt
            ProgressGross = GrossWt \ 100
            If ProgressGross > MyVerticalProgessBar1.Maximum Then
                MyVerticalProgessBar1.Value = MyVerticalProgessBar1.Maximum
            Else
                If ProgressGross < MyVerticalProgessBar1.Minimum Then
                    MyVerticalProgessBar1.Value = MyVerticalProgessBar1.Minimum
                Else
                    MyVerticalProgessBar1.Value = ProgressGross
                End If
            End If

            If MaterialType = 1 Then  'SA or BN
                If Control.SALoadingArmUp = True Or chkLoadingArm.Checked = True And AutoPause = False Then  'Arm is UP
                    If PauseMode = False Then
                        If PlatformUpCounter = 5 Then
                            AddLogEntry("Loading Arm is not down - Fill Paused")
                            Status.Text = "Loading Arm is not down - Fill Paused"
                            AutoPause = True
                            PauseMode = True
                            PauseFill()
                        Else
                            PlatformUpCounter = PlatformUpCounter + 1
                        End If
                    End If
                ElseIf Control.SALoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = True Then  'Arm is Down
                    'Stop
                    AddLogEntry("Loading Arm down - Resuming Fill")
                    Status.Text = "Loading Arm down - Resuming Fill"
                    PlatformUpCounter = 0
                    PauseMode = False
                    ContinueFill()
                End If
                'Stop
            Else  'UC or MO
                If Control.UCLoadingArmUp = True Or chkLoadingArm.Checked = True And AutoPause = False Then   'Arm is UP
                    If PauseMode = False Then
                        If PlatformUpCounter = 5 Then
                            AddLogEntry("Loading Arm is not down - Fill Paused")
                            Status.Text = "Loading Arm is not down - Fill Paused"
                            AutoPause = True
                            PauseMode = True
                            PauseFill()
                        Else
                            PlatformUpCounter = PlatformUpCounter + 1
                        End If
                    End If

                ElseIf Control.UCLoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = True Then  'Arm is Down
                    AddLogEntry("Loading Arm down - Resuming Fill")
                    Status.Text = "Loading Arm down - Resuming Fill"
                    PlatformUpCounter = 0
                    PauseMode = False
                    ContinueFill()
                End If
            End If

            Delay(ScaleReadDelay)
        Loop
        AddLogEntry("Out of Fill Loop")
        AddLogEntry("Stopping Watchdog Timer")
        'Send WatchDog disable to ADU
        Control.SetWatchDog(0)  'Disable Watchdog
        WatchDogTimer.Enabled = False

        ' ----- Truck is full turn off Outputs -----
        If MaterialType = 1 Then
            AddLogEntry("Control Control.SADisable")
            Control.SADisable()
            lblSA.ForeColor = Color.Black
        Else
            AddLogEntry("Control Control.UCDisable")
            Control.UCDisable()
            lblUC.ForeColor = Color.Black
        End If
        'MyVerticalProgessBar1.Visible = False
        FrameFilling.Visible = False
        Status.Text = ""

    End Sub

    Private Sub FillTruckH2O()

        Dim SysOptions As clsSystem
        Dim MaxWeight As Long
        Dim ProgressGross As Long
        Dim ScaleReadDelay As Integer

        'AddLogEntry ("frmTransactionProcessing - FillTruck()")
        ShutOffMessages()
        lblFilling.Text = "Filling H2O"
        FrameFilling.Visible = True
        FrameFilling.Left = 214
        FrameFilling.Top = 14
        Status.Text = "Now Filling H2O"
        WaterFill = True

        MyVerticalProgessBar1.Visible = True
        MyVerticalProgessBar1.Maximum = Val(txtTargetWt.Text) \ 100
        If Val(txtTargetWt.Text) > TareWt Then
            MyVerticalProgessBar1.Minimum = TareWt \ 100
        End If

        SysOptions = New clsSystem
        If MosaicDriver = True Then
            'MaxWeight = SysOptions.MOMaxFillWeight
            MaxWeight = Val(MaxWeightBox.Text)
        Else
            'MaxWeight = SysOptions.MaxFillWeight
            MaxWeight = Val(MaxWeightBox.Text)
        End If
        ScaleReadDelay = SysOptions.ReadDelay
        'AddLogEntry ("MaxWeight = " & MaxWeight)
        SysOptions = Nothing

        AddLogEntry("Enter FILL LOOP for H2O")
        AddLogEntry("Starting Watchdog Timer")
        'Send WD command to ADU
        If Demo.Visible = False Then
            Control.SetWatchDog(2)  'Turn on for 10s time
            WatchDogTimer.Enabled = True
        End If
        AutoPause = True

        AddLogEntry("Scale Weight: " & GrossWt & "  TargetWt: " & txtH2OTarget.Text)
        Do While (GrossWt < Val(txtH2OTarget.Text)) And (GrossWt < MaxWeight)
            Application.DoEvents()
            Control.ReadWatchDog()
            If TransactionComplete Then
                AddLogEntry("TransactionComplete - Exiting Fill Loop")
                Exit Do
            End If
            If cmdCancelFlag = True Then
                AddLogEntry("Cancel button Pressed - Exiting Fill Loop")
                Exit Do
            End If
            GrossWt = Val(Control.DisplayedWeight)
            GrossBox.Text = GrossWt
            ProgressGross = GrossWt \ 100
            If ProgressGross > MyVerticalProgessBar1.Maximum Then
                MyVerticalProgessBar1.Value = MyVerticalProgessBar1.Maximum
            Else
                If ProgressGross < MyVerticalProgessBar1.Minimum Then
                    MyVerticalProgessBar1.Value = MyVerticalProgessBar1.Minimum
                Else
                    MyVerticalProgessBar1.Value = ProgressGross
                End If
            End If

            If Control.SALoadingArmUp = True Or chkLoadingArm.Checked = True And AutoPause = False Then  'Arm is UP
                If PauseMode = False Then
                    If PlatformUpCounter = 5 Then
                        AddLogEntry("Loading Arm is not down - Fill Paused")
                        Status.Text = "Loading Arm is not down - Fill Paused"
                        AutoPause = True
                        PauseMode = True
                        PauseFillH2O()
                    Else
                        PlatformUpCounter = PlatformUpCounter + 1
                    End If
                End If

            ElseIf Control.SALoadingArmUp = False And chkLoadingArm.Checked = False And AutoPause = True Then
                'AddLogEntry("Loading Arm down - Resuming Fill")
                Status.Text = "Loading Arm down - Resuming Fill"
                PlatformUpCounter = 0
                PauseMode = False
                ContinueFillH2O()
            End If

            Delay(ScaleReadDelay)
        Loop
        AddLogEntry("Out of Fill Loop")
        AddLogEntry("Stopping Watchdog Timer")
        'Send WatchDog disable to ADU
        Control.SetWatchDog(0)  'Disable Watchdog
        WatchDogTimer.Enabled = False

        ' ----- Truck is full turn off Outputs -----
        AddLogEntry("Control Control.H2ODisable")
        Control.H2ODisable()
        lblWater.ForeColor = Color.Black

        'MyVerticalProgessBar1.Visible = False
        FrameFilling.Visible = False
        Status.Text = ""

    End Sub
    Private Sub WeightHasHitTarget()

        'AddLogEntry ("frmTransactionProcessing - WeightHasHitTarget()")
        cmdCancel.Enabled = False
        cmdContinue.Enabled = False
        cmdEdit.Enabled = False
        'cmdPrint.Enabled = False
        FramePlatform.Left = 214
        FramePlatform.Top = 14
        FramePlatform.Visible = True
    End Sub

    Private Sub H2OHasHitTarget()

        'AddLogEntry ("frmTransactionProcessing - WeightHasHitTarget()")
        cmdCancel.Enabled = False
        cmdContinue.Enabled = False
        cmdEdit.Enabled = False
        'cmdPrint.Enabled = False
        FramePlatform.Left = 214
        FramePlatform.Top = 14
        FrameWaiting.Visible = True
    End Sub
    Private Sub WaitForPlatformsToClear()

        Dim PlatformClear As Boolean

        'AddLogEntry ("frmTransactionProcessing - WaitForPlatformsToClear()")
        PlatformClear = False
        If MaterialType = 1 Then
            AddLogEntry("Entering SA Platform do Loop")
            Do While PlatformClear = False
                Application.DoEvents()

                Delay(1000)
                If Control.SALoadingArmUp = True Or chkLoadingArm.Checked = True Then  'Arm is UP
                    AddLogEntry("Loading arm is up - Waiting for Platform")
                    If Control.SouthPlatformUp = True Or chkPlatform.Checked = True Then  'South Platform is UP
                        AddLogEntry("South Platform is now clear")
                        If Control.NorthPlatformUp = True Then
                            AddLogEntry("North Platform is now clear")
                            cmdCancel.Enabled = False
                            cmdContinue.Enabled = False
                            cmdEdit.Enabled = False
                            cmdPrint.Enabled = True
                            FramePlatform.Visible = False
                            PlatformClear = True
                            'Turn off Tank request afer 30 seconds
                            TankRequestTimer.Enabled = True

                            'txtOutTime.Text = Format(Now, "HH:mm")
                            'Stop
                        End If
                    End If
                End If
            Loop
        Else
            AddLogEntry("Entering UC Platform do Loop")
            Do While PlatformClear = False
                Application.DoEvents()

                Delay(1000)
                If Control.UCLoadingArmUp = True Or chkLoadingArm.Checked = True Then  'Arm is UP
                    AddLogEntry("Loading arm is up - Waiting for Platform")
                    If Control.NorthPlatformUp = True Or chkPlatform.Checked = True Then  'South Platform is UP
                        AddLogEntry("South Platform is now clear")
                        If Control.NorthPlatformUp = True Then
                            AddLogEntry("North Platform is now clear")
                            cmdCancel.Enabled = False
                            cmdContinue.Enabled = False
                            cmdEdit.Enabled = False
                            cmdPrint.Enabled = True
                            FramePlatform.Visible = False
                            PlatformClear = True
                            'Turn off Tank request afer 30 seconds
                            TankRequestTimer.Enabled = True

                            'txtOutTime.Text = Format(Now, "HH:mm")
                            'Stop
                        End If
                    End If
                End If
            Loop
        End If

    End Sub

    Private Sub GrossBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles GrossBox.TextChanged
        NetBox.Text = Val(GrossBox.Text) - Val(TareBox.Text)
        TonBox.Text = Val(NetBox.Text) / 2000

    End Sub

    Private Sub txtDisplayTarget_Click(sender As Object, e As System.EventArgs) Handles txtDisplayTarget.Click
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtVehicle_Click(sender As Object, e As System.EventArgs) Handles txtVehicle.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtVehicle_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVehicle.TextChanged

    End Sub

    Private Sub txtTrailer_Click(sender As Object, e As System.EventArgs) Handles txtTrailer.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtTrailer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTrailer.TextChanged

    End Sub

    Private Sub txtReleaseNumber_Click(sender As Object, e As System.EventArgs) Handles txtReleaseNumber.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtReleaseNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReleaseNumber.TextChanged

    End Sub

    Private Sub cmdEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdEdit.Click
        AddLogEntry("EDIT button hit Caption = " & cmdEdit.Text)
        If cmdEdit.Text = "Edit" Then
            AddLogEntry("Change cmdEdit caption to SAVE")
            cmdEdit.Text = "Save"

            cmdCancel.Enabled = False
            cmdContinue.Enabled = False
            cmdPrint.Enabled = False

            Dim CodeTest = Mid(cboCode.Text, 1, 2)

            'Fill in ComboBox
            SQL.RunQuery("SELECT * FROM Consignee WHERE LEFT(Consignee.Code,2) = '" & CodeTest & "' And ACTIVE = '1'")
            If SQL.RecordCount > 0 Then
                For Each r As DataRow In SQL.SQLDataset.Tables(0).Rows
                    cboCode.Items.Add(r("Code"))
                Next
            End If

            cmdPrint.Enabled = False
            cboCode.Enabled = True
            txtVehicle.Enabled = True
            txtTrailer.Enabled = True
            txtSeal1.Enabled = True
            txtSeal2.Enabled = True
            txtSeal3.Enabled = True
            txtSeal4.Enabled = True
            txtDisplayTarget.Enabled = True
            If Mid(cboCode.Text, 1, 2) <> "SA" Then
                txtReleaseNumber.Enabled = True
            End If
        Else
            AddLogEntry("Change cmdEdit caption to EDIT")
            cmdEdit.Text = "Edit"

            cmdCancel.Enabled = False
            cmdContinue.Enabled = True
            cmdPrint.Enabled = True
            cboCode.Enabled = False
            txtVehicle.Enabled = False
            txtTrailer.Enabled = False
            txtSeal1.Enabled = False
            txtSeal2.Enabled = False
            txtSeal3.Enabled = False
            txtSeal4.Enabled = False
            txtDisplayTarget.Enabled = False
            cboCommodity.Enabled = False
            txtReleaseNumber.Enabled = False
        End If

    End Sub

    Private Sub Scale1Check_Tick(sender As System.Object, e As System.EventArgs) Handles Scale1Check.Tick
        Scale1Box.Text = ScaleWeight1
    End Sub

    Private Sub Scale1Box_TextChanged(sender As System.Object, e As System.EventArgs) Handles Scale1Box.TextChanged
        txtGross.Text = Val(Scale1Box.Text)
    End Sub

    Private Sub SetupCom()
        Dim SysOptions = New clsSystem
        Dim CommInfo As String
        Try
            If SysOptions.ScaleActive = 1 Then

                'Select which port to setup
                If RailMode Then
                    ScaleCom.ReceivedBytesThreshold = 50
                    If SADriver Then
                        CommInfo = SysOptions.ScaleSettings   'Acid Flowmeter
                    Else
                        CommInfo = SysOptions.CardSettings    'Caustic Flowmeter
                    End If
                Else
                    ScaleCom.ReceivedBytesThreshold = 1       'Truck Loadout Scale
                    CommInfo = SysOptions.ScaleSettings
                End If

                Dim parts As String() = CommInfo.Split(","c)

                'First determining that port exists
                AddLogEntry("First determining that port exists")
                Dim portNMs() As String = IO.Ports.SerialPort.GetPortNames
                If Not portNMs.Contains(parts(0)) Then
                    AddLogEntry("Scale Serial port: " & parts(0) & " does not exist")
                Else
                    If ScaleCom.IsOpen Then
                        AddLogEntry("Scale Serial port is already open - close it first")
                        ScaleCom.Close()
                    End If
                End If

                ScaleCom.PortName = parts(0)
                ScaleCom.BaudRate = parts(1)
                Select Case parts(2)
                    Case "N"
                        ScaleCom.Parity = Ports.Parity.None
                    Case "E"
                        ScaleCom.Parity = Ports.Parity.Even
                    Case "O"
                        ScaleCom.Parity = Ports.Parity.Odd
                    Case "S"
                        ScaleCom.Parity = Ports.Parity.Space
                    Case "M"
                        ScaleCom.Parity = Ports.Parity.Mark
                End Select

                ScaleCom.DataBits = parts(3)

                Select Case parts(4)
                    Case 1
                        ScaleCom.StopBits = Ports.StopBits.One
                    Case 2
                        ScaleCom.StopBits = Ports.StopBits.Two
                    Case Else
                        ScaleCom.StopBits = Ports.StopBits.One
                End Select

                AddLogEntry("Now opening Scale Serial port: " & ScaleCom.PortName)
                ScaleCom.Open()

                ScaleCom.DiscardInBuffer()
                ScaleCom.DiscardOutBuffer()

            End If
            SysOptions = Nothing
        Catch ex As Exception
            Status.Text = ex.Message
            AddLogEntry("SetupCom: " & ex.Message)
        End Try

    End Sub

    Private Sub ScaleCom_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ScaleCom.DataReceived

        Dim rcvd1 As String

        Try
            If RailMode Then
                Dim startnum As Integer
                Dim endnum As Integer
                rcvd1 = ScaleCom.ReadExisting
                Dim msglength As String = Len(rcvd1)

                If SADriver Then ' Acid method
                    If InStr(rcvd1, "Total:") <> 0 Then
                        startnum = InStr(rcvd1, "Total:")
                        endnum = InStr(rcvd1, "lb")
                        ScaleWeight1 = Val(Mid(rcvd1, startnum + 15, 6))
                    End If
                Else ' Caustic method
                    Dim match As Match = Regex.Match(rcvd1, "Actual:\s+(\d+)")
                    If match.Success Then
                        ScaleWeight1 = Val(match.Groups(1).Value)
                    End If
                End If
            Else
            Dim w1 As String = ""
            rcvd1 = ScaleCom.ReadExisting
            For i = 1 To Len(rcvd1)
                w1 = Mid(rcvd1, i, 1)
                If w1 = vbCr And Flag1 = True Then   'end of weight string vbCr (or L if using simulator)
                    Flag1 = False
                    If InStr(Weight1, "?") = 0 Then
                        'Scale1Box.Text = Val(Weight1)
                        ScaleWeight1 = Val(Mid(Weight1, 4, 6))  '4, 6  (or 1,6 if using simulator)
                    End If
                    Weight1 = ""
                End If
                If Flag1 = True Then   'start adding up weight
                    Weight1 = Weight1 + w1
                End If
                If w1 = Chr(2) Then   'Get STX
                    Flag1 = True
                End If
            Next i
            End If

            'Reset watchdog timer if set
            If WatchDogTimer.Enabled = True Then
                WatchDogTimer.Enabled = False
                WatchDogTimer.Enabled = True
            End If

        Catch ex As Exception
            AddLogEntry("ScaleCom_DataReceived: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdWD_Click(sender As System.Object, e As System.EventArgs) Handles cmdWD.Click
        Control.ReadWatchDog()
    End Sub

    Private Sub WatchDogTimer_Tick(sender As System.Object, e As System.EventArgs) Handles WatchDogTimer.Tick
        Status.Text = "Watchdog Timeout"
        cmdCancel.PerformClick()
    End Sub

    Private Sub GetInput()
        Dim WhitePen As Pen
        WhitePen = New Pen(Drawing.Color.White, 12)
        Dim GreenPen As Pen
        GreenPen = New Pen(Drawing.Color.Green, 12)
        'Draw status circles in Tank Select groupbox
        Dim BlackPen As Pen
        BlackPen = New Pen(Drawing.Color.Black, 2)

        Dim myGraphics As Graphics = Me.grpLoadStatus.CreateGraphics

        'myGraphics.DrawEllipse(BlackPen, 20, 184, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 20, 222, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 20, 260, 26, 26)

        If Control.SADriverReady = True Then
            myGraphics.DrawEllipse(GreenPen, 20, 45, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 20, 45, 12, 12)
        End If
        If Control.SouthPlatformUp = True Then
            myGraphics.DrawEllipse(GreenPen, 20, 85, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 20, 85, 12, 12)
        End If
        If Control.SALoadingArmUp = True Then
            myGraphics.DrawEllipse(GreenPen, 20, 120, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 20, 120, 12, 12)
        End If

        'If Control.SARailReady = True Then
        '    myGraphics.DrawEllipse(GreenPen, 40, 180, 12, 12)
        'Else
        '    myGraphics.DrawEllipse(WhitePen, 40, 180, 12, 12)
        'End If

        If Control.UCDriverReady = True Then
            myGraphics.DrawEllipse(GreenPen, 180, 45, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 180, 45, 12, 12)
        End If
        If Control.NorthPlatformUp = True Then
            myGraphics.DrawEllipse(GreenPen, 180, 85, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 180, 85, 12, 12)
        End If
        If Control.UCLoadingArmUp = True Then
            myGraphics.DrawEllipse(GreenPen, 180, 120, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 180, 120, 12, 12)
        End If

        If Control.H2ODriverReady = True Then
            myGraphics.DrawEllipse(GreenPen, 20, 150, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 20, 150, 12, 12)
        End If
    End Sub

    Private Sub InputTimer_Tick(sender As System.Object, e As System.EventArgs) Handles InputTimer.Tick
        GetInput()
    End Sub

    Private Sub cboCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCode.SelectedIndexChanged
        Dim Consignee As clsConsignee

        Consignee = New clsConsignee
        Consignee.FindRecord(cboCode.Text)
        txtConsignee.Text = Consignee.Consignee
        txtDestination.Text = Consignee.Destination

        Consignee = Nothing
    End Sub

    Private Sub LoadStatusTimer_Tick(sender As Object, e As EventArgs) Handles LoadStatusTimer.Tick
        LoadStatus(LoadID, True, "Filling Truck", txtTank.Text, Scale1Box.Text)
    End Sub

    Private Sub TankRequestTimer_Tick(sender As Object, e As EventArgs) Handles TankRequestTimer.Tick
        Try
            TankRequestTimer.Enabled = False
            'Release any Tank Select request
            aduhandle = OpenAduDeviceBySerialNumber(TankSelectSN, 1)
            Control.ResetTankRequest()
            Delay(400)
            'Reopen Truck Loading ADU
            aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)
        Catch ex As Exception
            AddLogEntry("TankRequestTimer: " & ex.Message)
        End Try
    End Sub

    Private Sub txtGross_TextChanged(sender As Object, e As EventArgs) Handles txtGross.TextChanged

    End Sub
End Class