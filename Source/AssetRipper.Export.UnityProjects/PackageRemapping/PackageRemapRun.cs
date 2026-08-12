using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.Project;
using AssetRipper.Import.Logging;
using AssetRipper.IO.Files;
using System.Text.Json;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// One package's outcome, which is what the report is made of.
/// </summary>
public sealed class PackageOutcome
{
	public required string Name { get; init; }
	public required string Version { get; init; }

	public bool Skipped { get; set; }

	/// <summary>
	/// Assemblies paired, which is the match that repoints every script of the package at once.
	/// </summary>
	public int AssembliesPaired { get; set; }

	public int ShadersPaired { get; set; }
	public int OtherAssetsPaired { get; set; }
	/// <summary>
	/// Types paired one at a time against the source files a package ships.
	/// </summary>
	public int TypesPaired { get; set; }

	public int TypesInAssemblies { get; set; }
	public int FilesDeleted { get; set; }
	public bool AddedToManifest { get; set; }

	public int TotalPaired => AssembliesPaired + ShadersPaired + OtherAssetsPaired;
}

/// <summary>
/// Carries out the remapping across every package in a cache.
/// </summary>
/// <remarks>
/// The packages are gathered first and the project is rewritten once at the end, because a reference
/// can point anywhere and a file would otherwise be read and written once per package.
/// </remarks>
public sealed class PackageRemapRun
{
	private readonly FullConfiguration settings;
	private readonly FileSystem fileSystem;
	private readonly PackageRemapConfiguration configuration;
	private readonly string? backupPath;

	private readonly Dictionary<string, string> guidMatches = new(StringComparer.OrdinalIgnoreCase);
	private readonly HashSet<string> assemblyGuids = new(StringComparer.OrdinalIgnoreCase);
	private readonly List<string> conflicts = [];
	private readonly List<ScriptRemap> scripts = [];
	private readonly List<PackageOutcome> outcomes = [];

	/// <summary>
	/// Files to remove once the rewrite is done, with the package each one belongs to so that what was
	/// actually deleted is what gets reported.
	/// </summary>
	private readonly List<(string Path, PackageOutcome Outcome)> redundantPaths = [];

	/// <summary>
	/// The folders those files were in, so only those are pruned when they end up empty.
	/// </summary>
	private readonly HashSet<string> emptiedDirectories = new(StringComparer.OrdinalIgnoreCase);

	private RemapReport report = new();

	/// <param name="backupPath">
	/// Where a deleted file is kept, or null to delete without keeping anything.
	/// </param>
	public PackageRemapRun(FullConfiguration settings, FileSystem fileSystem, PackageRemapConfiguration configuration, string? backupPath = null)
	{
		this.settings = settings;
		this.fileSystem = fileSystem;
		this.configuration = configuration;
		this.backupPath = backupPath;
	}

	public IReadOnlyList<PackageOutcome> Outcomes => outcomes;

	/// <summary>
	/// Reads one official package and works out what it replaces.
	/// </summary>
	public void Consider(string packageDirectory)
	{
		UnityPackageInfo? info = UnityPackageInfo.Read(Path.Join(packageDirectory, "package.json"));
		if (info is null)
		{
			return;
		}

		PackageRemapEntry entry = configuration.Find(info.Name) ?? Remember(new PackageRemapEntry { Name = info.Name });
		string version = ResolveVersion(entry, info, packageDirectory);
		entry.Version = version;

		PackageOutcome outcome = new() { Name = info.Name, Version = version };
		outcomes.Add(outcome);

		if (entry.Skip)
		{
			outcome.Skipped = true;
			return;
		}

		// Most packages ship source rather than an assembly, so their types are matched one at a time by
		// name. A package that does ship an assembly is covered by the assembly match below instead.
		SourcePackageScripts sourceScripts = SourcePackageScriptMapping.Build(settings.AssetsPath, packageDirectory, fileSystem);
		scripts.AddRange(sourceScripts.Remaps);
		outcome.TypesPaired = sourceScripts.Remaps.Count;

		PackageScripts packageScripts = ScriptReferenceMapping.Build(packageDirectory);
		scripts.AddRange(packageScripts.Remaps);
		outcome.TypesInAssemblies = packageScripts.Remaps.Count;

		List<ExportMatch> found = ExportPackageMatcher.Match(settings.AssetsPath, packageDirectory, fileSystem);
		foreach (ExportMatch match in found)
		{
			guidMatches[match.OldGuid] = match.NewGuid;

			switch (match.Kind)
			{
				case "assembly":
					assemblyGuids.Add(match.OldGuid);
					outcome.AssembliesPaired++;
					break;
				case "shader name":
					outcome.ShadersPaired++;
					break;
				default:
					outcome.OtherAssetsPaired++;
					break;
			}
		}

		// This package's own matches, not the run's. Counting the run's would put every package in the
		// cache into the manifest once any one of them had matched, and a manifest naming packages the
		// game never used is one the package manager may not be able to resolve at all.
		outcome.AddedToManifest = found.Count > 0 || sourceScripts.Remaps.Count > 0 || packageScripts.Remaps.Count > 0;

		if (configuration.DeleteRippedCopies)
		{
			CollectRedundant(outcome, found, [.. packageScripts.AssemblyNames, .. sourceScripts.AssemblyNames], sourceScripts.RippedAssemblyPaths);
		}
	}

