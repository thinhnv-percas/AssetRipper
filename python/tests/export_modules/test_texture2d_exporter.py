"""End-to-end test for the Texture2D content exporter (Export phase 6b): a dynamic-reader-
read Texture2D with embedded RGBA32 pixel data exports as a real PNG file with matching
pixel values.
"""
import io
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
from PIL import Image

from import_._tree_builder import node, pad_to_4, tree, unity_array

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)

# Texture2D (class 28): m_Width, m_Height, m_TextureFormat, "image data" (vector<UInt8>).
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


def _build_and_export(tmp_path, width, height, texture_format, pixel_data):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = 28
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _TEXTURE_2D_TREE

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = (
        struct.pack("<iii", width, height, texture_format) + pad_to_4(unity_array("B", pixel_data))
    )

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_texture2d_exports_as_png_with_correct_pixels(tmp_path):
    # 2x1 RGBA32 texture: red pixel, green pixel.
    pixel_data = [255, 0, 0, 255, 0, 255, 0, 255]
    _build_and_export(tmp_path, 2, 1, 4, pixel_data)  # 4 == TextureFormat.RGBA32

    png_files = [p for p in tmp_path.rglob("*.png") if p.is_file()]
    assert len(png_files) == 1

    image = Image.open(io.BytesIO(png_files[0].read_bytes()))
    assert image.size == (2, 1)
    assert image.convert("RGBA").getpixel((0, 0)) == (255, 0, 0, 255)
    assert image.convert("RGBA").getpixel((1, 0)) == (0, 255, 0, 255)


def test_texture2d_with_unsupported_format_is_not_exported(tmp_path):
    _build_and_export(tmp_path, 2, 1, 9999, [0] * 8)

    png_files = [p for p in tmp_path.rglob("*.png") if p.is_file()]
    assert len(png_files) == 0
