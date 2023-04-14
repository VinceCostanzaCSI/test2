Public Class frmSplash

    Private Sub GroupBox1_Click(sender As Object, e As System.EventArgs) Handles GroupBox1.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As System.EventArgs) Handles txtProductName.Click
        Me.Close()
    End Sub

    Private Sub frmSplash_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtVersion.Text = "Version " & FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion
        txtProductName.Text = Application.ProductName
        CenterForm(Me)
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

End Class