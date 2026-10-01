#!/usr/bin/env python3
"""Classifies every `nint` cast in a recovered project by what produced the value.

`NATIVE_INT_CAST` is the largest compile-failure cluster on three of the four fixtures, and the error
text says nothing about the cause: `Cannot convert type 'X' to 'nint'` is the same message whether the
value is a pointer the machine really had, a handle, a reference the typing lost, or a metadata address.
Those want opposite work, so the cluster has to be split by the *producer* before any of it is worth
touching.

The producer is read from the recovered C# rather than from the IR, because that is where the cast is
and because the IR rendering of the same statement is one operand further from the reader. Each cast is
attributed to the shape of the expression being cast:

  POINTER            `(nint)x + n` / `(nint)x` where x is already an address computed in the method
  ARRAY              the operand is an array - an element address the fold did not reach
  OBJECT_REFERENCE   the operand is a reference type, so the cast is the typing giving up
  METADATA_POINTER   the operand is `typeof(T)` or a runtime handle
  FIELD_ADDRESS      `(nint)this + n`, the address of a field rather than the field
  HANDLE             an IntPtr-typed operand, where the cast is a no-op the decompiler wrote out
  ENUM               an enum operand
  INTEGER            an integer operand, so the cast is a widening the machine really did
  NATIVE_RETURN      the operand is the result of an unresolved call
  UNKNOWN            none of the above

Usage: cluster_native_int_casts.py <recovered game directory> [--json out.json] [--markdown out.md]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

CAST = re.compile(r"\(nint\)(?P<operand>[A-Za-z_][\w.]*(?:\[[^\]]*\])?|\([^()]*\))")

# What the operand's declaration says, looked up in the same method.
DECLARATION = re.compile(r"^\s*(?P<type>[\w<>\[\],.?]+)\s+(?P<name>[A-Za-z_]\w*)\s*=")

REFERENCE_HINT = re.compile(r"^(string|object|[A-Z])")
ARRAY_HINT = re.compile(r"\[\]$")
INTEGER_TYPES = {"int", "uint", "long", "ulong", "short", "ushort", "byte", "sbyte", "char", "bool",
                 "nint", "nuint", "System.Int32", "System.Int64"}

POINTER, ARRAY, OBJECT_REFERENCE, METADATA_POINTER, FIELD_ADDRESS = (
    "POINTER", "ARRAY", "OBJECT_REFERENCE", "METADATA_POINTER", "FIELD_ADDRESS")
HANDLE, ENUM, INTEGER, NATIVE_RETURN, UNKNOWN = (
    "HANDLE", "ENUM", "INTEGER", "NATIVE_RETURN", "UNKNOWN")
ORDER = [POINTER, ARRAY, FIELD_ADDRESS, OBJECT_REFERENCE, METADATA_POINTER, HANDLE, ENUM, INTEGER,
         NATIVE_RETURN, UNKNOWN]


def declarations(lines):
    """{local name: declared type} for a whole file, which is enough: the exporter does not reuse a
    local's name for a different type in one file."""
    found = {}
    for line in lines:
        if (match := DECLARATION.match(line)) is not None:
            found.setdefault(match.group("name"), match.group("type"))
    return found


def producer_of(operand, declared, previous):
    """The kind of value being cast, from the operand and the statement that defined it."""
    operand = operand.strip()

    if operand.startswith("typeof(") or "RuntimeTypeHandle" in operand or "RuntimeMethodHandle" in operand:
        return METADATA_POINTER
    if operand in ("this",) or operand.startswith("this."):
        return FIELD_ADDRESS
    if operand.endswith("]"):
        return ARRAY

    root = operand.split(".", 1)[0].strip("()")
    kind = declared.get(root)

    if kind is None:
        return UNKNOWN
    if ARRAY_HINT.search(kind):
        return ARRAY
    if kind in ("IntPtr", "UIntPtr", "System.IntPtr"):
        return HANDLE
    if kind in INTEGER_TYPES:
        # An integer-typed local that was itself defined by address arithmetic is a pointer the
        # typing happened to call an integer; the defining statement is what separates them.
        return POINTER if previous.get(root, "").find("(nint)") >= 0 else INTEGER
    if kind == "object":
        return POINTER if previous.get(root, "").find("(nint)") >= 0 else OBJECT_REFERENCE
    if kind.endswith("Enum") or kind.startswith("Enum"):
        return ENUM
    if REFERENCE_HINT.match(kind):
        return OBJECT_REFERENCE
    return UNKNOWN


# Iteration 064 (brief §5): the producer of an OBJECT_REFERENCE cast's value, followed through the
# method's own assignments. The cast is where the typing gave up; the producer is where to fix it.
RESOLVED_PRODUCERS = ("FIELD", "PARAMETER", "ALLOCATION", "CALL_RESULT", "TYPE_CHECK", "CONSTANT", "ARRAY_ELEMENT", "THIS")
UNRESOLVED_PRODUCERS = ("UNRESOLVED_LOAD_STANDIN", "ENTRY_VALUE", "UNKNOWN")
SIGNATURE = re.compile(r"^\s*(?:public|private|protected|internal|static|unsafe|override|virtual|new|sealed|abstract|extern|\s)+[\w<>\[\],.? ]+\s+[\w.<>]+\s*\((?P<params>[^)]*)\)")
IDENTIFIER = re.compile(r"^[A-Za-z_]\w*$")


