#!/usr/bin/env python3
"""
Sinh type-tree DB cho typetreedb/ — thay cho StreamingAssets/ClassAll.zip.

Vì sao cần
----------
Để đọc `.assets` / AssetBundle, tool phải biết **type-tree của Unity built-in
classes** cho đúng phiên bản Unity của game. DevXUnity-Unpacker ship thứ đó dưới
dạng `StreamingAssets/ClassAll.zip` — 81 MB, 718 file XML, nạp TOÀN BỘ vào RAM
ngay lần tra cứu đầu tiên, và dừng ở Unity 2021.2.7f1. Game 2022 trở lên không có
gì để tra.

Tool này sinh ra bộ thay thế: mỗi phiên bản Unity một file JSON không mã hoá, nạp
lười từng file, đọc bằng mắt và `git diff` được — đúng cơ chế mà `structdb/` đã
dùng cho layout struct IL2CPP. Loader phía C#:
`Recovered/DevXUnityUnpackerTools/UnityTypeTreeDb.cs`. Schema: typetreedb/README.md.

Ba nguồn dữ liệu
----------------
    from-zip          ClassAll.zip / UnityType.zip cũ  -> JSON   (bootstrap ≤ 2021.2)
    from-dumps        TypeTreeDumps InfoJson           -> JSON   (đường chính cho bản mới)
    from-serialized   .assets / AssetBundle có type-tree -> JSON (khi chưa ai dump)

`from-dumps` là đường dễ nhất cho một bản Unity mới: bộ TypeTreeDumps công khai
(AssetRipper/TypeTreeDumps, thư mục `InfoJson/`) có sẵn file cho gần như mọi bản
Unity từ 3.4 tới 6000.x. Tải file `<version>.json` về rồi trỏ tool vào nó.

`from-serialized` là đường dự phòng cho bản Unity vừa ra chưa ai dump: build một
AssetBundle bằng đúng bản Unity đó (Unity ghi type-tree vào bundle trừ khi bật
`BuildAssetBundleOptions.DisableWriteTypeTree`), rồi trỏ tool vào file bundle.
Nhiều file được **gộp** lại thành một DB, nên cứ đưa vào tất cả những gì có.

Sau mỗi lần sinh, tool tự chạy lại bước `index`:
    * khử trùng lặp — các bản patch có type-tree y hệt nhau dùng chung một file,
      tên file là bản CŨ NHẤT trong nhóm (718 version thường gom còn vài chục file);
    * ghi `index.json` ánh xạ mọi version -> file.

Cách dùng
---------
    # bootstrap từ DB cũ của DevX
    python tools/typetreedb_gen.py from-zip \\
        --zip "…/StreamingAssets/ClassAll.zip" \\
        --zip "…/StreamingAssets/UnityType.zip" \\
        --out typetreedb

    # thêm một bản Unity mới từ TypeTreeDumps
    python tools/typetreedb_gen.py from-dumps --input 6000.3.18f1.json --out typetreedb

    # hoặc rút thẳng từ AssetBundle build bằng bản Unity đó
    python tools/typetreedb_gen.py from-serialized \\
        --input build/*.bundle --unity-version 6000.3.18f1 --out typetreedb

    python tools/typetreedb_gen.py index  --out typetreedb
    python tools/typetreedb_gen.py verify --out typetreedb

Bẫy đã gặp (đừng bỏ cái nào)
----------------------------
1. `ZipInputStream.Read` trong tool C# gốc chỉ gọi MỘT lần cho mỗi entry — chạy
   đúng với entry deflate nhưng cắt cụt entry *stored*. Ở đây dùng `zipfile` nên
   không dính, nhưng đó là lý do đừng repack ClassAll.zip ở mức nén 0.
2. Type-tree blob của SerializedFile dùng bảng chuỗi dùng chung: offset có bit
   0x80000000 trỏ vào bảng CommonString cứng, không phải vào string buffer của
   file. Sai bảng này thì mọi tên field sai mà không có lỗi nào nổ ra — nên
   `_resolve_string` bắt buộc offset phải rơi đúng đầu một chuỗi.
3. SerializedFile version ≥ 22 có header lớn: 4 field đầu vẫn u32 BE nhưng bị
   ghi đè bởi metadataSize/fileSize/dataOffset đọc lại ngay sau đó.
4. `m_EnableTypeTree = false` là chuyện bình thường với player build release.
   File đó KHÔNG dùng được; tool báo rõ thay vì sinh DB rỗng.
5. Node `size = -1` là hợp lệ (kích thước động: string, vector…). Đừng "sửa".
6. Trong DB cũ của DevX, `classID` của MonoBehaviour script là 0 và định danh
   nằm ở `className`; `StrSth.FindByStr` chỉ khớp khi `objectType == 0`. Giữ
   nguyên quy ước đó khi chuyển đổi, nếu không MonoBehaviour sẽ tra không ra.
"""

