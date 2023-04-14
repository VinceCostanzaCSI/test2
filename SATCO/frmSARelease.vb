Public Class frmSARelease
    Private Sub frmSARelease_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterForm(Me)
        SADriver = True
        BrenntagDriver = False
        BrenntagSplit = False
        TankStatusTimer.Enabled = True
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        Me.Close()
        frmPin.MdiParent = frmMain
        frmPin.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim SA As clsSA
        Dim Consignee As clsConsignee
        Dim Tank As clsTank
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Commodity As clsCommodity
        Dim Carrier As clsCarrier
        Dim ActiveScale As Integer
        Dim MaterialType As Integer
        Dim CarrierCheck As String
        Dim MaxFill As Long

        If cmdNext.Text = "Validate" Then
            'AddLogEntry ("frmSARelease - Validate button hit")
            'Check for valid Release number and fill in the blanks
            SA = New clsSA
            Process = New clsProcess
            If Len(txtRelease.Text) > 0 Then
                AddLogEntry("Find SA record - " & txtRelease.Text)
                If SA.FindRecord(txtRelease.Text) = False Then
                    AddLogEntry("SA Record not found")
                    lblMsg.Text = "Release # not found !"
                Else
                    'Check to see if it is Active
                    If SA.Active = False Then
                        AddLogEntry("Release # is not active")
                        lblMsg.Text = "Release # not Active !"
                    Else
                        'Show Valid and show fields
                        lblRelease.Text = txtRelease.Text
                        lblProduct.Text = SA.Product
                        lblStrength.Text = SA.Analysis
                        lblCode.Text = "SA" & SA.Consignee
                        lblTank.Text = SA.Tank
                        lblPO.Text = SA.PO

                        If lblCode.Text = "SA" & SA.Consignee Then
                            'Get Destination from Consignee (Consignee) table
                            Consignee = New clsConsignee
                            AddLogEntry("Find Consignee record - " & lblCode.Text)
                            If Consignee.FindRecord(lblCode.Text) = False Then
                                AddLogEntry("Consignee Record not found")
                                lblMsg.Text = "Consignee not found !"
                            Else
                                AddLogEntry("Consignee Record found")
                                lblConsignee.Text = Consignee.Consignee
                                lblDest1.Text = Consignee.Destination
                                lblDest2.Text = Consignee.Destination2

                                'Check for NSF
                                lblNSF.Visible = Consignee.NSF
                                NSFLoad = Consignee.NSF

                                lblMsg.Text = "Checking Tank Selection"
                            End If
                            Consignee = Nothing

                            SARelease = txtRelease.Text
                            GroupBox1.Visible = True

                            'Check to see if Tanks match
                            Tank = New clsTank

                            ActiveScale = 0
                            MaterialType = 0   'SA
                            Tank.GetFillTank(ActiveScale, MaterialType)

                            RequestedTank = lblTank.Text
                            SelectedTank = "00"   'Tank.Id
                            If RailMode Then
                                RequestedTank = lblTank.Text
                                SelectedTank = Tank.Id
                                If RequestedTank <> SelectedTank Then
                                    MsgBox("Tank requested is not selected")
                                    AddLogEntry("Tanks do not match. - RailMode")
                                    Exit Sub
                                End If
                            End If


                            If RailMode = False Then
                                TankSelectForm = False
                                frmTankSelect.MdiParent = frmMain
                                frmTankSelect.Show()
                                Do While TankSelectForm = False
                                    Application.DoEvents()
                                Loop
                                'Now check again for tank alignment
                                If RequestedTank <> SelectedTank Then     'Request Failed
                                    SA = Nothing
                                    Process = Nothing
                                    SysOptions = Nothing
                                    Commodity = Nothing
                                    Tank = Nothing
                                    Exit Sub
                                End If
                            End If

                            AddLogEntry("Tank " & lblTank.Text & " is active. Proceeding")
                            'End If

                            'Now check for Commodity
                            'Commodity = New clsCommodity

                            ActiveScale = 0
                            MaterialType = 0   'SA
                            Tank.GetFillTank(ActiveScale, MaterialType)
                            Tank.FindRecord(Tank.Id)
                            lblProductCode.Text = "SA" & Tank.Id

                            '*** Now validate the Commodity ***
                            AddLogEntry("Commodity = " & lblProductCode.Text)
                            Commodity = New clsCommodity
                            If Len(lblProductCode.Text) > 0 Then
                                AddLogEntry("Verifying Commodity " & lblProductCode.Text)
                                If Commodity.FindRecord("SA" & Tank.Id) = False Then
                                    AddLogEntry("Commodity SA" & Tank.Id & " is NOT valid")
                                    lblMsg.Text = "Commodity not found !"
                                Else
                                    AddLogEntry("Commodity SA" & Tank.Id & " is VALID")
                                    lblStrength.Text = Commodity.Description2
                                End If
                            End If

                            If RailMode Then
                                cmdNext.Text = "Next"

                            Else
                                cmdNext.Text = "Next"
                                lblMsg.Text = "Enter Target Weight"
                                lblOrder.Text = "Target Weight:"
                                txtTargetWt.Visible = True
                                txtRelease.Visible = False
                                txtTargetWt.Focus()
                            End If

                        Else
                            'Stop
                            AddLogEntry("Consignee does not match Release Number")
                            lblMsg.Text = "Consignee does not Match!"
                            SA = Nothing
                            Process = Nothing
                            SysOptions = Nothing
                            Commodity = Nothing
                            Tank = Nothing
                            Exit Sub
                        End If


                    End If
                End If
            End If

            SA = Nothing
            Process = Nothing
            SysOptions = Nothing
            Commodity = Nothing
            Tank = Nothing
            Exit Sub
        End If
        If cmdNext.Text = "Next" Then
            If RailMode Then
                txtTargetWt.Text = "210000"
            End If
            'Get Target Weight
            'AddLogEntry ("frmTargetWt - NEXT button hit")
            SysOptions = New clsSystem
            Commodity = New clsCommodity
            Tank = New clsTank
            Process = New clsProcess
            If Len(txtTargetWt.Text) > 0 Then
                AddLogEntry("Validating Target Weight entered")
                CarrierCheck = Process.Carrier
                Carrier = New clsCarrier
                If Carrier.FindRecord(CarrierCheck) = True Then
                    AddLogEntry("Carrier MaxLoad set to: " & Carrier.MaxLoad)
                    CarrierMaxWeight = Carrier.MaxLoad
                    MaxFill = CarrierMaxWeight
                Else
                    AddLogEntry("Carrier not found to get maxload. Setting Default = " & SysOptions.MaxFillWeight)
                    MaxFill = SysOptions.MaxFillWeight
                End If
                Carrier = Nothing
                If RailMode Then
                    MaxFill = "250000"
                End If

                If Val(txtTargetWt.Text) > MaxFill Then
                    AddLogEntry("Target Weight entered exceeds maximum")
                    lblMsg.Text = "MAXIMUM FILL WEIGHT EXCEEDED !"
                Else
                    If Val(txtTargetWt.Text) > 0 Then
                        AddLogEntry("Target Weight is > 0 and < Maximum")
                        ' ----- Verify the tank has enough to complete the fill -----
                        AddLogEntry("Verify Tank contains enough product to complete fill")
                        ActiveScale = 0
                        MaterialType = 0   'SA
                        Tank.GetFillTank(ActiveScale, MaterialType)
                        Tank.FindRecord(Tank.Id)
                        AddLogEntry("Fill will come from TANK " & Tank.Id)
                        AddLogEntry("Target weight = " & txtTargetWt.Text / 2000 & "  Current Tank Level = " & Tank.CurrentLevel)
                        If Tank.CurrentLevel > (Val(txtTargetWt.Text) / 2000) Then
                            AddLogEntry("Low Alarm value = " & Tank.LowAlarmValue & "  Current Tank Level = " & Tank.CurrentLevel)
                            Process.TargetWt = txtTargetWt.Text
                            If MaterialType = 0 Then Process.DisplayTarget = Process.TargetWt

                            If Tank.CurrentLevel > Tank.LowAlarmValue Then
                                'Everything OK so far
                                cmdNext.Text = "Proceed"
                                lblMsg.Text = "Target Weight Confirmed"
                                txtTargetWt.BackColor = Color.LightGreen
                                Process = Nothing
                                Tank = Nothing
                                Commodity = Nothing
                                SysOptions = Nothing
                                Exit Sub
                            Else
                                AddLogEntry("Unable to fill Tank is below Low Level Alarm")
                                MsgBox("Unable to fill !  Tank is below low alarm value !", vbOKOnly, "Target Wt Error")
                            End If
                        Else
                            AddLogEntry("Insufficient product to complete fill")
                            MsgBox("Insufficient quantity to complete fill !", vbOKOnly, "Target Wt Error")
                        End If
                    Else
                        AddLogEntry("Target Weight entered is less then ZERO")
                        lblMsg.Text = "FILL WEIGHT LESS THEN ZERO !"
                    End If
                End If
            Else
                AddLogEntry("INVALID Target Weight entered")
                lblMsg.Text = "INVALID TARGET WEIGHT ENTERED !"
            End If
            Process = Nothing
            Tank = Nothing
            Commodity = Nothing
            SysOptions = Nothing

            Exit Sub
        End If
        If cmdNext.Text = "Proceed" Then
            'Check Commodity and proceed to Capacity form
            If Len(lblCode.Text) > 0 Then
                SysOptions = New clsSystem
                Tank = New clsTank
                Consignee = New clsConsignee
                AddLogEntry("Find Consignee record - " & lblCode.Text)
                'Stop
                If Consignee.FindRecord(lblCode.Text) = False Then
                    'Consignee.EOF Then
                    AddLogEntry("Consignee Record not found: " & lblCode.Text)
                    lblMsg.Text = "Code not found !"
                Else
                    AddLogEntry("Consignee Record found: " & lblCode.Text)

                    'Check if limit is reached for Consignee
                    If Consignee.Limit <> 0 Then   'Ignore if Limit = 0
                            If Consignee.Limit - Consignee.Used < 0 Then
                                AddLogEntry("Consignee Limit exceeded")
                                MsgBox("Consignee Limit exceeded")
                                'Stop
                                Exit Sub
                            End If
                        End If
                        'Stop
                        If Len(Tank.GetFillTank(ActiveScale, MaterialType)) > 0 Then
                            'AddLogEntry ("frmSA - Tank has an associated Material")
                            Process = New clsProcess
                            'AddLogEntry ("frmSA - Set Code = " & cboCode.Text & "  Consignee = " & Consignee.Consignee & "  Destination = " & Consignee.Destination)
                            Process.ReleaseNumber = txtRelease.Text
                            Process.Code = lblCode.Text
                            Process.Consignee = lblConsignee.Text
                            Process.Destination = lblDest1.Text
                            Process.PO = lblPO.Text

                            '*** Now validate the Commodity ***
                            AddLogEntry("Commodity = " & lblProductCode.Text)
                            Commodity = New clsCommodity
                            If Len(lblProductCode.Text) > 0 Then
                                AddLogEntry("Verifying Commodity " & lblProductCode.Text)
                                If Commodity.FindRecord(lblProductCode.Text) = False Then
                                    'Commodity.EOF
                                    AddLogEntry("Commodity " & lblProductCode.Text & " is NOT valid")
                                    lblMsg.Text = "Code not found !"
                                Else
                                    AddLogEntry("Commodity " & lblProductCode.Text & " is VALID")
                                    AddLogEntry("Commodity Variable Wt = " & Commodity.VariableWt & "  ProcessWt = " & Process.TargetWt)
                                    If (Val(Process.TargetWt) - Val(Commodity.VariableWt)) > 0 Then
                                        Process.DisplayTarget = Process.TargetWt
                                        'AddLogEntry("DisplayTarget = " & Process.DisplayTarget & "  Actual TargetWt = " & Process.TargetWt - Val(Commodity.VariableWt))
                                        'Process.TargetWt = Process.TargetWt - Val(Commodity.VariableWt)
                                        Process.Commodity = Commodity.ID
                                        Process.Description1 = Commodity.Description1
                                        Process.Description2 = Commodity.Description2
                                        Process.Description3 = Commodity.Description3
                                        Process.Description4 = Commodity.Description4
                                        Process.FreeFlow = Commodity.VariableWt
                                    Else
                                        AddLogEntry("Adjusted Target weight is below zero")
                                        MsgBox("Target weight is below zero !", vbOKOnly, "Weight Error")
                                    End If
                                End If

                            Else
                                AddLogEntry("INVALID Commodity")
                                lblMsg.Text = "Invalid Commodity !"
                                Process = Nothing
                                Commodity = Nothing
                                Exit Sub
                            End If

                            ' ----- Open Loading Control ADU -----
                            AddLogEntry("Switching back to Trailer Load ADU")
                            aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)

                            AddLogEntry("Unload frmSARelease")
                            Me.Close()

                            If RailMode Then
                                AddLogEntry("frmSARelease - Loading frmTrailer")
                                frmTrailer.MdiParent = frmMain
                                frmTrailer.Show()
                            Else
                                AddLogEntry("frmSARelease - Loading frmSACapacity")
                                frmSACapacity.MdiParent = frmMain
                                frmSACapacity.Show()

                            End If

                        Else
                            If MaterialType = 0 Then
                                AddLogEntry("No SA Tank associated with this Scale")
                                MsgBox("No SA Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                            End If
                            If MaterialType = 1 Then
                                AddLogEntry("No UC Tank associated with this Scale")
                                MsgBox("No UC Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                            End If
                            If MaterialType = 2 Then
                                AddLogEntry("No MO Tank associated with this Scale")
                                MsgBox("No UC Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                            End If

                        End If

                End If
            Else
                AddLogEntry("Invalid Consignee code entered")
                lblMsg.Text = "Invalid Consignee Code entered !"
            End If
        End If
        Consignee = Nothing
        Tank = Nothing
        Process = Nothing
        Commodity = Nothing
        SysOptions = Nothing
    End Sub

    Private Sub txtRelease_Click(sender As Object, e As System.EventArgs) Handles txtRelease.Click
        lblMsg.Text = "Enter Release Number"
        EditActiveControl(Me)
    End Sub

    Private Sub txtTargetWt_Click(sender As Object, e As System.EventArgs) Handles txtTargetWt.Click
        lblMsg.Text = "Enter Target Weight"
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtRelease_TextChanged(sender As Object, e As EventArgs) Handles txtRelease.TextChanged

    End Sub

    Private Sub TankStatusTimer_Tick(sender As Object, e As EventArgs) Handles TankStatusTimer.Tick
        frmMain.GetTankInfo()
    End Sub
End Class