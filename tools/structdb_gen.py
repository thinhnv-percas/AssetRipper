#!/usr/bin/env python3
"""
Sinh struct DB cho structdb/ từ header libil2cpp của một bản Unity Editor.

Vì sao cần
----------
Bộ lift IL2CPP phải biết layout struct runtime để dịch `LDR x8, [x0, #0x18]`
thành `methodInfo->klass`. DevXUnity-Unpacker bán kèm 368 file `.dvxil2c` mã hoá,
dừng ở Unity 2021.2. Nhưng **Unity ship nguyên source runtime IL2CPP kèm Editor**,
nên không cần reverse gì cả:

    <Unity>/Editor/Data/il2cpp/libil2cpp/

Tool này biên dịch bộ header đó bằng chính clang trong NDK đi kèm Unity, rồi đọc
layout ra JSON. Xem structdb/README.md để biết schema, IL2CPP-REBUILD-GUIDE.md §10
để biết nó nằm ở đâu trong pipeline.

Ba lượt clang
-------------
`-Xclang -fdump-record-layouts` CHỈ in layout của struct/union. Enum, macro và
typedef nằm ở chỗ khác, nên phải chạy thêm hai lượt:

    1. -Xclang -fdump-record-layouts -c   -> sizeof/offset của struct
    2. -Xclang -ast-dump -fsyntax-only    -> EnumDecl (kèm giá trị), TypedefDecl
    3. -dM -E                             -> macro object-like

Bảy cái bẫy đã gặp (đừng bỏ cái nào)
------------------------------------
1. `-fsyntax-only` KHÔNG in layout gì cả. Phải dùng `-c` (hoặc `-emit-llvm -S`).
2. Nhiều struct IL2CPP có field `const` -> default constructor bị xoá, khai báo
   biến toàn cục để ép layout sẽ lỗi. Dùng `char x[sizeof(T)];` thay thế.
3. Clang in offset TUYỆT ĐỐI cho cả thành viên lồng nhau. Cộng thêm offset của
   struct cha là sai (lỗi cộng hai lần).
4. Aggregate vô danh KHÔNG có tên thành viên thì truy cập không có tiền tố:
   `union Il2CppObject::(anonymous at ...)`      -> obj.klass
   `union Il2CppType::(anonymous at ...) data`   -> data.dummy
5. Con trỏ hàm in ra `struct X *(*)(Y *)` — bắt đầu bằng "struct " nhưng KHÔNG
   phải forward declaration. Phải kiểm tra '(' TRƯỚC khi xét tiền tố struct/union.
6. Bitfield: clang cho (byteOffset, bitStart) tương đối theo byte đó. DB này dùng
   quy ước của DevX: offset = byte đầu của cụm bitfield liền nhau, bitOffset =
   vị trí bit tuyệt đối trừ đi offset*8. Trường bitOrdinal chỉ là số thứ tự.
7. Clang chỉ in tên file ở decl ĐẦU TIÊN của mỗi file, các decl sau dùng dạng
   rút gọn `line:N:C`. Đừng lọc theo vị trí — lọc theo tên.

Cách dùng
---------
    python tools/structdb_gen.py list
    python tools/structdb_gen.py gen 2022.3.62f2
    python tools/structdb_gen.py gen --all
    python tools/structdb_gen.py verify 2022.3.62f2
    python tools/structdb_gen.py index
"""
import argparse
import datetime
import json
import os
import re
import subprocess
import sys
import tempfile

# --------------------------------------------------------------------------- #
# Cấu hình

REPO = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
DEFAULT_OUT = os.path.join(REPO, "structdb")

UNITY_ROOTS = [
    r"C:/Program Files/Unity/Hub/Editor",
    r"C:/Program Files/Unity Hub/Editor",
    os.path.expanduser("~/Unity/Hub/Editor"),
    "/Applications/Unity/Hub/Editor",
]

# (tag, clang target, pointerSize, longSize)
ARCHS = [
    ("x64", "aarch64-linux-android21", 8, 8),
    ("x32", "armv7a-linux-androideabi21", 4, 4),
]

HEADERS = [
    "il2cpp-config.h",
    "il2cpp-api-types.h",
    "il2cpp-blob.h",
    "il2cpp-metadata.h",
    "il2cpp-runtime-metadata.h",
    "il2cpp-class-internals.h",
    "il2cpp-object-internals.h",
    "il2cpp-tabledefs.h",
    "vm/GlobalMetadataFileInternals.h",
]

