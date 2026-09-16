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

An entry is a record, not a path. A key is a path and an address, and neither is unique across
fixtures: an address that matched something in one game matched nothing in another, and the corpus
reported that as "not present" without being able to say which game it belonged to. So every entry
carries the fixture it was frozen from, and a measurement only looks at the entries belonging to the
fixture being measured. It also carries what the entry is for (`runtime_role`), what it reached when
it was frozen (`semantic_fingerprint`, `status`), and whether the programmer's own text exists for it
(`source_available`) - which is what says whether a regression in it can be read against the source.

An entry that resolves in no current fixture is retired with its reason rather than deleted: a
dropped entry is a hole in the net, and a hole reports "regressed 0" for a method nobody looks at.
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


def role_of(declaration_text: str) -> str:
    """What this method is for, as far as a running game cares, or GENERAL when nothing says."""
    for role, pattern in sorted(RUNTIME_ROLES.items()):
        if pattern.search(declaration_text):
            return role
    return "GENERAL"


def source_types(manifest: pathlib.Path | None) -> set[str] | None:
    """The types the source project declares, from a source manifest, or None when there is none."""
    if manifest is None or not manifest.exists():
        return None
    report = json.loads(manifest.read_text())
    return {f"{entry['assembly']}::{entry['type']}" for entry in report["types"]}


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


def load(path: pathlib.Path) -> tuple[list[dict], list[dict]]:
    """A corpus file, as (entries, retired). The old list-of-keys form loads with no fixture."""
    if not path.exists():
        return [], []
    stored = json.loads(path.read_text())
    if "entries" in stored:
        return stored["entries"], stored.get("retired", [])
    return [{"method": key, "fixture": None} for key in stored.get("methods", [])], []


def referenced_types(root: pathlib.Path) -> set[str]:
    """Every script type a serialized document points at through `m_Script`.

    Read from the rip rather than from the reference audit, because the audit reports what did *not*
    resolve and this needs what did. A MonoScript is named by the GUID its `.cs.meta` declares, so
    the index is meta-GUID to type name and the scan is for that GUID in an `m_Script` line.
    """
    guids = {}
    for meta in root.rglob("*.cs.meta"):
        for line in meta.read_text(encoding="utf-8", errors="replace").splitlines():
            if line.startswith("guid:"):
                guids[line.split(":", 1)[1].strip()] = meta.name[: -len(".cs.meta")]
                break

    if not guids:
        return set()

    named = set()
    for suffix in ("*.unity", "*.prefab", "*.asset", "*.mat", "*.controller", "*.anim"):
        for document in root.rglob(suffix):
            for line in document.read_text(encoding="utf-8", errors="replace").splitlines():
                if "m_Script:" not in line or "guid:" not in line:
                    continue
                guid = line.split("guid:", 1)[1].split(",")[0].strip()
                if guid in guids:
                    named.add(guids[guid])
    return named


def files_with_errors(errors: pathlib.Path | None) -> set[str] | None:
    """The files Roslyn rejected, from a raw diagnostic dump, or None when there is none.

    Keyed by the path as the corpus keys it - relative to the game directory - so the two line up
    without either having to know where the rip sits.
    """
    if errors is None or not errors.exists():
        return None
    failing = set()
    for line in errors.read_text(encoding="utf-8", errors="replace").splitlines():
        match = re.match(r"^(?P<path>[^(]+)\(\d+,\d+\): error ", line)
        if not match:
            continue
        parts = pathlib.PurePosixPath(match.group("path")).parts
        if "Assets" in parts:
            failing.add(str(pathlib.PurePosixPath(*parts[parts.index("Assets"):])))
    return failing


