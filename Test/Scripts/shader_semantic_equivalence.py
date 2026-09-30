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
# What ShaderLab uses when a pass sets nothing.
DEFAULTS = {"Cull": "Back", "Zwrite": "On", "Ztest": "LEqual", "ColorMask": "All",
            "Lighting": "Off", "Blend": "Off"}

# An operation a shader compiler is free to expand into arithmetic rather than preserve: HLSLcc
# writes `lerp(a, b, t)` as `a + t * (b - a)` and `saturate` as a clamp of literals. Its absence from
# the compiled program is not evidence the recovery lost anything. The rest are instructions or
# accesses that survive compilation, and their absence is a real difference.
DERIVABLE = {"LERP", "CLAMP", "MIN", "MAX", "NORMALIZE", "LENGTH", "VECTOR_MUL", "MATRIX_MUL",
             "ADD", "SUB", "MUL", "DIV", "RETURN", "COMPARE"}

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

    # ShaderLab's own defaults. A shader that writes `ZTest LEqual` and one that writes nothing set
    # the same state, and comparing presence rather than value reported the two as different.
    for key, default in DEFAULTS.items():
        if not result.get(key):
            result[key] = [default]

    # Tag names and values are case-insensitive in ShaderLab, and the asset does not preserve the
    # case the programmer typed: `IgnoreProjector` comes back `IGNOREPROJECTOR`.
    result["Tags"] = sorted({f"{name}={value}".lower() for name, value in TAG.findall(stripped)})
    result["Stencil"] = ["present"] if re.search(r"^\s*Stencil\s*\{", stripped, re.M | re.I) else []
    return result


# The literals ShaderLab accepts for each single-valued state. Anything else in that position is a
# material property driving the state - `ZTest [unity_GUIZTestMode]`, `Cull [_CullMode]` - which has
# no fixed value, so there is nothing to compare and reporting a difference would be inventing one.
LITERALS = {
    "Cull": {"Off", "Front", "Back"},
    "Zwrite": {"On", "Off"},
    "Ztest": {"Less", "Greater", "LEqual", "GEqual", "Equal", "NotEqual", "Always", "Never", "Disabled"},
    "ColorMask": {"All", "None", "RGBA", "RGB", "RG", "R", "G", "B", "A", "0"},
    "Lighting": {"On", "Off"},
}


