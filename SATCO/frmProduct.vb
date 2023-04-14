Public Class frmProduct

    Dim Consignee As clsConsignee

    Private Sub frmProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CenterForm(Me)
            frmMain.ToolStrip1.Visible = False

            AddLogEntry("frmProduct.LOAD")

            SARelease = ""
            BrenntagRelease = ""

        Catch ex As Exception
            AddLogEntry("frmProduct.LOAD: " & ex.Message)
        End Try
    End Sub
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
        frmPassword.MdiParent = frmMain
        frmPassword.Show()
    End Sub

    Private Sub cmdSA_Click(sender As Object, e As EventArgs) Handles cmdSA.Click
        SADriver = True
        AddLogEntry("frmPIN - Determining if Release Numbers are required")
        Consignee = New clsConsignee
        Consignee.FindRecord("SA00000")
        Me.Close()
        SAReleaseRequired = True
        AddLogEntry("frmProduct - loading frmSARelease")
        frmSARelease.MdiParent = frmMain
        frmSARelease.Show()

    End Sub

    Private Sub cmdBN_Click(sender As Object, e As EventArgs) Handles cmdBN.Click
        BrenntagDriver = True
        AddLogEntry("BrenntagDriver = True")
        lblMsg.Text = ADUResponse
        Me.Close()
        AddLogEntry("frmProduct - loading frmBNRelease")
        frmBNRelease.MdiParent = frmMain
        frmBNRelease.Show()
    End Sub

End Class