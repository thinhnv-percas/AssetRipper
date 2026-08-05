"""Port of Source/AssetRipper.IO.Files/CompressedFiles/Brotli/BrotliFile.cs

Uses the `brotli` PyPI package (Google's reference bindings) for decompression -- no
brotli support in the Python standard library. `is_brotli_file` is a byte-for-byte port of
upstream's detection heuristic: Unity writes the plaintext signature
`"UnityWeb Compressed Content (brotli)"` as the payload of the very first (uncompressed)
Brotli meta-block, so detecting it means partially parsing the Brotli meta-block header
(WBITS byte, then the ISLAST/ISLASTEMPTY/MNIBBLES-style size bits) to recover that
meta-block's declared length and compare it against the signature's length, without
running a real Brotli decoder.
"""
from __future__ import annotations

from ...failed_file import FailedFile
from ..compressed_file import CompressedFile

_BROTLI_SIGNATURE = b"UnityWeb Compressed Content (brotli)"


class BrotliFile(CompressedFile):
    def read(self, stream) -> None:
        from ...resource_files.resource_file import ResourceFile

        try:
            import brotli

            remaining = stream.length - stream.position
            payload = bytearray(remaining)
            stream.read_exactly(payload)
            decompressed = brotli.decompress(bytes(payload))
            self.uncompressed_file = ResourceFile.from_bytes(decompressed, self.file_path, self.name)
        except Exception as ex:  # noqa: BLE001 -- matches upstream's catch-all + FailedFile
            self.uncompressed_file = FailedFile()
            self.uncompressed_file.name = self.name
            self.uncompressed_file.file_path = self.file_path
            self.uncompressed_file.stack_trace = repr(ex)

    def write(self, stream) -> None:
        raise NotImplementedError

    @staticmethod
    def is_brotli_file(stream) -> bool:
        remaining = stream.length - stream.position
        if remaining < 4:
            return False

        position = stream.position
        stream.position += 1
        bt = stream.read_byte()
        size_bytes = bt & 0x3

        if stream.position + size_bytes > stream.length:
            stream.position = position
            return False

        length = 0
        for i in range(size_bytes):
            nbt = stream.read_byte()
            bits = (bt >> 2) | ((nbt & 0x3) << 6)
            bt = nbt
            length += bits << (8 * i)

        if length != len(_BROTLI_SIGNATURE) or stream.position + length > stream.length:
            stream.position = position
            return False

        buffer = bytearray(len(_BROTLI_SIGNATURE))
        stream.read_exactly(buffer)
        stream.position = position
        return bytes(buffer) == _BROTLI_SIGNATURE
