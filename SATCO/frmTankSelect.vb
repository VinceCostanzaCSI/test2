Public Class frmTankSelect
    Dim Tank1Analysis As String
    Dim Tank2Analysis As String
    Dim Tank5Analysis As String

    Private Sub frmTankSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterForm(Me)
        Me.Top = Top

        LoadTimer.Enabled = True
    End Sub

    Private Sub LoadTimer_Tick(sender As Object, e As EventArgs) Handles LoadTimer.Tick
        LoadTimer.Enabled = False
        Dim Commodity As clsCommodity

        Try
            'ADU Control
            aduhandle = OpenAduDeviceBySerialNumber(TankSelectSN, 1)
            If aduhandle = -1 Then
                MsgBox("Problem communicating with Tank Select Controls. " & vbCrLf & "  Please contact a SATCO Representative.")
                TankSelectForm = True
                Me.Close()
                Exit Sub
            End If

            lblTank.Text = RequestedTank
            lblSelTank.Text = SelectedTank

            'Get Analysis of tanks
            Commodity = New clsCommodity

            If Commodity.FindRecord("SA01") = True Then
                Tank1Analysis = Commodity.Description2
            End If

            If Commodity.FindRecord("SA02") = True Then
                Tank2Analysis = Commodity.Description2
            End If

            If Commodity.FindRecord("SA05") = True Then
                Tank5Analysis = Commodity.Description2
            End If

            If Commodity.FindRecord("SA" & RequestedTank) = True Then
                lblAnalysis1.Text = Commodity.Description2
            End If

            If Commodity.FindRecord("SA" & SelectedTank) = True Then
                lblAnalysis2.Text = Commodity.Description2
            End If

            'Control ADU to desired Tank
            Select Case Val(RequestedTank)
                Case 1
                    Tank1Select()
                Case 2
                    Tank2Select()
                Case 5
                    Tank5Select()
            End Select



            'Now get status
            StatusTimer.Enabled = True

        Catch ex As Exception
            AddLogEntry("OpenADU: " & ex.Message)
        End Try

    End Sub

    Private Sub Tank1Select()
        Control.SetTank1()
        cmdTank1.Text = "On"
        cmdTank2.Text = "Off"
        cmdTank5.Text = "Off"
    End Sub

    Private Sub Tank2Select()
        Control.SetTank2()
        cmdTank2.Text = "On"
        cmdTank1.Text = "Off"
        cmdTank5.Text = "Off"
    End Sub

    Private Sub Tank5Select()
        Control.SetTank5()
        cmdTank5.Text = "On"
        cmdTank1.Text = "Off"
        cmdTank2.Text = "Off"
    End Sub
    Private Sub GetTankInput()
        Dim WhitePen As Pen
        WhitePen = New Pen(Drawing.Color.White, 12)
        Dim GreenPen As Pen
        GreenPen = New Pen(Drawing.Color.Green, 12)
        'Draw status circles in Tank Select groupbox
        Dim BlackPen As Pen
        BlackPen = New Pen(Drawing.Color.Black, 2)

        Dim myGraphics As Graphics = Me.grpTankStatus.CreateGraphics

        myGraphics.DrawEllipse(BlackPen, 30, 184, 26, 26)
        myGraphics.DrawEllipse(BlackPen, 30, 222, 26, 26)
        myGraphics.DrawEllipse(BlackPen, 30, 260, 26, 26)

        If Control.Tank1Ready = True Then
            myGraphics.DrawEllipse(WhitePen, 37, 190, 12, 12)
        Else
            myGraphics.DrawEllipse(GreenPen, 37, 190, 12, 12)
            SelectedTank = "01"
            lblSelTank.Text = "01"
            lblAnalysis2.Text = Tank1Analysis
        End If
        If Control.Tank2Ready = True Then
            myGraphics.DrawEllipse(WhitePen, 37, 228, 12, 12)
        Else
            myGraphics.DrawEllipse(GreenPen, 37, 228, 12, 12)
            SelectedTank = "02"
            lblSelTank.Text = "02"
            lblAnalysis2.Text = Tank2Analysis
        End If
        If Control.Tank5Ready = True Then
            myGraphics.DrawEllipse(WhitePen, 37, 266, 12, 12)
        Else
            myGraphics.DrawEllipse(GreenPen, 37, 266, 12, 12)
            SelectedTank = "05"
            lblSelTank.Text = "05"
            lblAnalysis2.Text = Tank5Analysis
        End If
    End Sub

    Private Sub StatusTimer_Tick(sender As Object, e As EventArgs) Handles StatusTimer.Tick
        GetTankInput()
        If RequestedTank = SelectedTank Then
            StatusTimer.Enabled = False
            Dim Tank As clsTank
            Tank = New clsTank
            Tank.SetSATank(SelectedTank)
            Delay(4000)
            TankSelectForm = True
            Me.Close()
        End If
    End Sub
    Private Sub cmdTank1_Click(sender As Object, e As EventArgs) Handles cmdTank1.Click
        Tank1Select()
    End Sub

    Private Sub cmdTank2_Click(sender As Object, e As EventArgs) Handles cmdTank2.Click
        Tank2Select()
    End Sub

    Private Sub cmdTank5_Click(sender As Object, e As EventArgs) Handles cmdTank5.Click
        Tank5Select()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        TankSelectForm = True
        Me.Close()
    End Sub

End Class