"""Port of the export paths of Source/AssetRipper.Export.UnityProjects/Project/
YamlExporterBase.cs -- both the single-asset overload and (Phase 12) the multi-asset-per-file
one used for scene/prefab files. See export_collection.py/asset_export_collection.py for the
single-asset collection case; project/scene_export_collection.py and
project/prefab_export_collection.py are the multi-asset callers of `export_assets`.
"""
from __future__ import annotations

from assetripper_yaml import YamlWriter

from ._text_writer import Utf8TextWriter


def export_asset(container, asset, path: str, file_system) -> bool:
    from .project.project_yaml_walker import ProjectYamlWalker

    with file_system.file.create(path) as stream:
        writer = YamlWriter()
        walker = ProjectYamlWalker(container)
        document = walker.export_yaml_document(asset)
        writer.add_document(document)
        writer.write(Utf8TextWriter(stream))
    return True


def export_assets(container, assets, path: str, file_system) -> bool:
    """Port of `YamlExporterBase.Export(IExportContainer, IEnumerable<IUnityObjectBase>,
    string, FileSystem)`: one file, multiple `--- !u!<ClassID> &<exportID>` YAML documents,
    in `assets`' iteration order."""
    from .project.project_yaml_walker import ProjectYamlWalker

    with file_system.file.create(path) as stream:
        text_writer = Utf8TextWriter(stream)
        writer = YamlWriter()
        writer.write_head(text_writer)
        walker = ProjectYamlWalker(container)
        for asset in assets:
            document = walker.export_yaml_document(asset)
            writer.write_document(document)
        writer.write_tail(text_writer)
    return True
