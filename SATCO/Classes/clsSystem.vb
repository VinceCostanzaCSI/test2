Imports System.Reflection
Imports System.IO

Public Class clsSystem
    Private SQL As New SQLControl
    'local variable(s) to hold property value(s)
    Private iDriverWarning As Integer
    Private iDriverTraining As Integer
    Private iDriverExpires As Integer
    Private iDriverTWIC As Integer

    Private sMOGravity As String
    Private sMOppg As String
    Private sMODate As String
    Private sMOProduct As String
    Private sMOTotalNi As String
    Private sMOUreaNi As String
    Private sMONitrate As String

    Private sBNGravity As String
    Private sBNppg As String
    Private sBNCOA1 As String
    Private sBNCOA2 As String
    Private sBNCOA3 As String
    Private sBNCOA4 As String
    Private sBNCOA5 As String
    Private sBNCOA6 As String
    Private sBNCOA7 As String
    Private sBNCOA8 As String
    Private sBNCOA9 As String
    Private sBNCOA10 As String
    Private sBNCOA11 As String
    Private sBNCOA12 As String
    Private sBNCOA13 As String
    Private sBNCOA14 As String
    '25% Caustic
    Private sBTGravity As String
    Private sBTppg As String
    Private sBTCOA1 As String
    Private sBTCOA2 As String
    Private sBTCOA3 As String
    Private sBTCOA4 As String
    Private sBTCOA5 As String
    Private sBTCOA6 As String
    Private sBTCOA7 As String
    Private sBTCOA8 As String
    Private sBTCOA9 As String
    Private sBTCOA10 As String
    Private sBTCOA11 As String
    Private sBTCOA12 As String
    Private sBTCOA13 As String
    Private sBTCOA14 As String
    Private sH2OFlow As String

    Private CurrentRecord As Integer

    Const MESSAGE_TXT = "Received, Subject to the Classification and Tariffs in effect on the date of the issue of this RECEIPT"

    Dim Section As String
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Public Sub GetCurrentRecord()
        Try
            UpdateClass(CurrentRecord)
        Catch ex As Exception
            AddLogEntry("System.GetCurrentRecord: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateClass(ByVal CRecord As Integer)
        Try
            SQL.RunQuery("Select Top 1 * from DriverInfo")
            If SQL.RecordCount <> 0 Then
                With SQL.SQLDataset.Tables(0).Rows(0)
                    iDriverWarning = Trim(.Item("Warning"))
                    iDriverTraining = Trim(.Item("Training"))
                    iDriverExpires = Trim(.Item("Expires"))
                    iDriverTWIC = Trim(.Item("TWIC"))
                End With
            End If

            SQL.RunQuery("Select Top 1 * from MosaicCOA")
            If SQL.RecordCount <> 0 Then
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sMOGravity = Trim(.Item("MOGravity"))
                    sMOppg = Trim(.Item("MOppg"))
                    sMODate = Trim(.Item("MODate"))
                    sMOProduct = Trim(.Item("MOProduct"))
                    sMOTotalNi = Trim(.Item("MOTotalNi"))
                    sMOUreaNi = Trim(.Item("MOUreaNi"))
                    sMONitrate = Trim(.Item("MONitrate"))
                End With
            End If

            SQL.RunQuery("Select Top 1 * from BrenntagCOA")
            If SQL.RecordCount <> 0 Then
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sBNGravity = Trim(.Item("BNGravity"))
                    sBNppg = Trim(.Item("BNppg"))
                    sBNCOA1 = Trim(.Item("BNCOA1"))
                    sBNCOA2 = Trim(.Item("BNCOA2"))
                    sBNCOA3 = Trim(.Item("BNCOA3"))
                    sBNCOA4 = Trim(.Item("BNCOA4"))
                    sBNCOA5 = Trim(.Item("BNCOA5"))
                    sBNCOA6 = Trim(.Item("BNCOA6"))
                    sBNCOA7 = Trim(.Item("BNCOA7"))
                    sBNCOA8 = Trim(.Item("BNCOA8"))
                    sBNCOA9 = Trim(.Item("BNCOA9"))
                    sBNCOA10 = Trim(.Item("BNCOA10"))
                    sBNCOA11 = Trim(.Item("BNCOA11"))
                    sBNCOA12 = Trim(.Item("BNCOA12"))
                    sBNCOA13 = Trim(.Item("BNCOA13"))
                    sBNCOA14 = Trim(.Item("BNCOA14"))
                    '25% Caustic
                    sBTGravity = Trim(.Item("BTGravity"))
                    sBTppg = Trim(.Item("BTppg"))
                    sBTCOA1 = Trim(.Item("BTCOA1"))
                    sBTCOA2 = Trim(.Item("BTCOA2"))
                    sBTCOA3 = Trim(.Item("BTCOA3"))
                    sBTCOA4 = Trim(.Item("BTCOA4"))
                    sBTCOA5 = Trim(.Item("BTCOA5"))
                    sBTCOA6 = Trim(.Item("BTCOA6"))
                    sBTCOA7 = Trim(.Item("BTCOA7"))
                    sBTCOA8 = Trim(.Item("BTCOA8"))
                    sBTCOA9 = Trim(.Item("BTCOA9"))
                    sBTCOA10 = Trim(.Item("BTCOA10"))
                    sBTCOA11 = Trim(.Item("BTCOA11"))
                    sBTCOA12 = Trim(.Item("BTCOA12"))
                    sBTCOA13 = Trim(.Item("BTCOA13"))
                    sBTCOA14 = Trim(.Item("BTCOA14"))
                    sH2OFlow = Trim(.Item("H2OFlow"))
                End With
            End If

        Catch ex As Exception
            AddLogEntry("System.UpdateClass: " & ex.Message)
        End Try
    End Sub

    Property DatabasePath() As String
        Get
            Section = "System\Paths"
            DatabasePath = GetSetting(appName, Section, "DatabasePath", "SATCOMAINT")
        End Get
        Set(value As String)
            Section = "System\Paths"
            SaveSetting(appName, Section, "DatabasePath", value)
        End Set
    End Property
    Property ReportPath() As String
        Get
            Section = "System\Paths"
            ReportPath = GetSetting(appName, Section, "ReportPath", "C:\SATCO\Reports\")
        End Get
        Set(value As String)
            Section = "System\Paths"
            SaveSetting(appName, Section, "ReportPath", value)
        End Set
    End Property
    Property DocumentPath() As String
        Get
            Section = "System\Paths"
            DocumentPath = GetSetting(appName, Section, "DocumentPath", "C:\SATCO\Documents\")
        End Get
        Set(value As String)
            Section = "System\Paths"
            SaveSetting(appName, Section, "DocumentPath", value)
        End Set
    End Property
    Property WatchPath() As String
        Get
            Section = "System\Paths"
            WatchPath = GetSetting(appName, Section, "WatchPath", "C:\SATCO\Watch\")
        End Get
        Set(value As String)
            Section = "System\Paths"
            SaveSetting(appName, Section, "WatchPath", value)
        End Set
    End Property

    Property TLSN() As String
        Get
            Section = "ADU"
            TLSN = GetSetting(appName, Section, "TLSN", "")
        End Get
        Set(value As String)
            Section = "ADU"
            SaveSetting(appName, Section, "TLSN", value)
        End Set
    End Property

    Property TSSN() As String
        Get
            Section = "ADU"
            TSSN = GetSetting(appName, Section, "TSSN", "")
        End Get
        Set(value As String)
            Section = "ADU"
            SaveSetting(appName, Section, "TSSN", value)
        End Set
    End Property
    Public ReadOnly Property ScaleSettings() As String
        Get
            Dim SystemOptions As clsSystem

            SystemOptions = New clsSystem

            ScaleSettings = ""

            Select Case SystemOptions.ScalePort
                Case 0
                    ScaleSettings = "COM1"
                Case 1
                    ScaleSettings = "COM2"
                Case 2
                    ScaleSettings = "COM3"
                Case 3
                    ScaleSettings = "COM4"
                Case 4
                    ScaleSettings = "COM5"
                Case 5
                    ScaleSettings = "COM6"
                Case Else
                    ScaleSettings = "COM1"
            End Select

            Select Case SystemOptions.ScaleBaud
                Case 1
                    ScaleSettings = ScaleSettings & ",2400"
                Case 2
                    ScaleSettings = ScaleSettings & ",4800"
                Case 3
                    ScaleSettings = ScaleSettings & ",9600"
                Case 4
                    ScaleSettings = ScaleSettings & ",14400"
                Case 5
                    ScaleSettings = ScaleSettings & ",19200"
                Case 6
                    ScaleSettings = ScaleSettings & ",38400"
                Case Else
                    ScaleSettings = ScaleSettings & ",9600"
            End Select

            Select Case SystemOptions.ScaleParity
                Case 0
                    ScaleSettings = ScaleSettings & ",N"
                Case 1
                    ScaleSettings = ScaleSettings & ",E"
                Case 2
                    ScaleSettings = ScaleSettings & ",O"
                Case 3
                    ScaleSettings = ScaleSettings & ",S"
                Case Else
                    ScaleSettings = ScaleSettings & ",M"
            End Select

            Select Case SystemOptions.ScaleDataBits
                Case 0
                    ScaleSettings = ScaleSettings & ",7"
                Case 1
                    ScaleSettings = ScaleSettings & ",8"
                Case Else
                    ScaleSettings = ScaleSettings & ",8"
            End Select

            Select Case SystemOptions.ScaleStopBits
                Case 0
                    ScaleSettings = ScaleSettings & ",1"
                Case 1
                    ScaleSettings = ScaleSettings & ",2"
                Case Else
                    ScaleSettings = ScaleSettings & ",1"
            End Select

            SystemOptions = Nothing
        End Get

    End Property

    Property ScaleIP() As String
        Get
            Section = "System\Scale"
            ScaleIP = GetSetting(appName, Section, "IP", "100.100.100.000")
        End Get
        Set(value As String)
            Section = "System\Scale"
            SaveSetting(appName, Section, "IP", value)
        End Set
    End Property
    Property LogProcess() As Integer
        Get
            Section = "System"
            LogProcess = GetSetting(appName, Section, "Log", 0)
        End Get
        Set(value As Integer)
            Section = "System"
            SaveSetting(appName, Section, "Log", value)
        End Set
    End Property
    Property ScalePort() As Integer
        Get
            Section = "System\Scale"
            ScalePort = GetSetting(appName, Section, "Port", "0")
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "Port", value)
        End Set
    End Property
    Property ScaleBaud() As Integer
        Get
            Section = "System\Scale"
            ScaleBaud = GetSetting(appName, Section, "Baud", "3")
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "Baud", value)
        End Set
    End Property
    Public Property ScaleParity() As Integer
        Get
            Section = "System\Scale"
            ScaleParity = GetSetting(appName, Section, "Parity", "0")
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "Parity", value)
        End Set
    End Property
    Public Property ScaleDataBits() As Integer
        Get
            Section = "System\Scale"
            ScaleDataBits = GetSetting(appName, Section, "DataBits", "1")
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "DataBits", value)
        End Set
    End Property
    Public Property ScaleStopBits() As Integer
        Get
            Section = "System\Scale"
            ScaleStopBits = GetSetting(appName, Section, "StopBits", "0")
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "StopBits", value)
        End Set
    End Property
    Public Property ScaleNumber() As Integer
        Get
            Section = "System\Scale"
            ScaleNumber = GetSetting(appName, Section, "Number", "1")
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "Number", value)
        End Set
    End Property
    Public Property ScaleActive() As Integer
        Get
            Section = "System\Scale"
            ScaleActive = GetSetting(appName, Section, "Active", 0)
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "Active", value)
        End Set
    End Property
    Public Property ScaleStatus() As Integer
        Get
            Section = "System\Scale"
            ScaleStatus = GetSetting(appName, Section, "Status", 0)
        End Get
        Set(value As Integer)
            Section = "System\Scale"
            SaveSetting(appName, Section, "Status", value)
        End Set
    End Property
    Public Property CurrentTab() As Integer
        Get
            Section = "System"
            CurrentTab = GetSetting(appName, Section, "Current Tab", "0")
        End Get
        Set(value As Integer)
            Section = "System"
            SaveSetting(appName, Section, "Current Tab", value)
        End Set
    End Property

    Public Property ActiveOperator() As String
        Get
            Section = "System"
            ActiveOperator = GetSetting(appName, Section, "Active Operator", "")
        End Get
        Set(value As String)
            Section = "System"
            SaveSetting(appName, Section, "Active Operator", value)
        End Set
    End Property
    Public Property ArchiveDate() As String
        Get
            Section = "System"
            ArchiveDate = GetSetting(appName, Section, "Archive Date", Format(Now, "MM/dd/yyyy"))
        End Get
        Set(value As String)
            Section = "System"
            SaveSetting(appName, Section, "Archive Date", value)
        End Set
    End Property
    Public Property TareWeightHigh() As Long
        Get
            Section = "System\Variables"
            TareWeightHigh = GetSetting(appName, Section, "TareWeightHigh", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "TareWeightHigh", value)
        End Set
    End Property
    Public Property TareWeightLow() As Long
        Get
            Section = "System\Variables"
            TareWeightLow = GetSetting(appName, Section, "TareWeightLow", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "TareWeightLow", value)
        End Set
    End Property
    Public Property BNCapacityMin() As Long
        Get
            Section = "System\Variables"
            BNCapacityMin = GetSetting(appName, Section, "BNCapacityMin", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "BNCapacityMin", value)
        End Set
    End Property
    Public Property BNCapacityMax() As Long
        Get
            Section = "System\Variables"
            BNCapacityMax = GetSetting(appName, Section, "BNCapacityMax", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "BNCapacityMax", value)
        End Set
    End Property
    Public Property MOCapacityMin() As Long
        Get
            Section = "System\Variables"
            MOCapacityMin = GetSetting(appName, Section, "MOCapacityMin", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MOCapacityMin", value)
        End Set
    End Property
    Public Property MOCapacityMax() As Long
        Get
            Section = "System\Variables"
            MOCapacityMax = GetSetting(appName, Section, "MOCapacityMax", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MOCapacityMax", value)
        End Set
    End Property

    Public Property SACapacityMin() As Long
        Get
            Section = "System\Variables"
            SACapacityMin = GetSetting(appName, Section, "SACapacityMin", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "SACapacityMin", value)
        End Set
    End Property
    Public Property SACapacityMax() As Long
        Get
            Section = "System\Variables"
            SACapacityMax = GetSetting(appName, Section, "SACapacityMax", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "SACapacityMax", value)
        End Set
    End Property

    Public Property MaxFillWeight() As Long
        Get
            Section = "System\Variables"
            MaxFillWeight = GetSetting(appName, Section, "MaxFillWeight", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MaxFillWeight", value)
        End Set
    End Property

    Public Property MinFillWeight() As Long
        Get
            Section = "System\Variables"
            MinFillWeight = GetSetting(appName, Section, "MinFillWeight", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MinFillWeight", value)
        End Set
    End Property

    Public Property MOMaxFillWeight() As Long
        Get
            Section = "System\Variables"
            MOMaxFillWeight = GetSetting(appName, Section, "MO MaxFillWeight", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MO MaxFillWeight", value)
        End Set
    End Property

    Public Property MOMinFillWeight() As Long
        Get
            Section = "System\Variables"
            MOMinFillWeight = GetSetting(appName, Section, "MO MinFillWeight", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MO MinFillWeight", value)
        End Set
    End Property
    Public Property VariableWt() As Long
        Get
            Section = "System\Variables"
            VariableWt = GetSetting(appName, Section, "VariableWt", 0)
        End Get
        Set(value As Long)
            Section = "System\Variables"
            SaveSetting(appName, Section, "VariableWt", value)
        End Set
    End Property
    Public Property ReadDelay() As Integer
        Get
            Section = "System\Variables"
            ReadDelay = GetSetting(appName, Section, "ReadDelay", 2)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "ReadDelay", value)
        End Set
    End Property
    Public Property SANumberOfTickets() As Integer
        Get
            Section = "System\Variables"
            SANumberOfTickets = GetSetting(appName, Section, "SANumberOfTickets", 2)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "SANumberOfTickets", value)
        End Set
    End Property
    Public Property UMOumberOfTickets() As Integer
        Get
            Section = "System\Variables"
            UMOumberOfTickets = GetSetting(appName, Section, "UMOumberOfTickets", 2)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "UMOumberOfTickets", value)
        End Set
    End Property
    Public Property MONumberOfTickets() As Integer
        Get
            Section = "System\Variables"
            MONumberOfTickets = GetSetting(appName, Section, "MONumberOfTickets", 2)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "MONumberOfTickets", value)
        End Set
    End Property
    Public Property BNNumberOfTickets() As Integer
        Get
            Section = "System\Variables"
            BNNumberOfTickets = GetSetting(appName, Section, "BNNumberOfTickets", 2)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "BNNumberOfTickets", value)
        End Set
    End Property
    Public Property HazmatActive() As Integer
        Get
            Section = "System\Variables"
            HazmatActive = GetSetting(appName, Section, "HazmatActive", 0)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "HazmatActive", value)
        End Set
    End Property
    Public Property ManualTicket() As Integer
        Get
            Section = "System\Variables"
            ManualTicket = GetSetting(appName, Section, "ManualTicket", 2)
        End Get
        Set(value As Integer)
            Section = "System\Variables"
            SaveSetting(appName, Section, "ManualTicket", value)
        End Set
    End Property

    Public Property MOGravity() As String
        Get
            MOGravity = sMOGravity
        End Get
        Set(value As String)
            sMOGravity = value
        End Set
    End Property

    Public Property MOppg() As String
        Get
            MOppg = sMOppg
        End Get
        Set(value As String)
            sMOppg = value
        End Set
    End Property
    Public Property MODate() As String
        Get
            MODate = sMODate
        End Get
        Set(value As String)
            sMODate = value
        End Set
    End Property
    Public Property MOProduct() As String
        Get
            MOProduct = sMOProduct
        End Get
        Set(value As String)
            sMOProduct = value
        End Set
    End Property
    Public Property MOTotalNi() As String
        Get
            MOTotalNi = sMOTotalNi
        End Get
        Set(value As String)
            sMOTotalNi = value
        End Set
    End Property
    Public Property MOUreaNi() As String
        Get
            MOUreaNi = sMOUreaNi
        End Get
        Set(value As String)
            sMOUreaNi = value
        End Set
    End Property

    Public Property MONitrate() As String
        Get
            MONitrate = sMONitrate
        End Get
        Set(value As String)
            sMONitrate = value
        End Set
    End Property


    Public Property BNGravity() As String
        Get
            BNGravity = sBNGravity
        End Get
        Set(value As String)
            sBNGravity = value
        End Set
    End Property
    Public Property BNppg() As String
        Get
            BNppg = sBNppg
        End Get
        Set(value As String)
            sBNppg = value
        End Set
    End Property
    Public Property BNCOA1() As String
        Get
            BNCOA1 = sBNCOA1
        End Get
        Set(value As String)
            sBNCOA1 = value
        End Set
    End Property
    Public Property BNCOA2() As String
        Get
            BNCOA2 = sBNCOA2
        End Get
        Set(value As String)
            sBNCOA2 = value
        End Set
    End Property
    Public Property BNCOA3() As String
        Get
            BNCOA3 = sBNCOA3
        End Get
        Set(value As String)
            sBNCOA3 = value
        End Set
    End Property
    Public Property BNCOA4() As String
        Get
            BNCOA4 = sBNCOA4
        End Get
        Set(value As String)
            sBNCOA4 = value
        End Set
    End Property
    Public Property BNCOA5() As String
        Get
            BNCOA5 = sBNCOA5
        End Get
        Set(value As String)
            sBNCOA5 = value
        End Set
    End Property
    Public Property BNCOA6() As String
        Get
            BNCOA6 = sBNCOA6
        End Get
        Set(value As String)
            sBNCOA6 = value
        End Set
    End Property
    Public Property BNCOA7() As String
        Get
            BNCOA7 = sBNCOA7
        End Get
        Set(value As String)
            sBNCOA7 = value
        End Set
    End Property
    Public Property BNCOA8() As String
        Get
            BNCOA8 = sBNCOA8
        End Get
        Set(value As String)
            sBNCOA8 = value
        End Set
    End Property
    Public Property BNCOA9() As String
        Get
            BNCOA9 = sBNCOA9
        End Get
        Set(value As String)
            sBNCOA9 = value
        End Set
    End Property
    Public Property BNCOA10() As String
        Get
            BNCOA10 = sBNCOA10
        End Get
        Set(value As String)
            sBNCOA10 = value
        End Set
    End Property
    Public Property BNCOA11() As String
        Get
            BNCOA11 = sBNCOA11
        End Get
        Set(value As String)
            sBNCOA11 = value
        End Set
    End Property
    Public Property BNCOA12() As String
        Get
            BNCOA12 = sBNCOA12
        End Get
        Set(value As String)
            sBNCOA12 = value
        End Set
    End Property
    Public Property BNCOA13() As String
        Get
            BNCOA13 = sBNCOA13
        End Get
        Set(value As String)
            sBNCOA13 = value
        End Set
    End Property
    Public Property BNCOA14() As String
        Get
            BNCOA14 = sBNCOA14
        End Get
        Set(value As String)
            sBNCOA14 = value
        End Set
    End Property

    Public Property BTGravity() As String
        Get
            BTGravity = sBTGravity
        End Get
        Set(value As String)
            sBTGravity = value
        End Set
    End Property
    Public Property BTppg() As String
        Get
            BTppg = sBTppg
        End Get
        Set(value As String)
            sBTppg = value
        End Set
    End Property
    Public Property BTCOA1() As String
        Get
            BTCOA1 = sBTCOA1
        End Get
        Set(value As String)
            sBTCOA1 = value
        End Set
    End Property
    Public Property BTCOA2() As String
        Get
            BTCOA2 = sBTCOA2
        End Get
        Set(value As String)
            sBTCOA2 = value
        End Set
    End Property
    Public Property BTCOA3() As String
        Get
            BTCOA3 = sBTCOA3
        End Get
        Set(value As String)
            sBTCOA3 = value
        End Set
    End Property
    Public Property BTCOA4() As String
        Get
            BTCOA4 = sBTCOA4
        End Get
        Set(value As String)
            sBTCOA4 = value
        End Set
    End Property
    Public Property BTCOA5() As String
        Get
            BTCOA5 = sBTCOA5
        End Get
        Set(value As String)
            sBTCOA5 = value
        End Set
    End Property
    Public Property BTCOA6() As String
        Get
            BTCOA6 = sBTCOA6
        End Get
        Set(value As String)
            sBTCOA6 = value
        End Set
    End Property
    Public Property BTCOA7() As String
        Get
            BTCOA7 = sBTCOA7
        End Get
        Set(value As String)
            sBTCOA7 = value
        End Set
    End Property
    Public Property BTCOA8() As String
        Get
            BTCOA8 = sBTCOA8
        End Get
        Set(value As String)
            sBTCOA8 = value
        End Set
    End Property
    Public Property BTCOA9() As String
        Get
            BTCOA9 = sBTCOA9
        End Get
        Set(value As String)
            sBTCOA9 = value
        End Set
    End Property
    Public Property BTCOA10() As String
        Get
            BTCOA10 = sBTCOA10
        End Get
        Set(value As String)
            sBTCOA10 = value
        End Set
    End Property
    Public Property BTCOA11() As String
        Get
            BTCOA11 = sBTCOA11
        End Get
        Set(value As String)
            sBTCOA11 = value
        End Set
    End Property
    Public Property BTCOA12() As String
        Get
            BTCOA12 = sBTCOA12
        End Get
        Set(value As String)
            sBTCOA12 = value
        End Set
    End Property
    Public Property BTCOA13() As String
        Get
            BTCOA13 = sBTCOA13
        End Get
        Set(value As String)
            sBTCOA13 = value
        End Set
    End Property
    Public Property BTCOA14() As String
        Get
            BTCOA14 = sBTCOA14
        End Get
        Set(value As String)
            sBTCOA14 = value
        End Set
    End Property
    Public Property H2OFlow() As String
        Get
            H2OFlow = sH2OFlow
        End Get
        Set(value As String)
            sH2OFlow = value
        End Set
    End Property

    Public Property CardReaderPort() As Integer
        Get
            Section = "System\CardReader"
            CardReaderPort = GetSetting(appName, Section, "Port", "0")
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Port", value)
        End Set
    End Property
    Public Property CardReaderBaud() As Integer
        Get
            Section = "System\CardReader"
            CardReaderBaud = GetSetting(appName, Section, "Baud", "3")
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Baud", value)
        End Set
    End Property
    Public Property CardReaderParity() As Integer
        Get
            Section = "System\CardReader"
            CardReaderParity = GetSetting(appName, Section, "Parity", "0")
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Parity", value)
        End Set
    End Property
    Public Property CardReaderDataBits() As Integer
        Get
            Section = "System\CardReader"
            CardReaderDataBits = GetSetting(appName, Section, "DataBits", "1")
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "DataBits", value)
        End Set
    End Property
    Public Property CardReaderStopBits() As Integer
        Get
            Section = "System\CardReader"
            CardReaderStopBits = GetSetting(appName, Section, "StopBits", "0")
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "StopBits", value)
        End Set
    End Property
    Public Property CardReaderStatus() As Integer
        Get
            Section = "System\CardReader"
            CardReaderStatus = GetSetting(appName, Section, "Status", "1")
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Status", value)
        End Set
    End Property
    Public Property CardReaderActive() As Integer
        Get
            Section = "System\CardReader"
            CardReaderActive = GetSetting(appName, Section, "Active", 0)
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Active", value)
        End Set
    End Property
    Public Property CardReaderStart() As Integer
        Get
            Section = "System\CardReader"
            CardReaderStart = GetSetting(appName, Section, "Start", 6)
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Start", value)
        End Set
    End Property
    Public Property CardReaderLength() As Integer
        Get
            Section = "System\CardReader"
            CardReaderLength = GetSetting(appName, Section, "Length", 5)
        End Get
        Set(value As Integer)
            Section = "System\CardReader"
            SaveSetting(appName, Section, "Length", value)
        End Set
    End Property

    Property DriverWarning() As Integer
        Get
            DriverWarning = iDriverWarning
        End Get
        Set(value As Integer)
            iDriverWarning = value
        End Set
    End Property

    Property DriverTraining() As Integer
        Get
            DriverTraining = iDriverTraining
        End Get
        Set(value As Integer)
            iDriverTraining = value
        End Set
    End Property

    Property DriverExpires() As Integer
        Get
            DriverExpires = iDriverExpires
        End Get
        Set(value As Integer)
            iDriverExpires = value
        End Set
    End Property

    Property DriverTWIC() As Integer
        Get
            DriverTWIC = iDriverTWIC
        End Get
        Set(value As Integer)
            iDriverTWIC = value
        End Set
    End Property

    Public ReadOnly Property CardReaderSettings() As String
        Get
            Dim SystemOptions As clsSystem

            SystemOptions = New clsSystem

            CardReaderSettings = ""

            Select Case SystemOptions.CardReaderPort
                Case 0
                    CardReaderSettings = "COM1"
                Case 1
                    CardReaderSettings = "COM2"
                Case 2
                    CardReaderSettings = "COM3"
                Case 3
                    CardReaderSettings = "COM4"
                Case 4
                    CardReaderSettings = "COM5"
                Case 5
                    CardReaderSettings = "COM6"
                Case Else
                    CardReaderSettings = "COM1"
            End Select

            Select Case SystemOptions.CardReaderBaud
                Case 1
                    CardReaderSettings = CardReaderSettings & ",2400"
                Case 2
                    CardReaderSettings = CardReaderSettings & ",4800"
                Case 3
                    CardReaderSettings = CardReaderSettings & ",9600"
                Case 4
                    CardReaderSettings = CardReaderSettings & ",14400"
                Case 5
                    CardReaderSettings = CardReaderSettings & ",19200"
                Case 6
                    CardReaderSettings = CardReaderSettings & ",38400"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",9600"
            End Select

            Select Case SystemOptions.CardReaderParity
                Case 0
                    CardReaderSettings = CardReaderSettings & ",N"
                Case 1
                    CardReaderSettings = CardReaderSettings & ",E"
                Case 2
                    CardReaderSettings = CardReaderSettings & ",O"
                Case 3
                    CardReaderSettings = CardReaderSettings & ",S"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",M"
            End Select

            Select Case SystemOptions.CardReaderDataBits
                Case 0
                    CardReaderSettings = CardReaderSettings & ",7"
                Case 1
                    CardReaderSettings = CardReaderSettings & ",8"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",8"
            End Select

            Select Case SystemOptions.CardReaderStopBits
                Case 0
                    CardReaderSettings = CardReaderSettings & ",1"
                Case 1
                    CardReaderSettings = CardReaderSettings & ",2"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",1"
            End Select

            SystemOptions = Nothing
        End Get

    End Property

    Public Property AccessReaderPort() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderPort = GetSetting(appName, Section, "Port", "0")
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Port", value)
        End Set
    End Property
    Public Property AccessReaderBaud() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderBaud = GetSetting(appName, Section, "Baud", "3")
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Baud", value)
        End Set
    End Property
    Public Property AccessReaderParity() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderParity = GetSetting(appName, Section, "Parity", "0")
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Parity", value)
        End Set
    End Property
    Public Property AccessReaderDataBits() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderDataBits = GetSetting(appName, Section, "DataBits", "1")
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "DataBits", value)
        End Set
    End Property
    Public Property AccessReaderStopBits() As Integer
        Get
            Section = "SystemAccessReader"
            AccessReaderStopBits = GetSetting(appName, Section, "StopBits", "0")
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "StopBits", value)
        End Set
    End Property
    Public Property AccessReaderStatus() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderStatus = GetSetting(appName, Section, "Status", "1")
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Status", value)
        End Set
    End Property
    Public Property AccessReaderActive() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderActive = GetSetting(appName, Section, "Active", 0)
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Active", value)
        End Set
    End Property
    Public Property AccessReaderStart() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderStart = GetSetting(appName, Section, "Start", 6)
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Start", value)
        End Set
    End Property
    Public Property AccessReaderLength() As Integer
        Get
            Section = "System\AccessReader"
            AccessReaderLength = GetSetting(appName, Section, "Length", 5)
        End Get
        Set(value As Integer)
            Section = "System\AccessReader"
            SaveSetting(appName, Section, "Length", value)
        End Set
    End Property

    Public ReadOnly Property AccessReaderSettings() As String
        Get
            Dim SystemOptions As clsSystem

            SystemOptions = New clsSystem

            AccessReaderSettings = ""

            Select Case SystemOptions.AccessReaderPort
                Case 0
                    AccessReaderSettings = "COM1"
                Case 1
                    AccessReaderSettings = "COM2"
                Case 2
                    AccessReaderSettings = "COM3"
                Case 3
                    AccessReaderSettings = "COM4"
                Case 4
                    AccessReaderSettings = "COM5"
                Case Else
                    AccessReaderSettings = "COM1"
            End Select

            Select Case SystemOptions.AccessReaderBaud
                Case 1
                    AccessReaderSettings = AccessReaderSettings & ",2400"
                Case 2
                    AccessReaderSettings = AccessReaderSettings & ",4800"
                Case 3
                    AccessReaderSettings = AccessReaderSettings & ",9600"
                Case 4
                    AccessReaderSettings = AccessReaderSettings & ",14400"
                Case 5
                    AccessReaderSettings = AccessReaderSettings & ",19200"
                Case 6
                    AccessReaderSettings = AccessReaderSettings & ",38400"
                Case Else
                    AccessReaderSettings = AccessReaderSettings & ",9600"
            End Select

            Select Case SystemOptions.AccessReaderParity
                Case 0
                    AccessReaderSettings = AccessReaderSettings & ",N"
                Case 1
                    AccessReaderSettings = AccessReaderSettings & ",E"
                Case 2
                    AccessReaderSettings = AccessReaderSettings & ",O"
                Case 3
                    AccessReaderSettings = AccessReaderSettings & ",S"
                Case Else
                    AccessReaderSettings = AccessReaderSettings & ",M"
            End Select

            Select Case SystemOptions.CardReaderDataBits
                Case 0
                    AccessReaderSettings = AccessReaderSettings & ",7"
                Case 1
                    AccessReaderSettings = AccessReaderSettings & ",8"
                Case Else
                    AccessReaderSettings = AccessReaderSettings & ",8"
            End Select

            Select Case SystemOptions.CardReaderStopBits
                Case 0
                    AccessReaderSettings = AccessReaderSettings & ",1"
                Case 1
                    AccessReaderSettings = AccessReaderSettings & ",2"
                Case Else
                    AccessReaderSettings = AccessReaderSettings & ",1"
            End Select

            SystemOptions = Nothing
        End Get
    End Property

End Class
