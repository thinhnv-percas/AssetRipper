#!/usr/bin/env python3
"""Packages, player settings and native plugins: the build, the source and the recovery side by side.

Iteration 063. A method oracle says whether code came back; this says whether the *project* around it
did - which packages the build shipped and at what version, the player settings, and the native
libraries a P/Invoke will need. Three witnesses, ranked:

  build      the shipped package itself: its assemblies (which packages it compiled), its Info.plist
             (bundle id, versions, minimum OS) and its Frameworks folder. This is the reference - it is
             what actually ran.
  source     the checkout. For JellyBlast it is derived from this very build and then edited, so it is a
             witness, not the reference; where it disagrees with the build, the build wins.
  recovered  the rip.

Package status:
  RECOVERED                 in the build and in the recovered manifest
  MISSING_FROM_RECOVERED    the build compiled it (its assembly is present); the recovered manifest lacks it
  NOT_IN_BUILD              in the source manifest, no assembly in the build - unused, editor-only, or stripped
  VERSION_UNKNOWN           in the build, but nothing here establishes the version
Version, where the source declares one: CONSISTENT (declarations match the build, `build_provenance.py`)
or DIFFERENT (they do not) - never changed to make anything compile (brief §19).

Setting status: MATCH / DIFFERENT / UNKNOWN (a side does not state it). The build's Info.plist answers for
the few settings it carries, and is authoritative for those.

Usage: project_oracle.py <build input dir> <source checkout> <recovered game dir> [--provenance json] [--json out]
"""
import argparse
import collections
import json
import pathlib
import plistlib
import re
import sys

# Build assembly -> the package that compiles it. Read from the source's package cache when present
# (an asmdef's name and the package directory holding it); these are the fallbacks for packages whose
# assemblies are not asmdefs in any cache.
KNOWN_ASSEMBLY_PACKAGES = {
    "UnityEngine.UI": "com.unity.ugui",
    "Newtonsoft.Json": "com.unity.nuget.newtonsoft-json",
}

# Player settings worth a verdict: identity, versions, rendering and scripting. Top-level scalars only.
SETTINGS = ("companyName", "productName", "bundleVersion", "defaultScreenOrientation", "m_ActiveColorSpace",
            "iOSTargetOSVersionString", "apiCompatibilityLevel", "accelerometerFrequency", "runInBackground",
            "m_StereoRenderingPath", "gpuSkinning", "graphicsJobs", "useOnDemandResources",
            "stripEngineCode", "iPhoneStrippingLevel", "iPhoneScriptCallOptimization", "allowedAutorotateToPortrait",
            "allowedAutorotateToLandscapeLeft", "defaultScreenWidth", "defaultScreenHeight", "targetDevice",
            "uIRequiresFullScreen", "uIStatusBarHidden", "uIExitOnSuspend", "appleDeveloperTeamID",
            "iOSRequireARKit", "m_MTRendering", "mipStripping", "resetResolutionOnWindowResize")


def build_assemblies(build_dir):
    """Assembly names the build shipped, from the rip's metadata stubs beside it if given, else from the IPA."""
    names = set()
    for dll in pathlib.Path(build_dir).rglob("*.dll"):
        names.add(dll.stem)
    return names


def package_of_assembly(checkout):
    """asmdef name -> package directory name (without @version), from the source's package cache."""
    found = {}
    cache = pathlib.Path(checkout) / "Library" / "PackageCache"
    for asmdef in cache.rglob("*.asmdef"):
        try:
            name = json.loads(asmdef.read_text(encoding="utf-8-sig")).get("name")
        except (OSError, ValueError):
            continue
        package = asmdef.relative_to(cache).parts[0].split("@")[0]
        if name:
            found.setdefault(name, package)
    found.update({k: v for k, v in KNOWN_ASSEMBLY_PACKAGES.items() if k not in found})
    return found


def manifest(path):
    try:
        return json.loads(pathlib.Path(path).read_text()).get("dependencies", {})
    except (OSError, ValueError):
        return {}


def player_settings(path):
    values = {}
    try:
        text = pathlib.Path(path).read_text(encoding="utf-8", errors="replace")
    except OSError:
        return values
    for line in text.splitlines():
        match = re.match(r"^  ([A-Za-z_][\w]*): (.*)$", line)
        if match:
            values.setdefault(match.group(1), match.group(2).strip())
    return values


def info_plist(build_dir):
    for plist in pathlib.Path(build_dir).glob("Payload/*.app/Info.plist"):
        with open(plist, "rb") as handle:
            return plistlib.load(handle)
    return {}


