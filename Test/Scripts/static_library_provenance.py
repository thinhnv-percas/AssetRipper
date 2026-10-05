#!/usr/bin/env python3
"""Whether a static library is the one a shipped Mach-O binary linked, read from the machine code.

A static archive leaves no file in the package: the linker copies the object code it needs into the
engine binary and the archive is gone. So "the build used this archive" cannot be answered by a file
listing, and a symbol table only says the *names* are there. What can answer it is the code itself: an
object file's function and the same function in the linked binary are the same bytes, except where the
linker patched an address in - and the object file says exactly where that is, in its relocations.

For each entry point the managed code P/Invokes, this finds the object member of the archive that
defines it, takes the function's bytes out of that member's __text, takes the bytes at the same symbol
out of the linked binary, and compares them four bytes at a time, skipping every word a relocation
covers. A function is BYTE_IDENTICAL when every unrelocated word agrees, DIFFERENT otherwise, and
NOT_IN_TARGET / NOT_IN_ARCHIVE when either side lacks the symbol. Nothing is inferred from a name, a
size or a version string.

    static_library_provenance.py <archive.a> <linked Mach-O> [--entries a,b,c | --game <recovered game dir> --assembly <name>] [--json out]
                                 [--preserve <recovered game dir>]
    static_library_provenance.py --self-test

--preserve copies the archive (and the .meta beside it, which carries Unity's plugin import settings) into
`Assets/Plugins/iOS/<name>` of a recovered project, with `<name>.provenance.json` recording this report -
and only when the verdict is LINKED_ARCHIVE_PROVEN. An archive from outside the package is never placed in a
project on a name match, a symbol match or a version string.

Only a slice whose CPU type matches the linked binary's is compared; the others are listed with their
architecture, which is the "architecture compatible" half of the question.
"""
import hashlib
import json
import pathlib
import re
import struct
import sys

CPU_ARM64 = 0x0100000C
CPU_ARM = 12
CPU_NAMES = {CPU_ARM64: "arm64", CPU_ARM: "armv7", 7: "i386", 0x01000007: "x86_64"}
MH_MAGIC_64 = 0xFEEDFACF
LC_SEGMENT_64 = 0x19
LC_SYMTAB = 0x2
LC_BUILD_VERSION = 0x32
N_TYPE = 0x0E
N_SECT = 0x0E
N_EXT = 0x01
N_STAB = 0xE0
PLATFORMS = {1: "macos", 2: "ios", 3: "tvos", 4: "watchos", 6: "maccatalyst", 7: "ios-simulator"}


def fat_slices(data):
    """[(cputype, offset, size)] of a universal file, or one slice for a thin file."""
    if data[:4] == b"\xca\xfe\xba\xbe":
        (count,) = struct.unpack(">I", data[4:8])
        slices = []
        for index in range(count):
            cputype, _sub, offset, size, _align = struct.unpack(">iiIII", data[8 + 20 * index:28 + 20 * index])
            slices.append((cputype & 0xFFFFFFFF, offset, size))
        return slices
    if data[:8] == b"!<arch>\n":
        return [(None, 0, len(data))]
    if struct.unpack("<I", data[:4])[0] == MH_MAGIC_64:
        (cputype,) = struct.unpack("<i", data[4:8])
        return [(cputype & 0xFFFFFFFF, 0, len(data))]
    return []


def ar_members(data):
    """[(name, bytes)] of a BSD `ar` archive; `#1/<n>` names are stored in front of the member data."""
    if data[:8] != b"!<arch>\n":
        return []
    members, offset = [], 8
    while offset + 60 <= len(data):
        header = data[offset:offset + 60]
        name = header[:16].decode("latin1").strip()
        size = int(header[48:58].decode("latin1").strip() or 0)
        body = data[offset + 60:offset + 60 + size]
        if name.startswith("#1/"):
            length = int(name[3:])
            name = body[:length].split(b"\0", 1)[0].decode("latin1")
            body = body[length:]
        members.append((name, body))
        offset += 60 + size + (size & 1)
    return members


