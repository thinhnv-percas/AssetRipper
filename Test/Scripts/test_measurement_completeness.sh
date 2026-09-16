#!/usr/bin/env bash
# Prove a measurement refuses to report from a rip that is still being written.
#
#   Test/Scripts/test_measurement_completeness.sh
#
# Iteration 050 measured a rip mid-export - a watch fired on a line in the log rather than on the
# process exiting - and reported 280 .cs files against 819 and 1845 methods against 5482. That reads
# as the worst regression in the project's history and is a snapshot of a directory being filled in.
# The distinction a measurement has to keep is between "this rip is small" and "this rip is not
# finished", and no count can tell them apart: only the log can. Each case below goes red if that
# distinction breaks again. Nothing here needs a game or a rip - the inputs are two files and a log.

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

# A rip of one method, small but complete. Written once and measured against three different logs, so
# that what changes between the cases is only whether the run had finished.
mkdir -p "$work/rip/Game/Assets/Scripts/Assembly-CSharp"
cat > "$work/rip/Game/Assets/Scripts/Assembly-CSharp/Probe.cs" <<'CS'
public class Probe
{
	[Address(RVA = "0x100", Offset = "0x100", Length = "0x10")]
	[NativeSource(Body = "\treturn;\n")]
	public void Run()
	{
	}
}
CS

attempted='Import : Il2Cpp script recovery: 1 of 1 assemblies will be attempted. Attempted: Assembly-CSharp'

# The log of a run that finished.
{
    echo "$attempted"
    echo "Export : Finished post-export"
    echo "Export : Ripped to $work/rip"
} > "$work/complete.log"

# The same run, caught part way: the assembly list is already printed, the export is not done. This
# is exactly the state iteration 050 measured in.
echo "$attempted" > "$work/partial.log"

status_of() {
    python3 "$here/recovery_metrics.py" "$work/rip" --log "$1" 2>&1 | head -1 | cut -d' ' -f2
}

exit_of() {
    python3 "$here/recovery_metrics.py" "$work/rip" --log "$1" > /dev/null 2>&1
    echo $?
}

# A - the finished run measures, and says which assemblies it covered.
check "A  a finished run is measured"                "the"                    "$(status_of "$work/complete.log")"
check "A2 and reports success"                       "0"                      "$(exit_of "$work/complete.log")"

# B - the same directory, measured against the log of a run that had not finished. The rip on disk is
# identical, so nothing about the files can produce this answer: only the log can.
check "B  an unfinished run is refused"              "INCOMPLETE"             "$(status_of "$work/partial.log")"
check "B2 and is a failure, not a quiet zero"        "2"                      "$(exit_of "$work/partial.log")"

# C - no log at all is not the same as an unfinished one. A measurement with nothing to check against
# says so and goes on, because refusing here would refuse every ad-hoc measurement.
check "C  no log is UNKNOWN rather than INCOMPLETE"  "UNKNOWN"                "$(python3 "$here/recovery_metrics.py" "$work/rip" 2>&1 | head -1 | cut -d' ' -f2)"

# D - a log naming a file that is not there is not an unfinished run either; it is a missing log, and
# saying "incomplete" would send a reader looking at a process that already exited.
check "D  a missing log is UNKNOWN"                  "UNKNOWN"                "$(status_of "$work/absent.log")"

# E - either completion marker is enough on its own. The exporter writes both, and a run cut off
# between them has still written its files.
echo "$attempted" > "$work/finished-only.log"
echo "Export : Finished post-export" >> "$work/finished-only.log"
check "E  the post-export marker alone is enough"    "the"                    "$(status_of "$work/finished-only.log")"

# F - the other measure that takes a log makes the same refusal. Iteration 050's misreading was of a
# file count, so the placeholder measure has to hold the line too or the same number comes back under
# another name.
families_status() {
    python3 "$here/placeholder_families.py" "$work/rip" --log "$1" 2>&1 | head -1 | cut -d' ' -f2
}

check "F  the placeholder measure refuses too"       "INCOMPLETE"             "$(families_status "$work/partial.log")"
check "F2 and measures a finished run"               "the"                    "$(families_status "$work/complete.log")"

# G - the two measures agree on what finished means, which is the point of there being one definition
# of it rather than two.
check "G  both measures agree on a finished run"     "same"                   "$([ "$(status_of "$work/complete.log")" = "$(families_status "$work/complete.log")" ] && echo same || echo different)"

echo
echo "$passes passed, $failures failed"
[ "$failures" -eq 0 ]
