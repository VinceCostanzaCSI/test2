Imports System.Reflection
Imports System.IO

Public Class clsWeighIn
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sVehicleId As String        'local copy
    Private sTrailerID As String        'local copy
    Private nGross As Double            'local copy
    Private nTare As Double             'local copy
    Private nNet As Double              'local copy
    Private dDateTime As Date           'local copy
    Private bStatus As Boolean

    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE WeighIn " & _
                                      "SET VehicleId ='" & sVehicleId & "' , " & _
                                      "TrailerId ='" & sTrailerID & "' , " & _
                                      "DateTime ='" & dDateTime & "'," & _
                                      "Gross ='" & nGross & "' , " & _
                                      "Tare ='" & nTare & "' , " & _
                                      "Net ='" & nNet & "' " & _
                                      "WHERE VehicleId = '" & Id & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating WeighIn File")
                'Stop
            Else
                AddLogEntry("WeighIn File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurrentId As String)
        Try
            sVehicleId = CurrentId
            Dim strInsert As String = "INSERT INTO WeighIn (VehicleId, TrailerId, Gross, Tare, Net, DateTime) " & _
                                         "VALUES (" & _
                                         "'" & sVehicleId & "'," & _
                                         "'" & sTrailerID & "'," & _
                                         "'" & nGross & "'," & _
                                         "'" & nTare & "'," & _
                                         "'" & nNet & "'," & _
                                         "'" & dDateTime & "') "
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
            AddLogEntry("AddWeighIn: " & ex.Message)
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from WeighIn where VehicleId = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM WeighIn where VehicleId ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteWeighIn: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from WeighIn where VehicleId = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("WeighIn Record not found")
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sVehicleId = .Item("VehicleId")
                    sTrailerID = .Item("TrailerId")
                    nGross = .Item("Gross")
                    nTare = .Item("Tare")
                    nNet = .Item("Net")
                    dDateTime = .Item("DateTime")
                End With
            End If
            FindRecord = True
            'Stop
        Catch ex As Exception
            FindRecord = False
            AddLogEntry("FindWeighIn: " & ex.Message)
        End Try
    End Function

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

    Property VehicleId() As String
        Get
            VehicleId = sVehicleId
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
    Public Property Gross() As Double
        Get
            Gross = nGross
        End Get
        Set(value As Double)
            nGross = value
        End Set
    End Property
    Public Property Tare() As Double
        Get
            Tare = nTare
        End Get
        Set(value As Double)
            nTare = value
        End Set
    End Property
    Public Property Net() As Double
        Get
            Net = nNet
        End Get
        Set(value As Double)
            nNet = value
        End Set
    End Property
    Public Property DateTime() As Date
        Get
            DateTime = dDateTime
        End Get
        Set(value As Date)
            dDateTime = value
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
            CurrentId = GetSetting(appName, "Current\WeighIn", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\WeighIn", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "WeighIn\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "WeighIn\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "WeighIn\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "WeighIn\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property

End Class
