Imports System.Reflection
Imports System.IO

Public Class clsTransaction
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sCode As String             'local copy
    Private lId As Long                 'local copy
    Private dTDate As Date              'local copy
    Private sDriverId As String         'local copy
    Private sVehicleId As String        'local copy
    Private sTrailerID As String        'local copy
    Private iScaleNumber As Integer     'local copy
    Private sTankId As String           'local copy
    Private sCommodity As String        'local copy
    Private lFillWt As Long             'local copy
    Private lGross As Long              'local copy
    Private lTare As Long               'local copy
    Private lNet As Long                'local copy
    Private sReleaseNumber As String    'local copy
    Private sPO As String               'local copy
    Private sScaleTicket As String      'local copy
    Private sInTime As String           'local copy
    Private sOutTime As String          'local copy
    Private dTankLevel As Double        'local copy
    Private sAnalysis As String         'local copy
    Private sDesc2 As String            'local copy
    Private sDesc3 As String            'local copy
    Private sDesc4 As String            'local copy
    Private sDesc5 As String            'local copy
    Private sSeal1 As String            'local copy
    Private sSeal2 As String            'local copy
    Private sSeal3 As String            'local copy
    Private sSeal4 As String            'local copy
    Private sAdjustment As String       'local copy

    Private bStatus As Boolean

    Private sCurrentId As String        'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(Code As String, Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE Trans " &
                                      "SET Id ='" & lId & "' , " &
                                      "DriverId ='" & sDriverId & "' , " &
                                      "TDate ='" & dTDate & "' , " &
                                      "InTime ='" & sInTime & "' , " &
                                      "OutTime ='" & sOutTime & "' , " &
                                      "Code ='" & sCode & "' , " &
                                      "TrailerId ='" & sTrailerID & "' , " &
                                      "VehicleId ='" & sVehicleId & "' , " &
                                      "TankId ='" & sTankId & "' , " &
                                      "ScaleNumber ='" & iScaleNumber & "' , " &
                                      "TargetFillWt ='" & lFillWt & "' , " &
                                      "CommodityId ='" & sCommodity & "' , " &
                                      "GrossWt ='" & lGross & "' , " &
                                      "TareWt ='" & lTare & "' , " &
                                      "NetWt ='" & lNet & "' , " &
                                      "ReleaseNumber ='" & sReleaseNumber & "' , " &
                                      "PO ='" & sPO & "' , " &
                                      "TankLevel ='" & dTankLevel & "' , " &
                                      "Analysis ='" & sAnalysis & "' , " &
                                      "Desc2 ='" & sDesc2 & "' , " &
                                      "Desc3 ='" & sDesc3 & "' , " &
                                      "Desc4 ='" & sDesc4 & "' , " &
                                      "Desc5 ='" & sDesc5 & "' , " &
                                      "Seal1 ='" & sSeal1 & "' , " &
                                      "Seal2 ='" & sSeal2 & "' , " &
                                      "Seal3 ='" & sSeal3 & "' , " &
                                      "Seal4 ='" & sSeal4 & "' , " &
                                      "Adjustment ='" & sAdjustment & "' " &
                                      "WHERE Id = '" & Id & "' and Code = '" & Code & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Trans File")
                'Stop
            Else
                AddLogEntry("Trans File Updated")
                'Stop
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            AddLogEntry("Trans.Update error " & ex.Message)
        End Try

    End Sub

    Public Function AddRecord()
        Try
            'lId = CurrentId
            Dim strInsert As String = "INSERT INTO Trans (Code, Id, TDate, DriverId, VehicleId, TrailerId, ScaleNumber, TankId, CommodityId, TargetFillWt," &
                                       " GrossWt, TareWt, NetWt, ReleaseNumber, PO, InTime, OutTime, TankLevel, Analysis, Desc2, Desc3, Desc4, Desc5, Seal1, Seal2, Seal3, Seal4, Adjustment) VALUES (" &
                                         "'" & sCode & "'," &
                                         "'" & lId & "'," &
                                         "'" & dTDate & "'," &
                                         "'" & sDriverId & "'," &
                                         "'" & sVehicleId & "'," &
                                         "'" & sTrailerID & "'," &
                                         "'" & iScaleNumber & "'," &
                                         "'" & sTankId & "'," &
                                         "'" & sCommodity & "'," &
                                         "'" & lFillWt & "'," &
                                         "'" & lGross & "'," &
                                         "'" & lTare & "'," &
                                         "'" & lNet & "'," &
                                         "'" & sReleaseNumber & "'," &
                                         "'" & sPO & "'," &
                                         "'" & sInTime & "'," &
                                         "'" & sOutTime & "'," &
                                         "'" & dTankLevel & "'," &
                                         "'" & sAnalysis & "'," &
                                         "'" & sDesc2 & "'," &
                                         "'" & sDesc3 & "'," &
                                         "'" & sDesc4 & "'," &
                                         "'" & sDesc5 & "'," &
                                         "'" & sSeal1 & "'," &
                                         "'" & sSeal2 & "'," &
                                         "'" & sSeal3 & "'," &
                                         "'" & sSeal4 & "'," &
                                         "'" & sAdjustment & "') "
            'Stop
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
            AddLogEntry("Trans.AddRecord error " & ex.Message)
            'Stop
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Trans where Id = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Trans where Id ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            'MsgBox("DeleteTransaction: " & ex.Message)
            AddLogEntry("Trans.Delete error " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String, Code As String)
        Try
            SQL.RunQuery("Select * from Trans where Id = '" & CurrentId & "' and Code = '" & Code & "'")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Trans Record not found: " & CurrentId & " Code: " & Code)
                EOF = True
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    lId = .Item("Id")
                    sDriverId = .Item("DriverId")
                    dTDate = .Item("TDate")
                    sInTime = .Item("InTime")
                    sOutTime = .Item("OutTime")
                    sCode = .Item("Code")
                    sTrailerID = .Item("TrailerId")
                    sVehicleId = .Item("VehicleId")
                    sTankId = .Item("TankId")
                    iScaleNumber = .Item("ScaleNumber")
                    lFillWt = .Item("TargetFillWt")
                    sCommodity = .Item("CommodityId")
                    lGross = .Item("GrossWt")
                    lTare = .Item("TareWt")
                    lNet = .Item("NetWt")
                    sReleaseNumber = .Item("ReleaseNumber")
                    sPO = .Item("PO") & ""
                    dTankLevel = .Item("TankLevel")
                    sAnalysis = .Item("Analysis")
                    sDesc2 = .Item("Desc2") & ""
                    sDesc3 = .Item("Desc3") & ""
                    sDesc4 = .Item("Desc4") & ""
                    sDesc5 = .Item("Desc5") & ""
                    sSeal1 = .Item("Seal1") & ""
                    sSeal2 = .Item("Seal2") & ""
                    sSeal3 = .Item("Seal3") & ""
                    sSeal4 = .Item("Seal4") & ""
                    sAdjustment = .Item("Adjustment")
                End With
            End If
            FindRecord = True
        Catch ex As Exception
            FindRecord = False
            AddLogEntry("Trans.FindRecord error " & ex.Message)
            EOF = True
        End Try
    End Function

    Public Function GetFirstRecord()
        Try
            SQL.RunQuery("Select Top 1 * from Trans")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Record not found")
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    lId = .Item("Id")
                    sDriverId = .Item("DriverId")
                    dTDate = .Item("TDate")
                    sInTime = .Item("InTime")
                    sOutTime = .Item("OutTime")
                    sCode = .Item("Code")
                    sTrailerID = .Item("TrailerId")
                    sVehicleId = .Item("VehicleId")
                    sTankId = .Item("TankId")
                    iScaleNumber = .Item("ScaleNumber")
                    lFillWt = .Item("TargetFillWt")
                    sCommodity = .Item("CommodityId")
                    lGross = .Item("GrossWt")
                    lTare = .Item("TareWt")
                    lNet = .Item("NetWt")
                    sReleaseNumber = .Item("ReleaseNumber")
                    sPO = .Item("PO") & ""
                    dTankLevel = .Item("TankLevel")
                    sAnalysis = .Item("Analysis")
                    sDesc2 = .Item("Desc2") & ""
                    sDesc3 = .Item("Desc3") & ""
                    sDesc4 = .Item("Desc4") & ""
                    sDesc5 = .Item("Desc5") & ""
                    sSeal1 = .Item("Seal1") & ""
                    sSeal2 = .Item("Seal2") & ""
                    sSeal3 = .Item("Seal3") & ""
                    sSeal4 = .Item("Seal4") & ""
                    sAdjustment = .Item("Adjustment")
                End With
            End If
            GetFirstRecord = True
        Catch ex As Exception
            GetFirstRecord = False
            AddLogEntry("Trans.GetFirst error " & ex.Message)
        End Try
    End Function

    Public Sub ClearClass()

        lId = 0
        sDriverId = ""
        dTDate = Now
        sInTime = "00:00"
        sOutTime = "00:00"
        dTankLevel = 0
        sAnalysis = ""
        sDesc2 = ""
        sDesc3 = ""
        sDesc4 = ""
        sDesc5 = ""
        sSeal1 = ""
        sSeal2 = ""
        sSeal3 = ""
        sSeal4 = ""
        sAdjustment = ""

    End Sub


    Property BOF() As Boolean
        Get
            BOF = bBOF
        End Get
        Set(value As Boolean)
            bBOF = value
        End Set
    End Property

    Property EOF() As Boolean
        Get
            EOF = bEOF
        End Get
        Set(value As Boolean)
            bEOF = value
        End Set
    End Property

    Property Id() As String
        Get
            Id = lId
        End Get
        Set(value As String)
            lId = value
        End Set
    End Property
    Public Property DriverId() As String
        Get
            DriverId = sDriverId
        End Get
        Set(value As String)
            sDriverId = value
        End Set
    End Property
    Public Property TDate() As Date
        Get
            TDate = dTDate
        End Get
        Set(value As Date)
            dTDate = value
        End Set
    End Property
    Public Property InTime() As String
        Get
            InTime = sInTime
        End Get
        Set(value As String)
            sInTime = value
        End Set
    End Property
    Public Property OutTime() As String
        Get
            OutTime = sOutTime
        End Get
        Set(value As String)
            sOutTime = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Code = sCode
        End Get
        Set(value As String)
            sCode = value
        End Set
    End Property
    Public Property VehicleID() As String
        Get
            VehicleID = sVehicleId
        End Get
        Set(value As String)
            sVehicleId = value
        End Set
    End Property
    Public Property TrailerID() As String
        Get
            TrailerID = sTrailerID
        End Get
        Set(value As String)
            sTrailerID = value
        End Set
    End Property
    Public Property TankId() As String
        Get
            TankId = sTankId
        End Get
        Set(value As String)
            sTankId = value
        End Set
    End Property
    Public Property ScaleNumber() As Integer
        Get
            ScaleNumber = iScaleNumber
        End Get
        Set(value As Integer)
            iScaleNumber = value
        End Set
    End Property
    Public Property FillWt() As Long
        Get
            FillWt = lFillWt
        End Get
        Set(value As Long)
            lFillWt = value
        End Set
    End Property
    Public Property Commodity() As String
        Get
            Commodity = sCommodity
        End Get
        Set(value As String)
            sCommodity = value
        End Set
    End Property
    Public Property Gross() As Long
        Get
            Gross = lGross
        End Get
        Set(value As Long)
            lGross = value
        End Set
    End Property
    Public Property Tare() As Long
        Get
            Tare = lTare
        End Get
        Set(value As Long)
            lTare = value
        End Set
    End Property
    Public Property Net() As Long
        Get
            Net = lNet
        End Get
        Set(value As Long)
            lNet = value
        End Set
    End Property
    Public Property ReleaseNumber() As String
        Get
            ReleaseNumber = sReleaseNumber
        End Get
        Set(value As String)
            sReleaseNumber = value
        End Set
    End Property

    Public Property PO() As String
        Get
            PO = sPO
        End Get
        Set(value As String)
            sPO = value
        End Set
    End Property

    Public Property TankLevel() As Double
        Get
            TankLevel = dTankLevel
        End Get
        Set(value As Double)
            dTankLevel = value
        End Set
    End Property
    Public Property Analysis() As String
        Get
            Analysis = sAnalysis
        End Get
        Set(value As String)
            sAnalysis = value
        End Set
    End Property

    Public Property Desc2() As String
        Get
            Desc2 = sDesc2
        End Get
        Set(value As String)
            sDesc2 = value
        End Set
    End Property
    Public Property Desc3() As String
        Get
            Desc3 = sDesc3
        End Get
        Set(value As String)
            sDesc3 = value
        End Set
    End Property
    Public Property Desc4() As String
        Get
            Desc4 = sDesc4
        End Get
        Set(value As String)
            sDesc4 = value
        End Set
    End Property
    Public Property Desc5() As String
        Get
            Desc5 = sDesc5
        End Get
        Set(value As String)
            sDesc5 = value
        End Set
    End Property

    Public Property Seal1() As String
        Get
            Seal1 = sSeal1
        End Get
        Set(value As String)
            sSeal1 = value
        End Set
    End Property
    Public Property Seal2() As String
        Get
            Seal2 = sSeal2
        End Get
        Set(value As String)
            sSeal2 = value
        End Set
    End Property
    Public Property Seal3() As String
        Get
            Seal3 = sSeal3
        End Get
        Set(value As String)
            sSeal3 = value
        End Set
    End Property
    Public Property Seal4() As String
        Get
            Seal4 = sSeal4
        End Get
        Set(value As String)
            sSeal4 = value
        End Set
    End Property
    Public Property Adjustment() As String
        Get
            Adjustment = sAdjustment
        End Get
        Set(value As String)
            sAdjustment = value
        End Set
    End Property
    Public Property CurrentId() As String
        Get
            CurrentId = GetSetting(appName, "Current\Transaction", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\Transaction", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "Transaction\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Transaction\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "Transaction\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Transaction\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property

End Class
