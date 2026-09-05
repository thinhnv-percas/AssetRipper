@echo off
setlocal

rem ---------------------------------------------------------------------------
rem Rip Test\Input\<name> to Test\Output at script content level 3, headless, in
rem one command. No clicking, and the same arguments every run.
rem
rem   RUN-TEST.bat                  rips Test\Input\Pinata
rem   RUN-TEST.bat MyGame           rips Test\Input\MyGame
rem   RUN-TEST.bat Pinata Debug     Debug build
rem
rem Rips in Release. A failed Debug.Assert in a Debug build calls
rem Environment.FailFast: the process ends with nothing written to the log. A
rem Release build has no asserts compiled into it.
rem
rem Writes, replacing whatever was there:
rem   Test\AssetRipper.log          the whole log
rem   Test\AssetRipper-recovery.log just the IL2Cpp recovery lines, for attaching
rem   Test\Output                   the ripped Unity project
rem ---------------------------------------------------------------------------

set "ROOT=%~dp0"
set "NAME=%~1"
if "%NAME%"=="" set "NAME=Pinata"
set "CONFIG=%~2"
if "%CONFIG%"=="" set "CONFIG=Release"

set "PROJECT=%ROOT%Source\AssetRipper.Tools.SystemTester\AssetRipper.Tools.SystemTester.csproj"
set "EXE=%ROOT%Source\0Bins\AssetRipper.Tools.SystemTester\%CONFIG%\AssetRipper.Tools.SystemTester.exe"
set "INPUT=%ROOT%Test\Input\%NAME%"
set "OUTPUT=%ROOT%Test\Output"
set "LOG=%ROOT%Test\AssetRipper.log"
set "SUMMARY=%ROOT%Test\AssetRipper-recovery.log"
set "STRUCTDB=%ROOT%StructDb"

if not exist "%INPUT%" (
    echo Input "%INPUT%" does not exist.
    echo Put the game under Test\Input\%NAME%, or pass a different name.
    exit /b 1
)

rem An Android rip needs both of these. Git's "bin" ignore rule used to swallow
rem assets\bin, which leaves a tree that looks complete but has no scripts in it.
if not exist "%INPUT%\assets\bin\Data\Managed\Metadata\global-metadata.dat" (
    echo.
    echo MISSING: %INPUT%\assets\bin\Data\Managed\Metadata\global-metadata.dat
    echo Without it there is no IL2Cpp metadata and no scripts can be recovered.
    exit /b 1
)

echo === Removing previous run ===
if exist "%LOG%" del /q "%LOG%"
if exist "%SUMMARY%" del /q "%SUMMARY%"
if exist "%OUTPUT%" rmdir /s /q "%OUTPUT%"

echo.
echo === Building %CONFIG% ===
dotnet build "%PROJECT%" -c %CONFIG% -v minimal
if errorlevel 1 (
    echo.
    echo BUILD FAILED - not running the test.
    exit /b 1
)

if exist "%STRUCTDB%\index.json" (
    echo Struct database: present
) else (
    echo Struct database: MISSING from "%STRUCTDB%"
)

echo.
echo === Ripping %NAME% ===
echo Input:  %INPUT%
echo Output: %OUTPUT%
echo Log:    %LOG%
echo.

"%EXE%" --script-level 3 --reconstruct-bodies --struct-db "%STRUCTDB%" --output "%OUTPUT%" --log "%LOG%" "%INPUT%"
set "EXITCODE=%ERRORLEVEL%"

echo.
if not exist "%LOG%" (
    echo No log was written. The run exited with code %EXITCODE%.
    endlocal
    exit /b %EXITCODE%
)

echo === Recovery lines ===
findstr /i /c:"Il2Cpp recovery" /c:"IL2CPP struct database" /c:"method body recovery" /c:"Il2Cpp initialization" /c:"Native source injection" /c:"was abandoned part way" /c:"ScriptContentLevel" /c:"Ripped to" "%LOG%" > "%SUMMARY%"
type "%SUMMARY%"

echo.
echo Full log:    %LOG%
echo Summary log: %SUMMARY%
echo Output:      %OUTPUT%

endlocal
exit /b %EXITCODE%
