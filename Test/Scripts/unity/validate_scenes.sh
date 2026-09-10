#!/usr/bin/env bash
# U4: open every scene in the build settings. Needs the editor script below to be present in the
# project, which install_editor_harness.sh puts there.
. "$(dirname "$0")/_common.sh"
require_project "${1:-}"
require_unity

"$(dirname "$0")/install_editor_harness.sh" "$project" || exit $?

log=${LOG:-$project/../unity-scenes.log}
run_editor "$log" -quit -executeMethod AssetRipperValidation.Harness.ValidateScenes
status=$?

echo "editor exit $status, log $log"
grep -E 'VALIDATION' "$log" || true
exit $status
