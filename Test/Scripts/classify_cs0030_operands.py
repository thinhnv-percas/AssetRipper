#!/usr/bin/env python3
"""Groups CS0030 by the SHAPE OF THE OPERAND the cast is applied to, read from the source.

The type names in the message are the symptom.  What separates the causes is what is being cast:
a literal zero is the stand-in an unresolved load pushes and says nothing about typing; a local is
a genuine use-site typing failure; an address-of is a pointer reaching a position that wants a
value.  Those three want completely different work and the error text does not distinguish them.

Usage: classify_cs0030_operands.py <raw csc log> [--list SHAPE]
"""
import collections
import re
import sys

HEADER = re.compile(
    r"^(?P<file>[^(]+)\((?P<line>\d+),(?P<col>\d+)\): error CS0030: "
    r"Cannot convert type '(?P<src>[^']+)' to '(?P<dst>[^']+)'"
)

# The column points at the start of the cast expression, so the first balanced group is the type.
CAST = re.compile(r"^\([^()]*\)\s*")


def shape_of(operand: str) -> str:
    if re.match(r"^0(?![0-9A-Za-z_.])", operand):
        return "LITERAL_ZERO_STANDIN"
    if re.match(r"^-?[0-9]", operand):
        return "OTHER_LITERAL"
    if operand.startswith("&"):
        return "ADDRESS_OF"
    if operand.startswith("*"):
        return "DEREFERENCE"
    if operand.startswith("("):
        return "PARENTHESISED"
    if re.match(r"^(default|typeof|new)\b", operand):
        return "DEFAULT_OR_TYPEOF"
    if re.match(r"^[A-Za-z_][A-Za-z0-9_]*\s*\(", operand):
        return "CALL_RESULT"
    if re.match(r"^[A-Za-z_][A-Za-z0-9_.]*\s*[.\[]", operand):
        return "MEMBER_OR_ELEMENT"
    if re.match(r"^[A-Za-z_][A-Za-z0-9_]*", operand):
        return "LOCAL"
    return "OTHER"


def main():
    wanted = sys.argv[3] if len(sys.argv) > 3 and sys.argv[2] == "--list" else None
    sources: dict[str, list[str]] = {}
    shapes = collections.Counter()
    examples: dict[str, str] = {}
    listed: list[str] = []

    with open(sys.argv[1], encoding="utf-8", errors="replace") as handle:
        for raw in handle:
            match = HEADER.match(raw.strip())
            if not match:
                continue

            path = match["file"]
            if path not in sources:
                try:
                    with open(path, encoding="utf-8", errors="replace") as source:
                        sources[path] = source.read().splitlines()
                except OSError:
                    sources[path] = []

            lines = sources[path]
            index = int(match["line"]) - 1
            text = lines[index] if 0 <= index < len(lines) else ""
            tail = text[int(match["col"]) - 1:]
            operand = CAST.sub("", tail, count=1)

            shape = shape_of(operand)
            shapes[shape] += 1
            short = f"{path.split('Assembly-CSharp/')[-1]}:{match['line']}  {text.strip()[:110]}"
            examples.setdefault(shape, short)
            if shape == wanted:
                listed.append(short)

    total = sum(shapes.values())
    print(f"CS0030 by the shape of the operand cast (total {total})\n")
    for shape, count in shapes.most_common():
        print(f"{count:6d}  {shape:<22} {100 * count / total:5.1f}%")
        print(f"        e.g. {examples[shape]}")

    for line in listed[:40]:
        print("  " + line)


if __name__ == "__main__":
    main()
