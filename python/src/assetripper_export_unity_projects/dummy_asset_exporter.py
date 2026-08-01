"""Port of Source/AssetRipper.Export.UnityProjects/DummyAssetExporter.cs

Used for Unity object types this port has decided never to write real content for --
either because nothing should ever reference or need them at all (the seven
GlobalGameManager singletons `manager_asset_exporter.py`'s docstring explains are excluded
from `ManagerExportCollection`: BuildSettings/PreloadData/AssetBundle/AssetBundleManifest/
MonoManager/ResourceManager/ShaderNameRegistry -- upstream marks these `isEmptyCollection`,
i.e. never expected to be referenced by anything else), or because a raw-bytes asset
(`UnknownObject`/`UnreadableObject`, see `raw_asset_exporters.py`) should be replaced with a
missing reference rather than exported, when the caller opts out of raw export.

Upstream keeps 4 singleton instances (empty/skip x serialized/meta); `get_dummy_asset_exporter`
below does the same, lazily, keyed by the same two booleans as `DummyAssetExporter.Get`.
"""
from __future__ import annotations

from assetripper_io_files.asset_type import AssetType

from .empty_export_collection import INSTANCE as _EMPTY_EXPORT_COLLECTION
from .i_asset_exporter import IAssetExporter
from .skip_export_collection import SkipExportCollection


class DummyAssetExporter(IAssetExporter):
    def __init__(self, export_type: AssetType, is_empty_collection: bool):
        self._export_type = export_type
        self._is_empty_collection = is_empty_collection

    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if self._is_empty_collection:
            return True, _EMPTY_EXPORT_COLLECTION
        return True, SkipExportCollection(self, asset)

    def to_export_type(self, asset) -> AssetType:
        return self._export_type

    def to_unknown_export_type(self, type_: type) -> "tuple[bool, AssetType]":
        return True, self._export_type


_instances: dict[tuple[bool, bool], DummyAssetExporter] = {}


def get_dummy_asset_exporter(is_empty_collection: bool, is_meta_type: bool) -> DummyAssetExporter:
    """Port of `DummyAssetExporter.Get`.

    is_empty_collection: True -> referencing the asset elsewhere is an error (nothing should);
        False -> references resolve to a missing reference instead.
    is_meta_type: whether `to_export_type` reports `AssetType.META` instead of `SERIALIZED`.
    """
    key = (is_empty_collection, is_meta_type)
    exporter = _instances.get(key)
    if exporter is None:
        export_type = AssetType.META if is_meta_type else AssetType.SERIALIZED
        exporter = DummyAssetExporter(export_type, is_empty_collection)
        _instances[key] = exporter
    return exporter
