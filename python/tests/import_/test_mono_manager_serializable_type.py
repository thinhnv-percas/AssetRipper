"""
Phase 16f: tests for `mono_manager.MonoAssembly.get_serializable_type`, the piece that turns a
recovered Mono type into an actual `SerializableType` graph (not just `.cs` text) so a
MonoBehaviour with no embedded type tree can be *read* for real. See mono_manager.py's module
docstring for exactly which simplifications this makes.

Builds a richer synthetic module than test_mono_manager.py's (inheritance chain, a PPtr-shaped
reference field, `List<T>`, a hardcoded engine struct, and one genuinely unresolvable field) via
the same hand-built-PE approach as the rest of this test package. The last test in this file
goes one step further than structural assertions: it feeds real bytes through
`SerializableStructure.read`, the same reader every TypeTree-derived asset already uses,
proving the recovered graph is not just plausible-looking but actually consumable.
"""
import struct

from assetripper_import.structure.assembly.dotnet_metadata.compressed_integer import encode_type_def_or_ref
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.assembly.managers import unity_engine_structs
from assetripper_import.structure.assembly.managers.mono_manager import read_assembly
from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_files.serialized_files.transfer_instruction_flags import TransferInstructionFlags
from assetripper_primitives import UnityVersion
from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_serialization_logic.serializable_pointer_type import SerializablePointerType

from ._module_builder import Coded, ModuleBuilder, compress_uint, wrap_pe

_INT_SIG = bytes([0x06, 0x08])
_FLOAT_SIG = bytes([0x06, 0x0C])
_STRING_SIG = bytes([0x06, 0x0E])
_STRING_ARRAY_SIG = bytes([0x06, 0x1D, 0x0E])

_PUBLIC = 0x0006
_PRIVATE = 0x0001


def _value_type_sig(type_def_row_number: int) -> bytes:
    encoded = encode_type_def_or_ref(0, type_def_row_number - 1)
    return bytes([0x06, 0x11]) + compress_uint(encoded)


def _class_ref_sig(type_def_row_number: int) -> bytes:
    encoded = encode_type_def_or_ref(0, type_def_row_number - 1)
    return bytes([0x06, 0x12]) + compress_uint(encoded)


def _type_ref_valuetype_sig(type_ref_row_number: int) -> bytes:
    encoded = encode_type_def_or_ref(1, type_ref_row_number - 1)
    return bytes([0x06, 0x11]) + compress_uint(encoded)


def _list_of_int_sig(list_type_ref_row_number: int) -> bytes:
    encoded = encode_type_def_or_ref(1, list_type_ref_row_number - 1)
    return bytes([0x06, 0x15, 0x12]) + compress_uint(encoded) + compress_uint(1) + bytes([0x08])


def _build_module() -> bytes:
    b = ModuleBuilder()
    h = b.heaps
    h.add_guid()
    b.add_row(TableId.MODULE, generation=0, name=h.add_string("Test.dll"), mvid=1, enc_id=0, enc_base_id=0)
    b.add_row(TableId.ASSEMBLY_REF, major_version=4, minor_version=0, build_number=0, revision_number=0,
              flags=0, public_key_or_token=h.add_blob(b""), name=h.add_string("mscorlib"), culture=h.add_string(""),
              hash_value=h.add_blob(b""))

    def type_ref(namespace: str, name: str) -> int:
        return b.add_row(
            TableId.TYPE_REF, resolution_scope=Coded("ResolutionScope", TableId.ASSEMBLY_REF, 1),
            name=h.add_string(name), namespace=h.add_string(namespace),
        )

    tr_value_type = type_ref("System", "ValueType")
    tr_mono_behaviour = type_ref("UnityEngine", "MonoBehaviour")
    tr_vector3 = type_ref("UnityEngine", "Vector3")
    tr_datetime = type_ref("System", "DateTime")
    tr_list = type_ref("System.Collections.Generic", "List`1")
    tr_serialize_field = type_ref("UnityEngine", "SerializeFieldAttribute")

    member_ref_ctor = b.add_row(
        TableId.MEMBER_REF, class_=Coded("MemberRefParent", TableId.TYPE_REF, tr_serialize_field),
        name=h.add_string(".ctor"), signature=h.add_blob(bytes([0x20, 0x00, 0x01])),
    )

    type_def_module = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )
    assert type_def_module == 1

    my_struct = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("MyStruct"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_value_type), field_list=1, method_list=1,
    )
    recoverable = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("Recoverable"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=2, method_list=1,
    )
    other_behaviour = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("OtherBehaviour"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=10, method_list=1,
    )
    unrecoverable = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("Unrecoverable"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=10, method_list=1,
    )
    base_type = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("Base"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=11, method_list=1,
    )
    derived_type = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("Derived"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_DEF, base_type), field_list=12, method_list=1,
    )

    def field(flags: int, name: str, signature: bytes) -> int:
        return b.add_row(TableId.FIELD, flags=flags, name=h.add_string(name), signature=h.add_blob(signature))

    field(_PUBLIC, "x", _INT_SIG)  # MyStruct.x -- row 1
    field(_PUBLIC, "health", _INT_SIG)  # row 2
    speed_row = field(_PRIVATE, "_speed", _FLOAT_SIG)  # row 3
    field(_PUBLIC, "label", _STRING_SIG)  # row 4
    field(_PUBLIC, "target", _value_type_sig(my_struct))  # row 5
    field(_PUBLIC, "tags", _STRING_ARRAY_SIG)  # row 6
    field(_PUBLIC, "other", _class_ref_sig(other_behaviour))  # row 7
    field(_PUBLIC, "numbers", _list_of_int_sig(tr_list))  # row 8
    field(_PUBLIC, "position", _type_ref_valuetype_sig(tr_vector3))  # row 9
    field(_PUBLIC, "bad", _type_ref_valuetype_sig(tr_datetime))  # row 10 (Unrecoverable.bad)
    field(_PUBLIC, "baseField", _INT_SIG)  # row 11 (Base.baseField)
    field(_PUBLIC, "derivedField", _INT_SIG)  # row 12 (Derived.derivedField)

    b.add_row(
        TableId.CUSTOM_ATTRIBUTE, parent=Coded("HasCustomAttribute", TableId.FIELD, speed_row),
        type=Coded("CustomAttributeType", TableId.MEMBER_REF, member_ref_ctor),
        value=h.add_blob(bytes([0x01, 0x00, 0x00, 0x00])),
    )

    return wrap_pe(b.build())


