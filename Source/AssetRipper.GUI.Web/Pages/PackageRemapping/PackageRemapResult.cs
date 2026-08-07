using AssetRipper.Export.UnityProjects.PackageRemapping;

namespace AssetRipper.GUI.Web.Pages.PackageRemapping;

/// <summary>
/// What one run of the remapping did, or would have done.
/// </summary>
public sealed class PackageRemapResult
{
	public bool Applied { get; init; }

	/// <summary>
	/// Why the run could not be made, when it could not be.
	/// </summary>
	public string? Error { get; init; }

	public int Matches { get; init; }
	public int UnmatchedRipped { get; init; }
	public int ScriptTypes { get; init; }
	public int FilesScanned { get; init; }
	public int FilesChanged { get; init; }
	public int GuidsRewritten { get; init; }
	public int ScriptReferencesRewritten { get; init; }

	public List<string> Conflicts { get; init; } = [];
	public Dictionary<string, int> UnresolvedByGuid { get; init; } = [];

	public static PackageRemapResult Failure(string error) => new() { Error = error };

	/// <summary>
	/// Builds the mapping, rewrites the project, and reports what happened.
	/// </summary>
	/// <remarks>
	/// A run with conflicts is reported and refused rather than half applied: two ripped assets mapping
	/// onto one official asset would merge references that were distinct, and no rewrite can undo that.
	/// </remarks>
	public static PackageRemapResult Run(string rippedPackage, string officialPackage, string projectAssets, string? backupDirectory, bool apply)
	{
		if (!Directory.Exists(rippedPackage))
		{
			return Failure($"The ripped package directory does not exist: {rippedPackage}");
		}

		if (!Directory.Exists(officialPackage))
		{
			return Failure($"The official package directory does not exist: {officialPackage}");
		}

		if (!Directory.Exists(projectAssets))
		{
			return Failure($"The project directory does not exist: {projectAssets}");
		}

		PackageGuidMapping mapping = PackageGuidMapping.Build(
			MetaGuidScanner.Scan(rippedPackage),
			MetaGuidScanner.Scan(officialPackage));

		List<ScriptRemap> scripts = ScriptReferenceMapping.Build(officialPackage);
		ProjectRemapPlan plan = ProjectRemapPlan.Build(mapping, scripts);

		if (apply && !mapping.IsSafeToApply)
		{
			return new PackageRemapResult
			{
				Applied = false,
				Error = "The mapping has conflicts, so nothing was written. Resolve them and run again.",
				Matches = mapping.Matches.Count,
				UnmatchedRipped = mapping.UnmatchedRipped.Count,
				ScriptTypes = scripts.Count,
				Conflicts = mapping.Conflicts,
			};
		}

		RemapReport report = ProjectReferenceRewriter.Apply(
			projectAssets,
			plan,
			dryRun: !apply,
			backupDirectory: string.IsNullOrWhiteSpace(backupDirectory) ? null : backupDirectory);

		return new PackageRemapResult
		{
			Applied = apply,
			Matches = mapping.Matches.Count,
			UnmatchedRipped = mapping.UnmatchedRipped.Count,
			ScriptTypes = scripts.Count,
			FilesScanned = report.FilesScanned,
			FilesChanged = report.FilesChanged,
			GuidsRewritten = report.GuidsRewritten,
			ScriptReferencesRewritten = report.ScriptReferencesRewritten,
			Conflicts = mapping.Conflicts,
			UnresolvedByGuid = report.UnresolvedByGuid,
		};
	}
}
