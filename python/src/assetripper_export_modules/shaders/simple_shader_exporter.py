"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/SimpleShaderExporter.cs

The simple, high-confidence case: a Shader asset whose `m_Script` field already holds real
decompiled-looking shader source (not a "Program"/"SubProgram" compiled-bytecode marker) --
export it verbatim.
"""
from __future__ import annotations

from .shader_export_collection import ShaderExportCollection
from .shader_exporter_base import ShaderExporterBase

_SHADER_CLASS_ID = 48


class SimpleShaderExporter(ShaderExporterBase):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _SHADER_CLASS_ID:
            script = asset.get("m_Script")
            if script and _has_decompiled_shader_text(script):
                return True, ShaderExportCollection(self, asset)
        return False, None

    def export(self, container, asset, path: str, file_system) -> bool:
        script = asset.get("m_Script") or ""
        with file_system.file.create(path) as stream:
            data = script.encode("utf-8")
            stream.write(data, 0, len(data))
        return True


def _has_decompiled_shader_text(text: str) -> bool:
    return bool(text) and "Program" not in text and "SubProgram" not in text
