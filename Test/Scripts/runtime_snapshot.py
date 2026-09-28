#!/usr/bin/env python3
"""Snapshots of a scene's state, and a comparison between two of them that never uses an instance ID.

A runtime check of a recovered project comes down to one question: after the same scenario, is the
recovered scene in the same state as the original? That needs a state both sides can write and a
comparison that does not depend on anything the two projects do not share - and they share no
instance ID, no fileID, no GUID. So a snapshot is keyed exactly the way the serialized reference
graph is: a GameObject by its hierarchy path, a component by its GameObject and its type (a script's
namespace and class), a reference by what it points at, a value by itself.

Two kinds of snapshot share the schema `assetripper.runtime-snapshot/1`:

  SERIALIZED_INITIAL_STATE  what a scene serialises, read here from its YAML. This is the state every
                            scenario starts from, and it is the only kind this environment can
                            produce.
  RUNTIME                   what a running scene holds after a scenario, written by an editor-side
                            capture. There is no Unity here, so none exists, and comparing against
                            one reports NOT_RUN - never a pass.

The comparison of two initial states is still worth running: a recovered scene whose serialized
values differ from the source's starts every scenario from a different place, and no amount of
correct method recovery makes up for that.

Per value: EQUAL | DIFFERENT | ABSENT_IN_RECOVERED | ABSENT_IN_SOURCE. Floats compare within 1e-5
relative (1e-6 absolute), because a build re-serializes them. Editor-only fields - a transform's
Euler hint, a component's inspector identifier - are not part of any runtime state and are dropped.

Usage:
  runtime_snapshot.py capture <project> <scene.unity> [--json out.json]
  runtime_snapshot.py compare <source project> <recovered game directory> [--package-dir DIR] [--json out.json]
  runtime_snapshot.py --self-test
"""
import argparse
import collections
import json
import math
import pathlib
import sys

sys.path.insert(0, str(pathlib.Path(__file__).parent))
import serialized_reference_graph as srg  # noqa: E402

SCHEMA = "assetripper.runtime-snapshot/1"

# Not part of any runtime state: identity plumbing the graph already encodes, or editor-only data a
# player never has.
IGNORED = srg.STRUCTURAL | {
    "m_ObjectHideFlags", "serializedVersion", "m_EditorHideFlags", "m_EditorClassIdentifier",
    "m_LocalEulerAnglesHint", "m_ConstrainProportionsScale", "m_RootOrder", "m_Name",
}


def leaves(value, path=""):
    """(field path, value) for every leaf, with a PPtr kept whole so it can be described."""
    if isinstance(value, dict):
        if "fileID" in value and set(value) <= {"fileID", "guid", "type"}:
            yield path, value
            return
        # A particle system's MinMaxCurve reads maxCurve in Curve mode (1) and both curves in
        # TwoCurves (2); in Constant (0) and TwoConstants (3) it reads neither. An unread curve is not
        # state - the editor keeps whatever keys it last had, and a build does not serialize them.
        unused = set()
        if "minCurve" in value and "maxCurve" in value:
            unused = {0: {"minCurve", "maxCurve"}, 1: {"minCurve"}, 3: {"minCurve", "maxCurve"}}.get(value.get("minMaxState"), set())
        for key, item in value.items():
            if key in unused:
                continue
            # `serializedVersion` is a format marker wherever it appears - every keyframe of every
            # curve carries one - and is never state; the rest are ignored only at the top level.
            if key == "serializedVersion" or (not path and key in IGNORED):
                continue
            yield from leaves(item, f"{path}.{key}" if path else str(key))
    elif isinstance(value, list):
        for index, item in enumerate(value):
            yield from leaves(item, f"{path}[{index}]")
    else:
        yield path, value


def capture(graph: "srg.Graph", rename=None) -> dict:
    """A SERIALIZED_INITIAL_STATE snapshot of one expanded scene."""
    objects = {}
    for game_object, path in graph.path.items():
        body = graph.objects[game_object].body
        components = {}
        for component, (owner_path, kind, ordinal) in graph.component_key.items():
            if owner_path != path:
                continue
            key = (rename or {}).get(component) or (kind + (f"[{ordinal}]" if ordinal else ""))
            fields = {}
            for field, value in leaves(graph.objects[component].body):
                fields[field] = graph.describe(value) if isinstance(value, dict) else value
            components[key] = fields
        objects[path] = {"active": body.get("m_IsActive"), "tag": body.get("m_TagString"),
                         "layer": body.get("m_Layer"), "components": components}
    return {"schema": SCHEMA, "kind": "SERIALIZED_INITIAL_STATE", "scene": graph.label, "objects": objects}


