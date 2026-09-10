#!/usr/bin/env bash
# The blocked suite, in dependency order. Stops at the first failure, because every later stage needs
# the earlier one. Exit 90 from any stage means the validation could not be performed at all - that is
# not a pass, and reports/BLOCKED_UNITY_TESTS.md says so.
set -u
project=${1:?usage: run_all.sh <unity project directory>}
here=$(dirname "$0")
out=${OUT:-$project/../unity-validation}
mkdir -p "$out"

for stage in import_project compile_scripts refresh_assets validate_scenes validate_prefabs build_player; do
    echo "=== $stage"
    LOG="$out/$stage.log" "$here/$stage.sh" "$project"
    status=$?
    if [ "$status" -eq 90 ]; then
        echo "BLOCKED at $stage - no Unity. Nothing above this line is a pass either." >&2
        exit 90
    fi
    if [ "$status" -ne 0 ]; then
        echo "FAILED at $stage (exit $status)" >&2
        exit "$status"
    fi
done

echo "all Unity stages completed; logs in $out"