from __future__ import annotations

import argparse
import glob
import hashlib
import io
import json
import lzma
import os
import re
import struct
import sys
import zipfile
import xml.etree.ElementTree as ET

SCHEMA = 1

# --------------------------------------------------------------------------- #
# Mô hình chung
# --------------------------------------------------------------------------- #


def new_doc(unity_version: str, source: dict) -> dict:
    return {
        "schema": SCHEMA,
        "unityVersion": unity_version,
        "unityTypeVersion": 0,
        "platform": 0,
        "baseDefinitions": False,
        "source": source,
        "types": [],
    }


def new_node(type_name: str, name: str, size: int, index: int, is_array: bool,
             meta_flag: int, serialized_version: int, level: int) -> dict:
    node = {
        "type": type_name or "",
        "name": name or "",
        "size": int(size),
        "index": int(index),
        "isArray": bool(is_array),
        "metaFlag": int(meta_flag),
        "serializedVersion": int(serialized_version),
        "treeLevel": int(level),
    }
    node["children"] = []
    return node


def type_key(t: dict) -> tuple:
    """Khoá trùng lặp của một type trong cùng một DB."""
    return (int(t.get("classID", 0)), t.get("className") or "")


def merge_types(dst: dict, types: list) -> int:
    """Thêm type vào doc, bỏ qua cái đã có. Trả số type thực sự thêm mới."""
    seen = {type_key(t) for t in dst["types"]}
    added = 0
    for t in types:
        k = type_key(t)
        if k in seen:
            continue
        seen.add(k)
        dst["types"].append(t)
        added += 1
    return added


def sort_types(doc: dict) -> None:
    """classID tăng dần, rồi className — để git diff giữa hai bản Unity đọc được."""
    doc["types"].sort(key=lambda t: (int(t.get("classID", 0)), t.get("className") or ""))


# --------------------------------------------------------------------------- #
# Ghi ra đĩa + index
# --------------------------------------------------------------------------- #


VERSION_RE = re.compile(r"^(\d+)\.(\d+)\.(\d+)(?:([abfp])(\d+))?")
STAGE_ORDER = {"a": 0, "b": 1, "f": 2, "p": 3}


def version_key(v: str):
    """Khoá so sánh version. Bản không phân tích được xếp cuối."""
    m = VERSION_RE.match(v or "")
    if not m:
        return (1 << 30, 0, 0, 0, 0, v or "")
    return (
        int(m.group(1)),
        int(m.group(2)),
        int(m.group(3)),
        STAGE_ORDER.get(m.group(4) or "f", 2),
        int(m.group(5) or 0),
        "",
    )


def payload_hash(doc: dict) -> str:
    """Hash phần nội dung — bỏ qua unityVersion/source để khử trùng lặp được."""
    body = {k: v for k, v in doc.items() if k not in ("unityVersion", "source")}
    blob = json.dumps(body, sort_keys=True, separators=(",", ":"), ensure_ascii=False)
    return hashlib.sha256(blob.encode("utf-8")).hexdigest()


def write_doc(out_dir: str, doc: dict, compact: bool) -> str:
    os.makedirs(out_dir, exist_ok=True)
    sort_types(doc)
    path = os.path.join(out_dir, doc["unityVersion"] + ".json")
    dump(path, doc, compact)
    return path


def dump(path: str, obj, compact: bool) -> None:
    with io.open(path, "w", encoding="utf-8", newline="\n") as fh:
        if compact:
            json.dump(obj, fh, separators=(",", ":"), ensure_ascii=False)
        else:
            json.dump(obj, fh, indent=1, ensure_ascii=False)
        fh.write("\n")


def load_json(path: str):
    with io.open(path, encoding="utf-8") as fh:
        return json.load(fh)