# Struct cần lấy. Cái nào không tồn tại ở một phiên bản sẽ tự bị loại
# (xem resolve_struct_list) — cứ liệt kê thoải mái.
WANTED = """
EventInfo FieldInfo MethodInfo PropertyInfo VirtualInvokeData
Il2CppArrayType Il2CppAssembly Il2CppAssemblyDefinition Il2CppAssemblyName
Il2CppAssemblyNameDefinition Il2CppCatchPoint Il2CppClass Il2CppCodeGenModule
Il2CppCodeGenOptions Il2CppCodeRegistration Il2CppCustomAttributeDataRange
Il2CppCustomAttributeTypeRange Il2CppDebuggerMetadataRegistration Il2CppDefaults
Il2CppDomain Il2CppEventDefinition Il2CppFieldDefaultValue Il2CppFieldDefinition
Il2CppFieldMarshaledSize Il2CppFieldRef Il2CppGenericClass Il2CppGenericContainer
Il2CppGenericContext Il2CppGenericInst Il2CppGenericMethod
Il2CppGenericMethodFunctionsDefinitions Il2CppGenericMethodIndices
Il2CppGenericParameter Il2CppGenericParameterInfo Il2CppGlobalMetadataHeader
Il2CppImage Il2CppImageDefinition Il2CppInterfaceOffsetInfo
Il2CppInterfaceOffsetPair Il2CppMetadataEventInfo Il2CppMetadataFieldInfo
Il2CppMetadataMethodInfo Il2CppMetadataParameterInfo Il2CppMetadataPropertyInfo
Il2CppMetadataRange Il2CppMetadataRegistration Il2CppMetadataUsageList
Il2CppMetadataUsagePair Il2CppMethodDefinition Il2CppMethodExecutionContextInfo
Il2CppMethodExecutionContextInfoIndex Il2CppMethodHeaderInfo Il2CppMethodScope
Il2CppMethodSpec Il2CppParameterDefaultValue Il2CppParameterDefinition
Il2CppPerfCounters Il2CppPropertyDefinition Il2CppRGCTXConstrainedData
Il2CppRGCTXData Il2CppRGCTXDefinition Il2CppRGCTXDefinitionData Il2CppRange
Il2CppRuntimeInterfaceOffsetPair Il2CppSectionMetadata Il2CppSequencePoint
Il2CppSequencePointSourceFile Il2CppStringLiteral Il2CppTokenAdjustorThunkPair
Il2CppTokenIndexMethodTuple Il2CppTokenIndexPair Il2CppTokenRangePair Il2CppType
Il2CppTypeDefinition Il2CppTypeDefinitionSizes Il2CppTypeSourceFilePair
Il2CppWindowsRuntimeFactoryTableEntry Il2CppWindowsRuntimeTypeNamePair
GenericParameterFlags
Il2CppObject Il2CppString Il2CppArray Il2CppArrayBounds Il2CppArraySize
Il2CppReflectionType Il2CppReflectionMethod Il2CppReflectionField
Il2CppDelegate Il2CppMulticastDelegate Il2CppException Il2CppThread
Il2CppAppDomain Il2CppAppContext Il2CppCustomAttributesCache Il2CppMonitor
Il2CppNameToTypeDefinitionIndexHashTable Il2CppIntPtr Il2CppGuid Il2CppInteropData
""".split()

# Enum quan trọng về ngữ nghĩa nhưng không xuất hiện làm kiểu field.
KEEP_ENUMS = {"MethodVariableKind", "SequencePointKind", "Il2CppTypeNameFormat"}

PRIM = {
    "bool": 1, "char": 1, "signed char": 1, "unsigned char": 1, "_Bool": 1,
    "int8_t": 1, "uint8_t": 1, "void": 0,
    "short": 2, "unsigned short": 2, "int16_t": 2, "uint16_t": 2, "char16_t": 2,
    "int": 4, "unsigned int": 4, "int32_t": 4, "uint32_t": 4, "float": 4,
    "long long": 8, "unsigned long long": 8, "int64_t": 8, "uint64_t": 8, "double": 8,
}
LONG_LIKE = {"long", "unsigned long", "size_t", "intptr_t", "uintptr_t", "ptrdiff_t"}
STD_TYPEDEF = re.compile(
    r"^(u?int(8|16|32|64|ptr|max|_least\d+|_fast\d+)_t|size_t|ssize_t|ptrdiff_t"
    r"|wchar_t|char16_t|char32_t|__\w+)$")


# --------------------------------------------------------------------------- #
# Tìm Unity

