"""Tests for `project/yaml_streamed_asset_exporter.py` (2026-08-03).

The gap it closes: a player build stores texture pixels and mesh vertex buffers in an external
`.resS` file, referenced by `m_StreamData`. Phase 9 taught the *content* exporters to follow that
pointer, so `.png`/`.glb` output works -- but when a content exporter declines (unsupported
texture format, a mesh whose data only lives in `m_CompressedMesh`), the asset falls through to
`DefaultYamlExporter` and its YAML still names a `.resS` file that exists nowhere in the exported
project. Unity then reads an asset with no data at all.

Assets here are small stand-ins rather than real `TypeTreeObject`s: what is under test is the
inline/blank/restore logic and the registration order, and a real dynamic-reader asset would
drown both in TypeTree scaffolding. `tests/export_modules/` already covers the real-asset
streamed-data path end to end (Phase 9).
"""
from __future__ import annotations

import pytest
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_unity_projects.project.yaml_streamed_asset_exporter import (
    YamlStreamedAssetExporter,
    YamlStreamedAssetExportCollection,
)
from assetripper_export_unity_projects.project_exporter import ProjectExporter

_TEXTURE_2D_CLASS_ID = 28
_MESH_CLASS_ID = 43


class _Fields(dict):
    """A field bag with the `.get`/`[]`/`in` surface the exporter uses."""


class _FakeAsset:
    def __init__(self, class_id: int, fields: dict):
        self.class_id = class_id
        self._fields = fields
        self.collection = object()

    def get(self, name, default=None):
        return self._fields.get(name, default)

    def __getitem__(self, name):
        return self._fields[name]

    def __setitem__(self, name, value):
        self._fields[name] = value

    def __contains__(self, name):
        return name in self._fields


def _stream_data(path="archive:/CAB-x/CAB-x.resS", offset=0, size=8):
    return _Fields(path=path, offset=offset, size=size)


def _texture(*, inline=b"", stream=True, path="archive:/CAB-x/CAB-x.resS"):
    fields = {"image data": inline, "m_Name": "Tex"}
    if stream:
        fields["m_StreamData"] = _stream_data(path=path)
    return _FakeAsset(_TEXTURE_2D_CLASS_ID, fields)


def _mesh(*, inline=b"", stream=True):
    fields = {"m_VertexData": _Fields(m_DataSize=inline), "m_Name": "Mesh"}
    if stream:
        fields["m_StreamData"] = _stream_data()
    return _FakeAsset(_MESH_CLASS_ID, fields)


# -- try_create_collection: when the exporter takes the asset at all ----------------------


def test_declines_a_texture_with_no_stream_data():
    """The ordinary editor-built case -- pixels are already inline, nothing to do."""
    created, collection = YamlStreamedAssetExporter().try_create_collection(
        _texture(inline=b"\x01\x02", stream=False)
    )
    assert created is False
    assert collection is None


def test_declines_a_texture_whose_stream_data_has_an_empty_path():
    """`m_StreamData` exists on the layout but is blank, which is how an editor build serializes
    it. Treating that as streamed would blank a field for no reason."""
    created, _ = YamlStreamedAssetExporter().try_create_collection(_texture(path=""))
    assert created is False


def test_declines_an_unrelated_class():
    created, _ = YamlStreamedAssetExporter().try_create_collection(_FakeAsset(49, {"m_Script": b""}))
    assert created is False


def test_declines_a_mesh_with_no_vertex_data_field():
    """A Mesh whose layout did not resolve `m_VertexData` has nowhere to put the bytes."""
    created, _ = YamlStreamedAssetExporter().try_create_collection(
        _FakeAsset(_MESH_CLASS_ID, {"m_StreamData": _stream_data()})
    )
    assert created is False


@pytest.mark.parametrize("factory", [_texture, _mesh])
def test_accepts_a_streamed_asset(factory):
    created, collection = YamlStreamedAssetExporter().try_create_collection(factory())
    assert created is True
    assert isinstance(collection, YamlStreamedAssetExportCollection)


# -- _export_inner: inline, then restore --------------------------------------------------


class _RecordingExporter:
    """Stands in for the YAML writer, capturing what the asset looked like at write time -- the
    only moment the inlined values are supposed to be visible."""

    def __init__(self):
        self.seen = None

    def export(self, container, asset, path, file_system) -> bool:
        stream_data = asset.get("m_StreamData")
        if asset.class_id == _TEXTURE_2D_CLASS_ID:
            inline = asset.get("image data")
        else:
            inline = asset.get("m_VertexData").get("m_DataSize")
        self.seen = {
            "inline": inline,
            "path": stream_data.get("path"),
            "offset": stream_data.get("offset"),
            "size": stream_data.get("size"),
        }
        return True


def _export(asset, content: bytes, monkeypatch) -> _RecordingExporter:
    import assetripper_export_unity_projects.project.yaml_streamed_asset_exporter as module

    monkeypatch.setattr(module, "get_streaming_info_content", lambda *_: content)
    exporter = _RecordingExporter()
    collection = YamlStreamedAssetExportCollection(exporter, asset)
    assert collection._export_inner(None, "/out/Asset.asset", "/out", None) is True
    return exporter


