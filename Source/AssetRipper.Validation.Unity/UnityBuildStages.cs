namespace AssetRipper.Validation.Unity;

/// <summary>The stages between a recovered project on disk and a player that runs, in order.</summary>
public enum UnityBuildStage
{
	ProjectDiscovery,
	UnityImport,
	ScriptCompile,
	AssetImport,
	BuildPlayer,
	Runtime,
}

/// <summary>What the evidence says about one stage.</summary>
public enum UnityStageOutcome
{
	/// <summary>The log or the disk proves the stage completed.</summary>
	Passed,

	/// <summary>The log proves the stage failed.</summary>
	Failed,

	/// <summary>An earlier stage failed or the editor never started, so this one did not run.</summary>
	NotReached,

	/// <summary>Nothing in this kind of run could exercise the stage.</summary>
	NotRun,

	/// <summary>The stage may have run, and nothing in the evidence says how it went.</summary>
	Unknown,
}

public sealed record UnityStageResult(UnityBuildStage Stage, UnityStageOutcome Outcome, string Evidence);

/// <summary>
/// The status of each stage of a build, read from the same evidence the overall status is.
/// </summary>
/// <remarks>
/// <para>
/// One status for a whole run hides which stage it is about. "Unity exited 1" can be a licence, an
/// import, a compile or a build, and the one conclusion that must never be drawn from the exit code
/// alone is that the scripts did not compile. So each stage is decided on its own evidence, and a
/// stage with none is <see cref="UnityStageOutcome.Unknown"/>.
/// </para>
/// <para>
/// A later stage's evidence proves the earlier ones. The validation method runs only through
/// <c>-executeMethod</c>, which Unity executes after the project has been opened, every asset
/// imported and the editor scripts compiled; so any line the method logs proves all three. And
/// <see cref="UnityBuildStage.Runtime"/> is never decided here: building a player is not running
/// one, and no build result says anything about what the game does.
/// </para>
/// </remarks>
public static class UnityBuildStages
{
	private static readonly string[] AssetImportFailure =
	[
		"Asset import failed",
		"Could not create asset from",
		"Failed to import asset",
	];

