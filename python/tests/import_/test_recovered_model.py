"""Phase 16b: `RecoveredField`/`RecoveredType` -- the neutral model between script backend
readers (16c Mono / 16d-e IL2CPP) and `csharp_emitter.py`. No upstream C# file: this is a
port-original abstraction, not a port (see that module's docstring for why).
"""
from assetripper_import.structure.assembly.recovered_model import RecoveredField, RecoveredType


def test_recovered_field_defaults_are_public_with_no_attributes():
    f = RecoveredField(name="speed", type_name="float")
    assert f.is_public is True
    assert f.attributes == ()


def test_recovered_type_defaults_have_no_base_no_fields_and_is_a_class():
    t = RecoveredType(namespace="MyGame", name="Foo")
    assert t.base_type_name is None
    assert t.fields == ()
    assert t.is_struct is False


def test_recovered_types_are_frozen_and_hashable():
    t = RecoveredType(namespace=None, name="Foo", fields=(RecoveredField(name="x", type_name="int"),))
    assert hash(t) == hash(t)  # frozen dataclasses are hashable
    try:
        t.name = "Bar"
        assert False, "expected FrozenInstanceError"
    except AttributeError:
        pass
