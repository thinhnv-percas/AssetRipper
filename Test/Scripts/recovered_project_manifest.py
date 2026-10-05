#!/usr/bin/env python3
"""RecoveredProjectManifest.json: one record of what a recovered project is, where it came from, and what
still stands between it and the game it was recovered from.

Iteration 064 (brief §13). Every field is read from evidence, and a field nothing establishes is null with
the reason, never a default:

  source            the package: path, and SHA-256 of the files that decide the recovery (the il2cpp binary,
                    global-metadata.dat) plus one digest over every file's path and size
  unity_version     what the log says the build's own data declared ("found Unity version"), never a constant
  target_platform   read off the package layout: `lib/<abi>/libil2cpp.so` is Android, `UnityFramework` iOS
  assemblies        PackageProvenance rows (package_provenance.py)
  packages          the same, grouped by package
  native            NativeDependencyGraph (native_dependency_graph.py)
  shaders           shader count, program encodings (ShaderPrograms.json), external Metal programs
  serialized        scenes, prefabs, materials, other assets
  confidence        the semantic status distribution, when a recovery_metrics.py JSON is given
  known_blockers    what the evidence says is missing - including the one that is always there without
                    Unity: runtime NOT_RUN

Usage: recovered_project_manifest.py <package dir> <rip root> --log <rip log> [--source <checkout>]
                                     [--provenance build_provenance.json] [--metrics recovery_metrics.json]
                                     [--out RecoveredProjectManifest.json]
"""
import argparse
import collections
import hashlib
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import native_dependency_graph  # noqa: E402
import package_provenance  # noqa: E402

FOUND_VERSION = re.compile(r"found Unity version: (?P<version>\S+)")
EXPORT_VERSION = re.compile(r"Exporting to Unity version (?P<version>\S+)")


def sha256(path):
    digest = hashlib.sha256()
    with path.open("rb") as handle:
        for chunk in iter(lambda: handle.read(1 << 20), b""):
            digest.update(chunk)
    return digest.hexdigest()


def source_record(package):
    files = sorted(p for p in package.rglob("*") if p.is_file())
    tree = hashlib.sha256()
    for path in files:
        tree.update(f"{path.relative_to(package)}\0{path.stat().st_size}\n".encode())
    deciding = [p for p in files if p.name in ("libil2cpp.so", "UnityFramework", "global-metadata.dat")]
    return {
        "path": str(package),
        "files": len(files),
        "tree_digest": tree.hexdigest(),
        "deciding_files": {str(p.relative_to(package)): sha256(p) for p in deciding},
    }


def platform_of(package):
    if any(package.rglob("libil2cpp.so")):
        abis = sorted({p.parent.name for p in package.rglob("libil2cpp.so")})
        return {"platform": "Android", "architectures": abis, "evidence": "lib/<abi>/libil2cpp.so in the package"}
    framework = next((p for p in package.rglob("UnityFramework") if p.is_file()), None)
    if framework is not None:
        return {"platform": "iOS", "architectures": native_dependency_graph.rdg.mach_o_architectures(framework),
                "evidence": "Frameworks/UnityFramework.framework in the package"}
    return {"platform": None, "architectures": [], "evidence": "no il2cpp binary recognised in the package"}


def unity_version(log):
    found = exported = None
    for line in open(log, encoding="utf-8", errors="replace"):
        if found is None and (match := FOUND_VERSION.search(line)):
            found = match.group("version")
        if exported is None and (match := EXPORT_VERSION.search(line)):
            exported = match.group("version")
    return {"build": found, "project": exported,
            "evidence": "the build's own data, as the import log records it" if found else "not in the log"}


def shaders(rip_root, game):
    programs = rip_root / "AuxiliaryFiles" / "ShaderPrograms.json"
    encodings = collections.Counter()
    if programs.exists():
        for row in json.loads(programs.read_text()):
            encodings[row.get("encoding") or row.get("kind") or "UNKNOWN"] += 1
    return {
        "shaders": sum(1 for _ in (game / "Assets").rglob("*.shader")),
        "program_encodings": dict(encodings),
        "external_programs": sum(1 for _ in (rip_root / "AuxiliaryFiles" / "ShaderVariants").glob("*.metal")),
    }


def serialized(game):
    assets = game / "Assets"
    return {
        "scenes": sum(1 for _ in assets.rglob("*.unity")),
        "prefabs": sum(1 for _ in assets.rglob("*.prefab")),
        "materials": sum(1 for _ in assets.rglob("*.mat")),
        "assets": sum(1 for _ in assets.rglob("*.asset")),
    }


