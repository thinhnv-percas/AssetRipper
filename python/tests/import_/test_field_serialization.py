"""Port of Source/AssetRipper.SerializationLogic.Tests (2026-08-03): `FieldSerializationTests`
and `CyclicalReferenceTests`, which pin exactly what 16c's `get_serializable_type` implements --
Unity's own rules for which fields end up in a MonoBehaviour's byte layout.

Upstream builds its fixtures by compiling real C# classes and reflecting over them with
AsmResolver. This port has no compiler in the loop, so each case is hand-built ECMA-335 metadata
via `_module_builder`, the same discipline as the rest of this package. Each test names the
upstream test it corresponds to.

**These found three real bugs**, all now fixed in `mono_manager.py` (see its docstring), and all
of the same shape -- the layout either claimed a field Unity writes no bytes for, or read two
ints where inline content lives, so every field after it read from the wrong offset:

1. Every ordinary serializable class was classified as a PPtr, because the base-chain walk
   finished with `mono_utils.is_prime`, which includes `System.Object`.
2. A reference cycle resolved against the half-built cache entry and was kept.
3. An abstract field type was inlined.

None of them was a crash, and none of the pre-existing fixtures could have caught any of them:
every nested type in them was a struct or genuinely MonoBehaviour-derived.

Three cases are `xfail`: version-gated serialization, user-defined generic instantiations, and
fixed-size buffers. All three currently make this port *decline* the containing type rather than
mis-serialize it, so they cost coverage rather than correctness -- but they are written out here
rather than left to be rediscovered.
"""
from __future__ import annotations

import pytest
from assetripper_import.structure.assembly.dotnet_metadata.compressed_integer import encode_type_def_or_ref
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.assembly.managers.mono_manager import read_assembly
from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_serialization_logic.serializable_pointer_type import SerializablePointerType

from ._module_builder import Coded, ModuleBuilder, compress_uint, wrap_pe

_INT_SIG = bytes([0x06, 0x08])
_LONG_SIG = bytes([0x06, 0x0A])
_FLOAT_SIG = bytes([0x06, 0x0C])
_BOOL_SIG = bytes([0x06, 0x02])
_STRING_SIG = bytes([0x06, 0x0E])

_PUBLIC = 0x0006
_PRIVATE = 0x0001
_STATIC = 0x0010
_LITERAL = 0x0040
_NOT_SERIALIZED_FLAG = 0x0080

_TYPE_ABSTRACT = 0x00000080

# ELEMENT_TYPE_CMOD_VOLATILE is encoded as a CMOD_REQD referencing
# System.Runtime.CompilerServices.IsVolatile, which is what `volatile` compiles to.
_CMOD_REQD = 0x1F


def _class_sig(type_def_row_number: int) -> bytes:
    return bytes([0x06, 0x12]) + compress_uint(encode_type_def_or_ref(0, type_def_row_number - 1))


def _value_type_sig(type_def_row_number: int) -> bytes:
    return bytes([0x06, 0x11]) + compress_uint(encode_type_def_or_ref(0, type_def_row_number - 1))


def _list_sig(list_type_ref_row_number: int, element: bytes) -> bytes:
    encoded = encode_type_def_or_ref(1, list_type_ref_row_number - 1)
    return bytes([0x06, 0x15, 0x12]) + compress_uint(encoded) + compress_uint(1) + element


