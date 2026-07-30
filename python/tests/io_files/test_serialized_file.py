"""Port of Source/AssetRipper.IO.Files.Tests/SerializedFileTests.cs"""
import pytest

from assetripper_io_endian import EndianReader, EndianType, EndianWriter
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder, SerializedFileScheme
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_file_header import SerializedFileHeader
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.smart import SmartStream
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion

from .random_data import make_random_data

ALL_GENERATIONS = list(FormatVersion)


@pytest.mark.parametrize("generation", ALL_GENERATIONS)
def test_writing_serialized_file_does_not_throw(generation):
    builder = SerializedFileBuilder(generation=generation)
    file = builder.build()
    stream = SmartStream.create_memory()
    file.write(stream)


@pytest.mark.parametrize("generation", ALL_GENERATIONS)
def test_written_serialized_file_can_be_read(generation):
    builder = SerializedFileBuilder(generation=generation)
    file = builder.build()
    stream = SmartStream.create_memory()
    file.write(stream)
    stream.flush()
    stream.position = 0
    assert SerializedFileScheme.default().can_read(stream)


def _assert_reading_and_writing_are_consistent(original):
    stream = SmartStream.create_memory()
    original.write(stream)
    stream.flush()
    stream.position = 0
    read = SerializedFileScheme.default().read(stream, original.file_path, original.name)

    # Copy file_path and name from original to read for comparison since they are not written to the stream
    read.file_path = original.file_path
    read.name = original.name

    assert read.generation == original.generation
    assert read.version == original.version
    assert read.platform == original.platform
    assert read.endian_type == original.endian_type
    assert read.flags == original.flags
    assert list(read.dependencies) == list(original.dependencies)
    assert list(read.objects) == list(original.objects)
    assert list(read.script_types) == list(original.script_types)
    assert list(read.types) == list(original.types)
    assert list(read.ref_types) == list(original.ref_types)
    assert read.user_information == original.user_information


@pytest.mark.parametrize("generation", ALL_GENERATIONS)
def test_reading_and_writing_are_consistent(generation):
    builder = SerializedFileBuilder(generation=generation)
    original = builder.build()
    _assert_reading_and_writing_are_consistent(original)


def test_constructed_serialized_file_can_be_written_and_read_correctly():
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(6000, 1, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        endian_type=EndianType.LITTLE_ENDIAN,
        has_type_tree=False,
    )
    type_ = SerializedType()
    type_.type_id = 1
    type_.is_stripped_type = False
    type_.script_type_index = -1

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = make_random_data(100)

    builder.types.append(type_)
    builder.objects.append(obj)

    original = builder.build()
    _assert_reading_and_writing_are_consistent(original)


@pytest.mark.parametrize("generation", ALL_GENERATIONS)
def test_serialize_file_header_reading_matches_writing(generation):
    header = SerializedFileHeader(version=generation, metadata_size=256)  # arbitrary number greater than 0
    stream = MemoryStream()
    with EndianWriter(stream, EndianType.BIG_ENDIAN) as writer:
        header.write(writer)
    stream.flush()
    assert stream.position > 0
    stream.position = 0
    read_header = SerializedFileHeader()
    with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
        read_header.read(reader)

    assert stream.position == stream.length
    assert read_header == header
