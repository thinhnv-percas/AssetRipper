#!/usr/bin/env python3
"""Assignments to a method parameter whose value is an unresolved load's stand-in.

Iteration 065. Copy propagation substituted `&slot` with `&i` because the slot was a copy of the parameter `i`;
that made `i`'s register an address-taken one, CopyCoalescer merged every version of it into one storage, and
the invoker's method pointer - loaded into the same register later - became `i = 0;` in MMSwap, right before
`list[i]` read it. Every aggregate in the project was blind to it: a placeholder count does not move, a method
status does not move, the file still compiles.

What this counts: a statement `<parameter> = <stand-in>;` where `<parameter>` is one of the enclosing method's own
parameters and the stand-in is what the generator pushes for an unresolved operand (`0`, `default(...)`, `null`)
on the line right after the placeholder that reported it. That shape is a parameter overwritten with nothing,
which no source writes.

    parameter_overwrite_scan.py <rip game dir> [--baseline <rip game dir>] [--json out]
    parameter_overwrite_scan.py --self-test
"""
import json
import pathlib
import re
import sys

SIGNATURE = re.compile(r'^\s*(?:(?:public|private|protected|internal|static|virtual|override|sealed|abstract|extern|unsafe|new|async)\s+)*'
                       r'[\w<>\[\],.?* ]+\s+[\w<>.]+\s*\((?P<params>[^)]*)\)\s*(?:where .*)?$')
PARAM_NAME = re.compile(r'(?:^|\s)([A-Za-z_]\w*)\s*(?:=\s*[^,]+)?$')
STANDIN = re.compile(r'^\s*(?P<name>[A-Za-z_]\w*)\s*=\s*(?:0|null|default\([^)]*\)|default)\s*;\s*$')
PLACEHOLDER = re.compile(r'NoteDecompilerIssue\("Unmanaged memory load|Il2CppRuntime\.Boundary\(')


def parameters(signature_params: str) -> set[str]:
    names = set()
    for part in signature_params.split(","):
        part = part.strip()
        if not part:
            continue
        part = re.sub(r'\[[^\]]*\]\s*', '', part)  # attributes
        match = PARAM_NAME.search(part)
        if match and match.group(1) not in ("this", "ref", "out", "in", "params"):
            names.add(match.group(1))
    return names


def scan_text(text: str):
    found = []
    current: set[str] = set()
    method = ""
    previous = ""
    for number, line in enumerate(text.splitlines(), 1):
        signature = SIGNATURE.match(line)
        if signature and not line.rstrip().endswith(";"):
            current = parameters(signature.group("params"))
            method = line.strip()
        standin = STANDIN.match(line)
        if standin and standin.group("name") in current and PLACEHOLDER.search(previous):
            found.append({"line": number, "parameter": standin.group("name"), "method": method, "statement": line.strip()})
        if line.strip():
            previous = line
    return found


def scan(root: pathlib.Path):
    results = {}
    for path in sorted(root.rglob("*.cs")):
        hits = scan_text(path.read_text(errors="replace"))
        if hits:
            results[str(path.relative_to(root))] = hits
    return results


def self_test() -> int:
    overwritten = '''
		public static void MMSwap<T>(this IList<T> list, int i, int j)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ X0_v14+8]");
			i = 0;
			list[i] = value;
		}
'''
    honest = '''
		public static void MMSwap<T>(this IList<T> list, int i, int j)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ X0_v14+8]");
			int num = 0;
			i = j;
		}
'''
    cases = [
        ("a parameter assigned the stand-in after a placeholder is reported", len(scan_text(overwritten)) == 1),
        ("a local assigned the stand-in, or a parameter assigned a value, is not", len(scan_text(honest)) == 0),
    ]
    failures = 0
    for name, ok in cases:
        failures += not ok
        print(f"{'PASS' if ok else 'FAIL'} {name}")
    print(f"{len(cases) - failures} of {len(cases)} pass")
    return 1 if failures else 0


def main(argv) -> int:
    if "--self-test" in argv:
        return self_test()
    if len(argv) < 2:
        print(__doc__)
        return 2
    after = scan(pathlib.Path(argv[1]))
    report = {"files": len(after), "overwrites": sum(len(v) for v in after.values()), "by_file": after}
    if "--baseline" in argv:
        before = scan(pathlib.Path(argv[argv.index("--baseline") + 1]))
        report["baseline_overwrites"] = sum(len(v) for v in before.values())
        report["new_in_files"] = sorted(set(after) - set(before))
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(report, indent=1))
    print(f"parameter overwrites by a stand-in: {report['overwrites']} in {report['files']} files"
          + (f" (baseline {report['baseline_overwrites']})" if "baseline_overwrites" in report else ""))
    for path, hits in list(after.items())[:20]:
        for hit in hits[:3]:
            print(f"  {path}:{hit['line']}  {hit['statement']}   [{hit['method'][:80]}]")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
