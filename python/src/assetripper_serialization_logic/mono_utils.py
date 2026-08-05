"""Port of Source/AssetRipper.SerializationLogic/MonoUtils.cs

Only the string-based `(namespace, name)` overloads are ported. Every `ITypeDefOrRef`
overload, and `to_primitive_type(ITypeDefOrRef, RuntimeContext)` (which resolves enum
underlying types through .NET metadata), belong to the IL-based path this port omits.
"""
from __future__ import annotations

from .primitive_type import PrimitiveType

OBJECT_NAME = "Object"
C_OBJECT_NAME = "object"
VALUE_TYPE = "ValueType"
VOID_NAME = "Void"
C_VOID_NAME = "void"
BOOLEAN_NAME = "Boolean"
BOOL_NAME = "bool"
INT_PTR_NAME = "IntPtr"
UINT_PTR_NAME = "UIntPtr"
CHAR_NAME = "Char"
C_CHAR_NAME = "char"
SBYTE_NAME = "SByte"
C_SBYTE_NAME = "sbyte"
BYTE_NAME = "Byte"
C_BYTE_NAME = "byte"
INT16_NAME = "Int16"
SHORT_NAME = "short"
UINT16_NAME = "UInt16"
USHORT_NAME = "ushort"
INT32_NAME = "Int32"
INT_NAME = "int"
UINT32_NAME = "UInt32"
UINT_NAME = "uint"
INT64_NAME = "Int64"
LONG_NAME = "long"
UINT64_NAME = "UInt64"
ULONG_NAME = "ulong"
HALF_NAME = "Half"
SINGLE_NAME = "Single"
FLOAT_NAME = "float"
DOUBLE_NAME = "Double"
C_DOUBLE_NAME = "double"
STRING_NAME = "String"
C_STRING_NAME = "string"

SYSTEM_NAMESPACE = "System"
SYSTEM_COLLECTION_GENERIC_NAMESPACE = "System.Collections.Generic"
UNITY_ENGINE_NAMESPACE = "UnityEngine"
UNITY_ENGINE_RENDERING_NAMESPACE = "UnityEngine.Rendering"
COMPILER_SERVICES_NAMESPACE = "System.Runtime.CompilerServices"

COMPILER_GENERATED_NAME = "CompilerGeneratedAttribute"

GUID_NAME = "GUID"
HASH128_NAME = "Hash128"

VECTOR2_NAME = "Vector2"
VECTOR2INT_NAME = "Vector2Int"
VECTOR3_NAME = "Vector3"
VECTOR3INT_NAME = "Vector3Int"
VECTOR4_NAME = "Vector4"
RECT_NAME = "Rect"
BOUNDS_NAME = "Bounds"
BOUNDS_INT_NAME = "BoundsInt"
QUATERNION_NAME = "Quaternion"
MATRIX4X4_NAME = "Matrix4x4"
COLOR_NAME = "Color"
COLOR32_NAME = "Color32"
LAYER_MASK_NAME = "LayerMask"
FLOAT_CURVE_NAME = "FloatCurve"
VECTOR3_CURVE_NAME = "Vector3Curve"
QUATERNION_CURVE_NAME = "QuaternionCurve"
PPTR_CURVE_NAME = "PPtrCurve"
ANIMATION_CURVE_NAME = "AnimationCurve"
GRADIENT_NAME = "Gradient"
RECT_OFFSET_NAME = "RectOffset"
GUI_STYLE_NAME = "GUIStyle"
PROPERTY_NAME_NAME = "PropertyName"
SPHERICAL_HARMONICS_L2_NAME = "SphericalHarmonicsL2"

_MULTICAST_DELEGATE_NAME = "MulticastDelegate"
_LIST_NAME = "List`1"
_EXPOSED_REFERENCE_NAME = "ExposedReference`1"

_SCRIPTABLE_OBJECT_NAME = "ScriptableObject"
_COMPONENT_NAME = "Component"
_BEHAVIOUR_NAME = "Behaviour"
_MONO_BEHAVIOUR_NAME = "MonoBehaviour"

_PRIMITIVE_NAMES = frozenset({
    VOID_NAME, C_VOID_NAME,
    BOOLEAN_NAME, BOOL_NAME,
    SBYTE_NAME, C_SBYTE_NAME,
    BYTE_NAME, C_BYTE_NAME,
    CHAR_NAME, C_CHAR_NAME,
    INT16_NAME, SHORT_NAME,
    UINT16_NAME, USHORT_NAME,
    INT32_NAME, INT_NAME,
    UINT32_NAME, UINT_NAME,
    INT64_NAME, LONG_NAME,
    UINT64_NAME, ULONG_NAME,
    SINGLE_NAME, FLOAT_NAME,
    DOUBLE_NAME, C_DOUBLE_NAME,
})

