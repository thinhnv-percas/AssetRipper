#!/usr/bin/env python3
"""One behaviour contract per recovered method, read from the generator's own record.

`recovery_metrics.py` compares operation *classes* between two renderings. `method_semantic_contract.py`
compares the *names* a body reaches against the C# that was written for it. Neither says anything about
control flow, so a recovery that runs the right operations in the wrong order, or under the wrong
condition, reads as perfect in both - and "nineteen rows of obstacles instead of twenty" is exactly
that shape of defect.

A behaviour contract is what a method *does*: its effects, its graph, and the chains of values that
connect them. It is built from `AuxiliaryFiles/SemanticIR`, which the generator files as it emits, so
nothing here re-derives a program from a rendering of one.

  effects      reads and writes, by member name, split into instance / static / array
  calls        what it calls, split by dispatch kind, and what it allocates
  control      blocks, edges, branch conditions, loop back edges, returns, throws
  value flow   producer -> consumer chains through the locals each operation names

Usage: method_behavior_contract.py <rip output> [--json out.json] [--method NAME] [--limit N]
"""
import argparse
import collections
import json
import pathlib
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
from semantic_ir import DIRECTORY, load  # noqa: E402

READS = {"LOAD_FIELD", "PROPERTY_READ"}
WRITES = {"STORE_FIELD", "PROPERTY_WRITE"}
STATIC_READS = {"LOAD_STATIC"}
STATIC_WRITES = {"STORE_STATIC"}
ARRAY_READS = {"ARRAY_LOAD", "ARRAY_LENGTH"}
ARRAY_WRITES = {"ARRAY_STORE"}
CALLS = {"CALL": "calls", "VIRTUAL_CALL": "virtual_calls", "INTERFACE_CALL": "interface_calls",
         "DELEGATE_CALL": "delegate_calls", "INDIRECT_CALL": "indirect_calls", "LIST_ADD": "calls"}
ALLOCATIONS = {"NEW_OBJECT", "NEW_ARRAY"}

# An operation that changes state a caller could observe. A read does not; a branch does not; a call
# might, and is counted because the contract cannot see inside it.
SIDE_EFFECTING = WRITES | STATIC_WRITES | ARRAY_WRITES | set(CALLS) | {"THROW", "RUNTIME_BOUNDARY"}


def contract(body):
    """The behaviour contract of one recorded body."""
    operations = body.get("operations", [])
    blocks = body.get("blocks", [])

    effects = collections.defaultdict(list)
    calls = collections.defaultdict(list)
    allocations = []
    throws = 0
    boundaries = []

    # producer local -> the operation that defined it, so a consumer can be chained to its inputs
    produced_by = {}
    flow = []

    for operation, detail, block, result, operands, result_type in _rows(operations):
        if operation in READS:
            effects["field_reads"].append(detail)
        elif operation in WRITES:
            effects["field_writes"].append(detail)
        elif operation in STATIC_READS:
            effects["static_reads"].append(detail)
        elif operation in STATIC_WRITES:
            effects["static_writes"].append(detail)
        elif operation in ARRAY_READS:
            effects["array_reads"].append(detail)
        elif operation in ARRAY_WRITES:
            effects["array_writes"].append(detail)
        elif operation in CALLS:
            calls[CALLS[operation]].append(detail)
        elif operation in ALLOCATIONS:
            allocations.append(detail)
        elif operation == "THROW":
            throws += 1
        elif operation == "RUNTIME_BOUNDARY":
            boundaries.append(detail)

        if result:
            produced_by[result] = (operation, detail)

        # A consumer with no result of its own - a store, a void call, a branch - is still a
        # consumer, and those are most of what a contract is about. Requiring a result recorded flow
        # for 1909 of 4615 methods; without it, for the ones that actually do something.
        for operand in operands:
            if operand in produced_by:
                source_operation, source_detail = produced_by[operand]
                flow.append({
                    "from": f"{source_operation} {source_detail}".strip(),
                    "through": operand,
                    "to": f"{operation} {detail}".strip(),
                    "type": result_type,
                })

    # A branch's condition is chained to whatever produced it, which is what turns a bare BRANCH into
    # "branches on the result of comparing hp with 0".
    conditions = []

    for block in blocks:
        condition = block.get("condition", "")

        if not condition:
            continue

        produced = produced_by.get(condition)
        conditions.append({
            "block": block["id"],
            "value": condition,
            "decided_by": f"{produced[0]} {produced[1]}".strip() if produced else "UNKNOWN",
            "true_or_false_to": block.get("successors", []),
        })

    return {
        "method": body.get("method", ""),
        "native_length": body.get("nativeLength", -1),
        "declaringType": body.get("declaringType", ""),
        "returns": body.get("returnType", ""),
        "parameters": body.get("parameters", []),
        "effects": {key: sorted(set(value)) for key, value in effects.items()},
        "calls": {key: sorted(set(value)) for key, value in calls.items()},
        "allocations": sorted(set(allocations)),
        "throws": throws,
        "runtime_boundaries": sorted(set(boundaries)),
        "side_effect_count": sum(
            1 for operation, *_ in _rows(operations) if operation in SIDE_EFFECTING),
        "control": {
            "blocks": len(blocks),
            "edges": sum(len(block.get("successors", [])) for block in blocks),
            "branches": sum(1 for block in blocks if block.get("terminator") == "ConditionalJump"),
            "returns": sum(1 for block in blocks if block.get("terminator") == "Return"),
            "throw_blocks": sum(1 for block in blocks if block.get("terminator") == "Throw"),
            "loop_headers": [block["id"] for block in blocks if block.get("loopHeader")],
            "conditions": conditions,
            # The graph is recorded with no exception edges, on purpose: a recovered body has no
            # handlers for one to reach, and inventing an edge would make every comparison against
            # source wrong in the same direction.
            "exception_edges": 0,
        },
        "value_flow": flow,
        "graph": [
            {
                "id": block["id"],
                "successors": block.get("successors", []),
                "predecessors": block.get("predecessors", []),
                "terminator": block.get("terminator", ""),
            }
            for block in blocks
        ],
    }


