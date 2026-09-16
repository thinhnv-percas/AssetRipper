#!/usr/bin/env python3
"""Plans, and where possible runs, an execution comparison between a recovered method and its source.

Every other measure in this project is static. The source oracle compares the operations two texts
reach; it cannot say the recovered method computes the same answer, and a body that reaches every
operation class the source does can still be wrong by a sign. Only running both and comparing the
results answers that.

Most of a Unity game cannot be run here, and saying so precisely is the point of this planner. Each
paired method is placed in one of three tiers, from evidence in the two bodies:

  EXECUTABLE_WITHOUT_UNITY   static, primitives in and out, and neither body names a Unity type.
                             These can be invoked directly against the recovered assembly.
  REQUIRES_UNITY             the method reaches the engine - a component, a transform, PlayerPrefs.
                             A comparison needs a Unity player, which this container does not have.
  REQUIRES_INSTANCE          an instance method of a type whose construction needs the engine.

A tier is not a result. A planned case that was not executed is `NOT_RUN` with the reason, and
`runtime_equivalence_rate` is computed over the cases that ran and over nothing else - a rate of 1.0
over zero cases is reported as `None`, never as a pass.

The plan is written for `Test/Tools/RuntimeEquivalence`, which does the invoking; this file never
claims a result it did not get back from it.

Usage: runtime_equivalence.py <source project> <recovered game directory>
                              [--plan plan.json] [--results results.json] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
from source_oracle import (  # noqa: E402
    DECLARATION, NOT_A_METHOD, TYPE_DECLARATION, harvest,
)

# A type whose value this harness can produce and compare without an engine behind it.
PRIMITIVES = {"void", "bool", "byte", "sbyte", "short", "ushort", "int", "uint", "long", "ulong",
              "float", "double", "decimal", "char", "string"}

# Naming any of these means the method reaches the engine. Deliberately a prefix test on the
# namespace rather than a list of APIs: a new Unity type is still a Unity type.
UNITY_MARKERS = re.compile(
    r"\b(UnityEngine|UnityEditor|MonoBehaviour|GameObject|Transform|Rigidbody|Collider|Vector[234]|"
    r"Quaternion|PlayerPrefs|Time\.|Input\.|Camera|Animator|AudioSource|SceneManager|Resources\.|"
    r"Instantiate|Destroy|GetComponent|Debug\.)\b")

EXECUTABLE, REQUIRES_UNITY, REQUIRES_INSTANCE = (
    "EXECUTABLE_WITHOUT_UNITY", "REQUIRES_UNITY", "REQUIRES_INSTANCE")
TIERS = [EXECUTABLE, REQUIRES_UNITY, REQUIRES_INSTANCE]

# The one value a result may take when nothing ran. It is not a tier and not a pass.
NOT_RUN = "NOT_RUN"


def signature_is_primitive(returns, parameters):
    if returns.strip().rstrip("?") not in PRIMITIVES:
        return False
    for parameter in [p.strip() for p in parameters.split(",") if p.strip()]:
        without_default = parameter.split("=")[0].strip()
        words = without_default.replace("[]", "").split()
        if len(words) < 2 or words[-2].rstrip("?") not in PRIMITIVES:
            return False
    return True


def tier_of(declaration, body, source_body):
    """Which tier a method is in, and the evidence that put it there."""
    modifiers = declaration.get("modifiers", "")
    returns, parameters = declaration.get("returns", ""), declaration.get("parameters", "")
    reaches_unity = bool(UNITY_MARKERS.search(source_body) or UNITY_MARKERS.search(body))
    if reaches_unity:
        return REQUIRES_UNITY, "the body names a Unity type"
    if "static" not in modifiers:
        return REQUIRES_INSTANCE, "an instance method needs a constructed receiver"
    if not signature_is_primitive(returns, parameters):
        return REQUIRES_UNITY, f"signature is not primitive: {returns} ({parameters})"
    return EXECUTABLE, "static, primitives in and out, no Unity type named"


def arguments_for(parameters):
    """A small set of input vectors per signature: the edges, and one ordinary value."""
    types = []
    for parameter in [p.strip() for p in parameters.split(",") if p.strip()]:
        words = parameter.split("=")[0].strip().split()
        types.append(words[-2] if len(words) >= 2 else "int")
    samples = {
        "int": [0, 1, -1, 2147483647, -2147483648, 7],
        "uint": [0, 1, 4294967295, 7],
        "long": [0, 1, -1, 9223372036854775807, 7],
        "float": [0.0, 1.0, -1.0, 0.5, 1e30],
        "double": [0.0, 1.0, -1.0, 0.5],
        "bool": [True, False],
        "string": ["", "a", "0", "hello"],
        "char": ["a", "0"],
    }
    vectors, width = [], 6
    for index in range(width):
        vector = []
        for name in types:
            values = samples.get(name.rstrip("?"), [0])
            vector.append(values[index % len(values)])
        vectors.append(vector)
    return [list(vector) for vector in dict.fromkeys(tuple(v) for v in vectors)]


def declarations(root, skip=()):
    """{(type, name, arity): declaration} for a tree of C#.

    Read from the declaration line rather than from a harvested body, because a harvested body
    begins at the brace that opens it - which is the next line whenever the source puts it there,
    so 32 of 36 methods had no declaration in them at all and silently fell out of the plan.
    """
    found = {}
    for path in sorted(root.rglob("*.cs")):
        if any(part in skip for part in path.parts):
            continue
        current_type = "<file>"
        for line in path.read_text(encoding="utf-8", errors="replace").splitlines():
            type_match = TYPE_DECLARATION.match(line)
            if type_match:
                current_type = type_match["name"]
                continue
            match = DECLARATION.match(line)
            if not match or match["name"] in NOT_A_METHOD or match["returns"] in NOT_A_METHOD:
                continue
            parameters = match["parameters"].strip()
            arity = 0 if not parameters else parameters.count(",") + 1
            found.setdefault((current_type, match["name"], arity), {
                "modifiers": match["modifiers"] or "",
                "returns": match["returns"] or "",
                "parameters": match["parameters"] or "",
            })
    return found


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("source")
    parser.add_argument("game")
    parser.add_argument("--plan")
    parser.add_argument("--results", help="a results file written by Test/Tools/RuntimeEquivalence")
    parser.add_argument("--json")
    parser.add_argument("--name")
    arguments = parser.parse_args()

    project, game = pathlib.Path(arguments.source).resolve(), pathlib.Path(arguments.game).resolve()
    if not project.is_dir():
        print(f"SOURCE_NOT_AVAILABLE {project}")
        return 2
    if not game.is_dir():
        print(f"RIP_NOT_AVAILABLE {game}")
        return 2

    # The source's own scripts only, and the recovery without its injected attributes - the same
    # two roots the source oracle pairs over, so the two measures speak about one population.
    source_bodies, _ = harvest(project / "Assets", skip=("Library", "Packages"))
    recovered_bodies, _ = harvest(game, skip=("Cpp2ILInjected", "AssetRipperInjected"))
    source_declarations = declarations(project / "Assets", skip=("Library", "Packages"))

    cases, tiers = [], collections.Counter()

    for key, source_body in sorted(source_bodies.items()):
        recovered_body = recovered_bodies.get(key)
        if recovered_body is None:
            continue
        declaration = source_declarations.get(key)
        if declaration is None:
            continue
        tier, why = tier_of(declaration, recovered_body, source_body)
        tiers[tier] += 1
        if tier != EXECUTABLE:
            continue
        type_name, name, _ = key
        cases.append({
            "type": type_name,
            "method": name,
            "signature": f"{declaration['returns']} {name}({declaration['parameters']})",
            "arguments": arguments_for(declaration["parameters"]),
            "why": why,
        })

    results = {}
    if arguments.results and pathlib.Path(arguments.results).exists():
        results = json.loads(pathlib.Path(arguments.results).read_text()).get("cases", {})

    outcomes = collections.Counter()
    for case in cases:
        key = f"{case['type']}::{case['signature']}"
        outcome = results.get(key, {}).get("outcome", NOT_RUN)
        case["outcome"] = outcome
        outcomes[outcome] += 1
    for _ in range(tiers[REQUIRES_UNITY] + tiers[REQUIRES_INSTANCE]):
        outcomes[NOT_RUN] += 1

    ran = sum(count for outcome, count in outcomes.items() if outcome != NOT_RUN)
    equivalent = outcomes.get("EQUIVALENT", 0)

    report = {
        "fixture": arguments.name or game.name,
        "paired_methods": sum(tiers.values()),
        "tiers": {tier: tiers[tier] for tier in TIERS},
        "cases_planned": len(cases),
        "outcomes": dict(outcomes),
        "cases_run": ran,
        # None over zero cases. A rate of 1.0 computed over nothing is the shape of every false pass
        # this project has had to unpick.
        "runtime_equivalence_rate": round(equivalent / ran, 4) if ran else None,
        "not_run_reason": None if ran else "UNITY_NOT_AVAILABLE_AND_NO_RESULTS_SUPPLIED",
        "cases": cases,
    }

    print(f"{report['fixture']}: {report['paired_methods']} paired methods")
    for tier in TIERS:
        print(f"  {tier:<26} {tiers[tier]}")
    print(f"  cases planned              {len(cases)}")
    print(f"  cases run                  {ran}")
    print(f"  runtime_equivalence_rate   {report['runtime_equivalence_rate']}"
          f"{'' if ran else '  (' + report['not_run_reason'] + ')'}")

    if arguments.plan:
        pathlib.Path(arguments.plan).write_text(json.dumps({"cases": cases}, indent=2))
        print(f"  wrote plan {arguments.plan}")
    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))
        print(f"  wrote {arguments.json}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
