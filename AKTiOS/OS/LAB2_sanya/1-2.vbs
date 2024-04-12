strComputer = "."

Set WSHShell = CreateObject("WScript.Shell")
WScript.Echo "System path: " & WSHShell.ExpandEnvironmentStrings("%windir%")

Set objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\CIMV2")
Set colCSes = objWMIService.ExecQuery("SELECT * FROM Win32_ComputerSystem")
For Each objCS In colCSes
 Wscript.Echo "UserName: " & objCS.UserName
 WScript.Echo "Computer Name: " & objCS.Name
Next
Set colProcessors = objWMIService.ExecQuery("Select * from Win32_Processor")
For Each objProcessor in colProcessors
 WScript.Echo "Manufacturer: " & objProcessor.Manufacturer
 WScript.Echo "Name: " & objProcessor.Name
 WScript.Echo "Description: " & objProcessor.Description
Next