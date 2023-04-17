Public Class frmVehicle

    Private Sub frmVehicle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        If RailMode Then
            lblMsg.Text = "Enter Railcar Number"
            Label1.Text = "Car Number:"
            txtVehicleID.Tag = "Car Number"
        Else
            lblMsg.Text = "Enter Vehicle ID"
            Label1.Text = "Vehicle ID:"
            txtVehicleID.Tag = "Vehicle ID"
        End If
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        'AddLogEntry ("frmVehicle - BACK button hit")
        Me.Close()
        frmTrailer.MdiParent = frmMain
        frmTrailer.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'AddLogEntry ("frmVehicle - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess

        AddLogEntry("frmVehicle - NEXT button hit")
        Process = New clsProcess
        AddLogEntry("Vehicle ID = " & txtVehicleID.Text)
        If Len(txtVehicleID.Text) > 12 Then
            Process.Vehicle = Mid(txtVehicleID.Text, 1, 12)
        Else
            Process.Vehicle = txtVehicleID.Text
        End If

        Process = Nothing
        AddLogEntry("Unload frmVehicle")
        Me.Close()
        If RailMode Then
            AddLogEntry("frmVehicle - Loading frmSeal")
            frmSeal.MdiParent = frmMain
            frmSeal.Show()
        ElseIf MosaicDriver = True Then
            AddLogEntry("frmVehicle - Loading frmTransactionProcessing")
            frmTransactionProcessing.MdiParent = frmMain
            frmTransactionProcessing.Show()
        ElseIf BrenntagDriver = True Then
            AddLogEntry("frmVehicle - Loading frmSeal")
            frmSeal.MdiParent = frmMain
            frmSeal.Show()
        Else
            If NSFLoad = True Then
                AddLogEntry("frmVehicle - Loading frmSeal")
                frmSeal.MdiParent = frmMain
                frmSeal.Show()
            Else
                If SAReleaseRequired = True Then
                    AddLogEntry("frmVehicle - Loading frmTransactionProcessing")
                    frmTransactionProcessing.MdiParent = frmMain
                    frmTransactionProcessing.Show()
                Else
                    AddLogEntry("frmVehicle - Loading frmCommodity")
                    frmCommodity.MdiParent = frmMain
                    frmCommodity.Show()
                End If
            End If
        End If
    End Sub

    Private Sub txtVehicleID_Click(sender As Object, e As System.EventArgs) Handles txtVehicleID.Click
        EditActiveControl(Me)
    End Sub

End Class