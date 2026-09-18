#!/usr/bin/env python3
"""What the inlined-framework-operation recovery was offered, and what it took.

`InlineListAddRecovery` folds the fast path of `List<T>.Add` that il2cpp inlined into its caller back
into the call it came from. The number that matters is not how many Roslyn errors went away - that
counts one consequence of the fold and would go up or down for a dozen unrelated reasons - but how
many call sites were offered, how many were taken, and under what reason each of the rest was turned
down. A family that matches nothing and a family that is never reached print the same match count
otherwise, and this project has twice spent an iteration on a pass that never fired.

False positives and false negatives are reported as *cases*, not as a rate:

  false positive   a fold the evidence did not support. Bounded by construction rather than by
                   inspection: the anchor is a resolved call to `List<T>.AddWithResize`, which is
                   private to the framework type and called from `Add` and nowhere else, so a site
                   that is not an Add cannot reach the rule at all. What this script can still check
                   is the residue: a rewritten body must name no `_items`, `_size` or `_version` of
                   the list it folded.
  false negative   a site the rule was offered and turned down. Every one is counted under the reason
                   the pass rejected it for, read from the log rather than re-derived here.

Usage: inline_list_add_report.py <log>... [--json out.json] [--markdown out.md]
"""
import argparse
import collections
import json
import pathlib
import re
import sys

TOTALS = re.compile(r"inline operation recovery: (?P<candidates>\d+) candidate sites, (?P<matched>\d+) rewritten")
FAMILY = re.compile(r"inline operation recovery: (?P<count>\d+)x (?P<family>\w+)$")
REJECTION = re.compile(r"inline operation recovery: rejected (?P<count>\d+)x - (?P<reason>.+)$")

# What a body that folded an Add must no longer name. `_version` is the list's own and `Add` performs
# it; `_items` and `_size` are the backing array and the count the fast path reached directly.
RESIDUE = re.compile(r"\._(items|size|version)\b")
NATIVE_SOURCE = re.compile(r"^\s*\[NativeSource")


def read_log(path):
    report = {
        "log": str(path),
        "complete": False,
        "candidate_sites": None,
        "matched_sites": None,
        "rejected_sites": None,
        "by_family": {},
        "rejections": {},
    }

    if not path.is_file():
        report["status"] = "LOG_MISSING"
        return report

    text = path.read_text(encoding="utf-8", errors="replace")

    # A measurement read while the export is still writing is not a measurement.
    report["complete"] = "Finished post-export" in text

    for line in text.splitlines():
        if (match := TOTALS.search(line)):
            report["candidate_sites"] = int(match.group("candidates"))
            report["matched_sites"] = int(match.group("matched"))
        elif (match := FAMILY.search(line)):
            report["by_family"][match.group("family")] = int(match.group("count"))
        elif (match := REJECTION.search(line)):
            report["rejections"][match.group("reason")] = int(match.group("count"))

    if report["candidate_sites"] is None:
        report["status"] = "PASS_NEVER_REPORTED"
    elif not report["complete"]:
        report["status"] = "RIP_INCOMPLETE"
    else:
        report["status"] = "OK"
        report["rejected_sites"] = report["candidate_sites"] - report["matched_sites"]

    return report


def residue(game):
    """Reads of a list's private members left in the exported bodies, which a fold removes."""
    remaining = collections.Counter()

    for path in sorted(game.rglob("*.cs")):
        for line in path.read_text(encoding="utf-8", errors="replace").splitlines():
            if NATIVE_SOURCE.match(line):
                continue
            for match in RESIDUE.finditer(line):
                remaining[match.group(1)] += 1

    return dict(remaining)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("logs", nargs="+", help="one rip log per fixture, as <fixture>=<log>")
    parser.add_argument("--game", action="append", default=[],
                        help="<fixture>=<game directory inside the rip>, for the residue check")
    parser.add_argument("--json")
    parser.add_argument("--markdown")
    arguments = parser.parse_args()

    games = dict(entry.split("=", 1) for entry in arguments.game)
    fixtures = {}

    for entry in arguments.logs:
        name, _, path = entry.partition("=")
        fixtures[name] = read_log(pathlib.Path(path or name))

        if name in games:
            fixtures[name]["private_member_reads_left"] = residue(pathlib.Path(games[name]))

    report = {
        "fixtures": fixtures,
        "candidate_sites": sum(f["candidate_sites"] or 0 for f in fixtures.values()),
        "matched_sites": sum(f["matched_sites"] or 0 for f in fixtures.values()),
        "rejected_sites": sum(f["rejected_sites"] or 0 for f in fixtures.values()),
        # A site that cannot reach the rule is not a false negative; a site offered and turned down
        # is, and every one carries the reason it was turned down for.
        "false_negative_cases": collections.Counter(),
        # Bounded by the anchor rather than by inspection - see the module docstring.
        "false_positive_cases": [],
    }

    for fixture in fixtures.values():
        for reason, count in fixture["rejections"].items():
            report["false_negative_cases"][reason] += count

    report["false_negative_cases"] = dict(report["false_negative_cases"])

    print(f"{'fixture':<16}{'candidates':>12}{'matched':>9}{'rejected':>10}  status")
    for name, fixture in fixtures.items():
        print(f"{name:<16}{fixture['candidate_sites'] if fixture['candidate_sites'] is not None else '-':>12}"
              f"{fixture['matched_sites'] if fixture['matched_sites'] is not None else '-':>9}"
              f"{fixture['rejected_sites'] if fixture['rejected_sites'] is not None else '-':>10}  {fixture['status']}")

    print(f"\n{'total':<16}{report['candidate_sites']:>12}{report['matched_sites']:>9}{report['rejected_sites']:>10}")

    if report["false_negative_cases"]:
        print("\n== sites offered and turned down, by reason ==")
        for reason, count in sorted(report["false_negative_cases"].items(), key=lambda pair: -pair[1]):
            print(f"  {count:>6}  {reason}")

    for name, fixture in fixtures.items():
        if "private_member_reads_left" in fixture:
            left = fixture["private_member_reads_left"]
            print(f"\n{name}: private list members still read in exported bodies: "
                  f"{sum(left.values())} ({', '.join(f'{k}={v}' for k, v in sorted(left.items())) or 'none'})")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))

    if arguments.markdown:
        write_markdown(pathlib.Path(arguments.markdown), report)

    return 0 if all(f["status"] == "OK" for f in fixtures.values()) else 1


def write_markdown(path, report):
    lines = [
        "# Inlined `List<T>.Add` recovery",
        "",
        "Sinh bởi `Test/Scripts/inline_list_add_report.py`. Đừng sửa tay.",
        "",
        "| fixture | candidate | matched | rejected | status |",
        "| --- | ---: | ---: | ---: | --- |",
    ]

    for name, fixture in report["fixtures"].items():
        lines.append(f"| {name} | {fixture['candidate_sites']} | {fixture['matched_sites']} "
                     f"| {fixture['rejected_sites']} | {fixture['status']} |")

    lines += [
        f"| **tổng** | **{report['candidate_sites']}** | **{report['matched_sites']}** "
        f"| **{report['rejected_sites']}** | |",
        "",
        "## Sites được đề nghị nhưng bị từ chối",
        "",
        "| số lượng | lý do |",
        "| ---: | --- |",
    ]

    for reason, count in sorted(report["false_negative_cases"].items(), key=lambda pair: -pair[1]):
        lines.append(f"| {count} | `{reason}` |")

    path.write_text("\n".join(lines) + "\n")


if __name__ == "__main__":
    sys.exit(main())
