namespace AssetRipper.Validation.Unity;

/// <summary>
/// Runs the build inside a GameCI <c>unityci/editor</c> image, as unity-builder's default strategy does.
/// </summary>
/// <remarks>
/// It needs Docker and an editor licence in the environment (<c>UNITY_LICENSE</c>, or
/// <c>UNITY_SERIAL</c> with <c>UNITY_EMAIL</c>/<c>UNITY_PASSWORD</c>), which are passed to the container
/// by name and never on a command line. Without either, it declines rather than starting a container
/// that can only fail on activation.
/// </remarks>
public sealed class DockerUnityBuildProvider(IProcessRunner? runner = null, Func<string, string?>? environment = null) : IUnityBuildProvider
{
	private readonly IProcessRunner runner = runner ?? new SystemProcessRunner();
	private readonly Func<string, string?> environment = environment ?? Environment.GetEnvironmentVariable;

	public string Name => "docker";

	/// <summary>The unityci/editor module a build target needs.</summary>
	public static string ModuleFor(string target) => target switch
	{
		"Android" => "android",
		"iOS" => "ios",
		"StandaloneLinux64" => "linux-il2cpp",
		"StandaloneWindows" or "StandaloneWindows64" => "windows-mono",
		"StandaloneOSX" => "mac-mono",
		"WebGL" => "webgl",
		_ => "base",
	};

	public static string ImageFor(string version, string target) => $"unityci/editor:ubuntu-{version}-{ModuleFor(target)}-3";

	public bool CanBuild(RecoveredUnityProject project, BuildRequest request, out string reason)
	{
		string? version = request.UnityVersion ?? project.Version?.EditorVersion;

		if (version is null)
		{
			reason = $"no editor version: {ProjectVersion.RelativePath} is missing and none was given";
			return false;
		}

		bool licensed = environment("UNITY_LICENSE") is { Length: > 0 } || environment("UNITY_SERIAL") is { Length: > 0 };

		if (!licensed)
		{
			reason = "no editor licence in the environment (UNITY_LICENSE or UNITY_SERIAL)";
			return false;
		}

		ProcessOutcome docker = runner.Run("docker", ["version", "--format", "{{.Server.Version}}"], project.ProjectPath, TimeSpan.FromSeconds(30));

		if (docker.ExitCode != 0)
		{
			reason = "docker is not available";
			return false;
		}

		reason = "";
		return true;
	}

	public UnityBuildResult Build(RecoveredUnityProject project, BuildRequest request)
	{
		string version = request.UnityVersion ?? project.Version?.EditorVersion ?? "";
		string image = ImageFor(version, request.TargetPlatform);
		DateTimeOffset started = DateTimeOffset.UtcNow;
		RecoveredProjectFingerprint fingerprint = RecoveredProjectFingerprint.Compute(project.ProjectPath);

		RecoveredUnityProject inside = project with { ProjectPath = "/project" };
		BuildRequest containerRequest = request with { ProjectPath = "/project", BuildPath = "/project/Builds/" + request.TargetPlatform };
		string logName = $"AssetRipperValidation-{started:yyyyMMddTHHmmss}.log";
		List<string> editorArguments = LocalUnityBuildProvider.Arguments(inside, containerRequest, "/project/Logs/" + logName);

		List<string> arguments = ["run", "--rm", "-v", $"{project.ProjectPath}:/project", "-w", "/project"];
		foreach (string variable in (string[])["UNITY_LICENSE", "UNITY_SERIAL", "UNITY_EMAIL", "UNITY_PASSWORD"])
		{
			arguments.AddRange(["-e", variable]);
		}
		arguments.AddRange([image, "unity-editor", .. editorArguments]);

		Directory.CreateDirectory(Path.Combine(project.ProjectPath, "Logs"));
		string? installed = ValidationScript.Install(project.ProjectPath);
		ProcessOutcome outcome;
		try
		{
			outcome = runner.Run("docker", arguments, project.ProjectPath, request.Timeout);
		}
		finally
		{
			ValidationScript.Remove(installed);
		}

		string logFile = Path.Combine(project.ProjectPath, "Logs", logName);
		string log = File.Exists(logFile) ? File.ReadAllText(logFile) : outcome.StandardOutput;
		string artifact = Path.Combine(project.ProjectPath, "Builds", request.TargetPlatform);
		bool exists = File.Exists(artifact) || Directory.Exists(artifact);
		UnityLogClassifier.Classification classification = UnityLogClassifier.Classify(outcome.ExitCode, log, exists);

		return new UnityBuildResult
		{
			Status = classification.Status,
			Reason = classification.Reason,
			Transient = classification.Transient,
			CompilerErrors = classification.CompilerErrors,
			Provider = $"{Name}:{image}",
			UnityVersion = version,
			ProjectPath = project.ProjectPath,
			TargetPlatform = request.TargetPlatform,
			Fingerprint = fingerprint,
			ExitCode = outcome.ExitCode,
			StandardOutput = outcome.StandardOutput,
			StandardError = outcome.StandardError,
			UnityLogPath = File.Exists(logFile) ? logFile : null,
			BuildArtifact = artifact,
			ArtifactExists = exists,
			CommandLine = ["docker", .. arguments],
			StartedUtc = started,
			FinishedUtc = DateTimeOffset.UtcNow,
		};
	}
}
