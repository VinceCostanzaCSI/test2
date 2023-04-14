

Public Class clsControl
    Const TIMEOUT_VALUE = 3
    'Dim aduhandle As Integer
    Dim iRC As Integer
    Dim iBytesWritten As Integer

    Public Function DisplayedWeight() As String
        DisplayedWeight = frmTransactionProcessing.Scale1Box.Text
        'DisplayedWeight = frmTransactionProcessing.txtGross.Text
    End Function

    Public Sub ZeroScale()
        'Talk to Scale indicator
        MsgBox("Press ZERO ->0<- on the scale indicator or remove weight from scale")
    End Sub

    '------ Trailer Load ADU -----------------------------
    'Relay	On		Off
    'K0	SA Enable	SA Disable
    'K1	UC Enable	UC Disable
    'K2 H2O Enable  H2O Disable
    'K3 Red Light
    'K4 Green Light
    'K5 Camera Start
    'K6		
    'K7	Gate Open	Gate Close  (for Satco Manager only)
    '
    'PA0	SA Driver Ready
    'PA1	SA Platform Ready
    'PA2	SA Loading Arm Ready
    'PA3	SA Rail Ready (for Scale 2 only)
    '
    'PB0	UC Driver Ready
    'PB1	UC Platform Ready
    'PB2	UC Loading Arm Ready
    'PB3    H2O Driver Ready

    '----- Tank Select ADU -----------------------------
    'Relay	On		Off
    'K0	Tank1
    'K1	Tank2
    'K2 Tank5
    '
    'PA0	Tank 1 Ready
    'PA1	Tank 2 Ready
    'PA2	Tank 5 Ready
    'PA3	Manual Mode

    'Use ADU208.vb to open ADU with OpenADUbySerialNumber
    'Public Sub OpenADU()
    '    Try
    '        aduhandle = OpenAduDeviceBySerialNumber("C32099", 1)
    '        'Stop
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '        AddLogEntry("Couldn't Open ADU Device")
    '    End Try
    'End Sub

    Public Function SAEnable() As Boolean
        Try
            iRC = WriteAduDevice(aduhandle, "SK0", 3, 0, 500)
            SAEnable = True
        Catch ex As Exception
            SAEnable = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function SADisable() As Boolean
        Try
            iRC = WriteAduDevice(aduhandle, "RK0", 3, 0, 500)
            SADisable = True
        Catch ex As Exception
            SADisable = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function UCEnable() As Boolean
        Try
            iRC = WriteAduDevice(aduhandle, "SK1", 3, 0, 500)
            UCEnable = True
        Catch ex As Exception
            UCEnable = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function UCDisable() As Boolean
        Try
            iRC = WriteAduDevice(aduhandle, "RK1", 3, 0, 500)
            UCDisable = True
        Catch ex As Exception
            UCDisable = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function H2OEnable() As Boolean
        Try
            iRC = WriteAduDevice(aduhandle, "SK2", 3, 0, 500)
            H2OEnable = True
        Catch ex As Exception
            H2OEnable = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function H2ODisable() As Boolean
        Try
            iRC = WriteAduDevice(aduhandle, "RK2", 3, 0, 500)
            H2ODisable = True
        Catch ex As Exception
            H2ODisable = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Sub SetTrafficLightRed()
        Try
            iRC = WriteAduDevice(aduhandle, "SK4", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK3", 3, iBytesWritten, 500)
            'Stop
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub SetTrafficLightGreen()
        Try
            iRC = WriteAduDevice(aduhandle, "SK3", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK4", 3, iBytesWritten, 500)
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub CameraOn()
        Try
            iRC = WriteAduDevice(aduhandle, "SK5", 3, 0, 500)
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub CameraOff()
        Try
            iRC = WriteAduDevice(aduhandle, "RK5", 3, 0, 500)
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub OpenEntryGate()
        Try
            iRC = WriteAduDevice(aduhandle, "SK7", 3, 0, 500)
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub CloseEntryGate()
        Try
            iRC = WriteAduDevice(aduhandle, "RK7", 3, 0, 500)
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub SetWatchDog(ByVal WSet As Integer)
        'WSet values: 0 = Off, 1 = 1s, 2 = 10s, 3, = 1 min
        Try
            iRC = WriteAduDevice(aduhandle, "WD" & WSet, 3, 0, 500)
        Catch ex As Exception
            AddLogEntry(ex.Message)
        End Try
    End Sub

    Public Sub ResetTankRequest()
        Try
            'Turn Off Tank1, Tank2 and Tank5
            iRC = WriteAduDevice(aduhandle, "RK0", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK1", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK2", 3, iBytesWritten, 500)
            'Stop
        Catch ex As Exception
            AddLogEntry("ResetTankRequest: " & ex.Message)
        End Try
    End Sub

    Public Sub SetTank1()
        Try
            'Turn Off Tank2 and Tank5
            iRC = WriteAduDevice(aduhandle, "RK1", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK2", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "SK0", 3, iBytesWritten, 500)
            'Stop
        Catch ex As Exception
            AddLogEntry("SetTank1: " & ex.Message)
        End Try
    End Sub

    Public Sub SetTank2()
        Try
            'Turn Off Tank1 and Tank5
            iRC = WriteAduDevice(aduhandle, "RK0", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK2", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "SK1", 3, iBytesWritten, 500)
            'Stop
        Catch ex As Exception
            AddLogEntry("SetTank2: " & ex.Message)
        End Try
    End Sub

    Public Sub SetTank5()
        Try
            'Turn Off Tank1 and Tank2
            iRC = WriteAduDevice(aduhandle, "RK0", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "RK1", 3, iBytesWritten, 500)
            Delay(400)
            iRC = WriteAduDevice(aduhandle, "SK2", 3, iBytesWritten, 500)
            'Stop
        Catch ex As Exception
            AddLogEntry("SetTank5: " & ex.Message)
        End Try
    End Sub

    '------------------READ ADU ------------------

    Public Function SADriverReady() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA0", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            ADUResponse = sResponse
            If Mid(sResponse, 1, 1) = "0" Then
                SADriverReady = True
            Else
                SADriverReady = False
            End If
        Catch ex As Exception
            SADriverReady = False
            AddLogEntry(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Function

    Public Function SouthPlatformUp() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA1", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                SouthPlatformUp = True
            Else
                SouthPlatformUp = False
            End If
        Catch ex As Exception
            SouthPlatformUp = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function SALoadingArmUp() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA2", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                SALoadingArmUp = True
            Else
                SALoadingArmUp = False
            End If
        Catch ex As Exception
            SALoadingArmUp = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function SARailReady() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA3", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                SARailReady = True
            Else
                SARailReady = False
            End If
        Catch ex As Exception
            SARailReady = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function UCDriverReady() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPB0", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                UCDriverReady = True
            Else
                UCDriverReady = False
            End If
        Catch ex As Exception
            UCDriverReady = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function NorthPlatformUp() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPB1", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                NorthPlatformUp = True
            Else
                NorthPlatformUp = False
            End If
        Catch ex As Exception
            NorthPlatformUp = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function UCLoadingArmUp() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPB2", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                UCLoadingArmUp = True
            Else
                UCLoadingArmUp = False
            End If
        Catch ex As Exception
            UCLoadingArmUp = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function H2ODriverReady() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPB3", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            If Mid(sResponse, 1, 1) = "0" Then
                H2ODriverReady = True
            Else
                H2ODriverReady = False
            End If
        Catch ex As Exception
            H2ODriverReady = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    Public Function ReadWatchDog() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "WD", 2, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            frmTransactionProcessing.txtWD.Text = sResponse
            If Mid(sResponse, 1, 1) = "0" Then
                'WatchDog not enabled or timeout has occured
                ReadWatchDog = True
            Else
                ReadWatchDog = False
            End If
        Catch ex As Exception
            ReadWatchDog = False
            AddLogEntry(ex.Message)
        End Try
    End Function

    '------------------READ Tank Select ADU ------------------

    Public Function Tank1Ready() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA0", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            ADUResponse = sResponse
            If Mid(sResponse, 1, 1) = "0" Then
                Tank1Ready = True
            Else
                Tank1Ready = False
            End If
        Catch ex As Exception
            Tank1Ready = False
            AddLogEntry(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Function

    Public Function Tank2Ready() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA1", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            ADUResponse = sResponse
            If Mid(sResponse, 1, 1) = "0" Then
                Tank2Ready = True
            Else
                Tank2Ready = False
            End If
        Catch ex As Exception
            Tank2Ready = False
            AddLogEntry(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Function

    Public Function Tank5Ready() As Boolean
        Dim sResponse As String
        Dim iBytesRead As Integer
        Try
            sResponse = "+++ No Data+++"
            iRC = WriteAduDevice(aduhandle, "RPA2", 4, 0, 500)
            iRC = ReadAduDevice(aduhandle, sResponse, 7, iBytesRead, 500)
            ADUResponse = sResponse
            If Mid(sResponse, 1, 1) = "0" Then
                Tank5Ready = True
            Else
                Tank5Ready = False
            End If
        Catch ex As Exception
            Tank5Ready = False
            AddLogEntry(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Function

End Class
