"""Port of Source/AssetRipper.Export.UnityProjects/Shaders/{YamlShaderExporter,
YamlShaderExportCollection}.cs

Exports a shader as generic YAML (like DefaultYamlExporter) but forced to the `.asset`
extension -- a YAML-exported shader can't use `.shader` or the Unity Editor would try to
compile it as real shader source and fail. Also writes two small Editor patch scripts
(verbatim copies of upstream's, not reconstructed) into the project so a YAML-exported
shader still works with `Shader.Find()` and doesn't get corrupted if Unity resaves it.
"""
from __future__ import annotations

from assetripper_export_unity_projects.asset_export_collection import AssetExportCollection
from assetripper_export_unity_projects.project.unity_patches import apply_patch_from_text
from assetripper_export_unity_projects.project.yaml_exporter_base import YamlExporterBase

_SHADER_CLASS_ID = 48
_ASSET_EXTENSION = "asset"

_REGISTER_SHADER_PATCH_NAME = "YamlShaderPostprocessor"
_FILE_LOCKER_PATCH_NAME = "AvoidSavingYamlShaders"

_REGISTER_SHADER_PATCH_TEXT = """using System;
using UnityEngine;
using UnityEditor;

namespace AssetRipperPatches.Editor
{
	/// <summary>
	/// This script is AssetRipper's patch for shaders exported as YAML assets.
	/// Such a shader can be assigned to and used by a material as a regular .shader asset,
	/// but it does not work with Shader.Find() unless we explicitly register it.
	/// Note that this patch only works for a limited range of Unity versions
	/// since it uses ShaderUtil.RegisterShader(), which is only available in Unity 2018+.
	/// </summary>
	public class YamlShaderPostprocessor : AssetPostprocessor
	{
		static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
		{
			foreach (var importedAsset in importedAssets)
			{
				if (!importedAsset.EndsWith(".asset", StringComparison.Ordinal)) continue;
				Shader yamlShader = AssetDatabase.LoadMainAssetAtPath(importedAsset) as Shader;
				if (yamlShader == null) continue;
				ShaderUtil.RegisterShader(yamlShader);
				Debug.Log($"Registered shader \\"{yamlShader.name}\\" from {importedAsset}");
			}
		}
	}
}
"""

_FILE_LOCKER_PATCH_TEXT = """using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AssetRipperPatches.Editor
{
	/// <summary>
	/// This script is AssetRipper's patch for shaders exported as YAML assets.
	/// Such a shader asset can be corrupted if Unity Editor thinks it is dirty and tries to save it.
	/// Manual repro of the issue is easy as a simple call of EditorUtility.SetDirty(someYamlShaderAsset) followed by a Save Project.
	/// Hence we use this script to prevent Unity from saving YAML shader assets.
	/// </summary>
	class AvoidSavingYamlShaders
		// AssetModificationProcessor is a new API added since Unity 3.5. However, it is not in the UnityEditor namespace until Unity 4.0.
#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5 || UNITY_2017_1_OR_NEWER
		: UnityEditor.AssetModificationProcessor
#elif UNITY_3_5
		: AssetModificationProcessor
#endif
	{
		private static readonly List<string> _pathList = new List<string>();

		private static string[] OnWillSaveAssets(string[] paths)
		{
			_pathList.Clear();
			foreach (string path in paths)
			{
				if (path.EndsWith(".asset", StringComparison.Ordinal) && AssetDatabase.LoadMainAssetAtPath(path) is Shader)
				{
					Debug.Log(string.Format("Unity's attempt to overwrite the YAML Shader asset has been blocked: {0}", path));
				}
				else
				{
					_pathList.Add(path);
				}
			}
			return _pathList.ToArray();
		}
	}
}
"""


class YamlShaderExportCollection(AssetExportCollection):
    def _get_export_extension(self, asset) -> str:
        return _ASSET_EXTENSION

    def _export_inner(self, container, file_path: str, project_directory: str, file_system) -> bool:
        if container.export_version.greater_than_or_equals(2018, 1, 0):
            apply_patch_from_text(_REGISTER_SHADER_PATCH_TEXT, _REGISTER_SHADER_PATCH_NAME, project_directory, file_system)
        if container.export_version.greater_than_or_equals(3, 5, 0):
            apply_patch_from_text(_FILE_LOCKER_PATCH_TEXT, _FILE_LOCKER_PATCH_NAME, project_directory, file_system)
        return super()._export_inner(container, file_path, project_directory, file_system)


class YamlShaderExporter(YamlExporterBase):
    def try_create_collection(self, asset) -> "tuple[bool, object]":
        if asset.class_id == _SHADER_CLASS_ID:
            return True, YamlShaderExportCollection(self, asset)
        return False, None
