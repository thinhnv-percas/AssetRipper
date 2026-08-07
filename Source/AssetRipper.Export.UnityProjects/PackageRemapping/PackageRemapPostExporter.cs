using AssetRipper.Export.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.IO.Files;
using AssetRipper.Processing;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Repoints an export's references at the official packages, so the manual remapping step is not
/// needed.
/// </summary>
/// <remarks>
/// This does nothing unless a package cache is configured, because it cannot: the official guids only
/// exist in the packages themselves, and they are not part of the game being ripped.
/// <para>
/// The two halves of the work need different amounts of luck. Scripts need none: a decompiled script's
/// guid is derived from the assembly name, namespace and class name, so reading the official assembly
/// gives both ends of every reference to it. The assets a package ships need the ripped copy to be
/// found first, which is what <see cref="RippedPackageLocator"/> is for, and a package it cannot place
/// confidently is left to the script half alone rather than guessed at.
/// </para>
/// </remarks>
public sealed class PackageRemapPostExporter : IPostExporter
{
	/// <summary>
	/// The file a package is recognised by.
	/// </summary>
	private const string PackageManifestName = "package.json";

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

		string assetsPath = settings.AssetsPath;
		List<string> packages = FindPackages(cachePath);
		if (packages.Count == 0)
		{
			Logger.Warning(LogCategory.Export, $"Package remapping skipped: no packages under {cachePath}");
			return;
		}

		Logger.Info(LogCategory.Export, $"Remapping references against {packages.Count} official packages");

		List<GuidMatch> matches = [];
		List<AssetIdentity> unmatched = [];
		List<string> conflicts = [];
		List<ScriptRemap> scripts = [];
		List<string> locatedRoots = [];

		foreach (string package in packages)
		{
			// The official package is read from the local disk whatever the export was written to: it is
			// part of the user's Unity installation, not of the output.
			List<AssetIdentity> official = MetaGuidScanner.Scan(package);
			scripts.AddRange(ScriptReferenceMapping.Build(package));

			string? rippedRoot = RippedPackageLocator.Locate(assetsPath, official, fileSystem);
			if (rippedRoot is null)
			{
				continue;
			}

			string rippedRelative = MetaGuidScanner.GetRelativePath(assetsPath, rippedRoot);
			locatedRoots.Add(rippedRelative);
			PackageGuidMapping mapping = PackageGuidMapping.Build(MetaGuidScanner.Scan(rippedRoot, fileSystem), official);
			matches.AddRange(mapping.Matches);
			unmatched.AddRange(mapping.UnmatchedRipped);
			conflicts.AddRange(mapping.Conflicts);

			Logger.Info(LogCategory.Export, $"{Path.GetFileName(package)}: {mapping.Matches.Count} assets paired in {rippedRelative}");
		}

		if (conflicts.Count > 0)
		{
			// Two ripped assets mapping onto one official asset would merge references that were
			// distinct, and no rewrite undoes that. Nothing is written when that is in the mapping.
			Logger.Warning(LogCategory.Export, $"Package remapping skipped: the mapping has {conflicts.Count} conflicts");
			foreach (string conflict in conflicts)
			{
				Logger.Warning(LogCategory.Export, $"  {conflict}");
			}
			return;
		}

		PackageGuidMapping combined = new()
		{
			Matches = matches,
			UnmatchedRipped = unmatched,
			UnmatchedOfficial = [],
			Conflicts = [],
		};

		ProjectRemapPlan plan = ProjectRemapPlan.Build(combined, scripts);
		RemapReport report = ProjectReferenceRewriter.Apply(assetsPath, plan, dryRun: false, backupDirectory: null, fileSystem: fileSystem);

		Logger.Info(LogCategory.Export, $"Package remapping: {locatedRoots.Count} of {packages.Count} packages located, {scripts.Count} types read from their assemblies");
		Logger.Info(LogCategory.Export, $"Package remapping: {report.ScriptReferencesRewritten} script references and {report.GuidsRewritten} asset references rewritten across {report.FilesChanged} files");

		if (locatedRoots.Count > 0)
		{
			// The references now point at the official packages, but the ripped copies are still in the
			// project and Unity would compile both. Saying which folders they are is the difference
			// between a finished job and one that looks finished.
			Logger.Info(LogCategory.Export, $"Package remapping: install the packages and delete the ripped copies at {string.Join(", ", locatedRoots)}");
		}

		int unresolved = report.UnresolvedByGuid.Values.Sum();
		if (unresolved > 0)
		{
			// Saying so matters more than the count: a rewrite that looks complete and is not is the
			// failure this whole thing exists to avoid.
			Logger.Warning(LogCategory.Export, $"Package remapping: {unresolved} references still point at ripped assets the official packages have no counterpart for");
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
