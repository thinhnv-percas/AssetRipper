#!/usr/bin/env python3
"""Which native opcodes the lifter has no rule for, how much of a game they cost, and where.

`NOT_IMPLEMENTED_INSTRUCTION` placeholders name the machine opcode outright - they are the one
placeholder family that needs no inference at all to work on. But a count alone does not say whether
an opcode is worth a rule: two of them being 90% of the family on one fixture and 0% on another is
the ordinary case, because the family is distributed by the instruction selection the compiler used
for that build rather than by the program.

So this reports, per opcode: how many placeholders, in how many methods and assemblies, how many
bytes of native code those methods are, which fixtures see it at all, and - read out of the lifter's
own switch rather than guessed - whether the lifter already has a case for it. An opcode with a case
that still reports unimplemented is a different defect from one with no case.

Usage: instruction_coverage.py <rip output>[:<label>] [more rips...] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

UNIMPLEMENTED = re.compile(r'Not implemented instruction: .*Instruction ([A-Z0-9_]+) not yet implemented')
ADDRESS = re.compile(r'\[Address\(RVA = "0x[0-9A-Fa-f]+"(?:, Offset = "[^"]*")?(?:, VA = "[^"]*")?(?:, Length = "0x([0-9A-Fa-f]+)")?\)\]')
LIFTER_CASE = re.compile(r'case\s+Arm64Mnemonic\.([A-Z0-9_]+)\s*:')

LIFTER = pathlib.Path(__file__).resolve().parents[2] / "Source/External/Cpp2IL.Core/InstructionSets/NewArmV8InstructionSet.cs"


def implemented_mnemonics() -> set[str]:
    if not LIFTER.exists():
        return set()
    return set(LIFTER_CASE.findall(LIFTER.read_text(encoding="utf-8", errors="replace")))


def assembly_of(path: pathlib.Path, root: pathlib.Path) -> str:
    parts = path.relative_to(root).parts
    if "Assembly-CSharp" in parts:
        return "Assembly-CSharp"
    for index, part in enumerate(parts):
        if part == "Scripts" and index + 1 < len(parts):
            return parts[index + 1]
    return "<root>"


def scan(root: pathlib.Path, label: str, rows):
    for path in root.rglob("*.cs"):
        assembly = assembly_of(path, root)
        native = 0
        method = f"{path}#0"
        for line in path.read_text(encoding="utf-8", errors="replace").splitlines():
            stripped = line.lstrip()
            if stripped.startswith("["):
                match = ADDRESS.search(line)
                if match:
                    method = f"{path}#{line}"
                    native = int(match.group(1), 16) if match.group(1) else 0
                continue
            for mnemonic in UNIMPLEMENTED.findall(line):
                rows.append((mnemonic, label, assembly, method, native))


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("rips", nargs="+", help="<rip output>[:<label>]")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    implemented = implemented_mnemonics()
    rows = []
    labels = []
    for entry in arguments.rips:
        path, _, label = entry.partition(":")
        label = label or pathlib.Path(path).name
        labels.append(label)
        scan(pathlib.Path(path), label, rows)

    counts = collections.Counter()
    methods = collections.defaultdict(set)
    assemblies = collections.defaultdict(set)
    fixtures = collections.defaultdict(set)
    native = collections.defaultdict(int)

    for mnemonic, label, assembly, method, size in rows:
        counts[mnemonic] += 1
        if method not in methods[mnemonic]:
            native[mnemonic] += size
        methods[mnemonic].add(method)
        assemblies[mnemonic].add(assembly)
        fixtures[mnemonic].add(label)

    print(f"fixtures: {', '.join(labels)}")
    print(f"lifter cases found in NewArmV8InstructionSet: {len(implemented)}")
    print(f"opcodes with no rule, observed: {len(counts)}  placeholders: {sum(counts.values())}\n")

    header = f"{'opcode':<16}{'count':>7}{'methods':>9}{'asm':>5}{'nativeBytes':>13}  {'lifter case':<12} fixtures"
    print(header)
    print("-" * len(header))
    for mnemonic, count in counts.most_common():
        case = "PRESENT" if mnemonic in implemented else "none"
        print(f"{mnemonic:<16}{count:>7}{len(methods[mnemonic]):>9}{len(assemblies[mnemonic]):>5}"
              f"{native[mnemonic]:>13}  {case:<12} {','.join(sorted(fixtures[mnemonic]))}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "fixtures": labels,
            "lifterCases": sorted(implemented),
            "opcodes": {
                mnemonic: {
                    "count": count,
                    "methods": len(methods[mnemonic]),
                    "assemblies": sorted(assemblies[mnemonic]),
                    "nativeBytes": native[mnemonic],
                    "lifterCase": mnemonic in implemented,
                    "fixtures": sorted(fixtures[mnemonic]),
                }
                for mnemonic, count in counts.most_common()
            },
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
