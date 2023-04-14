Public Class frmPin

    Dim Driver As clsDriver
    Dim Consignee As clsConsignee
    Dim LoginCount As Integer

    Private Sub frmPin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            CenterForm(Me)
            LoginCount = 0
            AddLogEntry("frmPIN.LOAD")

            MosaicRelease = ""
            BrenntagRelease = ""
            txtPinNumber.Focus()

        Catch ex As Exception
            AddLogEntry("frmPIN.LOAD: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        'AddLogEntry ("frmPIN - NEXT button hit")
        Dim Process As clsProcess
        Dim DID As String
        Dim DPIN As String

        Try
            'Make sure driver exists to check on PIN number
            Process = New clsProcess
            Driver = New clsDriver
            AddLogEntry("Verifying Driver ID")
            Driver.FindRecord(Process.DriverId)
            If Driver.EOF = True Then
                AddLogEntry("Driver Not Found")
                lblMsg.Text = "Driver Not Found - Press Cancel"
            Else
                AddLogEntry("frmPIN - Driver Found")
            End If
            Process = Nothing
            DID = Driver.ID
            DPIN = Driver.PIN
            Driver = Nothing

            If UCase(txtPinNumber.Text) = UCase(DPIN) Then
                AddLogEntry("PIN validated: " & txtPinNumber.Text)

                If RailMode Then
                    Me.Close()
                    AddLogEntry("frmPIN - loading frmProduct")
                    frmProduct.MdiParent = frmMain
                    frmProduct.Show()
                Else
                    If InStr(DID, "MO") <> 0 Then   'Mosaic Driver
                        MosaicDriver = True
                        AddLogEntry("MosaicDriver = True")
                        Me.Close()
                        AddLogEntry("frmPIN - loading frmMO")
                        frmMO.MdiParent = frmMain
                        frmMO.Show()
                    ElseIf InStr(DID, "BT") <> 0 Then   'Brenntag Driver
                        'Check if switch is in Rail Mode

                        If Control.SARailReady = False Then
                            BrenntagDriver = True
                            AddLogEntry("BrenntagDriver = True but in Rail position")
                            lblMsg.Text = ADUResponse

                            Me.Close()
                            AddLogEntry("frmPIN - loading frmBNRail")
                            frmBNRail.MdiParent = frmMain
                            frmBNRail.Show()
                        Else
                            BrenntagDriver = True
                            AddLogEntry("BrenntagDriver = True")
                            lblMsg.Text = ADUResponse
                            Me.Close()
                            AddLogEntry("frmPIN - loading frmBNRelease")
                            frmBNRelease.MdiParent = frmMain
                            frmBNRelease.Show()
                        End If
                    Else
                        SADriver = True
                        AddLogEntry("frmPIN - Determining if Release Numbers are required")
                        Consignee = New clsConsignee
                        Consignee.FindRecord("SA00000")
                        If Consignee.Release = True And InStr(DID, "UC") = 0 Then
                            Me.Close()
                            SAReleaseRequired = True
                            AddLogEntry("frmPIN - loading frmSARelease")
                            frmSARelease.MdiParent = frmMain
                            frmSARelease.Show()
                        Else
                            Me.Close()
                            SAReleaseRequired = False
                            AddLogEntry("frmPIN - loading frmSA")
                            frmSA.MdiParent = frmMain
                            frmSA.Show()
                        End If

                    End If
                End If
            Else
                AddLogEntry("INVALID login")
                LoginCount = LoginCount + 1
                txtPinNumber.Text = ""
                lblMsg.Text = "INVALID PIN ENTERED !"
                AddLogEntry("Invalid PIN entered: " & txtPinNumber.Text)
                If LoginCount = 3 Then
                    cmdCancel.PerformClick()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            AddLogEntry("frmPIN_cmdNext: " & ex.Message)
        End Try

    End Sub

    Private Sub txtPinNumber_Click(sender As Object, e As System.EventArgs) Handles txtPinNumber.Click
        HidePassword = True
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtPinNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPinNumber.TextChanged
        lblMsg.Text = ""
    End Sub
End Class