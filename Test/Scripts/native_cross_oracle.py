#!/usr/bin/env python3
"""AssetRipper's native facts against two readers that share no code with it.

Three sources, and the point of having three is that each can be wrong:

  AR        what AssetRipper read, through LibCpp2IL - `CPP2IL_DUMP_NATIVE_FACTS` on a rip
  READER    `il2cpp_native_reader.py`: the struct layouts from `StructDb/`, the registration
            structs found by the counts the metadata declares, ELF relocations applied
  R2UNITY   radareorg/r2unity, run as an external binary: its own metadata parser and its own
            codegen module walker

r2unity recovers method pointers and nothing else - its own `doc/ptrtables.md` says field offsets,
type sizes and the generic method tables are not parsed - so for those three families the answer from
r2unity is `R2UNITY_UNAVAILABLE`, stated rather than implied. For method pointers it is run twice: once
to find the code registration by itself, which on a stripped build it cannot do, and once with the
anchor the independent reader found (`-O g_CodeRegistration=`), so that its walker is checked even
where its discovery is not. The second run is labelled `ANCHOR_FROM_READER`, because sharing the anchor
is sharing one fact, and saying so is part of the measurement.

Nothing is repaired. A disagreement is reported with every source's value and left alone:

  AGREE                   every source that answered gives the same value
  DISAGREE                two sources that answered give different values
  R2UNITY_UNAVAILABLE     r2unity does not produce this fact
  ASSET_RIPPER_UNCERTAIN  AssetRipper has no value where the reader has one (unreadable, encrypted,
                          or not looked up)
  AR_INTERPRETATION       the raw table agrees and AssetRipper's final value is a documented
                          interpretation of it - a definition given one of its instantiations' bodies

Usage:
  native_cross_oracle.py --fixture <name> --game <Test/Input/X> --facts <facts.jsonl>
                         [--r2unity <path>] [--unity <version>] [--json out.json]
  native_cross_oracle.py --self-test
"""
import argparse
import collections
import json
import os
import pathlib
import subprocess
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parent))
import il2cpp_native_reader as reader_module  # noqa: E402

REPO = pathlib.Path(__file__).resolve().parents[2]

AGREE = "AGREE"
DISAGREE = "DISAGREE"
R2_UNAVAILABLE = "R2UNITY_UNAVAILABLE"
AR_UNCERTAIN = "ASSET_RIPPER_UNCERTAIN"
AR_INTERPRETATION = "AR_INTERPRETATION"


def load_facts(path):
    facts = {"methods": {}, "types": {}, "generic": [], "images": [], "header": None}
    with open(path, encoding="utf-8") as handle:
        for line in handle:
            row = json.loads(line)
            kind = row.pop("kind")
            if kind == "header":
                facts["header"] = row
            elif kind == "image":
                facts["images"].append(row)
            elif kind == "method":
                facts["methods"][row["index"]] = row
            elif kind == "type":
                facts["types"][row["index"]] = row
            elif kind == "generic":
                facts["generic"].append(row)
    return facts


def hexint(text):
    return int(text, 16) if isinstance(text, str) else int(text or 0)


def locate(game):
    """The native binary and the metadata inside an extracted APK or IPA."""
    game = pathlib.Path(game)
    candidates = [game / "lib/arm64-v8a/libil2cpp.so"]
    candidates += list(game.glob("Payload/*.app/Frameworks/UnityFramework.framework/UnityFramework"))
    binary = next((c for c in candidates if c.exists()), None)
    metadata = next(iter(list(game.glob("assets/bin/Data/Managed/Metadata/global-metadata.dat"))
                         + list(game.glob("Payload/*.app/Data/Managed/Metadata/global-metadata.dat"))), None)
    return binary, metadata


