Module ADU208

    Structure ADU_DEVICE_ID
        Dim iVendorId As Short
        Dim iProductId As Short


        <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=7)> Public sSerialNumber As String
    End Structure

    Declare Function OpenAduDevice Lib "AduHid64.DLL" (ByVal iTimeout As Integer) As Integer

    Declare Function WriteAduDevice Lib "AduHid64.DLL" (ByVal aduHandle As Integer, ByVal lpBuffer As String, ByVal lNumberOfBytesToWrite As Integer, ByRef lBytesWritten As Integer, ByVal iTimeout As Integer) As Integer

    Declare Function ReadAduDevice Lib "AduHid64.DLL" (ByVal aduHandle As Integer, ByVal lpBuffer As String, ByVal lNumberOfBytesToRead As Integer, ByRef lBytesRead As Integer, ByVal iTimeout As Integer) As Integer

    Declare Function CloseAduDevice Lib "AduHid64.DLL" (ByVal iOverlapped As Integer) As Integer

    Declare Function ShowAduDeviceList Lib "AduHid64.DLL" (ByRef pAduDeviceId As ADU_DEVICE_ID, ByVal sPrompt As String) As Integer

    Declare Function OpenAduDeviceBySerialNumber Lib "AduHid64.DLL" (ByVal pSerialNumber As String, ByVal iTimeout As Integer) As Integer

    Declare Function ADUCount Lib "AduHid64.DLL" (ByVal iTimeout As Integer) As Integer

    Declare Function GetADU Lib "AduHid64.DLL" (ByRef pAduDeviceId As ADU_DEVICE_ID, ByVal iIndex As Integer, ByVal iTimeout As Integer) As Integer

End Module
