using AssetRipper.Import.Logging;
using AssetRipper.Primitives;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;

/// <summary>
/// Finds the IL2CPP runtime struct layout directory on disk.
/// </summary>
/// <remarks>
/// The database is optional. Every caller treats a null result as "no runtime field names", which is
/// exactly the behaviour before it existed, so a missing directory is never an error.
/// </remarks>
public static class StructDbLocator
{
	/// <summary>Directory name looked for in each candidate root.</summary>
	public const string DirectoryName = "structdb";

	/// <summary>Environment variable that overrides every other candidate.</summary>
	public const string EnvironmentVariable = "ASSETRIPPER_IL2CPP_STRUCTDB";

	/// <summary>
	/// Returns the first directory that exists and holds at least one layout file, or null.
	/// </summary>
	/// <param name="configuredPath">
	/// A path from settings. Taken over every default when set, and reported when it does not exist,
	/// because a path the user typed being ignored silently is its own bug.
	/// </param>
	public static string? Find(string? configuredPath = null)
	{
		if (!string.IsNullOrWhiteSpace(configuredPath))
		{
			if (IsUsable(configuredPath))
			{
				return configuredPath;
			}

			// A nested structdb directory is a common shape for a downloaded archive.
			string nested = Path.Join(configuredPath, DirectoryName);
			if (IsUsable(nested))
			{
				return nested;
			}

			Logger.Warning(LogCategory.Import,
				$"IL2CPP struct database path '{configuredPath}' does not contain any layout files. Falling back to the default locations.");
		}

		foreach (string candidate in EnumerateDefaultCandidates())
		{
			if (IsUsable(candidate))
			{
				return candidate;
			}
		}

		return null;
	}

	/// <summary>The default locations, in the order they are tried.</summary>
	public static IEnumerable<string> EnumerateDefaultCandidates()
	{
		string? fromEnvironment = Environment.GetEnvironmentVariable(EnvironmentVariable);
		if (!string.IsNullOrWhiteSpace(fromEnvironment))
		{
			yield return fromEnvironment;
		}

		string baseDirectory = AppContext.BaseDirectory;
		yield return Path.Join(baseDirectory, DirectoryName);
		yield return Path.Join(baseDirectory, "StreamingAssets", DirectoryName);

		string? executableDirectory = Path.GetDirectoryName(Environment.ProcessPath);
		if (!string.IsNullOrEmpty(executableDirectory) && executableDirectory != baseDirectory.TrimEnd(Path.DirectorySeparatorChar))
		{
			yield return Path.Join(executableDirectory, DirectoryName);
		}

		string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		if (!string.IsNullOrEmpty(applicationData))
		{
			yield return Path.Join(applicationData, "AssetRipper", DirectoryName);
		}
	}

	/// <summary>
	/// What a UI needs to tell the user whether a database was found, and how much it covers.
	/// </summary>
	/// <param name="Directory">Where it was found, or null when nothing was.</param>
	/// <param name="VersionCount">Unity versions the database can serve.</param>
	/// <param name="Oldest">Oldest version covered.</param>
	/// <param name="Newest">Newest version covered.</param>
	public readonly record struct StructDbSummary(string? Directory, int VersionCount, UnityVersion Oldest, UnityVersion Newest)
	{
		public bool Found => Directory is not null;
	}

	private static (string? Key, StructDbSummary Summary)? cachedSummary;

	/// <summary>
	/// Describes the database <see cref="Find"/> would use. Cached, because indexing hundreds of files on
	/// every page render would be wasteful, and quiet, so it does not repeat itself in the log.
	/// </summary>
	public static StructDbSummary Summarize(string? configuredPath = null)
	{
		string key = configuredPath ?? "";
		if (cachedSummary is { } cached && cached.Key == key)
		{
			return cached.Summary;
		}

		StructDbSummary summary = default;

		if (Find(configuredPath) is string directory
			&& StructDbCatalog.TryCreate(directory, log: false) is StructDbCatalog catalog)
		{
			List<UnityVersion> versions = [.. catalog.AvailableVersions];
			summary = new StructDbSummary(directory, versions.Count, versions[0], versions[^1]);
		}

		cachedSummary = (key, summary);
		return summary;
	}

	/// <summary>Drops the cache, so a database added while the application is running is noticed.</summary>
	public static void ClearSummaryCache() => cachedSummary = null;

	private static bool IsUsable(string path)
	{
		if (!Directory.Exists(path))
		{
			return false;
		}

		foreach (string _ in Directory.EnumerateFiles(path, "*-x64.json"))
		{
			return true;
		}
		foreach (string _ in Directory.EnumerateFiles(path, "*-x64.json.gz"))
		{
			return true;
		}
		return false;
	}
}
