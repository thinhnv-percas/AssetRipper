#!/usr/bin/env python3
"""A package cache holding exactly the packages whose version the build proves, and nothing else.

Iteration 067 §11. `PackageRemapPostExporter` already does the substitution properly - it repoints every
script reference to the real package's GUIDs, deletes the ripped copies so no type is declared twice, and
adds the package to `Packages/manifest.json`. It only needs a source. This script is that source, built so
the manifest can only ever receive a version that was proven:

  * a package is taken only when `package_provenance.py` (via the RecoveredProjectManifest) classifies it
    `UPSTREAM_EXACT`, which needs the build's declaration fingerprint to match the package at that version;
  * the version is the one the provenance names, never the source manifest's or the lock file's;
  * the tarball is fetched from the Unity registry and its own `package.json` must state that name and
    that version, or it is rejected;
  * anything else - UNKNOWN, a version mismatch, a package the registry does not carry (a core package
    such as com.unity.ugui 1.0.0 ships inside the editor) - is recorded with its reason and not cached.

`packages-lock.json` is not produced: the only thing that could state its contents is the resolver of a
real editor, so it is reported BLOCKED rather than invented.

    proven_package_cache.py <RecoveredProjectManifest.json> <cache dir> [--json out] [--offline] [--self-test]
"""
import io
import json
import pathlib
import shutil
import sys
import tarfile
import urllib.error
import urllib.request

REGISTRY = "https://packages.unity.com"
PROVEN_CATEGORIES = {"UPSTREAM_EXACT"}


def candidates(manifest):
    """(name, version, evidence) for every package the manifest proves, and every one it does not, with why."""
    proven, rejected = [], []
    for name, row in sorted(manifest.get("packages", {}).items()):
        category = row.get("category")
        version = row.get("version")
        if category in PROVEN_CATEGORIES and version and version != "UNKNOWN":
            proven.append({"name": name, "version": version, "category": category,
                           "evidence": row.get("version_source"), "assemblies": row.get("assemblies", [])})
        elif category != "NOT_IN_BUILD":
            rejected.append({"name": name, "category": category, "version": version,
                             "reason": "NOT_PROVEN" if category not in PROVEN_CATEGORIES else "NO_VERSION"})
    return proven, rejected


def fetch(name, version):
    url = f"{REGISTRY}/{name}/-/{name}-{version}.tgz"
    try:
        with urllib.request.urlopen(url, timeout=120) as response:
            return response.read(), url
    except urllib.error.HTTPError as error:
        return None, f"{url}: HTTP {error.code}"
    except urllib.error.URLError as error:
        return None, f"{url}: {error.reason}"


def extract(blob, name, version, cache):
    """Unpack into <cache>/<name>@<version>, the layout the remap resolver reads; refuse a mismatched package.json."""
    target = cache / f"{name}@{version}"
    with tarfile.open(fileobj=io.BytesIO(blob), mode="r:gz") as archive:
        members = [m for m in archive.getmembers() if m.name.startswith("package/") and ".." not in m.name.split("/")]
        package_json = next((m for m in members if m.name == "package/package.json"), None)
        if package_json is None:
            return None, "NO_PACKAGE_JSON"
        declared = json.loads(archive.extractfile(package_json).read())
        if declared.get("name") != name or declared.get("version") != version:
            return None, f"DECLARES_{declared.get('name')}@{declared.get('version')}"
        if target.exists():
            shutil.rmtree(target)
        target.mkdir(parents=True)
        for member in members:
            relative = member.name[len("package/"):]
            if not relative:
                continue
            destination = target / relative
            if member.isdir():
                destination.mkdir(parents=True, exist_ok=True)
            elif member.isfile():
                destination.parent.mkdir(parents=True, exist_ok=True)
                destination.write_bytes(archive.extractfile(member).read())
    return target, None


