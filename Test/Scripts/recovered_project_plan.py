#!/usr/bin/env python3
"""The project generator's plan, read from RecoveredProjectManifest.json rather than re-derived.

Iteration 065, §13: the manifest is the input. Every item it states is checked against the exported
project or turned into an action, and an action is APPLIED only where the export already carries what the
manifest says (a check), PLANNED where the evidence is complete but the change is not made here, and
BLOCKED where it is not - with the manifest's own reason. Nothing is dropped to make a project compile: a
package whose version is UNKNOWN stays a blocked declaration, never an omission.

    recovered_project_plan.py <RecoveredProjectManifest.json> <game dir> [--out plan.json]
"""
import json
import pathlib
import re
import sys


def plan(manifest, game):
    game = pathlib.Path(game)
    actions = []

    version_file = game / "ProjectSettings" / "ProjectVersion.txt"
    exported = re.search(r"m_EditorVersion: (\S+)", version_file.read_text()).group(1) if version_file.exists() else None
    wanted = manifest["unity_version"]["build"]
    actions.append({"item": "unity_version", "want": wanted, "have": exported,
                    "status": "APPLIED" if exported == wanted else "BLOCKED",
                    "reason": "ProjectVersion.txt states the build's version" if exported == wanted else "ProjectVersion.txt disagrees with the build"})

    actions.append({"item": "target_platform", "want": manifest["target_platform"]["platform"],
                    "status": "PLANNED", "reason": "the editor's build target is set when the project is opened (UnityBuildValidator)"})

    exported_packages = json.loads((game / "Packages" / "manifest.json").read_text()).get("dependencies", {}) if (game / "Packages" / "manifest.json").exists() else {}
    for name, package in sorted(manifest["packages"].items()):
        if package["category"] in ("BUILTIN_UNITY", "NOT_IN_BUILD", "CUSTOM", "GENERATED"):
            continue
        version = package.get("version")
        declared = exported_packages.get(name)
        if declared:
            actions.append({"item": f"package {name}", "want": version, "have": declared, "status": "APPLIED" if declared == version else "BLOCKED",
                            "reason": "declared by the export"})
        elif version and version != "UNKNOWN" and not str(version).startswith("http"):
            actions.append({"item": f"package {name}", "want": version, "status": "PLANNED",
                            "reason": f"declare {name}@{version} and replace the stubbed assemblies {package['assemblies']} with it - the version is proven by fingerprint"})
        else:
            actions.append({"item": f"package {name}", "want": version, "candidates": package.get("version_candidates"),
                            "conflicts": package.get("version_conflicts"), "status": "BLOCKED",
                            "reason": "version not established; the package stays required, not dropped"})

    for node in manifest["native_dependencies"]:
        if node["recoverability"] == "NOT_REQUIRED":
            continue
        status = {"PRESERVED": "APPLIED", "PRESERVED_FROM_VERIFIED_ARTIFACT": "APPLIED"}.get(node["recoverability"], "BLOCKED")
        actions.append({"item": f"native {node['library']}", "status": status, "recoverability": node["recoverability"], "reason": node["evidence"]})

    shaders = manifest.get("shaders") or {}
    actions.append({"item": "shader programs", "status": "PLANNED" if shaders.get("external_programs") else "APPLIED",
                    "reason": json.dumps(shaders.get("program_encodings"), sort_keys=True)})
    actions.append({"item": "runtime", "status": "BLOCKED", "reason": manifest.get("runtime_status", "NOT_RUN") + ": UNITY_NOT_AVAILABLE"})

    counts = {}
    for action in actions:
        counts[action["status"]] = counts.get(action["status"], 0) + 1
    return {"schema": "RecoveredProjectPlan/1", "from": manifest["schema"], "actions": actions, "counts": counts}


def main(argv):
    if len(argv) < 3:
        print(__doc__)
        return 2
    manifest = json.loads(pathlib.Path(argv[1]).read_text())
    result = plan(manifest, argv[2])
    if "--out" in argv:
        pathlib.Path(argv[argv.index("--out") + 1]).write_text(json.dumps(result, indent=1))
    for action in result["actions"]:
        print(f"{action['status']:8} {action['item']:48} {str(action.get('reason'))[:110]}")
    print(result["counts"])
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
