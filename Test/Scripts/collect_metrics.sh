#!/usr/bin/env bash
# Collect one iteration's measurements into a comparable report.
#
#   Test/Scripts/collect_metrics.sh <iteration directory>
#
# Reads the iteration's rip output and log and writes reports/metrics.json beside them. Every number
# is counted from the artifact that actually ran, so two iterations can be diffed field by field.
# A metric that counts what could not be recovered goes *up* when something previously discarded in
# silence starts being kept, so read the whole table rather than one line of it.

set -u

iteration=${1:?usage: collect_metrics.sh <iteration directory>}
output="$iteration/output"
log="$iteration/logs/AssetRipper.log"
report="$iteration/reports/metrics.json"

[ -d "$output" ] || { echo "no output under $iteration" >&2; exit 2; }
[ -f "$log" ] || { echo "no log at $log" >&2; exit 2; }

mkdir -p "$(dirname "$report")"

count_in_scripts() { grep -rho "$1" --include=*.cs "$output" 2>/dev/null | wc -l; }
count_in_log()     { grep -c "$1" "$log" 2>/dev/null || true; }

files=$(find "$output" -name '*.cs' | wc -l)
generator_failures=$(count_in_log 'Cpp2IL \[Error\] : Decompiling')
abandoned=$(count_in_log 'was abandoned part way through')

method_not_found=$(count_in_scripts 'Method not found @')
unmanaged_load=$(count_in_scripts 'Unmanaged memory load: ')
runtime_handle=$(count_in_scripts 'Il2Cpp runtime handle: ')
not_implemented=$(count_in_scripts 'Not implemented instruction: ')
unknown_call=$(count_in_scripts 'Unknown call target operand: ')
unresolved_delegate=$(count_in_scripts 'Delegate over an unresolved function pointer: ')
stack_shift=$(count_in_scripts 'Stack shift: ')
unresolved_branch=$(count_in_scripts 'Unable to resolve branch target')
ctor_on_instance=$(count_in_scripts '\._002Ector(')

loads_given_up=$(grep -oE '[0-9]+ memory loads the generator gave up on' "$log" | grep -oE '^[0-9]+' | tail -1)
untyped_locals=$(grep -oE '[0-9]+ locals the analysis could not type' "$log" | grep -oE '^[0-9]+' | tail -1)
aggregates=$(grep -oE '[0-9]+ call arguments the ABI spread' "$log" | grep -oE '^[0-9]+' | tail -1)
widened=$(grep -oE '[0-9]+ members of a game assembly were widened' "$log" | grep -oE '^[0-9]+' | tail -1)
accessor_pairings=$(grep -oE '[0-9]+ reads of a hidden static field' "$log" | grep -oE '^[0-9]+' | tail -1)

# Runtime-struct reads the generator gave up on. Each is a pattern il2cpp inlined that a recovery
# pass is meant to fold back, so the count is how much of that machinery is still leaking into the
# output - and none of it shows in an Assembly-CSharp measurement, because most of it is elsewhere.
load_kind() { grep -oE "[0-9]+ Il2CppClass\.$1" "$log" | grep -oE '^[0-9]+' | tail -1; }
type_hierarchy_depth=$(load_kind 'typeHierarchyDepth')
interface_offsets=$(load_kind 'interface_offsets_count')

seconds=$(grep -oE 'SECONDS=[0-9]+' "$iteration/logs/run-result.txt" 2>/dev/null | grep -oE '[0-9]+' | tail -1)

cat > "$report" <<JSON
{
  "iteration": "$(basename "$iteration")",
  "commit": "$(cat "$iteration/source-commit.txt" 2>/dev/null || echo unknown)",
  "runSeconds": ${seconds:-null},
  "csFiles": $files,
  "generatorFailures": ${generator_failures:-0},
  "assembliesAbandoned": ${abandoned:-0},
  "placeholders": {
    "methodNotFound": $method_not_found,
    "unmanagedMemoryLoad": $unmanaged_load,
    "il2CppRuntimeHandle": $runtime_handle,
    "notImplementedInstruction": $not_implemented,
    "unknownCallTarget": $unknown_call,
    "unresolvedDelegate": $unresolved_delegate,
    "stackShift": $stack_shift,
    "unresolvedBranchTarget": $unresolved_branch
  },
  "knownBadShapes": {
    "constructorCalledOnInstance": $ctor_on_instance
  },
  "analysis": {
    "loadsGivenUpOn": ${loads_given_up:-null},
    "untypedLocals": ${untyped_locals:-null},
    "aggregateArgumentsComposed": ${aggregates:-null},
    "membersWidened": ${widened:-null},
    "staticAccessorPairings": ${accessor_pairings:-null},
    "typeHierarchyDepthLoads": ${type_hierarchy_depth:-null},
    "interfaceOffsetCountLoads": ${interface_offsets:-null}
  }
}
JSON

cat "$report"
