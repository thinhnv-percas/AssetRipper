#!/usr/bin/env bash
# Compile a game's recovered scripts and report the errors by kind.
#
# The rip output ships the recovered and stubbed assemblies beside the scripts, so the exported C#
# can be compiled against exactly the metadata it was recovered from. That is the only measurement
# of the recovery that cannot be argued with: a grep guesses at what will not compile, a compiler
# knows. Against the *real* Unity assemblies it would need Unity, and would be stricter still.
#
#   Test/Scripts/compile_recovered_scripts.sh <rip output> [assembly name]
#
# e.g. Test/Scripts/compile_recovered_scripts.sh Test/Output Assembly-CSharp
#
# Framework assemblies are stubbed by design, so a member the recovery names on one of them will not
# exist here even though it exists at runtime - `List<T>._size` and the rest of what il2cpp inlined.
# Those errors are real for anyone compiling the export, which is the point of counting them.

set -u

output=${1:-Test/Output}
assembly=${2:-Assembly-CSharp}

assemblies=$(find "$output" -type d -name GameAssemblies | head -1)
scripts=$(find "$output" -type d -path "*/Scripts/$assembly" | head -1)

if [ -z "$assemblies" ] || [ -z "$scripts" ]; then
    echo "no GameAssemblies or Scripts/$assembly under $output" >&2
    exit 2
fi

# Finding the compiler is its own small problem, and getting it wrong is silent: this used to search
# `${DOTNET_ROOT:-$HOME/.dotnet}`, and in a container where the SDK is installed for one user and the
# harness runs as another, $HOME points somewhere with no SDK in it. Three iterations recorded
# "Roslyn: NOT RUN" for that reason alone while a perfectly good csc.dll sat on the disk. Ask the CLI
# where its SDKs are rather than guessing from an environment variable.
csc=$(TOOLSET_DIR="${TOOLSET_DIR:-$(dirname "$0")/../../artifacts/roslyn}" bash "$(dirname "$0")/find_csc.sh")
status=$?

if [ $status -ne 0 ] || [ -z "$csc" ]; then
    echo "ROSLYN_STATUS: TOOLCHAIN_ERROR"
    echo "TOOLCHAIN_ERROR: no C# compiler available. $csc" >&2
    echo "  Nothing was measured. Do not record this as zero errors." >&2
    exit 3
fi

DOTNET=${DOTNET:-$(command -v dotnet || true)}
[ -n "$DOTNET" ] || DOTNET=$(dirname "$csc")/../../../../dotnet

work=$(mktemp -d)
trap 'rm -rf "$work"' EXIT

find "$scripts" -name '*.cs' > "$work/sources.rsp"

# A framework type IL2CPP stripped out of the build is absent from the stub, and where the export
# names one in an *attribute* the error is a declaration error - which stops Roslyn before it binds a
# single method body, so every body error in the assembly goes unreported and every analyzer that
# needs a semantic model stays silent. Pinata read as "3 errors" for exactly this reason. The types
# are few and known, so they are shimmed in source; where the game does have them, its own win and
# these become CS0436 warnings.
cat > "$work/shim.cs" <<'SHIM'
namespace System.Runtime.InteropServices
{
    internal enum LayoutKind { Sequential = 0, Explicit = 2, Auto = 3 }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal sealed class StructLayoutAttribute : Attribute
    {
        public LayoutKind Value;
        public int Size;
        public int Pack;
        public CharSet CharSet;
        public StructLayoutAttribute(LayoutKind layoutKind) => Value = layoutKind;
    }

    internal enum CharSet { None = 1, Ansi = 2, Unicode = 3, Auto = 4 }
}
SHIM
echo "$work/shim.cs" >> "$work/sources.rsp"

