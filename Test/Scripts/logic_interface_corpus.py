#!/usr/bin/env python3
"""A regression corpus of interface calls, chosen from the dispatch pass's own evidence and, where a
source oracle is independent, confirmed against the programmer's text.

Iteration 063 (brief §6-§9). `interface_dispatch_corpus.py` (062) chose by call shape. This chooses by the
four priorities the brief names - a generic interface, a generic virtual, an interface on a generic
receiver, and a lookup whose interface class comes from the runtime generic context - and adds a second,
independent column: for a caller in a package whose source is proven to be the build's (JellyBlast's
TMP, UGUI, VisualScripting, Mathematics, Voodoo, PathCreator), does the source method name the interface
method the recovery says it calls?

The source is confirmation only. The native evidence decides what is called: a row exists because
`lookup(receiver, interface class, slot)` reaches the dispatch pointer and the slot is
`Il2CppMethodDefinition.slot` - never a name match. A source that does not name the method is not a
refutation either: the caller may reach it through a helper il2cpp inlined, so that column reads
SOURCE_SILENT, not WRONG.

  --select FIXTURE=EVIDENCE.tsv ...   choose the corpus
  --check RIP --fixture FIXTURE       each entry's caller, in the recovered C#, still names the method

Usage: logic_interface_corpus.py --select JellyBlastV2=iface.tsv [--source CHECKOUT --provenance JSON]
                                 [--corpus Test/logic-interface-corpus.json] [--per-case 6]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))

COLUMNS = ("caller", "kind", "receiver", "interface", "slot", "target", "token", "rva", "generic", "confidence", "evidence")
INDEPENDENT = ("PROVEN_BUILD_MATCH", "LIKELY_MATCH")


def rows(path):
    for line in open(path, encoding="utf-8", errors="replace"):
        cells = line.rstrip("\n").split("\t")
        if len(cells) >= len(COLUMNS) - 1:
            yield dict(zip(COLUMNS, cells + [""] * (len(COLUMNS) - len(cells))))


def categories(row):
    """Which of the brief's priorities a row exhibits, read off the row itself."""
    found = []
    target_type = row["target"].split("::")[0]
    if "`" in target_type:
        found.append("GENERIC_INTERFACE")
    if row["generic"] or re.search(r"\((?:[^()]*)[<`][^()]*\)$", row["receiver"]):
        found.append("GENERIC_RECEIVER")
    if "`" in row["target"].split("::")[-1] or re.search(r"::\w+<", row["target"]):
        found.append("GENERIC_VIRTUAL")
    # The interface class operand is a load rather than a metadata usage: it came from somewhere at run
    # time, which in shared generic code is the runtime generic context.
    if row["interface"].startswith("[") or "rgctx" in row["interface"].lower() or "+" in row["interface"].split("(")[0]:
        found.append("RUNTIME_CONTEXT_CLASS")
    found.append("TAIL" if row["kind"] == "TAIL" else "CALL")
    return found


def source_bodies(checkout, provenance_path):
    """(type short name, method) -> source body text, over the independent assemblies only."""
    import jellyblast_source_oracle as oracle
    import source_preprocessor

    provenance = {r["assembly"]: r for r in json.loads(pathlib.Path(provenance_path).read_text())}
    asmdefs = oracle.asmdef_map(checkout)
    defines = source_preprocessor.defines_for("2022.3", "ios")
    bodies = {}
    for assembly, row in provenance.items():
        if row["status"] not in INDEPENDENT:
            continue
        _asmdef, directory = asmdefs.get(row.get("sourceAssembly"), (None, None))
        if directory is None:
            continue
        found, _declared, decompiled = oracle.harvest(list(oracle.owned_files(directory)), defines)
        if decompiled:
            continue
        for (type_name, name, _arity), body in found.items():
            bodies.setdefault((type_name, name), []).append(body)
    return bodies


def confirmation(row, bodies):
    if bodies is None:
        return "NO_SOURCE"
    caller_type, _, caller_method = row["caller"].partition("::")
    short = caller_type.split(".")[-1].split("+")[-1].split("`")[0]
    candidates = bodies.get((short, caller_method))
    if not candidates:
        return "NO_SOURCE"
    method = row["target"].split("::")[-1].split("<")[0]
    # An interface property or indexer is an accessor in metadata and a member access in C#.
    names = {method}
    if method.startswith(("get_", "set_")):
        names.add(method[4:])
    if method in ("get_Item", "set_Item"):
        names.add("[")
    for body in candidates:
        for name in names:
            if name == "[" and "[" in body:
                return "SOURCE_CONFIRMED"
            if re.search(r"\b" + re.escape(name) + r"\b", body):
                return "SOURCE_CONFIRMED"
    return "SOURCE_SILENT"