def _rows(operations):
    """Each recorded operation, padded for records written before the graph and flow were added."""
    for entry in operations:
        operation = entry[0]
        detail = entry[1] if len(entry) > 1 else ""
        block = entry[2] if len(entry) > 2 else -1
        result = entry[3] if len(entry) > 3 else ""
        operands = entry[4] if len(entry) > 4 else []
        result_type = entry[5] if len(entry) > 5 else ""
        yield operation, detail, block, result, operands, result_type


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("rip")
    parser.add_argument("--json")
    parser.add_argument("--method")
    parser.add_argument("--limit", type=int, default=0)
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.rip)
    bodies = load(root)

    if not bodies:
        print(f"NO_SEMANTIC_IR: {root}/{DIRECTORY} is not there, so this rip records nothing to read.")
        return 3

    contracts = {}
    totals = collections.Counter()

    for assembly, methods in bodies.items():
        for rva, body in methods.items():
            if arguments.method and arguments.method not in body.get("method", ""):
                continue

            built = contract(body)
            built["assembly"] = assembly
            built["rva"] = rva
            contracts[f"{assembly}:{rva}"] = built

            totals["methods"] += 1
            totals["with_graph"] += 1 if built["control"]["blocks"] else 0
            totals["with_branches"] += 1 if built["control"]["branches"] else 0
            totals["with_loops"] += 1 if built["control"]["loop_headers"] else 0
            totals["with_value_flow"] += 1 if built["value_flow"] else 0
            totals["with_side_effects"] += 1 if built["side_effect_count"] else 0
            totals["conditions"] += len(built["control"]["conditions"])
            totals["decided_conditions"] += sum(
                1 for condition in built["control"]["conditions"]
                if condition["decided_by"] != "UNKNOWN")

            if arguments.limit and totals["methods"] >= arguments.limit:
                break

    print(f"methods                {totals['methods']}")
    print(f"  with a graph         {totals['with_graph']}")
    print(f"  with a branch        {totals['with_branches']}")
    print(f"  with a loop          {totals['with_loops']}")
    print(f"  with value flow      {totals['with_value_flow']}")
    print(f"  with a side effect   {totals['with_side_effects']}")
    print(f"branch conditions      {totals['conditions']}")
    print(f"  traced to a producer {totals['decided_conditions']}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(contracts, indent=1))
        print(f"written                {arguments.json}")

    return 0


if __name__ == "__main__":
    sys.exit(main())
