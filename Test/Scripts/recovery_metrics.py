#!/usr/bin/env python3
"""The one measurement of a recovery, so the parts cannot disagree with each other.

Every previous measure in this project answered one question and defined its own terms to do it, and
twice now two of them have disagreed about something as basic as what a placeholder is - once by 732
placeholders and 205 methods. So the definitions live in one place: placeholder families come from
`placeholder_families.MESSAGE_PREFIXES`, and nothing here restates them.

What is new here is the *semantic* status of a method. "No placeholder" is not recovery: a body that
reads `return default;` where the native code had a field read, a comparison, a branch and a call
carries no placeholder at all and has lost everything. The evidence for that is already in the export
- `[NativeSource(Body = "...")]` is a rendering of the analysed ISIL, not of the machine code, so the
operations it names are the operations the analysis recovered - and comparing the operation classes it
names against the operation classes the C# body names says which methods are stand-ins.

  EXACT            every operation class the IR had, no placeholder, no untyped local
  HIGH_CONFIDENCE  every operation class the IR had, no placeholder, some local is `object`
  PARTIAL          carries placeholders
  FALLBACK         no placeholder, and operation classes the IR had are absent from the C#
  MISSING          the body is gone - a generator failure, or empty where native code existed

Usage: recovery_metrics.py <rip output> --log <run log> [--json out.json] [--loads loads.tsv]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
from placeholder_families import MESSAGE_PREFIXES, family_of, assembly_of, run_is_complete, messages  # noqa: E402

ADDRESS = re.compile(r'\[Address\(RVA = "0x([0-9A-Fa-f]+)"(?:, Offset = "[^"]*")?(?:, VA = "[^"]*")?(?:, Length = "0x([0-9A-Fa-f]+)")?\)\]')
NATIVE_SOURCE = re.compile(r'\[NativeSource\(Body = "(.*)"\)\]')
# The one definition of how a placeholder reaches the source lives beside the family names.
PLACEHOLDER = re.compile('"(?:' + "|".join(re.escape(p) for p in MESSAGE_PREFIXES) + ')')
GENERATOR_FAILURE = re.compile(r'throw new \w*Exception\("(?:Decompil|Object reference|Index was|The given key)')
UNTYPED_LOCAL = re.compile(r'\bobject \w+(?:\s*=|;)')

# One operation class per shape, read off a rendering of the IR rather than off machine code.
#
# A call is written differently on the two sides and that is the one shape that needs two patterns:
# the IR rendering writes `Type::Method(`, `"helper"(` or `0xADDR(`, and C# writes `receiver.Method(`
# or a bare `Method(`. One pattern for both is what makes a measure that reports every method as
# having lost its calls - the C# side matched nothing at all, so the deficit was the whole IR side.
CALL_IR = re.compile(r'(?:::\w+|"[^"]+"|0x[0-9A-Fa-f]+)\(')
CSHARP_KEYWORD = r'(?<!\bif)(?<!\bwhile)(?<!\bfor)(?<!\bforeach)(?<!\bswitch)(?<!\bcatch)(?<!\breturn)(?<!\bnew)(?<!\block)(?<!\busing)(?<!\bsizeof)(?<!\btypeof)(?<!\bnameof)(?<!\bdefault)'
CALL_CSHARP = re.compile(r'\b\w+' + CSHARP_KEYWORD + r'\s*\(')
NEWOBJ = re.compile(r'\bnew\s')
FIELD_WRITE = re.compile(r'(?:\w|\])\.\w+\s*=[^=]')
FIELD_READ = re.compile(r'=\s*[^=]*(?:\w|\])\.\w+')
ARRAY_WRITE = re.compile(r'\w\[[^\]]+\]\s*=[^=]')
ARRAY_READ = re.compile(r'=\s*[^=]*\w\[[^\]]+\]')
BRANCH = re.compile(r'\b(?:if|goto|else|switch|while|for)\b')
COMPARE = re.compile(r'(?:==|!=|<=|>=|\s<\s|\s>\s)')
ARITHMETIC = re.compile(r'(?:\s[-+*/%]\s|<<|>>|\s&\s|\s\|\s|\s\^\s)')
THROW = re.compile(r'\bthrow\b')
RETURN = re.compile(r'\breturn\b')

NEWARR = re.compile(r'\bnew\s+[\w.<>]+\s*\[')
SWITCH = re.compile(r'\bswitch\b')
LOOP = re.compile(r'\b(?:while|for|foreach)\b|\bgoto L_[0-9A-Fa-f]+;[\s\S]{0,0}')
CAST = re.compile(r'\((?:[A-Z]\w*|[\w.]+\.[A-Z]\w*)\)\s*\w|\bas\s+[A-Z]')
INSTANCEOF = re.compile(r'\bis\s+[A-Z]|\bIsInst\b')
STATIC_ACCESS = re.compile(r'\bIl2CppStaticFields\b|\b[A-Z]\w*\.[A-Z_]\w*\b')
NULL_CHECK = re.compile(r'==\s*null|!=\s*null|==\s*0\b')
FIELD_ADDRESS = re.compile(r'&\w+\.\w+|\bref\s')

CLASSES = [
    ("NEWOBJ", NEWOBJ),
    ("NEWARR", NEWARR),
    ("ARRAY_WRITE", ARRAY_WRITE),
    ("ARRAY_READ", ARRAY_READ),
    ("BRANCH", BRANCH),
    ("SWITCH", SWITCH),
    ("LOOP", LOOP),
    ("COMPARE", COMPARE),
    ("ARITHMETIC", ARITHMETIC),
    ("CAST", CAST),
    ("INSTANCEOF", INSTANCEOF),
    ("STATIC_ACCESS", STATIC_ACCESS),
    ("NULL_CHECK", NULL_CHECK),
    ("FIELD_ADDRESS", FIELD_ADDRESS),
    ("THROW", THROW),
    ("RETURN", RETURN),
]

# Every class above is *reported*, and only these count as behaviour lost when absent. The rest are
# deliberately excluded, each for a reason a measurement of this kind has to be able to state:
#
#   RETURN, COMPARE   a void method has no return in the IR rendering, and a comparison folded into
#                     an `if` is still the comparison
#   ARITHMETIC        constant folding legitimately removes it
#   CAST, INSTANCEOF  a decompiler removes a cast the type system no longer needs
#   STATIC_ACCESS     the pattern cannot tell a static field from a type name in a call
#   NULL_CHECK        il2cpp's injected checks are removed on purpose, and that is the point
#   LOOP, SWITCH      the same control flow is legitimately written as `goto`, which BRANCH covers
#   FIELD_ADDRESS     an address-of disappears when the value is used directly
#   NEWARR            covered by NEWOBJ for the purpose of "did an allocation survive"
#
# What cannot be folded away is reaching memory or reaching another method.
SUBSTANTIVE = {"CALL", "ARRAY_WRITE", "ARRAY_READ", "BRANCH", "NEWOBJ", "THROW"}

# Field access is compared by the MEMBER NAMES the IR reaches, not by the shape of the access, because
# C# writes `this.field` as bare `field` and a shape comparison therefore reports every method that
# touches its own state as having lost it. Asking "the IR named this member; does the C# mention it at
# all" is immune to that, and to every other elision a decompiler makes on the receiver.
IR_MEMBER = re.compile(r'\.([A-Za-z_]\w*)')
IR_RECEIVER_MEMBER = re.compile(r'([A-Za-z_]\w*)\.([A-Za-z_]\w*)')


def fingerprint(text: str, side: str) -> set[str]:
    found = {name for name, pattern in CLASSES if pattern.search(text)}
    if (CALL_IR if side == "ir" else CALL_CSHARP).search(text):
        found.add("CALL")
    return found


def unmentioned_members(source: str, body: str) -> set[str]:
    """Members the IR reached that the C# never names at all."""
    words = set(re.findall(r'[A-Za-z_]\w*', body))
    reached = set()
    for receiver, member in IR_RECEIVER_MEMBER.findall(source):
        # A namespace-qualified type is not a member access; the rendering writes those as
        # `UnityEngine.Transform::get_position`, so a receiver starting upper-case with a `::` after
        # it is a type name. Requiring the member to be reached off a local or `this` keeps those out.
        if receiver not in ("this",) and not receiver.startswith("v") and not receiver.startswith("stack_"):
            continue
        reached.add(member)
    return {member for member in reached if member not in words}


