namespace AssetRipper.Validation.Unity;

/// <summary>A recovered Unity project on disk, with the version it declares.</summary>
public sealed record RecoveredUnityProject(string ProjectPath, ProjectVersion? Version)
{
	public static RecoveredUnityProject Open(string projectPath)
	{
		string full = Path.GetFullPath(projectPath);

		if (!Directory.Exists(Path.Combine(full, "Assets")) || !Directory.Exists(Path.Combine(full, "ProjectSettings")))
		{
			throw new DirectoryNotFoundException(
				$"{full} is not a Unity project (no Assets/ and ProjectSettings/). For a rip, pass the game directory inside the output, not the output root.");
		}

		return new RecoveredUnityProject(full, ProjectVersion.Read(full));
	}
}
