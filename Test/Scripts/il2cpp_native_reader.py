#!/usr/bin/env python3
"""An IL2CPP native table reader that shares no code with LibCpp2IL.

AssetRipper reads every native fact it recovers from - where a method's body is, where a field sits,
which generic instantiation a shared body belongs to - through one reader, LibCpp2IL. Nothing in the
pipeline checks those facts against anything else, so an error in that reader is indistinguishable
from a property of the game. This is the second reader. It exists to disagree with the first one
when the first one is wrong, so it is written from the struct layouts rather than from LibCpp2IL:

  * every struct layout (metadata header, image and type rows, Il2CppCodeRegistration,
    Il2CppMetadataRegistration, Il2CppCodeGenModule, the generic tables) comes from the struct
    database in `StructDb/`, which was measured from il2cpp's own headers per Unity version;
  * the two registration structs are found by the counts the metadata declares - a code
    registration's `codeGenModulesCount` is the number of images, a metadata registration's
    `fieldOffsetsCount` and `typeDefinitionsSizesCount` are both the number of types - and never by
    being told where they are;
  * an ELF pointer in a relocatable section is read through its `R_*_RELATIVE` relocation, because
    in the file the slot holds the addend, not the address. A reader that skips that step reads
    zeroes for every pointer in `.data.rel.ro` and cannot find either struct at all.

What it does not do is interpret. A field offset is reported exactly as the table holds it, with no
conversion into the value-type frame; a generic method table entry is reported with the spec it
names and the pointer it indexes, with no attribution to a definition. The interpretation is the
thing being checked, so it must not be in the reader.

Mach-O: segments are read from `LC_SEGMENT_64`, and a region covered by `LC_ENCRYPTION_INFO_64` with a
non-zero `cryptid` is reported as unreadable rather than read. Chained fixups are not applied; a
binary that carries `LC_DYLD_CHAINED_FIXUPS` is reported as such, and every pointer read from it is
marked unreliable.

Usage (a module; `native_cross_oracle.py` is the command):
    reader = NativeReader(binary_path, metadata_path, struct_db_dir)
"""
import bisect
import gzip
import json
import pathlib
import re
import struct

ELF_RELATIVE = {183: 1027, 62: 8, 40: 23}   # e_machine -> R_*_RELATIVE: AArch64, x86-64, ARM
PF_X = 1

LC_SEGMENT_64 = 0x19
LC_ENCRYPTION_INFO_64 = 0x2C
LC_DYLD_CHAINED_FIXUPS = 0x80000034
VM_PROT_EXECUTE = 4