def find_unity_installs():
    out = {}
    for root in UNITY_ROOTS:
        if not os.path.isdir(root):
            continue
        for name in sorted(os.listdir(root)):
            lib = os.path.join(root, name, "Editor/Data/il2cpp/libil2cpp")
            if os.path.isdir(lib):
                out[name] = os.path.join(root, name)
    return out


def find_clang(unity_dir):
    """clang trong NDK đi kèm Unity; nếu không có thì mượn của bản Unity khác."""
    rel = ("Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/"
           "prebuilt/%s/bin/clang%s")
    for host, ext in (("windows-x86_64", ".exe"), ("darwin-x86_64", ""), ("linux-x86_64", "")):
        p = os.path.join(unity_dir, rel % (host, ext))
        if os.path.isfile(p):
            return p
    for other in find_unity_installs().values():
        if other == unity_dir:
            continue
        for host, ext in (("windows-x86_64", ".exe"), ("darwin-x86_64", ""), ("linux-x86_64", "")):
            p = os.path.join(other, rel % (host, ext))
            if os.path.isfile(p):
                return p
    return None


def metadata_version(libil2cpp):
    """Số version metadata mà bản Unity này phát ra (runtime tự assert giá trị đó)."""
    p = os.path.join(libil2cpp, "vm", "GlobalMetadata.cpp")
    if not os.path.isfile(p):
        return 0
    txt = open(p, encoding="utf-8", errors="replace").read()
    m = re.search(r"s_GlobalMetadataHeader->version\s*==\s*(\d+)", txt)
    return int(m.group(1)) if m else 0


# --------------------------------------------------------------------------- #
# Chạy clang

def _run(cmd):
    return subprocess.run(cmd, capture_output=True, text=True, errors="replace")


def _includes(lib):
    return ["-I", lib, "-I", os.path.join(lib, "pch")]


def _write_includes(f):
    for h in HEADERS:
        f.write('#include "%s"\n' % h)


def compile_layouts(clang, lib, target, workdir, names):
    """Bẫy #1: phải -c, không phải -fsyntax-only. Bẫy #2: ép layout bằng sizeof."""
    src = os.path.join(workdir, "probe.cpp")
    with open(src, "w", encoding="utf-8") as f:
        _write_includes(f)
        f.write("\n")
        for i, n in enumerate(names):
            f.write("char force_%d[sizeof(%s)];\n" % (i, n))
            f.write("char align_%d[__alignof__(%s)];\n" % (i, n))
        f.write("\nint main(){return 0;}\n")
    p = _run([clang, "-x", "c++", "-std=c++11", "-target", target] + _includes(lib) +
             ["-Wno-everything", "-Xclang", "-fdump-record-layouts",
              "-c", "-o", os.path.join(workdir, "probe.o"), src])
    return p.returncode, p.stdout, p.stderr


MISSING_RE = re.compile(
    r"(?:unknown type name|use of undeclared identifier|incomplete type"
    r"|does not name a type|no type named)[^\n]*?'([A-Za-z_]\w*)'")


def resolve_struct_list(clang, lib, target, workdir, names, quiet=False):
    """Bỏ dần struct không tồn tại ở phiên bản này cho tới khi biên dịch sạch."""
    names, dropped = sorted(set(names)), []
    for _ in range(len(names) + 2):
        rc, out, err = compile_layouts(clang, lib, target, workdir, names)
        if rc == 0:
            return names, dropped, out
        hit = [n for n in names if n in set(MISSING_RE.findall(err))]
        if not hit:
            sys.stderr.write("clang lỗi không parse được:\n" + err[:3000] + "\n")
            return None, dropped, None
        for n in hit:
            names.remove(n)
            dropped.append(n)
    return None, dropped, None


def measure_types(clang, lib, target, workdir, type_names):
    """Hỏi clang sizeof của typedef/enum (không phải record) bằng cách bọc vào struct."""
    names = list(type_names)
    out = None
    for _ in range(len(names) + 2):
        if not names:
            return {}
        src = os.path.join(workdir, "sizeprobe.cpp")
        with open(src, "w", encoding="utf-8") as f:
            _write_includes(f)
            f.write("\n")
            for i, n in enumerate(names):
                f.write("struct __szprobe_%d { %s x; };\n" % (i, n))
                f.write("char __f_%d[sizeof(__szprobe_%d)];\n" % (i, i))
            f.write("\nint main(){return 0;}\n")
        p = _run([clang, "-x", "c++", "-std=c++11", "-target", target] + _includes(lib) +
                 ["-Wno-everything", "-Xclang", "-fdump-record-layouts",
                  "-c", "-o", os.path.join(workdir, "sizeprobe.o"), src])
        if p.returncode == 0:
            out = p.stdout
            break
        bad = set(MISSING_RE.findall(p.stderr))
        for m in re.finditer(r"__szprobe_(\d+)", p.stderr):
            i = int(m.group(1))
            if i < len(names):
                bad.add(names[i])
        hit = [n for n in names if n in bad]
        if not hit:
            return {}
        for n in hit:
            names.remove(n)
    if out is None:
        return {}
    sizes = {}
    for name, rec in parse_layout_blocks(out).items():
        m = re.fullmatch(r"__szprobe_(\d+)", name)
        if m and int(m.group(1)) < len(names):
            sizes[names[int(m.group(1))]] = rec["size"]
    return sizes


