#!/usr/bin/env python3
"""Classifies every memory access the generator gave up on, by what it actually is.

The count of unresolved loads answers "how much did not come back" and nothing else. It mixes three
populations that want opposite work: a managed field access that failed to resolve is a recovery
defect; a read of the runtime's own structures has no managed equivalent and never will be; a native
temporary is scaffolding the compiler emitted. Reporting them as one number makes the first invisible
and the second look like failure.

So this is a taxonomy, not a total. The goal is to drive UNKNOWN down, not the total to zero: a read
of Il2CppClass.stack_slot_size is correctly recovered as what it is, and it stays in the report as a
runtime operation rather than being deleted to make a number look better.

Usage: recovery_report.py <unresolved.tsv> [--resolved <resolved.tsv>] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import sys

KIND, ASSEMBLY, TYPE, METHOD, OWNER = 0, 1, 2, 3, 4
ROOT_CAUSE, ORIGIN, SEARCH, RUNTIME_MEMBER, CONSUMER, MEMORY = 12, 18, 19, 20, 21, 22

# Where a base pointer came from decides which of the three populations a load belongs to. An origin
# is read off the IR, so this mapping carries no guess of its own.
NATIVE_TEMPORARY = {"STACK_SLOT", "RETURN_BUFFER", "ENTRY_VALUE"}
MANAGED_STORAGE = {"THIS", "PARAMETER", "INSTANCE_FIELD", "STATIC_FIELD", "ALLOCATION", "CALL_RESULT"}


def classify(row: list[str]) -> tuple[str, str, str]:
    """(category, subcategory, confidence) for one unresolved load."""
    origin = row[ORIGIN]
    coarse = origin.split(":", 1)[0]
    runtime = row[RUNTIME_MEMBER]
    memory = row[MEMORY] if len(row) > MEMORY else ""

    if runtime not in ("-", ""):
        # The base is correctly typed as a runtime structure and the member is named from the struct
        # database, so this is a finished answer about a runtime operation - not a typing failure.
        return "RUNTIME_STRUCT", runtime, "EXACT"

    if coarse in ("ARRAY_ELEMENT",) or "*" in memory.rsplit("+", 1)[-1]:
        return "ARRAY_ACCESS", coarse, "INFERRED"

    if coarse == "GENERIC_CONTEXT":
        return "RUNTIME_STRUCT", "rgctx", "EXACT"

    if coarse in NATIVE_TEMPORARY:
        return "NATIVE_TEMPORARY", coarse, "EXACT"

    if coarse == "LOADED_POINTER":
        # The pointer came out of memory nothing named, so what it points into is genuinely not known
        # here - the failure is upstream, at the load that produced it.
        return "UNKNOWN", "LOADED_POINTER", "NONE"

    if coarse in MANAGED_STORAGE:
        resolvable = row[SEARCH].startswith("SEARCH_ANSWERS")
        return "MANAGED_FIELD", coarse, "EXACT" if resolvable else "INFERRED"

    return "UNKNOWN", origin, "NONE"


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("unresolved")
    parser.add_argument("--resolved")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    rows = []
    with open(arguments.unresolved, encoding="utf-8", errors="replace") as handle:
        for line in handle:
            parts = line.rstrip("\n").split("\t")
            if len(parts) > MEMORY:
                rows.append(parts)

    categories = collections.Counter()
    subcategories = collections.Counter()
    confidence = collections.Counter()
    unknown_methods = collections.Counter()
    unknown_origins = collections.Counter()
    unknown_assemblies = collections.Counter()

    for row in rows:
        category, subcategory, rank = classify(row)
        categories[category] += 1
        subcategories[(category, subcategory)] += 1
        confidence[rank] += 1
        if category == "UNKNOWN":
            unknown_methods[f"{row[TYPE]}.{row[METHOD]}"] += 1
            unknown_origins[row[ORIGIN]] += 1
            unknown_assemblies[row[ASSEMBLY]] += 1

    resolved = 0
    if arguments.resolved:
        with open(arguments.resolved, encoding="utf-8", errors="replace") as handle:
            resolved = sum(1 for _ in handle)

    print(f"memory accesses the generator resolved:   {resolved}")
    print(f"memory accesses the generator gave up on: {len(rows)}\n")

    print("== by what the access is ==")
    for category, count in categories.most_common():
        print(f"{count:6d}  {category:<18} {100 * count / max(len(rows), 1):5.1f}%")

    print("\n== by subcategory ==")
    for (category, subcategory), count in subcategories.most_common(24):
        print(f"{count:6d}  {category:<18} {subcategory}")

    print("\n== confidence in the classification ==")
    for rank, count in confidence.most_common():
        print(f"{count:6d}  {rank}")

    print("\n== top methods still UNKNOWN ==")
    for method, count in unknown_methods.most_common(10):
        print(f"{count:6d}  {method}")

    print("\n== top UNKNOWN provenance ==")
    for origin, count in unknown_origins.most_common(10):
        print(f"{count:6d}  {origin}")

    print("\n== UNKNOWN by assembly ==")
    for assembly, count in unknown_assemblies.most_common(8):
        print(f"{count:6d}  {assembly or '<none>'}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "resolved": resolved,
            "unresolved": len(rows),
            "categories": dict(categories),
            "subcategories": {f"{a}/{b}": c for (a, b), c in subcategories.items()},
            "confidence": dict(confidence),
            "top_unknown_methods": unknown_methods.most_common(20),
            "top_unknown_provenance": unknown_origins.most_common(20),
            "unknown_by_assembly": unknown_assemblies.most_common(20),
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
