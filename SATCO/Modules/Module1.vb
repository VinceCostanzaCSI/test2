Imports System.IO
Imports System.Drawing.Printing
Imports Spire.Doc
Imports Spire.Doc.Documents
Imports Spire.Xls
Module Module1

    Public Version As String = "3.1.0.27"
    Public CtrlPassword As String
    Public OperatorName As String
    Public PrinterConnected As Integer
    Public GateCardReaderConnected As Integer
    Public NewPrinterID As String
    Public NewPrinterCode As String
    Public NewPrinterTicket As String
    Public MaintMode As Boolean
    Public FullAccess As Boolean
    Public LoadAccess As Boolean
    Public RailMode As Boolean

    Public TankSearch As String
    Public CardStart As Integer
    Public CardLength As Integer
    Public GateCardStart As Integer
    Public GateCardLength As Integer
    Public CardSearchID As String
    Public caldate As String
    Public ScaleIsActive As Boolean
    Public DBPath As String
    Public SharePath As String
    Public RptPath As String
    Public NSFLoad As Boolean
    Public ScaleNumber As Integer = 1
    Public MaxLength As Integer
    Public ADUResponse As String
    Public WatchPath As String
    Public Weight1 As String
    Public Flag1 As Boolean
    Public CodeCommodity As String
    Public HidePassword As Boolean
    Public CarrierMaxWeight As Long

    Public aduhandle As Integer
    Public TrailerLoadSN As String
    Public TankSelectSN As String
    Public TankSelectForm As Boolean

    Public Control As New clsControl

    'Tank Selection Variables
    Public RequestedTank As String
    Public SelectedTank As String

    'SA Variables
    Public SADriver As Boolean
    Public SARelease As String
    Public SAReleaseRequired As Boolean

    'Mosaic Variables
    Public MosaicDriver As Boolean
    Public MosaicRelease As String
    Public MosaicSolution As String

    'Brenntag Variables
    Public BrenntagDriver As Boolean
    Public BrenntagRelease As String
    Public BrenntagSolution As String
    Public BrenntagMaxLoad As String
    Public BrenntagSplit As Boolean
    Public BrenntagUpdate As Boolean
    Public Brenntag25 As Boolean
    Public BrenntagPCName As String

    Public Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
        'Stop
    End Sub

    Public Sub Delay(ByVal interval As Integer)
        'Delays process for number of milliseconds
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Public Function DelayMinutes(ByVal Wait As Double) As Integer
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(Wait)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop
        Return True
    End Function

    Public Function AnotherInstance() As Integer
        'Eschew multiple instances of program
        If Process.GetProcessesByName _
          (Process.GetCurrentProcess.ProcessName).Length > 1 Then

            MessageBox.Show _
             ("Another Instance of this process is already running", _
                 "Multiple Instances Forbidden", _
                  MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation)
            Application.Exit()
            AnotherInstance = True
        Else
            AnotherInstance = False
        End If

    End Function

    Public Sub AddLogEntry(ByVal Msg As String)
        Try
            Dim uriPath As String = System.IO.Path.GetDirectoryName( _
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
            'localpath = New Uri(uriPath).LocalPath
            Dim strFile As String = "c:\Satco\Logs\" & DateTime.Today.ToString("dd-MMM-yyyy") & ".txt"
            File.AppendAllText(strFile, String.Format(Msg & " " & DateTime.Now & vbCrLf))
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DataPathInit()
        Dim TPth As String
        Dim XPth As String
        Dim A As String
        Dim B As String
        Dim C As String

        Try
            Dim rdr As StreamReader
            rdr = New StreamReader("c:\SATCO\SetPath.dat")
            Dim parts() As String = rdr.ReadLine().Split(","c)
            TPth = parts(0)
            XPth = parts(1)
            A = parts(2)
            B = parts(3)
            C = parts(4)

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Sub EditActiveControl(frm As Form)

        Dim Keyboard As clsKeyboard

        On Error Resume Next

        Keyboard = New clsKeyboard

        'Change Text File Label For Keyboard Layout
        Keyboard.Label = frm.ActiveControl.Tag
        'Change String That Will Be Displayed On Keyboard Form
        Keyboard.Data = frm.ActiveControl.Text
        'Set Max String Length For Keyboard Layout
        Keyboard.Length = MaxLength
        Keyboard.Password = "" 'frm.ActiveControl.PasswordChar
        'Stop
        'frmKeyboard.MdiParent = frmMain
        frmKeyboard.ShowDialog()
        frm.ActiveControl.Focus()
        frm.ActiveControl.Text = Keyboard.Data

        Keyboard = Nothing

    End Sub

    Public Sub EditActiveControlPad(frm As Form)

        Dim Keyboard As clsKeyboard

        Keyboard = New clsKeyboard

        'Change Text File Label For Keyboard Layout
        Keyboard.Label = frm.ActiveControl.Tag
        'Change String That Will Be Displayed On Keyboard Form
        Keyboard.Data = frm.ActiveControl.Text
        'Set Max String Length For Keyboard Layout
        Keyboard.Length = MaxLength
        Keyboard.Password = "" 'frm.ActiveControl.PasswordChar

        frmKeypad.ShowDialog()
        frm.ActiveControl.Focus()
        frm.ActiveControl.Text = Keyboard.Data

        Keyboard = Nothing

    End Sub


    Public Sub PrintExcel(Spreadsheet As String)
        'Print out an Hazmat Sheet

        Try
            Dim workbook As Workbook = New Workbook()
            'Load an Excel file
            workbook.LoadFromFile(SharePath & Spreadsheet)

            'Set the print controller to StandardPrintController, which will prevent print process from showing
            workbook.PrintDocument.PrintController = New StandardPrintController()

            workbook.PrintDocument.Print()

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Sub PrintLastTicket()
        Dim Code As String
        Dim ID As String
        Dim Net As Long
        Dim Tonnage As Single
        Dim Gallons As Single
        Dim Quantity As Single
        Dim CommID As String
        Dim CommDesc As String

        Dim Freight As String = ""

        Dim Transaction As clsTransaction
        Dim Consignee As clsConsignee
        Dim Commodity As clsCommodity
        Dim Tank As clsTank
        Dim Driver As clsDriver
        Dim Mosaic As clsMosaic
        Dim Brenntag As clsBrenntag
        Dim SysOptions As clsSystem

        Transaction = New clsTransaction
        Commodity = New clsCommodity
        Driver = New clsDriver
        Consignee = New clsConsignee
        Tank = New clsTank
        SysOptions = New clsSystem
        Mosaic = New clsMosaic
        Brenntag = New clsBrenntag

        Dim doc As New Document

        Try
            'WordObj = CreateObject("Word.Application")
            Code = NewPrinterCode
            ID = NewPrinterID
            If Code = "" Or ID = "" Then
                Transaction.GetFirstRecord()
                Code = Transaction.Code
                ID = Transaction.Id
            End If
            Transaction.FindRecord(ID, Code)
            Consignee.FindRecord(Code)

            Commodity.FindRecord(Transaction.Commodity)
            'get Commodity ID and Description and save to variables
            CommID = Commodity.ID
            CommDesc = Commodity.Description1

            Tank.FindRecord(Transaction.TankId)
            'Now get Commodity info related to tank info
            Commodity.FindRecord(Tank.Commodity)
            'Doc = ""

            If RailMode Then
                If SADriver = True Then
                    doc.LoadFromFile(SharePath & "Q183 SA BOL Rail.docx")
                Else
                    doc.LoadFromFile(SharePath & "Q184 BN BOL Rail.doc")
                End If

            Else
                If Mid(CommID, 1, 2) = "SA" Then
                    If Consignee.NSF = True Then
                        doc.LoadFromFile(SharePath & "Q095 SA BOL_NSF.doc")
                    Else
                        doc.LoadFromFile(SharePath & "Q091 SA BOL.doc")
                    End If
                End If

                If Val(CommID) >= 1 Or Mid(CommID, 1, 2) = "UC" Then
                    doc.LoadFromFile(SharePath & "Q092 Nutrien Ag Solutions BOL.doc")
                End If
                If Mid(CommID, 1, 2) = "MO" Then
                    doc.LoadFromFile(SharePath & "Q110 MO BOL.doc")

                End If
                If Mid(CommID, 1, 2) = "BN" Then
                    doc.LoadFromFile(SharePath & "Q108 Brenntag BOL.doc")
                End If
            End If

            'Read from database for DriverInfo, MosaicCOA and BrenntagCOA
            SysOptions.GetCurrentRecord()

            'Find the 'bookmark' and add text
            Dim navigator As New BookmarksNavigator(doc)

            navigator.MoveToBookmark("BOL")
            navigator.InsertText(Trim(Code) & "-" & Trim(ID))

            If RailMode Then
                navigator.MoveToBookmark("Car1")
                navigator.InsertText(Transaction.TrailerID)
                navigator.MoveToBookmark("Prefix1")
                navigator.InsertText(Transaction.VehicleID)
                navigator.MoveToBookmark("Net1")
                Net = Transaction.Gross - Transaction.Tare
                Tonnage = Net / 2000
                navigator.InsertText(Format(Net, "##,##0"))
                navigator.MoveToBookmark("Ton1")
                navigator.InsertText(Format(Tonnage, "##.000"))

                navigator.MoveToBookmark("Seal1")
                navigator.InsertText(Transaction.Seal1)
                navigator.MoveToBookmark("Seal2")
                navigator.InsertText(Transaction.Seal2)
                If Transaction.Seal3 <> "" Then
                    navigator.MoveToBookmark("Seal3")
                    navigator.InsertText(Transaction.Seal3)
                End If
                If Transaction.Seal4 <> "" Then
                    navigator.MoveToBookmark("Seal4")
                    navigator.InsertText(Transaction.Seal4)
                End If
            End If

            If Mid(CommID, 1, 2) <> "BN" Then
                navigator.MoveToBookmark("Desc1")
                navigator.InsertText(Mid(Consignee.Consignee, 1, 45))

                navigator.MoveToBookmark("Desc2")
                navigator.InsertText(Mid(Consignee.Destination, 1, 45))

                navigator.MoveToBookmark("Desc3")
                navigator.InsertText(Mid(Consignee.Destination2, 1, 45))
            End If

            If Mid(CommID, 1, 2) = "SA" Then
                navigator.MoveToBookmark("Consignee")
                navigator.InsertText(Code)
                navigator.MoveToBookmark("Strength")
                navigator.InsertText(Transaction.Analysis)    'was Commodity.Description2)
                navigator.MoveToBookmark("Gravity")
                navigator.InsertText(Transaction.Desc3) '(Commodity.Description3)
                navigator.MoveToBookmark("Iron")
                navigator.InsertText(Transaction.Desc4) '(Commodity.Description4)
                navigator.MoveToBookmark("TankID")
                navigator.InsertText(Transaction.TankId)
                navigator.MoveToBookmark("ScaleID")
                navigator.InsertText(Str(Transaction.ScaleNumber))
                navigator.MoveToBookmark("PO")
                navigator.InsertText(Transaction.PO)
                If Consignee.NSF = True Then
                    navigator.MoveToBookmark("Seal1")
                    navigator.InsertText(Transaction.Seal1)
                    navigator.MoveToBookmark("Seal2")
                    navigator.InsertText(Transaction.Seal2)
                End If
            End If

            If Val(CommID) >= 1 Or Mid(CommID, 1, 2) = "UC" Then  'UC
                navigator.MoveToBookmark("lblMCDC")
                If Val(Tank.Id) = 15 Then
                    navigator.InsertText("DCDS")
                Else
                    navigator.InsertText("MCDS")
                End If
                navigator.MoveToBookmark("Consignee")
                navigator.InsertText(Code)
                navigator.MoveToBookmark("TankID")
                navigator.InsertText(Transaction.TankId)
                navigator.MoveToBookmark("ScaleID")
                navigator.InsertText(Str(Transaction.ScaleNumber))
                navigator.MoveToBookmark("Commodity")
                navigator.InsertText(CommDesc)
                navigator.MoveToBookmark("LabTech")
                navigator.InsertText(Transaction.Desc5) '(Commodity.Description5)
                navigator.MoveToBookmark("MCDS")
                navigator.InsertText(Transaction.Desc3) '(Commodity.Description3)
                navigator.MoveToBookmark("ProductionDate")
                navigator.InsertText(Transaction.Desc2) '(Commodity.Description2)
                navigator.MoveToBookmark("Release")
                navigator.InsertText(Transaction.ReleaseNumber)
            End If

            If Mid(CommID, 1, 2) = "MO" Then
                navigator.MoveToBookmark("Release")
                navigator.InsertText(Transaction.ReleaseNumber)
            End If

            If Mid(CommID, 1, 2) = "BN" Then

                Brenntag.FindRecord(Transaction.ReleaseNumber)
                navigator.MoveToBookmark("PO")
                navigator.InsertText(Brenntag.PO)
                navigator.MoveToBookmark("AltPO")
                navigator.InsertText(Brenntag.AltPO)
                navigator.MoveToBookmark("AltBOL")
                navigator.InsertText(Brenntag.BOL)
                navigator.MoveToBookmark("AltCode")
                navigator.InsertText(Brenntag.AltCode)
                navigator.MoveToBookmark("Name")
                navigator.InsertText(Brenntag.Name)
                navigator.MoveToBookmark("Address1")
                navigator.InsertText(Brenntag.Address1)
                navigator.MoveToBookmark("Address2")
                navigator.InsertText(Brenntag.Address2)
                navigator.MoveToBookmark("CSZ")
                navigator.InsertText(Brenntag.CSZ)
                navigator.MoveToBookmark("Seal1")
                navigator.InsertText(Transaction.Seal1)
                navigator.MoveToBookmark("Seal2")
                navigator.InsertText(Transaction.Seal2)
                If Transaction.Seal3 <> "" Then
                    navigator.MoveToBookmark("Seal3")
                    navigator.InsertText(Transaction.Seal3)
                End If
                If Transaction.Seal4 <> "" Then
                    navigator.MoveToBookmark("Seal4")
                    navigator.InsertText(Transaction.Seal4)
                End If
                navigator.MoveToBookmark("Release")
                navigator.InsertText(Transaction.ReleaseNumber)
                If Transaction.Analysis = "25%" Then
                    navigator.MoveToBookmark("NaOH")
                    navigator.InsertText(SysOptions.BTCOA1)
                    navigator.MoveToBookmark("Na2O")
                    navigator.InsertText(SysOptions.BTCOA2)
                    navigator.MoveToBookmark("PCName")
                    navigator.InsertText(Transaction.Adjustment)
                    'Print dillution details
                    navigator.MoveToBookmark("PCWater")
                    navigator.InsertText("H2O   (lbs): " & Transaction.Desc4)
                    navigator.MoveToBookmark("PCCaustic")
                    navigator.InsertText("Na2O (lbs): " & Transaction.Desc5)
                Else
                    navigator.MoveToBookmark("NaOH")
                    navigator.InsertText(SysOptions.BNCOA1)
                    navigator.MoveToBookmark("Na2O")
                    navigator.InsertText(SysOptions.BNCOA2)
                    navigator.MoveToBookmark("PCName")
                    navigator.InsertText(Transaction.Adjustment)
                End If

            End If

            Driver.FindRecord(Transaction.DriverId)
            navigator.MoveToBookmark("Carrier")
            navigator.InsertText(Driver.Carrier)
            navigator.MoveToBookmark("VehicleID")
            navigator.InsertText(Transaction.VehicleID)
            navigator.MoveToBookmark("TrailerID")
            navigator.InsertText(Transaction.TrailerID)
            navigator.MoveToBookmark("Date")
            navigator.InsertText(Format(Transaction.TDate, "MM/dd/yyyy"))
            navigator.MoveToBookmark("OutTime")
            navigator.InsertText(Transaction.OutTime)

            If Mid(CommID, 1, 2) <> "MO" Then
                navigator.MoveToBookmark("InTime")
                navigator.InsertText(Transaction.InTime)
                navigator.MoveToBookmark("Driver")
                navigator.InsertText(Driver.Name)
            End If

            If Mid(CommID, 1, 2) = "BN" Then
                navigator.MoveToBookmark("Driver2")
                navigator.InsertText(Driver.Name)
            End If

            navigator.MoveToBookmark("Gross")
            navigator.InsertText(Format(Transaction.Gross, "##,##0"))
            navigator.MoveToBookmark("Tare")
            navigator.InsertText(Format(Transaction.Tare, "##,##0"))
            navigator.MoveToBookmark("Net")
            Net = Transaction.Gross - Transaction.Tare
            Tonnage = Net / 2000
            navigator.InsertText(Format(Net, "##,##0"))

            If Mid(CommID, 1, 2) = "BN" Then
                navigator.MoveToBookmark("Tons")
                navigator.InsertText(Format(Tonnage, "##.000"))
                navigator.MoveToBookmark("Tons1")
                navigator.InsertText(Format(Tonnage, "##.000"))
            Else
                navigator.MoveToBookmark("Tons")
                navigator.InsertText(Format(Tonnage, "##.00"))
            End If

            If Val(CommID) >= 1 Or Mid(CommID, 1, 2) = "UC" Then  'UC
                If Val(Commodity.Description4) = 0 Then
                    Gallons = 0
                Else
                    Gallons = Net / Val(Commodity.Description4)
                End If
                navigator.MoveToBookmark("Volume")
                navigator.InsertText(Format(Gallons, "#,###.00"))
                Quantity = Gallons * 3.785
                navigator.MoveToBookmark("Quantity")
                navigator.InsertText(Format(Quantity, "#,###.00"))
            End If

            'Now print it out!
            Dim printDoc As PrintDocument = doc.PrintDocument
            printDoc.PrintController = New StandardPrintController()
            printDoc.Print()

            Transaction = Nothing
            Commodity = Nothing
            Driver = Nothing
            Consignee = Nothing
            Tank = Nothing
            SysOptions = Nothing
            Mosaic = Nothing
            Brenntag = Nothing

        Catch ex As Exception
            MsgBox("PrintLastTicket: " & ex.Message)

        End Try
    End Sub

    Public Sub PrintWordDoc(WordDoc As String)
        'Print out a Word Document
        Dim doc As New Document

        doc.LoadFromFile(SharePath & WordDoc)

        'Now print it out!
        Dim printDoc As PrintDocument = doc.PrintDocument
        printDoc.PrintController = New StandardPrintController()
        printDoc.Print()

    End Sub

    Public Sub PrintBNCoA25(WordDoc As String)
        Dim SysOptions As clsSystem
        Dim doc As New Document
        Dim navigator As New BookmarksNavigator(doc)

        SysOptions = New clsSystem
        doc.LoadFromFile(SharePath & WordDoc)

        'Read from database for BrenntagCOA
        SysOptions.GetCurrentRecord()

        navigator.MoveToBookmark("COA1")
        navigator.InsertText(SysOptions.BTCOA1)
        navigator.MoveToBookmark("COA2")
        navigator.InsertText(SysOptions.BTCOA2)
        navigator.MoveToBookmark("COA3")
        navigator.InsertText(SysOptions.BTCOA3)
        navigator.MoveToBookmark("COA4")
        navigator.InsertText(SysOptions.BTCOA4)
        navigator.MoveToBookmark("COA5")
        navigator.InsertText(SysOptions.BTCOA5)
        navigator.MoveToBookmark("COA6")
        navigator.InsertText(SysOptions.BTCOA6)
        navigator.MoveToBookmark("COA7")
        navigator.InsertText(SysOptions.BTCOA7)
        navigator.MoveToBookmark("COA8")
        navigator.InsertText(SysOptions.BTCOA10)
        navigator.MoveToBookmark("COA9")
        navigator.InsertText(SysOptions.BTCOA11)
        navigator.MoveToBookmark("COA10")
        navigator.InsertText(SysOptions.BTCOA12)
        navigator.MoveToBookmark("COA11")
        navigator.InsertText(SysOptions.BTCOA13)
        navigator.MoveToBookmark("COA12")
        navigator.InsertText(SysOptions.BTCOA14)
        'navigator.MoveToBookmark("COA13").Select
        'navigator.InsertText SysOptions.BTCOA13
        'navigator.MoveToBookmark("COA14").Select
        'navigator.InsertText SysOptions.BTCOA14
        navigator.MoveToBookmark("COA0")
        navigator.InsertText(SysOptions.BTGravity)


        'Now print it out!
        Dim printDoc As PrintDocument = doc.PrintDocument
        printDoc.PrintController = New StandardPrintController()
        printDoc.Print()

        SysOptions = Nothing

    End Sub

    Public Sub PrintBNCoA50(WordDoc As String)
        Dim SysOptions As clsSystem
        Dim doc As New Document
        Dim navigator As New BookmarksNavigator(doc)

        SysOptions = New clsSystem
        doc.LoadFromFile(SharePath & WordDoc)

        'Read from database for BrenntagCOA
        SysOptions.GetCurrentRecord()

        navigator.MoveToBookmark("COA1")
        navigator.InsertText(SysOptions.BNCOA1)
        navigator.MoveToBookmark("COA2")
        navigator.InsertText(SysOptions.BNCOA2)
        navigator.MoveToBookmark("COA3")
        navigator.InsertText(SysOptions.BNCOA3)
        navigator.MoveToBookmark("COA4")
        navigator.InsertText(SysOptions.BNCOA4)
        navigator.MoveToBookmark("COA5")
        navigator.InsertText(SysOptions.BNCOA5)
        navigator.MoveToBookmark("COA6")
        navigator.InsertText(SysOptions.BNCOA6)
        navigator.MoveToBookmark("COA7")
        navigator.InsertText(SysOptions.BNCOA7)
        navigator.MoveToBookmark("COA8")
        navigator.InsertText(SysOptions.BNCOA10)
        navigator.MoveToBookmark("COA9")
        navigator.InsertText(SysOptions.BNCOA11)
        navigator.MoveToBookmark("COA10")
        navigator.InsertText(SysOptions.BNCOA12)
        navigator.MoveToBookmark("COA11")
        navigator.InsertText(SysOptions.BNCOA13)
        navigator.MoveToBookmark("COA12")
        navigator.InsertText(SysOptions.BNCOA14)
        'navigator.MoveToBookmark("COA13").Select
        'navigator.InsertText SysOptions.BNCOA13
        'navigator.MoveToBookmark("COA14").Select
        'navigator.InsertText SysOptions.BNCOA14
        navigator.MoveToBookmark("COA0")
        navigator.InsertText(SysOptions.BNGravity)


        'Now print it out!
        Dim printDoc As PrintDocument = doc.PrintDocument
        printDoc.PrintController = New StandardPrintController()
        printDoc.Print()

        SysOptions = Nothing

    End Sub

    Public Sub PrintBNNotes(WordDoc As String)
        Dim Brenntag As clsBrenntag
        'Dim SysOptions As clsSystem
        Dim Transaction As clsTransaction
        Dim Consignee As clsConsignee

        Dim Code As String
        Dim ID As String

        Dim doc As New Document
        Dim navigator As New BookmarksNavigator(doc)

        Transaction = New clsTransaction
        Consignee = New clsConsignee
        Brenntag = New clsBrenntag

        Code = NewPrinterCode
        ID = NewPrinterID
        If Code = "" Or ID = "" Then
            Transaction.GetFirstRecord()
            Code = Transaction.Code
            ID = Transaction.Id
        End If
        Transaction.FindRecord(ID, Code)

        doc.LoadFromFile(SharePath & "Brenntag Notes.doc")

        Brenntag.FindRecord(Transaction.ReleaseNumber)
        navigator.MoveToBookmark("Notes")
        navigator.InsertText(Brenntag.Notes)

        'Now print it out!
        Dim printDoc As PrintDocument = doc.PrintDocument
        printDoc.PrintController = New StandardPrintController()
        printDoc.Print()

    End Sub

End Module
