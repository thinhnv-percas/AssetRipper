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
    ADDRESS, ISSUE, attempted_assemblies, classify, fingerprint, methods, native_body, NATIVE_SOURCE,
)
from placeholder_families import assembly_of, family_of  # noqa: E402

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
                        if not line.lstrip().startswith("[") for message in ISSUE.findall(line)}
            yield (
                f"{relative}#0x{rva}",
                status,
                sorted(fingerprint(source, "ir")) if source else [],
                sorted(fingerprint(body, "csharp")),
                native,
                placeholders,
                sorted(families),
            )


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
        pathlib.Path(arguments.select).write_text(json.dumps({"methods": chosen}, indent=2))
        print(f"selected {len(chosen)} methods into {arguments.select}")
        return 0

    if not arguments.corpus:
        parser.error("one of --select or --corpus is required")

    wanted = set(json.loads(pathlib.Path(arguments.corpus).read_text())["methods"])
    measured = {
        key: {"status": status, "ir": ir, "csharp": csharp, "nativeBytes": native,
              "placeholders": placeholders, "families": families}
        for key, status, ir, csharp, native, placeholders, families in rows
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
