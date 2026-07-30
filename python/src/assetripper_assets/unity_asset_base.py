"""Port of Source/AssetRipper.Assets/UnityAssetBase.cs

The artificial base class for all generated Unity classes.
"""
from __future__ import annotations

from .i_unity_asset_base import IUnityAssetBase


class UnityAssetBase(IUnityAssetBase):
    @property
    def serialized_version(self) -> int:
        return 1

    @property
    def flow_mapped_in_yaml(self) -> bool:
        return False

    def ignore_field_in_meta_files(self, field_name: str) -> bool:
        return False

    def read_editor(self, reader) -> None:
        raise self._method_not_supported("read_editor")

    def read_release(self, reader) -> None:
        raise self._method_not_supported("read_release")

    def write_editor(self, writer) -> None:
        raise self._method_not_supported("write_editor")

    def write_release(self, writer) -> None:
        raise self._method_not_supported("write_release")

    def fetch_dependencies(self):
        return iter(())

    def __str__(self) -> str:
        name = getattr(self, "name", None)
        return name if name else type(self).__name__

    def reset(self) -> None:
        raise self._method_not_supported("reset")

    def copy_values(self, source: "IUnityAssetBase | None", converter) -> None:
        pass

    def walk_editor(self, walker) -> None:
        self.walk_standard(walker)

    def walk_release(self, walker) -> None:
        self.walk_standard(walker)

    def walk_standard(self, walker) -> None:
        if walker.enter_asset(self):
            walker.exit_asset(self)

    def add_to_equality_comparer(self, other: "IUnityAssetBase", comparer) -> bool | None:
        raise self._method_not_supported("add_to_equality_comparer")

    def _method_not_supported(self, method_name: str) -> NotImplementedError:
        return NotImplementedError(f"{method_name} is not supported for {type(self).__qualname__}")
