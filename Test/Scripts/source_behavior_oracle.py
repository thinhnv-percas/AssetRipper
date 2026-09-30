#!/usr/bin/env python3
"""A recovered method's behaviour against the behaviour of the source it was built from.

`source_oracle.py` compares the operation *classes* two renderings reach. That cannot see control
flow, and control flow is where the defects this project keeps finding actually live: a loop that
runs nineteen times instead of twenty reaches every class the source does.

This compares behaviour contracts. The recovered side is `method_behavior_contract.py`, built from the
record the generator filed as it emitted. The source side is read from the programmer's own text.

The comparison is deliberately asymmetric about calls, and the reason is il2cpp rather than a
concession: a trivial framework method is inlined into its caller, so `Vector3.MoveTowards` is gone by
the time there is anything to recover and what remains is the `Sqrt` and the arithmetic it was made
of. A recovered body therefore legitimately reaches calls the source does not name, and legitimately
fails to name calls the source made. What it may NOT do is lose the source's own effects: a field the
source writes has to be written, and a loop it runs has to be there.

  EXACT                   every effect, every surviving call, and the same branch and loop counts
  SEMANTICALLY_EQUIVALENT every effect and every surviving call, control flow differing only in ways
                          inlining explains (more branches, never fewer loops)
  PARTIAL                 some of the effects
  MISMATCH                writes the source does not, or loses every effect while reaching others
  FALLBACK                no effect and no call at all against a source that has them
  NOT_AVAILABLE           nothing recovered to compare

Usage: source_behavior_oracle.py <source project> <rip output> [--json out.json] [--verbose]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import source_oracle  # noqa: E402
import source_preprocessor  # noqa: E402
import method_behavior_contract as behavior  # noqa: E402
from semantic_ir import load  # noqa: E402

# `x.y = `, `x = `, `x += ` at statement level. The name before the last dot is not taken: what is
# wanted is the member being written, which is the last segment.
ASSIGNMENT = re.compile(r"(?:^|[;{}\s])(?:this\.)?([A-Za-z_]\w*(?:\.[A-Za-z_]\w*)*)\s*(?:[-+*/|&^]|<<|>>|\?\?)?=(?!=)")
# A string is not code. `Debug.LogFormat("Button A Pressed for the first time")` read as a `for` loop
# the recovery had lost - nine methods reported MISMATCH for a word inside a message.
STRING = re.compile(r'@?"(?:\\.|[^"\\\n])*"|\$?"(?:\\.|[^"\\\n])*"|\'(?:\\.|[^\'\\\n])*\'')
CALL = re.compile(r"([A-Za-z_]\w*)\s*\(")
LOOP = re.compile(r"\b(for|foreach|while|do)\b")
BRANCH = re.compile(r"\b(if|else\s+if|switch|case)\b|\?[^:]{1,60}:")
THROW = re.compile(r"\bthrow\b")
# `x++`, `--x`: a write with no `=` in it. Without this the oracle reported `scoreCounter++` as a
# write the source does not make - a defect in the measurement that reads exactly like one in the
# recovery.
INCREMENT = re.compile(r"(?:(?:this\.)?([A-Za-z_]\w*(?:\.[A-Za-z_]\w*)*)\s*(?:\+\+|--)|(?:\+\+|--)\s*(?:this\.)?([A-Za-z_]\w*(?:\.[A-Za-z_]\w*)*))")

# Written by the language rather than called: counting these as calls the recovery lost would report
# every method with a cast or a `new` as incomplete.
# How small a native body has to be before "it makes no call" is read off its size. Deliberately
# tight: two A64 instructions plus a little. A larger body that reaches nothing is a loss, and saying
# so is the point of the measure.
INLINE_BODY_BYTES = 16

NOT_A_CALL = {
    "if", "while", "for", "foreach", "switch", "catch", "lock", "using", "return", "new",
    "typeof", "sizeof", "nameof", "default", "checked", "unchecked", "fixed", "yield",
}


def source_behavior(body: str, declared_fields: set[str]) -> dict:
    """What the programmer's text says the method does."""
    # Comments, then strings, then the declaration line itself: a one-line method's own name sits in
    # the text its body was collected from, and reads as a call the method makes to itself.
    code = STRING.sub('""', source_oracle.code_only(body))
    code = code.split("{", 1)[1] if "{" in code else code

    writes = set()
    write_only = collections.Counter()

    for match in ASSIGNMENT.finditer(code):
        name = match[1].split(".")[-1]
        if name in declared_fields or "." in match[1]:
            writes.add(name)

            # A plain `=` writes and does not read; `+=` and `++` do both. Counting the two alike
            # made a field the method only assigns - `isNext = false` - read as a read the recovery
            # had lost.
            if match[0].rstrip().endswith("="):
                compound = match[0].rstrip()[:-1].rstrip()[-1:] in "-+*/|&^" or match[0].count("<<") or match[0].count(">>")
                if not compound:
                    write_only[name] += 1

    for match in INCREMENT.finditer(code):
        name = (match[1] or match[2]).split(".")[-1]
        if name in declared_fields or "." in (match[1] or match[2]):
            writes.add(name)

    reads = set()

    for name in declared_fields:
        appearances = len(re.findall(rf"\b{re.escape(name)}\b", code))

        if appearances and appearances > write_only[name]:
            reads.add(name)

    calls = {name for name in CALL.findall(code) if name not in NOT_A_CALL}

    return {
        "field_writes": writes,
        "field_reads": reads,
        "calls": calls,
        "loops": len(LOOP.findall(code)),
        "branches": len(BRANCH.findall(code)),
        "throws": len(THROW.findall(code)),
        # An `async` method's body is moved into a state machine exactly as a coroutine's is, and
        # what is left behind is a kickoff. Comparing that against the source measures the compiler.
        "coroutine": "yield " in code or "await " in code,
    }


