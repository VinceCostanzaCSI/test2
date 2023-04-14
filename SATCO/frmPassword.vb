Public Class frmPassword

    Private Sub frmPassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
    End Sub

    Private Sub txtPassword_Click(sender As Object, e As System.EventArgs) Handles txtPassword.Click
        HidePassword = True
        EditActiveControl(Me)
    End Sub

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged
        lblMsg.Text = ""
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Dim SysOptions As clsSystem

        SysOptions = New clsSystem
        If UCase(txtPassword.Text) = "TLH" Or UCase(txtPassword.Text) = "SCALE" Then
            Me.Close()
            frmTransactionProcessing.Close()
            frmMain.ToolStrip1.Visible = True
        Else
            Me.Close()
            frmCardID.MdiParent = frmMain
            frmCardID.Show()

        End If
        SysOptions = Nothing
    End Sub
End Class