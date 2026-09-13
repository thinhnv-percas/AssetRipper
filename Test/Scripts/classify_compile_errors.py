#!/usr/bin/env python3
"""Classify a Roslyn log's errors by cause, so a recovery number is not confused with a setup one.

    classify_compile_errors.py <csc log> <scripts dir> <references dir> [--json <path>]

A count of compiler errors is only a measurement of the recovery if the errors are the recovery's.
Four causes produce them and they want opposite work:

  TOOLCHAIN_ERROR   the compiler could not read one of its inputs; nothing was measured
  ROSLYN_ERROR      the compiler itself malfunctioned
  REFERENCE_ERROR   the export names a member the *real* runtime has and the assemblies we compile
                    against do not - IL2CPP strips what the build never called, so the stub is
                    missing it even though the export is right (Math.PI, Quaternion.Euler(Vector3))
  DECOMPILER_ERROR  the export is not valid C#, or reaches a member no compiler can reach

Anything the evidence does not separate is UNCLASSIFIED and is reported as such. It is never folded
into a neighbour: a wrong category costs every decision downstream, an honest unknown costs one row.

The evidence, and its limits.

The exporter writes one type per file named after the type, so the set of .cs basenames under the
assembly's script directory is the set of types that assembly declares. A diagnostic about a type
outside that set is about a referenced assembly.

Whether a *foreign* type's member is absent because IL2CPP stripped it or because it is private
cannot be read off the log: C# reports a private member of a base type as "does not contain a
definition", the same text it uses for a member that is not there. A string-heap probe does not
settle it either - the recovered assemblies are themselves in the reference set and their memberrefs
carry exactly the names the export names, so every such name is "present" whatever its declaring
assembly holds. The metadata tables do carry the visibility flags, so Test/Tools/MemberVisibility
answers it; build that tool and the family is classified, and where it is not built the family stays
UNCLASSIFIED rather than being guessed. It matches on simple type names, so two types of one name in
different assemblies answer as one - which can only turn an ABSENT into a PRESENT, the direction that
keeps a recovery defect visible rather than hiding one.

The one reference-set fact that is readable here is completeness: if a reference could not be loaded,
or there are none, then every lookup failure downstream is the reference set's and not the export's.
"""

import json
import os
import re
import shutil
import subprocess
import sys
from collections import Counter, defaultdict

DECOMPILER_ERROR = "DECOMPILER_ERROR"
REFERENCE_ERROR = "REFERENCE_ERROR"
ROSLYN_ERROR = "ROSLYN_ERROR"
TOOLCHAIN_ERROR = "TOOLCHAIN_ERROR"
UNCLASSIFIED = "UNCLASSIFIED"

# An input the compiler could not read. Nothing downstream of one of these was measured at all.
TOOLCHAIN_CODES = {"CS0006", "CS0009", "CS0016", "CS1548", "CS1566", "CS2001", "CS2008"}

# The compiler reporting on itself.
ROSLYN_CODES = {"CS0583"}
ROSLYN_MARKERS = ("internal error", "Unexpected error writing", "error CS8078")

# A name lookup that failed: which cause it has depends on where the name lives, so these are the
# only codes that need evidence rather than a table.
LOOKUP_CODES = {"CS0117", "CS0122", "CS0234", "CS0246", "CS1061", "CS1501", "CS1729", "CS7036"}

# The compiler prints a diagnostic with C#'s keyword for a type; the metadata carries the CLR name.
# A closed list, not a heuristic: these are every alias the language has.
KEYWORD_ALIASES = {
    "bool": "Boolean", "byte": "Byte", "sbyte": "SByte", "char": "Char", "decimal": "Decimal",
    "double": "Double", "float": "Single", "int": "Int32", "uint": "UInt32", "long": "Int64",
    "ulong": "UInt64", "short": "Int16", "ushort": "UInt16", "object": "Object", "string": "String",
    "nint": "IntPtr", "nuint": "UIntPtr", "void": "Void",
}

# A decompiler renders a name it cannot spell with its escape of the character's code point.
MANGLED = re.compile(r"_00[0-9A-Fa-f]{2}")

