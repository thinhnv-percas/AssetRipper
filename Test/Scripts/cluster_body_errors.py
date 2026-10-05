#!/usr/bin/env python3
"""Cluster the body-pass Roslyn errors of a recovered assembly by root-cause family.

Input is the file `compile_recovered_scripts.sh` writes with BODY_ERRORS_TO (or ERRORS_TO): one Roslyn
diagnostic per line. Each error is read together with the source text at its position and the next few
lines, because the same compiler message covers producers that want opposite work - `Cannot convert type
'X' to 'nint'` is an interface scan that survived, an array element address, a struct used as its own
address and an unresolved load, and only the expression says which.

A family names the *producer* (the first layer that went wrong), never the message. The family table is
the one place the rules live; every rule is a regular expression over the expression, the message or the
lines that follow, and an error that matches none is OTHER - a measured remainder, not a guess.

    cluster_body_errors.py <errors.txt> <assembly source dir> [--json out.json] [--examples N]
    cluster_body_errors.py --self-test
"""
import json
import os
import re
import sys
from collections import Counter, defaultdict

LINE = re.compile(r'(.*?)\((\d+),(\d+)\): error (CS\d+): (.*)')

# (family, layer, producer, rule). The rule is called with (code, message, expression, context) and the
# first family whose rule answers true wins, so order goes from the most specific shape to the least.
# `layer` is the first pipeline representation the family is wrong in (docs/agent/DECOMPILER_PIPELINE.md).
FAMILIES = [
    ("STRUCT_SELF_FIELD_ADDRESS", "ISIL analysis", "this + k on a value-type receiver, passed as a byref",
     lambda c, m, e, x: "AddByteOffset(ref this" in e or re.search(r"\(\(Async\w*MethodBuilder\*\)", e) is not None
     or re.search(r"Cannot convert type '[\w.]*MethodBuilder' to '[\w.]*MethodBuilder\*'", m) is not None),
    ("INTERFACE_METHOD_DELEGATE", "ISIL analysis", "ldvirtftn over an interface method, compiled as an interface lookup",
     lambda c, m, e, x: c == "CS0149" or re.search(r"new [\w.<>, ]+\(\w+, \(IntPtr\)0\)", e) is not None),
    ("INTERFACE_SCAN_SURVIVOR", "ISIL analysis", "inlined interface offset scan left beside its dispatch",
     lambda c, m, e, x: "(nint)typeof(" in e
     or re.search(r"Il2CppClass<[^>]+>+\)\+(12E|B0|12A|128)\]", x) is not None and re.search(r"\(nint\)\w+;", e) is not None
     or re.search(r"obj\d+ << 4", e) is not None),
    ("INDIRECT_STRUCT_ARGUMENT", "ISIL lifting (ABI)", "AAPCS64 B.4: a composite over 16 bytes passed by reference to a copy",
     lambda c, m, e, x: re.search(r"Cannot convert type '[\w.<>?\[\]]+\*' to '[\w.<>?]+'", m) is not None and "(&" in e),
    ("STRUCT_LOCAL_AS_ADDRESS", "ISIL analysis", "the address of a stack struct typed as the struct",
     lambda c, m, e, x: re.search(r"\(\([\w.<>?, ]+\*\)(\(nint\))?\w+\)->", e) is not None
     or re.search(r"Cannot convert type '([\w.<>]+)' to '\1\*'", m) is not None
     or re.search(r"Cannot convert type '[\w.<>]+\.Enumerator' to 'nint'", m) is not None),
    ("SHARED_GENERIC_PLACEHOLDER", "metadata / type resolution", "a shared-generic stand-in type (Int32Enum, List<object>)",
     lambda c, m, e, x: "Int32Enum" in m or "Int32Enum" in e
     or re.search(r"to 'System\.Collections\.Generic\.(List|Dictionary)<object", m) is not None
     or re.search(r"'(List|Dictionary)<object(, object)?>[\w.]*Enumerator\._", m) is not None),
    ("FRAMEWORK_PRIVATE_MEMBER", "CIL emission (accessor pairing)", "an inlined trivial accessor named by its private field",
     lambda c, m, e, x: (c == "CS0122" and re.search(r"'[\w.<>?, ]+\.(m_\w+|_\w+|hasValue|item)'", m) is not None)
     or (c == "CS1061" and re.search(r"definition for '(m_\w+|_\w+|item)'", m) is not None)),
    ("ARRAY_ELEMENT_ADDRESS", "ISIL analysis", "element address arithmetic not folded into an element access",
     lambda c, m, e, x: re.search(r"Cannot convert type '[\w.<>]+\[\](\[\])?' to '(nint|int)'", m) is not None
     or re.search(r"operands of type '[\w.]+\[\]' and 'int'", m) is not None),
    ("WIDE_IMMEDIATE_STRUCT", "ISIL analysis", "a wide immediate store covering a struct's leading fields",
     lambda c, m, e, x: re.search(r"Cannot convert type 'long' to", m) is not None and re.search(r"\)\d{6,}L", e) is not None),
    ("UNRESOLVED_LOAD_STANDIN", "ISIL analysis (load resolution)", "the native-int zero an unresolved load pushes",
     lambda c, m, e, x: re.search(r"Cannot convert type 'int' to", m) is not None and re.search(r"\([\w.<>, \[\]]+\)0\b", e) is not None),
    ("STRUCT_FIRST_MEMBER", "CIL emission (offset zero)", "a struct where its first member is wanted, or the reverse",
     lambda c, m, e, x: re.search(r"Cannot convert type '[\w.]+' to '(float|int|UnityEngine\.Vector[234])'", m) is not None
     and re.search(r"'(int|float|nint|long|bool|double)' to", m) is None
     or re.search(r"Cannot convert type 'float' to '(UnityEngine\.Vector[234]|[\w.]+)'", m) is not None),
    ("OBJECT_AS_NATIVE_INT", "ISIL analysis (typing)", "a reference used in address arithmetic",
     lambda c, m, e, x: re.search(r"Cannot convert type '[\w.<>]+' to 'nint'", m) is not None
     or re.search(r"Cannot convert type 'nint' to", m) is not None
     or re.search(r"operands of type 'object' and", m) is not None),
    ("FLOAT_USED_AS_INTEGER", "ISIL analysis (typing)", "a local typed float/double that carries integer bits",
     lambda c, m, e, x: re.search(r"operands of type '(float|double)' and '(int|long)'", m) is not None),
    ("STRIPPED_FRAMEWORK_MEMBER", "reference assemblies", "a member IL2CPP stripped from the build",
     lambda c, m, e, x: "'Math' does not contain a definition for 'PI'" in m),
    ("INLINED_STATIC_PROPERTY", "CIL emission (accessor pairing)", "a static property inlined to its private field",
     lambda c, m, e, x: re.search(r"'(Vector[234]|Quaternion|Color)' does not contain a definition for '\w+'", m) is not None),
    ("BASE_CONSTRUCTOR_CALL", "CIL emission", "a constructor call ILSpy could not fold into an initialiser",
     lambda c, m, e, x: "_002Ector" in m or "_002Ector" in e),
    ("UNASSIGNED_LOCAL", "SSA destruction", "a read with no reaching definition",
     lambda c, m, e, x: c == "CS0165"),
]


