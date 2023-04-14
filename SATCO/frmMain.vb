Imports System.Drawing.Printing
Imports System.IO
Imports System.IO.Ports
Imports System
Imports System.Deployment.Application

Public Class frmMain
    Private SQL As New SQLControl
    Dim PrintDoc As PrintDocument

    'Const TOOLBAR_MAIN = 0
    'Const TOOLBAR_TRANSACTION = 1
    'Const TOOLBAR_FILEMAINT = 2
    'Const TOOLBAR_REPORTS = 3

    Dim SysOptions As clsSystem
    Dim GateCardReader As clsCardReader
    Dim Tank As clsTank

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)

        LoadTimer.Enabled = True
        Status1Panel1.Text = Format(Now, "MM/dd/yyyy")
        Status1Panel3.Text = Format(Now, "hh:mm tt")
    End Sub

    Private Sub LoadTimer_Tick(sender As System.Object, e As System.EventArgs) Handles LoadTimer.Tick
        LoadTimer.Enabled = False

        Try

            'Display version information

            Status2Panel3.Text = "Version " & Version

            DisplayVersionNumber()

            SysOptions = New clsSystem
            DBPath = SysOptions.DatabasePath
            AddLogEntry("                                     ")
            AddLogEntry("***** SATCO Application Started *****")
            AddLogEntry("Starting SATCO with database " & DBPath)
            RptPath = SysOptions.ReportPath  'Left$(DBPath, Len(DBPath) - 9)
            SharePath = SysOptions.DocumentPath  'App.Path & "\" 'Left$(DBPath, Len(DBPath) - 9)

            If SQL.HasConnection = True Then
                Status1Panel2.Text = "SQL Connection Successful"
            Else
                Status1Panel2.Text = "SQL Connection FAILED"
                MsgBox("Connection to SQL Database FAILED")
                ToolStrip1.Visible = True
                Me.Refresh()
                Exit Sub
            End If

            If SysOptions.ScaleNumber = 0 Then
                'Enter RailMode
                RailMode = True
                frmCardID.MdiParent = Me
                frmCardID.Show()
            Else
                RailMode = False
                ScaleIsActive = True
                StatusStrip3.Visible = True
                'AddLogEntry("Setting Scale IP address to " & SysOptions.ScaleIP)

                '---Open connection to ADU ----
                Try
                    TrailerLoadSN = SysOptions.TLSN
                    TankSelectSN = SysOptions.TSSN
                    aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)
                    If aduhandle = -1 Then
                        MsgBox("Error connecting to Truck Load Control Device. Contact SATCO Representative.")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try



                ' ----- Signal ADU to turn traffic light RED -----
                Control.SetTrafficLightRed()
                AddLogEntry("Setting traffic signal to RED")

                'frmTransactionProcessing.MdiParent = Me
                'frmTransactionProcessing.Show()
                'Exit Sub

                'frmTest.MdiParent = Me
                'frmTest.Show()

                frmCardID.MdiParent = Me
                frmCardID.Show()
            End If

            SysOptions = Nothing

        Catch ex As Exception
            AddLogEntry(ex.Message)

        End Try
    End Sub

    Public Sub GetTankInfo()
        Try
            SysOptions = New clsSystem
            'Set Status Bars for Scale # and Tank Info
            Dim ScaleNumber As Integer = SysOptions.ScaleNumber
            If ScaleNumber = 0 Then
                Status2Panel2.Text = "Rail Mode"
            Else
                Status2Panel2.Text = "Scale " & ScaleNumber
            End If

            StatusStrip3.Visible = False
            Status3Panel1.Text = ""
            Status3Panel2.Text = ""
            Status3Panel3.Text = "          "
            Status3Panel4.Text = ""
            Status3Panel5.Text = ""
            SysOptions = Nothing
            Tank = New clsTank

            Tank.GetFirstRecord()

            Do While Not Tank.EOF
                If Tank.ActiveScale = 2 Then
                    'left pane = Tank # & Description
                    StatusStrip3.Visible = True
                    Status3Panel1.Text = "Tank " & Tank.Id
                    Status3Panel2.Text = Tank.Description
                End If
                If ScaleNumber = 1 Then  'Scale 1
                    If Tank.ActiveScale = 0 And Mid(Tank.Commodity, 1, 2) = "SA" Then
                        'left pane = Tank # & Description
                        StatusStrip3.Visible = True
                        Status3Panel1.Text = "Tank " & Tank.Id
                        Status3Panel2.Text = Tank.Description
                        CodeCommodity = "SA" & Tank.Id
                    End If
                    If Tank.ActiveScale = 0 And Mid(Tank.Commodity, 1, 2) <> "SA" Then
                        'right pane = Tank # & Description
                        StatusStrip3.Visible = True
                        Status3Panel4.Text = "Tank " & Tank.Id
                        Status3Panel5.Text = Tank.Description
                    End If
                ElseIf ScaleNumber = 1 Then 'Scale 2
                    If Tank.ActiveScale = 1 And Mid(Tank.Commodity, 1, 2) = "BN" Then
                        'left pane = Tank # & Description
                        StatusStrip3.Visible = True
                        Status3Panel1.Text = "Tank " & Tank.Id
                        Status3Panel2.Text = Tank.Description
                    End If
                    If Tank.ActiveScale = 1 And Mid(Tank.Commodity, 1, 2) = "MO" Then
                        'right pane = Tank # & Description
                        StatusStrip3.Visible = True
                        Status3Panel4.Text = "Tank " & Tank.Id
                        Status3Panel5.Text = Tank.Description
                    End If
                Else  'Railmode
                    If Tank.ActiveScale = 0 And Mid(Tank.Commodity, 1, 2) = "SA" Then
                        'left pane = Tank # & Description
                        StatusStrip3.Visible = True
                        Status3Panel1.Text = "Tank " & Tank.Id
                        Status3Panel2.Text = Tank.Description
                        CodeCommodity = "SA" & Tank.Id
                    End If
                    If Tank.ActiveScale = 1 And Mid(Tank.Commodity, 1, 2) = "BN" Then
                        'right pane = Tank # & Description
                        StatusStrip3.Visible = True
                        Status3Panel4.Text = "Tank " & Tank.Id
                        Status3Panel5.Text = Tank.Description
                    End If
                End If
                'Stop
                Tank.GetNextRecord()
            Loop
            Tank = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
            AddLogEntry("frmCardID-GetTankInfo: " & ex.Message)
        End Try

    End Sub

    Private Sub DisplayMessage(msg As String)
        Status1Panel2.Text = msg
    End Sub

    Private Sub DisplayMessage3(msg As String)
        Status3Panel1.Text = msg
    End Sub

    Sub DisplayVersionNumber()
        StatusStrip1.Text = "Version " & Version 'FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion
    End Sub

    Private Sub SetToolbar(ToolbarType As Integer)

        Dim btnX As Button
        btnX = AcceptButton
    End Sub

    Private Sub cmdLoad_Click(sender As System.Object, e As System.EventArgs)
        'If Environment.Is64BitProcess = True Then
        frmCardID.MdiParent = Me
        frmCardID.Show()
        'Else
        'frmSetup.Show()
        'End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs)
        frmSetup.MdiParent = Me
        frmSetup.Show()
    End Sub

    Private Sub cmdPrintTickets_Click(sender As System.Object, e As System.EventArgs)
        frmTicketPrint.MdiParent = Me
        frmTicketPrint.Show()
    End Sub

    Private Sub mnuPrintTicket_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrintTicket.Click
        frmTicketPrint.MdiParent = Me
        frmTicketPrint.Show()
    End Sub

    Private Sub mnuCertifiedWeight_Click(sender As System.Object, e As System.EventArgs) Handles mnuCertifiedWeight.Click
        frmWeighIn.MdiParent = Me
        frmWeighIn.Show()
    End Sub

    Private Sub mnuSetup_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetup.Click
        frmSetup.MdiParent = Me
        frmSetup.Show()
    End Sub

    Private Sub mnuLoadout_Click(sender As System.Object, e As System.EventArgs) Handles mnuLoadout.Click
        frmCardID.MdiParent = Me
        frmCardID.Show()
    End Sub

    Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click
        AddLogEntry("**** Exiting Application from Menu ****")
        Me.Close()
    End Sub

    Private Sub CmdTempExit_Click(sender As System.Object, e As System.EventArgs) Handles CmdTempExit.Click
        Me.Close()
    End Sub

    Private Sub TimeTimer_Tick(sender As System.Object, e As System.EventArgs) Handles TimeTimer.Tick
        Status1Panel1.Text = Format(Now, "MM/dd/yyyy")
        Status1Panel3.Text = Format(Now, "hh:mm tt")
    End Sub
End Class
