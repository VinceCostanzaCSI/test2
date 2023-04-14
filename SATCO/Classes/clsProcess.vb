Imports System.Reflection
Imports System.IO

Public Class clsProcess
    
    Dim location = Assembly.GetExecutingAssembly().Location
    Dim appPath = Path.GetDirectoryName(location)       ' C:\Some\Directory
    Dim appName = Path.GetFileName(location)            ' MyLibrary.DLL

    Property ProcessDate() As Date
        Get
            ProcessDate = GetSetting(appName, "Process", "Date", Format(Now, "MM/dd/yyyy"))
        End Get
        Set(value As Date)
            SaveSetting(appName, "Process", "Date", value)
        End Set
    End Property
    Property ProcessTime() As Date
        Get
            ProcessTime = GetSetting(appName, "Process", "Time", Format(Now, "Short Time"))
        End Get
        Set(value As Date)
            SaveSetting(appName, "Process", "Time", value)
        End Set
    End Property

    Property CardId() As String
        Get
            CardId = GetSetting(appName, "Process", "CardID", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "CardID", value)
        End Set
    End Property

    Property DriverId() As String
        Get
            DriverId = GetSetting(appName, "Process", "DriverID", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "DriverID", value)
        End Set
    End Property
    Property DriverName() As String
        Get
            DriverName = GetSetting(appName, "Process", "DriverName", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "DriverName", value)
        End Set
    End Property
    Property Carrier() As String
        Get
            Carrier = GetSetting(appName, "Process", "Carrier", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Carrier", value)
        End Set
    End Property
    Property Code() As String
        Get
            Code = GetSetting(appName, "Process", "Code", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Code", value)
        End Set
    End Property
    Property Consignee() As String
        Get
            Consignee = GetSetting(appName, "Process", "Consignee", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Consignee", value)
        End Set
    End Property
    Property Destination() As String
        Get
            Destination = GetSetting(appName, "Process", "Destination", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Destination", value)
        End Set
    End Property
    Property NetCapacity() As String
        Get
            NetCapacity = GetSetting(appName, "Process", "NetCapacity", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "NetCapacity", value)
        End Set
    End Property
    Property TargetWt() As String
        Get
            TargetWt = GetSetting(appName, "Process", "TargetWt", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "TargetWt", value)
        End Set
    End Property
    Property DisplayTarget() As String
        Get
            DisplayTarget = GetSetting(appName, "Process", "DisplayTarget", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "DisplayTarget", value)
        End Set
    End Property
    Property MOCapacity() As String
        Get
            MOCapacity = GetSetting(appName, "Process", "MOCapacity", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "MOCapacity", value)
        End Set
    End Property
    Property Trailer() As String
        Get
            Trailer = GetSetting(appName, "Process", "Trailer", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Trailer", value)
        End Set
    End Property
    Property Seal1() As String
        Get
            Seal1 = GetSetting(appName, "Process", "Seal1", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Seal1", value)
        End Set
    End Property
    Property Seal2() As String
        Get
            Seal2 = GetSetting(appName, "Process", "Seal2", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Seal2", value)
        End Set
    End Property

    Property Seal3() As String
        Get
            Seal3 = GetSetting(appName, "Process", "Seal3", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Seal3", value)
        End Set
    End Property

    Property Seal4() As String
        Get
            Seal4 = GetSetting(appName, "Process", "Seal4", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Seal4", value)
        End Set
    End Property

    Property Vehicle() As String
        Get
            Vehicle = GetSetting(appName, "Process", "Vehicle", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Vehicle", value)
        End Set
    End Property
    Property Commodity() As String
        Get
            Commodity = GetSetting(appName, "Process", "Commodity", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Commodity", value)
        End Set
    End Property
    Property Description1() As String
        Get
            Description1 = GetSetting(appName, "Process", "Description1", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Description1", value)
        End Set
    End Property
    Property Description2() As String
        Get
            Description2 = GetSetting(appName, "Process", "Description2", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Description2", value)
        End Set
    End Property
    Property Description3() As String
        Get
            Description3 = GetSetting(appName, "Process", "Description3", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Description3", value)
        End Set
    End Property
    Property Description4() As String
        Get
            Description4 = GetSetting(appName, "Process", "Description4", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "Description4", value)
        End Set
    End Property
    Property ReleaseNumber() As String
        Get
            ReleaseNumber = GetSetting(appName, "Process", "ReleaseNumber", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "ReleaseNumber", value)
        End Set
    End Property
    Property PO() As String
        Get
            PO = GetSetting(appName, "Process", "PO", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "PO", value)
        End Set
    End Property
    Property FreeFlow() As String
        Get
            FreeFlow = GetSetting(appName, "Process", "FreeFlow", "")
        End Get
        Set(value As String)
            SaveSetting(appName, "Process", "FreeFlow", value)
        End Set
    End Property

End Class