def rebuild_index(out_dir: str, compact: bool, quiet: bool = False) -> dict:
    """
    Gom các file có nội dung giống hệt nhau về một file (tên = version cũ nhất),
    xoá phần dư, rồi ghi index.json ánh xạ mọi version -> file.
    """
    files = sorted(
        (p for p in glob.glob(os.path.join(out_dir, "*.json"))
         if os.path.basename(p).lower() != "index.json"),
        key=lambda p: version_key(os.path.splitext(os.path.basename(p))[0]),
    )
    if not files:
        raise SystemExit("typetreedb rỗng: %s" % out_dir)

    groups: dict[str, list[str]] = {}
    docs: dict[str, dict] = {}
    for path in files:
        version = os.path.splitext(os.path.basename(path))[0]
        doc = load_json(path)
        docs[version] = doc
        # Chạy lại `index` không được làm mất các version đã bị gộp ở lần trước:
        # chúng chỉ còn tồn tại trong source.coversVersions của file giữ lại.
        covered = set((doc.get("source") or {}).get("coversVersions") or [])
        covered.add(version)
        groups.setdefault(payload_hash(doc), []).extend(sorted(covered, key=version_key))

    index = {}
    kept = 0
    for _, raw_versions in groups.items():
        versions = sorted(set(raw_versions), key=version_key)
        keeper = versions[0]
        kept += 1
        keeper_doc = docs[keeper]
        keeper_doc["unityVersion"] = keeper
        keeper_doc.setdefault("source", {})["coversVersions"] = versions
        dump(os.path.join(out_dir, keeper + ".json"), keeper_doc, compact)
        for v in versions:
            index[v] = keeper + ".json"
            stale = os.path.join(out_dir, v + ".json")
            if v != keeper and os.path.isfile(stale):
                os.remove(stale)

    ordered = {v: index[v] for v in sorted(index, key=version_key)}
    dump(os.path.join(out_dir, "index.json"),
         {"schema": SCHEMA, "versions": ordered}, compact)
    if not quiet:
        print("index: %d version -> %d file (khử trùng lặp %d)"
              % (len(ordered), kept, len(ordered) - kept))
    return ordered


def finish(out_dir: str, args) -> None:
    if getattr(args, "no_index", False):
        return
    rebuild_index(out_dir, args.compact)


# --------------------------------------------------------------------------- #
# Nguồn 1 — ClassAll.zip / UnityType.zip (XML của DevX)
# --------------------------------------------------------------------------- #


ENTRY_RE = re.compile(r"_v([0-9][^\\/_]*?)(?:_c[^\\/_]*)?\.xml$", re.IGNORECASE)


def _xml_int(el: ET.Element, name: str, default: int = 0) -> int:
    raw = el.get(name)
    if raw is None or raw == "":
        return default
    try:
        return int(raw, 0)
    except ValueError:
        try:
            return int(float(raw))
        except ValueError:
            return default


def _xml_bool(el: ET.Element, name: str) -> bool:
    raw = (el.get(name) or "").strip().lower()
    return raw in ("1", "true", "yes")


def xml_node(el: ET.Element, level: int) -> dict:
    node = new_node(
        el.get("type") or "",
        el.get("name") or "",
        _xml_int(el, "size", -1),
        _xml_int(el, "index"),
        _xml_bool(el, "isArray"),
        _xml_int(el, "metaFlag"),
        _xml_int(el, "serializedVersion", 1),
        _xml_int(el, "treeLevel", level),
    )
    if el.get("LicenseType"):
        node["licenseType"] = el.get("LicenseType")
    if el.get("Value"):
        node["value"] = el.get("Value")
    for child in el:
        if child.tag == "node":
            node["children"].append(xml_node(child, level + 1))
    return node


def xml_type(el: ET.Element) -> dict:
    out = {
        "classID": _xml_int(el, "classID"),
        "className": el.get("className") or "",
        "serializedVersion": _xml_int(el, "serializedVersion", 1),
        "nodes": [xml_node(child, 0) for child in el if child.tag == "node"],
    }
    if el.get("scriptID"):
        out["scriptID"] = el.get("scriptID")
    if el.get("typeHash"):
        out["typeHash"] = el.get("typeHash")
    platform = el.get("platform")
    if platform is not None and platform != "":
        out["platform"] = _xml_int(el, "platform")
    return out


def from_zip(args) -> None:
    """
    Mỗi entry `*_v<version>.xml` thành một doc. UnityType.zip được nạp TRƯỚC
    ClassAll.zip cho cùng một version, giống thứ tự ưu tiên của TryGetStrSth2 cũ.
    """
    by_version: dict[str, dict] = {}
    order = sorted(args.zip, key=lambda p: 0 if "unitytype" in os.path.basename(p).lower() else 1)
    for zip_path in order:
        if not os.path.isfile(zip_path):
            raise SystemExit("không thấy file: %s" % zip_path)
        with zipfile.ZipFile(zip_path) as zf:
            names = [n for n in zf.namelist() if n.lower().endswith(".xml")]
            print("%s: %d entry XML" % (os.path.basename(zip_path), len(names)))
            for name in names:
                m = ENTRY_RE.search(name.replace("\\", "/").split("/")[-1])
                raw = zf.read(name)
                try:
                    root = ET.fromstring(raw)
                except ET.ParseError as ex:
                    print("  bỏ qua %s: XML hỏng (%s)" % (name, ex), file=sys.stderr)
                    continue
                version = root.get("unity_version") or (m.group(1) if m else None)
                if not version:
                    print("  bỏ qua %s: không suy ra được unity version" % name, file=sys.stderr)
                    continue
                doc = by_version.get(version)
                if doc is None:
                    doc = new_doc(version, {"origin": "DevXUnity ClassAll.zip",
                                            "files": []})
                    by_version[version] = doc
                    doc["unityTypeVersion"] = _xml_int(root, "unity_type_version")
                    doc["platform"] = _xml_int(root, "platform")
                    doc["baseDefinitions"] = _xml_bool(root, "baseDefinitions")
                doc["source"]["files"].append("%s!%s" % (os.path.basename(zip_path), name))
                merge_types(doc, [xml_type(el) for el in root if el.tag == "Type"])

    if not by_version:
        raise SystemExit("không rút được version nào từ các zip đã cho")
    for version in sorted(by_version, key=version_key):
        doc = by_version[version]
        write_doc(args.out, doc, args.compact)
        print("  %-14s %4d type" % (version, len(doc["types"])))
    finish(args.out, args)


