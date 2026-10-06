#!/usr/bin/env python3
"""Which of the files a Unity project needs to open an export actually carries, and with what provenance.

Iteration 066 (brief §12). A recovered project is opened by an editor that reads `Packages/manifest.json`, may
read `Packages/packages-lock.json`, imports `Assets/Plugins/<platform>`, and reads `ProjectSettings/`. This lists
each for one rip and says, per item, PRESENT / ABSENT and - for package versions - where the version came from.
It writes nothing and invents nothing: a package the export does not declare is ABSENT here, not given a version.

  - `com.unity.modules.*` are the engine's built-in modules; Unity versions them all 1.0.0, so that version is a
    fact of the editor, not a reconstruction.
  - any other dependency in the manifest is reported with the version written, as EXPORTER_WRITTEN, because this
    tool cannot tell how the exporter chose it; package_manifest_reconstruction.py is the tool that proves versions.

    project_artifact_check.py <rip game dir> [--json out.json]
"""
import json
import pathlib
import sys


def check(root: pathlib.Path):
    report = {"root": str(root)}
    manifest = root / "Packages" / "manifest.json"
    if manifest.exists():
        dependencies = json.loads(manifest.read_text()).get("dependencies", {})
        modules = {name: version for name, version in dependencies.items() if name.startswith("com.unity.modules.")}
        others = {name: version for name, version in dependencies.items() if not name.startswith("com.unity.modules.")}
        report["manifest"] = {"status": "PRESENT", "builtInModules": len(modules),
                              "builtInModuleVersions": sorted(set(modules.values())),
                              "packages": {name: {"version": version, "provenance": "EXPORTER_WRITTEN"} for name, version in others.items()}}
    else:
        report["manifest"] = {"status": "ABSENT"}
    report["packagesLock"] = {"status": "PRESENT" if (root / "Packages" / "packages-lock.json").exists() else "ABSENT"}

    plugins = root / "Assets" / "Plugins"
    report["plugins"] = {}
    for platform in ("Android", "iOS"):
        folder = plugins / platform
        if not folder.exists():
            report["plugins"][platform] = {"status": "ABSENT"}
            continue
        files = [p for p in folder.rglob("*") if p.is_file() and p.suffix != ".meta"]
        report["plugins"][platform] = {"status": "PRESENT",
                                       "entries": sorted(str(p.relative_to(folder)) for p in folder.iterdir()),
                                       "files": len(files)}

    settings = root / "ProjectSettings"
    version = settings / "ProjectVersion.txt"
    report["projectSettings"] = {
        "status": "PRESENT" if settings.exists() else "ABSENT",
        "files": sorted(p.name for p in settings.iterdir()) if settings.exists() else [],
        "editorVersion": next((line.split(":", 1)[1].strip() for line in version.read_text().splitlines()
                               if line.startswith("m_EditorVersion:")), None) if version.exists() else None,
    }
    return report


def main(argv) -> int:
    if len(argv) < 2:
        print(__doc__)
        return 2
    report = check(pathlib.Path(argv[1]))
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(report, indent=1))
    manifest = report["manifest"]
    print(f'{report["root"]}: manifest {manifest["status"]} '
          f'({manifest.get("builtInModules", 0)} built-in modules {manifest.get("builtInModuleVersions", [])}, '
          f'{len(manifest.get("packages", {}))} other packages); packages-lock {report["packagesLock"]["status"]}; '
          + "; ".join(f'Plugins/{k} {v["status"]}' + (f' {v["entries"]}' if v["status"] == "PRESENT" else "") for k, v in report["plugins"].items())
          + f'; ProjectSettings {report["projectSettings"]["status"]} ({len(report["projectSettings"]["files"])} files, editor {report["projectSettings"]["editorVersion"]})')
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
