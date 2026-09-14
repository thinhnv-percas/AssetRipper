#!/usr/bin/env python3
"""Checks a generated Unity project for the things that stop it opening, importing or running.

This is not a file-existence check. Unity opens almost anything: a project whose every asset is
present and whose every reference is dangling opens, imports, and runs as an empty scene with a
console full of warnings. So each check here asks whether a *reference* has a target, or whether a
declaration a later stage depends on is actually there - and states its verdict as PASS, FAIL,
WARN or NOT_RUN, never as a count that could be read either way.

Usage: validate_unity_project.py <project root> [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

GUID_REFERENCE = re.compile(r"guid: (?P<guid>[0-9a-f]{32}), type: (?P<type>\d+)")

# Unity's own built-in resources. Nothing in a project declares these and nothing should: the editor
# resolves them internally, and every default material, mesh and cookie names one. Counting them as
# broken links reports 22 failures on a project whose materials are fine.
BUILTIN_GUIDS = {
    "0000000000000000f000000000000000",  # built-in extra resources: Default-Diffuse, Sprites/Default...
    "0000000000000000e000000000000000",  # built-in resources: Cube, Sphere, default cookies...
}
META_GUID = re.compile(r"^guid: (?P<guid>[0-9a-f]{32})", re.MULTILINE)
SCRIPT_NULL = re.compile(r"^\s*m_Script: \{fileID: 0\}", re.MULTILINE)
DOCUMENTS = (".unity", ".prefab", ".asset", ".mat", ".controller", ".anim")

# A shader every material falls back to is not a recovered shader. The stand-in exporter writes one
# replacement pass for every shader in the game, and it compiles - so a material using it is not
# pink and a check that looks for pink reports success while the shading is wrong.
DUMMY_SHADER_MARK = "mul(unity_MatrixVP, mul(unity_ObjectToWorld"


COMPONENT_DECLARATION = re.compile(
    r"^\s*(?:public|internal)\s+(?:sealed\s+|abstract\s+|partial\s+)*class\s+\w+[^:\n]*:\s*"
    r"(?:[\w.]*\b(?:MonoBehaviour|ScriptableObject|UIBehaviour|StateMachineBehaviour|Graphic|Selectable)\b)",
    re.MULTILINE)

GENERIC_DECLARATION = re.compile(r"^\s*(?:public|internal)\s+(?:sealed\s+|abstract\s+|partial\s+)*class\s+\w+<", re.MULTILINE)


class Report:
    def __init__(self):
        self.rows = []

    def add(self, area, verdict, detail):
        self.rows.append({"area": area, "verdict": verdict, "detail": detail})

    def print(self):
        width = max((len(row["area"]) for row in self.rows), default=0)
        for row in self.rows:
            print(f"{row['verdict']:<8} {row['area']:<{width}}  {row['detail']}")
        print()
        for verdict, count in collections.Counter(row["verdict"] for row in self.rows).most_common():
            print(f"{count:4d}  {verdict}")


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root", help="the folder holding Assets/, ProjectSettings/ and Packages/")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    report = Report()

    assets = root / "Assets"
    settings = root / "ProjectSettings"
    packages = root / "Packages"

    for name, folder in (("Assets", assets), ("ProjectSettings", settings), ("Packages", packages)):
        report.add(f"structure/{name}", "PASS" if folder.is_dir() else "FAIL",
                   str(folder) if folder.is_dir() else "missing")

    version = settings / "ProjectVersion.txt"
    if version.is_file():
        text = version.read_text(encoding="utf-8", errors="replace").strip()
        editor = text.split("m_EditorVersion:", 1)[-1].strip().splitlines()[0] if "m_EditorVersion:" in text else ""
        report.add("structure/ProjectVersion", "PASS" if editor else "FAIL", editor or "no m_EditorVersion line")
    else:
        report.add("structure/ProjectVersion", "FAIL", "missing - the editor cannot pick a version to open with")

    manifest = packages / "manifest.json"
    if manifest.is_file():
        try:
            dependencies = json.loads(manifest.read_text(encoding="utf-8")).get("dependencies", {})
            report.add("packages/manifest", "PASS", f"{len(dependencies)} dependencies")
        except json.JSONDecodeError as error:
            report.add("packages/manifest", "FAIL", f"not valid JSON: {error}")
    else:
        report.add("packages/manifest", "FAIL", "missing")

    if not assets.is_dir():
        report.print()
        return 1

    # Every GUID any document names, against every GUID a .meta declares. A reference to a GUID no
    # meta declares is a broken link whatever kind of asset it points at.
    declared = set()
    for meta in assets.rglob("*.meta"):
        match = META_GUID.search(meta.read_text(encoding="utf-8", errors="replace"))
        if match:
            declared.add(match["guid"])

    referenced = collections.Counter()
    null_scripts = 0
    documents = 0
    for document in (path for suffix in DOCUMENTS for path in assets.rglob(f"*{suffix}")):
        documents += 1
        text = document.read_text(encoding="utf-8", errors="replace")
        for match in GUID_REFERENCE.finditer(text):
            referenced[match["guid"]] += 1
        null_scripts += len(SCRIPT_NULL.findall(text))

    dangling = {
        guid: count for guid, count in referenced.items()
        if guid not in declared and guid not in BUILTIN_GUIDS
    }
    builtin = sum(count for guid, count in referenced.items() if guid in BUILTIN_GUIDS)

    # A GUID with no .meta here is not necessarily broken: a package asset's GUID lives in the
    # package, which is not in this folder. Without an editor to resolve the manifest, the two cannot
    # be told apart - so this is UNKNOWN rather than FAIL, which is a verdict about the check and not
    # about the project.
    report.add("references/guids", "PASS" if not dangling else "UNKNOWN",
               f"{len(referenced)} distinct GUIDs across {documents} documents; {builtin} sites name Unity's own "
               f"built-in resources and resolve in the editor; {len(dangling)} GUIDs ({sum(dangling.values())} sites) "
               "are declared by no .meta here and may belong to a package or to nothing")
    report.add("references/m_Script", "PASS" if null_scripts == 0 else "FAIL",
               f"{null_scripts} MonoBehaviour(s) with a null script pointer - each loses its component and every field on it")

    scripts = list((assets / "Scripts").rglob("*.cs")) if (assets / "Scripts").is_dir() else []
    metas = list((assets / "Scripts").rglob("*.cs.meta")) if (assets / "Scripts").is_dir() else []
    report.add("scripts/present", "PASS" if scripts else "FAIL", f"{len(scripts)} .cs files")

    # A plain class needs no GUID and gets no .cs.meta, so comparing the two counts reports 369
    # failures on a project with none. What must have one is a type something can reference as a
    # MonoScript: a non-generic MonoBehaviour or ScriptableObject. A generic one cannot be a
    # component at all, so it correctly has none either.
    behaviours = []
    for path in scripts:
        head = path.read_text(encoding="utf-8", errors="replace")[:4000]
        if COMPONENT_DECLARATION.search(head) and not GENERIC_DECLARATION.search(head):
            behaviours.append(path)

    # And even a non-generic component type legitimately has none when nothing ever serialized it:
    # a hook added by AddComponent at runtime is never a MonoScript in the game's data, so the rip
    # has no GUID to write. Whether that is the case here cannot be decided without asking what
    # references it - which references/guids above already does - so this is a WARN, not a FAIL.
    without = [path for path in behaviours if not path.with_suffix(".cs.meta").is_file()]
    report.add("scripts/meta", "PASS" if not without else "WARN",
               f"{len(metas)} .cs.meta for {len(scripts)} .cs; of the {len(behaviours)} non-generic component types, "
               f"{len(without)} have none - legitimate for one only ever added at runtime"
               + (f" (e.g. {without[0].name})" if without else ""))

    shaders = list(assets.rglob("*.shader"))
    if not shaders:
        report.add("shaders/recovered", "NOT_RUN", "no .shader files in the project")
    else:
        dummy = sum(1 for path in shaders if DUMMY_SHADER_MARK in path.read_text(encoding="utf-8", errors="replace"))
        verdict = "PASS" if dummy == 0 else "WARN"
        report.add("shaders/recovered", verdict,
                   f"{len(shaders)} shaders, {dummy} carry the stand-in unlit pass. A stand-in COMPILES, so the "
                   "material is not pink and a pink check would report success while the shading is wrong")

    scenes = list(assets.rglob("*.unity"))
    report.add("scenes/present", "PASS" if scenes else "WARN", f"{len(scenes)} scene(s)")

    build = settings / "EditorBuildSettings.asset"
    if build.is_file():
        listed = build.read_text(encoding="utf-8", errors="replace").count("- enabled:")
        report.add("scenes/buildSettings", "PASS" if listed else "WARN",
                   f"{listed} scene(s) in the build list - with none, a player build starts on an empty scene")
    else:
        report.add("scenes/buildSettings", "WARN", "no EditorBuildSettings.asset")

    report.add("import/unity", "NOT_RUN", "no Unity editor on this machine; NOT_RUN is not PASS")
    report.add("build/unity", "NOT_RUN", "idem")
    report.add("runtime/unity", "NOT_RUN", "idem")

    report.print()

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report.rows, indent=2))

    return 1 if any(row["verdict"] == "FAIL" for row in report.rows) else 0


if __name__ == "__main__":
    sys.exit(main())
