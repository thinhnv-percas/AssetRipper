"""Port of the Texture2D slice of Source/AssetRipper.Export.Modules.Textures, wired as an
IAssetExporter (mirroring TextureAssetExporter/TextureAssetExportCollection upstream,
neither of which is vendored here as source -- reconstructed from TextureConverter.cs's
callers and Unity's known Texture2D field layout).

Texture2D's raw embedded pixel bytes are serialized under the field literally named
"image data" (with a space) -- one of Unity's few non-`m_`-prefixed field names. Player
builds commonly leave that field empty and store the actual pixel bytes in an external
`.resS` resource file instead, referenced by `m_StreamData` (a `StreamingInfo`); see
assetripper_import/streamed_resource.py for the resolution logic (Phase 9 -- before that,
this exporter declined outright whenever "image data" was empty, which is why real player
builds exported almost nothing).
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_import.streamed_resource import get_streaming_info_content

from .binary_asset_exporter import BinaryAssetExporter
from .texture_converter import decode_texture
from .texture_format import TextureFormat

_TEXTURE_2D_CLASS_ID = 28
_PNG_EXTENSION = "png"


class Texture2DExporter(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _TEXTURE_2D_CLASS_ID and self.is_valid_data(_image_data_bytes(asset)):
            return True, Texture2DExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        image = _decode(asset)
        if image is None:
            return False

        with file_system.file.create(path) as stream:
            import io

            buffer = io.BytesIO()
            image.save(buffer, format="PNG")
            data = buffer.getvalue()
            stream.write(data, 0, len(data))
        return True


class Texture2DExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return _PNG_EXTENSION


def _image_data_bytes(asset) -> bytes:
    data = bytes(asset.get("image data") or ())
    if data:
        return data

    stream_data = asset.get("m_StreamData")
    if stream_data is not None:
        return get_streaming_info_content(stream_data, asset.collection)
    return b""


def _decode(asset):
    data = _image_data_bytes(asset)
    width = asset.get("m_Width") or 0
    height = asset.get("m_Height") or 0
    format_value = asset.get("m_TextureFormat")
    try:
        texture_format = TextureFormat(format_value)
    except ValueError:
        return None
    return decode_texture(data, width, height, texture_format)
