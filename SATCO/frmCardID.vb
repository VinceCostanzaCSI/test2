Imports System.IO

Public Class frmCardID
    Private SQL As New SQLControl

    Dim Driver As clsDriver
    Dim SysOptions As clsSystem
    Dim CardReader As clsCardReader
    Dim Tank As clsTank
    Dim CardNumber As String
    Dim TDate As Date
    Dim availableSerialPorts As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.Ports.SerialPortNames

    Private Sub frmCardID_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'AddLogEntry ("frmCardID_Unload - Set classes to nothing")
        SysOptions = Nothing
        CardReader = Nothing
        'frmCardID = Nothing
    End Sub

    Private Sub frmCardID_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)

        Try
            frmMain.ToolStrip1.Visible = False
            ClearProcessClass()
            SADriver = False
            MosaicDriver = False
            MosaicRelease = ""
            BrenntagDriver = False
            BrenntagSplit = False
            BrenntagRelease = ""
            Brenntag25 = False

            If RailMode Then
                ComboFill()
                cboCardID.Visible = True
                txtCardID.Visible = False
            Else
                'Release any Tank Select request
                aduhandle = OpenAduDeviceBySerialNumber(TankSelectSN, 1)
                Control.ResetTankRequest()

                Delay(400)

                ' ----- Signal ADU to turn Light RED -----
                aduhandle = OpenAduDeviceBySerialNumber(TrailerLoadSN, 1)
                AddLogEntry("frmCardId - Turn Traffic Light RED")
                Control.SetTrafficLightRed()

                frmMain.GetTankInfo()
                SetupCom()  'Check to see if Card Reader port is active

                txtCardID.Focus()
            End If

        Catch ex As Exception
            AddLogEntry("frmCardID_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        AddLogEntry("frmCardId - EXIT button hit")
        CardCom.Close()
        Me.Close()
        frmPassword.MdiParent = frmMain
        frmPassword.Show()
    End Sub

    Private Sub ComboFill()
        If Sql.HasConnection = True Then

            SQL.RunQuery("SELECT * FROM Driver WHERE Carrier = 'SATCO OPR' AND ACTIVE = '1'")
            If Sql.RecordCount > 0 Then
                For Each r As DataRow In Sql.SQLDataset.Tables(0).Rows
                    cboCardID.Items.Add(r("Name"))
                Next

            ElseIf Sql.SQLDataset.HasErrors <> "" Then
                MsgBox("No Operators found")
            End If
            'Stop
        Else
            MsgBox("No SQL Connection")
        End If

    End Sub

    Private Sub SetupCom()
        Dim SysOptions = New clsSystem

        Try
            If SysOptions.CardReaderActive = 1 Then

                'Monitor AccessCom port for activity
                Dim Card As String = SysOptions.CardReaderSettings
                Dim parts As String() = Card.Split(","c)

                CardCom.PortName = parts(0)

                CardCom.BaudRate = parts(1)
                Select Case parts(2)
                    Case "N"
                        CardCom.Parity = Ports.Parity.None
                    Case "E"
                        CardCom.Parity = Ports.Parity.Even
                    Case "O"
                        CardCom.Parity = Ports.Parity.Odd
                    Case "S"
                        CardCom.Parity = Ports.Parity.Space
                    Case "M"
                        CardCom.Parity = Ports.Parity.Mark
                End Select

                CardCom.DataBits = parts(3)

                Select Case parts(4)
                    Case 1
                        CardCom.StopBits = Ports.StopBits.One
                    Case 2
                        CardCom.StopBits = Ports.StopBits.Two
                    Case Else
                        CardCom.StopBits = Ports.StopBits.One
                End Select

                If availableSerialPorts.Contains(parts(0)) Then
                    lblCardStatus.Text = "Card Reader Status: Ready"
                    CardCom.Open()
                    CardReadTimer.Enabled = True
                Else
                    lblCardStatus.Text = "No " & parts(0) & " on this computer"
                End If

            End If

            SysOptions = Nothing

        Catch ex As Exception
            AddLogEntry("frCardID_SetupCom: " & ex.Message)
        End Try

    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim Process As clsProcess
        Dim Driver As clsDriver

        Try
            CardReadTimer.Enabled = False
            AddLogEntry("frmCardId - Next button hit")
            If Len(txtCardID.Text) > 0 Then
                AddLogEntry("Validating CardId: " & txtCardID.Text)

                SysOptions = New clsSystem
                SysOptions.GetCurrentRecord()
                Dim TrainTest = SysOptions.DriverTraining
                Dim WarnTest = SysOptions.DriverWarning
                Dim ExpireTest = SysOptions.DriverExpires
                Dim TWICTest = SysOptions.DriverTWIC
                SysOptions = Nothing

                Driver = New clsDriver
                Driver.Search("CardId", txtCardID.Text)
                If Driver.EOF Then
                    AddLogEntry("Invalid CardId: " & txtCardID.Text)
                    lblMsg.Text = "INVALID CARD ID ENTERED !"
                    txtCardID.Text = ""
                Else
                    AddLogEntry("Valid CardId found: " & txtCardID.Text)
                    TDate = Format(Driver.Twic, "MM/dd/yyyy")
                    If TDate < Now Then
                        AddLogEntry("Driver Twic is expired")
                        lblMsg.Text = "DRIVER TWIC IS EXPIRED !"
                        Driver = Nothing
                        txtCardID.Text = ""
                        CardReadTimer.Enabled = True
                        Exit Sub
                    End If
                    'Check for TWIC date nearing expiration
                    Dim TWICDays As Integer = DateDiff(DateInterval.Day, Now, Driver.Twic)
                    If TWICDays <= TWICTest Then
                        MsgBox("WARNING: You're TWIC will expire in " & TWICDays & " days")
                    End If
                    If Driver.Active = False Then
                        AddLogEntry("Driver is INACTIVE")
                        lblMsg.Text = "DRIVER IS INACTIVE !"
                        txtCardID.Text = ""
                    Else
                        AddLogEntry("Driver is ACTIVE")
                        'Check for Training and last time driver was here
                        Dim TrainDays As Integer = TrainTest - DateDiff(DateInterval.Day, Driver.Training, Now)
                        'Dim WarningDays As Integer = DateDiff(DateInterval.Day, Now, Driver.Warning)
                        Dim ExpiredDays As Integer = DateDiff(DateInterval.Day, Driver.Expires, Now)
                        'Stop

                        If ExpiredDays > ExpireTest Then
                            MsgBox("You have not been here for more than " & ExpireTest & " days. - Please contact SATCO personnel")
                            Driver = Nothing
                            CardReadTimer.Enabled = True
                            Exit Sub
                        End If

                        If TrainDays < 0 Then
                            MsgBox("You are required to go through Training - Please contact SATCO presonnel")
                            Driver = Nothing
                            CardReadTimer.Enabled = True
                            Exit Sub
                        End If

                        If TrainDays <= WarnTest Then
                            MsgBox("Warning: You are required to go through Training within " & TrainDays & " days")
                        End If


                        'Driver passed all validation - update Expires date to today
                        Driver.Expires = Format(Now, "MM/dd/yyyy")
                        Driver.UpdateRecord(Driver.ID)

                        Process = New clsProcess
                        Process.ProcessDate = Format(Now, "MM/dd/yyyy")
                        Process.ProcessTime = Format(Now, "hh:mm")
                        Process.CardId = txtCardID.Text
                        Process.DriverId = Driver.ID
                        Process.DriverName = Driver.Name
                        Process.Carrier = Driver.Carrier
                        Process = Nothing

                        CardCom.Close()
                        AddLogEntry("Unload frmCardId")
                        Me.Close()
                        AddLogEntry("frmCardId loading frmPIN")
                        frmPin.MdiParent = frmMain
                        frmPin.Show()
                    End If
                End If
                Driver = Nothing
                CardReadTimer.Enabled = True

            Else
                AddLogEntry("No card Id was entered")
                lblMsg.Text = "NO CARD ID ENTERED !"
            End If

        Catch ex As Exception
            AddLogEntry("frmCardID_cmdNext: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrint.Click
        Driver = New clsDriver

        Try
            If Len(txtCardID.Text) > 0 Then
                Driver.Search("CardId", txtCardID.Text)
                If Driver.EOF Then
                    AddLogEntry("Invalid CardId found")
                    lblMsg.Text = "INVALID CARD ID ENTERED !"
                Else
                    AddLogEntry("Valid CardId found")
                    TDate = Format(Driver.Twic, "MM/dd/yyyy")
                    If TDate < Now Then
                        AddLogEntry("Driver Twic is expired")
                        lblMsg.Text = "DRIVER TWIC IS EXPIRED !"
                        Driver = Nothing
                        'Exit Sub
                    End If
                    If Driver.Active = False Then
                        AddLogEntry("Driver is INACTIVE")
                        lblMsg.Text = "DRIVER IS INACTIVE !"
                    Else
                        AddLogEntry("Driver is ACTIVE")
                        CardSearchID = Driver.ID
                        frmTicketPrint.MdiParent = frmMain
                        frmTicketPrint.Show()
                        'Unload frmCardId
                    End If
                End If
                Driver = Nothing
            Else
                AddLogEntry("No card Id was entered")
                lblMsg.Text = "NO CARD ID ENTERED !"
            End If

        Catch ex As Exception
            AddLogEntry("frmCardID_cmdPrint: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearProcessClass()

        Dim Process As clsProcess

        Process = New clsProcess
        Process.ProcessDate = Format(Now, "MM/dd/yyyy")
        Process.ProcessTime = Format(Now, "hh:mm")
        Process.CardId = ""
        Process.DriverId = ""
        Process.DriverName = ""
        Process.Carrier = ""
        Process.Code = ""
        Process.Consignee = ""
        Process.Destination = ""
        Process.ReleaseNumber = ""
        Process = Nothing

    End Sub

    Private Sub txtCardID_Click(sender As Object, e As System.EventArgs) Handles txtCardID.Click
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtCardID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCardID.TextChanged
        'lblMsg.Text = ""
    End Sub

    Private Sub TankInfoTimer_Tick(sender As System.Object, e As System.EventArgs) Handles TankInfoTimer.Tick
        frmMain.GetTankInfo()
    End Sub

    Private Sub CardReadTimer_Tick(sender As System.Object, e As System.EventArgs) Handles CardReadTimer.Tick
        CardReadTimer.Enabled = False

        Dim CardChar As String = ""
        Dim CardStr As String = ""

        Dim SysOptions = New clsSystem

        Dim CardStart As Integer = SysOptions.CardReaderStart
        Dim CardLength As Integer = SysOptions.CardReaderLength
        SysOptions = Nothing

        Try
            'AddLogEntry("Gate Reader Data Received")
            If CardCom.IsOpen Then
                CardStr = CardCom.ReadExisting
                If CardStr = "" Then
                    CardReadTimer.Enabled = True
                    Exit Sub
                End If
                If CardStart = 0 And CardLength = 0 Then
                    'Decode card data from SecureAkey encoding
                    txtCardID.Text = DecodeCard(CardStr)
                    If txtCardID.Text = "" Then
                        CardReadTimer.Enabled = True
                        Exit Sub
                    End If
                ElseIf CardStart = 1 And CardLength = 1 Then
                    'This is an RS232 RFID Reader that outputs Ascii representation of Hex values
                    txtCardID.Text = Convert.ToInt32(Mid(CardStr, 2, 8), 16)

                    'This is an RS232 RFID Reader that outputs Ascii representation of Hex values with added ADA numbers
                    'txtCardID.Text = Convert.ToInt32(Mid(CardStr, 4, 8), 16)
                Else
                    txtCardID.Text = Mid(CardStr, CardStart, CardLength)
                    AddLogEntry("Card Reader Data Received " & txtCardID.Text)
                End If
            End If
        Catch ex As Exception
            AddLogEntry("CardReadTimer_Tick: " & ex.Message)
        End Try
    End Sub

    Private Function DecodeCard(ByVal CardRead As String) As String

        Try
            Dim TrimCard As String = Mid(CardRead, 19, 8)
            'Mask MSB and LSB
            Dim msb As String = Mid(TrimCard, 1, 2)
            Dim lsb As String = Mid(TrimCard, 7, 2)
            Dim msbmask As Integer = Val("&H" & msb)
            Dim lsbmask As Integer = Val("&H" & lsb)
            msbmask = msbmask And &H7F
            lsbmask = lsbmask And &HFE

            msb = Hex(msbmask).PadLeft(2, "0"c)
            lsb = Hex(lsbmask).PadLeft(2, "0"c)

            Dim TrimCard2 As String = msb & Mid(TrimCard, 3, 4) & lsb

            ''Now shift bits to the right by one
            Dim MyShift = Convert.ToInt32(TrimCard2, 16) >> 1

            Dim TrimCard3 As String = Hex(MyShift)
            TrimCard3 = TrimCard3.PadLeft(8, "0"c)

            Dim TrimCard4 As String = Mid(TrimCard3, 1, 4)
            Dim TrimCard5 As String = Mid(TrimCard3, 5, 4)

            Dim intfc As Integer = Convert.ToInt32(TrimCard4, 16)
            Dim intcn As Integer = Convert.ToInt32(TrimCard5, 16)

            TrimCard4 = intfc.ToString("00000")
            TrimCard5 = intcn.ToString("00000")
            Dim TrimCard6 As String = TrimCard4 & TrimCard5
            DecodeCard = Mid(TrimCard6, 6, 5)

        Catch ex As Exception
            DecodeCard = ""
            AddLogEntry("DecodeCard: " & ex.Message)
        End Try

    End Function

    Private Sub cboCardID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCardID.SelectedIndexChanged
        Dim Driver As clsDriver
        Driver = New clsDriver
        If Driver.Search("Name", cboCardID.Text) = True Then
            Driver.FindRecord(Driver.ID)
            txtCardID.Text = Driver.CardNumber
        End If
        'Stop
    End Sub

    Private Sub cboCardID_Click(sender As Object, e As EventArgs) Handles cboCardID.Click
        cboCardID.DroppedDown = True
    End Sub
End Class