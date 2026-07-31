"""Registers this package's content exporters onto a ProjectExporter, ahead of the
DefaultYamlExporter fallback. Mirrors upstream's ExportHandler wiring these exporters in
before `GameExporter`/`ProjectExporter` runs -- see project_exporter.py's module docstring
for why class-ID-keyed registration is used instead of upstream's type-based one.
"""
from __future__ import annotations

from .font_asset_exporter import FontAssetExporter
from .movie_texture_exporter import MovieTextureAssetExporter
from .text_asset_exporter import TextAssetExporter


def register_default_exporters(project_exporter) -> None:
    project_exporter.override_exporter_for_class_id(49, TextAssetExporter())  # TextAsset
    project_exporter.override_exporter_for_class_id(128, FontAssetExporter())  # Font
    project_exporter.override_exporter_for_class_id(152, MovieTextureAssetExporter())  # MovieTexture
