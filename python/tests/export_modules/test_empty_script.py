from assetripper_export_modules.scripts.empty_script import get_content


def test_global_namespace_content():
    text = get_content(None, "MyBehaviour")
    assert text.startswith("using UnityEngine;\n\npublic class MyBehaviour : MonoBehaviour\n{\n\t/*\n")
    assert text.endswith("\t*/\n}\n")
    assert "Dummy class." in text


def test_empty_namespace_string_treated_as_global():
    assert get_content("", "Foo") == get_content(None, "Foo")


def test_namespaced_content_indents_explanation():
    text = get_content("Foo.Bar", "MyBehaviour")
    assert text.startswith("using UnityEngine;\n\nnamespace Foo.Bar\n{\n\tpublic class MyBehaviour : MonoBehaviour\n\t{\n\t\t/*\n")
    assert "\t\tDummy class." in text
    assert text.endswith("\t\t*/\n\t}\n}\n")


def test_generic_class_name_expands_type_params():
    text = get_content(None, "MyGeneric`2")
    assert "public class MyGeneric<T1, T2> : MonoBehaviour" in text


def test_non_generic_name_is_unchanged():
    text = get_content(None, "PlainClass")
    assert "public class PlainClass : MonoBehaviour" in text
