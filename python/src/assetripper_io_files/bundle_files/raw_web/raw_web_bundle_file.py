"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/RawWebBundleFile.cs

C#'s `RawWebBundleFile<THeader>` generic collapses here into one concrete base class
whose `_is_web_variant` class attribute replaces the `typeof(THeader) == typeof(WebBundleHeader)`
JIT-collapsed branch: the metadata-reading path differs by exactly that one bit -- the Raw
variant reads metadata straight out of the main stream, the Web variant first has to
LZMA-decompress the last chunk of the bundle to get at it.
"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType

from ...file_container import FileContainer
from ...streams.stream import MemoryStream
from ..lzma_compression import decompress_lzma_size_stream
from .raw_web_node import RawWebNode


class RawWebBundleFile(FileContainer):
    _is_web_variant: bool = False  # True on WebBundleFile (see web/web_bundle_file.py)

    def __init__(self):
        super().__init__()
        self.header = self._create_header()
        self.nodes: list[RawWebNode] = []

    def _create_header(self):
        raise NotImplementedError

    def read(self, stream) -> None:
        from ...resource_files.resource_file import ResourceFile

        base_position = stream.position
        self.header.read_from_stream(stream)
        header_size = stream.position - base_position
        if header_size != self.header.header_size:
            raise ValueError(
                f"Read {header_size} but expected {self.header.header_size} bytes "
                "while reading the raw/web bundle header."
            )

        metadata_size = (
            self.header.uncompressed_blocks_info_size
            if self.header._has_uncompressed_blocks_info_size(self.header.version)
            else 0
        )

        if self._is_web_variant:
            chunk_info = self.header.scenes[-1]
            data_stream = MemoryStream(bytearray(chunk_info.decompressed_size))
            decompress_lzma_size_stream(stream, chunk_info.compressed_size, data_stream)
            metadata_offset = 0
            data_stream.position = 0
        else:
            data_stream = stream
            metadata_offset = stream.position

        self.nodes = self._read_metadata(data_stream, metadata_size)

        for entry in self.nodes:
            buffer = bytearray(entry.size)
            data_stream.position = metadata_offset + entry.offset
            data_stream.read_exactly(buffer)
            self.add_resource_file(ResourceFile.from_bytes(bytes(buffer), self.file_path, entry.path))

    @staticmethod
    def _read_metadata(stream, metadata_size: int) -> "list[RawWebNode]":
        metadata_position = stream.position
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            count = reader.read_int32()
            nodes = [RawWebNode.read(reader) for _ in range(count)]
            reader.align_stream()
        if metadata_size > 0 and stream.position - metadata_position != metadata_size:
            raise ValueError(
                f"Read {stream.position - metadata_position} but expected {metadata_size} "
                "while reading bundle metadata"
            )
        return nodes

    def write(self, stream) -> None:
        self.header.write_to_stream(stream)
        raise NotImplementedError