def ast_dump(clang, lib, target, workdir):
    src = os.path.join(workdir, "ast.cpp")
    with open(src, "w", encoding="utf-8") as f:
        _write_includes(f)
    return _run([clang, "-x", "c++", "-std=c++11", "-target", target] + _includes(lib) +
                ["-Wno-everything", "-fsyntax-only", "-Xclang", "-ast-dump", src]).stdout


def macro_dump(clang, lib, target, workdir):
    src = os.path.join(workdir, "ast.cpp")
    out = {}
    for line in _run([clang, "-x", "c++", "-std=c++11", "-target", target] + _includes(lib) +
                     ["-Wno-everything", "-dM", "-E", src]).stdout.split("\n"):
        m = re.match(r"^#define\s+(\w+)\s+(.*)$", line.strip())
        if m:
            out[m.group(1)] = m.group(2).strip()
    return out


# --------------------------------------------------------------------------- #
# Parse layout

HEAD_RE = re.compile(r"^\s*(\d+)\s*\|\s*(struct|class|union)\s+(.+?)\s*$")
MEMBER_RE = re.compile(r"^(\s*)(\d+)(?::(\d+)-(\d+))?\s*\|(\s+)(.*?)\s*$")
SIZE_RE = re.compile(r"\[sizeof=(\d+), dsize=(\d+), align=(\d+)")


def parse_layout_blocks(text):
    """{tên: {size, align, kind, members}} — members là cây lồng nhau."""
    blocks, cur = [], None
    for line in text.split("\n"):
        if "*** Dumping IRgen Record Layout" in line:
            break                                   # phần IRgen không cần
        if "*** Dumping AST Record Layout" in line:
            if cur:
                blocks.append(cur)
            cur = []
            continue
        if cur is not None:
            cur.append(line)
    if cur:
        blocks.append(cur)

    records = {}
    for lines in blocks:
        if not lines:
            continue
        mh = HEAD_RE.match(lines[0])
        if not mh:
            continue
        name = mh.group(3).strip()
        # Bản ghi lồng nhau / vô danh được dump riêng nhưng đã nằm trong bản ghi cha.
        if "::" in name or "(anonymous" in name or "(unnamed" in name:
            continue
        rec = {"size": 0, "align": 0, "kind": mh.group(2), "members": []}
        stack = [(-1, rec["members"])]
        for raw in lines[1:]:
            ms = SIZE_RE.search(raw)
            if ms:
                rec["size"], rec["align"] = int(ms.group(1)), int(ms.group(3))
                break
            mm = MEMBER_RE.match(raw)
            if not mm or not mm.group(6):
                continue
            entry = {
                "offset": int(mm.group(2)),
                "bitStart": int(mm.group(3)) if mm.group(3) else None,
                "bitEnd": int(mm.group(4)) if mm.group(4) else None,
                "raw": mm.group(6),
                "children": [],
            }
            indent = len(mm.group(5))
            while stack and indent <= stack[-1][0]:
                stack.pop()
            if not stack:
                stack = [(-1, rec["members"])]
            stack[-1][1].append(entry)
            stack.append((indent, entry["children"]))
        if name not in records or len(rec["members"]) >= len(records[name]["members"]):
            records[name] = rec
    return records


def clean_type(t):
    for junk in ("const ", "volatile ", "struct ", "class "):
        t = t.replace(junk, "")
    return re.sub(r"\s+", " ", t).strip()


def base_type(t):
    return clean_type(t).split("[")[0].strip().rstrip("*").strip()


def split_decl(body):
    """'const struct Il2CppType * type' -> ('const struct Il2CppType *', 'type')"""
    m = re.match(r"^(.*?)([A-Za-z_]\w*)(\[[^\]]*\])?$", body.strip())
    if not m:
        return body, body
    typ = m.group(1).strip() + ((" " + m.group(3)) if m.group(3) else "")
    return typ, m.group(2)


