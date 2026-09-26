#!/usr/bin/env python3
"""An exported shader against the ShaderLab it was built from, by what the two mean.

Until this iteration no fixture was believed to ship source shaders, and every shader verdict was
capped at "the structure came back". Three of the four do ship them: the packages a game embeds -
TextMesh Pro, Spine, post-processing - are source in the project tree, and the build compiled exactly
those. So there is an oracle.

What is compared, in order, because the earlier ones make the later ones meaningless if they fail:

  1. is the export a stand-in?      a pass carrying `AssetRipperReplacementProgram` is not the
                                    shader's own program, whatever else matches. DUMMY.
  2. render state                   Properties, Tags, Cull, ZWrite, ZTest, Blend, Stencil. A program
                                    that is right under state that is not does not draw what the
                                    shader drew: PARTIAL, never EXACT.
  3. program semantics              the operations each side's programs reach, through
                                    `shader_semantic_ir`, which reduces GLSL and Cg to one vocabulary.

Statuses: EXACT, SEMANTICALLY_EQUIVALENT, PARTIAL, FALLBACK, DUMMY, FAILED, UNKNOWN, NOT_APPLICABLE.
`DUMMY` is not a degree of success and is decided first.

Usage: shader_semantic_equivalence.py <rip output> <source project> [--json out.json] [--verbose]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import shader_semantic_ir as ir  # noqa: E402

REPLACEMENT_MARKER = "AssetRipperReplacementProgram"
RECOVERED_MARKER = "AssetRipperRecoveredProgram"

PROPERTY = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*(\w+)\s*\(\s*"', re.M)
TAG = re.compile(r'"(\w+)"\s*=\s*"([^"]*)"')


# How many words each state statement takes. ShaderLab lets several sit on one line, and a
# line-oriented read of `Cull Off ZWrite Off ZTest Always` reports Cull as
# "Off ZWrite Off ZTest Always" - which is a difference in the measurement, not in the shader, and it
# reported eleven shaders as PARTIAL on the first run.
ARITY = {"cull": 1, "zwrite": 1, "ztest": 1, "colormask": 1, "alphatomask": 1,
         "lighting": 1, "zclip": 1, "blendop": 1, "offset": 2}
WORD = re.compile(r"[A-Za-z_]\w*|[-+]?\d*\.?\d+|[,]")


def render_state(text: str) -> dict:
    """The render state a ShaderLab file sets, as a flat comparable dictionary."""
    # Render state is ShaderLab and never inside a program. Without cutting the program blocks
    # out first, a local named `offset` and the word `Blend` in an HLSL comment read as state the
    # shader sets, and two shaders were reported PARTIAL for exactly that.
    stripped = ir.PROGRAM_BLOCK.sub(" ", re.sub(r"//[^\n]*", "", text))
    state = collections.defaultdict(set)
    words = WORD.findall(stripped)

    index = 0
    while index < len(words):
        key = words[index].lower()

        if key == "blend" and index + 1 < len(words) and words[index + 1].lower() not in ("off",):
            # `Blend Src Dst` or `Blend Src Dst, SrcA DstA`, and `Blend N Src Dst` for one target.
            taken = words[index + 1:index + 7]
            end = len(taken)
            for position, word in enumerate(taken):
                if word.lower() in ARITY or word.lower() in ("blend", "pass", "cgprogram", "glslprogram", "tags"):
                    end = position
                    break
            state["Blend"].add(" ".join(taken[:end]))
            index += 1 + end
            continue

        if key in ARITY:
            arity = ARITY[key]
            state[words[index].capitalize() if key != "colormask" else "ColorMask"].add(
                " ".join(words[index + 1:index + 1 + arity]))
            index += 1 + arity
            continue

        index += 1

    result = {key: sorted(value) for key, value in state.items()}
    result["Tags"] = sorted({f"{name}={value}" for name, value in TAG.findall(stripped)})
    result["Stencil"] = ["present"] if re.search(r"^\s*Stencil\s*\{", stripped, re.M | re.I) else []
    return result


def properties(text: str) -> set[str]:
    inside = re.search(r"Properties\s*\{(.*?)\n\s*\}", text, re.S)
    return set(PROPERTY.findall(inside[1])) if inside else set()


def compare(exported: pathlib.Path, source: pathlib.Path, rip: pathlib.Path, shader_name: str) -> dict:
    exported_text = exported.read_text(encoding="utf-8", errors="replace")
    source_text = source.read_text(encoding="utf-8", errors="replace")

    result = {
        "shader": shader_name,
        "exported": str(exported),
        "source": str(source),
    }

    recovered_programs = ir.recovered_programs(rip, shader_name)
    source_programs = ir.source_programs(source)

    result["recovered_program_count"] = len(recovered_programs)
    result["source_program_count"] = len(source_programs)

    # A stand-in is decided before any degree of success. The export says so itself rather than the
    # measurement inferring it from the absence of something.
    if REPLACEMENT_MARKER in exported_text and RECOVERED_MARKER not in exported_text:
        result["status"] = "DUMMY"
        result["notes"] = ["every pass carries the replacement stage"]
        return result

    exported_state = render_state(exported_text)
    source_state = render_state(source_text)
    state_differences = [
        f"{key}: source {source_state.get(key, [])} exported {exported_state.get(key, [])}"
        for key in set(exported_state) | set(source_state)
        if exported_state.get(key, []) != source_state.get(key, [])
    ]

    exported_properties = properties(exported_text)
    source_properties = properties(source_text)
    missing_properties = sorted(source_properties - exported_properties)

    source_operations = ir.merge(source_programs, "hlsl")
    recovered_operations = ir.merge(recovered_programs, "glsl")

    result["render_state_differences"] = state_differences
    result["missing_properties"] = missing_properties
    result["source_operations"] = sorted(source_operations)
    result["recovered_operations"] = sorted(recovered_operations)

    if not recovered_programs:
        result["status"] = "FALLBACK"
        result["notes"] = ["the structure came back and no program did"]
        return result

    if not source_programs:
        result["status"] = "UNKNOWN"
        result["notes"] = ["the source shader carries no program block to compare against"]
        return result

    missing_operations = sorted(set(source_operations) - set(recovered_operations))
    extra_operations = sorted(set(recovered_operations) - set(source_operations))
    result["missing_operations"] = missing_operations
    result["extra_operations"] = extra_operations

    notes = []

    if missing_operations:
        notes.append(f"operations the source reaches and the program does not: {missing_operations}")
    if state_differences:
        notes.append(f"render state: {state_differences}")
    if missing_properties:
        notes.append(f"properties not exported: {missing_properties}")

    result["notes"] = notes

    if missing_operations:
        result["status"] = "PARTIAL"
    elif state_differences or missing_properties:
        # The program means the same thing under state that does not, which is not the same drawing.
        result["status"] = "PARTIAL"
    elif extra_operations:
        result["status"] = "SEMANTICALLY_EQUIVALENT"
    else:
        result["status"] = "EXACT"

    return result


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("rip")
    parser.add_argument("source")
    parser.add_argument("--json")
    parser.add_argument("--verbose", action="store_true")
    arguments = parser.parse_args()

    rip = pathlib.Path(arguments.rip)
    source_root = pathlib.Path(arguments.source)

    exported = sorted(rip.rglob("Assets/Shader/*.shader"))

    if not exported:
        print(f"NO_EXPORTED_SHADERS under {rip}")
        return 3

    by_name = {}

    for path in source_root.rglob("*.shader"):
        name = ir.source_shader_name(path)
        if name:
            by_name.setdefault(name, path)

    print(f"source shaders declared: {len(by_name)}")

    results = []
    counts = collections.Counter()

    for path in exported:
        text = path.read_text(encoding="utf-8", errors="replace")
        match = re.search(r'Shader\s+"([^"]+)"', text)
        name = match[1] if match else path.stem

        source = by_name.get(name)

        if source is None:
            counts["NOT_APPLICABLE"] += 1
            results.append({"shader": name, "status": "NOT_APPLICABLE",
                            "notes": ["no source shader of this name in the project"]})
            continue

        result = compare(path, source, rip, name)
        counts[result["status"]] += 1
        results.append(result)

        if arguments.verbose:
            print(f"{result['status']:24} {name}  {'; '.join(result.get('notes', []))}")

    for status in ("EXACT", "SEMANTICALLY_EQUIVALENT", "PARTIAL", "FALLBACK",
                   "DUMMY", "FAILED", "UNKNOWN", "NOT_APPLICABLE"):
        print(f"{status:24} {counts[status]}")

    compared = sum(counts[status] for status in
                   ("EXACT", "SEMANTICALLY_EQUIVALENT", "PARTIAL", "FALLBACK", "DUMMY", "UNKNOWN"))

    if compared:
        good = counts["EXACT"] + counts["SEMANTICALLY_EQUIVALENT"]
        print(f"shader_semantic_equivalence_rate {good / compared:.4f} ({good}/{compared})")
    else:
        print("shader_semantic_equivalence_rate None (0 compared)")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(results, indent=1))

    return 0


if __name__ == "__main__":
    sys.exit(main())
