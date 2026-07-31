"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/ScriptExporter.cs, scoped down
to the branch that upstream itself takes whenever no assembly manager is set
(`AssemblyManager.IsSet` is always `False` in this port -- see the plan's "no script
decompilation" scope): every `MonoScript` is treated as `AssemblyExportType.Decompile`,
i.e. exported as a dummy/empty class rather than a redirect to a real reference assembly.

The first `MonoScript` encountered by the project exporter creates one
`EmptyScriptExportCollection`, which writes every unique script in the whole bundle
hierarchy in one pass. Every subsequent `MonoScript` the project exporter reaches gets a
lightweight `SingleRedirectExportCollection` pointing at the same (fileID, guid) pair
--- matching upstream's `HasDecompiled` one-shot flag.
"""
from __future__ import annotations

from assetripper_io_files.asset_type import AssetType

from assetripper_export_unity_projects.export_id_handler import get_main_export_id
from assetripper_export_unity_projects.i_asset_exporter import IAssetExporter
from assetripper_export_unity_projects.meta_ptr import MetaPtr
from assetripper_export_unity_projects.single_redirect_export_collection import SingleRedirectExportCollection

from . import script_hashing
from .empty_script_export_collection import EmptyScriptExportCollection
from .mono_script_info import MonoScriptInfo

_MONO_SCRIPT_CLASS_ID = 115
_MONO_SCRIPT_DECOMPILED_FILE_ID = get_main_export_id(_MONO_SCRIPT_CLASS_ID)


class ScriptExporter(IAssetExporter):
    def __init__(self):
        self._has_decompiled = False

    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if getattr(asset, "class_id", None) != _MONO_SCRIPT_CLASS_ID:
            return False, None

        if self._has_decompiled:
            return True, SingleRedirectExportCollection(asset, self.create_export_pointer(asset))

        self._has_decompiled = True
        return True, EmptyScriptExportCollection(self, asset)

    def create_export_pointer(self, script) -> MetaPtr:
        info = MonoScriptInfo.from_mono_script(script)
        guid = script_hashing.calculate_script_guid(info.assembly, info.namespace, info.class_name)
        return MetaPtr(_MONO_SCRIPT_DECOMPILED_FILE_ID, guid, AssetType.META)

    def export(self, container, asset, path: str, file_system) -> bool:
        raise NotImplementedError

    def to_export_type(self, asset) -> AssetType:
        return AssetType.META

    def to_unknown_export_type(self, type_: type) -> "tuple[bool, AssetType]":
        return True, AssetType.META
