from assetripper_export_modules.scripts import script_hashing
from assetripper_primitives import UnityGuid


def test_calculate_script_file_id_is_deterministic():
    a = script_hashing.calculate_script_file_id("Foo", "Bar")
    b = script_hashing.calculate_script_file_id("Foo", "Bar")
    assert a == b


def test_calculate_script_file_id_differs_for_different_input():
    a = script_hashing.calculate_script_file_id("Foo", "Bar")
    b = script_hashing.calculate_script_file_id("Foo", "Baz")
    assert a != b


def test_calculate_script_file_id_returns_a_signed_32_bit_int():
    value = script_hashing.calculate_script_file_id("Some.Namespace", "SomeClassNameLongEnoughToFlipTheSignBit")
    assert -(2**31) <= value < 2**31


def test_calculate_script_guid_is_deterministic_and_md5_based():
    guid = script_hashing.calculate_script_guid("Assembly-CSharp", "Foo", "Bar")
    assert isinstance(guid, UnityGuid)
    assert guid == script_hashing.calculate_script_guid("Assembly-CSharp", "Foo", "Bar")
    assert guid == UnityGuid.md5_hash(b"Assembly-CSharp", b"Foo", b"Bar")


def test_calculate_script_guid_differs_per_component():
    a = script_hashing.calculate_script_guid("Assembly-CSharp", "Foo", "Bar")
    b = script_hashing.calculate_script_guid("Assembly-CSharp", "Foo", "Baz")
    assert a != b


def test_calculate_assembly_guid_strips_dll_extension():
    assert script_hashing.calculate_assembly_guid("Foo.dll") == script_hashing.calculate_assembly_guid("Foo")


def test_calculate_assembly_guid_matches_md5_hash_directly():
    assert script_hashing.calculate_assembly_guid("Foo") == UnityGuid.md5_hash(b"Foo")
