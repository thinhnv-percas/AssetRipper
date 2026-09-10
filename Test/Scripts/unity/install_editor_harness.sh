#!/usr/bin/env bash
# Puts the editor-side harness the scene, prefab and build validations call into the project. Written
# into the project rather than kept as a loose asset so a rip output is validated exactly as exported,
# with one added Editor script that is not part of the recovery.
set -u
project=${1:?usage: install_editor_harness.sh <unity project directory>}
target="$project/Assets/Editor/AssetRipperValidation"
mkdir -p "$target"

cat > "$target/Harness.cs" <<'CSHARP'
// Editor-side validation harness. Not part of the recovered project: installed by
// Test/Scripts/unity/install_editor_harness.sh so the blocked Unity suite has something to call.
//
// Every method exits the editor with a non-zero code on failure, because a batchmode run that
// reports success in its log and zero on its exit is indistinguishable from one that did nothing.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AssetRipperValidation
{
    public static class Harness
    {
        private const string Tag = "VALIDATION";

        public static void ValidateScenes()
        {
            var failures = 0;
            var scenes = EditorBuildSettings.scenes.Where(s => s != null).Select(s => s.path).ToList();

            if (scenes.Count == 0)
            {
                scenes = AssetDatabase.FindAssets("t:Scene")
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Where(p => p.StartsWith("Assets/", StringComparison.Ordinal))
                    .ToList();
            }

            Debug.Log($"{Tag}: {scenes.Count} scenes to open");

            foreach (var path in scenes)
            {
                try
                {
                    var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
                    if (!scene.IsValid())
                    {
                        Debug.LogError($"{Tag}: scene did not open: {path}");
                        failures++;
                        continue;
                    }

                    var missing = scene.GetRootGameObjects()
                        .SelectMany(root => root.GetComponentsInChildren<Component>(true))
                        .Count(component => component == null);

                    if (missing > 0)
                    {
                        Debug.LogError($"{Tag}: {missing} unresolved components in {path}");
                        failures++;
                    }
                    else
                    {
                        Debug.Log($"{Tag}: ok {path}");
                    }
                }
                catch (Exception exception)
                {
                    Debug.LogError($"{Tag}: {path} threw {exception.GetType().Name}: {exception.Message}");
                    failures++;
                }
            }

            Finish(failures, $"{scenes.Count} scenes");
        }

        public static void ValidateAssets()
        {
            var failures = 0;
            var checked_ = 0;

            foreach (var path in AssetDatabase.FindAssets("t:Prefab").Select(AssetDatabase.GUIDToAssetPath))
            {
                checked_++;
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (prefab == null)
                {
                    Debug.LogError($"{Tag}: prefab did not load: {path}");
                    failures++;
                    continue;
                }

                var missing = prefab.GetComponentsInChildren<Component>(true).Count(c => c == null);
                if (missing > 0)
                {
                    Debug.LogError($"{Tag}: {missing} unresolved components in {path}");
                    failures++;
                }
            }

            foreach (var path in AssetDatabase.FindAssets("t:ScriptableObject").Select(AssetDatabase.GUIDToAssetPath))
            {
                checked_++;
                if (AssetDatabase.LoadAssetAtPath<ScriptableObject>(path) == null)
                {
                    Debug.LogError($"{Tag}: ScriptableObject did not deserialise: {path}");
                    failures++;
                }
            }

            Finish(failures, $"{checked_} assets");
        }

        public static void BuildPlayer()
        {
            var scenes = EditorBuildSettings.scenes.Where(s => s != null && s.enabled).Select(s => s.path).ToArray();

            if (scenes.Length == 0)
            {
                Debug.LogError($"{Tag}: no enabled scenes in the build settings, nothing to build");
                EditorApplication.Exit(1);
                return;
            }

            var output = Path.Combine(Path.GetTempPath(), "assetripper-validation", "player.apk");
            Directory.CreateDirectory(Path.GetDirectoryName(output));

            var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = output,
                target = BuildTarget.Android,
                options = BuildOptions.None,
            });

            Debug.Log($"{Tag}: BuildResult {report.summary.result}, {report.summary.totalErrors} errors, output {output}");
            EditorApplication.Exit(report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded ? 0 : 1);
        }

        private static void Finish(int failures, string what)
        {
            if (failures > 0)
            {
                Debug.LogError($"{Tag}: {failures} failures over {what}");
                EditorApplication.Exit(1);
                return;
            }

            Debug.Log($"{Tag}: {what} validated with no failures");
            EditorApplication.Exit(0);
        }
    }
}
CSHARP

echo "installed $target/Harness.cs"
