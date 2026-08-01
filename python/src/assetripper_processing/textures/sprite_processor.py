"""Port of Source/AssetRipper.Processing/Textures/SpriteProcessor.cs (Phase 13c)

Scoped down from the C# original -- this is the highest-risk item in Phase 13 (see
ROADMAP.md), and one whole piece of upstream's logic is intentionally NOT ported here:

**Not ported: recovering `m_RD` from `SpriteAtlas.RenderDataMap`.** Upstream looks up a
sprite's true (atlas-corrected) render data by matching `sprite.RenderDataKey` (a
`pair<GUID, SInt64>`) against `atlas.RenderDataMap`'s keys. Doing that here would require
knowing the exact sub-field names the dynamic reader gives a `GUID` complex structure --
which this project has *already* declined to guess at once before, for the exact same
reason: see `assetripper_processing/scenes/scene_definition_processor.py`'s own docstring
("`IOcclusionCullingSettings.SceneGUID` recovery is skipped... converting the dynamically-
read GUID sub-structure to a UnityGuid needs its exact sub-field names, which aren't known
with confidence here"). Guessing wrong here would silently misalign every atlased sprite in
a project -- worse than not touching it at all.

Practical consequence: for a sprite that WAS packed into a `SpriteAtlas`, this port's
`Rect`/`Pivot`/`Border` stay based on the sprite's own (pre-atlas-packing) `m_RD.textureRect`
rather than the atlas-corrected one -- i.e. `get_sprite_coordinates_in_atlas` always runs
upstream's own "no atlas data resolved" fallback branch here, never its "matched" branch.
That fallback is mathematically a no-op whenever the sprite's own `m_RD.textureRect` already
equals `m_Rect` (no crop happened) -- the overwhelmingly common shape for content that
predates the `SpriteAtlas` system or wasn't packed. It is very much *not* a no-op, and is
therefore silently wrong in the way the ROADMAP note warns about, for any sprite that really
was packed into an atlas with real cropping. **Do not treat atlased-sprite output from this
port as trustworthy without a real Unity fixture to check it against.**

What IS ported and is comparatively low-risk: clearing the dangling `SpriteAtlas` reference
(`m_SpriteAtlas`/`m_AtlasTags`) whenever it resolves to a real asset -- upstream does this
unconditionally, specifically because the Unity Editor crashes trying to re-pack an
already-packed atlas otherwise, and it doesn't depend on the RenderDataMap lookup at all.

Also not ported: the `SpriteInformationObject`/`ObjectFactory` main-asset bookkeeping that
determines which synthesized asset "owns" a texture shared between multiple sprites/atlases
-- an export-organization concern (which name/collection a shared texture's PNG lands
under), not a correctness property of any individual sprite's own Rect/Pivot/Border. Left
for a later pass if export-organization fidelity for atlas-page textures becomes a priority.
"""
from __future__ import annotations

import logging

from assetripper_assets.null_object import NullObject
from assetripper_io_files.special_file_names import is_default_resource_or_builtin_extra

from ..i_asset_processor import IAssetProcessor
from .sprite_coordinates import get_sprite_coordinates_in_atlas

_logger = logging.getLogger(__name__)

_SPRITE_CLASS_ID = 213


class SpriteProcessor(IAssetProcessor):
    def process(self, game_data) -> None:
        _logger.info("Processing Sprites")
        for collection in game_data.game_bundle.fetch_asset_collections():
            if is_default_resource_or_builtin_extra(collection.name):
                continue
            for asset in collection:
                if asset.class_id == _SPRITE_CLASS_ID:
                    _process_sprite(asset)


