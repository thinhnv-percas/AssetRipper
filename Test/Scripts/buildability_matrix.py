#!/usr/bin/env python3
"""The buildability matrix: how far each fixture is from a project that builds and runs, level by level.

Iteration 066. The older measures stay as they are - placeholders, EXACT, Roslyn errors - and this sits
beside them, because none of them alone says whether a recovered project would build, and each of them has
been read as if it did. Six levels, each read from the artefact that owns it:

  NativeRecovery        the run finished, no body threw out of the generator, no field layout disagreed
  SemanticRecovery      recovery_metrics: EXACT / HIGH_CONFIDENCE / PARTIAL / FALLBACK, as a rate
  UnityProjectRecovery  validate_unity_stages.py stages A-C (layout, scripts, references), when its JSON is given
  CompileReadiness      the body pass of compile_recovered_scripts.sh: files with no error over files compiled
  RuntimeReadiness      a Unity editor, found or not; without one: UNITY_NOT_AVAILABLE
  BehaviorReadiness     a static behaviour oracle rate when one is given, labelled as static; never PASS without a run

Verdicts: PASS, FAIL, MEASURED (a rate with no threshold this tool can defend), NOT_MEASURED (no input given),
UNITY_NOT_AVAILABLE (the tool to decide this is not here). Nothing here is FULLY_RECOVERED: that needs every gate
from import to behavioural equivalence to have run and passed, and in a container with no Unity none of the
runtime gates can.

    buildability_matrix.py --fixture NAME=<rip game dir> [--log NAME=run.log] [--rm NAME=recovery_metrics.json]
                           [--errors NAME=body-errors.txt] [--assembly NAME=Assembly-CSharp] [--stages NAME=stages.json]
                           [--behavior NAME=<rate>:<label>] [--json out.json] [--markdown out.md]
"""
import json
import os
import pathlib
import re
import shutil
import sys

LINE = re.compile(r'(.*?)\((\d+),(\d+)\): error (CS\d+): ')

UNITY_CANDIDATES = ["Unity", "unity", "unity-editor"]


def find_unity():
    """A Unity editor binary, from UNITY_PATH, the PATH, or the usual Hub locations; None when there is none."""
    explicit = os.environ.get("UNITY_PATH")
    if explicit and pathlib.Path(explicit).exists():
        return explicit
    for name in UNITY_CANDIDATES:
        if (found := shutil.which(name)):
            return found
    for hub in (pathlib.Path.home() / "Unity" / "Hub" / "Editor", pathlib.Path("/opt/unity"), pathlib.Path("/Applications/Unity/Hub/Editor")):
        if hub.exists():
            for candidate in hub.rglob("Unity"):
                if candidate.is_file() and os.access(candidate, os.X_OK):
                    return str(candidate)
    return None


def native_level(log):
    if not log or not pathlib.Path(log).exists():
        return {"verdict": "NOT_MEASURED", "reason": "no log"}
    text = pathlib.Path(log).read_text(errors="replace")
    failures = text.count("Cpp2IL [Error] : Decompiling")
    disagreed = sum(int(n) for n in re.findall(r"(\d+) disagreed", text)[:1])
    mismatched = len(re.findall(r"layout mismatched", text))
    complete = "Export : Finished exporting assets" in text
    verdict = "PASS" if complete and failures == 0 and disagreed == 0 and mismatched == 0 else "FAIL"
    return {"verdict": verdict, "generatorFailures": failures, "fieldLayoutDisagreements": disagreed,
            "monoBehaviourLayoutMismatches": mismatched, "runComplete": complete}


def semantic_level(rm_json):
    if not rm_json or not pathlib.Path(rm_json).exists():
        return {"verdict": "NOT_MEASURED", "reason": "no recovery_metrics json"}
    data = json.loads(pathlib.Path(rm_json).read_text())
    status = data.get("status", {})
    total = sum(status.values()) or 1
    return {"verdict": "MEASURED", "methods": total, "status": status,
            "exactRate": round(status.get("EXACT", 0) / total, 4),
            "placeholders": data.get("placeholders")}


def project_level(stages_json):
    if not stages_json or not pathlib.Path(stages_json).exists():
        return {"verdict": "NOT_MEASURED", "reason": "no validate_unity_stages json"}
    data = json.loads(pathlib.Path(stages_json).read_text())
    stages = data.get("stages", data)
    if isinstance(stages, list):
        stages = {f'{entry["stage"]} {entry["name"]}': entry for entry in stages}
    picked = {key: {"verdict": value.get("verdict"), "detail": value.get("detail")} for key, value in stages.items() if key[:1] in "ABC"}
    verdicts = [value["verdict"] for value in picked.values()]
    verdict = "PASS" if verdicts and all(v == "PASS" for v in verdicts) else ("FAIL" if "FAIL" in verdicts else "MEASURED")
    metrics = data.get("metrics", {})
    return {"verdict": verdict, "stages": picked,
            "referenceResolutionRate": metrics.get("reference_resolution_rate"), "bodyRecoveryRate": metrics.get("body_recovery_rate"),
            "note": "stage D of validate_unity_stages counts the declaration pass; CompileReadiness below is the body pass"}


