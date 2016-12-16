@ECHO off
SETLOCAL

REM Before running this batch file, you must build the CodeEvalProjectTemplate solution.
REM Also, this batch file is run automatically as a post-build event of the CodeEvalProjectTemplate solution.

REM Get the current user's Documents folder.

for /f "tokens=3*" %%p in ('REG QUERY "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders" /v Personal') do (
    SET DocumentsFolder=%%p
)
ECHO %DocumentsFolder%

REM Copy CodeEvalProjectTemplate.zip to the Visual Studio 2015 (v14.0) templates folder.
REM Update the paths below as needed for your environment.

SET Source="..\Debug\ProjectTemplates\CSharp\1033\\"
SET Dest="%DocumentsFolder%\Visual Studio 2015\Templates\ProjectTemplates\Custom\\"
ECHO %Source%
ECHO %Dest%
robocopy %Source% %Dest% /s

REM PAUSE