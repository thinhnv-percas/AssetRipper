#!/usr/bin/env python3
"""Compares a recovery against the source it was built from, method by method, by semantics.

Every other measure in this project asks the recovery about itself: how many placeholders it printed,
how many operations its own IR carries that its C# lost. None of them can say whether what came back
is what the programmer wrote, because none of them has the programmer's text. RunFromZombies ships
its whole Unity project, so here that text exists and is the oracle.

The comparison is semantic, not textual. A decompiler legitimately writes a `for` as a `while`, folds
a comparison into an `if`, drops a cast the type system no longer needs, and renames every local - so
string equality would report every method as wrong. What is compared is the set of operation classes
each side reaches, through the same fingerprint the rest of the harness uses on C#, plus the members
each side names.

Status per method:

  EXACT                   the same operation classes, and the same members named
  SEMANTICALLY_EQUIVALENT every operation class the source reaches, and every member it names
  PARTIAL                 some of them, and something real
  FALLBACK                a body that reaches nothing the source does
  MISMATCH                reaches classes the source does not while missing ones it does
  NOT_AVAILABLE           no recovered method to compare against

Usage: source_oracle.py <source project> <recovered game directory> [--json out.json] [--verbose]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
from recovery_metrics import CLASSES, CALL_CSHARP, SUBSTANTIVE  # noqa: E402

# A method declaration and the brace that opens its body, as either side writes one. Deliberately
# loose about modifiers and generous about the return type: what matters is the name and the arity,
# because those are what pair the two sides.
DECLARATION = re.compile(
    r"^[ \t]*(?:\[[^\]]*\][ \t]*)*"
    r"(?P<modifiers>(?:public|private|protected|internal|static|virtual|override|sealed|abstract|extern|unsafe|async|new|partial|\s)*)"
    r"(?P<returns>[\w<>\[\],.?]+)[ \t]+"
    r"(?P<name>[A-Za-z_]\w*)[ \t]*(?P<generics><[^>(]*>)?[ \t]*\((?P<parameters>[^)]*)\)")

TYPE_DECLARATION = re.compile(r"^[ \t]*(?:\[[^\]]*\][ \t]*)*(?:public|internal|private|protected|static|sealed|abstract|partial|\s)*"
                              r"(?:class|struct|interface|enum)\s+(?P<name>[A-Za-z_]\w*)")

FIELD_DECLARATION = re.compile(r"^[ \t]*(?:\[[^\]]*\][ \t]*)*(?:public|private|protected|internal|static|readonly|const|volatile|\s)*"
                               r"(?P<type>[\w<>\[\],.?]+)[ \t]+(?P<name>[A-Za-z_]\w*)[ \t]*(?:=[^;]*)?;")

# Keywords a declaration regex would otherwise read as a method.
NOT_A_METHOD = {"if", "while", "for", "foreach", "switch", "catch", "lock", "using", "fixed", "return", "new"}

EXACT, EQUIVALENT, PARTIAL, FALLBACK, MISMATCH, ABSENT = (
    "EXACT", "SEMANTICALLY_EQUIVALENT", "PARTIAL", "FALLBACK", "MISMATCH", "NOT_AVAILABLE")
ORDER = [EXACT, EQUIVALENT, PARTIAL, FALLBACK, MISMATCH, ABSENT]


# A comment is not code, and a source file is full of them while a recovered one is not.
LINE_COMMENT = re.compile(r"//[^\n]*")
BLOCK_COMMENT = re.compile(r"/\*.*?\*/", re.DOTALL)

# A generic call has `>` before its parenthesis, which the keyword-guarded call pattern cannot see.
GENERIC_CALL = re.compile(r"\b\w+\s*<[\w\s,.\[\]<>]+>\s*\(")


def code_only(text: str) -> str:
    """The text with its comments removed.

    This oracle reported `Checker.Start` as losing a branch and a loop against a recovery that is
    exact, because the source carries `// condition for spawning new street` and the words `for` and
    `new` in it match the loop and construction patterns. A source file is full of comments and a
    recovered one is not, so fingerprinting them compares prose on one side with code on the other.
    """
    return LINE_COMMENT.sub(" ", BLOCK_COMMENT.sub(" ", text))


def fingerprint(text: str) -> set[str]:
    """The operation classes a piece of C# reaches - the same definition the rest of the harness uses."""
    text = code_only(text)
    found = {name for name, pattern in CLASSES if pattern.search(text)}

    # `GetComponent<Animator>()` is a call, and the shared pattern cannot match it: it requires a word
    # immediately before the parenthesis and a generic call has `>` there. Missing it read the whole
    # of `Checker.Start` as reaching nothing at all.
    if CALL_CSHARP.search(text) or GENERIC_CALL.search(text):
        found.add("CALL")

    return found


