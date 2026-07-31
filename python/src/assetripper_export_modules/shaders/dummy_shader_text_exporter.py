"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/DummyShaderTextExporter.cs,
scoped down (see this package's __init__.py docstring for the properties-block caveat and
why GetBestTemplate always resolves to "Default" here).

Also not ported: the `ParsedForm`-driven branch that preserves the shader's declared name/
Fallback/CustomEditor from `m_ParsedForm` -- those field names aren't confirmed with
confidence, so `asset.get_best_name()` (existing, confident infrastructure) stands in for
the shader name, and Fallback/CustomEditor lines are omitted rather than fabricated.
"""
from __future__ import annotations

from .shader_exporter_base import ShaderExporterBase
from .template_list import get_best_template

_INDENT = "\t"

# Same fallback shader body upstream uses when no template matches (never happens here,
# since "Default" always matches -- kept for parity and as a last-resort safety net).
_FALLBACK_DUMMY_SHADER = """
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Lambert
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
"""


class DummyShaderTextExporter(ShaderExporterBase):
    def export(self, container, asset, path: str, file_system) -> bool:
        text = export_shader_text(asset)
        if text is None:
            return False
        with file_system.file.create(path) as stream:
            data = text.encode("utf-8")
            stream.write(data, 0, len(data))
        return True


def export_shader_text(shader) -> "str | None":
    script = shader.get("m_Script") or ""
    subshader_index = script.find("SubShader")

    template = get_best_template(shader)
    body = template.shader_text if template is not None else _FALLBACK_DUMMY_SHADER

    lines = []
    if subshader_index >= 0:
        lines.append(script[:subshader_index])
    else:
        lines.append(f'Shader "{shader.get_best_name()}" {{\n')
        lines.append(f"{_INDENT}Properties {{\n{_INDENT}}}\n")

    lines.append(f"{_INDENT}//DummyShaderTextExporter\n")
    lines.append(body)
    lines.append("\n}")
    return "".join(lines)
