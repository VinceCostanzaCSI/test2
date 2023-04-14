Public Class frmBNRail

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
        'Skip if doing Demo tests
        'frmBNRelease.MdiParent = frmMain
        'frmBNRelease.Show()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()

    End Sub

    Private Sub frmBNRail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)

    End Sub
End Class