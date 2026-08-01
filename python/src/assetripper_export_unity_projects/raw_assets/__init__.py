"""Port of Source/AssetRipper.Export.UnityProjects/RawAssets/

Exporters for `UnknownObject`/`UnreadableObject` (assetripper_import.asset_creation.
raw_data_object): assets whose real field layout couldn't be determined, kept only as raw
bytes. Without these, both types fell through to `DefaultYamlExporter` (via `AssetExportCollection`,
which calls `asset_exporter.export_asset` -- a YAML asset walker that has nothing to walk on a
`RawDataObject`, since it exposes no fields), producing a meaningless empty YAML document
instead of the raw bytes. These write the raw bytes directly under
`AssetRipper/{UnknownAssets,UnreadableAssets}/<ClassName>/<Name>.<unknown|unreadable>`,
matching upstream exactly.
"""
