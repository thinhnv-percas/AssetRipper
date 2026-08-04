"""
Tests for `assetripper_primitives.UnityGuid` (see test_unity_version.py's docstring on why this
directory was empty until 2026-08-03).

`md5_hash` gets the most attention: it is what makes every exported script's `.meta` GUID
*stable* across runs, which is what lets a re-export keep the same asset identities and not
break every reference in an already-open Unity project. A change in its byte ordering would be
invisible in a single run and only show up as "all my script references broke" on the second.
"""
import pytest

from assetripper_primitives import UnityGuid


def test_default_guid_is_zero():
    assert UnityGuid().is_zero
    assert UnityGuid.ZERO.is_zero


def test_a_nonzero_guid_is_not_reported_as_zero():
    assert not UnityGuid(1, 0, 0, 0).is_zero
    assert not UnityGuid(0, 0, 0, 1).is_zero


def test_from_bytes_round_trips_through_to_bytes():
    data = bytes(range(16))
    assert UnityGuid.from_bytes(data).to_bytes() == data


def test_from_bytes_reads_four_little_endian_words():
    guid = UnityGuid.from_bytes(bytes([1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0]))
    assert (guid.data0, guid.data1, guid.data2, guid.data3) == (1, 2, 3, 4)


@pytest.mark.parametrize("length", [0, 15, 17, 32])
def test_from_bytes_rejects_anything_but_sixteen_bytes(length):
    with pytest.raises(ValueError):
        UnityGuid.from_bytes(b"\x00" * length)


def test_str_is_the_lowercase_hex_of_the_bytes():
    guid = UnityGuid.from_bytes(bytes(range(16)))
    assert str(guid) == "000102030405060708090a0b0c0d0e0f"


def test_parse_round_trips_through_str():
    text = "0123456789abcdef0123456789abcdef"
    assert str(UnityGuid.parse(text)) == text


def test_parse_is_the_inverse_of_str_for_a_random_guid():
    guid = UnityGuid.new_guid()
    assert UnityGuid.parse(str(guid)) == guid


def test_new_guid_is_random_and_nonzero():
    guids = {UnityGuid.new_guid() for _ in range(16)}
    assert len(guids) == 16, "new_guid must not repeat"
    assert all(not guid.is_zero for guid in guids)


def test_equality_is_by_value_not_identity():
    assert UnityGuid(1, 2, 3, 4) == UnityGuid(1, 2, 3, 4)
    assert UnityGuid(1, 2, 3, 4) != UnityGuid(1, 2, 3, 5)


def test_guid_is_hashable_so_it_can_key_a_dict():
    """Export collections key assets by GUID, so this has to hold."""
    mapping = {UnityGuid(1, 2, 3, 4): "asset"}
    assert mapping[UnityGuid(1, 2, 3, 4)] == "asset"


# --- md5_hash: the stable-GUID contract -----------------------------------------------------


def test_md5_hash_is_deterministic_across_calls():
    first = UnityGuid.md5_hash(b"Assembly-CSharp", b"MyGame", b"PlayerController")
    second = UnityGuid.md5_hash(b"Assembly-CSharp", b"MyGame", b"PlayerController")
    assert first == second


def test_md5_hash_matches_the_md5_digest_read_as_four_little_endian_words():
    """Pins the exact byte interpretation, not just "it's stable" -- a change here silently
    renumbers every exported script's .meta GUID."""
    import hashlib

    parts = (b"Assembly-CSharp", b"MyGame", b"PlayerController")
    expected = UnityGuid.from_bytes(hashlib.md5(b"".join(parts)).digest())
    assert UnityGuid.md5_hash(*parts) == expected


def test_md5_hash_differs_for_different_inputs():
    a = UnityGuid.md5_hash(b"Assembly-CSharp", b"MyGame", b"PlayerController")
    b = UnityGuid.md5_hash(b"Assembly-CSharp", b"MyGame", b"EnemyAI")
    assert a != b


def test_md5_hash_concatenates_parts_so_boundaries_are_not_significant():
    """Documents a real (upstream-inherited) property rather than asserting a nicer one: the
    parts are joined with no separator, so ("ab", "c") and ("a", "bc") collide. Callers avoid
    this by construction (assembly/namespace/class are distinct fields), but anyone adding a new
    call site should know the boundaries carry no information."""
    assert UnityGuid.md5_hash(b"ab", b"c") == UnityGuid.md5_hash(b"a", b"bc")


def test_md5_hash_of_no_parts_is_the_md5_of_empty_input():
    import hashlib

    assert UnityGuid.md5_hash() == UnityGuid.from_bytes(hashlib.md5(b"").digest())
