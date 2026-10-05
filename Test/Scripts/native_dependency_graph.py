#!/usr/bin/env python3
"""NativeDependencyGraph: every native library a build depends on, what kind it is, and whether a
recovered project can carry it.

Iteration 064 (brief §8). `runtime_dependency_graph.py` (054-056) answers "which shipped libraries does the
project carry". It cannot see a library that ships as no file at all: on iOS a static library (`.a`) is
linked into `UnityFramework` at build time, so the package has nothing to copy and the old report read the
dependency as absent rather than as linked. This reads three more sources of evidence and never invents a
file:

  * the recovered scripts' P/Invokes: `[DllImport("__Internal")]` on Apple, `[DllImport("libfoo")]` elsewhere
    - which managed assembly needs which entry point;
  * the symbol table of the binary the entry points must resolve in (`UnityFramework` on iOS): an entry
    point present there is linked into it, which is what proves a static library rather than assumes one;
  * optionally the source tree's plugin files (`--source`): a `.a` whose archive symbol table names the
    entry points is the library they came from. That is the only place a static library's *name* exists.

Kinds (brief §8):
  IL2CPP_RUNTIME, UNITY_ENGINE, ENGINE_BUILD_OUTPUT, SYSTEM_LIBRARY - not the project's to carry
  GAME_NATIVE_PLUGIN  a shared library the game shipped (`.so`, `.dylib`)
  FRAMEWORK           an iOS framework bundle the game shipped
  STATIC_LIBRARY      linked into the engine binary; no file in the package

Recoverability:
  NOT_REQUIRED                    the kind is supplied by the editor, the device or the recovery itself
  PRESERVED                       the project carries the file or the bundle
  MISSING                         the project should carry it and does not
  LINKED_STATIC_NOT_EXTRACTABLE   linked into another binary; there is no file to extract, ever
  UNKNOWN                         the evidence does not settle it (e.g. entry points stripped from the symbol table)

Usage: native_dependency_graph.py <package dir> <recovered game dir> [--source <checkout>] [--json out.json]
       native_dependency_graph.py --self-test
"""
import argparse
import collections
import json
import pathlib
import re
import struct
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import runtime_dependency_graph as rdg  # noqa: E402

DLLIMPORT = re.compile(
    r'\[DllImport\("(?P<library>[^"]+)"(?:[^\]]*?EntryPoint\s*=\s*"(?P<entry>[^"]+)")?[^\]]*\]'
    r'[\s\S]{0,600}?static\s+extern\s+[^(;{]*?(?P<method>\w+)\s*\(')

NOT_REQUIRED = {rdg.IL2CPP_RUNTIME, rdg.UNITY_ENGINE, rdg.ENGINE_BUILD_OUTPUT, rdg.SYSTEM_LIBRARY}


def pinvokes(game):
    """{(assembly, library): [entry point, ...]} from the recovered scripts."""
    found = collections.defaultdict(list)
    scripts = game / "Assets" / "Scripts"
    for path in sorted(scripts.rglob("*.cs")):
        text = path.read_text(encoding="utf-8", errors="replace")
        if "DllImport" not in text:
            continue
        assembly = path.relative_to(scripts).parts[0]
        for match in DLLIMPORT.finditer(text):
            found[(assembly, match.group("library"))].append(match.group("entry") or match.group("method"))
    return found


def mach_o_symbols(path):
    """Every name in a thin 64-bit Mach-O's LC_SYMTAB, or None when the file is not one."""
    try:
        data = path.read_bytes()
    except OSError:
        return None
    if len(data) < 32 or struct.unpack("<I", data[:4])[0] != 0xFEEDFACF:
        return None
    (ncmds,) = struct.unpack("<I", data[16:20])
    offset, names = 32, set()
    for _ in range(ncmds):
        command, size = struct.unpack("<II", data[offset:offset + 8])
        if command == 2:  # LC_SYMTAB
            symoff, nsyms, stroff, _strsize = struct.unpack("<IIII", data[offset + 8:offset + 24])
            for index in range(nsyms):
                entry = symoff + 16 * index
                (strx,) = struct.unpack("<I", data[entry:entry + 4])
                end = data.find(b"\0", stroff + strx)
                names.add(data[stroff + strx:end].decode("latin1"))
        offset += size
    return names


def archive_defines(path, entry_points):
    """Which entry points a static archive names, read from the bytes: an `ar` archive carries a symbol
    table of NUL-terminated names, and a C symbol on Apple is the name with one leading underscore."""
    try:
        data = path.read_bytes()
    except OSError:
        return set()
    # A universal archive (one `ar` per architecture behind a fat header) is what Xcode-era plugins ship.
    if not (data.startswith(b"!<arch>\n") or (data[:4] == b"\xca\xfe\xba\xbe" and b"!<arch>\n" in data[:4096])):
        return set()
    # Bounded by NUL on both sides: entry points like `New` are a suffix of a thousand other names.
    return {entry for entry in entry_points if b"\0_" + entry.encode() + b"\0" in data}


