#!/usr/bin/env python3
"""The producers behind every `object`-declared local a recovered body reads - by native instruction.

Iteration 068. A compile error such as `Cannot convert type 'X' to 'nint'` names an expression; the cause is
whatever produced the value, which is several definitions and one native instruction away. The generator
writes one row per untyped local something reads (`CPP2IL_DUMP_UNTYPED=<file>`, filed from
`Il2CppIlRecoveryOutputFormat.ClassifyUntypedLocal`): the defining ISIL instruction, the native address it was
lifted from and the chain of definitions behind it. This classifies those rows into producer families:

  ENTRY_VALUE              read before anything in the method wrote it
  UNRESOLVED_CALL_ARGUMENT an entry value read only as a raw argument of a call nothing resolved
  RUNTIME_HELPER_RESULT    the return of a call to an address (no managed method)
  MANAGED_CALL_RESULT      the return of a resolved managed method
  UNRESOLVED_LOAD          a value read from memory the field search could not place
  FIELD_ADDRESS            an object plus a constant - the address of a field, kept as arithmetic
  ARRAY_ELEMENT_ADDRESS    an array plus an offset
  SHARED_GENERIC_ALLOCA    `Il2CppClass.stack_slot_size + 15`, the alloca rounding of a fully shared body
  INTERFACE_METADATA       arithmetic on a runtime class pointer
  INTEGER_ARITHMETIC       arithmetic whose operands are untyped or integers
  MERGE                    a local with more than one definition
  OTHER                    none of the above

Usage:
  untyped_producers.py <untyped.tsv> [--assembly Assembly-CSharp] [--errors <bodyerr.txt> --rip <rip dir>]
                       [--json out.json] [--self-test]

With --errors, each OBJECT_AS_NATIVE_INT body error (cluster_body_errors' own rule) is tied to the producers
of untyped locals in the same method, which is as close to the expression as the dump can get.
"""
import argparse
import collections
import json
import os
import re
import sys

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

COLUMNS = ["assembly", "type", "method", "rva", "local", "opcode", "native", "definitions", "first_read", "chain"]

ARRAY = re.compile(r":[\w.`<>, ]+\[\]")
RUNTIME_CLASS = re.compile(r":Il2CppClass<|:RuntimeClassTypeAnalysisContext|:Il2CppMethodInfo")


def family(row):
    chain = row["chain"]
    first = chain.split(" | ")[0]
    definition = first.split("<-", 1)[1] if "<-" in first else ""
    opcode = row["opcode"]

    if row["definitions"] not in ("0", "1"):
        return "MERGE"
    if opcode == "NONE" or definition.startswith("ENTRY") or definition.startswith("PARAMETER"):
        return "UNRESOLVED_CALL_ARGUMENT" if row["first_read"] == "an unresolved call" else "ENTRY_VALUE"
    if opcode in ("Call", "IndirectCall"):
        target = definition[definition.find("(") + 1:].split(";", 1)[0]
        # an address, or a symbol the binary named (`"il2cpp_vm_object_box"` renders as StringLiteral), is no managed method
        runtime = target.startswith("0x") or target.startswith("StringLiteral") or target.startswith('"') or opcode == "IndirectCall"
        return "RUNTIME_HELPER_RESULT" if runtime else "MANAGED_CALL_RESULT"
    if opcode == "Move" and "MemoryOperand" in definition:
        return "UNRESOLVED_LOAD"
    if opcode == "Add":
        if "MemoryOperand,#15" in definition:
            return "SHARED_GENERIC_ALLOCA"
        if RUNTIME_CLASS.search(definition):
            return "INTERFACE_METADATA"
        if ARRAY.search(definition):
            return "ARRAY_ELEMENT_ADDRESS"
        if re.search(r"\((this|v\d+|[A-Za-z_]\w*):[A-Z][\w.`<>+]*,#\d+\)", definition) and "Int32" not in definition.split(",")[0]:
            return "FIELD_ADDRESS"
        if "FieldReference,#" in definition:
            return "FIELD_ADDRESS"
    if opcode in ("Add", "Subtract", "Multiply", "Negate", "ShiftLeft", "ShiftRight", "And", "Or", "Xor"):
        return "INTEGER_ARITHMETIC"
    return "OTHER"


