"""Hand-written stand-in for `NativeFormatImporter` (Source/AssetRipper.SourceGenerated,
generated per Unity-version-range -- not vendored, see the project plan's rationale for
hand-written layouts). This is the importer real Unity uses for any asset serialized in
Unity's native YAML format (ScriptableObjects, prefabs, scenes, materials, ...), i.e. every
asset `AssetExportCollection`'s `DefaultYamlExporter` produces.

Reconstructed from general familiarity with Unity's own `.meta` file shape:

    NativeFormatImporter:
      externalObjects: {}
      mainObjectFileID: 11400000
      userData:
      assetBundleName:
      assetBundleVariant:

This is a reimplementation, not a port (there is no C# source to copy -- the real class is
generated IL); treat the exact field set as best-effort.
"""
from __future__ import annotations

from assetripper_assets.unity_asset_base import UnityAssetBase
from assetripper_serialization_logic.primitive_type import PrimitiveType


class NativeFormatImporter(UnityAssetBase):
    def __init__(self):
        self.main_object_file_id = 0
        self.user_data = ""
        self.asset_bundle_name: str | None = None
        self.asset_bundle_variant = ""

    @property
    def class_name(self) -> str:
        return "NativeFormatImporter"

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

        if walker.enter_field(self, "mainObjectFileID"):
            walker.visit_primitive(self.main_object_file_id, PrimitiveType.LONG)
            walker.exit_field(self, "mainObjectFileID")
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
