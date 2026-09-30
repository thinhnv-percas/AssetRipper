#!/usr/bin/env python3
"""Every Metal program a rip carries: what it is, where it is, what it computes, and who draws with it.

Iteration 063 (brief §12-§15). The brief expected compiled Metal libraries and asked for them to be
described without being decompiled. Measured on the one Metal fixture, a Unity Metal program is not a
library at all: it is Metal Shading Language source inside Unity's own container (`0x0C0A75BA`), which the
driver compiles on the device - so there is nothing to decompile and the text is the program. This report
says, per program, which of the two it is, and never promotes one to the other:

  METAL_SOURCE_AVAILABLE   MSL text was extracted (encoding METALSOURCETEXT)
  METAL_BINARY_AVAILABLE   an Apple `MTLB` library - no decompiler exists here, and none is pretended
  PARAMETER_BLOCK          a Metal entry with neither: the constant-name table a program's parameters use

Per program it records the stage and entry point (read from the MSL's own `vertex`/`fragment` declaration),
the byte range in the platform blob, a content hash, and the semantic operations (`shader_semantic_ir`).
Per shader, the materials in the rip that name it.

METAL_SEMANTIC_MATCH is not decided here: it needs a source shader, and `shader_semantic_equivalence.py`
is the comparison; this report marks it UNKNOWN wherever that comparison has not been run.

Usage: metal_program_report.py <rip output root> [--game NAME] [--json out.json]
"""
import argparse
import collections
import hashlib
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import shader_semantic_ir as ir  # noqa: E402

STAGE = re.compile(r"\b(vertex|fragment|kernel)\s+[\w<>:, ]+?\s+(\w+)\s*\(")


def materials_by_shader(game_dir):
    """Shader name -> the materials in the rip that draw with it, by GUID through the shader's .meta."""
    guid_to_shader = {}
    for meta in game_dir.rglob("*.shader.meta"):
        guid = re.search(r"^guid:\s*([0-9a-f]{32})", meta.read_text(errors="replace"), re.M)
        shader = meta.with_suffix("")
        if guid and shader.is_file():
            name = re.search(r'Shader\s+"([^"]+)"', shader.read_text(errors="replace"))
            if name:
                guid_to_shader[guid.group(1)] = name.group(1)
    found = collections.defaultdict(list)
    for material in game_dir.rglob("*.mat"):
        text = material.read_text(errors="replace")
        match = re.search(r"m_Shader:\s*\{fileID:\s*-?\d+,\s*guid:\s*([0-9a-f]{32})", text)
        if match and match.group(1) in guid_to_shader:
            found[guid_to_shader[match.group(1)]].append(material.stem)
    return found


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("rip")
    parser.add_argument("--game")
    parser.add_argument("--json")
    args = parser.parse_args()

    rip = pathlib.Path(args.rip)
    report = rip / "AuxiliaryFiles" / "ShaderPrograms.json"
    if not report.is_file():
        print(f"NO_REPORT: {report}")
        return 2
    records = [r for r in json.loads(report.read_text()) if r.get("backend") == "Metal"]
    game = rip / args.game if args.game else next((d for d in rip.iterdir() if (d / "Assets").is_dir()), rip)
    materials = materials_by_shader(game)

    programs = []
    for record in records:
        encoding = record.get("encoding", "")
        row = {"shader": record["shader"], "index": record["index"], "offset": record["offset"],
               "size": record["size"], "encoding": encoding}
        if encoding == "METALSOURCETEXT" and record.get("payload") and (rip / "AuxiliaryFiles" / record["payload"]).is_file():
            text = (rip / "AuxiliaryFiles" / record["payload"]).read_text(encoding="utf-8", errors="replace")
            stage = STAGE.search(text)
            row.update(status="METAL_SOURCE_AVAILABLE",
                       stage=stage.group(1) if stage else "UNKNOWN",
                       entry=stage.group(2) if stage else None,
                       sha256=hashlib.sha256(text.encode()).hexdigest()[:16],
                       operations=ir.operations(text, "msl"))
        elif encoding == "METALLIBRARY" and record.get("headHex", "").find("4d544c42") >= 0:
            row.update(status="METAL_BINARY_AVAILABLE")
        elif encoding == "METALSOURCETEXT":
            row.update(status="METAL_SOURCE_NOT_WRITTEN")
        else:
            row.update(status="PARAMETER_BLOCK" if record["size"] > 0 else "STRIPPED")
        row["semanticMatch"] = "UNKNOWN"
        programs.append(row)

    by_status = collections.Counter(p["status"] for p in programs)
    stages = collections.Counter(p.get("stage") for p in programs if p["status"] == "METAL_SOURCE_AVAILABLE")
    entries = collections.Counter(p.get("entry") for p in programs if p["status"] == "METAL_SOURCE_AVAILABLE")
    distinct = len({p["sha256"] for p in programs if p.get("sha256")})
    shaders = collections.defaultdict(lambda: collections.Counter())
    for p in programs:
        shaders[p["shader"]][p["status"]] += 1

    print(f"Metal entries: {len(programs)}  {json.dumps(dict(by_status), sort_keys=True)}")
    print(f"stages: {json.dumps(dict(stages))}  entry points: {json.dumps(dict(entries))}  distinct programs: {distinct}")
    print(f"shaders: {len(shaders)}; with a material in the rip: {sum(1 for s in shaders if materials.get(s))}")
    for shader, counts in sorted(shaders.items()):
        print(f"  {shader:52} {json.dumps(dict(counts), sort_keys=True):70} materials: {len(materials.get(shader, []))}")

    if args.json:
        pathlib.Path(args.json).write_text(json.dumps({
            "summary": {"entries": len(programs), "byStatus": by_status, "stages": stages,
                        "entryPoints": entries, "distinctPrograms": distinct},
            "shaders": {s: {"programs": dict(c), "materials": materials.get(s, [])} for s, c in shaders.items()},
            "programs": programs}, indent=1, default=dict))
    return 0


if __name__ == "__main__":
    sys.exit(main())
