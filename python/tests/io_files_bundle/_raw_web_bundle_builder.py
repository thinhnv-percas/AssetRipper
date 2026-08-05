"""
Test-only helper for building synthetic legacy "UnityRaw"/"UnityWeb" bundle byte layouts
by hand (Phase 14), mirroring _bundle_builder.py's approach for the modern UnityFS format --
no real pre-Unity5 bundle fixtures are available in this environment.
"""
from __future__ import annotations

import lzma
import struct

from assetripper_io_endian import EndianType, EndianWriter
from assetripper_io_files.bundle_files.bundle_version import BundleVersion
from assetripper_io_files.bundle_files.hash128 import Hash128
from assetripper_io_files.streams.stream import MemoryStream


def _lzma_size_compress(data: bytes) -> bytes:
    """Matches `LzmaCompression.decompress_lzma_size_stream`'s expected layout: 5 LZMA1
    properties bytes, then an 8-byte little-endian decompressed size, then the headerless
    LZMA1 stream (same trick `_bundle_builder._compress` uses for the plain LZMA case)."""
    comp = lzma.LZMACompressor(format=lzma.FORMAT_ALONE)
    alone = comp.compress(data) + comp.flush()
    properties = alone[:5]
    raw_lzma = alone[13:]  # strip FORMAT_ALONE's 8-byte size field
    return properties + struct.pack("<q", len(data)) + raw_lzma


def _write_header(
    magic: str,
    version: BundleVersion,
    header_size: int,
    scenes: list[tuple[int, int]],
    uncompressed_blocks_info_size: int,
) -> bytes:
    stream = MemoryStream()
    with EndianWriter(stream, EndianType.BIG_ENDIAN) as w:
        w.write_string_zero_term(magic)
        w.write_int32(int(version))
        w.write_string_zero_term("2.x.x")
        w.write_string_zero_term("2.x.x")
        if version >= BundleVersion.BF_520A1:
            Hash128().write(w)
            w.write_uint32(0)  # crc
        w.write_uint32(0)  # minimum_streamed_bytes
        w.write_int32(header_size)
        w.write_int32(1 if len(scenes) == 1 else 0)  # number_of_scenes_to_download_before_streaming
        w.write_int32(len(scenes))
        for compressed_size, decompressed_size in scenes:
            w.write_uint32(compressed_size)
            w.write_uint32(decompressed_size)
        if version >= BundleVersion.BF_260_340:
            w.write_uint32(0)  # complete_file_size
        if version >= BundleVersion.BF_350_4X:
            w.write_uint32(uncompressed_blocks_info_size)
        w.align_stream()
    return stream.to_array()


def _write_metadata(entries: dict, base_offset: int = 0) -> bytes:
    """Node offsets are relative to the start of the metadata region itself (this is what
    upstream's `metadataOffset` anchors to -- the position right after the bundle header,
    before the metadata is read), so the first entry's offset equals the metadata region's
    own (aligned) byte length, not 0 -- data starts immediately after metadata in the file.
    `base_offset` is that length; write once with 0 to measure it, then again for real."""
    stream = MemoryStream()
    offset = base_offset
    with EndianWriter(stream, EndianType.BIG_ENDIAN) as w:
        w.write_int32(len(entries))
        for name, data in entries.items():
            w.write_string_zero_term(name)
            w.write_int32(offset)
            w.write_int32(len(data))
            offset += len(data)
        w.align_stream()
    return stream.to_array()


def _build_metadata(entries: dict) -> bytes:
    placeholder = _write_metadata(entries, base_offset=0)
    return _write_metadata(entries, base_offset=len(placeholder))


def build_raw_bundle(entries: dict, version=BundleVersion.BF_520A1) -> bytes:
    metadata = _build_metadata(entries)
    data_blob = b"".join(entries.values())

    # header_size is self-referential but fixed-width (int32), so its own *value* doesn't
    # change the header's byte *length* -- one write pass with a placeholder is enough to
    # measure it, no probe-then-patch needed.
    header = _write_header(
        magic="UnityRaw", version=version, header_size=0, scenes=[], uncompressed_blocks_info_size=len(metadata)
    )
    header_size = len(header)
    header = _write_header(
        magic="UnityRaw",
        version=version,
        header_size=header_size,
        scenes=[],
        uncompressed_blocks_info_size=len(metadata),
    )
    assert len(header) == header_size
    return header + metadata + data_blob


def build_web_bundle(entries: dict, version=BundleVersion.BF_520A1) -> bytes:
    metadata = _build_metadata(entries)
    data_blob = b"".join(entries.values())
    combined = metadata + data_blob
    compressed = _lzma_size_compress(combined)
    scenes = [(len(compressed), len(combined))]

    header = _write_header(
        magic="UnityWeb", version=version, header_size=0, scenes=scenes, uncompressed_blocks_info_size=len(metadata)
    )
    header_size = len(header)
    header = _write_header(
        magic="UnityWeb",
        version=version,
        header_size=header_size,
        scenes=scenes,
        uncompressed_blocks_info_size=len(metadata),
    )
    assert len(header) == header_size
    return header + compressed