class _Module:
    """Builds one module with the standard external references every case needs, then lets each
    test add only the types it is about."""

    def __init__(self):
        self.b = ModuleBuilder()
        h = self.b.heaps
        h.add_guid()
        self.b.add_row(
            TableId.MODULE, generation=0, name=h.add_string("Test.dll"), mvid=1, enc_id=0, enc_base_id=0
        )
        self.b.add_row(
            TableId.ASSEMBLY_REF, major_version=4, minor_version=0, build_number=0, revision_number=0,
            flags=0, public_key_or_token=h.add_blob(b""), name=h.add_string("mscorlib"),
            culture=h.add_string(""), hash_value=h.add_blob(b""),
        )
        self.ref_object = self._type_ref("System", "Object")
        self.ref_value_type = self._type_ref("System", "ValueType")
        self.ref_mono_behaviour = self._type_ref("UnityEngine", "MonoBehaviour")
        self.ref_unity_object = self._type_ref("UnityEngine", "Object")
        self.ref_list = self._type_ref("System.Collections.Generic", "List`1")
        self.ref_serialize_field = self._type_ref("UnityEngine", "SerializeFieldAttribute")
        self.ref_is_volatile = self._type_ref("System.Runtime.CompilerServices", "IsVolatile")
        self._member_ref_ctor = None

        # TypeDef row 1 is always the `<Module>` pseudo-type, and its empty field range is what
        # makes the first real type's field_list unambiguous.
        self.b.add_row(
            TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
            extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
        )
        self._next_field = 1

    def _type_ref(self, namespace: str, name: str) -> int:
        h = self.b.heaps
        return self.b.add_row(
            TableId.TYPE_REF, resolution_scope=Coded("ResolutionScope", TableId.ASSEMBLY_REF, 1),
            name=h.add_string(name), namespace=h.add_string(namespace),
        )

    def add_type(self, name: str, *, extends=None, flags: int = 0, namespace: str = "Game") -> int:
        """`extends` is ("def", row) / ("ref", row) / None (System.Object)."""
        h = self.b.heaps
        if extends is None:
            coded = Coded("TypeDefOrRef", TableId.TYPE_REF, self.ref_object)
        else:
            kind, row = extends
            table = TableId.TYPE_DEF if kind == "def" else TableId.TYPE_REF
            coded = Coded("TypeDefOrRef", table, row)
        return self.b.add_row(
            TableId.TYPE_DEF, flags=flags, name=h.add_string(name), namespace=h.add_string(namespace),
            extends=coded, field_list=self._next_field, method_list=1,
        )

    def add_field(self, name: str, signature: bytes, *, flags: int = _PUBLIC, serialize_field: bool = False) -> int:
        h = self.b.heaps
        row_number = self.b.add_row(
            TableId.FIELD, flags=flags, name=h.add_string(name), signature=h.add_blob(signature)
        )
        self._next_field = row_number + 1
        if serialize_field:
            self._add_serialize_field_attribute(row_number)
        return row_number

    def _add_serialize_field_attribute(self, field_row_number: int) -> None:
        h = self.b.heaps
        if self._member_ref_ctor is None:
            self._member_ref_ctor = self.b.add_row(
                TableId.MEMBER_REF,
                class_=Coded("MemberRefParent", TableId.TYPE_REF, self.ref_serialize_field),
                name=h.add_string(".ctor"), signature=h.add_blob(bytes([0x20, 0x00, 0x01])),
            )
        self.b.add_row(
            TableId.CUSTOM_ATTRIBUTE,
            parent=Coded("HasCustomAttribute", TableId.FIELD, field_row_number),
            type=Coded("CustomAttributeType", TableId.MEMBER_REF, self._member_ref_ctor),
            value=h.add_blob(b"\x01\x00\x00\x00"),
        )

    def read(self):
        return read_assembly(wrap_pe(self.b.build()))


def _fields_of(module: _Module, name: str, namespace: str = "Game"):
    serializable = module.read().get_serializable_type(namespace, name)
    assert serializable is not None, f"{namespace}.{name} was declined outright"
    return serializable.fields


# -- FieldSerializationTests --------------------------------------------------------------


def test_private_fields_are_correctly_discriminated():
    """Upstream's `PrivateFieldsAreCorrectlyDiscriminated`: only the `[SerializeField]` one."""
    m = _Module()
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("field1", _INT_SIG, flags=_PRIVATE, serialize_field=True)
    m.add_field("field2", _INT_SIG, flags=_PRIVATE)

    fields = _fields_of(m, "Behaviour")
    assert [field.name for field in fields] == ["field1"]