def engine_binary(package):
    """The binary `__Internal` resolves in: UnityFramework on iOS (2019.3+)."""
    for path in package.rglob("UnityFramework"):
        if path.is_file() and path.parent.name == "UnityFramework.framework":
            return path
    return None


def build(package, game, source=None):
    libraries = rdg.libraries(package)
    nodes = []

    for library in libraries:
        kind = library["kind"]
        if kind == rdg.GAME_NATIVE_PLUGIN and library["framework"]:
            kind = "FRAMEWORK"
        carried = rdg.packaged(game, library["framework"] or library["name"])
        nodes.append({
            "library": library["framework"] or library["name"],
            "kind": kind,
            "bundle": library["framework"],
            "architecture": library["architecture"],
            "platform": library["platform"],
            "symbols": None,
            "source_evidence": [],
            "recoverability": "NOT_REQUIRED" if kind in NOT_REQUIRED else ("PRESERVED" if carried else "MISSING"),
            "evidence": f"file in package: {library['path']}",
        })

    imports = pinvokes(game)
    engine = engine_binary(package)
    engine_symbols = mach_o_symbols(engine) if engine else None
    archives = sorted(pathlib.Path(source).rglob("*.a")) if source else []
    edges = []

    for (assembly, library_name), entries in sorted(imports.items()):
        edge = {"assembly": assembly, "library": library_name, "entry_points": len(entries)}
        edges.append(edge)
        if library_name != "__Internal":
            # A named library resolves to a file by name; the shipped-library nodes above already say
            # whether the project carries it.
            edge["resolves_to"] = next((n["library"] for n in nodes if n["library"].startswith(("lib" + library_name, library_name))), None)
            continue

        in_engine = sorted(e for e in entries if engine_symbols is not None and "_" + e in engine_symbols)
        edge["in_engine_symbol_table"] = len(in_engine)
        archive_hits = []
        for archive in archives:
            defined = archive_defines(archive, entries)
            if defined:
                archive_hits.append({"archive": str(archive.relative_to(source)), "defines": len(defined)})

        if engine_symbols is not None and len(in_engine) == len(entries):
            recoverability, evidence = "LINKED_STATIC_NOT_EXTRACTABLE", (
                f"all {len(entries)} entry points are symbols of {engine.name}: linked into it, no file to extract")
        elif engine_symbols is not None and in_engine:
            recoverability, evidence = "LINKED_STATIC_NOT_EXTRACTABLE", (
                f"{len(in_engine)} of {len(entries)} entry points are symbols of {engine.name}")
        else:
            recoverability, evidence = "UNKNOWN", (
                "no entry point is in the engine binary's symbol table (stripped, or not linked there)")

        name = archive_hits[0]["archive"].rsplit("/", 1)[-1] if len(archive_hits) == 1 else None
        nodes.append({
            "library": name or f"{assembly} (__Internal)",
            "kind": "STATIC_LIBRARY" if recoverability == "LINKED_STATIC_NOT_EXTRACTABLE" else "UNKNOWN",
            "bundle": engine.parent.name if engine else None,
            "architecture": ",".join(rdg.mach_o_architectures(engine)) if engine else None,
            "platform": "ios",
            "symbols": {"entry_points": len(entries), "in_engine_symbol_table": len(in_engine)},
            "source_evidence": archive_hits,
            "recoverability": recoverability,
            "evidence": evidence,
            "required_by": assembly,
        })

    return {"nodes": nodes, "edges": edges,
            "by_kind": dict(collections.Counter(n["kind"] for n in nodes)),
            "by_recoverability": dict(collections.Counter(n["recoverability"] for n in nodes))}


