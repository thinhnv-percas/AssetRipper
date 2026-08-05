"""Phase 10: `register_default_exporters(project_exporter, settings)` actually changes which
exporter/format gets wired up, instead of always hardcoding the same defaults."""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_configuration.export_settings import ExportSettings
from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.image_export_format import ImageExportFormat
from assetripper_export_configuration.shader_export_mode import ShaderExportMode
from assetripper_export_configuration.text_export_mode import TextExportMode
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, pad_to_4, string_nodes, tree, unity_array, unity_string

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)

_TEXTURE_2D_TREE = tree(
    node("Texture2D", "Base", 0),
    node("int", "m_Width", 1),
    node("int", "m_Height", 1),
    node("int", "m_TextureFormat", 1),
    node("vector", "image data", 1),
    node("Array", "Array", 2),
    node("int", "size", 3),
    node("UInt8", "data", 3),
)
_SHADER_TREE = tree(node("Shader", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))
_TEXT_ASSET_TREE = tree(node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))


def _build_and_export(tmp_path, class_id, tree_nodes, payload, settings, file_name="sharedassets0"):
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
    register_default_exporters(exporter, settings)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_register_default_exporters_with_no_settings_matches_defaults(tmp_path):
    # ExportSettings()'s own defaults (Png/Dummy/Parse) -- same behavior as passing nothing.
    pixel_data = [255, 0, 0, 255]
    payload = struct.pack("<iii", 1, 1, 4) + pad_to_4(unity_array("B", pixel_data))
    _build_and_export(tmp_path, 28, _TEXTURE_2D_TREE, payload, None)
    assert len([p for p in tmp_path.rglob("*.png") if p.is_file()]) == 1


def test_image_export_format_jpeg_is_wired_through_settings(tmp_path):
    pixel_data = [255, 0, 0, 255]
    payload = struct.pack("<iii", 1, 1, 4) + pad_to_4(unity_array("B", pixel_data))
    settings = FullConfiguration(export_settings=ExportSettings(image_export_format=ImageExportFormat.JPEG))
    _build_and_export(tmp_path, 28, _TEXTURE_2D_TREE, payload, settings)

    assert len([p for p in tmp_path.rglob("*.png") if p.is_file()]) == 0
    jpeg_files = [p for p in tmp_path.rglob("*.jpeg") if p.is_file()]
    assert len(jpeg_files) == 1


def test_shader_export_mode_yaml_is_wired_through_settings(tmp_path):
    # "SubProgram" would normally fall back to DummyShaderTextExporter's .shader output;
    # ShaderExportMode.YAML should override that to a generic .asset YAML document instead.
    script = "Shader Data\nSubProgram\n<binary-ish placeholder>"
    payload = unity_string("MyShader") + unity_string(script)
    settings = FullConfiguration(export_settings=ExportSettings(shader_export_mode=ShaderExportMode.YAML))
    _build_and_export(tmp_path, 48, _SHADER_TREE, payload, settings)

    assert len([p for p in tmp_path.rglob("*.shader") if p.is_file()]) == 0
    assert len([p for p in tmp_path.rglob("*.asset") if p.is_file()]) == 1


def test_text_export_mode_bytes_forces_bytes_extension(tmp_path):
    # Plain text would normally guess ".txt"; TextExportMode.BYTES should force ".bytes".
    payload = unity_string("Readme") + unity_string("hello, this is plain text")
    settings = FullConfiguration(export_settings=ExportSettings(text_export_mode=TextExportMode.BYTES))
    _build_and_export(tmp_path, 49, _TEXT_ASSET_TREE, payload, settings)

    assert len([p for p in tmp_path.rglob("*.txt") if p.is_file()]) == 0
    assert len([p for p in tmp_path.rglob("*.bytes") if p.is_file()]) == 1
