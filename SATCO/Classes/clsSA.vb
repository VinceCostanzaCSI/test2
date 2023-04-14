Imports System.Reflection
Imports System.IO

Public Class clsSA
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sRelease As String      'local copy
    Private sConsignee As String    'local copy
    Private sDeliveryDate As String 'local copy
    Private sProduct As String      'local copy
    Private sAnalysis As String     'local copy
    Private sTank As String         'local copy
    Private sShipTo As String       'local copy
    Private sQuantity As String     'local copy
    Private sPO As String           'local copy
    Private bActive As Boolean      'local copy

    Private bStatus As Boolean

    Private sCurrentId As String    'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(CurrentId As String)

        Try
            Dim UpdateCmd As String = "UPDATE SA " &
                                      "SET Release ='" & sRelease & "' , " &
                                      "Consignee ='" & sConsignee & "' , " &
                                      "DeliveryDate ='" & sDeliveryDate & "' , " &
                                      "Product ='" & sProduct & "' , " &
                                      "Analysis ='" & sAnalysis & "' , " &
                                      "Tank ='" & sTank & "' , " &
                                      "ShipTo ='" & sShipTo & "' , " &
                                      "Quantity ='" & sQuantity & "' , " &
                                      "PO ='" & sPO & "' , " &
                                      "Active ='" & bActive & "' " &
                                      "WHERE Release = '" & CurrentId & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating SA File")
            Else
                AddLogEntry("SA File Updated")
            End If

        Catch ex As Exception
            AddLogEntry("SAUpdateRecord: " & ex.Message)
            'Stop
        End Try

    End Sub

    Public Function AddRecord(CurentId As String)
        Try
            sRelease = CurentId
            Dim strInsert As String = "INSERT INTO SA (Release, Consignee, DeliveryDate, Product, Analysis, Tank, ShipTo, PO, Quantity, Active) " &
                                         "VALUES (" &
                                         "'" & sRelease & "'," &
                                         "'" & sConsignee & "'," &
                                         "'" & sDeliveryDate & "'," &
                                         "'" & sProduct & "'," &
                                         "'" & sAnalysis & "'," &
                                         "'" & sTank & "'," &
                                         "'" & sShipTo & "'," &
                                         "'" & sPO & "'," &
                                         "'" & sQuantity & "'," &
                                         "'" & bActive & "') "
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
            AddLogEntry("SAAddRecord: " & ex.Message)
            'Stop
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from SA where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM SA where Release ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteSA: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from SA where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("SA Record " & CurrentId & " not found")
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sRelease = .Item("Release")
                    sConsignee = .Item("Consignee")
                    sDeliveryDate = .Item("DeliveryDate")
                    sProduct = .Item("Product")
                    sAnalysis = .Item("Analysis")
                    sTank = .Item("Tank")
                    sShipTo = .Item("ShipTo")
                    sPO = .Item("PO") & ""
                    sQuantity = .Item("Quantity")
                    bActive = .Item("Active")
                End With
                FindRecord = True
            End If

        Catch ex As Exception
            AddLogEntry("SAFindRecord: " & ex.Message)
            FindRecord = False
        End Try
    End Function

    Public Sub UpdateActivity(ByVal CurrentId As String, ActiveChange As Boolean)
        Try
            SQL.RunQuery("Update SA Set Active = '" & ActiveChange & "' where Release = '" & CurrentId & "' ")

        Catch ex As Exception
            AddLogEntry("UpdateSA: " & ex.Message)
        End Try
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

    Property Release() As String
        Get
            Release = sRelease
        End Get
        Set(value As String)
            sRelease = value
        End Set
    End Property
    Public Property Consignee() As String
        Get
            Consignee = sConsignee
        End Get
        Set(value As String)
            sConsignee = value
        End Set
    End Property
    Public Property DeliveryDate() As String
        Get
            DeliveryDate = sDeliveryDate
        End Get
        Set(value As String)
            sDeliveryDate = value
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
    Public Property Tank() As String
        Get
            Tank = sTank
        End Get
        Set(value As String)
            sTank = value
        End Set
    End Property
    Public Property ShipTo() As String
        Get
            ShipTo = sShipTo
        End Get
        Set(value As String)
            sShipTo = value
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

    Public Property Quantity() As String
        Get
            Quantity = sQuantity
        End Get
        Set(value As String)
            sQuantity = value
        End Set
    End Property
    Public Property Product() As String
        Get
            Product = sProduct
        End Get
        Set(value As String)
            sProduct = value
        End Set
    End Property
    Public Property Active() As Boolean
        Get
            Active = bActive
        End Get
        Set(value As Boolean)
            bActive = value
        End Set
    End Property
    Public Property Status() As Boolean
        Get
            Status = bStatus
        End Get
        Set(value As Boolean)
            bStatus = value
        End Set
    End Property
    Public Property CurrentId() As String
        Get
            CurrentId = GetSetting(appName, "Current\SA", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\SA", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "SA\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "SA\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "SA\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "SA\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property
End Class
