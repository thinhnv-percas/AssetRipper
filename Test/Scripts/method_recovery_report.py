#!/usr/bin/env python3
"""Scores every recovered method by what came back, not by how many placeholders the rip printed.

Every existing measure is a total over an assembly: unresolved loads, Roslyn errors, diagnostics.
None answers the question the project is actually judged on - *how many methods came back with their
behaviour intact* - and a total cannot, because one method with two hundred placeholders and two
hundred methods with one each produce the same number.

The evidence is in the export itself. Each method carries `[Address(RVA, Length)]`, so how much
native code it was is known; the body is beside it, so what came back is known too. A method whose
native code is 8 bytes and whose body is one statement is finished; one whose native code is 600
bytes and whose body is empty is not, and no aggregate says so.

Usage: method_recovery_report.py <rip output> [--assembly NAME] [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

ADDRESS = re.compile(r'\[Address\(RVA = "0x([0-9A-Fa-f]+)"(?:, Offset = "[^"]*")?(?:, VA = "[^"]*")?(?:, Length = "0x([0-9A-Fa-f]+)")?\)\]')
# The families are defined once, in placeholder_families.py, and imported rather than restated. The
# restated copy that used to sit here named "Unresolved delegate", which the generator never prints,
# and omitted `Indirect call` and `Indirect jump` outright: 732 placeholders invisible, and every
# method whose only defect was one of them scored RECOVERED_CLEAN.
sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
from placeholder_families import MESSAGE_PREFIXES  # noqa: E402

DIAGNOSTIC = re.compile('"(?:' + "|".join(re.escape(prefix) for prefix in MESSAGE_PREFIXES) + ')')
GENERATOR_FAILURE = re.compile(r'throw new \w*Exception\("(?:Decompil|Object reference|Index was|The given key)')
UNTYPED_LOCAL = re.compile(r'\bobject \w+(?:\s*=|;)')


def bodies(text: str):
    """(nativeLength, bodyText) for each method that declares where it came from."""
    lines = text.splitlines()
    for index, line in enumerate(lines):
        match = ADDRESS.search(line)
        if not match or match.group(2) is None:
            continue

        native = int(match.group(2), 16)

        # The body is the next brace-balanced block. Attributes and the signature sit between - and an
        # attribute line has to be skipped rather than counted, because `[NativeSource(Body = "...")]`
        # carries braces inside a string literal. Counting those closed the block before it opened and
        # reported 366 methods as having lost their body when every one of them had a body.
        depth = 0
        started = False
        collected = []
        for following in lines[index + 1:index + 4000]:
            stripped = following.lstrip()
            if stripped.startswith("["):
                continue

            collected.append(following)
            depth += following.count("{") - following.count("}")
            if "{" in following:
                started = True
            if started and depth <= 0:
                break

        yield native, "\n".join(collected)


def classify(native: int, body: str) -> tuple[str, int, int]:
    """(verdict, diagnostics, untyped locals)."""
    diagnostics = len(DIAGNOSTIC.findall(body))
    untyped = len(UNTYPED_LOCAL.findall(body))

    if GENERATOR_FAILURE.search(body):
        return "FAILED", diagnostics, untyped

    # Statements, ignoring the braces and the signature line.
    statements = sum(
        1 for line in body.splitlines()
        if line.strip() and not line.strip().startswith(("{", "}", "//", "[", "get", "set", "add", "remove"))
    )

    if statements == 0:
        # A method whose native code is a bare `ret` legitimately has no body; anything longer does.
        return ("EMPTY_BY_DESIGN" if native <= 8 else "EMPTY"), diagnostics, untyped

    if diagnostics:
        return "PARTIAL", diagnostics, untyped

    return ("RECOVERED_CLEAN" if untyped == 0 else "RECOVERED_UNTYPED"), diagnostics, untyped


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--assembly")
    parser.add_argument("--log", help="the run log, which names the assemblies recovery was attempted on")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    scripts = root.rglob("*.cs")

    # Only a few assemblies are recovered; the rest are stubbed by design and every method in them is
    # legitimately empty. Scoring those as lost bodies reported 322 losses where there were none - the
    # same "absent read as broken" that has now cost three measurements in this project. The log names
    # which is which, so it is read rather than guessed; without it the scope is stated as unknown.
    attempted = None
    if arguments.log:
        for line in pathlib.Path(arguments.log).read_text(encoding="utf-8", errors="replace").splitlines():
            if "assemblies will be attempted" in line and "Attempted:" in line:
                attempted = {name.strip() for name in line.split("Attempted:", 1)[1].split(",")}
                break

    verdicts = collections.Counter()
    diagnostics_by_verdict = collections.Counter()
    worst = []
    stubbed_assemblies = set()
    native_total = 0
    per_assembly = collections.defaultdict(collections.Counter)

    for path in scripts:
        parts = path.parts
        assembly = ""
        if "Assembly-CSharp" in parts:
            assembly = "Assembly-CSharp"
        else:
            for index, part in enumerate(parts):
                if part == "Scripts" and index + 1 < len(parts):
                    assembly = parts[index + 1]
                    break

        if arguments.assembly and assembly != arguments.assembly:
            continue

        if attempted is not None and assembly not in attempted:
            stubbed_assemblies.add(assembly)
            continue

        text = path.read_text(encoding="utf-8", errors="replace")
        for native, body in bodies(text):
            verdict, diagnostics, untyped = classify(native, body)
            verdicts[verdict] += 1
            per_assembly[assembly][verdict] += 1
            diagnostics_by_verdict[verdict] += diagnostics
            native_total += native
            if diagnostics or verdict in ("EMPTY", "FAILED"):
                worst.append((diagnostics, native, verdict, str(path.relative_to(root))))

    total = sum(verdicts.values())
    if attempted is None:
        print("SCOPE: UNKNOWN - no log given, so assemblies stubbed by design are counted with the rest")
    else:
        print(f"SCOPE: the {len(attempted)} assemblies recovery was attempted on; "
              f"{len(stubbed_assemblies)} stubbed assemblies excluded")
    print(f"methods with a recorded native address: {total}")
    print(f"native code accounted for: {native_total} bytes\n")

    print("== by verdict ==")
    for verdict, count in verdicts.most_common():
        share = 100 * count / max(total, 1)
        print(f"{count:6d}  {verdict:<18} {share:5.1f}%   diagnostics {diagnostics_by_verdict[verdict]}")

    recovered = verdicts["RECOVERED_CLEAN"] + verdicts["RECOVERED_UNTYPED"] + verdicts["EMPTY_BY_DESIGN"]
    print(f"\nmethods with no placeholder in the body: {recovered} of {total} "
          f"({100 * recovered / max(total, 1):.1f}%)")
    print(f"methods that lost their body entirely:   {verdicts['EMPTY'] + verdicts['FAILED']}")

    print("\n== worst methods by placeholder count ==")
    for diagnostics, native, verdict, path in sorted(worst, reverse=True)[:12]:
        print(f"{diagnostics:5d} placeholders  {native:6d} bytes native  {verdict:<16} {path}")

    if arguments.assembly is None:
        print("\n== by assembly, methods with no placeholder ==")
        rows = []
        for assembly, counts in per_assembly.items():
            subtotal = sum(counts.values())
            clean = counts["RECOVERED_CLEAN"] + counts["RECOVERED_UNTYPED"] + counts["EMPTY_BY_DESIGN"]
            rows.append((subtotal, assembly, clean))
        for subtotal, assembly, clean in sorted(rows, reverse=True)[:12]:
            print(f"{clean:6d} / {subtotal:<6d} {100 * clean / max(subtotal, 1):5.1f}%  {assembly or '<root>'}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "methods": total,
            "nativeBytes": native_total,
            "verdicts": dict(verdicts),
            "diagnosticsByVerdict": dict(diagnostics_by_verdict),
            "byAssembly": {assembly: dict(counts) for assembly, counts in per_assembly.items()},
            "worst": [
                {"diagnostics": d, "nativeBytes": n, "verdict": v, "file": f}
                for d, n, v, f in sorted(worst, reverse=True)[:50]
            ],
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
