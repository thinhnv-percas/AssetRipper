"""Port of Source/AssetRipper.IO.Files/BundleFiles/FileStream/FileStreamBundleFile.cs

The "UnityFS" bundle format -- the modern AssetBundle container almost all current
Unity games ship (level0/level1/.../*.unity3d/*.bundle files), as opposed to the
legacy pre-5.x Archive/Raw/Web bundle variants (not ported).
"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType, EndianWriter

from ...exceptions import DecompressionFailedException, UnsupportedBundleDecompression
from ...extensions.stream_extensions import align
from ...failed_file import FailedFile
from ...file_container import FileContainer
from ...resource_files.resource_file import ResourceFile
from ...streams.stream import MemoryStream
from ..bundle_flags import (
    get_block_info_need_padding_at_start,
    get_blocks_and_directory_info_combined,
    get_blocks_info_at_the_end,
    get_compression,
)
from ..bundle_version import BundleVersion
from ..compression_type import CompressionType
from ..directory_info import DirectoryInfo
from ..lzma_compression import decompress_lzma_stream
from .blocks_info import BlocksInfo
from .bundle_file_block_reader import decompress_blocks, read_entry
from .file_stream_bundle_header import FileStreamBundleHeader


class FileStreamBundleFile(FileContainer):
    def __init__(self):
        super().__init__()
        self.header = FileStreamBundleHeader()
        self.blocks_info = BlocksInfo()
        self.directory_info = DirectoryInfo()

    def read(self, stream) -> None:
        base_position = stream.position
        self.header.read_from_stream(stream)
        header_size = stream.position - base_position
        self._read_metadata(stream, base_position)
        self._read_data(stream, base_position, header_size)

    def write(self, stream) -> None:
        """Port of FileStreamBundleFile.Write. Like the C# original, this only
        supports writing bundles with no directory entries (WriteFileStreamData raises
        NotImplementedError otherwise, same as C#'s own unfinished write path)."""
        base_position = stream.position
        self.header.write_to_stream(stream)
        header_size = stream.position - base_position
        self._write_metadata(stream, base_position)
        self._write_data(stream, base_position, header_size)

    # -- read path --------------------------------------------------------------

    def _read_metadata(self, stream, base_position: int) -> None:
        if self.header.version >= BundleVersion.BF_LARGE_FILES_SUPPORT:
            align(stream, 16)
        if get_blocks_info_at_the_end(self.header.flags):
            stream.position = base_position + (self.header.size - self.header.compressed_blocks_info_size)

        DecompressionFailedException.throw_if_uncompressed_size_is_negative(self.name_fixed, self.header.uncompressed_blocks_info_size)

        metadata_compression = get_compression(self.header.flags)
        if metadata_compression == CompressionType.NONE:
            # Unlike the compressed cases (which must decompress into a fixed-size
            # buffer), the uncompressed case reads BlocksInfo/DirectoryInfo directly
            # off the live stream -- they're self-describing via length-prefixed
            # arrays, so no fixed byte count is needed up front (matches C#, which
            # also doesn't pre-slice a buffer for CompressionType.None).
            with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
                self._read_blocks_and_directory_info(reader)
            return

        metadata_bytes = self._decompress_metadata_bytes(stream, metadata_compression)
        metadata_stream = MemoryStream(metadata_bytes)
        with EndianReader(metadata_stream, EndianType.BIG_ENDIAN) as reader:
            self._read_blocks_and_directory_info(reader)

    def _read_blocks_and_directory_info(self, reader) -> None:
        self.blocks_info = BlocksInfo.read(reader)
        if get_blocks_and_directory_info_combined(self.header.flags):
            self.directory_info = DirectoryInfo.read(reader)

    def _decompress_metadata_bytes(self, stream, metadata_compression: CompressionType) -> bytes:
        uncompressed_size = self.header.uncompressed_blocks_info_size
        compressed_size = self.header.compressed_blocks_info_size

        if metadata_compression == CompressionType.LZMA:
            output = MemoryStream()
            decompress_lzma_stream(stream, compressed_size, output, uncompressed_size)
            return output.to_array()
        elif metadata_compression in (CompressionType.LZ4, CompressionType.LZ4_HC):
            import lz4.block

            compressed = bytearray(compressed_size)
            stream.read_exactly(compressed)
            decompressed = lz4.block.decompress(bytes(compressed), uncompressed_size=uncompressed_size)
            if len(decompressed) != uncompressed_size:
                DecompressionFailedException.throw_incorrect_number_bytes_written(
                    self.name_fixed, metadata_compression, uncompressed_size, len(decompressed)
                )
            return decompressed
        elif metadata_compression == CompressionType.LZHAM:
            UnsupportedBundleDecompression.throw_lzham(self.name_fixed)
        else:
            UnsupportedBundleDecompression.throw(self.name_fixed, metadata_compression)
        raise AssertionError("unreachable")  # the throw_* helpers above always raise

    def _read_data(self, stream, base_position: int, header_size: int) -> None:
        if get_blocks_info_at_the_end(self.header.flags):
            stream.position = base_position + header_size
            if self.header.version >= BundleVersion.BF_LARGE_FILES_SUPPORT:
                align(stream, 16)
        if get_block_info_need_padding_at_start(self.header.flags):
            align(stream, 16)

        decompressed = decompress_blocks(stream, self.blocks_info)
        for entry in self.directory_info.nodes:
            try:
                entry_stream = read_entry(decompressed, entry)
                self.add_resource_file(ResourceFile(entry_stream, self.file_path, entry.path))
            except Exception as ex:  # noqa: BLE001 -- per-entry error boundary, matches the C# try/catch around ReadEntry
                failed_file = FailedFile()
                failed_file.name = entry.path
                failed_file.file_path = self.file_path
                failed_file.stack_trace = repr(ex)
                self.add_failed_file(failed_file)

    # -- write path (mirrors the C# original's limited support) -----------------

    def _write_metadata(self, stream, base_position: int) -> None:
        if self.header.version >= BundleVersion.BF_LARGE_FILES_SUPPORT:
            align(stream, 16)
        if get_blocks_info_at_the_end(self.header.flags):
            stream.position = base_position + (self.header.size - self.header.compressed_blocks_info_size)

        metadata_compression = get_compression(self.header.flags)
        if metadata_compression == CompressionType.NONE:
            self._write_metadata_to(stream, self.header.uncompressed_blocks_info_size)
        elif metadata_compression == CompressionType.LZMA:
            raise NotImplementedError(str(CompressionType.LZMA))
        elif metadata_compression in (CompressionType.LZ4, CompressionType.LZ4_HC):
            import lz4.block

            uncompressed_size = self.header.uncompressed_blocks_info_size
            compressed_size = self.header.compressed_blocks_info_size

            uncompressed_stream = MemoryStream()
            self._write_metadata_to(uncompressed_stream, uncompressed_size)
            compressed_bytes = lz4.block.compress(uncompressed_stream.to_array(), store_size=False)
            if len(compressed_bytes) != compressed_size:
                raise ValueError(
                    f"Incorrect number of bytes written. {len(compressed_bytes)} instead of "
                    f"{compressed_size} for {len(compressed_bytes)} compressed bytes"
                )
            stream.write(compressed_bytes, 0, len(compressed_bytes))
        else:
            raise NotImplementedError(f"Bundle compression '{metadata_compression.name}' isn't supported")

    def _write_metadata_to(self, stream, metadata_size: int) -> None:
        metadata_position = stream.position
        with EndianWriter(stream, EndianType.BIG_ENDIAN) as writer:
            self.blocks_info.write(writer)
            if get_blocks_and_directory_info_combined(self.header.flags):
                self.directory_info.write(writer)
        if metadata_size > 0 and stream.position - metadata_position != metadata_size:
            raise ValueError(f"Wrote {stream.position - metadata_position} but expected {metadata_size} while writing bundle metadata")

    def _write_data(self, stream, base_position: int, header_size: int) -> None:
        if get_blocks_info_at_the_end(self.header.flags):
            stream.position = base_position + header_size
            if self.header.version >= BundleVersion.BF_LARGE_FILES_SUPPORT:
                align(stream, 16)
        if get_block_info_need_padding_at_start(self.header.flags):
            align(stream, 16)

        if len(self.directory_info.nodes) == 0:
            return
        raise NotImplementedError
