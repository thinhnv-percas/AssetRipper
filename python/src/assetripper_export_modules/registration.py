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
"""
from __future__ import annotations

from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.shader_export_mode import ShaderExportMode

from .audio_clip_exporter import AudioClipExporter
from .font_asset_exporter import FontAssetExporter
from .mesh_exporter import MeshExporter
from .movie_texture_exporter import MovieTextureAssetExporter
from .scripts.script_exporter import ScriptExporter
from .shaders.dummy_shader_text_exporter import DummyShaderTextExporter
from .shaders.simple_shader_exporter import SimpleShaderExporter
from .shaders.yaml_shader_exporter import YamlShaderExporter
from .text_asset_exporter import TextAssetExporter
from .texture2d_exporter import Texture2DExporter


def register_default_exporters(project_exporter, settings: "FullConfiguration | None" = None) -> None:
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
    project_exporter.override_exporter_for_class_id(115, ScriptExporter())  # MonoScript
    project_exporter.override_exporter_for_class_id(128, FontAssetExporter())  # Font
    project_exporter.override_exporter_for_class_id(152, MovieTextureAssetExporter())  # MovieTexture
