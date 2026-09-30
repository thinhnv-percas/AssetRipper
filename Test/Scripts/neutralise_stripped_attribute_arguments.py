#!/usr/bin/env python3
"""Remove, from a copy of the scripts, the named attribute arguments the build's assemblies cannot take.

Iteration 063. IL2CPP strips an accessor nothing calls, and for an attribute's named argument that is the
getter: `CreateAssetMenuAttribute.order` is write-only in the build's UnityEngine, so
`[CreateAssetMenu(order = 1)]` is CS0617 against the stubs and fine against a Unity install. A CS0617 is a
*declaration* error, and Roslyn stops before binding a single method body when one exists, so eleven of
them hid every body error in JellyBlast's Assembly-CSharp. This removes exactly those arguments - each one
the classifier proves stripped, at the line and column Roslyn reported - so a second compile can see the
bodies. It never touches the export itself.

Usage: neutralise_stripped_attribute_arguments.py <roslyn log> <scripts dir> <references dir> <copy dir>
Prints how many arguments were removed; writes the edited files under <copy dir> with the same layout.
"""
import os
import pathlib
import re
import shutil
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import classify_compile_errors as classifier  # noqa: E402


def remove_argument(line, column, member):
    """`[X(a = 1, order = 2)]` with the column on `order` -> `[X(a = 1)]`."""
    start = column - 1
    if not line[start:].startswith(member):
        return None
    depth, end = 0, start
    while end < len(line):
        ch = line[end]
        if ch in "([{":
            depth += 1
        elif ch in ")]}":
            if depth == 0:
                break
            depth -= 1
        elif ch == "," and depth == 0:
            break
        end += 1
    before, after = line[:start], line[end:]
    if after.startswith(","):
        after = after[1:].lstrip()
    else:
        before = re.sub(r",\s*$", "", before)
    return before + after


def main():
    log, scripts, references, copy = sys.argv[1:5]
    wanted = []
    for raw in open(log, encoding="utf-8", errors="replace"):
        match = classifier.ERROR_LINE.match(raw.rstrip("\n"))
        if not match or match.group("code") != "CS0617":
            continue
        named = classifier.NAMED_ARGUMENT.match(match.group("message"))
        attribute = classifier.attribute_at(match.group("file"), match.group("line"), match.group("col"))
        if named and attribute:
            wanted.append((match.group("file"), int(match.group("line")), int(match.group("col")),
                           named.group("member"), attribute))

    queries = set()
    for _, _, _, member, attribute in wanted:
        queries |= {(attribute, member), (attribute, "get_" + member), (attribute, "set_" + member)}
    visibility = classifier.member_visibility(queries, references)

    by_file = {}
    for path, line, column, member, attribute in wanted:
        category, _ = classifier.classify("CS0617", f"'{member}' is not a valid named attribute argument",
                                          set(), True, visibility, attribute)
        if category == classifier.REFERENCE_ERROR:
            by_file.setdefault(path, []).append((line, column, member))

    removed = 0
    for path, edits in by_file.items():
        lines = pathlib.Path(path).read_text(encoding="utf-8", errors="replace").split("\n")
        # Right to left within a line, so an earlier column is still where Roslyn said.
        for line, column, member in sorted(edits, key=lambda e: (e[0], -e[1])):
            edited = remove_argument(lines[line - 1], column, member)
            if edited is not None:
                lines[line - 1] = edited
                removed += 1
        target = pathlib.Path(copy) / os.path.relpath(path, scripts)
        target.parent.mkdir(parents=True, exist_ok=True)
        target.write_text("\n".join(lines), encoding="utf-8")

    print(removed)
    return 0


if __name__ == "__main__":
    sys.exit(main())
