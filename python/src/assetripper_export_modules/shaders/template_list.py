"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/TemplateList.cs

Templates are loaded once from this package's templates/ directory (a verbatim copy of
Source/AssetRipper.Export.UnityProjects/Shaders/Templates/) via importlib.resources,
mirroring upstream's embedded-manifest-resource loading.
"""
from __future__ import annotations

import json
from importlib import resources

from .template_shader import RequiredProperty, TemplateShader

_TEMPLATES_PACKAGE = "assetripper_export_modules.shaders.templates"
_TEMPLATE_EXTENSION = ".txt"

_templates: "list[TemplateShader] | None" = None


def get_templates() -> "list[TemplateShader]":
    global _templates
    if _templates is None:
        _templates = _load_templates()
    return _templates


def get_best_template(shader) -> "TemplateShader | None":
    matches = [template for template in get_templates() if template.is_match(shader)]
    if not matches:
        return None
    return max(matches, key=lambda template: len(template.required_properties))


def _load_templates() -> "list[TemplateShader]":
    templates_dir = resources.files(_TEMPLATES_PACKAGE)
    json_text = (templates_dir / "Templates.json").read_text(encoding="utf-8")
    data = json.loads(json_text)

    templates = []
    for entry in data["Templates"]:
        required_properties = [RequiredProperty.from_json(p) for p in entry.get("RequiredProperties", [])]
        template = TemplateShader(entry["TemplateName"], required_properties)
        template.shader_text = (templates_dir / (template.template_name + _TEMPLATE_EXTENSION)).read_text(
            encoding="utf-8"
        ).replace("\r", "")
        templates.append(template)
    return templates
