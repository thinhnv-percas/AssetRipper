#!/usr/bin/env python3
"""What a Unity-enabled environment would have to check, scenario by scenario.

`runtime_validation_manifest.py` says what a project needs to open. This says what would have to be
*observed* once it opens, as one scenario per (scene, object, component, lifecycle method): the state
the scene serialises going in, what running that method should leave behind, and what event should
have fired.

The honesty rule is the same one the rest of this harness lives by: a field this cannot settle is
`UNKNOWN` with the reason, never a plausible-looking value. Three things are readable without Unity
and are therefore stated as facts:

  scene / object / component   from the scene's own YAML
  method                       from the recovered script's declaration, matched on the signature a
                               Unity message has (returns void, takes no arguments) rather than on
                               the name, because a helper of the same name is not a message
  initial_state                the serialised field values the scene carries for that component

Everything past that needs the engine. `expected_state` and `expected_event` are `UNKNOWN` unless a
source project settles them, and the contract as a whole carries `runtime_status: NOT_RUN` so nothing
downstream can read it as a result. A contract that guessed an expected state would be worse than no
contract: it would fail against a correct recovery, or pass against a broken one, and there is no way
to tell which from the file.

Usage: runtime_smoke_contract.py <game directory> [--source <unity project>] [--json out.json]
"""
import argparse
import json
import pathlib
import re
import sys

DOCUMENT = re.compile(r"^--- !u!(?P<class>\d+) &(?P<id>\d+)", re.MULTILINE)
GAME_OBJECT_NAME = re.compile(r"^  m_Name: (?P<name>.*)$", re.MULTILINE)
SCRIPT = re.compile(r"^  m_Script: \{fileID: (?P<file>-?\d+), guid: (?P<guid>[0-9a-f]+)", re.MULTILINE)
COMPONENT_REF = re.compile(r"component: \{fileID: (?P<id>\d+)\}")

# A Unity message returns void and takes no arguments; a helper with the same name does not, which is
# why this matches the declaration rather than the name.
MESSAGE = re.compile(
    r"^\s*(?:(?:private|public|protected|internal|virtual|override|sealed|static|extern)\s+)*"
    r"void\s+(?P<name>Awake|Start|OnEnable|OnDisable|Update|FixedUpdate|LateUpdate|OnDestroy)\s*\(\s*\)",
    re.MULTILINE)

UNKNOWN = "UNKNOWN"


def guid_of(meta):
    if not meta.is_file():
        return None
    match = re.search(r"^guid: ([0-9a-f]+)", meta.read_text(encoding="utf-8", errors="replace"), re.MULTILINE)
    return match.group(1) if match else None


def scripts_by_guid(game):
    """{guid: (path, the Unity messages it declares)} for every recovered script with a .cs.meta."""
    found = {}

    for path in sorted(game.rglob("*.cs")):
        guid = guid_of(path.with_suffix(".cs.meta"))

        if guid is None:
            continue

        text = path.read_text(encoding="utf-8", errors="replace")
        # The attribute lines carry whole method bodies inside a string literal, so strip them first
        # or every message named anywhere in a rendering reads as declared here.
        body = "\n".join(line for line in text.splitlines() if not line.lstrip().startswith("["))
        found[guid] = (str(path.relative_to(game)), sorted({m.group("name") for m in MESSAGE.finditer(body)}))

    return found


def documents(text):
    """{fileID: (classID, the document's body)} for one serialised scene."""
    parsed = {}
    matches = list(DOCUMENT.finditer(text))

    for index, match in enumerate(matches):
        end = matches[index + 1].start() if index + 1 < len(matches) else len(text)
        parsed[match.group("id")] = (match.group("class"), text[match.end():end])

    return parsed


def serialised_fields(body):
    """The component's own serialised values - everything Unity did not put there itself."""
    fields = {}

    for line in body.splitlines():
        match = re.match(r"^  (?P<name>[A-Za-z_][\w]*): (?P<value>.+)$", line)

        if not match or match.group("name").startswith("m_"):
            continue

        fields[match.group("name")] = match.group("value").strip()

    return fields


def scenarios_for(scene, game, by_guid):
    text = scene.read_text(encoding="utf-8", errors="replace")
    parsed = documents(text)
    built = []

    for identifier, (class_id, body) in parsed.items():
        # 114 is MonoBehaviour. Anything else carries no recovered script to run.
        if class_id != "114":
            continue

        script = SCRIPT.search(body)

        if not script or script.group("guid") not in by_guid:
            continue

        path, messages = by_guid[script.group("guid")]

        if not messages:
            continue

        owner = UNKNOWN
        for candidate_id, (candidate_class, candidate_body) in parsed.items():
            if candidate_class == "1" and any(m.group("id") == identifier for m in COMPONENT_REF.finditer(candidate_body)):
                name = GAME_OBJECT_NAME.search(candidate_body)
                owner = name.group("name").strip() if name else UNKNOWN
                break

        for message in messages:
            built.append({
                "scene": str(scene.relative_to(game)),
                "object": owner,
                "component": path,
                "method": message,
                # A Unity message takes no arguments, so there is nothing to supply.
                "input": "NONE",
                "initial_state": serialised_fields(body),
                "expected_state": UNKNOWN,
                "expected_state_reason": "needs the engine, or a source project stating it",
                "expected_event": UNKNOWN,
                "expected_event_reason": "needs the engine, or a source project stating it",
                "status": "NOT_RUN",
            })

    return built


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("game", help="the game directory inside the rip")
    parser.add_argument("--source", help="the source Unity project, where one exists")
    parser.add_argument("--fixture")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    game = pathlib.Path(arguments.game)

    if not game.is_dir():
        print(f"NOT_A_DIRECTORY: {game}")
        return 2

    by_guid = scripts_by_guid(game)
    scenarios = []

    for scene in sorted(game.rglob("*.unity")):
        scenarios.extend(scenarios_for(scene, game, by_guid))

    contract = {
        "fixture": arguments.fixture or game.name,
        "project_root": str(game),
        # The source is an oracle for what the expected state should be; without one, every expected
        # state stays UNKNOWN, which is the point rather than a gap to be filled in with a guess.
        "source_oracle": arguments.source or None,
        "scenario_count": len(scenarios),
        "scenarios_with_expected_state": 0,
        "runtime_status": "NOT_RUN",
        "runtime_status_reason": "UNITY_NOT_AVAILABLE",
        "scenarios": scenarios,
    }

    print(f"{contract['fixture']}: {len(scenarios)} smoke scenarios across "
          f"{len({s['scene'] for s in scenarios})} scenes, "
          f"{len({s['component'] for s in scenarios})} components")
    print(f"  expected_state settled: {contract['scenarios_with_expected_state']} of {len(scenarios)}"
          f"  (the rest need the engine)")
    print(f"  runtime_status {contract['runtime_status']} ({contract['runtime_status_reason']})")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(contract, indent=2))
        print(f"  wrote {arguments.json}")

    return 0


if __name__ == "__main__":
    sys.exit(main())
