Public Class frmBNRelease
    Private SQL As New SQLControl
    Public CommodityID As String

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

   

    Private Sub frmBNRelease_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        MosaicDriver = False
        txtRelease.Focus()
    End Sub

    Private Sub Validate_Commodity(Code As String)
        Dim Commodity As clsCommodity
        Dim Process As clsProcess
        Dim TmpCommodity As String = ""

        AddLogEntry("frmBNRelease - Validate button hit")
        Process = New clsProcess
        If UCase(Mid(Code, 2)) = "BN03" Then
            TmpCommodity = "BN03"
        Else
            'TmpCommodity = txtId.Text
        End If
        'Stop
        AddLogEntry("Commodity = " & TmpCommodity)
        Commodity = New clsCommodity
        If Len(TmpCommodity) > 0 Then
            AddLogEntry("Verifying Commodity " & TmpCommodity)
            If Commodity.FindRecord(TmpCommodity) = False Then
                AddLogEntry("Commodity " & TmpCommodity & " is NOT valid")
                lblMsg.Text = "Code not found !"
            Else
                AddLogEntry("Commodity " & TmpCommodity & " is VALID")
                AddLogEntry("Commodity Variable Wt = " & Commodity.VariableWt & "  ProcessWt = " & Process.TargetWt)
                If (Val(Process.TargetWt) - Val(Commodity.VariableWt)) > 0 Then
                    Process.DisplayTarget = Process.TargetWt
                    AddLogEntry("DisplayTarget = " & Process.DisplayTarget & "  Actual TargetWt = " & Process.TargetWt - Val(Commodity.VariableWt))
                    Process.TargetWt = Process.TargetWt - Val(Commodity.VariableWt)
                    CommodityID = Commodity.ID
                    Process.Description1 = Commodity.Description1
                    Process.Description2 = Commodity.Description2
                    Process.Description3 = Commodity.Description3
                    AddLogEntry("Unloading frmCommodity")
                    frmCommodity.Close()
                    If TmpCommodity <> "BN" Then
                        AddLogEntry("frmCommodity - Loading frmRelease")
                        frmRelease.MdiParent = frmMain
                        frmRelease.Show()
                    Else
                        AddLogEntry("frmCommodity - Loading frmTransactionProcessing")
                        frmTransactionProcessing.MdiParent = frmMain
                        frmTransactionProcessing.Show()
                    End If
                Else
                    AddLogEntry("Adjusted Target weight is below zero")
                    MsgBox("Target weight is below zero !", vbOKOnly, "Weight Error")
                End If
            End If
        Else
            AddLogEntry("INVALID Commodity")
            lblMsg.Text = "Invalid Commodity !"
            'cboCommodity.Text = ""
        End If
        Process = Nothing
        Commodity = Nothing

    End Sub

    Private Sub txtRelease_Click(sender As Object, e As System.EventArgs) Handles txtRelease.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtRelease_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRelease.TextChanged
        lblMsg.Text = ""
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Brenntag As clsBrenntag
        Dim Consignee As clsConsignee
        Dim Tank As clsTank
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Commodity As clsCommodity
        Dim ActiveScale As Integer
        Dim MaterialType As Integer

        If cmdNext.Text = "Validate" Then
            AddLogEntry("frmBNRelease - Validate button hit")
            'Check for valid Release number and fill in the blanks
            Brenntag = New clsBrenntag
            If Len(txtRelease.Text) > 0 Then
                AddLogEntry("Find Brenntag record - " & txtRelease.Text)
                If Brenntag.FindRecord(txtRelease.Text) = False Then
                    AddLogEntry("Brenntag Record not found")
                    lblMsg.Text = "Release # is not in the system !"
                Else
                    'Check to see if it is Active
                    If Brenntag.Active = False Then
                        AddLogEntry("Release # has already been loaded (is not active)")
                        lblMsg.Text = "Release # has already been loaded !"
                    Else
                        'Show Valid and show fields
                        lblRelease.Text = txtRelease.Text
                        lblPO.Text = Brenntag.PO
                        'lblBOL.Text = Brenntag.BOL
                        lblAltPO.Text = Brenntag.AltPO
                        lblName.Text = Brenntag.Name
                        lblDest1.Text = Brenntag.Address1
                        lblDest2.Text = Brenntag.CSZ
                        BrenntagPCName = Brenntag.PCName
                        lblPercent.Text = Brenntag.PC
                        If lblPercent.Text = "25" Then
                            Brenntag25 = True
                        Else
                            Brenntag25 = False
                        End If
                        lblConsignee.Text = "BN0001"
                        'Get Destination from Consignee table
                        Consignee = New clsConsignee
                        'AddLogEntry ("Find Consignee record - " & lblConsignee.Text)
                        Consignee.FindRecord(lblConsignee.Text)
                        If Consignee.EOF Then
                            AddLogEntry("Consignee Record not found")
                            lblMsg.Text = "Consignee not found !"
                        Else
                            AddLogEntry("Consignee Record found")
                            'lblDest1.Text = Consignee.Destination
                            'lblDest2.Text = Consignee.Destination2
                        End If
                        'Set Consignee = Nothing

                        BrenntagRelease = txtRelease.Text

                        GroupBox1.Visible = True
                        cmdNext.Text = "Next"
                        If Val(Brenntag.MaxLoad) > 0 And Val(Brenntag.MaxLoad) < 60000 Then
                            txtTargetWt.Text = Brenntag.MaxLoad
                            lblOrder.Text = "Brenntag Net Load:"
                            txtTargetWt.Visible = True
                            txtRelease.Visible = False
                            lblMsg.Text = "Press NEXT to Continue"
                            cmdNext.Focus()
                        ElseIf RailMode And Val(Brenntag.MaxLoad) > 0 And Val(Brenntag.MaxLoad) < 230000 Then
                            txtTargetWt.Text = Brenntag.MaxLoad
                            lblOrder.Text = "Brenntag Net Load:"
                            txtTargetWt.Visible = True
                            txtRelease.Visible = False
                            lblMsg.Text = "Press NEXT to Continue"
                            cmdNext.Focus()
                        Else
                            lblOrder.Text = "Net Load (lbs):"
                            txtTargetWt.Visible = True
                            txtRelease.Visible = False
                            txtTargetWt.Focus()
                        End If
                    End If
                End If
            End If
            Brenntag = Nothing
            Exit Sub
        End If
        If cmdNext.Text = "Next" Then
            'Get Target Weight
            AddLogEntry("frmBNRelease - NEXT button hit")
            SysOptions = New clsSystem
            Commodity = New clsCommodity
            Tank = New clsTank
            Process = New clsProcess
            If Len(txtTargetWt.Text) > 0 Then
                AddLogEntry("Validating Net Weight entered")

                BrenntagMaxLoad = SysOptions.MaxFillWeight


                If Val(txtTargetWt.Text) > Val(BrenntagMaxLoad) - 20000 Then
                    AddLogEntry("Target Weight entered exceeds maximum")
                    lblMsg.Text = "MAXIMUM FILL WEIGHT EXCEEDED !"
                Else
                    If Val(txtTargetWt.Text) > 0 Then
                        AddLogEntry("Target Weight is > 0 and < Maximum")
                        ' ----- Verify the tank has enough to complete the fill -----
                        AddLogEntry("Verify Tank contains enough product to complete fill")
                        ActiveScale = 1
                        MaterialType = 3
                        Tank.GetFillTank(ActiveScale, MaterialType)

                        Tank.FindRecord(Tank.Id)
                        AddLogEntry("Fill will come from TANK " & Tank.Id)
                        AddLogEntry("Target weight = " & txtTargetWt.Text / 2000 & " Tons and Current Tank Level = " & Tank.CurrentLevel)
                        If Tank.CurrentLevel > (Val(txtTargetWt.Text) / 2000) Then
                            AddLogEntry("Low Alarm value = " & Tank.LowAlarmValue & "  Current Tank Level = " & Tank.CurrentLevel)
                            Process.TargetWt = txtTargetWt.Text
                            If MaterialType = 3 Then Process.DisplayTarget = Process.TargetWt
                            'Stop
                            If Tank.CurrentLevel > Tank.LowAlarmValue Then
                                'Everything OK so far
                                cmdNext.Text = "Proceed"
                                lblMsg.Text = "Net Weight Confirmed"
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
                lblMsg.Text = "INVALID NET WEIGHT ENTERED !"
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
                    If SysOptions.ScaleNumber <> 1 And SysOptions.ScaleNumber <> 2 And RailMode = False Then
                        AddLogEntry("frmBNRelease - Scale ID has not been set")
                        MsgBox("The Scale ID has not been set !", vbOKOnly, "Scale Error")
                    Else
                        AddLogEntry("frmBNRelease - Active scale is " & Str(SysOptions.ScaleNumber))
                        ActiveScale = 1

                        If UCase(Mid(lblConsignee.Text, 1, 2)) = "BN" Then
                            AddLogEntry("Material Type is 3 (BN)")
                            MaterialType = 3
                        End If
                        'Check if limit is reached for Consignee
                        If Consignee.Limit <> 0 Then   'Ignore if Limit = 0
                            If Consignee.Limit - Consignee.Used < 0 Then
                                AddLogEntry("Consignee Limit exceeded")
                                MsgBox("Consignee Limit exceeded")
                                Exit Sub
                            End If
                        End If
                        If Len(Tank.GetFillTank(ActiveScale, MaterialType)) > 0 Then
                            Process = New clsProcess
                            Process.ReleaseNumber = txtRelease.Text
                            Process.Code = lblConsignee.Text
                            Process.Consignee = lblDest1.Text
                            Process.Destination = lblDest2.Text

                            '*** Now validate the Commodity ***
                            AddLogEntry("Commodity = " & lblProduct.Text)
                            Commodity = New clsCommodity
                            If Len(lblProduct.Text) > 0 Then
                                AddLogEntry("Verifying Commodity " & lblProduct.Text)
                                If Commodity.FindRecord("BN03") = False Then
                                    AddLogEntry("Commodity " & lblProduct.Text & " is NOT valid")
                                    lblMsg.Text = "Code not found !"
                                Else
                                    AddLogEntry("Commodity " & lblProduct.Text & " is VALID")
                                    AddLogEntry("Commodity Variable Wt = " & Commodity.VariableWt & "  ProcessWt = " & Process.TargetWt)
                                    Process.FreeFlow = Commodity.VariableWt
                                    If (Val(Process.TargetWt) - Val(Commodity.VariableWt)) > 0 Then
                                        Process.DisplayTarget = Process.TargetWt
                                        Process.Commodity = Commodity.ID
                                        If Brenntag25 = True Then
                                            Process.Description1 = "25% Caustic"
                                        Else
                                            Process.Description1 = Commodity.Description1
                                        End If
                                        Process.Description2 = Commodity.Description2
                                        Process.Description3 = Commodity.Description3
                                    Else
                                        AddLogEntry("Adjusted Target weight is below zero")
                                        MsgBox("Target weight is below zero !", vbOKOnly, "Weight Error")
                                    End If
                                End If
                            Else
                                AddLogEntry("INVALID Commodity")
                                lblMsg.Text = "Invalid Commodity !"
                                Exit Sub
                            End If

                            AddLogEntry("Unload frmBNRelease")
                            Me.Close()

                            AddLogEntry("frmBNRelease - Loading frmTrailer")
                            frmTrailer.MdiParent = frmMain
                            frmTrailer.Show()
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
                                MsgBox("No MO Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                            End If
                            If MaterialType = 3 Then
                                AddLogEntry("No BN Tank associated with this Scale")
                                MsgBox("No BN Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
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

    Private Sub txtTargetWt_Click(sender As Object, e As System.EventArgs) Handles txtTargetWt.Click
        EditActiveControlPad(Me)
    End Sub

End Class