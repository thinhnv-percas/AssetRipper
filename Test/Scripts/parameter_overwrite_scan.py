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

# A declaration: modifiers, an optional return type (a constructor has none), a name, a parameter list.
# Iteration 066: `else if (x == null)` matched as "type `else`, name `if`" and turned a local test into a
# signature, so the statement after it read as a parameter write. A name or a leading word that is a
# statement keyword is never a declaration.
SIGNATURE = re.compile(r'^\s*(?:(?:public|private|protected|internal|static|virtual|override|sealed|abstract|extern|unsafe|new|async|readonly)\s+)*'
                       r'(?:(?P<type>[\w<>\[\],.?* ]+?)\s+)?(?P<name>[\w<>.]+)\s*\((?P<params>[^)]*)\)\s*(?:where .*|:\s*(?:base|this)\(.*\))?$')
STATEMENT_KEYWORDS = {"if", "else", "for", "foreach", "while", "do", "switch", "case", "catch", "using", "lock", "return",
                      "throw", "fixed", "checked", "unchecked", "yield", "await", "typeof", "sizeof", "nameof", "default",
                      "new", "when", "get", "set", "var", "goto"}
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


def is_declaration(match) -> bool:
    """A signature-shaped line is a declaration only when neither its name nor any word before it is a statement keyword,
    and a typeless one is a constructor (its name has no generic arguments and starts upper-case)."""
    name = match.group("name").split(".")[-1]
    words = (match.group("type") or "").split()
    if name in STATEMENT_KEYWORDS or any(word in STATEMENT_KEYWORDS for word in words):
        return False
    if not words:
        return name[:1].isupper() and "<" not in name
    return True


def scan_text(text: str):
    found = []
    current: set[str] = set()
    method = ""
    previous = ""
    for number, line in enumerate(text.splitlines(), 1):
        signature = SIGNATURE.match(line)
        if signature and not line.rstrip().endswith(";") and is_declaration(signature):
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
    def declares(line):
        match = SIGNATURE.match(line)
        return bool(match) and not line.rstrip().endswith(";") and is_declaration(match)

    def overwrite_after(header):
        return len(scan_text(header + """
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X0+8]");
			shellMeshRenderer = null;
		}
"""))

    cases = [
        ("a parameter assigned the stand-in after a placeholder is reported", len(scan_text(overwritten)) == 1),
        ("a local assigned the stand-in, or a parameter assigned a value, is not", len(scan_text(honest)) == 0),
        ("`if (...)` is not a declaration", not declares("\t\t\tif (shellMeshRenderer == null)")),
        ("`else if (...)` is not a declaration (iteration 065's false positive)", not declares("\t\t\telse if (shellMeshRenderer == null)")),
        ("`for (...)` is not a declaration", not declares("\t\t\tfor (int i = 0; i < n; i++)")),
        ("`while (...)` is not a declaration", not declares("\t\t\twhile (enumerator.MoveNext())")),
        ("`switch (...)` is not a declaration", not declares("\t\t\tswitch (state)")),
        ("a local declaration is not a declaration", not declares("\t\t\tint x = Foo(a, b);")),
        ("a lambda is not a declaration", not declares("\t\t\tAction a = () => Foo(shellMeshRenderer);")),
        ("a method declaration is one", declares("\t\tpublic void Build(MeshRenderer shellMeshRenderer)")),
        ("a constructor is one", declares("\t\tpublic RayfireShell(MeshRenderer shellMeshRenderer)")),
        ("a write after `else if` inside a method whose parameter it is not reports nothing",
         overwrite_after("\t\tpublic void Build(int other)\n\t\t{\n\t\t\telse if (shellMeshRenderer == null)") == 0),
        ("a constructor's parameter overwritten by a stand-in is reported",
         overwrite_after("\t\tpublic RayfireShell(MeshRenderer shellMeshRenderer)") == 1),
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
