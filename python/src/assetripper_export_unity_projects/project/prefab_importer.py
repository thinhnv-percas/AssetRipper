"""Hand-written stand-in for `PrefabImporter` (generated, not vendored -- same situation as
native_format_importer.py). Used for `.prefab` files' `.meta` on modern (2018.3+) Unity,
where the prefab's root GameObject is treated as the file's implicit main asset with no
`mainObjectFileID` needed (unlike NativeFormatImporter) -- see
assetripper_processing/prefabs/synthetic_prefab_instance.py for why this port always uses
this importer rather than upstream's pre-2018.3 alternative.

Reconstructed from general familiarity with a real modern `.prefab.meta` shape:

    PrefabImporter:
      externalObjects: {}
      userData:
      assetBundleName:
      assetBundleVariant:

This is a reimplementation, not a port; treat the exact field set as best-effort.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_serialization_logic.primitive_type import PrimitiveType


class PrefabImporter(UnityAssetBase):
    def __init__(self):
        self.user_data = ""
        self.asset_bundle_name: str | None = None
        self.asset_bundle_variant = ""

    @property
    def class_name(self) -> str:
        return "PrefabImporter"

    def has_asset_bundle_name(self) -> bool:
        return True

    def walk_standard(self, walker) -> None:
        if not walker.enter_asset(self):
            return

        if walker.enter_field(self, "externalObjects"):
            if walker.enter_dictionary(()):
                walker.exit_dictionary(())
            walker.exit_field(self, "externalObjects")
        walker.divide_asset(self)

        if walker.enter_field(self, "userData"):
            walker.visit_primitive(self.user_data, PrimitiveType.STRING)
            walker.exit_field(self, "userData")
        walker.divide_asset(self)

        if walker.enter_field(self, "assetBundleName"):
            walker.visit_primitive(self.asset_bundle_name or "", PrimitiveType.STRING)
            walker.exit_field(self, "assetBundleName")
        walker.divide_asset(self)

        if walker.enter_field(self, "assetBundleVariant"):
            walker.visit_primitive(self.asset_bundle_variant, PrimitiveType.STRING)
            walker.exit_field(self, "assetBundleVariant")

        walker.exit_asset(self)
