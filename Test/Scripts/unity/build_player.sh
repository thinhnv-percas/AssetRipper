#!/usr/bin/env bash
# U7: build a player. Needs an Android SDK and NDK for this project's target.
. "$(dirname "$0")/_common.sh"
require_project "${1:-}"
require_unity

"$(dirname "$0")/install_editor_harness.sh" "$project" || exit $?

log=${LOG:-$project/../unity-build.log}
run_editor "$log" -quit -executeMethod AssetRipperValidation.Harness.BuildPlayer
status=$?

echo "editor exit $status, log $log"
grep -E 'VALIDATION|BuildResult' "$log" || true
exit $status