# --------------------------------------------------------------------------- #
# Nguồn 2 — TypeTreeDumps InfoJson
# --------------------------------------------------------------------------- #


def _pick(d: dict, *names, default=None):
    for n in names:
        if n in d:
            return d[n]
    return default


def dump_node(raw: dict, level: int) -> dict:
    node = new_node(
        _pick(raw, "m_Type", "Type", "type", default=""),
        _pick(raw, "m_Name", "Name", "name", default=""),
        _pick(raw, "m_ByteSize", "ByteSize", "size", default=-1),
        _pick(raw, "m_Index", "Index", "index", default=0),
        bool(_pick(raw, "m_TypeFlags", "TypeFlags", "m_IsArray", "isArray", default=0)),
        _pick(raw, "m_MetaFlag", "MetaFlag", "metaFlag", default=0),
        _pick(raw, "m_Version", "Version", "serializedVersion", default=1),
        _pick(raw, "m_Level", "Level", "treeLevel", default=level),
    )
    for child in _pick(raw, "m_SubNodes", "SubNodes", "children", default=[]) or []:
        node["children"].append(dump_node(child, level + 1))
    return node


def from_dumps(args) -> None:
    inputs: list[str] = []
    for pattern in args.input:
        if os.path.isdir(pattern):
            inputs.extend(sorted(glob.glob(os.path.join(pattern, "*.json"))))
        else:
            inputs.extend(sorted(glob.glob(pattern)) or [pattern])
    if not inputs:
        raise SystemExit("không có file đầu vào")

    for path in inputs:
        if not os.path.isfile(path):
            raise SystemExit("không thấy file: %s" % path)
        raw = load_json(path)
        classes = _pick(raw, "Classes", "classes")
        if classes is None:
            raise SystemExit("%s: không có mục \"Classes\" — đây có phải InfoJson "
                             "của TypeTreeDumps không?" % path)
        version = (args.unity_version
                   or _pick(raw, "Version", "version", "UnityVersion")
                   or os.path.splitext(os.path.basename(path))[0])
        doc = new_doc(version, {"origin": "TypeTreeDumps InfoJson",
                                "file": os.path.basename(path)})
        types, skipped = [], 0
        for cls in classes:
            root = _pick(cls, "ReleaseRootNode", "releaseRootNode")
            if not root:
                root = _pick(cls, "EditorRootNode", "editorRootNode")
            if not root:
                # Type trừu tượng hoặc bị strip: không có cây, bỏ qua có chủ đích.
                skipped += 1
                continue
            entry = {
                "classID": int(_pick(cls, "TypeID", "ClassID", "typeID", default=0)),
                "className": _pick(cls, "Name", "name", default="") or "",
                "serializedVersion": int(_pick(root, "m_Version", "Version", default=1)),
                "nodes": [dump_node(root, 0)],
            }
            types.append(entry)
        merge_types(doc, types)
        if not doc["types"]:
            raise SystemExit("%s: không rút được type nào" % path)
        write_doc(args.out, doc, args.compact)
        print("%-14s %4d type (bỏ qua %d type không có cây)"
              % (version, len(doc["types"]), skipped))
    finish(args.out, args)


# --------------------------------------------------------------------------- #
# Nguồn 3 — SerializedFile / AssetBundle có type-tree
# --------------------------------------------------------------------------- #

