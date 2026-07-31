"""Port of Source/AssetRipper.Export.UnityProjects/Miscellaneous/
{FontAssetExporter, FontAssetExportCollection}.cs, scoped down.

Upstream's FontAssetExportCollection also pairs the font's Material/Texture sub-assets
into the same collection and builds a full TrueTypeFontImporter (font size, style,
fallback fonts, character spacing, ...). Neither is ported: MainAssetProcessor (Phase 5)
was itself scoped to skip that pairing (font.TryGetFontMaterial/TryGetFontTexture need
generated extension methods this port doesn't have), and TrueTypeFontImporter's exact
field shape isn't confirmed with enough confidence to reproduce -- this falls back to
NativeFormatImporter (documented, reduced-fidelity choice) rather than fabricate one.
Only the byte-passthrough export of the raw font file (with real ttf/otf sniffing, which
IS confidently known) is implemented.
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection

from .binary_asset_exporter import BinaryAssetExporter

_FONT_CLASS_ID = 128
_OTF_MAGIC = b"OTTO"
_TTF_EXTENSION = "ttf"
_OTF_EXTENSION = "otf"


class FontAssetExporter(BinaryAssetExporter):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _FONT_CLASS_ID and self.is_valid_data(asset.get("m_FontData")):
            return True, FontAssetExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        data = _font_data_bytes(asset)
        with file_system.file.create(path) as stream:
            stream.write(data, 0, len(data))
        return True


class FontAssetExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return get_font_extension(_font_data_bytes(asset))


def get_font_extension(font_data: bytes) -> str:
    """OpenType fonts start with the "OTTO" magic (CFF-flavored OpenType); everything
    else Unity accepts as font data is a variant of TrueType."""
    return _OTF_EXTENSION if font_data.startswith(_OTF_MAGIC) else _TTF_EXTENSION


def _font_data_bytes(asset) -> bytes:
    """m_FontData is a TypelessData field, read as list[int] by the dynamic reader."""
    return bytes(asset.get("m_FontData") or ())
