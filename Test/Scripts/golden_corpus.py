#!/usr/bin/env python3
"""A frozen set of methods whose recovery is checked one method at a time.

Every other measure in this project is an aggregate, and an aggregate cannot say that a particular
method got worse while the total got better - which is exactly the shape of the changes this pipeline
keeps making, since recovering more of a program routinely raises some counts. So a corpus: a fixed
list of methods chosen to span the operation classes, each carrying its semantic status and its two
fingerprints, compared method by method against a stored baseline.

The selection is made by the tool rather than by hand, from the operation classes the IR says each
method reaches, and then frozen to a file - so it is reproducible, and so nobody has to argue about
whether the list was chosen to flatter a result.

  golden_corpus.py <rip> --log <log> --select <corpus.json>     choose and freeze the list
  golden_corpus.py <rip> --log <log> --corpus <corpus.json>     measure those methods
  golden_corpus.py <rip> --log <log> --corpus <corpus.json> --check <baseline.json>

`--check` exits non-zero when a method's status moves the wrong way. A method that improves is
reported and never fails the run.
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
from recovery_metrics import (  # noqa: E402
    ADDRESS, attempted_assemblies, classify, fingerprint, methods, native_body, NATIVE_SOURCE,
)
from placeholder_families import assembly_of, family_of, messages  # noqa: E402

SIGNATURE = re.compile(r'^\s*(?:\[[^\]]*\]\s*)*((?:public|private|protected|internal|static|override|virtual|sealed|extern|unsafe|async|\s)*[\w<>\[\],.]+\s+[\w<>.]+\s*\([^)]*\))')

# Rank worst-first so the corpus is not all trivial methods: a category is represented by the
# methods that exercise it most, which is where a regression would show.
RANK = ["EXACT", "HIGH_CONFIDENCE", "PARTIAL", "FALLBACK", "MISSING"]


def harvest(root: pathlib.Path, log: pathlib.Path | None):
    """(key, status, ir fingerprint, c# fingerprint, native bytes) for every scoped method."""
    attempted = attempted_assemblies(log)

    for path in sorted(root.rglob("*.cs")):
        assembly = assembly_of(path, root)
        if attempted is not None and assembly not in attempted:
            continue

        text = path.read_text(encoding="utf-8", errors="replace")
        relative = str(path.relative_to(root))
        addresses = ADDRESS.findall(text)
        index = 0

        for native, source, body in methods(text):
            rva = addresses[index][0] if index < len(addresses) else f"i{index}"
            index += 1
            status, placeholders, untyped, lost = classify(native, source, body)
            families = {family_of(message)[0] for line in body.splitlines()
                        if not line.lstrip().startswith("[") for message in messages(line)}
            yield (
                f"{relative}#0x{rva}",
                status,
                sorted(fingerprint(source, "ir")) if source else [],
                sorted(fingerprint(body, "csharp")),
                native,
                placeholders,
                sorted(families),
                declaration(body),
            )


# What a method is, as far as a running game cares. A corpus picked only by how badly recovery went
# is a corpus of the code least likely to run; these are the entry points a project actually executes,
# and a regression in one of them is worth more than a regression in the worst method in the rip.
# Matched on the declaration rather than on a name alone, so `Update` the message and `Update` some
# helper of the same name are not conflated - a Unity message is void and takes no arguments.
RUNTIME_ROLES = {
    "LIFECYCLE_AWAKE": re.compile(r"\bvoid (Awake|OnEnable)\(\)"),
    "LIFECYCLE_START": re.compile(r"\bvoid Start\(\)"),
    "LIFECYCLE_UPDATE": re.compile(r"\bvoid (Update|LateUpdate|FixedUpdate)\(\)"),
    "LIFECYCLE_DESTROY": re.compile(r"\bvoid (OnDisable|OnDestroy|OnApplicationQuit|OnApplicationPause)\("),
    "UNITY_CALLBACK": re.compile(r"\bvoid (OnCollision|OnTrigger|OnMouse|OnGUI|OnBecame|OnWillRender|OnDrawGizmos)\w*\("),
    "COROUTINE": re.compile(r"\bIEnumerator \w+\("),
    "PROPERTY_GETTER": re.compile(r"\bpublic .*\bget_\w+\(\)"),
    "EVENT_ACCESSOR": re.compile(r"\b(add|remove)_\w+\("),
    "CONSTRUCTOR": re.compile(r"\bpublic \w+\([^)]*\)\s*$"),
    "STATIC_ENTRY": re.compile(r"\bpublic static \w[\w<>,\[\] ]* \w+\("),
}


def declaration(body: str) -> str:
    """A method's declaration, through the same pattern the rest of this file reads one with."""
    for line in body.splitlines():
        match = SIGNATURE.match(line)
        if match:
            return match.group(1)[:200]
    return ""


def select_runtime(rows, per_role: int) -> list[str]:
    """One method per (runtime role, status), so the corpus covers what a project executes."""
    chosen: list[str] = []
    seen = set()

    for role, pattern in sorted(RUNTIME_ROLES.items()):
        for status in RANK:
            candidates = [
                row for row in rows
                if row[1] == status and row[0] not in seen and pattern.search(row[7])
            ]
            candidates.sort(key=lambda row: (-row[4], row[0]))
            for row in candidates[:per_role]:
                chosen.append(row[0])
                seen.add(row[0])

    return chosen


def select(rows, per_class: int) -> list[str]:
    """One method per (operation class, status), so the corpus spans both axes.

    Taking the worst methods per class gives a corpus that is entirely FALLBACK, which can only ever
    report improvement - and the regression worth catching is an EXACT method falling out of EXACT.
    So each class contributes one method at each status it has, largest native body first within a
    status, and the whole thing is sorted so the file is stable across runs.
    """
    chosen: list[str] = []
    seen = set()

    for name in sorted({cls for row in rows for cls in row[2]}):
        for status in RANK:
            candidates = [
                row for row in rows
                if name in row[2] and row[1] == status and row[0] not in seen
            ]
            candidates.sort(key=lambda row: (-row[4], row[0]))
            for row in candidates[:per_class]:
                chosen.append(row[0])
                seen.add(row[0])

    # And the worst method carrying each placeholder family, so the corpus has a representative of
    # every way recovery still fails - a vtable slot, a runtime helper, a delegate - not only of every
    # operation class. These are by construction the hardest methods in the rip, which is the point.
    for family in sorted({f for row in rows for f in row[6]}):
        candidates = [row for row in rows if family in row[6] and row[0] not in seen]
        candidates.sort(key=lambda row: (-row[5], -row[4], row[0]))
        for row in candidates[:per_class]:
            chosen.append(row[0])
            seen.add(row[0])

    # And the entry points a running project executes, which nothing above selects for: the axes so
    # far are how a method was recovered and how it failed, neither of which knows what a method is
    # for.
    for key in select_runtime(rows, per_class):
        if key not in seen:
            chosen.append(key)
            seen.add(key)

    return sorted(chosen)


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--log")
    parser.add_argument("--select")
    parser.add_argument("--corpus")
    parser.add_argument("--check")
    parser.add_argument("--json")
    parser.add_argument("--per-class", type=int, default=3)
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    log = pathlib.Path(arguments.log) if arguments.log else None
    rows = list(harvest(root, log))

    if arguments.select:
        chosen = select(rows, arguments.per_class)

        # Unioned, never replaced. A frozen entry that gets dropped is a hole in the net, and the
        # hole is invisible: the corpus still reports "regressed 0" for a method it no longer looks
        # at. The rule was written down and the code did not have it - a reselection replaced the
        # file outright, which is how 61 frozen methods became 165 with no overlap guaranteed.
        existing = pathlib.Path(arguments.corpus) if arguments.corpus else pathlib.Path(arguments.select)
        kept = []
        if existing.exists():
            kept = json.loads(existing.read_text())["methods"]

        merged = list(dict.fromkeys([*kept, *chosen]))
        pathlib.Path(arguments.select).write_text(json.dumps({"methods": merged}, indent=2))
        print(f"selected {len(chosen)}, kept {len(kept)} already frozen, {len(merged)} in {arguments.select}")
        return 0

    if not arguments.corpus:
        parser.error("one of --select or --corpus is required")

    wanted = set(json.loads(pathlib.Path(arguments.corpus).read_text())["methods"])
    measured = {
        key: {"status": status, "ir": ir, "csharp": csharp, "nativeBytes": native,
              "placeholders": placeholders, "families": families}
        for key, status, ir, csharp, native, placeholders, families, _ in rows
        if key in wanted
    }

    missing = sorted(wanted - measured.keys())
    statuses = collections.Counter(entry["status"] for entry in measured.values())

    print(f"corpus: {len(wanted)} methods, {len(measured)} found, {len(missing)} not present in this rip\n")
    print("== by semantic status ==")
    for status in RANK:
        print(f"{statuses[status]:5d}  {status}")

    if missing:
        print("\n== not present ==")
        for key in missing[:20]:
            print(f"  {key}")

    exit_code = 0

    # A corpus that matches nothing in the rip reports "improved 0, regressed 0" and looks exactly
    # like a corpus that found no regression. It has happened: the keys are relative to the game
    # directory inside the output, so pointing the check one level too high silently measured
    # nothing, three times, while printing a clean result. A net that caught nothing has to say so.
    if measured and len(missing) > len(wanted) // 2:
        print(f"\nCORPUS_MISMATCH: only {len(measured)} of {len(wanted)} frozen methods are in this rip.")
        exit_code = 3
    elif not measured:
        print(f"\nCORPUS_NOT_APPLICABLE: none of the {len(wanted)} frozen methods is in {root}.")
        print("The keys are relative to the game directory inside the rip - try <output>/<GameName>.")
        return 3

    if arguments.check:
        baseline = json.loads(pathlib.Path(arguments.check).read_text())["methods"]
        better, worse = [], []
        for key, entry in sorted(measured.items()):
            if key not in baseline:
                continue
            before, after = RANK.index(baseline[key]["status"]), RANK.index(entry["status"])
            if after < before:
                better.append((key, baseline[key]["status"], entry["status"]))
            elif after > before:
                worse.append((key, baseline[key]["status"], entry["status"]))

        print(f"\n== against baseline ==\nimproved {len(better)}, regressed {len(worse)}")
        for key, before, after in better:
            print(f"  IMPROVED  {before} -> {after}  {key}")
        for key, before, after in worse:
            print(f"  REGRESSED {before} -> {after}  {key}")
        exit_code = 1 if worse else 0

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({"methods": measured}, indent=2))

    return exit_code


if __name__ == "__main__":
    sys.exit(main())