class Sizer:
    def __init__(self, records, pointer_size, long_size, extra=None):
        self.rec, self.ps, self.ls = records, pointer_size, long_size
        self.extra = extra or {}
        self.unknown = set()

    def size_of(self, ctype):
        t = clean_type(ctype)
        arr = re.search(r"\[(\d*)\]", t)
        if arr:
            n = int(arr.group(1)) if arr.group(1) else 0
            return n * self.size_of(t.split("[")[0])
        if t.endswith("*"):
            return self.ps
        if t in PRIM:
            return PRIM[t]
        if t in LONG_LIKE:
            return self.ls
        if t in self.extra:
            return self.extra[t]
        if t in self.rec:
            return self.rec[t]["size"]
        if re.fullmatch(r"[A-Z]\w*Index", t) or t == "EncodedMethodIndex":
            return 4
        if t.startswith("Il2CppMetadata") and t.endswith("Handle"):
            return self.ps
        if t in ("Il2CppMethodPointer", "InvokerMethod"):
            return self.ps
        self.unknown.add(t)
        return 0


def flatten(members, sizer, prefix="", in_union=False):
    """Làm phẳng aggregate lồng nhau thành 'parent.child'. Xem bẫy #3 và #4."""
    out = []
    for m in members:
        typ, name = split_decl(m["raw"])
        ct = clean_type(typ)
        if m["children"]:
            nested_union = m["raw"].lstrip().startswith("union ")
            anonymous = m["raw"].rstrip().endswith(")")     # không có tên thành viên
            out.extend(flatten(m["children"], sizer,
                               prefix=prefix if anonymous else prefix + name + ".",
                               in_union=in_union or nested_union))
            continue
        f = {"name": prefix + name, "type": ct, "offset": m["offset"]}
        if m["bitStart"] is not None:
            f["_bitStart"] = m["bitStart"]
            f["_bits"] = m["bitEnd"] - m["bitStart"] + 1
        else:
            f["size"] = sizer.size_of(typ)
            item = sizer.size_of(base_type(typ))
            if item and (ct.endswith("*") or "[" in ct):
                f["arrayItemSize"] = item
        if in_union:
            f["union"] = True
        out.append(f)
    return out


def normalize_bitfields(fields):
    """Bẫy #6: gộp bitfield liền nhau về (đơn vị lưu trữ, bitOffset tương đối)."""
    out, i = [], 0
    while i < len(fields):
        if "_bitStart" not in fields[i]:
            out.append(fields[i])
            i += 1
            continue
        j = i
        while j < len(fields) and "_bitStart" in fields[j]:
            j += 1
        base = fields[i]["offset"]
        for k, bf in enumerate(fields[i:j]):
            g = {"name": bf["name"], "type": bf["type"], "offset": base,
                 "bits": bf["_bits"], "bitOrdinal": k,
                 "bitOffset": bf["offset"] * 8 + bf["_bitStart"] - base * 8}
            if bf.get("union"):
                g["union"] = True
            out.append(g)
        i = j
    return out


# --------------------------------------------------------------------------- #
# enums / defines / typedefs (bẫy #7: đừng lọc theo vị trí file)

ENUM_DECL = re.compile(r"^[|`\- ]*EnumDecl 0x\w+ <[^>]*>[^\n]*?\s(\w+)\s*$")
ENUM_CONST = re.compile(r"^[|`\- ]*EnumConstantDecl 0x\w+ <[^>]*>[^\n]*?\s(\w+)\s+'")
VALUE_LINE = re.compile(r"^[|`\- ]*value: Int (-?\d+)")
TYPEDEF_DECL = re.compile(r"^[|`\- ]*TypedefDecl 0x\w+ <[^>]*>[^\n]*?\s(\w+)\s+'([^']*)'")


def parse_enums(ast_text):
    enums, cur, items, pending, auto = {}, None, [], None, 0

    def close():
        nonlocal cur, items, pending
        if pending is not None:
            items.append((pending, auto))
            pending = None
        if cur and items:
            enums[cur] = items
        cur, items = None, []

    for ln in ast_text.split("\n"):
        me = ENUM_DECL.match(ln)
        if me:
            close()
            cur, items, pending, auto = me.group(1), [], None, 0
            continue
        if cur is None:
            continue
        mc = ENUM_CONST.match(ln)
        if mc:
            if pending is not None:
                items.append((pending, auto))
                auto += 1
            pending = mc.group(1)
            continue
        mv = VALUE_LINE.match(ln)
        if mv and pending is not None:
            auto = int(mv.group(1))
            items.append((pending, auto))
            auto += 1
            pending = None
    close()
    return enums