def select(dumps, per_case, bodies):
    chosen, seen = [], set()
    counts = collections.Counter()
    pool = collections.defaultdict(list)
    for fixture, path in dumps:
        for row in rows(path):
            if row["confidence"] != "EXACT":
                continue
            key = (fixture, row["caller"], row["target"])
            if key in seen:
                continue
            seen.add(key)
            row["fixture"] = fixture
            row["categories"] = categories(row)
            row["sourceConfirmation"] = confirmation(row, bodies)
            for category in row["categories"]:
                pool[(fixture, category)].append(row)

    taken = set()
    # Priority order from the brief: the rarer, harder shapes first so a small per-case budget keeps them.
    order = ("RUNTIME_CONTEXT_CLASS", "GENERIC_VIRTUAL", "GENERIC_RECEIVER", "GENERIC_INTERFACE", "TAIL", "CALL")
    for fixture in sorted({f for f, _ in pool}):
        for category in order:
            candidates = sorted(pool.get((fixture, category), []),
                                key=lambda r: (r["sourceConfirmation"] != "SOURCE_CONFIRMED", r["caller"], r["target"]))
            for row in candidates:
                if counts[(fixture, category)] >= per_case:
                    break
                key = (fixture, row["caller"], row["target"])
                if key in taken:
                    continue
                taken.add(key)
                counts[(fixture, category)] += 1
                chosen.append({k: row[k] for k in ("fixture", "caller", "kind", "receiver", "interface", "slot",
                                                   "target", "token", "generic", "confidence", "categories",
                                                   "sourceConfirmation")})
    available = {f"{f}:{c}": len(v) for (f, c), v in sorted(pool.items())}
    return chosen, available


def check(corpus, rip, fixture):
    scripts = pathlib.Path(rip) / fixture / "Assets" / "Scripts"
    results = collections.Counter()
    for entry in corpus["entries"]:
        if entry["fixture"] != fixture:
            continue
        caller_type, _, caller_method = entry["caller"].partition("::")
        # The exporter writes one file per top-level type; a nested type lives in its outer type's file.
        outer = caller_type.split("+")[0].split(".")[-1].split("`")[0]
        files = list(scripts.rglob(f"{outer}.cs"))
        if not files:
            print(f"NOT_PRESENT {entry['caller']}")
            results["NOT_PRESENT"] += 1
            entry["check"] = "NOT_PRESENT"
            continue
        # A default rip stubs engine and package assemblies by design (the same prefix rule as
        # IsFrameworkAssembly); a stub names nothing, and saying NOT_NAMED would call that a regression.
        assembly = files[0].relative_to(scripts).parts[0]
        if assembly.startswith(("UnityEngine", "Unity.", "System", "mscorlib", "netstandard")):
            entry["check"] = "STUBBED"
            results["STUBBED"] += 1
            continue
        text = "\n".join(f.read_text(encoding="utf-8", errors="replace") for f in files)
        # How C# spells the caller: an explicit implementation by its last segment
        # (`void ICollection.CopyTo(`), a constructor by its type's name.
        inner = caller_type.split("+")[-1].split(".")[-1].split("`")[0]
        if caller_method in (".ctor", ".cctor"):
            caller_method = inner
        else:
            caller_method = caller_method.split(".")[-1]
        method = entry["target"].split("::")[-1].split("<")[0]
        spelled = {method, method[4:]} if method.startswith(("get_", "set_")) else {method}
        # Every overload of the caller: the row carries no RVA, and a name is shared.
        named = False
        for match in re.finditer(r"\b" + re.escape(caller_method) + r"\s*(?:<[^>]*>)?\s*\(", text):
            window = text[match.end(): match.end() + 20000]
            if any(re.search(r"\b" + re.escape(s) + r"\b", window) for s in spelled):
                named = True
                break
        entry["check"] = "NAMED" if named else "NOT_NAMED"
        if not named:
            print(f"NOT_NAMED {entry['caller']} -> {entry['target']}")
        results[entry["check"]] += 1
    return results


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("--select", nargs="+", metavar="FIXTURE=EVIDENCE")
    parser.add_argument("--source")
    parser.add_argument("--provenance")
    parser.add_argument("--per-case", type=int, default=6)
    parser.add_argument("--corpus", default="Test/logic-interface-corpus.json")
    parser.add_argument("--check", metavar="RIP")
    parser.add_argument("--fixture")
    args = parser.parse_args()

    if args.select:
        bodies = source_bodies(pathlib.Path(args.source), args.provenance) if args.source and args.provenance else None
        dumps = [tuple(item.split("=", 1)) for item in args.select]
        chosen, available = select(dumps, args.per_case, bodies)
        path = pathlib.Path(args.corpus)
        previous = json.loads(path.read_text())["entries"] if path.exists() else []
        # Union, never replace: a frozen entry that disappears is a hole in the net.
        keys = {(e["fixture"], e["caller"], e["target"]) for e in chosen}
        merged = chosen + [e for e in previous if (e["fixture"], e["caller"], e["target"]) not in keys]
        path.write_text(json.dumps({"entries": merged, "available": available}, indent=1))
        print(f"{len(merged)} entries ({len(chosen)} selected now)")
        print(json.dumps(collections.Counter(c for e in chosen for c in e["categories"]), sort_keys=True))
        print(json.dumps(collections.Counter(e["sourceConfirmation"] for e in chosen), sort_keys=True))
        return 0

    if args.check:
        corpus = json.loads(pathlib.Path(args.corpus).read_text())
        results = check(corpus, args.check, args.fixture)
        print(json.dumps(dict(results), sort_keys=True))
        return 1 if results.get("NOT_NAMED") else 0

    parser.print_help()
    return 2


if __name__ == "__main__":
    sys.exit(main())
