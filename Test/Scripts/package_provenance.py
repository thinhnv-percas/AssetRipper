#!/usr/bin/env python3
"""PackageProvenance: for every assembly a build shipped (and every package a source declares), where its
code comes from and what the recovered project does with it.

Iteration 064 (brief §9). The exported `Packages/manifest.json` lists the engine modules and nothing else,
so the project does not know that `Unity.TextMeshPro` is a package, that `Assembly-CSharp` is the game, or
that `__Generated` was produced by the build. Categories:

  UPSTREAM_EXACT              a published package whose declarations match the build exactly (`build_provenance.py`
                              PROVEN_BUILD_MATCH / LIKELY_MATCH against a checkout of that package)
  UPSTREAM_VERSION_MISMATCH   a published package, but the checkout at hand is not the version the build compiled
  BUILTIN_UNITY               the engine's own: `UnityEngine.*Module`, `UnityEngine`, the .NET class library
  CUSTOM                      the game's code, recovered by this export
  GENERATED                   produced by the build itself (`__Generated`), never written by anyone
  STUB                        in the build, stubbed by the export, and nothing proves which upstream it is
  NOT_IN_BUILD                declared by the source manifest, no assembly in the build
  UNKNOWN                     nothing above is established

Each row also states the separate facts the brief asks the generator to know: `manifest_declared`,
`engine_provided`, `vendor_source` (in the source under Assets/), `stub_only`, `in_build`, and `version` with
where the version came from. A version is never filled in to make something compile: without a witness it
is null.

Usage: package_provenance.py <rip game dir> --log <rip log> [--source <checkout>] [--provenance build_provenance.json]
                             [--json out.json]
       package_provenance.py --self-test
"""
import argparse
import collections
import json
import pathlib
import re
import sys

ATTEMPTED = re.compile(r"Attempted: (?P<names>.+)$")

# The package a Unity registry assembly belongs to. Used only to *name* the package an assembly came from;
# never as evidence that the build's copy is that package at any version - that takes a fingerprint.
REGISTRY_ASSEMBLIES = {
    "Unity.TextMeshPro": "com.unity.textmeshpro",
    "UnityEngine.UI": "com.unity.ugui",
    "Unity.Mathematics": "com.unity.mathematics",
    "Unity.Burst": "com.unity.burst",
    "Unity.Burst.Unsafe": "com.unity.burst",
    "Unity.Collections": "com.unity.collections",
    "Unity.Collections.LowLevel.ILSupport": "com.unity.collections",
    "Unity.VisualScripting.Core": "com.unity.visualscripting",
    "Unity.VisualScripting.Flow": "com.unity.visualscripting",
    "Unity.VisualScripting.State": "com.unity.visualscripting",
    "Unity.Timeline": "com.unity.timeline",
    "Unity.InputSystem": "com.unity.inputsystem",
    "Unity.Addressables": "com.unity.addressables",
    "Unity.ResourceManager": "com.unity.addressables",
    "Unity.RenderPipelines.Core.Runtime": "com.unity.render-pipelines.core",
    "Unity.RenderPipelines.Universal.Runtime": "com.unity.render-pipelines.universal",
    "Unity.Services.Core": "com.unity.services.core",
    "Unity.Postprocessing.Runtime": "com.unity.postprocessing",
    "Newtonsoft.Json": "com.unity.nuget.newtonsoft-json",
}

DOTNET = re.compile(r"^(mscorlib|netstandard|System(\..+)?|Mono\.Security)$")
ENGINE = re.compile(r"^UnityEngine(\..+Module)?$")
GENERATED = re.compile(r"^__Generated$")


def build_assemblies(rip_root):
    directory = rip_root / "AuxiliaryFiles" / "GameAssemblies"
    return sorted(path.stem for path in directory.glob("*.dll")) if directory.is_dir() else []


def attempted(log):
    for line in open(log, encoding="utf-8", errors="replace"):
        match = ATTEMPTED.search(line.rstrip("\n"))
        if match:
            return {name.strip() for name in match.group("names").split(",")}
    return None


def source_manifest(checkout):
    path = checkout / "Packages" / "manifest.json"
    if not path.is_file():
        return {}
    return json.loads(path.read_text(encoding="utf-8")).get("dependencies", {})


def vendor_assemblies(checkout):
    """Assembly names whose source is under Assets/ (an asmdef there), i.e. vendored rather than a package."""
    found = set()
    for asmdef in (checkout / "Assets").rglob("*.asmdef"):
        try:
            found.add(json.loads(asmdef.read_text(encoding="utf-8-sig")).get("name"))
        except (OSError, ValueError):
            continue
    return found