def recovered_behavior(contract: dict) -> dict:
    effects = contract["effects"]
    calls = contract["calls"]
    named = set()

    for kind in ("calls", "virtual_calls", "interface_calls", "delegate_calls"):
        for call in calls.get(kind, []):
            named.add(call.split("::")[-1])

    return {
        "native_length": contract.get("native_length", -1),
        "boundaries": len(contract.get("runtime_boundaries", [])),
        "property_writes": {call.split("::")[-1][len("set_"):]
                            for kind in ("calls", "virtual_calls", "interface_calls")
                            for call in calls.get(kind, [])
                            if call.split("::")[-1].startswith("set_")},
        "field_writes": set(effects.get("field_writes", [])) | set(effects.get("static_writes", [])),
        "field_reads": set(effects.get("field_reads", [])) | set(effects.get("static_reads", [])),
        "calls": named,
        "loops": len(contract["control"]["loop_headers"]),
        "branches": contract["control"]["branches"],
        "throws": contract["throws"],
    }


def backing_name(name: str) -> str:
    """`_gameState`, `m_GameState` and `GameState` are one member under the usual backing-field names."""
    if name.startswith("m_"):
        name = name[2:]
    return name.lstrip("_").lower()


def verdict(source: dict, found: dict, declared_fields: set[str], project_members: set[str],
            calls_complete: bool = False) -> tuple[str, list[str]]:
    """`calls_complete`: every call the machine code makes is named in the recovered body - no runtime
    boundary and no placeholder of any kind. Then a project call the source makes and the body does not
    name is absent from the machine code itself: the native compiler inlined it, exactly as it inlines
    framework calls. Without that evidence the two cases stay apart. Off unless the caller has checked."""
    notes = []

    # A coroutine's body is not in the method at all: the compiler moved it into a state machine and
    # left a kickoff that allocates one and returns it. Comparing the kickoff against the source text
    # measures the compiler, not the recovery.
    if source["coroutine"]:
        return "NOT_AVAILABLE", ["coroutine: the body is in a compiler-generated state machine"]

    if not found["field_writes"] and not found["field_reads"] and not found["calls"]:
        if source["field_writes"] or source["field_reads"] or source["calls"]:
            # A body of a few bytes that reaches no runtime boundary is one the analysis recovered
            # whole, so a call the source names is absent from the *machine code* - il2cpp inlined it,
            # which is what it does to a one-line forwarding method. `AndroidOnly.IsGoodPlatform`
            # returns `DeviceInfo.IsAndroid()`, its native body is eight bytes, and `return true;` is
            # the right recovery. Without the length the two are indistinguishable.
            if 0 <= found["native_length"] <= INLINE_BODY_BYTES and found["boundaries"] == 0:
                return "SEMANTICALLY_EQUIVALENT", [
                    f"the body is {found['native_length']} bytes of machine code and reaches no "
                    "runtime boundary, so what the source calls was inlined"]

            return "FALLBACK", ["recovered body reaches no effect and no call"]
        return "EXACT", []

    # `x.Prop = v` in the source is a property write, and the recovery names it as the call it
    # compiles to. Counting it as a lost field write reported every `transform.position = …` and
    # every `Time.timeScale = 0` as unrecovered while the setter call was right there.
    setters = {name[len("set_"):] for name in found["calls"] if name.startswith("set_")}
    # `OnModified += handler` subscribes to an event: the compiler writes it as a call to `add_OnModified`
    # (or `remove_`), so the "write" the source text shows is that call.
    accessors = {name[len("add_"):] for name in found["calls"] if name.startswith("add_")}
    accessors |= {name[len("remove_"):] for name in found["calls"] if name.startswith("remove_")}
    written = found["field_writes"] | setters | found["property_writes"] | accessors

    lost_writes = source["field_writes"] - written
    # The other side of the inlined-accessor rule below: the source's property write is the recovered
    # body's store to that property's backing field.
    stored = {backing_name(name) for name in written}
    lost_writes = {name for name in lost_writes if backing_name(name) not in stored}
    lost_reads = source["field_reads"] - found["field_reads"]
    lost_calls = source["calls"] - found["calls"]

    # Only a write to a field the type itself declares can be a write the source does not make. A
    # recovered body writes the members of value-typed temporaries - the x, y and z of a Vector3 that
    # an inlined `MoveTowards` computed - and those are not state a reader could observe.
    invented_writes = (found["field_writes"] & declared_fields) - source["field_writes"]
    # A property the source reads or writes is compiled to an accessor, and an accessor that il2cpp
    # inlined writes its backing field in the caller: `GameState = Win` becomes a store to `_gameState`,
    # and a lazy getter (`text => _text ??= GetComponent<...>()`) stores on a read. The pairing is by
    # the backing-field naming convention (`_x`, `m_X`, `x`), and only for a member the source names.
    named_by_source = {backing_name(name) for name in source["field_writes"] | source["field_reads"]}
    explained = {name for name in invented_writes if backing_name(name) in named_by_source}
    if explained:
        notes.append(f"writes an inlined accessor makes: {sorted(explained)}")
        invented_writes -= explained

    if lost_writes:
        notes.append(f"writes not recovered: {sorted(lost_writes)}")
    if lost_reads:
        notes.append(f"reads not recovered: {sorted(lost_reads)}")
    # A call the source makes into a type this project does not declare is one il2cpp may have
    # inlined - `Vector3.MoveTowards` and `Quaternion.Euler` are gone before there is anything to
    # recover, and what remains is the arithmetic they were made of. That is not evidence the
    # recovery lost anything, and it is not evidence it did not: the two are reported apart rather
    # than one of them being assumed.
    lost_own_calls = lost_calls & project_members
    lost_framework_calls = lost_calls - project_members
    if calls_complete and lost_own_calls:
        notes.append(f"calls absent from the machine code (every call the body makes is resolved): {sorted(lost_own_calls)}")
        lost_own_calls = set()

    if lost_own_calls:
        notes.append(f"calls into this project not named: {sorted(lost_own_calls)}")
    if lost_framework_calls:
        notes.append(f"framework calls absent, consistent with inlining: {sorted(lost_framework_calls)}")
    if invented_writes:
        notes.append(f"writes the source does not make: {sorted(invented_writes)}")

    # A loop the source runs and the recovery does not is a behaviour difference a reader would see;
    # the other direction is not, because il2cpp unrolls and inlines.
    if found["loops"] < source["loops"]:
        notes.append(f"loops: source {source['loops']}, recovered {found['loops']}")
        return "MISMATCH", notes

    if invented_writes:
        return "MISMATCH", notes

    if lost_writes:
        return "PARTIAL", notes

    if not lost_reads and not lost_calls and found["branches"] == source["branches"]:
        return "EXACT", notes

    if not lost_own_calls:
        return "SEMANTICALLY_EQUIVALENT", notes

    return "PARTIAL", notes


