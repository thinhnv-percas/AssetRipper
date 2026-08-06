#!/usr/bin/env bash
# Sets up Ghidra for script content level 4 and launches AssetRipper with it.
#
# Ghidra is not bundled with AssetRipper. This downloads it into ./ghidra the
# first time, then reuses that installation on every later run.
#
# An existing installation is used instead if GHIDRA_INSTALL_DIR points at one.
#
# Any arguments are forwarded to AssetRipper.
#
# Ghidra requires a JDK 21 runtime.

set -euo pipefail

GHIDRA_VERSION="12.1.2"
GHIDRA_BUILD="20260605"
GHIDRA_ARCHIVE="ghidra_${GHIDRA_VERSION}_PUBLIC_${GHIDRA_BUILD}.zip"
GHIDRA_URL="https://github.com/NationalSecurityAgency/ghidra/releases/download/Ghidra_${GHIDRA_VERSION}_build/${GHIDRA_ARCHIVE}"

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
LOCAL_INSTALL="${ROOT}/ghidra"
DOWNLOAD_CACHE="${ROOT}/${GHIDRA_ARCHIVE}"

is_installation() {
	[ -n "${1:-}" ] && [ -f "${1}/support/analyzeHeadless" ]
}

if is_installation "${GHIDRA_INSTALL_DIR:-}"; then
	echo "Using the Ghidra installation from GHIDRA_INSTALL_DIR: ${GHIDRA_INSTALL_DIR}"
elif is_installation "${LOCAL_INSTALL}"; then
	echo "Using the Ghidra installation at ${LOCAL_INSTALL}"
	export GHIDRA_INSTALL_DIR="${LOCAL_INSTALL}"
else
	echo "Ghidra was not found. Downloading ${GHIDRA_VERSION} into ${LOCAL_INSTALL}"
	echo "This is a large download and only happens once."

	if [ ! -f "${DOWNLOAD_CACHE}" ]; then
		curl -sSL --fail -o "${DOWNLOAD_CACHE}" "${GHIDRA_URL}"
	else
		echo "Reusing the already downloaded ${GHIDRA_ARCHIVE}"
	fi

	EXTRACT_DIR="$(mktemp -d)"
	trap 'rm -rf "${EXTRACT_DIR}"' EXIT
	unzip -q "${DOWNLOAD_CACHE}" -d "${EXTRACT_DIR}"

	# The archive contains a single versioned directory.
	EXTRACTED="$(find "${EXTRACT_DIR}" -maxdepth 1 -mindepth 1 -type d | head -1)"
	if ! is_installation "${EXTRACTED}"; then
		echo "The downloaded archive did not contain a Ghidra installation." >&2
		exit 1
	fi

	rm -rf "${LOCAL_INSTALL}"
	mv "${EXTRACTED}" "${LOCAL_INSTALL}"
	chmod +x "${LOCAL_INSTALL}/support/analyzeHeadless"
	export GHIDRA_INSTALL_DIR="${LOCAL_INSTALL}"
	echo "Ghidra installed at ${LOCAL_INSTALL}"
fi

if ! command -v java >/dev/null 2>&1; then
	echo "Warning: java was not found on PATH. Ghidra needs a JDK 21 runtime." >&2
fi

echo
echo "Starting AssetRipper. Select script content level 4 in the settings to use Ghidra."
cd "${ROOT}/Source/AssetRipper.GUI.Free"
exec dotnet run -c Release -- "$@"
