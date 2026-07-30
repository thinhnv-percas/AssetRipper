"""Port of Source/AssetRipper.Assets/IUnityObjectBase.cs"""
from __future__ import annotations

from abc import abstractmethod

from .i_unity_asset_base import IUnityAssetBase


class IUnityObjectBase(IUnityAssetBase):
    @property
    @abstractmethod
    def asset_info(self):
        """The key information about the location of this asset."""
        ...

    @property
    @abstractmethod
    def class_id(self) -> int:
        """The native class ID number of this object."""
        ...

    @property
    @abstractmethod
    def class_name(self) -> str:
        """The native class name of this object."""
        ...

    @property
    @abstractmethod
    def collection(self):
        """The AssetCollection this object belongs to."""
        ...

    @property
    @abstractmethod
    def path_id(self) -> int:
        """The AssetInfo.path_id of this object within `collection`."""
        ...

    # Original/override path components, and asset bundle name/main asset, are plain
    # mutable attributes on the concrete UnityObjectBase, not abstract properties here --
    # Python doesn't need the interface/implementation split C# uses for auto-properties.

    def get_best_directory(self) -> str:
        """In order of preference: override_directory, original_directory, "Assets/{class_name}"."""
        if self.override_directory is not None or self.override_name is not None:
            return self.override_directory if self.override_directory is not None else "Assets"
        elif self.original_directory is not None or self.original_name is not None:
            return self.original_directory if self.original_directory is not None else "Assets"
        else:
            return "Assets/" + self.class_name

    def get_best_name(self) -> str:
        """In order of preference: override_name, INamed.name, original_name, class_name."""
        if self.override_name is not None:
            return self.override_name
        name = getattr(self, "name", None)
        if name:
            return name
        elif self.original_name is not None:
            return self.original_name
        else:
            return self.class_name

    def get_best_extension(self) -> str | None:
        """In order of preference: override_extension, original_extension."""
        return self.override_extension if self.override_extension is not None else self.original_extension

    def copy_values_from(self, source: "IUnityObjectBase | None") -> None:
        """Port of the sealed `CopyValues(IUnityObjectBase? source)` default method
        (named differently here since Python can't overload on parameter count)."""
        from assetripper_assets.cloning.pptr_converter import PPtrConverter

        if source is None:
            self.reset()
        else:
            self.copy_values(source, PPtrConverter(source.collection, self.collection))


def read(asset: IUnityObjectBase, reader) -> None:
    """Port of UnityObjectBaseExtensions.Read(this IUnityObjectBase, ref EndianSpanReader)."""
    from .i_unity_asset_base import read as _read_with_flags

    _read_with_flags(asset, reader, asset.collection.flags)
