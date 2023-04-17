Public Class frmSeal

    Private Sub frmSeal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        AddLogEntry("frmSeal - BACK button hit")
        Me.Close()
        If RailMode Then
            AddLogEntry("frmSeal - Loading frmVehicle")
            frmVehicle.MdiParent = frmMain
            frmVehicle.Show()
        Else
            If MosaicDriver = True Then
                AddLogEntry("frmSeal - Loading frmMO")
                frmMO.MdiParent = frmMain
                frmMO.Show()

            ElseIf BrenntagDriver = True Then
                AddLogEntry("frmSeal - Loading frmVehicle")
                frmVehicle.MdiParent = frmMain
                frmVehicle.Show()
            Else
                AddLogEntry("frmSeal - Loading frmSACapacity")
                frmTrailer.MdiParent = frmMain
                frmTrailer.Show()
            End If
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        AddLogEntry("frmSeal - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess

        Try
            If RailMode Then
                If txtSeal1.Text = "" Or txtSeal2.Text = "" Or txtSeal3.Text = "" Or txtSeal4.Text = "" Then
                    MsgBox("Please enter all Seal values")
                    Exit Sub
                End If
            End If
            If txtSeal1.Text = "" Or txtSeal2.Text = "" Then
                MsgBox("Please enter Seal 1 and Seal 2 values")
                Exit Sub
            End If
            AddLogEntry("frmSeal - NEXT button hit")
            Process = New clsProcess

            'Clear out Seal numbers to start
            Process.Seal1 = ""
            Process.Seal2 = ""
            Process.Seal3 = ""
            Process.Seal4 = ""

            AddLogEntry("Seal1 = " & txtSeal1.Text)
            AddLogEntry("Seal2 = " & txtSeal2.Text)
            AddLogEntry("Seal3 = " & txtSeal3.Text)
            AddLogEntry("Seal4 = " & txtSeal4.Text)
            If txtSeal1.Text <> "" Then
                txtSeal1.Text = Replace(txtSeal1.Text, "/", "")
                If Len(txtSeal1.Text) > 12 Then
                    Process.Seal1 = Mid(txtSeal1.Text, 1, 12)  'truncate if too long
                Else
                    Process.Seal1 = txtSeal1.Text
                End If
            End If

            If txtSeal2.Text <> "" Then
                txtSeal2.Text = Replace(txtSeal2.Text, "/", "")
                If Len(txtSeal2.Text) > 12 Then
                    Process.Seal2 = Mid(txtSeal2.Text, 1, 12)  'truncate if too long
                Else
                    Process.Seal2 = txtSeal2.Text
                End If
            End If

            If txtSeal3.Text <> "" Then
                txtSeal3.Text = Replace(txtSeal3.Text, "/", "")
                If Len(txtSeal3.Text) > 12 Then
                    Process.Seal3 = Mid(txtSeal3.Text, 1, 12)  'truncate if too long
                Else
                    Process.Seal3 = txtSeal3.Text
                End If
            End If

            If txtSeal4.Text <> "" Then
                txtSeal4.Text = Replace(txtSeal4.Text, "/", "")
                If Len(txtSeal4.Text) > 12 Then
                    Process.Seal4 = Mid(txtSeal4.Text, 1, 12)  'truncate if too long
                Else
                    Process.Seal4 = txtSeal4.Text
                End If
            End If

            AddLogEntry("Process.Seal1 = " & Process.Seal1)
            AddLogEntry("Process.Seal2 = " & Process.Seal2)
            AddLogEntry("Process.Seal3 = " & Process.Seal3)
            AddLogEntry("Process.Seal4 = " & Process.Seal4)
            Process = Nothing
            AddLogEntry("Unload frmSeal")
            Me.Close()
            If RailMode Then
                AddLogEntry("frmSeal - Loading frmTransactionProcessing")
                frmTransactionProcessing.MdiParent = frmMain
                frmTransactionProcessing.Show()
            Else
                If MosaicDriver = True Then
                    AddLogEntry("frmSeal - Loading frmMOCapacity")
                    frmMOCapacity.MdiParent = frmMain
                    frmMOCapacity.Show()
                ElseIf BrenntagDriver = True Then
                    AddLogEntry("frmSeal - Loading frmBNCapacity")
                    frmBNCapacity.MdiParent = frmMain
                    frmBNCapacity.Show()
                Else
                    If SAReleaseRequired = True Then
                        AddLogEntry("frmSeal - Loading frmTransactionProcessing")
                        frmTransactionProcessing.MdiParent = frmMain
                        frmTransactionProcessing.Show()
                    Else
                        AddLogEntry("frmSeal - Loading frmCommodity")
                        frmCommodity.MdiParent = frmMain
                        frmCommodity.Show()
                    End If

                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSeal1_Click(sender As Object, e As System.EventArgs) Handles txtSeal1.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtSeal1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSeal1.TextChanged

    End Sub

    Private Sub txtSeal2_Click(sender As Object, e As System.EventArgs) Handles txtSeal2.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtSeal2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSeal2.TextChanged

    End Sub

    Private Sub txtSeal3_Click(sender As Object, e As System.EventArgs) Handles txtSeal3.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtSeal3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSeal3.TextChanged

    End Sub

    Private Sub txtSeal4_Click(sender As Object, e As System.EventArgs) Handles txtSeal4.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtSeal4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSeal4.TextChanged

    End Sub
End Class