def read(path, assembly):
    rows = []
    with open(path, encoding="utf-8", errors="replace") as handle:
        for line in handle:
            parts = line.rstrip("\n").split("\t")
            if len(parts) != len(COLUMNS):
                continue
            row = dict(zip(COLUMNS, parts))
            if assembly and row["assembly"] != assembly:
                continue
            row["family"] = family(row)
            rows.append(row)
    return rows


METHOD_DECLARATION = re.compile(r"^\s*(?:\[[^\]]*\]\s*)*(?:(?:public|private|protected|internal|static|virtual|override|sealed|"
                                r"abstract|extern|unsafe|new|async)\s+)+[\w<>\[\],.? ]*?\b(?P<name>[\w]+|this)\s*(?:<[^>]*>)?\s*\(")
ACCESSOR = re.compile(r"^\s*(get|set|add|remove)\s*$")


def enclosing_method(lines, index, type_name):
    """The name the dump gives the method containing line `index`: `.ctor`, `get_X` for an accessor, else the name."""
    accessor = None
    for i in range(index, -1, -1):
        text = lines[i]
        found = ACCESSOR.match(text)
        if found and accessor is None:
            accessor = found.group(1)
            continue
        match = METHOD_DECLARATION.match(text)
        if match:
            name = match.group("name")
            return ".ctor" if name == type_name else name
        prop = re.match(r"^\s*(?:public|private|protected|internal|static|override|virtual|\s)+[\w<>\[\],.? ]+\s+(?P<name>\w+)\s*$", text)
        if prop and accessor:
            return f"{accessor}_{prop.group('name')}"
    return None


def tie_errors(rows, errors_path, rip):
    import cluster_body_errors as cbe
    by_method = collections.defaultdict(list)
    for row in rows:
        by_method[(row["type"].split(".")[-1].split("+")[0], row["method"])].append(row)

    # read_errors yields a file's base name; the exporter writes one type per file, so the name is the key
    paths = {}
    for directory, _, names in os.walk(rip):
        if os.sep + "Assembly-CSharp" in directory:
            for name in names:
                paths.setdefault(name, os.path.join(directory, name))

    tied = collections.Counter()
    untied = 0
    examples = {}
    cache = {}
    for file, line, code, message, expression, context in cbe.read_errors(errors_path, rip):
        file = paths.get(file, file)
        if cbe.classify(code, message, expression, context) != "OBJECT_AS_NATIVE_INT":
            continue
        if file not in cache:
            try:
                cache[file] = open(file, encoding="utf-8-sig", errors="replace").read().split("\n")
            except OSError:
                cache[file] = []
        lines = cache[file]
        type_name = os.path.splitext(os.path.basename(file))[0]
        method = enclosing_method(lines, int(line) - 1, type_name) if lines else None
        producers = by_method.get((type_name, method), [])
        families = collections.Counter(p["family"] for p in producers if p["first_read"] != "an unresolved call")
        if not families:
            untied += 1
            continue
        top = families.most_common(1)[0][0]
        tied[top] += 1
        examples.setdefault(top, f"{type_name}.{method}:{line} {expression.strip()[:100]}")
    return tied, untied, examples


