#!/usr/bin/env python3
"""Compile a recovered project the way Unity does, play its scenes, and compare with the source - through MiniUnity.

The stages between an export and a running game used to be BLOCKED on every fixture: there is no Unity in the
container, and the per-assembly Roslyn harness (compile_recovered_scripts.sh) compiles each assembly against the
DLLs the rip shipped, which is not what Unity does. MiniUnity (github.com/ThinhNV-DEV/miniUnity) is a headless
stand-in for the Editor that needs only the Editor's files: it compiles a project by Unity's own rules - asmdefs and
their references, plugin DLLs and their importer settings, packages from the manifest, Assembly-CSharp referencing
every auto-referenced assembly - and it runs the player loop (physics, Animator, audio, coroutines) on a scene.

Three findings it produced on the first recovered project it was pointed at, none visible to the Roslyn harness:
every asmdef had empty references (3022 errors, Assembly-CSharp skipped altogether); `internal abstract struct` in
__Generated failed that asmdef and everything depending on it; and UnityEngine.UI shipped as a second copy of
com.unity.ugui, so EventSystem.current was a different type's static and was null.

    miniunity_gate.py <rip>/<Game> [--source <source project>] [--scenario Test/miniunity-scenarios.json]
                      [--miniunity <dir>] [--unity-editor <dir>] [--scene Assets/...unity]... [--seconds 5]
                      [--input "..."] [--watch "Obj/Comp.field"]... [--screenshots <dir>] [--json out]
    miniunity_gate.py --self-test

The project is copied to a scratch directory first: MiniUnity writes Library/ into the project it runs on, and a
measurement must not change the artefact it measures.

What it reports, and what it does not:
  * compile: errors per assembly and which assemblies were skipped because one they depend on failed. That is a
    verdict about the export, because the rules applied are Unity's.
  * play: frames run and every exception, split into MINIUNITY_GAP (a Unity API MiniUnity has not implemented -
    a limit of the stand-in, never a defect of the recovery) and RUNTIME_EXCEPTION (thrown by project code; the
    candidate recovery defects). A scene that plays with only gaps is PASS_WITH_GAPS, not PASS.
  * behaviour: with --source, the same scenario on the source project, and every --watch compared. A watched value
    that differs is a behaviour difference; nothing is compared that was not asked for.
It is not Unity. Rendering, asset import and FBX models are partial or absent there, so this never stands in for
the Unity stages of validate_unity_stages.py; it reports beside them.
"""
import argparse
import json
import os
import pathlib
import re
import shutil
import subprocess
import sys
import tempfile

HERE = pathlib.Path(__file__).resolve().parent
REPO = HERE.parent.parent

PASS, FAIL, PASS_WITH_GAPS, BLOCKED = "PASS", "FAIL", "PASS_WITH_GAPS", "BLOCKED"
MINIUNITY_GAP, RUNTIME_EXCEPTION = "MINIUNITY_GAP", "RUNTIME_EXCEPTION"

# A stub MiniUnity generates for an API it has not written names the member it stands in for.
STUB = re.compile(r"^(?:System\.)?NotImplementedException(?::\s*|$)")
UNITY_MEMBER = re.compile(r"^Unity(?:Engine|Editor)?[\w.`]*\.\w+")


def find_miniunity(explicit: str | None) -> pathlib.Path | None:
    """The MiniUnity checkout: --miniunity, $MINIUNITY_HOME, or nothing. Its ua.sh is what is run."""
    for candidate in (explicit, os.environ.get("MINIUNITY_HOME")):
        if candidate and (pathlib.Path(candidate) / "ua.sh").is_file():
            return pathlib.Path(candidate)
    return None


def classify(kind: str, message: str) -> str:
    """MINIUNITY_GAP for a stub of a Unity API, RUNTIME_EXCEPTION for anything else."""
    text = f"{kind}: {message}" if kind and kind != "Exception" else message
    text = text.replace("System.NotImplementedException: ", "NotImplementedException: ")
    if STUB.match(text) or kind.endswith("NotImplementedException"):
        member = STUB.sub("", text).strip() if STUB.match(text) else message.strip()
        if UNITY_MEMBER.match(member):
            return MINIUNITY_GAP
    return RUNTIME_EXCEPTION


