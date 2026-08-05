"""Phase 16b: `csharp_emitter.py` -- turns a `RecoveredType` into real `.cs` text (no
method bodies -- see that module's docstring for why not). No upstream C# file: upstream
gets `.cs` text for free from ICSharpCode.Decompiler given a real assembly; this port has
no IL decompiler, so structure (fields, base type) has to become text by hand.
"""
from assetripper_export_modules.scripts.csharp_emitter import emit
from assetripper_import.structure.assembly.recovered_model import RecoveredField, RecoveredType


def test_emits_a_monobehaviour_with_public_fields_no_namespace():
    recovered = RecoveredType(
        namespace=None,
        name="PlayerController",
        base_type_name="MonoBehaviour",
        fields=(
            RecoveredField(name="speed", type_name="float"),
            RecoveredField(name="playerName", type_name="string"),
        ),
    )
    text = emit(recovered)

    assert "using UnityEngine;" in text
    assert "public class PlayerController : MonoBehaviour" in text
    assert "\tpublic float speed;" in text
    assert "\tpublic string playerName;" in text
    # Braces balance and the class isn't wrapped in a namespace block.
    assert "namespace" not in text
    assert text.count("{") == text.count("}") == 1


def test_emits_a_namespaced_type_with_private_serialize_field():
    recovered = RecoveredType(
        namespace="MyGame.Player",
        name="Health",
        base_type_name="MonoBehaviour",
        fields=(RecoveredField(name="_current", type_name="int", is_public=False, attributes=("SerializeField",)),),
    )
    text = emit(recovered)

    assert "namespace MyGame.Player" in text
    assert "\t\t[SerializeField]" in text
    assert "\t\tprivate int _current;" in text
    assert text.count("{") == text.count("}") == 2


def test_emits_a_struct_with_no_base_type():
    recovered = RecoveredType(
        namespace=None,
        name="Payload",
        base_type_name=None,
        fields=(RecoveredField(name="amount", type_name="int"),),
        is_struct=True,
    )
    text = emit(recovered)

    assert "public struct Payload\n" in text
    assert " : " not in text.splitlines()[2]  # the header line has no base clause


def test_emits_generic_type_with_mangled_name():
    recovered = RecoveredType(
        namespace=None,
        name="Pair`2",
        fields=(RecoveredField(name="first", type_name="T1"), RecoveredField(name="second", type_name="T2")),
    )
    text = emit(recovered)

    assert "public class Pair<T1, T2>" in text
    assert "public T1 first;" in text
    assert "public T2 second;" in text


def test_emits_a_type_with_no_fields():
    recovered = RecoveredType(namespace=None, name="Marker", base_type_name="MonoBehaviour")
    text = emit(recovered)

    assert "public class Marker : MonoBehaviour" in text
    assert "{\n}" in text.replace("\n\n", "\n")


def test_multiple_attributes_on_one_field_each_get_their_own_line():
    recovered = RecoveredType(
        namespace=None,
        name="Foo",
        fields=(
            RecoveredField(
                name="bar", type_name="int", is_public=False, attributes=("SerializeField", "HideInInspector")
            ),
        ),
    )
    text = emit(recovered)

    lines = text.splitlines()
    bar_index = next(i for i, line in enumerate(lines) if "private int bar;" in line)
    assert lines[bar_index - 1].strip() == "[HideInInspector]"
    assert lines[bar_index - 2].strip() == "[SerializeField]"
