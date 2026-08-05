"""
Phase 16c end-to-end test: builds one synthetic module covering the field-recovery rules
`mono_manager.py` implements (WillUnitySerialize subset, see its module docstring), then reads
it back through `read_assembly` and checks the recovered `RecoveredType`/`RecoveredField`
shapes -- the same kind of hand-built-fixture verification test_dotnet_metadata.py uses for the
lower-level metadata pieces.
"""
from assetripper_import.structure.assembly.dotnet_metadata.compressed_integer import encode_type_def_or_ref
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.assembly.managers.mono_manager import read_assembly
from assetripper_export_modules.scripts.csharp_emitter import emit

from ._module_builder import Coded, ModuleBuilder, compress_uint, wrap_pe

_INT_SIG = bytes([0x06, 0x08])
_FLOAT_SIG = bytes([0x06, 0x0C])
_STRING_SIG = bytes([0x06, 0x0E])
_STRING_ARRAY_SIG = bytes([0x06, 0x1D, 0x0E])
_VAR0_SIG = bytes([0x06, 0x13, 0x00])

_PUBLIC = 0x0006
_PRIVATE = 0x0001
_STATIC = 0x0010
_LITERAL = 0x0040
_SPECIAL_NAME = 0x0200
_RT_SPECIAL_NAME = 0x0400


def _value_type_sig(type_def_row_number: int) -> bytes:
    encoded = encode_type_def_or_ref(0, type_def_row_number - 1)  # tag 0 = TypeDef
    return bytes([0x06, 0x11]) + compress_uint(encoded)


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

    tr_object = type_ref("System", "Object")
    tr_value_type = type_ref("System", "ValueType")
    tr_enum = type_ref("System", "Enum")
    tr_mono_behaviour = type_ref("UnityEngine", "MonoBehaviour")
    tr_serialize_field = type_ref("UnityEngine", "SerializeFieldAttribute")

    member_ref_ctor = b.add_row(
        TableId.MEMBER_REF, class_=Coded("MemberRefParent", TableId.TYPE_REF, tr_serialize_field),
        name=h.add_string(".ctor"), signature=h.add_blob(bytes([0x20, 0x00, 0x01])),
    )

    # <Module> pseudo-type (mandatory TypeDef row 1, no fields of its own).
    type_def_module = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )
    assert type_def_module == 1

    my_struct = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("MyStruct"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_value_type), field_list=1, method_list=1,
    )
    test_behaviour = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("TestBehaviour"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_mono_behaviour), field_list=2, method_list=1,
    )
    skipped_enum = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("SkippedEnum"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_enum), field_list=11, method_list=1,
    )
    generic_holder = b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("GenericHolder`1"), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_object), field_list=12, method_list=1,
    )

    def field(flags: int, name: str, signature: bytes) -> int:
        return b.add_row(TableId.FIELD, flags=flags, name=h.add_string(name), signature=h.add_blob(signature))

    field(_PUBLIC, "x", _INT_SIG)  # MyStruct.x -- row 1
    field(_PUBLIC, "health", _INT_SIG)  # row 2
    speed_row = field(_PRIVATE, "_speed", _FLOAT_SIG)  # row 3
    field(_PUBLIC, "label", _STRING_SIG)  # row 4
    field(_PUBLIC, "target", _value_type_sig(my_struct))  # row 5
    field(_PUBLIC, "tags", _STRING_ARRAY_SIG)  # row 6
    field(_PRIVATE, "_hidden", _INT_SIG)  # row 7 -- excluded, not public/no SerializeField
    field(_PUBLIC | _STATIC, "_static", _INT_SIG)  # row 8 -- excluded, static
    field(_PUBLIC | _LITERAL, "_const", _INT_SIG)  # row 9 -- excluded, const
    field(_PRIVATE, "<Health>k__BackingField", _INT_SIG)  # row 10 -- excluded, compiler-generated
    field(_PUBLIC | _SPECIAL_NAME | _RT_SPECIAL_NAME, "value__", _INT_SIG)  # row 11 (SkippedEnum)
    field(_PUBLIC, "Value", _VAR0_SIG)  # row 12 (GenericHolder`1)

    b.add_row(
        TableId.CUSTOM_ATTRIBUTE, parent=Coded("HasCustomAttribute", TableId.FIELD, speed_row),
        type=Coded("CustomAttributeType", TableId.MEMBER_REF, member_ref_ctor),
        value=h.add_blob(bytes([0x01, 0x00, 0x00, 0x00])),
    )
    b.add_row(
        TableId.GENERIC_PARAM, number=0, flags=0,
        owner=Coded("TypeOrMethodDef", TableId.TYPE_DEF, generic_holder), name=h.add_string("T"),
    )

    return wrap_pe(b.build())


def test_struct_type_is_recovered_with_public_field():
    assembly = read_assembly(_build_module())
    my_struct = assembly.get_type("MyGame", "MyStruct")
    assert my_struct is not None
    assert my_struct.is_struct
    assert my_struct.base_type_name is None
    assert [(f.name, f.type_name, f.is_public) for f in my_struct.fields] == [("x", "int", True)]


def test_enum_type_def_is_not_recovered():
    assembly = read_assembly(_build_module())
    assert assembly.get_type("MyGame", "SkippedEnum") is None


def test_generic_type_field_resolves_to_its_own_type_parameter():
    assembly = read_assembly(_build_module())
    generic_holder = assembly.get_type("MyGame", "GenericHolder`1")
    assert generic_holder is not None
    assert [(f.name, f.type_name) for f in generic_holder.fields] == [("Value", "T")]


def test_mono_behaviour_field_recovery_applies_will_unity_serialize_gating():
    assembly = read_assembly(_build_module())
    test_behaviour = assembly.get_type("MyGame", "TestBehaviour")
    assert test_behaviour is not None
    assert test_behaviour.base_type_name == "MonoBehaviour"
    assert not test_behaviour.is_struct

    fields_by_name = {f.name: f for f in test_behaviour.fields}
    assert set(fields_by_name) == {"health", "_speed", "label", "target", "tags"}

    assert fields_by_name["health"].type_name == "int"
    assert fields_by_name["health"].is_public

    assert fields_by_name["_speed"].type_name == "float"
    assert not fields_by_name["_speed"].is_public
    assert fields_by_name["_speed"].attributes == ("SerializeField",)

    assert fields_by_name["label"].type_name == "string"
    assert fields_by_name["target"].type_name == "MyGame.MyStruct"
    assert fields_by_name["tags"].type_name == "string[]"


def test_recovered_test_behaviour_emits_valid_looking_cs_text():
    assembly = read_assembly(_build_module())
    test_behaviour = assembly.get_type("MyGame", "TestBehaviour")
    text = emit(test_behaviour)
    assert "public class TestBehaviour : MonoBehaviour" in text
    assert "public int health;" in text
    assert "[SerializeField]" in text
    assert "private float _speed;" in text
    assert "public MyGame.MyStruct target;" in text
