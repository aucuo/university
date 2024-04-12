Option Explicit
Dim objWMIService, objItem, colItems, strComputer, intPrinters

strComputer ="."
intPrinters = 1

Set objWMIService = GetObject _
("winmgmts:\\" & strComputer & "\root\CIMV2")
Set colItems = objWMIService.ExecQuery _
("SELECT * FROM Win32_Printer")

' On Error Resume Next
For Each objItem In colItems
WScript.Echo "Printers on " _
& objItem.name & ", Printer Number: " & intPrinters & VbCr & _ 
"====================================" & VbCr & _ 
"Availability: " & objItem.Availability & VbCr & _
"Description: " & objItem.Description & VbCr & _ 
"Printer: " & objItem.DeviceID & VbCr & _ 
"Driver Name: " & objItem.DriverName & VbCr & _ 
"Port Name: " & objItem.PortName & VbCr & _ 
"Printer State: " & objItem.PrinterState & VbCr & _ 
"Printer Status: " & objItem.PrinterStatus & VbCr & _ 
"PrintJobDataType: " & objItem.PrintJobDataType & VbCr & _ 
"Print Processor: " & objItem.PrintProcessor & VbCr & _ 
"Spool Enabled: " & objItem.SpoolEnabled & VbCr & _ 
"Separator File: " & objItem.SeparatorFile & VbCr & _ 
"Queued: " & objItem.Queued & VbCr & _ 
"Status: " & objItem.Status & VbCr & _ 
"StatusInfo: " & objItem.StatusInfo & VbCr & _ 
"Published: " & objItem.Published & VbCr & _ 
"Shared: " & objItem.Shared & VbCr & _ 
"ShareName: " & objItem.ShareName & VbCr & _ 
"Direct: " & objItem.Direct & VbCr & _ 
"Location: " & objItem.Location & VbCr & _ 
"Priority: " & objItem.Priority & VbCr & _ 
"Work Offline: " & objItem.WorkOffline & VbCr & _ 
"Horizontal Res: " & objItem.HorizontalResolution & VbCr & _
"Vertical Res: " & objItem.VerticalResolution & VbCr & _ 
""
' SetDefault Printer
intPrinters = intPrinters + 1
Next

Dim WshNetwork, WshShell, otkluch, path
Set WshNetwork = WScript.CreateObject("WScript.Network") 
Set WshShell = WScript.CreateObject("WScript.Shell")
path=InputBox ("Vvedite nazvanie PRINTERA", , "Fax")
WshNetwork.SetDefaultPrinter path