def entry_for(key: str, fixture: str, rows_by_key: dict, declared: set[str] | None,
              failing: set[str] | None, referenced: set[str] | None) -> dict:
    """A frozen record: what the method is, what it reached, and whether its source exists."""
    status, ir, _, _, _, _, declaration_text = rows_by_key[key]
    path = key.split("#", 1)[0]
    assembly = pathlib.PurePosixPath(path).parts[2] if len(pathlib.PurePosixPath(path).parts) > 2 else ""
    type_name = pathlib.PurePosixPath(path).stem
    return {
        "method": key,
        "fixture": fixture,
        "runtime_role": role_of(declaration_text),
        "semantic_fingerprint": ir,
        "status": status,
        # None, not False, where no manifest was supplied: "not known" and "not there" are different
        # answers and only one of them is evidence.
        "source_available": None if declared is None else f"{assembly}::{type_name}" in declared,
        # Whether the file this method is in compiles, and whether anything in the project points at
        # its type. Both are per file rather than per method, which is what the evidence supports:
        # Roslyn reports a file and a `m_Script` names a type.
        "compile_status": None if failing is None else ("FAILS" if path in failing else "CLEAN"),
        "reference_status": (None if referenced is None
                             else ("REFERENCED" if type_name in referenced else "NOT_REFERENCED")),
    }


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--log")
    parser.add_argument("--select")
    parser.add_argument("--corpus")
    parser.add_argument("--check")
    parser.add_argument("--json")
    parser.add_argument("--manifest", help="a source_manifest.py report, for source_available")
    parser.add_argument("--errors", help="a raw Roslyn diagnostic dump, for compile_status")
    parser.add_argument("--references", action="store_true",
                        help="scan the rip for m_Script targets, for reference_status")
    parser.add_argument("--fixture", help="the fixture this rip is of (default: the directory name)")
    parser.add_argument("--retire-unresolved", metavar="FIXTURES",
                        help="retire every entry still belonging to no fixture, recording that these "
                             "fixtures were swept and none of them resolved it")
    parser.add_argument("--per-class", type=int, default=3)
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    fixture = arguments.fixture or root.resolve().name
    log = pathlib.Path(arguments.log) if arguments.log else None
    rows = list(harvest(root, log))
    rows_by_key = {row[0]: (row[1], row[2], row[3], row[4], row[5], row[6], row[7]) for row in rows}
    declared = source_types(pathlib.Path(arguments.manifest) if arguments.manifest else None)
    failing = files_with_errors(pathlib.Path(arguments.errors) if arguments.errors else None)
    referenced = referenced_types(root) if arguments.references else None

    if arguments.select:
        chosen = select(rows, arguments.per_class)

        # Unioned, never replaced. A frozen entry that gets dropped is a hole in the net, and the
        # hole is invisible: the corpus still reports "regressed 0" for a method it no longer looks
        # at. The rule was written down and the code did not have it - a reselection replaced the
        # file outright, which is how 61 frozen methods became 165 with no overlap guaranteed.
        existing = pathlib.Path(arguments.corpus) if arguments.corpus else pathlib.Path(arguments.select)
        kept, retired = load(existing)

        by_identity = {(entry.get("fixture"), entry["method"]): entry for entry in kept}

        # A legacy entry this rip resolves belongs to this fixture, whether or not the reselection
        # picked it again. Adopting only the chosen ones leaves entries no fixture claims, which is
        # the hole this record format exists to close.
        adoptable = [key for (owner, key) in list(by_identity)
                     if owner is None and key in rows_by_key]

        for key in dict.fromkeys([*chosen, *adoptable]):
            identity = (fixture, key)
            record = entry_for(key, fixture, rows_by_key, declared, failing, referenced)
            # An entry frozen before fixtures were recorded is adopted by the fixture that resolves
            # it rather than duplicated, so a reselection does not double the corpus.
            legacy = by_identity.pop((None, key), None)
            if legacy is not None and identity not in by_identity:
                record.setdefault("frozen_before_fixtures", True)
            by_identity[identity] = record

        if arguments.retire_unresolved:
            for identity in [identity for identity in list(by_identity) if identity[0] is None]:
                entry = by_identity.pop(identity)
                retired.append({
                    "method": entry["method"],
                    "reason": "RESOLVES_IN_NO_FIXTURE",
                    "fixtures_swept": arguments.retire_unresolved,
                })

        merged = [by_identity[identity] for identity in sorted(by_identity, key=lambda i: (i[0] or "", i[1]))]
        pathlib.Path(arguments.select).write_text(
            json.dumps({"entries": merged, "retired": retired}, indent=2))
        print(f"selected {len(chosen)} for {fixture}, kept {len(kept)} already frozen, "
              f"{len(merged)} entries and {len(retired)} retired in {arguments.select}")
        return 0

    if not arguments.corpus:
        parser.error("one of --select or --corpus is required")

    entries, retired = load(pathlib.Path(arguments.corpus))
    # An entry belonging to another fixture is not a miss - it is somebody else's method. Only the
    # entries frozen from this fixture, plus the untagged legacy ones, are this run's to answer for.
    mine = [entry for entry in entries if entry.get("fixture") in (None, fixture)]
    elsewhere = len(entries) - len(mine)
    wanted = {entry["method"] for entry in mine}

    measured = {
        key: {"status": status, "ir": ir, "csharp": csharp, "nativeBytes": native,
              "placeholders": placeholders, "families": families, "fixture": fixture,
              "runtimeRole": role_of(declaration_text)}
        for key, status, ir, csharp, native, placeholders, families, declaration_text in rows
        if key in wanted
    }

    missing = sorted(wanted - measured.keys())
    statuses = collections.Counter(entry["status"] for entry in measured.values())
    roles = collections.Counter(entry["runtimeRole"] for entry in measured.values())

    print(f"corpus: {len(entries)} entries, {len(mine)} for {fixture} "
          f"({elsewhere} for other fixtures, {len(retired)} retired), "
          f"{len(measured)} found, {len(missing)} not present in this rip\n")
    print("== by semantic status ==")
    for status in RANK:
        print(f"{statuses[status]:5d}  {status}")
    print("\n== by runtime role ==")
    for role, count in sorted(roles.items(), key=lambda item: (-item[1], item[0])):
        print(f"{count:5d}  {role}")

    if missing:
        print("\n== not present ==")
        for key in missing[:20]:
            print(f"  {key}")

    exit_code = 0

    # A corpus that matches nothing in the rip reports "improved 0, regressed 0" and looks exactly
    # like a corpus that found no regression. It has happened: the keys are relative to the game
    # directory inside the output, so pointing the check one level too high silently measured
    # nothing, three times, while printing a clean result. A net that caught nothing has to say so.
    if measured and len(missing) > len(mine) // 2:
        print(f"\nCORPUS_MISMATCH: only {len(measured)} of {len(mine)} frozen methods are in this rip.")
        exit_code = 3
    elif not measured:
        print(f"\nCORPUS_NOT_APPLICABLE: none of the {len(mine)} frozen methods for {fixture} is in {root}.")
        print("The keys are relative to the game directory inside the rip - try <output>/<GameName>.")
        return 3

    if arguments.check:
        stored = json.loads(pathlib.Path(arguments.check).read_text())["methods"]
        better, worse = [], []
        for key, entry in sorted(measured.items()):
            before_entry = stored.get(f"{fixture}::{key}") or stored.get(key)
            if before_entry is None:
                continue
            before, after = RANK.index(before_entry["status"]), RANK.index(entry["status"])
            if after < before:
                better.append((key, before_entry["status"], entry["status"]))
            elif after > before:
                worse.append((key, before_entry["status"], entry["status"]))

        print(f"\n== against baseline ==\nimproved {len(better)}, regressed {len(worse)}")
        for key, before, after in better:
            print(f"  IMPROVED  {before} -> {after}  {key}")
        for key, before, after in worse:
            print(f"  REGRESSED {before} -> {after}  {key}")
        exit_code = 1 if worse else exit_code

    if arguments.json:
        pathlib.Path(arguments.json).write_text(
            json.dumps({"methods": {f"{fixture}::{key}": entry for key, entry in measured.items()}},
                       indent=2))

    return exit_code


if __name__ == "__main__":
    sys.exit(main())
