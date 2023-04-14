Public Class frmSACapacity
    Private SQL As New SQLControl

    Private Sub frmSACapacity_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        'AddLogEntry ("frmBNCapacity_Load Set focus to txtCapacity")
        txtCapacity.Focus()
    End Sub

    Private Sub txtCapacity_Click(sender As Object, e As System.EventArgs) Handles txtCapacity.Click
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtCapacity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCapacity.TextChanged
        lblMsg.Text = ""
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        AddLogEntry("frmSACapacity - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        AddLogEntry("SACapacity - BACK button hit")
        If SAReleaseRequired = True Then
            Me.Close()
            frmSARelease.MdiParent = frmMain
            frmSARelease.Show()
        Else
            Me.Close()
            frmTargetWt.MdiParent = frmMain
            frmTargetWt.Show()
        End If

    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Consignee As clsConsignee
        Dim Lbs As Long

        'AddLogEntry ("frmSACapacity - NEXT button hit")
        Process = New clsProcess
        SysOptions = New clsSystem
        Consignee = New clsConsignee


        AddLogEntry("Capacity Entered: " & txtCapacity.Text & " gallons")
        If Val(txtCapacity.Text) < SysOptions.SACapacityMin Or Val(txtCapacity.Text) > SysOptions.SACapacityMax Then
            AddLogEntry("Capacity Entered is out of range")
            lblMsg.Text = "Capacity Entered is out of range"
            Process = Nothing
            Consignee = Nothing
            SysOptions = Nothing
            Exit Sub
        End If

        'Calculate Lbs from SA pounds per gallon
        Consignee.FindRecord(Process.Code)
        Lbs = Int(15.3 * Val(txtCapacity.Text))
        Lbs = Lbs - 3000
        AddLogEntry("Gallons per pound: 15.3")
        AddLogEntry("Minus 3000 safety range")
        AddLogEntry("Tank capacity calculated to: " & Lbs & " lbs.")
        Process.NetCapacity = Lbs

        Process = Nothing
        Consignee = Nothing
        SysOptions = Nothing

        AddLogEntry("Unload frmSACapacity")
        Me.Close()
        AddLogEntry("frmSACapacity - Loading frmTrailer")
        frmTrailer.MdiParent = frmMain
        frmTrailer.Show()

    End Sub
End Class