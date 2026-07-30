"""Port of Source/AssetRipper.Assets/IUnityAssetBase.cs"""
from __future__ import annotations

from abc import ABC, abstractmethod


class IUnityAssetBase(ABC):
    @property
    @abstractmethod
    def serialized_version(self) -> int: ...

    @property
    @abstractmethod
    def flow_mapped_in_yaml(self) -> bool:
        """See TransferMetaFlags.TRANSFER_USING_FLOW_MAPPING_STYLE."""
        ...

    @abstractmethod
    def ignore_field_in_meta_files(self, field_name: str) -> bool:
        """See TransferMetaFlags.IGNORE_IN_META_FILES. Returns True if `field_name`
        (per the original naming) should not be emitted in yaml meta files."""
        ...

    @abstractmethod
    def read_editor(self, reader) -> None: ...

    @abstractmethod
    def read_release(self, reader) -> None: ...

    @abstractmethod
    def write_editor(self, writer) -> None: ...

    @abstractmethod
    def write_release(self, writer) -> None: ...

    @abstractmethod
    def copy_values(self, source: "IUnityAssetBase | None", converter) -> None: ...

    @abstractmethod
    def reset(self) -> None: ...

    def walk_editor(self, walker) -> None:
        """Walk this asset using original naming."""
        self.walk_standard(walker)

    def walk_release(self, walker) -> None:
        """Walk this asset using original naming."""
        self.walk_standard(walker)

    @abstractmethod
    def walk_standard(self, walker) -> None:
        """Walk this asset using standardized naming."""
        ...

    @abstractmethod
    def fetch_dependencies(self):
        """Yields (name, PPtr) pairs."""
        ...

    @abstractmethod
    def add_to_equality_comparer(self, other: "IUnityAssetBase", comparer) -> bool | None:
        """Compares this object to another for deep value equality. `other` is expected to
        be not None and of the same type as this object. Returns None if it could not be
        immediately determined."""
        ...


def read(asset: IUnityAssetBase, reader, flags) -> None:
    """Port of UnityAssetBaseExtensions.Read(this IUnityAssetBase, ref EndianSpanReader, TransferInstructionFlags)."""
    from assetripper_io_files.serialized_files.transfer_instruction_flags import is_release

    if is_release(flags):
        asset.read_release(reader)
    else:
        asset.read_editor(reader)