ERROR_LINE = re.compile(r"^(?P<file>.*?)\((?P<line>\d+),(?P<col>\d+)\): error (?P<code>CS\d+): (?P<message>.*)$")
BARE_ERROR = re.compile(r"error (?P<code>CS\d+): (?P<message>.*)$")

# 'Owner' does not contain a definition for 'member'
NO_DEFINITION = re.compile(r"^'(?P<owner>[^']+)' does not contain a definition for '(?P<member>[^']+)'")
# 'Owner.member' is inaccessible due to its protection level
INACCESSIBLE = re.compile(r"^'(?P<name>[^']+)' is inaccessible due to its protection level")
# The type or namespace name 'X' could not be found
MISSING_TYPE = re.compile(r"type or namespace name '(?P<name>[^']+)'")

def declared_types(scripts_dir):
    """Type names the assembly under test declares, from the one-type-per-file export."""
    names = set()
    for root, _dirs, files in os.walk(scripts_dir):
        for name in files:
            if name.endswith(".cs"):
                names.add(name[:-3])
    return names

VISIBILITY_TOOL = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                               "..", "Tools", "MemberVisibility", "bin", "Release", "net10.0", "MemberVisibility.dll")


def member_visibility(queries, references_dir):
    """{(type, member): PRESENT_PUBLIC | PRESENT_NONPUBLIC | ABSENT} for what the tool can answer."""
    if not queries or not os.path.isfile(VISIBILITY_TOOL):
        return {}

    runner = os.environ.get("DOTNET") or shutil.which("dotnet")
    if not runner:
        for candidate in (os.path.expanduser("~/.dotnet/dotnet"), "/home/user/.dotnet/dotnet", "/usr/share/dotnet/dotnet"):
            if os.path.isfile(candidate):
                runner = candidate
                break
    if not runner:
        return {}

    stdin = "".join(f"{owner}|{member}\n" for owner, member in sorted(queries))
    result = subprocess.run([runner, VISIBILITY_TOOL, references_dir],
                            input=stdin, capture_output=True, text=True, check=False)
    if result.returncode != 0:
        return {}

    answers = {}
    for line in result.stdout.splitlines():
        parts = line.split("|")
        if len(parts) == 3:
            answers[(parts[0], parts[1])] = parts[2]
    return answers


def references_present(references_dir):
    """How many reference assemblies the compilation actually had."""
    if not os.path.isdir(references_dir):
        return 0
    return sum(1 for entry in os.listdir(references_dir) if entry.endswith(".dll"))

def simple_name(text):
    """'System.Collections.Generic.List<Foo>.Bar' -> 'Bar'; 'Action<int, long>' -> 'Action'."""
    depth = 0
    stripped = []
    for ch in text:
        if ch == "<":
            depth += 1
        elif ch == ">":
            depth = max(0, depth - 1)
        elif depth == 0:
            stripped.append(ch)
    name = "".join(stripped).split(".")[-1].strip()
    return KEYWORD_ALIASES.get(name, name)

def owner_and_member(code, message):
    m = NO_DEFINITION.match(message)
    if m:
        return simple_name(m.group("owner")), m.group("member")
    m = INACCESSIBLE.match(message)
    if m:
        name = m.group("name")
        if "." in name:
            owner, _, member = name.rpartition(".")
            return simple_name(owner), member
        return simple_name(name), name
    m = MISSING_TYPE.search(message)
    if m:
        name = m.group("name")
        return simple_name(name), name
    return None, None

