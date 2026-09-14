#!/usr/bin/env python3
"""Reports every script reference in a rip that a Unity project could not follow.

A project "imports" only in the sense that Unity opens it; a MonoBehaviour whose m_Script does not
resolve silently loses its component and every field on it, and the editor reports that as one line
in the console. So the question a runnable-project claim rests on is not whether the YAML parses but
whether each reference has a target - and, where it does not, whether anything in the rip could be
that target.

Each finding names the source, the target, why it is broken, what repair is available, and how
certain that repair is. Where no candidate exists the finding says UNRESOLVED: inventing a GUID
would make the console quiet and the component wrong.

Usage: audit_script_references.py <rip output> [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

ANCHOR = re.compile(r"^--- !u!(?P<class>\d+) &(?P<anchor>\d+)")
SCRIPT = re.compile(r"^\s*m_Script: \{fileID: (?P<fileID>-?\d+)(?:, guid: (?P<guid>[0-9a-f]+), type: (?P<type>\d+))?\}")
GAMEOBJECT = re.compile(r"^\s*m_GameObject: \{fileID: (?P<fileID>-?\d+)")
NAME = re.compile(r"^\s*m_Name: (?P<name>.*)$")
META_GUID = re.compile(r"^guid: (?P<guid>[0-9a-f]+)")

SCENE_SUFFIXES = (".unity", ".prefab", ".asset")


def guids_of_scripts(root: pathlib.Path) -> dict[str, str]:
    """GUID -> script path, read from the .cs.meta files the rip wrote."""
    found = {}
    for meta in root.rglob("*.cs.meta"):
        for line in meta.read_text(encoding="utf-8", errors="replace").splitlines():
            match = META_GUID.match(line)
            if match:
                found[match["guid"]] = str(meta.with_suffix("").relative_to(root))
                break
    return found


def scan(path: pathlib.Path):
    """Every MonoBehaviour in one document, with its anchor, its m_Script and its GameObject."""
    text = path.read_text(encoding="utf-8", errors="replace").splitlines()

    names: dict[str, str] = {}
    anchor = None
    for line in text:
        header = ANCHOR.match(line)
        if header:
            anchor = header["anchor"]
            continue
        named = NAME.match(line)
        if named and anchor and named["name"].strip():
            names.setdefault(anchor, named["name"].strip())

    anchor = None
    current = None
    for number, line in enumerate(text, start=1):
        header = ANCHOR.match(line)
        if header:
            if current:
                yield current
            anchor = header["anchor"]
            current = {"anchor": anchor, "class": header["class"], "script": None, "gameObject": None, "line": number}
            continue

        if current is None:
            continue

        script = SCRIPT.match(line)
        if script:
            current["script"] = (script["fileID"], script["guid"])
            current["line"] = number

        owner = GAMEOBJECT.match(line)
        if owner:
            current["gameObject"] = owner["fileID"]

    if current:
        yield current

    yield {"__names__": names}


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    if not root.is_dir():
        print(f"not a directory: {root}", file=sys.stderr)
        return 1

    scripts = guids_of_scripts(root)
    by_name = {pathlib.Path(path).stem: guid for guid, path in scripts.items()}

    findings = []
    total = 0

    for document in sorted(p for suffix in SCENE_SUFFIXES for p in root.rglob(f"*{suffix}")):
        entries = list(scan(document))
        names = entries[-1].get("__names__", {}) if entries and "__names__" in entries[-1] else {}

        # What each GameObject in this document already has attached and resolved.
        already_attached: dict[tuple[str, str], set[str]] = collections.defaultdict(set)
        for entry in entries:
            if "__names__" in entry or entry["class"] != "114" or entry["script"] is None:
                continue
            _, attached_guid = entry["script"]
            if attached_guid and attached_guid in scripts:
                already_attached[(str(document), entry["gameObject"] or "")].add(attached_guid)

        for entry in entries:
            if "__names__" in entry or entry["class"] != "114" or entry["script"] is None:
                continue

            total += 1
            fileID, guid = entry["script"]
            owner = names.get(entry["gameObject"] or "", "")

            if guid is not None and guid in scripts:
                continue

            if guid is None or fileID == "0":
                reason = "NO_TARGET: m_Script is the null PPtr, so the serialized data named no MonoScript the rip could map"
            else:
                reason = f"DANGLING_GUID: m_Script names guid {guid}, which no .cs.meta in the rip declares"

            # The only evidence for a repair that is not a guess: a recovered script whose name
            # matches the GameObject or the document. A name is a convention, not metadata, so it is
            # reported as a candidate and never applied - and the document's own name is weaker than
            # the GameObject's, because a prefab is routinely named after the thing it represents
            # rather than after any one of its components.
            candidates = []
            if owner and owner in by_name:
                candidates.append((owner, "GAMEOBJECT_NAME"))
            if document.stem != owner and document.stem in by_name:
                candidates.append((document.stem, "DOCUMENT_NAME"))

            # A script already attached to this GameObject is evidence against, not for: the component
            # that wanted it is right there and resolved, so this is a different one.
            attached = already_attached.get((str(document), entry["gameObject"] or ""), set())
            candidates = [
                (name, evidence + ("_CONFLICT" if by_name[name] in attached else ""))
                for name, evidence in candidates
            ]
            candidates.sort(key=lambda pair: ("_CONFLICT" in pair[1], pair[1] != "GAMEOBJECT_NAME"))

            findings.append({
                "sourceFile": str(document.relative_to(root)),
                "sourceObject": entry["anchor"],
                "sourceObjectName": owner or "<unnamed>",
                "property": "m_Script",
                "line": entry["line"],
                "fileID": fileID,
                "guid": guid,
                "expectedType": "MonoScript",
                "candidateTarget": candidates[0][0] if candidates else None,
                "candidateGuid": by_name.get(candidates[0][0]) if candidates else None,
                "candidateEvidence": candidates[0][1] if candidates else None,
                "reason": reason,
                "confidence": (candidates[0][1] if candidates else "NONE"),
                "repairStatus": (
                    "UNRESOLVED" if not candidates
                    else "CONFLICTING" if "_CONFLICT" in candidates[0][1]
                    else "AMBIGUOUS"
                ),
            })

    print(f"script references checked: {total}")
    print(f"broken: {len(findings)}\n")

    for status, count in collections.Counter(f["repairStatus"] for f in findings).most_common():
        print(f"{count:6d}  {status}")

    print()
    for finding in findings:
        print(f"{finding['sourceFile']}:{finding['line']}  &{finding['sourceObject']} on '{finding['sourceObjectName']}'")
        print(f"        {finding['reason']}")
        print(f"        repair={finding['repairStatus']} evidence={finding['confidence']} candidate={finding['candidateTarget']}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({"checked": total, "findings": findings}, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
