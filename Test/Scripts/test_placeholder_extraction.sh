#!/usr/bin/env bash
# Prove a placeholder is counted whichever call shape carries it into the exported source.
#
#   Test/Scripts/test_placeholder_extraction.sh
#
# A placeholder used to reach the source one way, as NoteDecompilerIssue("message"). Iteration 052
# added a second, Il2CppRuntime.Boundary("KIND", "message"), so that a native boundary says what kind
# of boundary it is instead of only printing prose. The extractor read only the first, and the moment
# the generator started using the second, three whole families - METHOD_NOT_FOUND, NATIVE_IMPORT,
# UNKNOWN_CALL_TARGET - read as zero. That is indistinguishable from having fixed them, which is the
# most expensive way a measurement can be wrong. Each case below goes red if the second shape stops
# being read, or if reading it ever double counts.

set -u

here=$(cd "$(dirname "$0")" && pwd)
work=$(mktemp -d)
trap 'rm -rf "$work"' EXIT

passes=0
failures=0

check() {
    local name=$1 expected=$2 actual=$3
    if [ "$expected" = "$actual" ]; then
        printf 'PASS  %s\n' "$name"
        passes=$((passes + 1))
    else
        printf 'FAIL  %s\n        expected: %s\n        actual:   %s\n' "$name" "$expected" "$actual"
        failures=$((failures + 1))
    fi
}

mkdir -p "$work/rip/Game/Assets/Scripts/Assembly-CSharp"
cat > "$work/rip/Game/Assets/Scripts/Assembly-CSharp/Probe.cs" <<'CS'
public class Probe
{
	[Address(RVA = "0x100", Offset = "0x100", Length = "0x10")]
	[NativeSource(Body = "\tv1 = 0xB349B4(this);\n\treturn;\n")]
	public void Old()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X0+10]");
	}

	[Address(RVA = "0x200", Offset = "0x200", Length = "0x10")]
	[NativeSource(Body = "\tv1 = 0xB349B4(this);\n\treturn;\n")]
	public void New()
	{
		Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854E70");
		Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: v7 @ X8");
	}
}
CS

{
    echo 'Import : Il2Cpp script recovery: 1 of 1 assemblies will be attempted. Attempted: Assembly-CSharp'
    echo 'Export : Ripped to somewhere'
} > "$work/run.log"

count_of() {
    python3 "$here/placeholder_families.py" "$work/rip" --log "$work/run.log" 2>/dev/null \
        | awk -v family="$1" '$1 == family { print $2; exit }'
}

total() {
    python3 "$here/placeholder_families.py" "$work/rip" --log "$work/run.log" 2>/dev/null \
        | awk '/^placeholders:/ { print $2; exit }'
}

# A - the old shape still counts, which is what keeps every number before this change comparable.
check "A  the diagnostic shape is counted"            "1" "$(count_of UNMANAGED_MEMORY_LOAD)"

# B - the new shape counts too, and by the message rather than by the kind: the kind classifies the
# boundary, the message is what names the family, and reading the wrong argument silently renames
# every family at once.
check "B  the boundary shape is counted"              "3" "$(count_of METHOD_NOT_FOUND)"
check "B2 and by its message, not its kind"           "1" "$(count_of UNKNOWN_CALL_TARGET)"

# C - five placeholders across two shapes, counted once each. A regex that matched both arguments of
# the boundary call would report ten and look like a regression in the thing being measured.
check "C  neither shape is counted twice"             "5" "$(total)"

# D - the authoritative measure agrees. The two scripts share one definition of what a placeholder is
# precisely so they cannot drift, and this is the case that says the sharing still holds.
check "D  the semantic measure sees the same count"   "5" "$(python3 "$here/recovery_metrics.py" "$work/rip" --log "$work/run.log" 2>/dev/null | awk '/^placeholders:/ { print $2; exit }')"

echo
echo "$passes passed, $failures failed"
[ "$failures" -eq 0 ]
