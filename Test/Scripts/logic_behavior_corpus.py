#!/usr/bin/env python3
"""A frozen corpus of what particular methods were recovered to *do*.

`golden_corpus.py` freezes each method's semantic *status*, which can stay EXACT while the body starts
comparing the wrong field or running the loop one time fewer. This freezes the behaviour contract
itself - the members read and written, the calls made, the number of loops and branches - so a change
that keeps the shape and alters the meaning is caught where a status cannot see it.

The selection is by what a method is *for*, not by how badly it was recovered: a corpus picked
worst-first can only ever report improvement.

  runtime role      Awake OnEnable Start Update FixedUpdate LateUpdate OnDestroy, and the rest of the
                    Unity message set, matched on the declaration rather than on the name alone
  domain            movement score health timer spawn level, by the members the contract names
  construct         List Array Dictionary generic delegate event coroutine virtual interface
                    native boundary exception
  regression        the shapes this project has already been wrong about once: a loop's trip count, a
                    flag that has to propagate, a store wider than its field, an int reaching a float,
                    a value carried across a back edge

Usage:
  logic_behavior_corpus.py --select <rip> --fixture NAME [--corpus FILE]
  logic_behavior_corpus.py --check  <rip> --fixture NAME [--corpus FILE]
"""
import argparse
import collections
import json
import pathlib
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import method_behavior_contract as behavior  # noqa: E402
from semantic_ir import load  # noqa: E402

CORPUS = pathlib.Path(__file__).resolve().parent.parent / "logic-behavior-corpus.json"

UNITY_MESSAGES = {
    "Awake", "OnEnable", "Start", "Update", "FixedUpdate", "LateUpdate", "OnDisable", "OnDestroy",
    "OnTriggerEnter", "OnTriggerExit", "OnCollisionEnter", "OnCollisionExit", "OnApplicationPause",
    "OnApplicationQuit", "OnApplicationFocus", "OnGUI", "OnValidate", "Reset",
}

DOMAIN = {
    "movement": ("position", "velocity", "rotation", "move", "speed", "transform"),
    "score": ("score", "coin", "point"),
    "health": ("health", "hp", "damage", "lives", "die", "dead"),
    "timer": ("time", "timer", "cooldown", "delay", "duration"),
    "spawn": ("spawn", "instantiate", "pool"),
    "level": ("level", "stage", "win", "lose", "complete", "finish"),
}

CONSTRUCT = {
    "list": ("List`1", "LIST_ADD"),
    "array": ("ARRAY_STORE", "ARRAY_LOAD"),
    "dictionary": ("Dictionary`2",),
    "delegate": ("DELEGATE_CALL",),
    "interface": ("INTERFACE_CALL",),
    "virtual": ("VIRTUAL_CALL",),
    "coroutine": ("d__", "MoveNext"),
    "exception": ("THROW",),
    "boundary": ("RUNTIME_BOUNDARY",),
}

# The regression shapes. Each is a property of the contract that a known past defect changed.
REGRESSION = {
    "loop_trip_count": lambda contract: bool(contract["control"]["loop_headers"]),
    "flag_propagation": lambda contract: any(
        condition["decided_by"].startswith("COMPARE") for condition in contract["control"]["conditions"]),
    "multi_byte_store": lambda contract: len(contract["effects"].get("field_writes", [])) > 1,
    "int_to_float": lambda contract: any(
        flow["type"] in ("System.Single", "System.Double") for flow in contract["value_flow"]),
    "back_edge_value": lambda contract: bool(contract["control"]["loop_headers"]) and bool(contract["value_flow"]),
}


def digest(contract: dict) -> dict:
    """The facts frozen for one method: what it does, not how well it scored."""
    return {
        "field_reads": contract["effects"].get("field_reads", []),
        "field_writes": contract["effects"].get("field_writes", []),
        "static_reads": contract["effects"].get("static_reads", []),
        "static_writes": contract["effects"].get("static_writes", []),
        "array_reads": contract["effects"].get("array_reads", []),
        "array_writes": contract["effects"].get("array_writes", []),
        "calls": sorted({call for kind in contract["calls"].values() for call in kind}),
        "allocations": contract["allocations"],
        "throws": contract["throws"],
        "blocks": contract["control"]["blocks"],
        "branches": contract["control"]["branches"],
        "loops": len(contract["control"]["loop_headers"]),
        "returns": contract["control"]["returns"],
        "conditions": [condition["decided_by"] for condition in contract["control"]["conditions"]],
    }


