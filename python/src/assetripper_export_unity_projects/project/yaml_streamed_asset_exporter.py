"""Port of Source/AssetRipper.Export.UnityProjects/Project/{YamlStreamedAssetExporter,
YamlStreamedAssetExportCollection}.cs (2026-08-03).

The problem it solves. A player build almost never stores texture pixels or mesh vertex buffers
inline; it puts them in an external `.resS` resource file and leaves a `m_StreamData`
(`StreamingInfo`: path, offset, size) pointing at it. Phase 9 taught the *content* exporters to
follow that pointer, so `.png`/`.glb` output works. But when a content exporter declines -- an
unsupported texture format, a mesh whose data lives only in `m_CompressedMesh` -- the asset falls
through to `DefaultYamlExporter` and gets written as a `.asset` YAML file **with `m_StreamData`
still in it**, naming a `.resS` file that does not exist anywhere in the exported project. Unity
then reads a texture or mesh with no data at all.

This collection inlines the streamed bytes into the field they belong in and blanks
`m_StreamData` for the duration of the write, so the YAML is self-contained. Upstream restores
the original values afterwards and so does this, because the same asset is still referenced by
other collections in the same export run and by the GUI's preview.

Registered for the two class IDs upstream handles -- Texture2D (28) and Mesh (43) -- ahead of the
content exporters, and declines whenever there is nothing to inline, so a normal `.png`/`.glb`
export is completely unaffected. `ImageTexture` upstream also covers Cubemap (89) and
Texture2DArray (187); those are not registered here because this port has no layout for them, so
they never read successfully in the first place (ROADMAP Phase 2).
"""
from __future__ import annotations

import logging

from assetripper_import.streamed_resource import get_streaming_info_content
from assetripper_io_files.asset_type import AssetType

from ..asset_export_collection import AssetExportCollection
from .yaml_exporter_base import YamlExporterBase

_logger = logging.getLogger(__name__)

_TEXTURE_2D_CLASS_ID = 28
_MESH_CLASS_ID = 43

_STREAM_DATA = "m_StreamData"
_IMAGE_DATA = "image data"
"""Texture2D's inline pixel bytes -- one of Unity's few field names without an `m_` prefix."""
_VERTEX_DATA = "m_VertexData"
_DATA_SIZE = "m_DataSize"
"""`m_VertexData`'s inline vertex buffer. Named "size" but it is the buffer itself, not a count."""


class YamlStreamedAssetExporter(YamlExporterBase):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if _inlinable_target(asset) is None:
            return False, None
        return True, YamlStreamedAssetExportCollection(self, asset)

    def to_export_type(self, asset) -> AssetType:
        return AssetType.SERIALIZED


class YamlStreamedAssetExportCollection(AssetExportCollection):
    def _export_inner(self, container, file_path: str, project_directory: str, file_system) -> bool:
        target = _inlinable_target(self.asset)
        if target is None:
            return super()._export_inner(container, file_path, project_directory, file_system)

        owner, field_name = target
        stream_data = self.asset.get(_STREAM_DATA)
        original_stream_data = _stream_data_values(stream_data)
        original_inline = owner.get(field_name)

        content = b""
        try:
            content = get_streaming_info_content(stream_data, self.asset.collection)
        except Exception as ex:  # noqa: BLE001 -- a missing/short .resS must not fail the export
            _logger.warning("Could not resolve streamed data for %s: %r", self.asset, ex)

        if not content:
            # Nothing to inline. Blanking `m_StreamData` anyway would be worse than leaving it:
            # a dangling path at least tells the user which resource file went missing, whereas a
            # blank one silently claims the asset genuinely has no data.
            _logger.warning(
                "Streamed data for %s could not be read; its YAML keeps the original %s "
                "reference, which will not resolve inside the exported project",
                self.asset,
                _STREAM_DATA,
            )
            return super()._export_inner(container, file_path, project_directory, file_system)

        try:
            owner[field_name] = content
            _clear_stream_data(stream_data)
            return super()._export_inner(container, file_path, project_directory, file_system)
        finally:
            owner[field_name] = original_inline
            _restore_stream_data(stream_data, original_stream_data)


def _inlinable_target(asset) -> "tuple[object, str] | None":
    """`(owner, field_name)` of the inline field that should receive the streamed bytes, or None
    if this asset needs no inlining at all -- wrong class, no `m_StreamData`, an empty
    `m_StreamData`, or an inline field that already holds the data."""
    class_id = getattr(asset, "class_id", None)
    if class_id == _TEXTURE_2D_CLASS_ID:
        owner, field_name = asset, _IMAGE_DATA
    elif class_id == _MESH_CLASS_ID:
        vertex_data = asset.get(_VERTEX_DATA)
        if vertex_data is None:
            return None
        owner, field_name = vertex_data, _DATA_SIZE
    else:
        return None

    if _STREAM_DATA not in asset:
        return None
    stream_data = asset.get(_STREAM_DATA)
    if stream_data is None or not _stream_data_values(stream_data)[0]:
        return None
    if owner.get(field_name):
        # Already inline -- upstream still clears `m_StreamData` in this branch, and so does the
        # caller by way of it: a resource path with real inline data beside it is contradictory,
        # and Unity would prefer the (nonexistent) file.
        return owner, field_name
    return owner, field_name


def _stream_data_values(stream_data) -> "tuple[str, int, int]":
    if stream_data is None:
        return "", 0, 0
    return (
        stream_data.get("path") or "",
        stream_data.get("offset") or 0,
        stream_data.get("size") or 0,
    )


def _clear_stream_data(stream_data) -> None:
    if stream_data is None:
        return
    stream_data["path"] = ""
    stream_data["offset"] = 0
    stream_data["size"] = 0


def _restore_stream_data(stream_data, values: "tuple[str, int, int]") -> None:
    if stream_data is None:
        return
    stream_data["path"], stream_data["offset"], stream_data["size"] = values
