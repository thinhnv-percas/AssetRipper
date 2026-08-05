"""End-to-end tests for the shader content exporters (Export phase 6c):
SimpleShaderExporter (raw decompiled-text passthrough), DummyShaderTextExporter (template-
based reconstruction), and YamlShaderExporter (generic YAML + Editor patch scripts).
"""
import struct

from assetripper_assets.bundles.game_bundle import GameBundle
from assetripper_export_modules.registration import register_default_exporters
from assetripper_export_modules.shaders.dummy_shader_text_exporter import export_shader_text
from assetripper_export_modules.shaders.template_list import get_best_template
from assetripper_export_unity_projects.project_exporter import ProjectExporter
from assetripper_import.asset_creation.game_asset_factory import GameAssetFactory
from assetripper_io_files.build_target import BuildTarget
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_io_files.serialized_files import FormatVersion, SerializedFileBuilder
from assetripper_io_files.serialized_files.parser.object_info import ObjectInfo
from assetripper_io_files.serialized_files.parser.serialized_type import SerializedType
from assetripper_primitives import UnityVersion

from import_._tree_builder import node, string_nodes, tree, unity_string

FS = LocalFileSystem()
_V2019 = UnityVersion(2019, 4, 0)

# Shader (class 48): m_Name (string), m_Script (string).
_SHADER_TREE = tree(node("Shader", "Base", 0), *string_nodes("m_Name", 1), *string_nodes("m_Script", 1))


def _build_and_export(tmp_path, script_text: str):
    builder = SerializedFileBuilder(
        generation=FormatVersion.LARGE_FILES_SUPPORT,
        version=_V2019,
        platform=BuildTarget.STANDALONE_WIN64_PLAYER,
        has_type_tree=True,
    )
    type_ = SerializedType()
    type_.type_id = 48
    type_.is_stripped_type = False
    type_.script_type_index = -1
    type_.old_type = _SHADER_TREE

    obj = ObjectInfo(type_)
    obj.file_id = 1
    obj.serialized_type_index = 0
    obj.object_data = unity_string("MyShader") + unity_string(script_text)

    builder.types.append(type_)
    builder.objects.append(obj)
    serialized_file = builder.build()
    serialized_file.name = "sharedassets0"

    game_bundle = GameBundle()
    game_bundle.add_collection_from_serialized_file(serialized_file, GameAssetFactory())

    exporter = ProjectExporter()
    register_default_exporters(exporter)
    exporter.export(game_bundle, str(tmp_path), FS)


def test_decompiled_looking_shader_text_is_exported_verbatim(tmp_path):
    script = 'Shader "Custom/Foo" { SubShader { Pass { } } }'
    _build_and_export(tmp_path, script)

    shader_files = [p for p in tmp_path.rglob("*.shader") if p.is_file()]
    assert len(shader_files) == 1
    assert shader_files[0].read_text(encoding="utf-8") == script


def test_compiled_shader_falls_back_to_dummy_exporter(tmp_path):
    # "SubProgram" marks this as compiled bytecode text, not real decompiled source.
    script = "Shader Data\nSubProgram\n<binary-ish placeholder>"
    _build_and_export(tmp_path, script)

    shader_files = [p for p in tmp_path.rglob("*.shader") if p.is_file()]
    assert len(shader_files) == 1
    text = shader_files[0].read_text(encoding="utf-8")
    assert "//DummyShaderTextExporter" in text
    assert "SubProgram" not in text  # header before "SubShader" is dropped since there's none


def test_dummy_exporter_preserves_header_before_subshader():
    class _FakeAsset:
        def get(self, name, default=None):
            return {"m_Script": 'Shader "Kept" {\n\tSubShader {\n\t\t/* compiled */\n\t}\n}'}.get(name, default)

        def get_best_name(self):
            return "Unused"

    text = export_shader_text(_FakeAsset())
    assert text.startswith('Shader "Kept" {\n')
    assert "//DummyShaderTextExporter" in text


def test_dummy_exporter_uses_best_name_when_no_script():
    class _FakeAsset:
        def get(self, name, default=None):
            return {"m_Script": ""}.get(name, default)

        def get_best_name(self):
            return "GeneratedName"

    text = export_shader_text(_FakeAsset())
    assert text.startswith('Shader "GeneratedName" {\n')
    assert "Properties {\n\t}" in text


def test_get_best_template_defaults_to_default_template():
    template = get_best_template(shader=None)
    assert template.template_name == "Default"