class NativeImage:
    """A memory view of an ELF or Mach-O image: segments, relocated pointers, executable ranges."""

    def __init__(self, path):
        self.path = pathlib.Path(path)
        self.data = self.path.read_bytes()
        self.segments = []          # (vaddr, memsz, fileoff, filesz, executable)
        self.relocations = {}       # va -> relocated pointer value
        self.encrypted = []         # (vaddr, vaddr_end)
        self.chained_fixups = False
        self.pointer_size = 8
        magic = self.data[:4]

        if magic == b"\x7fELF":
            self.format = "ELF"
            self._read_elf()
        elif magic in (b"\xcf\xfa\xed\xfe",):
            self.format = "MachO"
            self._read_macho()
        else:
            raise ValueError(f"{path}: not an ELF or 64-bit Mach-O image")

        self.segments.sort()
        self._starts = [s[0] for s in self.segments]

    # ---- ELF -------------------------------------------------------------------------------------

    def _read_elf(self):
        d = self.data
        cls = d[4]
        self.pointer_size = 8 if cls == 2 else 4
        if cls != 2:
            raise ValueError("only 64-bit ELF is read")
        e_machine, = struct.unpack_from("<H", d, 18)
        e_phoff, = struct.unpack_from("<Q", d, 0x20)
        e_phentsize, e_phnum = struct.unpack_from("<HH", d, 0x36)
        dynamic = None

        for i in range(e_phnum):
            o = e_phoff + i * e_phentsize
            p_type, p_flags, p_offset, p_vaddr, _, p_filesz, p_memsz = struct.unpack_from("<IIQQQQQ", d, o)
            if p_type == 1:
                self.segments.append((p_vaddr, p_memsz, p_offset, p_filesz, bool(p_flags & PF_X)))
            elif p_type == 2:
                dynamic = (p_offset, p_filesz)

        self.segments.sort()
        self._starts = [s[0] for s in self.segments]
        relative = ELF_RELATIVE.get(e_machine)

        if dynamic is None or relative is None:
            return

        tags = {}
        off, size = dynamic
        for i in range(size // 16):
            tag, val = struct.unpack_from("<qQ", d, off + 16 * i)
            if tag == 0:
                break
            tags[tag] = val

        # DT_RELA / DT_RELASZ: every relative relocation is (slot, type, addend) and the slot's
        # final value is base + addend, base being zero for an image read unslid.
        if 7 in tags and 8 in tags:
            rela = self.va_to_offset(tags[7])
            for i in range(tags[8] // 24):
                r_offset, r_info, r_addend = struct.unpack_from("<QQq", d, rela + 24 * i)
                if r_info & 0xFFFFFFFF == relative:
                    self.relocations[r_offset] = r_addend & 0xFFFFFFFFFFFFFFFF

        # DT_RELR (35/36): packed relative relocations, one address then bitmaps.
        if 36 in tags and 35 in tags:
            relr = self.va_to_offset(tags[36])
            where = 0
            for i in range(tags[35] // 8):
                entry, = struct.unpack_from("<Q", d, relr + 8 * i)
                if entry & 1 == 0:
                    self._apply_relr(entry)
                    where = entry + 8
                else:
                    bits = entry >> 1
                    for k in range(63):
                        if bits & (1 << k):
                            self._apply_relr(where + 8 * k)
                    where += 8 * 63

    def _apply_relr(self, va):
        off = self.va_to_offset(va)
        if off is not None:
            self.relocations[va] = struct.unpack_from("<Q", self.data, off)[0]

    # ---- Mach-O ----------------------------------------------------------------------------------

    def _read_macho(self):
        d = self.data
        ncmds, = struct.unpack_from("<I", d, 16)
        o = 32
        crypt = None

        for _ in range(ncmds):
            cmd, cmdsize = struct.unpack_from("<II", d, o)
            if cmd == LC_SEGMENT_64:
                vmaddr, vmsize, fileoff, filesize, _, initprot = struct.unpack_from("<QQQQii", d, o + 24)
                self.segments.append((vmaddr, vmsize, fileoff, filesize, bool(initprot & VM_PROT_EXECUTE)))
            elif cmd == LC_ENCRYPTION_INFO_64:
                cryptoff, cryptsize, cryptid = struct.unpack_from("<III", d, o + 8)
                if cryptid != 0 and cryptsize:
                    crypt = (cryptoff, cryptoff + cryptsize)
            elif cmd == LC_DYLD_CHAINED_FIXUPS:
                self.chained_fixups = True
            o += cmdsize

        if crypt:
            # The encrypted range is given as file offsets; report it as virtual addresses.
            for vaddr, memsz, fileoff, filesz, _ in self.segments:
                lo, hi = max(crypt[0], fileoff), min(crypt[1], fileoff + filesz)
                if lo < hi:
                    self.encrypted.append((vaddr + lo - fileoff, vaddr + hi - fileoff))

    # ---- the view --------------------------------------------------------------------------------

    def segment_of(self, va):
        i = bisect.bisect_right(self._starts, va) - 1
        if i >= 0:
            s = self.segments[i]
            if s[0] <= va < s[0] + s[1]:
                return s
        return None

    def va_to_offset(self, va):
        s = self.segment_of(va)
        if s is None or va - s[0] >= s[3]:
            return None
        return s[2] + (va - s[0])

    def is_encrypted(self, va):
        return any(lo <= va < hi for lo, hi in self.encrypted)

    def is_code(self, va):
        s = self.segment_of(va)
        return s is not None and s[4]

    def is_data(self, va):
        return self.segment_of(va) is not None

    def read(self, va, size):
        off = self.va_to_offset(va)
        if off is None or self.is_encrypted(va):
            return None
        return self.data[off:off + size]

    def u32(self, va):
        b = self.read(va, 4)
        return None if b is None or len(b) < 4 else struct.unpack("<I", b)[0]

    def i32(self, va):
        b = self.read(va, 4)
        return None if b is None or len(b) < 4 else struct.unpack("<i", b)[0]

    def ptr(self, va):
        if va in self.relocations:
            return self.relocations[va]
        b = self.read(va, 8)
        return None if b is None or len(b) < 8 else struct.unpack("<Q", b)[0]

    def cstring(self, va, limit=256):
        b = self.read(va, limit)
        if b is None:
            return None
        end = b.find(b"\0")
        return b[: end if end >= 0 else limit].decode("utf-8", "replace")

    def aligned_hits(self, value):
        """Every pointer-aligned address in a non-executable segment whose low four bytes are `value`.

        A count is stored in an eight byte slot, so the upper half has to be zero as well; that
        second test is what makes a count-constrained scan precise enough to find one struct.
        """
        needle = struct.pack("<Q", value)
        for vaddr, memsz, fileoff, filesz, executable in self.segments:
            if executable:
                continue
            blob = self.data[fileoff:fileoff + filesz]
            at = blob.find(needle)
            while at >= 0:
                va = vaddr + at
                if va % 8 == 0:
                    yield va
                at = blob.find(needle, at + 1)


# ---- struct database ---------------------------------------------------------------------------

def version_key(text):
    m = re.match(r"(\d+)\.(\d+)\.(\d+)([abfpx])?(\d+)?", text)
    if not m:
        return (0,)
    return (int(m[1]), int(m[2]), int(m[3]), "abfpx".find(m[4] or "f"), int(m[5] or 0))


def load_struct_db(directory, unity_version):
    """The layout for this Unity version, or the nearest one in the same major.minor."""
    directory = pathlib.Path(directory)
    wanted = version_key(unity_version)
    exact = directory / f"{unity_version}-x64.json.gz"
    chosen = exact if exact.exists() else None

    if chosen is None:
        candidates = []
        for path in directory.glob("*-x64.json.gz"):
            key = version_key(path.name.split("-x64")[0])
            if key[:2] == wanted[:2]:
                candidates.append((abs(key[2] - wanted[2]), path))
        if not candidates:
            raise FileNotFoundError(f"no struct database for {unity_version}")
        chosen = min(candidates)[1]

    db = json.loads(gzip.open(chosen).read())
    return db, chosen.name.split("-x64")[0]


class Layout:
    def __init__(self, db, name):
        s = db["structs"][name]
        self.name = name
        self.size = s["size"]
        self.fields = {f["name"]: (f["offset"], f.get("size") or 4) for f in s["fields"] if f.get("bits") is None}

    def offset(self, field):
        return self.fields[field][0]


# ---- metadata ----------------------------------------------------------------------------------

class Metadata:
    """The rows of global-metadata.dat this reader needs, laid out by the struct database."""

    def __init__(self, path, db):
        d = pathlib.Path(path).read_bytes()
        self.data = d
        header = Layout(db, "Il2CppGlobalMetadataHeader")
        self.sanity, self.version = struct.unpack_from("<Ii", d, 0)
        if self.sanity != 0xFAB11BAF:
            raise ValueError(f"{path}: not il2cpp metadata")

        def section(name):
            off, = struct.unpack_from("<i", d, header.offset(name + "Offset"))
            size, = struct.unpack_from("<i", d, header.offset(name + "Size"))
            return off, size

        self.string_offset, _ = section("string")
        image = Layout(db, "Il2CppImageDefinition")
        typedef = Layout(db, "Il2CppTypeDefinition")
        method = Layout(db, "Il2CppMethodDefinition")

        def rows(name, layout):
            off, size = section(name)
            return [off + layout.size * i for i in range(size // layout.size)]

        self.images = []
        for o in rows("images", image):
            name_index, = struct.unpack_from("<i", d, o + image.offset("nameIndex"))
            type_start, type_count = struct.unpack_from("<iI", d, o + image.offset("typeStart"))
            self.images.append({"name": self.string(name_index), "typeStart": type_start, "typeCount": type_count})

        self.types = []
        for o in rows("typeDefinitions", typedef):
            field_start, = struct.unpack_from("<i", d, o + typedef.offset("fieldStart"))
            method_start, = struct.unpack_from("<i", d, o + typedef.offset("methodStart"))
            method_count, = struct.unpack_from("<H", d, o + typedef.offset("method_count"))
            field_count, = struct.unpack_from("<H", d, o + typedef.offset("field_count"))
            bitfield, = struct.unpack_from("<I", d, o + typedef.offset("bitfield"))
            container, = struct.unpack_from("<i", d, o + typedef.offset("genericContainerIndex"))
            self.types.append({"fieldStart": field_start, "fieldCount": field_count,
                               "methodStart": method_start, "methodCount": method_count,
                               "valueType": bool(bitfield & 1), "genericDefinition": container >= 0})

        field = Layout(db, "Il2CppFieldDefinition")
        self.field_type_indices = []
        for o in rows("fields", field):
            type_index, = struct.unpack_from("<i", d, o + field.offset("typeIndex"))
            self.field_type_indices.append(type_index)

        self.method_tokens = []
        for o in rows("methods", method):
            token, = struct.unpack_from("<I", d, o + method.offset("token"))
            self.method_tokens.append(token)

    def string(self, index):
        o = self.string_offset + index
        end = self.data.index(b"\0", o)
        return self.data[o:end].decode("utf-8", "replace")


# ---- the reader --------------------------------------------------------------------------------

class NativeReader:
    def __init__(self, binary_path, metadata_path, struct_db_dir, unity_version):
        self.db, self.struct_db_version = load_struct_db(struct_db_dir, unity_version)
        self.image = NativeImage(binary_path)
        self.metadata = Metadata(metadata_path, self.db)
        self.code_reg = Layout(self.db, "Il2CppCodeRegistration")
        self.meta_reg = Layout(self.db, "Il2CppMetadataRegistration")
        self.module = Layout(self.db, "Il2CppCodeGenModule")
        self.sizes = Layout(self.db, "Il2CppTypeDefinitionSizes")
        self.generic = Layout(self.db, "Il2CppGenericMethodFunctionsDefinitions")
        self.spec = Layout(self.db, "Il2CppMethodSpec")
        self.code_registration = None
        self.metadata_registration = None
        self.notes = []

    # -- discovery by count, never by being told --

    def find_code_registration(self):
        """Il2CppCodeRegistration, found by `codeGenModulesCount == len(images)`."""
        img = self.image
        count = len(self.metadata.images)
        at_count = self.code_reg.offset("codeGenModulesCount")
        at_modules = self.code_reg.offset("codeGenModules")
        found = []

        for va in img.aligned_hits(count):
            base = va - at_count
            modules = img.ptr(base + at_modules)
            if modules is None or not img.is_data(modules):
                continue
            # Every module pointer has to map, and every module has to be named after an image.
            names = set(i["name"] for i in self.metadata.images)
            ok = True
            for k in range(count):
                m = img.ptr(modules + 8 * k)
                if m is None or not img.is_data(m):
                    ok = False
                    break
                name_ptr = img.ptr(m + self.module.offset("moduleName"))
                if name_ptr is None or img.cstring(name_ptr) not in names:
                    ok = False
                    break
            if ok:
                found.append(base)

        if len(found) != 1:
            self.notes.append(f"code registration: {len(found)} candidates satisfy the image count")
        self.code_registration = found[0] if len(found) == 1 else None
        return self.code_registration

    def find_metadata_registration(self):
        """Il2CppMetadataRegistration, found by `fieldOffsetsCount == typeDefinitionsSizesCount == len(types)`."""
        img = self.image
        count = len(self.metadata.types)
        at_fields = self.meta_reg.offset("fieldOffsetsCount")
        at_sizes = self.meta_reg.offset("typeDefinitionsSizesCount")
        found = []

        for va in img.aligned_hits(count):
            base = va - at_fields
            if img.u32(base + at_sizes) != count:
                continue
            fields = img.ptr(base + self.meta_reg.offset("fieldOffsets"))
            sizes = img.ptr(base + self.meta_reg.offset("typeDefinitionsSizes"))
            if fields and sizes and img.is_data(fields) and img.is_data(sizes):
                found.append(base)

        if len(found) != 1:
            self.notes.append(f"metadata registration: {len(found)} candidates satisfy the type count")
        self.metadata_registration = found[0] if len(found) == 1 else None
        return self.metadata_registration

    # -- tables --

    def module_tables(self):
        """{module name: [method pointer per token row]} straight out of the codegen modules."""
        img = self.image
        if self.code_registration is None:
            return {}
        base = self.code_registration
        count = img.u32(base + self.code_reg.offset("codeGenModulesCount"))
        modules = img.ptr(base + self.code_reg.offset("codeGenModules"))
        by_name = {}

        for k in range(count):
            m = img.ptr(modules + 8 * k)
            name = img.cstring(img.ptr(m + self.module.offset("moduleName")))
            n = img.u32(m + self.module.offset("methodPointerCount"))
            table = img.ptr(m + self.module.offset("methodPointers"))
            by_name[name] = [img.ptr(table + 8 * i) if table else 0 for i in range(n or 0)]
        return by_name

    def sequential_join(self):
        """{method index: the module entry at the method's *row ordinal* within its image}.

        Not what il2cpp does - the runtime indexes a module by the token's row id - and reported only
        so that a reader which joins this way can be recognised as doing so.
        """
        by_name = self.module_tables()
        result = {}
        for image in self.metadata.images:
            pointers = by_name.get(image["name"], [])
            ordinal = 0
            for t in range(image["typeStart"], image["typeStart"] + image["typeCount"]):
                ty = self.metadata.types[t]
                if ty["methodStart"] < 0:
                    continue
                for m in range(ty["methodStart"], ty["methodStart"] + ty["methodCount"]):
                    result[m] = pointers[ordinal] if ordinal < len(pointers) else 0
                    ordinal += 1
        return result

    def method_pointers(self):
        """{method definition index: module entry}, joined by image name and token, never by method name.

        `methodPointers[rid - 1]` is the runtime's own rule (il2cpp's MetadataCache looks a method up
        by the row id of its token), so it is the join used here.
        """
        by_name = self.module_tables()
        result = {}
        md = self.metadata
        for image in md.images:
            pointers = by_name.get(image["name"], [])
            for t in range(image["typeStart"], image["typeStart"] + image["typeCount"]):
                ty = md.types[t]
                if ty["methodStart"] < 0:
                    continue
                for m in range(ty["methodStart"], ty["methodStart"] + ty["methodCount"]):
                    rid = md.method_tokens[m] & 0xFFFFFF
                    result[m] = pointers[rid - 1] if 0 < rid <= len(pointers) else 0
        return result

    def field_offsets(self):
        """{type index: [raw offset or None per field]}, exactly as the table holds them."""
        img = self.image
        if self.metadata_registration is None:
            return {}
        table = img.ptr(self.metadata_registration + self.meta_reg.offset("fieldOffsets"))
        result = {}
        for t, ty in enumerate(self.metadata.types):
            p = img.ptr(table + 8 * t)
            if not p:
                result[t] = [None] * ty["fieldCount"]
                continue
            result[t] = [img.i32(p + 4 * f) for f in range(ty["fieldCount"])]
        return result

    def field_is_static(self):
        """[bool per field definition]: whether the field's Il2CppType carries FIELD_ATTRIBUTE_STATIC.

        The attributes live in the binary's type pool, not in the metadata: a field definition names a
        type index, and `Il2CppMetadataRegistration.types[index]` is the Il2CppType whose low sixteen
        bits of the word after `data` are the field's attributes. A static field is laid out in static
        storage rather than in the object, so the object-header question does not apply to it.
        """
        img = self.image
        if self.metadata_registration is None:
            return []
        count = img.u32(self.metadata_registration + self.meta_reg.offset("typesCount"))
        table = img.ptr(self.metadata_registration + self.meta_reg.offset("types"))
        result = []
        for type_index in self.metadata.field_type_indices:
            if type_index is None or not 0 <= type_index < (count or 0):
                result.append(None)
                continue
            word = img.u32(img.ptr(table + 8 * type_index) + 8)
            result.append(None if word is None else bool(word & 0x10))
        return result

    def type_sizes(self):
        """{type index: [instance, native, static, thread static] or None}."""
        img = self.image
        if self.metadata_registration is None:
            return {}
        table = img.ptr(self.metadata_registration + self.meta_reg.offset("typeDefinitionsSizes"))
        result = {}
        for t in range(len(self.metadata.types)):
            p = img.ptr(table + 8 * t)
            b = img.read(p, 16) if p else None
            result[t] = list(struct.unpack("<IiII", b)) if b and len(b) == 16 else None
        return result

    def generic_methods(self):
        """[{index, spec, method, classInst, methodInst, pointerIndex, pointer}] - the table, uninterpreted."""
        img = self.image
        if self.metadata_registration is None or self.code_registration is None:
            return []
        mr, cr = self.metadata_registration, self.code_registration
        table_count = img.u32(mr + self.meta_reg.offset("genericMethodTableCount"))
        table = img.ptr(mr + self.meta_reg.offset("genericMethodTable"))
        spec_count = img.u32(mr + self.meta_reg.offset("methodSpecsCount"))
        specs = img.ptr(mr + self.meta_reg.offset("methodSpecs"))
        pointer_count = img.u32(cr + self.code_reg.offset("genericMethodPointersCount"))
        pointers = img.ptr(cr + self.code_reg.offset("genericMethodPointers"))
        g, s = self.generic, self.spec
        rows = []

        for i in range(table_count or 0):
            row = table + g.size * i
            spec_index = img.i32(row + g.offset("genericMethodIndex"))
            pointer_index = img.i32(row + g.offset("indices.methodIndex"))
            entry = {"index": i, "spec": spec_index, "pointerIndex": pointer_index,
                     "method": -1, "classInst": -1, "methodInst": -1, "pointer": 0}
            if spec_index is not None and 0 <= spec_index < (spec_count or 0):
                sp = specs + s.size * spec_index
                entry["method"] = img.i32(sp + s.offset("methodDefinitionIndex"))
                entry["classInst"] = img.i32(sp + s.offset("classIndexIndex"))
                entry["methodInst"] = img.i32(sp + s.offset("methodIndexIndex"))
            if pointer_index is not None and 0 <= pointer_index < (pointer_count or 0):
                entry["pointer"] = img.ptr(pointers + 8 * pointer_index) or 0
            rows.append(entry)
        return rows
