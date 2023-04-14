Imports System.Reflection
Imports System.IO

Public Class clsYara
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sRelease As String      'local copy
    Private bActive As Boolean      'local copy
    Private sProduct As String      'local copy
    Private sGrade As String        'local copy
    Private sConsignee As String    'local copy
    Private sPO As String           'local copy
    Private sFreight As String      'local copy
    Private sCode As String         'local copy
    Private bEvoqua As Boolean     'local copy
    Private bStatus As Boolean

    Private sCurrentId As String    'local copy
    Private bEOF As Boolean
    Private bBOF As Boolean

    Public Sub UpdateRecord(CurrentId As String)

        Try
            Dim UpdateCmd As String = "UPDATE Yara " & _
                                      "SET Release ='" & sRelease & "' , " & _
                                      "Active ='" & bActive & "' , " & _
                                      "Product ='" & sProduct & "' , " & _
                                      "Grade ='" & sGrade & "' , " & _
                                      "Consignee ='" & sConsignee & "' , " & _
                                      "PO ='" & sPO & "' , " & _
                                      "Freight ='" & sFreight & "' , " & _
                                      "Code ='" & sCode & "' , " & _
                                      "Evoqua ='" & bEvoqua & "' " & _
                                      "WHERE Release = '" & CurrentId & "';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Control File")
                'Stop
            Else
                AddLogEntry("Control File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Function AddRecord(CurentId As String)
        Try
            sRelease = CurentId
            Dim strInsert As String = "INSERT INTO Yara (Release, Active, Product, Grade, Consignee, PO, Freight, Code, Evoqua, Status) " & _
                                         "VALUES (" & _
                                         "'" & sRelease & "'," & _
                                         "'" & bActive & "'," & _
                                         "'" & sProduct & "'," & _
                                         "'" & sGrade & "'," & _
                                         "'" & sConsignee & "'," & _
                                         "'" & sPO & "'," & _
                                         "'" & sFreight & "'," & _
                                         "'" & sCode & "'," & _
                                         "'" & bEvoqua & "') "
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Yara where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Yara where Release ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteBrenntag: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Yara where Release = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Yara Record not found")
                EOF = True
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)

                    sRelease = .Item("Release")
                    bActive = .Item("Active")
                    sProduct = .Item("Product")
                    sGrade = .Item("Grade")
                    sConsignee = .Item("Consignee")
                    sPO = .Item("PO")
                    sFreight = .Item("Freight")
                    sCode = .Item("Code")
                    bEvoqua = .Item("Evoqua")

                End With
            End If
            FindRecord = True
        Catch ex As Exception
            FindRecord = False
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

    Property Release() As String
        Get
            Release = sRelease
        End Get
        Set(value As String)
            sRelease = value
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
    Public Property Product() As String
        Get
            Product = sProduct
        End Get
        Set(value As String)
            sProduct = value
        End Set
    End Property
    Public Property Grade() As String
        Get
            Grade = sGrade
        End Get
        Set(value As String)
            sGrade = value
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
    Property PO() As String
        Get
            PO = sPO
        End Get
        Set(value As String)
            sPO = value
        End Set
    End Property
    Public Property Freight() As String
        Get
            Freight = sFreight
        End Get
        Set(value As String)
            sFreight = value
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
    Public Property Evoqua() As Boolean
        Get
            Evoqua = bEvoqua
        End Get
        Set(value As Boolean)
            bEvoqua = value
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
            CurrentId = GetSetting(appName, "Current\Yara", "CurrentId", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Current\Yara", "CurrentId", value)
        End Set
    End Property
    Public Property SearchData() As String
        Get
            SearchData = GetSetting(appName, "Yara\Search", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Yara\Search", "Data", value)
        End Set
    End Property
    Public Property SearchField() As String
        Get
            SearchField = GetSetting(appName, "Yara\Search", "Field", "ID")
        End Get
        Set(value As String)
            SaveSetting(appName, "Yara\Search", "Field", value)
        End Set
    End Property
    Public ReadOnly Property NumberOfRecords() As Long
        Get
            NumberOfRecords = SQL.RecordCount
        End Get
    End Property

End Class
