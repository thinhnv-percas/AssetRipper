using AssetRipper.IO.Files;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Finds where a package's contents ended up in an export.
/// </summary>
/// <remarks>
/// Nothing in the export says which folder a package was ripped into: the assets are just files under
/// <c>Assets</c>. What does identify it is the shape underneath. A package holds its assets at fixed
/// relative paths, so if enough of those paths exist under one folder, that folder is where the package
/// landed. Anchoring on the shape rather than the folder name means a renamed or nested export is still
/// found, and a folder that merely shares a name is not.
/// <para>
/// The scripts half of a remap never needs this. A decompiled script's guid is derived from the type it
/// holds, so the official assembly identifies it wherever it was written. This is only for the assets a
/// package ships alongside its code, shaders most of all.
/// </para>
/// </remarks>
public static class RippedPackageLocator
{
	/// <summary>
	/// How many of a package's assets have to be found before a folder is accepted as its home.
	/// </summary>
	/// <remarks>
	/// A single agreement proves nothing: one file name repeating somewhere unrelated would be enough.
	/// Requiring several, and a share of the package rather than a flat count, keeps a large package
	/// from being located by a handful of coincidences.
	/// </remarks>
	public const int MinimumAgreements = 3;

	/// <summary>
	/// What share of the package's assets have to be found in the same place.
	/// </summary>
	public const double MinimumShare = 0.25;

	/// <summary>
	/// Finds the folder an official package's assets were ripped into, or null when nothing convincing
	/// was found.
	/// </summary>
	/// <param name="exportRoot">The exported project's assets folder.</param>
	/// <param name="official">The official package's assets, as scanned from its meta files.</param>
	public static string? Locate(string exportRoot, IReadOnlyList<AssetIdentity> official, FileSystem? fileSystem = null)
	{
		fileSystem ??= LocalFileSystem.Instance;

		if (official.Count == 0 || !fileSystem.Directory.Exists(exportRoot))
		{
			return null;
		}

		// Only assets that sit in a folder are useful anchors. One at the package root would imply the
		// export root itself, which every package would agree on.
		List<string> anchors = official
			.Select(static identity => identity.RelativePath)
			.Where(static path => path.Contains('/'))
			.ToList();

		if (anchors.Count == 0)
		{
			return null;
		}

		Dictionary<string, int> agreementsByRoot = new(StringComparer.OrdinalIgnoreCase);
		foreach (string path in fileSystem.Directory.EnumerateFiles(exportRoot, "*", SearchOption.AllDirectories))
		{
			string relative = MetaGuidScanner.GetRelativePath(exportRoot, path);

			foreach (string anchor in anchors)
			{
				// The package's path has to be the tail of the exported one, on a folder boundary, so
				// that Shaders/TMP.shader is not matched by OtherShaders/TMP.shader.
				if (relative.Length <= anchor.Length
					|| relative[relative.Length - anchor.Length - 1] != '/'
					|| !relative.EndsWith(anchor, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}

				string root = relative[..^(anchor.Length + 1)];
				agreementsByRoot[root] = agreementsByRoot.GetValueOrDefault(root) + 1;
			}
		}

		if (agreementsByRoot.Count == 0)
		{
			return null;
		}

		(string bestRoot, int agreements) = agreementsByRoot.MaxBy(static pair => pair.Value);

		if (agreements < MinimumAgreements || agreements < anchors.Count * MinimumShare)
		{
			return null;
		}

		return fileSystem.Path.Join(exportRoot, bestRoot);
	}
}
