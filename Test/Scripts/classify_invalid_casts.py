#!/usr/bin/env python3
"""Groups CS0030 (invalid explicit cast) by the KIND of the two types, not by their names.

The compile summary prints one example message per error code, taken with `grep -m1`, and that is
the first occurrence rather than the dominant one: on the test game it prints
"Cannot convert type 'int' to 'TCP2_PlanarReflection'" beside a count of 1125, of which that exact
message is one.  Grouping by the type names is barely better - the tail is hundreds of singletons.
What separates the causes is the kind of each end.

Usage: classify_invalid_casts.py <raw csc log>
"""
import collections
import re
import sys

PATTERN = re.compile(
    r"^(?P<file>[^(]+)\((?P<line>\d+),\d+\): error CS0030: "
    r"Cannot convert type '(?P<src>[^']+)' to '(?P<dst>[^']+)'"
)

PRIMITIVES = {
    "int", "uint", "long", "ulong", "short", "ushort", "byte", "sbyte",
    "float", "double", "decimal", "bool", "char", "nint", "nuint",
    "System.IntPtr", "System.UIntPtr",
}

UNITY_VALUE = {
    "UnityEngine.Vector2", "UnityEngine.Vector3", "UnityEngine.Vector4",
    "UnityEngine.Quaternion", "UnityEngine.Color", "UnityEngine.Color32",
    "UnityEngine.Rect", "UnityEngine.Bounds", "UnityEngine.Matrix4x4",
    "UnityEngine.RaycastHit", "UnityEngine.RaycastHit2D",
}


def kind(name: str) -> str:
    if name.endswith("*"):
        return "POINTER"
    if name.endswith("[]"):
        return "ARRAY"
    if name in PRIMITIVES:
        return "NATIVE_INT" if name in {"nint", "nuint", "System.IntPtr", "System.UIntPtr"} else "PRIMITIVE"
    if name in UNITY_VALUE:
        return "UNITY_VALUE_TYPE"
    if name in {"System.Enum", "System.ValueType", "System.Object"}:
        return "ABSTRACT_BASE"
    if name in {"System.Type"}:
        return "REFLECTION"
    if ".Enumerator" in name or name.startswith("System.Collections"):
        return "COLLECTION"
    return "REFERENCE"


def main():
    rows = []
    with open(sys.argv[1], encoding="utf-8", errors="replace") as handle:
        for line in handle:
            match = PATTERN.match(line.strip())
            if match:
                rows.append((match["src"], match["dst"], match["file"].split("Assembly-CSharp/")[-1]))

    print(f"CS0030 total {len(rows)}\n")

    print("== by kind of each end ==")
    pairs = collections.Counter((kind(s), kind(d)) for s, d, _ in rows)
    for (src, dst), count in pairs.most_common():
        print(f"{count:6d}  {src:<18} -> {dst}")

    print("\n== by exact message, top 12 (the tail is singletons) ==")
    for (src, dst), count in collections.Counter((s, d) for s, d, _ in rows).most_common(12):
        print(f"{count:6d}  {src} -> {dst}")

    distinct = len(collections.Counter((s, d) for s, d, _ in rows))
    print(f"\ndistinct (source, target) pairs: {distinct}")

    print("\n== by file, top 12 ==")
    for path, count in collections.Counter(f for _, _, f in rows).most_common(12):
        print(f"{count:6d}  {path}")

    print("\n== by assembly area ==")
    for area, count in collections.Counter(f.split("/")[0] for _, _, f in rows).most_common(10):
        print(f"{count:6d}  {area}")


if __name__ == "__main__":
    main()
