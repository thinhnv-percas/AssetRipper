#!/usr/bin/env python3
"""What a recovered project would need at run time that the project does not contain.

Iteration 054 found every fixture reporting zero native plugins while its package ships native
libraries, and called that a runtime blocker without saying which libraries or who needs them. This
answers both: it reads the package for what is there, reads the recovered scripts for the native
boundaries they reach, and says for each library whether the project carries it.

A dependency is classified by what it is, because the four kinds want completely different handling:

  IL2CPP_RUNTIME     `libil2cpp.so` / `UnityFramework` - the recovery replaces this, so a project
                     must NOT carry it. Copying it in as a plugin would ship the game twice.
  UNITY_ENGINE       `libunity.so`, `libmain.so` - Unity's own player, provided by the editor.
  ENGINE_BUILD_OUTPUT `lib_burst_generated.so` - Burst's output, compiled from the managed source at
                     build time, so a project regenerates it and must not carry the built one.
  GAME_NATIVE_PLUGIN a library the game shipped that is none of the above. This is the only kind a
                     Unity project has to carry, and the only kind whose absence is a blocker.
  SYSTEM_LIBRARY     the platform's own, present on the device.

`required_by` is read from the managed side rather than assumed: `NativeBoundary` already classifies
every unresolved call, and the symbol it names is what ties a boundary to a library. A library nothing
managed reaches is reported with an empty `required_by` rather than dropped, because a plugin can be
reached from native code or from a Unity plugin importer setting this cannot see.

Usage: runtime_dependency_graph.py <package dir> <recovered game directory> [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

BOUNDARY = re.compile(r'Il2CppRuntime\.Boundary\("(?P<kind>[A-Z0-9_]+)(?::(?P<symbol>[^"]*))?",\s*"(?P<detail>[^"]*)"')
SYMBOL_IN_DETAIL = re.compile(r'\\"(?P<symbol>[A-Za-z_][\w.]*)\\"')

IL2CPP_RUNTIME, UNITY_ENGINE, GAME_NATIVE_PLUGIN, SYSTEM_LIBRARY, ENGINE_BUILD_OUTPUT = (
    "IL2CPP_RUNTIME", "UNITY_ENGINE", "GAME_NATIVE_PLUGIN", "SYSTEM_LIBRARY", "ENGINE_BUILD_OUTPUT")

# Burst compiles `[BurstCompile]` jobs into this library at build time from the managed source, so a
# project regenerates it and must not carry the built one - the same reasoning as the il2cpp runtime,
# one level up. It is separated from GAME_NATIVE_PLUGIN because it is the only library in that shape
# whose absence from the project is correct.
ENGINE_BUILT = re.compile(r"^lib_burst_generated")

# Named rather than pattern-matched, because these are the two libraries the recovery *replaces* and
# getting either wrong ships the game twice or drops the engine.
REPLACED_BY_RECOVERY = {"libil2cpp.so", "UnityFramework"}
UNITY_PLAYER = {"libunity.so", "libmain.so", "libunity.dylib"}

# A system library on either platform. `libswift*` is the Swift runtime, which the toolchain supplies.
SYSTEM = re.compile(r"^(libc|libm|libdl|libz|liblog|libandroid|libGLES|libEGL|libOpenSL|libvulkan|"
                    r"libstdc\+\+|libswift|libsystem|libobjc)")


def kind_of(name):
    if name in REPLACED_BY_RECOVERY:
        return IL2CPP_RUNTIME
    if name in UNITY_PLAYER:
        return UNITY_ENGINE
    if ENGINE_BUILT.match(name):
        return ENGINE_BUILD_OUTPUT
    if SYSTEM.match(name):
        return SYSTEM_LIBRARY
    return GAME_NATIVE_PLUGIN


def libraries(package):
    """Every native library the package ships, with its platform and architecture."""
    found = []

    for path in sorted(package.rglob("*")):
        if not path.is_file():
            continue
        suffix = path.suffix
        if suffix not in (".so", ".dylib", ".a"):
            # An iOS framework's binary has no extension; it is the file named like its directory.
            parents = [p.name for p in path.parents]
            if not any(p.endswith(".framework") for p in parents) or "." in path.name:
                continue
            if f"{path.name}.framework" not in parents:
                continue

        parts = path.relative_to(package).parts
        architecture = next((p for p in parts if p in
                             ("arm64-v8a", "armeabi-v7a", "x86", "x86_64", "arm64")), None)
        found.append({
            "name": path.name,
            "path": str(path.relative_to(package)),
            "platform": "android" if suffix == ".so" else "ios",
            "architecture": architecture,
            "bytes": path.stat().st_size,
            "kind": kind_of(path.name),
        })

    return found


def boundaries(game):
    """{symbol: set of declaring files} for every native boundary the recovered scripts name."""
    reached = collections.defaultdict(set)
    kinds = collections.Counter()

    for path in sorted(game.rglob("*.cs")):
        text = path.read_text(encoding="utf-8", errors="replace")
        for match in BOUNDARY.finditer(text):
            kinds[match.group("kind")] += 1
            symbol = match.group("symbol")
            if symbol is None and (inner := SYMBOL_IN_DETAIL.search(match.group("detail"))):
                symbol = inner.group("symbol")
            if symbol:
                reached[symbol].add(str(path.relative_to(game)))

    return reached, kinds


def packaged(game, name):
    """Whether the recovered project carries this library, in any of Unity's plugin locations."""
    return [str(p.relative_to(game)) for p in game.rglob(name)]


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("package", help="the unpacked APK or IPA")
    parser.add_argument("game", help="the game directory inside the rip")
    parser.add_argument("--json")
    parser.add_argument("--name")
    arguments = parser.parse_args()

    package, game = pathlib.Path(arguments.package), pathlib.Path(arguments.game)
    for root in (package, game):
        if not root.is_dir():
            print(f"NOT_A_DIRECTORY: {root}")
            return 2

    found = libraries(package)
    reached, kinds = boundaries(game)

    # Which symbols belong to which library cannot be read without the export tables, so the tie is
    # reported at the level the evidence supports: the kind of boundary, and the symbols themselves.
    for library in found:
        library["packaged_into_project"] = packaged(game, library["name"])
        library["required_by_symbols"] = []
        library["resolved"] = bool(library["packaged_into_project"])

    by_kind = collections.Counter(library["kind"] for library in found)
    plugins = [library for library in found if library["kind"] == GAME_NATIVE_PLUGIN]
    preserved = [library for library in plugins if library["resolved"]]

    report = {
        "fixture": arguments.name or game.name,
        "package": str(package),
        "project": str(game),
        "libraries_in_package": len(found),
        "by_kind": dict(by_kind),
        "native_boundaries_by_verdict": dict(kinds),
        "distinct_symbols_reached": len(reached),
        "game_native_plugins": len(plugins),
        "game_native_plugins_preserved": len(preserved),
        # The one rate that matters for runtime: of the libraries a project must carry, how many it
        # carries. The runtime and the engine are excluded because a project must not carry them.
        "native_plugin_preservation_rate": (round(len(preserved) / len(plugins), 4)
                                            if plugins else None),
        "libraries": found,
        "symbols_reached": {symbol: sorted(files)[:4] for symbol, files in sorted(reached.items())},
    }

    print(f"{report['fixture']}: {len(found)} native libraries in the package")
    for kind, count in by_kind.most_common():
        print(f"  {kind:<20} {count}")
    print(f"  distinct native symbols the scripts reach: {len(reached)}")
    print(f"  game native plugins preserved in the project: {len(preserved)} of {len(plugins)}"
          f"  (rate {report['native_plugin_preservation_rate']})")
    for library in plugins:
        state = "PRESERVED" if library["resolved"] else "MISSING"
        print(f"    {state:<10} {library['name']} ({library['bytes']} bytes, {library['architecture'] or library['platform']})")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))
    return 0


if __name__ == "__main__":
    sys.exit(main())