_ENGINE_STRUCT_NAMES = frozenset({
    GUID_NAME, HASH128_NAME,
    VECTOR2_NAME, VECTOR2INT_NAME,
    VECTOR3_NAME, VECTOR3INT_NAME,
    VECTOR4_NAME,
    RECT_NAME, BOUNDS_NAME, BOUNDS_INT_NAME,
    QUATERNION_NAME, MATRIX4X4_NAME,
    COLOR_NAME, COLOR32_NAME,
    LAYER_MASK_NAME, ANIMATION_CURVE_NAME,
    GRADIENT_NAME, RECT_OFFSET_NAME,
    GUI_STYLE_NAME, PROPERTY_NAME_NAME,
})

_SYSTEM_TO_PRIMITIVE = {
    VOID_NAME: PrimitiveType.VOID,
    BOOLEAN_NAME: PrimitiveType.BOOL,
    CHAR_NAME: PrimitiveType.CHAR,
    SBYTE_NAME: PrimitiveType.SBYTE,
    BYTE_NAME: PrimitiveType.BYTE,
    INT16_NAME: PrimitiveType.SHORT,
    UINT16_NAME: PrimitiveType.USHORT,
    INT32_NAME: PrimitiveType.INT,
    UINT32_NAME: PrimitiveType.UINT,
    INT64_NAME: PrimitiveType.LONG,
    UINT64_NAME: PrimitiveType.ULONG,
    SINGLE_NAME: PrimitiveType.SINGLE,
    DOUBLE_NAME: PrimitiveType.DOUBLE,
    STRING_NAME: PrimitiveType.STRING,
}


def is_primitive(namespace: str | None, name: str | None) -> bool:
    return namespace == SYSTEM_NAMESPACE and name in _PRIMITIVE_NAMES


def is_object(namespace: str | None, name: str | None) -> bool:
    return namespace == SYSTEM_NAMESPACE and name in (OBJECT_NAME, C_OBJECT_NAME)


def is_list(namespace: str | None, name: str | None) -> bool:
    return namespace == SYSTEM_COLLECTION_GENERIC_NAMESPACE and name == _LIST_NAME


def is_engine_object(namespace: str | None, name: str | None) -> bool:
    return namespace == UNITY_ENGINE_NAMESPACE and name == OBJECT_NAME


def is_scriptable_object(namespace: str | None, name: str | None) -> bool:
    return namespace == UNITY_ENGINE_NAMESPACE and name == _SCRIPTABLE_OBJECT_NAME


def is_component(namespace: str | None, name: str | None) -> bool:
    return namespace == UNITY_ENGINE_NAMESPACE and name == _COMPONENT_NAME


def is_behaviour(namespace: str | None, name: str | None) -> bool:
    return namespace == UNITY_ENGINE_NAMESPACE and name == _BEHAVIOUR_NAME


def is_mono_behaviour(namespace: str | None, name: str | None) -> bool:
    return namespace == UNITY_ENGINE_NAMESPACE and name == _MONO_BEHAVIOUR_NAME


def is_engine_struct(namespace: str | None, name: str | None) -> bool:
    if namespace == UNITY_ENGINE_NAMESPACE:
        return name in _ENGINE_STRUCT_NAMES
    elif namespace == UNITY_ENGINE_RENDERING_NAMESPACE:
        return name == SPHERICAL_HARMONICS_L2_NAME
    return False


def is_exposed_reference(namespace: str | None, name: str | None) -> bool:
    return namespace == UNITY_ENGINE_NAMESPACE and name == _EXPOSED_REFERENCE_NAME


def is_mono_prime(namespace: str | None, name: str | None) -> bool:
    return (
        is_mono_behaviour(namespace, name)
        or is_behaviour(namespace, name)
        or is_component(namespace, name)
        or is_engine_object(namespace, name)
    )


def is_prime(namespace: str | None, name: str | None) -> bool:
    return is_object(namespace, name) or is_mono_prime(namespace, name)


def is_builtin_generic(namespace: str | None, name: str | None) -> bool:
    return is_list(namespace, name) or is_exposed_reference(namespace, name)


def to_primitive_type(namespace: str | None, name: str | None) -> PrimitiveType:
    if namespace == SYSTEM_NAMESPACE:
        return _SYSTEM_TO_PRIMITIVE.get(name, PrimitiveType.COMPLEX)
    return PrimitiveType.COMPLEX
