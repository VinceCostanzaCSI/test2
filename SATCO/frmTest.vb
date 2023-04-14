Imports System.IO

Public Class frmTest
    Dim ScaleWeight1 As Double

    Private Sub frmTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        Me.Top = Top - 100
        LoadTimer.Enabled = True

    End Sub
    Private Sub LoadTimer_Tick(sender As Object, e As EventArgs) Handles LoadTimer.Tick
        Try
            LoadTimer.Enabled = False

            'SetupCircles()

            SetupCom()
            Scale1Check.Enabled = True

            'ADU Control
            aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)
            StatusTimer.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        If ScaleCom.IsOpen Then
            AddLogEntry("Closing Scale Serial port ")
            ScaleCom.Close()
        End If
        Me.Close()
    End Sub

    Private Sub SetupCom()
        Dim SysOptions = New clsSystem
        Try
            AddLogEntry("Setting up Scale Serial port")
            If SysOptions.ScaleActive = 1 Then

                'Monitor AccessCom port for activity
                Dim Card As String = SysOptions.ScaleSettings
                Dim parts As String() = Card.Split(","c)

                'First determining that port exists
                AddLogEntry("First determining that port exists")
                Dim portNMs() As String = IO.Ports.SerialPort.GetPortNames
                If Not portNMs.Contains(parts(0)) Then
                    AddLogEntry("Scale Serial port: " & parts(0) & " does not exist")
                Else
                    If ScaleCom.IsOpen Then
                        AddLogEntry("Scale Serial port is already open - close it first")
                        ScaleCom.Close()
                    End If
                End If

                ScaleCom.PortName = parts(0)
                ScaleCom.BaudRate = parts(1)
                Select Case parts(2)
                    Case "N"
                        ScaleCom.Parity = Ports.Parity.None
                    Case "E"
                        ScaleCom.Parity = Ports.Parity.Even
                    Case "O"
                        ScaleCom.Parity = Ports.Parity.Odd
                    Case "S"
                        ScaleCom.Parity = Ports.Parity.Space
                    Case "M"
                        ScaleCom.Parity = Ports.Parity.Mark
                End Select

                ScaleCom.DataBits = parts(3)

                Select Case parts(4)
                    Case 1
                        ScaleCom.StopBits = Ports.StopBits.One
                    Case 2
                        ScaleCom.StopBits = Ports.StopBits.Two
                    Case Else
                        ScaleCom.StopBits = Ports.StopBits.One
                End Select

                AddLogEntry("Now opening Scale Serial port: " & ScaleCom.PortName)
                ScaleCom.Open()

            End If
            SysOptions = Nothing
        Catch ex As Exception
            Status.Text = ex.Message
            AddLogEntry("SetupCom: " & ex.Message)
        End Try

    End Sub

    Private Sub SetupCircles()
        Dim WhitePen As Pen
        WhitePen = New Pen(Drawing.Color.White, 12)
        Dim GreenPen As Pen
        GreenPen = New Pen(Drawing.Color.Green, 12)
        'Draw status circles in Tank Select groupbox
        Dim BlackPen As Pen
        BlackPen = New Pen(Drawing.Color.Black, 2)

        Dim myGraphics As Graphics = Me.grpLoadStatus.CreateGraphics
        myGraphics.DrawEllipse(BlackPen, 30, 100, 26, 26)
        myGraphics.DrawEllipse(BlackPen, 30, 140, 26, 26)
        myGraphics.DrawEllipse(BlackPen, 30, 160, 26, 26)

        'myGraphics = Me.grpLoadStatus.CreateGraphics
        'myGraphics.DrawEllipse(BlackPen, 30, 184, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 30, 222, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 30, 260, 26, 26)

    End Sub
    Private Sub ScaleCom_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ScaleCom.DataReceived
        Dim w1 As String = ""
        Dim rcvd1 As String

        Try
            rcvd1 = ScaleCom.ReadExisting
            For i = 1 To Len(rcvd1)
                w1 = Mid(rcvd1, i, 1)
                If w1 = vbCr And Flag1 = True Then   'end of weight string
                    Flag1 = False
                    If InStr(Weight1, "?") = 0 Then
                        ScaleWeight1 = Mid(Weight1, 4, 6)
                    End If
                    Weight1 = ""
                End If
                If Flag1 = True Then   'start adding up weight
                    Weight1 = Weight1 + w1
                End If
                If w1 = Chr(2) Then   'Get STX
                    Flag1 = True
                End If
            Next i

        Catch ex As Exception
            AddLogEntry("ScaleCom_DataReceived" & ex.Message)
        End Try
    End Sub

    Private Sub Scale1Check_Tick(sender As System.Object, e As System.EventArgs) Handles Scale1Check.Tick
        txtWeight.Text = ScaleWeight1
    End Sub

    Private Sub cmdRead_Click(sender As System.Object, e As System.EventArgs) Handles cmdRead.Click
        txtWeight.Text = Val(Control.DisplayedWeight)
    End Sub

    Private Sub cmdZero_Click(sender As System.Object, e As System.EventArgs) Handles cmdZero.Click
        Control.ZeroScale()
    End Sub

    Private Sub cmdRedON_Click(sender As System.Object, e As System.EventArgs) Handles cmdRedON.Click
        Control.SetTrafficLightRed()
    End Sub

    Private Sub cmdGreenON_Click(sender As System.Object, e As System.EventArgs) Handles cmdGreenON.Click
        Control.SetTrafficLightGreen()
    End Sub

    Private Sub cmdSAON_Click(sender As System.Object, e As System.EventArgs) Handles cmdSAON.Click
        Control.SAEnable()
    End Sub

    Private Sub cmdSAOff_Click(sender As System.Object, e As System.EventArgs) Handles cmdSAOff.Click
        Control.SADisable()
    End Sub

    Private Sub cmdUCON_Click(sender As System.Object, e As System.EventArgs) Handles cmdUCON.Click
        Control.UCEnable()
    End Sub

    Private Sub cmdUCOff_Click(sender As System.Object, e As System.EventArgs) Handles cmdUCOff.Click
        Control.UCDisable()
    End Sub
    Private Sub cmdH2OOn_Click(sender As Object, e As EventArgs) Handles cmdH2OOn.Click
        Control.H2OEnable()
    End Sub

    Private Sub cmdH2OOff_Click(sender As Object, e As EventArgs) Handles cmdH2OOff.Click
        Control.H2ODisable()
    End Sub
    Private Sub cmdGate_Click(sender As System.Object, e As System.EventArgs) Handles cmdGate.Click
        Control.OpenEntryGate()
        GateTimer.Enabled = True     'Delay to close gate
    End Sub

    Private Sub GateTimer_Tick(sender As System.Object, e As System.EventArgs) Handles GateTimer.Tick
        Control.CloseEntryGate()
        GateTimer.Enabled = False
    End Sub

    Private Sub GetInput()
        Dim WhitePen As Pen
        WhitePen = New Pen(Drawing.Color.White, 12)
        Dim GreenPen As Pen
        GreenPen = New Pen(Drawing.Color.Green, 12)
        'Draw status circles in Tank Select groupbox
        Dim BlackPen As Pen
        BlackPen = New Pen(Drawing.Color.Black, 2)

        Dim myGraphics As Graphics = Me.grpLoadStatus.CreateGraphics

        'myGraphics.DrawEllipse(BlackPen, 20, 184, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 20, 222, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 20, 260, 26, 26)

        If Control.SADriverReady = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 60, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 60, 12, 12)
        End If
        If Control.SouthPlatformUp = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 100, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 100, 12, 12)
        End If
        If Control.SALoadingArmUp = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 140, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 140, 12, 12)
        End If

        If Control.SARailReady = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 180, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 180, 12, 12)
        End If

        If Control.UCDriverReady = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 220, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 220, 12, 12)
        End If
        If Control.NorthPlatformUp = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 260, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 260, 12, 12)
        End If
        If Control.UCLoadingArmUp = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 300, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 300, 12, 12)
        End If

        If Control.H2ODriverReady = True Then
            myGraphics.DrawEllipse(GreenPen, 40, 340, 12, 12)
        Else
            myGraphics.DrawEllipse(WhitePen, 40, 340, 12, 12)
        End If
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

        'myGraphics.DrawEllipse(BlackPen, 30, 184, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 30, 222, 26, 26)
        'myGraphics.DrawEllipse(BlackPen, 30, 260, 26, 26)

        If Control.Tank1Ready = True Then
            myGraphics.DrawEllipse(WhitePen, 37, 190, 12, 12)
        Else
            myGraphics.DrawEllipse(GreenPen, 37, 190, 12, 12)
        End If
        If Control.Tank2Ready = True Then
            myGraphics.DrawEllipse(WhitePen, 37, 228, 12, 12)
        Else
            myGraphics.DrawEllipse(GreenPen, 37, 228, 12, 12)
        End If
        If Control.Tank5Ready = True Then
            myGraphics.DrawEllipse(WhitePen, 37, 266, 12, 12)
        Else
            myGraphics.DrawEllipse(GreenPen, 37, 266, 12, 12)
        End If
    End Sub

    Private Sub StatusTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StatusTimer.Tick
        GetInput()
    End Sub

    Private Sub cmdADUCount_Click(sender As Object, e As EventArgs)
        MsgBox("ADU Count: " & ADUCount(100)) ' count is limited to 100 devices
    End Sub

    Private Sub cmdOpenBySNo_Click(sender As Object, e As EventArgs)
        aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)

    End Sub

    Private Sub cmdCloseADU_Click(sender As Object, e As EventArgs)
        CloseAduDevice(aduhandle)
    End Sub

    Private Sub grpLoadControl_Enter(sender As Object, e As EventArgs) Handles grpLoadControl.Enter
        aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)
        StatusTimer.Enabled = True
        TankStatusTimer.Enabled = False
    End Sub

    Private Sub TankStatusTimer_Tick(sender As Object, e As EventArgs) Handles TankStatusTimer.Tick
        GetTankInput()

    End Sub

    Private Sub cmdTank1_Click(sender As Object, e As EventArgs) Handles cmdTank1.Click
        Control.SetTank1()
        cmdTank1.Text = "On"
        cmdTank2.Text = "Off"
        cmdTank5.Text = "Off"
    End Sub

    Private Sub cmdTank2_Click(sender As Object, e As EventArgs) Handles cmdTank2.Click
        Control.SetTank2()
        cmdTank2.Text = "On"
        cmdTank1.Text = "Off"
        cmdTank5.Text = "Off"
    End Sub

    Private Sub cmdTank5_Click(sender As Object, e As EventArgs) Handles cmdTank5.Click
        Control.SetTank5()
        cmdTank5.Text = "On"
        cmdTank1.Text = "Off"
        cmdTank2.Text = "Off"
    End Sub

    Private Sub grpTankStatus_Click(sender As Object, e As EventArgs) Handles grpTankStatus.Click
        aduhandle = OpenAduDeviceBySerialNumber(TankSelectSN, 1)
        StatusTimer.Enabled = False
        TankStatusTimer.Enabled = True
    End Sub

    Private Sub grpLoadStatus_Click(sender As Object, e As EventArgs) Handles grpLoadStatus.Click
        aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)
        StatusTimer.Enabled = True
        TankStatusTimer.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetupCom()

    End Sub
End Class