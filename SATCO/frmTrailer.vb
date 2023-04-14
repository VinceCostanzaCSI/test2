Public Class frmTrailer

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        'AddLogEntry ("frmTrailer - BACK button hit")
        Me.Close()

        If MosaicDriver = True Then
            frmMOCapacity.MdiParent = frmMain
            frmMOCapacity.Show()
        ElseIf BrenntagDriver = True Then
            frmBNRelease.MdiParent = frmMain
            frmBNRelease.Show()
        Else
            frmSACapacity.MdiParent = frmMain
            frmSACapacity.Show()
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'AddLogEntry ("frmTrailer - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess

        'AddLogEntry ("frmTrailer - NEXT button hit")
        Process = New clsProcess
        AddLogEntry("Trailer Id = " & txtTrailerID.Text)
        If Len(txtTrailerID.Text) > 12 Then
            Process.Trailer = Mid(txtTrailerID.Text, 1, 12)
        Else
            Process.Trailer = txtTrailerID.Text
        End If

        Process = Nothing
        AddLogEntry("Unload frmTrailerID")
        Me.Close()
        AddLogEntry("frmTrailerId - Loading frmVehicle")
        frmVehicle.MdiParent = frmMain
        frmVehicle.Show()
    End Sub

    Private Sub frmTrailer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        If RailMode Then
            lblMsg.Text = "Enter Railcar Prefix"
            Label1.Text = "Prefix:"
        Else
            lblMsg.Text = "Enter Trailer ID"
            Label1.Text = "Trailer ID:"
        End If
    End Sub

    Private Sub txtTrailerID_Click(sender As Object, e As System.EventArgs) Handles txtTrailerID.Click
        EditActiveControl(Me)
    End Sub

End Class