"""Port of Source/AssetRipper.Export.UnityProjects/Miscellaneous/{TextAssetExporter,
TextAssetExportCollection}.cs

Known caveat: TextAsset's `m_Script` field is read by this port's dynamic reader through
the generic STRING primitive path (assetripper_io_endian.EndianSpanReader.read_utf8_string),
which decodes with `errors="replace"`. A TextAsset whose original bytes were not valid
UTF-8 (a common use of TextAsset -- packing arbitrary binary data) will already have lossy
U+FFFD replacement characters by the time this exporter sees it; re-encoding to UTF-8 on
export cannot recover the original bytes. This is a pre-existing Phase 1 limitation, not
something introduced here -- fixing it needs threading raw bytes through the string-reading
path everywhere a String field is read, a larger cross-cutting change.

`TextExportMode` (Phase 10): `Bytes`/`Txt` force a fixed extension; `Parse` (the default)
keeps the JSON/plain-text/bytes guessing this exporter always did before settings existed.
`GetBestExtension()` (an asset-bundle-name-derived extension) still wins over all three
modes, matching upstream exactly.
"""
from __future__ import annotations

import json

from assetripper_export_configuration.text_export_mode import TextExportMode
from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_export_unity_projects.project.text_script_importer import TextScriptImporter

from .binary_asset_exporter import BinaryAssetExporter

_JSON_EXTENSION = "json"
_TXT_EXTENSION = "txt"
_BYTES_EXTENSION = "bytes"

_TEXT_ASSET_CLASS_ID = 49

_DANGEROUS_EXTENSIONS = frozenset(
    {"cs", "dll", "exe", "bat", "cmd", "ps1", "vbs", "js", "msi", "scr", "com"}
)


class TextAssetExporter(BinaryAssetExporter):
    def __init__(self, export_mode: TextExportMode = TextExportMode.PARSE):
        self.export_mode = export_mode

    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _TEXT_ASSET_CLASS_ID and asset.get("m_Script"):
            return True, TextAssetExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        script = asset.get("m_Script") or ""
        with file_system.file.create(path) as stream:
            data = script.encode("utf-8")
            stream.write(data, 0, len(data))
        return True


class TextAssetExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        extension = asset.get_best_extension()
        if extension is not None:
            if extension.lower() in _DANGEROUS_EXTENSIONS:
                return _TXT_EXTENSION
            return extension

        mode = self.asset_exporter.export_mode
        if mode == TextExportMode.TXT:
            return _TXT_EXTENSION
        if mode == TextExportMode.PARSE:
            return _guess_extension(asset.get("m_Script") or "")
        return _BYTES_EXTENSION  # TextExportMode.BYTES

    def _create_importer(self, container):
        importer = TextScriptImporter()
        if self.asset.asset_bundle_name is not None:
            importer.asset_bundle_name = self.asset.asset_bundle_name
        return importer


def _guess_extension(text: str) -> str:
    if _is_valid_json(text):
        return _JSON_EXTENSION
    if _is_plain_text(text):
        return _TXT_EXTENSION
    return _BYTES_EXTENSION


def _is_valid_json(text: str) -> bool:
    try:
        json.loads(text)
        return True
    except (ValueError, TypeError):
        return False


def _is_plain_text(text: str) -> bool:
    """Port of `text.All(c => !char.IsControl(c) || char.IsWhiteSpace(c))`."""
    return all(not _is_control(c) or c.isspace() for c in text)


def _is_control(c: str) -> bool:
    return ord(c) < 0x20 or ord(c) == 0x7F
