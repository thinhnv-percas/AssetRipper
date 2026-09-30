#!/usr/bin/env bash
# Iteration 063: was the JellyBlast IPA compiled from the pinned source? Per assembly, from declarations.
#
#   jellyblast_build_provenance.sh <rip output of Test/Input/JellyBlastV2> <jelly-blast checkout> <work dir>
#
# The build side is the metadata stubs the rip writes to AuxiliaryFiles/GameAssemblies. The source side is
# the checkout's Library/ScriptAssemblies (every package and asmdef assembly the editor compiled) plus
# Assembly-CSharp, which the checkout does not carry compiled: it is rebuilt here from its declaration
# surface (SourceDeclarationSurface strips bodies) against the source's own package assemblies and the
# build's engine stubs, with the preprocessor symbols of an iOS 2022.3 player.
set -euo pipefail
RIP=$(realpath "$1"); SRC=$(realpath "$2"); WORK=$(mkdir -p "$3" && realpath "$3")
HERE=$(cd "$(dirname "$0")" && pwd); ROOT=$(cd "$HERE/../.." && pwd)
DOTNET=${DOTNET:-$(command -v dotnet || echo "$HOME/.dotnet/dotnet")}
SDK=$("$DOTNET" --list-sdks | tail -1 | sed -E 's/^([^ ]+) \[(.*)\]$/\2\/\1/')
CSC="$SDK/Roslyn/bincore/csc.dll"
GAME="$RIP/AuxiliaryFiles/GameAssemblies"; LIB="$SRC/Library/ScriptAssemblies"
[ -d "$GAME" ] || { echo "no $GAME: not a rip output root" >&2; exit 2; }
[ -d "$LIB" ] || { echo "no $LIB: the checkout carries no compiled assemblies" >&2; exit 2; }
echo "source commit: $(git -C "$SRC" rev-parse HEAD)"
grep -q "$(git -C "$SRC" rev-parse HEAD)" "$ROOT/Test/fixtures/jellyblast-source-revision.txt" \
  || echo "WARNING: the checkout is not the pinned revision in Test/fixtures/jellyblast-source-revision.txt"

for tool in AssemblyFingerprint SourceDeclarationSurface; do
  "$DOTNET" build -c Release -v q "$ROOT/Test/Tools/$tool" >/dev/null
done
FP="$ROOT/Test/Tools/AssemblyFingerprint/bin/Release/net10.0/AssemblyFingerprint.dll"
SURFACE="$ROOT/Test/Tools/SourceDeclarationSurface/bin/Release/net10.0/SourceDeclarationSurface.dll"

# Assembly-CSharp: every script outside an asmdef, a Plugins folder or an Editor folder.
rm -rf "$WORK/src" "$WORK/surf"; mkdir -p "$WORK/src"
(cd "$SRC/Assets" && find . -name '*.cs' -not -path '*/Editor/*' -not -path './Plugins/*' \
    -not -path './Standard Assets/*' | while read -r f; do
  dir=$(dirname "$f"); owned=0
  while [ "$dir" != "." ]; do ls "$dir"/*.asmdef >/dev/null 2>&1 && { owned=1; break; }; dir=$(dirname "$dir"); done
  [ $owned = 0 ] && { mkdir -p "$WORK/src/$(dirname "$f")"; cp "$f" "$WORK/src/$f"; }
done)
DEFINES=$(python3 -c "
import sys, pathlib; sys.path.insert(0, '$HERE'); import source_preprocessor as sp
d = sp.defines_for('2022.3.53f1', 'ios'); d.update(sp.project_defines(pathlib.Path('$SRC'), 'ios'))
print(' '.join(sorted(k for k, v in d.items() if v is True)))")
"$DOTNET" "$SURFACE" "$WORK/src" "$WORK/surf" $DEFINES
# What the build's stripped UnityEngine no longer declares and the source still names: two attribute
# arguments and one constant's value. None of the three changes a declaration.
grep -rl 'CreateAssetMenu(' "$WORK/surf" | xargs -r sed -i -E 's/\[CreateAssetMenu\([^]]*\)\]/[CreateAssetMenu]/'
grep -rl 'Mathf\.PI' "$WORK/surf" | xargs -r sed -i 's/Mathf\.PI/3.14159274f/g'

: > "$WORK/refs.rsp"
for f in "$LIB"/*.dll; do n=$(basename "$f" .dll)
  case "$n" in *Editor*|*Tests*|*DocCodeSamples*|*CodeGen*|*BurstCompatibilityGen*|Assembly-CSharp*) continue;; esac
  echo "-r:$f" >> "$WORK/refs.rsp"; done
for f in "$GAME"/*.dll; do n=$(basename "$f" .dll)
  [ -e "$LIB/$n.dll" ] && continue
  case "$n" in Assembly-CSharp*|DOTween) continue;; esac
  echo "-r:$f" >> "$WORK/refs.rsp"; done
# Precompiled plugins a package ships (DOTween's runtime is a DLL in the package, not an asmdef).
find "$SRC/Library/PackageCache" "$SRC/Assets" -name '*.dll' -path '*Runtime*' -not -path '*Editor*' 2>/dev/null \
  | grep -i dotween | sed 's/^/-r:/' >> "$WORK/refs.rsp"

"$DOTNET" "$CSC" -nologo -noconfig -nostdlib -target:library -unsafe \
  -nowarn:0436,0618,0169,0414,0649,0162,0219,0067,1998 $(for d in $DEFINES; do printf -- '-define:%s ' "$d"; done) \
  -out:"$WORK/Assembly-CSharp.dll" @"$WORK/refs.rsp" $(find "$WORK/surf" -name '*.cs') > "$WORK/csc.log" 2>&1 \
  || { echo "Assembly-CSharp declaration surface did not compile:"; grep -c 'error CS' "$WORK/csc.log"; exit 1; }
[ -s "$WORK/Assembly-CSharp.dll" ] || { echo "no assembly written" >&2; exit 1; }

"$DOTNET" "$FP" "$GAME" > "$WORK/fp-build.tsv"
{ "$DOTNET" "$FP" "$LIB"; "$DOTNET" "$FP" "$WORK/Assembly-CSharp.dll"; } > "$WORK/fp-source.tsv"
python3 "$HERE/build_provenance.py" "$WORK/fp-build.tsv" "$WORK/fp-source.tsv" --json "$WORK/provenance.json" --examples 400