def members_named(text: str) -> set[str]:
    """Members reached off something, which is what a field or property access looks like on both sides."""
    # Overlapping, through a lookahead: `a.b.c` is two accesses and a non-overlapping scan sees one
    # and a half. It consumed `a.b`, resumed past `b`, and so found `b.c` on one side and not the
    # other depending on where the line broke - which read as a member the recovery never named.
    return {member for _, member in re.findall(r"(?=(\w+)\.(\w+))", code_only(text)) if not member[0].isupper() or "_" in member}


def bodies(text: str):
    """(type, method name, arity, body) for every method with a body in a C# file."""
    lines = text.splitlines()
    current_type = "<file>"

    for index, line in enumerate(lines):
        type_match = TYPE_DECLARATION.match(line)

        if type_match:
            current_type = type_match["name"]
            continue

        match = DECLARATION.match(line)

        if not match or match["name"] in NOT_A_METHOD or match["returns"] in NOT_A_METHOD:
            continue

        # Find the brace that opens the body; a declaration with a semicolon has none.
        cursor = index
        while cursor < len(lines) and "{" not in lines[cursor]:
            if ";" in lines[cursor]:
                cursor = -1
                break
            cursor += 1

        if cursor < 0 or cursor >= len(lines):
            continue

        depth = 0
        collected = []

        for body_line in lines[cursor:]:
            depth += body_line.count("{") - body_line.count("}")
            collected.append(body_line)
            if depth <= 0:
                break

        parameters = match["parameters"].strip()
        arity = 0 if not parameters else parameters.count(",") + 1
        yield current_type, match["name"], arity, "\n".join(collected)


def fields(text: str) -> set[str]:
    """Field declarations at type scope.

    Depth matters: a local variable declaration reads exactly like a field one, and counting those
    reported `Movement` as declaring 79 fields against the source's 7 - a column that says nothing
    except how long the recovered bodies are. At brace depth 1 the only declarations are the type's
    own.
    """
    found = set()
    depth = 0

    for line in text.splitlines():
        if depth == 1 and (match := FIELD_DECLARATION.match(line)) and match["type"] not in NOT_A_METHOD:
            found.add(match["name"])

        depth += line.count("{") - line.count("}")

    return found


def harvest(root: pathlib.Path, skip: tuple[str, ...] = ()):
    """Every method body in a tree of C#, keyed by (type, name, arity)."""
    found = {}
    declared_fields = collections.defaultdict(set)

    for path in sorted(root.rglob("*.cs")):
        if any(part in skip for part in path.parts):
            continue

        text = path.read_text(encoding="utf-8", errors="replace")

        for type_name, name, arity, body in bodies(text):
            found.setdefault((type_name, name, arity), body)

        for type_name in set(match["name"] for line in text.splitlines() if (match := TYPE_DECLARATION.match(line))):
            declared_fields[type_name] |= fields(text)

    return found, declared_fields


# `new T(...)` in either side's C#, for the construction rule below.
CONSTRUCTION = re.compile(r"\bnew\s+([A-Za-z_][\w.]*)\s*[<(]")

# `default(T)`, which is what a value type's construction reads as once il2cpp has compiled it.
ZEROED = re.compile(r"\bdefault\s*\(\s*([A-Za-z_][\w.]*)\s*\)")


def constructions_accounted_for(source_body: str, recovered_body: str) -> bool:
    """Whether every type the source constructs is constructed in the recovery too.

    A value type has no allocation. `new Vector3(x, y, z)` compiles to zeroing a slot and storing its
    members, so it comes back as `Vector3 v = default(Vector3); v.x = ...` - the same program, and a
    fingerprint that only looks for `new` reports it as a lost NEWOBJ. Seven of the eight methods
    this oracle first reported as not equivalent were exactly that, which made the number wrong in
    the direction that flatters nothing and wastes time: a check too strict is as wrong as one too
    lax, and costs more.

    So a construction is accounted for when the recovery either constructs that type or zeroes it.
    A type the recovery does neither to is a real loss.
    """
    built = set(CONSTRUCTION.findall(code_only(recovered_body))) | set(ZEROED.findall(code_only(recovered_body)))

    for type_name in CONSTRUCTION.findall(code_only(source_body)):
        short = type_name.rsplit(".", 1)[-1]

        if not any(candidate.rsplit(".", 1)[-1] == short for candidate in built):
            return False

    return True


