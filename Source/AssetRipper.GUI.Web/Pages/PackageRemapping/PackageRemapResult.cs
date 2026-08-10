using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.IO.Files;

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

	public int Assemblies { get; init; }
	public int Shaders { get; init; }
	public int OtherAssets { get; init; }
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
	public static PackageRemapResult Run(string officialPackage, string projectAssets, string? backupDirectory, bool apply)
	{
		if (!Directory.Exists(officialPackage))
		{
			return Failure($"The official package directory does not exist: {officialPackage}");
		}

		if (!Directory.Exists(projectAssets))
		{
			return Failure($"The project directory does not exist: {projectAssets}");
		}

		List<ExportMatch> found = ExportPackageMatcher.Match(projectAssets, officialPackage, LocalFileSystem.Instance);

		Dictionary<string, string> guids = new(StringComparer.OrdinalIgnoreCase);
		HashSet<string> assemblyGuids = new(StringComparer.OrdinalIgnoreCase);
		int assemblies = 0;
		int shaders = 0;
		foreach (ExportMatch match in found)
		{
			guids[match.OldGuid] = match.NewGuid;
			if (match.Kind == "assembly")
			{
				assemblyGuids.Add(match.OldGuid);
				assemblies++;
			}
			else if (match.Kind == "shader name")
			{
				shaders++;
			}
		}

		PackageGuidMapping mapping = new()
		{
			Matches = [.. guids.Select(static pair => new GuidMatch("", "", pair.Key, pair.Value, GuidMatchKind.FileName))],
			UnmatchedRipped = [],
			UnmatchedOfficial = [],
			Conflicts = [],
		};

		// A decompiled script is referred to by a guid of its own, so both halves of that reference move.
		// This only applies when the export decompiled the package's code rather than saving the assembly.
		List<ScriptRemap> scripts = ScriptReferenceMapping.Build(officialPackage).Remaps;
		ProjectRemapPlan plan = ProjectRemapPlan.Build(mapping, scripts, assemblyGuids);

		RemapReport report = ProjectReferenceRewriter.Apply(
			projectAssets,
			plan,
			dryRun: !apply,
			backupDirectory: string.IsNullOrWhiteSpace(backupDirectory) ? null : backupDirectory,
			fileSystem: LocalFileSystem.Instance);

		return new PackageRemapResult
		{
			Applied = apply,
			Assemblies = assemblies,
			Shaders = shaders,
			OtherAssets = found.Count - assemblies - shaders,
			ScriptTypes = scripts.Count,
			FilesScanned = report.FilesScanned,
			FilesChanged = report.FilesChanged,
			GuidsRewritten = report.GuidsRewritten,
			ScriptReferencesRewritten = report.ScriptReferencesRewritten,
		};
	}
}
