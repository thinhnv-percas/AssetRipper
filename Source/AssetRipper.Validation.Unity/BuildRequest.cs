namespace AssetRipper.Validation.Unity;

/// <summary>
/// Everything a Unity build needs to be told, and nothing it should infer.
/// </summary>
/// <remarks>
/// Modelled on the inputs of <c>game-ci/unity-builder</c> - an explicit target platform, an explicit
/// project path, a build method, custom parameters, GPU on or off - without its GitHub Action
/// plumbing. <see cref="UnityVersion"/> is null to mean "read it from the project", which is the only
/// honest default for a recovered project.
/// </remarks>
public sealed record BuildRequest
{
	public required string ProjectPath { get; init; }

	/// <summary>A Unity <c>BuildTarget</c> name, e.g. <c>Android</c>, <c>iOS</c>, <c>StandaloneLinux64</c>.</summary>
	public required string TargetPlatform { get; init; }

	/// <summary>Null: take it from <c>ProjectSettings/ProjectVersion.txt</c>.</summary>
	public string? UnityVersion { get; init; }

	public string BuildMethod { get; init; } = ValidationScript.BuildMethod;

	/// <summary>Where the player is written. Null: <c>&lt;project&gt;/Builds/&lt;target&gt;</c>.</summary>
	public string? BuildPath { get; init; }

	/// <summary>Extra arguments appended verbatim to the Unity command line.</summary>
	public IReadOnlyList<string> CustomParameters { get; init; } = [];

	/// <summary>Launch without <c>-nographics</c>, as unity-builder's <c>enableGpu</c> does.</summary>
	public bool EnableGpu { get; init; }

	/// <summary>Attempts in all. Only a failure the classifier marks transient is retried.</summary>
	public int MaxAttempts { get; init; } = 1;

	/// <summary>An explicit editor executable; null lets the provider look for one.</summary>
	public string? EditorPath { get; init; }

	public TimeSpan Timeout { get; init; } = TimeSpan.FromHours(2);

	public string ResolveBuildPath() => BuildPath ?? Path.Combine(ProjectPath, "Builds", TargetPlatform);
}
