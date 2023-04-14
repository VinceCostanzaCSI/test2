Public Class frmSA
    Private SQL As New SQLControl

    Private Sub frmSA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Process As clsProcess
        CenterForm(Me)

        ComboFill()

        AddLogEntry(" Clearing Code, Consignee, Destination")
        Process = New clsProcess
        Process.Code = ""
        Process.Consignee = ""
        Process.Destination = ""
        Process = Nothing
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        'AddLogEntry ("frmSA - BACK button hit")
        Me.Close()
        frmPin.MdiParent = frmMain
        frmPin.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'AddLogEntry ("frmSA - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Consignee As clsConsignee
        Dim Tank As clsTank
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim ActiveScale As Integer
        Dim MaterialType As Integer
        NSFLoad = False

        'AddLogEntry ("frmSA - NEXT button hit")
        SysOptions = New clsSystem
        Tank = New clsTank
        Consignee = New clsConsignee

        If Len(cboSAUC.Text) > 0 Then
            AddLogEntry("Find Consignee record - " & cboSAUC.Text)
            Consignee.FindRecord(cboSAUC.Text)
            If Consignee.EOF Then
                AddLogEntry("Consignee Record not found")
                lblMsg.Text = "Code not found !"
            Else
                AddLogEntry("Consignee Record found")
                ' ----- Warn if Code is not associated with this scale -----
                If SysOptions.ScaleNumber <> 1 And SysOptions.ScaleNumber <> 2 Then
                    AddLogEntry("frmSA - Scale ID has not been set")
                    MsgBox("The Scale ID has not been set !", vbOKOnly, "Scale Error")
                Else
                    AddLogEntry("frmSA - Active scale is " & Str(SysOptions.ScaleNumber))
                    ActiveScale = SysOptions.ScaleNumber - 1
                    If UCase(Mid(cboSAUC.Text, 1, 2)) = "SA" Then
                        AddLogEntry("Material Type is 0 (SA)")
                        MaterialType = 0
                    Else
                        AddLogEntry("Material Type is 1 (UC)")
                        MaterialType = 1
                    End If
                    'Check if limit is reached for SA code
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
                        Process.Code = cboSAUC.Text
                        Process.Consignee = Consignee.Consignee
                        Process.Destination = Consignee.Destination
                        Process.Seal1 = ""
                        Process.Seal2 = ""
                        Process.Seal3 = ""
                        Process.Seal4 = ""

                        Process = Nothing

                        If MaterialType = 0 And Consignee.NSF = True Then
                            NSFLoad = True
                        Else
                            NSFLoad = False
                        End If

                        Consignee = Nothing
                        Tank = Nothing
                        SysOptions = Nothing

                        AddLogEntry("Unloading frmSA")
                        Me.Close()
                        AddLogEntry("frmSA - Loading frmTargetWt")
                        frmTargetWt.MdiParent = frmMain
                        frmTargetWt.Show()
                    Else
                        If MaterialType = 0 Then
                            AddLogEntry("No SA Tank associated with this Scale")
                            MsgBox("No SA Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                            'Stop
                        Else
                            AddLogEntry("No UC Tank associated with this Scale")
                            MsgBox("No UC Tank has been assigned for Scale " & SysOptions.ScaleNumber & " !", vbOKOnly, "Assigment Error")
                        End If
                    End If
                End If
            End If
        Else
            AddLogEntry("Invalid Consignee code entered")
            lblMsg.Text = "Invalid Consignee Code entered !"
            cboSAUC.Text = ""
        End If
        Consignee = Nothing
        Tank = Nothing
        SysOptions = Nothing

    End Sub

    Private Sub ComboFill()
        If SQL.HasConnection = True Then
            SQL.RunQuery("SELECT * FROM Consignee WHERE Left(Code,2) = 'SA' And ACTIVE = '1' or Left(Code,2) = 'UC' And ACTIVE = '1'")
            If SQL.SQLDataset.Tables.Count > 0 Then
                For Each r As DataRow In SQL.SQLDataset.Tables(0).Rows
                    cboSAUC.Items.Add(r("Code"))
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

    Private Sub cboCode_Click(sender As Object, e As System.EventArgs) Handles cboSAUC.Click
        cboSAUC.DroppedDown = True
    End Sub

    Private Sub cboSAUC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSAUC.SelectedIndexChanged

    End Sub
End Class