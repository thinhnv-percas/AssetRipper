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

output=${1:?usage: check_recovered_shapes.sh <rip output> [run log]}
log=${2:-$output/../logs/AssetRipper.log}
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

# DECOMP-0007: il2cpp shares one generic body across instantiations, so a call names whichever one
# the address was attributed to - `Dictionary<Int32Enum, object>` for any int-backed enum key. The
# receiver's own type says which instantiation it really is, and here it comes straight from the
# field's declared type.
check DECOMP-0007 ResourcesUtil.cs 'resourceDict.ContainsKey(statType)' 'Dictionary<System.Int32Enum, object>'

# DECOMP-0009: an address the machine computed before the load - `Add v73, this, 88` and then
# `Move v104, [v73]` - left the base untyped, so the load did not resolve, nor did the load off what
# it produced. `GamePlayController.RewindPlay` came out as `(nint)this + 88` and
# `((GameObject)0).SetActive(false)` for what the source writes as one field access.
check DECOMP-0009 GamePlayController.cs 'SetActive' '(GameObject)0'

# DECOMP-0010: a runtime class carries the type it is the class of, and the case that emitted a zero
# for one sat ahead of the cases that know how to answer, so `Type.GetTypeFromHandle(typeof(T))` came
# out as `Type.GetTypeFromHandle((RuntimeTypeHandle)0)`.
# ILSpy folds `ldtoken T; call GetTypeFromHandle` back into `typeof(T)`, which is what the source says.
check DECOMP-0010 CSVSerializer.cs 'Type typeFromHandle = typeof(T);' '(RuntimeTypeHandle)0'

# DECOMP-0012: shared generic code carries no instantiation, so an RGCTX slot read off the open
# definition resolved with no type arguments and failed - taking the class-init guard and the static
# field storage down with it. `SingletonMono<T>.Instance` was placeholders end to end.
check DECOMP-0012 SingletonMono.cs 'Monitor.Enter(syncRoot' 'Rgctx<SingletonMono`1>)+'

# DECOMP-0008: the computed field layout has to reproduce every offset metadata carries. It is used
# where metadata has none - a generic definition's offsets are all zero - so this is the only exact
# check on it there is, and a layout that is off by a field does not fail, it names the wrong field.
if [ -f "$log" ]; then
    selfcheck=$(grep -o 'field layout self-check: .*' "$log" | tail -1)
    if [ -z "$selfcheck" ]; then
        printf 'FAIL  %-12s the run log has no field layout self-check\n' DECOMP-0008
        failures=$((failures + 1))
    elif echo "$selfcheck" | grep -q ', 0 disagreed'; then
        printf 'PASS  %-12s %s\n' DECOMP-0008 "$selfcheck"
    else
        printf 'FAIL  %-12s %s\n' DECOMP-0008 "$selfcheck"
        failures=$((failures + 1))
    fi
else
    printf 'SKIP  %-12s no run log at %s\n' DECOMP-0008 "$log"
fi

echo
if [ "$failures" -eq 0 ]; then
    echo "all shape checks passed"
else
    echo "$failures shape check(s) failed"
fi

[ "$failures" -eq 0 ]
