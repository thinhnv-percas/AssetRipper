#!/usr/bin/env python3
"""Which version of each package a build shipped, from every source that can say - reported separately.

A source checkout states a package's version in up to three places that need not agree: the manifest
(what was asked for), the lock file (what the resolver chose, and at what depth - a direct dependency is
depth 0), and the editor's PackageCache (what was actually on disk). None of them is the build. The build
is evidence only through a fingerprint: the declarations a shipped assembly carries against the package's
own, and for a package that ships a precompiled DLL, whether the candidate versions' DLLs even differ.

A version is reported only when the build's fingerprint is established and every source agrees. A
disagreement is reported as a conflict with each side's value, and the version is UNKNOWN - or, where the
candidates' payloads are byte-identical, the candidate set, because then no fingerprint of the build could
ever choose between them.

    package_manifest_reconstruction.py <source checkout> --provenance <jellyblast-provenance.json>
        [--registry <dir with <version>/package/ extracted>] [--json out] [--self-test]
"""
import hashlib
import json
import pathlib
import sys

# package -> the build assembly whose fingerprint speaks for it
PACKAGES = {
    "com.unity.textmeshpro": "Unity.TextMeshPro",
    "com.unity.ugui": "UnityEngine.UI",
    "com.unity.mathematics": "Unity.Mathematics",
    "com.unity.visualscripting": "Unity.VisualScripting.Core",
    "com.unity.burst": "Unity.Burst",
    "com.unity.collections": "Unity.Collections",
    "com.unity.nuget.newtonsoft-json": "Newtonsoft.Json",
}
PROVEN = {"PROVEN_BUILD_MATCH", "LIKELY_MATCH"}


def payload_hashes(package_dir):
    """sha256 of every DLL a package ships, by path inside the package."""
    return {str(p.relative_to(package_dir)): hashlib.sha256(p.read_bytes()).hexdigest()
            for p in sorted(package_dir.rglob("*.dll"))}


def reconstruct(source, provenance, registry=None):
    source = pathlib.Path(source)
    manifest = json.loads((source / "Packages" / "manifest.json").read_text())["dependencies"]
    lock_path = source / "Packages" / "packages-lock.json"
    lock = json.loads(lock_path.read_text())["dependencies"] if lock_path.exists() else {}
    cache_dir = source / "Library" / "PackageCache"
    cache = {}
    if cache_dir.is_dir():
        for entry in cache_dir.iterdir():
            if "@" in entry.name:
                name, _, version = entry.name.partition("@")
                cache.setdefault(name, []).append(version)
    fingerprints = {row["assembly"]: row for row in provenance}

    rows = []
    for package, assembly in PACKAGES.items():
        locked = lock.get(package, {})
        fingerprint = fingerprints.get(assembly, {})
        row = {
            "package": package,
            "manifest_version": manifest.get(package),
            "lock_version": locked.get("version"),
            "lock_depth": locked.get("depth"),
            "cache_versions": sorted(cache.get(package, [])),
            "build_assembly": assembly,
            "build_declares_assembly": bool(fingerprint),
            "compiled_fingerprint": fingerprint.get("status", "NOT_IN_BUILD"),
            "payload_identical_versions": None,
            "conflicts": [],
            "version": "UNKNOWN",
            "reason": "",
        }

        stated = {k: v for k, v in (("manifest", row["manifest_version"]), ("lock", row["lock_version"]))
                  if v is not None}
        for version in row["cache_versions"]:
            stated.setdefault("cache", version)
        if len(set(stated.values())) > 1:
            row["conflicts"].append(", ".join(f"{k}={v}" for k, v in stated.items()))
        if row["manifest_version"] and row["lock_depth"] not in (None, 0):
            row["conflicts"].append(f"the manifest pins it directly but the lock resolved it at depth {row['lock_depth']} - the two files describe different resolutions")

        if registry and len(set(stated.values())) > 1:
            versions = sorted(set(stated.values()))
            hashes = {v: payload_hashes(pathlib.Path(registry) / v / "package") for v in versions
                      if (pathlib.Path(registry) / v / "package").is_dir()}
            if len(hashes) == len(versions) and len({json.dumps(h, sort_keys=True) for h in hashes.values()}) == 1 and next(iter(hashes.values())):
                row["payload_identical_versions"] = versions

        if row["compiled_fingerprint"] in PROVEN and not row["conflicts"] and len(set(stated.values())) == 1:
            row["version"] = next(iter(stated.values()))
            row["reason"] = "fingerprint establishes the build ships this package, and manifest, lock and cache agree"
        elif row["payload_identical_versions"]:
            row["version"] = "UNKNOWN"
            row["candidates"] = row["payload_identical_versions"]
            row["reason"] = "the candidate versions ship byte-identical DLLs, so no fingerprint of the build can choose; sources disagree"
        elif row["compiled_fingerprint"] not in PROVEN:
            row["reason"] = f"the build's fingerprint is {row['compiled_fingerprint']}, so no stated version is established"
        else:
            row["reason"] = "sources disagree"
        rows.append(row)
    return rows