def self_test() -> int:
    """That each rule the verdict rests on actually decides something.

    A measure that reports 1.0000 is indistinguishable from one that cannot report anything else, and
    this project has shipped two of those. Each case below is red if the rule it names is removed.
    """
    base_source = {"field_writes": {"hp"}, "field_reads": {"hp"}, "calls": {"Die"},
                   "loops": 0, "branches": 1, "throws": 0, "coroutine": False}
    base_found = {"field_writes": {"hp"}, "field_reads": {"hp"}, "calls": {"Die"},
                  "property_writes": set(), "loops": 0, "branches": 1, "throws": 0,
                  "native_length": 256, "boundaries": 0}
    declared = {"hp", "score", "_state"}
    members = {"Die", "Player"}

    cases = [
        ("identical", base_source, base_found, "EXACT"),
        ("a write lost", base_source, {**base_found, "field_writes": set()}, "PARTIAL"),
        ("a write invented", base_source, {**base_found, "field_writes": {"hp", "score"}}, "MISMATCH"),
        ("a loop lost", {**base_source, "loops": 1}, base_found, "MISMATCH"),
        ("a call into the project lost", base_source, {**base_found, "calls": set()}, "PARTIAL"),
        ("a framework call absent",
         {**base_source, "calls": {"Die", "MoveTowards"}}, base_found, "SEMANTICALLY_EQUIVALENT"),
        ("nothing recovered", base_source,
         {**base_found, "field_writes": set(), "field_reads": set(), "calls": set()}, "FALLBACK"),
        ("nothing recovered from a body too small to call anything", base_source,
         {**base_found, "field_writes": set(), "field_reads": set(), "calls": set(),
          "native_length": 8}, "SEMANTICALLY_EQUIVALENT"),
        ("nothing recovered from a small body that left managed code", base_source,
         {**base_found, "field_writes": set(), "field_reads": set(), "calls": set(),
          "native_length": 8, "boundaries": 1}, "FALLBACK"),
        ("a coroutine", {**base_source, "coroutine": True}, base_found, "NOT_AVAILABLE"),
        ("a property write matched by its setter",
         base_source, {**base_found, "field_writes": set(), "calls": {"Die", "set_hp"}},
         "EXACT"),
        ("an event subscription matched by its accessor",
         {**base_source, "field_writes": {"hp", "OnDied"}},
         {**base_found, "calls": {"Die", "add_OnDied"}}, "EXACT"),
        # Two halves of one rule: without the evidence a lost project call stays a loss; with it, the call
        # is not in the machine code at all.
        ("a backing field written by an inlined setter",
         {**base_source, "field_writes": {"hp", "State"}},
         {**base_found, "field_writes": {"hp", "_state"}}, "EXACT"),
        ("a project call unnamed, calls not known complete",
         base_source, {**base_found, "calls": set()}, "PARTIAL", False),
        ("a project call unnamed, every call the body makes resolved",
         base_source, {**base_found, "calls": set()}, "SEMANTICALLY_EQUIVALENT", True),
    ]

    failures = 0

    for name, source, found, expected, *complete in cases:
        status, notes = verdict(source, found, declared, members, calls_complete=bool(complete and complete[0]))

        if status != expected:
            print(f"FAIL {name}: expected {expected}, got {status} ({'; '.join(notes)})")
            failures += 1
        else:
            print(f"ok   {name}: {status}")

    print(f"{len(cases) - failures}/{len(cases)} cases")
    return 1 if failures else 0


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("source", nargs="?")
    parser.add_argument("rip", nargs="?")
    parser.add_argument("--self-test", action="store_true")
    # The build's own facts, not a guess: a player build defines no UNITY_EDITOR and exactly one
    # platform, and comparing against the other branches reports a correct recovery as a total loss.
    parser.add_argument("--platform", default="android", choices=("android", "ios"))
    parser.add_argument("--unity", default="2022.3")
    parser.add_argument("--json")
    parser.add_argument("--verbose", action="store_true")
    arguments = parser.parse_args()

    if arguments.self_test:
        return self_test()

    defines = source_preprocessor.defines_for(arguments.unity, arguments.platform)
    harvested, declared = source_oracle.harvest(pathlib.Path(arguments.source), defines=defines)
    bodies = load(pathlib.Path(arguments.rip))

    if not bodies:
        print("NO_SEMANTIC_IR")
        return 3

    # (type, name) -> contract. Arity is not in the record's key, and a method recovered under one
    # overload is still that method's behaviour.
    contracts = {}

    for assembly, methods in bodies.items():
        for rva, body in methods.items():
            key = (body.get("declaringType", "").split(".")[-1], body.get("method", ""))
            contracts.setdefault(key, behavior.contract(body))

    # Every method and type name the project itself declares. A call the source makes to one of
    # these and the recovery does not name is a real loss; a call to anything else may be inlining.
    project_members = {name for _type, name, _arity in harvested}
    project_members |= {type_name for type_name, _name, _arity in harvested}

    results = {}
    counts = collections.Counter()

    # Keyed by arity too: a type with two overloads of one name wrote twice into the report and the
    # last won, so the JSON held fewer rows than the printed count and the two disagreed by five.
    for (type_name, name, arity), body in harvested.items():
        contract = contracts.get((type_name, name))

        if contract is None:
            counts["NOT_AVAILABLE"] += 1
            results[f"{type_name}.{name}/{arity}"] = {"status": "NOT_AVAILABLE", "notes": []}
            continue

        source = source_behavior(body, declared.get(type_name, set()))
        found = recovered_behavior(contract)
        status, notes = verdict(source, found, declared.get(type_name, set()), project_members)
        counts[status] += 1
        results[f"{type_name}.{name}/{arity}"] = {
            "status": status,
            "notes": notes,
            "source": {key: sorted(value) if isinstance(value, set) else value for key, value in source.items()},
            "recovered": {key: sorted(value) if isinstance(value, set) else value for key, value in found.items()},
        }

        if arguments.verbose and status not in ("EXACT", "SEMANTICALLY_EQUIVALENT"):
            print(f"{status:24} {type_name}.{name}  {'; '.join(notes)}")

    compared = sum(count for status, count in counts.items() if status != "NOT_AVAILABLE")

    for status in ("EXACT", "SEMANTICALLY_EQUIVALENT", "PARTIAL", "MISMATCH", "FALLBACK", "NOT_AVAILABLE"):
        print(f"{status:24} {counts[status]}")

    if compared:
        good = counts["EXACT"] + counts["SEMANTICALLY_EQUIVALENT"]
        print(f"behaviour_equivalence_rate {good / compared:.4f} ({good}/{compared})")
    else:
        print("behaviour_equivalence_rate None (0 compared)")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(results, indent=1))

    return 0


if __name__ == "__main__":
    sys.exit(main())