def build(manifest, cache, offline=False, fetcher=fetch):
    cache = pathlib.Path(cache)
    cache.mkdir(parents=True, exist_ok=True)
    proven, rejected = candidates(manifest)
    cached = []
    for row in proven:
        existing = cache / f"{row['name']}@{row['version']}" / "package.json"
        if existing.exists() and json.loads(existing.read_text()).get("version") == row["version"]:
            cached.append({**row, "status": "CACHED", "source": str(existing.parent)})
            continue
        if offline:
            rejected.append({**row, "reason": "OFFLINE_NOT_CACHED"})
            continue
        blob, where = fetcher(row["name"], row["version"])
        if blob is None:
            # a core package ships inside the editor and is not on the registry
            rejected.append({**row, "reason": "PROVEN_VERSION_NOT_ON_REGISTRY", "detail": where})
            continue
        target, problem = extract(blob, row["name"], row["version"], cache)
        if problem:
            rejected.append({**row, "reason": problem, "detail": where})
            continue
        cached.append({**row, "status": "FETCHED", "source": where})
    report = {
        "schema": "ProvenPackageCache/1",
        "cache": str(cache),
        "manifest_receives": [{"name": r["name"], "version": r["version"], "category": r["category"],
                               "evidence": r["evidence"], "source": r["source"]} for r in cached],
        "not_in_manifest": rejected,
        "packages_lock": {"status": "BLOCKED",
                          "reason": "only an editor's package resolver can state a lock file; none is available, "
                                    "and a lock file written from the manifest would claim a resolution that never ran"},
    }
    (cache / "provenance.json").write_text(json.dumps(report, indent=1) + "\n")
    return report


def self_test():
    import tempfile
    manifest = {"packages": {
        "com.a": {"category": "UPSTREAM_EXACT", "version": "1.0.0", "version_source": "fingerprint"},
        "com.b": {"category": "UNKNOWN", "version": "UNKNOWN"},
        "com.c": {"category": "UPSTREAM_VERSION_MISMATCH", "version": "UNKNOWN"},
        "com.d": {"category": "NOT_IN_BUILD", "version": "2.0.0"},
        "com.e": {"category": "UPSTREAM_EXACT", "version": "3.0.0", "version_source": "fingerprint"},
        "com.f": {"category": "UPSTREAM_EXACT", "version": "4.0.0", "version_source": "fingerprint"},
    }}

    def tgz(name, version):
        buffer = io.BytesIO()
        with tarfile.open(fileobj=buffer, mode="w:gz") as archive:
            data = json.dumps({"name": name, "version": version}).encode()
            info = tarfile.TarInfo("package/package.json")
            info.size = len(data)
            archive.addfile(info, io.BytesIO(data))
        return buffer.getvalue()

    def fake(name, version):
        if name == "com.e":
            return None, "HTTP 404"
        if name == "com.f":
            return tgz(name, "4.0.1"), "x"  # the registry returned another version than asked
        return tgz(name, version), "x"

    failures = []
    with tempfile.TemporaryDirectory() as directory:
        report = build(manifest, directory, fetcher=fake)
        received = {r["name"]: r["version"] for r in report["manifest_receives"]}
        reasons = {r["name"]: r["reason"] for r in report["not_in_manifest"]}
        cases = [
            ("only a proven version is received", received == {"com.a": "1.0.0"}),
            ("UNKNOWN is never received", "com.b" not in received and reasons.get("com.b") == "NOT_PROVEN"),
            ("a version mismatch is never received", reasons.get("com.c") == "NOT_PROVEN"),
            ("a package not in the build is neither received nor reported", "com.d" not in received and "com.d" not in reasons),
            ("a proven version the registry lacks is reported, not substituted", reasons.get("com.e") == "PROVEN_VERSION_NOT_ON_REGISTRY"),
            ("a tarball declaring another version is refused", reasons.get("com.f", "").startswith("DECLARES_")),
            ("the lock file is BLOCKED, not written", report["packages_lock"]["status"] == "BLOCKED"
             and not (pathlib.Path(directory) / "packages-lock.json").exists()),
            ("the cache uses the resolver's layout", (pathlib.Path(directory) / "com.a@1.0.0" / "package.json").exists()),
        ]
    for label, ok in cases:
        print(("PASS " if ok else "FAIL ") + label)
        if not ok:
            failures.append(label)
    return 1 if failures else 0


def main(argv):
    if "--self-test" in argv:
        return self_test()
    if len(argv) < 2:
        print(__doc__)
        return 2
    manifest = json.loads(pathlib.Path(argv[0]).read_text())
    report = build(manifest, argv[1], offline="--offline" in argv)
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(report, indent=1) + "\n")
    for row in report["manifest_receives"]:
        print(f"MANIFEST {row['name']} {row['version']} ({row['category']})")
    for row in report["not_in_manifest"]:
        print(f"LEFT_OUT {row['name']} {row.get('version')} {row['reason']}")
    print(f"packages-lock.json {report['packages_lock']['status']}")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv[1:]))
