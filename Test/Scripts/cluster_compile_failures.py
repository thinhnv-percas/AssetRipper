#!/usr/bin/env python3
"""Groups a rip's compile errors by root cause rather than by error code.

An error code is not a cause. CS0030 on this project is at least four unrelated defects, and two
different codes - CS0079 and CS0030 - are one: a body that reads an event's backing field is refused
once for reading an event and once for the cast that follows. Clustering by the *shape of what the
compiler rejected* is what puts a number on each thing to fix.

Usage: cluster_compile_failures.py <errors file> [--json out.json] [--markdown out.md]

The errors file is what `ERRORS_TO=<file> compile_recovered_scripts.sh` writes: every `: error ` line
Roslyn printed, with its file and position.
"""
import argparse
import collections
import json
import pathlib
import re
import sys

LINE = re.compile(r"^(?P<file>[^(]+)\((?P<line>\d+),(?P<col>\d+)\): error (?P<code>CS\d+): (?P<message>.*)$")

# Each rule is (cluster, category, matcher). Order matters: the first that matches wins, so the
# specific shapes come before the general ones. The category is the §4 taxonomy.
RULES = [
    ("EVENT_BACKING_FIELD", "FIELD", lambda code, m:
        code == "CS0079" or (code == "CS0030" and "EventHandler" in m) or (code == "CS0029" and "EventHandler" in m)),
    ("FRAMEWORK_PRIVATE_MEMBER", "TYPE", lambda code, m:
        code in ("CS1061", "CS0122") and re.search(r"'(List|Dictionary|Stack|Queue|HashSet|String|Array)[<`']", m) is not None),
    ("MANGLED_IDENTIFIER", "DECOMPILER", lambda code, m: "_002E" in m or "_0021" in m or "_003F" in m),
    ("NATIVE_INT_CAST", "CAST", lambda code, m:
        code in ("CS0030", "CS0037", "CS0029") and ("nint" in m or "'System.IntPtr'" in m)),
    ("ATTRIBUTE_ARGUMENT", "DECOMPILER", lambda code, m: code == "CS0617"),
    ("ACCESSOR_VISIBILITY", "TYPE", lambda code, m: code in ("CS0272", "CS0507", "CS0506")),
    ("UNASSIGNED_LOCAL", "CONTROL_FLOW", lambda code, m: code == "CS0165"),
    ("PARSE", "DECOMPILER", lambda code, m: code in ("CS1525", "CS1002", "CS1519", "CS1031")),
    ("MEMBER_NOT_FOUND", "FIELD", lambda code, m: code in ("CS1061", "CS0117")),
    ("INACCESSIBLE", "TYPE", lambda code, m: code == "CS0122"),
    ("INVALID_CAST", "CAST", lambda code, m: code in ("CS0030", "CS0029", "CS0037")),
    ("MISSING_TYPE", "REFERENCE", lambda code, m: code in ("CS0246", "CS0234")),
    ("OPERATOR", "CALL", lambda code, m: code == "CS0019"),
    ("UNSAFE", "DECOMPILER", lambda code, m: code in ("CS8172", "CS0193", "CS0208")),
]


def cluster_of(code: str, message: str) -> tuple[str, str]:
    for name, category, matches in RULES:
        if matches(code, message):
            return name, category
    return "OTHER:" + code, "OTHER"


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("errors")
    parser.add_argument("--json")
    parser.add_argument("--markdown")
    arguments = parser.parse_args()

    path = pathlib.Path(arguments.errors)

    if not path.is_file():
        print(f"NO_ERRORS_FILE: {path}")
        return 2

    clusters = collections.defaultdict(lambda: {
        "category": "", "count": 0, "files": set(), "codes": collections.Counter(),
        "messages": collections.Counter(),
    })
    total = 0
    unparsed = 0

    for raw in path.read_text(encoding="utf-8", errors="replace").splitlines():
        match = LINE.match(raw.strip())

        if not match:
            unparsed += 1
            continue

        total += 1
        name, category = cluster_of(match["code"], match["message"])
        entry = clusters[name]
        entry["category"] = category
        entry["count"] += 1
        entry["files"].add(pathlib.Path(match["file"]).name)
        entry["codes"][match["code"]] += 1
        entry["messages"][match["message"][:160]] += 1

    ranked = sorted(clusters.items(), key=lambda item: -item[1]["count"])
    faulted = {name for entry in clusters.values() for name in entry["files"]}

    print(f"errors: {total} ({unparsed} lines not parsed), files with at least one: {len(faulted)}\n")
    print(f"{'cluster':<28}{'category':<16}{'errors':>7}{'files':>7}  most common message")
    print("-" * 140)

    for name, entry in ranked:
        example = entry["messages"].most_common(1)[0]
        print(f"{name:<28}{entry['category']:<16}{entry['count']:>7}{len(entry['files']):>7}  "
              f"[{example[1]} of {entry['count']}] {example[0][:70]}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps([
            {
                "cluster": name,
                "category": entry["category"],
                "count": entry["count"],
                "affected_files": sorted(entry["files"]),
                "codes": dict(entry["codes"]),
                "messages": [{"message": message, "count": count}
                             for message, count in entry["messages"].most_common(8)],
            }
            for name, entry in ranked
        ], indent=2))

    if arguments.markdown:
        lines = ["# Compile failures by root cause", "",
                 f"{total} errors across {len(faulted)} files.", "",
                 "| cluster | category | errors | files | most common message |",
                 "|---|---|---|---|---|"]
        for name, entry in ranked:
            example = entry["messages"].most_common(1)[0]
            message = example[0].replace("|", "\\|")[:110]
            lines.append(f"| `{name}` | {entry['category']} | {entry['count']} | {len(entry['files'])} | {message} |")
        pathlib.Path(arguments.markdown).write_text("\n".join(lines) + "\n")

    return 0


if __name__ == "__main__":
    sys.exit(main())
