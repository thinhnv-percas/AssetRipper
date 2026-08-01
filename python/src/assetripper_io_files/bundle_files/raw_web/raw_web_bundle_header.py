"""Port of Source/AssetRipper.IO.Files/BundleFiles/RawWeb/RawWebBundleHeader.cs"""
from __future__ import annotations

from abc import abstractmethod

from ..bundle_header import BundleHeader
from ..bundle_version import BundleVersion
from ..hash128 import Hash128
from .bundle_scene import BundleScene


class RawWebBundleHeader(BundleHeader):
    def __init__(self):
        super().__init__()
        self.hash: Hash128 | None = None
        self.crc: int = 0
        self.minimum_streamed_bytes: int = 0
        """Minimum number of bytes to read for streamed bundles; equal to the whole bundle
        size for normal (non-streamed) bundles."""
        self.header_size: int = 0
        self.number_of_scenes_to_download_before_streaming: int = 0
        """1 for a streamed bundle; the number of LZMA chunk infos + mainData assets
        otherwise."""
        self.scenes: list[BundleScene] = []
        """LZMA chunk info."""
        self.complete_file_size: int = 0
        self.uncompressed_blocks_info_size: int = 0

    @property
    @abstractmethod
    def _magic_string(self) -> str: ...

    def read(self, reader) -> None:
        super().read(reader)
        if self._has_hash(self.version):
            self.hash = Hash128.read(reader)
            self.crc = reader.read_uint32()
        self.minimum_streamed_bytes = reader.read_uint32()
        self.header_size = reader.read_int32()
        self.number_of_scenes_to_download_before_streaming = reader.read_int32()

        scene_count = reader.read_int32()
        self.scenes = [BundleScene.read(reader) for _ in range(scene_count)]

        if self._has_complete_file_size(self.version):
            self.complete_file_size = reader.read_uint32()
        if self._has_uncompressed_blocks_info_size(self.version):
            self.uncompressed_blocks_info_size = reader.read_uint32()
        reader.align_stream()

    def write(self, writer) -> None:
        super().write(writer)
        raise NotImplementedError

    @staticmethod
    def _has_hash(generation: int) -> bool:
        """5.2.0 and greater / Bundle Version 4+."""
        return generation >= BundleVersion.BF_520A1

    @staticmethod
    def _has_complete_file_size(generation: int) -> bool:
        """2.6.0 and greater / Bundle Version 2+."""
        return generation >= BundleVersion.BF_260_340

    @staticmethod
    def _has_uncompressed_blocks_info_size(generation: int) -> bool:
        """3.5.0 and greater / Bundle Version 3+."""
        return generation >= BundleVersion.BF_350_4X
