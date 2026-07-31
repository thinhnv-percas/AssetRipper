"""Hand-written stand-in for `MonoImporter` (generated, not vendored -- same situation as
native_format_importer.py). Used for MonoScript's `.meta` file.

Reconstructed from general familiarity with Unity's `.meta` shape for scripts:

    MonoImporter:
      externalObjects: {}
      serializedVersion: 2
      defaultReferences: []
      executionOrder: 0
      icon: {instanceID: 0}
      userData:
      assetBundleName:
      assetBundleVariant:

This is a reimplementation, not a port; treat the exact field set as best-effort.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_serialization_logic.primitive_type import PrimitiveType


class MonoImporter(UnityAssetBase):
    def __init__(self):
        self.execution_order = 0
        self.user_data = ""
        self.asset_bundle_name: str | None = None
        self.asset_bundle_variant = ""

    @property
    def serialized_version(self) -> int:
        return 2

    @property
    def class_name(self) -> str:
        return "MonoImporter"

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

        if walker.enter_field(self, "defaultReferences"):
            if walker.enter_list((), None):
                walker.exit_list((), None)
            walker.exit_field(self, "defaultReferences")
        walker.divide_asset(self)

        if walker.enter_field(self, "executionOrder"):
            walker.visit_primitive(self.execution_order, PrimitiveType.SHORT)
            walker.exit_field(self, "executionOrder")
        walker.divide_asset(self)

        if walker.enter_field(self, "icon"):
            walker.visit_pptr(_ZERO_PPTR)
            walker.exit_field(self, "icon")
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


class _ZeroPPtr:
    __slots__ = ("file_id", "path_id")

    def __init__(self):
        self.file_id = 0
        self.path_id = 0


_ZERO_PPTR = _ZeroPPtr()
