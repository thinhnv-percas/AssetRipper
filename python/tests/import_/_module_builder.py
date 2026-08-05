"""
Test-only hand-built .NET module (PE + CLI header + ECMA-335 metadata) construction, mirroring
the approach in _tree_builder.py / tests/io_files_bundle/_bundle_builder.py: no .NET SDK is
available in this environment to compile a real reference assembly, so the reader
(assetripper_import.structure.assembly.dotnet_metadata) is verified by constructing both sides
of the contract by hand -- a set of declarative table rows, and the exact bytes ECMA-335 says
those rows should produce.

This builder is deliberately narrow: only the table/heap features this port's Mono reader
actually consumes are supported (no unused-table padding, no encryption, no obfuscation).
"""
from __future__ import annotations

import struct
from dataclasses import dataclass, field

from assetripper_import.structure.assembly.dotnet_metadata.table_ids import CODED_INDEX_TABLES, TABLE_COLUMNS, TableId

_HEAP_SIZE_STRINGS_BIG = 0x01
_HEAP_SIZE_GUID_BIG = 0x02
_HEAP_SIZE_BLOB_BIG = 0x04


def compress_uint(value: int) -> bytes:
    if value < 0x80:
        return bytes([value])
    if value < 0x4000:
        return struct.pack(">H", value | 0x8000)
    return struct.pack(">I", value | 0xC0000000)


class HeapBuilder:
    def __init__(self):
        self.strings = bytearray(b"\x00")
        self.blobs = bytearray(b"\x00")
        self.guids = bytearray()

    def add_string(self, value: str) -> int:
        if value == "":
            return 0
        index = len(self.strings)
        self.strings += value.encode("utf-8") + b"\x00"
        return index

    def add_blob(self, value: bytes) -> int:
        if value == b"":
            return 0
        index = len(self.blobs)
        self.blobs += compress_uint(len(value)) + value
        return index

    def add_guid(self, value: bytes = b"\x00" * 16) -> int:
        self.guids += value
        return len(self.guids) // 16  # 1-based


@dataclass
class Coded:
    kind: str
    table: "TableId | None"
    row_number: int = 0

    @staticmethod
    def null(kind: str) -> "Coded":
        return Coded(kind, None, 0)


@dataclass
class ModuleBuilder:
    heaps: HeapBuilder = field(default_factory=HeapBuilder)
    rows: "dict[TableId, list[dict]]" = field(default_factory=dict)

    def add_row(self, table_id: TableId, **columns) -> int:
        """Returns the new row's 1-based row number."""
        self.rows.setdefault(table_id, []).append(columns)
        return len(self.rows[table_id])

    def row_count(self, table_id: TableId) -> int:
        return len(self.rows.get(table_id, []))

    def build(self) -> bytes:
        heap_sizes = 0
        if len(self.heaps.strings) > 0xFFFF:
            heap_sizes |= _HEAP_SIZE_STRINGS_BIG
        if len(self.heaps.guids) > 0xFFFF:
            heap_sizes |= _HEAP_SIZE_GUID_BIG
        if len(self.heaps.blobs) > 0xFFFF:
            heap_sizes |= _HEAP_SIZE_BLOB_BIG

        table_index_sizes = {
            table_id: (4 if self.row_count(table_id) > 0xFFFF else 2) for table_id in TableId
        }
        coded_index_sizes = {}
        coded_tag_bits = {}
        for kind, tables in CODED_INDEX_TABLES.items():
            tag_bits = max(1, (len(tables) - 1).bit_length())
            coded_tag_bits[kind] = tag_bits
            max_rows = max((self.row_count(t) for t in tables), default=0)
            coded_index_sizes[kind] = 4 if max_rows >= (1 << (16 - tag_bits)) else 2

        present_tables = [t for t in TableId if self.row_count(t) > 0]

        valid = 0
        for t in present_tables:
            valid |= 1 << t.value

        header = struct.pack(
            "<IBBBBQQ", 0, 2, 0, heap_sizes, 1, valid, 0
        )
        row_count_bytes = b"".join(struct.pack("<I", self.row_count(t)) for t in present_tables)

        row_bytes = bytearray()
        for table_id in present_tables:
            columns = TABLE_COLUMNS[table_id]
            for row in self.rows[table_id]:
                for column in columns:
                    col_name, kind = column[0], column[1]
                    value = row[col_name]
                    if kind == "u2":
                        row_bytes += struct.pack("<H", value)
                    elif kind == "u4":
                        row_bytes += struct.pack("<I", value)
                    elif kind == "str":
                        size = 4 if heap_sizes & _HEAP_SIZE_STRINGS_BIG else 2
                        row_bytes += value.to_bytes(size, "little")
                    elif kind == "guid":
                        size = 4 if heap_sizes & _HEAP_SIZE_GUID_BIG else 2
                        row_bytes += value.to_bytes(size, "little")
                    elif kind == "blob":
                        size = 4 if heap_sizes & _HEAP_SIZE_BLOB_BIG else 2
                        row_bytes += value.to_bytes(size, "little")
                    elif kind == "tbl":
                        target = column[2]
                        row_bytes += value.to_bytes(table_index_sizes[target], "little")
                    elif kind == "coded":
                        coded_kind = column[2]
                        coded_value: Coded = value
                        tag = 0 if coded_value.table is None else CODED_INDEX_TABLES[coded_kind].index(coded_value.table)
                        raw = (coded_value.row_number << coded_tag_bits[coded_kind]) | tag
                        row_bytes += raw.to_bytes(coded_index_sizes[coded_kind], "little")
                    else:
                        raise ValueError(kind)

        tables_stream = bytes(header) + row_count_bytes + bytes(row_bytes)
        return _wrap_metadata_root(
            tables_stream, bytes(self.heaps.strings), bytes(self.heaps.blobs), bytes(self.heaps.guids)
        )


