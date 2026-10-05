#!/usr/bin/env python3
"""Per-method semantic status between two rips of the same build, with the reason a method changed.

`recovery_metrics.py` reports totals, and a total that moves says nothing about which methods moved or
why - a FALLBACK count that rises can be a hundred methods losing a call or a hundred methods whose
placeholders were removed and whose name check now runs for the first time. This scores every method of
both rips with recovery_metrics' own `methods` and `classify` (so the two cannot disagree), keys them by
file and RVA, and prints each transition with what the after-side lost and which members the name check
says the C# no longer mentions.

    method_status_diff.py <before game dir> <after game dir> [--from STATUS] [--to STATUS] [--limit N] [--json out]
"""
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import recovery_metrics as rm  # noqa: E402

ADDRESS = re.compile(r'\[Address\(RVA = "0x([0-9A-F]+)"')


def score(root):
    found = {}
    root = pathlib.Path(root)
    for path in root.rglob("*.cs"):
        text = path.read_text(encoding="utf-8", errors="replace")
        rvas = ADDRESS.findall(text)
        for index, (native, source, body) in enumerate(rm.methods(text)):
            status, placeholders, untyped, lost = rm.classify(native, source, body)
            key = (str(path.relative_to(root)), rvas[index] if index < len(rvas) else str(index))
            found[key] = {"status": status, "placeholders": placeholders, "untyped": untyped, "lost": lost,
                          "unmentioned": sorted(rm.unmentioned_members(source, body)) if source else [],
                          "body": body}
    return found


def main(argv):
    if len(argv) < 3:
        print(__doc__)
        return 2
    want_from = argv[argv.index("--from") + 1] if "--from" in argv else None
    want_to = argv[argv.index("--to") + 1] if "--to" in argv else None
    limit = int(argv[argv.index("--limit") + 1]) if "--limit" in argv else 40
    before, after = score(argv[1]), score(argv[2])
    transitions = collections.Counter()
    rows = []
    for key in sorted(set(before) & set(after)):
        old, new = before[key]["status"], after[key]["status"]
        if old == new:
            continue
        transitions[(old, new)] += 1
        if (want_from is None or old == want_from) and (want_to is None or new == want_to):
            rows.append({"file": key[0], "rva": key[1], "from": old, "to": new, "lost": after[key]["lost"],
                         "unmentioned": after[key]["unmentioned"], "placeholders": (before[key]["placeholders"], after[key]["placeholders"])})
    print(f"methods in both: {len(set(before) & set(after))}; only before {len(set(before) - set(after))}; only after {len(set(after) - set(before))}")
    for (old, new), count in transitions.most_common():
        print(f"{count:6}  {old} -> {new}")
    lost = collections.Counter(tuple(row["lost"]) for row in rows)
    unmentioned = collections.Counter(name for row in rows for name in row["unmentioned"])
    print(f"\nselected {len(rows)}; lost classes: {lost.most_common(10)}")
    print(f"members the C# no longer mentions, most common: {unmentioned.most_common(25)}")
    for row in rows[:limit]:
        print(f"  {row['from']}->{row['to']} {row['file']}#{row['rva']} lost={row['lost']} unmentioned={row['unmentioned'][:6]} placeholders={row['placeholders']}")
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps({"transitions": {f"{a}->{b}": c for (a, b), c in transitions.items()}, "rows": rows}, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
