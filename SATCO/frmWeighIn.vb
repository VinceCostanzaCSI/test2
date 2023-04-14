Imports System.IO
Imports System.IO.Ports
Imports System.Drawing.Printing
Imports Spire.Doc
Imports Spire.Doc.Documents
Public Class frmWeighIn

    Dim ScaleWeight1 As Double
    Dim availableSerialPorts As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.Ports.SerialPortNames

    Private Sub frmWeighIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        Me.Top = 90
        LoadTimer.Enabled = True

    End Sub

    Private Sub LoadTimer_Tick(sender As System.Object, e As System.EventArgs) Handles LoadTimer.Tick
        LoadTimer.Enabled = False
        Try
            Comm1.PortName = "COM1"
            'See if it exists
            If availableSerialPorts.Contains("COM1") Then
                txtStatus.Text = "COM1 is available"
                Comm1.Open()
                Scale1Check.Enabled = True
            Else
                txtStatus.Text = "No COM1 on this computer"
            End If
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub
    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Comm1.Close()
        Me.Close()
    End Sub

    Private Sub txtGross_Resize(sender As Object, e As System.EventArgs) Handles txtGross.Resize
        txtGross.Text = Val(Control.DisplayedWeight)
    End Sub

    Private Sub txtGross_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGross.TextChanged
        txtNet.Text = Val(txtGross.Text) - Val(txtTare.Text)
    End Sub

    Private Sub txtNet_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNet.TextChanged
        txtTons.Text = Val(txtNet.Text) / 2000
    End Sub

    Private Sub txtTare_Click(sender As Object, e As System.EventArgs) Handles txtTare.Click
        EditActiveControlPad(Me)
    End Sub

    Private Sub txtTare_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTare.TextChanged
        txtNet.Text = Val(txtGross.Text) - Val(txtTare.Text)
    End Sub

    Private Sub txtVehicle_Click(sender As Object, e As System.EventArgs) Handles txtVehicle.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtVehicle_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVehicle.TextChanged

    End Sub

    Private Sub txtTrailer_Click(sender As Object, e As System.EventArgs) Handles txtTrailer.Click
        EditActiveControl(Me)
    End Sub

    Private Sub txtTrailer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTrailer.TextChanged

    End Sub

    Private Sub cmdRead_Click(sender As System.Object, e As System.EventArgs) Handles cmdRead.Click
        txtGross.Text = Val(Control.DisplayedWeight)
    End Sub

    Private Sub cmdZero_Click(sender As System.Object, e As System.EventArgs) Handles cmdZero.Click
        Control.ZeroScale()
    End Sub

    Private Sub cmdPrint_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrint.Click
        'First update record then print
        Dim Ticket As String
        Dim Net As Long
        Dim Tonnage As Single
        Dim WeighIn As clsWeighIn
        Dim SysOptions As clsSystem
        'Dim WordObj As Object
        'Dim Doc As Object
        Dim doc As New Document

        Try

            WeighIn = New clsWeighIn
            SysOptions = New clsSystem

            If txtVehicle.Text <> "" Then
                WeighIn.VehicleId = txtVehicle.Text & ""
                WeighIn.TrailerID = txtTrailer.Text & ""
                WeighIn.Gross = txtGross.Text & ""
                WeighIn.Tare = txtTare.Text & ""
                WeighIn.Net = txtNet.Text & ""
                WeighIn.DateTime = Now
                WeighIn.AddRecord(txtVehicle.Text)

                'WordObj = CreateObject("Word.Application")
                doc.LoadFromFile(SharePath & "Q093 Weight Ticket.doc")
                'Fill in the blanks

                Ticket = SysOptions.ManualTicket + 1
                SysOptions.ManualTicket = Ticket

                'Find the 'bookmark' and add text
                Dim navigator As New BookmarksNavigator(doc)

                navigator.MoveToBookmark("Ticket")
                navigator.InsertText(Ticket)

                navigator.MoveToBookmark("VehicleID")
                navigator.InsertText(txtVehicle.Text & "")
                navigator.MoveToBookmark("TrailerID")
                navigator.InsertText(txtTrailer.Text & "")

                navigator.MoveToBookmark("Date")
                navigator.InsertText(Format(Now, "MM/dd/yyyy"))
                navigator.MoveToBookmark("Time")
                navigator.InsertText(Format(Now, "HH:mm"))

                navigator.MoveToBookmark("Gross")
                navigator.InsertText(Format(Val(txtGross.Text), "##,##0"))
                navigator.MoveToBookmark("Tare")
                navigator.InsertText(Format(Val(txtTare.Text), "##,##0"))
                navigator.MoveToBookmark("Net")
                Net = Val(txtGross.Text) - Val(txtTare.Text)
                Tonnage = Net / 2000
                navigator.InsertText(Format(Val(txtNet.Text), "##,##0"))
                navigator.MoveToBookmark("Tons")
                navigator.InsertText(Format(Tonnage, "##.##"))

                'Now print it out!
                Dim printDoc As PrintDocument = doc.PrintDocument
                printDoc.PrintController = New StandardPrintController()
                printDoc.Print()

            Else
                MsgBox("Please enter a Vehicle ID and weight first")
            End If

            SysOptions = Nothing
            WeighIn = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Scale1Check_Tick(sender As System.Object, e As System.EventArgs) Handles Scale1Check.Tick
        Scale1Box.Text = ScaleWeight1
    End Sub

    Private Sub Comm1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Comm1.DataReceived
        Dim w1 As String = ""
        Dim rcvd1 As String

        Try
            rcvd1 = Comm1.ReadExisting
            For i = 1 To Len(rcvd1)
                w1 = Mid(rcvd1, i, 1)
                If w1 = vbCr And Flag1 = True Then   'end of weight string
                    Flag1 = False
                    If InStr(Weight1, "?") = 0 Then
                        'Scale1Box.Text = Val(Weight1)
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
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Private Sub Scale1Box_TextChanged(sender As System.Object, e As System.EventArgs) Handles Scale1Box.TextChanged
        txtGross.Text = Val(Scale1Box.Text)
    End Sub


End Class