#!/usr/bin/env python3
"""Writes what a Unity-enabled environment would need to open a recovered project and run it.

Nothing here claims a runtime result. Unity is not in this container, so stages E through I of
`validate_unity_stages.py` are BLOCKED on every fixture and no measurement in this project has ever
started the game. What can be prepared is the input to that run: which project, which editor version,
which scene first, which packages and native plugins have to be present, and which methods a smoke
test should reach.

The manifest is read from the rip rather than written by hand, so it cannot drift from it, and every
field says how it was obtained. A field that could not be read is absent rather than guessed.

Usage: runtime_validation_manifest.py <recovered game directory> [--corpus c.json] [--fixture X]
                                      [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

# The Unity messages a smoke test can observe without knowing anything about the game.
LIFECYCLE = ("Awake", "OnEnable", "Start", "Update", "FixedUpdate", "LateUpdate", "OnDestroy")

SCENE_ORDER = re.compile(r"m_Scenes:\s*$")
ENABLED_SCENE = re.compile(r"-\s+enabled:\s*1\s*$")
# A scene path can contain spaces - `Assets/_Impostor 3/Scenes/Main.unity` - so it runs to the end
# of the line rather than to the first space.
SCENE_PATH = re.compile(r"path:\s*(?P<path>[^\r\n]+?)\s*$")


def editor_version(root):
    version = root / "ProjectSettings" / "ProjectVersion.txt"
    if not version.is_file():
        return None
    for line in version.read_text(encoding="utf-8", errors="replace").splitlines():
        if line.startswith("m_EditorVersion:"):
            return line.split(":", 1)[1].strip()
    return None


def packages(root):
    """The package dependencies the rip declares, from the project manifest it wrote."""
    manifest = root / "Packages" / "manifest.json"
    if not manifest.is_file():
        return None
    try:
        return json.loads(manifest.read_text(encoding="utf-8", errors="replace")).get("dependencies")
    except ValueError:
        return None


def scenes(root):
    """Every scene in the project, and the ones the build settings enable, in order."""
    every = sorted(str(path.relative_to(root)) for path in root.rglob("*.unity"))
    settings = root / "ProjectSettings" / "EditorBuildSettings.asset"
    enabled = []

    if settings.is_file():
        lines = settings.read_text(encoding="utf-8", errors="replace").splitlines()
        for index, line in enumerate(lines):
            if not ENABLED_SCENE.search(line):
                continue
            for following in lines[index:index + 4]:
                if (match := SCENE_PATH.search(following)) is not None:
                    enabled.append(match.group("path"))
                    break

    return every, enabled


def native_plugins(root):
    """The native libraries the project carries, which a player needs and an editor may not have."""
    found = []
    for suffix in ("*.so", "*.dll", "*.dylib", "*.a", "*.aar", "*.jar"):
        for path in root.rglob(suffix):
            if "Scripts" in path.parts:
                continue
            found.append(str(path.relative_to(root)))
    return sorted(found)


def smoke_methods(root, corpus, fixture):
    """The methods a smoke test would reach: the corpus entries that a running scene executes.

    Taken from the corpus rather than chosen here, so the two agree about what matters, and narrowed
    to the Unity messages - a method nothing calls is not evidence that the game runs.
    """
    if corpus is None or not corpus.exists():
        return None
    entries = json.loads(corpus.read_text()).get("entries", [])
    wanted = [entry for entry in entries
              if entry.get("fixture") == fixture
              and str(entry.get("runtime_role", "")).startswith("LIFECYCLE")]
    return [{"method": entry["method"], "runtime_role": entry["runtime_role"],
             "status": entry.get("status"), "compile_status": entry.get("compile_status")}
            for entry in wanted]


def lifecycle_counts(root):
    """How many recovered scripts declare each Unity message, which bounds what a smoke test sees."""
    counts = collections.Counter()
    scripts = root / "Assets" / "Scripts"
    if not scripts.is_dir():
        return counts
    for path in scripts.rglob("*.cs"):
        text = path.read_text(encoding="utf-8", errors="replace")
        for message in LIFECYCLE:
            if re.search(rf"\bvoid {message}\(\)", text):
                counts[message] += 1
    return counts


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root", help="the game directory inside the rip")
    parser.add_argument("--corpus")
    parser.add_argument("--fixture")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root).resolve()
    if not (root / "Assets").is_dir() or not (root / "ProjectSettings").is_dir():
        print(f"PROJECT_ROOT_MISMATCH: {root} has no Assets and ProjectSettings")
        return 2

    every, enabled = scenes(root)
    fixture = arguments.fixture or root.name
    manifest = {
        "fixture": fixture,
        "project_root": str(root),
        "unity_version": editor_version(root),
        "startup_scene": enabled[0] if enabled else (every[0] if every else None),
        "startup_scene_source": "EditorBuildSettings" if enabled else "only scene in the project",
        "smoke_scenes": enabled or every,
        "scenes": every,
        "required_packages": packages(root),
        "required_native_plugins": native_plugins(root),
        "lifecycle_declared": dict(lifecycle_counts(root)),
        "smoke_methods": smoke_methods(root, pathlib.Path(arguments.corpus) if arguments.corpus else None, fixture),
        # Said outright, in the artefact itself, so nothing downstream can read this as a result.
        "runtime_status": "NOT_RUN",
        "runtime_status_reason": "UNITY_NOT_AVAILABLE",
        "expected_runtime_events": [
            f"{message} reached at least once" for message in LIFECYCLE[:4]
        ],
    }

    print(f"{fixture}: Unity {manifest['unity_version']}, startup scene {manifest['startup_scene']}")
    print(f"  scenes {len(every)} ({len(enabled)} in build settings), "
          f"native plugins {len(manifest['required_native_plugins'])}, "
          f"packages {len(manifest['required_packages'] or {})}")
    print(f"  lifecycle declared: " + ", ".join(f"{k} {v}" for k, v in sorted(manifest["lifecycle_declared"].items())))
    smoke = manifest["smoke_methods"]
    print(f"  smoke methods from the corpus: {len(smoke) if smoke is not None else 'NO_CORPUS'}")
    print(f"  runtime_status {manifest['runtime_status']} ({manifest['runtime_status_reason']})")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(manifest, indent=2))
        print(f"  wrote {arguments.json}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