def test_struct_serializable_type_has_one_int_field():
    assembly = read_assembly(_build_module())
    my_struct = assembly.get_serializable_type("MyGame", "MyStruct")
    assert my_struct is not None
    assert [(f.name, f.type.type, f.array_depth) for f in my_struct.fields] == [("x", PrimitiveType.INT, 0)]


def test_recoverable_behaviour_resolves_every_field_shape():
    assembly = read_assembly(_build_module())
    recoverable = assembly.get_serializable_type("MyGame", "Recoverable")
    assert recoverable is not None
    fields = {f.name: f for f in recoverable.fields}
    assert set(fields) == {"health", "_speed", "label", "target", "tags", "other", "numbers", "position"}

    assert fields["health"].type.type == PrimitiveType.INT
    assert fields["health"].array_depth == 0
    assert fields["_speed"].type.type == PrimitiveType.SINGLE
    assert fields["label"].type.type == PrimitiveType.STRING

    my_struct = assembly.get_serializable_type("MyGame", "MyStruct")
    assert fields["target"].type is my_struct  # same cached instance, not a re-built copy

    assert fields["tags"].type.type == PrimitiveType.STRING
    assert fields["tags"].array_depth == 1

    assert fields["other"].type is SerializablePointerType.shared()
    assert fields["other"].array_depth == 0

    assert fields["numbers"].type.type == PrimitiveType.INT
    assert fields["numbers"].array_depth == 1

    vector3_template = unity_engine_structs.get("UnityEngine", "Vector3")
    assert fields["position"].type is vector3_template


def test_unresolvable_field_declines_the_whole_type():
    assembly = read_assembly(_build_module())
    assert assembly.get_serializable_type("MyGame", "Unrecoverable") is None
    # Repeat call must not raise or resolve differently -- the decline itself is cached.
    assert assembly.get_serializable_type("MyGame", "Unrecoverable") is None


def test_inherited_fields_from_a_local_base_class_are_included_base_first():
    assembly = read_assembly(_build_module())
    base = assembly.get_serializable_type("MyGame", "Base")
    assert base is not None
    assert [f.name for f in base.fields] == ["baseField"]

    derived = assembly.get_serializable_type("MyGame", "Derived")
    assert derived is not None
    assert [f.name for f in derived.fields] == ["baseField", "derivedField"]


def test_get_serializable_type_caches_the_same_instance():
    assembly = read_assembly(_build_module())
    first = assembly.get_serializable_type("MyGame", "Recoverable")
    second = assembly.get_serializable_type("MyGame", "Recoverable")
    assert first is second


def test_recovered_struct_actually_reads_real_bytes():
    """End-to-end: feed real bytes through the same SerializableStructure/EndianSpanReader
    reader every TypeTree-derived asset uses, proving the recovered graph is consumable, not
    just structurally plausible."""
    assembly = read_assembly(_build_module())
    my_struct = assembly.get_serializable_type("MyGame", "MyStruct")
    structure = my_struct.create_serializable_structure()
    data = struct.pack("<i", 42)
    reader = EndianSpanReader(data)
    structure.read(reader, UnityVersion(2019, 4, 0), TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS)
    assert reader.position == reader.length
    assert structure["x"] == 42
