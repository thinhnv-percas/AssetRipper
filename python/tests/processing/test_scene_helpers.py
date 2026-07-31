"""Port-adjacent tests for Source/AssetRipper.Processing/Scenes/SceneHelpers.cs."""
from assetripper_processing.scenes import scene_helpers
from assetripper_primitives import UnityVersion

_V2019 = UnityVersion(2019, 4, 0)
_V5_2 = UnityVersion(5, 2, 0)


class _FakeAsset:
    """Stands in for a dynamically-read BuildSettings TypeTreeObject: only `.get()` is
    needed by scene_helpers.try_get_scene_path/is_scene_duplicate."""

    def __init__(self, fields: dict):
        self._fields = fields

    def get(self, name, default=None):
        return self._fields.get(name, default)


def test_has_main_data_before_5_3():
    assert scene_helpers.has_main_data(UnityVersion(5, 2, 0))
    assert not scene_helpers.has_main_data(UnityVersion(5, 3, 0))


def test_try_get_file_name_to_scene_index_modern():
    assert scene_helpers.try_get_file_name_to_scene_index("level0", _V2019) == (True, 0)
    assert scene_helpers.try_get_file_name_to_scene_index("level12", _V2019) == (True, 12)
    assert scene_helpers.try_get_file_name_to_scene_index("notalevel", _V2019) == (False, -1)


def test_try_get_file_name_to_scene_index_with_main_data():
    assert scene_helpers.try_get_file_name_to_scene_index("maindata", _V5_2) == (True, 0)
    assert scene_helpers.try_get_file_name_to_scene_index("level0", _V5_2) == (True, 1)


def test_scene_index_to_file_name_round_trips():
    for version in (_V2019, _V5_2):
        for index in range(3):
            name = scene_helpers.scene_index_to_file_name(index, version)
            found, recovered_index = scene_helpers.try_get_file_name_to_scene_index(name, version)
            assert found
            assert recovered_index == index


class _FakeCollection:
    def __init__(self, name: str, original_version: UnityVersion):
        self.name = name
        self.original_version = original_version


def test_try_get_scene_path_strips_extension_and_keeps_assets_prefix():
    collection = _FakeCollection("level0", _V2019)
    build_settings = _FakeAsset({"m_Scenes": ["Assets/Scenes/Level0.unity"]})
    found, path = scene_helpers.try_get_scene_path(collection, build_settings)
    assert found
    assert path == "Assets/Scenes/Level0"


def test_try_get_scene_path_relative_name_gets_assets_scenes_prefix():
    collection = _FakeCollection("level0", _V2019)
    build_settings = _FakeAsset({"m_Scenes": ["Level0"]})
    found, path = scene_helpers.try_get_scene_path(collection, build_settings)
    assert found
    assert path == "Assets/Scenes/Level0"


def test_try_get_scene_path_fails_without_build_settings():
    collection = _FakeCollection("level0", _V2019)
    found, path = scene_helpers.try_get_scene_path(collection, None)
    assert not found
    assert path is None


def test_try_get_scene_path_fails_when_index_out_of_range():
    collection = _FakeCollection("level5", _V2019)
    build_settings = _FakeAsset({"m_Scenes": ["Assets/Scenes/Level0.unity"]})
    found, path = scene_helpers.try_get_scene_path(collection, build_settings)
    assert not found


def test_is_scene_duplicate():
    build_settings = _FakeAsset({"m_Scenes": ["A", "B", "A"]})
    assert scene_helpers.is_scene_duplicate(0, build_settings)
    assert not scene_helpers.is_scene_duplicate(1, build_settings)
    assert not scene_helpers.is_scene_duplicate(0, None)
