"""End-to-end tests for the AudioClip content exporter (Export phase 6c-3): raw audio
bytes are dumped verbatim with an extension chosen by container-format sniffing (see
audio_clip_decoder.py's module docstring for why no FSB5 rebuild is attempted).
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_array, vector_nodes

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)
_AUDIO_CLIP_CLASS_ID = 83

_AUDIO_CLIP_TREE = tree(
    node("AudioClip", "Base", 0),
    *string_nodes("m_Name", 1),
    *vector_nodes("m_AudioData", "UInt8", 1),
    node("int", "m_CompressionFormat", 1),
)


def _build_and_export(tmp_path, name: str, audio_bytes: bytes, compression_format: int = 0):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = _AUDIO_CLIP_CLASS_ID
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _AUDIO_CLIP_TREE

    from import_._tree_builder import unity_string

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = unity_string(name) + unity_array("B", audio_bytes) + struct.pack("<i", compression_format)

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_undecodable_fsb5_audio_is_dumped_verbatim_with_fsb_extension(tmp_path):
    """The fallback path (2026-08-03): a decodable FSB5 now becomes a real .wav/.ogg -- see
    test_audio_clip_decoder.py. This payload is truncated garbage after the magic, so it takes
    the documented raw-dump branch, which is upstream's behavior for an unsupported codec."""
    payload = b"FSB5" + b"\x00" * 60
    _build_and_export(tmp_path, "Explosion", payload)

    files = [p for p in tmp_path.rglob("*.fsb") if p.is_file()]
    assert len(files) == 1
    assert files[0].read_bytes() == payload

    meta_path = files[0].with_name(files[0].name + ".meta")
    assert meta_path.exists()


def test_tracker_module_audio_gets_matching_extension(tmp_path):
    payload = b"IMPM" + b"\x00" * 60
    _build_and_export(tmp_path, "Chiptune", payload)

    files = [p for p in tmp_path.rglob("*.it") if p.is_file()]
    assert len(files) == 1
    assert files[0].read_bytes() == payload


def test_unrecognized_audio_falls_back_to_compression_format_extension(tmp_path):
    from assetripper_export_modules.audio_compression_format import AudioCompressionFormat

    payload = b"\x01\x02\x03\x04"
    _build_and_export(tmp_path, "Beep", payload, compression_format=int(AudioCompressionFormat.AAC))

    files = [p for p in tmp_path.rglob("*.m4a") if p.is_file()]
    assert len(files) == 1
    assert files[0].read_bytes() == payload


def test_empty_audio_data_is_not_exported(tmp_path):
    _build_and_export(tmp_path, "Empty", b"")

    assert list(tmp_path.rglob("*.fsb")) == []
    assert list(tmp_path.rglob("*.it")) == []


def test_constructor_accepts_audio_export_format():
    # Phase 10: accepted for parity with upstream's constructor, but never changes output
    # here -- see audio_clip_exporter.py's module docstring for why PreferWav is
    # unreachable dead code in this port (no FSB5 rebuild, so get_export_extension never
    # returns "ogg").
    from assetripper_export_configuration.audio_export_format import AudioExportFormat
    from assetripper_export_modules.audio_clip_exporter import AudioClipExporter

    exporter = AudioClipExporter(AudioExportFormat.PREFER_WAV)
    assert exporter.audio_export_format == AudioExportFormat.PREFER_WAV
