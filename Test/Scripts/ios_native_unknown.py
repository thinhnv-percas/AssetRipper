#!/usr/bin/env python3
"""What an iOS `__Internal` P/Invoke binds to when the symbol table no longer says.

On iOS a `[DllImport("__Internal")]` is resolved by the linker, so the engine binary holds the native
implementation - and an App Store build strips the C symbols, which is why iteration 064 could only call
three groups UNKNOWN. The binding still exists in the code: il2cpp compiles each extern method to a
wrapper that marshals the arguments and calls the implementation directly. So the implementation's
address is in the wrapper's body, and the implementation's own instructions say what it reaches: the
Objective-C selectors it sends (through `__objc_stubs` or `__objc_selrefs`), the classes it names (bound
from a framework by the dyld bind opcodes, or defined in the binary with a `class_ro_t` name), and the C
strings it loads. None of that is a symbol, and none of it was stripped.

The wrapper's call to the implementation is told from its calls to marshalling helpers by count: a helper
is called from many wrappers, the implementation from one. RayFire, whose symbols survive, is the control:
every implementation found that way must be at that entry point's own symbol.

Verdicts per entry point:
  PROVEN    the implementation is in the engine binary's own code (an LC_FUNCTION_STARTS boundary in
            __text, outside the il2cpp section) and it references at least one class, selector or string
  LINKED    the implementation is there, but references nothing that names what it is
  UNKNOWN   no wrapper call identifies an implementation

    ios_native_unknown.py <UnityFramework> <recovered game dir> [--json out] [--self-test]
"""
import collections
import json
import pathlib
import re
import struct
import sys

LC_SEGMENT_64 = 0x19
LC_SYMTAB = 0x2
LC_DYSYMTAB = 0xB
LC_DYLD_INFO_ONLY = 0x80000022
LC_FUNCTION_STARTS = 0x26
LC_LOAD_DYLIB = 0xC
LC_LOAD_WEAK_DYLIB = 0x80000018

EXTERN = re.compile(r'\[DllImport\("__Internal"[^\]]*\]\s*\[Token[^\]]*\]\s*\[Address\(RVA = "0x([0-9A-F]+)"[^\]]*\]\s*\[NativeSource\(Body = "(.*?)"\)\]\s*[^;]*?static extern [^(;]*?(\w+)\s*\(', re.S)
CALL = re.compile(r'0x([0-9A-F]+)\(')


def uleb(data, at):
    value = shift = 0
    while True:
        byte = data[at]
        at += 1
        value |= (byte & 0x7F) << shift
        shift += 7
        if byte < 0x80:
            return value, at


def sleb(data, at):
    value = shift = 0
    while True:
        byte = data[at]
        at += 1
        value |= (byte & 0x7F) << shift
        shift += 7
        if byte < 0x80:
            if byte & 0x40:
                value -= 1 << shift
            return value, at