def summarise_play(result: dict) -> dict:
    """Frames, objects, and the exceptions grouped by class, from one `ua play` result."""
    groups = {MINIUNITY_GAP: {}, RUNTIME_EXCEPTION: {}}
    for log in result.get("logs") or []:
        if log.get("type") not in ("Exception", "Error"):
            continue
        message = log.get("message", "")
        kind, _, rest = message.partition(": ")
        cls = classify(kind, rest) if rest else classify("", message)
        groups[cls][message.splitlines()[0][:200]] = groups[cls].get(message.splitlines()[0][:200], 0) + int(log.get("count", 1))
    where = {}
    for exception in result.get("exceptions") or []:
        cls = classify(exception.get("type", ""), exception.get("message", ""))
        if cls == RUNTIME_EXCEPTION:
            frame = next((f for f in exception.get("stack") or [] if str(f.get("file", "")).startswith("Assets/")), None)
            where[exception.get("message", "")[:120]] = f"{frame['file']}:{frame.get('line')}" if frame else exception.get("where", "")
    if not result.get("ok", False):
        verdict = FAIL
    elif groups[RUNTIME_EXCEPTION]:
        verdict = FAIL
    elif groups[MINIUNITY_GAP]:
        verdict = PASS_WITH_GAPS
    else:
        verdict = PASS
    return {
        "verdict": verdict,
        "frames": result.get("frames"),
        "objects": result.get("objects"),
        "error": result.get("error"),
        "runtime_exceptions": groups[RUNTIME_EXCEPTION],
        "runtime_exception_sites": where,
        "miniunity_gaps": groups[MINIUNITY_GAP],
        "watch": result.get("watch") or {},
        "audio_events": len(result.get("audio") or []),
        "screenshots": result.get("screenshots") or [],
    }


def summarise_compile(result: dict) -> dict:
    assemblies = result.get("assemblies") or []
    failed = {a["name"]: a.get("errors", 0) for a in assemblies if not a.get("ok") and not a.get("skippedBecause")}
    skipped = {a["name"]: a["skippedBecause"] for a in assemblies if a.get("skippedBecause")}
    errors = [d for d in result.get("diagnostics") or [] if d.get("severity") == "error"]
    by_code = {}
    for d in errors:
        by_code[d.get("id", "?")] = by_code.get(d.get("id", "?"), 0) + 1
    if not result.get("ok", False):
        verdict = FAIL
    else:
        verdict = PASS if result.get("success") else FAIL
    return {
        "verdict": verdict,
        "errors": result.get("errors"),
        "assemblies": len(assemblies),
        "assemblies_ok": sum(1 for a in assemblies if a.get("ok")),
        "failed": failed,
        "skipped_because_a_dependency_failed": skipped,
        "errors_by_code": dict(sorted(by_code.items(), key=lambda kv: -kv[1])),
        "first_errors": [f"{d.get('file')}:{d.get('line')} {d.get('id')} {d.get('message', '')[:140]}" for d in errors[:10]],
        "truncated": result.get("truncated", False),
        "error": result.get("error"),
    }


def unobserved(value) -> bool:
    """MiniUnity's answer for a watch whose object or component is not in the scene."""
    return isinstance(value, str) and value.endswith("not found")


def compare_watches(recovered: dict, source: dict) -> dict:
    """Every watched value, equal or not. Only what was asked for is compared.

    A watch that finds nothing on either side observed nothing - "component not found" on both sides is not two
    equal values - so it is listed apart and decides nothing. Not found on one side only is a difference: the
    recovered scene lost (or gained) the object."""
    rows, absent = {}, []
    for key in sorted(set(recovered) | set(source)):
        r, s = recovered.get(key), source.get(key)
        if unobserved(r) and unobserved(s):
            absent.append(key)
            continue
        rows[key] = {"recovered": r, "source": s, "equal": r == s}
    differing = [k for k, v in rows.items() if not v["equal"]]
    verdict = (PASS if not differing else FAIL) if rows else BLOCKED
    return {"verdict": verdict, "values": rows, "differing": differing, "unobserved": absent,
            **({} if rows else {"reason": "nothing watched is in this scene"})}


