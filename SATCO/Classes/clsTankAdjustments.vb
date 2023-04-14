Imports System.Reflection
Imports System.IO

Public Class clsTankAdjustments
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sId As String               'local copy
    Private dDateTime As Date               'local copy
    Private sTankId As String
    Private lAdjustment As Long
    Private sCommodity As String
    Private lTransactionId As Long

    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Function AddRecord(CurrentId As String)
        Try
            sId = CurrentId
            Dim strInsert As String = "INSERT INTO TankAdjustment (Id, DateTime, TankId, Adjustment, Commodity, TransactionId) " & _
                                         "VALUES (" & _
                                         "'" & sId & "'," & _
                                         "'" & dDateTime & "'," & _
                                         "'" & sTankId & "'," & _
                                         "'" & lAdjustment & "'," & _
                                         "'" & sCommodity & "'," & _
                                         "'" & lTransactionId & "') "
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
        End Try
    End Function

    Public Function Search(FldName As String, SearchStr As String) As Integer
        Try
            SQL.RunQuery("Select * from TankAdjustment where " & FldName & " = '" & SearchStr & "'")
            If SQL.RecordCount = 0 Then
                Search = False
                EOF = True
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Id")
                    sTankId = .Item("TankId")
                End With
                Search = True
            End If

        Catch ex As Exception
            Search = False
            EOF = True
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

    Property Id() As String
        Get
            Id = sId
        End Get
        Set(value As String)
            sId = value
        End Set
    End Property
    Public Property Adjustment() As Long
        Get
            Adjustment = lAdjustment
        End Get
        Set(value As Long)
            lAdjustment = value
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
    Public Property Commodity() As String
        Get
            Commodity = sCommodity
        End Get
        Set(value As String)
            sCommodity = value
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
    Public Property TransactionId() As Long
        Get
            TransactionId = lTransactionId
        End Get
        Set(value As Long)
            lTransactionId = value
        End Set
    End Property
    Public Property CurrentId() As String
        Get
            CurrentId = GetSetting(appName, "Current\Tank", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\Tank", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "Tank\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Tank\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "Tank\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Tank\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property
    Private Sub New()
        Try
            SQL.RunQuery("Select * from TankAdjustment")
            With SQL.SQLDataset.Tables(0).Rows(0)
                sId = .Item("Id")
                sTankId = .Item("TankId")
            End With

            bEOF = False
            bBOF = False

        Catch ex As Exception

        End Try

    End Sub
   
End Class
