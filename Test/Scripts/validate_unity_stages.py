#!/usr/bin/env python3
"""How far a recovered project gets toward running, stage by stage, and what the tool actually ran.

A rip is an export until something opens it. This walks the stages between the two and reports each
one with a verdict it can defend:

  A  project generated          the directory layout Unity requires
  B  scripts generated          C# files with bodies in them
  C  references consistent      every PPtr that names a target resolves
  D  C# compiles                Roslyn, against the assemblies the rip shipped
  E  AssetDatabase imports      needs Unity
  F  scene opens                needs Unity
  G  prefab instantiates        needs Unity
  H  MonoBehaviour lifecycle    needs Unity
  I  gameplay smoke test        needs Unity

Verdicts: PASS, FAIL, BLOCKED (the tool to decide this is not here), UNKNOWN (it is here and could
not decide). BLOCKED is never PASS and never FAIL - a stage nobody ran has no result, and reporting
one is how a pipeline claims to run a game it has never started. Nothing here simulates a runtime.

Usage: validate_unity_stages.py <rip output>/<GameName> [--log run.log] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import shutil
import subprocess
import sys

HERE = pathlib.Path(__file__).resolve().parent

PASS, FAIL, BLOCKED, UNKNOWN = "PASS", "FAIL", "BLOCKED", "UNKNOWN"

DUMMY_MARKER = "//DummyShaderTextExporter"

# A body the generator gave up on entirely. Counted so stage B can say "files exist" without that
# being read as "files have content".
EMPTY_BODY = re.compile(r"\{\s*\}")


def unity_available() -> bool:
    """Whether a Unity editor is on this machine at all."""
    return shutil.which("unity") is not None or shutil.which("Unity") is not None


def stage_a(root: pathlib.Path):
    """Unity opens a directory only if it has these; anything else it offers to create as new."""
    required = ["Assets", "ProjectSettings"]
    missing = [name for name in required if not (root / name).is_dir()]

    if missing:
        # A rip output holds the game directory, which is the project; pointed one level too high the
        # stages below still run and still print numbers, against the wrong tree. That is the same
        # silent-wrong-root failure the golden corpus had, so say which directory was meant.
        candidates = [child.name for child in sorted(root.iterdir()) if child.is_dir()
                      and all((child / name).is_dir() for name in required)] if root.is_dir() else []
        suggestion = f" - try {root / candidates[0]}" if candidates else ""
        return FAIL, f"no {', '.join(missing)} in {root}{suggestion}"

    version = root / "ProjectSettings" / "ProjectVersion.txt"

    if not version.is_file():
        # The editor will still open it, choosing a version itself, so this is not a failure - but it
        # is the difference between opening in the version the game was built with and some other.
        return PASS, "Assets and ProjectSettings present, no ProjectVersion.txt"

    return PASS, f"Assets and ProjectSettings present, {version.read_text(errors='replace').strip().splitlines()[0]}"


def stage_b(root: pathlib.Path):
    scripts = list(root.rglob("*.cs"))

    if not scripts:
        return FAIL, "no scripts were generated", {}

    total_bytes = sum(path.stat().st_size for path in scripts)
    trivial = sum(1 for path in scripts if path.stat().st_size < 200)

    return PASS, f"{len(scripts)} scripts, {total_bytes // 1024} KiB, {trivial} under 200 bytes", {
        "scripts": len(scripts), "bytes": total_bytes, "trivial": trivial,
    }


def stage_c(root: pathlib.Path):
    """Runs the reference audit and reads its own verdict rather than restating it."""
    result = subprocess.run(
        [sys.executable, str(HERE / "audit_project_references.py"), str(root), "--json", "/dev/stdout"],
        capture_output=True, text=True)

    if result.returncode != 0:
        return UNKNOWN, f"the reference audit exited {result.returncode}", {}

    try:
        payload = json.loads(result.stdout[result.stdout.index("{"):])
    except (ValueError, json.JSONDecodeError):
        return UNKNOWN, "the reference audit produced no report", {}

    verdicts = payload.get("verdicts", {})
    unfollowable = verdicts.get("BROKEN", 0) + verdicts.get("MISSING", 0) + verdicts.get("AMBIGUOUS", 0)
    rate = payload.get("reference_resolution_rate")

    detail = {
        "reference_resolution_rate": rate,
        "naming": payload.get("naming"),
        "unfollowable": unfollowable,
    }

    if rate is None:
        return UNKNOWN, "no reference names a target", detail

    return (PASS if unfollowable == 0 else FAIL,
            f"{rate:.4f} of {payload['naming']} references resolve, {unfollowable} do not", detail)


def stage_d(root: pathlib.Path, rip: pathlib.Path, assembly: str | None):
    """Roslyn, through the harness that owns the reference set."""
    harness = HERE / "compile_recovered_scripts.sh"

    if not harness.is_file():
        return BLOCKED, "no compile harness", {}

    # The harness compiles one assembly, defaulting to Assembly-CSharp, so "all of them" has to be
    # spelled out here. Stated rather than implied: a rate over one assembly and a rate over the
    # project are different claims, and the first was quietly being reported as the second.
    names = [assembly] if assembly else sorted({
        path.name for path in root.rglob("Scripts/*") if path.is_dir()
    })

    if not names:
        return UNKNOWN, "no recovered assemblies to compile", {}

    stdout = ""

    for name in names:
        result = subprocess.run(["bash", str(harness), str(rip), name], capture_output=True, text=True)
        stdout += result.stdout

    result = subprocess.CompletedProcess(args=[], returncode=0, stdout=stdout, stderr="")

    if "ROSLYN_STATUS: AVAILABLE_AND_RUN" not in result.stdout:
        # "No errors were printed" is also what an absent compiler produces, so a run that said
        # nothing is unknown rather than clean. The harness states which it was.
        return UNKNOWN, "no compiler ran", {}

    # Files, not errors, and not assemblies. One file with a hundred errors and a hundred files with
    # one are the same error count and completely different projects, and an assembly is too coarse
    # to move at all - it has been "not clean" for every iteration on record.
    clean = 0
    attempted = 0
    errors = 0
    detail = []

    for line in result.stdout.splitlines():
        counted = re.search(r"(?P<name>\S+): (?P<clean>\d+) of (?P<files>\d+) files compile clean", line)

        if counted:
            clean += int(counted["clean"])
            attempted += int(counted["files"])
            detail.append({"assembly": counted["name"].rstrip(":"),
                           "clean": int(counted["clean"]), "files": int(counted["files"])})
            continue

        counted = re.search(r"\S+: \d+ files, (?P<errors>\d+) errors", line)

        if counted:
            errors += int(counted["errors"])

    if attempted == 0:
        return UNKNOWN, "the compile harness reported no assembly", {}

    rate = clean / attempted

    return (PASS if clean == attempted else FAIL,
            f"{clean} of {attempted} files compile clean, {errors} errors",
            {"compile_pass_rate": rate, "compile_errors": errors, "assemblies": detail})


def body_status(rip: pathlib.Path, log: str | None):
    """How much of the native code came back, from the authoritative semantic measure."""
    if log is None:
        return {}

    result = subprocess.run(
        [sys.executable, str(HERE / "recovery_metrics.py"), str(rip), "--log", log],
        capture_output=True, text=True)

    counts = {}

    for line in result.stdout.splitlines():
        match = re.match(r"\s*(\d+)\s+(EXACT|HIGH_CONFIDENCE|PARTIAL|FALLBACK|MISSING)\b", line)
        if match:
            counts[match.group(2)] = int(match.group(1))

    total = sum(counts.values())

    if total == 0:
        # Not "no log": a log was read and the answer is that nothing in this rip carries a native
        # address, so no body was recovered at all. The iOS fixture is exactly this - FairPlay
        # encrypts the whole of __TEXT, so declarations and signatures come back and method bodies
        # cannot - and it is the case a compile rate on its own reports as near perfect.
        return {"body_status": {}, "bodies_attempted": 0}

    # A body is recovered when the analysis put real operations in it. FALLBACK and MISSING are
    # stand-ins, and a project made of stand-ins compiles.
    recovered = counts.get("EXACT", 0) + counts.get("HIGH_CONFIDENCE", 0) + counts.get("PARTIAL", 0)

    return {"body_recovery_rate": recovered / total, "body_status": counts, "bodies_attempted": total}


def shader_status(root: pathlib.Path):
    """Every exported shader, by what it actually is."""
    counts = collections.Counter()

    for path in root.rglob("*.shader"):
        text = path.read_text(encoding="utf-8", errors="replace")
        # The exporter names itself in the output, so this needs no inference: a shader carrying that
        # marker has had its whole program replaced by one unlit pass, whatever its properties say.
        counts["DUMMY" if DUMMY_MARKER in text else "EXACT_OR_BETTER"] += 1

    return counts


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root", help="the game directory inside the rip output")
    parser.add_argument("--rip", help="the rip output directory, for the compile harness; defaults to the parent")
    parser.add_argument("--assembly", help="restrict the compile stage to one assembly")
    parser.add_argument("--log", help="the run log, so the body measure can be read beside the compile rate")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    rip = pathlib.Path(arguments.rip) if arguments.rip else root.parent

    if not root.is_dir():
        print(f"NOT_A_DIRECTORY: {root}")
        return 2

    stages = []
    metrics = {}

    verdict, detail = stage_a(root)
    stages.append(("A", "project generated", verdict, detail))

    # Nothing below this measures anything about a directory that is not a Unity project, and a
    # number computed over the wrong tree is worse than no number at all.
    if verdict == FAIL:
        print(f"project: {root}\n")
        print(f"A  project generated         {verdict}     {detail}")
        print("\nPROJECT_ROOT_MISMATCH: no stage below A was run.")
        return 2

    verdict, detail, extra = stage_b(root)
    stages.append(("B", "scripts generated", verdict, detail))
    metrics.update(extra)

    verdict, detail, extra = stage_c(root)
    stages.append(("C", "references consistent", verdict, detail))
    metrics.update(extra)

    verdict, detail, extra = stage_d(root, rip, arguments.assembly)
    stages.append(("D", "C# compiles", verdict, detail))
    metrics.update(extra)

    # Everything past here needs an editor. Saying BLOCKED rather than leaving it out is the point:
    # an absent stage reads as one nobody thought of, and a PASS here would be a claim about a
    # program that was never started.
    blocked = "UNITY_NOT_AVAILABLE" if not unity_available() else "not implemented in this harness"

    for letter, name in [("E", "AssetDatabase imports"), ("F", "scene opens"), ("G", "prefab instantiates"),
                         ("H", "MonoBehaviour lifecycle"), ("I", "gameplay smoke test")]:
        stages.append((letter, name, BLOCKED, blocked))

    # A compile rate read on its own is the "a stand-in that compiles looks exactly like success"
    # trap in another place. An export whose bodies are empty compiles beautifully: the iOS fixture,
    # whose __TEXT is FairPlay-encrypted so no method body can be read at all, scores 0.9654 against
    # the Android fixture's 0.8952. So where the log is available the body measure is printed beside
    # it, and where it is not, that is said rather than left out.
    bodies = body_status(rip, arguments.log)
    metrics.update(bodies)

    shaders = shader_status(root)
    total_shaders = sum(shaders.values())

    print(f"project: {root}\n")
    print(f"{'':<3}{'stage':<26}{'verdict':<9}detail")
    print("-" * 100)
    for letter, name, verdict, detail in stages:
        print(f"{letter:<3}{name:<26}{verdict:<9}{detail}")

    print("\n== metrics ==")
    print(f"compile_pass_rate          {format_rate(metrics.get('compile_pass_rate'))}")
    if "body_recovery_rate" in metrics:
        print(f"body_recovery_rate         {format_rate(metrics['body_recovery_rate'])}"
              f"  ({metrics['bodies_attempted']} methods carry a native address)")
    elif metrics.get("bodies_attempted") == 0:
        print("body_recovery_rate         NO_BODIES  (nothing in this rip carries a native address, "
              "so the compile rate is over declarations)")
    else:
        print("body_recovery_rate         UNKNOWN  (no --log, so the compile rate cannot be read alone)")
    print(f"reference_resolution_rate  {format_rate(metrics.get('reference_resolution_rate'))}")
    print(f"scene_load_rate            BLOCKED ({blocked})")
    print(f"prefab_load_rate           BLOCKED ({blocked})")
    print(f"runtime_smoke_pass_rate    BLOCKED ({blocked})")
    print(f"shader_exact               {shaders['EXACT_OR_BETTER']} of {total_shaders}")
    print(f"shader_dummy               {shaders['DUMMY']} of {total_shaders}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "project": str(root),
            "stages": [{"stage": s, "name": n, "verdict": v, "detail": d} for s, n, v, d in stages],
            "metrics": metrics,
            "shaders": dict(shaders),
        }, indent=2))

    # A blocked stage is not a failure of the project, so it does not fail the run; a stage that ran
    # and said no is.
    return 1 if any(verdict == FAIL for _, _, verdict, _ in stages) else 0


def format_rate(value) -> str:
    return "UNKNOWN" if value is None else f"{value:.4f}"


if __name__ == "__main__":
    sys.exit(main())
