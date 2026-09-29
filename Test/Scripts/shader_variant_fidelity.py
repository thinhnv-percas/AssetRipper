#!/usr/bin/env python3
"""Which compiled program each material of an export would draw with, decided the way Unity decides it.

Iteration 062. `shader_variant_binding.py` reads the variant comments the exporter writes and matches a
material's keywords against them. This reads the guard chain itself - the `#if`/`#elif` conditions a
recovered pass carries - and evaluates it, so it measures the text Unity will compile rather than the
comment beside it. Each selection is then compared by *content* with the program the variant table
says the original build compiled for exactly that keyword state:

  material -> shader -> keyword state -> variant the table compiled for it -> program (content hash)
                                      -> guard the export selects       -> program (content hash)

A keyword the material does not control - a shadow caster's SHADOWS_DEPTH, fog, instancing - is set by
the engine at run time and is unknown here, so every combination of those is evaluated and a binding
is EXACT only when all of them agree. Nothing is chosen: a keyword state the build never compiled must
reach the guard chain's `#else`, and one that reaches a program must reach the same program the build
compiled for it.

Statuses, per material and pass:

  EXACT                        every engine keyword state selects the program compiled for it, and
                               a state the build never compiled selects nothing
  WRONG_PROGRAM                some state selects a program other than the one compiled for it
  SELECTS_UNCOMPILED           some state the build never compiled selects a program anyway
  MISSING_PROGRAM              the build compiled a program for some state and the export has no guard
                               that selects it
  VARIANT_SELECTION_UNKNOWN    the material's own state reaches `#else`: the build compiled no program
                               for it, and Unity would have picked a nearest one by rules not reproduced
  NOT_EMBEDDED                 the pass carries one program and no guards, so the table's other
                               variants are not in the export; decided against that one program
  NO_CONTENT_HASH              the rip predates program identity (ShaderVariants.json has no hashes)
  PROGRAM_NOT_RECOVERED        the pass carries a replacement program

`--source` adds the material's keywords as the source project wrote them, found by material name and
shader name. The field that matters there is `sourceKeywordsAgree`: a recovered material whose
keywords differ from its source selects a different program for a reason no shader work can fix.
"""
import argparse
import collections
import itertools
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import shader_variant_binding as binding  # noqa: E402

GUARD_BEGIN = re.compile(r"^\s*#(if|elif) (?P<condition>.*)$")
GUARD_ELSE = re.compile(r"^\s*#else\s*$")
GUARD_END = re.compile(r"^\s*#endif\s*$")
VARIANT = re.compile(r"AssetRipperVariant: variant (?P<variant>\d+), content (?P<hash>\w+), keywords (?P<keywords>\S+)")
CHAIN_START = "AssetRipperRecoveredVariants:"
CONDITION_TOKEN = re.compile(r"\s*(\(|\)|&&|\|\||!|defined\((\w+)\))")


def evaluate(condition, defined):
    """Evaluate a guard written by ShaderVariantGuards; anything outside that grammar is an error."""
    tokens, position = [], 0
    while position < len(condition):
        match = CONDITION_TOKEN.match(condition, position)
        if not match:
            raise ValueError(f"unexpected guard text at {position}: {condition!r}")
        token = match.group(1)
        tokens.append(("KW", match.group(2)) if token.startswith("defined") else (token, None))
        position = match.end()

    index = 0

    def disjunction():
        nonlocal index
        value = conjunction()
        while index < len(tokens) and tokens[index][0] == "||":
            index += 1
            value = conjunction() or value
        return value

    def conjunction():
        nonlocal index
        value = unary()
        while index < len(tokens) and tokens[index][0] == "&&":
            index += 1
            value = unary() and value
        return value

    def unary():
        nonlocal index
        kind, name = tokens[index]
        index += 1
        if kind == "!":
            return not unary()
        if kind == "(":
            value = disjunction()
            index += 1  # ")"
            return value
        return name in defined

    return disjunction()


