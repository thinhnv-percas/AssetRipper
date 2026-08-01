"""Port of Source/AssetRipper.Export.UnityProjects/EmptyExportCollection.cs

A singleton `IExportCollection` that claims no assets and refuses to export -- used for
Unity object types this port has decided to route away entirely (see
`project/manager_asset_exporter.py`'s docstring for the seven GlobalGameManager singletons
that use this, and `dummy_asset_exporter.py` for how). `contains()` always returning False
means nothing else in this port will ever resolve a pointer to one of these assets back to
this collection -- matching upstream's own contract ("an exception will be thrown if the
asset is referenced by another asset"): referencing one surfaces as a `LookupError` from
whatever tries to look up its collection, instead of quietly producing a broken pointer.
"""
from __future__ import annotations

from .i_export_collection import IExportCollection


class EmptyExportCollection(IExportCollection):
    def export(self, container, project_directory: str, file_system) -> bool:
        raise NotImplementedError("EmptyExportCollection does not support exporting")

    def contains(self, asset) -> bool:
        return False

    def get_export_id(self, container, asset) -> int:
        raise NotImplementedError("EmptyExportCollection does not support exporting")

    def create_export_pointer(self, container, asset, is_local: bool):
        raise NotImplementedError("EmptyExportCollection does not support exporting")

    @property
    def exportable(self) -> bool:
        return False

    @property
    def file(self):
        raise NotImplementedError("EmptyExportCollection has no backing file")

    @property
    def assets(self):
        return iter(())

    @property
    def name(self) -> str:
        return "EmptyExportCollection"


INSTANCE = EmptyExportCollection()
