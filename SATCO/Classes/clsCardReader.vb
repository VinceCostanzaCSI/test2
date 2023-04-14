Imports System.IO.Ports

Public Class clsCardReader
    Const ERR_DEVICE_UNAVAILABLE = 51
    '
    'local variable(s) to hold property value(s)
    Private ScaleMode As Integer    ' 0 = continuous   1 = on demand
    Private ScaleOpen As Integer
    Private MyScale As SerialPort
    Private ScaleStatus As Integer
    Private vScaleError As Integer

    Public Sub DisConnect(CardReader As SerialPort)

        CardReader.Close()

    End Sub

    Public Function Connect(CardReader As SerialPort)

        Try

            MyScale = CardReader

            MyScale.Close()
            Dim Err As Integer = 0
            MyScale.Open()

            ScaleOpen = True
            Connect = True

        Catch ex As Exception
            ScaleOpen = False
            Connect = False
        End Try
    End Function

    Public Sub New()

        ScaleOpen = False
        ScaleStatus = True

    End Sub

    Public ReadOnly Property CardReaderSettings() As String
        Get
            Dim SystemOptions As clsSystem

            SystemOptions = New clsSystem

            CardReaderSettings = ""

            Select Case SystemOptions.CardReaderBaud
                Case 1
                    CardReaderSettings = "2400"
                Case 2
                    CardReaderSettings = "4800"
                Case 3
                    CardReaderSettings = "9600"
                Case 4
                    CardReaderSettings = "14400"
                Case 5
                    CardReaderSettings = "19200"
                Case 6
                    CardReaderSettings = "38400"
                Case Else
                    CardReaderSettings = "9600"
            End Select

            Select Case SystemOptions.CardReaderParity
                Case 0
                    CardReaderSettings = CardReaderSettings & ",N"
                Case 1
                    CardReaderSettings = CardReaderSettings & ",E"
                Case 2
                    CardReaderSettings = CardReaderSettings & ",O"
                Case 3
                    CardReaderSettings = CardReaderSettings & ",S"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",N"
            End Select

            Select Case SystemOptions.CardReaderDataBits
                Case 0
                    CardReaderSettings = CardReaderSettings & ",7"
                Case 1
                    CardReaderSettings = CardReaderSettings & ",8"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",8"
            End Select

            Select Case SystemOptions.CardReaderStopBits
                Case 0
                    CardReaderSettings = CardReaderSettings & ",1"
                Case 1
                    CardReaderSettings = CardReaderSettings & ",2"
                Case Else
                    CardReaderSettings = CardReaderSettings & ",1"
            End Select

            SystemOptions = Nothing
        End Get
    End Property


End Class
