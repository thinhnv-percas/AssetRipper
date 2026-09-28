namespace AssetRipper.Validation.Unity;

/// <summary>Finds an installed editor of an exact version, and says everywhere it looked.</summary>
public static class UnityEditorLocator
{
	public static IReadOnlyList<string> Candidates(string version, string? explicitPath)
	{
		List<string> candidates = [];

		if (!string.IsNullOrEmpty(explicitPath))
		{
			candidates.Add(explicitPath);
		}

		foreach (string variable in (string[])["UNITY_EDITOR", "UNITY_PATH", "UNITY_EXECUTABLE"])
		{
			if (Environment.GetEnvironmentVariable(variable) is { Length: > 0 } value)
			{
				candidates.Add(value);
			}
		}

		string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

		if (OperatingSystem.IsWindows())
		{
			candidates.Add($@"C:\Program Files\Unity\Hub\Editor\{version}\Editor\Unity.exe");
			candidates.Add($@"C:\Program Files\Unity {version}\Editor\Unity.exe");
		}
		else if (OperatingSystem.IsMacOS())
		{
			candidates.Add($"/Applications/Unity/Hub/Editor/{version}/Unity.app/Contents/MacOS/Unity");
			candidates.Add($"/Applications/Unity {version}/Unity.app/Contents/MacOS/Unity");
		}
		else
		{
			candidates.Add(Path.Combine(home, "Unity", "Hub", "Editor", version, "Editor", "Unity"));
			candidates.Add($"/opt/unity/editors/{version}/Editor/Unity");
			// The layout inside the GameCI unityci/editor images.
			candidates.Add("/opt/unity/Editor/Unity");
		}

		return candidates;
	}

	public static string? Find(string version, string? explicitPath) => Candidates(version, explicitPath).FirstOrDefault(File.Exists);
}
