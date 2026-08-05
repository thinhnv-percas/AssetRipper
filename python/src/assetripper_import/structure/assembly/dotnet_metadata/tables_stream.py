"""Parses the `#~` (or `#-`) tables stream header and every present table's rows, per
ECMA-335 II.24.2.6.

Row decoding happens in two passes because column widths are interdependent: a "simple table
index" column is 2 bytes unless the *target* table's row count exceeds 0xFFFF, and a "coded
index" column's width depends on the *largest* row count among all the tables it can point
into. Both are only knowable once every table's row count has been read from the header.
"""
from __future__ import annotations

import struct
from dataclasses import dataclass

from .table_ids import CODED_INDEX_TABLES, TABLE_COLUMNS, TableId

_HEAP_SIZE_STRINGS_BIG = 0x01
_HEAP_SIZE_GUID_BIG = 0x02
_HEAP_SIZE_BLOB_BIG = 0x04


@dataclass(frozen=True, slots=True)
class CodedIndex:
    """A decoded coded-index column value: which table it refers to, and that table's
    1-based row number (0 means "null reference", matching a simple table index's 0)."""

    kind: str
    table: "TableId | None"
    row_number: int

    def is_null(self) -> bool:
        return self.row_number == 0


class TablesStream:
    """Row access: `rows(TableId.TYPE_DEF)` returns a list of dicts, one per row, keyed by the
    column names declared in `table_ids.TABLE_COLUMNS`. Simple table-index and coded-index
    columns are already resolved to (table, 1-based row number); heap index columns are left
    as raw indexes for the caller to resolve against the matching heap."""

    def __init__(self, data: bytes):
        reserved, major, minor, heap_sizes, reserved2, valid, sorted_mask = struct.unpack_from(
            "<IBBBBQQ", data, 0
        )
        offset = 24

        self._string_index_size = 4 if heap_sizes & _HEAP_SIZE_STRINGS_BIG else 2
        self._guid_index_size = 4 if heap_sizes & _HEAP_SIZE_GUID_BIG else 2
        self._blob_index_size = 4 if heap_sizes & _HEAP_SIZE_BLOB_BIG else 2

        self.row_counts: "dict[TableId, int]" = {}
        present_tables: "list[TableId]" = []
        for table_id in TableId:
            if valid & (1 << table_id.value):
                present_tables.append(table_id)
        for table_id in present_tables:
            (count,) = struct.unpack_from("<I", data, offset)
            offset += 4
            self.row_counts[table_id] = count

        self._table_index_sizes = {
            table_id: (4 if self.row_counts.get(table_id, 0) > 0xFFFF else 2) for table_id in TableId
        }
        self._coded_index_sizes = {
            kind: self._coded_index_size(tables) for kind, tables in CODED_INDEX_TABLES.items()
        }

        self._rows: "dict[TableId, list[dict]]" = {}
        for table_id in present_tables:
            offset = self._decode_table(data, offset, table_id)

    def _coded_index_size(self, tables: "list[TableId]") -> int:
        tag_bits = max(1, (len(tables) - 1).bit_length())
        max_rows = max((self.row_counts.get(t, 0) for t in tables), default=0)
        return 4 if max_rows >= (1 << (16 - tag_bits)) else 2

    def _decode_table(self, data: bytes, offset: int, table_id: TableId) -> int:
        columns = TABLE_COLUMNS[table_id]
        rows = []
        for _ in range(self.row_counts[table_id]):
            row = {}
            for column in columns:
                name, kind = column[0], column[1]
                if kind == "u2":
                    (value,) = struct.unpack_from("<H", data, offset)
                    offset += 2
                elif kind == "u4":
                    (value,) = struct.unpack_from("<I", data, offset)
                    offset += 4
                elif kind == "str":
                    value, offset = self._read_index(data, offset, self._string_index_size)
                elif kind == "guid":
                    value, offset = self._read_index(data, offset, self._guid_index_size)
                elif kind == "blob":
                    value, offset = self._read_index(data, offset, self._blob_index_size)
                elif kind == "tbl":
                    target_table = column[2]
                    raw, offset = self._read_index(data, offset, self._table_index_sizes[target_table])
                    value = raw
                elif kind == "coded":
                    coded_kind = column[2]
                    raw, offset = self._read_index(data, offset, self._coded_index_sizes[coded_kind])
                    value = self._decode_coded_index(coded_kind, raw)
                else:
                    raise ValueError(f"Unknown column kind {kind!r}")
                row[name] = value
            rows.append(row)
        self._rows[table_id] = rows
        return offset

    @staticmethod
    def _read_index(data: bytes, offset: int, size: int) -> "tuple[int, int]":
        if size == 2:
            (value,) = struct.unpack_from("<H", data, offset)
        else:
            (value,) = struct.unpack_from("<I", data, offset)
        return value, offset + size

    @staticmethod
    def _decode_coded_index(kind: str, raw: int) -> CodedIndex:
        tables = CODED_INDEX_TABLES[kind]
        tag_bits = max(1, (len(tables) - 1).bit_length())
        tag_mask = (1 << tag_bits) - 1
        tag = raw & tag_mask
        row_number = raw >> tag_bits
        table = tables[tag] if tag < len(tables) else None
        return CodedIndex(kind, table, row_number)

    def rows(self, table_id: TableId) -> "list[dict]":
        return self._rows.get(table_id, [])

    def row(self, table_id: TableId, row_number: int) -> "dict | None":
        """1-based row lookup, matching how table-index/coded-index columns are stored."""
        if row_number <= 0:
            return None
        rows = self._rows.get(table_id, [])
        if row_number > len(rows):
            return None
        return rows[row_number - 1]