class MiniUnity:
    def __init__(self, home: pathlib.Path, editor: str | None):
        self.home = home
        self.editor = editor

    def ua(self, project: pathlib.Path, *args: str, timeout: int = 1800) -> dict:
        env = dict(os.environ, UNITY_PROJECT=str(project), MU_NOREBUILD=os.environ.get("MU_NOREBUILD", "1"))
        if self.editor:
            env["UNITY_EDITOR"] = self.editor
        try:
            process = subprocess.run([str(self.home / "ua.sh"), *args], capture_output=True, text=True, env=env, timeout=timeout)
        except subprocess.TimeoutExpired:
            return {"ok": False, "error": f"timed out after {timeout} s"}
        try:
            return json.loads(process.stdout)
        except json.JSONDecodeError:
            return {"ok": False, "error": (process.stdout[-600:] + process.stderr[-600:]).strip() or f"exit {process.returncode}"}


def scratch_copy(project: pathlib.Path, scratch: pathlib.Path) -> pathlib.Path:
    """The project without its Library, so what MiniUnity writes lands in the copy."""
    target = scratch / project.name
    shutil.copytree(project, target, ignore=shutil.ignore_patterns("Library", "Temp", "Logs"), symlinks=True)
    return target


def build_scenes(project: pathlib.Path) -> list[str]:
    """The scenes in EditorBuildSettings, in order, else every scene under Assets."""
    settings = project / "ProjectSettings" / "EditorBuildSettings.asset"
    scenes = []
    if settings.is_file():
        scenes = re.findall(r"path:\s*(Assets/\S+\.unity)", settings.read_text(errors="replace"))
    if not scenes:
        scenes = sorted(str(p.relative_to(project)) for p in (project / "Assets").rglob("*.unity"))
    return scenes


def run_project(mu: MiniUnity, project: pathlib.Path, scenes: list[str], seconds: float, size: str,
                inputs: str | None, watches: list[str], shots: pathlib.Path | None, tag: str) -> dict:
    resolve = mu.ua(project, "pkg.resolve", "--fetch")
    compile_result = summarise_compile(mu.ua(project, "compile"))
    plays = {}
    if compile_result["verdict"] == PASS:
        for scene in scenes:
            args = ["play", scene, "--seconds", str(seconds), "--size", size]
            if inputs:
                args += ["--input", inputs]
            if watches:
                args += ["--watch", ",".join(watches)]
            if shots is not None:
                shots.mkdir(parents=True, exist_ok=True)
                args += ["--screenshot", str(shots / f"{tag}-{pathlib.Path(scene).stem}.png@{max(seconds - 1, 0)}")]
            plays[scene] = summarise_play(mu.ua(project, *args))
    return {
        "packages": {"ok": resolve.get("ok", False), "count": resolve.get("count"), "fetched": resolve.get("fetched"), "error": resolve.get("error")},
        "compile": compile_result,
        "play": plays,
    }


