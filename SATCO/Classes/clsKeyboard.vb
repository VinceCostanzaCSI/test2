Imports System.Reflection
Imports System.IO

Public Class clsKeyboard

    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    'local variable(s) to hold property value(s)
    Private sLabel As String        'local copy
    Private iLength As Integer      'local copy
    Private sData As String         'local copy

    Public Property Data() As String
        Get
            Data = GetSetting(appName, "Keyboard", "Data", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Keyboard", "Data", value)
        End Set
    End Property
    Public Property Length() As Integer
        Get
            Length = GetSetting(appName, "Keyboard", "Length", "")
        End Get
        Set(value As Integer)
            SaveSetting(appName, "Keyboard", "Length", value)
        End Set
    End Property
    Public Property Label() As String
        Get
            Label = GetSetting(appName, "Keyboard", "Label", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Keyboard", "Label", value & "")
        End Set
    End Property

    Public Property Password() As String
        Get
            Password = GetSetting(appName, "Keyboard", "Password", " ")
        End Get
        Set(value As String)
            SaveSetting(appName, "Keyboard", "Password", value)
        End Set
    End Property

End Class