class MachO:
    def __init__(self, data):
        self.data = data
        assert struct.unpack("<I", data[:4])[0] == 0xFEEDFACF, "a thin 64-bit Mach-O"
        ncmds = struct.unpack("<I", data[16:20])[0]
        offset = 32
        self.segments, self.sections, self.dylibs = [], {}, []
        self.symbols, self.indirect, self.function_starts = [], [], []
        self.binds = {}
        dyld_info = None
        for _ in range(ncmds):
            command, size = struct.unpack("<II", data[offset:offset + 8])
            if command == LC_SEGMENT_64:
                segname = data[offset + 8:offset + 24].split(b"\0")[0].decode()
                vmaddr, vmsize, fileoff, filesize = struct.unpack("<QQQQ", data[offset + 24:offset + 56])
                nsects = struct.unpack("<I", data[offset + 64:offset + 68])[0]
                self.segments.append((segname, vmaddr, vmsize, fileoff, filesize))
                for index in range(nsects):
                    base = offset + 72 + 80 * index
                    sectname = data[base:base + 16].split(b"\0")[0].decode()
                    addr, sectsize = struct.unpack("<QQ", data[base + 32:base + 48])
                    sectoff = struct.unpack("<I", data[base + 48:base + 52])[0]
                    reserved1, reserved2 = struct.unpack("<II", data[base + 68:base + 76])
                    self.sections[sectname] = (addr, sectsize, sectoff, reserved1, reserved2)
            elif command == LC_SYMTAB:
                symoff, nsyms, stroff, _ = struct.unpack("<IIII", data[offset + 8:offset + 24])
                for index in range(nsyms):
                    entry = symoff + 16 * index
                    strx, ntype, nsect, _desc, value = struct.unpack("<IBBhQ", data[entry:entry + 16])
                    end = data.find(b"\0", stroff + strx)
                    self.symbols.append((data[stroff + strx:end].decode("latin1"), ntype, nsect, value))
            elif command == LC_DYSYMTAB:
                fields = struct.unpack("<18I", data[offset + 8:offset + 80])
                indirectsymoff, nindirectsyms = fields[12], fields[13]
                self.indirect = list(struct.unpack(f"<{nindirectsyms}I", data[indirectsymoff:indirectsymoff + 4 * nindirectsyms]))
            elif command == LC_DYLD_INFO_ONLY:
                dyld_info = struct.unpack("<10I", data[offset + 8:offset + 48])
            elif command == LC_FUNCTION_STARTS:
                dataoff, datasize = struct.unpack("<II", data[offset + 8:offset + 16])
                text = next(s for s in self.segments if s[0] == "__TEXT")
                address, at = text[1], dataoff
                while at < dataoff + datasize:
                    delta, at = uleb(data, at)
                    if delta == 0:
                        break
                    address += delta
                    self.function_starts.append(address)
            elif command in (LC_LOAD_DYLIB, LC_LOAD_WEAK_DYLIB):
                name_offset = struct.unpack("<I", data[offset + 8:offset + 12])[0]
                self.dylibs.append(data[offset + name_offset:offset + size].split(b"\0")[0].decode())
            offset += size
        if dyld_info:
            for start, length in ((dyld_info[2], dyld_info[3]), (dyld_info[4], dyld_info[5]), (dyld_info[6], dyld_info[7])):
                if length:
                    self._binds(start, length)
        self.function_starts.sort()

    def _binds(self, start, length):
        data, at, end = self.data, start, start + length
        ordinal, symbol, segment, address = 0, "", 0, 0
        while at < end:
            byte = data[at]
            at += 1
            opcode, immediate = byte & 0xF0, byte & 0x0F
            if opcode == 0x00:
                continue  # DONE separates lazy entries; keep reading
            elif opcode == 0x10:
                ordinal = immediate
            elif opcode == 0x20:
                ordinal, at = uleb(data, at)
            elif opcode == 0x30:
                ordinal = -immediate if immediate else 0
            elif opcode == 0x40:
                stop = data.find(b"\0", at)
                symbol = data[at:stop].decode("latin1")
                at = stop + 1
            elif opcode == 0x50:
                pass
            elif opcode == 0x60:
                _, at = sleb(data, at)
            elif opcode == 0x70:
                segment = immediate
                offset, at = uleb(data, at)
                address = self.segments[segment][1] + offset
            elif opcode == 0x80:
                delta, at = uleb(data, at)
                address = (address + delta) & 0xFFFFFFFFFFFFFFFF
            elif opcode == 0x90:
                self.binds[address] = (symbol, ordinal)
                address += 8
            elif opcode == 0xA0:
                self.binds[address] = (symbol, ordinal)
                delta, at = uleb(data, at)
                address += 8 + delta
            elif opcode == 0xB0:
                self.binds[address] = (symbol, ordinal)
                address += 8 + immediate * 8
            elif opcode == 0xC0:
                count, at = uleb(data, at)
                skip, at = uleb(data, at)
                for _ in range(count):
                    self.binds[address] = (symbol, ordinal)
                    address += 8 + skip
            else:
                break

    def offset_of(self, address):
        for _name, vmaddr, vmsize, fileoff, filesize in self.segments:
            if vmaddr <= address < vmaddr + vmsize and address - vmaddr < filesize:
                return fileoff + (address - vmaddr)
        return None

    def read(self, address, size):
        offset = self.offset_of(address)
        return None if offset is None else self.data[offset:offset + size]

    def pointer(self, address):
        raw = self.read(address, 8)
        return None if raw is None else struct.unpack("<Q", raw)[0]

    def cstring(self, address):
        offset = self.offset_of(address)
        if offset is None:
            return None
        end = self.data.find(b"\0", offset, offset + 512)
        return self.data[offset:end].decode("latin1") if end > 0 else None

    def section_of(self, address):
        for name, (addr, size, *_rest) in self.sections.items():
            if addr <= address < addr + size:
                return name
        return None

    def function_bounds(self, address):
        import bisect
        index = bisect.bisect_right(self.function_starts, address) - 1
        if index < 0 or self.function_starts[index] != address:
            return None
        end = self.function_starts[index + 1] if index + 1 < len(self.function_starts) else address + 4096
        return address, end

    def stub_symbol(self, address):
        if "__stubs" not in self.sections:
            return None
        addr, size, _off, reserved1, reserved2 = self.sections["__stubs"]
        if not addr <= address < addr + size:
            return None
        index = reserved1 + (address - addr) // (reserved2 or 12)
        if index >= len(self.indirect):
            return None
        symbol_index = self.indirect[index]
        return self.symbols[symbol_index][0] if symbol_index < len(self.symbols) else None

    def class_name(self, classref):
        if classref in self.binds:
            symbol, ordinal = self.binds[classref]
            library = self.dylibs[ordinal - 1] if 0 < ordinal <= len(self.dylibs) else None
            return symbol.replace("_OBJC_CLASS_$_", ""), library
        target = self.pointer(classref)
        if not target:
            return None, None
        data = self.pointer(target + 0x20)
        if not data:
            return None, None
        name = self.pointer((data & ~7) + 0x18)
        return (self.cstring(name) if name else None), "this binary"


