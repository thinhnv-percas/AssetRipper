#!/usr/bin/env python3
"""Compare a game's recovered scripts against the Unity source they were built from.

AssetRipper's IL2Cpp recovery is measured on games that ship their own source, so the
output can be marked rather than estimated. This does the mechanical half of that: it
checks that no member was lost, and counts every diagnostic and every known-bad C#
shape per file, so the reading can start with the files that need it.

    python3 Test/Scripts/audit_recovered_scripts.py \
        --source  <clone of the game's repo>/Assets \
        --output  <rip output>/<GameName>/Assets/Scripts/Assembly-CSharp

The judgement is still a person's. What this gives them is where to look.
"""

import argparse
import json
import os
import re
import sys

# The attributes the recovery injects. They are not part of the comparison.
INJECTED = ("[Token(", "[Address(", "[NativeSource(", "[FieldOffset(", "[CallerCount(")

# Directories that are middleware or Editor-only, so absent from a player build.
NOT_IN_BUILD = ("ThirdParties", "GoogleMobileAds", "/Spine", "Plugins", "/Editor")

# A member declaration, which is enough to answer "is it there at all".
DECLARATION = re.compile(
    r"^\s*(?:public|private|protected|internal)\s"
    r"(?:[\w<>\[\],.?\s]*?\s)?"
    r"(\w+)\s*\("
)

# Placeholders the generator emits where it could not recover something.
DIAGNOSTICS = {
    "unresolved_load": "Unmanaged memory load",
    "method_not_found": "Method not found",
    "runtime_handle": "Il2Cpp runtime handle",
    "not_implemented": "Not implemented instruction",
    "invalid": "Invalid instruction",
}

# C# that does not compile, or that names something the source did not.
SHAPES = {
    # a value used as a native integer, which an untyped local is
    "nint_cast": "(nint)",
    # a ref local assigned by dereferencing an untyped local
    "ref_deref": "ref *(",
    # a base constructor call ILSpy could not fold into an initializer
    "mangled_ctor": "_002Ector",
    # a compiler-generated name the source never wrote
    "mangled_name": "_003C_003E",
    # generic sharing naming one instantiation for every other
    "shared_generic": ")(object)",
    # a private backing field of a framework type
    "backing_field": "._items",
    "backing_size": "._size",
    # an injected check that was not recognised
    "null_reference": "NullReferenceException",
    "out_of_memory": "OutOfMemoryException",
}

# What each measure means for correctness, so the headline number is confirmed defects rather than a
# raw count. A benign one is not hidden - it is still counted and still printed - but it does not get
# to look like a defect, and a change that only moves benign counts is not an improvement.
#
#   REAL_ERROR    the recovery lost something the binary contains
#   SEMANTIC_RISK it reads as valid C# and the meaning is suspect
#   EXPECTED      the recovery is faithful and the shape is a property of what il2cpp did
#   BENIGN        cosmetic: the output says the same thing in a way the source did not
CATEGORIES = {
    "unresolved_load": "REAL_ERROR",
    "method_not_found": "REAL_ERROR",
    "runtime_handle": "REAL_ERROR",
    "not_implemented": "REAL_ERROR",
    "invalid": "REAL_ERROR",
    "type_mismatch": "REAL_ERROR",
    "nint_cast": "REAL_ERROR",
    "ref_deref": "REAL_ERROR",
    "shared_generic": "SEMANTIC_RISK",
    "null_reference": "SEMANTIC_RISK",
    "out_of_memory": "SEMANTIC_RISK",
    "mangled_ctor": "SEMANTIC_RISK",
    # il2cpp inlined a framework member the real assembly does not expose. The export is right and a
    # compiler is right to reject it; see DECOMP-0005 in reports/issues.json.
    "backing_field": "EXPECTED",
    "backing_size": "EXPECTED",
    # a compiler-generated name, which the binary really does contain
    "mangled_name": "BENIGN",
}

TYPE_MISMATCH = re.compile(r"Expected [A-Za-z0-9]+, but got [A-Za-z0-9]+")


