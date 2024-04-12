strComputer = "."

Set WSHShell = CreateObject("WScript.Shell")
WScript.Echo "System path: " & WSHShell.ExpandEnvironmentStrings("%windir%")

Set objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\CIMV2")
Set colCSes = objWMIService.ExecQuery("SELECT * FROM Win32_ComputerSystem")
For Each objCS In colCSes
 Wscript.Echo "UserName: " & objCS.UserName '2 задание
 WScript.Echo "Computer Name: " & objCS.Name
 WScript.Echo "System Family: " & objCS.SystemFamily '1 задание
 WScript.Echo "System Type: " & objCS.SystemType
 WScript.Echo "System SKU number: " & objCS.SystemSKUNumber
Next
Set colProcessors = objWMIService.ExecQuery("Select * from Win32_Processor")
For Each objProcessor in colProcessors
 WScript.Echo "Manufacturer: " & objProcessor.Manufacturer ' тип процессора
 WScript.Echo "Name: " & objProcessor.Name ' тип процессора
Next