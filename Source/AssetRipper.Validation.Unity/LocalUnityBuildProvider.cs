namespace AssetRipper.Validation.Unity;

/// <summary>
/// Runs an editor installed on this machine: <c>-batchmode -quit -projectPath -executeMethod</c>.
/// </summary>
/// <remarks>
/// The equivalent of unity-builder's <c>local-system</c> strategy. The editor has to be the exact
/// version the project declares; a near version would upgrade the project on import, and a build of
/// an upgraded project validates the upgrade.
/// </remarks>
public sealed class LocalUnityBuildProvider(IProcessRunner? runner = null, Func<string, string?, string?>? locate = null) : IUnityBuildProvider
{
	private readonly IProcessRunner runner = runner ?? new SystemProcessRunner();
	private readonly Func<string, string?, string?> locate = locate ?? UnityEditorLocator.Find;

	public string Name => "local";

	public bool CanBuild(RecoveredUnityProject project, BuildRequest request, out string reason)
	{
		string? version = request.UnityVersion ?? project.Version?.EditorVersion;

		if (version is null)
		{
			reason = $"no editor version: {ProjectVersion.RelativePath} is missing and none was given";
			return false;
		}

		if (locate(version, request.EditorPath) is null)
		{
			reason = $"no Unity {version} editor at any of: {string.Join(", ", UnityEditorLocator.Candidates(version, request.EditorPath))}";
			return false;
		}

		reason = "";
		return true;
	}

	public static List<string> Arguments(RecoveredUnityProject project, BuildRequest request, string logFile)
	{
		List<string> arguments = ["-batchmode"];

		if (!request.EnableGpu)
		{
			arguments.Add("-nographics");
		}

		arguments.AddRange([
			"-quit",
			"-projectPath", project.ProjectPath,
			"-buildTarget", request.TargetPlatform,
			"-executeMethod", request.BuildMethod,
			"-logFile", logFile,
			"-customBuildTarget", request.TargetPlatform,
			"-customBuildPath", request.ResolveBuildPath(),
		]);
		arguments.AddRange(request.CustomParameters);
		return arguments;
	}

	public UnityBuildResult Build(RecoveredUnityProject project, BuildRequest request)
	{
		string version = request.UnityVersion ?? project.Version?.EditorVersion ?? "";
		string? editor = locate(version, request.EditorPath);
		DateTimeOffset started = DateTimeOffset.UtcNow;

		// Fingerprinted before the validation script goes in, so the hash is of the recovery alone.
		RecoveredProjectFingerprint fingerprint = RecoveredProjectFingerprint.Compute(project.ProjectPath);

		if (editor is null)
		{
			return UnityBuildPipeline.Build(project, request, [this]);
		}

		UnityBuildResult? result = null;

		for (int attempt = 1; attempt <= Math.Max(1, request.MaxAttempts); attempt++)
		{
			string logDirectory = Path.Combine(project.ProjectPath, "Logs");
			Directory.CreateDirectory(logDirectory);
			string logFile = Path.Combine(logDirectory, $"AssetRipperValidation-{started:yyyyMMddTHHmmss}-{attempt}.log");
			List<string> arguments = Arguments(project, request, logFile);

			string? installed = ValidationScript.Install(project.ProjectPath);
			ProcessOutcome outcome;
			try
			{
				outcome = runner.Run(editor, arguments, project.ProjectPath, request.Timeout);
			}
			finally
			{
				ValidationScript.Remove(installed);
			}

			string log = File.Exists(logFile) ? File.ReadAllText(logFile) : outcome.StandardOutput;
			string artifact = request.ResolveBuildPath();
			bool artifactExists = File.Exists(artifact) || Directory.Exists(artifact);
			UnityLogClassifier.Classification classification = outcome.TimedOut
				? new(UnityBuildStatus.UnityBuildFailed, $"timed out after {request.Timeout}", true, [])
				: UnityLogClassifier.Classify(outcome.ExitCode, log, artifactExists);

			result = new UnityBuildResult
			{
				Status = classification.Status,
				Reason = classification.Reason,
				Transient = classification.Transient,
				CompilerErrors = classification.CompilerErrors,
				Stages = UnityBuildStages.Decide(true, project.DiscoveryEvidence, outcome.ExitCode, log, artifactExists, classification),
				Provider = Name,
				UnityVersion = version,
				EditorPath = editor,
				ProjectPath = project.ProjectPath,
				TargetPlatform = request.TargetPlatform,
				Fingerprint = fingerprint,
				ExitCode = outcome.ExitCode,
				StandardOutput = outcome.StandardOutput,
				StandardError = outcome.StandardError,
				UnityLogPath = File.Exists(logFile) ? logFile : null,
				BuildArtifact = artifact,
				ArtifactExists = artifactExists,
				Attempts = attempt,
				CommandLine = [editor, .. arguments],
				StartedUtc = started,
				FinishedUtc = DateTimeOffset.UtcNow,
			};

			// Only a failure that is not about the project is retried: a licence server that did not
			// answer. Retrying a compile failure would only report it twice.
			if (!classification.Transient)
			{
				break;
			}
		}

		return result!;
	}
}
