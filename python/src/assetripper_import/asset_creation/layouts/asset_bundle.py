"""
Hand-written layout for AssetBundle (class ID 142).

Lower confidence than the other layouts in this package: AssetBundle has accumulated
several fields over Unity's lifetime (m_IsStreamedSceneAssetBundle, m_ExplicitDataLayout,
m_PathFlags, m_SceneHashes among them), and this layout only models the core fields common
across versions, in the order believed to be original: m_Name, m_PreloadTable (a flat list
of every asset referenced by any container entry), m_Container (path -> AssetInfo map),
m_MainAsset, m_RuntimeCompatibility, m_AssetBundleName, m_Dependencies. Newer files carrying
the later fields will consume fewer bytes than are actually present and correctly fail the
exact-byte-count check in SerializableStructure.read (see the layouts package docstring),
rather than silently misreading the trailing fields as something else.
"""
from __future__ import annotations

from assetripper_primitives import UnityVersion

from .builder import leaf, map_field, pptr_field, root, string_field, struct_, vector_field

_CLASS_ID = 142


def _asset_info(name: str):
    return struct_(
        "AssetInfo",
        name,
        leaf("int", "preloadIndex"),
        leaf("int", "preloadSize"),
        pptr_field("asset", "Object"),
    )


def _build(version: UnityVersion):
    return root(
        "AssetBundle",
        string_field("m_Name"),
        vector_field("m_PreloadTable", pptr_field("data", "Object")),
        map_field("m_Container", string_field("key"), _asset_info("value")),
        _asset_info("m_MainAsset"),
        leaf("unsigned int", "m_RuntimeCompatibility"),
        string_field("m_AssetBundleName"),
        vector_field("m_Dependencies", string_field("data")),
    )


def register(registry) -> None:
    registry.register(_CLASS_ID, _build)