# Bảng chuỗi dùng chung của Unity. Offset có bit 0x80000000 trỏ vào đây.
COMMON_STRINGS = (
    "AABB", "AnimationClip", "AnimationCurve", "AnimationState", "Array", "Base",
    "BitField", "bitset", "bool", "char", "ColorRGBA", "Component", "data", "deque",
    "double", "dynamic_array", "FastPropertyName", "first", "float", "Font",
    "GameObject", "Generic Mono", "GradientNEW", "GUID", "GUIStyle", "int", "list",
    "long long", "map", "Matrix4x4f", "MdFour", "MonoBehaviour", "MonoScript",
    "m_ByteSize", "m_Curve", "m_EditorClassIdentifier", "m_EditorHideFlags",
    "m_Enabled", "m_ExtensionPtr", "m_GameObject", "m_Index", "m_IsArray",
    "m_IsStatic", "m_MetaFlag", "m_Name", "m_ObjectHideFlags", "m_PrefabInternal",
    "m_PrefabParentObject", "m_Script", "m_StaticEditorFlags", "m_Type", "m_Version",
    "Object", "pair", "PPtr<Component>", "PPtr<GameObject>", "PPtr<Material>",
    "PPtr<MonoBehaviour>", "PPtr<MonoScript>", "PPtr<Object>", "PPtr<Prefab>",
    "PPtr<Sprite>", "PPtr<TextAsset>", "PPtr<Texture>", "PPtr<Texture2D>",
    "PPtr<Transform>", "Prefab", "Quaternionf", "Rectf", "RectInt", "RectOffset",
    "second", "set", "short", "size", "SInt16", "SInt32", "SInt64", "SInt8",
    "staticvector", "string", "TextAsset", "TextMesh", "Texture", "Texture2D",
    "Transform", "TypelessData", "UInt16", "UInt32", "UInt64", "UInt8",
    "unsigned int", "unsigned long long", "unsigned short", "vector", "Vector2f",
    "Vector3f", "Vector4f", "m_ScriptingClassIdentifier", "Gradient", "Type*",
    "int2_storage", "int3_storage", "BoundsInt", "m_CorrespondingSourceObject",
    "m_PrefabInstance", "m_PrefabAsset", "FileSize", "Hash128",
)
COMMON_BUFFER = ("\0".join(COMMON_STRINGS) + "\0").encode("ascii")


class Reader:
    """Đọc nhị phân đổi được endianness giữa chừng (header BE, thân tuỳ file)."""

    def __init__(self, data: bytes, big_endian: bool = True):
        self.data = data
        self.pos = 0
        self.be = big_endian

    @property
    def _e(self) -> str:
        return ">" if self.be else "<"

    def seek(self, pos: int) -> None:
        self.pos = pos

    def read(self, n: int) -> bytes:
        if self.pos + n > len(self.data):
            raise EOFError("đọc quá cuối file tại %d (+%d, cỡ %d)"
                           % (self.pos, n, len(self.data)))
        out = self.data[self.pos:self.pos + n]
        self.pos += n
        return out

    def u8(self) -> int:
        return self.read(1)[0]

    def i8(self) -> int:
        return struct.unpack("b", self.read(1))[0]

    def u16(self) -> int:
        return struct.unpack(self._e + "H", self.read(2))[0]

    def i16(self) -> int:
        return struct.unpack(self._e + "h", self.read(2))[0]

    def u32(self) -> int:
        return struct.unpack(self._e + "I", self.read(4))[0]

    def i32(self) -> int:
        return struct.unpack(self._e + "i", self.read(4))[0]

    def i64(self) -> int:
        return struct.unpack(self._e + "q", self.read(8))[0]

    def u64(self) -> int:
        return struct.unpack(self._e + "Q", self.read(8))[0]

    def cstring(self) -> str:
        end = self.data.index(b"\0", self.pos)
        out = self.data[self.pos:end].decode("utf-8", "replace")
        self.pos = end + 1
        return out

    def align(self, n: int = 4) -> None:
        self.pos = (self.pos + n - 1) & ~(n - 1)


def lz4_block_decompress(src: bytes, out_size: int) -> bytes:
    """LZ4 block format. Bundle Unity dùng LZ4/LZ4HC, cùng một format khối."""
    out = bytearray(out_size)
    s, d, n = 0, 0, len(src)
    while s < n:
        token = src[s]
        s += 1
        lit = token >> 4
        if lit == 15:
            while True:
                b = src[s]
                s += 1
                lit += b
                if b != 255:
                    break
        out[d:d + lit] = src[s:s + lit]
        s += lit
        d += lit
        if s >= n:
            break
        offset = src[s] | (src[s + 1] << 8)
        s += 2
        if offset == 0:
            raise ValueError("LZ4: offset 0")
        match = token & 0x0F
        if match == 15:
            while True:
                b = src[s]
                s += 1
                match += b
                if b != 255:
                    break
        match += 4
        start = d - offset
        if start < 0:
            raise ValueError("LZ4: match trỏ ra ngoài cửa sổ")
        for i in range(match):          # có thể chồng lấn, không dùng slice được
            out[d + i] = out[start + i]
        d += match
    if d != out_size:
        raise ValueError("LZ4: giải nén ra %d byte, mong đợi %d" % (d, out_size))
    return bytes(out)


