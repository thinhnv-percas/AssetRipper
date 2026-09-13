#!/usr/bin/env bash
# Prove the Roslyn harness bootstraps, and that it says so honestly when it cannot.
#
#   Test/Scripts/test_roslyn_bootstrap.sh
#
# Three iterations recorded "Roslyn: NOT RUN" while a perfectly good csc.dll sat on the disk, because
# discovery searched $HOME and the harness had no way to tell "no compiler" from "no errors". Each
# case below is written so that it goes red if that distinction breaks again. Nothing here needs a rip
# or a game: the compiler inputs are two source files written on the spot.

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

dotnet_cli=${DOTNET:-$(command -v dotnet || true)}
if [ -z "$dotnet_cli" ]; then
    for candidate in "${DOTNET_ROOT:-}/dotnet" "$HOME/.dotnet/dotnet" /usr/share/dotnet/dotnet /home/*/.dotnet/dotnet; do
        [ -x "$candidate" ] && { dotnet_cli=$candidate; break; }
    done
fi

# A - the installed SDK is found, and found by asking the CLI rather than by guessing from $HOME.
# HOME is deliberately pointed somewhere empty: that is exactly the container this broke in. The other
# three tiers are shut off - no cached toolset, no network - so the only way to pass is the SDK tier.
# Without that the NuGet fallback answers and the case passes against the very bug it is here to
# catch, which is how it was first written.
found=$(HOME=$work TOOLSET_DIR=$work/unused NO_NETWORK=1 bash "$here/find_csc.sh" 2>/dev/null)
status=$?
check "A  SDK present: found from the SDK alone, with HOME pointing nowhere" \
    "0 exists" "$status $([ -n "$found" ] && [ -f "$found" ] && echo exists || echo missing)"

# B - with no SDK visible, discovery falls through to an unpacked Microsoft.Net.Compilers.Toolset.
# The layout is faked rather than downloaded so the case runs offline; what is under test is that the
# fallback tier is reached and used, not NuGet.
fake_sdk_root=$work/nosdk
mkdir -p "$fake_sdk_root"
cat > "$work/no-sdk-dotnet" <<DOTNET
#!/usr/bin/env bash
if [ "\${1:-}" = "--list-sdks" ]; then exit 0; fi
exec "$dotnet_cli" "\$@"
DOTNET
chmod +x "$work/no-sdk-dotnet"

toolset=$work/toolset
mkdir -p "$toolset/9.9.9/tasks/netcore/bincore"
if [ -n "$found" ] && [ -f "$found" ]; then
    cp "$(dirname "$found")"/* "$toolset/9.9.9/tasks/netcore/bincore/" 2>/dev/null
fi
fallback=$(DOTNET=$work/no-sdk-dotnet TOOLSET_DIR=$toolset TOOLSET_VERSION=9.9.9 NO_NETWORK=1 \
    bash "$here/find_csc.sh" 2>/dev/null)
check "B  no SDK: falls through to the unpacked toolset" \
    "$toolset/9.9.9/tasks/netcore/bincore/csc.dll" "$fallback"

# C - the same fall-through with the network refused, which is the offline/cached case. It must not
# reach for NuGet at all when the package is already unpacked.
cached=$(DOTNET=$work/no-sdk-dotnet TOOLSET_DIR=$toolset TOOLSET_VERSION=9.9.9 NO_NETWORK=1 \
    bash "$here/find_csc.sh" 2>/dev/null)
check "C  offline with the toolset cached: still resolves" \
    "$toolset/9.9.9/tasks/netcore/bincore/csc.dll" "$cached"

# D - nothing available anywhere. This must be a non-zero status and a reason, never a silent empty
# answer that a caller could read as success with no errors.
missing=$(DOTNET=$work/no-sdk-dotnet TOOLSET_DIR=$work/empty TOOLSET_VERSION=9.9.9 NO_NETWORK=1 \
    bash "$here/find_csc.sh" 2>/dev/null)
status=$?
check "D  nothing available: non-zero status with a reason" \
    "1 reason" "$status $([ -n "$missing" ] && echo reason || echo silent)"

# The remaining two run the compiler the harness found, on sources whose verdict is not in doubt.
run_csc() {
    "$dotnet_cli" "$found" -nologo -nostdlib -noconfig -target:library -out:"$work/out.dll" "$@" 2>&1
}

refs=""
for dll in "$(dirname "$(dirname "$(dirname "$found")")")"/../../packs/Microsoft.NETCore.App.Ref/*/ref/net*/System.Runtime.dll; do
    [ -f "$dll" ] && refs="-reference:$dll"
