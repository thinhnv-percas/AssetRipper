#!/usr/bin/env bash
# U3: refresh the asset database and report what it could not resolve.
. "$(dirname "$0")/_common.sh"
require_project "${1:-}"
require_unity

log=${LOG:-$project/../unity-refresh.log}

run_editor "$log" -quit -executeMethod UnityEditor.AssetDatabase.Refresh
status=$?

echo "editor exit $status, log $log"
grep -icE 'could not be loaded|missing|broken' "$log" || true
exit $status
