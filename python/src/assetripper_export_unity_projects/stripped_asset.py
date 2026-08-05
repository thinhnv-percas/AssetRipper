"""Port of Source/AssetRipper.Export.UnityProjects/StrippedAssetExtensions.cs

What Unity means by "stripped": inside a `.unity`/`.prefab` file, an object that lives
*somewhere else* still needs a local anchor so the file's own references can point at it. Unity
writes such an object as a stub -- tagged `stripped` after the anchor, and carrying only the
handful of fields that identify where the real object comes from. Everything else is dropped,
because the real values are in the other file.

Previously not ported, with the stated reason that `PrefabProcessor.Process` never populates
`StrippedAssets` upstream either, so porting it would carry a no-op. That reasoning held for
the *producer* side and still does -- nothing in this port marks assets as stripped during a
normal export, exactly as upstream. What it got wrong is that the *consumer* side is not dead
weight: it is a documented YAML shape with upstream tests pinning it byte for byte
(`AssetRipper.Tests/StrippedAssetTests.cs`, ported to
`tests/export_unity_projects/test_stripped_asset.py`), and `YamlWalker` is the one place where
a future producer would have to plug in. Porting the consumer makes that shape verified rather
than merely absent.

The field allow-lists below are upstream's verbatim, and the ordering of the emitted fields is
whatever the asset's own `walk_editor` produced -- this filters, it never reorders or adds.
"""
from __future__ import annotations

_ALLOWED_ASSET_FIELDS = frozenset(
    {
        "m_CorrespondingSourceObject",
        "m_PrefabAsset",
        "m_PrefabInstance",
        "m_PrefabInternal",
        "m_PrefabParentObject",
    }
)

_ALLOWED_MONO_BEHAVIOUR_FIELDS = _ALLOWED_ASSET_FIELDS | {
    "m_EditorClassIdentifier",
    "m_EditorHideFlags",
    "m_Enabled",
    "m_GameObject",
    "m_Name",
    "m_Script",
}

_MONO_BEHAVIOUR_CLASS_ID = 114


def is_stripped(asset) -> bool:
    """Whether `asset` is one of the stubs its owning hierarchy marked as stripped.

    Reached through `main_asset` rather than a flag on the asset itself, matching upstream:
    stripping is a property of *how a particular file references* the asset, and
    `GameObjectHierarchyObject` is the thing that knows which file that is.
    """
    hierarchy = getattr(asset, "main_asset", None)
    stripped_assets = getattr(hierarchy, "stripped_assets", None)
    if stripped_assets is None:
        return False
    return any(existing is asset for existing in stripped_assets)


def remove_stripped_fields(asset, root) -> None:
    """Drops every field of `root` (the asset's own mapping node) that a stripped stub must not
    carry. MonoBehaviour keeps more than other classes, because Unity needs the script
    reference and the owning GameObject to reattach the component at all."""
    allowed = (
        _ALLOWED_MONO_BEHAVIOUR_FIELDS
        if asset.class_id == _MONO_BEHAVIOUR_CLASS_ID
        else _ALLOWED_ASSET_FIELDS
    )
    _remove_disallowed(root, allowed)


def _remove_disallowed(root, allowed) -> None:
    from assetripper_yaml import YamlScalarNode

    kept = []
    for key, value in root.children:
        if isinstance(key, YamlScalarNode) and key.value in allowed:
            kept.append((key, value))
    root.children[:] = kept