def classify(code, message, ours, references_complete, visibility):
    """Return (category, reason). Precedence is deliberate; see the module docstring."""
    if code in TOOLCHAIN_CODES:
        return TOOLCHAIN_ERROR, "compiler could not read an input"
    if code in ROSLYN_CODES or any(marker in message for marker in ROSLYN_MARKERS):
        return ROSLYN_ERROR, "the compiler reported on itself"

    # A name the decompiler invented cannot be supplied by any reference set, whatever the code.
    if MANGLED.search(message):
        return DECOMPILER_ERROR, "names a decompiler-mangled identifier"

    if code in LOOKUP_CODES:
        owner, member = owner_and_member(code, message)
        if owner is None:
            return UNCLASSIFIED, "lookup failure whose symbol could not be read from the message"
        if owner in ours:
            return DECOMPILER_ERROR, "the type is one this export declares"
        if not references_complete:
            return REFERENCE_ERROR, "a reference assembly was missing or unreadable"
        if code == "CS0122":
            # The compiler found the member, so it is there and the export reached what C# cannot.
            return DECOMPILER_ERROR, "reaches a member of a referenced assembly that C# cannot"

        seen = visibility.get((owner, member))
        if seen == "PRESENT_NONPUBLIC":
            return DECOMPILER_ERROR, "reaches a non-public member of a referenced assembly"
        if seen == "ABSENT":
            return REFERENCE_ERROR, "absent from the reference assemblies - stripped from the build"
        if seen == "PRESENT_PUBLIC":
            return UNCLASSIFIED, "the member is public and was still not found - a signature mismatch"
        return UNCLASSIFIED, "foreign member not found, and Test/Tools/MemberVisibility is not built"

    return DECOMPILER_ERROR, "invalid C# independent of the reference set"

def main():
    if len(sys.argv) < 4:
        print(__doc__.strip(), file=sys.stderr)
        return 2

    log_path, scripts_dir, references_dir = sys.argv[1:4]
    json_path = None
    if "--json" in sys.argv:
        json_path = sys.argv[sys.argv.index("--json") + 1]

    ours = declared_types(scripts_dir)
    reference_count = references_present(references_dir)

    # A reference the compiler could not read makes every lookup failure after it the set's fault, so
    # the log is read once for that before anything is classified.
    with open(log_path, encoding="utf-8", errors="replace") as handle:
        unreadable = any(f"error {code}: " in line for line in handle for code in TOOLCHAIN_CODES)
    references_complete = reference_count > 0 and not unreadable

    diagnostics = []
    with open(log_path, encoding="utf-8", errors="replace") as handle:
        for raw in handle:
            match = ERROR_LINE.match(raw.rstrip("\n")) or BARE_ERROR.search(raw)
            if match:
                diagnostics.append((match.group("code"), match.group("message")))

    queries = set()
    for code, message in diagnostics:
        if code in LOOKUP_CODES and code != "CS0122" and not MANGLED.search(message):
            owner, member = owner_and_member(code, message)
            if owner is not None and owner not in ours:
                queries.add((owner, member))
    visibility = member_visibility(queries, references_dir)

    counts = Counter()
    per_code = defaultdict(Counter)
    reasons = {}
    examples = {}

    for code, message in diagnostics:
        category, reason = classify(code, message, ours, references_complete, visibility)
        counts[category] += 1
        per_code[category][code] += 1
        reasons.setdefault((category, code), reason)
        examples.setdefault((category, code), message)

    total = sum(counts.values())
    note = "" if references_complete else "  (INCOMPLETE - lookup failures are the set's, not the export's)"
    print(f"reference assemblies: {reference_count}{note}")
    print(f"errors classified: {total}")
    print()
    for category in (DECOMPILER_ERROR, REFERENCE_ERROR, ROSLYN_ERROR, TOOLCHAIN_ERROR, UNCLASSIFIED):
        print(f"{category:<18} {counts[category]:>6}")
    print()
    for category in (DECOMPILER_ERROR, REFERENCE_ERROR, ROSLYN_ERROR, TOOLCHAIN_ERROR, UNCLASSIFIED):
        if not counts[category]:
            continue
        print(f"{category}")
        for code, count in per_code[category].most_common():
            print(f"  {count:>6}  {code:<8} {reasons[(category, code)]}")
            print(f"          {examples[(category, code)][:110]}")
        print()

    if json_path:
        with open(json_path, "w", encoding="utf-8") as handle:
            json.dump({
                "total": total,
                "categories": {c: counts[c] for c in
                               (DECOMPILER_ERROR, REFERENCE_ERROR, ROSLYN_ERROR, TOOLCHAIN_ERROR, UNCLASSIFIED)},
                "byCode": {c: dict(per_code[c]) for c in per_code},
                "referenceAssemblies": reference_count,
                "referencesComplete": references_complete,
            }, handle, indent=2)

    return 0

if __name__ == "__main__":
    sys.exit(main())