def frameworks(root):
    """Native bundles and libraries, by name, a project or package carries."""
    found = set()
    for pattern in ("*.framework", "*.dylib", "*.a", "*.so", "*.bundle"):
        for path in pathlib.Path(root).rglob(pattern):
            if path.is_dir() or path.is_file():
                found.add(path.name)
    return found


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("build")
    parser.add_argument("source")
    parser.add_argument("recovered")
    parser.add_argument("--build-assemblies", help="directory of the build's assemblies (the rip's AuxiliaryFiles/GameAssemblies)")
    parser.add_argument("--provenance", help="build_provenance.py JSON, for version consistency")
    parser.add_argument("--json")
    args = parser.parse_args()

    build, source, recovered = map(pathlib.Path, (args.build, args.source, args.recovered))
    shipped = build_assemblies(args.build_assemblies or build)
    owners = package_of_assembly(source)
    source_manifest = manifest(source / "Packages" / "manifest.json")
    recovered_manifest = manifest(recovered / "Packages" / "manifest.json")
    provenance = {}
    if args.provenance:
        provenance = {row["assembly"]: row["status"] for row in json.loads(pathlib.Path(args.provenance).read_text())}

    # --- packages
    evidenced = collections.defaultdict(list)
    for assembly in sorted(shipped):
        if assembly in owners:
            evidenced[owners[assembly]].append(assembly)
    packages = []
    for package in sorted(set(evidenced) | {p for p in source_manifest if not p.startswith("com.unity.modules.")}):
        in_build = package in evidenced
        row = {"package": package, "buildAssemblies": evidenced.get(package, []),
               "sourceVersion": source_manifest.get(package), "recoveredVersion": recovered_manifest.get(package)}
        if not in_build:
            row["status"] = "NOT_IN_BUILD"
        elif package in recovered_manifest:
            row["status"] = "RECOVERED"
        else:
            row["status"] = "MISSING_FROM_RECOVERED"
        if in_build and row["sourceVersion"] is not None:
            statuses = {provenance.get(a) for a in evidenced[package]} - {None}
            if statuses and statuses <= {"PROVEN_BUILD_MATCH", "LIKELY_MATCH"}:
                row["version"] = "CONSISTENT"
            elif "SOURCE_MISMATCH" in statuses:
                row["version"] = "DIFFERENT"
            else:
                row["version"] = "VERSION_UNKNOWN"
        elif in_build:
            row["version"] = "VERSION_UNKNOWN"
        packages.append(row)

    # --- settings
    src_settings = player_settings(source / "ProjectSettings" / "ProjectSettings.asset")
    rec_settings = player_settings(recovered / "ProjectSettings" / "ProjectSettings.asset")
    settings = []
    for key in SETTINGS:
        a, b = src_settings.get(key), rec_settings.get(key)
        status = "UNKNOWN" if a is None or b is None else ("MATCH" if a == b else "DIFFERENT")
        settings.append({"setting": key, "source": a, "recovered": b, "status": status})

    # The build's own statement, for the settings it carries.
    plist = info_plist(build)
    plist_checks = []
    if plist:
        for key, setting, source_value, recovered_value in (
                ("CFBundleShortVersionString", "bundleVersion", src_settings.get("bundleVersion"), rec_settings.get("bundleVersion")),
                ("MinimumOSVersion", "iOSTargetOSVersionString", src_settings.get("iOSTargetOSVersionString"),
                 rec_settings.get("iOSTargetOSVersionString")),
                ("CFBundleDisplayName", "productName", src_settings.get("productName"), rec_settings.get("productName"))):
            truth = plist.get(key)
            plist_checks.append({"plist": key, "build": truth, "setting": setting,
                                 "source": "MATCH" if source_value == truth else ("UNKNOWN" if source_value is None else "DIFFERENT"),
                                 "recovered": "MATCH" if recovered_value == truth else ("UNKNOWN" if recovered_value is None else "DIFFERENT"),
                                 "sourceValue": source_value, "recoveredValue": recovered_value})
        # The bundle identifier is per platform in the asset, as a map; say what each side holds.
        plist_checks.append({"plist": "CFBundleIdentifier", "build": plist.get("CFBundleIdentifier"),
                             "setting": "applicationIdentifier",
                             "sourceValue": src_settings.get("applicationIdentifier"),
                             "recoveredValue": rec_settings.get("applicationIdentifier")})

    # --- native
    shipped_native = {n for n in frameworks(build / "Payload") if not n.startswith(("UnityFramework", "libswift"))}
    native = []
    for name in sorted(shipped_native | frameworks(source / "Assets")):
        native.append({"library": name, "inBuild": name in shipped_native,
                       "inSource": name in frameworks(source / "Assets"),
                       "inRecovered": name in frameworks(recovered / "Assets")})

    print("== packages (build evidence: an assembly the package compiles is in the build)")
    for row in packages:
        print(f"  {row['status']:24} {row['package']:44} source {row['sourceVersion'] or '-':>8}  "
              f"recovered {row['recoveredVersion'] or '-':>8}  version {row.get('version', '-'):16} "
              f"{','.join(row['buildAssemblies'])}")
    print("  " + json.dumps(collections.Counter(r["status"] for r in packages)))
    print("== player settings (source vs recovered)")
    for row in settings:
        if row["status"] != "MATCH":
            print(f"  {row['status']:10} {row['setting']:32} source={row['source']!s:24} recovered={row['recovered']}")
    print("  " + json.dumps(collections.Counter(r["status"] for r in settings)))
    print("== the build's Info.plist")
    for row in plist_checks:
        print(f"  {row['plist']:28} build={row['build']!s:22} source={row.get('source', '-'):9} ({row['sourceValue']}) "
              f"recovered={row.get('recovered', '-'):9} ({row['recoveredValue']})")
    print("== native libraries")
    for row in native:
        print(f"  build={'Y' if row['inBuild'] else '-'} source={'Y' if row['inSource'] else '-'} "
              f"recovered={'Y' if row['inRecovered'] else '-'}  {row['library']}")

    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(
            {"packages": packages, "settings": settings, "infoPlist": plist_checks, "native": native}, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