def decode(image, start, end):
    """References out of one function: selectors, classes, strings, imported calls."""
    found = collections.defaultdict(set)
    pages = {}
    for pc in range(start, end, 4):
        raw = image.read(pc, 4)
        if raw is None:
            break
        insn = struct.unpack("<I", raw)[0]
        if insn & 0x9F000000 == 0x90000000:  # ADRP
            immediate = ((insn >> 29) & 3) | (((insn >> 5) & 0x7FFFF) << 2)
            if immediate & (1 << 20):
                immediate -= 1 << 21
            pages[insn & 31] = (pc & ~0xFFF) + (immediate << 12)
            continue
        if insn & 0xFFC00000 == 0xF9400000 or insn & 0xFF800000 == 0x91000000:  # LDR x, [x, #imm] / ADD x, x, #imm
            rn = (insn >> 5) & 31
            if rn in pages:
                scale = 8 if insn & 0xFFC00000 == 0xF9400000 else 1
                imm = ((insn >> 10) & 0xFFF) * scale
                if scale == 1 and insn & (1 << 22):
                    imm <<= 12
                reference(image, pages[rn] + imm, found)
            continue
        if insn & 0xFC000000 == 0x94000000:  # BL
            offset = insn & 0x3FFFFFF
            if offset & (1 << 25):
                offset -= 1 << 26
            target = pc + offset * 4
            if (symbol := image.stub_symbol(target)) is not None:
                found["imports"].add(symbol)
            elif image.section_of(target) == "__objc_stubs":
                selector = objc_stub_selector(image, target)
                if selector:
                    found["selectors"].add(selector)
    return found


def objc_stub_selector(image, stub):
    first, second = (struct.unpack("<I", image.read(stub + 4 * i, 4))[0] for i in range(2))
    if first & 0x9F000000 != 0x90000000 or second & 0xFFC00000 != 0xF9400000:
        return None
    immediate = ((first >> 29) & 3) | (((first >> 5) & 0x7FFFF) << 2)
    if immediate & (1 << 20):
        immediate -= 1 << 21
    selref = (stub & ~0xFFF) + (immediate << 12) + ((second >> 10) & 0xFFF) * 8
    target = image.pointer(selref)
    return image.cstring(target) if target else None


def reference(image, address, found):
    section = image.section_of(address)
    if section == "__objc_selrefs":
        target = image.pointer(address)
        if target and (name := image.cstring(target)):
            found["selectors"].add(name)
    elif section == "__objc_classrefs":
        name, library = image.class_name(address)
        if name:
            found["classes"].add(f"{name} ({library})" if library else name)
    elif section in ("__cstring", "__cfstring"):
        text = image.cstring(address) if section == "__cstring" else None
        if section == "__cfstring":
            pointer = image.pointer(address + 16)
            text = image.cstring(pointer) if pointer else None
        if text:
            found["strings"].add(text[:60])


