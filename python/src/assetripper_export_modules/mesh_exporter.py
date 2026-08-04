"""Scoped-down port of Source/AssetRipper.Export.Modules.Models/{GlbMeshBuilder,
GlbWriter}.cs and their upstream wiring (Mesh, class ID 43), reassembled here as one
IAssetExporter following the pattern established for the other content exporters
(binary_asset_exporter.py, texture2d_exporter.py, audio_clip_exporter.py).

See meshes/mesh_data.py's module docstring for exactly what's ported (uncompressed
`m_VertexData`, up to 8 UVs, vertex colors, tangents/normals, blend weights/indices as raw
vertex attributes) versus declined (CompressedMesh, blend shapes, bind poses/skeleton).
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection

from .binary_asset_exporter import BinaryAssetExporter
from .meshes.glb_writer import build_glb
from .meshes.mesh_data import get_mesh_data

_MESH_CLASS_ID = 43
_GLB_EXTENSION = "glb"


class MeshExporter(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _MESH_CLASS_ID and get_mesh_data(asset) is not None:
            return True, MeshExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        mesh_data = get_mesh_data(asset)
        if mesh_data is None:
            return False

        name = asset.get("m_Name") or "Mesh"
        data = build_glb(name, mesh_data)
        with file_system.file.create(path) as stream:
            stream.write(data, 0, len(data))
        return True


class MeshExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return _GLB_EXTENSION


    def _create_importer(self, container):
        """2026-08-03: a .glb model file needs Unity's ModelImporter -- see
        `assetripper_export_unity_projects/project/content_importers.py`. Before this, the base
        class's `NativeFormatImporter` default named an importer that cannot read this file."""
        from assetripper_export_unity_projects.project.content_importers import ModelImporter

        importer = ModelImporter()
        if self.asset.asset_bundle_name is not None:
            importer.asset_bundle_name = self.asset.asset_bundle_name
        return importer
