"""Phase 14: `WebFiles/{WebFile,WebFileEntry,WebFileScheme}.cs` port -- the
"UnityWebData1.0" flat archive container WebGL builds place their asset files inside
(typically the `.data` payload of a `<Product>.data`, itself often further gzip/brotli-
wrapped -- see test_gzip_file.py/test_brotli_file.py).
"""
from assetripper_io_files.streams.smart import SmartStream
from assetripper_io_files.web_files.web_file import WebFile
from assetripper_io_files.web_files.web_file_scheme import WebFileScheme


def _round_trip(entries: dict) -> WebFile:
    web_file = WebFile()
    for name, data in entries.items():
        from assetripper_io_files.resource_files.resource_file import ResourceFile

        web_file.add_resource_file(ResourceFile.from_bytes(data, "/game/data.unityweb", name))

    write_stream = SmartStream.create_memory()
    web_file.write(write_stream)
    payload = write_stream.to_array()

    read_stream = SmartStream.create_memory(bytearray(payload))
    scheme = WebFileScheme()
    assert scheme.can_read(read_stream)
    read_stream.position = 0
    return scheme.read(read_stream, "/game/data.unityweb", "data.unityweb")


def test_web_file_round_trips_entries():
    entries = {"boot.json": b'{"key": "value"}', "framework.js": b"function main() {}"}
    web_file = _round_trip(entries)

    results = {resource.name: resource.to_byte_array() for resource in web_file.resource_files}
    assert results == entries


def test_web_file_scheme_rejects_non_web_data():
    stream = SmartStream.create_memory(bytearray(b"this is not a UnityWebData1.0 archive"))
    assert not WebFileScheme().can_read(stream)


def test_web_file_scheme_can_read_does_not_consume_the_stream():
    web_file = _round_trip({"a.txt": b"hello"})
    write_stream = SmartStream.create_memory()
    web_file.write(write_stream)
    payload = write_stream.to_array()

    stream = SmartStream.create_memory(bytearray(payload))
    assert WebFileScheme().can_read(stream)
    assert stream.position == 0
