#!/usr/bin/env python3
"""The methods a person corrected in the JellyBlast source, read from its commit messages.

Iteration 063. The JellyBlast source is derived from an earlier rip of this very pipeline
(`reports/JELLYBLAST_BUILD_PROVENANCE.md`), and its history names what was wrong with that rip:
`Fix Fish: IsInWater, PlayHitWaterAnimation, FallThenFly, ... constructor`. Each named method is one a
person judged the recovery to have got wrong, which makes the list a labelled defect corpus - labelled by
someone other than this project's measurements.

It is not ground truth for the fix itself: the corrected text is a person's (or an LLM's) reading of the
old output and the native code, so where the current recovery disagrees with it, either may be right.
The report says which methods are in the corpus and what the source oracle says about each today.

Usage: jellyblast_fix_corpus.py <source checkout> <derivation root> <pinned commit>
           [--oracle jellyblast_source_oracle.json] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import subprocess
import sys

# "Fix Fish: IsInWater, PlayHitWaterAnimation, constructor" - a type and the methods corrected in it.
PER_METHOD = re.compile(r"^Fix (?P<type>[A-Za-z_][\w.]*): (?P<methods>.+)$")
# "Fix Chain.cs decompiler corruption (36 errors)" or "Fix compile errors in Stone, FixedFluid" -
# whole files, no method named.
PER_FILE = re.compile(r"^Fix (?:(?P<file>[\w.]+)\.cs decompiler corruption|compile errors in (?P<types>.+)|"
                      r"(?P<types2>[\w, ]+) decompiled code)")


def commits(checkout, since, until):
    out = subprocess.run(["git", "-C", str(checkout), "log", "--format=%h%x09%s", f"{since}..{until}"],
                         check=True, capture_output=True, text=True).stdout
    for line in out.splitlines():
        sha, _, subject = line.partition("\t")
        yield sha, subject


def method_names(text, type_name):
    for raw in re.split(r",\s*|\s+and\s+", text):
        name = raw.strip().rstrip(".")
        name = re.sub(r"\(\)$", "", name)
        # "Update() per-character pop/bounce animation" - the method is the first word.
        name = name.split("(")[0].split(" ")[0]
        if not name:
            continue
        if name == "constructor":
            yield ".ctor"
        elif name in ("text", "getter") or not re.match(r"^[A-Za-z_]\w*$", name):
            continue
        else:
            yield name
    # A slash joins alternatives: "Bezier/BezierDeriv/ApproxQuadLen".


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("checkout")
    parser.add_argument("since")
    parser.add_argument("until")
    parser.add_argument("--oracle")
    parser.add_argument("--build-fingerprint", help="keep only names the build's Assembly-CSharp declares: "
                        "a commit subject is prose, and 'particle add/remove' names no method")
    parser.add_argument("--json")
    args = parser.parse_args()

    methods, files = [], []
    for sha, subject in commits(pathlib.Path(args.checkout), args.since, args.until):
        match = PER_METHOD.match(subject)
        if match and "decompiled code" not in subject:
            type_name = match["type"]
            for part in re.split(r",\s*", match["methods"]):
                for name in part.split("/"):
                    for method in method_names(name, type_name):
                        methods.append({"type": type_name, "method": method, "commit": sha, "subject": subject})
            continue
        match = PER_FILE.match(subject)
        if match:
            types = match["file"] or match["types"] or match["types2"] or ""
            for type_name in re.split(r",\s*|\s+and\s+", types):
                if type_name.strip():
                    files.append({"type": type_name.strip(), "commit": sha, "subject": subject})

    if args.build_fingerprint:
        declared = set()
        for line in open(args.build_fingerprint, encoding="utf-8", errors="replace"):
            cells = line.rstrip("\n").split("\t")
            if len(cells) >= 4 and cells[0] == "Assembly-CSharp" and cells[2] == "method":
                declared.add((cells[1].split(".")[-1], cells[3]))
        prose = [e for e in methods if (e["type"], e["method"]) not in declared]
        methods = [e for e in methods if (e["type"], e["method"]) in declared]
        print(f"dropped {len(prose)} words that name no method of the build: "
              + ", ".join(sorted({f"{e['type']}.{e['method']}" for e in prose})))

    verdicts = {}
    if args.oracle:
        for assembly in json.loads(pathlib.Path(args.oracle).read_text())["assemblies"]:
            if assembly["assembly"] != "Assembly-CSharp":
                continue
            for m in assembly.get("methods", []):
                verdicts.setdefault((m["type"], m["method"]), []).append(m["behaviour"])

    tally = collections.Counter()
    for entry in methods:
        name = entry["type"] if entry["method"] == ".ctor" else entry["method"]
        found = verdicts.get((entry["type"], name), [])
        entry["behaviour_today"] = found or ["NOT_PAIRED"]
        tally[found[0] if found else "NOT_PAIRED"] += 1

    print(f"methods named in fix commits: {len(methods)} across "
          f"{len({e['type'] for e in methods})} types; files fixed whole: {len(files)}")
    if verdicts:
        print("behaviour today against the corrected source:", json.dumps(dict(tally), sort_keys=True))
        for entry in methods:
            print(f"  {entry['commit']} {entry['type']}.{entry['method']:<28} {','.join(entry['behaviour_today'])}")
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps({"methods": methods, "files": files}, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