def parse_typedefs(ast_text):
    return {m.group(1): m.group(2).strip()
            for m in (TYPEDEF_DECL.match(l) for l in ast_text.split("\n")) if m}


def resolve_typedef(name, tdmap):
    """TypeDefinitionIndex -> int32_t (đi hết chuỗi typedef vô hướng)."""
    cur = name
    for _ in range(8):
        nxt = tdmap.get(cur)
        if not nxt:
            break
        nxt = nxt.strip()
        if ("*" in nxt or "(" in nxt or nxt.startswith("__")
                or nxt.startswith(("struct ", "union ", "class ", "enum ")) or nxt == cur):
            break
        cur = nxt
    return cur


def canonicalize(structs, tdmap):
    """type = kiểu đã giải typedef, realType = tên gốc (đúng quy ước 368 file cũ)."""
    n = 0
    for s in structs.values():
        for f in s["fields"]:
            m = re.match(r"^([A-Za-z_]\w*)(\s*\[[^\]]*\])?$", f["type"])
            if not m:
                continue
            resolved = resolve_typedef(m.group(1), tdmap)
            if resolved != m.group(1):
                f["realType"] = m.group(1)
                f["type"] = resolved + (m.group(2) or "")
                n += 1
    return n


def collect_extras(structs, ast_text, macros, records):
    used = set()
    for s in structs.values():
        for f in s["fields"]:
            used.update(re.findall(r"[A-Za-z_]\w*", f["type"]))

    enums = {}
    for name, items in parse_enums(ast_text).items():
        if items and (name.startswith("Il2Cpp") or name in KEEP_ENUMS or name in used):
            enums[name] = ",".join("%s=%d" % (n, v) for n, v in items)

    tdmap = parse_typedefs(ast_text)
    defines, typedefs = {}, {}
    for name, underlying in sorted(tdmap.items()):
        if name in records or name in enums or name not in used:
            continue
        u = underlying.strip()
        if "(" in u:                       # bẫy #5: con trỏ hàm, không phải struct
            continue
        if u.startswith(("struct ", "union ", "class ")):
            typedefs[name] = "typedef %s %s %s;" % (u.split()[0], name, name)
        elif not u.startswith("enum "):
            defines[name] = u
    for name, value in macros.items():
        if name in used and name not in defines and name not in enums:
            defines[name] = value
    defines = {k: v for k, v in defines.items() if not STD_TYPEDEF.match(k)}
    return enums, defines, typedefs, tdmap


# --------------------------------------------------------------------------- #
# Sinh một file

def build_one(clang, lib, unity_version, mdver, tag, target, ps, ls, workdir, quiet):
    names, dropped, layout = resolve_struct_list(clang, lib, target, workdir, WANTED)
    if names is None:
        return None, dropped
    records = parse_layout_blocks(layout)

    def make(extra):
        sizer = Sizer(records, ps, ls, extra)
        structs = {}
        for n in sorted(set(WANTED)):
            if n not in records:
                continue
            r = records[n]
            s = {"size": r["size"],
                 "fields": normalize_bitfields(flatten(r["members"], sizer))}
            if r["kind"] == "union":
                s["union"] = True
            structs[n] = s
        return structs, sizer.unknown

    structs, unknown = make(None)                       # lượt 1: tìm kiểu chưa biết
    extra = measure_types(clang, lib, target, workdir, sorted(unknown)) if unknown else {}
    structs, still = make(extra)                        # lượt 2: dùng số đo từ clang

    ast = ast_dump(clang, lib, target, workdir)
    enums, defines, typedefs, tdmap = collect_extras(
        structs, ast, macro_dump(clang, lib, target, workdir), records)
    canonicalize(structs, tdmap)

    doc = {
        "schema": 1,
        "unityVersion": unity_version,
        "pointerSize": ps,
        "metadataVersion": mdver,
        "source": {
            "origin": "clang -Xclang -fdump-record-layouts trên Editor/Data/il2cpp/libil2cpp",
            "target": target,
            "tool": "tools/structdb_gen.py",
            "generatedUtc": datetime.datetime.now(datetime.timezone.utc)
                              .strftime("%Y-%m-%dT%H:%M:%SZ"),
            "note": "arrayItemSize = sizeof(kiểu được trỏ tới) — khác 368 file cũ (dùng dsize).",
        },
        "structs": structs,
        "enums": enums,
        "defines": defines,
        "typedefs": typedefs,
    }
    if still and not quiet:
        print("    cảnh báo: chưa suy được kích thước: %s" % ", ".join(sorted(still)))
    return doc, dropped


