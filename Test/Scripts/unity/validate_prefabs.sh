#!/usr/bin/env bash
# U5 and U6: load every prefab and every ScriptableObject asset, and report the ones whose script
# reference does not resolve.
. "$(dirname "$0")/_common.sh"
require_project "${1:-}"
require_unity

"$(dirname "$0")/install_editor_harness.sh" "$project" || exit $?

log=${LOG:-$project/../unity-prefabs.log}
run_editor "$log" -quit -executeMethod AssetRipperValidation.Harness.ValidateAssets
status=$?

echo "editor exit $status, log $log"
grep -E 'VALIDATION' "$log" || true
exit $status
