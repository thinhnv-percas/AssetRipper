"""Renders a single asset for GUI preview by running the real export pipeline
(`ProjectExporter`) into a scratch temp directory and reading the resulting bytes back,
instead of duplicating each content exporter's encoding logic here a second time. Mirrors
upstream's Pages/Assets/AssetAPI.cs endpoints (Image/Binary/Text/Yaml), but built on top of
this port's Phase 6/9/10 exporters rather than reimplementing per-format encoding in the GUI
layer (Phase 11).

Trade-off: this groups+exports the asset's whole collection on every request rather than
caching anything, so repeatedly opening the same asset tab re-runs its exporter each time.
Acceptable for a GUI preview (not a hot path); if it ever needs to be fast, memoizing by
`asset.asset_info` would be the next step, not a rewrite of this approach.
"""
from __future__ import annotations

import os
import tempfile

_MIME_TYPES = {
    "png": "image/png",
    "jpeg": "image/jpeg",
    "bmp": "image/bmp",
    "tga": "image/x-tga",
    "wav": "audio/wav",
    "ogg": "audio/ogg",
    "mp3": "audio/mpeg",
    "m4a": "audio/mp4",
    "it": "application/octet-stream",
    "xm": "application/octet-stream",
    "s3m": "application/octet-stream",
    "mod": "application/octet-stream",
    "fsb": "application/octet-stream",
    "ogv": "video/ogg",
    "otf": "font/otf",
    "ttf": "font/ttf",
    "glb": "model/gltf-binary",
    "txt": "text/plain; charset=utf-8",
    "json": "application/json",
    "asset": "text/yaml; charset=utf-8",
    "yaml": "text/yaml; charset=utf-8",
    "shader": "text/plain; charset=utf-8",
    "bytes": "application/octet-stream",
}

IMAGE_EXTENSIONS = frozenset({"png", "jpeg", "bmp", "tga"})
TEXT_EXTENSIONS = frozenset({"txt", "json", "shader"})
YAML_EXTENSIONS = frozenset({"asset", "yaml"})


def mime_type_for_extension(extension: str) -> str:
    return _MIME_TYPES.get(extension.lower(), "application/octet-stream")


def render_asset(game_bundle, asset, export_version, register_exporters, settings=None) -> "tuple[bytes, str] | None":
    """Returns `(data, extension)` for `asset`, or `None` if no exporter in `register_exporters`
    can handle it (matches `try_create_collection` returning False for every registered
    exporter -- the same asset the "Fields"/"Hex" tabs would show as raw bytes instead)."""
    from assetripper_export_unity_projects.project.project_asset_container import ProjectAssetContainer
    from assetripper_export_unity_projects.project_exporter import ProjectExporter
    from assetripper_io_files.local_file_system import LocalFileSystem

    exporter = ProjectExporter()
    register_exporters(exporter, settings)
    collections = exporter.create_collections(game_bundle)

    target_collection = None
    for collection in collections:
        if any(a.asset_info == asset.asset_info for a in collection.assets):
            target_collection = collection
            break
    if target_collection is None or not target_collection.exportable:
        return None

    container = ProjectAssetContainer(exporter, export_version, game_bundle.fetch_assets(), collections)
    container.current_collection = target_collection
    file_system = LocalFileSystem.instance()

    with tempfile.TemporaryDirectory(prefix="assetripper_preview_") as scratch_dir:
        if not target_collection.export(container, scratch_dir, file_system):
            return None

        candidates = []
        for root, _dirs, files in os.walk(scratch_dir):
            for file_name in files:
                if not file_name.endswith(".meta"):
                    candidates.append(os.path.join(root, file_name))
        if len(candidates) != 1:
            return None

        with open(candidates[0], "rb") as f:
            data = f.read()
        extension = os.path.splitext(candidates[0])[1].lstrip(".")
        return data, extension