def native_body(attribute: str) -> str:
    """The pseudo-C# out of the attribute, with its escapes undone and its commentary removed."""
    body = attribute.replace("\\n", "\n").replace('\\"', '"').replace("\\\\", "\\")
    return "\n".join(line for line in body.split("\n") if not line.lstrip().startswith("//"))


def methods(text: str):
    """(native length, native-source body, C# body) for each method that declares where it came from."""
    lines = text.splitlines()
    for index, line in enumerate(lines):
        match = ADDRESS.search(line)
        if not match or match.group(2) is None:
            continue

        native = int(match.group(2), 16)
        source = ""
        depth = 0
        started = False
        collected = []

        for following in lines[index + 1:index + 4000]:
            stripped = following.lstrip()
            if stripped.startswith("["):
                # An attribute line carries the same text inside a string literal, braces included.
                native_match = NATIVE_SOURCE.search(following)
                if native_match:
                    source = native_body(native_match.group(1))
                continue

            collected.append(following)
            depth += following.count("{") - following.count("}")
            if "{" in following:
                started = True
            if started and depth <= 0:
                break

        yield native, source, "\n".join(collected)


def classify(native: int, source: str, body: str):
    """(status, placeholders, untyped, missing operation classes)."""
    placeholders = len(PLACEHOLDER.findall(body))
    untyped = len(UNTYPED_LOCAL.findall(body))

    if GENERATOR_FAILURE.search(body):
        return "MISSING", placeholders, untyped, []

    statements = sum(
        1 for line in body.splitlines()
        if line.strip() and not line.strip().startswith(("{", "}", "//", "[", "get", "set", "add", "remove"))
    )

    if statements == 0:
        # A method whose native code is a bare `ret` legitimately has no body; anything longer does.
        return ("EXACT" if native <= 8 else "MISSING"), placeholders, untyped, []

    if placeholders:
        return "PARTIAL", placeholders, untyped, []

    # No placeholder is where the old measure stopped. The IR says what the body should reach.
    lost = []
    if source:
        lost = sorted((fingerprint(source, "ir") & SUBSTANTIVE) - fingerprint(body, "csharp"))
        if unmentioned_members(source, body):
            lost.append("FIELD")
            lost.sort()
    if lost:
        return "FALLBACK", placeholders, untyped, lost

    return ("EXACT" if untyped == 0 else "HIGH_CONFIDENCE"), placeholders, untyped, lost


