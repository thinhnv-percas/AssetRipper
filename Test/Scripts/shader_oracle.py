#!/usr/bin/env python3
"""Compares an exported shader against the ShaderLab the game was built from.

A shader that compiles is not a shader that is right. `DummyShaderTextExporter` reconstructs a
shader's `Properties` block exactly - names, types, defaults, `[Toggle]`, `[HideInInspector]` - and
then gives every shader the same replacement unlit pass. The material is not pink, so anything
looking for pink materials reports success while the shading is wrong. Only a comparison against the
original ShaderLab can tell the two apart, and only for a game whose source is available.

Verdicts per shader:

  EXACT                   the same properties, the same structure, and the same program text
  SEMANTICALLY_EQUIVALENT the same properties and structure; program text differs only in layout
  PARTIAL                 the properties survive and the structure does not
  FALLBACK                neither survives, and the export is not a recognisable stand-in
  DUMMY                   the export carries the stand-in's own marker, or no program at all. This
                          is not a degree of success: the shading is a replacement, whatever the
                          properties say.
  NOT_EXPORTED            the source declares the shader and the rip has no such shader
  NO_SOURCE               the rip has the shader and the source project does not declare it

`property_recovery_rate` is reported separately, because it is the part that genuinely is recovered
and reporting it inside one shader verdict would make a DUMMY look partly right.

Usage: shader_oracle.py <source project> <recovered game directory> [--json out.json] [--verbose]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

DECLARATION = re.compile(r'^\s*Shader\s+"(?P<name>[^"]+)"', re.MULTILINE)
DUMMY_MARKER = "DummyShaderTextExporter"

# A property line: `[Attr] _Name ("Display", Type) = default`. The display string is deliberately not
# compared - it is localisation, not shading - while the attributes are, because `[HideInInspector]`
# and `[Toggle]` change what the material inspector and the variant collection do.
PROPERTY = re.compile(
    r'^\s*(?P<attributes>(?:\[[^\]]*\]\s*)*)'
    r'(?P<name>[_A-Za-z]\w*)\s*\(\s*"[^"]*"\s*,\s*(?P<type>[^)]*)\)\s*=\s*(?P<default>[^\r\n]*)',
    re.MULTILINE)

# The ShaderLab statements that decide how a pass draws. A stand-in reproduces none of them.
STRUCTURE = re.compile(
    r'^\s*(?P<keyword>Tags|LOD|Blend|BlendOp|ZTest|ZWrite|Cull|ColorMask|Offset|Stencil|Lighting|'
    r'AlphaToMask|Fog|GrabPass|UsePass|Name)\b(?P<rest>[^\r\n]*)', re.MULTILINE)

PROGRAM = re.compile(r'(?:CGPROGRAM|HLSLPROGRAM|GLSLPROGRAM)(?P<body>.*?)(?:ENDCG|ENDHLSL|ENDGLSL)',
                     re.DOTALL)

LINE_COMMENT = re.compile(r"//[^\n]*")
BLOCK_COMMENT = re.compile(r"/\*.*?\*/", re.DOTALL)

EXACT, EQUIVALENT, PARTIAL, FALLBACK, DUMMY, NOT_EXPORTED, NO_SOURCE = (
    "EXACT", "SEMANTICALLY_EQUIVALENT", "PARTIAL", "FALLBACK", "DUMMY", "NOT_EXPORTED", "NO_SOURCE")
ORDER = [EXACT, EQUIVALENT, PARTIAL, FALLBACK, DUMMY, NOT_EXPORTED, NO_SOURCE]


def code_only(text):
    return LINE_COMMENT.sub("", BLOCK_COMMENT.sub("", text))


def properties(text):
    """The Properties block as {name: (type, default, attributes)}, ignoring display strings."""
    start = re.search(r"\bProperties\s*\{", text)
    if not start:
        return {}
    depth, index = 0, start.end() - 1
    while index < len(text):
        if text[index] == "{":
            depth += 1
        elif text[index] == "}":
            depth -= 1
            if depth == 0:
                break
        index += 1
    block = text[start.end():index]
    found = {}
    for match in PROPERTY.finditer(block):
        attributes = tuple(sorted(re.findall(r"\[([^\]]*)\]", match.group("attributes"))))
        found[match.group("name")] = (
            match.group("type").strip(),
            normalise_default(match.group("default")),
            attributes,
        )
    return found


def normalise_default(text):
    """A default with its trailing `{}` texture block and its spacing removed."""
    return re.sub(r"\s+", "", text.split("{")[0]).rstrip(",")


# A ShaderLab property has no Int in the serialized shader: Unity stores one as a Float, so an `Int`
# in the source and a `Float` in the export are the same property and the difference is metadata that
# does not exist to be recovered. `Color` and `Vector` are NOT that case - the serialized form
# distinguishes them - so they are left as a real difference.
EQUIVALENT_TYPES = {frozenset({"int", "float"})}


def numbers_equal(left, right):
    """Two defaults compared as numbers where both are, so `1.0` and `1` are not a difference."""
    def parts(text):
        # ShaderLab writes `.5` where the export writes `0.5`, so a leading dot has to be part of a
        # number or the two read as different shapes rather than as the same value.
        return re.findall(r"-?(?:\d+\.?\d*|\.\d+)(?:[eE][-+]?\d+)?", text)
    left_parts, right_parts = parts(left), parts(right)
    if not left_parts or len(left_parts) != len(right_parts):
        return False
    if re.sub(r"-?[\d.eE+]+", "", left) != re.sub(r"-?[\d.eE+]+", "", right):
        return False
    return all(float(a) == float(b) for a, b in zip(left_parts, right_parts))


def property_agreement(source_value, exported_value):
    """`EXACT`, `EQUIVALENT` (a difference the serialized form cannot carry), or `DIFFERENT`."""
    if exported_value is None:
        return "DIFFERENT"
    if source_value == exported_value:
        return "EXACT"
    source_type, source_default, source_attributes = source_value
    exported_type, exported_default, exported_attributes = exported_value
    # ShaderLab type names are case-insensitive, so `vector` and `Vector` are one type.
    source_type, exported_type = source_type.casefold(), exported_type.casefold()
    types_agree = (source_type == exported_type
                   or frozenset({source_type, exported_type}) in EQUIVALENT_TYPES)
    defaults_agree = source_default == exported_default or numbers_equal(source_default, exported_default)
    if types_agree and defaults_agree and source_attributes == exported_attributes:
        return "EQUIVALENT"
    return "DIFFERENT"


def structure(text):
    """The render-state statements, as a multiset - order within a pass is not meaningful."""
    statements = []
    for match in STRUCTURE.finditer(text):
        rest = re.sub(r"\s+", " ", match.group("rest")).strip()
        statements.append(f"{match.group('keyword')} {rest}".strip())
    return collections.Counter(statements)


def programs(text):
    """The shader program bodies, whitespace-normalised, so layout alone is not a difference."""
    return [re.sub(r"\s+", " ", match.group("body")).strip() for match in PROGRAM.finditer(text)]


def is_dummy(text):
    return DUMMY_MARKER in text


def compare(source_text, exported_text):
    """The verdict for one shader, and the evidence behind it."""
    source_code, exported_code = code_only(source_text), code_only(exported_text)
    source_properties, exported_properties = properties(source_code), properties(exported_code)
    agreement = {name: property_agreement(value, exported_properties.get(name))
                 for name, value in source_properties.items()}
    matched = {name for name, verdict in agreement.items() if verdict == "EXACT"}
    equivalent = {name for name, verdict in agreement.items() if verdict == "EQUIVALENT"}
    evidence = {
        "source_properties": len(source_properties),
        "exported_properties": len(exported_properties),
        "properties_matched": len(matched),
        "properties_equivalent": len(equivalent),
        "properties_differ": sorted(set(source_properties) - matched - equivalent),
        "source_structure": sum(structure(source_code).values()),
        "exported_structure": sum(structure(exported_code).values()),
        "source_programs": len(programs(source_code)),
        "exported_programs": len(programs(exported_code)),
    }

    # The marker first, and before any degree of success: a stand-in that reproduces the properties
    # perfectly is still a stand-in, and calling that PARTIAL is exactly the reading this file exists
    # to prevent.
    if is_dummy(exported_text):
        return DUMMY, evidence

    source_programs, exported_programs = programs(source_code), programs(exported_code)
    if source_programs and not exported_programs:
        return DUMMY, evidence

    properties_agree = source_properties and (matched | equivalent) == set(source_properties)
    structures_agree = structure(source_code) == structure(exported_code)

    if properties_agree and structures_agree and source_programs == exported_programs:
        return EXACT, evidence
    if properties_agree and structures_agree:
        return EQUIVALENT, evidence
    if properties_agree or (matched and len(matched | equivalent) >= len(source_properties) // 2):
        return PARTIAL, evidence
    return FALLBACK, evidence


def declared(path):
    try:
        text = path.read_text(encoding="utf-8", errors="replace")
    except OSError:
        return None, ""
    match = DECLARATION.search(code_only(text))
    return (match.group("name") if match else None), text


def collect(root, skip):
    """{shader name: (path, text)} for every ShaderLab file under `root`."""
    found = {}
    for path in sorted(root.rglob("*.shader")):
        if any(part in skip for part in path.parts):
            continue
        name, text = declared(path)
        if name:
            found.setdefault(name, (path, text))
    return found


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("source")
    parser.add_argument("game")
    parser.add_argument("--json")
    parser.add_argument("--name")
    parser.add_argument("--verbose", action="store_true")
    arguments = parser.parse_args()

    project, game = pathlib.Path(arguments.source).resolve(), pathlib.Path(arguments.game).resolve()
    if not project.is_dir():
        print(f"SOURCE_NOT_AVAILABLE {project}")
        return 2
    if not game.is_dir():
        print(f"RIP_NOT_AVAILABLE {game}")
        return 2

    in_source = collect(project, {".git", "Library", "Temp", "Builds"})
    in_rip = collect(game, set())

    entries, counts = [], collections.Counter()
    for name in sorted(set(in_source) | set(in_rip)):
        if name in in_source and name in in_rip:
            verdict, evidence = compare(in_source[name][1], in_rip[name][1])
        elif name in in_source:
            verdict, evidence = NOT_EXPORTED, {}
        else:
            verdict, evidence = NO_SOURCE, {"dummy": is_dummy(in_rip[name][1])}
        counts[verdict] += 1
        entries.append({"shader": name, "verdict": verdict, "evidence": evidence})

    paired = [entry for entry in entries
              if entry["verdict"] not in (NOT_EXPORTED, NO_SOURCE)]
    declared_properties = sum(entry["evidence"]["source_properties"] for entry in paired)
    exact_properties = sum(entry["evidence"]["properties_matched"] for entry in paired)
    recovered_properties = exact_properties + sum(
        entry["evidence"]["properties_equivalent"] for entry in paired)

    report = {
        "fixture": arguments.name or game.name,
        "source": str(project),
        "rip": str(game),
        "shaders_in_source": len(in_source),
        "shaders_in_rip": len(in_rip),
        "paired": len(paired),
        "verdicts": {verdict: counts[verdict] for verdict in ORDER},
        # Reported beside the verdicts and never folded into them: the properties are the part that
        # is genuinely recovered, and a DUMMY with every property right is still a replacement pass.
        "property_recovery_rate": (round(recovered_properties / declared_properties, 4)
                                   if declared_properties else None),
        "property_exact_rate": (round(exact_properties / declared_properties, 4)
                                if declared_properties else None),
        "dummy_in_rip": sum(1 for _, (_, text) in in_rip.items() if is_dummy(text)),
        "shaders": entries,
    }

    print(f"{report['fixture']}: {len(in_source)} shaders in source, {len(in_rip)} in rip, "
          f"{len(paired)} paired")
    for verdict in ORDER:
        if counts[verdict]:
            print(f"  {verdict:<24} {counts[verdict]}")
    print(f"  property_recovery_rate   {report['property_recovery_rate']} "
          f"({recovered_properties} of {declared_properties} declared properties, "
          f"{exact_properties} of them exact)")
    print(f"  dummy_in_rip             {report['dummy_in_rip']} of {len(in_rip)}")
    if arguments.verbose:
        for entry in paired:
            print(f"    {entry['verdict']:<24} {entry['shader']}  {entry['evidence']}")
    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))
        print(f"  wrote {arguments.json}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
