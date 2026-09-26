#!/usr/bin/env python3
"""Which shaders in a build have source to be compared against, and where that source is.

Every shader verdict in this project was capped at "the structure came back" on the stated ground
that no fixture ships source shaders. That was never checked against the fixtures. Three of the four
carry the source of the packages they embed - TextMesh Pro, Spine, post-processing, Feel - and the
build compiled exactly those, so an oracle exists and always did.

For each shader the build carries, this reports:

  name              as the asset declares it
  guid              from the source `.shader.meta`, when the source is in the tree
  source            the path of the `.shader` that declares that name
  build_presence    EXPORTED (a `.shader` came out), IN_BUILD_NOT_EXPORTED, or NOT_IN_BUILD
  material_usage    how many exported materials name it
  programs          how many compiled sub-programs were read out of it, and how many as source text

A source tree routinely holds shaders a build excluded, and a build routinely holds shaders whose
source is in a package rather than in `Assets/`. Both are reported as what they are rather than as a
gap - a package's source can be fetched at the version `manifest.json` pins, which is what
`--package-root` is for.

Usage: shader_source_discovery.py <rip output> <source root>... [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import shader_semantic_ir as ir  # noqa: E402

GUID = re.compile(r"^guid:\s*([0-9a-f]{32})", re.M)
MATERIAL_SHADER = re.compile(r"m_Shader:\s*\{fileID:\s*(-?\d+),\s*guid:\s*([0-9a-f]{32})")


def source_index(roots: list[pathlib.Path]) -> dict:
    """{declared shader name: {path, guid}} over every `.shader` in the given trees."""
    found = {}

    for root in roots:
        for path in root.rglob("*.shader"):
            name = ir.source_shader_name(path)

            if not name or name in found:
                continue

            meta = path.with_suffix(path.suffix + ".meta")
            guid = None

            if meta.is_file():
                match = GUID.search(meta.read_text(encoding="utf-8", errors="replace"))
                guid = match[1] if match else None

            found[name] = {"path": str(path), "guid": guid}

    return found


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("rip")
    parser.add_argument("sources", nargs="+")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    rip = pathlib.Path(arguments.rip)
    sources = source_index([pathlib.Path(path) for path in arguments.sources])

    exported = {}

    for path in rip.rglob("Assets/Shader/*.shader"):
        text = path.read_text(encoding="utf-8", errors="replace")
        match = re.search(r'Shader\s+"([^"]+)"', text)

        if match:
            exported[match[1]] = path

    # Materials name a shader by GUID; the exported `.shader.meta` is what gives the GUID a name.
    guid_to_name = {}

    for name, path in exported.items():
        meta = path.with_suffix(path.suffix + ".meta")

        if meta.is_file():
            found = GUID.search(meta.read_text(encoding="utf-8", errors="replace"))
            if found:
                guid_to_name[found[1]] = name

    usage = collections.Counter()

    for material in rip.rglob("*.mat"):
        for _file_id, guid in MATERIAL_SHADER.findall(
                material.read_text(encoding="utf-8", errors="replace")):
            if guid in guid_to_name:
                usage[guid_to_name[guid]] += 1

    report = rip / "AuxiliaryFiles" / "ShaderPrograms.json"
    programs = collections.Counter()
    source_programs = collections.Counter()

    if report.is_file():
        for record in json.loads(report.read_text()):
            programs[record.get("shader", "")] += 1
            if record.get("encoding") == "SOURCETEXT":
                source_programs[record.get("shader", "")] += 1

    rows = []

    for name in sorted(set(exported) | set(programs)):
        source = sources.get(name)
        rows.append({
            "name": name,
            "guid": source["guid"] if source else None,
            "source": source["path"] if source else None,
            "build_presence": "EXPORTED" if name in exported else "IN_BUILD_NOT_EXPORTED",
            "material_usage": usage[name],
            "programs": programs[name],
            "source_text_programs": source_programs[name],
        })

    for name in sorted(set(sources) - set(exported) - set(programs)):
        rows.append({
            "name": name,
            "guid": sources[name]["guid"],
            "source": sources[name]["path"],
            "build_presence": "NOT_IN_BUILD",
            "material_usage": 0,
            "programs": 0,
            "source_text_programs": 0,
        })

    with_source = sum(1 for row in rows if row["source"] and row["build_presence"] == "EXPORTED")
    exported_count = sum(1 for row in rows if row["build_presence"] == "EXPORTED")

    print(f"shaders in the build      {len(set(exported) | set(programs))}")
    print(f"  exported as ShaderLab   {exported_count}")
    print(f"  with source to compare  {with_source}")
    print(f"source shaders not built  {sum(1 for row in rows if row['build_presence'] == 'NOT_IN_BUILD')}")
    print(f"materials naming a shader {sum(usage.values())}")
    print(f"sub-programs read         {sum(programs.values())} ({sum(source_programs.values())} as source text)")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(rows, indent=1))

    return 0


if __name__ == "__main__":
    sys.exit(main())