@pytest.mark.parametrize("factory", [_texture, _mesh])
def test_streamed_bytes_are_inlined_and_stream_data_blanked_at_write_time(factory, monkeypatch):
    """The load-bearing assertion: the YAML Unity reads must carry the bytes, not a path to a
    resource file the exported project does not contain."""
    exporter = _export(factory(), b"\xde\xad\xbe\xef", monkeypatch)

    assert exporter.seen["inline"] == b"\xde\xad\xbe\xef"
    assert exporter.seen["path"] == ""
    assert exporter.seen["offset"] == 0
    assert exporter.seen["size"] == 0


@pytest.mark.parametrize("factory", [_texture, _mesh])
def test_the_asset_is_restored_afterwards(factory, monkeypatch):
    """The same asset object is still referenced by other collections in the same export run and
    by the GUI preview, so the mutation has to be undone -- upstream restores it too."""
    asset = factory()
    original_path = asset.get("m_StreamData").get("path")
    original_size = asset.get("m_StreamData").get("size")

    _export(asset, b"\xde\xad\xbe\xef", monkeypatch)

    stream_data = asset.get("m_StreamData")
    assert stream_data.get("path") == original_path
    assert stream_data.get("size") == original_size
    if asset.class_id == _TEXTURE_2D_CLASS_ID:
        assert asset.get("image data") == b""
    else:
        assert asset.get("m_VertexData").get("m_DataSize") == b""


def test_the_asset_is_restored_even_when_the_yaml_write_fails(monkeypatch):
    """A failed write must not leave the asset mutated for every later consumer."""
    import assetripper_export_unity_projects.project.yaml_streamed_asset_exporter as module

    monkeypatch.setattr(module, "get_streaming_info_content", lambda *_: b"\x01\x02")

    class _Failing:
        def export(self, *_):
            raise RuntimeError("write failed")

    asset = _texture()
    collection = YamlStreamedAssetExportCollection(_Failing(), asset)
    with pytest.raises(RuntimeError):
        collection._export_inner(None, "/out/Tex.asset", "/out", None)

    assert asset.get("image data") == b""
    assert asset.get("m_StreamData").get("path") == "archive:/CAB-x/CAB-x.resS"


def test_unresolvable_streamed_data_keeps_the_original_reference(monkeypatch):
    """A dangling path at least names the resource file that went missing. Blanking it would
    silently claim the asset genuinely has no data, which is strictly less informative."""
    import assetripper_export_unity_projects.project.yaml_streamed_asset_exporter as module

    monkeypatch.setattr(module, "get_streaming_info_content", lambda *_: b"")
    exporter = _RecordingExporter()
    asset = _texture()

    assert YamlStreamedAssetExportCollection(exporter, asset)._export_inner(None, "/o/a", "/o", None) is True
    assert exporter.seen["path"] == "archive:/CAB-x/CAB-x.resS"
    assert exporter.seen["inline"] == b""


def test_a_raising_resolver_does_not_abort_the_export(monkeypatch):
    """A short or corrupt `.resS` must cost one asset's data, not the whole run."""
    import assetripper_export_unity_projects.project.yaml_streamed_asset_exporter as module

    def _boom(*_):
        raise ValueError("truncated resource file")

    monkeypatch.setattr(module, "get_streaming_info_content", _boom)
    exporter = _RecordingExporter()

    assert YamlStreamedAssetExportCollection(exporter, _texture())._export_inner(None, "/o/a", "/o", None) is True
    assert exporter.seen["path"] == "archive:/CAB-x/CAB-x.resS"


def test_already_inline_data_still_gets_stream_data_blanked(monkeypatch):
    """Upstream's branch for an asset carrying both. A resource path next to real inline data is
    contradictory, and Unity prefers the (nonexistent) file."""
    exporter = _export(_texture(inline=b"\x07\x08"), b"\xaa\xbb", monkeypatch)
    assert exporter.seen["path"] == ""


# -- registration order -------------------------------------------------------------------


@pytest.mark.parametrize("class_id", [_TEXTURE_2D_CLASS_ID, _MESH_CLASS_ID])
def test_content_exporters_are_still_tried_first(class_id):
    """The regression this guards is severe and silent: registered the other way round, every
    streamed texture and mesh in a normal export would become a `.asset` YAML blob instead of a
    `.png`/`.glb`, and nothing would error."""
    project_exporter = ProjectExporter()
    register_default_exporters(project_exporter)

    chain = project_exporter._class_id_exporters[class_id]
    streamed_positions = [i for i, e in enumerate(chain) if isinstance(e, YamlStreamedAssetExporter)]
    assert streamed_positions, "the streamed-YAML fallback must be registered at all"
    assert streamed_positions[0] == len(chain) - 1, (
        f"it must be last in the chain for class {class_id}, got position {streamed_positions[0]} "
        f"of {len(chain)}"
    )
