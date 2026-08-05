"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/SerializedFileHeader.cs

The file header is found at the beginning of an asset file. The header always uses big
endian byte order.
"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_io_endian import EndianReader, EndianType, EndianWriter

from ..format_version import FormatVersion

HEADER_MIN_SIZE = 16
METADATA_MIN_SIZE = 13


def has_endianess(generation: FormatVersion) -> bool:
    """3.5.0 and greater / Format Version 9+."""
    return generation >= FormatVersion.UNKNOWN_9


def has_large_files_support(generation: FormatVersion) -> bool:
    """2020.1.0 and greater / Format Version 22+."""
    return generation >= FormatVersion.LARGE_FILES_SUPPORT


@dataclass(slots=True, eq=True)
class SerializedFileHeader:
    metadata_size: int = 0
    """Size of the metadata parts of the file."""
    file_size: int = 0
    """Size of the whole file."""
    version: FormatVersion = FormatVersion.UNSUPPORTED
    """File format version, incremented after major format changes."""
    data_offset: int = 0
    """Offset to the serialized object data (start of the first object)."""
    endianess: bool = False
    """Presumably controls the byte order. Normally 0, which may indicate little endian."""

    @staticmethod
    def is_serialized_file_header(reader: EndianReader, file_size: int) -> bool:
        initial_position = reader.base_stream.position

        # Sanity check that there is enough room here first.
        if reader.base_stream.position + HEADER_MIN_SIZE > reader.base_stream.length:
            return False

        # Pre-22 format: Metadata Size, File Size, Generation
        metadata_size = reader.read_int32()
        header_defined_file_size = reader.read_uint32()

        # Read generation first: the format changed hugely in gen 22 (unity 2020).
        # Generation is always at [base + 0x8].
        try:
            generation = FormatVersion(reader.read_int32())
        except ValueError:
            reader.base_stream.position = initial_position
            return False

        if generation >= FormatVersion.LARGE_FILES_SUPPORT:
            # 22 format: metadata size (32-bit int) at 0x14, then file size (64-bit int).
            reader.base_stream.position = initial_position + 0x14
            metadata_size = reader.read_int32()
            header_defined_file_size = reader.read_uint64()

        reader.base_stream.position = initial_position

        return (
            metadata_size >= METADATA_MIN_SIZE
            and header_defined_file_size >= HEADER_MIN_SIZE + METADATA_MIN_SIZE
            and file_size >= 0
            and header_defined_file_size == file_size
        )

    def read(self, stream_or_reader) -> None:
        if isinstance(stream_or_reader, EndianReader):
            self._read(stream_or_reader)
        else:
            with EndianReader(stream_or_reader, EndianType.BIG_ENDIAN) as reader:
                self._read(reader)

    def _read(self, reader: EndianReader) -> None:
        # For gen 22+ these will be zero.
        self.metadata_size = reader.read_int32()
        self.file_size = reader.read_uint32()

        self.version = FormatVersion(reader.read_int32())

        # For gen 22+ this will be zero.
        self.data_offset = reader.read_uint32()

        if has_endianess(self.version):
            self.endianess = reader.read_boolean()
            reader.align_stream()
        if has_large_files_support(self.version):
            self.metadata_size = reader.read_uint32()
            self.file_size = reader.read_int64()
            self.data_offset = reader.read_int64()
            reader.read_int64()  # unknown

        if self.metadata_size <= 0:
            raise Exception(f"Invalid metadata size {self.metadata_size}")

        try:
            FormatVersion(self.version)
        except ValueError:
            raise Exception(f"Unsupported file generation {self.version}'")

    def write(self, stream_or_writer) -> None:
        if isinstance(stream_or_writer, EndianWriter):
            self._write(stream_or_writer)
        else:
            with EndianWriter(stream_or_writer, EndianType.BIG_ENDIAN) as writer:
                self._write(writer)

    def _write(self, writer: EndianWriter) -> None:
        # 0x00
        if has_large_files_support(self.version):
            writer.write_int32(0)
            writer.write_uint32(0)
        else:
            writer.write_int32(self.metadata_size)
            writer.write_uint32(self.file_size)

        # 0x08
        writer.write_int32(int(self.version))

        # 0x0c
        if has_large_files_support(self.version):
            writer.write_uint32(0)
        else:
            writer.write_uint32(self.data_offset)

        # 0x10
        if has_endianess(self.version):
            writer.write_boolean(self.endianess)
            writer.align_stream()

        # 0x14
        if has_large_files_support(self.version):
            writer.write_uint32(self.metadata_size)
            writer.write_int64(self.file_size)
            writer.write_int64(self.data_offset)
            writer.write_int64(0)
