"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/EmptyScriptExportCollection.cs
(plus the shared parts of the abstract ScriptExportCollectionBase.cs it inherits from --
GetExportSubPath/OnScriptExported are ported as functions in script_export_paths.py and
this module rather than as a base class, since ScriptExportCollection -- the real-assembly
sibling that would be the base class's other subclass -- is out of scope; see
script_exporter.py's module docstring).

Assembly-definition (.asmdef) file generation is NOT ported: upstream's
AssemblyDefinitionExporter only runs for non-predefined assemblies resolved through
ReferenceAssemblies.GetReferenceAssemblies, which needs a set IAssemblyManager -- always
unset in this port. Script content (dummy classes) and their stable per-script GUIDs are
fully ported; only this organizational scaffolding is skipped.

Phase 16f: `_get_script_text` tries `asset_exporter.assembly_manager.get_recovered_type(...)`
first (real `.cs` text via `csharp_emitter`, see mono_manager.py) and only falls back to
`empty_script.get_content`'s dummy stub when that's unavailable -- no assembly manager, the
script's assembly wasn't found/couldn't be parsed, or its class wasn't (fully) recoverable.
Every script's `.meta` GUID is unaffected either way (still derived from
assembly/namespace/class name alone, matching upstream, so file identity is stable across a
run with recovery and one without).
"""
from __future__ import annotations

import logging

from assetripper_export_unity_projects.export_collection import ASSETS_KEYWORD, ExportCollection
from assetripper_export_unity_projects.meta import Meta

from . import script_hashing
from .empty_script import get_content
from .mono_script_info import MonoScriptInfo
from .script_export_paths import get_export_sub_path

_logger = logging.getLogger(__name__)

_MONO_SCRIPT_CLASS_ID = 115


class EmptyScriptExportCollection(ExportCollection):
    def __init__(self, asset_exporter, first_script):
        self.asset_exporter = asset_exporter
        self.first_script = first_script

        self._unique_scripts: "dict[MonoScriptInfo, object]" = {}
        for script in first_script.collection.bundle.fetch_assets_in_hierarchy():
            if getattr(script, "class_id", None) != _MONO_SCRIPT_CLASS_ID:
                continue
            info = MonoScriptInfo.from_mono_script(script)
            self._unique_scripts.setdefault(info, script)

    @property
    def name(self) -> str:
        return "EmptyScriptExportCollection"

    @property
    def file(self):
        return self.first_script.collection

    @property
    def assets(self):
        yield self.first_script

    def contains(self, asset) -> bool:
        return asset is self.first_script

    def create_export_pointer(self, container, asset, is_local: bool):
        if is_local:
            raise NotImplementedError
        self._throw_if_not_asset(asset)
        return self.asset_exporter.create_export_pointer(self.first_script)

    def get_export_id(self, container, asset) -> int:
        self._throw_if_not_asset(asset)
        return self.create_export_pointer(container, asset, False).file_id

    def export(self, container, project_directory: str, file_system) -> bool:
        _logger.info("Exporting scripts...")

        assets_directory_path = file_system.path.join(project_directory, ASSETS_KEYWORD)

        for info, script in self._unique_scripts.items():
            if info.is_injected():
                continue

            folder_sub_path, file_name = get_export_sub_path(info.assembly, info.namespace, info.class_name)
            folder_path = file_system.path.join(assets_directory_path, folder_sub_path)
            file_path = file_system.path.join(folder_path, file_name)
            file_system.directory.create(folder_path)
            file_system.file.write_all_text(file_path, self._get_script_text(info))

            self._on_script_exported(container, script, file_path, file_system)

        return True

    def _get_script_text(self, info: MonoScriptInfo) -> str:
        assembly_manager = getattr(self.asset_exporter, "assembly_manager", None)
        if assembly_manager is not None:
            recovered_type = assembly_manager.get_recovered_type(info.assembly, info.namespace, info.class_name)
            if recovered_type is not None:
                from .csharp_emitter import emit

                return emit(recovered_type)
        return get_content(info.namespace, info.class_name)

    def _on_script_exported(self, container, script, path: str, file_system) -> None:
        from assetripper_export_unity_projects.project.mono_importer import MonoImporter

        info = MonoScriptInfo.from_mono_script(script)
        importer = MonoImporter()
        importer.execution_order = script.get("m_ExecutionOrder") or 0
        guid = script_hashing.calculate_script_guid(info.assembly, info.namespace, info.class_name)
        meta = Meta(guid, importer)
        self._export_meta(container, meta, path, file_system)

    def _throw_if_not_asset(self, asset) -> None:
        if asset is not self.first_script:
            raise ValueError("The asset must be the same one referenced in this collection.")
