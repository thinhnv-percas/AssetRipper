@echo off
setlocal enabledelayedexpansion

REM ============================================================================
REM  build_windows.bat
REM
REM  Builds standalone Windows .exe files for the Python port of AssetRipper
REM  (assetripper-inspect.exe and assetripper-gui-web.exe) using PyInstaller.
REM
REM  Run this script FROM WINDOWS, from the `python\` directory of this repo
REM  (the same directory as pyproject.toml), with Python 3.11+ installed and
REM  on PATH. It cannot be run in this Linux sandbox -- PyInstaller cannot
REM  cross-compile a Windows .exe from Linux, which is why this script exists
REM  for you to run locally instead.
REM
REM  Usage:
REM      build_windows.bat
REM
REM  Output:
REM      dist\assetripper-inspect.exe
REM      dist\assetripper-gui-web.exe
REM ============================================================================

if not exist "pyproject.toml" (
    echo [ERROR] pyproject.toml not found in the current directory.
    echo         Run this script from the "python" folder of the AssetRipper repo.
    exit /b 1
)

echo [1/5] Checking for Python...
where python >nul 2>nul
if errorlevel 1 (
    echo [ERROR] Python was not found on PATH.
    echo         Install Python 3.11+ from https://www.python.org/downloads/
    echo         and make sure "Add python.exe to PATH" is checked during setup.
    exit /b 1
)

for /f "tokens=2 delims= " %%v in ('python --version 2^>^&1') do set PY_VERSION=%%v
echo       Found Python %PY_VERSION%

echo [2/5] Creating a clean build virtual environment (.venv-build)...
if exist ".venv-build" (
    echo       Removing existing .venv-build...
    rmdir /s /q ".venv-build"
)
python -m venv .venv-build
if errorlevel 1 (
    echo [ERROR] Failed to create the virtual environment.
    exit /b 1
)

call ".venv-build\Scripts\activate.bat"
if errorlevel 1 (
    echo [ERROR] Failed to activate the virtual environment.
    exit /b 1
)

echo [3/5] Installing assetripper-python and PyInstaller...
python -m pip install --upgrade pip >nul
python -m pip install ".[build]"
if errorlevel 1 (
    echo [ERROR] Failed to install dependencies.
    call ".venv-build\Scripts\deactivate.bat"
    exit /b 1
)

echo [4/5] Building assetripper-inspect.exe...
pyinstaller --noconfirm --onefile --name assetripper-inspect ^
    --paths src ^
    src\assetripper_cli\__main__.py
if errorlevel 1 (
    echo [ERROR] PyInstaller build failed for assetripper-inspect.
    call ".venv-build\Scripts\deactivate.bat"
    exit /b 1
)

echo [5/5] Building assetripper-gui-web.exe (includes Flask templates/static)...
pyinstaller --noconfirm --onefile --name assetripper-gui-web ^
    --paths src ^
    --collect-data assetripper_gui_web ^
    src\assetripper_gui_web\__main__.py
if errorlevel 1 (
    echo [ERROR] PyInstaller build failed for assetripper-gui-web.
    call ".venv-build\Scripts\deactivate.bat"
    exit /b 1
)

call ".venv-build\Scripts\deactivate.bat"

echo.
echo ============================================================================
echo  Build complete:
echo      dist\assetripper-inspect.exe
echo      dist\assetripper-gui-web.exe
echo.
echo  Both are standalone -- they can be copied and run on another Windows
echo  machine without Python installed. Build artifacts (.venv-build, build\,
echo  *.spec) can be deleted; only the dist\ folder is needed afterward.
echo ============================================================================

endlocal
