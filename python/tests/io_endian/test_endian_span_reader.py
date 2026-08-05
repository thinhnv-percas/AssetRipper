"""
Tests for `assetripper_io_endian.endian_span_reader.EndianSpanReader`.

This directory sat **empty** from Phase 1 until 2026-08-03, tracked as a known gap in
ROADMAP.md's "Việc lẻ" list. `EndianSpanReader` is the single lowest-level primitive the whole
dynamic reader stands on -- every asset field, in every layout, in every phase, is ultimately
one of these calls -- yet it had no tests of its own. It was only ever exercised *indirectly*
through higher-level tests, which means an endianness or alignment bug here would have surfaced
as a confusing failure several layers up (exactly the "alignment/offset is the number one source
of silent bugs" risk ROADMAP.md's risk list calls out).

Both endiannesses are covered for every multi-byte type, because a big-endian read path that is
never tested is a real risk for this port: Unity ships big-endian SerializedFiles for some
console targets, and only `read_*` sees that difference.
"""
import struct

import pytest

from assetripper_io_endian.endian_span_reader import EndianSpanReader
from assetripper_io_endian.endian_type import EndianType


def _le(data: bytes) -> EndianSpanReader:
    return EndianSpanReader(data, EndianType.LITTLE_ENDIAN)


def _be(data: bytes) -> EndianSpanReader:
    return EndianSpanReader(data, EndianType.BIG_ENDIAN)


# --- position / length / remaining ----------------------------------------------------------


def test_position_starts_at_zero_and_advances_by_the_bytes_read():
    reader = _le(b"\x01\x02\x03\x04\x05\x06\x07\x08")
    assert reader.position == 0
    assert reader.length == 8
    assert reader.remaining == 8

    reader.read_int32()
    assert reader.position == 4
    assert reader.remaining == 4


def test_position_is_settable_for_seeking():
    reader = _le(struct.pack("<ii", 11, 22))
    reader.position = 4
    assert reader.read_int32() == 22
    reader.position = 0
    assert reader.read_int32() == 11


def test_offset_is_an_initial_absolute_position_not_a_window_base():
    """Documents the actual semantics, which are easy to get backwards: `offset` seeds
    `position` in the *underlying* buffer's coordinates rather than re-basing the reader onto a
    sub-window. So `position` starts at `offset` (not 0) and `length`/`remaining` still measure
    the whole buffer -- `remaining` is therefore `len(data) - offset`."""
    data = b"\xff\xff" + struct.pack("<i", 7)
    reader = EndianSpanReader(data, EndianType.LITTLE_ENDIAN, offset=2)

    assert reader.position == 2
    assert reader.length == len(data)
    assert reader.remaining == len(data) - 2
    assert reader.read_int32() == 7


# --- single-byte types (endian-independent) -------------------------------------------------


def test_read_boolean_treats_any_nonzero_as_true():
    reader = _le(b"\x00\x01\x02\xff")
    assert reader.read_boolean() is False
    assert reader.read_boolean() is True
    assert reader.read_boolean() is True
    assert reader.read_boolean() is True


def test_read_byte_and_sbyte_differ_only_in_signedness():
    assert _le(b"\xff").read_byte() == 255
    assert _le(b"\xff").read_sbyte() == -1
    assert _le(b"\x80").read_byte() == 128
    assert _le(b"\x80").read_sbyte() == -128


# --- multi-byte integers, both endiannesses -------------------------------------------------


@pytest.mark.parametrize(
    ("method", "fmt", "value"),
    [
        ("read_int16", "h", -12345),
        ("read_uint16", "H", 54321),
        ("read_int32", "i", -1234567),
        ("read_uint32", "I", 4000000000),
        ("read_int64", "q", -1234567890123),
        ("read_uint64", "Q", 18000000000000000000),
    ],
)
def test_integer_reads_respect_endianness(method, fmt, value):
    assert getattr(_le(struct.pack("<" + fmt, value)), method)() == value
    assert getattr(_be(struct.pack(">" + fmt, value)), method)() == value


@pytest.mark.parametrize(("method", "fmt", "value"), [("read_single", "f", 1.5), ("read_double", "d", -2.25)])
def test_float_reads_respect_endianness(method, fmt, value):
    assert getattr(_le(struct.pack("<" + fmt, value)), method)() == value
    assert getattr(_be(struct.pack(">" + fmt, value)), method)() == value


def test_the_same_bytes_read_as_different_endianness_give_different_values():
    """Guards the case a single-endianness test suite would miss entirely: a reader that
    ignored its endian setting would pass every little-endian test above."""
    data = b"\x00\x00\x00\x01"
    assert _le(data).read_int32() == 0x01000000
    assert _be(data).read_int32() == 0x00000001


# --- strings, bulk reads, alignment ---------------------------------------------------------


def test_read_bytes_returns_exactly_the_requested_count():
    reader = _le(b"abcdef")
    assert reader.read_bytes(4) == b"abcd"
    assert reader.position == 4


def test_read_utf8_string_reads_a_length_prefixed_string():
    payload = "hé".encode("utf-8")
    reader = _le(struct.pack("<i", len(payload)) + payload)
    assert reader.read_utf8_string() == "hé"


def test_read_utf8_string_handles_the_empty_string():
    reader = _le(struct.pack("<i", 0))
    assert reader.read_utf8_string() == ""


def test_align_advances_to_the_next_boundary_and_is_a_noop_when_already_aligned():
    reader = _le(b"\x00" * 16)
    reader.read_byte()
    reader.align()
    assert reader.position == 4

    reader.align()  # already on a boundary
    assert reader.position == 4

    reader.read_bytes(4)
    reader.align()
    assert reader.position == 8


def test_align_supports_a_non_default_alignment():
    reader = _le(b"\x00" * 32)
    reader.read_byte()
    reader.align(16)
    assert reader.position == 16


def test_read_primitive_bulk_matches_repeated_scalar_reads():
    values = (1, -2, 3, -4)
    data = struct.pack("<4i", *values)
    assert _le(data).read_primitive_bulk("i", 4) == values

    big = struct.pack(">4i", *values)
    assert _be(big).read_primitive_bulk("i", 4) == values


def test_read_primitive_bulk_of_zero_elements_reads_nothing():
    reader = _le(b"\x01\x02\x03\x04")
    assert reader.read_primitive_bulk("i", 0) == ()
    assert reader.position == 0


# --- overruns must raise, not return garbage -----------------------------------------------


def test_reading_past_the_end_raises():
    reader = _le(b"\x01\x02")
    with pytest.raises(Exception):
        reader.read_int32()


def test_read_bytes_past_the_end_raises():
    reader = _le(b"\x01\x02")
    with pytest.raises(Exception):
        reader.read_bytes(8)