def gate(project: pathlib.Path, *, source: pathlib.Path | None = None, miniunity: str | None = None,
         editor: str | None = None, scenes: list[str] | None = None, seconds: float = 5, size: str = "720x1280",
         inputs: str | None = None, watches: list[str] | None = None, screenshots: pathlib.Path | None = None) -> dict:
    home = find_miniunity(miniunity)
    if home is None:
        return {"status": BLOCKED, "reason": "MINIUNITY_NOT_AVAILABLE (set --miniunity or MINIUNITY_HOME to a MiniUnity checkout that ran setup.sh)"}
    mu = MiniUnity(home, editor)
    watches = watches or []
    with tempfile.TemporaryDirectory(prefix="miniunity_gate_") as tmp:
        scratch = pathlib.Path(tmp)
        recovered_copy = scratch_copy(project, scratch / "recovered")
        scene_list = scenes or build_scenes(recovered_copy)
        report = {"status": "RAN", "miniunity": str(home), "project": str(project), "scenes": scene_list,
                  "scenario": {"seconds": seconds, "size": size, "input": inputs, "watch": watches}}
        report["recovered"] = run_project(mu, recovered_copy, scene_list, seconds, size, inputs, watches, screenshots, "recovered")
        if source is not None:
            source_copy = scratch_copy(source, scratch / "source")
            report["source"] = run_project(mu, source_copy, scene_list, seconds, size, inputs, watches, screenshots, "source")
            comparison = {}
            for scene in scene_list:
                recovered_play = report["recovered"]["play"].get(scene)
                source_play = report["source"]["play"].get(scene)
                if recovered_play is None or source_play is None:
                    comparison[scene] = {"verdict": BLOCKED, "reason": "a side did not play (compile failed)"}
                else:
                    comparison[scene] = compare_watches(recovered_play["watch"], source_play["watch"])
            report["behaviour"] = comparison
    return report


def verdicts(report: dict) -> list[tuple[str, str, str]]:
    """(stage, verdict, detail) rows for validate_unity_stages.py."""
    if report.get("status") != "RAN":
        reason = report.get("reason", "")
        return [("D2", BLOCKED, reason), ("F2", BLOCKED, reason), ("I2", BLOCKED, reason)]
    recovered = report["recovered"]
    compiled = recovered["compile"]
    skipped = compiled["skipped_because_a_dependency_failed"]
    detail = f"{compiled['errors']} errors, {compiled['assemblies_ok']}/{compiled['assemblies']} assemblies"
    if skipped:
        detail += f", {len(skipped)} skipped because a dependency failed ({', '.join(sorted(skipped)[:3])})"
    rows = [("D2", compiled["verdict"], detail)]
    plays = recovered["play"]
    if not plays:
        rows.append(("F2", BLOCKED, "nothing played: the project does not compile under Unity's rules"))
    else:
        worst = FAIL if any(p["verdict"] == FAIL for p in plays.values()) else PASS_WITH_GAPS if any(p["verdict"] == PASS_WITH_GAPS for p in plays.values()) else PASS
        runtime = sum(sum(p["runtime_exceptions"].values()) for p in plays.values())
        gaps = sum(sum(p["miniunity_gaps"].values()) for p in plays.values())
        rows.append(("F2", worst, f"{len(plays)} scenes, {runtime} runtime exceptions, {gaps} MiniUnity API gaps"))
    behaviour = report.get("behaviour")
    if behaviour is None:
        rows.append(("I2", BLOCKED, "no --source to compare against"))
    else:
        compared = [b for b in behaviour.values() if b.get("verdict") in (PASS, FAIL)]
        differing = sum(len(b.get("differing", [])) for b in compared)
        values = sum(len(b.get("values", {})) for b in compared)
        if not compared:
            reasons = sorted({b.get("reason") or "no --watch in the scenario" for b in behaviour.values()})
            rows.append(("I2", BLOCKED, "; ".join(reasons)))
        else:
            rows.append(("I2", FAIL if differing else PASS, f"{values} watched values over {len(compared)} scenes, {differing} differ from the source"))
    return rows


def load_scenario(path: pathlib.Path | None, project: pathlib.Path) -> dict:
    """The scenario for this fixture from the scenario file, matched on the game directory's name."""
    if path is None or not path.is_file():
        return {}
    data = json.loads(path.read_text())
    return data.get("fixtures", {}).get(project.name, {})


