"""Port of Source/AssetRipper.Processing/Editor/EditorFormatProcessor.cs

Upstream restores ~15 different asset kinds' editor-only fields (Transform's
LocalEulerAnglesHint/RootOrder recovered from quaternion math and parent/child traversal,
GameObject/Renderer/SpriteAtlas/AnimationClip/NavMeshSettings/Mesh/Terrain/PlayableDirector/
AssetBundle/GraphicsSettings/QualitySettings/Physics2DSettings/LightmapSettings/
LightingSettings/UnityConnectSettings conversions), each its own algorithm defined in files
this port hasn't ported. None of that is included here -- porting it well would be its own
multi-phase effort, not something to guess at.

What IS ported: the release-collection-filtering structure (a real, useful piece of
scaffolding for whichever of those conversions get added later) and part of the one case
that's within this port's existing capabilities: PlayerSettings' default-value patching via
dynamic field access (TypeTreeObject.editor_fields, already ported in Phase 1). Only the two
sub-fields upstream sets to fixed literals (`webGLLinkerTarget = 1`, `allowUnsafeCode =
true`) are patched. `apiCompatibilityLevel`/`scriptingRuntimeVersion` are NOT patched: their
correct values are `ApiCompatibilityLevel`/`ScriptingRuntimeVersion` enum members whose exact
integer values aren't confirmed here (and `assembly_manager.has_mscorlib2`, which upstream
uses to choose between them, is unavailable anyway -- assembly_manager is always None in
this port, see assetripper_import/structure/game_structure.py). Writing a guessed integer
into exported PlayerSettings data would be a fabricated value, not just a missing one, so
this is skipped rather than guessed.
"""
from __future__ import annotations

import logging

from assetripper_io_files.serialized_files.transfer_instruction_flags import is_release

from ..i_asset_processor import IAssetProcessor

_logger = logging.getLogger(__name__)


class EditorFormatProcessor(IAssetProcessor):
    def __init__(self, bundled_assets_export_mode=None):
        self.bundled_assets_export_mode = bundled_assets_export_mode

    def process(self, game_data) -> None:
        _logger.info("Editor Format Conversion")
        for asset in _get_release_assets(game_data):
            self._convert(asset)

    def _convert(self, asset) -> None:
        if getattr(asset, "is_player_settings", False):
            self._convert_player_settings(asset)

    @staticmethod
    def _convert_player_settings(player_settings) -> None:
        editor_structure = player_settings.editor_fields
        if "webGLLinkerTarget" in editor_structure:
            editor_structure["webGLLinkerTarget"] = 1
        if "allowUnsafeCode" in editor_structure:
            editor_structure["allowUnsafeCode"] = True


def _get_release_assets(game_data):
    for collection in _get_release_collections(game_data):
        yield from collection


def _get_release_collections(game_data):
    for collection in game_data.game_bundle.fetch_asset_collections():
        if is_release(collection.flags):
            yield collection
