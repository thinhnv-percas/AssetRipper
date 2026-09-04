@echo off
setlocal

rem ---------------------------------------------------------------------------
rem Build AssetRipper, throw away the previous log, and start it with a fixed
rem log path so the file is easy to find and attach.
rem
rem   BUILD-AND-RUN.bat                 Debug build, random port
rem   BUILD-AND-RUN.bat Release         Release build
rem   BUILD-AND-RUN.bat Debug 17845     Debug build on a fixed port
rem
rem Writes two files next to this script, replacing whatever was there:
rem   AssetRipper.log             the whole log
rem   AssetRipper-recovery.log    just the IL2Cpp recovery lines, for attaching
rem ---------------------------------------------------------------------------

set "ROOT=%~dp0"
set "CONFIG=%~1"
if "%CONFIG%"=="" set "CONFIG=Debug"
set "PORT=%~2"

set "PROJECT=%ROOT%Source\AssetRipper.GUI.Free\AssetRipper.GUI.Free.csproj"
set "OUTDIR=%ROOT%Source\0Bins\AssetRipper.GUI.Free\%CONFIG%"
set "EXE=%OUTDIR%\AssetRipper.GUI.Free.exe"
set "LOG=%ROOT%AssetRipper.log"
set "SUMMARY=%ROOT%AssetRipper-recovery.log"

echo === Removing old logs ===
rem The two files this script writes, plus the timestamped ones AssetRipper
rem creates when started without --log-path.
if exist "%LOG%" del /q "%LOG%"
if exist "%SUMMARY%" del /q "%SUMMARY%"
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
echo 1. Settings - set Script Content Level to Level 3, Save.
echo 2. Load the game, then export the Unity project.
echo 3. Close AssetRipper. This window then writes the summary log.
echo.

set "ARGS=--log-path "%LOG%""
if not "%PORT%"=="" set "ARGS=%ARGS% --port %PORT%"

pushd "%OUTDIR%"
"%EXE%" %ARGS%
set "EXITCODE=%ERRORLEVEL%"
popd

echo.
if not exist "%LOG%" (
    echo No log was written. AssetRipper exited with code %EXITCODE%.
    endlocal
    exit /b %EXITCODE%
)

echo === Recovery lines ===
findstr /i /c:"Il2Cpp recovery" /c:"IL2CPP struct database" /c:"method body recovery" /c:"Il2Cpp initialization" /c:"ScriptContentLevel" /c:"EmitIl2CppOffsets" /c:"ReconstructNativeBodies" /c:"Il2CppStructDbPath" "%LOG%" > "%SUMMARY%"
type "%SUMMARY%"

echo.
echo Full log:    %LOG%
echo Summary log: %SUMMARY%

endlocal
exit /b %EXITCODE%
