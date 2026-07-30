"""Port of Source/AssetRipper.Assets/Collections/AssetCollection.cs

A collection of IUnityObjectBase assets.
"""
from __future__ import annotations

from assetripper_io_endian import EndianType
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion

from ..metadata.pptr import PPtr
from ..null_object import NullObject


class AssetCollection:
    def __init__(self, bundle):
        self._dependencies: list["AssetCollection | None"] = [self]
        self.bundle = bundle
        bundle.add_collection(self)

        self.name: str = ""
        self.file_path: str = ""
        self._assets: dict[int, object] = {}
        self.original_version: UnityVersion = UnityVersion()
        self.version: UnityVersion = UnityVersion()
        self.platform: BuildTarget = BuildTarget.NO_TARGET
        self.flags: TransferInstructionFlags = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS
        self.endian_type: EndianType = EndianType.LITTLE_ENDIAN
        self.scene = None

    @property
    def dependencies(self) -> list["AssetCollection | None"]:
        """The zeroth entry is always `self`, for correspondence with file indices.
        Entries are None if they could not be found."""
        return self._dependencies

    @property
    def assets(self) -> dict[int, object]:
        return self._assets

    @property
    def is_scene(self) -> bool:
        return self.scene is not None

    def add_dependency(self, dependency: "AssetCollection") -> int:
        if dependency in self._dependencies:
            return self._dependencies.index(dependency)
        elif self._is_compatible_dependency(dependency):
            self._dependencies.append(dependency)
            return len(self._dependencies) - 1
        else:
            raise ValueError("Dependency is not compatible with this AssetCollection.")

    def _set_dependency(self, index: int, collection: "AssetCollection | None") -> None:
        if index < 1:
            raise IndexError(index)
        elif index < len(self._dependencies):
            self._dependencies[index] = collection
        else:
            while len(self._dependencies) < index:
                self._dependencies.append(None)
            self._dependencies.append(collection)

    def _is_compatible_dependency(self, dependency: "AssetCollection") -> bool:
        return True

    def create_pptr(self, asset) -> PPtr:
        if asset is None:
            return PPtr()
        try:
            file_index = self._dependencies.index(asset.collection)
        except ValueError:
            raise ValueError("Asset doesn't belong to this AssetCollection or any of its dependencies") from None
        return PPtr(file_index, asset.path_id)

    def force_create_pptr(self, asset) -> PPtr:
        if asset is None:
            return PPtr()
        file_index = self.add_dependency(asset.collection)
        return PPtr(file_index, asset.path_id)

    def add_asset(self, asset) -> None:
        self._validate_asset_for_add(asset)
        self._assets[asset.path_id] = asset

    def _validate_asset_for_add(self, asset) -> None:
        if asset.collection is not self:
            raise ValueError("AssetInfo must have this marked as its collection.")
        if asset.path_id == 0:
            raise ValueError("The zero path ID is reserved for null PPtr's.")

    def replace_asset(self, replacement) -> None:
        if replacement.collection is not self:
            raise ValueError("AssetInfo must have this marked as its collection.")
        original = self._assets.get(replacement.path_id)
        if original is None:
            raise ValueError("There is no existing asset with this PathID.")
        if replacement.class_id != original.class_id:
            raise ValueError("The replacement asset's class id is not equal to the original asset's class id.")
        self._assets[replacement.path_id] = replacement

    def __str__(self) -> str:
        return self.name

    def get_asset(self, path_id: int, cls: type | None = None):
        """Port of the untyped and generic `TryGetAsset(long pathID)` overloads,
        returning the asset (or None) directly instead of a (bool, out) pair."""
        obj = self._assets.get(path_id)
        if obj is None:
            return None
        if cls is not None and issubclass(cls, NullObject):
            # cls itself derives from NullObject, so NullObject instances are allowed.
            return obj if isinstance(obj, cls) else None
        else:
            if isinstance(obj, NullObject):
                return None
            if cls is None or isinstance(obj, cls):
                return obj
            return None

    def get_asset_in_dependency(self, file_index: int, path_id: int, cls: type | None = None):
        dependency = self._try_get_dependency(file_index)
        if dependency is not None:
            return dependency.get_asset(path_id, cls)
        return None

    def get_asset_by_pptr(self, pptr: PPtr, cls: type | None = None):
        return self.get_asset_in_dependency(pptr.file_id, pptr.path_id, cls)

    def _try_get_dependency(self, file_index: int) -> "AssetCollection | None":
        if file_index < 0 or file_index >= len(self._dependencies):
            return None
        return self._dependencies[file_index]

    def __iter__(self):
        return iter(self._assets.values())

    def __len__(self) -> int:
        return len(self._assets)