# --------------------------------------------------------------------------- #
# Kiểm chứng: sinh ngược .cpp rồi biên dịch với static_assert

def verify_file(clang, lib, target, workdir, json_path):
    doc = json.load(open(json_path, encoding="utf-8"))
    src = os.path.join(workdir, "verify.cpp")
    n_size = n_off = 0
    with open(src, "w", encoding="utf-8") as f:
        _write_includes(f)
        f.write("#include <stddef.h>\n\n")
        for sn, s in doc["structs"].items():
            f.write('static_assert(sizeof(%s) == %d, "%s");\n' % (sn, s["size"], sn))
            n_size += 1
            for fl in s["fields"]:
                if "bits" in fl:                        # offsetof không áp dụng cho bitfield
                    continue
                f.write('static_assert(offsetof(%s, %s) == %d, "%s.%s");\n'
                        % (sn, fl["name"], fl["offset"], sn, fl["name"]))
                n_off += 1
        f.write("\nint main(){return 0;}\n")
    p = _run([clang, "-x", "c++", "-std=c++11", "-target", target] + _includes(lib) +
             ["-Wno-everything", "-fsyntax-only", src])

    # kiểm tra luôn enums/defines/typedefs: dựng lại header rồi biên dịch
    hdr = os.path.join(workdir, "verify_hdr.cpp")
    with open(hdr, "w", encoding="utf-8") as f:
        f.write("#include <stdint.h>\n#include <stddef.h>\n\n")
        for v in doc["typedefs"].values():
            f.write(v + "\n")
        for k, v in doc["defines"].items():
            f.write("#define %s %s\n" % (k, v))
        for k, v in doc["enums"].items():
            f.write("enum %s {%s};\n" % (k, v))
        f.write("int main(){return 0;}\n")
    p2 = _run([clang, "-x", "c++", "-std=c++11", "-target", target,
               "-Wno-everything", "-fsyntax-only", hdr])
    return (p.returncode == 0 and p2.returncode == 0), n_size, n_off, (p.stderr + p2.stderr)


# --------------------------------------------------------------------------- #
# index.json

def version_key(v):
    m = re.match(r"^(\d+)\.(\d+)\.(\d+)([abfp])?(\d+)?", v)
    if not m:
        return (0, 0, 0, "", 0)
    return (int(m.group(1)), int(m.group(2)), int(m.group(3)),
            m.group(4) or "f", int(m.group(5) or 0))


def rebuild_index(out_dir):
    versions = sorted({f[:-9] for f in os.listdir(out_dir) if f.endswith("-x64.json")},
                      key=version_key)
    entries = []
    for v in versions:
        d = json.load(open(os.path.join(out_dir, v + "-x64.json"), encoding="utf-8"))
        e = {"unityVersion": v,
             "files": {"x32": v + "-x32.json", "x64": v + "-x64.json"},
             "structCount": len(d["structs"]),
             "enumCount": len(d["enums"]),
             "defineCount": len(d["defines"])}
        if d.get("metadataVersion"):
            e["metadataVersion"] = d["metadataVersion"]
        e["source"] = "clang" if d.get("source", {}).get("target") else "dvxil2c"
        entries.append(e)
    with open(os.path.join(out_dir, "index.json"), "w", encoding="utf-8") as f:
        json.dump({"schema": 1, "count": len(entries),
                   "note": "Struct layout runtime IL2CPP. Xem structdb/README.md.",
                   "versions": entries}, f, ensure_ascii=False, indent=1)
    return len(entries)


# --------------------------------------------------------------------------- #

def cmd_list(args):
    installs = find_unity_installs()
    if not installs:
        print("Không tìm thấy Unity Editor nào. Thư mục đã dò:")
        for r in UNITY_ROOTS:
            print("   ", r)
        return 1
    print("%-16s %-10s %s" % ("Unity", "metadata", "clang"))
    for name, path in installs.items():
        lib = os.path.join(path, "Editor/Data/il2cpp/libil2cpp")
        clang = find_clang(path)
        print("%-16s v%-9s %s" % (name, metadata_version(lib) or "?",
                                  "có" if clang else "KHÔNG CÓ (cần Android Build Support)"))
    return 0


