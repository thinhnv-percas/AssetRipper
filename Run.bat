@echo off
setlocal

:: Launches the AssetRipper GUI directly from source.
:: `dotnet run` builds the project automatically if it isn't built yet,
:: so there is no need to run `dotnet build` beforehand.
::
:: Any arguments passed to this script (e.g. --port 1234, --headless)
:: are forwarded to AssetRipper itself.

cd /d "%~dp0Source\AssetRipper.GUI.Free"

echo Starting AssetRipper GUI...
dotnet run -c Release -- %*

if errorlevel 1 (
	echo.
	echo AssetRipper exited with an error. See the output above for details.
	pause
)

endlocal
