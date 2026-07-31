"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/*.cs (SimpleShaderExporter,
DummyShaderTextExporter, YamlShaderExporter, and their supporting Template* classes).

Unlike most of this port's "reconstructed from general knowledge" disclaimers, the shader
templates themselves (templates/*.txt, templates/Templates.json) ARE a real, faithful port
-- copied verbatim from Source/AssetRipper.Export.UnityProjects/Shaders/Templates/, which
is checked into this repo (unlike the Tpk type-tree database).

What's scoped down: `DummyShaderTextExporter`'s Properties-block declaration normally lists
each of the shader's real parsed properties (name, type, default value, attributes) by
reading generated `ISerializedProperty` interface members whose exact type-tree field names
aren't confirmed here. Rather than guess, this port always emits an empty `Properties {}`
block and treats every shader as having no matchable properties (see template_shader.py),
so `TemplateList.get_best_template` always resolves to "Default" here -- a safe, working
simplification, not a silently wrong one: a template requiring properties is simply never
selected, rather than selected against fabricated property data.
"""