def classify(assembly, *, recovered, fingerprint, in_manifest, vendored):
    """The category of one build assembly, from the facts established about it."""
    if ENGINE.match(assembly) or DOTNET.match(assembly):
        return "BUILTIN_UNITY", "the engine's module or the .NET class library it ships"
    if GENERATED.match(assembly):
        return "GENERATED", "emitted by the il2cpp build, not by any source"
    if fingerprint in ("PROVEN_BUILD_MATCH", "LIKELY_MATCH") and (assembly in REGISTRY_ASSEMBLIES or vendored):
        return "UPSTREAM_EXACT", f"declarations match the source checkout ({fingerprint})"
    if fingerprint == "SOURCE_MISMATCH" and assembly in REGISTRY_ASSEMBLIES:
        return "UPSTREAM_VERSION_MISMATCH", "a registry package whose checkout declares a different surface than the build"
    if recovered and assembly not in REGISTRY_ASSEMBLIES:
        return "CUSTOM", "the game's code, recovered by this export"
    if not recovered:
        return "STUB", "stubbed by the export; no fingerprint establishes which upstream it is"
    return "UNKNOWN", "nothing establishes the origin"


def build(rip_game, log, checkout=None, provenance_path=None):
    rip_root = rip_game.parent
    assemblies = build_assemblies(rip_root)
    recovered = attempted(log) if log else None
    fingerprints = {}
    if provenance_path:
        fingerprints = {row["assembly"]: row["status"] for row in json.loads(pathlib.Path(provenance_path).read_text())}
    manifest = source_manifest(checkout) if checkout else {}
    vendored = vendor_assemblies(checkout) if checkout else set()

    rows = []
    packages_in_build = set()
    for assembly in assemblies:
        package = REGISTRY_ASSEMBLIES.get(assembly)
        if package:
            packages_in_build.add(package)
        is_recovered = recovered is not None and assembly in recovered
        category, evidence = classify(assembly, recovered=is_recovered, fingerprint=fingerprints.get(assembly),
                                      in_manifest=package in manifest if package else False, vendored=assembly in vendored)
        version = manifest.get(package) if package and category == "UPSTREAM_EXACT" else None
        rows.append({
            "assembly": assembly,
            "package": package,
            "category": category,
            "evidence": evidence,
            "in_build": True,
            "manifest_declared": bool(package and package in manifest),
            "engine_provided": category == "BUILTIN_UNITY",
            "vendor_source": assembly in vendored,
            "stub_only": recovered is not None and not is_recovered and category != "BUILTIN_UNITY",
            "export": "UNKNOWN" if recovered is None else ("RECOVERED" if is_recovered else "STUB"),
            "fingerprint": fingerprints.get(assembly),
            "version": version,
            "version_source": "source manifest, declarations proven to match" if version else None,
        })

    for package, declared in sorted(manifest.items()):
        if package in packages_in_build or package.startswith("com.unity.modules."):
            continue
        rows.append({
            "assembly": None, "package": package, "category": "NOT_IN_BUILD",
            "evidence": "declared by the source manifest; no assembly of it is in the build",
            "in_build": False, "manifest_declared": True, "engine_provided": False, "vendor_source": False,
            "stub_only": False, "export": None, "fingerprint": None, "version": declared,
            "version_source": "source manifest (not in the build, so not a fact about it)",
        })

    return {"rows": rows, "by_category": dict(collections.Counter(row["category"] for row in rows)),
            "scope": "UNKNOWN" if recovered is None else "LOG"}


def self_test():
    failures = []
    if classify("UnityEngine.PhysicsModule", recovered=False, fingerprint=None, in_manifest=False, vendored=False)[0] != "BUILTIN_UNITY":
        failures.append("an engine module is the engine's")
    if classify("Unity.TextMeshPro", recovered=False, fingerprint=None, in_manifest=True, vendored=False)[0] != "STUB":
        failures.append("a registry name alone does not prove UPSTREAM_EXACT")
    if classify("Unity.TextMeshPro", recovered=False, fingerprint="PROVEN_BUILD_MATCH", in_manifest=True, vendored=False)[0] != "UPSTREAM_EXACT":
        failures.append("a declaration fingerprint does")
    if classify("Unity.Collections", recovered=False, fingerprint="SOURCE_MISMATCH", in_manifest=True, vendored=False)[0] != "UPSTREAM_VERSION_MISMATCH":
        failures.append("a registry package with a mismatched surface is a version mismatch")
    if classify("Assembly-CSharp", recovered=True, fingerprint="SOURCE_MISMATCH", in_manifest=False, vendored=False)[0] != "CUSTOM":
        failures.append("the game's own code is custom even when its source drifted")
    if classify("__Generated", recovered=True, fingerprint=None, in_manifest=False, vendored=False)[0] != "GENERATED":
        failures.append("__Generated is the build's")
    for failure in failures:
        print("FAIL", failure)
    print(f"self-test: {6 - len(failures)}/6")
    return 1 if failures else 0


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("game", nargs="?")
    parser.add_argument("--log")
    parser.add_argument("--source")
    parser.add_argument("--provenance")
    parser.add_argument("--json")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()
    if args.self_test:
        return self_test()

    result = build(pathlib.Path(args.game), args.log, pathlib.Path(args.source) if args.source else None, args.provenance)
    for row in result["rows"]:
        if row["category"] in ("BUILTIN_UNITY",):
            continue
        print(f"{row['category']:<26} {row['export'] or '-':<9} {row['assembly'] or '-':<36} {row['package'] or '-':<34} "
              f"version={row['version']}")
    print(json.dumps(result["by_category"], sort_keys=True))
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(result, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
