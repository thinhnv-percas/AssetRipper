#!/usr/bin/env python3
"""One recovery contract per method: why a recovered method is, or is not, ready to compile.

Iteration 066. Every other measure answers one question for all methods at once - how many placeholders,
how many Roslyn errors, how many EXACT - and none answers the one a person asks of a single method: *why
does this not compile?* The contract puts every axis side by side for each method, each read by the tool
that already owns it, so the contract cannot disagree with the measure it summarises:

  semantic_status      recovery_metrics.classify            (EXACT / HIGH_CONFIDENCE / PARTIAL / FALLBACK / MISSING)
  provenance_status    placeholder_families.family_of       (which kinds of placeholder the body still carries)
  unresolved_loads     UNMANAGED_MEMORY_LOAD placeholders
  unresolved_calls     METHOD_NOT_FOUND, UNKNOWN_CALL_TARGET, NATIVE_IMPORT, INDIRECT_CALL, INDIRECT_JUMP, delegate
  unresolved_returns   invoker dispatches refused on their return (CPP2IL_DUMP_INVOKER_ARGS), with the reason
  abi_status           the ABI-level evidence of loss the body carries: invoker arguments, stack shifts
  type_status          ILSpy's own `Expected X, but got Y` stack mismatches, and `object` locals
  control_flow_status  `goto` left in the body, and instructions the lifter has no rule for
  compile_status       COMPILES / FAILS / NOT_COMPILED, from the body pass of compile_recovered_scripts.sh
  compile_risk         the producer family of the first error (cluster_body_errors.classify), or the reason none
                       was measured

A method that compiles with placeholders is not called recovered, and a method that does not compile is
attributed to the first layer that went wrong, never to the message.

    recovery_contract.py <rip game dir> [--errors body-errors.txt] [--invoker invoker.tsv]
                         [--assembly Assembly-CSharp] [--json out.json] [--why N]
"""
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import cluster_body_errors as cbe  # noqa: E402
import placeholder_families as pf  # noqa: E402
import recovery_metrics as rm  # noqa: E402

ADDRESS = re.compile(r'\[Address\(RVA = "0x([0-9A-F]+)"')
DECLARATION = re.compile(r'^\s*(?:(?:public|private|protected|internal|static|virtual|override|sealed|abstract|extern|unsafe|new|async)\s+)+[^=;]*?(\w+)\s*(?:<[^>]*>)?\s*\(')
MISMATCH = re.compile(r'//IL_[0-9a-f]+: Expected (\w+), but got (\w+)')
UNTYPED = re.compile(r'\bobject obj\d* =')

CALL_FAMILIES = {"METHOD_NOT_FOUND", "UNKNOWN_CALL_TARGET", "NATIVE_IMPORT", "INDIRECT_CALL", "INDIRECT_JUMP", "UNRESOLVED_DELEGATE"}


def method_spans(text: str):
    """(rva, first line, last line, declared name) for every method carrying an Address attribute; 1-based lines."""
    lines = text.splitlines()
    starts = [(index + 1, match.group(1)) for index, line in enumerate(lines) if (match := ADDRESS.search(line))]
    spans = []
    for position, (line, rva) in enumerate(starts):
        end = starts[position + 1][0] - 1 if position + 1 < len(starts) else len(lines)
        name = ""
        for candidate in lines[line:min(end, line + 6)]:
            if (declared := DECLARATION.match(candidate)):
                name = declared.group(1)
                break
        spans.append((rva, line, end, name))
    return spans


def invoker_returns(path):
    """caller -> [reason] for every invoker dispatch refused on its return."""
    found = collections.defaultdict(list)
    if not path or not pathlib.Path(path).exists():
        return found  # no invoker dump: no invoker dispatch was analysed, which is not the same as none refused
    for line in pathlib.Path(path).read_text(errors="replace").splitlines():
        cells = line.split("\t")
        if len(cells) >= 11 and cells[10].startswith("UNKNOWN_RETURN"):
            found[cells[0]].append(cells[10])
    return found


