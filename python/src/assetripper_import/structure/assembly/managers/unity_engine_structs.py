"""Phase 16f: hardcoded `SerializableType` layouts for a handful of built-in UnityEngine value
structs, used when `mono_manager.py` recovers a MonoBehaviour field typed as one of them.

No upstream C# file to port -- this stands in for the generated `GameAssetFactory.
CreateEngineAsset` classes that `serializable_value.py`'s `_create_instance` docstring notes
are missing here. Those fields' real .NET assembly (UnityEngine.CoreModule.dll) is not parsed
by this port (see mono_manager.py: only the game's own script assembly is read), so their
field layout can't be *recovered* the way a user script's can -- it has to be supplied.

Deliberately narrow: only structs whose serialized field names are public, stable Unity API
knowledge this port is highly confident about (several already independently confirmed by this
repo's own TypeTree test fixtures in tests/import_/_tree_builder.py's `rect_nodes`/
`vector2_nodes`/`vector4_nodes` helpers, which encode the exact same field names against real
`SerializableTreeType` behavior). Every other name in `mono_utils._ENGINE_STRUCT_NAMES`
(Bounds, BoundsInt, Matrix4x4, LayerMask, RectOffset, GUID, Hash128, Vector2Int, Vector3Int,
SphericalHarmonicsL2, AnimationCurve, Gradient, GUIStyle, PropertyName) is deliberately NOT
included: several of those use non-obvious private backing-field names (Vector2Int/Vector3Int
serialize `m_X`/`m_Y`/`m_Z`, not bare `x`/`y`/`z`; Bounds serializes `m_Center`/`m_Extent`, not
`m_Extents`) or genuinely complex nested shapes (AnimationCurve/Gradient/GUIStyle) this port
has no real fixture to verify against -- guessing wrong here would silently misalign every
field after it in the containing MonoBehaviour, which is worse than declining. A field of one
of those un-hardcoded types causes `mono_manager.get_serializable_type` to decline the whole
containing type (see its docstring), the same safe-default this port uses whenever a type
can't be confidently resolved.
"""
from __future__ import annotations

from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_serialization_logic.serializable_type import Field, SerializableType

_UNITY_ENGINE = "UnityEngine"


def _struct(name: str, field_names: "tuple[str, ...]", primitive: PrimitiveType) -> SerializableType:
    result = SerializableType(_UNITY_ENGINE, PrimitiveType.COMPLEX, name)
    leaf = SerializableType("System", primitive, "Byte" if primitive == PrimitiveType.BYTE else "Single")
    leaf.max_depth = 0
    result.fields = [Field(leaf, 0, field_name, False) for field_name in field_names]
    result.max_depth = 1
    return result


_TEMPLATES = {
    ("UnityEngine", "Vector2"): lambda: _struct("Vector2", ("x", "y"), PrimitiveType.SINGLE),
    ("UnityEngine", "Vector3"): lambda: _struct("Vector3", ("x", "y", "z"), PrimitiveType.SINGLE),
    ("UnityEngine", "Vector4"): lambda: _struct("Vector4", ("x", "y", "z", "w"), PrimitiveType.SINGLE),
    ("UnityEngine", "Quaternion"): lambda: _struct("Quaternion", ("x", "y", "z", "w"), PrimitiveType.SINGLE),
    ("UnityEngine", "Color"): lambda: _struct("Color", ("r", "g", "b", "a"), PrimitiveType.SINGLE),
    ("UnityEngine", "Color32"): lambda: _struct("Color32", ("r", "g", "b", "a"), PrimitiveType.BYTE),
    ("UnityEngine", "Rect"): lambda: _struct("Rect", ("x", "y", "width", "height"), PrimitiveType.SINGLE),
}

_cache: "dict[tuple[str, str], SerializableType]" = {}


def get(namespace: str, name: str) -> "SerializableType | None":
    key = (namespace, name)
    if key in _cache:
        return _cache[key]
    factory = _TEMPLATES.get(key)
    if factory is None:
        return None
    result = factory()
    _cache[key] = result
    return result
