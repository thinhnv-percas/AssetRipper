"""
Tests for the five `.meta` importers added 2026-08-03 (`content_importers.py`) and the shared
`AssetImporterBase` walk they use.

The bug these close: every asset exported as a *non-native* file (a `.png`, `.ogg`, `.glb`,
`.ttf`) got a `NativeFormatImporter` block, because that's the base
`AssetExportCollection._create_importer` default and no collection overrode it.
`NativeFormatImporter` is for assets stored in Unity's own YAML format, so naming it for a PNG
names an importer that cannot read the file -- and the importer name is what Unity keys off to
decide how to read the asset at all.
"""
from __future__ import annotations

import pytest

from assetripper_export_unity_projects.project.asset_importer_base import AssetImporterBase
from assetripper_export_unity_projects.project.content_importers import (
    AudioImporter,
    ModelImporter,
    TextureImporter,
    TrueTypeFontImporter,
    VideoClipImporter,
)
_ALL = [TextureImporter, AudioImporter, ModelImporter, TrueTypeFontImporter, VideoClipImporter]


class _RecordingWalker:
    """Records the walk instead of rendering YAML. `Meta.export_yaml_document` needs a full
    `ProjectAssetContainer`, which would make these unit tests an integration test of the whole
    export stack; `walk_standard` is the actual contract each importer implements, so it's what
    gets exercised directly here. The real YAML rendering is covered end to end against the
    shipped game build by `tests/real_fixtures/test_demo_android_apk.py::
    test_real_meta_files_name_the_right_importer`."""

    def __init__(self):
        self.fields: list[tuple[str, object]] = []
        self.dictionaries = 0
        self.divides = 0
        self.entered = False
        self.exited = False
        self._current: str | None = None

    def enter_asset(self, asset) -> bool:
        self.entered = True
        return True

    def exit_asset(self, asset) -> None:
        self.exited = True

    def divide_asset(self, asset) -> None:
        self.divides += 1

    def enter_field(self, asset, name: str) -> bool:
        self._current = name
        return True

    def exit_field(self, asset, name: str) -> None:
        self._current = None

    def visit_primitive(self, value, primitive_type) -> None:
        self.fields.append((self._current, value))

    def enter_dictionary(self, value) -> bool:
        self.dictionaries += 1
        self.fields.append((self._current, {}))
        return True

    def exit_dictionary(self, value) -> None:
        pass


def _walk(importer) -> _RecordingWalker:
    walker = _RecordingWalker()
    importer.walk_standard(walker)
    return walker


@pytest.mark.parametrize("importer_class", _ALL)
def test_class_name_matches_unitys_own_importer_name(importer_class):
    """The load-bearing assertion: Unity picks its importer by this exact name."""
    assert importer_class().class_name == importer_class.IMPORTER_CLASS_NAME
    assert importer_class.IMPORTER_CLASS_NAME.endswith("Importer")


@pytest.mark.parametrize("importer_class", _ALL)
def test_walk_emits_the_four_shared_tail_fields_in_order(importer_class):
    """Every real Unity `.meta` importer block ends with these four, in this order."""
    walker = _walk(importer_class())

    assert walker.entered and walker.exited
    assert [name for name, _ in walker.fields] == [
        "externalObjects",
        "userData",
        "assetBundleName",
        "assetBundleVariant",
    ]
    assert walker.dictionaries == 1, "externalObjects must be an empty mapping"


@pytest.mark.parametrize("importer_class", _ALL)
def test_walk_separates_every_field_with_a_divide(importer_class):
    """One fewer divide than fields -- a missing divide merges two YAML keys."""
    walker = _walk(importer_class())
    assert walker.divides == len(walker.fields) - 1


@pytest.mark.parametrize("importer_class", _ALL)
def test_asset_bundle_name_is_emitted_when_set(importer_class):
    importer = importer_class()
    importer.asset_bundle_name = "my-bundle"

    values = dict(_walk(importer).fields)
    assert values["assetBundleName"] == "my-bundle"


@pytest.mark.parametrize("importer_class", _ALL)
def test_unset_asset_bundle_name_becomes_an_empty_string_not_none(importer_class):
    """`None` would render as a YAML null, which isn't what a real `.meta` carries."""
    values = dict(_walk(importer_class()).fields)
    assert values["assetBundleName"] == ""


@pytest.mark.parametrize("importer_class", _ALL)
def test_each_importer_reports_a_distinct_name(importer_class):
    """Guards a copy-paste error in `content_importers.py`: five subclasses of one base, each
    differing only by a class attribute, is exactly the shape where two could silently share a
    name."""
    names = {cls.IMPORTER_CLASS_NAME for cls in _ALL}
    assert len(names) == len(_ALL)


def test_base_class_refuses_to_render_without_a_name():
    """A subclass that forgot IMPORTER_CLASS_NAME must fail loudly, not emit an empty YAML key."""

    class Forgotten(AssetImporterBase):
        pass

    with pytest.raises(NotImplementedError):
        _ = Forgotten().class_name


def test_serialized_version_is_deliberately_absent():
    """Documents a considered omission rather than an oversight: `serializedVersion` varies by
    Unity version *and* importer, and a wrong value is worse than an absent one -- Unity treats
    absent as "oldest" and upgrades, but a wrong number can make it misread the block."""
    assert "serializedVersion" not in dict(_walk(TextureImporter()).fields)
