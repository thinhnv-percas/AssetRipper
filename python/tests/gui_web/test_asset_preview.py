"""Phase 11: `/Assets/Image`, `/Assets/Text`, `/Assets/Yaml`, `/Assets/Binary` render a
single asset by running it through the real export pipeline (asset_preview.render_asset)
and serving the resulting bytes -- not a reimplementation of texture decoding/etc. here.
"""
from __future__ import annotations

import json
import struct

import pytest
from assetripper_gui_web import create_app, game_file_loader
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, pad_to_4, string_nodes, tree, unity_array

_TEXT_ASSET_TREE = tree(node("TextAsset", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))
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


@pytest.fixture(autouse=True)
def _reset_game_file_loader():
    game_file_loader.reset()
    yield
    game_file_loader.reset()


@pytest.fixture
def client():
    app = create_app()
    app.testing = True
    return app.test_client()


def _string_payload(name: str, script: str) -> bytes:
    from import_._tree_builder import unity_string

    return unity_string(name) + unity_string(script)


def _write_sample_file(path) -> None:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2019, 4, 0),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )

    text_type = SerializedType()
    text_type.type_id = 49
    text_type.is_stripped_type = False
    text_type.script_type_index = -1
    text_type.old_type = _TEXT_ASSET_TREE
    text_type.old_type.build_string_buffer()
    text_obj = ObjectInfo(text_type)
    text_obj.file_id = 1
    text_obj.serialized_type_index = 0
    text_obj.object_data = _string_payload("MyText", "hello world")

    texture_type = SerializedType()
    texture_type.type_id = 28
    texture_type.is_stripped_type = False
    texture_type.script_type_index = -1
    texture_type.old_type = _TEXTURE_2D_TREE
    texture_type.old_type.build_string_buffer()
    texture_obj = ObjectInfo(texture_type)
    texture_obj.file_id = 2
    texture_obj.serialized_type_index = 1
    pixel_data = [255, 0, 0, 255]
    texture_obj.object_data = struct.pack("<iii", 1, 1, 4) + pad_to_4(unity_array("B", pixel_data))

    builder.types.append(text_type)
    builder.types.append(texture_type)
    builder.objects.append(text_obj)
    builder.objects.append(texture_obj)
    serialized_file = builder.build()

    stream = MemoryStream()
    serialized_file.write(stream)
    path.write_bytes(stream.to_array())


def _asset_path(path_id: int) -> str:
    return json.dumps({"C": {"B": {"P": []}, "I": 0}, "D": path_id})


def test_text_asset_renders_through_text_endpoint(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    client.post("/LoadFile", data={"Path": str(sample)})

    response = client.get(f"/Assets/Text?Path={_asset_path(1)}")

    assert response.status_code == 200
    assert response.data == b"hello world"
    assert response.mimetype == "text/plain"


def test_texture2d_renders_through_image_endpoint(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    client.post("/LoadFile", data={"Path": str(sample)})

    response = client.get(f"/Assets/Image?Path={_asset_path(2)}")

    assert response.status_code == 200
    assert response.mimetype == "image/png"
    assert response.data[:8] == b"\x89PNG\r\n\x1a\n"


def test_text_asset_404s_on_image_endpoint(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    client.post("/LoadFile", data={"Path": str(sample)})

    response = client.get(f"/Assets/Image?Path={_asset_path(1)}")

    assert response.status_code == 404


def test_texture2d_renders_through_binary_endpoint_as_attachment(client, tmp_path):
    sample = tmp_path / "sample.assets"
    _write_sample_file(sample)
    client.post("/LoadFile", data={"Path": str(sample)})

    response = client.get(f"/Assets/Binary?Path={_asset_path(2)}")

    assert response.status_code == 200
    assert "attachment" in response.headers["Content-Disposition"]


def test_asset_endpoints_404_without_loaded_files(client):
    response = client.get(f"/Assets/Text?Path={_asset_path(1)}")
    assert response.status_code == 404
