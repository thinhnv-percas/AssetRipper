namespace AssetRipper.Export.UnityProjects.NativePlugins;

/// <summary>What a native library a package ships is, and so whether a recovered project carries it.</summary>
public enum NativeLibraryKind
{
	/// <summary>The il2cpp runtime. The recovery replaces it, so carrying it ships the game twice.</summary>
	Il2CppRuntime,

	/// <summary>The Unity player. The editor provides it.</summary>
	UnityEngine,

	/// <summary>Burst's output, which a project recompiles from the managed source it already has.</summary>
	EngineBuildOutput,

	/// <summary>A library the platform or its language runtime supplies. The device has it.</summary>
	SystemLibrary,

	/// <summary>What the developer added. The only kind whose absence is a runtime blocker.</summary>
	GameNativePlugin,
}

/// <summary>
/// AssetRipper: names a native library by what supplies it, for both platforms this project rips.
/// </summary>
/// <remarks>
/// Kept apart from the exporter so that <c>Test/Scripts/runtime_dependency_graph.py</c> and the
/// export agree on what a missing plugin is: a measurement that classifies differently from the
/// thing it measures reports a rate nobody can act on. The rule is by name rather than by content
/// because the name is what the toolchain fixes - a library the developer added can contain
/// anything, while <c>libil2cpp.so</c>, <c>UnityFramework</c> and the Swift compatibility dylibs are
/// named by Unity and by Apple respectively.
/// </remarks>
public static class NativeLibraryClassifier
{
	/// <summary>Named rather than matched: getting either wrong ships the game twice or drops the engine.</summary>
	private static readonly string[] Il2CppRuntimeNames = ["libil2cpp.so", "libil2cpp.dylib"];

	/// <summary>
	/// <c>UnityFramework</c> carries both the player and il2cpp on iOS - Unity 2019.3 moved the
	/// player into an embedded framework - so it is one entry and the engine is what names it.
	/// </summary>
	private static readonly string[] UnityPlayerNames =
	[
		"libunity.so", "libmain.so", "libunity.dylib", "UnityFramework", "UnityFramework.framework",
	];

	private const string BurstOutput = "lib_burst_generated";

	private static readonly string[] SystemPrefixes =
	[
		"libc.", "libm.", "libdl.", "libz.", "liblog.", "libandroid", "libGLES", "libEGL",
		"libOpenSL", "libvulkan", "libstdc++", "libswift", "libsystem", "libobjc",
	];

	/// <param name="name">The library's file name, or a framework bundle's directory name.</param>
	public static NativeLibraryKind Classify(string name)
	{
		if (Array.IndexOf(Il2CppRuntimeNames, name) >= 0)
		{
			return NativeLibraryKind.Il2CppRuntime;
		}

		if (Array.IndexOf(UnityPlayerNames, name) >= 0)
		{
			return NativeLibraryKind.UnityEngine;
		}

		if (name.StartsWith(BurstOutput, StringComparison.Ordinal))
		{
			return NativeLibraryKind.EngineBuildOutput;
		}

		foreach (string prefix in SystemPrefixes)
		{
			if (name.StartsWith(prefix, StringComparison.Ordinal))
			{
				return NativeLibraryKind.SystemLibrary;
			}
		}

		return NativeLibraryKind.GameNativePlugin;
	}

	/// <summary>Whether a recovered project has to carry this library for the game to run.</summary>
	public static bool IsGamePlugin(string name) => Classify(name) == NativeLibraryKind.GameNativePlugin;
}
