@echo off
setlocal enabledelayedexpansion

REM ============================================================================
REM  run_gui.bat
REM
REM  Sets up a virtual environment (if needed), installs the Python port of
REM  AssetRipper, and launches the Flask GUI (assetripper-gui-web) in your
REM  default browser.
REM
REM  Run this script FROM WINDOWS, from the `python\` directory of this repo
REM  (the same directory as pyproject.toml), with Python 3.11+ installed and
REM  on PATH.
REM
REM  Usage:
REM      run_gui.bat            (uses port 5000)
REM      run_gui.bat 8080       (uses a custom port)
REM ============================================================================

set "PORT=%~1"
if "%PORT%"=="" set "PORT=5000"

if not exist "pyproject.toml" (
    echo [ERROR] pyproject.toml not found in the current directory.
    echo         Run this script from the "python" folder of the AssetRipper repo.
    exit /b 1
)

echo [1/3] Checking for Python...
where python >nul 2>nul
if errorlevel 1 (
    echo [ERROR] Python was not found on PATH.
    echo         Install Python 3.11+ from https://www.python.org/downloads/
    echo         and make sure "Add python.exe to PATH" is checked during setup.
    exit /b 1
)

if not exist ".venv-gui\Scripts\python.exe" (
    echo [2/3] Creating virtual environment ^(.venv-gui^) and installing the package...
    python -m venv .venv-gui
    if errorlevel 1 (
        echo [ERROR] Failed to create the virtual environment.
        exit /b 1
    )
    call ".venv-gui\Scripts\activate.bat"
    python -m pip install --upgrade pip >nul
    python -m pip install -e .
    if errorlevel 1 (
        echo [ERROR] Failed to install dependencies.
        call ".venv-gui\Scripts\deactivate.bat"
        exit /b 1
    )
) else (
    echo [2/3] Reusing existing virtual environment ^(.venv-gui^)...
    call ".venv-gui\Scripts\activate.bat"
    REM Keep it in sync in case the source changed since the last run.
    python -m pip install --quiet -e .
)

echo [3/3] Starting the GUI on http://127.0.0.1:%PORT% ...
start "" "http://127.0.0.1:%PORT%"
python -m assetripper_gui_web %PORT%

call ".venv-gui\Scripts\deactivate.bat"
endlocal