def test_public_fields_are_correctly_discriminated():
    """Upstream's `PublicFieldsAreCorrectlyDiscriminated`: `[NonSerialized]` wins over public."""
    m = _Module()
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("field1", _INT_SIG, flags=_PUBLIC | _NOT_SERIALIZED_FLAG)
    m.add_field("field2", _INT_SIG)

    assert [field.name for field in _fields_of(m, "Behaviour")] == ["field2"]


def test_static_and_const_fields_are_not_serialized():
    """Not a separate upstream test, but the same gate and the same consequence if it broke: a
    `static` or `const` field occupies no bytes in the instance."""
    m = _Module()
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("staticField", _INT_SIG, flags=_PUBLIC | _STATIC)
    m.add_field("constField", _INT_SIG, flags=_PUBLIC | _STATIC | _LITERAL)
    m.add_field("instanceField", _INT_SIG)

    assert [field.name for field in _fields_of(m, "Behaviour")] == ["instanceField"]


def test_resolution_for_unity_types_works_as_expected():
    """Upstream's `ResolutionForUnityTypesWorksAsExpected`: `List<string>` is a string array of
    depth 1, not a complex type."""
    m = _Module()
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("listOfStrings", _list_sig(m.ref_list, bytes([0x0E])))

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].name == "listOfStrings"
    assert fields[0].type.type == PrimitiveType.STRING
    assert fields[0].array_depth == 1


def test_a_plain_nested_class_is_inlined_and_not_treated_as_a_pptr():
    """**Bug found by this port.** `_is_unity_object_descendant` walked the base chain and
    finished with `mono_utils.is_prime`, which is `is_mono_prime` *plus* `System.Object` --
    upstream uses it as a "reached the root of the chain" stop condition, not as "this is a
    UnityEngine.Object". Since every C# class extends `System.Object`, every plain serializable
    class used as a field type came back as a two-int pointer instead of inline content.

    Not a case upstream tests separately -- it has no equivalent bug to guard against -- but it
    is the single most consequential thing this whole file found, because a nested serializable
    class is an extremely ordinary shape in game code."""
    m = _Module()
    nested_row = m.add_type("NestedData")  # extends System.Object, like any ordinary class
    m.add_field("count", _INT_SIG)
    m.add_field("label", _STRING_SIG)
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("data", _class_sig(nested_row))

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].type != SerializablePointerType.shared(), "must be inlined, not a PPtr"
    assert fields[0].type.type == PrimitiveType.COMPLEX
    assert [sub.name for sub in fields[0].type.fields] == ["count", "label"]


def test_deserialization_supports_structs_with_int_field():
    """Upstream's `DeserializationSupportsStructsWithIntField`."""
    m = _Module()
    struct_row = m.add_type("StructWithIntField", extends=("ref", m.ref_value_type))
    m.add_field("value", _INT_SIG)
    m.add_type("Holder", extends=("ref", m.ref_mono_behaviour))
    m.add_field("value", _value_type_sig(struct_row))

    fields = _fields_of(m, "StructWithIntField")
    assert len(fields) == 1
    assert fields[0].name == "value"
    assert fields[0].type.type == PrimitiveType.INT
    assert fields[0].array_depth == 0


def test_struct_field_resolves_to_a_complex_type():
    """The other half of upstream's `StructSerializationStartedWithUnity4_5` (the modern side --
    the version gate itself is xfailed below)."""
    m = _Module()
    struct_row = m.add_type("StructWithIntField", extends=("ref", m.ref_value_type))
    m.add_field("value", _INT_SIG)
    m.add_type("Holder", extends=("ref", m.ref_mono_behaviour))
    m.add_field("value", _value_type_sig(struct_row))

    fields = _fields_of(m, "Holder")
    assert len(fields) == 1
    assert fields[0].type.type == PrimitiveType.COMPLEX
    assert fields[0].array_depth == 0
    assert [sub.name for sub in fields[0].type.fields] == ["value"]


def test_deserialization_supports_volatile_fields():
    """Upstream's `DeserializationSupportsVolatileFields`. `volatile` compiles to a CMOD_REQD on
    the field signature, so a reader that did not skip custom modifiers would read the modifier
    token as the field's type."""
    m = _Module()
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    volatile_bool = (
        bytes([0x06, _CMOD_REQD])
        + compress_uint(encode_type_def_or_ref(1, m.ref_is_volatile - 1))
        + bytes([0x02])
    )
    m.add_field("value", volatile_bool)

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].name == "value"
    assert fields[0].type.type == PrimitiveType.BOOL


