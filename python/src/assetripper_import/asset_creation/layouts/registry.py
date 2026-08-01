"""
A registry mapping (class ID, Unity version) to a hand-written TypeTreeNodeStruct layout,
for files that embed no type tree of their own (typically stripped release player builds --
`globalgamemanagers`, `level*`, `resources.assets`; AssetBundles usually keep their trees).

This has no direct C# counterpart: upstream resolves this case from the Tpk type-tree
database, which isn't available here (see the phase plan). Exposes `default_layout_provider`,
matching the `layout_provider` callable GameAssetFactory accepts from Phase 1:
`(class_id, version) -> TypeTreeNodeStruct | None`.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion


class LayoutRegistry:
    def __init__(self):
        self._entries: dict[int, list[tuple[UnityVersion | None, UnityVersion | None, callable]]] = {}

    def register(self, class_id: int, builder_fn, *, min_version: UnityVersion | None = None, max_version: UnityVersion | None = None) -> None:
        """Registers `builder_fn(version) -> TypeTreeNodeStruct` for `class_id`, valid for
        `min_version <= version <= max_version` (either bound may be omitted). Later
        registrations for the same class ID are tried first, so a narrower override can be
        added after a broader default."""
        self._entries.setdefault(class_id, []).insert(0, (min_version, max_version, builder_fn))

    def get(self, class_id: int, version: UnityVersion):
        for min_version, max_version, builder_fn in self._entries.get(class_id, ()):
            if min_version is not None and version < min_version:
                continue
            if max_version is not None and version > max_version:
                continue
            return builder_fn(version)
        return None

    def __contains__(self, class_id: int) -> bool:
        return class_id in self._entries


def _build_default_registry() -> LayoutRegistry:
    from . import (
        asset_bundle,
        audio_clip,
        game_object,
        material,
        mono_script,
        sprite,
        text_asset,
        texture2d,
        transform,
    )

    registry = LayoutRegistry()
    game_object.register(registry)
    transform.register(registry)
    text_asset.register(registry)
    mono_script.register(registry)
    asset_bundle.register(registry)
    texture2d.register(registry)
    audio_clip.register(registry)
    sprite.register(registry)
    material.register(registry)
    return registry


_default_registry: LayoutRegistry | None = None


def default_registry() -> LayoutRegistry:
    global _default_registry
    if _default_registry is None:
        _default_registry = _build_default_registry()
    return _default_registry


def default_layout_provider(class_id: int, version: UnityVersion):
    return default_registry().get(class_id, version)
