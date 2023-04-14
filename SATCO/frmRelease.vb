Public Class frmRelease

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        'AddLogEntry ("frmRelease - BACK button hit")
        Me.Close()
        frmCommodity.MdiParent = frmMain
        frmCommodity.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess

        'AddLogEntry ("frmRelease - NEXT button hit")
        If Len(txtRelease.Text) > 0 Then
            Process = New clsProcess
            AddLogEntry("Release Number = " & txtRelease.Text)
            Process.ReleaseNumber = txtRelease.Text
            Process = Nothing
            'AddLogEntry ("Unload frmRelease")
            Me.Close()
            'AddLogEntry ("frmRelease - Loading frmTransaction Processing")
            frmTransactionProcessing.MdiParent = frmMain
            frmTransactionProcessing.Show()
        End If
    End Sub

    Private Sub frmRelease_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
    End Sub

    Private Sub txtRelease_Click(sender As Object, e As System.EventArgs) Handles txtRelease.Click
        EditActiveControl(Me)
    End Sub

End Class