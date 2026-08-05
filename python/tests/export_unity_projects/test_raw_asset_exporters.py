"""Phase 15: `RawAssets/{UnknownObjectExporter,UnreadableObjectExporter}.cs` port -- verifies
`UnknownObject`/`UnreadableObject` (assets whose layout couldn't be determined, or that failed
to read against a known layout) get their raw bytes written out under
`AssetRipper/{UnknownAssets,UnreadableAssets}/` instead of falling through to
`DefaultYamlExporter`, which would produce a meaningless empty YAML document (they expose no
fields to walk).
"""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_unity_projects.dummy_asset_exporter import get_dummy_asset_exporter
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_export_unity_projects.raw_assets.unknown_object_exporter import UnknownObjectExporter
from assetripper_export_unity_projects.raw_assets.unreadable_object_exporter import UnreadableObjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_import.asset_creation.raw_data_object import UnknownObject, UnreadableObject
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, unity_string

FS = LocalFileSystem()

_TEXT_ASSET_TREE = [node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1)]
_UNREGISTERED_CLASS_ID = 30000  # not in asset_creation.layouts' default registry


def _build_game_bundle(class_id: int, tree_nodes, payload: bytes, *, with_type_tree: bool):
    serialized_type = SerializedType()
    serialized_type.type_id = class_id
    serialized_type.is_stripped_type = False
    serialized_type.script_type_index = -1
    if with_type_tree:
        serialized_type.old_type.nodes = list(tree_nodes)

    obj = ObjectInfo(serialized_type)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload

    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=with_type_tree,
    )
    builder.types.append(serialized_type)
    builder.objects.append(obj)
    serialized_file = builder.build()

    game_bundle = GameBundle()
    collection = game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle, collection


def test_unknown_object_writes_raw_bytes():
    game_bundle, collection = _build_game_bundle(_UNREGISTERED_CLASS_ID, [], b"\x01\x02\x03\x04", with_type_tree=False)
    asset = collection.assets[1]
    assert isinstance(asset, UnknownObject)

    exporter = ProjectExporter()
    exporter.override_exporter(UnknownObject, UnknownObjectExporter(), allow_inheritance=False)

    import tempfile

    with tempfile.TemporaryDirectory() as tmp:
        exporter.export(game_bundle, tmp, FS)

        import os

        found = []
        for root, _dirs, files in os.walk(tmp):
            found.extend(os.path.join(root, f) for f in files)
        assert len(found) == 1
        assert found[0].endswith(".unknown")
        with open(found[0], "rb") as f:
            assert f.read() == b"\x01\x02\x03\x04"


def test_unreadable_object_writes_raw_bytes():
    game_bundle, collection = _build_game_bundle(49, _TEXT_ASSET_TREE, b"\xff\xff\xff\xff", with_type_tree=True)
    asset = collection.assets[1]
    assert isinstance(asset, UnreadableObject)

    exporter = ProjectExporter()
    exporter.override_exporter(UnreadableObject, UnreadableObjectExporter(), allow_inheritance=False)

    import tempfile

    with tempfile.TemporaryDirectory() as tmp:
        exporter.export(game_bundle, tmp, FS)

        import os

        found = []
        for root, _dirs, files in os.walk(tmp):
            found.extend(os.path.join(root, f) for f in files)
        assert len(found) == 1
        assert found[0].endswith(".unreadable")
        with open(found[0], "rb") as f:
            assert f.read() == b"\xff\xff\xff\xff"


def test_unknown_object_dummy_exporter_produces_no_file():
    """`export_unreadable_assets=False` (the default) -- registration.py wires the dummy
    (skip) exporter instead of a real one, so nothing gets written at all."""
    game_bundle, collection = _build_game_bundle(_UNREGISTERED_CLASS_ID, [], b"\x01\x02\x03\x04", with_type_tree=False)
    assert isinstance(collection.assets[1], UnknownObject)

    exporter = ProjectExporter()
    exporter.override_exporter(
        UnknownObject, get_dummy_asset_exporter(is_empty_collection=False, is_meta_type=False), allow_inheritance=False
    )

    import os
    import tempfile

    with tempfile.TemporaryDirectory() as tmp:
        exporter.export(game_bundle, tmp, FS)

        written_files = [os.path.join(root, f) for root, _d, files in os.walk(tmp) for f in files]
        assert written_files == []


def test_class_id_dispatch_is_bypassed_for_raw_data_objects():
    """A regression guard for the project_exporter.py fix this phase needed: an UnreadableObject
    whose class ID (49, TextAsset) collides with a registered class-ID exporter must still go
    through UnreadableObjectExporter, not the TextAsset content exporter (which would crash --
    TextAssetExporter expects real `m_Script`/`m_Name` fields that a RawDataObject doesn't have)."""
    from assetripper_export_modules.text_asset_exporter import TextAssetExporter

    game_bundle, collection = _build_game_bundle(49, _TEXT_ASSET_TREE, b"\xff\xff\xff\xff", with_type_tree=True)
    assert isinstance(collection.assets[1], UnreadableObject)

    exporter = ProjectExporter()
    exporter.override_exporter_for_class_id(49, TextAssetExporter())
    exporter.override_exporter(UnreadableObject, UnreadableObjectExporter(), allow_inheritance=False)

    import tempfile

    with tempfile.TemporaryDirectory() as tmp:
        # Must not raise -- if class-ID dispatch won, TextAssetExporter would blow up trying
        # to read m_Script/m_Name off a RawDataObject.
        exporter.export(game_bundle, tmp, FS)