def compile_level(root, errors, assembly):
    if not errors or not pathlib.Path(errors).exists():
        return {"verdict": "NOT_MEASURED", "reason": "no body-pass errors file"}
    base = pathlib.Path(root) / "Assets" / "Scripts" / (assembly or "")
    files = sorted(str(p.resolve()) for p in base.rglob("*.cs"))
    failing = set()
    count = 0
    for raw in open(errors, encoding="utf-8", errors="replace"):
        match = LINE.match(raw.strip())
        if match:
            count += 1
            failing.add(str(pathlib.Path(match.group(1)).resolve()))
    clean = sum(1 for f in files if f not in failing)
    return {"verdict": "PASS" if count == 0 and files else "FAIL", "assembly": assembly, "errors": count,
            "files": len(files), "filesClean": clean, "fileCompileRate": round(clean / len(files), 4) if files else None}


def runtime_level(unity):
    if unity is None:
        return {"verdict": "UNITY_NOT_AVAILABLE", "stages": {stage: "UNITY_NOT_AVAILABLE" for stage in
                ("import", "compile_in_editor", "build", "launch", "scenarios")}}
    return {"verdict": "NOT_RUN", "unity": unity, "reason": "a Unity editor exists; run AssetRipper.Tools.UnityBuildValidator for per-stage results"}


def behavior_level(spec, unity):
    if not spec:
        return {"verdict": "NOT_MEASURED", "reason": "no behaviour oracle given",
                "runtime": "UNITY_NOT_AVAILABLE" if unity is None else "NOT_RUN"}
    rate, _, label = spec.partition(":")
    return {"verdict": "MEASURED", "staticOracleRate": float(rate), "oracle": label or "static",
            "runtime": "UNITY_NOT_AVAILABLE" if unity is None else "NOT_RUN",
            "note": "a static oracle over the recovered text; behavioural equivalence needs both builds run"}


def parse(argv, flag):
    found = {}
    for index, item in enumerate(argv):
        if item == flag and index + 1 < len(argv):
            name, _, value = argv[index + 1].partition("=")
            found[name] = value
    return found


def main(argv) -> int:
    if len(argv) < 2 or "--help" in argv:
        print(__doc__)
        return 2
    fixtures = parse(argv, "--fixture")
    logs, rms, errors, assemblies = parse(argv, "--log"), parse(argv, "--rm"), parse(argv, "--errors"), parse(argv, "--assembly")
    stages, behaviors = parse(argv, "--stages"), parse(argv, "--behavior")
    unity = find_unity()
    matrix = {}
    for name, root in fixtures.items():
        matrix[name] = {
            "NativeRecovery": native_level(logs.get(name)),
            "SemanticRecovery": semantic_level(rms.get(name)),
            "UnityProjectRecovery": project_level(stages.get(name)),
            "CompileReadiness": compile_level(root, errors.get(name), assemblies.get(name)),
            "RuntimeReadiness": runtime_level(unity),
            "BehaviorReadiness": behavior_level(behaviors.get(name), unity),
            "FULLY_RECOVERED": False,
        }
    out = {"unity": unity or "UNITY_NOT_AVAILABLE", "fixtures": matrix}
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(out, indent=1))
    if "--markdown" in argv:
        lines = ["| Fixture | Native | Semantic (EXACT rate) | Project A-C | Compile (file rate) | Runtime | Behaviour |", "|---|---|---|---|---|---|---|"]
        for name, levels in matrix.items():
            sem = levels["SemanticRecovery"]
            comp = levels["CompileReadiness"]
            beh = levels["BehaviorReadiness"]
            lines.append(f"| {name} | {levels['NativeRecovery']['verdict']} | {sem.get('exactRate', sem['verdict'])} | "
                         f"{levels['UnityProjectRecovery']['verdict']} (refs {round(levels['UnityProjectRecovery'].get('referenceResolutionRate') or 0, 4)}) | {comp['verdict']} {comp.get('fileCompileRate', '')} ({comp.get('errors', '-')} lỗi) | "
                         f"{levels['RuntimeReadiness']['verdict']} | {beh.get('staticOracleRate', beh['verdict'])} |")
        pathlib.Path(argv[argv.index("--markdown") + 1]).write_text("\n".join(lines) + "\n")
    print(json.dumps(out, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