def guard_chains(shader_file):
    """{(subShader, pass): {"chain": [(condition, [(variant, hash, keywords)])], "header": ...}}."""
    text = shader_file.read_text(encoding="utf-8", errors="replace")
    declared = binding.SHADER_NAME.search(text)
    if not declared:
        return None, {}
    passes = {}
    sub, index = -1, -1
    chain, in_chain = None, False
    for line in text.splitlines():
        if binding.SUBSHADER.match(line):
            sub, index = sub + 1, -1
        elif binding.PASS.match(line) and not line.strip().startswith(("UsePass", "GrabPass")):
            index += 1
        header = binding.RECOVERED.search(line)
        if header and sub >= 0 and index >= 0:
            passes[(sub, index)] = {"backend": header.group("backend"), "variant": int(header.group("variant")) - 1,
                                    "keywords": binding.keyword_set(header.group("keywords")), "chain": None}
            continue
        if binding.REPLACEMENT in line and sub >= 0 and index >= 0 and (sub, index) not in passes:
            passes[(sub, index)] = {"replacement": True}
            continue
        if CHAIN_START in line and (sub, index) in passes:
            chain, in_chain, depth = [], True, 0
            passes[(sub, index)]["chain"] = chain
            continue
        if not in_chain:
            continue
        # The programs inside the chain carry their own conditionals (#ifdef VERTEX, precision
        # blocks), so only a directive at the chain's own depth belongs to the chain.
        stripped = line.strip()
        if stripped.startswith(("#if ", "#ifdef", "#ifndef")):
            guard = GUARD_BEGIN.match(line)
            if depth == 0 and guard and stripped.startswith("#if (") and not chain:
                chain.append((guard.group("condition"), []))
            else:
                depth += 1
            continue
        if stripped.startswith("#elif") and depth == 0:
            chain.append((GUARD_BEGIN.match(line).group("condition"), []))
            continue
        if GUARD_ELSE.match(line) and depth == 0:
            in_chain = False
            continue
        if GUARD_END.match(line):
            depth = max(depth - 1, 0)
            continue
        variant = VARIANT.search(line)
        if variant and chain:
            chain[-1][1].append((int(variant.group("variant")) - 1, variant.group("hash"),
                                 binding.keyword_set(variant.group("keywords"))))
    return declared.group(1), passes


def select(chain, defined):
    """The (variant, hash) list of the first guard that holds, or None for the #else."""
    for condition, variants in chain:
        if evaluate(condition, defined):
            return variants
    return None


def source_material_keywords(source_root):
    """{(material name, shader name): [keyword sets]} for every material in a source project."""
    if source_root is None:
        return {}
    shader_names = {}
    for shader in source_root.rglob("*.shader"):
        meta = shader.with_suffix(".shader.meta")
        try:
            guid = re.search(r"^guid: ([0-9a-f]{32})", meta.read_text(errors="replace"), re.M)
            name = binding.SHADER_NAME.search(shader.read_text(errors="replace"))
        except OSError:
            continue
        if guid and name:
            shader_names[guid.group(1)] = name.group(1)
    found = collections.defaultdict(list)
    for path, name, guid, file_id, keywords in binding.materials(source_root):
        if guid in shader_names:
            found[(name, shader_names[guid])].append(keywords)
    return found


