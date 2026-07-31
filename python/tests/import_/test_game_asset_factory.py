"""
End-to-end tests for GameAssetFactory: a real SerializedFile is written and read back
through the actual scheme, then its objects are decoded against the file's own embedded type
tree. This is the integration path the CLI and GUI use.

No upstream counterpart -- upstream's equivalent resolves layouts from generated classes.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.asset_creation import GameAssetFactory, TypeTreeObject, UnknownObject
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder, SerializedFileScheme
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.smart import SmartStream
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion

from ._tree_builder import node, string_nodes, unity_string


def _build_file(class_id: int, tree_nodes, payload: bytes, *, with_type_tree: bool = True, version=None):
    serialized_type = SerializedType()
    serialized_type.type_id = class_id
    serialized_type.is_stripped_type = False
    serialized_type.script_type_index = -1
    if with_type_tree:
        serialized_type.old_type.nodes = list(tree_nodes)
        serialized_type.old_type.build_string_buffer()

    obj = ObjectInfo(serialized_type)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload

    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=version or UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=with_type_tree,
    )
    builder.types.append(serialized_type)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0.assets"

    stream = MemoryStream()
    serialized_file.write(stream)
    smart = SmartStream.create_memory(bytearray(stream.to_array()))
    return SerializedFileScheme.default().read(smart, "/game/sharedassets0.assets", "sharedassets0.assets")


_TEXT_ASSET_TREE = [
    node("TextAsset", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_Script", 1),
]


def test_asset_with_embedded_type_tree_decodes_to_named_fields():
    payload = unity_string("MyTextAsset") + unity_string("hello world")
    serialized_file = _build_file(49, _TEXT_ASSET_TREE, payload)
    assert serialized_file.has_type_tree

    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    assert len(collection.assets) == 1
    asset = collection.assets[1]
    assert isinstance(asset, TypeTreeObject)
    assert asset.class_name == "TextAsset"
    assert asset["m_Name"] == "MyTextAsset"
    assert asset["m_Script"] == "hello world"
    assert list(asset.keys()) == ["m_Name", "m_Script"]


def test_asset_without_type_tree_and_without_a_registered_layout_becomes_unknown_object():
    """A stripped release file for a class ID this port has no layout for gives the factory
    nothing to work with, so the raw bytes are preserved as an UnknownObject rather than
    being guessed at."""
    _UNREGISTERED_CLASS_ID = 30000  # not in asset_creation.layouts' default registry
    serialized_file = _build_file(_UNREGISTERED_CLASS_ID, [], b"\x01\x02\x03\x04", with_type_tree=False)
    assert not serialized_file.has_type_tree

    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    asset = collection.assets[1]
    assert isinstance(asset, UnknownObject)
    assert asset.raw_data == b"\x01\x02\x03\x04"
    assert asset.name.startswith("Unknown")


def test_default_layout_registry_decodes_a_stripped_text_asset():
    """End-to-end: GameAssetFactory()'s default layout_provider (asset_creation.layouts)
    decodes a TextAsset (class 49) even though the file embeds no type tree at all --
    exercising the actual Phase 2 registry, not a test-supplied stand-in."""
    payload = unity_string("PlayerName") + unity_string("dialogue text")
    serialized_file = _build_file(49, [], payload, with_type_tree=False)
    assert not serialized_file.has_type_tree

    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    asset = collection.assets[1]
    assert isinstance(asset, TypeTreeObject)
    assert asset.class_name == "TextAsset"
    assert asset["m_Name"] == "PlayerName"
    assert asset["m_Script"] == "dialogue text"


def test_layout_provider_supplies_a_tree_when_the_file_has_none():
    """The hook phase 2's hand-written layout registry plugs into."""
    from assetripper_import.structure.assembly.type_trees import TypeTreeNodeStruct
    from assetripper_io_files.serialized_files.parser.type_trees.type_tree import TypeTree

    serialized_file = _build_file(49, _TEXT_ASSET_TREE, unity_string("Hi") + unity_string("There"), with_type_tree=False)

    def layout_provider(class_id, version):
        assert class_id == 49
        tree = TypeTree()
        tree.nodes = list(_TEXT_ASSET_TREE)
        ok, root = TypeTreeNodeStruct.try_make_from_type_tree(tree)
        return root if ok else None

    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(
        serialized_file, GameAssetFactory(layout_provider=layout_provider)
    )

    asset = collection.assets[1]
    assert isinstance(asset, TypeTreeObject)
    assert asset["m_Name"] == "Hi"
    assert asset["m_Script"] == "There"


def test_payload_that_does_not_match_the_tree_becomes_unreadable():
    serialized_file = _build_file(49, _TEXT_ASSET_TREE, b"\xff\xff\xff\xff")

    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    from assetripper_import.asset_creation import UnreadableObject

    asset = collection.assets[1]
    assert isinstance(asset, UnreadableObject)
    assert asset.name.startswith("UnreadableTextAsset_")


def test_dependencies_are_fetched_through_pptr_fields():
    tree_nodes = [
        node("MyType", "Base", 0),
        node("PPtr<GameObject>", "m_Target", 1),
        node("int", "m_FileID", 2),
        node("SInt64", "m_PathID", 2),
    ]
    payload = struct.pack("<i", 0) + struct.pack("<q", 77)
    serialized_file = _build_file(1000, tree_nodes, payload)

    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    asset = collection.assets[1]

    dependencies = list(asset.fetch_dependencies())
    assert len(dependencies) == 1
    path, pptr = dependencies[0]
    assert path.startswith("m_Target")
    assert (pptr.file_id, pptr.path_id) == (0, 77)


def test_walk_editor_visits_fields_in_order():
    """The traversal hook the YAML exporter will consume in a later phase."""
    from assetripper_assets.traversal import AssetWalker

    class RecordingWalker(AssetWalker):
        def __init__(self):
            self.events = []

        def enter_asset(self, asset):
            self.events.append(("enter_asset", str(asset)))
            return True

        def exit_asset(self, asset):
            self.events.append(("exit_asset", str(asset)))

        def enter_field(self, asset, name):
            self.events.append(("enter_field", name))
            return True

        def exit_field(self, asset, name):
            self.events.append(("exit_field", name))

        def visit_primitive(self, value):
            self.events.append(("primitive", value))

    payload = unity_string("N") + unity_string("S")
    serialized_file = _build_file(49, _TEXT_ASSET_TREE, payload)
    bundle = GameBundle()
    collection = bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    asset = collection.assets[1]

    walker = RecordingWalker()
    asset.walk_editor(walker)

    assert walker.events[0][0] == "enter_asset"
    assert ("enter_field", "m_Name") in walker.events
    assert ("primitive", "N") in walker.events
    assert ("primitive", "S") in walker.events
    assert walker.events[-1][0] == "exit_asset"
