"""Unit tests for assetripper_import/streamed_resource.py (Phase 9): the shared resolve+
slice logic behind Texture2D/Mesh's `m_StreamData` and AudioClip's `m_Resource`.
"""
from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_import.streamed_resource import (
    check_integrity,
    get_content,
    get_streamed_resource_content,
    get_streaming_info_content,
)
from assetripper_io_files.resource_files.resource_file import ResourceFile


class _FakeCollection:
    def __init__(self, bundle):
        self.bundle = bundle


class _FakeStruct:
    def __init__(self, **fields):
        self._fields = fields

    def get(self, name, default=None):
        return self._fields.get(name, default)


def _bundle_with_resource(name: str, data: bytes) -> GameBundle:
    bundle = GameBundle()
    bundle.add_resource(ResourceFile.from_bytes(data, "/does/not/matter", name))
    return bundle


def test_get_content_reads_the_correct_slice():
    bundle = _bundle_with_resource("CAB-abc.resS", b"0123456789")
    collection = _FakeCollection(bundle)

    assert get_content("CAB-abc.resS", 3, 4, collection) == b"3456"


def test_get_content_returns_none_for_empty_path():
    bundle = _bundle_with_resource("CAB-abc.resS", b"0123456789")
    collection = _FakeCollection(bundle)

    assert get_content(None, 0, 4, collection) is None
    assert get_content("", 0, 4, collection) is None


def test_get_content_returns_none_for_zero_size():
    bundle = _bundle_with_resource("CAB-abc.resS", b"0123456789")
    collection = _FakeCollection(bundle)

    assert get_content("CAB-abc.resS", 0, 0, collection) is None


def test_get_content_returns_none_when_resource_cannot_be_resolved():
    bundle = GameBundle()
    collection = _FakeCollection(bundle)

    assert get_content("missing.resS", 0, 4, collection) is None


def test_get_content_returns_none_when_resource_is_too_short():
    bundle = _bundle_with_resource("CAB-abc.resS", b"short")
    collection = _FakeCollection(bundle)

    assert get_content("CAB-abc.resS", 0, 100, collection) is None


def test_get_content_returns_none_on_integer_overflow_guard():
    bundle = _bundle_with_resource("CAB-abc.resS", b"0123456789")
    collection = _FakeCollection(bundle)

    huge = 2**63
    assert get_content("CAB-abc.resS", huge, 1, collection) is None
    assert get_content("CAB-abc.resS", 1, huge, collection) is None


def test_check_integrity_matches_get_content_availability():
    bundle = _bundle_with_resource("CAB-abc.resS", b"0123456789")
    collection = _FakeCollection(bundle)

    assert check_integrity("CAB-abc.resS", 0, 10, collection)
    assert not check_integrity("CAB-abc.resS", 0, 100, collection)
    assert not check_integrity("missing.resS", 0, 1, collection)
    assert check_integrity(None, 0, 0, collection)  # empty path is always "fine"


def test_get_streaming_info_content_reads_path_offset_size_fields():
    bundle = _bundle_with_resource("archive:/CAB-tex/CAB-tex.resS", b"\x00\x00\xffimage-bytes")
    collection = _FakeCollection(bundle)
    streaming_info = _FakeStruct(path="archive:/CAB-tex/CAB-tex.resS", offset=3, size=len(b"image-bytes"))

    assert get_streaming_info_content(streaming_info, collection) == b"image-bytes"


def test_get_streaming_info_content_returns_empty_bytes_when_unresolvable():
    bundle = GameBundle()
    collection = _FakeCollection(bundle)
    streaming_info = _FakeStruct(path="missing.resS", offset=0, size=4)

    assert get_streaming_info_content(streaming_info, collection) == b""


def test_get_streamed_resource_content_reads_m_prefixed_fields():
    bundle = _bundle_with_resource("CAB-audio.resS", b"header" + b"audio-payload")
    collection = _FakeCollection(bundle)
    streamed_resource = _FakeStruct(m_Source="CAB-audio.resS", m_Offset=6, m_Size=len(b"audio-payload"))

    assert get_streamed_resource_content(streamed_resource, collection) == b"audio-payload"


def test_get_streamed_resource_content_returns_empty_bytes_when_unresolvable():
    bundle = GameBundle()
    collection = _FakeCollection(bundle)
    streamed_resource = _FakeStruct(m_Source="", m_Offset=0, m_Size=0)

    assert get_streamed_resource_content(streamed_resource, collection) == b""
