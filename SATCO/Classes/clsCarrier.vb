Imports System.Reflection
Imports System.IO

Public Class clsCarrier
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sCode As String         'local copy
    Private sName As String         'local copy
    Private sAddress As String      'local copy
    Private sCSZ As String          'local copy
    Private sMaxLoad As String      'local copy
    Private bActive As Boolean      'local copy

    Private sCurrentId As String    'local copy

    Public Function FindRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Carrier where Code = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Carrier Record not found: " & CurrentId)
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sCode = .Item("Code")
                    sName = .Item("Name")
                    sAddress = .Item("Address")
                    sCSZ = .Item("CSZ")
                    sMaxLoad = .Item("MaxLoad")
                    bActive = .Item("Active")
                End With
                FindRecord = True
            End If

        Catch ex As Exception
            FindRecord = False
        End Try
    End Function

    Property Code() As String
        Get
            Code = sCode
        End Get
        Set(value As String)
            sCode = value
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
    Property Address() As String
        Get
            Address = sAddress
        End Get
        Set(value As String)
            sAddress = value
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

    Property Active() As Boolean
        Get
            Active = bActive
        End Get
        Set(value As Boolean)
            bActive = value
        End Set
    End Property
End Class
