"""Port of Source/AssetRipper.IO.Files/WebFiles/WebFile.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType, EndianWriter

from ..file_container import FileContainer
from .web_file_entry import WebFileEntry

_SIGNATURE = "UnityWebData1.0"


class WebFile(FileContainer):
    def read(self, stream) -> None:
        from ..resource_files.resource_file import ResourceFile

        base_position = stream.position
        entries: list[WebFileEntry] = []
        with EndianReader(stream, EndianType.LITTLE_ENDIAN) as reader:
            signature = reader.read_string_zero_term()
            assert signature == _SIGNATURE, f"Signature '{signature}' doesn't match '{_SIGNATURE}'"

            header_length = reader.read_int32()
            while reader.base_stream.position - base_position < header_length:
                entries.append(WebFileEntry.read(reader))

        for entry in entries:
            buffer = bytearray(entry.size)
            stream.position = entry.offset + base_position
            stream.read_exactly(buffer)
            self.add_resource_file(ResourceFile.from_bytes(bytes(buffer), self.file_path, entry.name))

    def write(self, stream, align_entries: bool = True) -> None:
        with EndianWriter(stream, EndianType.LITTLE_ENDIAN) as writer:
            self._write(writer, align_entries)

    def _write(self, writer, align_entries: bool = True) -> None:
        base_position = writer.base_stream.position
        writer.write_string_zero_term(_SIGNATURE)
        header_size_position = writer.base_stream.position

        entry_data_list = [(f.name, f.to_byte_array()) for f in self.all_files]

        entries_start_position = header_size_position + 4
        writer.base_stream.position = entries_start_position
        offset_positions = [0] * len(entry_data_list)
        for i, (entry_name, entry_data) in enumerate(entry_data_list):
            offset_positions[i] = writer.base_stream.position
            writer.base_stream.position += 4
            writer.write_int32(len(entry_data))
            writer.write_string(entry_name)
        entries_end_position = writer.base_stream.position

        writer.base_stream.position = header_size_position
        writer.write_int32(entries_end_position - base_position)
        writer.base_stream.position = entries_end_position

        for i, (_entry_name, entry_data) in enumerate(entry_data_list):
            if align_entries:
                writer.align_stream()
            data_position = writer.base_stream.position
            writer.base_stream.position = offset_positions[i]
            writer.write_int32(data_position - base_position)
            writer.base_stream.position = data_position
            writer.write_bytes(entry_data)

    @staticmethod
    def is_web_file(reader) -> bool:
        if reader.base_stream.length - reader.base_stream.position <= len(_SIGNATURE):
            return False
        position = reader.base_stream.position
        raw = bytearray(len(_SIGNATURE) + 1)
        reader.base_stream.read_exactly(raw)
        reader.base_stream.position = position
        terminator = raw.find(0)
        if terminator < 0:
            return False
        try:
            signature = bytes(raw[:terminator]).decode("utf-8")
        except UnicodeDecodeError:
            return False
        return signature == _SIGNATURE