def comparable(key: str, value: str) -> bool:
    literals = LITERALS.get(key)
    return value in literals if literals else not value.startswith("_")


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

    backends = ir.backends_of(rip, shader_name)

    # A build compiled only to Metal has no shading-language source anywhere in it, and no amount of
    # extraction reaches one. That is a fact about the input and has its own verdict: counting it as
    # a recovery that fell back would put it in the same bucket as a program that was there and was
    # missed.
    # Iteration 063: a Metal program is MSL source unless the build precompiled it, so the verdict is
    # decided by whether anything was extracted, never by the backend's name alone.
    if backends and backends <= {"Metal", "Vulkan"} and not ir.recovered_programs(rip, shader_name):
        result["status"] = "METAL_BINARY_ONLY"
        result["notes"] = ["no program of this shader was extracted: every one is a compiled library"]
        return result

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
    # Only state the source sets and the export does not. A build legitimately carries state the
    # source did not write - a tag the pipeline adds, a pass the variant stripped - and counting
    # those as differences measures the build, not the recovery. A value the source drives from a
    # material property (`Cull [_CullMode]`) has no fixed value to compare at all.
    state_differences = []

    for key in sorted(set(exported_state) | set(source_state)):
        wanted = [value for value in source_state.get(key, []) if comparable(key, value)]
        missing = [value for value in wanted if value not in exported_state.get(key, [])]

        if missing:
            state_differences.append(
                f"{key}: source {wanted} exported {exported_state.get(key, [])}")

    exported_properties = properties(exported_text)
    source_properties = properties(source_text)
    missing_properties = sorted(source_properties - exported_properties)

    source_operations = ir.merge(source_programs, "hlsl")
    recovered_operations = ir.merge(recovered_programs, "recovered")

    result["render_state_differences"] = state_differences
    result["missing_properties"] = missing_properties
    result["source_operations"] = sorted(source_operations)
    result["recovered_operations"] = sorted(recovered_operations)

    # Identity, not shape: two programs reaching the same operations that sample different textures
    # do different things, and a comparison of operation sets alone cannot see it.
    source_samplers = ir.samplers(" ".join(source_programs))
    recovered_samplers = ir.samplers(" ".join(recovered_programs))
    missing_samplers = sorted(
        name for name in source_samplers
        if name not in recovered_samplers and not name.startswith("unity_"))
    result["source_samplers"] = sorted(source_samplers)
    result["recovered_samplers"] = sorted(recovered_samplers)
    result["missing_samplers"] = missing_samplers

    if not recovered_programs:
        result["status"] = "FALLBACK"
        result["notes"] = ["the structure came back and no program did"]
        return result

    if not source.is_file():
        # The program came back and there is nothing to grade it against. Saying so is a different
        # fact from saying it is equivalent, and from saying it is not.
        result["status"] = "PROGRAM_RECOVERED"
        result["notes"] = ["the program came back; no source shader to compare it with"]
        return result

    if not source_programs:
        result["status"] = "UNKNOWN"
        result["notes"] = ["the source shader carries no program block to compare against"]
        return result

    missing_operations = sorted(set(source_operations) - set(recovered_operations) - DERIVABLE)
    expanded_operations = sorted((set(source_operations) - set(recovered_operations)) & DERIVABLE)
    result["expanded_operations"] = expanded_operations
    extra_operations = sorted(set(recovered_operations) - set(source_operations))
    result["missing_operations"] = missing_operations
    result["extra_operations"] = extra_operations

    notes = []

    if missing_operations:
        notes.append(f"operations the source reaches and the program does not: {missing_operations}")
    if missing_samplers:
        notes.append(f"textures the source samples and the program does not: {missing_samplers}")
    if expanded_operations:
        notes.append(f"absent but expandable by a shader compiler: {expanded_operations}")
    if state_differences:
        notes.append(f"render state: {state_differences}")
    if missing_properties:
        notes.append(f"properties not exported: {missing_properties}")

    result["notes"] = notes

    if missing_operations or missing_samplers:
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

        # Decided before the oracle is looked for: "this build compiled only to Metal" is a fact
        # about the input that holds whether or not a source shader exists, and it is the one a
        # reader needs. Reporting NO_SOURCE_ORACLE instead would suggest that finding the source
        # would change something.
        backends = ir.backends_of(rip, name)

        if backends and backends <= {"Metal", "Vulkan"} and not ir.recovered_programs(rip, name):
            counts["METAL_BINARY_ONLY"] += 1
            results.append({"shader": name, "status": "METAL_BINARY_ONLY",
                            "notes": [f"every compiled program is a {'/'.join(sorted(backends))} library"]})
            continue

        source = by_name.get(name)

        if source is None:
            counts["NO_SOURCE_ORACLE"] += 1
            results.append({"shader": name, "status": "NO_SOURCE_ORACLE",
                            "notes": ["no source shader of this name in the project or its packages"]})
            continue

        result = compare(path, source, rip, name)
        counts[result["status"]] += 1
        results.append(result)

        if arguments.verbose:
            print(f"{result['status']:24} {name}  {'; '.join(result.get('notes', []))}")

    for status in ("EXACT", "SEMANTICALLY_EQUIVALENT", "PROGRAM_RECOVERED", "PARTIAL", "FALLBACK",
                   "DUMMY", "METAL_BINARY_ONLY", "FAILED", "UNKNOWN", "NO_SOURCE_ORACLE",
                   "NOT_APPLICABLE"):
        print(f"{status:24} {counts[status]}")

    # Only shaders an oracle could grade. A shader with no source, and one whose programs are a Metal
    # library, are both outside the question the rate asks.
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