def producer_kind(expression, name_of_param):
    expression = expression.strip().rstrip(";").strip()
    while expression.startswith("(") and expression.endswith(")") and expression.count("(") == expression.count(")"):
        expression = expression[1:-1].strip()
    cast = re.match(r"^\((?:[\w.<>\[\],? ]+)\)\s*(?P<inner>.+)$", expression)
    if cast:
        return None, cast.group("inner")
    if expression.startswith("default("):
        return "UNRESOLVED_LOAD_STANDIN", None
    if expression in ("null", "true", "false") or re.match(r"^-?[\d.]+[fLuU]*$", expression) or expression.startswith('"'):
        return "CONSTANT", None
    if expression.startswith("new "):
        return "ALLOCATION", None
    if " as " in expression or " is " in expression:
        return "TYPE_CHECK", None
    if expression == "this":
        return "THIS", None
    if expression.endswith(")") and "(" in expression:
        return "CALL_RESULT", None
    if expression.endswith("]"):
        return "ARRAY_ELEMENT", None
    if "." in expression and IDENTIFIER.match(expression.rsplit(".", 1)[-1]):
        return "FIELD", None
    if IDENTIFIER.match(expression):
        return ("PARAMETER", None) if name_of_param(expression) else (None, expression)
    return "UNKNOWN", None


def trace_producer(name, at, lines, depth=0):
    """Follow `name` back to the statement that produced it, inside the method that contains line `at`."""
    if depth > 8:
        return "UNKNOWN"
    start = at
    params = set()
    while start > 0:
        start -= 1
        signature = SIGNATURE.match(lines[start])
        if signature:
            params = {p.strip().split()[-1] for p in signature.group("params").split(",") if p.strip()}
            break
    assignment = re.compile(r"(?:^|[\s(])" + re.escape(name) + r"\s*=\s*(?P<value>[^=].*?);\s*$")
    for index in range(at - 1, start, -1):
        match = assignment.search(lines[index])
        if match:
            kind, follow = producer_kind(match.group("value"), params.__contains__)
            while kind is None and follow is not None and not IDENTIFIER.match(follow):
                kind, follow = producer_kind(follow, params.__contains__)
            if kind is not None:
                return kind
            return trace_producer(follow, index, lines, depth + 1)
    return "PARAMETER" if name in params else "ENTRY_VALUE"


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--json")
    parser.add_argument("--markdown")
    parser.add_argument("--name")
    parser.add_argument("--trace", action="store_true", help="follow each OBJECT_REFERENCE cast to its producer")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    if not root.is_dir():
        print(f"NOT_A_DIRECTORY: {root}")
        return 2

    counts = collections.Counter()
    producers = collections.Counter()
    files = collections.defaultdict(set)
    samples = collections.defaultdict(list)
    total = 0

    for path in sorted(root.rglob("*.cs")):
        lines = [line for line in path.read_text(encoding="utf-8", errors="replace").splitlines()
                 if "NativeSource(Body" not in line]
        declared = declarations(lines)
        previous = {}

        for number, line in enumerate(lines):
            if (match := DECLARATION.match(line)) is not None:
                previous[match.group("name")] = line

            for cast in CAST.finditer(line):
                kind = producer_of(cast.group("operand"), declared, previous)
                if arguments.trace and kind == OBJECT_REFERENCE:
                    root_name = cast.group("operand").strip("()").split(".", 1)[0]
                    producers[trace_producer(root_name, number, lines)] += 1
                counts[kind] += 1
                total += 1
                files[kind].add(str(path.relative_to(root)))
                if len(samples[kind]) < 3:
                    samples[kind].append(line.strip()[:110])

    report = {
        "fixture": arguments.name or root.name,
        "total": total,
        "producers": {kind: {"casts": counts[kind], "files": len(files[kind]),
                             "samples": samples[kind]}
                      for kind in ORDER if counts[kind]},
    }

    print(f"{report['fixture']}: {total} nint casts")
    for kind in ORDER:
        if counts[kind]:
            share = counts[kind] / total if total else 0
            print(f"  {kind:<18} {counts[kind]:6d}  {share:5.1%}  {len(files[kind])} files")
            print(f"                     {samples[kind][0]}")

    if arguments.trace:
        traced = sum(producers.values())
        resolved = sum(producers[k] for k in RESOLVED_PRODUCERS)
        report["object_reference_producers"] = dict(producers.most_common())
        report["resolved_producer_rate"] = round(resolved / traced, 4) if traced else None
        print(f"  OBJECT_REFERENCE producers: {json.dumps(dict(producers.most_common()))}")
        print(f"  resolved_producer_rate {report['resolved_producer_rate']} ({resolved} of {traced})")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))
    if arguments.markdown:
        rows = "\n".join(
            f"| `{kind}` | {counts[kind]} | {len(files[kind])} | `{samples[kind][0]}` |"
            for kind in ORDER if counts[kind])
        pathlib.Path(arguments.markdown).write_text(
            f"# `nint` cast theo producer — {report['fixture']}\n\n"
            f"{total} cast, phân loại theo hình dạng của giá trị bị cast.\n\n"
            "| producer | cast | file | ví dụ |\n|---|---|---|---|\n" + rows + "\n")
    return 0


if __name__ == "__main__":
    sys.exit(main())