def read_errors(path, root):
    """Yield (file, line, code, message, expression, context) for every error line in `path`."""
    cache = {}
    for raw in open(path, encoding="utf-8", errors="replace"):
        match = LINE.match(raw.strip())
        if not match:
            continue
        file, line, column, code, message = match.groups()
        if not os.path.exists(file):
            # The body pass compiles a copy in a temporary directory; the file is the same one by name.
            file = os.path.join(root, os.path.basename(file))
        if file not in cache:
            try:
                cache[file] = open(file, encoding="utf-8-sig", errors="replace").read().split("\n")
            except OSError:
                cache[file] = []
        lines = cache[file]
        index = int(line) - 1
        text = lines[index] if 0 <= index < len(lines) else ""
        expression = text.strip()
        context = "\n".join(lines[index:index + 4])
        yield os.path.basename(file), int(line), code, message, expression, context


def classify(code, message, expression, context):
    for family, _, _, rule in FAMILIES:
        if rule(code, message, expression, context):
            return family
    return "OTHER"


def cluster(errors):
    families = defaultdict(list)
    for file, line, code, message, expression, context in errors:
        families[classify(code, message, expression, context)].append((file, line, code, message, expression))
    return families


def report(families, examples=2):
    meta = {family: (layer, producer) for family, layer, producer, _ in FAMILIES}
    meta["OTHER"] = ("-", "matched no rule")
    total = sum(len(v) for v in families.values())
    out = {"total": total, "families": []}
    for family, rows in sorted(families.items(), key=lambda kv: -len(kv[1])):
        codes = Counter(r[2] for r in rows)
        files = Counter(r[0] for r in rows)
        out["families"].append({
            "family": family, "count": len(rows), "layer": meta[family][0], "producer": meta[family][1],
            "codes": dict(codes.most_common()), "files": len(files),
            "examples": [f"{r[0]}:{r[1]} {r[2]} {r[4][:160]}" for r in rows[:examples]],
        })
    return out


