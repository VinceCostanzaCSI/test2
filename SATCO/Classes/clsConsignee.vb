Imports System.Reflection
Imports System.IO

Public Class clsConsignee
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sId As String               'local copy
    Private sConsignee As String        'local copy
    Private lNextTransNumber As Long    'local copy
    Private sDestination As String      'local copy
    Private sDestination2 As String     'local copy
    Private bActive As Boolean          'local copy
    Private dLimit As Double
    Private dUsed As Double
    Private bNSF As Boolean
    Private bRelease As Boolean

    Private sCurrentId As String        'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE Consignee " & _
                                      "SET Code ='" & sId & "' , " & _
                                      "Consignee ='" & sConsignee & "' , " & _
                                      "NextTransNumber ='" & lNextTransNumber & "' , " & _
                                      "Destination ='" & sDestination & "' , " & _
                                      "Destination2 ='" & sDestination2 & "' , " & _
                                      "Active ='" & bActive & "' , " & _
                                      "Limit ='" & dLimit & "' , " & _
                                      "Used ='" & dUsed & "' , " & _
                                      "NSF ='" & bNSF & "' " & _
                                      "Release ='" & bRelease & "' " & _
                                      "WHERE Code = '" & Id & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Consignee File")
                'Stop
            Else
                AddLogEntry("Consignee File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurrentId As String)
        Try
            sId = CurrentId
            Dim strInsert As String = "INSERT INTO Consignee (Code, Consignee, NextTransNumber, Destination, Destination2, Active, Limit, Used, NSF, Release) " & _
                                         "VALUES (" & _
                                         "'" & sId & "'," & _
                                         "'" & sConsignee & "'," & _
                                         "'" & lNextTransNumber & "'," & _
                                         "'" & sDestination & "'," & _
                                         "'" & sDestination2 & "'," & _
                                         "'" & bActive & "'," & _
                                         "'" & dLimit & "'," & _
                                         "'" & dUsed & "'," & _
                                         "'" & bNSF & "'," & _
                                         "'" & bRelease & "')"
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Consignee where Code = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Consignee where Code ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("Delete Consignee: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String) As Boolean

        Try
            SQL.RunQuery("Select * from Consignee where Code = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Consignee Record not found: " & CurrentId)
                'EOF = True
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Code")
                    sConsignee = .Item("Consignee")
                    lNextTransNumber = .Item("NextTransNumber")
                    sDestination = .Item("Destination")
                    sDestination2 = .Item("Destination2")
                    bActive = .Item("Active")
                    dLimit = .Item("Limit")
                    dUsed = .Item("Used")
                    bNSF = .Item("NSF")
                    bRelease = .Item("Release")
                End With
                FindRecord = True
            End If
            'EOF = False

        Catch ex As Exception
            AddLogEntry("FindRecord Consignee: " & ex.Message)
            'EOF = True
            FindRecord = False
        End Try
    End Function

    Public Function GetNextTransNumber(Code As String) As Long

        Dim NextNum As Long
        Dim NewNum As Long

        SQL.RunQuery("Select top 1 * from Consignee where Code = '" & Code & "'")
        If SQL.RecordCount > 0 Then
            bEOF = False
            NextNum = SQL.SQLDataset.Tables(0).Rows(0).Item("NextTransNumber")
            NewNum = NextNum + 1
        Else
            bEOF = True
            NextNum = -1
        End If

        'Now update record

        Dim UpdateCmd As String = "UPDATE Consignee SET NextTransNumber ='" & NewNum & "' WHERE Code = '" & Code & "';"

        If SQL.DataUpdate(UpdateCmd) = 0 Then
            'didn't work
        End If
        GetNextTransNumber = NextNum

    End Function

    Public Sub UpdateUsed(Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE Consignee SET Used ='" & dUsed & "' WHERE Code = '" & Id & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Consignee File")
                'Stop
            Else
                AddLogEntry("Consignee File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
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

    Property Id() As String
        Get
            Id = sId
        End Get
        Set(value As String)
            sId = value
        End Set
    End Property

    Property Consignee() As String
        Get
            Consignee = sConsignee
        End Get
        Set(value As String)
            sConsignee = value
        End Set
    End Property

    Property NextTransNumber() As Long
        Get
            NextTransNumber = lNextTransNumber
        End Get
        Set(value As Long)
            lNextTransNumber = value
        End Set
    End Property

    Property Destination() As String
        Get
            Destination = sDestination
        End Get
        Set(value As String)
            sDestination = value
        End Set
    End Property

    Property Destination2() As String
        Get
            Destination2 = sDestination2
        End Get
        Set(value As String)
            sDestination2 = value
        End Set
    End Property

    Property Active() As Boolean
        Get
            Active = bActive
        End Get
        Set(value As Boolean)
            bActive = value
        End Set
    End Property

    Property Limit() As Double
        Get
            Limit = dLimit
        End Get
        Set(value As Double)
            dLimit = value
        End Set
    End Property

    Property Used() As Double
        Get
            Used = dUsed
        End Get
        Set(value As Double)
            dUsed = value
        End Set
    End Property

    Property NSF() As Boolean
        Get
            NSF = bNSF
        End Get
        Set(value As Boolean)
            bNSF = value
        End Set
    End Property

    Property Release() As Boolean
        Get
            Release = bRelease
        End Get
        Set(value As Boolean)
            bRelease = value
        End Set
    End Property

    Property SearchField As String
        Get
            SearchField = GetSetting(appName, "Consignee\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Consignee\Search", "Field", value)
        End Set
    End Property
    Property SearchData As String
        Get
            SearchData = GetSetting(appName, "Consignee\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Consignee\Search", "Data", value)
        End Set
    End Property
End Class
