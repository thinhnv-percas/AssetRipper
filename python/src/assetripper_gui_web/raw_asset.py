"""
A stand-in for AssetRipper's SourceGenerated typed asset classes.

The real C# GameFileLoader loads files through AssetRipper.Import + AssetRipper.Processing,
which use Mono.Cecil to read the AssemblyDumper-generated C# classes matching each Unity
class ID (Texture2D, GameObject, MonoBehaviour, ...). That whole pipeline is out of scope for
this Python port (it depends on IL analysis of compiled .NET assemblies).

Instead, RawAsset wraps each ObjectInfo's raw, undecoded bytes so the GUI can still list and
inspect a SerializedFile's objects (info + hex views) without understanding their field layout.
"""
from __future__ import annotations

from assetripper_assets.unity_object_base import UnityObjectBase


class RawAsset(UnityObjectBase):
    def __init__(self, asset_info, object_data: bytes = b"", type_id: int = 0):
        super().__init__(asset_info)
        self.object_data = object_data
        self.type_id = type_id

    @property
    def class_name(self) -> str:
        return f"UnknownType_{self.type_id}"


class RawAssetFactory:
    """Minimal stand-in for AssetRipper.Import's AssetFactory, matching the
    `factory.read_asset(asset_info, object_data, type)` call in
    SerializedAssetCollection._read_data. It does not decode object_data at all --
    it is stored as-is on the RawAsset for hex/info display only."""

    def read_asset(self, asset_info, object_data: bytes, type_):
        return RawAsset(asset_info, object_data, asset_info.class_id)
