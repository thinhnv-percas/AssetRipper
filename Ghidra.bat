@echo off
setlocal

:: Sets up Ghidra for script content level 4 and launches AssetRipper with it.
::
:: Ghidra is not bundled with AssetRipper. This downloads it into .\ghidra the
:: first time, then reuses that installation on every later run.
::
:: An existing installation is used instead if GHIDRA_INSTALL_DIR points at one.
::
:: Any arguments are forwarded to AssetRipper.
::
:: Ghidra requires a JDK 21 runtime.

set "GHIDRA_VERSION=12.1.2"
set "GHIDRA_BUILD=20260605"
set "GHIDRA_ARCHIVE=ghidra_%GHIDRA_VERSION%_PUBLIC_%GHIDRA_BUILD%.zip"
set "GHIDRA_URL=https://github.com/NationalSecurityAgency/ghidra/releases/download/Ghidra_%GHIDRA_VERSION%_build/%GHIDRA_ARCHIVE%"

set "ROOT=%~dp0"
set "LOCAL_INSTALL=%ROOT%ghidra"
set "EXTRACT_DIR=%ROOT%ghidra_extract_tmp"

if not defined GHIDRA_INSTALL_DIR goto :checkLocal
if not exist "%GHIDRA_INSTALL_DIR%\support\analyzeHeadless.bat" goto :checkLocal
echo Using the Ghidra installation from GHIDRA_INSTALL_DIR: %GHIDRA_INSTALL_DIR%
goto :launch

:checkLocal
if not exist "%LOCAL_INSTALL%\support\analyzeHeadless.bat" goto :install
echo Using the Ghidra installation at %LOCAL_INSTALL%
set "GHIDRA_INSTALL_DIR=%LOCAL_INSTALL%"
goto :launch

:install
echo Ghidra was not found. Downloading %GHIDRA_VERSION% into %LOCAL_INSTALL%
echo This is a large download and only happens once.

if exist "%ROOT%%GHIDRA_ARCHIVE%" (
	echo Reusing the already downloaded %GHIDRA_ARCHIVE%
) else (
	curl -L --fail -o "%ROOT%%GHIDRA_ARCHIVE%" "%GHIDRA_URL%"
	if errorlevel 1 (
		echo Failed to download Ghidra from %GHIDRA_URL%
		pause
		exit /b 1
	)
)

if exist "%EXTRACT_DIR%" rmdir /s /q "%EXTRACT_DIR%"
mkdir "%EXTRACT_DIR%"

:: tar ships with Windows 10 and later and handles zip archives.
tar -xf "%ROOT%%GHIDRA_ARCHIVE%" -C "%EXTRACT_DIR%"
if errorlevel 1 (
	echo Failed to extract %GHIDRA_ARCHIVE%
	pause
	exit /b 1
)

if exist "%LOCAL_INSTALL%" rmdir /s /q "%LOCAL_INSTALL%"
move "%EXTRACT_DIR%\ghidra_%GHIDRA_VERSION%_PUBLIC" "%LOCAL_INSTALL%" >nul
rmdir /s /q "%EXTRACT_DIR%"

if not exist "%LOCAL_INSTALL%\support\analyzeHeadless.bat" (
	echo The downloaded archive did not contain a Ghidra installation.
	pause
	exit /b 1
)

set "GHIDRA_INSTALL_DIR=%LOCAL_INSTALL%"
echo Ghidra installed at %LOCAL_INSTALL%

:launch
where java >nul 2>nul
if errorlevel 1 echo Warning: java was not found on PATH. Ghidra needs a JDK 21 runtime.

echo.
echo Starting AssetRipper. Select script content level 4 in the settings to use Ghidra.
call "%ROOT%Run.bat" %*

endlocal
