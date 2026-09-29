#!/usr/bin/env python3
"""Interface dispatch regression corpus: select from the recovery's own evidence rows, check against a rip.

Iteration 062. `InterfaceInvokeDataRecovery` writes one row per resolved dispatch to
`CPP2IL_DUMP_INTERFACE_CALLS`: caller, CALL or TAIL, receiver, interface class, slot, the interface
method, its token, the RVA (always RUNTIME_DISPATCH - which implementation runs is the receiver's
class's decision at run time), the generic context, confidence and evidence.

--select builds the corpus from those rows, one entry per case the brief names that a row can
establish on its own:

  CALL                 an ordinary interface call
  TAIL                 an interface call in tail position (an indirect jump)
  GENERIC_INTERFACE    the interface is a generic instance (IDictionary<K,V>, ICollection<T>)
  GENERIC_RECEIVER     the receiver is typed by an open parameter or a generic instance
  EXPLICIT_IMPL        the caller is an explicit interface implementation (System.Collections.IList.X)

"In an if", "in a loop" and "multiple implementations" are not facts a row carries - the first two
are about the caller's control flow, the third about the program's type hierarchy - so they are
reported NOT_SELECTABLE_FROM_ROWS rather than filled with a guess.

--check reads the corpus against a rip: the caller's recovered C# must still name the interface
method (as a call, a property access or an indexer). An entry whose caller is not in the rip is
NOT_PRESENT, never a pass.
"""
import argparse
import collections
import json
import pathlib
import re
import sys

CASES = ("CALL", "TAIL", "GENERIC_INTERFACE", "GENERIC_RECEIVER", "EXPLICIT_IMPL")
UNSELECTABLE = ("IN_IF", "IN_LOOP", "MULTIPLE_IMPLEMENTATIONS")


def rows(path):
    for line in pathlib.Path(path).read_text(errors="replace").splitlines():
        cells = line.split("\t")
        if len(cells) < 11:
            continue
        caller, kind, receiver, interface, slot, target, token, rva, generic, confidence, evidence = cells[:11]
        yield {"caller": caller, "kind": kind, "receiver": receiver, "interface": interface, "slot": slot,
               "target": target, "token": token, "rva": rva, "generic": generic, "confidence": confidence}


def cases_of(row):
    found = ["TAIL" if row["kind"] == "TAIL" else "CALL"]
    if row["generic"]:
        found.append("GENERIC_INTERFACE")
    receiver_type = re.search(r"\(([^()]*)\)\s*$", row["receiver"])
    if receiver_type and re.search(r"(^|[<, ])T\w*[>,]?|`\d", receiver_type.group(1)):
        found.append("GENERIC_RECEIVER")
    method = row["caller"].split("::", 1)[-1]
    if "." in method and not method.startswith((".ctor", ".cctor")):
        found.append("EXPLICIT_IMPL")
    return found


def select(dumps, per_case):
    corpus = []
    for fixture, path in dumps:
        taken = collections.Counter()
        seen = set()
        for row in rows(path):
            for case in cases_of(row):
                key = (row["caller"], row["target"], case)
                if taken[case] >= per_case or key in seen:
                    continue
                seen.add(key)
                taken[case] += 1
                corpus.append({"fixture": fixture, "case": case, **row})
    return {"entries": corpus, "notSelectable": {case: "not a fact an evidence row carries" for case in UNSELECTABLE}}


def spelled(target):
    """How C# can write a call to the interface method: X(, a property access, or an indexer."""
    name = target.split("::")[-1]
    if name in ("get_Item", "set_Item"):
        return [re.compile(r"\[")]
    if name.startswith(("get_", "set_", "add_", "remove_")):
        prop = name.split("_", 1)[1]
        return [re.compile(rf"\b{re.escape(prop)}\b"), re.compile(rf"\b{re.escape(name)}\(")]
    return [re.compile(rf"\b{re.escape(name)}\b")]


def check(corpus, rip, fixture):
    game = next((d for d in pathlib.Path(rip).iterdir() if (d / "Assets").is_dir()), None) if pathlib.Path(rip).is_dir() else None
    if game is None:
        return {"status": "PROJECT_ROOT_MISMATCH"}
    by_type = collections.defaultdict(list)
    for path in (game / "Assets").rglob("*.cs"):
        by_type[path.stem].append(path)
    results = collections.Counter()
    failures = []
    for entry in corpus["entries"]:
        if entry["fixture"] != fixture:
            continue
        type_name, method = entry["caller"].split("::", 1)
        simple = re.split(r"[.+]", re.sub(r"`\d+.*", "", type_name))[-1]
        files = by_type.get(simple, [])
        if not files:
            results["NOT_PRESENT"] += 1
            continue
        text = "\n".join(p.read_text(errors="replace") for p in files)
        text = re.sub(r'\[NativeSource\(Body = ".*?"\)\]', "", text, flags=re.S)
        method_name = method.split(".")[-1]
        declaration = f" {method_name[4:]}" if method_name.startswith(("get_", "set_")) else f" {method_name}("
        # The row names the caller but not its RVA, so every overload of that name is read: the entry
        # holds if any of them names the interface method. That is what this checks, and no more.
        starts = [m.start() for m in re.finditer(re.escape(declaration), text)]
        bodies = [text[start:start + 20000] for start in starts]
        if not starts:
            results["NOT_PRESENT"] += 1
        elif any(p.search(body) for body in bodies for p in spelled(entry["target"])):
            results["NAMED"] += 1
        else:
            results["NOT_NAMED"] += 1
            failures.append(f"{entry['case']} {entry['caller']} -> {entry['target']}")
    return {"status": "CHECKED", "results": dict(results), "failures": failures}


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("--select", nargs="+", metavar="FIXTURE=DUMP")
    parser.add_argument("--per-case", type=int, default=3)
    parser.add_argument("--corpus", default="Test/interface-dispatch-corpus.json")
    parser.add_argument("--check", metavar="RIP")
    parser.add_argument("--fixture")
    args = parser.parse_args()

    if args.select:
        dumps = [tuple(item.split("=", 1)) for item in args.select]
        corpus = select(dumps, args.per_case)
        pathlib.Path(args.corpus).write_text(json.dumps(corpus, indent=1))
        tally = collections.Counter((e["fixture"], e["case"]) for e in corpus["entries"])
        for (fixture, case), count in sorted(tally.items()):
            print(f"{fixture:16} {case:18} {count}")
        for case in UNSELECTABLE:
            print(f"{'-':16} {case:18} NOT_SELECTABLE_FROM_ROWS")
        return 0

    if args.check:
        corpus = json.loads(pathlib.Path(args.corpus).read_text())
        result = check(corpus, args.check, args.fixture)
        print(json.dumps({k: v for k, v in result.items() if k != "failures"}))
        for failure in result.get("failures", []):
            print("  NOT_NAMED " + failure)
        return 0 if result.get("status") == "CHECKED" and not result.get("failures") else 1

    parser.print_help()
    return 2


if __name__ == "__main__":
    sys.exit(main())