def run(root, source_root, example_limit):
    game = binding.game_directory(root)
    if game is None:
        return {"status": "PROJECT_ROOT_MISMATCH", "detail": f"no game directory with Assets/ under {root}"}
    table_path = root / "AuxiliaryFiles" / "ShaderBlobMapping.json"
    variants_path = root / "AuxiliaryFiles" / "ShaderVariants.json"
    if not table_path.exists():
        return {"status": "NO_VARIANT_TABLE", "detail": str(table_path)}

    table = collections.defaultdict(dict)
    for row in json.loads(table_path.read_text()):
        keywords = row.get("keywords")
        if keywords is None or row["stage"] != "Vertex":
            continue
        table[(row["shader"], row["subShader"], row["pass"], row["backend"])][row["variant"]] = {
            "keywords": frozenset(keywords), "stripped": row.get("programSize", 1) == 0,
            "blobIndex": row.get("blobIndex"), "offset": row.get("programOffset"), "size": row.get("programSize")}

    hashes = {}
    has_hashes = False
    if variants_path.exists():
        for row in json.loads(variants_path.read_text()):
            if "contentHash" in row:
                has_hashes = True
                hashes[(row["shader"], row["subShader"], row["pass"], row["stage"], row["backend"], row["variant"])] = row["contentHash"]

    sources = source_material_keywords(source_root)

    guids = binding.read_guids(game / "Assets")
    shaders = {}
    for shader_file in (game / "Assets").rglob("*.shader"):
        name, passes = guard_chains(shader_file)
        if name:
            shaders[shader_file] = (name, passes)

    by_shader = collections.defaultdict(list)
    for path, name, guid, file_id, keywords in binding.materials(game / "Assets"):
        shader_path = guids.get(guid) if guid else None
        if shader_path in shaders:
            by_shader[shader_path].append((path, name, keywords))

    statuses = collections.Counter()
    source_agreement = collections.Counter()
    rows = []
    for shader_path, users in by_shader.items():
        shader_name, passes = shaders[shader_path]
        controlled = frozenset().union(*(k for _, _, k in users))
        for (sub, index), exported in sorted(passes.items()):
            for path, material, keywords in users:
                row = {"material": material, "file": str(path.relative_to(game)), "shader": shader_name,
                       "pass": f"{sub}.{index}", "recoveredKeywords": sorted(keywords)}
                candidates = sources.get((material, shader_name), [])
                if source_root is not None:
                    if len(candidates) == 1:
                        row["sourceKeywords"] = sorted(candidates[0])
                        row["sourceKeywordsAgree"] = candidates[0] == keywords
                        source_agreement["AGREE" if candidates[0] == keywords else "DIFFER"] += 1
                    else:
                        row["sourceKeywords"] = None
                        source_agreement["NOT_FOUND" if not candidates else "AMBIGUOUS"] += 1
                if exported.get("replacement"):
                    row["status"] = "PROGRAM_NOT_RECOVERED"
                    statuses[row["status"]] += 1
                    rows.append(row)
                    continue
                backend = exported["backend"]
                compiled = table.get((shader_name, sub, index, backend), {})
                space = frozenset().union(*(v["keywords"] for v in compiled.values())) if compiled else frozenset()
                engine = sorted(space - controlled)
                own = keywords & space

                def compiled_for(state):
                    matches = [v for v, entry in compiled.items() if entry["keywords"] == state and not entry["stripped"]]
                    return matches

                def hash_of(variant, stage):
                    return hashes.get((shader_name, sub, index, stage, backend, variant))

                expected = compiled_for(own)
                row["expectedVariants"] = [v + 1 for v in expected]
                row["expectedVertexProgram"] = sorted({h for v in expected if (h := hash_of(v, "Vertex"))})
                row["expectedFragmentProgram"] = sorted({h for v in expected if (h := hash_of(v, "Fragment"))})
                row["engineKeywords"] = engine
                if not has_hashes:
                    row["status"] = "NO_CONTENT_HASH"
                elif exported["chain"] is None:
                    # One program, no guards: it is what every state draws with.
                    selected = exported["variant"]
                    row["selectedVariant"] = selected + 1
                    row["vertexProgram"] = hash_of(selected, "Vertex")
                    row["fragmentProgram"] = hash_of(selected, "Fragment")
                    wanted = set(row["expectedVertexProgram"])
                    row["status"] = "EXACT" if wanted and row["vertexProgram"] in wanted else "NOT_EMBEDDED"
                else:
                    # Every combination of the keywords the engine sets, with the material's own. A
                    # state is judged against what the build compiled for exactly it.
                    verdict, judged, first = "EXACT", 0, None
                    for size in range(len(engine) + 1):
                        for extra in itertools.combinations(engine, size):
                            state = own | frozenset(extra)
                            chosen = select(exported["chain"], set(state))
                            built = compiled_for(state)
                            wanted = {h for v in built if (h := hash_of(v, "Vertex"))}
                            if chosen is not None and first is None:
                                first = (sorted(state), chosen[0])
                            if built:
                                judged += 1
                            if chosen is None:
                                if built and verdict == "EXACT":
                                    verdict = "MISSING_PROGRAM"
                            elif not built:
                                verdict = "SELECTS_UNCOMPILED" if verdict == "EXACT" else verdict
                            elif chosen[0][1] not in wanted:
                                verdict = "WRONG_PROGRAM"
                    if judged == 0 and verdict == "EXACT":
                        verdict = "VARIANT_SELECTION_UNKNOWN"
                    if first is not None:
                        row["selectedState"] = first[0]
                        row["selectedVariant"] = first[1][0] + 1
                        row["vertexProgram"] = first[1][1]
                        row["fragmentProgram"] = first[1][1]  # one GLSL program carries both stages
                    else:
                        row["selectedVariant"] = None
                    row["statesJudged"] = judged
                    row["status"] = verdict
                statuses[row["status"]] += 1
                rows.append(row)

    decided = sum(statuses[s] for s in ("EXACT", "WRONG_PROGRAM", "SELECTS_UNCOMPILED", "MISSING_PROGRAM",
                                         "VARIANT_SELECTION_UNKNOWN", "NOT_EMBEDDED"))
    return {
        "status": "MEASURED" if has_hashes else "NO_CONTENT_HASH",
        "game": game.name,
        "bindings": dict(statuses),
        "exact_rate": round(statuses["EXACT"] / decided, 4) if decided else None,
        "decided": decided,
        "sourceKeywords": dict(source_agreement) if source_root is not None else None,
        "mismatches": [r for r in rows if r["status"] != "EXACT"][:example_limit],
        "rows": rows,
    }


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("rip", type=pathlib.Path, nargs="?")
    parser.add_argument("--source", type=pathlib.Path)
    parser.add_argument("--json")
    parser.add_argument("--examples", type=int, default=10)
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return self_test()

    result = run(args.rip, args.source, args.examples)
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(result, indent=1))
    if result["status"] not in ("MEASURED",):
        print(f"{result['status']}: {result.get('detail', '')}")
        if result["status"] != "NO_CONTENT_HASH":
            return 2
    print(f"game {result['game']}: bindings {json.dumps(result['bindings'])}")
    print(f"exact_rate {result['exact_rate']} over {result['decided']} decided")
    if result["sourceKeywords"] is not None:
        print(f"material keywords against source: {json.dumps(result['sourceKeywords'])}")
    for row in result["mismatches"]:
        print("  " + json.dumps({k: row.get(k) for k in ("material", "shader", "pass", "sourceKeywords", "recoveredKeywords",
                                                          "expectedVariants", "selectedVariant", "vertexProgram",
                                                          "fragmentProgram", "status")}))
    return 0