def mach_o(data):
    """Sections, symbols and build version of a 64-bit Mach-O (object or image), or None."""
    if len(data) < 32 or struct.unpack("<I", data[:4])[0] != MH_MAGIC_64:
        return None
    cputype, _sub, filetype, ncmds, _size, _flags = struct.unpack("<iiIIII", data[4:28])
    offset = 32
    sections, segments, symbols, build = [], [], [], None
    for _ in range(ncmds):
        command, size = struct.unpack("<II", data[offset:offset + 8])
        if command == LC_SEGMENT_64:
            segname = data[offset + 8:offset + 24].split(b"\0", 1)[0].decode("latin1")
            vmaddr, vmsize, fileoff, filesize = struct.unpack("<QQQQ", data[offset + 24:offset + 56])
            nsects = struct.unpack("<I", data[offset + 64:offset + 68])[0]
            segments.append((segname, vmaddr, vmsize, fileoff, filesize))
            for index in range(nsects):
                base = offset + 72 + 80 * index
                sectname = data[base:base + 16].split(b"\0", 1)[0].decode("latin1")
                sectseg = data[base + 16:base + 32].split(b"\0", 1)[0].decode("latin1")
                addr, sectsize = struct.unpack("<QQ", data[base + 32:base + 48])
                sectoff, _align, reloff, nreloc = struct.unpack("<IIII", data[base + 48:base + 64])
                sections.append({"segment": sectseg, "name": sectname, "addr": addr, "size": sectsize,
                                 "offset": sectoff, "reloff": reloff, "nreloc": nreloc})
        elif command == LC_SYMTAB:
            symoff, nsyms, stroff, _strsize = struct.unpack("<IIII", data[offset + 8:offset + 24])
            for index in range(nsyms):
                entry = symoff + 16 * index
                strx, ntype, nsect, _desc, value = struct.unpack("<IBBhQ", data[entry:entry + 16])
                end = data.find(b"\0", stroff + strx)
                symbols.append({"name": data[stroff + strx:end].decode("latin1"), "type": ntype,
                                "sect": nsect, "value": value})
        elif command == LC_BUILD_VERSION:
            platform, minos, sdk = struct.unpack("<III", data[offset + 8:offset + 20])
            build = {"platform": PLATFORMS.get(platform, str(platform)),
                     "minos": f"{minos >> 16}.{(minos >> 8) & 0xFF}", "sdk": f"{sdk >> 16}.{(sdk >> 8) & 0xFF}"}
        offset += size
    return {"cputype": cputype & 0xFFFFFFFF, "filetype": filetype, "sections": sections,
            "segments": segments, "symbols": symbols, "build": build}


def defined(symbol):
    return symbol["type"] & N_STAB == 0 and symbol["type"] & N_TYPE == N_SECT


def object_function(member, name):
    """(bytes, relocated word offsets) of a function defined in an object, or None."""
    parsed = mach_o(member)
    if parsed is None:
        return None
    target = next((s for s in parsed["symbols"] if s["name"] == name and defined(s) and s["type"] & N_EXT), None)
    if target is None:
        return None
    section = parsed["sections"][target["sect"] - 1]
    # A function ends where the next symbol in the same section starts, or at the section's end.
    starts = sorted({s["value"] for s in parsed["symbols"] if defined(s) and s["sect"] == target["sect"] and s["value"] > target["value"]})
    end = starts[0] if starts else section["addr"] + section["size"]
    start_in_section = target["value"] - section["addr"]
    code = member[section["offset"] + start_in_section:section["offset"] + (end - section["addr"])]
    relocated = set()
    for index in range(section["nreloc"]):
        entry = section["reloff"] + 8 * index
        (address,) = struct.unpack("<i", member[entry:entry + 4])
        if start_in_section <= address < end - section["addr"]:
            relocated.add((address - start_in_section) & ~3)
    return code, relocated


def linked_function(image, data, name, length):
    """The bytes at a defined symbol of a linked image, or None."""
    symbol = next((s for s in image["symbols"] if s["name"] == name and defined(s)), None)
    if symbol is None:
        return None
    for _segname, vmaddr, vmsize, fileoff, _filesize in image["segments"]:
        if vmaddr <= symbol["value"] < vmaddr + vmsize:
            start = fileoff + (symbol["value"] - vmaddr)
            return data[start:start + length]
    return None


def compare(code, relocated, linked):
    """(words, masked, differing) for two equal-length code blocks, skipping relocated words."""
    words = len(code) // 4
    differing = 0
    for word in range(words):
        if word * 4 in relocated:
            continue
        if code[word * 4:word * 4 + 4] != linked[word * 4:word * 4 + 4]:
            differing += 1
    return words, len(relocated), differing