def test_deserialization_supports_fields_with_same_name():
    """Upstream's `DeserializationSupportsFieldsWithSameName`: a derived `new` field shadowing a
    base one gives *two* fields with the same name, base first. Unity serializes both, so
    dropping the duplicate would shift every following field."""
    m = _Module()
    base_row = m.add_type("ClassWithLongField")
    m.add_field("value", _LONG_SIG)
    m.add_type("DerivedClassWithNewField", extends=("def", base_row))
    m.add_field("value", _FLOAT_SIG)

    fields = _fields_of(m, "DerivedClassWithNewField")
    assert len(fields) == 2
    assert fields[0].name == fields[1].name == "value"
    assert fields[0].type.type == PrimitiveType.LONG
    assert fields[1].type.type == PrimitiveType.SINGLE


def test_fields_from_base_types_are_serialized_even_without_a_serializable_attribute():
    """Upstream's
    `FieldsFromBaseTypesAreStillSerializedEvenWithoutSerializableAttributeOnBaseType`."""
    m = _Module()
    base_row = m.add_type("BaseWithoutAttribute")
    m.add_field("baseField", _INT_SIG)
    m.add_type("Derived", extends=("def", base_row))
    m.add_field("derivedField", _INT_SIG)

    assert [field.name for field in _fields_of(m, "Derived")] == ["baseField", "derivedField"]


@pytest.mark.parametrize("extends_unity_object_directly", [True, False])
def test_deserialization_supports_pptr_fields(extends_unity_object_directly):
    """Upstream's `DeserializationSupportsPPtrFields`: anything descending from
    `UnityEngine.Object` is a pointer, whether it does so directly or through another local
    type."""
    m = _Module()
    if extends_unity_object_directly:
        target = m.add_type("DerivedObject", extends=("ref", m.ref_unity_object))
    else:
        middle = m.add_type("Middle", extends=("ref", m.ref_mono_behaviour))
        target = m.add_type("DerivedObject", extends=("def", middle))
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("pptr", _class_sig(target))

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].type == SerializablePointerType.shared()
    assert fields[0].array_depth == 0


def test_a_field_of_the_external_unity_object_type_is_a_pptr():
    """Upstream's first `DeserializationSupportsPPtrFields` case: the field's type is
    `UnityEngine.Object` itself, i.e. an external TypeRef rather than a local TypeDef."""
    m = _Module()
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("pptr", bytes([0x06, 0x12]) + compress_uint(encode_type_def_or_ref(1, m.ref_unity_object - 1)))

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].type == SerializablePointerType.shared()


def test_abstract_pptr_fields_are_still_serialized():
    """The reason the abstract gate must sit *after* the PPtr check: upstream's
    `DeserializationSupportsPPtrFields` includes an abstract generic MonoBehaviour, and a PPtr is
    two ints regardless of whether the target can be instantiated."""
    m = _Module()
    target = m.add_type("AbstractBehaviour", extends=("ref", m.ref_mono_behaviour), flags=_TYPE_ABSTRACT)
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field("pptr", _class_sig(target))

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].type == SerializablePointerType.shared()


def test_fields_with_abstract_types_should_not_be_serialized():
    """Upstream's `FieldsWithAbstractTypesShouldNotBeSerialized`. **Bug found by this port** --
    the abstract type used to be inlined as a complex field, so the layout claimed bytes Unity
    never wrote and every following field misaligned."""
    m = _Module()
    abstract_row = m.add_type("AbstractSerializableClass", flags=_TYPE_ABSTRACT)
    m.add_field("value", _INT_SIG)
    m.add_type("Holder", extends=("ref", m.ref_mono_behaviour))
    m.add_field("abstractField", _class_sig(abstract_row))
    m.add_field("intField", _INT_SIG)

    fields = _fields_of(m, "Holder")
    assert [field.name for field in fields] == ["intField"], (
        "the abstract field must be dropped, and the type must NOT be declined outright"
    )


