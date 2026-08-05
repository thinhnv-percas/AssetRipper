"""Test for the scoped port of
Source/AssetRipper.Processing/MainAssetProcessor.cs (self-pairing only)."""
from assetripper_import.class_id_type import ClassIDType
from assetripper_processing.game_data import GameData
from assetripper_processing.main_asset_processor import MainAssetProcessor


class _FakeAsset:
    def __init__(self, class_id: int):
        self.class_id = class_id
        self.main_asset = None


class _FakeGameBundle:
    def __init__(self, assets):
        self._assets = assets

    def fetch_assets(self):
        return iter(self._assets)


def test_font_and_terrain_data_become_their_own_main_asset():
    font = _FakeAsset(ClassIDType.Font)
    terrain_data = _FakeAsset(ClassIDType.TerrainData)
    other = _FakeAsset(ClassIDType.Texture2D)

    game_data = GameData(_FakeGameBundle([font, terrain_data, other]), None, None, None)
    MainAssetProcessor().process(game_data)

    assert font.main_asset is font
    assert terrain_data.main_asset is terrain_data
    assert other.main_asset is None
