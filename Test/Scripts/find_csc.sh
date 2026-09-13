#!/usr/bin/env bash
# Print the path of a usable Roslyn csc.dll, or a reason on stdout and a non-zero status.
#
# Order, most local first:
#   1. CSC_DLL, when a caller already knows
#   2. the installed .NET SDK, located by asking the CLI rather than by guessing from $HOME
#   3. a Microsoft.Net.Compilers.Toolset already unpacked under TOOLSET_DIR
#   4. that package fetched from NuGet at the pinned version, when the network allows
#
# Nothing here writes into the repository. Microsoft.Net.Compilers.Toolset is the supported package;
# Microsoft.Net.Compilers is deprecated and is not used.

set -u

# Pinned deliberately: a compiler that changes under a measurement makes the measurement
# incomparable with the iteration before it. Raise this on purpose, never implicitly.
TOOLSET_VERSION=${TOOLSET_VERSION:-4.14.0}
TOOLSET_DIR=${TOOLSET_DIR:-artifacts/roslyn}

usable() {
    [ -f "$1" ] || return 1
    local runner=${DOTNET:-$(command -v dotnet || true)}
    [ -n "$runner" ] || return 1
    # A compiler that cannot start on this runtime is not a compiler we have.
    "$runner" "$1" -version > /dev/null 2>&1
}

if [ -n "${CSC_DLL:-}" ] && usable "$CSC_DLL"; then
    echo "$CSC_DLL"
    exit 0
fi

dotnet_cli=${DOTNET:-$(command -v dotnet || true)}

# The CLI may not be on PATH even where it is installed, so look in the usual places before giving up.
if [ -z "$dotnet_cli" ]; then
    for candidate in "${DOTNET_ROOT:-}/dotnet" "$HOME/.dotnet/dotnet" /usr/share/dotnet/dotnet /usr/local/share/dotnet/dotnet /home/*/.dotnet/dotnet; do
        [ -x "$candidate" ] && { dotnet_cli=$candidate; break; }
    done
fi

if [ -n "$dotnet_cli" ]; then
    # `dotnet --list-sdks` prints "<version> [<directory>]"; the newest last.
    while read -r line; do
        dir=${line##*[}
        dir=${dir%]}
        version=${line%% *}
        candidate="$dir/$version/Roslyn/bincore/csc.dll"
        [ -f "$candidate" ] && newest=$candidate
    done < <("$dotnet_cli" --list-sdks 2>/dev/null)

    if [ -n "${newest:-}" ] && DOTNET=$dotnet_cli usable "$newest"; then
        echo "$newest"
        exit 0
    fi
fi

unpacked="$TOOLSET_DIR/$TOOLSET_VERSION/tasks/netcore/bincore/csc.dll"

if DOTNET=${dotnet_cli:-} usable "$unpacked"; then
    echo "$unpacked"
    exit 0
fi

if [ -n "${NO_NETWORK:-}" ]; then
    echo "no SDK compiler, and $unpacked is not unpacked (network fetch disabled)"
    exit 1
fi

mkdir -p "$TOOLSET_DIR/$TOOLSET_VERSION" || { echo "cannot create $TOOLSET_DIR"; exit 1; }
package="$TOOLSET_DIR/toolset-$TOOLSET_VERSION.nupkg"

if [ ! -f "$package" ]; then
    url="https://www.nuget.org/api/v2/package/Microsoft.Net.Compilers.Toolset/$TOOLSET_VERSION"
    curl -sSL --fail -o "$package" "$url" 2>/dev/null || { rm -f "$package"; echo "could not fetch Microsoft.Net.Compilers.Toolset $TOOLSET_VERSION from NuGet"; exit 1; }
fi

unzip -qo "$package" -d "$TOOLSET_DIR/$TOOLSET_VERSION" 2>/dev/null || { echo "could not unpack $package"; exit 1; }

if DOTNET=${dotnet_cli:-} usable "$unpacked"; then
    echo "$unpacked"
    exit 0
fi

echo "Microsoft.Net.Compilers.Toolset $TOOLSET_VERSION unpacked but its csc.dll does not run on this runtime"
exit 1