# The game's own mscorlib is among the references, so the SDK's must not be: -nostdlib -noconfig.
references=""
for dll in "$assemblies"/*.dll; do
    [ "$(basename "$dll")" = "$assembly.dll" ] && continue
    references="$references -reference:$dll"
done

# ANALYZERS=<dir or dll> also runs Roslyn analyzers over the scripts. Microsoft.Unity.Analyzers is
# the one worth running: its diagnostics are about Unity's own contract - a message with the wrong
# signature, a GetComponent for a type that is not a component - which is exactly the kind of thing a
# recovery gets wrong and a compiler does not mind. Get it with
#   curl -sSL -o a.nupkg https://www.nuget.org/api/v2/package/Microsoft.Unity.Analyzers && unzip a.nupkg
# and point ANALYZERS at analyzers/dotnet/cs.
analyzers=""
if [ -n "${ANALYZERS:-}" ]; then
    if [ -d "$ANALYZERS" ]; then
        for dll in "$ANALYZERS"/*.dll; do
            analyzers="$analyzers -analyzer:$dll"
        done
    else
        analyzers="-analyzer:$ANALYZERS"
    fi

    # Most of Microsoft.Unity.Analyzers' rules ship at Info severity, which the command line compiler
    # does not print at all - the first run of this looked like a clean sheet and was a silent one.
    # A global analyzer config raises them to warning so they are reported.
    {
        echo 'is_global = true'
        for i in $(seq -w 1 60); do
            echo "dotnet_diagnostic.UNT00$i.severity = warning"
        done
    } > "$work/analyzers.globalconfig"

    analyzers="$analyzers -analyzerconfig:$work/analyzers.globalconfig"
fi

# shellcheck disable=SC2086
"$DOTNET" "$csc" -nostdlib -noconfig -nologo -target:library -unsafe+ -langversion:9 \
    -out:"$work/out.dll" $references $analyzers "@$work/sources.rsp" > "$work/log.txt" 2>&1

files=$(($(wc -l < "$work/sources.rsp") - 1))
errors=$(grep -c ': error ' "$work/log.txt")
warnings=$(grep -c ': warning ' "$work/log.txt")

# The status is stated rather than implied. A run that did not happen and a run that found nothing
# both print "0 errors" otherwise, and three iterations recorded the first as if it were the second.
echo "ROSLYN_STATUS: AVAILABLE_AND_RUN"
echo "ROSLYN_COMPILER: $csc"
# Files, not errors, is what a compile pass rate is over: one file with a hundred errors and a
# hundred files with one are the same error count and completely different projects. Roslyn names the
# file of every diagnostic, so the distinct ones are countable without parsing anything else.
faulted=$(grep ': error ' "$work/log.txt" | grep -oE '^[^(]+\.cs' | sort -u | wc -l)

# AssetRipper: the raw diagnostics, where asked for. Clustering compile failures by root cause needs
# every line with its file, its line number and its message, and the harness has always deleted the
# only copy - so every previous attempt at that read a summary instead of the data.
if [ -n "${ERRORS_TO:-}" ]; then
    grep ': error ' "$work/log.txt" > "$ERRORS_TO" || true
fi

echo "$assembly: $files files, $errors errors, $warnings warnings"
echo "$assembly: $((files - faulted)) of $files files compile clean"
echo

# The message shown per code is the MOST COMMON one, with how many share it - not the first in the
# log. A `grep -m1` example beside a count of 1125 reads as 1125 of that message, and an iteration
# was planned on exactly that misreading: the code's dominant message was a different one entirely,
# and the family turned out to be 275 distinct type pairs rather than one.
grep -oE ': error CS[0-9]+' "$work/log.txt" | sort | uniq -c | sort -rn | while read -r count code; do
    bare="${code##*error }"
    top=$(grep ": error $bare: " "$work/log.txt" | sed "s/.*error $bare: //" | sort | uniq -c | sort -rn | head -1)
    share=$(echo "$top" | awk '{print $1}')
    example=$(echo "$top" | sed 's/^ *[0-9]* //')
    printf '%6d  %-8s [most common: %s of %s] %s\n' "$count" "$bare" "$share" "$count" "$example"
done

# Analyzer diagnostics are warnings among tens of thousands of compiler ones, so they get their own
# table. Anything that is not CS is an analyzer's.
if [ -n "$analyzers" ]; then
    echo
    grep -oE ': (warning|error) [A-Z]+[0-9]+' "$work/log.txt" | grep -vE ' CS[0-9]+$' \
        | sed 's/.* //' | sort | uniq -c | sort -rn | while read -r count code; do
        example=$(grep -m1 "$code:" "$work/log.txt" | sed "s/.*$code: //")
        printf '%6d  %-8s %s\n' "$count" "$code" "$example"
    done
fi

# An error count is a measurement of the recovery only once the errors are known to be the
# recovery's. A missing reference assembly produces the same CS0246 an invented name does.
classifier=$(dirname "$0")/classify_compile_errors.py
if command -v python3 > /dev/null 2>&1 && [ -f "$classifier" ] && [ "$errors" -gt 0 ]; then
    echo
    python3 "$classifier" "$work/log.txt" "$scripts" "$assemblies" ${CLASSIFY_JSON:+--json "$CLASSIFY_JSON"}
fi

if [ -n "${KEEP_LOG:-}" ]; then
    cp "$work/log.txt" "$KEEP_LOG"
    echo
    echo "full log: $KEEP_LOG"
fi

[ "$errors" -eq 0 ]