def run_r2unity(r2unity, binary, metadata, anchor=None):
    """(summary, {method index: address}) or (None, reason)."""
    if not r2unity or not pathlib.Path(r2unity).exists():
        return None, "r2unity binary not given"
    args = [r2unity, "-f", "-c", "-j"]
    if anchor:
        args += ["-O", f"g_CodeRegistration=0x{anchor:x}"]
    env = dict(os.environ)
    r2lib = pathlib.Path(r2unity).resolve().parent
    env.setdefault("LD_LIBRARY_PATH", "/opt/r2/lib")
    try:
        out = subprocess.run(args + [str(binary), str(metadata)], capture_output=True, timeout=1800, env=env)
    except subprocess.TimeoutExpired:
        return None, "r2unity timed out"
    if out.returncode != 0:
        return None, f"r2unity exited {out.returncode}: {out.stderr.decode(errors='replace')[-300:]}"
    doc = json.loads(out.stdout)
    doc_classes = doc.get("classes", [])
    addresses = {}
    for cls in doc.get("classes", []):
        for method in cls.get("methods", []):
            addresses[method["index"]] = int(method.get("addr") or 0)
    summary = {k: doc.get(k) for k in ("version", "unity_range", "has_ptrs", "native_source",
                                       "code_registration", "metadata_registration", "method_pointers",
                                       "code_gen_modules", "native_tables")}
    summary["classes"] = doc_classes
    return summary, addresses


def relocated_copy(image, directory):
    """The binary as a loader at base zero would lay it out: every relative relocation applied.

    r2unity reads through radare2's r_bin view, and on these builds that view does not apply
    `R_AARCH64_RELATIVE` ("Reloc type 1027 not used for imports"), so every pointer in `.data.rel.ro`
    reads as the zero the file holds and no table can be walked from any anchor. Handing it this copy
    shares one step with the reader - the relocation - and nothing else: the walk, the module-to-image
    join and the token scatter are still r2unity's. The run that uses it is labelled so.
    """
    if not image.relocations:
        return None
    buffer = bytearray(image.data)
    for va, value in image.relocations.items():
        off = image.va_to_offset(va)
        if off is not None:
            buffer[off:off + 8] = value.to_bytes(8, "little")
    path = pathlib.Path(directory) / (image.path.name + ".relocated")
    path.write_bytes(bytes(buffer))
    return path


def compare(values):
    """AGREE/DISAGREE over the sources that answered."""
    answered = {k: v for k, v in values.items() if v is not None}
    if len(set(map(json.dumps, answered.values()))) <= 1:
        return AGREE
    return DISAGREE