def lzma_decompress(src: bytes, out_size: int) -> bytes:
    """Unity ghi 5 byte props rồi thẳng dữ liệu; FORMAT_ALONE cần thêm 8 byte cỡ."""
    blob = src[:5] + struct.pack("<Q", out_size) + src[5:]
    return lzma.LZMADecompressor(format=lzma.FORMAT_ALONE).decompress(blob)


def unpack_bundle(data: bytes) -> list[tuple[str, bytes]]:
    """UnityFS -> danh sách (tên, nội dung) các SerializedFile bên trong."""
    r = Reader(data, big_endian=True)
    signature = r.cstring()
    if signature != "UnityFS":
        raise ValueError("chỉ hỗ trợ bundle UnityFS, gặp %r" % signature)
    version = r.u32()
    r.cstring()                          # unityVersion
    r.cstring()                          # unityRevision
    r.i64()                              # size
    comp_blocks = r.u32()
    uncomp_blocks = r.u32()
    flags = r.u32()
    if flags & 0x80:                     # kArchiveBlocksInfoAtTheEnd
        keep = r.pos
        r.seek(len(data) - comp_blocks)
        blocks_info = r.read(comp_blocks)
        r.seek(keep)
    else:
        if version >= 7:
            r.align(16)
        blocks_info = r.read(comp_blocks)

    method = flags & 0x3F
    if method == 0:
        blocks_info = blocks_info[:uncomp_blocks]
    elif method == 1:
        blocks_info = lzma_decompress(blocks_info, uncomp_blocks)
    elif method in (2, 3):
        blocks_info = lz4_block_decompress(blocks_info, uncomp_blocks)
    else:
        raise ValueError("bundle nén bằng phương thức %d chưa hỗ trợ" % method)

    b = Reader(blocks_info, big_endian=True)
    b.read(16)                           # uncompressedDataHash
    block_count = b.i32()
    blocks = [(b.u32(), b.u32(), b.u16()) for _ in range(block_count)]

    if flags & 0x200:                    # kBlockInfoNeedPaddingAtStart
        r.align(16)
    payload = bytearray()
    for uncomp, comp, bflags in blocks:
        chunk = r.read(comp)
        m = bflags & 0x3F
        if m == 0:
            payload += chunk
        elif m == 1:
            payload += lzma_decompress(chunk, uncomp)
        elif m in (2, 3):
            payload += lz4_block_decompress(chunk, uncomp)
        else:
            raise ValueError("khối nén bằng phương thức %d chưa hỗ trợ" % m)
    payload = bytes(payload)

    node_count = b.i32()
    files = []
    for _ in range(node_count):
        offset = b.i64()
        size = b.i64()
        b.u32()                          # flags
        name = b.cstring()
        files.append((name, payload[offset:offset + size]))
    return files


def _resolve_string(offset: int, string_buffer: bytes) -> str:
    if offset & 0x80000000:
        buf, off = COMMON_BUFFER, offset & 0x7FFFFFFF
    else:
        buf, off = string_buffer, offset
    if off >= len(buf) or (off > 0 and buf[off - 1] != 0):
        # Bẫy #2: offset không rơi đúng đầu chuỗi nghĩa là sai bảng, không phải
        # dữ liệu lạ. Nổ ngay còn hơn sinh ra DB có tên field sai lặng lẽ.
        raise ValueError("offset chuỗi 0x%08X không rơi đúng đầu một chuỗi "
                         "(bảng CommonString lệch?)" % offset)
    end = buf.index(b"\0", off)
    return buf[off:end].decode("utf-8", "replace")


def read_type_tree_blob(r: Reader, version: int) -> dict:
    node_count = r.i32()
    buffer_size = r.i32()
    flat = []
    for _ in range(node_count):
        serialized_version = r.u16()
        level = r.u8()
        type_flags = r.u8()
        type_off = r.u32()
        name_off = r.u32()
        byte_size = r.i32()
        index = r.i32()
        meta_flag = r.i32()
        if version >= 19:
            r.u64()                      # m_RefTypeHash
        flat.append([serialized_version, level, type_flags, type_off, name_off,
                     byte_size, index, meta_flag])
    string_buffer = r.read(buffer_size)

    root = None
    stack: list[dict] = []
    for (sv, level, type_flags, type_off, name_off, byte_size, index, meta_flag) in flat:
        node = new_node(_resolve_string(type_off, string_buffer),
                        _resolve_string(name_off, string_buffer),
                        byte_size, index, bool(type_flags), meta_flag, sv, level)
        del stack[level:]
        if level == 0:
            root = node
        else:
            if not stack:
                raise ValueError("type-tree có node level %d nhưng chưa có gốc" % level)
            stack[-1]["children"].append(node)
        stack.append(node)
    if root is None:
        raise ValueError("type-tree rỗng")
    return root


