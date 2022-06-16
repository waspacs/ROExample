Public Class Form1
    Private Declare Function ReadMemoryLong Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As IntPtr, ByVal Address As Long, ByRef Value As Long, Optional ByVal Size As Integer = 8, Optional ByRef Bytes As Integer = 0) As Long
    Private Declare Function ReadMemoryInteger Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As IntPtr, ByVal Address As Long, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
    Private Declare Function WriteMemoryInteger Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As IntPtr, ByVal Address As Long, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer

    Public Function GetPMValue(ByVal ProcessName As String, ByVal Pointer As Long, Optional ByVal OffSets() As Long = Nothing) As Integer
        Dim ReturnLong As Long = 0
        Dim ReturnInteger As Integer = 0
        Dim Pprocess As Process = Process.GetProcessesByName(ProcessName)(1)
        Dim Phandle As IntPtr = Pprocess.Handle
        If OffSets IsNot Nothing Then
            Dim PbaseAdress As Long = Pprocess.MainModule.BaseAddress.ToInt64 + Pointer
            ReadMemoryLong(Phandle, PbaseAdress, ReturnLong)
            For Each i As Long In OffSets
                If i <> OffSets.Last() Then
                    ReadMemoryLong(Phandle, ReturnLong + i, ReturnLong)
                End If
            Next
            ReadMemoryInteger(Phandle, CLng("&H" + Hex(ReturnLong + OffSets.Last())), ReturnInteger)
        Else
            ReadMemoryInteger(Phandle, Pointer, ReturnInteger)
        End If
        Return ReturnInteger
    End Function

    Public Function EditPMValue(ByVal ProcessName As String, ByVal Pointer As Long, ByVal Value As Integer, Optional ByVal OffSets() As Long = Nothing)
        Dim ReturnLong As Long = 0
        Dim ReturnInteger As Integer = 0
        Dim Pprocess As Process = Process.GetProcessesByName(ProcessName)(0)
        Dim Phandle As IntPtr = Pprocess.Handle
        If OffSets IsNot Nothing Then
            Dim PbaseAdress As Long = Pprocess.MainModule.BaseAddress.ToInt64 + Pointer
            ReadMemoryLong(Phandle, PbaseAdress, ReturnLong)
            For Each i As Long In OffSets
                If i <> OffSets.Last() Then
                    ReadMemoryLong(Phandle, ReturnLong + i, ReturnLong)
                End If
            Next
            WriteMemoryInteger(Phandle, CLng("&H" + Hex(ReturnLong + OffSets.Last())), Value)
        Else
            WriteMemoryInteger(Phandle, Pointer, Value)
        End If
        Return vbNull
    End Function
    Private Sub alwaysOnTop_CheckedChanged(sender As Object, e As EventArgs) Handles alwaysOnTop.CheckedChanged
        If alwaysOnTop.Checked Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Private Sub readCb_CheckedChanged(sender As Object, e As EventArgs) Handles readCb.CheckedChanged
        If readCb.Checked Then
            readTimer.Start()
        Else
            readTimer.Stop()
        End If
    End Sub

    Private Sub readTimer_Tick(sender As Object, e As EventArgs) Handles readTimer.Tick
        hplabel.Text = "HP: " & GetPMValue("RiseOnline-Win64-Shipping", &H5A32590, {&H8, &H8, &HEB0, &H20, &H78, &H2F8, &H84C})
    End Sub
End Class
