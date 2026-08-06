namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// A located Ghidra installation that headless analysis can be run from.
/// </summary>
public sealed class GhidraInstallation
{
	/// <summary>
	/// The environment variable Ghidra itself uses to locate an installation.
	/// </summary>
	public const string EnvironmentVariable = "GHIDRA_INSTALL_DIR";

	/// <summary>
	/// Set this to use a specific installation instead of searching.
	/// </summary>
	public static string? OverrideDirectory { get; set; }

	public string Directory { get; }

	/// <summary>
	/// The full path of the headless analyzer script.
	/// </summary>
	public string HeadlessAnalyzerPath { get; }

	private GhidraInstallation(string directory, string headlessAnalyzerPath)
	{
		Directory = directory;
		HeadlessAnalyzerPath = headlessAnalyzerPath;
	}

	/// <summary>
	/// The name of the headless analyzer script for the current platform.
	/// </summary>
	public static string HeadlessAnalyzerFileName => OperatingSystem.IsWindows() ? "analyzeHeadless.bat" : "analyzeHeadless";

	/// <summary>
	/// Gets the path the headless analyzer would have inside an installation directory.
	/// </summary>
	public static string GetHeadlessAnalyzerPath(string installationDirectory)
	{
		return Path.Join(installationDirectory, "support", HeadlessAnalyzerFileName);
	}

	/// <summary>
	/// Determines whether a directory looks like a Ghidra installation.
	/// </summary>
	public static bool IsInstallationDirectory(string directory)
	{
		return !string.IsNullOrEmpty(directory) && File.Exists(GetHeadlessAnalyzerPath(directory));
	}

	/// <summary>
	/// Locates a Ghidra installation, preferring <see cref="OverrideDirectory"/> and then
	/// <see cref="EnvironmentVariable"/>.
	/// </summary>
	public static bool TryLocate([NotNullWhen(true)] out GhidraInstallation? installation)
	{
		foreach (string? candidate in GetCandidateDirectories())
		{
			if (!string.IsNullOrEmpty(candidate) && IsInstallationDirectory(candidate))
			{
				installation = new GhidraInstallation(candidate, GetHeadlessAnalyzerPath(candidate));
				return true;
			}
		}

		installation = null;
		return false;
	}

	private static IEnumerable<string?> GetCandidateDirectories()
	{
		yield return OverrideDirectory;
		yield return Environment.GetEnvironmentVariable(EnvironmentVariable);

		// A sibling of the executable is a convenient place to drop an installation.
		yield return Path.Join(AppContext.BaseDirectory, "ghidra");
	}
}
