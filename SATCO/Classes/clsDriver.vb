Imports System.Reflection
Imports System.IO

Public Class clsDriver
    Private SQL As New SQLControl

    Dim Section As String
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    'local variable(s) to hold property value(s)
    Private sId As String               'local copy
    Private sName As String             'local copy
    Private lCardNumber As Long         'local copy
    Private sPin As String              'local copy
    Private sCarrier As String          'local copy
    Private dTwic As Date               'local copy
    Private bActive As Boolean          'local copy
    Private dWarning As Date
    Private dTraining As Date
    Private dExpires As Date
    Private bStatus As Boolean

    Private sCurrentId As String        'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE Driver " & _
                                      "SET Id ='" & sId & "' , " & _
                                      "Name ='" & sName & "' , " & _
                                      "CardId ='" & lCardNumber & "' , " & _
                                      "PIN ='" & sPin & "' , " & _
                                      "Carrier ='" & sCarrier & "' , " & _
                                      "Twic ='" & dTwic & "' , " & _
                                      "Active ='" & bActive & "' , " & _
                                      "Warning ='" & dWarning & "' , " & _
                                      "Training ='" & dTraining & "' , " & _
                                      "Expires ='" & dExpires & "' " & _
                                      "WHERE Id = '" & Id & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Driver File")
                'Stop
            Else
                AddLogEntry("Driver File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurrentId As String)
        Try
            sId = CurrentId
            Dim strInsert As String = "INSERT INTO Driver (Id, Name, CardId, PIN, Carrier, Twic, Active, Warning, Training, Expires) " & _
                                         "VALUES (" & _
                                         "'" & sId & "'," & _
                                         "'" & sName & "'," & _
                                         "'" & lCardNumber & "'," & _
                                         "'" & sPin & "'," & _
                                         "'" & sCarrier & "'," & _
                                         "'" & dTwic & "'," & _
                                         "'" & bActive & "'," & _
                                         "'" & dWarning & "'," & _
                                         "'" & dTraining & "'," & _
                                         "'" & dExpires & "')"
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Driver where Id = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Driver where Id ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteTank: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String) As Boolean
        Try
            SQL.RunQuery("Select * from Driver where Id = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Driver Record not found")
                FindRecord = False
                EOF = True
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Id")
                    sName = .Item("Name")
                    lCardNumber = .Item("CardId")
                    sPin = .Item("PIN")
                    sCarrier = .Item("Carrier")
                    dTwic = .Item("Twic")
                    bActive = .Item("Active")
                    dWarning = .Item("Warning")
                    dTraining = .Item("Training")
                    dExpires = .Item("Expires")
                End With
            End If
            EOF = False
            FindRecord = True
        Catch ex As Exception
            FindRecord = False
            EOF = True
        End Try

    End Function


    Public Function FindName(ByVal Name As String) As Integer
        Try
            SQL.RunQuery("Select * from Driver where Name = '" & Name & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Driver Record not found")
                FindName = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Id")
                    sName = .Item("Name")
                    lCardNumber = .Item("CardId")
                    sPin = .Item("PIN")
                    sCarrier = .Item("Carrier")
                    dTwic = .Item("Twic")
                    bActive = .Item("Active")
                    dWarning = .Item("Warning")
                    dTraining = .Item("Training")
                    dExpires = .Item("Expires")
                    FindName = True
                End With
            End If
        Catch ex As Exception
            FindName = False
        End Try
    End Function

    Public Function Search(FldName As String, SearchStr As String) As Boolean
        Try
            SQL.RunQuery("Select * from Driver where " & FldName & " = '" & SearchStr & "'")
            If SQL.RecordCount = 0 Then
                Search = False
                EOF = True
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Id")
                    sName = .Item("Name")
                    lCardNumber = .Item("CardId")
                    sPin = .Item("PIN")
                    sCarrier = .Item("Carrier")
                    dTwic = .Item("Twic")
                    bActive = .Item("Active")
                    dWarning = .Item("Warning")
                    dTraining = .Item("Training")
                    dExpires = .Item("Expires")
                End With
                EOF = False
                Search = True
            End If
            'Stop
        Catch ex As Exception
            EOF = True
            Search = False
        End Try
    End Function

    Public Sub GetLastRecord()
        ' ?
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

    Property ID() As String
        Get
            ID = sId
        End Get
        Set(value As String)
            sId = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Name = sName
        End Get
        Set(value As String)
            sName = value
        End Set
    End Property
    Public Property CardNumber() As Long
        Get
            CardNumber = lCardNumber
        End Get
        Set(value As Long)
            lCardNumber = value
        End Set
    End Property
    Public Property PIN() As String
        Get
            PIN = sPin
        End Get
        Set(value As String)
            sPin = value
        End Set
    End Property
    Public Property Carrier() As String
        Get
            Carrier = sCarrier
        End Get
        Set(value As String)
            sCarrier = value
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
    Public Property Twic() As Date
        Get
            Twic = dTwic
        End Get
        Set(value As Date)
            dTwic = value
        End Set
    End Property
    Public Property Warning() As Date
        Get
            Warning = dWarning
        End Get
        Set(value As Date)
            dWarning = value
        End Set
    End Property
    Public Property Training() As Date
        Get
            Training = dTraining
        End Get
        Set(value As Date)
            dTraining = value
        End Set
    End Property
    Public Property Expires() As Date
        Get
            Expires = dExpires
        End Get
        Set(value As Date)
            dExpires = value
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
            CurrentId = GetSetting(appName, "Current\Driver", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\Driver", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "Driver\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Driver\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "Driver\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Driver\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property

    Public Sub New()
        Try
            bStatus = True
            'rsDriver = New ADODB.Recordset
            'rsDriver.ActiveConnection = dbConnection
            'rsDriver.CursorType = adOpenKeyset
            'rsDriver.LockType = adLockOptimistic
            'rsDriver.Source = "SELECT * FROM DRIVER"
            'rsDriver.Open()
            'bEOF = False
            'bBOF = False
        Catch ex As Exception
            bStatus = False
        End Try
    End Sub

End Class