def categories(contract: dict) -> list[str]:
    found = []
    name = contract["method"]

    if name in UNITY_MESSAGES:
        found.append(f"role:{name}")

    text = " ".join([
        name.lower(), contract["declaringType"].lower(),
        " ".join(contract["effects"].get("field_reads", [])).lower(),
        " ".join(contract["effects"].get("field_writes", [])).lower(),
        " ".join(call.lower() for kind in contract["calls"].values() for call in kind),
    ])

    for domain, words in DOMAIN.items():
        if any(word in text for word in words):
            found.append(f"domain:{domain}")

    blob = json.dumps(contract)

    for construct, markers in CONSTRUCT.items():
        if any(marker in blob for marker in markers):
            found.append(f"construct:{construct}")

    for regression, test in REGRESSION.items():
        if test(contract):
            found.append(f"regression:{regression}")

    return found


def contracts_of(rip: pathlib.Path):
    for assembly, methods in load(rip).items():
        for rva, body in methods.items():
            yield assembly, rva, behavior.contract(body)


def select(rip: pathlib.Path, fixture: str, corpus: pathlib.Path, per_category: int = 3) -> int:
    existing = json.loads(corpus.read_text()) if corpus.is_file() else []
    keys = {(entry["fixture"], entry["assembly"], entry["rva"]) for entry in existing}

    taken = collections.Counter()
    added = 0

    for assembly, rva, contract in contracts_of(rip):
        if not contract["side_effect_count"]:
            continue

        wanted = [category for category in categories(contract) if taken[category] < per_category]

        if not wanted:
            continue

        if (fixture, assembly, rva) in keys:
            continue

        for category in wanted:
            taken[category] += 1

        existing.append({
            "fixture": fixture,
            "assembly": assembly,
            "rva": rva,
            "type": contract["declaringType"],
            "method": contract["method"],
            "categories": sorted(set(categories(contract))),
            "digest": digest(contract),
        })
        keys.add((fixture, assembly, rva))
        added += 1

    # Unioned, never replaced: a frozen entry that gets dropped is a hole in the net.
    corpus.write_text(json.dumps(existing, indent=1))
    print(f"selected {added} new entries for {fixture}; corpus now {len(existing)}")
    return 0


def check(rip: pathlib.Path, fixture: str, corpus: pathlib.Path, verbose: bool) -> int:
    if not corpus.is_file():
        print(f"CORPUS_NOT_FOUND: {corpus}")
        return 3

    frozen = [entry for entry in json.loads(corpus.read_text()) if entry["fixture"] == fixture]

    if not frozen:
        print(f"CORPUS_NOT_APPLICABLE: no entries for {fixture}")
        return 3

    found = {(assembly, rva): contract for assembly, rva, contract in contracts_of(rip)}
    matched = changed = missing = 0
    differences = collections.Counter()

    for entry in frozen:
        contract = found.get((entry["assembly"], entry["rva"]))

        if contract is None:
            missing += 1
            if verbose:
                print(f"MISSING  {entry['type']}.{entry['method']}")
            continue

        matched += 1
        now = digest(contract)

        for key, value in entry["digest"].items():
            if now.get(key) != value:
                changed += 1
                differences[key] += 1
                if verbose:
                    print(f"CHANGED  {entry['type']}.{entry['method']}  {key}: {value} -> {now.get(key)}")
                break

    print(f"entries {len(frozen)}  matched {matched}  changed {changed}  missing {missing}")

    if differences:
        for key, count in differences.most_common():
            print(f"  {key}: {count}")

    return 1 if changed or missing else 0


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("rip")
    parser.add_argument("--fixture", required=True)
    parser.add_argument("--corpus", default=str(CORPUS))
    parser.add_argument("--select", action="store_true")
    parser.add_argument("--check", action="store_true")
    parser.add_argument("--verbose", action="store_true")
    arguments = parser.parse_args()

    rip = pathlib.Path(arguments.rip)
    corpus = pathlib.Path(arguments.corpus)

    if not load(rip):
        print(f"NO_SEMANTIC_IR under {rip}")
        return 3

    if arguments.select:
        return select(rip, arguments.fixture, corpus)

    if arguments.check:
        return check(rip, arguments.fixture, corpus, arguments.verbose)

    parser.error("one of --select or --check")
    return 2


if __name__ == "__main__":
    sys.exit(main())
