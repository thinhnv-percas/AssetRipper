namespace AssetRipper.Validation.Unity;

/// <summary>
/// The editor version a project declares, read from <c>ProjectSettings/ProjectVersion.txt</c>.
/// </summary>
/// <remarks>
/// This is the version a build has to use, and it is read rather than written down: a recovered
/// project carries the version of the game it was recovered from, and building it with another
/// editor tests an upgrade, not a recovery. The same file is what <c>game-ci/unity-builder</c> reads
/// when its <c>unityVersion</c> is <c>auto</c>.
/// </remarks>
public sealed record ProjectVersion(string EditorVersion, string? Revision)
{
	public const string RelativePath = "ProjectSettings/ProjectVersion.txt";

	public static ProjectVersion? Read(string projectPath)
	{
		string path = Path.Combine(projectPath, RelativePath);
		return File.Exists(path) ? Parse(File.ReadAllText(path)) : null;
	}

	public static ProjectVersion? Parse(string text)
	{
		string? version = null;
		string? revision = null;

		foreach (string rawLine in text.Split('\n'))
		{
			string line = rawLine.Trim();

			if (line.StartsWith("m_EditorVersionWithRevision:", StringComparison.Ordinal))
			{
				// "2021.3.45f1 (0da89fac8e79)"
				string value = line["m_EditorVersionWithRevision:".Length..].Trim();
				int open = value.IndexOf('(');
				int close = value.IndexOf(')');

				if (open > 0 && close > open)
				{
					version ??= value[..open].Trim();
					revision = value[(open + 1)..close].Trim();
				}
			}
			else if (line.StartsWith("m_EditorVersion:", StringComparison.Ordinal))
			{
				version = line["m_EditorVersion:".Length..].Trim();
			}
		}

		return string.IsNullOrEmpty(version) ? null : new ProjectVersion(version, revision);
	}
}
