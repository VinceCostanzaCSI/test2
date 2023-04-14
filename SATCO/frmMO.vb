Public Class frmMO
    Private SQL As New SQLControl

    Private Sub frmMO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Process As clsProcess
        CenterForm(Me)

        ComboFill()

        AddLogEntry(" Clearing MO, Consignee, Destination")
        Process = New clsProcess
        Process.Code = ""
        Process.Consignee = ""
        Process.Destination = ""
        Process = Nothing
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        'AddLogEntry ("frmMO - BACK button hit")
        Me.Close()
        frmPin.MdiParent = frmMain
        frmPin.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'AddLogEntry ("frmMO - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Consignee As clsConsignee
        Dim Tank As clsTank
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Commodity As clsCommodity
        Dim ActiveScale As Integer
        Dim MaterialType As Integer
        Dim TmpCommodity As String
        NSFLoad = False

        'AddLogEntry ("frmMO - NEXT button hit")
        SysOptions = New clsSystem
        Tank = New clsTank
        Consignee = New clsConsignee
        If Len(cboMO.Text) > 0 Then
            AddLogEntry("Find Consignee record - " & cboMO.Text)
            Consignee.FindRecord(cboMO.Text)
            If Consignee.EOF Then
                AddLogEntry("Consignee Record not found")
                lblMsg.Text = "Code not found !"
            Else
                AddLogEntry("Consignee Record found")
                ' ----- Warn if Code is not associated with this scale -----
                If SysOptions.ScaleNumber <> 1 And SysOptions.ScaleNumber <> 2 Then
                    AddLogEntry("frmMO - Scale ID has not been set")
                    MsgBox("The Scale ID has not been set !", vbOKOnly, "Scale Error")
                Else
                    AddLogEntry("frmMO - Active scale is " & Str(SysOptions.ScaleNumber))
                    ActiveScale = SysOptions.ScaleNumber - 1
                    If UCase(Mid(cboMO.Text, 1, 2)) = "MO" Then
                        AddLogEntry("Material Type is 2 (MO)")
                        MaterialType = 2
                    Else
                        AddLogEntry("Material Type is 1 (UC)")
                        MaterialType = 1
                    End If
                    'Check if limit is reached for MO code
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
                        'AddLogEntry ("frmMO - Tank has an associated Material")
                        Process = New clsProcess
                        'AddLogEntry ("frmMO - Set MO = " & cboCode.Text & "  Consignee = " & Consignee.Consignee & "  Destination = " & Consignee.Destination)
                        Process.Code = cboMO.Text
                        TmpCommodity = "MO04"
                        Process.Commodity = "MO04"
                        Process.Consignee = Consignee.Consignee
                        Process.Destination = Consignee.Destination
                        Commodity = New clsCommodity
                        AddLogEntry("Verifying Commodity " & TmpCommodity)
                        If Commodity.FindRecord(TmpCommodity) = False Then
                            AddLogEntry("Commodity " & TmpCommodity & " is NOT valid")
                            lblMsg.Text = "Code not found !"
                            'Stop
                        Else
                            AddLogEntry("Commodity " & TmpCommodity & " is VALID")
                            AddLogEntry("Commodity Variable Wt = " & Commodity.VariableWt & "  ProcessWt = " & Process.TargetWt)
                            'If (Val(Process.TargetWt) - Val(Commodity.VariableWt)) > 0 Then
                            '    Process.DisplayTarget = Process.TargetWt
                            '    AddLogEntry("DisplayTarget = " & Process.DisplayTarget & "  Actual TargetWt = " & Process.TargetWt - Val(Commodity.VariableWt))
                            '    Process.TargetWt = Process.TargetWt - Val(Commodity.VariableWt)
                            '    Process.Commodity = Commodity.ID
                            'End If
                        End If
                        Process.FreeFlow = Commodity.VariableWt
                        AddLogEntry("Free Flow value is set to: " & Commodity.VariableWt)
                        Process.Description1 = Commodity.Description1
                        Process.Seal1 = ""
                        Process.Seal2 = ""
                        Process.Seal3 = ""
                        Process.Seal4 = ""
                        Process = Nothing
                        Commodity = Nothing
                        AddLogEntry("Unloading frmMO")
                        Me.Close()
                        'If MaterialType = 0 And Consignee.NSF = True Then
                        '    NSFLoad = True
                        '    AddLogEntry("frmSA - Loading frmSeal")
                        '    frmSeal.MdiParent = frmMain
                        '    frmSeal.Show()
                        'Else
                        If Consignee.Release = True Then
                            AddLogEntry("frmMO - Loading frmMORelease")
                            frmMORelease.MdiParent = frmMain
                            frmMORelease.Show()
                        Else
                            AddLogEntry("frmMO - Loading frmTargetWt")
                            frmTargetWt.MdiParent = frmMain
                            frmTargetWt.Show()
                        End If

                        'End If
                    Else
                        If MaterialType = 2 Then
                            AddLogEntry("No Mosaic Tank associated with this Scale")
                            MsgBox("No Mosaic Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                            'Stop
                        Else
                            AddLogEntry("No UC Tank associated with this Scale")
                            MsgBox("No UC Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                        End If
                    End If
                End If
            End If
        Else
            AddLogEntry("Invalid MO code entered")
            lblMsg.Text = "Invalid MO Code entered !"
            cboMO.Text = ""
        End If
        Consignee = Nothing
        Tank = Nothing
        SysOptions = Nothing

    End Sub

    Private Sub ComboFill()
        If SQL.HasConnection = True Then

            SQL.RunQuery("SELECT * FROM Consignee WHERE Left(Code,2) = 'MO' And ACTIVE = '1'")
            If SQL.SQLDataset.Tables.Count > 0 Then
                For Each r As DataRow In SQL.SQLDataset.Tables(0).Rows
                    cboMO.Items.Add(r("Code"))
                Next
                'Set the ComboBox to the first Record
                'cbIssue.SelectedIndex = 0
            ElseIf SQL.SQLDataset.HasErrors <> "" Then
                MsgBox(SQL.SQLDataset.HasErrors)
            End If

        Else
            MsgBox("No Connection")
        End If

    End Sub

    Private Sub cboCode_Click(sender As Object, e As System.EventArgs) Handles cboMO.Click
        cboMO.DroppedDown = True
    End Sub

End Class