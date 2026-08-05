"""Hand-written stand-in for `DefaultImporter` (generated, not vendored -- same situation as
native_format_importer.py). Used for `.unity` scene files' `.meta`.

Reconstructed from general familiarity with a real scene's `.meta` shape:

    DefaultImporter:
      externalObjects: {}
      userData:
      assetBundleName:
      assetBundleVariant:

This is a reimplementation, not a port; treat the exact field set as best-effort.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_serialization_logic.primitive_type import PrimitiveType


class DefaultImporter(UnityAssetBase):
    def __init__(self):
        self.user_data = ""
        self.asset_bundle_name: str | None = None
        self.asset_bundle_variant = ""

    @property
    def class_name(self) -> str:
        return "DefaultImporter"

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
