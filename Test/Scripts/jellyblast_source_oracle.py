#!/usr/bin/env python3
"""The JellyBlast source oracle, per assembly, labelled by what the source is evidence of.

Iteration 063. `source_oracle.py` and `source_behavior_oracle.py` harvest a whole project and pair
methods by (type, name) across every assembly at once. For JellyBlast that is wrong twice over: a class
is not an identity without its assembly, and the source is not one kind of evidence. Build provenance
(`reports/JELLYBLAST_BUILD_PROVENANCE.md`) proved that Assembly-CSharp in the source was *derived from
this very IPA* by decompilation and hand-editing, while five upstream packages match the build's
declarations exactly and never passed through a decompiler. Agreement with the first is agreement
between two recoveries; agreement with the second is agreement with the programmer.

So every assembly gets three labels before any method is compared:

  category    GAME / THIRD_PARTY / UNITY_PACKAGE / ENGINE / GENERATED_CODE, from where its source lives
  provenance  the build_provenance.py status of the pair (PROVEN_BUILD_MATCH, LIKELY_MATCH, ...)
  oracle      INDEPENDENT     declarations proven equal and the source was never decompiled
              VERSION_MISMATCH the source is a different version of the same package
              DERIVED         the source was recovered from this binary (pin file: derived_assemblies)
              NO_SOURCE       nothing in the checkout compiles to it

and the headline rates are reported for INDEPENDENT assemblies only. Methods pair within one assembly
by (type, name, arity); the source is first reduced to what an iOS 2022.3 player compiles.

Usage: jellyblast_source_oracle.py <source checkout> <rip output root> <provenance.json>
           [--pin Test/fixtures/jellyblast-source-revision.txt] [--json out.json] [--verbose]
"""
import argparse
import collections
import json
import pathlib
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import source_oracle  # noqa: E402
import source_behavior_oracle  # noqa: E402
import source_preprocessor  # noqa: E402
import placeholder_families  # noqa: E402
import method_behavior_contract as behavior  # noqa: E402
from semantic_ir import load  # noqa: E402

ENGINE_PREFIXES = ("UnityEngine.", "System", "mscorlib", "Mono.", "netstandard")
UNITY_PACKAGE_PREFIXES = ("Unity.",)
UNITY_PACKAGE_NAMES = ("UnityEngine.UI",)
GAME_ASSEMBLIES = ("Assembly-CSharp", "Assembly-CSharp-firstpass")
MARKERS = ("Cpp2ILInjected", "NativeSource(", "Il2CppRuntime.")


def read_pin(path):
    values = {}
    for line in pathlib.Path(path).read_text().splitlines():
        if "=" in line and not line.lstrip().startswith("#"):
            key, value = line.split("=", 1)
            values[key.strip()] = value.strip()
    return values


def asmdef_map(checkout):
    """Assembly name -> (asmdef path, directory), for the project's own asmdefs and its packages'."""
    found = {}
    roots = [checkout / "Assets", checkout / "Library" / "PackageCache"]
    for root in roots:
        for asmdef in root.rglob("*.asmdef"):
            try:
                name = json.loads(asmdef.read_text(encoding="utf-8-sig")).get("name")
            except (OSError, ValueError):
                continue
            if name:
                found.setdefault(name, (asmdef, asmdef.parent))
    return found


def owned_files(directory):
    """The .cs files an asmdef owns: everything under it except what a nested asmdef claims."""
    nested = {a.parent for a in directory.rglob("*.asmdef") if a.parent != directory}
    for path in sorted(directory.rglob("*.cs")):
        if any(parent in nested for parent in path.parents):
            continue
        yield path


def assembly_csharp_files(checkout, firstpass):
    """Unity's rule: outside every asmdef and every Editor folder; Plugins goes to firstpass."""
    assets = checkout / "Assets"
    claimed = {a.parent for a in assets.rglob("*.asmdef")}
    for path in sorted(assets.rglob("*.cs")):
        relative = path.relative_to(assets).parts
        if "Editor" in relative or any(parent in claimed for parent in path.parents):
            continue
        in_plugins = relative[0] in ("Plugins", "Standard Assets")
        if in_plugins == firstpass:
            yield path


def category_of(assembly, source_location):
    if assembly in GAME_ASSEMBLIES:
        return "GAME", "Unity's predefined script assembly"
    if assembly.startswith("__Generated") or assembly.startswith("__"):
        return "GENERATED_CODE", "il2cpp-generated assembly"
    if assembly.startswith(ENGINE_PREFIXES) and assembly not in UNITY_PACKAGE_NAMES:
        return "ENGINE", "engine module or class library, shipped by the Unity install"
    if source_location and "PackageCache" in str(source_location):
        package = pathlib.Path(source_location).relative_to(
            next(p for p in pathlib.Path(source_location).parents if p.name == "PackageCache")).parts[0]
        if package.startswith("com.unity."):
            return "UNITY_PACKAGE", f"source in {package}"
        return "THIRD_PARTY", f"source in {package}"
    if assembly.startswith(UNITY_PACKAGE_PREFIXES) or assembly in UNITY_PACKAGE_NAMES:
        return "UNITY_PACKAGE", "Unity package by name; no source in the checkout"
    if source_location:
        return "THIRD_PARTY", f"asmdef in {pathlib.Path(source_location).name}"
    return "THIRD_PARTY", "no source in the checkout"


