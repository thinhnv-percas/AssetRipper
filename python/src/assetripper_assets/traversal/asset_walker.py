"""Port of Source/AssetRipper.Assets/Traversal/AssetWalker.cs

Abstract base class for traversing objects that implement IUnityAssetBase. Subclasses
override only the hooks they care about; the defaults are no-ops that continue traversal.

C#'s generic parameters (`EnterList<T>`, `VisitPrimitive<T>`, `VisitPPtr<TAsset>`) carry no
runtime meaning here, so they collapse to plain methods. The two `VisitPPtr` overloads
(one taking IPPtr<TAsset>, one taking PPtr<TAsset>) collapse into one, since this port has
a single concrete PPtr type.
"""
from __future__ import annotations


class AssetWalker:
    # -- assets --

    def enter_asset(self, asset) -> bool:
        """Return True to visit the asset's children, False to skip them (in which case
        the matching exit method is not called either)."""
        return True

    def divide_asset(self, asset) -> None:
        """Called between two fields of the same asset."""

    def exit_asset(self, asset) -> None:
        pass

    # -- fields --

    def enter_field(self, asset, name: str) -> bool:
        return True

    def exit_field(self, asset, name: str) -> None:
        pass

    # -- lists --

    def enter_list(self, list_) -> bool:
        return True

    def divide_list(self, list_) -> None:
        pass

    def exit_list(self, list_) -> None:
        pass

    # -- dictionaries --

    def enter_dictionary(self, dictionary) -> bool:
        return True

    def divide_dictionary(self, dictionary) -> None:
        pass

    def exit_dictionary(self, dictionary) -> None:
        pass

    def enter_dictionary_pair(self, pair) -> bool:
        return True

    def divide_dictionary_pair(self, pair) -> None:
        pass

    def exit_dictionary_pair(self, pair) -> None:
        pass

    # -- pairs --

    def enter_pair(self, pair) -> bool:
        return True

    def divide_pair(self, pair) -> None:
        pass

    def exit_pair(self, pair) -> None:
        pass

    # -- leaves --

    def visit_primitive(self, value) -> None:
        """Visit a primitive leaf node. `bytes` is treated as a primitive."""

    def visit_pptr(self, pptr) -> None:
        pass
