#!/usr/bin/env python3
"""Groups the runtime helpers a recovery could not name, by what their machine code does.

`NativeBoundary` names a call target from evidence the binary carries - a relocation, a located key
function, a recognised instruction sequence. What is left is `UNKNOWN`: 416 calls on the test game to
addresses the export table does not name, where no managed method sits, and which no key-function
search found. Iteration 051 established that 27 of 30 such helpers cannot be named from their call
sites at all, so the remaining evidence is the code itself.

This reads the first instructions at each address and groups the addresses by what they look like, so
that a cluster can be argued about as one thing. It names nothing and rewrites nothing: a cluster is
promoted out of UNKNOWN only by a rule with binary evidence behind it, and this is the measurement
that says which clusters are worth writing one for.

Usage: cluster_runtime_boundaries.py <rip output> <libil2cpp.so> [--json out.json]
"""
import argparse
import collections
import json
import pathlib
import re
import struct
import sys

BOUNDARY = re.compile(r'Il2CppRuntime\.Boundary\("(?P<kind>[A-Z_]+)(?::[^"]*)?",\s*"[^"@]*@(?P<address>[0-9A-F]+)"\)')

# AArch64 encodings, enough to say what a function's opening does without a disassembler.
def decode(word: int) -> str:
    if word == 0xD65F03C0:
        return "RET"
    if (word >> 26) == 0b000101:
        return "B"
    if (word >> 26) == 0b100101:
        return "BL"
    if (word & 0xFFFFFC1F) == 0xD61F0000:
        return "BR"
    if (word & 0x9F000000) == 0x90000000:
        return "ADRP"
    if (word & 0xFFC00000) == 0xF9400000:
        return "LDR_imm"
    if (word & 0xFFC00000) == 0xF9000000:
        return "STR_imm"
    if (word & 0xFFC00000) == 0x91000000:
        return "ADD_imm"
    if (word & 0xFFC00000) == 0xD1000000:
        return "SUB_imm"
    if (word & 0x7FC00000) == 0x29800000 or (word & 0x7FC00000) == 0x29000000:
        return "STP"
    if (word & 0xFFE00000) == 0xA9800000 or (word & 0xFFC00000) == 0xA9000000:
        return "STP"
    if (word & 0xFFC00000) == 0xA9400000 or (word & 0xFFE00000) == 0xA8C00000:
        return "LDP"
    if (word & 0x7FE0FC00) == 0x2A0003E0:
        return "MOV_reg"
    if (word & 0x7F800000) == 0x52800000:
        return "MOVZ"
    if (word & 0x3FFF7C00) == 0x085F7C00:
        return "LDXR"
    if (word & 0x3FE07C00) == 0x08007C00:
        return "STXR"
    if (word & 0x7F000000) == 0x35000000 or (word & 0x7F000000) == 0x34000000:
        return "CBZ/CBNZ"
    if (word & 0xFF000010) == 0x54000000:
        return "B.cond"
    return "?"


def loads(data: bytes):
    e_phoff = struct.unpack_from("<Q", data, 0x20)[0]
    e_phentsize = struct.unpack_from("<H", data, 0x36)[0]
    e_phnum = struct.unpack_from("<H", data, 0x38)[0]
    segments = []
    for index in range(e_phnum):
        offset = e_phoff + index * e_phentsize
        if struct.unpack_from("<I", data, offset)[0] != 1:
            continue
        p_offset, p_vaddr = struct.unpack_from("<QQ", data, offset + 0x08)
        p_filesz = struct.unpack_from("<Q", data, offset + 0x20)[0]
        segments.append((p_vaddr, p_offset, p_filesz))
    return segments


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root")
    parser.add_argument("binary")
    parser.add_argument("--json")
    parser.add_argument("--window", type=int, default=6, help="instructions read at each address")
    arguments = parser.parse_args()

    root = pathlib.Path(arguments.root)
    binary = pathlib.Path(arguments.binary)

    if not root.is_dir() or not binary.is_file():
        print("NOT_FOUND")
        return 2

    data = binary.read_bytes()
    segments = loads(data)

    def raw(address: int):
        for vaddr, offset, size in segments:
            if vaddr <= address < vaddr + size:
                return offset + (address - vaddr)
        return None

    calls = collections.Counter()

    for path in root.rglob("*.cs"):
        for match in BOUNDARY.finditer(path.read_text(encoding="utf-8", errors="replace")):
            if match["kind"] == "UNKNOWN":
                calls[int(match["address"], 16)] += 1

    shapes = collections.defaultdict(lambda: {"addresses": [], "calls": 0})

    for address, count in calls.items():
        offset = raw(address)

        if offset is None or offset + arguments.window * 4 > len(data):
            shape = "UNMAPPED"
        else:
            words = struct.unpack_from("<" + "I" * arguments.window, data, offset)
            shape = " ".join(decode(word) for word in words)

        entry = shapes[shape]
        entry["addresses"].append(f"{address:X}")
        entry["calls"] += count

    ranked = sorted(shapes.items(), key=lambda item: -item[1]["calls"])

    print(f"UNKNOWN call sites: {sum(calls.values())} to {len(calls)} addresses, "
          f"in {len(shapes)} machine-code shapes\n")
    print(f"{'calls':>7}{'addrs':>7}  shape (first {arguments.window} instructions)")
    print("-" * 110)

    for shape, entry in ranked:
        print(f"{entry['calls']:>7}{len(entry['addresses']):>7}  {shape}")

    print("\n== the busiest addresses per shape ==")
    for shape, entry in ranked[:8]:
        print(f"  {entry['calls']:>5} calls  {', '.join('0x' + a for a in sorted(entry['addresses'])[:6])}"
              f"{' …' if len(entry['addresses']) > 6 else ''}")

    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps([
            {"shape": shape, "calls": entry["calls"], "addresses": sorted(entry["addresses"])}
            for shape, entry in ranked
        ], indent=2))

    return 0


if __name__ == "__main__":
    sys.exit(main())