def self_test():
    import tempfile
    failures = 0
    with tempfile.TemporaryDirectory() as tmp:
        root = pathlib.Path(tmp)
        (root / "Packages").mkdir()
        (root / "Packages" / "manifest.json").write_text(json.dumps({"dependencies": {"com.unity.nuget.newtonsoft-json": "3.2.1", "com.unity.mathematics": "1.2.6"}}))
        (root / "Packages" / "packages-lock.json").write_text(json.dumps({"dependencies": {
            "com.unity.nuget.newtonsoft-json": {"version": "3.2.2", "depth": 2}, "com.unity.mathematics": {"version": "1.2.6", "depth": 0}}}))
        (root / "Library" / "PackageCache" / "com.unity.mathematics@1.2.6").mkdir(parents=True)
        for v in ("3.2.1", "3.2.2"):
            d = root / "reg" / v / "package"
            d.mkdir(parents=True)
            (d / "N.dll").write_bytes(b"same")
        provenance = [{"assembly": "Unity.Mathematics", "status": "PROVEN_BUILD_MATCH"}, {"assembly": "Newtonsoft.Json", "status": "NO_SOURCE"}]
        rows = {r["package"]: r for r in reconstruct(root, provenance, root / "reg")}
        checks = [
            ("agreeing sources with a proven fingerprint give the version", rows["com.unity.mathematics"]["version"] == "1.2.6"),
            ("disagreeing sources give UNKNOWN", rows["com.unity.nuget.newtonsoft-json"]["version"] == "UNKNOWN"),
            ("identical payloads are reported as the candidate set", rows["com.unity.nuget.newtonsoft-json"].get("candidates") == ["3.2.1", "3.2.2"]),
            ("a direct pin resolved at depth 2 is a conflict", any("depth 2" in c for c in rows["com.unity.nuget.newtonsoft-json"]["conflicts"])),
        ]
        for name, ok in checks:
            failures += not ok
            print(f"{'PASS' if ok else 'FAIL'} {name}")
        print(f"{len(checks) - failures} of {len(checks)} pass")
    return 1 if failures else 0


def main(argv):
    if "--self-test" in argv:
        return self_test()
    if len(argv) < 2 or "--provenance" not in argv:
        print(__doc__)
        return 2
    provenance = json.loads(pathlib.Path(argv[argv.index("--provenance") + 1]).read_text())
    registry = argv[argv.index("--registry") + 1] if "--registry" in argv else None
    rows = reconstruct(argv[1], provenance, registry)
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(rows, indent=1))
    for row in rows:
        print(f"{row['package']:34} manifest={row['manifest_version']} lock={row['lock_version']}(depth {row['lock_depth']}) "
              f"cache={row['cache_versions']} fingerprint={row['compiled_fingerprint']} -> version={row['version']}"
              + (f" candidates={row.get('candidates')}" if row.get("candidates") else ""))
        for conflict in row["conflicts"]:
            print(f"    conflict: {conflict}")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