SELF_TEST = [
    ({"opcode": "Add", "definitions": "1", "first_read": "Add", "chain": "v74:?<-Add(this:UIManager,#48)@18DFE0C | this:UIManager<-PARAMETER"}, "FIELD_ADDRESS"),
    ({"opcode": "Add", "definitions": "1", "first_read": "And", "chain": "v54:?<-Add(MemoryOperand,#15)@1D92454"}, "SHARED_GENERIC_ALLOCA"),
    ({"opcode": "Add", "definitions": "2", "first_read": "Add", "chain": "v829:?<-Add(v1785:Mesh[],#32)@18D9950x2"}, "MERGE"),
    ({"opcode": "Add", "definitions": "1", "first_read": "Add", "chain": "v829:?<-Add(v1785:Mesh[],#32)@18D9950"}, "ARRAY_ELEMENT_ADDRESS"),
    ({"opcode": "NONE", "definitions": "0", "first_read": "an unresolved call", "chain": "v1:?<-ENTRY"}, "UNRESOLVED_CALL_ARGUMENT"),
    ({"opcode": "NONE", "definitions": "0", "first_read": "Add", "chain": "v1:?<-ENTRY"}, "ENTRY_VALUE"),
    ({"opcode": "Call", "definitions": "1", "first_read": "And", "chain": "v1:?<-Call(0xF7087C;v2:?,#7)@100"}, "RUNTIME_HELPER_RESULT"),
    ({"opcode": "Call", "definitions": "1", "first_read": "And", "chain": "v1:?<-Call(List`1::get_Item;v2:?,#7)@100"}, "MANAGED_CALL_RESULT"),
    ({"opcode": "Call", "definitions": "1", "first_read": "Add",
      "chain": "v567:?<-Call(StringLiteral;TypeAnalysisContext,MemoryOperand,clobbered_X2:?)@18CB298"}, "RUNTIME_HELPER_RESULT"),
    ({"opcode": "Move", "definitions": "1", "first_read": "Subtract", "chain": "v264:?<-Move(MemoryOperand)@18DA87C"}, "UNRESOLVED_LOAD"),
    ({"opcode": "Add", "definitions": "1", "first_read": "Add",
      "chain": "v1446:?<-Add(v1390:Il2CppClass<System.Collections.Generic.IEnumerator`1<X>>,v1445:Int32)@18C93E0"}, "INTERFACE_METADATA"),
]


def self_test():
    failures = 0
    for row, expected in SELF_TEST:
        got = family(row)
        failures += got != expected
        print(f"{'PASS' if got == expected else 'FAIL'} {expected:26} got {got}")
    print(f"{len(SELF_TEST) - failures} of {len(SELF_TEST)} pass")
    return 1 if failures else 0


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("dump", nargs="?")
    parser.add_argument("--assembly", default="Assembly-CSharp")
    parser.add_argument("--errors")
    parser.add_argument("--rip")
    parser.add_argument("--json")
    parser.add_argument("--self-test", action="store_true")
    arguments = parser.parse_args()
    if arguments.self_test:
        return self_test()
    if not arguments.dump:
        parser.error("a dump is required")

    rows = read(arguments.dump, arguments.assembly)
    read_by_code = [r for r in rows if r["first_read"] != "an unresolved call"]
    counts = collections.Counter(r["family"] for r in read_by_code)
    print(f"{len(rows)} untyped locals that something reads ({arguments.assembly or 'all assemblies'}); "
          f"{len(rows) - len(read_by_code)} read only by an unresolved call, which loads no operand")
    for name, count in counts.most_common():
        example = next(r for r in read_by_code if r["family"] == name)
        print(f"{count:6}  {name:26} {example['type'].split('.')[-1]}.{example['method']} @{example['native']}: {example['chain'][:120]}")

    out = {"assembly": arguments.assembly, "rows": len(rows), "families": dict(counts)}
    if arguments.errors and arguments.rip:
        tied, untied, examples = tie_errors(rows, arguments.errors, arguments.rip)
        print(f"\nOBJECT_AS_NATIVE_INT body errors tied to a producer in the same method: {sum(tied.values())}, untied {untied}")
        for name, count in tied.most_common():
            print(f"{count:6}  {name:26} {examples[name]}")
        out["errors_by_producer"] = dict(tied)
        out["errors_untied"] = untied
    if arguments.json:
        with open(arguments.json, "w") as handle:
            json.dump(out, handle, indent=1)
    return 0


if __name__ == "__main__":
    sys.exit(main())
