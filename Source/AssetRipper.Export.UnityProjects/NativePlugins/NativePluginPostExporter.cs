using AssetRipper.Export.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Processing;

namespace AssetRipper.Export.UnityProjects.NativePlugins;

/// <summary>
/// AssetRipper: copies the native libraries the game shipped into the places Unity looks for a
/// plugin, and only those.
/// </summary>
/// <remarks>
/// <para>
/// A recovered project had no native libraries at all, which is a runtime blocker wherever the game
/// reaches one: <c>Lofelt.NiceVibrations</c> is a recovered assembly whose whole job is to P/Invoke
/// into <c>liblofelt_sdk.so</c>, and without the library every call into it fails the moment it runs.
/// Nothing in the export carried it, because an APK's <c>lib/</c> is not an asset and no exporter
/// looked there.
/// </para>
/// <para>
/// Which libraries to copy is the whole question, and four kinds must NOT be copied: the il2cpp
/// runtime, because the recovery replaces it and copying it ships the game twice; the Unity player,
/// because the editor provides it; Burst's output, because a project compiles that from the managed
/// source it already has; and the platform's own libraries, because the device has them. What is left
/// is what the developer added, and that is what a project has to carry.
/// </para>
/// <para>
/// The four kinds are the same ones <c>Test/Scripts/runtime_dependency_graph.py</c> reports, so the
/// measurement and the export agree about what a missing plugin is.
/// </para>
/// </remarks>
public sealed class NativePluginPostExporter : IPostExporter
{
	/// <summary>The libraries the recovery replaces, named rather than matched: getting either wrong
	/// ships the game twice or drops the engine.</summary>
	private static readonly string[] ReplacedByRecovery = ["libil2cpp.so", "UnityFramework"];

	private static readonly string[] UnityPlayer = ["libunity.so", "libmain.so", "libunity.dylib"];

	/// <summary>Burst compiles this from the managed source at build time, so a project regenerates it.</summary>
	private const string BurstOutput = "lib_burst_generated";

	private static readonly string[] SystemPrefixes =
	[
		"libc.", "libm.", "libdl.", "libz.", "liblog.", "libandroid", "libGLES", "libEGL",
		"libOpenSL", "libvulkan", "libstdc++", "libswift", "libsystem", "libobjc",
	];

	/// <summary>The ABI directories an APK uses, which are also the ones Unity expects under Android.</summary>
	private static readonly string[] Architectures = ["arm64-v8a", "armeabi-v7a", "x86", "x86_64"];

	public void DoPostExport(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		string? root = gameData.PlatformStructure?.RootPath;

		if (root is null || !fileSystem.Directory.Exists(root))
		{
			Logger.Info(LogCategory.Export,
				"Native plugins: the package root is not known, so none could be looked for.");
			return;
		}

		int preserved = 0;
		int skipped = 0;

		foreach (string file in fileSystem.Directory.EnumerateFiles(root, "*.so", SearchOption.AllDirectories))
		{
			string name = fileSystem.Path.GetFileName(file);

			if (!IsGamePlugin(name))
			{
				skipped++;
				continue;
			}

			string architecture = ArchitectureOf(file, fileSystem) ?? "arm64-v8a";
			string destination = fileSystem.Path.Join(settings.AssetsPath, "Plugins", "Android", architecture);

			fileSystem.Directory.Create(destination);

			// Streamed rather than read whole: a plugin can be tens of megabytes, and the Facebook
			// SDK frameworks on the iOS fixture are four.
			using (Stream source = fileSystem.File.OpenRead(file))
			using (Stream target = fileSystem.File.OpenWrite(fileSystem.Path.Join(destination, name)))
			{
				source.CopyTo(target);
			}

			preserved++;
		}

		Logger.Info(LogCategory.Export,
			$"Native plugins: {preserved} libraries the game shipped were copied into Assets/Plugins; " +
			$"{skipped} were the il2cpp runtime, the Unity player, Burst output or a platform library " +
			"and are deliberately not carried.");
	}

	/// <summary>Whether this is a library the developer added rather than one the toolchain supplies.</summary>
	internal static bool IsGamePlugin(string name)
	{
		if (Array.IndexOf(ReplacedByRecovery, name) >= 0 || Array.IndexOf(UnityPlayer, name) >= 0)
		{
			return false;
		}

		if (name.StartsWith(BurstOutput, StringComparison.Ordinal))
		{
			return false;
		}

		foreach (string prefix in SystemPrefixes)
		{
			if (name.StartsWith(prefix, StringComparison.Ordinal))
			{
				return false;
			}
		}

		return true;
	}

	/// <summary>The ABI a library sits under, read from its path rather than from the library itself.</summary>
	internal static string? ArchitectureOf(string path, FileSystem fileSystem)
	{
		string? directory = fileSystem.Path.GetDirectoryName(path);

		while (!string.IsNullOrEmpty(directory))
		{
			string name = fileSystem.Path.GetFileName(directory);

			if (Array.IndexOf(Architectures, name) >= 0)
			{
				return name;
			}

			string? parent = fileSystem.Path.GetDirectoryName(directory);
			if (parent == directory)
			{
				break;
			}

			directory = parent;
		}

		return null;
	}
}