def self_test() -> int:
    failures = 0

    def check(condition, message):
        nonlocal failures
        print(("  ok   " if condition else "  FAIL ") + message)
        failures += 0 if condition else 1

    check(classify("NotImplementedException", "UnityEngine.TextGenerator.Invalidate") == MINIUNITY_GAP, "a Unity stub is a MiniUnity gap")
    check(classify("System.NotImplementedException", "UnityEngine.Screen.currentResolution") == MINIUNITY_GAP, "with its namespace too")
    check(classify("NotImplementedException", "The method or operation is not implemented.") == RUNTIME_EXCEPTION,
          "a NotImplementedException that names no Unity member is the project's own")
    check(classify("NullReferenceException", "Object reference not set to an instance of an object.") == RUNTIME_EXCEPTION, "a null reference is a runtime exception")
    check(classify("MissingReferenceException", "The variable moveSound of Movement doesn't exist anymore.") == RUNTIME_EXCEPTION, "so is a missing reference")

    play = summarise_play({"ok": True, "frames": 300, "objects": 10, "watch": {"A/T.position": "(0, 1, 2)"}, "logs": [
        {"type": "Exception", "message": "NotImplementedException: UnityEngine.TextGenerator.Invalidate", "count": 6},
        {"type": "Exception", "message": "NullReferenceException: Object reference not set to an instance of an object.", "count": 2},
    ], "exceptions": [{"type": "System.NullReferenceException", "message": "Object reference not set to an instance of an object.",
                       "stack": [{"method": "Movement.Update", "file": "Assets/Scripts/Movement.cs", "line": 115}]}]})
    check(play["verdict"] == FAIL, "a runtime exception fails the scene")
    check(play["miniunity_gaps"] == {"NotImplementedException: UnityEngine.TextGenerator.Invalidate": 6}, "gaps are counted apart")
    check(list(play["runtime_exception_sites"].values()) == ["Assets/Scripts/Movement.cs:115"], "the first project frame is the site")
    gaps_only = summarise_play({"ok": True, "logs": [{"type": "Exception", "message": "NotImplementedException: UnityEngine.Screen.currentResolution", "count": 3}]})
    check(gaps_only["verdict"] == PASS_WITH_GAPS, "only gaps is PASS_WITH_GAPS, never PASS")
    check(summarise_play({"ok": True, "logs": []})["verdict"] == PASS, "nothing thrown is PASS")
    check(summarise_play({"ok": False, "error": "scene not found"})["verdict"] == FAIL, "a play that did not run is FAIL")

    compiled = summarise_compile({"ok": True, "success": False, "errors": 2, "assemblies": [
        {"name": "Lib", "ok": False, "errors": 2}, {"name": "Assembly-CSharp", "ok": False, "errors": 0, "skippedBecause": "Lib"},
        {"name": "UI", "ok": True, "errors": 0}], "diagnostics": [
        {"severity": "error", "id": "CS0106", "file": "Assets/Scripts/Lib/A.cs", "line": 8, "message": "The modifier 'abstract' is not valid for this item"},
        {"severity": "warning", "id": "CS0108", "file": "x", "line": 1, "message": "w"}]})
    check(compiled["verdict"] == FAIL and compiled["failed"] == {"Lib": 2}, "a failed assembly fails the compile")
    check(compiled["skipped_because_a_dependency_failed"] == {"Assembly-CSharp": "Lib"}, "a skipped assembly is named with its cause")
    check(compiled["errors_by_code"] == {"CS0106": 1}, "warnings are not errors")

    same = compare_watches({"a": "1", "b": "2"}, {"a": "1", "b": "2"})
    differs = compare_watches({"a": "1", "b": "3"}, {"a": "1", "b": "2"})
    check(same["verdict"] == PASS and differs["verdict"] == FAIL and differs["differing"] == ["b"], "watches compare value by value")
    check(compare_watches({}, {})["verdict"] == BLOCKED, "nothing watched decides nothing")
    absent = compare_watches({"a": "component not found"}, {"a": "component not found"})
    check(absent["verdict"] == BLOCKED and absent["unobserved"] == ["a"], "not found on both sides observed nothing")
    lost = compare_watches({"a": "object not found"}, {"a": "(0, 1, 2)"})
    check(lost["verdict"] == FAIL, "not found on one side only is a difference")

    rows = verdicts({"status": BLOCKED, "reason": "MINIUNITY_NOT_AVAILABLE"})
    check(all(v == BLOCKED for _, v, _ in rows), "no MiniUnity is BLOCKED on every row, never PASS")
    rows = verdicts({"status": "RAN", "recovered": {"compile": compiled, "play": {}}})
    check(rows[0][1] == FAIL and rows[1][1] == BLOCKED and rows[2][1] == BLOCKED, "a project that does not compile plays nothing")
    check(find_miniunity("/nonexistent") is None or os.environ.get("MINIUNITY_HOME"), "a directory without ua.sh is not MiniUnity")

    print(f"{'PASS' if failures == 0 else 'FAILED'}: self-test, {failures} failures")
    return 1 if failures else 0


