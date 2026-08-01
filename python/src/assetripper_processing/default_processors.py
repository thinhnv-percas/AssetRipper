"""The asset-processor half of `ExportHandler.GetProcessors()`
(Source/AssetRipper.Export.UnityProjects/ExportHandler.cs:57-93), in upstream's exact order:
SceneDefinitionProcessor -> OriginalPathProcessor -> MainAssetProcessor -> EditorFormatProcessor
-> SpriteProcessor (Phase 13c, partial -- see its own docstring) -> PrefabProcessor (Phase 12).

Not ported (each is a real, un-guessed-at gap, not a fabricated no-op):
- AnimatorControllerProcessor, AudioMixerProcessor, LightingDataProcessor,
  ScriptableObjectProcessor -- see python/ROADMAP.md Phase 13. Upstream runs these between
  EditorFormatProcessor and PrefabProcessor; "static mesh separation" also goes there but is
  premium-only upstream and no processor in this repo reads that setting, so it has no
  Python counterpart to omit either.
- `PrefabProcessor`'s `AddMissingTransforms` step and its "prefabs with an existing
  PrefabInstance" branch -- see prefabs/prefab_processor.py's own module docstring for why.

Skipped with high confidence (not merely deferred): the 11 assembly processors upstream runs
first (AttributePolyfillGenerator, MonoExplicitPropertyRepairProcessor,
ObfuscationRepairProcessor, ForwardingAssemblyGenerator, MethodStubbingProcessor,
NullRefReturnProcessor, UnmanagedConstraintRecoveryProcessor, NullableRemovalProcessor,
SafeAssemblyPublicizingProcessor, RemoveAssemblyKeyFileAttributeProcessor,
InternalsVisibileToPublicKeyRemover). Every one of them iterates
`assembly_manager.get_assemblies()`, which is always empty in this port (`assembly_manager`
is always `None` -- see assetripper_import/structure/game_structure.py's module docstring),
so they are provably no-ops here, not just unported.
"""
from __future__ import annotations

from .configuration.bundled_assets_export_mode import BundledAssetsExportMode
from .editor.editor_format_processor import EditorFormatProcessor
from .main_asset_processor import MainAssetProcessor
from .prefabs.prefab_processor import PrefabProcessor
from .scenes.original_path_processor import OriginalPathProcessor
from .scenes.scene_definition_processor import SceneDefinitionProcessor
from .textures.sprite_processor import SpriteProcessor


def default_processors(
    bundled_assets_export_mode: BundledAssetsExportMode = BundledAssetsExportMode.DIRECT_EXPORT,
) -> tuple:
    return (
        SceneDefinitionProcessor(),
        OriginalPathProcessor(bundled_assets_export_mode),
        MainAssetProcessor(),
        EditorFormatProcessor(bundled_assets_export_mode),
        SpriteProcessor(),
        PrefabProcessor(),
    )


def run_default_processors(game_data, settings=None) -> None:
    """`settings` (Phase 10): a `FullConfiguration`; only its
    `processing_settings.bundled_assets_export_mode` is consulted. Omitting it keeps
    `default_processors`'s own default (upstream's real default, `DirectExport`)."""
    bundled_assets_export_mode = (
        settings.processing_settings.bundled_assets_export_mode
        if settings is not None
        else BundledAssetsExportMode.DIRECT_EXPORT
    )
    for processor in default_processors(bundled_assets_export_mode):
        processor.process(game_data)
