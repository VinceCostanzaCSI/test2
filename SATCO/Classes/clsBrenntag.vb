Imports System.Reflection
Imports System.IO

Public Class clsBrenntag
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sRelease As String      'local copy
    Private sPO As String           'local copy
    Private sBOL As String          'local copy
    Private sAltPO As String        'local copy
    Private sAltCode As String      'local copy
    Private sName As String         'local copy
    Private sAddress1 As String     'local copy
    Private sAddress2 As String     'local copy
    Private sCSZ As String          'local copy
    Private sMaxLoad As String      'local copy
    Private sNotes As String        'local copy
    Private sPCName As String       'Local copy
    Private sPC As String           'Local copy
    Private bActive As Boolean      'local copy
    Private bStatus As Boolean

    Private sCurrentId As String    'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean
    Private CurrentRecord As Integer


    Public Sub UpdateRecord(CurrentId As String)

        Try
            Dim UpdateCmd As String = "UPDATE Brenntag " &
                                      "SET Release ='" & sRelease & "' , " &
                                      "PO ='" & sPO & "' , " &
                                      "BOL ='" & sBOL & "' , " &
                                      "AltPO ='" & sAltPO & "' , " &
                                      "AltCode ='" & sAltCode & "' , " &
                                      "Name ='" & sName & "' , " &
                                      "Address1 ='" & sAddress1 & "' , " &
                                      "Address2 ='" & sAddress2 & "' , " &
                                      "CSZ ='" & sCSZ & "' , " &
                                      "MaxLoad ='" & sMaxLoad & "' , " &
                                      "Notes ='" & sNotes & "' , " &
                                      "PCName ='" & sPCName & "' , " &
                                      "PC ='" & sPC & "' , " &
                                      "Active ='" & bActive & "' " &
                                      "WHERE Release = '" & CurrentId & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Brenntag File")
            Else
                AddLogEntry("Brenntag File Updated")
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurentId As String)
        Try
            sRelease = CurentId
            Dim strInsert As String = "INSERT INTO Brenntag (Release, PO, BOL, AltPO, AltCode, Name, Address1, Address2, CSZ, MaxLoad, Active, PCName,  PC, Notes ) " &
                                         "VALUES (" &
                                         "'" & sRelease & "'," &
                                         "'" & sPO & "'," &
                                         "'" & sBOL & "'," &
                                         "'" & sAltPO & "'," &
                                         "'" & sAltCode & "'," &
                                         "'" & sName & "'," &
                                         "'" & sAddress1 & "'," &
                                         "'" & sAddress2 & "'," &
                                         "'" & sCSZ & "'," &
                                         "'" & sMaxLoad & "'," &
                                         "'" & bActive & "'," &
                                         "'" & sPCName & "'," &
                                         "'" & sPC & "'," &
                                         "'" & sNotes & "') "
            'Stop
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Brenntag where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Brenntag where Release ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteBrenntag: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Brenntag where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Brenntag Record not found: " & CurrentId)
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)

                    sPO = .Item("PO")
                    sBOL = .Item("BOL")
                    sAltPO = .Item("AltPO")
                    sAltCode = .Item("AltCode")
                    sName = .Item("Name")
                    sAddress1 = .Item("Address1")
                    sAddress2 = .Item("Address2")
                    sCSZ = .Item("CSZ")
                    sMaxLoad = .Item("MaxLoad")
                    sNotes = .Item("Notes")
                    sPCName = .Item("PCName")
                    sPC = .Item("PC")
                    bActive = .Item("Active")
                End With
                FindRecord = True
            End If

        Catch ex As Exception
            FindRecord = False
            AddLogEntry("Brenntag-Find: " & ex.Message)
        End Try
    End Function

    Public Sub UpdateActivity(ByVal CurrentId As String, ActiveChange As Boolean)
        Try
            SQL.RunQuery("Update Brenntag Set Active = '" & ActiveChange & "' where Release = '" & CurrentId & "' ")


        Catch ex As Exception
            AddLogEntry("UpdateBrenntag: " & ex.Message)
        End Try
    End Sub

    Public Sub GetPreviousRecord()

        CurrentRecord = CurrentRecord - 1
        UpdateClass(CurrentRecord)

    End Sub

    Public Sub GetFirstRecord()
        bEOF = False
        bBOF = False
        SQL.RunQuery("Select * from Brenntag")
        If SQL.RecordCount = 0 Then
            AddLogEntry("Brenntag Record not found")
            bBOF = True
            bEOF = True
            ClearClass()
        Else
            CurrentRecord = 0
            UpdateClass(CurrentRecord)
        End If
    End Sub

    Public Sub GetNextRecord()
        CurrentRecord = CurrentRecord + 1
        UpdateClass(CurrentRecord)
    End Sub

    Private Sub UpdateClass(ByVal CRecord As Integer)
        Try

            With SQL.SQLDataset.Tables(0).Rows(CRecord)

                If String.IsNullOrEmpty(.Item("Release")) Then
                    sRelease = ""
                Else
                    sRelease = .Item("Release")
                End If
                If String.IsNullOrEmpty(.Item("PO")) Then
                    sPO = ""
                Else
                    sPO = .Item("PO")
                End If
                If String.IsNullOrEmpty(.Item("BOL")) Then
                    sBOL = ""
                Else
                    sBOL = .Item("BOL")
                End If
                If String.IsNullOrEmpty(.Item("AltPO")) Then
                    sAltPO = ""
                Else
                    sAltPO = .Item("AltPO")
                End If
                If String.IsNullOrEmpty(.Item("AltCode")) Then
                    sAltCode = ""
                Else
                    sAltCode = .Item("AltCode")
                End If
                If String.IsNullOrEmpty(.Item("Name")) Then
                    sName = ""
                Else
                    sName = .Item("Name")
                End If
                If String.IsNullOrEmpty(.Item("Address1")) Then
                    sAddress1 = ""
                Else
                    sAddress1 = .Item("Address1")
                End If
                If String.IsNullOrEmpty(.Item("Address2")) Then
                    sAddress2 = ""
                Else
                    sAddress2 = .Item("Address2")
                End If
                If String.IsNullOrEmpty(.Item("CSZ")) Then
                    sCSZ = ""
                Else
                    sCSZ = .Item("CSZ")
                End If
                If String.IsNullOrEmpty(.Item("MaxLoad")) Then
                    sMaxLoad = ""
                Else
                    sMaxLoad = .Item("MaxLoad")
                End If
                If String.IsNullOrEmpty(.Item("Notes")) Then
                    sNotes = ""
                Else
                    sNotes = .Item("Notes")
                End If
                If String.IsNullOrEmpty(.Item("PCName")) Then
                    sPCName = ""
                Else
                    sPCName = .Item("PCName")
                End If
                If String.IsNullOrEmpty(.Item("PC")) Then
                    sPC = ""
                Else
                    sPC = .Item("PC")
                End If
                If String.IsNullOrEmpty(.Item("Active")) Then
                    bActive = 0
                Else
                    bActive = .Item("Active")
                End If

            End With
        Catch ex As Exception
            bBOF = True
            bEOF = True
            MsgBox("Brenntag UpdateClass: " & ex.Message)
            'AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub ClearClass()

        sRelease = ""
        sPO = ""
        sBOL = ""
        sAltPO = ""
        sAltCode = ""
        sName = ""
        sAddress1 = ""
        sAddress2 = ""
        sCSZ = ""
        sMaxLoad = ""
        sNotes = ""
        sPCName = ""
        sPC = ""
        bActive = False

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

    Property PO() As String
        Get
            PO = sPO
        End Get
        Set(value As String)
            sPO = value
        End Set
    End Property
    Property BOL() As String
        Get
            BOL = sBOL
        End Get
        Set(value As String)
            sBOL = value
        End Set
    End Property
    Property AltPO() As String
        Get
            AltPO = sAltPO
        End Get
        Set(value As String)
            sAltPO = value
        End Set
    End Property
    Property AltCode() As String
        Get
            AltCode = sAltCode
        End Get
        Set(value As String)
            sAltCode = value
        End Set
    End Property
    Property Name() As String
        Get
            Name = sName
        End Get
        Set(value As String)
            sName = value
        End Set
    End Property
    Property Address1() As String
        Get
            Address1 = sAddress1
        End Get
        Set(value As String)
            sAddress1 = value
        End Set
    End Property
    Property Address2() As String
        Get
            Address2 = sAddress2
        End Get
        Set(value As String)
            sAddress2 = value
        End Set
    End Property
    Property CSZ() As String
        Get
            CSZ = sCSZ
        End Get
        Set(value As String)
            sCSZ = value
        End Set
    End Property

    Property MaxLoad() As String
        Get
            MaxLoad = sMaxLoad
        End Get
        Set(value As String)
            sMaxLoad = value
        End Set
    End Property

    Property Notes() As String
        Get
            Notes = sNotes
        End Get
        Set(value As String)
            sNotes = value
        End Set
    End Property

    Property PCName() As String
        Get
            PCName = sPCName
        End Get
        Set(value As String)
            sPCName = value
        End Set
    End Property

    Property PC() As String
        Get
            PC = sPC
        End Get
        Set(value As String)
            sPC = value
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
    Property CurrentId() As String
        Get
            CurrentId = sCurrentId
        End Get
        Set(value As String)
            sCurrentId = value
        End Set
    End Property
    Property SearchField As String
        Get
            SearchField = GetSetting(appName, "Brenntag\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Brenntag\Search", "Field", value)
        End Set
    End Property
    Property SearchData As String
        Get
            SearchData = GetSetting(appName, "Brenntag\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Brenntag\Search", "Data", value)
        End Set
    End Property
End Class