def main() -> int:
    if "--self-test" in sys.argv:
        return self_test()
    parser = argparse.ArgumentParser(description=__doc__.split("\n\n")[0])
    parser.add_argument("project", help="the game directory inside the rip output")
    parser.add_argument("--source", help="the source Unity project, to play the same scenario on and compare")
    parser.add_argument("--scenario", default=str(REPO / "Test" / "miniunity-scenarios.json"),
                        help="scenes, input and watches per fixture (matched on the game directory's name)")
    parser.add_argument("--miniunity", help="MiniUnity checkout (default: $MINIUNITY_HOME)")
    parser.add_argument("--unity-editor", help="Unity Editor folder for MiniUnity (default: its own search)")
    parser.add_argument("--scene", action="append", help="a scene to play (default: the scenario's, else Build Settings)")
    parser.add_argument("--seconds", type=float)
    parser.add_argument("--size")
    parser.add_argument("--input")
    parser.add_argument("--watch", action="append")
    parser.add_argument("--screenshots", help="directory for one screenshot per scene and side")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    project = pathlib.Path(arguments.project).resolve()
    if not (project / "Assets").is_dir():
        print(f"PROJECT_ROOT_MISMATCH: {project} has no Assets/ (pass the game directory inside the rip)")
        return 2
    scenario = load_scenario(pathlib.Path(arguments.scenario) if arguments.scenario else None, project)
    report = gate(
        project,
        source=pathlib.Path(arguments.source).resolve() if arguments.source else None,
        miniunity=arguments.miniunity,
        editor=arguments.unity_editor,
        scenes=arguments.scene or scenario.get("scenes"),
        seconds=arguments.seconds or scenario.get("seconds", 5),
        size=arguments.size or scenario.get("size", "720x1280"),
        inputs=arguments.input or scenario.get("input"),
        watches=arguments.watch or scenario.get("watch"),
        screenshots=pathlib.Path(arguments.screenshots) if arguments.screenshots else None,
    )

    print(f"project: {project}")
    for stage, verdict, detail in verdicts(report):
        print(f"{stage:<4}{verdict:<16}{detail}")
    if report.get("status") == "RAN":
        for side in ("recovered", "source"):
            if side not in report:
                continue
            compiled = report[side]["compile"]
            print(f"\n== {side}: compile {compiled['verdict']} ({compiled['errors']} errors) ==")
            for name, cause in sorted(compiled["skipped_because_a_dependency_failed"].items()):
                print(f"  skipped {name} because {cause} failed")
            for line in compiled["first_errors"][:5]:
                print(f"  {line}")
            for scene, play in report[side]["play"].items():
                print(f"  play {scene}: {play['verdict']}, {play['frames']} frames, {play['objects']} objects, {play['audio_events']} audio events")
                for message, count in sorted(play["runtime_exceptions"].items(), key=lambda kv: -kv[1])[:5]:
                    print(f"    RUNTIME_EXCEPTION x{count}  {message[:120]}")
                for message, count in sorted(play["miniunity_gaps"].items(), key=lambda kv: -kv[1])[:5]:
                    print(f"    MINIUNITY_GAP     x{count}  {message[:120]}")
        for scene, result in (report.get("behaviour") or {}).items():
            print(f"\n== behaviour {scene}: {result['verdict']} ==")
            for key, row in (result.get("values") or {}).items():
                print(f"  {'=' if row['equal'] else '≠'} {key}: recovered {row['recovered']}  source {row['source']}")
    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))
    return 1 if any(v == FAIL for _, v, _ in verdicts(report)) else 0


if __name__ == "__main__":
    sys.exit(main())
