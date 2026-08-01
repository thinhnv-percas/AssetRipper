"""Phase 13a: `Miscellaneous/{VideoClipExporter,VideoClipExportCollection}.cs` port --
VideoClip (class 329) keeps its video bytes external (`m_ExternalResources`, the same
StreamingInfo shape Texture2D/Mesh use, see test_streamed_data_export.py), so this reuses
Phase 9's streamed-resource resolver. Extension comes from `m_OriginalPath`.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.resource_files.resource_file import ResourceFile
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)

# VideoClip (class 329): m_Name, m_OriginalPath, m_ExternalResources {offset, size, path}.
_VIDEO_CLIP_TREE = tree(
    node("VideoClip", "Base", 0),
    *string_nodes("m_Name", 1),
    *string_nodes("m_OriginalPath", 1),
    node("StreamingInfo", "m_ExternalResources", 1),
    node("unsigned int", "offset", 2),
    node("unsigned int", "size", 2),
    *string_nodes("path", 2),
)


def _build_bundle(class_id: int, payload: bytes) -> GameBundle:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = class_id
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _VIDEO_CLIP_TREE

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle


def _export(game_bundle, tmp_path):
    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_video_clip_exports_external_resource_bytes_with_original_extension(tmp_path):
    video_bytes = b"\x00\x00\x00\x18ftypmp42" + b"\x00" * 20
    resource_bytes = b"leading-junk" + video_bytes
    offset = len(b"leading-junk")

    payload = (
        unity_string("Explosion")
        + unity_string("Assets/Videos/Explosion.mp4")
        + struct.pack("<II", offset, len(video_bytes))
        + unity_string("CAB-video.resS")
    )
    class_id = 329
    game_bundle = _build_bundle(class_id, payload)
    game_bundle.add_resource(ResourceFile.from_bytes(resource_bytes, "/does/not/matter", "CAB-video.resS"))

    _export(game_bundle, tmp_path)

    mp4_files = [p for p in tmp_path.rglob("*.mp4") if p.is_file()]
    assert len(mp4_files) == 1
    assert mp4_files[0].name == "Explosion.mp4"
    assert mp4_files[0].read_bytes() == video_bytes
    assert mp4_files[0].with_name(mp4_files[0].name + ".meta").exists()


def test_video_clip_falls_back_to_bytes_extension_when_original_path_has_none(tmp_path):
    video_bytes = b"videodata" * 4
    payload = (
        unity_string("NoExtension")
        + unity_string("Assets/Videos/NoExtension")
        + struct.pack("<II", 0, len(video_bytes))
        + unity_string("CAB-video2.resS")
    )
    game_bundle = _build_bundle(329, payload)
    game_bundle.add_resource(ResourceFile.from_bytes(video_bytes, "/does/not/matter", "CAB-video2.resS"))

    _export(game_bundle, tmp_path)

    bytes_files = [p for p in tmp_path.rglob("*.bytes") if p.is_file()]
    assert len(bytes_files) == 1
    assert bytes_files[0].read_bytes() == video_bytes


def test_video_clip_with_no_resolvable_resource_is_not_exported(tmp_path):
    payload = (
        unity_string("Missing")
        + unity_string("Assets/Videos/Missing.mp4")
        + struct.pack("<II", 0, 16)
        + unity_string("missing.resS")
    )
    game_bundle = _build_bundle(329, payload)
    # No ResourceFile added -- resolve_resource will fail.

    _export(game_bundle, tmp_path)

    assert [p for p in tmp_path.rglob("*.mp4") if p.is_file()] == []