SELF_TEST = [
    ("CS0122", "'Unsafe' is inaccessible due to its protection level", "x = (B)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref this, 8));", "", "STRUCT_SELF_FIELD_ADDRESS"),
    ("CS0030", "Cannot convert type 'System.Type' to 'nint'", "nint num3 = (nint)typeof(IDisposable);", "", "INTERFACE_SCAN_SURVIVOR"),
    ("CS0149", "Method name expected", "Action value = new Action(this, method);", "", "INTERFACE_METHOD_DELEGATE"),
    ("CS0030", "Cannot convert type 'UnityEngine.Vector3*' to 'UnityEngine.Ray'", "Physics.Raycast((Ray)(&origin), out hit)", "", "INDIRECT_STRUCT_ARGUMENT"),
    ("CS0030", "Cannot convert type 'ItemData' to 'nint'", "((ItemData*)(nint)itemData)->Type = eItem;", "", "STRUCT_LOCAL_AS_ADDRESS"),
    ("CS0122", "'Rect.m_Width' is inaccessible due to its protection level", "float w = rect.m_Width;", "", "FRAMEWORK_PRIVATE_MEMBER"),
    ("CS0030", "Cannot convert type 'int' to 'UnityEngine.Object'", "string s = ((UnityEngine.Object)0).name;", "", "UNRESOLVED_LOAD_STANDIN"),
    ("CS0030", "Cannot convert type 'T[]' to 'nint'", "object o = (nint)array + 32;", "", "ARRAY_ELEMENT_ADDRESS"),
    ("CS0030", "Cannot convert type 'long' to 'X._003CY_003Ed__1'", "_003CY_003Ed__1 s = (_003CY_003Ed__1)4294967295L;", "", "WIDE_IMMEDIATE_STRUCT"),
    ("CS0030", "Cannot convert type 'Ctl.Settings' to 'float'", "_cooldown = (float)settings;", "", "STRUCT_FIRST_MEMBER"),
    ("CS0999", "nothing like it", "x;", "", "OTHER"),
]


def self_test():
    failures = 0
    for code, message, expression, context, expected in SELF_TEST:
        got = classify(code, message, expression, context)
        ok = got == expected
        failures += not ok
        print(f"{'PASS' if ok else 'FAIL'} {expected:28} got {got}")
    print(f"{len(SELF_TEST) - failures} of {len(SELF_TEST)} pass")
    return 1 if failures else 0


def main(argv):
    if "--self-test" in argv:
        return self_test()
    if len(argv) < 3:
        print(__doc__)
        return 2
    examples = int(argv[argv.index("--examples") + 1]) if "--examples" in argv else 2
    result = report(cluster(read_errors(argv[1], argv[2])), examples)
    if "--json" in argv:
        with open(argv[argv.index("--json") + 1], "w") as handle:
            json.dump(result, handle, indent=1)
    print(f"{result['total']} errors")
    for family in result["families"]:
        codes = ", ".join(f"{k} {v}" for k, v in family["codes"].items())
        print(f"{family['count']:6}  {family['family']:28} [{codes}]  {family['layer']}")
        for example in family["examples"]:
            print(f"          {example}")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
