Dim WshNetwork, WshShell, otkluch, path
Set WshNetwork = WScript.CreateObject("WScript.Network") 
Set WshShell = WScript.CreateObject("WScript.Shell")
path=InputBox ("Vvedite nazvanie setevogo diska" & vbLf & _
  "i put dlya setevogo diska", , "A\\Sergei\mail")
On Error Resume Next  
WshNetwork.MapNetworkDrive Left(path, 1) & ":", Mid(path, 2)
If Err.Number<>0 Then
  Info="Oshibka pri podklychenii " & Drive & vbCrLf & _
       "Kod: " &  err.number & vbCrLf &+ _
       "Opisanie: " & err.description
WshShell.Popup Info,0,"Oshibka pri podklychenii",vbCritical
Else
Info="Disk " & Drive & "podkluchen"
  WshShell.Popup Info,0,"Podkluchenie diska",vbInformation
otkluch=WshShell.Popup( "Otklychaem?",,, 4)
Select Case otkluch
Case 6
On Error Resume Next  
WshNetwork.RemoveNetworkDrive Left(path, 1) & ":"
If Err.Number<>0 Then
  Info="Oshibka pri otkluchenii diska " & Drive & vbCrLf & _
       "Kod oshibki: " &  err.number & vbCrLf &+ _
       "Opisanie: " & err.description
  WshShell.Popup Info,0,"Otkluchenie diska",vbCritical
Else
  Info="Disk " & Drive & " uspeshno otkluchen"
  WshShell.Popup Info,0,"Otklychenie setevogo diska",vbInformation
End If
Case 7
End Select
End If