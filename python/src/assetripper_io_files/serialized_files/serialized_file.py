"""
Port of Source/AssetRipper.IO.Files/SerializedFiles/SerializedFile.cs

Serialized files contain binary serialized objects and optional run-time type
information. They have file name extensions like .asset, .assets, .sharedAssets but may
also have no extension at all.
"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianType, EndianWriter
from assetripper_primitives import UnityVersion

from ..build_target import BuildTarget
from ..file_base import FileBase
from ..special_file_names import is_builtin_extra, is_engine_resource
from ..streams.smart import SmartStream
from ..streams.stream import Stream
from .format_version import FormatVersion
from .parser.serialized_file_header import SerializedFileHeader
from .parser.serialized_file_metadata import SerializedFileMetadata, is_metadata_at_the_end
from .parser.serialized_file_metadata import has_platform as _metadata_has_platform
from .transfer_instruction_flags import TransferInstructionFlags


class SerializedFile(FileBase):
    def __init__(self):
        super().__init__()
        self.generation: FormatVersion = FormatVersion.UNSUPPORTED
        self.version: UnityVersion = UnityVersion()
        self.platform: BuildTarget = BuildTarget.NO_TARGET
        self.endian_type: EndianType = EndianType.LITTLE_ENDIAN
        self._dependencies: list = []
        self._objects: list = []
        self._types: list = []
        self._script_types: list = []
        self._ref_types: list = []
        self.has_type_tree: bool = False
        self.user_information: str = ""

    @property
    def flags(self) -> TransferInstructionFlags:
        if _metadata_has_platform(self.generation) and self.platform == BuildTarget.NO_TARGET:
            if self.file_path.endswith(".unity"):
                result = TransferInstructionFlags.SERIALIZE_EDITOR_MINIMAL_SCENE
            else:
                result = TransferInstructionFlags.NO_TRANSFER_INSTRUCTION_FLAGS
        else:
            result = TransferInstructionFlags.SERIALIZE_GAME_RELEASE

        if is_engine_resource(self.name) or (self.generation < FormatVersion.UNKNOWN_10 and is_builtin_extra(self.name)):
            result |= TransferInstructionFlags.IS_BUILTIN_RESOURCES_FILE
        if self.endian_type == EndianType.BIG_ENDIAN:
            result |= TransferInstructionFlags.SWAP_ENDIANESS
        return result

    @property
    def dependencies(self) -> list:
        return self._dependencies

    @property
    def objects(self) -> list:
        return self._objects

    @property
    def types(self) -> list:
        return self._types

    @property
    def script_types(self) -> list:
        return self._script_types

    @property
    def ref_types(self) -> list:
        return self._ref_types

    @staticmethod
    def _get_endian_type(header: SerializedFileHeader, metadata: SerializedFileMetadata) -> EndianType:
        from .parser.serialized_file_header import has_endianess

        swap_endianess = header.endianess if has_endianess(header.version) else metadata.swap_endianess
        return EndianType.BIG_ENDIAN if swap_endianess else EndianType.LITTLE_ENDIAN

    @staticmethod
    def is_serialized_file(stream: Stream) -> bool:
        with EndianReader(stream, EndianType.BIG_ENDIAN) as reader:
            return SerializedFileHeader.is_serialized_file_header(reader, stream.length)

    @staticmethod
    def is_serialized_file_path(file_path: str, file_system) -> bool:
        with file_system.file.open_read(file_path) as stream:
            return SerializedFile.is_serialized_file(stream)

    def __str__(self) -> str:
        return self.name_fixed

    def read(self, stream: SmartStream) -> None:
        header = SerializedFileHeader()
        header.read(stream)
        if is_metadata_at_the_end(header.version):
            stream.position = header.file_size - header.metadata_size
        metadata = SerializedFileMetadata()
        metadata.read(stream, header)

        self._set_properties(header, metadata)

    def _set_properties(self, header: SerializedFileHeader, metadata: SerializedFileMetadata) -> None:
        self.generation = header.version
        self.version = metadata.unity_version
        self.platform = metadata.target_platform
        self.endian_type = self._get_endian_type(header, metadata)
        self._dependencies = metadata.externals
        self._objects = metadata.object
        self._types = metadata.types
        self._script_types = metadata.script_types
        self._ref_types = metadata.ref_types
        self.has_type_tree = metadata.enable_type_tree
        self.user_information = metadata.user_information

    def write(self, stream: Stream) -> None:
        initial_position = stream.position
        header = SerializedFileHeader(
            version=self.generation,
            endianess=self.endian_type == EndianType.BIG_ENDIAN,
        )
        header.write(stream)

        with self._make_writer(stream) as writer:
            metadata = SerializedFileMetadata(
                unity_version=self.version,
                target_platform=self.platform,
                externals=self._dependencies,
                object=self._objects,
                types=self._types,
                script_types=self._script_types,
                ref_types=self._ref_types,
                enable_type_tree=self.has_type_tree,
                user_information=self.user_information,
            )
            if is_metadata_at_the_end(self.generation):
                _align_stream(writer, 16)  # object data position must be aligned to 16 bytes
                object_data_position = stream.position
                _write_object_data(writer, metadata.object)
                metadata_position = stream.position
                metadata.write(writer)
                metadata_size = stream.position - metadata_position
            else:
                metadata_position = stream.position
                metadata.write(writer)
                metadata_size = stream.position - metadata_position
                _align_stream(writer, 16)
                object_data_position = stream.position
                _write_object_data(writer, metadata.object)

        final_position = stream.position

        stream.position = initial_position
        header.file_size = final_position - initial_position
        header.metadata_size = metadata_size
        header.data_offset = object_data_position - initial_position
        with EndianWriter(stream, EndianType.BIG_ENDIAN, leave_open=True) as header_writer:
            header.write(header_writer)

        stream.position = final_position

    def _make_writer(self, stream: Stream):
        from .io.serialized_writer import SerializedWriter

        return SerializedWriter(stream, self.endian_type, self.generation, self.version)

    @staticmethod
    def from_file(file_path: str, file_system) -> "SerializedFile":
        from .serialized_file_scheme import SerializedFileScheme

        file_name = file_system.path.get_file_name(file_path)
        stream = SmartStream.open_read(file_path, file_system)
        return SerializedFileScheme.default().read(stream, file_path, file_name)

    @staticmethod
    def from_builder(builder) -> "SerializedFile":
        file = SerializedFile()
        file.generation = builder.generation
        file.version = builder.version
        file.platform = builder.platform
        file.endian_type = builder.endian_type
        file._dependencies = list(builder.dependencies)
        file._objects = list(builder.objects)
        file._types = list(builder.types)
        file._script_types = list(builder.script_types)
        file._ref_types = list(builder.ref_types)
        file.has_type_tree = builder.has_type_tree
        file.user_information = builder.user_information
        return file


def _write_object_data(writer, objects) -> None:
    for object_info in objects:
        if object_info.object_data is not None:
            writer.write_bytes(object_info.object_data)
        _align_stream(writer, 8)  # each object data must be aligned to 8 bytes


def _align_stream(writer, alignment: int) -> None:
    bytes_since_last_alignment = writer.base_stream.position & (alignment - 1)
    if bytes_since_last_alignment != 0:
        padding = alignment - bytes_since_last_alignment
        writer.write_bytes(bytes(padding))