def apply_evidence(graph, bindings_path, archive_reports, game):
    """Iteration 065: what the machine code says about a node the symbol table could not decide.

    `ios_native_unknown.py` finds each `__Internal` entry point's implementation through the il2cpp wrapper
    and reads what it references; a group whose every resolved entry point is PROVEN is implemented in the
    engine binary, and the classes it names say whether that is a bridge to a framework the package ships
    or a library compiled in. `static_library_provenance.py` proves an archive from outside the package is
    the code that was linked, byte for byte, and whether it was preserved into the project. Neither changes
    a node it has nothing to say about.
    """
    if bindings_path:
        rows = json.loads(pathlib.Path(bindings_path).read_text())["rows"]
        for node in graph["nodes"]:
            group = node.get("required_by")
            if node.get("recoverability") != "UNKNOWN" or not group:
                continue
            mine = [row for row in rows if row["assembly"] == group]
            proven = [row for row in mine if row["verdict"] == "PROVEN"]
            if not proven:
                continue
            frameworks = sorted({c.split("(")[-1].rstrip(")") for row in proven for c in row["classes"] if "@rpath/" in c})
            node["symbols"]["implementations_proven"] = len(proven)
            node["symbols"]["implementations_unknown"] = len(mine) - len(proven)
            node["kind"] = "OBJC_BRIDGE" if frameworks else "STATIC_LIBRARY"
            node["recoverability"] = "BRIDGE_TO_PRESERVED_FRAMEWORK" if frameworks else "LINKED_STATIC_NOT_EXTRACTABLE"
            node["evidence"] = (f"{len(proven)} of {len(mine)} entry points located through the il2cpp wrapper and proven by the "
                                f"classes and selectors their code references" + (f"; calls into {', '.join(frameworks)}" if frameworks else "; every class is defined in the engine binary"))
    for report_path in archive_reports:
        report = json.loads(pathlib.Path(report_path).read_text())
        name = pathlib.Path(report["archive"]["path"]).name
        for node in graph["nodes"]:
            if node["library"] != name or report.get("verdict") != "LINKED_ARCHIVE_PROVEN":
                continue
            preserved = (game / "Assets" / "Plugins" / "iOS" / name).exists()
            node["recoverability"] = "PRESERVED_FROM_VERIFIED_ARTIFACT" if preserved else "VERIFIED_ARTIFACT_AVAILABLE"
            node["evidence"] = (f"archive {report['archive']['git_blob']} is byte-identical to the linked code at "
                                f"{report['summary'].get('BYTE_IDENTICAL', 0)} entry points" + ("; preserved into the project" if preserved else ""))
    graph["by_kind"] = dict(collections.Counter(n["kind"] for n in graph["nodes"]))
    graph["by_recoverability"] = dict(collections.Counter(n["recoverability"] for n in graph["nodes"]))


def self_test():
    """Each case is red if the rule it names is removed."""
    failures = []

    # A DllImport with an EntryPoint names the entry point, not the method.
    text = '[DllImport("__Internal", EntryPoint = "RF_Do")]\n[Token(Token = "0x1")]\nprivate static extern void Do(int a);'
    match = DLLIMPORT.search(text)
    if not match or (match.group("entry") or match.group("method")) != "RF_Do":
        failures.append("EntryPoint is the symbol a static library must define")

    # Without one, the method name is the entry point.
    text = '[DllImport("__Internal")]\n[Address(RVA = "0x1")]\npublic static extern int IOSFBInit(string a);'
    match = DLLIMPORT.search(text)
    if not match or match.group("method") != "IOSFBInit":
        failures.append("the method name is the entry point when none is given")

    # An archive defines an entry point only as `_name\\0`; a longer name sharing the prefix is not it.
    import tempfile
    with tempfile.TemporaryDirectory() as tmp:
        archive = pathlib.Path(tmp) / "libx.a"
        archive.write_bytes(b"!<arch>\n\0" + b"_RF_DoMore\0" + b"_RF_Other\0" + b"Foo_New\0")
        if archive_defines(archive, ["RF_Do", "RF_Other", "New"]) != {"RF_Other"}:
            failures.append("a prefix or a suffix of a symbol is not the symbol")
        fat = pathlib.Path(tmp) / "libfat.a"
        fat.write_bytes(b"\xca\xfe\xba\xbe\0\0\0\x02" + b"\0" * 32 + b"!<arch>\n\0_RF_Other\0")
        if archive_defines(fat, ["RF_Other"]) != {"RF_Other"}:
            failures.append("a universal archive is an archive")
        not_archive = pathlib.Path(tmp) / "liby.a"
        not_archive.write_bytes(b"_RF_Other\0")
        if archive_defines(not_archive, ["RF_Other"]):
            failures.append("a file that is not an ar archive defines nothing")

    for failure in failures:
        print("FAIL", failure)
    print(f"self-test: {5 - len(failures)}/5")
    return 1 if failures else 0


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("package", nargs="?")
    parser.add_argument("game", nargs="?")
    parser.add_argument("--source")
    parser.add_argument("--json")
    parser.add_argument("--bindings", help="ios_native_unknown.py --json output")
    parser.add_argument("--archive-provenance", action="append", default=[], help="static_library_provenance.py --json output")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return self_test()

    graph = build(pathlib.Path(args.package), pathlib.Path(args.game), pathlib.Path(args.source) if args.source else None)
    apply_evidence(graph, args.bindings, args.archive_provenance, pathlib.Path(args.game))
    for node in graph["nodes"]:
        if node["kind"] in NOT_REQUIRED:
            continue
        print(f"{node['kind']:<16} {node['recoverability']:<30} {node['library']}  ({node['evidence']})")
    print(json.dumps({"by_kind": graph["by_kind"], "by_recoverability": graph["by_recoverability"]}, sort_keys=True))
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(graph, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
