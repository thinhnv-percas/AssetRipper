"""PE/COFF header parsing, just far enough to locate the CLI header (Cor20Header) and, from
that, the metadata root's file offset -- ECMA-335 II.25 and the Microsoft PE/COFF spec.

Only what's needed to get to metadata is implemented: no imports/exports/resources/relocations.
"""
from __future__ import annotations

import struct
from dataclasses import dataclass

_PE32_MAGIC = 0x10B
_PE32PLUS_MAGIC = 0x20B
_CLI_HEADER_DIRECTORY_INDEX = 14


@dataclass(frozen=True, slots=True)
class _Section:
    virtual_address: int
    virtual_size: int
    size_of_raw_data: int
    pointer_to_raw_data: int


class PEImage:
    """A parsed PE image, exposing RVA->file-offset mapping and the CLI header's
    MetaData directory (RVA + size)."""

    def __init__(self, data: bytes):
        self.data = data
        self._sections: "list[_Section]" = []
        self.cli_header_rva, self.cli_header_size = self._parse()

    def _parse(self) -> "tuple[int, int]":
        data = self.data
        if data[0:2] != b"MZ":
            raise ValueError("Not a PE file: missing 'MZ' DOS signature")
        pe_header_offset = struct.unpack_from("<I", data, 0x3C)[0]
        if data[pe_header_offset:pe_header_offset + 4] != b"PE\x00\x00":
            raise ValueError("Not a PE file: missing 'PE\\0\\0' signature")

        coff_offset = pe_header_offset + 4
        number_of_sections = struct.unpack_from("<H", data, coff_offset + 2)[0]
        size_of_optional_header = struct.unpack_from("<H", data, coff_offset + 16)[0]

        optional_header_offset = coff_offset + 20
        magic = struct.unpack_from("<H", data, optional_header_offset)[0]
        if magic == _PE32_MAGIC:
            data_directory_offset = optional_header_offset + 96
        elif magic == _PE32PLUS_MAGIC:
            data_directory_offset = optional_header_offset + 112
        else:
            raise ValueError(f"Unsupported PE optional header magic 0x{magic:04X}")

        cli_directory_offset = data_directory_offset + _CLI_HEADER_DIRECTORY_INDEX * 8
        cli_header_rva, cli_header_size = struct.unpack_from("<II", data, cli_directory_offset)

        section_table_offset = optional_header_offset + size_of_optional_header
        for i in range(number_of_sections):
            base = section_table_offset + i * 40
            virtual_size, virtual_address, size_of_raw_data, pointer_to_raw_data = struct.unpack_from(
                "<IIII", data, base + 8
            )
            self._sections.append(_Section(virtual_address, virtual_size, size_of_raw_data, pointer_to_raw_data))

        if cli_header_rva == 0:
            raise ValueError("Not a .NET assembly: no CLI header (COM Descriptor directory is empty)")
        return cli_header_rva, cli_header_size

    def rva_to_offset(self, rva: int) -> int:
        for section in self._sections:
            size = max(section.virtual_size, section.size_of_raw_data)
            if section.virtual_address <= rva < section.virtual_address + size:
                return section.pointer_to_raw_data + (rva - section.virtual_address)
        raise ValueError(f"RVA 0x{rva:X} is not contained in any section")

    def metadata_root_offset_and_size(self) -> "tuple[int, int]":
        """Reads the Cor20Header at `cli_header_rva` and returns the MetaData directory's
        (file offset, size)."""
        header_offset = self.rva_to_offset(self.cli_header_rva)
        metadata_rva, metadata_size = struct.unpack_from("<II", self.data, header_offset + 8)
        return self.rva_to_offset(metadata_rva), metadata_size