	/// <summary>
	/// Rewrites the project, removes what the packages replace, and adds them to the manifest.
	/// </summary>
	public void Finish()
	{
		if (conflicts.Count > 0)
		{
			// Two ripped assets mapping onto one official asset would merge references that were
			// distinct, and no rewrite undoes that. Nothing is written when that is in the mapping.
			Logger.Warning(LogCategory.Export, $"Package remapping stopped: the mapping has {conflicts.Count} conflicts and nothing was written");
			foreach (string conflict in conflicts)
			{
				Logger.Warning(LogCategory.Export, $"  {conflict}");
			}
			return;
		}

		ProjectRemapPlan plan = ProjectRemapPlan.Build(
			new PackageGuidMapping
			{
				Matches = [.. guidMatches.Select(static pair => new GuidMatch("", "", pair.Key, pair.Value, GuidMatchKind.FileName))],
				UnmatchedRipped = [],
				UnmatchedOfficial = [],
				Conflicts = [],
			},
			scripts,
			assemblyGuids);
		report = ProjectReferenceRewriter.Apply(settings.AssetsPath, plan, dryRun: false, backupDirectory: null, fileSystem: fileSystem);

		// Deleting comes after the rewrite, so a file that still had references into it is rewritten
		// before it goes.
		DeleteRedundant();
		AddToManifest();
		LogSummary();
	}

	/// <summary>
	/// Which version to ask the package manager for.
	/// </summary>
	/// <remarks>
	/// A cached package's folder is named after the version it holds, which is the answer when its own
	/// manifest does not carry one.
	/// </remarks>
	private static string ResolveVersion(PackageRemapEntry entry, UnityPackageInfo info, string packageDirectory)
	{
		if (entry.Version.Length > 0)
		{
			return entry.Version;
		}

		if (info.Version.Length > 0)
		{
			return info.Version;
		}

		string folderName = Path.GetFileName(packageDirectory.TrimEnd('/', '\\'));
		int separator = folderName.LastIndexOf('@');
		return separator >= 0 ? folderName[(separator + 1)..] : "";
	}

	private PackageRemapEntry Remember(PackageRemapEntry entry)
	{
		configuration.Packages.Add(entry);
		return entry;
	}

	/// <summary>
	/// Lists the ripped files the package makes redundant.
	/// </summary>
	/// <remarks>
	/// Only files that were actually paired with one in the package are listed. Anything the package has
	/// no counterpart for belongs to the game rather than to the package, and deleting it would break
	/// the references this run just took care to keep.
	/// </remarks>
	private void CollectRedundant(PackageOutcome outcome, List<ExportMatch> found, List<string> assemblyNames, List<string> rippedAssemblyPaths)
	{
		foreach (ExportMatch match in found)
		{
			Add(match.RippedPath);
		}

		// A saved assembly is a file rather than a folder, so it is named here rather than walked.
		foreach (string path in rippedAssemblyPaths)
		{
			Add(path);
		}

		// A decompiled script lives under a folder named after the assembly it came from, and the whole
		// folder belongs to that assembly, so it goes rather than being walked file by file.
		foreach (string assemblyName in assemblyNames)
		{
			foreach (string container in (string[])["Scripts", "Plugins"])
			{
				string folder = fileSystem.Path.Join(settings.AssetsPath, container, assemblyName);
				if (!fileSystem.Directory.Exists(folder))
				{
					continue;
				}

				foreach (string path in fileSystem.Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories))
				{
					// Adding a file takes its meta with it, so listing metas separately would count them
					// twice and look for a meta of a meta.
					if (!path.EndsWith(".meta", StringComparison.OrdinalIgnoreCase))
					{
						Add(path);
					}
				}
			}
		}

