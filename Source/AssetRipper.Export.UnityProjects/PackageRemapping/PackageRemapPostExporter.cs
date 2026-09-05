using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.Project;
using AssetRipper.Import.Logging;
using AssetRipper.IO.Files;
using AssetRipper.Processing;
using System.Text.Json;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Replaces the ripped copies of Unity packages with the real ones.
/// </summary>
/// <remarks>
/// This does nothing unless a package cache is configured, because it cannot: the official guids only
/// exist in the packages themselves, and they are not part of the game being ripped.
/// <para>
/// Repointing the references is only half of it. The ripped copies are still in the project, and Unity
/// would compile the decompiled scripts alongside the package's assembly and end up with every type
/// twice, so the copies the package replaces are deleted and the package is added to the project's
/// manifest instead. What is left behind is what the package had no counterpart for.
/// </para>
/// </remarks>
public sealed class PackageRemapPostExporter : IPostExporter
{
	/// <summary>
	/// The file a package is recognised by, and where its name and version come from.
	/// </summary>
	private const string PackageManifestName = "package.json";

	private const string ReportFileName = "PackageRemapping.txt";

	public void DoPostExport(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		string? cachePath = settings.ExportSettings.OfficialPackageCachePath;
		if (string.IsNullOrWhiteSpace(cachePath))
		{
			return;
		}

		if (!Directory.Exists(cachePath))
		{
			Logger.Warning(LogCategory.Export, $"Package remapping skipped: no package cache at {cachePath}");
			return;
		}

		List<string> packageDirectories = FindPackages(cachePath);
		if (packageDirectories.Count == 0)
		{
			Logger.Warning(LogCategory.Export, $"Package remapping skipped: no packages under {cachePath}");
			return;
		}

		string configurationPath = Path.Join(LocalFileSystem.ExecutingDirectory, PackageRemapConfiguration.FileName);
		PackageRemapConfiguration configuration = PackageRemapConfiguration.Load(configurationPath);

		Logger.Info(LogCategory.Export, $"Package remapping: {packageDirectories.Count} packages under {cachePath}, settings from {configurationPath}");

		PackageRemapRun run = new(settings, fileSystem, configuration);
		foreach (string directory in packageDirectories)
		{
			run.Consider(directory);
		}

		run.Finish();
		configuration.Save(configurationPath);
		WriteReport(settings, fileSystem, run);
	}

	private static void WriteReport(FullConfiguration settings, FileSystem fileSystem, PackageRemapRun run)
	{
		try
		{
			fileSystem.Directory.Create(settings.AuxiliaryFilesPath);
			using StringWriter writer = new();
			run.WriteReport(writer);
			fileSystem.File.WriteAllText(fileSystem.Path.Join(settings.AuxiliaryFilesPath, ReportFileName), writer.ToString());
		}
		catch (IOException exception)
		{
			Logger.Warning(LogCategory.Export, $"Package remapping report could not be written: {exception.Message}");
		}
	}

	/// <summary>
	/// Every package under a cache directory, recognised by its manifest.
	/// </summary>
	private static List<string> FindPackages(string cachePath)
	{
		List<string> packages = [];

		if (File.Exists(Path.Join(cachePath, PackageManifestName)))
		{
			// The path given is a package rather than a cache of them.
			packages.Add(cachePath);
			return packages;
		}

		foreach (string directory in Directory.EnumerateDirectories(cachePath))
		{
			if (File.Exists(Path.Join(directory, PackageManifestName)))
			{
				packages.Add(directory);
			}
		}

		return packages;
	}
}
