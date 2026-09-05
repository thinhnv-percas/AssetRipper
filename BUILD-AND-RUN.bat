@echo off
setlocal

rem ---------------------------------------------------------------------------
rem Build AssetRipper, throw away the previous log, and start it with a fixed
rem log path so the file is easy to find and attach.
rem
rem   BUILD-AND-RUN.bat                 Release build, random port
rem   BUILD-AND-RUN.bat Debug           Debug build
rem   BUILD-AND-RUN.bat Release 17845   Release build on a fixed port
rem
rem Rip in Release. AssetRipper asserts its own invariants with Debug.Assert in a
rem few hundred places, and on a real game one of them can be wrong; in a Debug
rem build a failed assert calls Environment.FailFast, which ends the process with
rem nothing written to the log and the message only on standard error. A Release
rem build has none of those asserts compiled into it. Use Debug to attach a
rem debugger, not to rip.
rem
rem Writes two files next to this script, replacing whatever was there:
rem   AssetRipper.log             the whole log
rem   AssetRipper-recovery.log    just the IL2Cpp recovery lines, for attaching
rem ---------------------------------------------------------------------------

set "ROOT=%~dp0"
set "CONFIG=%~1"
if "%CONFIG%"=="" set "CONFIG=Release"
set "PORT=%~2"

set "PROJECT=%ROOT%Source\AssetRipper.GUI.Free\AssetRipper.GUI.Free.csproj"
set "OUTDIR=%ROOT%Source\0Bins\AssetRipper.GUI.Free\%CONFIG%"
set "EXE=%OUTDIR%\AssetRipper.GUI.Free.exe"
set "LOG=%ROOT%AssetRipper.log"
set "SUMMARY=%ROOT%AssetRipper-recovery.log"
set "CRASH=%ROOT%AssetRipper-crash.log"

echo === Removing old logs ===
rem The two files this script writes, plus the timestamped ones AssetRipper
rem creates when started without --log-path.
if exist "%LOG%" del /q "%LOG%"
if exist "%SUMMARY%" del /q "%SUMMARY%"
if exist "%CRASH%" del /q "%CRASH%"
if exist "%ROOT%AssetRipper_*.log" del /q "%ROOT%AssetRipper_*.log"
if exist "%OUTDIR%\AssetRipper_*.log" del /q "%OUTDIR%\AssetRipper_*.log"

echo.
echo === Building %CONFIG% ===
dotnet build "%PROJECT%" -c %CONFIG% -v minimal
if errorlevel 1 (
    echo.
    echo BUILD FAILED - not starting AssetRipper.
    exit /b 1
)

if not exist "%EXE%" (
    echo.
    echo Build reported success but "%EXE%" is missing.
    exit /b 1
)

rem The struct database is copied to the output directory by the build. Without it,
rem recovered bodies show raw offsets instead of runtime field names.
if exist "%OUTDIR%\structdb\index.json" (
    echo Struct database: present
) else (
    echo Struct database: MISSING from "%OUTDIR%\structdb"
)

echo.
echo === Starting AssetRipper ===
echo Log: %LOG%
echo.
echo This script passes --log-path, which overrides the Log file path setting.
echo.
echo 1. Settings - set Script Content Level to Level 3, Save.
echo 2. Load the game, then export the Unity project.
echo 3. Close AssetRipper. This window then writes the summary log.
echo.

set "ARGS=--log-path "%LOG%""
if not "%PORT%"=="" set "ARGS=%ARGS% --port %PORT%"

rem Standard error goes to a file of its own. The two ways AssetRipper can end
rem without the logger seeing anything - a failed Debug.Assert, which calls
rem Environment.FailFast, and a stack overflow - both write there and nowhere
rem else, so this file is what says which one happened and where.
pushd "%OUTDIR%"
"%EXE%" %ARGS% 2>"%CRASH%"
set "EXITCODE=%ERRORLEVEL%"
popd

echo.
for %%F in ("%CRASH%") do if %%~zF GTR 0 (
    echo === Standard error - the process ended without logging ===
    type "%CRASH%"
    echo.
    echo Saved to: %CRASH%
    echo.
)

if not exist "%LOG%" (
    echo No log was written. AssetRipper exited with code %EXITCODE%.
    endlocal
    exit /b %EXITCODE%
)

echo === Recovery lines ===
findstr /i /c:"Il2Cpp recovery" /c:"IL2CPP struct database" /c:"method body recovery" /c:"Il2Cpp initialization" /c:"Native source injection" /c:"was abandoned part way" /c:"ScriptContentLevel" /c:"EmitIl2CppOffsets" /c:"ReconstructNativeBodies" /c:"Il2CppStructDbPath" /c:"DefaultExportPath" /c:"Attempting to export assets" "%LOG%" > "%SUMMARY%"
type "%SUMMARY%"

echo.
echo Full log:    %LOG%
echo Summary log: %SUMMARY%

endlocal
exit /b %EXITCODE%
