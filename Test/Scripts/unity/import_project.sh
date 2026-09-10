#!/usr/bin/env bash
# U1: import the generated project, which is what builds Library/ from Assets/.
. "$(dirname "$0")/_common.sh"
require_project "${1:-}"
require_unity

log=${LOG:-$project/../unity-import.log}
version=$(expected_version)
[ -n "$version" ] && echo "project declares Unity $version; running $UNITY"

run_editor "$log" -quit
status=$?

echo "editor exit $status, log $log"
[ -d "$project/Library" ] || { echo "no Library/ was produced" >&2; exit 1; }
exit $status
