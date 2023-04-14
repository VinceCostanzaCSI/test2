Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class SQLControl
    ' Connection
    'Dim ConnectionString As String = "Server=" & Environment.MachineName & ";Database=SATCO;User=adminuser;Pwd=Tampa08;"
    Dim ConnectionString As String = "Server=" & DBPath & ";Database=SATCO;User=adminuser;Pwd=Tampa08;"
    Dim SQLCon As SqlConnection = New SqlConnection(ConnectionString)

    'Private SQLCon As New SqlConnection With {.ConnectionString = "Server=WFLA81800;Database=STST;User=adminuser;Pwd=Tampa08;"}
    Private SQLCmd As SqlCommand

    'SQL Data
    Public SQLDA As SqlDataAdapter
    Public SQLDataset As DataSet

    'Query Parameters
    Public SQLParams As New List(Of SqlParameter)

    'Query Statistics
    Public RecordCount As Integer
    Public Exception As String


    Public Function HasConnection() As Boolean
        Dim ConnectionString As String
        Dim SQLCon As SqlConnection
        ConnectionString = "Server=" & DBPath & ";Database=SATCO;User=adminuser;Pwd=Tampa08;"
        SQLCon = New SqlConnection(ConnectionString)
        Try
            SQLCon.Open()

            SQLCon.Close()
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub RunQuery(Query As String)
        Try
            SQLCon.Open()

            SQLCmd = New SqlCommand(Query, SQLCon)

            'Load SQL Records for datagrid
            SQLDA = New SqlDataAdapter(SQLCmd)
            SQLDataset = New DataSet
            RecordCount = SQLDA.Fill(SQLDataset)

            SQLCon.Close()
        Catch ex As Exception
            AddLogEntry("RunQuery: " & ex.Message)

            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If

        End Try
    End Sub

    Public Function DataUpdate(Command As String) As Integer
        Try
            SQLCon.Open()
            SQLCmd = New SqlCommand(Command, SQLCon)

            Dim ChangeCount As Integer = SQLCmd.ExecuteNonQuery


            SQLCon.Close()

            Return ChangeCount
            'Report results

        Catch ex As Exception
            AddLogEntry("DataUpdate: " & ex.Message)

            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If

        End Try

        Return 0
    End Function

    Public Sub Paramquery(Query As String, Optional Collate As Collation = Collation.None)
        Try
            SQLCon.Open()

            If Collate = Collation.CaseSensitive Then Query = Query & "COLLATE SQL_Latin1_General_CP1_CS_AS "

            SQLCmd = New SqlCommand(Query, SQLCon)
            For Each p As SqlParameter In SQLParams
                SQLCmd.Parameters.Add(p)
                SQLCmd.Parameters(p.ParameterName).Value = p.Value
            Next

            'Fill Dataset
            SQLDA = New SqlDataAdapter(SQLCmd)
            SQLDataset = New DataSet
            RecordCount = SQLDA.Fill(SQLDataset)

            'MsgBox(Query & vbCrLf & SQLDataset.Tables(0).Rows(0).Item(0), MsgBoxStyle.OkOnly, "Success")

            SQLCon.Close()

        Catch ex As Exception
            If SQLCon.State = ConnectionState.Open Then SQLCon.Close()

            AddLogEntry("Query Failed: " & ex.Message)
            MsgBox(Query)

        End Try

        FlushParams()


    End Sub

    Public Sub AddParam(Name As String, Value As Object, Optional DataType As DbType = DbType.String)
        Dim newParam As New SqlParameter With {.ParameterName = Name, .Value = Value, .DbType = DataType}
        SQLParams.Add(newParam)
    End Sub

    Public Sub FlushParams()
        SQLParams.Clear()
    End Sub

    Public Enum Collation
        None
        CaseSensitive
    End Enum
End Class