def cross_check(facts, reader, r2_own, r2_anchor, r2_relocated=(None, "not run")):
    report = {"anchors": {}, "methodPointers": {}, "fieldLayout": {}, "typeSizes": {}, "generic": {},
              "examples": collections.defaultdict(list)}

    def example(bucket, item, limit=8):
        if len(report["examples"][bucket]) < limit:
            report["examples"][bucket].append(item)

    header = facts["header"]
    ar_code, ar_meta = hexint(header["codeRegistration"]), hexint(header["metadataRegistration"])
    report["anchors"] = {
        "codeRegistration": {"AR": hex(ar_code), "READER": hex(reader.code_registration or 0),
                             "R2UNITY": hex(r2_own[0]["code_registration"] or 0) if r2_own[0] else None,
                             "status": AGREE if ar_code == reader.code_registration else DISAGREE},
        "metadataRegistration": {"AR": hex(ar_meta), "READER": hex(reader.metadata_registration or 0),
                                 "R2UNITY": hex(r2_own[0]["metadata_registration"] or 0) if r2_own[0] else None,
                                 "status": AGREE if ar_meta == reader.metadata_registration else DISAGREE},
        "r2unityOwnDiscovery": r2_own[0] or r2_own[1],
        "r2unityOwnDiscoveryOnRelocatedCopy": r2_relocated[0] or r2_relocated[1],
        "readerNotes": reader.notes,
    }

    # ---- method pointers ----
    reader_ptrs = reader.method_pointers()
    generic_pointer_by_method = collections.defaultdict(set)
    for row in facts["generic"]:
        if row["method"] >= 0:
            generic_pointer_by_method[row["method"]].add(hexint(row["pointer"]))

    module_counts = collections.Counter()
    final_counts = collections.Counter()
    r2_counts = collections.Counter()
    r2_own_counts = collections.Counter()
    r2_reloc_counts = collections.Counter()
    for index, ar in facts["methods"].items():
        raw = reader_ptrs.get(index)
        ar_module, ar_final = hexint(ar["module"]), hexint(ar["pointer"])

        status = compare({"AR": ar_module, "READER": raw})
        module_counts[status] += 1
        if status == DISAGREE:
            example("methodModuleDisagree", {"index": index, "name": ar["name"], "token": ar["token"],
                                             "AR": hex(ar_module), "READER": hex(raw or 0)})

        if ar_final == raw:
            final_counts[AGREE] += 1
        elif ar_final in generic_pointer_by_method.get(index, ()):
            final_counts[AR_INTERPRETATION] += 1
            example("methodGenericAttribution", {"index": index, "name": ar["name"], "module": hex(raw or 0),
                                                 "AR": hex(ar_final)})
        elif ar_final == 0 and raw:
            final_counts[AR_UNCERTAIN] += 1
        else:
            final_counts[DISAGREE] += 1
            example("methodFinalDisagree", {"index": index, "name": ar["name"], "AR": hex(ar_final),
                                            "READER": hex(raw or 0)})

        for counts, source in ((r2_counts, r2_anchor), (r2_own_counts, r2_own), (r2_reloc_counts, r2_relocated)):
            if source[0] is None:
                counts[R2_UNAVAILABLE] += 1
                continue
            r2 = source[1].get(index, 0)
            if r2 == raw:
                counts[AGREE] += 1
            else:
                counts[DISAGREE] += 1
                if counts is r2_counts:
                    example("methodR2Disagree", {"index": index, "name": ar["name"], "R2UNITY": hex(r2),
                                                 "READER": hex(raw or 0)})

    report["methodPointers"] = {
        "compared": len(facts["methods"]),
        "nonZeroInReader": sum(1 for v in reader_ptrs.values() if v),
        "codegenModuleEntry_AR_vs_READER": dict(module_counts),
        "finalAttribution_AR_vs_READER": dict(final_counts),
        "R2UNITY_anchorFromReader_vs_READER": dict(r2_counts),
        "R2UNITY_ownDiscovery_vs_READER": dict(r2_own_counts),
        "R2UNITY_ownDiscoveryRelocated_vs_READER": dict(r2_reloc_counts),
    }
    # Every anchored disagreement, tested against one explanation: that r2unity indexes a module's
    # table by the method's row ordinal within its image rather than by its token's row id. The
    # residual is what that explanation does not cover.
    if r2_anchor[0] is not None:
        sequential = reader.sequential_join()
        explained = residual = 0
        for index in facts["methods"]:
            raw, r2 = reader_ptrs.get(index, 0), r2_anchor[1].get(index, 0)
            if raw == r2:
                continue
            if sequential.get(index) == r2:
                explained += 1
            else:
                residual += 1
                example("methodR2Unexplained", {"index": index, "R2UNITY": hex(r2), "READER": hex(raw)})
        report["methodPointers"]["R2UNITY_disagreementCause"] = {
            "R2UNITY_SEQUENTIAL_SCATTER": explained, "UNEXPLAINED": residual}
        report["methodPointers"]["R2UNITY_getterArbiter"] = getter_arbiter(reader, reader_ptrs, r2_anchor)

    tables = (r2_anchor[0] or {}).get("native_tables") or {}
    report["methodPointers"]["genericMethodPointerCount"] = {
        "AR": header.get("genericMethodPointerCount"),
        "READER": reader.image.u32(reader.code_registration + reader.code_reg.offset("genericMethodPointersCount"))
        if reader.code_registration else None,
        "R2UNITY": (tables.get("genericMethodPointers") or {}).get("count"),
    }
    report["methodPointers"]["genericMethodPointerCount"]["status"] = compare(
        {k: v for k, v in report["methodPointers"]["genericMethodPointerCount"].items()})

    # ---- field layout, raw ----
    reader_fields = reader.field_offsets()
    statics = reader.field_is_static()
    field_counts = collections.Counter()
    frame_counts = collections.Counter()
    for t, ar in facts["types"].items():
        ours = reader_fields.get(t, [])
        for f, ar_raw in enumerate(ar["fields"]):
            raw = ours[f] if f < len(ours) else None
            if ar_raw is None and raw is not None:
                field_counts[AR_UNCERTAIN] += 1
                continue
            status = compare({"AR": ar_raw, "READER": raw})
            field_counts[status] += 1
            if status == DISAGREE:
                example("fieldDisagree", {"type": ar["name"], "field": f, "AR": ar_raw, "READER": raw})
            # The frame question, separately: a value type's instance field offsets in the table
            # include the object header, and AssetRipper's GetFieldOffsetFromIndex subtracts it.
            # Here the only thing checked is that the raw value leaves room for the header.
            definition = ar["fieldStart"] + f
            is_static = statics[definition] if 0 <= definition < len(statics) else None
            if ar["valueType"] and raw is not None and raw >= 0:
                if is_static:
                    frame_counts["valueTypeStatic"] += 1
                elif is_static is None:
                    frame_counts["valueTypeStaticnessUnknown"] += 1
                elif reader.metadata.types[t]["genericDefinition"] and raw == 0:
                    # An open generic definition has no layout: il2cpp lays out instantiations, and
                    # the definition's table is all zeroes. Not a frame question at all.
                    frame_counts["valueTypeGenericDefinitionNoLayout"] += 1
                elif raw >= 2 * facts["header"]["pointerSize"]:
                    frame_counts["valueTypeInstanceRawIncludesHeader"] += 1
                else:
                    frame_counts["valueTypeInstanceRawBelowHeader"] += 1
                    example("valueTypeFrameViolation", {"type": ar["name"], "field": f, "raw": raw})
    report["fieldLayout"] = {"AR_vs_READER": dict(field_counts), "R2UNITY": R2_UNAVAILABLE,
                             "valueTypeFrame": dict(frame_counts)}

    # ---- type sizes ----
    reader_sizes = reader.type_sizes()
    size_counts = collections.Counter()
    for t, ar in facts["types"].items():
        ours = reader_sizes.get(t)
        if ar["sizes"] is None and ours is not None:
            size_counts[AR_UNCERTAIN] += 1
            continue
        status = compare({"AR": ar["sizes"], "READER": ours})
        size_counts[status] += 1
        if status == DISAGREE:
            example("sizeDisagree", {"type": ar["name"], "AR": ar["sizes"], "READER": ours})
    report["typeSizes"] = {"AR_vs_READER": dict(size_counts), "R2UNITY": R2_UNAVAILABLE}

    # ---- generic method table ----
    reader_rows = {row["index"]: row for row in reader.generic_methods()}
    generic_counts = collections.Counter()
    shape_counts = collections.Counter()
    names = {i: m["name"] for i, m in facts["methods"].items()}
    type_names = {i: t["name"] for i, t in facts["types"].items()}
    method_type = {i: m["type"] for i, m in facts["methods"].items()}
    focus = collections.Counter()

    for ar in facts["generic"]:
        ours = reader_rows.get(ar["index"])
        keys = ("spec", "method", "classInst", "methodInst", "pointerIndex")
        ar_view = [ar[k] for k in keys] + [hexint(ar["pointer"])]
        our_view = None if ours is None else [ours[k] for k in keys] + [ours["pointer"]]
        status = compare({"AR": ar_view, "READER": our_view})
        generic_counts[status] += 1
        if status == DISAGREE:
            example("genericDisagree", {"index": ar["index"], "AR": ar_view, "READER": our_view})

        shape = ("class+method" if ar["classInst"] >= 0 and ar["methodInst"] >= 0
                 else "class" if ar["classInst"] >= 0 else "method" if ar["methodInst"] >= 0 else "none")
        shape_counts[(shape, status)] += 1

        owner = type_names.get(method_type.get(ar["method"]), "")
        name = names.get(ar["method"], "")
        if (owner, name) in {("System.Collections.Generic.List`1", "Add"),
                             ("System.Collections.Generic.List`1", "get_Item")}:
            focus[(f"{owner}::{name}", status)] += 1

    report["generic"] = {
        "rows": len(facts["generic"]),
        "AR_vs_READER": dict(generic_counts),
        "byInstantiationShape": {f"{s}:{st}": n for (s, st), n in sorted(shape_counts.items())},
        "focus": {f"{n}:{st}": c for (n, st), c in sorted(focus.items())},
        "R2UNITY": R2_UNAVAILABLE,
    }
    report["examples"] = dict(report["examples"])
    return report


