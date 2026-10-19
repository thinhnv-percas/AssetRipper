using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.Project;
using AssetRipper.Import.Logging;
using AssetRipper.IO.Files;
using AssetRipper.Processing;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Replaces the ripped copies of Unity packages with the real ones.
/// </summary>
/// <remarks>
/// This does nothing unless a source is configured, because it cannot: the official guids only exist in
/// the packages themselves, and they are not part of the game being ripped. A source is a package cache,
/// a folder, or a git repository, and the sources are managed on the Package Sources page.
/// <para>
/// Repointing the references is only half of it. The ripped copies are still in the project, and Unity
/// would compile the decompiled scripts alongside the package's assembly and end up with every type
/// twice, so the copies the package replaces are deleted and the package is added to the project's
/// manifest instead. What is left behind is what the package had no counterpart for.
/// </para>
/// </remarks>
public sealed class PackageRemapPostExporter : IPostExporter
{
	private const string ReportFileName = "PackageRemapping.txt";

	public void DoPostExport(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		string configurationPath = PackageRemapConfiguration.DefaultPath;
		PackageRemapConfiguration configuration = PackageRemapConfiguration.Load(configurationPath);

		List<PackageSource> sources = GatherSources(settings, configuration);
		if (sources.Count == 0)
		{
			return;
		}

		// A git source is cloned when it has never been, and never re-fetched: an export should not be
		// waiting on a network, and updating a clone is something the Package Sources page does on ask.
		List<PackageSourceResult> resolved = PackageSourceResolver.Resolve(sources, GitFetchMode.WhenMissing);
		List<ResolvedPackage> packages = Gather(resolved);

		if (packages.Count == 0)
		{
			Logger.Warning(LogCategory.Export, "Package remapping skipped: none of the configured sources hold a package");
			return;
		}

		Logger.Info(LogCategory.Export, $"Package remapping: {packages.Count} packages from {sources.Count} sources, settings from {configurationPath}");

		PackageRemapRun run = new(settings, fileSystem, configuration);
		foreach (ResolvedPackage package in packages)
		{
			run.Consider(package);
		}

		run.Finish();
		RemovePluginsThePackagesProvide(settings, fileSystem, run, packages);
		configuration.Save(configurationPath);
		WriteReport(settings, fileSystem, run);
		WritePackageGuids(settings, fileSystem, run);
	}

	/// <summary>
	/// Deletes the plugin DLLs whose assembly a package now in the manifest provides, directly or through its dependencies.
	/// See <see cref="PackageProvidedPlugins"/>.
	/// </summary>
	private static void RemovePluginsThePackagesProvide(FullConfiguration settings, FileSystem fileSystem, PackageRemapRun run, List<ResolvedPackage> packages)
	{
		List<string> roots = run.Outcomes.Where(static outcome => outcome.AddedToManifest).Select(static outcome => outcome.Name).ToList();
		if (roots.Count == 0)
		{
			return;
		}

		Dictionary<string, string> directories = new(StringComparer.Ordinal);
		foreach (ResolvedPackage package in packages)
		{
			directories.TryAdd(package.Name, package.Directory);
		}

		HashSet<string> provided = PackageProvidedPlugins.ProvidedAssemblies(roots, directories);
		string plugins = fileSystem.Path.Join(settings.ProjectRootPath, "Assets", "Plugins");
		List<string> removed = PackageProvidedPlugins.RemoveFrom(plugins, provided, fileSystem);
		if (removed.Count > 0)
		{
			Logger.Info(LogCategory.Export, $"Package remapping: removed {removed.Count} plugin assemblies the manifest's packages provide: {string.Join(", ", removed)}");
		}
	}

	/// <summary>
	/// Every source to look in, which is the configured list plus the cache path from the settings.
	/// </summary>
	/// <remarks>
	/// The cache path goes last, so a source added by hand wins over it. Someone who adds a package's
	/// repository while the cache also holds that package added it to be used.
	/// </remarks>
	private static List<PackageSource> GatherSources(FullConfiguration settings, PackageRemapConfiguration configuration)
	{
		List<PackageSource> sources = [.. configuration.Sources.Where(static source => source.Enabled && !source.IsEmpty)];

		// Several caches may be given, separated as a PATH is. A Unity Editor's own built-in packages
		// (Editor/Data/Resources/PackageManager/BuiltInPackages) are one: com.unity.ugui ships there and in no
		// registry, so a cache built from the registry can never place UnityEngine.UI.
		string? cachePath = settings.ExportSettings.OfficialPackageCachePath;
		if (!string.IsNullOrWhiteSpace(cachePath))
		{
			foreach (string path in cachePath.Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
			{
				sources.Add(new PackageSource { Kind = PackageSourceKind.Cache, Location = path });
			}
		}

		return sources;
	}

	/// <summary>
	/// The packages the sources resolved to, one per name.
	/// </summary>
	/// <remarks>
	/// Two sources holding the same package would be two sets of guids for one thing, and the references
	/// would end up pointing at whichever ran last. The first source that has it is the one used, and the
	/// other is named in the log rather than silently dropped.
	/// </remarks>
	private static List<ResolvedPackage> Gather(List<PackageSourceResult> resolved)
	{
		List<ResolvedPackage> packages = [];
		Dictionary<string, PackageSource> taken = new(StringComparer.OrdinalIgnoreCase);

		foreach (PackageSourceResult result in resolved)
		{
			if (result.Error is string error)
			{
				Logger.Warning(LogCategory.Export, $"Package remapping: {result.Source.Describe()} was skipped. {error}");
				continue;
			}

			foreach (ResolvedPackage package in result.Packages)
			{
				if (taken.TryGetValue(package.Name, out PackageSource? owner))
				{
					Logger.Info(LogCategory.Export, $"Package remapping: {package.Name} in {result.Source.Describe()} was ignored, {owner.Describe()} has it too");
					continue;
				}

				taken.Add(package.Name, result.Source);
				packages.Add(package);
			}
		}

		return packages;
	}

	/// <summary>
	/// The guids references were repointed at and the package each belongs to, for a reference audit: the package
	/// lives in the manifest rather than in the project folder, so no .meta in the export declares them.
	/// </summary>
	private static void WritePackageGuids(FullConfiguration settings, FileSystem fileSystem, PackageRemapRun run)
	{
		if (run.PackageGuids.Count == 0)
		{
			return;
		}

		try
		{
			fileSystem.Directory.Create(settings.AuxiliaryFilesPath);
			using StringWriter writer = new();
			writer.WriteLine("{");
			int index = 0;
			foreach ((string guid, string package) in run.PackageGuids)
			{
				writer.WriteLine($"  \"{guid}\": \"{package}\"{(++index < run.PackageGuids.Count ? "," : "")}");
			}
			writer.WriteLine("}");
			fileSystem.File.WriteAllText(fileSystem.Path.Join(settings.AuxiliaryFilesPath, PackageGuidsFileName), writer.ToString());
		}
		catch (IOException exception)
		{
			Logger.Warning(LogCategory.Export, $"Package guid list could not be written: {exception.Message}");
		}
	}

	public const string PackageGuidsFileName = "PackageGuids.json";

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
}
