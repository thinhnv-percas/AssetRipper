"""End-to-end tests for the byte-passthrough content exporters
(Source/AssetRipper.Export.UnityProjects/Miscellaneous/*.cs port, Export phase 6): each
verifies raw content is written (not a YAML asset document) with the right extension and a
matching .meta file, driven through the real dynamic reader.
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.font_asset_exporter import get_font_extension
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, pad_to_4, string_nodes, tree, unity_array, unity_string, vector_nodes

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)

_TEXT_ASSET_TREE = tree(node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))
_MOVIE_TEXTURE_TREE = tree(node("MovieTexture", "Base", 0), *vector_nodes("m_MovieData", "UInt8", 1))
_FONT_TREE = tree(node("Font", "Base", 0), *vector_nodes("m_FontData", "UInt8", 1))


def _build_and_export(tmp_path, class_id: int, tree_nodes, payload: bytes, file_name="ProjectSettings"):
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
    type_.old_type = tree_nodes

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = payload

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = file_name

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def _find_file(tmp_path, suffix: str):
    matches = [p for p in tmp_path.rglob(f"*{suffix}") if p.is_file()]
    assert len(matches) == 1, f"expected exactly one {suffix} file, found {matches}"
    return matches[0]


def test_text_asset_exports_raw_json_content(tmp_path):
    payload = unity_string("Config") + unity_string('{"level": 1}')
    _build_and_export(tmp_path, 49, _TEXT_ASSET_TREE, payload)

    asset_path = _find_file(tmp_path, ".json")
    assert asset_path.read_text(encoding="utf-8") == '{"level": 1}'

    meta_path = tmp_path / (str(asset_path.relative_to(tmp_path)) + ".meta")
    meta_text = meta_path.read_text(encoding="utf-8")
    assert "TextScriptImporter:" in meta_text
    assert "mainObjectFileID" not in meta_text


def test_text_asset_plain_text_gets_txt_extension(tmp_path):
    payload = unity_string("Readme") + unity_string("hello, this is plain text")
    _build_and_export(tmp_path, 49, _TEXT_ASSET_TREE, payload)

    asset_path = _find_file(tmp_path, ".txt")
    assert asset_path.read_text(encoding="utf-8") == "hello, this is plain text"


def test_movie_texture_exports_raw_bytes_with_ogv_extension(tmp_path):
    movie_bytes = [0x01, 0x02, 0x03, 0x04]
    payload = pad_to_4(unity_array("B", movie_bytes))
    _build_and_export(tmp_path, 152, _MOVIE_TEXTURE_TREE, payload)

    asset_path = _find_file(tmp_path, ".ogv")
    assert asset_path.read_bytes() == bytes(movie_bytes)


def test_font_exports_raw_bytes_with_sniffed_extension(tmp_path):
    font_bytes = list(b"OTTO" + b"\x00" * 12)
    payload = pad_to_4(unity_array("B", font_bytes))
    _build_and_export(tmp_path, 128, _FONT_TREE, payload)

    asset_path = _find_file(tmp_path, ".otf")
    assert asset_path.read_bytes() == bytes(font_bytes)


def test_get_font_extension_sniffs_otto_magic():
    assert get_font_extension(b"OTTO" + b"\x00" * 4) == "otf"
    assert get_font_extension(b"\x00\x01\x00\x00" + b"\x00" * 4) == "ttf"
