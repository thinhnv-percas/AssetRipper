"""Port of the single-asset export path of
Source/AssetRipper.Export.UnityProjects/Project/YamlExporterBase.cs

Multi-asset-per-file export (`Export(container, assets, path, fileSystem)`, used for scene/
prefab files) is not ported here -- it depends on Phase 5's scene/prefab processors to decide
which assets belong in the same file. See export_collection.py/asset_export_collection.py
for the single-asset case this port currently supports.
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
