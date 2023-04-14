Public Class frmMOCapacity
    Private SQL As New SQLControl

    Private Sub frmMOCapacity_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
       
    End Sub

    Private Sub txtCapacity_Click(sender As Object, e As System.EventArgs) Handles txtCapacity.Click
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtCapacity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCapacity.TextChanged
        lblMsg.Text = ""
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        AddLogEntry("frmMOCapacity - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        AddLogEntry("MOCapacity - BACK button hit")
        Me.Close()
        If MosaicRelease = "" Then
            frmTargetWt.MdiParent = frmMain
            frmTargetWt.Show()
        Else
            frmMORelease.MdiParent = frmMain
            frmMORelease.Show()
        End If

    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess
        Dim SysOptions As clsSystem
        Dim Lbs As Long

        'AddLogEntry ("frmMOCapacity - NEXT button hit")
        Process = New clsProcess
        SysOptions = New clsSystem

        AddLogEntry("Capacity Entered: " & txtCapacity.Text & " gallons")
        If Val(txtCapacity.Text) < SysOptions.MOCapacityMin Or Val(txtCapacity.Text) > SysOptions.MOCapacityMax Then
            AddLogEntry("Capacity Entered is out of range")
            lblMsg.Text = "Capacity Entered is out of range"
            Process = Nothing
            'Mosaic = Nothing
            SysOptions = Nothing
            Exit Sub
        End If
        'Calculate Lbs from Mosaic pounds per gallon
        'Read from database for MosaicCOA
        SysOptions.GetCurrentRecord()

        Lbs = Int(Val(SysOptions.MOppg) * Val(txtCapacity.Text))
        'Put in safety amount here
        Lbs = Lbs - 3000
        AddLogEntry("Gallons per pound: " & SysOptions.MOppg)
        AddLogEntry("Minus 3000 safety range")
        AddLogEntry("Tank capacity calculated to: " & Lbs & " lbs.")
        Process.MOCapacity = Lbs

        Process = Nothing
        SysOptions = Nothing

        AddLogEntry("Unload frmMOCapacity")
        Me.Close()

        AddLogEntry("frmMOCapacity - Loading frmTrailer")
        frmTrailer.MdiParent = frmMain
        frmTrailer.Show()

    End Sub
End Class