#!/usr/bin/env bash
# Golden checks on a rip's recovered scripts.
#
#   Test/Scripts/check_recovered_shapes.sh <rip output>
#
# Each check is a shape a confirmed defect produced, or the shape that replaced it. They are stated
# against the recovered text rather than against a count, so a check keeps meaning as the numbers
# around it move. A check that cannot find the file it is about FAILs rather than passing quietly -
# a body that stopped being exported is the failure the check exists to catch.

set -u

output=${1:?usage: check_recovered_shapes.sh <rip output>}
failures=0

find_script() {
    find "$output" -name "$1" -path '*/Scripts/*' 2>/dev/null | head -1
}

# $1 issue, $2 file, $3 must contain, $4 must not contain (optional)
check() {
    local issue=$1 name=$2 wanted=$3 unwanted=${4:-}
    local file
    file=$(find_script "$name")

    if [ -z "$file" ]; then
        printf 'FAIL  %-12s %s was not exported\n' "$issue" "$name"
        failures=$((failures + 1))
        return
    fi

    if ! grep -q -- "$wanted" "$file"; then
        printf 'FAIL  %-12s %s does not contain %s\n' "$issue" "$name" "$wanted"
        failures=$((failures + 1))
        return
    fi

    if [ -n "$unwanted" ] && grep -q -- "$unwanted" "$file"; then
        printf 'FAIL  %-12s %s still contains %s\n' "$issue" "$name" "$unwanted"
        failures=$((failures + 1))
        return
    fi

    printf 'PASS  %-12s %s\n' "$issue" "$name"
}

# DECOMP-0001: a branch over a dropped constructor call threw out of the whole body, and the body
# came back as a `throw new Exception(<the stack trace>)`.
check DECOMP-0001 TimeInGame.cs 'public int CompareTo' 'at Cpp2IL.Core.IlGenerator.GenerateIl'

# DECOMP-0002: il2cpp calls a value type's constructor on the address of the slot holding it, and
# dropping the call left the value zeroed - `return default(DateTime).CompareTo(value)`.
check DECOMP-0002 TimeInGame.cs 'new DateTime(' 'default(DateTime).CompareTo'

# DECOMP-0003: a helper handed a constructed exception was named after the first "...Exception"
# string its callee references, so the generic raiser read as the out-of-memory one and the exception
# the body had just built was left in a dead local beside the wrong throw.
check DECOMP-0003 Common.cs 'throw ex;' 'throw new OutOfMemoryException'

echo
if [ "$failures" -eq 0 ]; then
    echo "all shape checks passed"
else
    echo "$failures shape check(s) failed"
fi

[ "$failures" -eq 0 ]