def equal(a, b) -> bool:
    if isinstance(a, bool) or isinstance(b, bool):
        return a == b
    if isinstance(a, (int, float)) and isinstance(b, (int, float)):
        if math.isnan(a) and math.isnan(b):
            return True
        return math.isclose(a, b, rel_tol=1e-5, abs_tol=1e-6)
    # YAML reads `0.5` as a float and `1` as an int, and a build may write either for the same value.
    try:
        return math.isclose(float(a), float(b), rel_tol=1e-5, abs_tol=1e-6)
    except (TypeError, ValueError):
        return a == b


def compare(source: dict, recovered: dict) -> dict:
    """Value by value, keyed by path and component identity; never by an instance ID."""
    if source.get("schema") != SCHEMA or recovered.get("schema") != SCHEMA:
        return {"status": "SCHEMA_MISMATCH"}
    if "RUNTIME" in (source.get("kind"), recovered.get("kind")) and source.get("kind") != recovered.get("kind"):
        return {"status": "NOT_RUN", "detail": "a runtime snapshot is compared only with another runtime snapshot"}
    tally = collections.Counter()
    by_field = collections.Counter()
    examples = []
    for path, wanted in source["objects"].items():
        got = recovered["objects"].get(path)
        if got is None:
            tally["OBJECT_ABSENT_IN_RECOVERED"] += 1
            continue
        for attribute in ("active", "tag", "layer"):
            tally["EQUAL" if equal(wanted.get(attribute), got.get(attribute)) else "DIFFERENT"] += 1
        for component, fields in wanted["components"].items():
            other = got["components"].get(component)
            if other is None:
                tally["COMPONENT_ABSENT_IN_RECOVERED"] += 1
                continue
            for field in set(fields) | set(other):
                if field not in other:
                    status = "ABSENT_IN_RECOVERED"
                elif field not in fields:
                    status = "ABSENT_IN_SOURCE"
                elif str(fields[field]).startswith("UNKNOWN:") or str(other[field]).startswith("UNKNOWN:"):
                    status = "UNKNOWN"
                elif isinstance(fields[field], str) and "?" in fields[field] and srg.re.search(r"\?[0-9a-f]{32}", fields[field]):
                    # A reference into a component whose script this checkout cannot name: the same
                    # rule as the reference graph - never a match, and never a difference either.
                    status = "UNKNOWN"
                else:
                    status = "EQUAL" if equal(fields[field], other[field]) else "DIFFERENT"
                tally[status] += 1
                if status == "DIFFERENT":
                    by_field[f"{component.split('[')[0]}.{field.split('[')[0]}"] += 1
                    if len(examples) < 40:
                        examples.append({"object": path, "component": component, "field": field,
                                         "source": fields[field], "recovered": other[field]})
    decided = tally["EQUAL"] + tally["DIFFERENT"]
    return {"status": "MEASURED", "values": dict(tally),
            "value_equality_rate": round(tally["EQUAL"] / decided, 4) if decided else None,
            "differentFields": dict(by_field.most_common(30)), "examples": examples}


def compare_projects(source_root, recovered_root, package_dirs):
    source = srg.Project(source_root, package_dirs)
    recovered = srg.Project(recovered_root)
    report = {"scenes": []}
    for relative, source_scene, recovered_scene, how in srg.pair_scenes(source_root, recovered_root):
        if source_scene is None:
            report["scenes"].append({"scene": relative, "status": "NO_SOURCE_SCENE"})
            continue
        source_graph = srg.Graph(source, source.expanded(source_scene), relative)
        recovered_graph = srg.Graph(recovered, recovered.expanded(recovered_scene), relative)
        # Components are keyed by the recovered side's identity wherever the pairing established one,
        # so a component whose source script this checkout cannot name is still compared - under a
        # key that says the pairing was positional.
        rename = {}
        recovered_by_path = {p: g for g, p in recovered_graph.path.items()}
        scratch = {"components": collections.Counter()}
        for game_object, path in source_graph.path.items():
            if path not in recovered_by_path:
                continue
            for source_component, recovered_component, how_paired in srg.pair_components(
                    source_graph, recovered_graph, game_object, recovered_by_path[path], scratch,
                    collections.defaultdict(list)):
                _, kind, ordinal = recovered_graph.component_key[recovered_component]
                key = kind + (f"[{ordinal}]" if ordinal else "")
                rename[source_component] = key if how_paired == "exact" else key + "~positional"
        source_snapshot = capture(source_graph, rename)
        recovered_snapshot = capture(recovered_graph)
        # A positional key has to exist on the recovered side too for the values to meet.
        for obj in recovered_snapshot["objects"].values():
            for key in list(obj["components"]):
                obj["components"][key + "~positional"] = obj["components"][key]
        result = compare(source_snapshot, recovered_snapshot)
        result["scene"] = relative
        report["scenes"].append(result)
    total = collections.Counter()
    fields = collections.Counter()
    for scene in report["scenes"]:
        total.update(scene.get("values", {}))
        fields.update(scene.get("differentFields", {}))
    decided = total["EQUAL"] + total["DIFFERENT"]
    report["total"] = dict(total)
    report["value_equality_rate"] = round(total["EQUAL"] / decided, 4) if decided else None
    report["differentFields"] = dict(fields.most_common(30))
    report["runtime_status"] = "NOT_RUN"
    return report


