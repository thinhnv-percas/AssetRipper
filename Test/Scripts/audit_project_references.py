#!/usr/bin/env python3
"""Reports every asset reference in a rip and whether a Unity project could follow it.

A recovered project is only runnable if its references resolve. A script that compiles says nothing
about that: Unity follows PPtrs, and one that points at nothing loses the component, the material,
the mesh or the sprite it named - silently, as one console line at import. So this walks every
serialized document in the rip, finds every PPtr in it, and resolves it the way the editor would.

Five verdicts, and the distinctions are the point:

  EXACT     a reference within the same document, whose anchor is in that document
  RESOLVED  a reference to another asset, whose GUID a .meta in this rip declares - or to one of
            Unity's own built-in resources, which no project declares and which are therefore not
            broken however much they look it
  AMBIGUOUS a GUID that resolves to more than one file, so which one the editor picks is not decided
  BROKEN    a GUID no .meta declares, or a local anchor that is not in the document
  MISSING   a null PPtr in a slot that must not be null - a MonoBehaviour with no m_Script has no
            component at all, whatever else the document says about it
  NULL      a null PPtr in a slot that is allowed to be one, which is most of them

The last distinction is the one that decides whether this measure means anything. Unity writes
`{fileID: 0}` for every optional slot of every object: `m_CorrespondingSourceObject` on a GameObject
that is not a prefab instance, `m_ProbeAnchor` on a renderer that has none, `m_SelectOnUp` under
automatic navigation. On the test game those account for 2522 of 2526 apparent losses. Counting them
as broken reports a project with no defect as 32% resolved, which is the shape of a check that is too
strict - and a check that is too strict is as wrong as one that is too lax, and costs more time. So
`NULL` is reported and excluded from the rate, and only a slot that cannot be empty counts as a loss.

Nothing here is repaired: inventing a target would make the console quiet and the project wrong.

Usage: audit_project_references.py <rip output> [--json out.json] [--verbose]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

# A PPtr as the YAML exporter writes it, with the property that holds it.
POINTER = re.compile(
    r"^\s*(?:- )?(?P<property>[A-Za-z_][A-Za-z0-9_]*): \{fileID: (?P<fileID>-?\d+)"
    r"(?:, guid: (?P<guid>[0-9a-f]+), type: (?P<type>\d+))?\}")
ANCHOR = re.compile(r"^--- !u!(?P<class>\d+) &(?P<anchor>\d+)")
META_GUID = re.compile(r"^guid: (?P<guid>[0-9a-f]+)")

# Unity's own built-in resources and extras. No project declares them and every project references
# them; reading them as broken was how a validator reported FAIL on a project with no defect.
BUILT_IN_GUIDS = {
    "0000000000000000f000000000000000",
    "0000000000000000e000000000000000",
    "0000000000000000d000000000000000",
}

DOCUMENT_SUFFIXES = (".unity", ".prefab", ".asset", ".mat", ".anim", ".controller", ".physicMaterial",
                     ".physicsMaterial2D", ".renderTexture", ".cubemap", ".flare", ".fontsettings",
                     ".guiskin", ".mixer", ".overrideController", ".playable", ".preset", ".shadervariants",
                     ".spriteatlas", ".terrainlayer")

EXACT, RESOLVED, AMBIGUOUS, BROKEN, MISSING, NULL = "EXACT", "RESOLVED", "AMBIGUOUS", "BROKEN", "MISSING", "NULL"
ORDER = [EXACT, RESOLVED, AMBIGUOUS, BROKEN, MISSING, NULL]

# The slots a null PPtr is a defect in. `m_Script` is the whole list and deserves to be: a
# MonoBehaviour whose script does not resolve loses the component and every field on it, which is
# exactly the failure this audit exists to catch. Any other property is left to `NULL` rather than
# asserted to be required, because "this ought to be set" is a claim about the game's design that
# nothing in the file can support.
REQUIRED_PROPERTIES = {"m_Script"}


def guid_index(root: pathlib.Path) -> dict[str, list[str]]:
    """GUID -> the assets declaring it. A list, because two .meta files with one GUID is ambiguous."""
    found: dict[str, list[str]] = collections.defaultdict(list)
    for meta in root.rglob("*.meta"):
        try:
            for line in meta.read_text(encoding="utf-8", errors="replace").splitlines():
                match = META_GUID.match(line)
                if match:
                    found[match["guid"]].append(str(meta.with_suffix("").relative_to(root)))
                    break
        except OSError:
            continue
    return found


def documents(root: pathlib.Path):
    """Every serialized document in the rip, by suffix."""
    for path in sorted(root.rglob("*")):
        if path.is_file() and path.suffix in DOCUMENT_SUFFIXES:
            yield path


def classify(match: re.Match, anchors: set[str], guids: dict[str, list[str]]) -> tuple[str, str]:
    """The verdict for one PPtr, and the evidence behind it."""
    file_id = match["fileID"]
    guid = match["guid"]

    if guid is None:
        if file_id == "0":
            return ((MISSING, "a required slot holds the null PPtr")
                    if match["property"] in REQUIRED_PROPERTIES
                    else (NULL, "an optional slot, empty"))
        return (EXACT, "anchor in this document") if file_id in anchors else (BROKEN, f"no anchor &{file_id} in this document")

    if guid in BUILT_IN_GUIDS:
        # Unity ships these; a project that declared them would be the broken one.
        return RESOLVED, "Unity built-in resource"

    targets = guids.get(guid, [])

    if len(targets) == 1:
        return RESOLVED, targets[0]
    if len(targets) > 1:
        return AMBIGUOUS, f"{len(targets)} assets declare this guid"
    return BROKEN, f"no .meta in the rip declares guid {guid}"


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root", help="the game directory inside the rip output")
    parser.add_argument("--json")
    parser.add_argument("--verbose", action="store_true", help="list every reference that is not EXACT or RESOLVED")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)

    if not root.is_dir():
        print(f"NOT_A_DIRECTORY: {root}")
        return 2

    guids = guid_index(root)
    verdicts = collections.Counter()
    by_property = collections.defaultdict(collections.Counter)
    by_document_kind = collections.defaultdict(collections.Counter)
    findings = []
    scanned = 0

    for path in documents(root):
        try:
            text = path.read_text(encoding="utf-8", errors="replace")
        except OSError:
            continue

        scanned += 1
        lines = text.splitlines()
        anchors = {match["anchor"] for line in lines if (match := ANCHOR.match(line))}
        relative = str(path.relative_to(root))

        for number, line in enumerate(lines, start=1):
            match = POINTER.match(line)
            if not match:
                continue

            verdict, evidence = classify(match, anchors, guids)
            verdicts[verdict] += 1
            by_property[match["property"]][verdict] += 1
            by_document_kind[path.suffix][verdict] += 1

            if verdict in (AMBIGUOUS, BROKEN, MISSING):
                findings.append({
                    "document": relative, "line": number, "property": match["property"],
                    "fileID": match["fileID"], "guid": match["guid"],
                    "verdict": verdict, "evidence": evidence,
                })

    total = sum(verdicts.values())
    # The rate is over references that name something. A slot that is allowed to be empty and is
    # empty is not a reference that failed to resolve, and putting it in the denominator measures how
    # many optional slots Unity serializes rather than how much of the project survived.
    naming = total - verdicts[NULL]
    followable = verdicts[EXACT] + verdicts[RESOLVED]

    print(f"documents scanned: {scanned}")
    print(f"references found: {total}, of which {naming} name a target")
    print()
    for verdict in ORDER:
        share = f"{verdicts[verdict] / total:6.1%}" if total else "     -"
        print(f"{verdicts[verdict]:6d}  {verdict:<10}{share}")
    print()
    # The headline. Stated as a rate over references that exist, never over references attempted:
    # a document this cannot parse contributes nothing rather than a pass.
    print(f"reference_resolution_rate: {followable / naming:.4f} ({followable} of {naming} that name a target)" if naming
          else "reference_resolution_rate: UNKNOWN (no reference names a target)")

    if by_property:
        print("\n== by the property holding the reference, worst first ==")
        ranked = sorted(by_property.items(),
                        key=lambda item: -(item[1][BROKEN] + item[1][MISSING] + item[1][AMBIGUOUS]))
        print(f"{'property':<28}{'exact':>7}{'resolved':>10}{'ambig':>7}{'broken':>8}{'missing':>9}{'null':>7}")
        for name, counts in ranked[:15]:
            if counts[BROKEN] + counts[MISSING] + counts[AMBIGUOUS] == 0:
                break
            print(f"{name:<28}{counts[EXACT]:>7}{counts[RESOLVED]:>10}{counts[AMBIGUOUS]:>7}"
                  f"{counts[BROKEN]:>8}{counts[MISSING]:>9}{counts[NULL]:>7}")

    if by_document_kind:
        print("\n== by document kind ==")
        for suffix, counts in sorted(by_document_kind.items(), key=lambda item: -sum(item[1].values())):
            naming_here = sum(counts.values()) - counts[NULL]
            print(f"{suffix:<12}{naming_here:>7} naming a target, "
                  f"{counts[BROKEN] + counts[MISSING] + counts[AMBIGUOUS]:>5} not followable")

    if arguments.verbose and findings:
        print("\n== every reference a project could not follow ==")
        for finding in findings:
            print(f"{finding['document']}:{finding['line']}  {finding['property']}  "
                  f"{finding['verdict']}: {finding['evidence']}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "documents": scanned,
            "total": total,
            "verdicts": dict(verdicts),
            "naming": naming,
            "reference_resolution_rate": (followable / naming) if naming else None,
            "findings": findings,
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
