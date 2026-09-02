using System.Globalization;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// How an asset in the ripped package was paired with one in the official package.
/// </summary>
public enum GuidMatchKind
{
	/// <summary>
	/// The same path relative to the package root. Unambiguous.
	/// </summary>
	RelativePath,
	/// <summary>
	/// The same file name, which was unique on both sides. Weaker, because a package may move files
	/// between versions.
	/// </summary>
	FileName,
}

/// <param name="RippedPath">The asset's path in the ripped package.</param>
/// <param name="OfficialPath">The asset's path in the official package.</param>
public readonly record struct GuidMatch(string RippedPath, string OfficialPath, string OldGuid, string NewGuid, GuidMatchKind Kind);

/// <summary>
/// What a remap would do, without doing any of it.
/// </summary>
/// <remarks>
/// Rewriting GUIDs edits a whole project in place and is expensive to undo, so the mapping is
/// produced and reviewed before anything is written.
/// </remarks>
public sealed class PackageGuidMapping
{
	public required List<GuidMatch> Matches { get; init; }

	/// <summary>
	/// Ripped assets with no counterpart. References to these cannot be repointed.
	/// </summary>
	public required List<AssetIdentity> UnmatchedRipped { get; init; }

	/// <summary>
	/// Official assets nothing in the ripped package corresponds to. Usually harmless.
	/// </summary>
	public required List<AssetIdentity> UnmatchedOfficial { get; init; }

	/// <summary>
	/// Problems that make part of the mapping unsafe to apply.
	/// </summary>
	public required List<string> Conflicts { get; init; }

	/// <summary>
	/// Whether the mapping can be applied without a human deciding something first.
	/// </summary>
	public bool IsSafeToApply => Conflicts.Count == 0;

	/// <summary>
	/// Builds the old to new GUID mapping for a package.
	/// </summary>
	public static PackageGuidMapping Build(IReadOnlyList<AssetIdentity> ripped, IReadOnlyList<AssetIdentity> official)
	{
		List<GuidMatch> matches = [];
		List<string> conflicts = [];

		Dictionary<string, AssetIdentity> officialByPath = new(StringComparer.OrdinalIgnoreCase);
		foreach (AssetIdentity identity in official)
		{
			if (!officialByPath.TryAdd(identity.RelativePath, identity))
			{
				conflicts.Add($"The official package has two assets at '{identity.RelativePath}'.");
			}
		}

		Dictionary<string, AssetIdentity> officialByFileName = BuildUniqueFileNameIndex(official);
		Dictionary<string, AssetIdentity> rippedByFileName = BuildUniqueFileNameIndex(ripped);

		HashSet<string> matchedOfficialPaths = new(StringComparer.OrdinalIgnoreCase);
		List<AssetIdentity> unmatchedRipped = [];

		foreach (AssetIdentity source in ripped)
		{
			if (officialByPath.TryGetValue(source.RelativePath, out AssetIdentity target))
			{
				AddMatch(source, target, GuidMatchKind.RelativePath);
				continue;
			}

			// Falling back to the file name is only safe when it is unique on both sides.
			string fileName = GetFileName(source.RelativePath);
			if (rippedByFileName.ContainsKey(fileName) && officialByFileName.TryGetValue(fileName, out target))
			{
				AddMatch(source, target, GuidMatchKind.FileName);
				continue;
			}

			unmatchedRipped.Add(source);
		}

		List<AssetIdentity> unmatchedOfficial = official
			.Where(identity => !matchedOfficialPaths.Contains(identity.RelativePath))
			.ToList();

		// Two ripped assets pointing at one official asset would merge references that were distinct.
		foreach (IGrouping<string, GuidMatch> group in matches.GroupBy(static m => m.NewGuid, StringComparer.OrdinalIgnoreCase))
		{
			if (group.Count() > 1)
			{
				conflicts.Add($"{group.Count()} ripped assets map onto the same official GUID {group.Key}: {string.Join(", ", group.Select(static m => m.RippedPath))}");
			}
		}

		foreach (IGrouping<string, GuidMatch> group in matches.GroupBy(static m => m.OldGuid, StringComparer.OrdinalIgnoreCase))
		{
			if (group.Select(static m => m.NewGuid).Distinct(StringComparer.OrdinalIgnoreCase).Count() > 1)
			{
				conflicts.Add($"The ripped GUID {group.Key} would be rewritten to more than one value.");
			}
		}

		return new PackageGuidMapping
		{
			Matches = matches,
			UnmatchedRipped = unmatchedRipped,
			UnmatchedOfficial = unmatchedOfficial,
			Conflicts = conflicts,
		};

		void AddMatch(AssetIdentity source, AssetIdentity target, GuidMatchKind kind)
		{
			matchedOfficialPaths.Add(target.RelativePath);

			// Nothing to rewrite when both sides already agree.
			if (!string.Equals(source.Guid, target.Guid, StringComparison.OrdinalIgnoreCase))
			{
				matches.Add(new GuidMatch(source.RelativePath, target.RelativePath, source.Guid, target.Guid, kind));
			}
		}
	}

	/// <summary>
	/// Indexes by file name, dropping names that occur more than once.
	/// </summary>
	private static Dictionary<string, AssetIdentity> BuildUniqueFileNameIndex(IReadOnlyList<AssetIdentity> identities)
	{
		Dictionary<string, AssetIdentity> index = new(StringComparer.OrdinalIgnoreCase);
		HashSet<string> duplicates = new(StringComparer.OrdinalIgnoreCase);

		foreach (AssetIdentity identity in identities)
		{
			string fileName = GetFileName(identity.RelativePath);
			if (!index.TryAdd(fileName, identity))
			{
				duplicates.Add(fileName);
			}
		}

		foreach (string duplicate in duplicates)
		{
			index.Remove(duplicate);
		}

		return index;
	}

	private static string GetFileName(string relativePath)
	{
		int separator = relativePath.LastIndexOf('/');
		return separator < 0 ? relativePath : relativePath[(separator + 1)..];
	}

	/// <summary>
	/// Writes the mapping in a form meant to be read before deciding whether to apply it.
	/// </summary>
	public void Write(TextWriter writer)
	{
		writer.WriteLine($"Matches: {Matches.Count.ToString(CultureInfo.InvariantCulture)}");
		writer.WriteLine($"Unmatched in the ripped package: {UnmatchedRipped.Count.ToString(CultureInfo.InvariantCulture)}");
		writer.WriteLine($"Unmatched in the official package: {UnmatchedOfficial.Count.ToString(CultureInfo.InvariantCulture)}");
		writer.WriteLine($"Conflicts: {Conflicts.Count.ToString(CultureInfo.InvariantCulture)}");

		if (Conflicts.Count > 0)
		{
			writer.WriteLine();
			writer.WriteLine("## Conflicts, which must be resolved before applying");
			foreach (string conflict in Conflicts)
			{
				writer.WriteLine($"- {conflict}");
			}
		}

		writer.WriteLine();
		writer.WriteLine("## Matches");
		writer.WriteLine("oldGuid,newGuid,matchedBy,rippedPath,officialPath");
		foreach (GuidMatch match in Matches)
		{
			writer.WriteLine($"{match.OldGuid},{match.NewGuid},{match.Kind},{match.RippedPath},{match.OfficialPath}");
		}

		if (UnmatchedRipped.Count > 0)
		{
			writer.WriteLine();
			writer.WriteLine("## Unmatched in the ripped package, whose references cannot be repointed");
			foreach (AssetIdentity identity in UnmatchedRipped)
			{
				writer.WriteLine($"{identity.Guid},{identity.RelativePath}");
			}
		}
	}
}
