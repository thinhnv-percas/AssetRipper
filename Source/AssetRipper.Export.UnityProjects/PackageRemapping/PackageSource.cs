using System.Text.Json.Serialization;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Where a set of official packages comes from.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<PackageSourceKind>))]
public enum PackageSourceKind
{
	/// <summary>
	/// A folder holding one package per subfolder, which is the shape of a project's Library/PackageCache.
	/// </summary>
	Cache,
	/// <summary>
	/// A folder on disk, either one package or a folder of them. The same scan as a cache, named apart
	/// because what someone points at is usually a package they checked out rather than a cache.
	/// </summary>
	Folder,
	/// <summary>
	/// A git repository, cloned locally and then read as a folder.
	/// </summary>
	Git,
}

/// <summary>
/// One place to look for official packages.
/// </summary>
/// <remarks>
/// A package is only useful here for the guids in its meta files, so every kind ends up as a folder on
/// disk. A git source is the one that is not a folder to begin with, and it becomes one by being cloned.
/// </remarks>
public sealed class PackageSource
{
	[JsonPropertyName("kind")]
	public PackageSourceKind Kind { get; set; }

	/// <summary>
	/// A folder path, or the repository url for a git source.
	/// </summary>
	[JsonPropertyName("location")]
	public string Location { get; set; } = "";

	/// <summary>
	/// The branch, tag or commit to check out. Empty takes the repository's default branch.
	/// </summary>
	[JsonPropertyName("revision")]
	public string Revision { get; set; } = "";

	/// <summary>
	/// The folder inside the source that holds the package or packages. Empty is the source itself.
	/// </summary>
	/// <remarks>
	/// A repository routinely holds a Unity project rather than a bare package, which is why a package
	/// manager dependency on one carries a path of its own.
	/// </remarks>
	[JsonPropertyName("subfolder")]
	public string Subfolder { get; set; } = "";

	/// <summary>
	/// Whether an export looks at this source. Turning one off keeps it in the list.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; } = true;

	public bool IsEmpty => Location.Length == 0;

	/// <summary>
	/// Reads a package manager git dependency as a source.
	/// </summary>
	/// <remarks>
	/// A dependency is written <c>https://host/owner/repo.git?path=/Packages/com.x#v1.2.3</c>, so the
	/// revision and the subfolder are already in what someone copies out of a manifest. Taking them from
	/// the string is what lets the whole thing be pasted into one box.
	/// </remarks>
	public static PackageSource FromGitUrl(string text)
	{
		string url = text.Trim();
		string revision = "";
		string subfolder = "";

		// The fragment is last in a url, so it comes off first.
		int fragment = url.LastIndexOf('#');
		if (fragment >= 0)
		{
			revision = url[(fragment + 1)..].Trim();
			url = url[..fragment];
		}

		int query = url.LastIndexOf("?path=", StringComparison.OrdinalIgnoreCase);
		if (query >= 0)
		{
			subfolder = url[(query + "?path=".Length)..].Trim().Trim('/');
			url = url[..query];
		}

		return new PackageSource
		{
			Kind = PackageSourceKind.Git,
			Location = url,
			Revision = revision,
			Subfolder = subfolder,
		};
	}

	/// <summary>
	/// How the source reads in a list, which is how it is told apart from the others.
	/// </summary>
	public string Describe()
	{
		string text = Location;

		if (Revision.Length > 0)
		{
			text += $" @ {Revision}";
		}

		if (Subfolder.Length > 0)
		{
			text += $" ({Subfolder})";
		}

		return text;
	}
}
