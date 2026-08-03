"""Registers this package's content exporters onto a ProjectExporter, ahead of the
DefaultYamlExporter fallback. Mirrors upstream's ExportHandler wiring these exporters in
before `GameExporter`/`ProjectExporter` runs -- see project_exporter.py's module docstring
for why class-ID-keyed registration is used instead of upstream's type-based one.

Shaders (class ID 48): upstream lets `ShaderExportMode` choose between DummyShaderTextExporter
and YamlShaderExporter as mutually-exclusive user settings (never both -- whichever is
registered second/highest-priority always succeeds for any Shader, since neither has a
narrower guard condition than "it's a Shader"). `settings.export_settings.shader_export_mode`
(Phase 10) now selects between them; `ShaderExportMode.DECOMPILE` has no decompiler in this
port (see shaders/ -- no HLSL/DXBC decompiler was ported) and falls back to Dummy, same as
upstream would if Decompile were requested without its decompiler assembly present.
SimpleShaderExporter always has top priority regardless of mode: it only succeeds when the
shader already has real decompiled-looking source text.

Phase 15 (`ProjectSettings/`, dummy managers, raw assets): mirrors
`Source/AssetRipper.Export.UnityProjects/ProjectExporter.Overrides.cs`'s equivalent section.
See `assetripper_export_unity_projects/project/manager_asset_exporter.py` for exactly which
class IDs are treated as GlobalGameManager singletons and why, and that module plus
`dummy_asset_exporter.py` for why 7 specific manager-ish class IDs are dummy-exported instead.
"""
from __future__ import annotations

from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.shader_export_mode import ShaderExportMode
from assetripper_export_configuration.sprite_export_mode import SpriteExportMode
from assetripper_export_unity_projects.dummy_asset_exporter import get_dummy_asset_exporter
from assetripper_export_unity_projects.project.manager_asset_exporter import (
    _GLOBAL_GAME_MANAGER_CLASS_IDS,
    _PLAYER_SETTINGS_CLASS_ID,
    ManagerAssetExporter,
)
from assetripper_export_unity_projects.raw_assets.unknown_object_exporter import UnknownObjectExporter
from assetripper_export_unity_projects.raw_assets.unreadable_object_exporter import UnreadableObjectExporter
from assetripper_import.asset_creation.raw_data_object import UnknownObject, UnreadableObject

from .audio_clip_exporter import AudioClipExporter
from .font_asset_exporter import FontAssetExporter
from .mesh_exporter import MeshExporter
from .movie_texture_exporter import MovieTextureAssetExporter
from .scripts.script_exporter import ScriptExporter
from .shaders.dummy_shader_text_exporter import DummyShaderTextExporter
from .shaders.simple_shader_exporter import SimpleShaderExporter
from .shaders.yaml_shader_exporter import YamlShaderExporter
from .sprite_exporter import SPRITE_ATLAS_CLASS_ID, SPRITE_CLASS_ID, YamlSpriteExporter
from .text_asset_exporter import TextAssetExporter
from .texture2d_exporter import Texture2DExporter
from .video_clip_exporter import VIDEO_CLIP_CLASS_IDS, VideoClipExporter

# BuildSettings, PreloadData, AssetBundle, AssetBundleManifest, MonoManager, ResourceManager,
# ShaderNameRegistry: IGlobalGameManager upstream, but dummy-exported at higher priority than
# ManagerAssetExporter (OverrideDummyExporter, isEmptyCollection=true) -- see
# manager_asset_exporter.py's docstring for the reasoning.
_DUMMY_GLOBAL_GAME_MANAGER_CLASS_IDS = (141, 150, 142, 290, 116, 147, 94)