def _pad4(data: bytes) -> bytes:
    return data + b"\x00" * (-len(data) % 4)


def _stream(name: str, data: bytes) -> "tuple[bytes, bytes]":
    """Returns (header-without-offset, padded-data) -- offset is filled in by the caller once
    every stream's size is known."""
    name_bytes = _pad4(name.encode("ascii") + b"\x00")
    return name_bytes, _pad4(data)


def _wrap_metadata_root(tables: bytes, strings: bytes, blobs: bytes, guids: bytes) -> bytes:
    version = b"v4.0.30319\x00\x00"  # already a multiple of 4 (12 bytes)
    streams = [("#~", tables), ("#Strings", strings), ("#GUID", guids), ("#Blob", blobs)]

    stream_headers = bytearray()
    stream_data = bytearray()
    placeholder = []
    for name, data in streams:
        name_bytes, padded = _stream(name, data)
        placeholder.append((name_bytes, padded))

    root_prefix = struct.pack("<IHHI", 0x424A5342, 1, 1, 0) + struct.pack("<I", len(version)) + version
    root_prefix += struct.pack("<HH", 0, len(streams))
    header_size = len(root_prefix) + sum(8 + len(name_bytes) for name_bytes, _ in placeholder)

    offset = header_size
    for name_bytes, padded in placeholder:
        stream_headers += struct.pack("<II", offset, len(padded)) + name_bytes
        stream_data += padded
        offset += len(padded)

    return bytes(root_prefix) + bytes(stream_headers) + bytes(stream_data)


def wrap_pe(metadata_root: bytes) -> bytes:
    """Wraps a metadata root's bytes in a minimal-but-valid PE32 image with one section
    containing the CLI header immediately followed by the metadata root."""
    cli_header = struct.pack("<IHH", 72, 2, 5)  # Cb, MajorRuntimeVersion, MinorRuntimeVersion
    metadata_rva_placeholder_offset = len(cli_header)
    cli_header += struct.pack("<II", 0, len(metadata_root))  # MetaData RVA (patched below), Size
    cli_header += struct.pack("<I", 1)  # Flags: COMIMAGE_FLAGS_ILONLY
    cli_header += struct.pack("<I", 0)  # EntryPointToken
    cli_header += struct.pack("<II", 0, 0)  # Resources
    cli_header += struct.pack("<II", 0, 0)  # StrongNameSignature
    cli_header += struct.pack("<II", 0, 0)  # CodeManagerTable
    cli_header += struct.pack("<II", 0, 0)  # VTableFixups
    cli_header += struct.pack("<II", 0, 0)  # ExportAddressTableJumps
    cli_header += struct.pack("<II", 0, 0)  # ManagedNativeHeader
    assert len(cli_header) == 72

    section_rva = 0x2000
    section_content = cli_header + metadata_root
    metadata_rva = section_rva + len(cli_header)
    section_content = (
        section_content[:metadata_rva_placeholder_offset]
        + struct.pack("<I", metadata_rva)
        + section_content[metadata_rva_placeholder_offset + 4:]
    )

    number_of_sections = 1
    size_of_optional_header = 96 + 16 * 8  # PE32 fixed fields + 16 data directories
    coff_header = struct.pack("<HHIIIHH", 0x14C, number_of_sections, 0, 0, 0, size_of_optional_header, 0x0102)

    optional_header = struct.pack(
        "<HBBIIIIII", 0x10B, 8, 0, 0, 0, 0, 0, 0, 0
    )  # Magic, LinkerVer x2, SizeOfCode, SizeOfInitData, SizeOfUninitData, EntryPoint, BaseOfCode, BaseOfData
    optional_header += struct.pack(
        "<IIIHHHHHHIIIIHHIIIIII",
        0x400000, 0x2000, 0x200, 0, 0, 0, 0, 4, 0, 0, 0x3000, 0x200, 0, 3, 0, 0x100000, 0x1000, 0x100000, 0x1000, 0, 16,
    )
    assert len(optional_header) == 96
    data_directories = bytearray()
    for i in range(16):
        if i == 14:
            data_directories += struct.pack("<II", section_rva, len(cli_header))
        else:
            data_directories += struct.pack("<II", 0, 0)
    optional_header += bytes(data_directories)
    assert len(optional_header) == size_of_optional_header

    section_name = b".text\x00\x00\x00"
    pointer_to_raw_data = 0x200
    section_header = section_name + struct.pack(
        "<IIIIIIHHI",
        len(section_content), section_rva, len(_pad4(section_content)), pointer_to_raw_data, 0, 0, 0, 0, 0x60000020,
    )

    dos_header = b"MZ" + b"\x00" * 0x3A + struct.pack("<I", 0x80)
    dos_header = dos_header.ljust(0x80, b"\x00")
    pe_signature = b"PE\x00\x00"

    header = dos_header + pe_signature + coff_header + optional_header + section_header
    header = header.ljust(pointer_to_raw_data, b"\x00")
    return header + _pad4(section_content)