		void Add(string path)
		{
			redundantPaths.Add((path, outcome));
			redundantPaths.Add((path + ".meta", outcome));
			emptiedDirectories.Add(fileSystem.Path.GetDirectoryName(path));
		}
	}

	private void DeleteRedundant()
	{
		int deleted = 0;
		foreach ((string path, PackageOutcome outcome) in redundantPaths)
		{
			try
			{
				if (!fileSystem.File.Exists(path))
				{
					continue;
				}

				Keep(path);
				fileSystem.File.Delete(path);
				outcome.FilesDeleted++;
				deleted++;
			}
			catch (IOException)
			{
			}
		}

		if (deleted == 0)
		{
			return;
		}

		Logger.Info(LogCategory.Export, backupPath is null
			? $"Package remapping: deleted {deleted} ripped files the packages replace"
			: $"Package remapping: deleted {deleted} ripped files the packages replace, kept in {backupPath}");

		// Only the folders the deletions emptied are pruned. Walking the whole project would also take
		// away folders that were empty before this ran and have nothing to do with any package.
		foreach (string directory in emptiedDirectories.OrderByDescending(static path => path.Length))
		{
			PruneUpwards(directory);
		}
	}

	/// <summary>
	/// Copies a file into the backup before it goes, keeping where it was.
	/// </summary>
	private void Keep(string path)
	{
		if (backupPath is null)
		{
			return;
		}

		try
		{
			string destination = fileSystem.Path.Join(backupPath, MetaGuidScanner.GetRelativePath(settings.AssetsPath, path));
			fileSystem.Directory.Create(fileSystem.Path.GetDirectoryName(destination));
			fileSystem.File.WriteAllBytes(destination, fileSystem.File.ReadAllBytes(path));
		}
		catch (IOException)
		{
		}
	}

	/// <summary>
	/// Removes a folder and its parents for as long as they are empty, taking their meta files too.
	/// </summary>
	private void PruneUpwards(string directory)
	{
		string assets = settings.AssetsPath;

		while (directory.Length > assets.Length && directory.StartsWith(assets, StringComparison.OrdinalIgnoreCase))
		{
			try
			{
				if (!fileSystem.Directory.Exists(directory)
					|| fileSystem.Directory.EnumerateFiles(directory).Any()
					|| fileSystem.Directory.EnumerateDirectories(directory).Any())
				{
					return;
				}

				fileSystem.Directory.Delete(directory);
				if (fileSystem.File.Exists(directory + ".meta"))
				{
					fileSystem.File.Delete(directory + ".meta");
				}
			}
			catch (IOException)
			{
				return;
			}

			directory = fileSystem.Path.GetDirectoryName(directory);
		}
	}

	/// <summary>
	/// Adds the packages to the project's manifest, so Unity installs the real ones.
	/// </summary>
	private void AddToManifest()
	{
		List<PackageOutcome> wanted = outcomes.Where(static outcome => outcome.AddedToManifest).ToList();
		if (wanted.Count == 0)
		{
			return;
		}

		string path = fileSystem.Path.Join(settings.ProjectRootPath, "Packages", "manifest.json");

		PackageManifest manifest;
		try
		{
			// The manifest already exists: an earlier post exporter wrote the default one, and its
			// dependencies are kept.
			manifest = fileSystem.File.Exists(path)
				? JsonSerializer.Deserialize(fileSystem.File.ReadAllText(path), PackageManifestSerializerContext.Default.PackageManifest) ?? new()
				: new();
		}
		catch (Exception)
		{
			manifest = new();
		}

		int added = 0;
		foreach (PackageOutcome outcome in wanted)
		{
			if (outcome.Version.Length == 0)
			{
				// A version the package manager cannot resolve would fail the project's first import,
				// which is worse than leaving the entry out and saying which one to add.
				Logger.Warning(LogCategory.Export, $"Package remapping: {outcome.Name} has no version, so it was left out of the manifest. Add it by hand or set one in {PackageRemapConfiguration.FileName}.");
				outcome.AddedToManifest = false;
				continue;
			}

			manifest.Dependencies[outcome.Name] = outcome.Version;
			added++;
		}

		if (added == 0)
		{
			return;
		}

		try
		{
			fileSystem.Directory.Create(fileSystem.Path.GetDirectoryName(path));
			using Stream stream = fileSystem.File.Create(path);
			manifest.Save(stream);
			Logger.Info(LogCategory.Export, $"Package remapping: added {added} packages to the project manifest");
		}
		catch (IOException exception)
		{
			Logger.Warning(LogCategory.Export, $"Package remapping: the manifest could not be written: {exception.Message}");
		}
	}

	private void LogSummary()
	{
		Logger.Info(LogCategory.Export, $"Package remapping: {report.ScriptReferencesRewritten} script references and {report.GuidsRewritten} asset references rewritten across {report.FilesChanged} files");

		foreach (PackageOutcome outcome in outcomes)
		{
			if (outcome.Skipped)
			{
				Logger.Info(LogCategory.Export, $"  {outcome.Name}: skipped by configuration");
			}
			else if (outcome.TotalPaired == 0 && outcome.TypesPaired == 0)
			{
				Logger.Info(LogCategory.Export, $"  {outcome.Name} {outcome.Version}: nothing in the export matched it");
			}
			else
			{
				Logger.Info(LogCategory.Export, $"  {outcome.Name} {outcome.Version}: {outcome.TypesPaired} types, {outcome.AssembliesPaired} assemblies, {outcome.ShadersPaired} shaders and {outcome.OtherAssetsPaired} other assets paired, {outcome.FilesDeleted} files deleted");
			}
		}

		int unresolved = report.UnresolvedByGuid.Values.Sum();
		if (unresolved > 0)
		{
			// Saying so matters more than the count: a rewrite that looks complete and is not is the
			// failure this whole thing exists to avoid.
			Logger.Warning(LogCategory.Export, $"Package remapping: {unresolved} references still point at ripped assets the packages have no counterpart for");
		}
	}

	/// <summary>
	/// Writes the full account, which is what to read when the log has scrolled past.
	/// </summary>
	public void WriteReport(TextWriter writer)
	{
		writer.WriteLine("# Package remapping");
		writer.WriteLine();
		writer.WriteLine($"Script references rewritten: {report.ScriptReferencesRewritten}");
		writer.WriteLine($"Asset references rewritten: {report.GuidsRewritten}");
		writer.WriteLine($"Files changed: {report.FilesChanged} of {report.FilesScanned} scanned");
		writer.WriteLine();

		writer.WriteLine("## Packages");
		writer.WriteLine("name,version,typesPaired,assemblies,shaders,otherAssets,filesDeleted,addedToManifest,skipped");
		foreach (PackageOutcome outcome in outcomes)
		{
			writer.WriteLine($"{outcome.Name},{outcome.Version},{outcome.TypesPaired},{outcome.AssembliesPaired},{outcome.ShadersPaired},{outcome.OtherAssetsPaired},{outcome.FilesDeleted},{outcome.AddedToManifest},{outcome.Skipped}");
		}

		if (conflicts.Count > 0)
		{
			writer.WriteLine();
			writer.WriteLine("## Conflicts, which stopped the rewrite");
			foreach (string conflict in conflicts)
			{
				writer.WriteLine($"- {conflict}");
			}
		}

		if (report.UnresolvedByGuid.Count > 0)
		{
			writer.WriteLine();
			writer.WriteLine("## References still pointing at ripped assets");
			writer.WriteLine("guid,references");
			foreach ((string guid, int count) in report.UnresolvedByGuid.OrderByDescending(static pair => pair.Value))
			{
				writer.WriteLine($"{guid},{count}");
			}
		}
	}
}
