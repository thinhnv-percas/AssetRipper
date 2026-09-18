#!/usr/bin/env python3
"""What each recovered method does, as a contract a reader or another tool can check against.

Built from `AuxiliaryFiles/SemanticIR`, which the generator files as it emits - so this describes the
program that was exported rather than a re-reading of a rendering of it. The fields are the ones a
reader would ask about when deciding whether a method was recovered: what it touches, what it calls,
what it allocates, what it branches on, and where it leaves managed code.

`status` is the semantic status of the body, which is not a compile status and not a placeholder
count:

  EXACT              every substantive operation the IR recorded is named in the exported C#
  HIGH_CONFIDENCE    the same, with a local the analysis could not type
  PARTIAL            the body carries a placeholder
  FALLBACK           no placeholder, and an operation the IR recorded is absent from the C#
  MISSING            the generator threw and the exported body is a stand-in

Usage: method_semantic_contract.py <rip output> --game <game dir> [--fixture NAME] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))

import semantic_ir
import recovery_metrics

ADDRESS = re.compile(r'\[Address\(RVA = "(?P<rva>0x[0-9A-Fa-f]+)"(?:, Offset = "0x[0-9A-Fa-f]+")?, Length = "0x(?P<length>[0-9A-Fa-f]+)"')

# Which operations feed which column of the contract.
READS = {"LOAD_FIELD", "PROPERTY_READ"}
WRITES = {"STORE_FIELD", "PROPERTY_WRITE"}
STATIC_READS = {"LOAD_STATIC"}
STATIC_WRITES = {"STORE_STATIC"}
ARRAY_READS = {"ARRAY_LOAD", "ARRAY_LENGTH"}
ARRAY_WRITES = {"ARRAY_STORE"}
CALLS = {"CALL"}
VIRTUAL = {"VIRTUAL_CALL"}
INTERFACE = {"INTERFACE_CALL"}
DELEGATE = {"DELEGATE_CALL"}
ALLOCATIONS = {"NEW_OBJECT", "NEW_ARRAY"}

# A method with any of these changes something outside itself, which is what a runtime check would
# have to observe. A pure computation has none.
SIDE_EFFECTING = WRITES | STATIC_WRITES | ARRAY_WRITES | CALLS | VIRTUAL | INTERFACE | DELEGATE | {
    "LIST_ADD", "THROW", "RUNTIME_BOUNDARY", "INDIRECT_CALL"}


def bodies_by_rva(game):
    """{rva: (file, native length, C# body)} for every exported method that carries an address.

    Keyed by reading the address out of the same line that starts each method, rather than by pairing
    two independent walks of the file: two lists that are only equal in length by convention is how
    every off-by-one in this harness has started.
    """
    found = {}

    for path in sorted(pathlib.Path(game).rglob("*.cs")):
        text = path.read_text(encoding="utf-8", errors="replace")
        lines = text.splitlines()
        relative = str(path.relative_to(game))

        for index, line in enumerate(lines):
            match = ADDRESS.search(line)

            if not match:
                continue

            depth = 0
            started = False
            collected = []

            for following in lines[index + 1:index + 4000]:
                if following.lstrip().startswith("["):
                    continue

                collected.append(following)
                depth += following.count("{") - following.count("}")

                if "{" in following:
                    started = True

                if started and depth <= 0:
                    break

            found[match.group("rva")] = (relative, int(match.group("length"), 16), "\n".join(collected))

    return found


def detail_names(body, wanted):
    """The distinct names the recorded operations carry, for the operations asked for."""
    return sorted({detail for operation, detail in body["operations"] if operation in wanted and detail})


def contract_for(rva, body, exported, assembly, exported_assemblies):
    counted = semantic_ir.counts(body)
    status = absence(body, assembly, exported_assemblies)
    file = None

    if exported is not None:
        file, native, csharp = exported
        status = classify(body, native, csharp)

    return {
        "rva": rva,
        "method": f"{body['declaringType']}::{body['method']}",
        "file": file,
        "status": status,
        "parameters": body["parameters"],
        "return_type": body["returnType"],
        "fields_read": detail_names(body, READS),
        "fields_written": detail_names(body, WRITES),
        "static_fields_read": detail_names(body, STATIC_READS),
        "static_fields_written": detail_names(body, STATIC_WRITES),
        "array_reads": counted["ARRAY_LOAD"] + counted["ARRAY_LENGTH"],
        "array_writes": counted["ARRAY_STORE"],
        "calls": detail_names(body, CALLS),
        "virtual_calls": detail_names(body, VIRTUAL),
        "interface_calls": detail_names(body, INTERFACE),
        "delegate_calls": counted["DELEGATE_CALL"],
        "allocations": detail_names(body, ALLOCATIONS),
        "branches": counted["BRANCH"],
        "loops": counted["LOOP"],
        "exceptions": counted["THROW"],
        "runtime_boundaries": detail_names(body, {"RUNTIME_BOUNDARY"}),
        "side_effects": sorted({operation for operation in semanticset(body) if operation in SIDE_EFFECTING}),
    }


# A compiler-generated member is folded into its caller by the decompiler - a state machine's
# MoveNext becomes the iterator body, a display class's lambda becomes an inline lambda - so it has no
# method of its own in the export. That is the decompiler doing its job, not a body that went missing.
FOLDED = ("<", "d__", "c__DisplayClass", "|")


def absence(body, assembly, exported_assemblies):
    """Why a recorded body has no exported method of its own."""
    marker = f"{body['declaringType']}::{body['method']}"

    if any(part in marker for part in FOLDED):
        return "FOLDED_BY_DECOMPILER"

    # A recovered assembly that is not exported as scripts ships as a stub DLL only, by design.
    return "ASSEMBLY_NOT_EXPORTED" if assembly not in exported_assemblies else "NOT_EXPORTED"


def semanticset(body):
    return semantic_ir.fingerprint(body)


def classify(body, native, csharp):
    """The semantic status, measured against the IR the generator recorded for this very body."""
    if body.get("generatorFailure") or recovery_metrics.GENERATOR_FAILURE.search(csharp):
        return "MISSING"

    statements = sum(1 for line in csharp.splitlines()
                     if line.strip() and not line.strip().startswith(("{", "}", "//", "[", "get", "set", "add", "remove")))

    if statements == 0:
        return "EXACT" if native <= 8 else "MISSING"

    if recovery_metrics.PLACEHOLDER.findall(csharp):
        return "PARTIAL"

    if lost(body, csharp):
        return "FALLBACK"

    return "HIGH_CONFIDENCE" if recovery_metrics.UNTYPED_LOCAL.findall(csharp) else "EXACT"


# An accessor is written as the property, a constructor as the type it builds, and an allocation
# names its declaring type - so the string both sides can be compared on is not the one the IR
# carries. Comparing the IR's own spelling is how iteration 056 counted a member the export had
# deliberately renamed as a member the export had lost.
ACCESSOR_PREFIXES = ("get_", "set_", "add_", "remove_")

# Written as syntax rather than as a name, so there is nothing to look for in the C#. Each exclusion
# has to be statable or the check quietly stops testing anything:
#   op_*    an operator - `Object.op_Equality(a, b)` is `a == b`
#   .ctor   a base constructor call inside a constructor is an initialiser, which a decompiler elides
#           when it is the implicit one
UNNAMEABLE_PREFIX = "op_"

# Written as syntax rather than as the member's name, each for a reason that has to be statable -
# an exclusion nobody can defend is a check that has quietly stopped testing anything.
UNNAMEABLE = {
    # `typeof(T)` is what the compiler renders as a call to this, and what a decompiler renders back.
    "GetTypeFromHandle",
    # An indexer is `x[i]` on both sides; `Chars` is the string indexer's own accessor name.
    "Item", "Chars",
    # A delegate invocation is `d(x)`.
    "Invoke",
    # `string.Concat` is what `a + b` compiles to and what a decompiler writes back as `+`.
    "Concat",
}


def written_as(operation, detail, caller=""):
    """The text the exported C# would use for an operation the IR recorded, or "" when there is none."""
    if not detail:
        return ""

    if operation in ALLOCATIONS:
        return simple_type_name(detail)

    name = detail.rsplit("::", 1)[-1]

    # A compiler-generated member belongs to a construct the decompiler folds back into its source
    # form - a state machine's `<>1__state`, a closure's `<>4__this` - so the C# for the method that
    # used to name it names the `yield`/`await`/lambda instead.
    if name.startswith("<"):
        return ""

    if name in UNNAMEABLE:
        return ""

    if name.startswith(UNNAMEABLE_PREFIX):
        return ""

    if name.startswith(ACCESSOR_PREFIXES):
        return name.split("_", 1)[1]

    if name == ".ctor":
        # Inside a constructor this is the base call, which C# can only write as an initialiser and
        # which a decompiler omits when it is the implicit one.
        return "" if caller == ".ctor" else simple_type_name(detail.rsplit("::", 1)[0])

    return name


def simple_type_name(full):
    """`System.Collections.Generic.List`1<System.Int32>` is written `List`.

    Generic arguments are stripped before the namespace is, because they carry dots of their own and
    taking the last segment first yields `Int32>` - a name that appears in no source and so reads as a
    loss in every generic method.
    """
    without_arguments = full.split("<", 1)[0]
    return without_arguments.rsplit(".", 1)[-1].split("`", 1)[0]


def lost(body, csharp):
    """Substantive operations the IR recorded that the exported C# does not name."""
    missing = []

    for operation, detail in body["operations"]:
        if operation not in semantic_ir.SUBSTANTIVE:
            continue

        name = written_as(operation, detail, body["method"])

        if name and name not in csharp:
            missing.append(f"{operation} {name}")

    return missing


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root", help="the rip output directory")
    parser.add_argument("--game", required=True, help="the game directory inside the rip")
    parser.add_argument("--fixture")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    recorded = semantic_ir.load(arguments.root)

    if not recorded:
        print(f"NO_SEMANTIC_IR: {arguments.root}/{semantic_ir.DIRECTORY}")
        return 2

    exported = bodies_by_rva(arguments.game)
    exported_assemblies = {path.name for path in (pathlib.Path(arguments.game) / "Assets" / "Scripts").iterdir()
                           if path.is_dir()} if (pathlib.Path(arguments.game) / "Assets" / "Scripts").is_dir() else set()
    contracts = []
    statuses = collections.Counter()

    for assembly, bodies in recorded.items():
        for rva, body in bodies.items():
            contract = contract_for(rva, body, exported.get(rva), assembly, exported_assemblies)
            contract["assembly"] = assembly
            contracts.append(contract)
            statuses[contract["status"]] += 1

    report = {
        "fixture": arguments.fixture or pathlib.Path(arguments.game).name,
        "root": arguments.root,
        "methods": len(contracts),
        "status": dict(statuses),
        "contracts": contracts,
    }

    print(f"{report['fixture']}: {len(contracts)} method contracts")
    for status in ("EXACT", "HIGH_CONFIDENCE", "PARTIAL", "FALLBACK", "MISSING",
                   "FOLDED_BY_DECOMPILER", "ASSEMBLY_NOT_EXPORTED", "NOT_EXPORTED"):
        print(f"  {statuses.get(status, 0):>7}  {status}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=1))
        print(f"  wrote {arguments.json}")

    return 0


if __name__ == "__main__":
    sys.exit(main())