def cmd_gen(args):
    installs = find_unity_installs()
    targets = sorted(installs) if args.all else args.versions
    if not targets:
        print("Chưa chỉ định phiên bản. Chạy 'list' để xem có gì.")
        return 1
    os.makedirs(args.out, exist_ok=True)
    workdir = args.workdir or os.path.join(tempfile.gettempdir(), "structdb_gen")
    os.makedirs(workdir, exist_ok=True)
    rc = 0
    for v in targets:
        if v not in installs:
            print("%s: không có trong Unity Hub" % v)
            rc = 1
            continue
        unity = installs[v]
        lib = os.path.join(unity, "Editor/Data/il2cpp/libil2cpp")
        clang = find_clang(unity)
        if not clang:
            print("%s: không tìm thấy clang (cài Android Build Support)" % v)
            rc = 1
            continue
        mdver = metadata_version(lib)
        print("%s  (metadata v%d)" % (v, mdver))
        for tag, target, ps, ls in ARCHS:
            doc, dropped = build_one(clang, lib, v, mdver, tag, target, ps, ls,
                                     workdir, args.quiet)
            if doc is None:
                print("  %s: THẤT BẠI" % tag)
                rc = 1
                continue
            path = os.path.join(args.out, "%s-%s.json" % (v, tag))
            with open(path, "w", encoding="utf-8") as f:
                json.dump(doc, f, ensure_ascii=False, indent=1)
            msg = ("  %s  structs=%d enums=%d defines=%d typedefs=%d"
                   % (tag, len(doc["structs"]), len(doc["enums"]),
                      len(doc["defines"]), len(doc["typedefs"])))
            if not args.no_verify:
                ok, ns, no, err = verify_file(clang, lib, target, workdir, path)
                msg += "  verify=%s (%d sizeof + %d offsetof)" % ("PASS" if ok else "FAIL", ns, no)
                if not ok:
                    rc = 1
                    sys.stderr.write(err[:2000] + "\n")
            print(msg)
        if dropped and not args.quiet:
            print("  không tồn tại ở bản này: %s" % ", ".join(sorted(dropped)))
    print("index.json: %d phiên bản" % rebuild_index(args.out))
    return rc


def cmd_verify(args):
    installs = find_unity_installs()
    workdir = args.workdir or os.path.join(tempfile.gettempdir(), "structdb_gen")
    os.makedirs(workdir, exist_ok=True)
    rc = 0
    for v in args.versions:
        if v not in installs:
            print("%s: không có Unity Editor tương ứng để đối chiếu" % v)
            rc = 1
            continue
        lib = os.path.join(installs[v], "Editor/Data/il2cpp/libil2cpp")
        clang = find_clang(installs[v])
        for tag, target, _, _ in ARCHS:
            path = os.path.join(args.out, "%s-%s.json" % (v, tag))
            if not os.path.isfile(path):
                print("%s-%s: chưa có file" % (v, tag))
                rc = 1
                continue
            ok, ns, no, err = verify_file(clang, lib, target, workdir, path)
            print("%s-%s: %s (%d sizeof + %d offsetof)"
                  % (v, tag, "PASS" if ok else "FAIL", ns, no))
            if not ok:
                rc = 1
                sys.stderr.write(err[:2000] + "\n")
    return rc


def cmd_index(args):
    print("index.json: %d phiên bản" % rebuild_index(args.out))
    return 0


def main():
    ap = argparse.ArgumentParser(
        description="Sinh struct DB IL2CPP từ header libil2cpp của Unity Editor.")
    ap.add_argument("--out", default=DEFAULT_OUT, help="thư mục structdb (mặc định: %(default)s)")
    ap.add_argument("--workdir", default=None,
                    help="nơi để file .cpp/.o tạm (mặc định: thư mục tạm của hệ thống)")
    sub = ap.add_subparsers(dest="cmd", required=True)

    p = sub.add_parser("list", help="liệt kê Unity Editor cài trên máy")
    p.set_defaults(func=cmd_list)

    p = sub.add_parser("gen", help="sinh JSON cho một hoặc nhiều phiên bản")
    p.add_argument("versions", nargs="*")
    p.add_argument("--all", action="store_true", help="mọi bản Unity tìm thấy")
    p.add_argument("--no-verify", action="store_true", help="bỏ qua static_assert round-trip")
    p.add_argument("-q", "--quiet", action="store_true")
    p.set_defaults(func=cmd_gen)

    p = sub.add_parser("verify", help="đối chiếu JSON đã có với header Unity")
    p.add_argument("versions", nargs="+")
    p.set_defaults(func=cmd_verify)

    p = sub.add_parser("index", help="dựng lại index.json")
    p.set_defaults(func=cmd_index)

    args = ap.parse_args()
    return args.func(args)


if __name__ == "__main__":
    sys.exit(main())