def read_serialized_types(data: bytes) -> tuple[str, int, list[dict]]:
    """Trả (unityVersion, targetPlatform, types) của một SerializedFile."""
    r = Reader(data, big_endian=True)
    metadata_size = r.u32()
    file_size = r.u32()
    version = r.u32()
    data_offset = r.u32()
    if version >= 9:
        big_endian = r.u8() != 0
        r.read(3)
    else:
        keep = r.pos
        r.seek(file_size - metadata_size)
        big_endian = r.u8() != 0
        r.seek(keep)
    if version >= 22:
        r.u32()                          # metadataSize (lặp lại)
        r.i64()                          # fileSize
        data_offset = r.i64()
        r.i64()                          # unknown
    if version < 12:
        raise ValueError("SerializedFile version %d quá cũ, tool này chỉ đọc "
                         "type-tree dạng blob (version >= 12)" % version)
    _ = data_offset
    r.be = big_endian

    unity_version = r.cstring() if version >= 7 else ""
    target_platform = r.i32() if version >= 8 else 0
    enable_type_tree = (r.u8() != 0) if version >= 13 else True
    if not enable_type_tree:
        raise ValueError("file này có m_EnableTypeTree = false (player build "
                         "release đã strip type-tree) — dùng AssetBundle build "
                         "không bật DisableWriteTypeTree")

    type_count = r.i32()
    types = []
    for _ in range(type_count):
        class_id = r.i32()
        if version >= 16:
            r.u8()                       # m_IsStrippedType
        script_index = r.i16() if version >= 17 else -1
        script_id = None
        type_hash = None
        if version >= 13:
            if (version < 16 and class_id < 0) or (version >= 16 and class_id == 114):
                script_id = r.read(16).hex()
            type_hash = r.read(16).hex()
        root = read_type_tree_blob(r, version)
        if version >= 21:
            dep_count = r.i32()
            r.read(4 * dep_count)        # m_TypeDependencies

        entry = {
            # MonoBehaviour script: giữ quy ước cũ của DevX — classID 0, định danh
            # nằm ở className, để StrSth.FindByStr (chỉ khớp objectType == 0) tra ra.
            "classID": 0 if (class_id == 114 and script_index >= 0) else class_id,
            "className": root["type"],
            "serializedVersion": root["serializedVersion"],
            "nodes": [root],
        }
        if script_id:
            entry["scriptID"] = script_id
        if type_hash:
            entry["typeHash"] = type_hash
        types.append(entry)
    return unity_version, target_platform, types


def iter_serialized(path: str):
    """Sinh (nhãn, bytes) cho mọi SerializedFile trong một file đầu vào."""
    with io.open(path, "rb") as fh:
        blob = fh.read()
    if blob[:7] == b"UnityFS":
        for name, content in unpack_bundle(blob):
            yield "%s!%s" % (os.path.basename(path), name), content
    else:
        yield os.path.basename(path), blob


def from_serialized(args) -> None:
    inputs: list[str] = []
    for pattern in args.input:
        inputs.extend(sorted(glob.glob(pattern)) or [pattern])
    if not inputs:
        raise SystemExit("không có file đầu vào")

    doc = None
    used = []
    for path in inputs:
        if not os.path.isfile(path):
            raise SystemExit("không thấy file: %s" % path)
        for label, blob in iter_serialized(path):
            try:
                unity_version, platform, types = read_serialized_types(blob)
            except (ValueError, EOFError, struct.error) as ex:
                print("  bỏ qua %s: %s" % (label, ex), file=sys.stderr)
                continue
            version = args.unity_version or unity_version
            if not version:
                raise SystemExit("%s: file không ghi Unity version, hãy truyền "
                                 "--unity-version" % label)
            if doc is None:
                doc = new_doc(version, {"origin": "SerializedFile", "files": []})
                doc["platform"] = platform
            elif version != doc["unityVersion"]:
                raise SystemExit("trộn hai bản Unity trong một lần chạy: %s và %s"
                                 % (doc["unityVersion"], version))
            added = merge_types(doc, types)
            doc["source"]["files"].append(label)
            used.append((label, len(types), added))

    if doc is None or not doc["types"]:
        raise SystemExit("không rút được type-tree nào — mọi file đầu vào đều "
                         "không có type-tree hoặc không đọc được")
    for label, total, added in used:
        print("  %-40s %4d type (mới %d)" % (label, total, added))

    existing = os.path.join(args.out, doc["unityVersion"] + ".json")
    if os.path.isfile(existing) and not args.overwrite:
        old = load_json(existing)
        added = merge_types(old, doc["types"])
        old.setdefault("source", {}).setdefault("files", [])
        old["source"]["files"] += doc["source"]["files"]
        doc = old
        print("gộp vào %s có sẵn: thêm %d type" % (os.path.basename(existing), added))
    write_doc(args.out, doc, args.compact)
    print("%-14s %4d type" % (doc["unityVersion"], len(doc["types"])))
    finish(args.out, args)