def _process_sprite(sprite) -> None:
    _clear_dangling_atlas_reference(sprite)

    rd = sprite.get("m_RD")
    texture_rect = _rect_tuple(rd.get("textureRect")) if rd is not None else (0.0, 0.0, 0.0, 0.0)
    texture_rect_offset = _vector2_tuple(rd.get("textureRectOffset")) if rd is not None else (0.0, 0.0)

    sprite_rect_field = sprite.get("m_Rect")
    sprite_rect = _rect_tuple(sprite_rect_field)
    sprite_pivot_field = sprite.get("m_Pivot")
    sprite_pivot = _vector2_tuple(sprite_pivot_field) if sprite_pivot_field is not None else None
    sprite_offset = _vector2_tuple(sprite.get("m_Offset")) or (0.0, 0.0)
    sprite_border_field = sprite.get("m_Border")
    sprite_border = _vector4_tuple(sprite_border_field) if sprite_border_field is not None else None

    result = get_sprite_coordinates_in_atlas(
        sprite_rect=sprite_rect,
        sprite_pivot=sprite_pivot,
        sprite_offset=sprite_offset,
        sprite_border=sprite_border,
        atlas_texture_rect=texture_rect,
        atlas_texture_rect_offset=texture_rect_offset,
    )

    if sprite_rect_field is not None:
        _write_rect(sprite_rect_field, result.rect)
    pivot_field = sprite.get("m_Pivot")
    if pivot_field is not None:
        _write_vector2(pivot_field, result.pivot)
    border_field = sprite.get("m_Border")
    if border_field is not None:
        _write_vector4(border_field, result.border)

    # Offset is the pixel offset of the pivot from the center of Rect.
    offset_field = sprite.get("m_Offset")
    if offset_field is not None:
        _write_vector2(offset_field, ((result.pivot[0] - 0.5) * result.rect[2], (result.pivot[1] - 0.5) * result.rect[3]))

    # TextureRectOffset is the pixel offset of m_RD.TextureRect from Rect.
    if rd is not None:
        rd_texture_rect_offset_field = rd.get("textureRectOffset")
        if rd_texture_rect_offset_field is not None:
            _write_vector2(
                rd_texture_rect_offset_field, (texture_rect[0] - result.rect[0], texture_rect[1] - result.rect[1])
            )


def _clear_dangling_atlas_reference(sprite) -> None:
    pptr = sprite.get("m_SpriteAtlas")
    if pptr is None or pptr.is_null:
        return
    # cls=NullObject: every dynamically-read asset in this port derives from NullObject
    # (see TypeTreeObject's own docstring), which AssetCollection.get_asset otherwise
    # filters out -- same reasoning as OriginalPathProcessor's PPtr resolution.
    atlas = sprite.collection.get_asset_by_pptr(pptr.to_pptr(), NullObject)
    if atlas is None:
        return

    # Must clear the reference: the Unity Editor crashes trying to re-pack an
    # already-packed sprite otherwise.
    pptr.file_id = 0
    pptr.path_id = 0
    atlas_tags = sprite.get("m_AtlasTags")
    if atlas_tags:
        atlas_tags.clear()


def _rect_tuple(rect_field) -> "tuple[float, float, float, float]":
    if rect_field is None:
        return (0.0, 0.0, 0.0, 0.0)
    return (rect_field["x"], rect_field["y"], rect_field["width"], rect_field["height"])


def _vector2_tuple(vector_field) -> "tuple[float, float] | None":
    if vector_field is None:
        return None
    return (vector_field["x"], vector_field["y"])


def _vector4_tuple(vector_field) -> "tuple[float, float, float, float] | None":
    if vector_field is None:
        return None
    return (vector_field["x"], vector_field["y"], vector_field["z"], vector_field["w"])


def _write_rect(rect_field, value: "tuple[float, float, float, float]") -> None:
    rect_field["x"], rect_field["y"], rect_field["width"], rect_field["height"] = value


def _write_vector2(vector_field, value: "tuple[float, float]") -> None:
    vector_field["x"], vector_field["y"] = value


def _write_vector4(vector_field, value: "tuple[float, float, float, float]") -> None:
    vector_field["x"], vector_field["y"], vector_field["z"], vector_field["w"] = value