def test_list_of_abstract_type_is_also_not_serialized():
    """A `List<Abstract>` is no more serializable than a bare `Abstract`, and the accumulated
    array depth must not survive the field being dropped."""
    m = _Module()
    abstract_row = m.add_type("AbstractSerializableClass", flags=_TYPE_ABSTRACT)
    m.add_field("value", _INT_SIG)
    m.add_type("Holder", extends=("ref", m.ref_mono_behaviour))
    m.add_field(
        "listOfAbstract",
        _list_sig(m.ref_list, bytes([0x12]) + compress_uint(encode_type_def_or_ref(0, abstract_row - 1))),
    )
    m.add_field("intField", _INT_SIG)

    assert [field.name for field in _fields_of(m, "Holder")] == ["intField"]


def test_field_whose_type_is_its_own_base_should_be_serialized():
    """Upstream's `FieldWhoseTypeIsBaseShouldBeSerialized`: a field typed as the *base* class,
    declared on the derived class, is fine -- there is no cycle, the base does not reference the
    derived type back."""
    m = _Module()
    base_row = m.add_type("BaseClass")
    m.add_field("baseField", _INT_SIG)
    m.add_type("DerivedClassWithBaseClassField", extends=("def", base_row))
    m.add_field("serializedField", _class_sig(base_row))

    fields = _fields_of(m, "DerivedClassWithBaseClassField")
    assert [field.name for field in fields] == ["baseField", "serializedField"]


# -- CyclicalReferenceTests ---------------------------------------------------------------


def test_self_referencing_class_has_no_fields():
    """Upstream's `CyclicalReferenceClassIsHandled_D1`. **Bug found by this port** -- the field
    used to resolve against the half-built cache entry and be kept, giving a layout of infinite
    nominal depth."""
    m = _Module()
    self_row = m.add_type("SelfReferencingClass")
    m.add_field("selfReference", _class_sig(self_row))

    m2 = _Module()  # the same shape, but reached as a nested field of a MonoBehaviour
    self_row2 = m2.add_type("SelfReferencingClass")
    m2.add_field("selfReference", _class_sig(self_row2))
    m2.add_type("Behaviour", extends=("ref", m2.ref_mono_behaviour))
    m2.add_field("nested", _class_sig(self_row2))

    assert _fields_of(m, "SelfReferencingClass") == []
    nested = _fields_of(m2, "Behaviour")
    assert [field.name for field in nested] == ["nested"]
    assert nested[0].type.fields == []


@pytest.mark.parametrize("cycle_length", [2, 3, 4])
def test_cycles_of_any_length_are_handled(cycle_length):
    """Upstream's `CyclicalReferenceClassIsHandled_D2`/`_D3`/`_D4`. The fix keys off "is this
    type currently being built" rather than "is this the type I started from", so length does
    not matter -- which is what these three cases exist to prove."""
    m = _Module()
    rows = [m.add_type(f"C{index + 1}") for index in range(cycle_length)]
    # Each type's single field points at the next, and the last points back at the first. The
    # fields have to be added after all the types exist, so the signatures can reference them.
    for index, row in enumerate(rows):
        target = rows[(index + 1) % cycle_length]
        m.b.add_row(
            TableId.FIELD, flags=_PUBLIC, name=m.b.heaps.add_string("reference"),
            signature=m.b.heaps.add_blob(_class_sig(target)),
        )
    # Re-point every type's field range: TypeDef row index+2 (row 1 is `<Module>`) owns field
    # index+1. Has to happen after the fact, because a type's field range can only be known once
    # every type exists to be referenced by the field signatures.
    type_defs = m.b.rows[TableId.TYPE_DEF]
    for index in range(cycle_length):
        type_defs[index + 1]["field_list"] = index + 1

    assembly = m.read()
    for index in range(cycle_length):
        serializable = assembly.get_serializable_type("Game", f"C{index + 1}")
        assert serializable is not None
        assert serializable.fields == [], f"C{index + 1} should have no fields"