def entries_from_game(game, assembly):
    """The `__Internal` entry points one recovered assembly P/Invokes."""
    pattern = re.compile(r'\[DllImport\("__Internal"(?:[^\]]*?EntryPoint\s*=\s*"(?P<entry>[^"]+)")?[^\]]*\][\s\S]{0,600}?static\s+extern\s+[^(;{]*?(?P<method>\w+)\s*\(')
    found = []
    root = pathlib.Path(game) / "Assets" / "Scripts" / assembly
    for path in sorted(root.rglob("*.cs")):
        for match in pattern.finditer(path.read_text(encoding="utf-8", errors="replace")):
            found.append(match.group("entry") or match.group("method"))
    return sorted(set(found))


def analyse(archive_path, linked_path, entries):
    archive = pathlib.Path(archive_path).read_bytes()
    linked = pathlib.Path(linked_path).read_bytes()
    linked_slices = fat_slices(linked)
    report = {
        "archive": {"path": str(archive_path), "sha256": hashlib.sha256(archive).hexdigest(),
                    "git_blob": hashlib.sha1(b"blob %d\0" % len(archive) + archive).hexdigest(), "slices": []},
        "linked": {"path": str(linked_path), "sha256": hashlib.sha256(linked).hexdigest(),
                   "architectures": [CPU_NAMES.get(c, hex(c)) for c, _, _ in linked_slices]},
        "entries": [],
    }

    images = {}
    for cputype, offset, size in linked_slices:
        image = mach_o(linked[offset:offset + size])
        if image is not None:
            images[cputype] = (image, linked[offset:offset + size])

    compared_slice = None
    for cputype, offset, size in fat_slices(archive):
        members = ar_members(archive[offset:offset + size])
        objects = [(name, body) for name, body in members if not name.startswith("__.SYMDEF")]
        builds = sorted({json.dumps(p["build"], sort_keys=True) for _, body in objects if (p := mach_o(body)) and p["build"]})
        report["archive"]["slices"].append({
            "architecture": CPU_NAMES.get(cputype, hex(cputype or 0)), "size": size, "members": len(objects),
            "build_versions": [json.loads(b) for b in builds], "compatible_with_linked": cputype in images,
        })
        if cputype in images and compared_slice is None:
            compared_slice = (cputype, objects)

    if compared_slice is None:
        report["verdict"] = "ARCHITECTURE_INCOMPATIBLE"
        return report

    cputype, objects = compared_slice
    image, image_data = images[cputype]
    for entry in entries:
        name = "_" + entry
        row = {"entry_point": entry, "member": None, "bytes": 0, "words": 0, "relocated": 0, "differing": None}
        for member_name, body in objects:
            found = object_function(body, name)
            if found is None:
                continue
            code, relocated = found
            row["member"], row["bytes"] = member_name, len(code)
            target = linked_function(image, image_data, name, len(code))
            if target is None or len(target) < len(code):
                row["verdict"] = "NOT_IN_TARGET"
            else:
                row["words"], row["relocated"], row["differing"] = compare(code, relocated, target)
                row["verdict"] = "BYTE_IDENTICAL" if row["differing"] == 0 else "DIFFERENT"
            break
        else:
            row["verdict"] = "NOT_IN_ARCHIVE"
        report["entries"].append(row)

    verdicts = [row["verdict"] for row in report["entries"]]
    identical = verdicts.count("BYTE_IDENTICAL")
    report["summary"] = {verdict: verdicts.count(verdict) for verdict in sorted(set(verdicts))}
    report["verdict"] = ("LINKED_ARCHIVE_PROVEN" if entries and identical == len(entries)
                         else "PARTIAL_MATCH" if identical else "NOT_PROVEN")
    return report


def preserve(report, archive_path, game):
    """Copy a proven archive into a recovered project; returns the destination or None."""
    if report.get("verdict") != "LINKED_ARCHIVE_PROVEN":
        return None
    source = pathlib.Path(archive_path)
    destination = pathlib.Path(game) / "Assets" / "Plugins" / "iOS" / source.name
    destination.parent.mkdir(parents=True, exist_ok=True)
    destination.write_bytes(source.read_bytes())
    meta = source.with_name(source.name + ".meta")
    if meta.exists():
        destination.with_name(destination.name + ".meta").write_bytes(meta.read_bytes())
    destination.with_name(destination.name + ".provenance.json").write_text(json.dumps(report, indent=1))
    return destination