def harvest(files, defines):
    found = {}
    declared = collections.defaultdict(set)
    decompiled = 0
    for path in files:
        text = path.read_text(encoding="utf-8", errors="replace")
        if any(marker in text for marker in MARKERS):
            decompiled += 1
        text = source_preprocessor.compile_text(text, defines)
        for type_name, name, arity, body in source_oracle.bodies(text):
            found.setdefault((type_name, name, arity), body)
        for line in text.splitlines():
            match = source_oracle.TYPE_DECLARATION.match(line)
            if match:
                declared[match["name"]] |= source_oracle.fields(text)
    return found, declared, decompiled


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("checkout")
    parser.add_argument("rip")
    parser.add_argument("provenance")
    parser.add_argument("--pin", default=str(pathlib.Path(__file__).resolve().parents[1] / "fixtures" / "jellyblast-source-revision.txt"))
    parser.add_argument("--game", default="JellyBlastV2")
    parser.add_argument("--build-fingerprint", help="AssemblyFingerprint of the build (fp-build.tsv): splits "
                        "NOT_AVAILABLE into NOT_IN_BUILD (IL2CPP stripped it) and genuinely unpaired")
    parser.add_argument("--json")
    parser.add_argument("--verbose", action="store_true")
    args = parser.parse_args()

    checkout, rip = pathlib.Path(args.checkout), pathlib.Path(args.rip)
    pin = read_pin(args.pin)
    derived = set(filter(None, pin.get("derived_assemblies", "").split(",")))
    game_scripts = rip / args.game / "Assets" / "Scripts"
    if not game_scripts.is_dir():
        print(f"PROJECT_ROOT_MISMATCH: no {game_scripts}")
        return 2

    declared_in_build = collections.defaultdict(set)
    if args.build_fingerprint:
        for line in open(args.build_fingerprint, encoding="utf-8", errors="replace"):
            cells = line.rstrip("\n").split("\t")
            if len(cells) >= 4 and cells[2] == "method":
                declared_in_build[cells[0]].add((cells[1].split(".")[-1].split("/")[-1], cells[3]))

    provenance = {row["assembly"]: row for row in json.loads(pathlib.Path(args.provenance).read_text())}
    asmdefs = asmdef_map(checkout)
    semantic = load(rip)
    defines = source_preprocessor.defines_for(pin.get("ipa_unity_version", "2022.3"), "ios")

    rows = []
    totals = collections.defaultdict(collections.Counter)
    for assembly in sorted(provenance):
        row = provenance[assembly]
        source_assembly = row.get("sourceAssembly")
        asmdef, directory = asmdefs.get(source_assembly, (None, None)) if source_assembly else (None, None)
        if source_assembly in GAME_ASSEMBLIES:
            files = list(assembly_csharp_files(checkout, source_assembly.endswith("firstpass")))
        elif directory is not None:
            files = list(owned_files(directory))
        else:
            files = []
        category, category_evidence = category_of(assembly, directory)

        if row["status"] == "NO_SOURCE" or not files:
            oracle = "NO_SOURCE"
        elif assembly in derived:
            oracle = "DERIVED"
        elif row["status"] in ("PROVEN_BUILD_MATCH", "LIKELY_MATCH"):
            oracle = "INDEPENDENT"
        else:
            oracle = "VERSION_MISMATCH"

        result = {"assembly": assembly, "category": category, "categoryEvidence": category_evidence,
                  "provenance": row["status"], "oracle": oracle, "sourceAssembly": source_assembly,
                  "sourceFiles": len(files)}
        bodies = semantic.get(assembly, {})
        result["recoveredBodies"] = len(bodies)
        if oracle == "NO_SOURCE":
            rows.append(result)
            continue
        if not bodies:
            result["status"] = "NOT_RECOVERED"
            rows.append(result)
            continue

        project_defines = source_preprocessor.project_defines(checkout, "ios", asmdef)
        symbols = dict(defines)
        symbols.update(project_defines)
        source_methods, declared, decompiled = harvest(files, symbols)
        result["sourceFilesWithDecompilerMarkers"] = decompiled
        if decompiled and oracle == "INDEPENDENT":
            # A decompiler marker in the source means it is not the programmer's text after all.
            result["oracle"] = oracle = "DERIVED"

        recovered_dir = game_scripts / assembly
        recovered_methods, _, _ = harvest(sorted(recovered_dir.rglob("*.cs")), symbols) if recovered_dir.is_dir() else ({}, None, None)

        contracts = {}
        for body in bodies.values():
            key = (body.get("declaringType", "").split(".")[-1].split("/")[-1], body.get("method", ""))
            contracts.setdefault(key, behavior.contract(body))
        project_members = {name for _t, name, _a in source_methods} | {t for t, _n, _a in source_methods}

        operation = collections.Counter()
        behaviour = collections.Counter()
        methods = []
        for (type_name, name, arity), source_body in sorted(source_methods.items()):
            recovered_body = recovered_methods.get((type_name, name, arity))
            if recovered_body is None:
                op_status = source_oracle.ABSENT
            else:
                op_status, _lost, _missing = source_oracle.compare(source_body, recovered_body)
            operation[op_status] += 1
            contract = contracts.get((type_name, name))
            if contract is None:
                # A method the build does not declare was stripped by IL2CPP: there is nothing to
                # recover, and counting it with the unpaired ones hides the ones that matter.
                stripped = args.build_fingerprint and (type_name, name) not in declared_in_build[assembly]
                be_status, notes = ("NOT_IN_BUILD" if stripped else "NOT_AVAILABLE"), []
            else:
                # Every call the machine code makes is named only when the body reaches no runtime
                # boundary and carries no placeholder of any kind (an unresolved indirect call is a
                # placeholder, not a boundary).
                calls_complete = (not contract.get("runtime_boundaries")
                                  and recovered_body is not None
                                  and not placeholder_families.messages(recovered_body))
                be_status, notes = source_behavior_oracle.verdict(
                    source_behavior_oracle.source_behavior(source_body, declared.get(type_name, set())),
                    source_behavior_oracle.recovered_behavior(contract),
                    declared.get(type_name, set()), project_members, calls_complete=calls_complete)
            behaviour[be_status] += 1
            methods.append({"type": type_name, "method": name, "arity": arity,
                            "operation": op_status, "behaviour": be_status, "notes": notes[:4]})
            if args.verbose and be_status not in ("EXACT", "SEMANTICALLY_EQUIVALENT", "NOT_AVAILABLE", "NOT_IN_BUILD"):
                print(f"    {assembly}: {type_name}.{name}/{arity} {be_status} {'; '.join(notes[:3])}")

        result["operation"] = dict(operation)
        result["behaviour"] = dict(behaviour)
        result["methods"] = methods
        totals[oracle].update({f"op:{k}": v for k, v in operation.items()})
        totals[oracle].update({f"be:{k}": v for k, v in behaviour.items()})
        rows.append(result)

    print(f"source oracle: {pin.get('repository', '?')} @ {pin.get('commit', '?')[:8]}; build {pin.get('ipa_unity_version', '?')}")
    print(f"{'assembly':30} {'category':14} {'provenance':19} {'oracle':17} {'bodies':>6}  behaviour (EXACT+EQ / compared)   operation (EXACT+EQ / paired)")
    for r in rows:
        if "behaviour" in r:
            be, op = r["behaviour"], r["operation"]
            be_cmp = sum(v for k, v in be.items() if k not in ("NOT_AVAILABLE", "NOT_IN_BUILD"))
            be_good = be.get("EXACT", 0) + be.get("SEMANTICALLY_EQUIVALENT", 0)
            op_cmp = sum(v for k, v in op.items() if k != source_oracle.ABSENT)
            op_good = op.get("EXACT", 0) + op.get("SEMANTICALLY_EQUIVALENT", 0)
            detail = f"{be_good}/{be_cmp}  {json.dumps(be, sort_keys=True)}   {op_good}/{op_cmp}"
        else:
            detail = r.get("status", "-")
        print(f"{r['assembly']:30} {r['category']:14} {r['provenance']:19} {r['oracle']:17} {r['recoveredBodies']:>6}  {detail}")

    print()
    for oracle in ("INDEPENDENT", "VERSION_MISMATCH", "DERIVED"):
        t = totals.get(oracle)
        if not t:
            print(f"{oracle}: no compared assembly")
            continue
        be_cmp = sum(v for k, v in t.items() if k.startswith("be:") and k not in ("be:NOT_AVAILABLE", "be:NOT_IN_BUILD"))
        be_good = t["be:EXACT"] + t["be:SEMANTICALLY_EQUIVALENT"]
        rate = f"{be_good / be_cmp:.4f}" if be_cmp else "None"
        print(f"{oracle}: behaviour_equivalence_rate {rate} ({be_good}/{be_cmp}); "
              + " ".join(f"{k[3:]}={v}" for k, v in sorted(t.items()) if k.startswith("be:")))

    if args.json:
        pathlib.Path(args.json).write_text(json.dumps({"pin": pin, "assemblies": rows}, indent=1))
    return 0


if __name__ == "__main__":
    sys.exit(main())
