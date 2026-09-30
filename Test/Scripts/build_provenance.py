#!/usr/bin/env python3
"""Was a player build compiled from this source? Per assembly, from declarations alone.

Iteration 063. Input is two `AssemblyFingerprint` dumps: the assemblies a build shipped (the recovered
metadata stubs in `AuxiliaryFiles/GameAssemblies`) and the assemblies a source project compiles to
(`Library/ScriptAssemblies`). Bodies are not compared: an il2cpp stub has none by construction.

IL2CPP strips what nothing reaches, so a member the source has and the build lacks proves nothing. The
direction that discriminates is the other one: every declaration the build shipped must exist in the
source with the same signature, or the source is not what the build was compiled from. Per build
assembly:

  PROVEN_BUILD_MATCH   every type, method and field the build declares is in the source, same signature
  LIKELY_MATCH         at least 98% are, and every type is
  SOURCE_MISMATCH      fewer; the missing declarations are listed
  NO_SOURCE            no source assembly declares most of its types (engine, stripped SDK, native)

"PROVEN" here is proven at the level of declarations - names, arities, parameter and field types. Two
sources with the same surface and different bodies are not told apart by this, and the report says so.

Compiler-generated members (closures, iterators, lambdas: names with `<`) are counted separately:
their names are the compiler's choice, not the programmer's, and a different compiler version renames
them without the program changing.
"""
import argparse
import collections
import json
import sys


def load(path):
    types = collections.defaultdict(dict)   # assembly -> type -> visibility
    members = collections.defaultdict(set)  # assembly -> {(type, kind, name, arity, signature)}
    for line in open(path, encoding="utf-8", errors="replace"):
        cells = line.rstrip("\n").split("\t")
        if len(cells) < 7:
            continue
        assembly, type_name, kind, name, arity, signature, visibility = cells[:7]
        if injected(type_name):
            continue
        if kind == "type":
            types[assembly][type_name] = visibility
        else:
            members[assembly].add((type_name, kind, name, arity, signature))
    return types, members


# The recovery injects these into every assembly it writes; they are this pipeline's, not the build's.
INJECTED_NAMESPACES = ("AssetRipperInjected.", "Cpp2ILInjected.")


def injected(type_name):
    return type_name.startswith(INJECTED_NAMESPACES)


# Types a code generator adds at build time rather than the programmer: Burst/Jobs writes one
# registration type per assembly with a hash in its name.
GENERATED_TYPE_PREFIXES = ("__JobReflectionRegistrationOutput__",)


def generated_type(type_name):
    return "<" in type_name or type_name.startswith(GENERATED_TYPE_PREFIXES)


def generated(entry):
    type_name, _, name, *_ = entry
    return generated_type(type_name) or "<" in name


def classify(build_path, source_path, example_limit=8):
    build_types, build_members = load(build_path)
    source_types, source_members = load(source_path)

    # Where each type lives in the source, so an assembly renamed between the two (DOTween /
    # Demigiant.DOTween) still pairs by what it declares.
    home = {}
    for assembly, declared in source_types.items():
        for type_name in declared:
            home.setdefault(type_name, set()).add(assembly)
    all_source_members = set()
    for declared in source_members.values():
        all_source_members |= declared

    rows = []
    for assembly in sorted(build_types):
        declared = build_types[assembly]
        homes = collections.Counter(a for t in declared for a in home.get(t, ()))
        # Pair only where most of the assembly's types exist in the source: one shared name
        # (an attribute every compiler emits) is not evidence of anything.
        if not homes or homes.most_common(1)[0][1] < 0.5 * len(declared):
            rows.append({"assembly": assembly, "status": "NO_SOURCE", "types": len(declared)})
            continue
        source_assembly = homes.most_common(1)[0][0]
        missing_types = sorted(t for t in declared if t not in home and not generated_type(t))
        mine = build_members[assembly]
        plain = [m for m in mine if not generated(m)]
        synthetic = [m for m in mine if generated(m)]
        missing = sorted(m for m in plain if m not in all_source_members)
        missing_synthetic = [m for m in synthetic if m not in all_source_members]
        present = len(plain) - len(missing)
        rate = present / len(plain) if plain else 1.0
        if not missing and not missing_types:
            status = "PROVEN_BUILD_MATCH"
        elif rate >= 0.98 and not missing_types:
            status = "LIKELY_MATCH"
        else:
            status = "SOURCE_MISMATCH"
        rows.append({
            "assembly": assembly,
            "sourceAssembly": source_assembly,
            "status": status,
            "types": len(declared),
            "typesMissingFromSource": len(missing_types),
            "members": len(plain),
            "membersMissingFromSource": len(missing),
            "memberMatchRate": round(rate, 4),
            "generatedMembers": len(synthetic),
            "generatedMissingFromSource": len(missing_synthetic),
            "missingTypeExamples": missing_types[:example_limit],
            "missingMemberExamples": ["|".join(m) for m in missing[:example_limit]],
        })
    return rows


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("build")
    parser.add_argument("source")
    parser.add_argument("--json")
    parser.add_argument("--examples", type=int, default=8)
    args = parser.parse_args()

    rows = classify(args.build, args.source, args.examples)
    if args.json:
        with open(args.json, "w") as out:
            json.dump(rows, out, indent=1)
    tally = collections.Counter(r["status"] for r in rows)
    print(f"build assemblies: {len(rows)}  {json.dumps(dict(tally))}")
    for r in rows:
        if r["status"] == "NO_SOURCE":
            continue
        print(f"  {r['status']:20} {r['assembly']:28} <- {r['sourceAssembly']:30} "
              f"members {r['members'] - r['membersMissingFromSource']}/{r['members']} ({r['memberMatchRate']}) "
              f"types missing {r['typesMissingFromSource']}  generated missing {r['generatedMissingFromSource']}/{r['generatedMembers']}")
        for example in r["missingTypeExamples"][:3] + r["missingMemberExamples"][:3]:
            print(f"      {example}")
    print("  NO_SOURCE: " + " ".join(r["assembly"] for r in rows if r["status"] == "NO_SOURCE"))
    return 0


if __name__ == "__main__":
    sys.exit(main())
