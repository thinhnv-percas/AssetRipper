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
/// Which libraries to copy is the whole question, and four of the five kinds
/// <see cref="NativeLibraryClassifier"/> names must NOT be copied. What is left is what the developer
/// added, and that is what a project has to carry.
/// </para>
/// <para>
/// The two platforms package a plugin differently and Unity imports them differently, so they are
/// handled separately rather than by one rule: Android ships a bare <c>.so</c> under an ABI
/// directory that names its architecture, while iOS ships a <c>.framework</c> bundle - a directory
/// carrying a binary, an <c>Info.plist</c> and often headers and resources - whose architecture is
/// only in the binary. Copying a framework's binary alone would give Unity something it does not
/// recognise as a plugin at all.
/// </para>
/// </remarks>
public sealed class NativePluginPostExporter : IPostExporter
{
	/// <summary>The ABI directories an APK uses, which are also the ones Unity expects under Android.</summary>
	private static readonly string[] Architectures = ["arm64-v8a", "armeabi-v7a", "x86", "x86_64"];

	/// <summary>Files a framework bundle carries that belong to the package rather than to the plugin.</summary>
	private static readonly string[] SigningDirectories = ["_CodeSignature"];

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

		CopyAndroidLibraries(root, settings, fileSystem, ref preserved, ref skipped);
		CopyAppleLibraries(root, settings, fileSystem, ref preserved, ref skipped);

		Logger.Info(LogCategory.Export,
			$"Native plugins: {preserved} libraries the game shipped were copied into Assets/Plugins; " +
			$"{skipped} were the il2cpp runtime, the Unity player, Burst output or a platform library " +
			"and are deliberately not carried.");
	}

	private static void CopyAndroidLibraries(
		string root,
		FullConfiguration settings,
		FileSystem fileSystem,
		ref int preserved,
		ref int skipped)
	{
		foreach (string file in fileSystem.Directory.EnumerateFiles(root, "*.so", SearchOption.AllDirectories))
		{
			string name = fileSystem.Path.GetFileName(file);

			if (!NativeLibraryClassifier.IsGamePlugin(name))
			{
				skipped++;
				continue;
			}

			string architecture = ArchitectureOf(file, fileSystem) ?? "arm64-v8a";
			string destination = fileSystem.Path.Join(settings.AssetsPath, "Plugins", "Android", architecture);

			fileSystem.Directory.Create(destination);
			CopyFile(file, fileSystem.Path.Join(destination, name), fileSystem);
			preserved++;
		}
	}

	/// <summary>
	/// The frameworks and dylibs an <c>.ipa</c> embeds, into the layout Unity imports an iOS plugin
	/// from.
	/// </summary>
	/// <remarks>
	/// A framework is copied whole - the binary, the <c>Info.plist</c>, the headers, the module map
	/// and any resource bundle - because that is what Unity recognises; only the package's own code
	/// signature is left behind, since it covers the app that was signed and not the project. The
	/// architectures come out of the Mach-O rather than out of the path, which on iOS carries none.
	/// </remarks>
	private static void CopyAppleLibraries(
		string root,
		FullConfiguration settings,
		FileSystem fileSystem,
		ref int preserved,
		ref int skipped)
	{
		string destinationRoot = fileSystem.Path.Join(settings.AssetsPath, "Plugins", "iOS");

		foreach (string bundle in fileSystem.Directory.EnumerateDirectories(root, "*.framework", SearchOption.AllDirectories))
		{
			string name = fileSystem.Path.GetFileName(bundle);

			if (!NativeLibraryClassifier.IsGamePlugin(name))
			{
				skipped++;
				continue;
			}

			CopyFramework(bundle, fileSystem.Path.Join(destinationRoot, name), fileSystem);
			ReportArchitectures(name, fileSystem.Path.Join(bundle, TrimBundleSuffix(name)), fileSystem);
			preserved++;
		}

		foreach (string file in fileSystem.Directory.EnumerateFiles(root, "*.dylib", SearchOption.AllDirectories))
		{
			string name = fileSystem.Path.GetFileName(file);

			// A dylib inside a framework has already been carried with its bundle.
			if (!NativeLibraryClassifier.IsGamePlugin(name) || IsInsideAFramework(file, fileSystem))
			{
				skipped++;
				continue;
			}

			fileSystem.Directory.Create(destinationRoot);
			CopyFile(file, fileSystem.Path.Join(destinationRoot, name), fileSystem);
			ReportArchitectures(name, file, fileSystem);
			preserved++;
		}
	}

	private static void CopyFramework(string bundle, string destination, FileSystem fileSystem)
	{
		fileSystem.Directory.Create(destination);

		foreach (string file in fileSystem.Directory.EnumerateFiles(bundle, "*", SearchOption.AllDirectories))
		{
			string relative = fileSystem.Path.GetRelativePath(bundle, file);

			if (IsSigning(relative))
			{
				continue;
			}

			string target = fileSystem.Path.Join(destination, relative);
			string? directory = fileSystem.Path.GetDirectoryName(target);

			if (!string.IsNullOrEmpty(directory))
			{
				fileSystem.Directory.Create(directory);
			}

			CopyFile(file, target, fileSystem);
		}
	}

	private static bool IsSigning(string relative)
	{
		foreach (string part in relative.Split('/', '\\'))
		{
			if (Array.IndexOf(SigningDirectories, part) >= 0)
			{
				return true;
			}
		}

		return false;
	}

	private static void ReportArchitectures(string name, string binary, FileSystem fileSystem)
	{
		if (!fileSystem.File.Exists(binary))
		{
			Logger.Info(LogCategory.Export, $"Native plugins: {name} carries no binary at its bundle name.");
			return;
		}

		using Stream stream = fileSystem.File.OpenRead(binary);
		IReadOnlyList<string> architectures = MachOArchitecture.Read(stream);

		Logger.Info(LogCategory.Export, architectures.Count == 0
			? $"Native plugins: {name} is not a Mach-O, so its architecture is not known."
			: $"Native plugins: {name} carries {string.Join(", ", architectures)}.");
	}

	private static bool IsInsideAFramework(string path, FileSystem fileSystem)
	{
		string? directory = fileSystem.Path.GetDirectoryName(path);

		while (!string.IsNullOrEmpty(directory))
		{
			if (fileSystem.Path.GetFileName(directory).EndsWith(".framework", StringComparison.Ordinal))
			{
				return true;
			}

			string? parent = fileSystem.Path.GetDirectoryName(directory);

			if (parent == directory)
			{
				break;
			}

			directory = parent;
		}

		return false;
	}

	internal static string TrimBundleSuffix(string name)
		=> name.EndsWith(".framework", StringComparison.Ordinal) ? name[..^".framework".Length] : name;

	/// <summary>Streamed: a plugin can be tens of megabytes, and the Facebook SDK frameworks are four.</summary>
	private static void CopyFile(string source, string destination, FileSystem fileSystem)
	{
		using Stream input = fileSystem.File.OpenRead(source);
		using Stream output = fileSystem.File.OpenWrite(destination);
		input.CopyTo(output);
	}

	/// <summary>Whether this is a library the developer added rather than one the toolchain supplies.</summary>
	internal static bool IsGamePlugin(string name) => NativeLibraryClassifier.IsGamePlugin(name);

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
