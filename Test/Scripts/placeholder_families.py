#!/usr/bin/env python3
"""Explains every placeholder in a rip by the family that produced it, not by the text it printed.

`method_recovery_report.py` says how many methods carry placeholders; it does not say what the
placeholders *are*. The two questions want opposite work: one ranks methods, the other ranks causes.
Counting the printed text cannot answer the second, because the text carries the operand - every
`Unmanaged memory load: [v24 @ X29_v1-58]` is its own string - so a naive tally reports thousands of
singletons and no family at all.

So the key is the emission site: each family below is one `instructions.Add(CilOpCodes.Ldstr, ...)`
in `IlGenerator`, and the columns name the generator site, the ISIL operation that reached it, and -
where the text carries it - the native opcode underneath. A family whose native opcode is named is
work in the lifter; one whose ISIL operation is a memory operand is work in type recovery; one that
names a libc import is a limitation of metadata rather than a defect.

Two things the parser has to get right, both learned the hard way in this project:
  * `[NativeSource(Body = "...")]` carries the same diagnostic text inside a string literal, so an
    attribute line must be skipped or the count is roughly double (563 against 303 for one family).
  * Only a few assemblies are recovered; the rest are stubbed by design. The log names which, and
    guessing invented 322 false losses the last time it was guessed.

Usage: placeholder_families.py <rip output> [--log run.log] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

ADDRESS = re.compile(r'\[Address\(RVA = "0x([0-9A-Fa-f]+)"')
# A placeholder reaches the exported source two ways now, and both have to be read or a
# representational change reads as a family disappearing. `NoteDecompilerIssue("m")` is the
# diagnostic; `Il2CppRuntime.Boundary("KIND", "m")` is the runtime compatibility layer, where the
# first argument classifies the boundary and the second is the same message the diagnostic carried.
# The message is what every family here keys on, so it is the group captured in both.
ISSUE = re.compile(
    r'NoteDecompilerIssue\("((?:[^"\\]|\\.)*)"\)'
    r'|Il2CppRuntime\.Boundary\("(?:[^"\\]|\\.)*",\s*"((?:[^"\\]|\\.)*)"\)')


def messages(text: str):
    """Every placeholder message in a body, whichever shape carried it."""
    return [diagnostic or boundary for diagnostic, boundary in ISSUE.findall(text)]


BOUNDARY = re.compile(r'Il2CppRuntime\.Boundary\("([A-Z_]+)(?::((?:[^"\\]|\\.)*))?"')
NATIVE_IMPORT = re.compile(r"^Method not found @[0-9A-Fa-f]+ \(native ([^)]+)\)$")
NOT_IMPLEMENTED = re.compile(r"^Not implemented instruction: .*Instruction ([A-Z0-9_]+) not yet implemented")
MEMORY_BASE = re.compile(r"^Unmanaged memory load: \[[^@]*@ ([A-Za-z0-9_]+)")

# Every prefix the generator can print. Kept here, and imported by `method_recovery_report.py`, so the
# two measures cannot disagree about what a placeholder is: they did, and the per-method one was
# blind to `Indirect call`, `Indirect jump` and `Delegate over an unresolved function pointer` - 732
# placeholders, and with them every method whose only defect was one of those, which read as clean.
MESSAGE_PREFIXES = (
    "Unmanaged memory load",
    "Method not found",
    "Unknown call target",
    "Delegate over an unresolved function pointer",
    "Not implemented instruction",
    "Invalid instruction",
    "Indirect call",
    "Indirect jump",
    "Il2Cpp runtime handle",
    "Stack shift",
    "Unresolved branch target",
)

# family -> (generator site, the ISIL operation that reaches it, what the family means)
SITES = {
    "METHOD_NOT_FOUND": ("IlGenerator.cs:1328", "OpCode.Call / CallVoid, target is an Immediate",
                         "an address with no managed method at it"),
    "NATIVE_IMPORT": ("IlGenerator.cs:1328", "OpCode.Call / CallVoid via a PLT slot",
                      "a libc or C++ runtime import, named from .rela.plt"),
    "UNMANAGED_MEMORY_LOAD": ("IlGenerator.cs:2463", "LoadOperand, a MemoryOperand no field was found for",
                              "a load whose base type or offset could not be placed"),
    "NOT_IMPLEMENTED_INSTRUCTION": ("IlGenerator.cs:1019", "OpCode.NotImplemented",
                                    "the lifter has no rule for this native opcode"),
    "UNKNOWN_CALL_TARGET": ("IlGenerator.cs:1333", "OpCode.Call, target is not an Immediate",
                            "a call whose target operand is a register or a memory read"),
    "UNRESOLVED_DELEGATE": ("IlGenerator.cs:1155", "OpCode.Newobj over a delegate type",
                            "a delegate built over a function pointer nothing resolved"),
    "INDIRECT_CALL": ("IlGenerator.cs:1446", "OpCode.IndirectCall",
                      "a virtual or interface dispatch the passes did not resolve"),
    "INDIRECT_JUMP": ("IlGenerator.cs:1471", "OpCode.IndirectJump",
                      "a computed branch, typically a switch table"),
    "RUNTIME_HANDLE": ("IlGenerator.cs:2450", "LoadOperand, a metadata usage global",
                       "an il2cpp runtime handle with no managed spelling"),
    "STACK_SHIFT": ("IlGenerator.cs:1476", "OpCode.ShiftStack",
                    "stack analysis left a shift behind"),
    "INVALID_INSTRUCTION": ("IlGenerator.cs:1012", "OpCode.Invalid",
                            "the disassembler produced nothing decodable"),
}


def family_of(message: str) -> tuple[str, str]:
    """(family, the sub-key that names the concrete cause within it)."""
    native = NATIVE_IMPORT.match(message)
    if native:
        return "NATIVE_IMPORT", native.group(1)

    if message.startswith("Method not found @"):
        return "METHOD_NOT_FOUND", "(address only)"

    unimplemented = NOT_IMPLEMENTED.match(message)
    if unimplemented:
        return "NOT_IMPLEMENTED_INSTRUCTION", unimplemented.group(1)

    if message.startswith("Unmanaged memory load:"):
        base = MEMORY_BASE.match(message)
        return "UNMANAGED_MEMORY_LOAD", base.group(1) if base else "(unnamed base)"

    if message.startswith("Unknown call target operand:"):
        return "UNKNOWN_CALL_TARGET", message.split(":", 1)[1].strip().split(" ", 1)[0]

    if message.startswith("Delegate over an unresolved function pointer:"):
        return "UNRESOLVED_DELEGATE", message.split(":", 1)[1].strip()

    if message.startswith("Indirect call:"):
        return "INDIRECT_CALL", "(dispatch)"

    if message.startswith("Indirect jump:"):
        return "INDIRECT_JUMP", "(computed branch)"

    if message.startswith("Il2Cpp runtime handle:"):
        return "RUNTIME_HANDLE", message.split(":", 1)[1].strip().split(" ", 1)[0]

    if message.startswith("Stack shift:"):
        return "STACK_SHIFT", "(residual)"

    if message.startswith("Invalid instruction:"):
        return "INVALID_INSTRUCTION", "(undecodable)"

    return "OTHER", message[:60]


def assembly_of(path: pathlib.Path, root: pathlib.Path) -> str:
    parts = path.relative_to(root).parts
    if "Assembly-CSharp" in parts:
        return "Assembly-CSharp"
    for index, part in enumerate(parts):
        if part == "Scripts" and index + 1 < len(parts):
            return parts[index + 1]
    return "<root>"


# The lines the exporter writes once it has finished writing files. A log that has neither is a log
# of a run that is still going, or of one that died - and reading a rip while it is still being
# written is not a measurement of it.
COMPLETION_MARKERS = ("Ripped to", "Finished post-export")


def run_is_complete(log: pathlib.Path | None) -> bool | None:
    """Whether the run this log belongs to finished writing.

    Iteration 050 measured a rip while the export was still running - a watch fired on a line in the
    log rather than on the process - and reported 280 .cs files against 819 and 1845 methods against
    5482. That reads as a catastrophic regression and is a snapshot of a directory being filled in.
    None when there is no log to ask, because "not known" and "not finished" want different words.
    """
    if log is None or not log.exists():
        return None
    text = log.read_text(encoding="utf-8", errors="replace")
    return any(marker in text for marker in COMPLETION_MARKERS)


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--log", help="the run log, which names the assemblies recovery was attempted on")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)

    log = pathlib.Path(arguments.log) if arguments.log else None

    if run_is_complete(log) is False:
        # The same refusal recovery_metrics.py makes, for the same reason: a count from half a rip
        # is worse than no count, because it looks like a count.
        print(f"SCOPE: INCOMPLETE - {log} records no finished export, so this rip is still being written")
        return 2

    attempted = None
    if log is not None and log.exists():
        for line in log.read_text(encoding="utf-8", errors="replace").splitlines():
            if "assemblies will be attempted" in line and "Attempted:" in line:
                attempted = {name.strip() for name in line.split("Attempted:", 1)[1].split(",")}
                break

    counts = collections.Counter()
    methods = collections.defaultdict(set)
    assemblies = collections.defaultdict(set)
    detail = collections.defaultdict(collections.Counter)
    detail_methods = collections.defaultdict(lambda: collections.defaultdict(set))
    total = 0

    for path in root.rglob("*.cs"):
        assembly = assembly_of(path, root)
        if attempted is not None and assembly not in attempted:
            continue

        method_key = f"{path}#0"
        for line in path.read_text(encoding="utf-8", errors="replace").splitlines():
            stripped = line.lstrip()
            if stripped.startswith("["):
                # An attribute line carries the same text inside a string literal.
                address = ADDRESS.search(line)
                if address:
                    method_key = f"{path}#{address.group(1)}"
                continue

            for message in messages(line):
                family, key = family_of(message)
                counts[family] += 1
                methods[family].add(method_key)
                assemblies[family].add(assembly)
                detail[family][key] += 1
                detail_methods[family][key].add(method_key)
                total += 1

    # Scope first, count second, the same order recovery_metrics.py prints them in: what a number
    # covers has to be read before the number, and a reader who takes the first line of each should
    # get the same kind of thing from both.
    if attempted is None:
        print("SCOPE: UNKNOWN - no log given, so assemblies stubbed by design are counted with the rest")
    else:
        print(f"SCOPE: the {len(attempted)} assemblies recovery was attempted on")
    print(f"placeholders: {total}")

    print("\n== by family ==")
    header = f"{'family':<30}{'count':>7}{'share':>7}{'methods':>9}{'asm':>5}  {'generator site':<22} ISIL operation"
    print(header)
    print("-" * len(header))
    for family, count in counts.most_common():
        site, operation, _ = SITES.get(family, ("-", "-", "-"))
        print(f"{family:<30}{count:>7}{100 * count / max(total, 1):>6.1f}%"
              f"{len(methods[family]):>9}{len(assemblies[family]):>5}  {site:<22} {operation}")

    print("\n== what each family means ==")
    for family, _ in counts.most_common():
        print(f"  {family:<30} {SITES.get(family, ('', '', '?'))[2]}")

    print("\n== inside each family, by concrete cause ==")
    for family, _ in counts.most_common():
        print(f"\n  {family}")
        for key, count in detail[family].most_common(12):
            print(f"    {count:>6}  {len(detail_methods[family][key]):>5} methods  {key}")
        remaining = len(detail[family]) - 12
        if remaining > 0:
            print(f"    ... and {remaining} more distinct causes")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "placeholders": total,
            "scope": sorted(attempted) if attempted else None,
            "families": {
                family: {
                    "count": count,
                    "methods": len(methods[family]),
                    "assemblies": sorted(assemblies[family]),
                    "generatorSite": SITES.get(family, ("-", "-", "-"))[0],
                    "isilOperation": SITES.get(family, ("-", "-", "-"))[1],
                    "meaning": SITES.get(family, ("-", "-", "-"))[2],
                    "causes": [
                        {"key": key, "count": n, "methods": len(detail_methods[family][key])}
                        for key, n in detail[family].most_common(40)
                    ],
                }
                for family, count in counts.most_common()
            },
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
