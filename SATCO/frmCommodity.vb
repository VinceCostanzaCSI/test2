Public Class frmCommodity
    Private SQL As New SQLControl
    Dim CodeCommodity As String

    Private Sub frmCommodity_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim Process As clsProcess

        CenterForm(Me)

        'AddLogEntry ("frmCommodity_Load")
        Process = New clsProcess
        CodeCommodity = UCase(Mid(Process.Code, 1, 2))
        If CodeCommodity <> "SA" Then
            'AddLogEntry ("frmCommodity - Set Focus to cboCommodity")
            cboCommodity.Focus()
            ComboFill()
        End If
        'Process = Nothing
        'AddLogEntry ("Setting datacontrol database name and query")


        If CodeCommodity = "SA" Then
            cboCommodity.Visible = False
            txtCommodity.Top = 100
            txtCommodity.Text = "Sulfuric Acid"
            txtCommodity.Visible = True
        End If
        Process = Nothing




    End Sub

    Private Sub ComboFill()
        If SQL.HasConnection = True Then
            Dim CommType As Integer
            If CodeCommodity = "UC" Then CommType = 1
            If CodeCommodity = "MO" Then CommType = 2
            If CodeCommodity = "BN" Then CommType = 3
            SQL.RunQuery("SELECT * FROM COMMODITY WHERE CType = '" & CommType & "' AND ACTIVE = '1' ORDER BY ID")
            If SQL.RecordCount > 0 Then
                For Each r As DataRow In SQL.SQLDataset.Tables(0).Rows
                    cboCommodity.Items.Add(r("Description1"))
                Next

            ElseIf SQL.SQLDataset.HasErrors <> "" Then
                MsgBox("No Commodity found")
            End If
            'Stop
        Else
            MsgBox("No SQL Connection")
        End If

    End Sub

    Private Sub cboCommodity_Click(sender As Object, e As System.EventArgs) Handles cboCommodity.Click
        cboCommodity.DroppedDown = True
    End Sub

    Private Sub cboCommodity_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCommodity.SelectedIndexChanged
        Dim Commodity As clsCommodity
        Commodity = New clsCommodity
        If Commodity.Search("Description1", cboCommodity.Text) = True Then
            Commodity.FindRecord(Commodity.ID)
            txtID.Text = Commodity.ID
        End If
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        'AddLogEntry ("frmCommodity - BACK button hit")
        Me.Close()
        frmVehicle.MdiParent = frmMain
        frmVehicle.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Commodity As clsCommodity
        Dim Process As clsProcess
        Dim Tank As clsTank
        Dim TmpCommodity As String

        AddLogEntry("frmCommodity - NEXT button hit")
        Process = New clsProcess
        If CodeCommodity = "SA" Then
            TmpCommodity = CodeCommodity  '"SA"
        Else
            TmpCommodity = txtID.Text
        End If
        AddLogEntry("Commodity = " & TmpCommodity)
        Commodity = New clsCommodity
        If Len(TmpCommodity) > 0 Then
            AddLogEntry("Verifying Commodity " & TmpCommodity)
            If Commodity.FindRecord(TmpCommodity) = False Then
                AddLogEntry("Commodity " & TmpCommodity & " is NOT valid")
                lblMsg.Text = "Code not found !"
                'Stop
            Else
                AddLogEntry("Commodity " & TmpCommodity & " is VALID")
                AddLogEntry("Commodity Variable Wt = " & Commodity.VariableWt) ' & "  ProcessWt = " & Process.TargetWt)
                If (Val(Process.TargetWt) - Val(Commodity.VariableWt)) > 0 Then
                    Process.DisplayTarget = Process.TargetWt
                    'AddLogEntry("DisplayTarget = " & Process.DisplayTarget & "  Actual TargetWt = " & Process.TargetWt - Val(Commodity.VariableWt))
                    'Process.TargetWt = Process.TargetWt - Val(Commodity.VariableWt)
                    Process.Commodity = Commodity.ID
                    Process.FreeFlow = Commodity.VariableWt
                    Tank = New clsTank
                    If Mid(TmpCommodity, 1, 2) <> "SA" Then
                        Tank.GetFillTank(0, 1)
                        Tank.FindRecord(Tank.Id)
                        Dim tmpCommID As String = Tank.Commodity
                        Commodity.FindRecord(tmpCommID)
                        Process.Description1 = Commodity.Description1
                        Process.Description2 = Commodity.Description2
                        Process.Description3 = Commodity.Description3
                    Else
                        Tank.GetFillTank(0, 0)
                        Tank.FindRecord(Tank.Id)
                        Dim tmpCommID As String = Mid(TmpCommodity, 1, 2) & Tank.Id
                        Commodity.FindRecord(tmpCommID)
                        Process.Description1 = Commodity.Description1
                        Process.Description2 = Commodity.Description2
                        Process.Description3 = Commodity.Description3
                    End If
                    Tank = Nothing
                    AddLogEntry("Unloading frmCommodity")
                    'Stop
                    Me.Close()
                    If Mid(TmpCommodity, 1, 2) = "SA" Then
                        AddLogEntry("frmCommodity - Loading frmTransactionProcessing")
                        frmTransactionProcessing.MdiParent = frmMain
                        frmTransactionProcessing.Show() 'MODAL
                    Else
                        AddLogEntry("frmCommodity - Loading frmRelease")
                        frmRelease.MdiParent = frmMain
                        frmRelease.Show()
                    End If
                Else
                    AddLogEntry("Adjusted Target weight is below zero")
                    MsgBox("Target weight is below zero !", vbOKOnly, "Weight Error")
                End If
            End If
        Else
            AddLogEntry("INVALID Commodity")
            lblMsg.Text = "Invalid Commodity !"
            cboCommodity.Text = ""
        End If
        Process = Nothing
        Commodity = Nothing
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'AddLogEntry ("frmCommodity - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

End Class