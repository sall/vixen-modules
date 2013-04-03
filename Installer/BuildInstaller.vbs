'Vixen Installer setup Build script.
' BuildInstaller.vbs		J.Liss       
'
' 04/03/2013 - J. Liss:		First version

'Path to the Makensis.exe 
strPathToNSIS = """C:\Program Files (x86)\NSIS\makensis.exe""" 'Double quotes for paths with spaces.

Dim intVersion
Const ForReading = 1
Const ForWriting = 2
Set objFSOg = CreateObject("Scripting.FileSystemObject")

strWorkingDir = left(WScript.ScriptFullName,(Len(WScript.ScriptFullName))-(len(WScript.ScriptName))) ' Our dir.
'Clean up before we start.
If objFSOg.FileExists(strWorkingDir & "Vixen-installer.nsi") Then objFSOg.DeleteFile left(WScript.ScriptFullName,(Len(WScript.ScriptFullName))-(len(WScript.ScriptName))) & "Vixen-installer.nsi"

'Read in our build version so we can update the installer with it.
intVersion = readFile(strWorkingDir & "version.txt")

'Open the template used to build the installer
strNSISTemplate = strWorkingDir & "Vixen-installer.template"
strNSIS = strWorkingDir & "Vixen-installer.nsi"
strFind =    "!define PRODUCT_VERSION ""X.X.X.X"""
strReplace = "!define PRODUCT_VERSION """ & intVersion & """"

'Switcher-roo
Set inputFile = CreateObject("Scripting.FileSystemObject").OpenTextFile(strNSISTemplate, ForReading)
strInputFile = inputFile.ReadAll
inputFile.Close
Set inputFile = Nothing
Set outputFile = CreateObject("Scripting.FileSystemObject").OpenTextFile(strNSIS,ForWriting,true)
outputFile.Write Replace(strInputFile, strFind, strReplace)
outputFile.Close
Set outputFile = Nothing

'Now run the makensis.exe to build the installer
Wscript.echo ""
Wscript.Echo "Vixen -> MakeNSIS - Building Installer..."
Wscript.Echo ""
call ExecuteWithTerminalOutput(strPathToNSIS & " """ & strWorkingDir & "\Vixen-installer.nsi""")
Wscript.Echo "Build Complete"

'Cleanup
If objFSOg.FileExists(strWorkingDir & "Vixen-installer.nsi") Then objFSOg.DeleteFile strWorkingDir & "Vixen-installer.nsi"


'Functions
'===================================
'Function readfile
'Reads txt file from path: c:\my documents\version.txt
function readFile(sPath) 
	Set objFileToRead = CreateObject("Scripting.FileSystemObject").OpenTextFile(sPath,1)
	readFile = objFileToRead.ReadAll()
	objFileToRead.Close
	Set objFileToRead = Nothing
end function


'===================================
'Function ExecuteWithTerminalOuput
'Runs a command and pipes back in the output
Function ExecuteWithTerminalOutput(cmd)
	Set sh = WScript.CreateObject("WScript.Shell")
	Set exec =  sh.Exec(cmd)
	Do While exec.Status = 0
		WScript.Sleep 10
		WScript.StdOut.Write(exec.StdOut.ReadAll())
		WScript.StdErr.Write(exec.StdErr.ReadAll())
	Loop
	ExecuteWithTerminalOutput = exec.Status
	set sh = nothing
End Function