def blockers(native, packages, shader_record):
    found = [{"blocker": "RUNTIME_NOT_RUN", "detail": "no Unity in this environment; nothing about runtime behaviour is established"}]
    for node in native["nodes"]:
        if node["recoverability"] in ("MISSING", "UNKNOWN"):
            found.append({"blocker": f"NATIVE_{node['recoverability']}", "detail": f"{node['library']}: {node['evidence']}"})
        elif node["recoverability"] == "LINKED_STATIC_NOT_EXTRACTABLE":
            found.append({"blocker": "NATIVE_LINKED_STATIC", "detail": f"{node['library']} must be supplied by its vendor ({node['evidence']})"})
        elif node["recoverability"] == "BRIDGE_TO_PRESERVED_FRAMEWORK":
            found.append({"blocker": "NATIVE_BRIDGE_SOURCE", "detail": f"{node['library']}: the frameworks it calls are preserved; the bridge compiled into the engine binary has no source in the export ({node['evidence']})"})
    stubbed = [row for row in packages["rows"] if row["export"] == "STUB" and row["category"] != "BUILTIN_UNITY"]
    if stubbed:
        found.append({"blocker": "PACKAGES_STUBBED_NOT_DECLARED",
                      "detail": f"{len(stubbed)} package assemblies are stubbed and the exported manifest does not declare their packages: "
                                + ", ".join(sorted({row['package'] or row['assembly'] for row in stubbed}))})
    if shader_record["program_encodings"]:
        found.append({"blocker": "SHADER_PROGRAMS_OUTSIDE_SHADERLAB" if shader_record["external_programs"] else "SHADER_PROGRAMS_PARTIAL",
                      "detail": json.dumps(shader_record["program_encodings"], sort_keys=True)})
    return found


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("package")
    parser.add_argument("rip")
    parser.add_argument("--log", required=True)
    parser.add_argument("--source")
    parser.add_argument("--provenance")
    parser.add_argument("--metrics")
    parser.add_argument("--out")
    parser.add_argument("--bindings", help="ios_native_unknown.py --json (iteration 065)")
    parser.add_argument("--archive-provenance", action="append", default=[], help="static_library_provenance.py --json (iteration 065)")
    parser.add_argument("--manifest-reconstruction", help="package_manifest_reconstruction.py --json (iteration 065)")
    args = parser.parse_args()

    package, rip_root = pathlib.Path(args.package), pathlib.Path(args.rip)
    game = next((child for child in sorted(rip_root.iterdir()) if (child / "Assets").is_dir()), None)
    if game is None:
        print(f"PROJECT_ROOT_MISMATCH: no game directory with Assets/ under {rip_root}")
        return 2

    source = pathlib.Path(args.source) if args.source else None
    packages = package_provenance.build(game, args.log, source, args.provenance)
    native = native_dependency_graph.build(package, game, source)
    native_dependency_graph.apply_evidence(native, args.bindings, args.archive_provenance, game)
    reconstructed = {row["package"]: row for row in json.loads(pathlib.Path(args.manifest_reconstruction).read_text())} if args.manifest_reconstruction else {}
    shader_record = shaders(rip_root, game)
    confidence = None
    if args.metrics:
        metrics = json.loads(pathlib.Path(args.metrics).read_text())
        confidence = metrics.get("statuses") or metrics.get("summary") or metrics

    by_package = collections.defaultdict(list)
    for row in packages["rows"]:
        if row["package"]:
            by_package[row["package"]].append(row)

    manifest = {
        "schema": "RecoveredProjectManifest/1",
        "source": source_record(package),
        "unity_version": unity_version(args.log),
        "target_platform": platform_of(package),
        "assemblies": [{k: row[k] for k in ("assembly", "category", "export", "fingerprint")} for row in packages["rows"] if row["assembly"]],
        "packages": {name: {"category": rows[0]["category"], "assemblies": [r["assembly"] for r in rows if r["assembly"]],
                            "export": rows[0].get("export"),
                            "version": reconstructed[name]["version"] if name in reconstructed else rows[0]["version"],
                            "version_source": "package_manifest_reconstruction (manifest, lock, cache and fingerprint, reported separately)"
                                if name in reconstructed else rows[0]["version_source"],
                            **({"version_candidates": reconstructed[name].get("candidates"), "version_conflicts": reconstructed[name]["conflicts"]}
                               if name in reconstructed else {})}
                     for name, rows in sorted(by_package.items())},
        "native_dependencies": [{k: node[k] for k in ("library", "kind", "recoverability", "evidence")} for node in native["nodes"]],
        "shaders": shader_record,
        "serialized": serialized(game),
        "recovery_confidence": confidence,
        "known_blockers": blockers(native, packages, shader_record),
        "runtime_status": "NOT_RUN",
    }

    text = json.dumps(manifest, indent=1)
    if args.out:
        pathlib.Path(args.out).write_text(text)
    print(f"{game.name}: Unity {manifest['unity_version']['build']} {manifest['target_platform']['platform']} "
          f"{len(manifest['assemblies'])} assemblies, {len(manifest['packages'])} packages, "
          f"{len(manifest['native_dependencies'])} native nodes, {len(manifest['known_blockers'])} known blockers")
    for blocker in manifest["known_blockers"]:
        print(f"  {blocker['blocker']}: {blocker['detail'][:160]}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