def self_test() -> int:
    failures = 0

    def check(name, condition):
        nonlocal failures
        print(("ok   " if condition else "FAIL ") + name)
        failures += 0 if condition else 1

    def snap(value, kind="SERIALIZED_INITIAL_STATE", path="Root"):
        return {"schema": SCHEMA, "kind": kind, "scene": "s",
                "objects": {path: {"active": 1, "tag": "Untagged", "layer": 0,
                                   "components": {"Transform": {"m_LocalPosition.x": value}}}}}

    check("a float re-serialized by a build is equal", compare(snap(0.1), snap(0.10000001))["values"].get("DIFFERENT", 0) == 0)
    check("a different value is DIFFERENT", compare(snap(0.1), snap(0.2))["values"].get("DIFFERENT", 0) == 1)
    check("an int and the same float are equal", compare(snap(1), snap(1.0))["values"].get("DIFFERENT", 0) == 0)
    check("a runtime snapshot is never compared with a serialized one",
          compare(snap(1), snap(1, kind="RUNTIME"))["status"] == "NOT_RUN")
    check("objects meet by path, not by any ID",
          compare(snap(1), snap(1, path="Other"))["values"].get("OBJECT_ABSENT_IN_RECOVERED") == 1)
    check("a constant-mode curve's keys are not state", "c.maxCurve.m_Curve[0].time" not in dict(
        leaves({"c": {"minMaxState": 0, "scalar": 1, "minCurve": {"m_Curve": [{"time": 0}]},
                      "maxCurve": {"m_Curve": [{"time": 0}]}}})))
    check("a curve-mode curve's keys are", "c.maxCurve.m_Curve[0].time" in dict(
        leaves({"c": {"minMaxState": 1, "scalar": 1, "minCurve": {"m_Curve": [{"time": 0}]},
                      "maxCurve": {"m_Curve": [{"time": 0}]}}})))
    check("an editor-only field is not state", "m_LocalEulerAnglesHint.x" not in dict(
        leaves({"m_LocalEulerAnglesHint": {"x": 1}, "m_LocalPosition": {"x": 2}})))
    return failures


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("mode", nargs="?", choices=["capture", "compare"])
    parser.add_argument("first", nargs="?")
    parser.add_argument("second", nargs="?")
    parser.add_argument("--package-dir", action="append", default=[])
    parser.add_argument("--json")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()
    if args.self_test:
        sys.exit(1 if self_test() else 0)
    if args.mode == "capture":
        project = srg.Project(pathlib.Path(args.first))
        scene = pathlib.Path(args.second)
        result = capture(srg.Graph(project, project.expanded(scene), scene.name))
    elif args.mode == "compare":
        result = compare_projects(pathlib.Path(args.first), pathlib.Path(args.second), args.package_dir)
        for scene in result["scenes"]:
            print(f"== {scene.get('scene')}: {scene.get('status')} {json.dumps(scene.get('values', {}), sort_keys=True)}")
        print("TOTAL", json.dumps(result["total"], sort_keys=True))
        print("value_equality_rate", result["value_equality_rate"], "runtime_status", result["runtime_status"])
        for field, count in list(result["differentFields"].items())[:15]:
            print(f"  {count:6} {field}")
    else:
        parser.error("mode required")
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(result, indent=1, sort_keys=True, default=str))


if __name__ == "__main__":
    main()
