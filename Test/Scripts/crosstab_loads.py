#!/usr/bin/env python3
"""Cross-tabulates base-pointer origin against coordinate frame over BOTH load populations.

Iteration 044 measured that cross-tab over the loads the generator gave up on, found it separated
with no exceptions, and declined to act on it because that population is a sample of the failures
rather than of the program.  This reads the resolved dump alongside it, so a shape can be asked the
only question that matters before a resolver is patched: is it already handled correctly elsewhere?

Usage: crosstab_loads.py <resolved.tsv> <unresolved.tsv>
"""
import collections
import sys

RES_ORIGIN, RES_FRAME, RES_OWNER, RES_KIND = 8, 9, 4, 13
UNR_ORIGIN, UNR_FRAME, UNR_OWNER, UNR_CAUSE = 18, 17, 4, 12


def read(path, origin_col, frame_col, owner_col, extra_col):
    rows = []
    with open(path, encoding="utf-8", errors="replace") as handle:
        for line in handle:
            parts = line.rstrip("\n").split("\t")
            if len(parts) <= max(origin_col, frame_col, owner_col, extra_col):
                continue
            rows.append((parts[origin_col], parts[frame_col], parts[owner_col], parts[extra_col]))
    return rows


def main():
    resolved = read(sys.argv[1], RES_ORIGIN, RES_FRAME, RES_OWNER, RES_KIND)
    unresolved = read(sys.argv[2], UNR_ORIGIN, UNR_FRAME, UNR_OWNER, UNR_CAUSE)

    print(f"resolved   {len(resolved)}")
    print(f"unresolved {len(unresolved)}")
    total = len(resolved) + len(unresolved)
    print(f"resolution rate {len(resolved) / total:.4f}\n")

    for name, rows in (("RESOLVED", resolved), ("UNRESOLVED", unresolved)):
        print(f"== {name}: origin ==")
        for origin, count in collections.Counter(r[0] for r in rows).most_common():
            print(f"{count:8d}  {origin}")
        print()
        print(f"== {name}: coordinate frame ==")
        for frame, count in collections.Counter(r[1] for r in rows).most_common():
            print(f"{count:8d}  {frame}")
        print()

    print("== origin x frame x status ==")
    cells = collections.defaultdict(lambda: [0, 0])
    for origin, frame, _, _ in resolved:
        cells[(origin, frame)][0] += 1
    for origin, frame, _, _ in unresolved:
        cells[(origin, frame)][1] += 1

    print(f"{'origin':<20} {'frame':<24} {'resolved':>9} {'unresolved':>11} {'rate':>7}")
    for (origin, frame), (ok, bad) in sorted(cells.items(), key=lambda kv: -(kv[1][0] + kv[1][1])):
        rate = ok / (ok + bad) if ok + bad else 0.0
        print(f"{origin:<20} {frame:<24} {ok:>9} {bad:>11} {rate:>7.3f}")

    print("\n== shapes present when RESOLVED and absent when UNRESOLVED ==")
    print("(a candidate missing rule only if the same shape never fails)")
    for (origin, frame), (ok, bad) in sorted(cells.items(), key=lambda kv: -kv[1][0]):
        if ok and not bad:
            print(f"{ok:8d}  {origin} / {frame}")

    print("\n== shapes present when UNRESOLVED and absent when RESOLVED ==")
    print("(nothing in the program resolves this shape: a genuinely missing capability)")
    for (origin, frame), (ok, bad) in sorted(cells.items(), key=lambda kv: -kv[1][1]):
        if bad and not ok:
            print(f"{bad:8d}  {origin} / {frame}")


if __name__ == "__main__":
    main()
