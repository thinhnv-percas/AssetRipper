namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// What of a package Unity imports, and what of that a player build can contain.
/// </summary>
/// <remarks>
/// A ripped asset came out of a build, so the package file it pairs with has to be one a build can carry. Two kinds
/// cannot be, and both were being paired on Kitty Knots: a file under a folder Unity never imports - the game's
/// <c>Resources/TMP Settings.asset</c> went to the copy in Core RP's <c>Samples~</c>, which deletes the game's own and
/// points every reference at a guid no project has - and an asset under an <c>Editor</c> folder, which never reaches a
/// build: the game's <c>circle.png</c> went to DemiLib's editor icon and <c>Link.png</c> to LookDev's.
/// </remarks>
public static class PackageAssetVisibility
{
	/// <summary>
	/// Whether Unity imports a path inside a package: no part of it may be hidden (a leading '.'), end in '~', be named
	/// <c>cvs</c>, or carry the <c>.tmp</c> extension.
	/// </summary>
	/// <param name="relativePath">The path relative to the package root, with either separator.</param>
	public static bool IsImported(string relativePath)
	{
		foreach (string part in Split(relativePath))
		{
			if (part.StartsWith('.') || part.EndsWith('~') || part.Equals("cvs", StringComparison.OrdinalIgnoreCase)
				|| part.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
		}

		return true;
	}

	/// <summary>
	/// Whether an asset at this path can be part of a player build, which an asset under an <c>Editor</c> folder never is.
	/// </summary>
	/// <remarks>
	/// For assets only. Code under an <c>Editor</c> folder can still be compiled into a player by an assembly definition,
	/// so scripts and assemblies are judged by <see cref="IsImported"/> alone.
	/// </remarks>
	public static bool CanBeInBuild(string relativePath)
	{
		return IsImported(relativePath)
			&& !Split(relativePath).SkipLast(1).Any(static part => part.Equals("Editor", StringComparison.OrdinalIgnoreCase));
	}

	private static string[] Split(string relativePath)
	{
		return relativePath.Split(['/', '\\'], StringSplitOptions.RemoveEmptyEntries);
	}
}
