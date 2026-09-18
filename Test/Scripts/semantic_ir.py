#!/usr/bin/env python3
"""The semantic IR the generator recorded while it emitted each body.

This is the single source of truth for what a recovered method does. Every semantic measurement in
this project used to re-derive that by parsing two renderings and comparing what each seemed to name:
`[NativeSource(Body = …)]` on the IR side and the decompiled C# on the other. Both were derivations
and both drifted - one walked an instruction list the generator no longer emits from, the other
counted a field as lost that the export had deliberately renamed to a property. Each cost an
iteration to find, and nothing structural stopped a third.

`AuxiliaryFiles/SemanticIR/<assembly>.json` is filed by `IlGenerator` at the moment it emits, keyed by
the same RVA the exported `[Address(RVA = "0x…")]` carries. A reader of the export can therefore ask
what a method does without recognising it from text.

Two operations are declared in the canonical set and never produced, and saying so is part of the
measurement rather than a gap in it:

  CAST, UNBOX   the generator emits neither `castclass` nor `unbox`; a cast in the exported C# is
                ILSpy rendering a type mismatch, not an operation the recovery decided on.
  ARRAY_CREATE  is NEW_ARRAY. An array initialiser is one `newarr` and one `stelem` per element, so
                `new char[2] { '#', 'c' }` records NEW_ARRAY + ARRAY_STORE + ARRAY_STORE already.

Usage: semantic_ir.py <rip output> [--assembly NAME] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import sys

DIRECTORY = "AuxiliaryFiles/SemanticIR"

# The operations that carry behaviour: a method that had one and no longer does has lost something a
# reader would notice. The rest are shape - a comparison folded into a branch is still the comparison,
# and a RETURN is implied by a void method.
SUBSTANTIVE = {
    "LOAD_FIELD", "STORE_FIELD", "PROPERTY_READ", "PROPERTY_WRITE",
    "LOAD_STATIC", "STORE_STATIC",
    "ARRAY_LOAD", "ARRAY_STORE",
    "CALL", "VIRTUAL_CALL", "INTERFACE_CALL", "DELEGATE_CALL", "LIST_ADD",
    "NEW_OBJECT", "NEW_ARRAY", "THROW",
}

# Declared in the canonical set, never produced. Reported rather than silently absent.
NEVER_PRODUCED = {"CAST", "UNBOX", "SWITCH", "ARRAY_CREATE"}


def load(root):
    """{assembly: {rva: body}} for one rip, or {} when the run recorded none."""
    directory = pathlib.Path(root) / DIRECTORY

    if not directory.is_dir():
        return {}

    return {
        path.stem: json.loads(path.read_text(encoding="utf-8"))
        for path in sorted(directory.glob("*.json"))
    }


def methods(root):
    """(assembly, rva, body) for every recorded body."""
    for assembly, bodies in load(root).items():
        for rva, body in bodies.items():
            yield assembly, rva, body


def operations(body):
    """The operation names one body performs, in order."""
    return [operation for operation, _ in body["operations"]]


def fingerprint(body):
    """The set of operation classes a body reaches."""
    return set(operations(body))


def counts(body):
    return collections.Counter(operations(body))


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root", help="the rip output directory")
    parser.add_argument("--assembly")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    recorded = load(arguments.root)

    if not recorded:
        print(f"NO_SEMANTIC_IR: {arguments.root}/{DIRECTORY} is not there. "
              "Either the run predates it or no bodies were generated.")
        return 2

    total = collections.Counter()
    per_assembly = {}

    for assembly, bodies in recorded.items():
        if arguments.assembly and assembly != arguments.assembly:
            continue

        here = collections.Counter()

        for body in bodies.values():
            here.update(operations(body))

        per_assembly[assembly] = {"methods": len(bodies), "operations": dict(here)}
        total.update(here)

    print(f"{sum(entry['methods'] for entry in per_assembly.values())} method bodies "
          f"across {len(per_assembly)} assemblies")

    for operation, count in total.most_common():
        print(f"  {count:>8}  {operation}")

    absent = sorted(NEVER_PRODUCED - set(total))
    if absent:
        print(f"\n  declared and never produced: {', '.join(absent)}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "root": arguments.root,
            "total": dict(total),
            "byAssembly": per_assembly,
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
