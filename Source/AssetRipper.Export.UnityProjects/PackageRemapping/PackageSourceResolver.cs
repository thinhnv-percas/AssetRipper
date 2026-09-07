namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// When a git source may be cloned.
/// </summary>
public enum GitFetchMode
{
	/// <summary>
	/// Use what is already on disk. A source that has never been fetched resolves to nothing.
	/// </summary>
	Never,
	/// <summary>
	/// Clone a source that has never been fetched, and leave the rest alone.
	/// </summary>
	WhenMissing,
	/// <summary>
	/// Replace every clone with a fresh one.
	/// </summary>
	Always,
}

/// <param name="Directory">The package's own folder, the one holding its manifest.</param>
/// <param name="Dependency">
/// What the project's manifest has to say for the package manager to install this exact package: a
/// version for one out of a registry, a <c>file:</c> path for one on disk, the repository url for one
/// out of git. Empty when the source could not say.
/// </param>
public readonly record struct ResolvedPackage(string Directory, string Name, string Version, string Dependency);

/// <summary>
/// What one source turned out to hold.
/// </summary>
public sealed class PackageSourceResult
{
	public required PackageSource Source { get; init; }

	/// <summary>
	/// Where the source resolved to on disk, which for a git source is its clone.
	/// </summary>
	public required string Directory { get; init; }

	public List<ResolvedPackage> Packages { get; } = [];

	/// <summary>
	/// Why the source yielded nothing, when that is something other than it holding no packages.
	/// </summary>
	public string? Error { get; set; }

	/// <summary>
	/// What a fetch said, for a git source that was fetched.
	/// </summary>
	public string? FetchMessage { get; set; }
}

/// <summary>
/// Turns the configured sources into the package folders an export reads.
/// </summary>
public static class PackageSourceResolver
{
	/// <summary>
	/// The file a package is recognised by, and where its name and version come from.
	/// </summary>
	public const string PackageManifestName = "package.json";

	public static List<PackageSourceResult> Resolve(IEnumerable<PackageSource> sources, GitFetchMode gitMode)
	{
		List<PackageSourceResult> results = [];

		foreach (PackageSource source in sources)
		{
			results.Add(Resolve(source, gitMode));
		}

		return results;
	}

	public static PackageSourceResult Resolve(PackageSource source, GitFetchMode gitMode)
	{
		if (source.IsEmpty)
		{
			return new PackageSourceResult { Source = source, Directory = "", Error = "The source has no location." };
		}

		string directory = source.Location;
		string? fetchMessage = null;

		if (source.Kind is PackageSourceKind.Git)
		{
			directory = GitPackageFetcher.GetCloneDirectory(source);
			bool cloned = GitPackageFetcher.IsCloned(source);

			if (gitMode is GitFetchMode.Always || (gitMode is GitFetchMode.WhenMissing && !cloned))
			{
				GitFetchResult fetch = GitPackageFetcher.Fetch(source, update: gitMode is GitFetchMode.Always);
				fetchMessage = fetch.Message;
				if (!fetch.Success)
				{
					return new PackageSourceResult { Source = source, Directory = directory, Error = fetch.Message };
				}
			}
			else if (!cloned)
			{
				return new PackageSourceResult
				{
					Source = source,
					Directory = directory,
					Error = "The repository has not been cloned yet. Fetch it from the Package Sources page.",
				};
			}
		}

		if (source.Subfolder.Length > 0)
		{
			directory = Path.Join(directory, source.Subfolder);
		}

		PackageSourceResult result = new() { Source = source, Directory = directory, FetchMessage = fetchMessage };

		if (!Directory.Exists(directory))
		{
			result.Error = $"There is nothing at {directory}.";
			return result;
		}

		// A git package's dependency is written against the clone's root rather than the folder the scan
		// started in, because a repository holding several packages needs a path per package.
		string root = source.Kind is PackageSourceKind.Git ? GitPackageFetcher.GetCloneDirectory(source) : directory;

		foreach (ResolvedPackage package in FindPackages(directory))
		{
			result.Packages.Add(package with { Dependency = BuildDependency(source, root, package) });
		}

		return result;
	}

	/// <summary>
	/// What the project's manifest says to install the package the source holds.
	/// </summary>
	/// <remarks>
	/// A version only means anything for a package a registry has. The other two kinds exist precisely
	/// because the package is somewhere a registry is not, so a version would name a different package
	/// than the one the export just took the guids out of, or none at all.
	/// <para>
	/// A local package is written with an absolute path. The package manager also takes one relative to
	/// the project's Packages folder, and a package worth pointing at this way is outside the project, so
	/// the relative form would be a climb out of it that only holds while the export stays where it was
	/// written.
	/// </para>
	/// </remarks>
	private static string BuildDependency(PackageSource source, string root, ResolvedPackage package)
	{
		switch (source.Kind)
		{
			case PackageSourceKind.Git:
				string path = GetRelativePath(root, package.Directory);
				string text = source.Location;
				if (path.Length > 0)
				{
					text += $"?path={path}";
				}
				if (source.Revision.Length > 0)
				{
					text += $"#{source.Revision}";
				}
				return text;

			case PackageSourceKind.Folder:
				return $"file:{Path.GetFullPath(package.Directory).Replace('\\', '/')}";

			default:
				return package.Version;
		}
	}

	/// <summary>
	/// Where a package sits inside its repository, in the form a manifest wants, or empty when it is the
	/// repository itself.
	/// </summary>
	private static string GetRelativePath(string root, string directory)
	{
		string relative = Path.GetRelativePath(root, directory).Replace('\\', '/').Trim('/');
		return relative is "." or "" ? "" : relative;
	}

	/// <summary>
	/// Every package under a directory, recognised by its manifest.
	/// </summary>
	/// <remarks>
	/// The directory is a package when it holds a manifest of its own, and a folder of them otherwise,
	/// which is what a package cache is. Only one level down is looked at: deeper than that is a package's
	/// own contents, and a Unity package routinely embeds test packages that are not what was asked for.
	/// </remarks>
	public static List<ResolvedPackage> FindPackages(string directory)
	{
		List<ResolvedPackage> packages = [];

		if (TryRead(directory, out ResolvedPackage package))
		{
			packages.Add(package);
			return packages;
		}

		try
		{
			foreach (string child in Directory.EnumerateDirectories(directory))
			{
				if (TryRead(child, out package))
				{
					packages.Add(package);
				}
			}
		}
		catch (IOException)
		{
		}

		packages.Sort(static (left, right) => string.CompareOrdinal(left.Name, right.Name));
		return packages;
	}

	private static bool TryRead(string directory, out ResolvedPackage package)
	{
		string manifest = Path.Join(directory, PackageManifestName);
		if (File.Exists(manifest) && UnityPackageInfo.Read(manifest) is UnityPackageInfo info)
		{
			// The dependency is filled in by whoever knows the source; the version stands in until then.
			string version = ResolveVersion(info, directory);
			package = new ResolvedPackage(directory, info.Name, version, version);
			return true;
		}

		package = default;
		return false;
	}

	/// <summary>
	/// A cached package's folder is named after the version it holds, which is the answer when its own
	/// manifest does not carry one.
	/// </summary>
	internal static string ResolveVersion(UnityPackageInfo info, string directory)
	{
		if (info.Version.Length > 0)
		{
			return info.Version;
		}

		string folderName = Path.GetFileName(directory.TrimEnd('/', '\\'));
		int separator = folderName.LastIndexOf('@');
		return separator >= 0 ? folderName[(separator + 1)..] : "";
	}
}
