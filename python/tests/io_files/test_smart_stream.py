"""Port of Source/AssetRipper.IO.Files.Tests/SmartStreamTests.cs"""
import pytest

from assetripper_io_files.streams.smart import SmartStream, SmartStreamType

from .random_data import make_random_data


def test_streams_have_the_correct_stream_type():
    assert SmartStream.create_null().stream_type == SmartStreamType.NULL
    assert SmartStream.create_temp().stream_type == SmartStreamType.FILE
    assert SmartStream.create_memory().stream_type == SmartStreamType.MEMORY


def test_memory_stream_maintain_their_length():
    length = 64
    memory_stream = SmartStream.create_memory(bytes(length))
    assert memory_stream.length == length


def test_to_array_makes_a_perfect_copy_for_memory_smart_streams():
    length = 87
    random_data = make_random_data(length)
    memory_stream = SmartStream.create_memory(random_data)
    assert memory_stream.to_array() == random_data


def test_freed_streams_must_be_null():
    stream = SmartStream.create_memory()
    assert stream.ref_count == 1
    assert not stream.is_null
    assert stream.stream_type == SmartStreamType.MEMORY

    stream.free_reference()
    assert stream.ref_count == 0
    assert stream.is_null
    assert stream.stream_type == SmartStreamType.NULL


def test_null_stream_is_null_and_has_ref_count_zero():
    assert SmartStream.create_null().ref_count == 0
    assert SmartStream.create_null().is_null


def test_disposed_stream_throws_for_many_members():
    SmartStream.create_null().flush()
    _ = SmartStream.create_null().can_read
    _ = SmartStream.create_null().can_seek
    _ = SmartStream.create_null().can_write
    _ = SmartStream.create_null().position
    _ = SmartStream.create_null().length
    _ = SmartStream.create_null().ref_count
    _ = SmartStream.create_null().is_null
    _ = SmartStream.create_null().stream_type

    # Count should match up with the number of references to _throw_if_null
    with pytest.raises(ReferenceError):
        SmartStream.create_null().read_exactly(bytearray(2), 1, 1)
    with pytest.raises(ReferenceError):
        SmartStream.create_null().read_exactly(bytearray(2))
    with pytest.raises(ReferenceError):
        SmartStream.create_null().read_byte()
    with pytest.raises(ReferenceError):
        from assetripper_io_files.streams.stream import SeekOrigin
        SmartStream.create_null().seek(0, SeekOrigin.BEGIN)
    with pytest.raises(ReferenceError):
        SmartStream.create_null().set_length(2)
    with pytest.raises(ReferenceError):
        SmartStream.create_null().write(bytearray(2), 1, 1)
    with pytest.raises(ReferenceError):
        SmartStream.create_null().position = 0
    with pytest.raises(ReferenceError):
        SmartStream.create_null().to_array()
