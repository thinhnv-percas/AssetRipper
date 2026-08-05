from assetripper_export_modules.scripts.mono_script_extensions import get_non_generic_class_name, is_generic


def test_is_generic_detects_mangled_name():
    assert is_generic("MyClass`2") == (True, "MyClass", 2)


def test_is_generic_non_generic_name():
    assert is_generic("MyClass") == (False, "MyClass", 0)


def test_is_generic_rejects_zero_arity():
    # The CLR never emits `0 arity, so this shouldn't match as generic.
    assert is_generic("MyClass`0") == (False, "MyClass`0", 0)


def test_get_non_generic_class_name():
    assert get_non_generic_class_name("MyClass`1") == "MyClass"
    assert get_non_generic_class_name("MyClass") == "MyClass"
