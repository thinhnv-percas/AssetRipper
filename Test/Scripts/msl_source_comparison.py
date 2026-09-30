#!/usr/bin/env python3
"""The Metal programs a build shipped, against the ShaderLab a source project declares for the same shader.

Iteration 063. The exported shader is a stand-in wherever the build's programs are MSL, because ShaderLab
has no block for MSL - so `shader_semantic_equivalence.py` rightly calls it DUMMY. The programs themselves
were extracted, and this compares *them* with the source: which operation classes and which samplers the
two reach. Which side is the reference depends on where the source came from, and is stated per shader:

  INDEPENDENT   a package shader at the version the build used: the source is the programmer's
  REBUILT       a shader the source project wrote by hand after deriving from a rip of this build (its
                history says "Rebuild dummy ..."): the build's MSL is the original, the source the copy
  STAND_IN      the source still carries a rip's replacement program: nothing to compare against

Operation classes, not counts: HLSLcc unrolls, inlines and splits, so counts differ between any HLSL and
its translation and say nothing.

Usage: msl_source_comparison.py <rip output> <source project> [--package-dir DIR] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import subprocess
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import shader_semantic_ir as ir  # noqa: E402

STAND_IN_MARKERS = ("DummyShaderTextExporter", "AssetRipperReplacementProgram")


def origin(path, project):
    text = path.read_text(errors="replace")
    if any(marker in text for marker in STAND_IN_MARKERS):
        return "STAND_IN"
    # A package, or a package's resources copied into the project (TMP Essential Resources), with no rip
    # marker in it: the programmer's text.
    if "PackageCache" in str(path) or "/TextMesh Pro/" in str(path):
        return "INDEPENDENT"
    try:
        log = subprocess.run(["git", "-C", str(project), "log", "--format=%s", "--", str(path.relative_to(project))],
                             capture_output=True, text=True, check=True).stdout
    except (subprocess.CalledProcessError, ValueError):
        log = ""
    return "REBUILT" if "Rebuild" in log or "rebuild" in log or log.count("\n") > 1 else "DERIVED_UNCHANGED"


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("rip")
    parser.add_argument("source")
    parser.add_argument("--package-dir", action="append", default=[])
    parser.add_argument("--json")
    args = parser.parse_args()

    rip, project = pathlib.Path(args.rip), pathlib.Path(args.source)
    candidates = list((project / "Assets").rglob("*.shader"))
    for directory in args.package_dir:
        candidates += list(pathlib.Path(directory).rglob("*.shader"))
    by_name = {}
    for path in candidates:
        name = ir.source_shader_name(path)
        if name and name not in by_name:
            by_name[name] = path

    rows, tally = [], collections.Counter()
    for name, path in sorted(by_name.items()):
        programs = [p for p in ir.recovered_programs(rip, name) if ir.language_of(p) == "msl"]
        if not programs:
            continue
        kind = origin(path, project)
        row = {"shader": name, "source": str(path), "origin": kind, "mslPrograms": len(programs)}
        if kind == "STAND_IN":
            row["verdict"] = "NO_SOURCE_PROGRAM"
        else:
            source_programs = ir.source_programs(path)
            src = set(ir.merge(source_programs, "hlsl"))
            rec = set(ir.merge(programs, "msl"))
            src_samplers = set().union(*(ir.samplers(p) for p in source_programs)) if source_programs else set()
            rec_samplers = set().union(*(ir.samplers(p) for p in programs))
            row.update(sourceOnly=sorted(src - rec), mslOnly=sorted(rec - src),
                       samplersSourceOnly=sorted(src_samplers - rec_samplers),
                       samplersMslOnly=sorted(rec_samplers - src_samplers))
            # What a translation must keep: which textures are sampled, whether fragments are discarded,
            # and that position and colour are written. Arithmetic classes are reported and not judged:
            # HLSLcc rewrites lerp as arithmetic, folds saturate into clamp, and drops what folds away.
            essential = {"TEXTURE_SAMPLE", "DISCARD", "STORE_POSITION", "STORE_COLOR"}
            lost_essential = sorted((src & essential) - rec)
            row["essentialSourceOnly"] = lost_essential
            agree = not lost_essential and not row["samplersSourceOnly"] and not row["samplersMslOnly"]
            row["verdict"] = "SAMPLING_AGREES" if agree else "SAMPLING_DIFFERS"
        tally[(kind, row["verdict"])] += 1
        rows.append(row)

    for row in rows:
        print(f"  {row['origin']:18} {row['verdict']:18} {row['shader']:44} "
              f"essential {row.get('essentialSourceOnly', '-')} samplers src-only {row.get('samplersSourceOnly', '-')} msl-only {row.get('samplersMslOnly', '-')}")
    print(json.dumps({f"{k}:{v}": n for (k, v), n in sorted(tally.items())}))
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(rows, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