	public static IReadOnlyList<UnityStageResult> Decide(
		bool projectDiscovered,
		string discoveryEvidence,
		int? exitCode,
		string log,
		bool artifactExists,
		UnityLogClassifier.Classification classification)
	{
		List<UnityStageResult> stages = [];
		const string runtime = "a build does not run the player; no runtime harness was run";

		if (!projectDiscovered)
		{
			stages.Add(new(UnityBuildStage.ProjectDiscovery, UnityStageOutcome.Failed, discoveryEvidence));
			AddRemaining(stages, UnityStageOutcome.NotReached, "the project was not discovered");
			return Finish(stages, runtime);
		}

		stages.Add(new(UnityBuildStage.ProjectDiscovery, UnityStageOutcome.Passed, discoveryEvidence));

		if (exitCode is null || classification.Status == UnityBuildStatus.UnityNotAvailable)
		{
			AddRemaining(stages, UnityStageOutcome.NotReached, $"the editor did not run the project: {classification.Reason}");
			return Finish(stages, runtime);
		}

		string marker = ValidationScript.Marker;
		bool methodRan = log.Contains($"{marker} ", StringComparison.Ordinal);
		bool compileFailedMarker = log.Contains($"{marker} BUILD_RESULT CompileFailed", StringComparison.Ordinal)
			|| log.Contains($"{marker} IMPORT_RESULT CompileFailed", StringComparison.Ordinal);
		bool buildReported = log.Contains($"{marker} BUILD_RESULT ", StringComparison.Ordinal) && !compileFailedMarker;

		// Unity import (open, resolve packages).
		if (classification.Status == UnityBuildStatus.UnityImportFailed)
		{
			stages.Add(new(UnityBuildStage.UnityImport, UnityStageOutcome.Failed, classification.Reason));
			AddRemaining(stages, UnityStageOutcome.NotReached, "the project did not import");
			return Finish(stages, runtime);
		}

		stages.Add(methodRan
			? new(UnityBuildStage.UnityImport, UnityStageOutcome.Passed, "the validation method ran, which Unity does only once the project is open")
			: new(UnityBuildStage.UnityImport, UnityStageOutcome.Unknown, "no line in the log shows the project opened or failed to"));

		// Script compile.
		if (classification.Status == UnityBuildStatus.UnityCompileFailed)
		{
			stages.Add(new(UnityBuildStage.ScriptCompile, UnityStageOutcome.Failed, classification.Reason));
			stages.Add(new(UnityBuildStage.AssetImport, methodRan ? UnityStageOutcome.Passed : UnityStageOutcome.Unknown,
				methodRan ? "the validation method ran" : "compile failed; the log does not say whether assets imported"));
			stages.Add(new(UnityBuildStage.BuildPlayer, UnityStageOutcome.NotReached, "scripts did not compile"));
			return Finish(stages, runtime);
		}

		stages.Add(methodRan
			? new(UnityBuildStage.ScriptCompile, UnityStageOutcome.Passed, "the validation method ran and did not report a compile failure")
			: new(UnityBuildStage.ScriptCompile, UnityStageOutcome.Unknown, "no compiler error and no marker; the exit code alone does not decide it"));

		// Asset import.
		if (AssetImportFailure.FirstOrDefault(log.Contains) is { } assetFailure)
		{
			stages.Add(new(UnityBuildStage.AssetImport, UnityStageOutcome.Failed, $"\"{assetFailure}\""));
		}
		else
		{
			stages.Add(methodRan
				? new(UnityBuildStage.AssetImport, UnityStageOutcome.Passed, "the validation method ran, which Unity does only after the initial import")
				: new(UnityBuildStage.AssetImport, UnityStageOutcome.Unknown, "no line in the log shows the import completing"));
		}

		// Player build.
		UnityStageResult build = classification.Status switch
		{
			UnityBuildStatus.UnityBuildSucceeded => new(UnityBuildStage.BuildPlayer, UnityStageOutcome.Passed, classification.Reason),
			UnityBuildStatus.UnityBuildFailed when buildReported => new(UnityBuildStage.BuildPlayer, UnityStageOutcome.Failed, classification.Reason),
			UnityBuildStatus.UnityBuildFailed when classification.Reason.StartsWith("the editor crashed", StringComparison.Ordinal)
				=> new(UnityBuildStage.BuildPlayer, UnityStageOutcome.Failed, classification.Reason),
			_ when !methodRan => new(UnityBuildStage.BuildPlayer, UnityStageOutcome.Unknown, $"{classification.Reason}; the build method left no line"),
			_ => new(UnityBuildStage.BuildPlayer, UnityStageOutcome.Unknown, classification.Reason),
		};
		if (build.Outcome == UnityStageOutcome.Passed && !artifactExists)
		{
			build = build with { Outcome = UnityStageOutcome.Failed, Evidence = "no player on disk" };
		}
		stages.Add(build);

		return Finish(stages, runtime);
	}

	private static void AddRemaining(List<UnityStageResult> stages, UnityStageOutcome outcome, string evidence)
	{
		foreach (UnityBuildStage stage in Enum.GetValues<UnityBuildStage>())
		{
			if (stage != UnityBuildStage.Runtime && stages.All(existing => existing.Stage != stage))
			{
				stages.Add(new(stage, outcome, evidence));
			}
		}
	}

	private static IReadOnlyList<UnityStageResult> Finish(List<UnityStageResult> stages, string runtime)
	{
		stages.Add(new(UnityBuildStage.Runtime, UnityStageOutcome.NotRun, runtime));
		return stages;
	}

	public static string ToReportName(this UnityBuildStage stage) => stage switch
	{
		UnityBuildStage.ProjectDiscovery => "PROJECT_DISCOVERY",
		UnityBuildStage.UnityImport => "UNITY_IMPORT",
		UnityBuildStage.ScriptCompile => "SCRIPT_COMPILE",
		UnityBuildStage.AssetImport => "ASSET_IMPORT",
		UnityBuildStage.BuildPlayer => "BUILD_PLAYER",
		UnityBuildStage.Runtime => "RUNTIME",
		_ => stage.ToString(),
	};

	public static string ToReportName(this UnityStageOutcome outcome) => outcome switch
	{
		UnityStageOutcome.Passed => "PASSED",
		UnityStageOutcome.Failed => "FAILED",
		UnityStageOutcome.NotReached => "NOT_REACHED",
		UnityStageOutcome.NotRun => "NOT_RUN",
		UnityStageOutcome.Unknown => "UNKNOWN",
		_ => outcome.ToString(),
	};
}