def attempted_assemblies(log: pathlib.Path | None):
    # A path that is not there says nothing, the same as no path at all. Reading it would raise, and
    # a measurement that dies on a bad --log is a measurement nobody can use ad hoc.
    if log is None or not log.exists():
        return None
    for line in log.read_text(encoding="utf-8", errors="replace").splitlines():
        if "assemblies will be attempted" in line and "Attempted:" in line:
            return {name.strip() for name in line.split("Attempted:", 1)[1].split(",")}
    return None


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("--log")
    parser.add_argument("--json")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    log = pathlib.Path(arguments.log) if arguments.log else None
    complete = run_is_complete(log)

    if complete is False:
        # Refusing is the whole point: a number from half a rip is worse than no number, because it
        # looks like a number.
        print(f"SCOPE: INCOMPLETE - {log} records no finished export, so this rip is still being written")
        print("Wait for the process to exit, then measure. Nothing is reported from a partial run.")
        return 2

    attempted = attempted_assemblies(log)

    statuses = collections.Counter()
    per_assembly = collections.defaultdict(collections.Counter)
    lost_classes = collections.Counter()
    ir_classes = collections.Counter()
    csharp_classes = collections.Counter()
    families = collections.Counter()
    family_methods = collections.defaultdict(set)
    fallbacks = []
    native_total = 0
    placeholder_total = 0

    for path in root.rglob("*.cs"):
        assembly = assembly_of(path, root)
        if attempted is not None and assembly not in attempted:
            continue

        text = path.read_text(encoding="utf-8", errors="replace")
        for native, source, body in methods(text):
            status, placeholders, untyped, lost = classify(native, source, body)
            if source:
                for name in fingerprint(source, "ir"):
                    ir_classes[name] += 1
                for name in fingerprint(body, "csharp"):
                    csharp_classes[name] += 1
            statuses[status] += 1
            per_assembly[assembly][status] += 1
            native_total += native
            placeholder_total += placeholders
            for name in lost:
                lost_classes[name] += 1
            if status == "FALLBACK":
                fallbacks.append((native, ",".join(lost), str(path.relative_to(root))))

        for line in text.splitlines():
            if line.lstrip().startswith("["):
                continue
            for message in messages(line):
                family, _ = family_of(message)
                families[family] += 1
                family_methods[family].add(str(path))

    total = sum(statuses.values())
    print(f"SCOPE: {'the ' + str(len(attempted)) + ' assemblies recovery was attempted on' if attempted else 'UNKNOWN - no log given'}")
    print(f"methods with a recorded native address: {total}")
    print(f"native code accounted for: {native_total} bytes")
    print(f"placeholders: {placeholder_total}\n")

    print("== by semantic status ==")
    for status in ("EXACT", "HIGH_CONFIDENCE", "PARTIAL", "FALLBACK", "MISSING"):
        count = statuses[status]
        print(f"{count:6d}  {status:<16} {100 * count / max(total, 1):5.1f}%")

    recovered = statuses["EXACT"] + statuses["HIGH_CONFIDENCE"]
    print(f"\nmethods recovered without a stand-in: {recovered} of {total} ({100 * recovered / max(total, 1):.1f}%)")

    if lost_classes:
        print("\n== what a FALLBACK lost, by operation class ==")
        for name, count in lost_classes.most_common():
            print(f"{count:6d}  {name}")

    # Two renderings of the same program, counted per side. The delta is NOT a loss measurement: the
    # two sides spell the same operation differently often enough that only the classes in
    # SUBSTANTIVE - the ones checked per method, above - carry that meaning. A class whose C# count is
    # the higher of the two is a pattern that matches more freely on that side, nothing more.
    print("\n== semantic fingerprint, methods reaching each operation class (per side, not a loss) ==")
    print(f"{'class':<16}{'IR':>8}{'C#':>8}{'delta':>8}")
    for name in sorted(ir_classes, key=lambda n: -ir_classes[n]):
        delta = csharp_classes[name] - ir_classes[name]
        print(f"{name:<16}{ir_classes[name]:>8}{csharp_classes[name]:>8}{delta:>+8}")

    print("\n== placeholder families ==")
    for family, count in families.most_common():
        print(f"{count:6d}  {family:<30} {len(family_methods[family]):5d} files")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps({
            "scope": sorted(attempted) if attempted else None,
            "methods": total,
            "nativeBytes": native_total,
            "placeholders": placeholder_total,
            "status": dict(statuses),
            "byAssembly": {a: dict(c) for a, c in per_assembly.items()},
            "lostOperationClasses": dict(lost_classes),
            "fingerprintIr": dict(ir_classes),
            "fingerprintCSharp": dict(csharp_classes),
            "families": {f: {"count": c, "files": len(family_methods[f])} for f, c in families.most_common()},
            "worstFallbacks": [
                {"nativeBytes": n, "lost": l, "file": f}
                for n, l, f in sorted(fallbacks, reverse=True)[:50]
            ],
        }, indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
