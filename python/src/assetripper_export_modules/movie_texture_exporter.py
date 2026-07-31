"""Port of Source/AssetRipper.Export.UnityProjects/Miscellaneous/
{MovieTextureAssetExporter, MovieTextureAssetExportCollection}.cs

MovieTexture is a long-deprecated Unity feature; the `.meta` importer shape for a `.ogv`
file is not confirmed here, so this falls back to NativeFormatImporter (documented,
reduced-fidelity choice) rather than fabricate a MovieImporter shape.
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection

from .binary_asset_exporter import BinaryAssetExporter

_MOVIE_TEXTURE_CLASS_ID = 152
_OGV_EXTENSION = "ogv"


class MovieTextureAssetExporter(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _MOVIE_TEXTURE_CLASS_ID and self.is_valid_data(asset.get("m_MovieData")):
            return True, MovieTextureAssetExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        data = _movie_data_bytes(asset)
        with file_system.file.create(path) as stream:
            stream.write(data, 0, len(data))
        return True


class MovieTextureAssetExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return _OGV_EXTENSION


def _movie_data_bytes(asset) -> bytes:
    """m_MovieData is a TypelessData field, read as list[int] by the dynamic reader."""
    return bytes(asset.get("m_MovieData") or ())