def read(path, drop_editor_only=False):
    """The file's lines with the injected attributes removed."""
    lines = []
    inside_editor = 0

    with open(path, encoding="utf-8-sig", errors="replace") as handle:
        for line in handle:
            stripped = line.strip()

            if drop_editor_only:
                if stripped.startswith("#if UNITY_EDITOR"):
                    inside_editor += 1
                    continue
                if stripped.startswith("#endif") and inside_editor:
                    inside_editor -= 1
                    continue
                if inside_editor:
                    continue

            if stripped.startswith(INJECTED):
                continue

            lines.append(line.rstrip("\n"))

    return lines


def declarations(lines):
    found = set()
    for line in lines:
        match = DECLARATION.match(line)
        if match:
            found.add(match.group(1))
    return found


def source_files(root):
    for directory, _, files in os.walk(root):
        if any(part in directory for part in NOT_IN_BUILD):
            continue
        for name in sorted(files):
            if name.endswith(".cs"):
                yield os.path.join(directory, name)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--source", required=True, help="the game's Assets directory")
    parser.add_argument("--output", required=True, help="the recovered Assembly-CSharp directory")
    parser.add_argument("--json", help="write the per-file rows here as well")
    arguments = parser.parse_args()

    sources = list(source_files(arguments.source))

    if not sources:
        sys.exit(f"no source .cs files under {arguments.source}")

    declared = {}
    for path in sources:
        for member in declarations(read(path, drop_editor_only=True)):
            declared.setdefault(member, []).append(os.path.basename(path))

    recovered = set()
    rows = []

    for name in sorted(os.listdir(arguments.output)):
        if not name.endswith(".cs"):
            continue

        lines = read(os.path.join(arguments.output, name))
        body = "\n".join(lines)
        recovered |= declarations(lines)

        row = {"file": name, "lines": len(lines), "type_mismatch": len(TYPE_MISMATCH.findall(body))}
        row.update({key: body.count(text) for key, text in DIAGNOSTICS.items()})
        row.update({key: body.count(text) for key, text in SHAPES.items()})
        row["total"] = sum(row[key] for key in DIAGNOSTICS) + row["type_mismatch"]
        rows.append(row)

    missing = sorted(member for member in declared if member not in recovered)

    print(f"source files in the build: {len(sources)}")
    print(f"members declared in them:  {len(declared)}")
    print(f"present in the recovery:   {len(declared) - len(missing)}")
    print(f"absent:                    {len(missing)}")

    for member in missing:
        print(f"  {member}   ({', '.join(sorted(set(declared[member])))})")

    columns = ["lines", "unresolved_load", "method_not_found", "type_mismatch", "nint_cast", "total"]
    width = max(len(row["file"]) for row in rows)

    print()
    print("  ".join(["file".ljust(width)] + [column[:14].rjust(14) for column in columns]))

    for row in sorted(rows, key=lambda r: -r["total"]):
        print("  ".join([row["file"].ljust(width)] + [str(row[column]).rjust(14) for column in columns]))

    print("  ".join(["TOTAL".ljust(width)]
                    + [str(sum(row[column] for row in rows)).rjust(14) for column in columns]))

    print()
    print("by what each measure means for correctness:")
    for category in ("REAL_ERROR", "SEMANTIC_RISK", "EXPECTED", "BENIGN"):
        measures = [key for key, value in CATEGORIES.items() if value == category]
        subtotal = sum(row[key] for row in rows for key in measures)
        detail = ", ".join(f"{key} {sum(row[key] for row in rows)}"
                           for key in sorted(measures, key=lambda k: -sum(row[k] for row in rows))
                           if sum(row[key] for row in rows) > 0)
        print(f"  {category:14} {subtotal:6}   {detail}")
    print()
    print("  the number to work from is REAL_ERROR; EXPECTED will not go to zero and should not")

    clean = [row["file"] for row in rows if row["total"] == 0]
    print(f"\n{len(clean)} of {len(rows)} files carry no diagnostic at all:")
    print("  " + ", ".join(clean))

    if arguments.json:
        with open(arguments.json, "w", encoding="utf-8") as handle:
            json.dump(rows, handle, indent=1)
        print(f"\nrows written to {arguments.json}")


if __name__ == "__main__":
    main()
