"""Facade tying the whole `dotnet_metadata` package together: given a whole `.dll` file's
bytes, exposes typed table-row access and the two coded-index resolvers callers actually need
(`resolve_type_def_or_ref`, `custom_attribute_type_name`)."""
from __future__ import annotations

import struct

from .heaps import BlobHeap, GuidHeap, StringsHeap, UserStringsHeap
from .pe_image import PEImage
from .signature import decode_type_blob
from .table_ids import TableId
from .tables_stream import CodedIndex, TablesStream

_METADATA_ROOT_SIGNATURE = 0x424A5342  # "BSJB"


class DotNetMetadataReader:
    def __init__(self, data: bytes):
        pe = PEImage(data)
        root_offset, _root_size = pe.metadata_root_offset_and_size()
        self._root_offset = root_offset
        streams = self._parse_root(data, root_offset)

        self.strings = StringsHeap(self._stream_bytes(data, streams, "#Strings"))
        self.user_strings = UserStringsHeap(self._stream_bytes(data, streams, "#US"))
        self.guids = GuidHeap(self._stream_bytes(data, streams, "#GUID"))
        self.blobs = BlobHeap(self._stream_bytes(data, streams, "#Blob"))

        tables_stream_name = "#~" if "#~" in streams else "#-"
        self.tables = TablesStream(self._stream_bytes(data, streams, tables_stream_name))

    @staticmethod
    def _parse_root(data: bytes, root_offset: int) -> "dict[str, tuple[int, int]]":
        signature = struct.unpack_from("<I", data, root_offset)[0]
        if signature != _METADATA_ROOT_SIGNATURE:
            raise ValueError("Not a metadata root: missing 'BSJB' signature")
        version_length = struct.unpack_from("<I", data, root_offset + 12)[0]
        offset = root_offset + 16 + version_length
        _flags, stream_count = struct.unpack_from("<HH", data, offset)
        offset += 4

        streams: "dict[str, tuple[int, int]]" = {}
        for _ in range(stream_count):
            stream_offset, stream_size = struct.unpack_from("<II", data, offset)
            offset += 8
            name_start = offset
            name_end = data.index(b"\x00", name_start)
            name = data[name_start:name_end].decode("ascii")
            offset = name_end + 1
            offset += -offset % 4
            streams[name] = (stream_offset, stream_size)
        return streams

    def _stream_bytes(self, data: bytes, streams: "dict[str, tuple[int, int]]", name: str) -> bytes:
        if name not in streams:
            return b""
        stream_offset, stream_size = streams[name]
        start = self._root_offset + stream_offset
        return data[start:start + stream_size]

    def type_def_full_name(self, row: dict) -> str:
        name = self.strings.get(row["name"])
        namespace = self.strings.get(row["namespace"])
        return f"{namespace}.{name}" if namespace else name

    def resolve_type_def_or_ref(self, tag: int, row_index_zero_based: int) -> str:
        """`tag`/`row_index_zero_based` as produced by `compressed_integer.decode_type_def_or_ref`
        (tag 0=TypeDef, 1=TypeRef, 2=TypeSpec) -- the encoding used *inside signature blobs*,
        distinct from (but numerically compatible with) the `TypeDefOrRef` coded index used in
        tables, which this also accepts via `resolve_coded_type_def_or_ref`."""
        row_number = row_index_zero_based + 1
        if tag == 0:
            row = self.tables.row(TableId.TYPE_DEF, row_number)
            return self.type_def_full_name(row) if row else "object"
        if tag == 1:
            row = self.tables.row(TableId.TYPE_REF, row_number)
            return self.type_def_full_name(row) if row else "object"
        if tag == 2:
            row = self.tables.row(TableId.TYPE_SPEC, row_number)
            if not row:
                return "object"
            blob = self.blobs.get(row["signature"])
            return decode_type_blob(blob, self.resolve_type_def_or_ref)
        return "object"

    def resolve_coded_type_def_or_ref(self, coded: CodedIndex) -> "str | None":
        """Resolves a `TypeDefOrRef`-kind `CodedIndex` (as stored in e.g. TypeDef.Extends or
        InterfaceImpl.Interface) to display text, or `None` for a null reference."""
        if coded.is_null() or coded.table is None:
            return None
        tag = {TableId.TYPE_DEF: 0, TableId.TYPE_REF: 1, TableId.TYPE_SPEC: 2}[coded.table]
        return self.resolve_type_def_or_ref(tag, coded.row_number - 1)

    def custom_attribute_type_name(self, row: dict) -> "str | None":
        """Resolves a CustomAttribute row's `type` coded index (MethodDef or MemberRef -- both
        are *constructors*, per II.22.10) to the attribute class's name, stripping a trailing
        "Attribute" suffix to match C# attribute-usage syntax (`[Foo]` for `FooAttribute`)."""
        coded = row["type"]
        if coded.is_null() or coded.table is None:
            return None
        if coded.table == TableId.METHOD_DEF:
            method_row = self.tables.row(TableId.METHOD_DEF, coded.row_number)
            if method_row is None:
                return None
            type_def_row = self._owning_type_def(TableId.METHOD_DEF, coded.row_number)
            name = self.type_def_full_name(type_def_row) if type_def_row else self.strings.get(method_row["name"])
        elif coded.table == TableId.MEMBER_REF:
            member_row = self.tables.row(TableId.MEMBER_REF, coded.row_number)
            if member_row is None:
                return None
            parent = member_row["class_"]
            name = self.resolve_coded_type_def_or_ref(parent) if parent.table in (
                TableId.TYPE_DEF, TableId.TYPE_REF, TableId.TYPE_SPEC
            ) else None
            if name is None:
                return None
        else:
            return None
        simple_name = name.rsplit(".", 1)[-1]
        if simple_name.endswith("Attribute"):
            simple_name = simple_name[: -len("Attribute")]
        return simple_name

    def _owning_type_def(self, member_table: TableId, member_row_number: int) -> "dict | None":
        """TypeDef rows store only the *first* Field/MethodDef row index they own (II.22.37);
        a member belongs to the TypeDef whose range `[field_list, next TypeDef's field_list)`
        (or `method_list`) contains it. Finds that owner by a linear scan -- module-sized
        assemblies make this cheap enough with no index needed."""
        type_defs = self.tables.rows(TableId.TYPE_DEF)
        column = "field_list" if member_table == TableId.FIELD else "method_list"
        for i, type_def in enumerate(type_defs):
            start = type_def[column]
            end = type_defs[i + 1][column] if i + 1 < len(type_defs) else float("inf")
            if start <= member_row_number < end:
                return type_def
        return None
