Public Class frmBNCapacity
    Private SQL As New SQLControl

    Private Sub frmBNCapacity_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        'AddLogEntry ("frmBNCapacity_Load Set focus to txtCapacity")
        txtCapacity.Focus()
        optSplitNo.Checked = True 'default as Split Load = No
        BrenntagSplit = False
    End Sub

    Private Sub optSplitNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSplitNo.CheckedChanged
        If optSplitNo.Checked = True Then
            BrenntagSplit = False
            txtCapacity.Tag = "Trailer Capacity"
        Else
            BrenntagSplit = True
            txtCapacity.Tag = "Compartment Capacity to be Loaded"
        End If
    End Sub

    Private Sub txtCapacity_Click(sender As Object, e As System.EventArgs) Handles txtCapacity.Click
        EditActiveControlPad(Me)

    End Sub

    Private Sub txtCapacity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCapacity.TextChanged
        lblMsg.Text = ""
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        AddLogEntry("frmBNCapacity - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        AddLogEntry("BNCapacity - BACK button hit")
        Me.Close()
        frmSeal.MdiParent = frmMain
        frmSeal.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Brenntag As clsBrenntag
        Dim Lbs As Long

        'AddLogEntry ("frmBNCapacity - NEXT button hit")
        Process = New clsProcess
        SysOptions = New clsSystem
        Brenntag = New clsBrenntag

        If BrenntagSplit = True Then
            AddLogEntry("This is a SPLIT LOAD")
        Else
            AddLogEntry("This is not a split load")
        End If
        AddLogEntry("Capacity Entered: " & txtCapacity.Text & " gallons")
        If Val(txtCapacity.Text) < SysOptions.BNCapacityMin Or Val(txtCapacity.Text) > SysOptions.BNCapacityMax Then
            AddLogEntry("Capacity Entered is out of range")
            lblMsg.Text = "Capacity Entered is out of range"
            Process = Nothing
            Brenntag = Nothing
            SysOptions = Nothing
            Exit Sub
        End If
        'Calculate Lbs from Brenntag pounds per gallon
        'Read from database for BrenntagCOA
        SysOptions.GetCurrentRecord()

        Brenntag.FindRecord(Process.ReleaseNumber)
        If Brenntag25 Then
            Lbs = Int(Val(SysOptions.BTppg) * Val(txtCapacity.Text))  'Calculate 25% pounds per gallon
            AddLogEntry("Gallons per pound: " & SysOptions.BTppg)
        Else
            Lbs = Int(Val(SysOptions.BNppg) * Val(txtCapacity.Text)) 'Calculate 50% pounds per gallon 
            AddLogEntry("Gallons per pound: " & SysOptions.BNppg)
        End If
        Lbs = Lbs - 3000
        AddLogEntry("Minus 3000 safety range")
        AddLogEntry("Tank capacity calculated to: " & Lbs & " lbs.")

        Process.NetCapacity = Lbs

        Process = Nothing
        Brenntag = Nothing
        SysOptions = Nothing

        AddLogEntry("Unload frmBNCapacity")
        Me.Close()
        'AddLogEntry ("frmBNCapacity - Loading frmTransactionProcess")
        frmTransactionProcessing.MdiParent = frmMain
        frmTransactionProcessing.Show()
    End Sub

End Class