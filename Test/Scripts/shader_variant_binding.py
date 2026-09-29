#!/usr/bin/env python3
"""Whether each material in an export would draw with the program its keywords select.

A shader pass compiled for several keyword sets has one program per set, and at run time the engine
picks the one whose keywords match what the material enabled (plus what the engine itself enables:
lights, shadows, fog, stereo). The exported ShaderLab carries one `GLSLPROGRAM` per pass with no
keyword directives, so the project compiles exactly that one program, and every material of the
shader draws with it whatever it enabled. A program that is right is therefore not enough: if the
material selects a different variant, it draws the wrong thing. So

    Material -> Shader -> Keywords -> Variant -> program

is checked for every material and every pass, from the build alone - a material serializes its
keywords, and `AuxiliaryFiles/ShaderVariants.json` records every variant's keyword set.

Which keywords a *material* controls cannot be read from a variant table: a variant's keywords are
the material's and the engine's together. They are taken, per shader, as the keywords some material
of that shader actually enables in this build. That is evidence the build carries, and it leans the
right way: a keyword no material enables is treated as the engine's, which can only make a binding
look *more* ambiguous, never falsely exact.

Statuses, per (material, pass):

  BOUND_EXACT            the exported program is the variant this material selects, with no engine
                         keyword in it
  BOUND_MODULO_ENGINE    it is one of the variants this material selects; which one the engine picks
                         depends on engine state the export cannot know
  VARIANT_BINDING_WRONG  the material selects a different variant from the one the export carries -
                         the program is right and the material still draws with the wrong one
  NO_COMPILED_VARIANT    no compiled variant matches the material's keywords; the build stripped it
                         or the material's keywords are not the ones the build saw
  VARIANT_SELECTION_UNKNOWN  the export carries every compiled variant under guards and none is
                         this state - it reaches the #else, which selects nothing (iteration 062)
  PROGRAM_NOT_RECOVERED  the pass carries a replacement program, so there is nothing to bind
  NO_VARIANT_TABLE       the pass has no entry in the variant table
  KEYWORDS_NOT_RECORDED  the build's version records no keyword names, so which variant a material
                         selects cannot be said - not "compiled with no keywords"
  NO_MARKED_PASS         the exported shader carries neither a recovered nor a replacement program

The variant table is `AuxiliaryFiles/ShaderBlobMapping.json`, which carries every compiled variant
with its program size; a size of zero is a variant the build stripped, which is in the table and
which the engine cannot select.

Usage: shader_variant_binding.py <rip output> [--json out.json] [--examples N]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

BUILTIN_GUIDS = {"0000000000000000f000000000000000", "0000000000000000e000000000000000"}
RECOVERED = re.compile(r"AssetRipperRecoveredProgram: (?P<backend>\w+), variant (?P<variant>\d+) of (?P<count>\d+), "
                       r"blob index (?P<blob>\d+)(?:, keywords (?P<keywords>\S+))?")
GUARDED_VARIANT = re.compile(r"AssetRipperVariant: variant (?P<variant>\d+), content \w+, keywords (?P<keywords>\S+)")
REPLACEMENT = "AssetRipperReplacementProgram"
SHADER_NAME = re.compile(r'^\s*Shader\s+"([^"]+)"', re.M)
SUBSHADER = re.compile(r"^\s*SubShader\b")
# `Pass Keep` inside a Stencil block is a stencil operation, not a pass.
PASS = re.compile(r"^\s*Pass\s*(\{.*)?$")
MATERIAL_HEADER = re.compile(r"^--- !u!21 &(-?\d+)", re.M)


def keyword_set(text):
    if not text or text == "<none>":
        return frozenset()
    return frozenset(k for k in re.split(r"[+ ]", text) if k)


def game_directory(root: pathlib.Path) -> pathlib.Path | None:
    for child in sorted(root.iterdir()):
        if (child / "Assets").is_dir():
            return child
    return None


def read_guids(assets: pathlib.Path):
    guids = {}
    for meta in assets.rglob("*.meta"):
        try:
            match = re.search(r"^guid: ([0-9a-f]{32})", meta.read_text(encoding="utf-8", errors="replace"), re.M)
        except OSError:
            continue
        if match:
            guids[match.group(1)] = meta.with_suffix("")
    return guids


def exported_passes(shader_file: pathlib.Path):
    """(name, {(subShader, pass): ("RECOVERED", backend, variant, keywords) | ("REPLACEMENT",)})."""
    text = shader_file.read_text(encoding="utf-8", errors="replace")
    declared = SHADER_NAME.search(text)
    if not declared:
        return None, {}
    passes = {}
    sub, index = -1, -1
    for line in text.splitlines():
        if SUBSHADER.match(line):
            sub, index = sub + 1, -1
        elif PASS.match(line) and not line.strip().startswith(("UsePass", "GrabPass")):
            index += 1
        match = RECOVERED.search(line)
        guarded = GUARDED_VARIANT.search(line)
        if match and sub >= 0 and index >= 0:
            passes[(sub, index)] = ("RECOVERED", match.group("backend"), int(match.group("variant")) - 1,
                                    keyword_set(match.group("keywords")), [])
        elif guarded and (sub, index) in passes and passes[(sub, index)][0] == "RECOVERED":
            # Iteration 062: every variant of the pass under a guard of its own keyword set. The
            # exported program is then whichever guard the keyword state selects.
            passes[(sub, index)][4].append(keyword_set(guarded.group("keywords")))
        elif REPLACEMENT in line and sub >= 0 and index >= 0 and (sub, index) not in passes:
            passes[(sub, index)] = ("REPLACEMENT",)
    return declared.group(1), passes


def materials(assets: pathlib.Path):
    """(file, name, shader guid, shader fileID, keywords) for every Material document in the export."""
    for path in list(assets.rglob("*.mat")) + list(assets.rglob("*.asset")):
        try:
            text = path.read_text(encoding="utf-8", errors="replace")
        except OSError:
            continue
        if "!u!21 " not in text:
            continue
        starts = [m.start() for m in MATERIAL_HEADER.finditer(text)]
        for start in starts:
            end = text.find("\n--- ", start + 1)
            document = text[start:end if end >= 0 else len(text)]
            name = re.search(r"^\s+m_Name: (.*)$", document, re.M)
            shader = re.search(r"m_Shader: \{fileID: (-?\d+)(?:, guid: ([0-9a-f]{32}))?", document)
            valid = re.search(r"^\s+m_ValidKeywords:\s*(\[\])?\n((?:\s+- .*\n)*)", document, re.M)
            legacy = re.search(r"^\s+m_ShaderKeywords: (.*)$", document, re.M)
            if valid:
                keywords = frozenset(line.strip()[2:].strip() for line in valid.group(2).splitlines() if line.strip())
            elif legacy:
                keywords = keyword_set(legacy.group(1).strip())
            else:
                keywords = frozenset()
            yield (path, name.group(1).strip() if name else "?",
                   shader.group(2) if shader else None, int(shader.group(1)) if shader else 0, keywords)


def run(root: pathlib.Path, example_limit: int):
    game = game_directory(root)
    # The complete table: ShaderVariants.json lists only the variants whose program is source text,
    # so a stripped or binary variant is absent there and reads as never having been compiled.
    table_path = root / "AuxiliaryFiles" / "ShaderBlobMapping.json"
    if game is None:
        return {"status": "PROJECT_ROOT_MISMATCH", "detail": f"no game directory with Assets/ under {root}"}
    if not table_path.exists():
        return {"status": "NO_VARIANT_TABLE", "detail": f"{table_path} is absent"}

    variants = collections.defaultdict(dict)
    for row in json.loads(table_path.read_text()):
        keywords = row.get("keywords")
        # null is "this version does not record keywords", which is not "compiled with none": the
        # second would make every variant the base one and every binding exact.
        keywords = None if keywords is None else frozenset(keywords) if isinstance(keywords, list) else keyword_set(keywords)
        # A variant whose program entry is empty was stripped from the build: it is in the table and
        # the engine cannot select it.
        variants[(row["shader"], row["subShader"], row["pass"], row["backend"])][row["variant"]] = (
            keywords, row.get("programSize", 1) == 0)

    guids = read_guids(game / "Assets")
    shaders = {}
    for shader_file in (game / "Assets").rglob("*.shader"):
        name, passes = exported_passes(shader_file)
        if name:
            shaders[shader_file] = (name, passes)

    material_list = list(materials(game / "Assets"))
    by_shader = collections.defaultdict(list)
    tally = collections.Counter()
    for path, name, guid, file_id, keywords in material_list:
        if guid is None or file_id == 0:
            tally["MATERIAL_WITHOUT_SHADER"] += 1
            continue
        if guid in BUILTIN_GUIDS:
            tally["BUILTIN_SHADER"] += 1
            continue
        shader_path = guids.get(guid)
        if shader_path not in shaders:
            tally["SHADER_NOT_EXPORTED_AS_SOURCE"] += 1
            continue
        by_shader[shader_path].append((path, name, keywords))

    statuses = collections.Counter()
    examples = collections.defaultdict(list)
    per_shader = {}
    for shader_path, users in by_shader.items():
        shader_name, passes = shaders[shader_path]
        controlled_all = frozenset().union(*(k for _, _, k in users))
        shader_counts = collections.Counter()
        if not passes:
            # The export wrote this shader with no marked program in any pass - neither a recovered
            # program nor a replacement that says it is one - so there is nothing to bind or to blame.
            statuses["NO_MARKED_PASS"] += len(users)
            per_shader[shader_name] = {"materials": len(users), "NO_MARKED_PASS": len(users)}
            continue
        for (sub, index), exported in sorted(passes.items()):
            if exported[0] == "REPLACEMENT":
                statuses["PROGRAM_NOT_RECOVERED"] += len(users)
                shader_counts["PROGRAM_NOT_RECOVERED"] += len(users)
                continue
            _, backend, exported_variant, exported_keywords, guards = exported
            # The table is the authority for which keywords the exported variant was compiled for; the
            # comment in the shader is a rendering of it, and the two must agree.
            table_entry = variants.get((shader_name, sub, index, backend), {}).get(exported_variant)
            if table_entry is not None and table_entry[0] is not None and table_entry[0] != exported_keywords:
                statuses["EXPORT_COMMENT_DISAGREES_WITH_TABLE"] += 1
            table_rows = variants.get((shader_name, sub, index, backend))
            if table_rows and any(k is None for k, _ in table_rows.values()):
                statuses["KEYWORDS_NOT_RECORDED"] += len(users)
                shader_counts["KEYWORDS_NOT_RECORDED"] += len(users)
                continue
            table = [(v, k) for v, (k, stripped) in sorted((table_rows or {}).items()) if not stripped]
            if not table_rows:
                statuses["NO_VARIANT_TABLE"] += len(users)
                shader_counts["NO_VARIANT_TABLE"] += len(users)
                continue
            space = frozenset().union(*(k for k, _ in table_rows.values())) | exported_keywords
            controlled = controlled_all & space
            for path, name, keywords in users:
                required = keywords & space
                candidates = [v for v, k in table if k & controlled == required]
                # The programs the export carries for this pass: one, or every guarded variant.
                carried = guards or [exported_keywords]
                selected = [k for k in carried if k & controlled == required]
                if selected:
                    status = "BOUND_EXACT" if any(not (k - controlled) for k in selected) else "BOUND_MODULO_ENGINE"
                elif not candidates and required:
                    status = "NO_COMPILED_VARIANT"
                elif guards:
                    # Guarded and still no guard for this state: it reaches the #else, which selects
                    # nothing rather than guessing.
                    status = "VARIANT_SELECTION_UNKNOWN"
                else:
                    status = "VARIANT_BINDING_WRONG"
                statuses[status] += 1
                shader_counts[status] += 1
                if status in ("VARIANT_BINDING_WRONG", "NO_COMPILED_VARIANT", "VARIANT_SELECTION_UNKNOWN") and len(examples[status]) < example_limit:
                    examples[status].append({
                        "material": name, "file": str(path.relative_to(game)), "shader": shader_name,
                        "pass": f"{sub}.{index}", "backend": backend,
                        "materialKeywords": sorted(required),
                        "exportedVariant": exported_variant + 1, "exportedKeywords": sorted(exported_keywords),
                        "selectableVariants": [v + 1 for v in candidates][:8]})
        per_shader[shader_name] = {"materials": len(users), **shader_counts}

    decided = sum(statuses[s] for s in ("BOUND_EXACT", "BOUND_MODULO_ENGINE", "VARIANT_BINDING_WRONG",
                                         "NO_COMPILED_VARIANT", "VARIANT_SELECTION_UNKNOWN"))
    bound = statuses["BOUND_EXACT"] + statuses["BOUND_MODULO_ENGINE"]
    return {
        "status": "MEASURED",
        "game": game.name,
        "materials": len(material_list),
        "materialScope": dict(tally),
        "bindings": dict(statuses),
        "variant_binding_rate": round(bound / decided, 4) if decided else None,
        "variant_binding_decided": decided,
        "perShader": per_shader,
        "examples": dict(examples),
    }


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("rip")
    parser.add_argument("--json")
    parser.add_argument("--examples", type=int, default=20)
    args = parser.parse_args()
    report = run(pathlib.Path(args.rip), args.examples)
    if report["status"] != "MEASURED":
        print(f"{report['status']}: {report['detail']}")
        sys.exit(2)
    print(f"game {report['game']}: {report['materials']} materials; scope {json.dumps(report['materialScope'], sort_keys=True)}")
    print(f"bindings {json.dumps(report['bindings'], sort_keys=True)}")
    print(f"variant_binding_rate {report['variant_binding_rate']} over {report['variant_binding_decided']} decided")
    for shader, counts in sorted(report["perShader"].items(), key=lambda kv: -kv[1].get("VARIANT_BINDING_WRONG", 0))[:12]:
        print(f"  {shader}: {json.dumps(counts, sort_keys=True)}")
    for status, items in report["examples"].items():
        print(f"-- {status}")
        for item in items[:6]:
            print(f"   {item}")
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(report, indent=1, sort_keys=True))


if __name__ == "__main__":
    main()
