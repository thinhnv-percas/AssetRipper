"""Hand-written stand-in for `ShaderImporter` (generated, not vendored -- same situation
as native_format_importer.py). Used for Shader's `.meta` file.

Reconstructed from general familiarity with Unity's `.meta` shape for shaders:

    ShaderImporter:
      externalObjects: {}
      defaultTextures: []
      nonModifiableTextures: []
      preprocessorOverride: 0
      userData:
      assetBundleName:
      assetBundleVariant:

Upstream also populates `nonModifiableTextures` with the shader's real PPtr references;
that is not done here (uncertain field names, see this package's shaders/__init__.py
equivalent disclaimer) -- it's always emitted as an empty array. This is a
reimplementation, not a port; treat the exact field set as best-effort.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_serialization_logic.primitive_type import PrimitiveType


class ShaderImporter(UnityAssetBase):
    def __init__(self):
        self.preprocessor_override = 0
        self.user_data = ""
        self.asset_bundle_name: str | None = None
        self.asset_bundle_variant = ""

    @property
    def class_name(self) -> str:
        return "ShaderImporter"

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

        for field_name in ("defaultTextures", "nonModifiableTextures"):
            if walker.enter_field(self, field_name):
                if walker.enter_list((), None):
                    walker.exit_list((), None)
                walker.exit_field(self, field_name)
            walker.divide_asset(self)

        if walker.enter_field(self, "preprocessorOverride"):
            walker.visit_primitive(self.preprocessor_override, PrimitiveType.INT)
            walker.exit_field(self, "preprocessorOverride")
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
