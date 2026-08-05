"""Port of Source/AssetRipper.Export.UnityProjects/ExportCollection.cs

`get_export_extension` dispatches on `asset.class_id` against the well-known Unity class
IDs (from assetripper_import.class_id_type.ClassIDType) instead of C#'s `is ITexture2D`/
`is IMaterial`/... pattern match against generated interfaces, which don't exist here.
"""
from __future__ import annotations

from abc import ABC, abstractmethod

from assetripper_io_files.filesystem import (
    MAX_FILE_NAME_LENGTH,
    fix_invalid_file_name_characters,
    remove_clone_suffixes,
    remove_instance_suffixes,
)
from assetripper_import.class_id_type import ClassIDType
from assetripper_yaml import YamlWriter

from ._text_writer import Utf8TextWriter
from .asset_exporter import export_asset
from .i_export_collection import IExportCollection
from .meta import Meta

_META_EXTENSION = ".meta"
ASSET_EXTENSION = "asset"
ASSETS_KEYWORD = "Assets"

# https://docs.unity3d.com/Manual/BuiltInImporters.html
_EXTENSION_BY_CLASS_ID = {
    ClassIDType.Shader: "shader",
    ClassIDType.Material: "mat",
    ClassIDType.AnimationClip: "anim",
    ClassIDType.AnimatorController: "controller",
    ClassIDType.AnimatorOverrideController: "overrideController",
    ClassIDType.AudioMixer: "mixer",
    ClassIDType.AvatarMask_319: "mask",
    ClassIDType.ShaderVariantCollection: "shadervariants",
    ClassIDType.Cubemap: "cubemap",
    ClassIDType.Texture2D: "texture2D",
    ClassIDType.Flare: "flare",
    ClassIDType.LightingSettings: "lighting",
    ClassIDType.LightmapParameters: "giparams",
    ClassIDType.PhysicsMaterial: "physicMaterial",
    ClassIDType.PhysicsMaterial2D: "physicsMaterial2D",
    ClassIDType.RenderTexture: "renderTexture",
    ClassIDType.TerrainLayer: "terrainlayer",
    ClassIDType.WebCamTexture: "webCamTexture",
    ClassIDType.AnimatorState: "state",
    ClassIDType.AnimatorStateMachine: "statemachine",
    ClassIDType.AnimatorTransition: "transition",
    ClassIDType.BlendTree: "blendtree",
}


class ExportCollection(IExportCollection, ABC):
    @property
    def guid(self):
        raise NotImplementedError

    @staticmethod
    def _export_meta(container, meta: Meta, file_path: str, file_system) -> None:
        meta_path = f"{file_path}{_META_EXTENSION}"
        with file_system.file.create(meta_path) as stream:
            writer = YamlWriter()
            writer.is_write_default_tag = False
            writer.is_write_version = False
            writer.is_format_keys = True
            doc = meta.export_yaml_document(container)
            writer.add_document(doc)
            writer.write(Utf8TextWriter(stream))

    def _export_asset(self, container, importer, asset, path: str, name: str, file_system) -> None:
        if not file_system.directory.exists(path):
            file_system.directory.create(path)

        full_name = f"{name}.{self._get_export_extension(asset)}"
        unique_name = file_system.get_unique_name(path, full_name, MAX_FILE_NAME_LENGTH - len(_META_EXTENSION))
        file_path = file_system.path.join(path, unique_name)
        export_asset(container, asset, file_path, file_system)
        meta = Meta(self.guid, importer)
        self._export_meta(container, meta, file_path, file_system)

    def _get_unique_file_name(self, asset, dir_path: str, file_system) -> str:
        file_name = asset.get_best_name()
        file_name = remove_clone_suffixes(file_name)
        file_name = remove_instance_suffixes(file_name)
        file_name = file_name.strip()
        if not file_name:
            file_name = asset.class_name
        else:
            file_name = fix_invalid_file_name_characters(file_name)

        file_name = f"{file_name}.{self._get_export_extension(asset)}"
        return self._get_unique_file_name_in(dir_path, file_name, file_system)

    @staticmethod
    def _get_unique_file_name_in(directory_path: str, file_name: str, file_system) -> str:
        return file_system.get_unique_name(directory_path, file_name, MAX_FILE_NAME_LENGTH - len(_META_EXTENSION))

    def _get_export_extension(self, asset) -> str:
        return _EXTENSION_BY_CLASS_ID.get(asset.class_id, ASSET_EXTENSION)