def invoker_arguments(path):
    found = collections.defaultdict(list)
    if not path or not pathlib.Path(path).exists():
        return found
    for line in pathlib.Path(path).read_text(errors="replace").splitlines():
        cells = line.split("\t")
        if len(cells) >= 11 and cells[10].startswith("UNKNOWN_ARGUMENT"):
            found[cells[0]].append(cells[10])
    return found


def contracts(root: pathlib.Path, errors_path, invoker_path, assembly):
    scripts = root / "Assets" / "Scripts"
    base = scripts / assembly if assembly else scripts
    errors_by_file = collections.defaultdict(list)
    if errors_path:
        cache = {}
        for raw in open(errors_path, encoding="utf-8", errors="replace"):
            match = cbe.LINE.match(raw.strip())
            if not match:
                continue
            file, line, column, code, message = match.groups()
            resolved = pathlib.Path(file)
            if not resolved.exists():
                continue  # the body pass compiled a copy elsewhere; a basename is not an identity, so do not guess
            key = str(resolved.resolve())
            if key not in cache:
                cache[key] = resolved.read_text(encoding="utf-8-sig", errors="replace").split("\n")
            index = int(line) - 1
            text = cache[key][index] if 0 <= index < len(cache[key]) else ""
            errors_by_file[key].append({"line": int(line), "column": int(column), "code": code, "message": message,
                                        "expression": text.strip(), "context": "\n".join(cache[key][index:index + 4])})
    returns = invoker_returns(invoker_path)
    arguments = invoker_arguments(invoker_path)

    result = []
    for path in sorted(base.rglob("*.cs")):
        text = path.read_text(encoding="utf-8", errors="replace")
        spans = method_spans(text)
        scored = list(rm.methods(text))
        if len(scored) != len(spans):
            # the two readers disagree about where methods are: say so rather than pairing them wrongly
            result.append({"file": str(path.relative_to(root)), "rva": None, "method": None,
                           "contract_status": "UNPAIRED", "reason": f"{len(spans)} address attributes, {len(scored)} scored bodies"})
            continue
        lines = text.splitlines()
        file_errors = errors_by_file.get(str(path.resolve()), [])
        type_name = path.stem
        for (rva, first, last, name), (native, source, body) in zip(spans, scored):
            status, placeholders, untyped, lost = rm.classify(native, source, body)
            families = collections.Counter(pf.family_of(message)[0] for message in pf.messages(body))
            segment = "\n".join(lines[first - 1:last])
            in_method = [e for e in file_errors if first <= e["line"] <= last]
            caller_keys = [key for key in returns if key.endswith(f"{type_name}::{name}")] if name else []
            argument_keys = [key for key in arguments if key.endswith(f"{type_name}::{name}")] if name else []
            unresolved_returns = sorted({reason for key in caller_keys for reason in returns[key]})
            unknown_arguments = sorted({reason for key in argument_keys for reason in arguments[key]})
            mismatches = MISMATCH.findall(segment)
            gotos = len(re.findall(r'\bgoto\b', body))

            if not errors_path:
                compile_status, risk = "NOT_COMPILED", "NO_COMPILE_RESULT"
            elif in_method:
                compile_status = "FAILS"
                first_error = min(in_method, key=lambda e: (e["line"], e["column"]))
                risk = cbe.classify(first_error["code"], first_error["message"], first_error["expression"], first_error["context"])
            else:
                compile_status, risk = "COMPILES", "NONE"

            abi = []
            if unknown_arguments:
                abi.append("INVOKER_ARGUMENT_UNPROVEN")
            if unresolved_returns:
                abi.append("INVOKER_RETURN_UNPROVEN")
            if families.get("STACK_SHIFT"):
                abi.append("STACK_SHIFT_UNMODELLED")

            result.append({
                "file": str(path.relative_to(root)),
                "rva": "0x" + rva,
                "method": name,
                "nativeBytes": native,
                "semantic_status": status,
                "provenance_status": "NO_PLACEHOLDER" if not families else "PLACEHOLDERS:" + ",".join(sorted(families)),
                "unresolved_loads": families.get("UNMANAGED_MEMORY_LOAD", 0),
                "unresolved_calls": sum(count for family, count in families.items() if family in CALL_FAMILIES),
                "unresolved_returns": unresolved_returns,
                "unknown_arguments": unknown_arguments,
                "abi_status": "NO_EVIDENCE_OF_LOSS" if not abi else ",".join(abi),
                "type_status": "STACK_TYPE_MISMATCH" if mismatches else ("UNTYPED_LOCALS" if UNTYPED.search(body) else "TYPED"),
                "type_mismatches": len(mismatches),
                "control_flow_status": "NOT_IMPLEMENTED_INSTRUCTION" if families.get("NOT_IMPLEMENTED_INSTRUCTION")
                    else ("GOTO" if gotos else "STRUCTURED"),
                "compile_status": compile_status,
                "compile_errors": [f'{e["code"]}: {e["message"]}' for e in sorted(in_method, key=lambda e: (e["line"], e["column"]))][:5],
                "compile_error_count": len(in_method),
                "compile_risk": risk,
                "lost_operation_classes": sorted(lost) if lost else [],
            })
    return result


