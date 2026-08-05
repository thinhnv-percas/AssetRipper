"""Shared `.meta` importer scaffolding (2026-08-03).

Every Unity `.meta` importer block ends with the same four fields --
`externalObjects`/`userData`/`assetBundleName`/`assetBundleVariant` -- and the four
hand-written importers this port already had (`NativeFormatImporter`, `TextScriptImporter`,
`DefaultImporter`, `PrefabImporter`, plus `ShaderImporter`/`MonoImporter`) each spell that walk
out by hand. Adding the five missing importers the ROADMAP tracked (`TextureImporter`,
`AudioImporter`, `ModelImporter`, `TrueTypeFontImporter`, `VideoClipImporter`) as five more
copies would have made nine near-identical `walk_standard` bodies, so the shared part lives here
instead.

Like every importer in this package, these are **reimplementations, not ports**: upstream's real
classes are generated IL from Unity's own serialization (AssetRipper.SourceGenerated, not
vendored -- see native_format_importer.py). What matters most for a usable exported project is
that the importer *class name* is right, because that is what makes Unity pick the correct
importer for the file at all; Unity fills in any field the `.meta` omits with that importer's
own defaults. So these deliberately carry the minimal common field set rather than inventing
detailed per-importer settings (texture compression, model rig options, ...) this port cannot
verify. That is a real improvement over the previous behavior -- where a `.png` got a
`NativeFormatImporter` block, i.e. the wrong importer entirely -- without fabricating values.

The pre-existing four importers are intentionally left as they are: they work, they're covered
by tests, and rewriting them onto this base would be churn with a regression risk and no user
-visible gain.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_serialization_logic.primitive_type import PrimitiveType


class AssetImporterBase(UnityAssetBase):
    """Walks `_leading_fields()` (importer-specific, may be empty) followed by the four fields
    every importer block ends with."""

    IMPORTER_CLASS_NAME = ""

    def __init__(self):
        self.user_data = ""
        self.asset_bundle_name: str | None = None
        self.asset_bundle_variant = ""

    @property
    def class_name(self) -> str:
        if not self.IMPORTER_CLASS_NAME:
            raise NotImplementedError("Subclasses must set IMPORTER_CLASS_NAME")
        return self.IMPORTER_CLASS_NAME

    def has_asset_bundle_name(self) -> bool:
        return True

    def _leading_fields(self) -> "list[tuple[str, object, PrimitiveType]]":
        """Fields emitted before `externalObjects`. Subclasses override; default is none."""
        return []

    def walk_standard(self, walker) -> None:
        if not walker.enter_asset(self):
            return

        fields = list(self._leading_fields())
        fields.append(("externalObjects", _EMPTY_DICTIONARY, None))
        fields.append(("userData", self.user_data, PrimitiveType.STRING))
        fields.append(("assetBundleName", self.asset_bundle_name or "", PrimitiveType.STRING))
        fields.append(("assetBundleVariant", self.asset_bundle_variant, PrimitiveType.STRING))

        for index, (name, value, primitive_type) in enumerate(fields):
            if index > 0:
                walker.divide_asset(self)
            if not walker.enter_field(self, name):
                continue
            if value is _EMPTY_DICTIONARY:
                if walker.enter_dictionary(()):
                    walker.exit_dictionary(())
            else:
                walker.visit_primitive(value, primitive_type)
            walker.exit_field(self, name)

        walker.exit_asset(self)


class _EmptyDictionary:
    """Sentinel for "emit an empty YAML mapping here" -- distinguishable from a real value,
    including from `None` or `""`, both of which are legitimate primitive values."""


_EMPTY_DICTIONARY = _EmptyDictionary()