def self_test():
    failures = 0

    def check(name, actual, expected):
        nonlocal failures
        ok = actual == expected
        failures += not ok
        print(f"{'PASS' if ok else 'FAIL'}  {name}: {actual!r}")

    chain = [("(!defined(A) && !defined(B))", [(0, "h0", frozenset())]),
             ("(defined(A) && !defined(B)) || (defined(A) && defined(B))", [(1, "h1", frozenset({"A"}))])]
    check("the empty state selects the base program", select(chain, set())[0][1], "h0")
    check("an || guard holds for either set", select(chain, {"A", "B"})[0][1], "h1")
    check("a state no guard names reaches #else", select(chain, {"B"}), None)
    check("negation binds tighter than &&", evaluate("(!defined(A) && defined(B))", {"B"}), True)
    try:
        evaluate("defined(A) + 1", {"A"})
        check("text outside the guard grammar is refused", "accepted", "refused")
    except ValueError:
        check("text outside the guard grammar is refused", "refused", "refused")
    import tempfile
    with tempfile.TemporaryDirectory() as directory:
        shader = pathlib.Path(directory) / "t.shader"
        shader.write_text("\n".join([
            'Shader "T" {', "SubShader {", "Pass {", "GLSLPROGRAM",
            "// AssetRipperRecoveredProgram: GLES, variant 1 of 2, blob index 1, keywords <none>",
            "// AssetRipperRecoveredVariants: 2 distinct programs over 2 keyword sets; keywords A",
            "#if (!defined(A))", "// AssetRipperVariant: variant 1, content h0, keywords <none>",
            "#ifdef VERTEX", "#ifdef GL_ES", "#else", "#endif", "#endif",
            "#elif (defined(A))", "// AssetRipperVariant: variant 2, content h1, keywords A",
            "#else", "#error VARIANT_SELECTION_UNKNOWN", "#endif", "ENDGLSL", "}", "}", "}"]))
        _, passes = guard_chains(shader)
        check("a program's own #else does not end the chain", len(passes[(0, 0)]["chain"]), 2)
    return 1 if failures else 0


if __name__ == "__main__":
    sys.exit(main())