LDR_UNSIGNED_OFFSET = ((0xF9400000, 8), (0xB9400000, 4), (0x39400000, 1), (0xBD400000, 4))


def getter_arbiter(reader, reader_ptrs, r2_anchor):
    """Where two joins disagree, which address's machine code does what the method is?

    An auto-property getter's body is `ldr <reg>, [x0, #offset of its backing field]; ret`, and the
    backing field's offset is a fact both readers agree on. So for every getter of an auto-property
    whose two candidate addresses differ, the first instruction at each is decoded and compared with
    the field it must load. `ONLY_READER` counts the join that holds; `ONLY_R2UNITY` would count the
    other; `NEITHER` is a static getter, which reads static storage and not `x0`.
    """
    if not r2_anchor[0] or "classes" not in r2_anchor[0]:
        return None
    offsets = reader.field_offsets()
    image = reader.image
    tally = collections.Counter()

    def loads(va):
        off = image.va_to_offset(va)
        if off is None:
            return None
        word = int.from_bytes(image.data[off:off + 4], "little")
        for base, scale in LDR_UNSIGNED_OFFSET:
            if word & 0xFFC00000 == base and (word >> 5) & 31 == 0:
                return ((word >> 10) & 0xFFF) * scale
        return None

    for cls in r2_anchor[0]["classes"]:
        fields = {f["name"]: k for k, f in enumerate(cls.get("fields", []))}
        for method in cls.get("methods", []):
            name = method["name"]
            if not name.startswith("get_") or method.get("parameter_count"):
                continue
            backing = fields.get(f"<{name[4:]}>k__BackingField")
            if backing is None:
                continue
            ours, theirs = reader_ptrs.get(method["index"], 0), int(method.get("addr") or 0)
            if not ours or not theirs or ours == theirs:
                continue
            want = offsets.get(cls["index"], [None] * (backing + 1))[backing]
            a, b = loads(ours) == want, loads(theirs) == want
            tally["BOTH" if a and b else "ONLY_READER" if a else "ONLY_R2UNITY" if b else "NEITHER"] += 1
    return dict(tally)