def analyse(binary, game):
    image = MachO(pathlib.Path(binary).read_bytes())
    il2cpp = image.sections.get("il2cpp")
    wrappers = []
    for path in sorted(pathlib.Path(game, "Assets", "Scripts").rglob("*.cs")):
        text = path.read_text(encoding="utf-8", errors="replace")
        if "__Internal" not in text:
            continue
        assembly = path.relative_to(pathlib.Path(game, "Assets", "Scripts")).parts[0]
        for rva, body, name in EXTERN.findall(text):
            wrappers.append((assembly, name, int(rva, 16), [int(t, 16) for t in CALL.findall(body)]))

    frequency = collections.Counter(target for *_rest, targets in wrappers for target in set(targets))
    symbols = {value: name for name, ntype, nsect, value in image.symbols if nsect}
    rows = []
    for assembly, name, rva, targets in wrappers:
        unique = [t for t in targets if frequency[t] == 1]
        row = {"assembly": assembly, "entry_point": name, "wrapper": hex(rva), "implementation": None, "verdict": "UNKNOWN",
               "symbol": None, "selectors": [], "classes": [], "strings": [], "imports": []}
        if len(unique) == 1:
            implementation = unique[0]
            bounds = image.function_bounds(implementation)
            in_generated = il2cpp and il2cpp[0] <= implementation < il2cpp[0] + il2cpp[1]
            if bounds and image.section_of(implementation) == "__text" and not in_generated:
                row["implementation"] = hex(implementation)
                row["symbol"] = symbols.get(implementation)
                found = decode(image, *bounds)
                for key in ("selectors", "classes", "strings", "imports"):
                    row[key] = sorted(found[key])
                row["verdict"] = "PROVEN" if found["selectors"] or found["classes"] or found["strings"] else "LINKED"
        rows.append(row)
    return {"binary": str(binary), "dylibs": image.dylibs, "function_starts": len(image.function_starts), "rows": rows}


def self_test():
    cases = []
    # ULEB/SLEB as dyld writes them.
    cases.append(("uleb 624485", uleb(bytes([0xE5, 0x8E, 0x26]), 0)[0] == 624485))
    cases.append(("sleb -123456", sleb(bytes([0xC0, 0xBB, 0x78]), 0)[0] == -123456))
    # A helper called from two wrappers is not an implementation; a target called from one is.
    targets = [("A", "f", 1, [0x10, 0x99]), ("A", "g", 2, [0x10, 0x98])]
    frequency = collections.Counter(t for *_r, ts in targets for t in set(ts))
    cases.append(("the shared helper is not the implementation", [t for t in targets[0][3] if frequency[t] == 1] == [0x99]))
    failures = sum(not ok for _, ok in cases)
    for name, ok in cases:
        print(f"{'PASS' if ok else 'FAIL'} {name}")
    print(f"{len(cases) - failures} of {len(cases)} pass")
    return 1 if failures else 0


def main(argv):
    if "--self-test" in argv:
        return self_test()
    if len(argv) < 3:
        print(__doc__)
        return 2
    result = analyse(argv[1], argv[2])
    if "--json" in argv:
        pathlib.Path(argv[argv.index("--json") + 1]).write_text(json.dumps(result, indent=1))
    by_group = collections.defaultdict(collections.Counter)
    for row in result["rows"]:
        by_group[row["assembly"]][row["verdict"]] += 1
    print(f"function starts {result['function_starts']}, dylibs {len(result['dylibs'])}")
    for assembly, counts in sorted(by_group.items()):
        print(f"{assembly:30} {dict(counts)}")
    for row in result["rows"]:
        detail = "; ".join(f"{k}={','.join(row[k][:4])}" for k in ("classes", "selectors", "strings", "imports") if row[k])
        print(f"  {row['verdict']:8} {row['assembly']:24} {row['entry_point']:40} impl={row['implementation']} sym={row['symbol']} {detail[:220]}")
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
