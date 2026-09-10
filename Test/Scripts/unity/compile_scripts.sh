#!/usr/bin/env bash
# U2: compile the exported scripts with Unity, which is authoritative where the Roslyn harness is not:
# it builds against the real UnityEngine assemblies rather than the stubs the rip ships.
. "$(dirname "$0")/_common.sh"
require_project "${1:-}"
require_unity

log=${LOG:-$project/../unity-compile.log}

run_editor "$log" -quit
status=$?

errors=$(report_editor_errors "$log")
echo "editor exit $status, $errors compiler errors, log $log"

if [ -f "$project/Library/ScriptAssemblies/Assembly-CSharp.dll" ]; then
    echo "Assembly-CSharp.dll produced"
else
    echo "Assembly-CSharp.dll was NOT produced" >&2
    exit 1
fi

grep -E 'error CS[0-9]+' "$log" | sed 's/.*error /error /' | sort | uniq -c | sort -rn | head -20
[ "${errors:-1}" -eq 0 ]
