"""End-to-end test for Phase 14: a synthetic "fake WebGL build" byte layout --
a SerializedFile packed into a WebFile ("UnityWebData1.0"), itself gzip-compressed (the
`.data.gz` shape a real WebGL build's `<Product>.data.gz` takes) -- read back through
`scheme_reader.read_file` + `read_contents_recursively`, exactly the path
`GameStructure.load` uses on real input. Before Phase 14, this whole chain would have
degraded silently to a single opaque `ResourceFile`: gzip and WebFile had no scheme
registered at all, so nothing past the first layer was ever discovered.
"""
import gzip

from assetripper_io_files import scheme_reader
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.streams.smart import SmartStream
from assetripper_io_files.streams.stream import MemoryStream
from assetripper_io_files.web_files.web_file import WebFile
from assetripper_primitives import UnityVersion


def _build_serialized_file_bytes(name: str) -> bytes:
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=UnityVersion(2021, 3, 5),
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
    )
    serialized_file = builder.build()
    serialized_file.name = name
    stream = MemoryStream()
    serialized_file.write(stream)
    return stream.to_array()


def _build_fake_webgl_data_gz(entries: dict) -> bytes:
    from assetripper_io_files.resource_files.resource_file import ResourceFile

    web_file = WebFile()
    for name, data in entries.items():
        web_file.add_resource_file(ResourceFile.from_bytes(data, "/game/Build/game.data.gz", name))

    web_stream = SmartStream.create_memory()
    web_file.write(web_stream)
    return gzip.compress(web_stream.to_array())


def test_gzip_wrapped_web_file_recursively_discovers_the_embedded_serialized_file():
    sf_bytes = _build_serialized_file_bytes("globalgamemanagers")
    payload = _build_fake_webgl_data_gz({"globalgamemanagers": sf_bytes, "boot.json": b'{"key": 1}'})

    stream = SmartStream.create_memory(bytearray(payload))
    game_data_gz = scheme_reader.read_file(stream, "/game/Build/game.data.gz", "game.data.gz")

    from assetripper_io_files.compressed_files.gzip.gzip_file import GZipFile

    assert isinstance(game_data_gz, GZipFile)
    game_data_gz.read_contents_recursively()

    from assetripper_io_files.web_files.web_file import WebFile as WebFileType

    web_file = game_data_gz.uncompressed_file
    assert isinstance(web_file, WebFileType)
    assert [f.name for f in web_file.serialized_files] == ["globalgamemanagers"]
    assert [r.name for r in web_file.resource_files] == ["boot.json"]
