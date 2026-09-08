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

csc=$(find "${DOTNET_ROOT:-$HOME/.dotnet}" -name csc.dll -path '*Roslyn*' 2>/dev/null | sort | tail -1)

if [ -z "$csc" ]; then
    echo "no Roslyn csc.dll under the .NET SDK" >&2
    exit 2
fi

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
dotnet "$csc" -nostdlib -noconfig -nologo -target:library -unsafe+ -langversion:9 \
    -out:"$work/out.dll" $references $analyzers "@$work/sources.rsp" > "$work/log.txt" 2>&1

files=$(($(wc -l < "$work/sources.rsp") - 1))
errors=$(grep -c ': error ' "$work/log.txt")
warnings=$(grep -c ': warning ' "$work/log.txt")

echo "$assembly: $files files, $errors errors, $warnings warnings"
echo

grep -oE ': error CS[0-9]+' "$work/log.txt" | sort | uniq -c | sort -rn | while read -r count code; do
    example=$(grep -m1 "${code#: }" "$work/log.txt" | sed 's/.*error CS[0-9]*: //')
    printf '%6d  %-8s %s\n' "$count" "${code##*error }" "$example"
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

if [ -n "${KEEP_LOG:-}" ]; then
    cp "$work/log.txt" "$KEEP_LOG"
    echo
    echo "full log: $KEEP_LOG"
fi

[ "$errors" -eq 0 ]