# --------------------------------------------------------------------------- #
# verify
# --------------------------------------------------------------------------- #


def walk(node: dict):
    yield node
    for child in node.get("children", []):
        yield from walk(child)


def verify(args) -> None:
    index_path = os.path.join(args.out, "index.json")
    if not os.path.isfile(index_path):
        raise SystemExit("thiếu index.json — chạy `index` trước")
    versions = load_json(index_path).get("versions") or {}
    if not versions:
        raise SystemExit("index.json không có version nào")

    problems = 0
    checked = set()
    for version, file_name in versions.items():
        path = os.path.join(args.out, file_name)
        if not os.path.isfile(path):
            print("THIẾU  %s -> %s" % (version, file_name))
            problems += 1
            continue
        if file_name in checked:
            continue
        checked.add(file_name)
        doc = load_json(path)
        if doc.get("schema") != SCHEMA:
            print("SCHEMA %s: %r" % (file_name, doc.get("schema")))
            problems += 1
        types = doc.get("types") or []
        if not types:
            print("RỖNG   %s" % file_name)
            problems += 1
        seen = set()
        for t in types:
            key = type_key(t)
            if key in seen:
                print("TRÙNG  %s: classID=%d className=%r" % (file_name, key[0], key[1]))
                problems += 1
            seen.add(key)
            nodes = t.get("nodes") or []
            if not nodes:
                print("KHÔNG CÂY %s: %r" % (file_name, key[1]))
                problems += 1
            for root in nodes:
                for n in walk(root):
                    if not n.get("type") and not n.get("name"):
                        print("NODE RỖNG %s: %r" % (file_name, key[1]))
                        problems += 1
                        break
    print("verify: %d version, %d file, %d vấn đề"
          % (len(versions), len(checked), problems))
    if problems:
        sys.exit(1)


# --------------------------------------------------------------------------- #
# CLI
# --------------------------------------------------------------------------- #


def main(argv=None) -> None:
    ap = argparse.ArgumentParser(
        prog="typetreedb_gen.py",
        description="Sinh typetreedb/ — type-tree Unity built-in classes dạng JSON.",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog=__doc__.split("Cách dùng")[1] if "Cách dùng" in __doc__ else None,
    )
    ap.add_argument("--out", default="typetreedb", help="thư mục đích (mặc định: typetreedb)")
    ap.add_argument("--compact", action="store_true",
                    help="JSON một dòng, nhỏ hơn ~2x nhưng không diff được")
    ap.add_argument("--no-index", action="store_true",
                    help="đừng chạy lại bước index sau khi sinh")
    sub = ap.add_subparsers(dest="cmd", required=True)

    p = sub.add_parser("from-zip", help="ClassAll.zip / UnityType.zip -> JSON")
    p.add_argument("--zip", action="append", required=True,
                   help="đường dẫn tới ClassAll.zip hoặc UnityType.zip (lặp lại được)")
    p.set_defaults(func=from_zip)

    p = sub.add_parser("from-dumps", help="TypeTreeDumps InfoJson -> JSON")
    p.add_argument("--input", nargs="+", required=True,
                   help="file .json, glob, hoặc thư mục InfoJson/")
    p.add_argument("--unity-version", help="ghi đè version đọc từ file")
    p.set_defaults(func=from_dumps)

    p = sub.add_parser("from-serialized",
                       help=".assets / AssetBundle có type-tree -> JSON (gộp nhiều file)")
    p.add_argument("--input", nargs="+", required=True, help="file hoặc glob")
    p.add_argument("--unity-version", help="ghi đè version đọc từ file")
    p.add_argument("--overwrite", action="store_true",
                   help="ghi đè file version có sẵn thay vì gộp vào")
    p.set_defaults(func=from_serialized)

    p = sub.add_parser("index", help="khử trùng lặp + ghi lại index.json")
    p.set_defaults(func=lambda a: rebuild_index(a.out, a.compact))

    p = sub.add_parser("verify", help="kiểm tra tính toàn vẹn của DB")
    p.set_defaults(func=verify)

    args = ap.parse_args(argv)
    args.func(args)


if __name__ == "__main__":
    main()
