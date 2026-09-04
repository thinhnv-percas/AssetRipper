using AssetRipper.Import.Logging;

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
