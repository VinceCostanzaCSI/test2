Public Class frmTargetWt

    Private Sub frmTargetWt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
    End Sub

    Private Sub cmdBack_Click(sender As System.Object, e As System.EventArgs) Handles cmdBack.Click
        Dim Process As clsProcess
        AddLogEntry("frmTargetWt - BACK button hit")
        Try
            Process = New clsProcess
            Me.Close()

            If UCase(Mid(Process.Code, 1, 2)) = "SA" Or UCase(Mid(Process.Code, 1, 2)) = "UC" Then
                frmSA.MdiParent = frmMain
                frmSA.Show()
            End If

            If UCase(Mid(Process.Code, 1, 2)) = "MO" Then
                frmMO.MdiParent = frmMain
                frmMO.Show()
            End If
            Process = Nothing

        Catch ex As Exception
            AddLogEntry("frmTargetWt_cmdBack: " & ex.Message)
        End Try

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        AddLogEntry("frmTargetWt - CANCEL button hit")
        Me.Close()
        frmCardID.MdiParent = frmMain
        frmCardID.Show()
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim SysOptions As clsSystem
        Dim Carrier As clsCarrier
        Dim Tank As clsTank
        Dim Process As clsProcess
        Dim ActiveScale As Integer
        Dim MaterialType As Integer
        Dim MaxFill As Long
        Dim MinFill As Long
        Dim CarrierCheck As String

        Try
            AddLogEntry("frmTargetWt - NEXT button hit")
            SysOptions = New clsSystem
            'Commodity = New clsCommodity
            Tank = New clsTank
            Process = New clsProcess

            AddLogEntry("Validating Target Weight entered")
            If MosaicDriver = True Then
                MinFill = SysOptions.MOMinFillWeight
                MaxFill = SysOptions.MOMaxFillWeight
            Else
                CarrierCheck = Process.Carrier

                Carrier = New clsCarrier
                If Carrier.FindRecord(CarrierCheck) = True Then
                    AddLogEntry("Carrier MaxLoad set to: " & Carrier.MaxLoad)
                    CarrierMaxWeight = Carrier.MaxLoad
                    MinFill = SysOptions.MinFillWeight
                    MaxFill = CarrierMaxWeight
                Else
                    AddLogEntry("Carrier not found to get maxload. Setting Default = " & SysOptions.MaxFillWeight)
                    MinFill = SysOptions.MinFillWeight
                    MaxFill = SysOptions.MaxFillWeight
                End If
                Carrier = Nothing
            End If

            If Val(txtTargetWt.Text) < MinFill Then
                AddLogEntry("Target Weight entered is too Low: " & txtTargetWt.Text)
                lblMsg.Text = "FILL WEIGHT BELOW MINIMUM !"
                txtTargetWt.Text = ""
                Exit Sub
            End If

            If Val(txtTargetWt.Text) > MaxFill Then
                AddLogEntry("Target Weight entered exceeds maximum")
                lblMsg.Text = "MAXIMUM FILL WEIGHT EXCEEDED !"
                txtTargetWt.Text = ""
            Else
                If Val(txtTargetWt.Text) > 0 Then
                    AddLogEntry("Target Weight is > 0 and < Maximum")
                    ' ----- Verify the tank has enough to complete the fill -----
                    AddLogEntry("Verify Tank contains enough product to complete fill")
                    ActiveScale = SysOptions.ScaleNumber - 1
                    If UCase(Mid(Process.Code, 1, 2)) = "SA" Then MaterialType = 0
                    If UCase(Mid(Process.Code, 1, 2)) = "UC" Then MaterialType = 1
                    If UCase(Mid(Process.Code, 1, 2)) = "MO" Then MaterialType = 2
                    Tank.GetFillTank(ActiveScale, MaterialType)
                    Tank.FindRecord(Tank.Id)
                    AddLogEntry("Fill will come from TANK " & Tank.Id)
                    AddLogEntry("Target weight = " & txtTargetWt.Text / 2000 & "  Current Tank Level = " & Tank.CurrentLevel)
                    If Tank.CurrentLevel > (Val(txtTargetWt.Text) / 2000) Then
                        AddLogEntry("Low Alarm value = " & Tank.LowAlarmValue & "  Current Tank Level = " & Tank.CurrentLevel)
                        Process.TargetWt = txtTargetWt.Text
                        If MaterialType = 2 Then Process.DisplayTarget = Process.TargetWt
                        'Stop
                        If Tank.CurrentLevel > Tank.LowAlarmValue Then
                            AddLogEntry("Unload frmTargetWt")
                            Process = Nothing
                            Tank = Nothing
                            'Commodity = Nothing
                            SysOptions = Nothing
                            Me.Close()

                            If MosaicDriver = True Then
                                AddLogEntry("frmTargetWt - Loading frmMOCapacity")
                                frmMOCapacity.MdiParent = frmMain
                                frmMOCapacity.Show()
                            ElseIf BrenntagDriver = True Then
                                AddLogEntry("frmTargetWt - Loading frmTrailer")
                                frmTrailer.MdiParent = frmMain
                                frmTrailer.Show()
                            Else
                                AddLogEntry("frmTargetWt - Loading frmSACapacity")
                                frmSACapacity.MdiParent = frmMain
                                frmSACapacity.Show()
                            End If

                        Else
                            AddLogEntry("Unable to fill Tank is below Low Level Alarm")
                            MsgBox("Unable to fill !  Tank is below low alarm value !", vbOKOnly, "Target Wt Error")
                        End If
                    Else
                        AddLogEntry("Insufficient product to complete fill")
                        MsgBox("Insufficient quantity to complete fill !", vbOKOnly, "Target Wt Error")
                    End If
                Else
                    AddLogEntry("Target Weight entered is less then ZERO")
                    lblMsg.Text = "FILL WEIGHT LESS THEN ZERO !"
                End If
            End If

            Process = Nothing
            Tank = Nothing
            'Commodity = Nothing
            SysOptions = Nothing

        Catch ex As Exception
            AddLogEntry("frmTargetWt_cmdNext: " & ex.Message)
        End Try

    End Sub

    Private Sub txtTargetWt_Click(sender As Object, e As System.EventArgs) Handles txtTargetWt.Click
        EditActiveControlPad(Me)
    End Sub

End Class