def _object(symbols, code, relocations):
    """A minimal arm64 MH_OBJECT with one __text section, for the self-test."""
    nsyms = len(symbols)
    header_size = 32 + 72 + 80 + 24
    text_off = header_size
    reloff = text_off + len(code)
    symoff = reloff + 8 * len(relocations)
    strtab = b"\0" + b"".join(n.encode() + b"\0" for n, _ in symbols)
    stroff = symoff + 16 * nsyms
    out = struct.pack("<IiiIIII", MH_MAGIC_64, CPU_ARM64, 0, 1, 2, 72 + 80 + 24, 0) + b"\0" * 4
    out += struct.pack("<II16sQQQQIIII", LC_SEGMENT_64, 72 + 80, b"", 0, len(code), text_off, len(code), 7, 7, 1, 0)
    out += struct.pack("<16s16sQQIIIIIIII", b"__text", b"__TEXT", 0, len(code), text_off, 2, reloff, len(relocations), 0, 0, 0, 0)
    out += struct.pack("<IIIIII", LC_SYMTAB, 24, symoff, nsyms, stroff, len(strtab))
    out += code
    for address in relocations:
        out += struct.pack("<iI", address, 0)
    strx = 1
    for name, value in symbols:
        out += struct.pack("<IBBhQ", strx, N_SECT | N_EXT, 1, 0, value)
        strx += len(name) + 1
    return out + strtab


def self_test():
    code = bytes(range(16))
    obj = _object([("_f", 0), ("_g", 8)], code, [4])
    cases = []
    found = object_function(obj, "_f")
    cases.append(("function ends at the next symbol", found is not None and found[0] == code[:8]))
    cases.append(("a relocation is masked by word", found is not None and found[1] == {4}))
    words, masked, differing = compare(code[:8], {4}, code[:4] + b"\xff\xff\xff\xff")
    cases.append(("a difference under a relocation does not count", differing == 0))
    words, masked, differing = compare(code[:8], set(), code[:4] + b"\xff\xff\xff\xff")
    cases.append(("a difference outside a relocation counts", differing == 1))
    member = b"!<arch>\n" + b"#1/8".ljust(16) + b"0".ljust(12) + b"0".ljust(6) + b"0".ljust(6) + b"644".ljust(8) + str(8 + len(obj)).encode().ljust(10) + b"`\n" + b"a.o\0\0\0\0\0" + obj
    cases.append(("a BSD long member name is read from the data", [n for n, _ in ar_members(member)] == ["a.o"]))
    failures = 0
    for name, ok in cases:
        failures += not ok
        print(f"{'PASS' if ok else 'FAIL'} {name}")
    print(f"{len(cases) - failures} of {len(cases)} pass")
    return 1 if failures else 0


def main(argv):
    if "--self-test" in argv:
        return self_test()
    if len(argv) < 3:
        print(__doc__)
        return 2
    if "--entries" in argv:
        entries = argv[argv.index("--entries") + 1].split(",")
    elif "--game" in argv:
        entries = entries_from_game(argv[argv.index("--game") + 1], argv[argv.index("--assembly") + 1])
    else:
        print("give --entries or --game/--assembly")
        return 2
    report = analyse(argv[1], argv[2], entries)
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(report, indent=1))
    print(f"archive {report['archive']['git_blob']} (git blob), sha256 {report['archive']['sha256']}")
    for piece in report["archive"]["slices"]:
        print(f"  slice {piece['architecture']}: {piece['members']} members, build {piece['build_versions']}, compatible {piece['compatible_with_linked']}")
    print(f"linked {report['linked']['architectures']}")
    for row in report["entries"]:
        print(f"  {row['verdict']:16} {row['entry_point']:40} {row['member'] or '-':24} words {row['words']} relocated {row['relocated']} differing {row['differing']}")
    print(f"summary {report.get('summary')}  verdict {report['verdict']}")
    if "--preserve" in argv:
        placed = preserve(report, argv[1], argv[argv.index("--preserve") + 1])
        print(f"preserved at {placed}" if placed else "not preserved: provenance not proven")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