done
[ -n "$refs" ] || for dll in "$(dirname "$dotnet_cli")"/packs/Microsoft.NETCore.App.Ref/*/ref/net*/System.Runtime.dll; do
    [ -f "$dll" ] && refs="-reference:$dll"
done

# E - invalid C# must be reported as errors. A harness that cannot fail cannot measure anything.
cat > "$work/bad.cs" <<'BAD'
class Bad { void M() { int x = "not an int"; } }
BAD
# shellcheck disable=SC2086
bad_errors=$(run_csc $refs "$work/bad.cs" | grep -c ': error CS')
check "E  invalid C#: errors are reported" "yes" "$([ "$bad_errors" -gt 0 ] && echo yes || echo no)"

# F - valid C# must compile clean, so a non-zero count in a real run means the source and not the
# setup. The produced assembly is part of the assertion: "no errors were printed" is also what an
# absent compiler produces, and this case passed against a broken discovery until it checked.
cat > "$work/good.cs" <<'GOOD'
class Good { int M() { return 1; } }
GOOD
rm -f "$work/out.dll"
# shellcheck disable=SC2086
good_errors=$(run_csc $refs "$work/good.cs" | grep -c ': error CS')
check "F  valid C#: no errors, and an assembly was produced" \
    "0 built" "$good_errors $([ -f "$work/out.dll" ] && echo built || echo nothing)"

# G and H are about the classifier rather than the bootstrap, and they exist because an error count is
# only a measurement of the recovery once the errors are known to be the recovery's.
classifier=$here/classify_compile_errors.py
mkdir -p "$work/scripts" "$work/refs"
: > "$work/scripts/Ours.cs"

classify_count() {
    python3 "$classifier" "$1" "$work/scripts" "$2" 2>/dev/null         | awk -v want="$3" '$1 == want { print $2 }'
}

# G - with no reference assemblies at all, a lookup failure is the reference set's, not the export's.
cat > "$work/refs.log" <<'LOG'
/x/Foo.cs(1,1): error CS0246: The type or namespace name 'UnityEngine' could not be found (are you missing a using directive or an assembly reference?)
LOG
check "G  no references: a lookup failure is a REFERENCE_ERROR"     "1 0" "$(classify_count "$work/refs.log" "$work/refs" REFERENCE_ERROR) $(classify_count "$work/refs.log" "$work/refs" DECOMPILER_ERROR)"

# H - a name the decompiler invented cannot be supplied by any reference set, however incomplete. The
# type is deliberately one this export does not declare, so the mangled-name rule is the only thing
# that can produce the right answer: with a type of our own, the "it is ours" rule answers first and
# the case passes whether or not the rule under test is there at all.
cat > "$work/mangled.log" <<'LOG'
/x/Foo.cs(1,1): error CS0117: 'MonoBehaviour' does not contain a definition for '_002Ector'
LOG
check "H  a mangled identifier is a DECOMPILER_ERROR even with no references"     "1 0" "$(classify_count "$work/mangled.log" "$work/refs" DECOMPILER_ERROR) $(classify_count "$work/mangled.log" "$work/refs" REFERENCE_ERROR)"

echo
echo "$passes passed, $failures failed"
[ "$failures" -eq 0 ]
