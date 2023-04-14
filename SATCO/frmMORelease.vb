Public Class frmMORelease

    Private Sub frmMORelease_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        SADriver = False
        BrenntagDriver = False
        BrenntagSplit = False
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        Me.Close()
        frmMO.MdiParent = frmMain
        frmMO.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Mosaic As clsMosaic
        Dim Consignee As clsConsignee
        Dim Tank As clsTank
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Commodity As clsCommodity
        Dim ActiveScale As Integer
        Dim MaterialType As Integer

        If cmdNext.Text = "Validate" Then
            'AddLogEntry ("frmMORelease - Validate button hit")
            'Check for valid Release number and fill in the blanks
            Mosaic = New clsMosaic
            Process = New clsProcess
            If Len(txtRelease.Text) > 0 Then
                AddLogEntry("Find Mosaic record - " & txtRelease.Text)
                If Mosaic.FindRecord(txtRelease.Text) = False Then
                    AddLogEntry("Mosaic Record not found")
                    lblMsg.Text = "Release # not found !"
                Else
                    'Check to see if it is Active
                    If Mosaic.Active = False Then
                        AddLogEntry("Release # is not active")
                        lblMsg.Text = "Release # not Active !"
                    Else
                        'Show Valid and show fields
                        lblRelease.Text = txtRelease.Text
                        lblProduct.Text = Mosaic.Product
                        lblCode.Text = Process.Code

                        'Get Destination from Consignee (Consignee) table
                        Consignee = New clsConsignee
                        'AddLogEntry ("Find Consignee record - " & lblConsignee.text)
                        If Consignee.FindRecord(lblCode.Text) = False Then
                            AddLogEntry("Consignee Record not found")
                            lblMsg.Text = "Consignee not found !"
                        Else
                            'AddLogEntry ("Consignee Record found")
                            lblConsignee.Text = Consignee.Consignee
                            lblDest1.Text = Consignee.Destination
                            lblDest2.Text = Consignee.Destination2
                            lblMsg.Text = "Enter Target Weight"
                        End If

                        Consignee = Nothing

                        MosaicRelease = txtRelease.Text
                        GroupBox1.Visible = True
                        cmdNext.Text = "Next"
                        lblOrder.Text = "Target Weight:"
                        txtTargetWt.Visible = True
                        txtRelease.Visible = False
                        txtTargetWt.Focus()

                    End If
                End If
            End If

            Mosaic = Nothing
            Process = Nothing
            Exit Sub
            End If
            If cmdNext.Text = "Next" Then
                'Get Target Weight
                'AddLogEntry ("frmTargetWt - NEXT button hit")
                SysOptions = New clsSystem
                Commodity = New clsCommodity
                Tank = New clsTank
                Process = New clsProcess
                If Len(txtTargetWt.Text) > 0 Then
                    AddLogEntry("Validating Target Weight entered")
                    If Val(txtTargetWt.Text) > SysOptions.MaxFillWeight Then
                        AddLogEntry("Target Weight entered exceeds maximum")
                        lblMsg.Text = "MAXIMUM FILL WEIGHT EXCEEDED !"
                    Else
                        If Val(txtTargetWt.Text) > 0 Then
                            AddLogEntry("Target Weight is > 0 and < Maximum")
                            ' ----- Verify the tank has enough to complete the fill -----
                            AddLogEntry("Verify Tank contains enough product to complete fill")
                            ActiveScale = SysOptions.ScaleNumber - 1
                            MaterialType = 2
                            Tank.GetFillTank(ActiveScale, MaterialType)
                            Tank.FindRecord(Tank.Id)
                            AddLogEntry("Fill will come from TANK " & Tank.Id)
                            AddLogEntry("Target weight = " & txtTargetWt.Text / 2000 & "  Current Tank Level = " & Tank.CurrentLevel)
                            If Tank.CurrentLevel > (Val(txtTargetWt.Text) / 2000) Then
                                AddLogEntry("Low Alarm value = " & Tank.LowAlarmValue & "  Current Tank Level = " & Tank.CurrentLevel)
                                Process.TargetWt = txtTargetWt.Text
                                If MaterialType = 2 Then Process.DisplayTarget = Process.TargetWt
                                'Stop
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
                'Check Commodity and proceed to Trailer form
                If Len(lblConsignee.Text) > 0 Then
                    SysOptions = New clsSystem
                    Tank = New clsTank
                    Consignee = New clsConsignee
                    AddLogEntry("Find Consignee record - " & lblConsignee.Text)
                    Consignee.FindRecord(lblConsignee.Text)
                    If Consignee.EOF Then
                        AddLogEntry("Consignee Record not found")
                        lblMsg.Text = "Code not found !"
                    Else
                        AddLogEntry("Consignee Record found")
                        ' ----- Warn if Code is not associated with this scale -----
                        If SysOptions.ScaleNumber <> 1 And SysOptions.ScaleNumber <> 2 Then
                            AddLogEntry("frmMORelease - Scale ID has not been set")
                            MsgBox("The Scale ID has not been set !", vbOKOnly, "Scale Error")
                        Else
                            AddLogEntry("frmMORelease - Active scale is " & Str(SysOptions.ScaleNumber))
                            ActiveScale = SysOptions.ScaleNumber - 1
                            If UCase(Mid(lblConsignee.Text, 1, 2)) = "SA" Then
                                AddLogEntry("Material Type is 0 (SA)")
                                MaterialType = 0
                        End If
                            If UCase(Mid(lblConsignee.Text, 1, 2)) = "UC" Then
                                AddLogEntry("Material Type is 1 (UC)")
                                MaterialType = 1
                            End If
                            If UCase(Mid(lblConsignee.Text, 1, 2)) = "MO" Then
                                AddLogEntry("Material Type is 2 (MO)")
                                MaterialType = 2
                            End If
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

                            '*** Now validate the Commodity ***
                            AddLogEntry("Commodity = " & lblProduct.Text)
                            Commodity = New clsCommodity
                            If Len(lblProduct.Text) > 0 Then
                                AddLogEntry("Verifying Commodity " & lblProduct.Text)
                                If Commodity.FindRecord(lblProduct.Text) = False Then
                                    AddLogEntry("Commodity " & lblProduct.Text & " is NOT valid")
                                    lblMsg.Text = "Code not found !"
                                Else
                                    AddLogEntry("Commodity " & lblProduct.Text & " is VALID")
                                    AddLogEntry("Commodity Variable Wt = " & Commodity.VariableWt & "  ProcessWt = " & Process.TargetWt)
                                    If (Val(Process.TargetWt) - Val(Commodity.VariableWt)) > 0 Then
                                        Process.DisplayTarget = Process.TargetWt
                                        AddLogEntry("DisplayTarget = " & Process.DisplayTarget & "  Actual TargetWt = " & Process.TargetWt - Val(Commodity.VariableWt))
                                        Process.TargetWt = Process.TargetWt - Val(Commodity.VariableWt)
                                        Process.Commodity = Commodity.ID
                                        Process.Description1 = Commodity.Description1
                                        Process.Description2 = Commodity.Description2
                                        Process.Description3 = "" 'lblPO.Text
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

                            AddLogEntry("Unload frmRelease")
                            Me.Close()
                            AddLogEntry("frmMORelease - Loading frmMOCapacity")
                            frmMOCapacity.MdiParent = frmMain
                            frmMOCapacity.Show()
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

End Class