def test_a_cycle_does_not_poison_unrelated_fields_on_the_same_type():
    """The cyclic field must be dropped without taking the rest of the type with it -- the
    difference between the `NOT_SERIALIZED` and `None` paths."""
    m = _Module()
    self_row = m.add_type("Node")
    m.add_field("value", _INT_SIG)
    m.add_field("next", _class_sig(self_row))
    m.add_field("label", _STRING_SIG)

    fields = _fields_of(m, "Node")
    assert [field.name for field in fields] == ["value", "label"]
    assert fields[0].type.type == PrimitiveType.INT
    assert fields[1].type.type == PrimitiveType.STRING


# -- Not modeled: written out rather than left to be rediscovered -------------------------


@pytest.mark.xfail(
    reason="version-gated serialization is not modeled: get_serializable_type takes no Unity "
    "version, so it always behaves like a modern Unity. Upstream gates `long` at 2017, structs "
    "at 4.5, and generic instantiations at 2020.1. Affects old games only, and the failure mode "
    "is over-serializing a field an ancient Unity would have skipped.",
    strict=True,
)
def test_long_integer_serialization_started_with_unity_2017():
    """Upstream's `LongIntegerSerializationStartedWithUnity2017` (the pre-2017 half)."""
    m = _Module()
    m.add_type("ClassWithLongField", extends=("ref", m.ref_mono_behaviour))
    m.add_field("value", _LONG_SIG)

    read = m.read()
    # There is no version parameter to pass, which is the gap.
    assert read.get_serializable_type("Game", "ClassWithLongField").fields == []


@pytest.mark.xfail(
    reason="user-defined generic instantiations are unresolvable: _try_unwrap_list_generic only "
    "recognizes List<T>, so `TestGenericClass<string>` declines the whole containing type. "
    "Substituting type arguments into the generic definition's field signatures is real work "
    "(GenericInst args have to be threaded through VAR/MVAR resolution). Declines rather than "
    "mis-serializes, so it costs coverage, not correctness.",
    strict=True,
)
def test_deserialization_supports_generic_types():
    """Upstream's `DeserializationSupportsGenericTypes`."""
    m = _Module()
    generic_row = m.add_type("TestGenericClass`1")
    m.add_field("listOfT", _list_sig(m.ref_list, bytes([0x13, 0x00])))  # List<!T>
    m.add_type("Behaviour", extends=("ref", m.ref_mono_behaviour))
    m.add_field(
        "testGenericClass",
        bytes([0x06, 0x15, 0x12])
        + compress_uint(encode_type_def_or_ref(0, generic_row - 1))
        + compress_uint(1)
        + bytes([0x0E]),
    )

    fields = _fields_of(m, "Behaviour")
    assert len(fields) == 1
    assert fields[0].type.type == PrimitiveType.COMPLEX
    assert [sub.name for sub in fields[0].type.fields] == ["listOfT"]


@pytest.mark.xfail(
    reason="fixed-size buffers are not modeled: `fixed int values[4]` compiles to a field typed "
    "as a compiler-generated nested struct (`<values>e__FixedBuffer`) whose single element field "
    "carries the buffer length in metadata this port does not read, so the containing type is "
    "declined. Rare in game code, and declines rather than mis-serializes.",
    strict=True,
)
def test_deserialization_supports_structs_with_fixed_size_buffer():
    """Upstream's `DeserializationSupportsStructsWithFixedSizeBuffer`: the field comes out as an
    int array of depth 1."""
    m = _Module()
    buffer_row = m.add_type("<values>e__FixedBuffer", extends=("ref", m.ref_value_type))
    m.add_field("FixedElementField", _INT_SIG)
    m.add_type("StructWithFixedSizeBuffer", extends=("ref", m.ref_value_type))
    m.add_field("values", _value_type_sig(buffer_row))

    fields = _fields_of(m, "StructWithFixedSizeBuffer")
    assert len(fields) == 1
    assert fields[0].type.type == PrimitiveType.INT
    assert fields[0].array_depth == 1