def compare(source_body: str, recovered_body: str) -> tuple[str, list[str], list[str]]:
    source_classes = fingerprint(source_body)
    recovered_classes = fingerprint(recovered_body)

    lost = sorted((source_classes & SUBSTANTIVE) - recovered_classes)

    if "NEWOBJ" in lost and constructions_accounted_for(source_body, recovered_body):
        lost.remove("NEWOBJ")
        recovered_classes = recovered_classes | {"NEWOBJ"}
    gained = sorted(recovered_classes - source_classes)

    source_members = members_named(source_body)
    recovered_members = members_named(recovered_body)
    missing_members = sorted(source_members - recovered_members)

    if not lost and not missing_members and source_classes == recovered_classes:
        return EXACT, lost, missing_members

    if not lost and not missing_members:
        return EQUIVALENT, lost, missing_members

    if lost and not (recovered_classes & SUBSTANTIVE):
        return FALLBACK, lost, missing_members

    if gained and lost:
        return MISMATCH, lost, missing_members

    return PARTIAL, lost, missing_members


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("source", help="the source Unity project")
    parser.add_argument("recovered", help="the game directory inside the rip output")
    parser.add_argument("--json")
    parser.add_argument("--verbose", action="store_true")
    arguments = parser.parse_args()

    source_root = pathlib.Path(arguments.source)
    recovered_root = pathlib.Path(arguments.recovered)

    for root in (source_root, recovered_root):
        if not root.is_dir():
            print(f"NOT_A_DIRECTORY: {root}")
            return 2

    # The source's own scripts only: a Unity project also carries the packages it depends on, and
    # those are not what this recovery was measured on.
    source_methods, source_fields = harvest(source_root / "Assets", skip=("Library", "Packages"))
    recovered_methods, recovered_fields = harvest(recovered_root, skip=("Cpp2ILInjected", "AssetRipperInjected"))

    statuses = collections.Counter()
    findings = []

    for key, source_body in sorted(source_methods.items()):
        type_name, name, arity = key
        recovered_body = recovered_methods.get(key)

        if recovered_body is None:
            statuses[ABSENT] += 1
            findings.append({"type": type_name, "method": name, "arity": arity, "status": ABSENT})
            continue

        status, lost, missing = compare(source_body, recovered_body)
        statuses[status] += 1
        findings.append({
            "type": type_name, "method": name, "arity": arity, "status": status,
            "lost_operation_classes": lost, "members_not_named": missing[:8],
        })

    total = sum(statuses.values())
    equivalent = statuses[EXACT] + statuses[EQUIVALENT]

    print(f"source methods: {total}")
    print(f"types in source: {len(source_fields)}, in recovery: {len(recovered_fields)}\n")

    for status in ORDER:
        share = f"{statuses[status] / total:6.1%}" if total else "     -"
        print(f"{statuses[status]:6d}  {status:<24}{share}")

    print()
    print(f"semantic_equivalence_rate: {equivalent / total:.4f} ({equivalent} of {total})" if total
          else "semantic_equivalence_rate: UNKNOWN (no source methods)")

    # Fields are the other half: a method that reads a field the recovery never declared is a method
    # that cannot be right, and the field count is where that shows first.
    print("\n== fields declared, per type present in both ==")
    shared = sorted(set(source_fields) & set(recovered_fields))
    print(f"{'type':<28}{'source':>8}{'recovered':>11}{'missing':>9}")
    for type_name in shared[:25]:
        missing = source_fields[type_name] - recovered_fields[type_name]
        print(f"{type_name:<28}{len(source_fields[type_name]):>8}{len(recovered_fields[type_name]):>11}{len(missing):>9}")

    if arguments.verbose:
        print("\n== every method that is not EXACT or SEMANTICALLY_EQUIVALENT ==")
        for finding in findings:
            if finding["status"] in (EXACT, EQUIVALENT):
                continue
            print(f"  {finding['type']}.{finding['method']}/{finding['arity']:<3} {finding['status']:<24}"
                  f"lost={','.join(finding.get('lost_operation_classes', [])) or '-'} "
                  f"unnamed={','.join(finding.get('members_not_named', [])[:4]) or '-'}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "source_methods": total,
            "statuses": dict(statuses),
            "semantic_equivalence_rate": (equivalent / total) if total else None,
            "methods": findings,
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
