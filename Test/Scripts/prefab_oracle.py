#!/usr/bin/env python3
"""Each prefab of a source project against the recovered one, by structure rather than by text.

Iteration 063 (brief §10-§11). Raw YAML is never compared: file IDs, GUIDs and field order are the
exporter's choices. A prefab is reduced to its canonical form - the set of (hierarchy path, component
type) pairs, where a MonoBehaviour's type is its script's class name (resolved through each side's own
`.meta` GUIDs, so a script living in a package on one side and in `Assets/Scripts` on the other still
pairs) and a built-in component's type is its YAML tag.

  MATCH                         same objects, same components
  SERIALIZED_RECOVERY_MISMATCH  the source prefab has objects or components the recovered one lacks, or
                                the other way round (the differences are listed)
  MISSING_IN_RECOVERED          no recovered prefab of that name
  NOT_IN_BUILD                  a source prefab under a vendor Demo/Tutorial/Examples folder that no
                                recovered prefab pairs with - shipped with a package, not with the game

With `--root`, every mismatch is attributed: if the derivation root (the rip the source began as) agrees
with the recovery, the difference was made by hand after derivation (SOURCE_EDIT); otherwise it is the
recovery's (RECOVERY_DEFECT) or undecided.

Usage: prefab_oracle.py <source project> <recovered game dir> [--root <derivation-root checkout>]
                        [--package-dir DIR] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

DOCUMENT = re.compile(r"^--- !u!(\d+) &(-?\d+)(?: stripped)?\n(\w+):\n(.*?)(?=^--- |\Z)", re.M | re.S)
VENDOR_DEMO = re.compile(r"/(Demo|Demos|Tutorial|Tutorials|Examples?)/", re.I)


def script_names(roots):
    """Script GUID -> class name, from every `.cs.meta` under the roots."""
    names = {}
    for root in roots:
        for meta in pathlib.Path(root).rglob("*.cs.meta"):
            match = re.search(r"^guid:\s*([0-9a-f]{32})", meta.read_text(errors="replace"), re.M)
            if match:
                names[match.group(1)] = meta.name[: -len(".cs.meta")]
    return names


def canonical(path, scripts):
    """{(hierarchy path, component type)} for one prefab."""
    text = pathlib.Path(path).read_text(encoding="utf-8", errors="replace")
    documents = {}
    for match in DOCUMENT.finditer(text):
        documents[match.group(2)] = (match.group(3), match.group(4))
    names, parent_of, components_of = {}, {}, collections.defaultdict(list)
    transform_owner = {}
    for file_id, (kind, body) in documents.items():
        if kind == "GameObject":
            name = re.search(r"^  m_Name: (.*)$", body, re.M)
            names[file_id] = name.group(1).strip() if name else "?"
            for component in re.findall(r"component: \{fileID: (-?\d+)\}", body):
                components_of[file_id].append(component)
        elif kind in ("Transform", "RectTransform"):
            owner = re.search(r"m_GameObject: \{fileID: (-?\d+)\}", body)
            father = re.search(r"m_Father: \{fileID: (-?\d+)\}", body)
            if owner:
                transform_owner[file_id] = owner.group(1)
                parent_of[owner.group(1)] = father.group(1) if father else "0"

    def path_of(game_object, depth=0):
        parent_transform = parent_of.get(game_object, "0")
        parent = transform_owner.get(parent_transform)
        own = names.get(game_object, "?")
        return own if parent is None or depth > 64 else path_of(parent, depth + 1) + "/" + own

    found = set()
    for game_object in names:
        where = path_of(game_object)
        found.add((where, "GameObject"))
        for component in components_of[game_object]:
            kind, body = documents.get(component, ("?", ""))
            if kind == "MonoBehaviour":
                guid = re.search(r"m_Script: \{fileID: -?\d+, guid: ([0-9a-f]{32})", body)
                kind = "Script:" + (scripts.get(guid.group(1), "UNRESOLVED") if guid else "NONE")
            found.add((where, kind))
    return found


def prefabs(root):
    return {p.stem: p for p in pathlib.Path(root).rglob("*.prefab")}


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("source")
    parser.add_argument("recovered")
    parser.add_argument("--root")
    parser.add_argument("--package-dir", action="append", default=[])
    parser.add_argument("--json")
    args = parser.parse_args()

    source, recovered = pathlib.Path(args.source), pathlib.Path(args.recovered)
    source_scripts = script_names([source / "Assets", *args.package_dir])
    recovered_scripts = script_names([recovered / "Assets"])
    root_prefabs, root_scripts = {}, {}
    if args.root:
        root_prefabs = prefabs(pathlib.Path(args.root) / "Assets")
        root_scripts = script_names([pathlib.Path(args.root) / "Assets", *args.package_dir])

    source_prefabs, recovered_prefabs = prefabs(source / "Assets"), prefabs(recovered / "Assets")
    rows, tally, attribution = [], collections.Counter(), collections.Counter()
    for name, path in sorted(source_prefabs.items()):
        row = {"prefab": name, "source": str(path.relative_to(source))}
        if name not in recovered_prefabs:
            row["status"] = "NOT_IN_BUILD" if VENDOR_DEMO.search("/" + row["source"]) else "MISSING_IN_RECOVERED"
        else:
            a = canonical(path, source_scripts)
            b = canonical(recovered_prefabs[name], recovered_scripts)
            only_source, only_recovered = sorted(a - b), sorted(b - a)
            row["objects"] = len({p for p, k in a if k == "GameObject"})
            row["components"] = len([1 for _, k in a if k != "GameObject"])
            if not only_source and not only_recovered:
                row["status"] = "MATCH"
            else:
                row["status"] = "SERIALIZED_RECOVERY_MISMATCH"
                row["onlySource"] = ["|".join(x) for x in only_source[:20]]
                row["onlyRecovered"] = ["|".join(x) for x in only_recovered[:20]]
                if args.root and name in root_prefabs:
                    # What the source has and the recovery lacks: if the derivation root did not have it
                    # either, it was added by hand after derivation. If the root had it, the recovery lost
                    # something an earlier recovery of the same build produced.
                    r = canonical(root_prefabs[name], root_scripts)
                    added_by_hand = not (set(only_source) & r)
                    lost_since_root = bool(set(only_source) & r) and not (set(only_source) - r)
                    row["attribution"] = ("SOURCE_EDIT" if added_by_hand
                                          else "RECOVERY_DEFECT" if lost_since_root else "UNDECIDED")
                    attribution[row["attribution"]] += 1
        tally[row["status"]] += 1
        rows.append(row)

    print(f"source prefabs: {len(source_prefabs)}, recovered: {len(recovered_prefabs)}  {json.dumps(dict(tally), sort_keys=True)}")
    if attribution:
        print(f"mismatch attribution against the derivation root: {json.dumps(dict(attribution), sort_keys=True)}")
    for row in rows:
        if row["status"] == "SERIALIZED_RECOVERY_MISMATCH":
            print(f"  {row['prefab']:36} {row.get('attribution', '-'):16} only source {len(row['onlySource'])}, "
                  f"only recovered {len(row['onlyRecovered'])}  e.g. {(row['onlySource'] or row['onlyRecovered'])[:2]}")
    matched = tally["MATCH"]
    compared = matched + tally["SERIALIZED_RECOVERY_MISMATCH"]
    print(f"prefab_match_rate {matched / compared:.4f} ({matched}/{compared})" if compared else "prefab_match_rate None")
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps({"summary": dict(tally), "attribution": dict(attribution), "prefabs": rows}, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
