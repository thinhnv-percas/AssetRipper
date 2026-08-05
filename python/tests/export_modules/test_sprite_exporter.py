"""Phase 13b: `Textures/YamlSpriteExporter.cs` port -- Sprite (213) exports as a plain
`.asset` YAML; SpriteAtlas (687078895) is skipped entirely (EmptyExportCollection, Phase 15)
so the Unity Editor doesn't try to re-pack an already-packed atlas.
"""
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

from import_._tree_builder import node, string_nodes, tree, unity_string

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)


def _build_bundle(entries: "list[tuple[int, str, str]]") -> GameBundle:
    """entries: list of (class_id, type_name, m_Name value)."""
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    for file_id, (class_id, type_name, name_value) in enumerate(entries, start=1):
        type_ = SerializedType()
        type_.type_id = class_id
        type_.is_stripped_type = False
        type_.script_type_index = -1
        type_.old_type = tree(node(type_name, "Base", 0), *string_nodes("m_Name", 1))

        obj = ObjectInfo(type_)
        obj.file_id = file_id
        obj.serialized_type_index = len(builder.types)
        obj.object_data = unity_string(name_value)

        builder.types.append(type_)
        builder.objects.append(obj)

    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())
    return game_bundle


def _export(game_bundle, tmp_path):
    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_sprite_exports_as_asset_yaml(tmp_path):
    game_bundle = _build_bundle([(213, "Sprite", "MySprite")])
    _export(game_bundle, tmp_path)

    asset_files = [p for p in tmp_path.rglob("*.asset") if p.is_file()]
    assert len(asset_files) == 1
    assert asset_files[0].name == "MySprite.asset"
    text = asset_files[0].read_text(encoding="utf-8")
    assert "--- !u!213" in text


def test_sprite_atlas_is_skipped_entirely(tmp_path):
    game_bundle = _build_bundle([(687078895, "SpriteAtlas", "MyAtlas")])
    _export(game_bundle, tmp_path)

    all_files = [p for p in tmp_path.rglob("*") if p.is_file()]
    assert all_files == []


def test_sprite_and_atlas_together_only_sprite_is_exported(tmp_path):
    game_bundle = _build_bundle([(213, "Sprite", "MySprite"), (687078895, "SpriteAtlas", "MyAtlas")])
    _export(game_bundle, tmp_path)

    asset_files = [p for p in tmp_path.rglob("*.asset") if p.is_file()]
    assert [p.name for p in asset_files] == ["MySprite.asset"]
