#!/usr/bin/env python3
"""Every il2cpp runtime helper managed code still calls unresolved, ranked, with what calls it.

`RUNTIME_HELPER` is the largest reason an unresolved call has, and a count of 718 says nothing about
which of them is one thing and which is many. A helper is worth naming when the evidence is decisive,
and the decisive evidence is rarely the address: it is the *shape of the call sites*. A helper every
one of whose callers is an event accessor is a different kind of fact from one called from two
hundred unrelated methods, and only the first can be named without reading machine code.

So the ranking here is by call sites, and the columns are the ones that let a reader decide: how many
distinct methods and assemblies reach it, how concentrated the caller names are, and what the first
instructions at the target look like (which the ripper already recorded).

Usage: runtime_helper_report.py <unresolved-calls.tsv> [--json out.json] [--top N]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

# The dump's columns, as `Il2CppIlRecoveryOutputFormat.RecordUnresolvedCall` writes them.
KIND, ASSEMBLY, TYPE, METHOD, ADDRESS, CANDIDATES, BEHIND, BEHIND_CANDIDATES, EXPORT, EXPORT_BEHIND, SHAPE, REASON = range(12)

ACCESSOR = re.compile(r'^(get|set)_')
EVENT = re.compile(r'^(add|remove)_')


def caller_shape(name: str) -> str:
    if EVENT.match(name):
        return "event accessor"
    if ACCESSOR.match(name):
        return "property accessor"
    if name in (".ctor", ".cctor"):
        return "constructor"
    return "ordinary method"


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("dump")
    parser.add_argument("--json")
    parser.add_argument("--top", type=int, default=20)
    arguments = parser.parse_args()

    rows = [
        line.rstrip("\n").split("\t")
        for line in pathlib.Path(arguments.dump).read_text(encoding="utf-8", errors="replace").splitlines()
        if line.strip()
    ]

    helpers = collections.defaultdict(lambda: {
        "calls": 0, "methods": set(), "assemblies": set(),
        "callerShapes": collections.Counter(), "shape": "-", "behind": "", "export": "-", "reason": "-",
    })

    for row in rows:
        if len(row) <= REASON:
            continue
        if row[REASON] not in ("RUNTIME_HELPER", "RUNTIME_HELPER_VENEER"):
            continue

        entry = helpers[row[ADDRESS]]
        entry["calls"] += 1
        entry["methods"].add(f"{row[TYPE]}::{row[METHOD]}")
        entry["assemblies"].add(row[ASSEMBLY])
        entry["callerShapes"][caller_shape(row[METHOD])] += 1
        entry["shape"] = row[SHAPE]
        entry["behind"] = row[BEHIND]
        entry["export"] = row[EXPORT_BEHIND] if row[EXPORT] == "-" else row[EXPORT]
        entry["reason"] = row[REASON]

    ranked = sorted(helpers.items(), key=lambda pair: -pair[1]["calls"])
    total = sum(entry["calls"] for _, entry in ranked)

    print(f"runtime helpers: {len(ranked)} addresses, {total} call sites\n")
    header = f"{'address':>10}{'calls':>7}{'methods':>9}{'asm':>5}  {'shape':<18}{'behind':>10}  caller profile"
    print(header)
    print("-" * (len(header) + 20))

    for address, entry in ranked[:arguments.top]:
        shapes = entry["callerShapes"]
        top, count = shapes.most_common(1)[0]
        # A helper whose call sites are ALL one kind of member is the case that can be named from the
        # call sites alone; anything mixed needs the machine code read instead.
        profile = f"{top} {count}/{entry['calls']}" + (" (all)" if count == entry["calls"] else "")
        print(f"{address:>10}{entry['calls']:>7}{len(entry['methods']):>9}{len(entry['assemblies']):>5}  "
              f"{entry['shape']:<18}{entry['behind']:>10}  {profile}")

    if len(ranked) > arguments.top:
        tail = sum(entry["calls"] for _, entry in ranked[arguments.top:])
        print(f"\n... and {len(ranked) - arguments.top} more addresses, {tail} call sites between them")

    named = [(a, e) for a, e in ranked if e["export"] not in ("-", "")]
    print(f"\naddresses the binary's export table names: {len(named)}")

    uniform = [(a, e) for a, e in ranked if len(e["callerShapes"]) == 1 and e["calls"] >= 10]
    print(f"addresses whose call sites are all one kind of member (>=10 calls): {len(uniform)}")
    for address, entry in uniform:
        print(f"  {address:>10}  {entry['calls']:>5} calls, all {next(iter(entry['callerShapes']))}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "callSites": total,
            "helpers": [
                {
                    "address": address,
                    "calls": entry["calls"],
                    "methods": len(entry["methods"]),
                    "assemblies": sorted(entry["assemblies"]),
                    "nativeShape": entry["shape"],
                    "behindVeneer": entry["behind"],
                    "exportedName": entry["export"],
                    "callerShapes": dict(entry["callerShapes"]),
                }
                for address, entry in ranked
            ],
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
