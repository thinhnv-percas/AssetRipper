namespace AssetRipper.Validation.Unity;

/// <summary>Something that can run a headless Unity build of a recovered project.</summary>
/// <remarks>
/// The same split as <c>game-ci/unity-builder</c>'s provider strategies - a local editor, a Docker
/// image - with a third that is always chosen last and always says why nothing else could run, so a
/// pipeline with no Unity reports <see cref="UnityBuildStatus.UnityNotAvailable"/> rather than
/// pretending to a verdict.
/// </remarks>
public interface IUnityBuildProvider
{
	string Name { get; }

	/// <summary>Whether this provider can run the request; the reason is reported when it cannot.</summary>
	bool CanBuild(RecoveredUnityProject project, BuildRequest request, out string reason);

	UnityBuildResult Build(RecoveredUnityProject project, BuildRequest request);
}

/// <summary>Chooses the first provider that can run a request.</summary>
public static class UnityBuildPipeline
{
	public static UnityBuildResult Build(RecoveredUnityProject project, BuildRequest request, IReadOnlyList<IUnityBuildProvider> providers)
	{
		List<string> reasons = [];

		foreach (IUnityBuildProvider provider in providers)
		{
			if (provider.CanBuild(project, request, out string reason))
			{
				return provider.Build(project, request);
			}

			reasons.Add($"{provider.Name}: {reason}");
		}

		DateTimeOffset now = DateTimeOffset.UtcNow;
		string unavailable = reasons.Count == 0 ? "no provider was configured" : string.Join("; ", reasons);
		return new UnityBuildResult
		{
			Status = UnityBuildStatus.UnityNotAvailable,
			Reason = unavailable,
			Stages = UnityBuildStages.Decide(true, project.DiscoveryEvidence, null, "", false,
				new UnityLogClassifier.Classification(UnityBuildStatus.UnityNotAvailable, unavailable, false, [])),
			Provider = "none",
			UnityVersion = request.UnityVersion ?? project.Version?.EditorVersion,
			ProjectPath = project.ProjectPath,
			TargetPlatform = request.TargetPlatform,
			Fingerprint = RecoveredProjectFingerprint.Compute(project.ProjectPath),
			StartedUtc = now,
			FinishedUtc = now,
		};
	}
}

/// <summary>A provider that never builds, and says why.</summary>
public sealed class UnavailableUnityBuildProvider(string reason) : IUnityBuildProvider
{
	public string Name => "unavailable";

	public bool CanBuild(RecoveredUnityProject project, BuildRequest request, out string why)
	{
		why = reason;
		return false;
	}

	public UnityBuildResult Build(RecoveredUnityProject project, BuildRequest request)
		=> UnityBuildPipeline.Build(project, request, [this]);
}