def summary(rows, why):
    paired = [row for row in rows if row.get("rva")]
    out = {
        "methods": len(paired),
        "unpaired_files": sum(1 for row in rows if not row.get("rva")),
        "compile_status": dict(collections.Counter(row["compile_status"] for row in paired)),
        "compile_risk_of_failing_methods": dict(collections.Counter(row["compile_risk"] for row in paired if row["compile_status"] == "FAILS").most_common()),
        "semantic_status": dict(collections.Counter(row["semantic_status"] for row in paired)),
        # the cross-tab that says what each status is worth: an EXACT method that fails to compile is the
        # interesting one, and so is a FALLBACK one that compiles
        "semantic_by_compile": {f"{s}/{c}": n for (s, c), n in collections.Counter((row["semantic_status"], row["compile_status"]) for row in paired).most_common()},
        "abi_status": dict(collections.Counter(row["abi_status"] for row in paired)),
        "type_status": dict(collections.Counter(row["type_status"] for row in paired)),
        "control_flow_status": dict(collections.Counter(row["control_flow_status"] for row in paired)),
    }
    out["why_not_compile_examples"] = [
        {key: row[key] for key in ("file", "rva", "method", "semantic_status", "compile_risk", "compile_errors", "provenance_status", "type_status")}
        for row in sorted((r for r in paired if r["compile_status"] == "FAILS"), key=lambda r: -r["compile_error_count"])[:why]]
    return out


def self_test() -> int:
    text = '''
	[Address(RVA = "0x10", Offset = "0x10", Length = "0x8")]
	[NativeSource(Body = "x")]
	public void A()
	{
		goto IL_0;
	}

	[Address(RVA = "0x20", Offset = "0x20", Length = "0x8")]
	public static int B(int x)
	{
		return x;
	}
'''
    spans = method_spans(text)
    cases = [
        ("two methods are found", len(spans) == 2),
        ("names come from the declaration after the attribute", [s[3] for s in spans] == ["A", "B"]),
        ("a method's span ends where the next one's attribute starts", spans[0][2] == spans[1][1] - 1),
        ("the last span runs to the end of the file", spans[1][2] == len(text.splitlines())),
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
    option = lambda name: argv[argv.index(name) + 1] if name in argv else None  # noqa: E731
    root = pathlib.Path(argv[1])
    rows = contracts(root, option("--errors"), option("--invoker"), option("--assembly"))
    report = summary(rows, int(option("--why") or 10))
    if option("--json"):
        pathlib.Path(option("--json")).write_text(json.dumps({"summary": report, "methods": rows}, indent=1))
    print(json.dumps({k: v for k, v in report.items() if k != "why_not_compile_examples"}, indent=1))
    for example in report["why_not_compile_examples"]:
        print(f'  {example["file"]}#{example["rva"]} {example["method"]}: {example["semantic_status"]}, {example["compile_risk"]}; '
              f'{example["compile_errors"][0] if example["compile_errors"] else ""}')
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
