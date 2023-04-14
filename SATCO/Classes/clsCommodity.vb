Imports System.Reflection
Imports System.IO

Public Class clsCommodity
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sId As String               'local copy
    Private sDescription1 As String     'local copy
    Private sDescription2 As String     'local copy
    Private sDescription3 As String     'local copy
    Private sDescription4 As String     'local copy
    Private sDescription5 As String     'local copy
    Private lVariableWt As Long         'local copy
    Private sCommType As String         'local copy
    Private bActive As Boolean          'local copy
    Private bStatus As Boolean

    Private bEOF As Boolean
    Private bBOF As Boolean


    Public Sub UpdateRecord(Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE Commodity " & _
                                      "SET Id ='" & sId & "' , " & _
                                      "Description1 ='" & sDescription1 & "' , " & _
                                      "Description2 ='" & sDescription2 & "' , " & _
                                      "Description3 ='" & sDescription3 & "' , " & _
                                      "Description4 ='" & sDescription4 & "' , " & _
                                      "Description5 ='" & sDescription5 & "'" & _
                                      "VariableWeight ='" & lVariableWt & "' , " & _
                                      "CType ='" & sCommType & "' , " & _
                                      "Active ='" & bActive & "' " & _
                                      "WHERE Id = '" & Id & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Commodity File")
                'Stop
            Else
                AddLogEntry("Commodity File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurrentId As String) As Boolean

        Try
            sId = CurrentId
            Dim strInsert As String = "INSERT INTO Commodity (Id, Description1, Description2, Description3, Description4, Description5, VariableWeight, CType, Active) " &
                                         "VALUES (" &
                                         "'" & sId & "'," &
                                         "'" & sDescription1 & "'," &
                                         "'" & sDescription1 & "'," &
                                         "'" & sDescription1 & "'," &
                                         "'" & sDescription1 & "'," &
                                         "'" & sDescription1 & "'," &
                                         "'" & lVariableWt & "'," &
                                         "'" & sCommType & "'," &
                                         "'" & bActive & "')"
            SQL.DataUpdate(strInsert)
            AddRecord = True

        Catch ex As Exception
            AddRecord = False
        End Try

    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Commodity where Id = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Commodity where Id ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteTank: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String) As Boolean

        Try
            SQL.RunQuery("Select * from Commodity where Id = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Commodity Record not found: " & CurrentId)
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)

                    sId = .Item("Id")
                    sDescription1 = .Item("Description1")
                    sDescription2 = .Item("Description2")
                    sDescription3 = .Item("Description3")
                    sDescription4 = .Item("Description4")
                    sDescription5 = .Item("Description5")
                    lVariableWt = .Item("VariableWeight")
                    sCommType = .Item("CType")
                    bActive = .Item("Active")

                End With
                FindRecord = True
            End If

        Catch ex As Exception
            FindRecord = False
        End Try

    End Function

    Public Function Search(FldName As String, SearchStr As String) As Boolean

        Try
            SQL.RunQuery("Select * from Commodity where " & FldName & " = '" & SearchStr & "'")
            If SQL.RecordCount = 0 Then
                Search = False
                EOF = True
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Id")
                    sDescription1 = .Item("Description1")
                    sDescription2 = .Item("Description2")
                    sDescription3 = .Item("Description3")
                    sDescription4 = .Item("Description4")
                    sDescription5 = .Item("Description5")
                    lVariableWt = .Item("VariableWeight")
                    sCommType = .Item("CType")
                    bActive = .Item("Active")

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

    Property ID() As String
        Get
            ID = sId
        End Get
        Set(value As String)
            sId = value
        End Set
    End Property

    Property Description1() As String
        Get
            Description1 = sDescription1
        End Get
        Set(value As String)
            sDescription1 = value
        End Set
    End Property
    Property Description2() As String
        Get
            Description2 = sDescription2
        End Get
        Set(value As String)
            sDescription2 = value
        End Set
    End Property
    Property Description3() As String
        Get
            Description3 = sDescription3
        End Get
        Set(value As String)
            sDescription3 = value
        End Set
    End Property
    Property Description4() As String
        Get
            Description4 = sDescription4
        End Get
        Set(value As String)
            sDescription4 = value
        End Set
    End Property
    Property Description5() As String
        Get
            Description5 = sDescription5
        End Get
        Set(value As String)
            sDescription5 = value
        End Set
    End Property

    Property VariableWt() As Long
        Get
            VariableWt = lVariableWt
        End Get
        Set(value As Long)
            lVariableWt = value
        End Set
    End Property

    Property CommType() As String
        Get
            CommType = sCommType
        End Get
        Set(value As String)
            sCommType = value
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

    Property Status() As Boolean
        Get
            Status = bStatus
        End Get
        Set(value As Boolean)
            bStatus = value
        End Set
    End Property
    Property SearchField As String
        Get
            SearchField = GetSetting(appName, "Commodity\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Commodity\Search", "Field", value)
        End Set
    End Property
    Property SearchData As String
        Get
            SearchData = GetSetting(appName, "Commodity\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Commodity\Search", "Data", value)
        End Set
    End Property
End Class
