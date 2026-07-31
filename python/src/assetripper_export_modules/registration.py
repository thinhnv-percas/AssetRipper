"""Registers this package's content exporters onto a ProjectExporter, ahead of the
DefaultYamlExporter fallback. Mirrors upstream's ExportHandler wiring these exporters in
before `GameExporter`/`ProjectExporter` runs -- see project_exporter.py's module docstring
for why class-ID-keyed registration is used instead of upstream's type-based one.

Shaders (class ID 48): upstream lets `ShaderExportMode` choose between DummyShaderTextExporter
and YamlShaderExporter as mutually-exclusive user settings (never both -- whichever is
registered second/highest-priority always succeeds for any Shader, since neither has a
narrower guard condition than "it's a Shader"). This port has no settings system, so
DummyShaderTextExporter is the wired-in default (matches upstream's typical default);
YamlShaderExporter is fully ported and available (shaders/yaml_shader_exporter.py) for a
caller that wants to register it instead. SimpleShaderExporter always has top priority: it
only succeeds when the shader already has real decompiled-looking source text.
"""
from __future__ import annotations

from .audio_clip_exporter import AudioClipExporter
from .font_asset_exporter import FontAssetExporter
from .mesh_exporter import MeshExporter
from .movie_texture_exporter import MovieTextureAssetExporter
from .scripts.script_exporter import ScriptExporter
from .shaders.dummy_shader_text_exporter import DummyShaderTextExporter
from .shaders.simple_shader_exporter import SimpleShaderExporter
from .text_asset_exporter import TextAssetExporter
from .texture2d_exporter import Texture2DExporter


def register_default_exporters(project_exporter) -> None:
    project_exporter.override_exporter_for_class_id(28, Texture2DExporter())  # Texture2D
    project_exporter.override_exporter_for_class_id(43, MeshExporter())  # Mesh
    project_exporter.override_exporter_for_class_id(48, DummyShaderTextExporter())  # Shader (fallback)
    project_exporter.override_exporter_for_class_id(48, SimpleShaderExporter())  # Shader (preferred)
    project_exporter.override_exporter_for_class_id(49, TextAssetExporter())  # TextAsset
    project_exporter.override_exporter_for_class_id(83, AudioClipExporter())  # AudioClip
    project_exporter.override_exporter_for_class_id(115, ScriptExporter())  # MonoScript
    project_exporter.override_exporter_for_class_id(128, FontAssetExporter())  # Font
    project_exporter.override_exporter_for_class_id(152, MovieTextureAssetExporter())  # MovieTexture
