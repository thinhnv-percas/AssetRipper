"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/{TemplateShader,RequiredProperty,
PropertyType}.cs

`TemplateShader.is_match` always returns True for a template with no required properties
(e.g. "Default") and False otherwise, since this port doesn't confidently expose a shader's
parsed property list (see this package's __init__.py docstring) to match against.
"""
from __future__ import annotations

from enum import IntEnum


class PropertyType(IntEnum):
    COLOR = 0
    VECTOR = 1
    SINGLE = 2
    RANGE = 3
    TEXTURE = 4


class RequiredProperty:
    __slots__ = ("property_name", "property_type")

    def __init__(self, property_name: str = "", property_type: PropertyType = PropertyType.COLOR):
        self.property_name = property_name
        self.property_type = property_type

    @staticmethod
    def from_json(data: dict) -> "RequiredProperty":
        return RequiredProperty(data["PropertyName"], PropertyType[data["PropertyTypeName"].upper()])


class TemplateShader:
    __slots__ = ("template_name", "required_properties", "shader_text")

    def __init__(self, template_name: str = "", required_properties: "list[RequiredProperty] | None" = None):
        self.template_name = template_name
        self.required_properties = required_properties if required_properties is not None else []
        self.shader_text = ""

    def is_match(self, shader) -> bool:
        """`shader` is unused -- see module docstring. Kept as a parameter for parity with
        upstream's `IsMatch(IShader shader)` signature."""
        return len(self.required_properties) == 0
