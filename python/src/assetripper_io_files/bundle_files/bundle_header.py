"""Port of Source/AssetRipper.IO.Files/BundleFiles/BundleHeader.cs

Utf8String fields (UnityWebBundleVersion/UnityWebMinimumRevision) are represented as
plain Python str, since this port has no separate Utf8String wrapper type.
"""
from __future__ import annotations

from abc import ABC, abstractmethod

from assetripper_io_endian import EndianReader, EndianType, EndianWriter

_MAX_SIGNATURE_LENGTH = 0x20


class BundleHeader(ABC):
    def __init__(self):
        self.version = 0
        self.unity_web_bundle_version: str = ""
        self.unity_web_minimum_revision: str = ""

    @property
    @abstractmethod
    def _magic_string(self) -> str: ...

    def read_from_stream(self, stream) -> None:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            self.read(reader)

    def read(self, reader) -> None:
        signature = reader.read_string_zero_term()
        assert signature == self._magic_string
        self.version = reader.read_int32()
        self.unity_web_bundle_version = reader.read_string_zero_term()
        self.unity_web_minimum_revision = reader.read_string_zero_term()

    def write_to_stream(self, stream) -> None:
        with EndianWriter(stream, EndianType.BIG_ENDIAN) as writer:
            self.write(writer)

    def write(self, writer) -> None:
        writer.write_string_zero_term(self._magic_string)
        writer.write_int32(int(self.version))
        writer.write_string_zero_term(self.unity_web_bundle_version)
        writer.write_string_zero_term(self.unity_web_minimum_revision)

    @staticmethod
    def _is_bundle_header_signature(reader, magic_string: str) -> bool:
        """Port of the bounded `ReadStringZeroTerm(maxLength, out)` check: reads up to
        _MAX_SIGNATURE_LENGTH bytes looking for a null terminator, without risking an
        unbounded read against arbitrary (non-bundle) input."""
        if reader.base_stream.length < _MAX_SIGNATURE_LENGTH:
            return False

        position = reader.base_stream.position
        buffer = bytearray(_MAX_SIGNATURE_LENGTH)
        reader.base_stream.read_exactly(buffer)
        reader.base_stream.position = position

        terminator = buffer.find(0)
        if terminator < 0:
            return False
        try:
            signature = bytes(buffer[:terminator]).decode("utf-8")
        except UnicodeDecodeError:
            return False
        return signature == magic_string