def self_test():
    """Each case is red if the rule it names is removed."""
    failures = 0

    def check(name, got, want):
        nonlocal failures
        ok = got == want
        failures += 0 if ok else 1
        print(f"{'ok  ' if ok else 'FAIL'}  {name}: {got!r}")

    check("equal values agree", compare({"AR": 1, "READER": 1}), AGREE)
    check("different values disagree", compare({"AR": 1, "READER": 2}), DISAGREE)
    check("a source with no answer does not vote", compare({"AR": 1, "READER": None}), AGREE)
    check("lists compare element-wise", compare({"AR": [1, 2], "READER": [1, 3]}), DISAGREE)

    # An ELF relative relocation is what a pointer in .data.rel.ro reads as; without it the slot
    # holds zero and neither registration struct can be found.
    image = reader_module.NativeImage.__new__(reader_module.NativeImage)
    image.data = bytes(16)
    image.segments = [(0x1000, 16, 0, 16, False)]
    image._starts = [0x1000]
    image.relocations = {0x1008: 0xABCDEF}
    image.encrypted = []
    check("a relocated slot reads its relocation", image.ptr(0x1008), 0xABCDEF)
    check("an unrelocated slot reads its bytes", image.ptr(0x1000), 0)
    image.encrypted = [(0x1000, 0x1008)]
    check("an encrypted byte is not read", image.u32(0x1000), None)

    # The count-constrained scan must require the upper half of the slot to be zero.
    image.data = (5).to_bytes(4, "little") + (1).to_bytes(4, "little") + (5).to_bytes(8, "little")
    image.encrypted = []
    check("a count whose upper half is not zero is not a count", list(image.aligned_hits(5)), [0x1008])

    print(f"{8 - failures} of 8 cases pass")
    return 1 if failures else 0


