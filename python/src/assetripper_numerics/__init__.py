"""Python port of Source/AssetRipper.Numerics."""
from ._vecmath import Matrix4x4, Quaternion, Vector2, Vector3, Vector4
from .bone_weight import BoneWeight1, BoneWeight4
from .color32 import Color32
from .color_float import ColorFloat
from .discontinuous_range import DiscontinuousRange
from .geometric_math import angle_from_3_points
from .range_ import Range
from .transformation import Transformation
from .vector2i import Vector2i
from .vector3i import Vector3i

__all__ = [
    "Vector2",
    "Vector3",
    "Vector4",
    "Quaternion",
    "Matrix4x4",
    "BoneWeight1",
    "BoneWeight4",
    "Color32",
    "ColorFloat",
    "DiscontinuousRange",
    "Range",
    "Transformation",
    "Vector2i",
    "Vector3i",
    "angle_from_3_points",
]
