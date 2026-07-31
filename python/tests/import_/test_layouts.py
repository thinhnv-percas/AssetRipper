"""
Tests for the hand-written layouts in assetripper_import.asset_creation.layouts.

No upstream counterpart -- this registry doesn't exist in AssetRipper (see the layouts
package docstring for why: upstream resolves this case from the Tpk type-tree database).
Each test builds a payload matching what the layout module claims to expect and verifies
the interpreter consumes it exactly, the same shape of test used throughout
test_serializable_structure.py.
"""
import struct

from assetripper_import.asset_creation.layouts import default_registry
from assetripper_import.structure.assembly.type_trees import SerializableTreeType
from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion

from ._tree_builder import unity_string

_NO_FLAGS = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS


def _read_via_registry(class_id: int, version: UnityVersion, data: bytes):
    registry = default_registry()
    node = registry.get(class_id, version)
    assert node is not None, f"no layout registered for class {class_id} at {version}"
    structure = SerializableTreeType.from_root_node(node).create_serializable_structure()
    reader = EndianSpanReader(data)
    structure.read(reader, version, _NO_FLAGS)
    return structure, reader


def test_registry_has_no_entry_for_an_unregistered_class():
    assert default_registry().get(999999, UnityVersion(2019, 4, 0)) is None


def test_registry_has_no_entry_for_monobehaviour():
    """MonoBehaviour is deliberately never registered -- its layout is user-defined and
    can't be guessed from the class ID alone."""
    assert default_registry().get(114, UnityVersion(2019, 4, 0)) is None


def test_text_asset_layout():
    data = unity_string("Name") + unity_string("Script contents")
    structure, reader = _read_via_registry(49, UnityVersion(2019, 4, 0), data)
    assert structure["m_Name"] == "Name"
    assert structure["m_Script"] == "Script contents"
    assert reader.position == len(data)


def test_mono_script_layout():
    data = unity_string("MyScript") + unity_string("MyBehaviour") + unity_string("MyGame") + unity_string("Assembly-CSharp")
    structure, reader = _read_via_registry(115, UnityVersion(2019, 4, 0), data)
    assert structure["m_Name"] == "MyScript"
    assert structure["m_ClassName"] == "MyBehaviour"
    assert structure["m_Namespace"] == "MyGame"
    assert structure["m_AssemblyName"] == "Assembly-CSharp"
    assert reader.position == len(data)


def test_game_object_layout():
    data = (
        struct.pack("<i", 2)  # m_Component count
        + struct.pack("<i", 0) + struct.pack("<i", 0) + struct.pack("<q", 100)  # first component
        + struct.pack("<i", 0) + struct.pack("<i", 0) + struct.pack("<q", 200)  # second component
        + struct.pack("<i", 5)  # m_Layer
        + unity_string("Player")  # m_Name
        + unity_string("Untagged")  # m_TagString
        + b"\x01" + b"\x00\x00\x00"  # m_IsActive (aligned bool)
    )
    structure, reader = _read_via_registry(1, UnityVersion(2019, 4, 0), data)
    components = structure["m_Component"]
    assert len(components) == 2
    assert components[0].second.value.path_id == 100
    assert components[1].second.value.path_id == 200
    assert structure["m_Layer"] == 5
    assert structure["m_Name"] == "Player"
    assert structure["m_TagString"] == "Untagged"
    assert structure["m_IsActive"] is True
    assert reader.position == len(data)


def test_game_object_layout_is_not_registered_before_5_5():
    assert default_registry().get(1, UnityVersion(5, 4, 0)) is None


def test_transform_layout_modern_has_no_root_order():
    data = (
        struct.pack("<i", 0) + struct.pack("<q", 42)  # m_GameObject
        + struct.pack("<4f", 0.0, 0.0, 0.0, 1.0)  # m_LocalRotation
        + struct.pack("<3f", 1.0, 2.0, 3.0)  # m_LocalPosition
        + struct.pack("<3f", 1.0, 1.0, 1.0)  # m_LocalScale
        + struct.pack("<i", 1) + struct.pack("<i", 0) + struct.pack("<q", 7)  # m_Children (1 entry)
        + struct.pack("<i", 0) + struct.pack("<q", 0)  # m_Father (null)
    )
    structure, reader = _read_via_registry(4, UnityVersion(2019, 4, 0), data)
    assert structure["m_GameObject"].path_id == 42
    assert structure["m_LocalPosition"]["x"] == 1.0
    assert len(structure["m_Children"]) == 1
    assert structure["m_Children"][0].path_id == 7
    assert structure["m_Father"].path_id == 0
    assert reader.position == len(data)


def test_transform_layout_legacy_has_root_order():
    data = (
        struct.pack("<i", 0) + struct.pack("<q", 42)  # m_GameObject
        + struct.pack("<4f", 0.0, 0.0, 0.0, 1.0)  # m_LocalRotation
        + struct.pack("<3f", 1.0, 2.0, 3.0)  # m_LocalPosition
        + struct.pack("<3f", 1.0, 1.0, 1.0)  # m_LocalScale
        + struct.pack("<i", 0)  # m_Children (empty)
        + struct.pack("<i", 0) + struct.pack("<q", 0)  # m_Father (null)
        + struct.pack("<i", 3)  # m_RootOrder
    )
    structure, reader = _read_via_registry(4, UnityVersion(2017, 4, 0), data)
    assert structure["m_RootOrder"] == 3
    assert reader.position == len(data)


def test_asset_bundle_layout():
    data = (
        unity_string("MyBundle")  # m_Name
        + struct.pack("<i", 1) + struct.pack("<i", 0) + struct.pack("<q", 55)  # m_PreloadTable (1 entry)
        + struct.pack("<i", 1)  # m_Container count
        + unity_string("assets/prefab.prefab")  # key
        + struct.pack("<ii", 0, 1) + struct.pack("<i", 0) + struct.pack("<q", 55)  # AssetInfo
        + struct.pack("<ii", 0, 0) + struct.pack("<i", 0) + struct.pack("<q", 55)  # m_MainAsset
        + struct.pack("<I", 5)  # m_RuntimeCompatibility
        + unity_string("mybundle")  # m_AssetBundleName
        + struct.pack("<i", 0)  # m_Dependencies (empty)
    )
    structure, reader = _read_via_registry(142, UnityVersion(2019, 4, 0), data)
    assert structure["m_Name"] == "MyBundle"
    assert len(structure["m_PreloadTable"]) == 1
    container = structure["m_Container"]
    assert len(container) == 1
    assert container[0].first.value == "assets/prefab.prefab"
    assert container[0].second.value["asset"].path_id == 55
    assert structure["m_MainAsset"]["asset"].path_id == 55
    assert structure["m_RuntimeCompatibility"] == 5
    assert structure["m_AssetBundleName"] == "mybundle"
    assert structure["m_Dependencies"] == []
    assert reader.position == len(data)