def summarise(fixture, report):
    lines = [f"== {fixture} =="]
    a = report["anchors"]
    lines.append(f"anchors  code {a['codeRegistration']['status']} (AR {a['codeRegistration']['AR']}, "
                 f"reader {a['codeRegistration']['READER']}, r2unity {a['codeRegistration']['R2UNITY']})  "
                 f"metadata {a['metadataRegistration']['status']}")
    for family in ("methodPointers", "fieldLayout", "typeSizes", "generic"):
        body = {k: v for k, v in report[family].items() if k not in ("focus",)}
        lines.append(f"{family:15}{json.dumps(body)}")
    if report["generic"].get("focus"):
        lines.append(f"{'generic focus':15}{json.dumps(report['generic']['focus'])}")
    return "\n".join(lines)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--fixture")
    parser.add_argument("--game")
    parser.add_argument("--facts")
    parser.add_argument("--unity")
    parser.add_argument("--r2unity")
    parser.add_argument("--struct-db", default=str(REPO / "StructDb"))
    parser.add_argument("--json")
    parser.add_argument("--work", default="/tmp", help="where the relocated copy for r2unity is written")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return self_test()

    binary, metadata = locate(args.game)
    if binary is None or metadata is None:
        print(f"{args.fixture}: no il2cpp binary or metadata under {args.game}")
        return 2

    facts = load_facts(args.facts)
    reader = reader_module.NativeReader(binary, metadata, args.struct_db, args.unity)
    reader.find_code_registration()
    reader.find_metadata_registration()

    r2_own = run_r2unity(args.r2unity, binary, metadata)
    relocated = relocated_copy(reader.image, args.work) if args.r2unity else None
    target = relocated or binary
    r2_relocated = run_r2unity(args.r2unity, target, metadata) if relocated else (None, "no relocations to apply")
    r2_anchor = run_r2unity(args.r2unity, target, metadata, reader.code_registration) \
        if reader.code_registration else (None, "no anchor to give")

    report = cross_check(facts, reader, r2_own, r2_anchor, r2_relocated)
    report["r2unityAnchoredInput"] = "RELOCATED_BY_READER + ANCHOR_FROM_READER" if relocated else "ANCHOR_FROM_READER"
    report["fixture"] = args.fixture
    report["structDb"] = reader.struct_db_version
    report["binary"] = {"format": reader.image.format, "relocations": len(reader.image.relocations),
                        "encryptedRanges": [[hex(a), hex(b)] for a, b in reader.image.encrypted],
                        "chainedFixups": reader.image.chained_fixups}
    report["r2unityAnchored"] = {k: v for k, v in (r2_anchor[0] or {}).items() if k != "classes"} or r2_anchor[1]
    report["anchors"]["r2unityOwnDiscovery"] = {k: v for k, v in (r2_own[0] or {}).items() if k != "classes"} or r2_own[1]
    report["anchors"]["r2unityOwnDiscoveryOnRelocatedCopy"] = {k: v for k, v in (r2_relocated[0] or {}).items() if k != "classes"} or r2_relocated[1]

    print(summarise(args.fixture, report))
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(report, indent=2))
    return 0


if __name__ == "__main__":
    sys.exit(main())
