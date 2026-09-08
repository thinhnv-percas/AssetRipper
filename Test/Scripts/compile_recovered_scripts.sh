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

# The game's own mscorlib is among the references, so the SDK's must not be: -nostdlib -noconfig.
references=""
for dll in "$assemblies"/*.dll; do
    [ "$(basename "$dll")" = "$assembly.dll" ] && continue
    references="$references -reference:$dll"
done

# shellcheck disable=SC2086
dotnet "$csc" -nostdlib -noconfig -nologo -target:library -unsafe+ -langversion:9 \
    -out:"$work/out.dll" $references "@$work/sources.rsp" > "$work/log.txt" 2>&1

files=$(wc -l < "$work/sources.rsp")
errors=$(grep -c ': error ' "$work/log.txt")
warnings=$(grep -c ': warning ' "$work/log.txt")

echo "$assembly: $files files, $errors errors, $warnings warnings"
echo

grep -oE ': error CS[0-9]+' "$work/log.txt" | sort | uniq -c | sort -rn | while read -r count code; do
    example=$(grep -m1 "${code#: }" "$work/log.txt" | sed 's/.*error CS[0-9]*: //')
    printf '%6d  %-8s %s\n' "$count" "${code##*error }" "$example"
done

if [ -n "${KEEP_LOG:-}" ]; then
    cp "$work/log.txt" "$KEEP_LOG"
    echo
    echo "full log: $KEEP_LOG"
fi

[ "$errors" -eq 0 ]
