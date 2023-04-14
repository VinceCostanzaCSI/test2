Public Class clsTank

    Private SQL As New SQLControl

    'local variable(s) to hold property value(s)
    Private sId As String               'local copy
    Private sDescription As String      'local copy
    Private dMaxTankTons As Double      'local copy
    Private dLowAlarmValue As Double    'local copy
    Private dCurrentLevel As Double     'local copy
    Private bActiveScale As Byte        'local copy
    Private sCommodity As String        'local copy
    Private bType As Byte               'local copy
    Private bActive As Boolean          'local copy
    Private bStatus As Boolean
    Private sFillTank As String

    Private bEOF As Boolean
    Private bBOF As Boolean
    Private CurrentRecord As Integer

    Public Sub UpdateRecord(Id As String)

        Try
            Dim UpdateCmd As String = "UPDATE Tank " & _
                                      "SET Id ='" & sId & "' , " & _
                                      "Description ='" & sDescription & "' , " & _
                                      "MaxTankTons ='" & dMaxTankTons & "' , " & _
                                      "LowAlarmValue ='" & dLowAlarmValue & "' , " & _
                                      "CurrentLevel ='" & dCurrentLevel & "' , " & _
                                      "ActiveScale ='" & bActiveScale & "' , " & _
                                      "Commodity ='" & sCommodity & "' , " & _
                                      "Type ='" & bType & "' ," & _
                                      "Active ='" & bActive & "' " & _
                                      "WHERE Id = '" & Id & "';"

            If Sql.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Tank File")
                'Stop
            Else
                AddLogEntry("Tank File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub

    Public Sub SetSATank(Id As String)
        'Stop
        Try
            'Tank 1
            If Id = "01" Then
                bActiveScale = 0
                bActive = 1
            Else
                bActiveScale = 3
                bActive = 0
            End If
            Dim UpdateCmd As String = "UPDATE Tank SET ActiveScale ='" & bActiveScale & "' , " &
                                      "Active ='" & bActive & "' " &
                                      "WHERE Id = '01';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Tank File")
                'Stop
            Else
                AddLogEntry("Tank File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

        Try
            'Tank 2
            If Id = "02" Then
                bActiveScale = 0
                bActive = 1
            Else
                bActiveScale = 3
                bActive = 0
            End If
            Dim UpdateCmd As String = "UPDATE Tank SET ActiveScale ='" & bActiveScale & "' , " &
                                      "Active ='" & bActive & "' " &
                                      "WHERE Id = '02';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Tank File")
                'Stop
            Else
                AddLogEntry("Tank File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

        Try
            'Tank 5
            If Id = "05" Then
                bActiveScale = 0
                bActive = 1
            Else
                bActiveScale = 3
                bActive = 0
            End If
            Dim UpdateCmd As String = "UPDATE Tank SET ActiveScale ='" & bActiveScale & "' , " &
                                      "Active ='" & bActive & "' " &
                                      "WHERE Id = '05';"

            If SQL.DataUpdate(UpdateCmd) = 0 Then
                AddLogEntry("Error updating Tank File")
                'Stop
            Else
                AddLogEntry("Tank File Updated")
                'Stop
            End If

        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try

    End Sub
    Public Function AddRecord(CurrentId As String)
        Try
            sId = CurrentId
            Dim strInsert As String = "INSERT INTO Tank (Id, Description, MaxTankTons, LowalarmValue, CurrentLevel, ActiveScale, Commodity, Type, Active) " & _
                                         "VALUES (" & _
                                         "'" & sId & "'," & _
                                         "'" & sDescription & "'," & _
                                         "'" & dMaxTankTons & "'," & _
                                         "'" & dLowAlarmValue & "'," & _
                                         "'" & dCurrentLevel & "'," & _
                                         "'" & bActiveScale & "'," & _
                                         "'" & sCommodity & "'," & _
                                         "'" & bType & "'," & _
                                         "'" & bActive & "') "
            SQL.DataUpdate(strInsert)
            AddRecord = True
        Catch ex As Exception
            AddRecord = False
            AddLogEntry("Tank.AddRecord " & ex.Message)
        End Try
    End Function

    Public Sub DeleteRecord(ByVal CurrentId As String)
        Try
            SQL.RunQuery("Select * from Tank where Id = '" & CurrentId & "' ")
            If Sql.RecordCount = 0 Then

                'Exit Sub
            Else
                'Delete record
                SQL.DataUpdate("DELETE FROM Tank where Id ='" & CurrentId & "' ")

            End If
        Catch ex As Exception
            AddLogEntry("DeleteTank: " & ex.Message)
        End Try
    End Sub

    Public Function FindRecord(ByVal CurrentId As String) As Boolean
        Try
            SQL.RunQuery("Select * from Tank where Id = '" & CurrentId & "' ")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Tank Record not found: " & CurrentId & " ")
                FindRecord = False
            Else
                With SQL.SQLDataset.Tables(0).Rows(0)
                    sId = .Item("Id")
                    sDescription = .Item("Description")
                    dMaxTankTons = .Item("MaxTankTons")
                    dLowAlarmValue = .Item("LowAlarmValue")
                    dCurrentLevel = .Item("CurrentLevel")
                    bActiveScale = .Item("ActiveScale")
                    sCommodity = .Item("Commodity")
                    bType = .Item("Type")
                    bActive = .Item("Active")
                End With
                FindRecord = True
            End If

        Catch ex As Exception
            AddLogEntry("Tank.FinRecord: " & ex.Message)
            FindRecord = False
        End Try
    End Function

    Public Function GetFillTank(FillScale As Integer, Material As Integer) As String
        '   Scale either Scale1 = 0  and Scale2 = 1
        '   Material 0=SA  1=UC  2=MO  3=BT
        Try
            SQL.RunQuery("Select * from Tank where Type = '" & Material & "' and ActiveScale = '" & FillScale & "'")
            If SQL.RecordCount = 0 Then
                GetFillTank = False
            Else
                sId = SQL.SQLDataset.Tables(0).Rows(0).Item("Id")
            End If
            Return FillScale
            GetFillTank = True
        Catch ex As Exception
            GetFillTank = False
            AddLogEntry("Tank.GetFillTank: " & ex.Message)
        End Try
    End Function

    Public Sub GetCurrentRecord()
        Try
            UpdateClass(CurrentRecord)
        Catch ex As Exception
            AddLogEntry("Tank.GetCurrentRecord: " & ex.Message)
        End Try

    End Sub

    Public Sub GetPreviousRecord()
        Try
            CurrentRecord = CurrentRecord - 1
            UpdateClass(CurrentRecord)
        Catch ex As Exception
            AddLogEntry("Tank.GetPreviousRecord: " & ex.Message)
        End Try

    End Sub

    Public Sub GetFirstRecord()
        Try
            bEOF = False
            bBOF = False
            SQL.RunQuery("Select * from Tank")
            If SQL.RecordCount = 0 Then
                AddLogEntry("Tank Record not found")
                bBOF = True
                bEOF = True
                ClearClass()
            Else
                CurrentRecord = 0
                UpdateClass(CurrentRecord)
            End If
        Catch ex As Exception
            AddLogEntry("Tank.GetFirstRecord: " & ex.Message)
        End Try
    End Sub

    Public Sub GetNextRecord()
        Try
            CurrentRecord = CurrentRecord + 1
            UpdateClass(CurrentRecord)
        Catch ex As Exception
            AddLogEntry("Tank.GetNextRecord: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateClass(ByVal CRecord As Integer)
        Try
            If SQL.RecordCount - 1 < CRecord Then
                EOF = True
                Exit Sub
            End If
            'Stop
            With SQL.SQLDataset.Tables(0).Rows(CRecord)

                If String.IsNullOrEmpty(.Item("ID")) Then
                    sId = ""
                Else
                    sId = .Item("ID")
                End If
                If String.IsNullOrEmpty(.Item("Description")) Then
                    sDescription = ""
                Else
                    sDescription = .Item("Description")
                End If
                If String.IsNullOrEmpty(.Item("MaxTankTons")) Then
                    dMaxTankTons = 0
                Else
                    dMaxTankTons = .Item("MaxTankTons")
                End If
                If String.IsNullOrEmpty(.Item("LowAlarmValue")) Then
                    dLowAlarmValue = 0
                Else
                    dLowAlarmValue = .Item("LowAlarmValue")
                End If
                If String.IsNullOrEmpty(.Item("CurrentLevel")) Then
                    dCurrentLevel = 0
                Else
                    dCurrentLevel = .Item("CurrentLevel")
                End If
                If String.IsNullOrEmpty(.Item("ActiveScale")) Then
                    bActiveScale = 0
                Else
                    bActiveScale = .Item("ActiveScale")
                End If
                If String.IsNullOrEmpty(.Item("Type")) Then
                    bType = 0
                Else
                    bType = .Item("Type")
                End If
                If String.IsNullOrEmpty(.Item("Active")) Then
                    bActive = 0
                Else
                    bActive = .Item("Active")
                End If
                If String.IsNullOrEmpty(.Item("Commodity")) Then
                    sCommodity = ""
                Else
                    sCommodity = .Item("Commodity")
                End If
            End With
        Catch ex As Exception
            bBOF = True
            bEOF = True
            EOF = True
            'MsgBox(ex.Message)
            AddLogEntry("Tank.UpdateClass: " & ex.Message)
        End Try
    End Sub

    Public Sub ClearClass()

        sId = ""
        sDescription = ""
        dMaxTankTons = 0
        dLowAlarmValue = 0
        dCurrentLevel = 0
        bActiveScale = 0
        sCommodity = ""
        bType = 0
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

    Property Id() As String
        Get
            Id = sId
        End Get
        Set(value As String)
            sId = value
        End Set
    End Property

    Property Description() As String
        Get
            Description = sDescription
        End Get
        Set(value As String)
            sDescription = value
        End Set
    End Property

    Property MaxTankTons() As Double
        Get
            MaxTankTons = dMaxTankTons
        End Get
        Set(value As Double)
            dMaxTankTons = value
        End Set
    End Property

    Property LowAlarmValue() As Double
        Get
            LowAlarmValue = dLowAlarmValue
        End Get
        Set(value As Double)
            dLowAlarmValue = value
        End Set
    End Property

    Property CurrentLevel() As Double
        Get
            CurrentLevel = dCurrentLevel
        End Get
        Set(value As Double)
            dCurrentLevel = value
        End Set
    End Property

    Property ActiveScale() As Byte
        Get
            ActiveScale = bActiveScale
        End Get
        Set(value As Byte)
            bActiveScale = value
        End Set
    End Property

    Property CodeType() As Byte
        Get
            CodeType = bType
        End Get
        Set(value As Byte)
            bType = value
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

    Property Commodity() As String
        Get
            Commodity = sCommodity
        End Get
        Set(value As String)
            sCommodity = value
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

End Class
