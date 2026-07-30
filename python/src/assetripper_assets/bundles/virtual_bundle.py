"""
Port of Source/AssetRipper.Assets/Bundles/VirtualBundle.cs

C#'s `VirtualBundle<T>` is generic over the VirtualAssetCollection subtype it accepts;
Python subclasses set `collection_type` as a class attribute instead of a type parameter.
"""
from __future__ import annotations

from .bundle import Bundle


class VirtualBundle(Bundle):
    collection_type: type = object

    def _is_compatible_bundle(self, bundle: Bundle) -> bool:
        return isinstance(bundle, VirtualBundle) and bundle.collection_type is self.collection_type

    def _is_compatible_collection(self, collection) -> bool:
        return isinstance(collection, self.collection_type)
