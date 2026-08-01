"""Phase 14: legacy "UnityRaw"/"UnityWeb" bundle format port
(`bundle_files/raw_web/{raw,web}`). No C# test project exercises these against real content
either (pre-Unity5 fixtures aren't available anywhere in this environment) -- these are
original tests built on `_raw_web_bundle_builder`, the same synthetic-byte-layout approach
`test_bundle_decompression.py` uses for the modern UnityFS format.
"""
from assetripper_io_files.bundle_files.raw_web.raw.raw_bundle_scheme import RawBundleScheme
from assetripper_io_files.bundle_files.raw_web.web.web_bundle_scheme import WebBundleScheme
from assetripper_io_files.streams.smart import SmartStream

from ._raw_web_bundle_builder import build_raw_bundle, build_web_bundle

_ENTRIES = {"CAB-abc": b"hello world" * 10, "CAB-abc.resS": bytes(range(256))}


def test_raw_bundle_entries_round_trip():
    data = build_raw_bundle(_ENTRIES)
    stream = SmartStream.create_memory(bytearray(data))

    scheme = RawBundleScheme()
    assert scheme.can_read(stream)
    stream.position = 0
    bundle_file = scheme.read(stream, "/game/level0.unity3d", "level0.unity3d")

    results = {resource.name: resource.to_byte_array() for resource in bundle_file.resource_files}
    assert results == _ENTRIES


def test_web_bundle_entries_round_trip():
    data = build_web_bundle(_ENTRIES)
    stream = SmartStream.create_memory(bytearray(data))

    scheme = WebBundleScheme()
    assert scheme.can_read(stream)
    stream.position = 0
    bundle_file = scheme.read(stream, "/game/level0.unity3d", "level0.unity3d")

    results = {resource.name: resource.to_byte_array() for resource in bundle_file.resource_files}
    assert results == _ENTRIES


def test_raw_bundle_scheme_rejects_a_web_bundle_and_vice_versa():
    raw_data = build_raw_bundle(_ENTRIES)
    web_data = build_web_bundle(_ENTRIES)

    assert not WebBundleScheme().can_read(SmartStream.create_memory(bytearray(raw_data)))
    assert not RawBundleScheme().can_read(SmartStream.create_memory(bytearray(web_data)))


def test_raw_bundle_scheme_rejects_non_bundle_data():
    garbage = SmartStream.create_memory(bytearray(b"just some plain text, not a bundle file at all here"))
    assert not RawBundleScheme().can_read(garbage)