def register_default_exporters(
    project_exporter, settings: "FullConfiguration | None" = None, assembly_manager=None
) -> None:
    """`assembly_manager` (Phase 16f): forwarded to `ScriptExporter` so recovered Mono
    scripts export real `.cs` text instead of the dummy stub -- see `script_exporter.py`."""
    if settings is None:
        settings = FullConfiguration()
    export_settings = settings.export_settings

    project_exporter.override_exporter_for_class_id(
        28, Texture2DExporter(export_settings.image_export_format)
    )  # Texture2D
    project_exporter.override_exporter_for_class_id(43, MeshExporter())  # Mesh

    if export_settings.shader_export_mode == ShaderExportMode.YAML:
        project_exporter.override_exporter_for_class_id(48, YamlShaderExporter())  # Shader
    else:
        # DUMMY and DECOMPILE (no decompiler ported -- see module docstring) both fall back
        # to the dummy text exporter.
        project_exporter.override_exporter_for_class_id(48, DummyShaderTextExporter())  # Shader
    project_exporter.override_exporter_for_class_id(48, SimpleShaderExporter())  # Shader (preferred)

    project_exporter.override_exporter_for_class_id(
        49, TextAssetExporter(export_settings.text_export_mode)
    )  # TextAsset
    project_exporter.override_exporter_for_class_id(
        83, AudioClipExporter(export_settings.audio_export_format)
    )  # AudioClip
    project_exporter.override_exporter_for_class_id(115, ScriptExporter(assembly_manager))  # MonoScript
    project_exporter.override_exporter_for_class_id(128, FontAssetExporter())  # Font
    project_exporter.override_exporter_for_class_id(152, MovieTextureAssetExporter())  # MovieTexture

    video_clip_exporter = VideoClipExporter()
    for class_id in VIDEO_CLIP_CLASS_IDS:  # VideoClip_327, VideoClip_329
        project_exporter.override_exporter_for_class_id(class_id, video_clip_exporter)

    if export_settings.sprite_export_mode == SpriteExportMode.YAML:
        yaml_sprite_exporter = YamlSpriteExporter()
        project_exporter.override_exporter_for_class_id(SPRITE_CLASS_ID, yaml_sprite_exporter)
        project_exporter.override_exporter_for_class_id(SPRITE_ATLAS_CLASS_ID, yaml_sprite_exporter)
    # NATIVE/TEXTURE_2D: no native-image Sprite exporter ported yet -- falls through to
    # DefaultYamlExporter (see sprite_export_mode.py's docstring).

    # Phase 15: ProjectSettings/*.asset for GlobalGameManager singletons + PlayerSettings.
    manager_exporter = ManagerAssetExporter()
    for class_id in (*_GLOBAL_GAME_MANAGER_CLASS_IDS, _PLAYER_SETTINGS_CLASS_ID):
        project_exporter.override_exporter_for_class_id(class_id, manager_exporter)

    # The 7 IGlobalGameManager types upstream dummy-exports instead (see module docstring).
    dummy_manager_exporter = get_dummy_asset_exporter(is_empty_collection=True, is_meta_type=False)
    for class_id in _DUMMY_GLOBAL_GAME_MANAGER_CLASS_IDS:
        project_exporter.override_exporter_for_class_id(class_id, dummy_manager_exporter)

    # Raw fallbacks for assets whose layout couldn't be determined (UnknownObject) or that
    # failed to read against a known layout (UnreadableObject). Dispatched by Python type, not
    # class ID -- see project_exporter.py's `_create_collection` for why RawDataObject skips
    # class-ID dispatch entirely.
    if export_settings.export_unreadable_assets:
        project_exporter.override_exporter(UnknownObject, UnknownObjectExporter(), allow_inheritance=False)
        project_exporter.override_exporter(UnreadableObject, UnreadableObjectExporter(), allow_inheritance=False)
    else:
        dummy_raw_exporter = get_dummy_asset_exporter(is_empty_collection=False, is_meta_type=False)
        project_exporter.override_exporter(UnknownObject, dummy_raw_exporter, allow_inheritance=False)
        project_exporter.override_exporter(UnreadableObject, dummy_raw_exporter, allow_inheritance=False)
