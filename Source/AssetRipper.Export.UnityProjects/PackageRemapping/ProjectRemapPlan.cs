namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Everything a rewrite needs to know, gathered before anything is written.
/// </summary>
public sealed class ProjectRemapPlan
{
	/// <summary>
	/// Assets whose fileID is the same on both sides, so only the guid moves. Shaders, materials,
	/// textures and asset files are all of this kind.
	/// </summary>
	public required Dictionary<string, string> GuidMap { get; init; }

	/// <summary>
	/// Scripts, whose fileID moves along with the guid.
	/// </summary>
	public required Dictionary<AssetReference, AssetReference> ScriptMap { get; init; }

	/// <summary>
	/// Ripped assets with nothing to repoint them at. A reference left pointing at one of these is what
	/// makes a rewrite a partial success, so they are counted rather than ignored.
	/// </summary>
	public required HashSet<string> UnmappedRippedGuids { get; init; }

	public bool IsEmpty => GuidMap.Count == 0 && ScriptMap.Count == 0;

	/// <summary>
	/// Builds a plan from a package mapping and the scripts the official package's assemblies hold.
	/// </summary>
	/// <remarks>
	/// A script never appears in the guid mapping, because the ripped side is a set of source files and
	/// the official side is one assembly, so nothing pairs up by path. The two halves therefore do not
	/// overlap, and the script half is still applied first so that a collision could never silently
	/// rewrite half a reference.
	/// </remarks>
	public static ProjectRemapPlan Build(PackageGuidMapping mapping, IEnumerable<ScriptRemap> scripts)
	{
		Dictionary<string, string> guids = new(StringComparer.OrdinalIgnoreCase);
		foreach (GuidMatch match in mapping.Matches)
		{
			guids[match.OldGuid] = match.NewGuid;
		}

		Dictionary<AssetReference, AssetReference> scriptMap = [];
		foreach (ScriptRemap remap in scripts)
		{
			scriptMap[remap.Old] = remap.New;
			guids.Remove(remap.Old.Guid);
		}

		HashSet<string> unmapped = new(StringComparer.OrdinalIgnoreCase);
		foreach (AssetIdentity identity in mapping.UnmatchedRipped)
		{
			unmapped.Add(identity.Guid);
		}

		return new ProjectRemapPlan
		{
			GuidMap = guids,
			ScriptMap = scriptMap,
			UnmappedRippedGuids = unmapped,
		};
	}
}

/// <summary>
/// What a rewrite did, or would have done.
/// </summary>
public sealed class RemapReport
{
	public int FilesScanned { get; set; }
	public int FilesChanged { get; set; }

	/// <summary>
	/// References repointed at an asset whose fileID did not change.
	/// </summary>
	public int GuidsRewritten { get; set; }

	/// <summary>
	/// Script references whose fileID was recomputed for the assembly.
	/// </summary>
	public int ScriptReferencesRewritten { get; set; }

	/// <summary>
	/// References still pointing at the ripped package after the rewrite, keyed by guid.
	/// </summary>
	public Dictionary<string, int> UnresolvedByGuid { get; } = new(StringComparer.OrdinalIgnoreCase);

	public void Write(TextWriter writer)
	{
		writer.WriteLine($"Files scanned: {FilesScanned}");
		writer.WriteLine($"Files changed: {FilesChanged}");
		writer.WriteLine($"Guid references rewritten: {GuidsRewritten}");
		writer.WriteLine($"Script references rewritten: {ScriptReferencesRewritten}");

		if (UnresolvedByGuid.Count > 0)
		{
			writer.WriteLine();
			writer.WriteLine("## References still pointing at the ripped package");
			foreach ((string guid, int count) in UnresolvedByGuid.OrderByDescending(static pair => pair.Value))
			{
				writer.WriteLine($"{guid},{count}");
			}
		}
	}
}
