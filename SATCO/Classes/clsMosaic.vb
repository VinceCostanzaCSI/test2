Imports System.Reflection
Imports System.IO

Public Class clsMosaic
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sRelease As String      'local copy
    Private sConsignee As String    'local copy
    Private sDeliveryDate As String  'local copy
    Private sProduct As String      'local copy
    Private sDocItem As String      'local copy
    Private sShipTo As String       'local copy
    Private sQuantity As String     'local copy
    Private bActive As Boolean      'local copy

    Private bStatus As Boolean

    Private sCurrentId As String    'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(CurrentId As String)

        Try
            Dim UpdateCmd As String = "UPDATE Mosaic " & _
                                      "SET Release ='" & sRelease & "' , " & _
                                      "Consignee ='" & sConsignee & "' , " & _
                                      "DeliveryDate ='" & sDeliveryDate & "' , " & _
                                      "Product ='" & sProduct & "' , " & _
                                      "DocItem ='" & sDocItem & "' , " & _
                                      "ShipTo ='" & sShipTo & "' , " & _
                                      "Quantity ='" & sQuantity & "' , " & _
                                      "Active ='" & bActive & "' " & _
                                      "WHERE Release = '" & CurrentId & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Mosaic File")
            Else
                AddLogEntry("Mosaic File Updated")
            End If

        Catch ex As Exception
            AddLogEntry("MOUpdateRecord: " & ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurentId As String)
        Try
            sRelease = CurentId
            Dim strInsert As String = "INSERT INTO Mosaic (Release, Consignee, DeliveryDate, Product, DocItem, ShipTo, Quantity, Active) " & _
                                         "VALUES (" & _
                                         "'" & sRelease & "'," & _
                                         "'" & sConsignee & "'," & _
                                         "'" & sDeliveryDate & "'," & _
                                         "'" & sProduct & "'," & _
                                         "'" & sDocItem & "'," & _
                                         "'" & sShipTo & "'," & _
                                         "'" & sQuantity & "'," & _
                                         "'" & bActive & "') "
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
            AddLogEntry("MOAddRecord: " & ex.Message)
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Mosaic where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Mosaic where Release ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteMosaic: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String) As Boolean
        Try
            SQL.RunQuery("Select * from Mosaic where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Mosaic Record " & CurrentId & " not found")
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sRelease = .Item("Release")
                    sConsignee = .Item("Consignee")
                    sDeliveryDate = .Item("DeliveryDate")
                    sProduct = .Item("Product")
                    sDocItem = .Item("DocItem")
                    sShipTo = .Item("ShipTo")
                    sQuantity = .Item("Quantity")
                    bActive = .Item("Active")
                End With
                FindRecord = True
            End If

        Catch ex As Exception
            AddLogEntry("MOFindRecord: " & ex.Message)
            FindRecord = False
        End Try
    End Function

    Public Sub UpdateActivity(ByVal CurrentId As String, ActiveChange As Boolean)
        Try
            SQL.RunQuery("Update Mosaic Set Active = '" & ActiveChange & "' where Release = '" & CurrentId & "' ")

        Catch ex As Exception
            AddLogEntry("UpdateMosaic: " & ex.Message)
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
    Public Property DocItem() As String
        Get
            DocItem = sDocItem
        End Get
        Set(value As String)
            sDocItem = value
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
            CurrentId = GetSetting(appName, "Current\Mosaic", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\Mosaic", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "Mosaic\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Mosaic\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "Mosaic\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Mosaic\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property

End Class
