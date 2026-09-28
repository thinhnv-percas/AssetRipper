namespace AssetRipper.Validation.Unity;

/// <summary>
/// What a Unity build attempt established, and nothing more.
/// </summary>
/// <remarks>
/// <para>
/// A non-zero exit from Unity is not one fact. An editor that could not be found, a project that did
/// not import, scripts that did not compile and a player build that failed are four different defects
/// with four different owners, and mapping every one of them to "compile failed" is how a pipeline
/// reports a licensing problem as a decompiler bug. Each value here is decided from evidence the run
/// left behind - the Unity log, the exit code, the artefact on disk - by
/// <see cref="UnityLogClassifier"/>, never from the exit code alone.
/// </para>
/// <para>
/// The two runtime values are reserved for a scenario runner. Nothing in this repository runs one
/// yet, so a build that succeeds is <see cref="UnityBuildSucceeded"/> and no further: a project is
/// <c>PROJECT_BUILD_VALIDATED</c> when Unity really imported and built it, and <c>RUNTIME_VALIDATED</c>
/// only when Unity really ran a scenario.
/// </para>
/// </remarks>
public enum UnityBuildStatus
{
	UnityNotAvailable,
	UnityImportFailed,
	UnityCompileFailed,
	UnityBuildFailed,
	UnityBuildSucceeded,
	UnityRuntimeBlocked,
	UnityRuntimeSucceeded,
	UnityRuntimeFailed,
}

public static class UnityBuildStatusNames
{
	/// <summary>The spelling reports use, which is the one the measurement harness greps for.</summary>
	public static string ToReportName(this UnityBuildStatus status) => status switch
	{
		UnityBuildStatus.UnityNotAvailable => "UNITY_NOT_AVAILABLE",
		UnityBuildStatus.UnityImportFailed => "UNITY_IMPORT_FAILED",
		UnityBuildStatus.UnityCompileFailed => "UNITY_COMPILE_FAILED",
		UnityBuildStatus.UnityBuildFailed => "UNITY_BUILD_FAILED",
		UnityBuildStatus.UnityBuildSucceeded => "UNITY_BUILD_SUCCEEDED",
		UnityBuildStatus.UnityRuntimeBlocked => "UNITY_RUNTIME_BLOCKED",
		UnityBuildStatus.UnityRuntimeSucceeded => "UNITY_RUNTIME_SUCCEEDED",
		UnityBuildStatus.UnityRuntimeFailed => "UNITY_RUNTIME_FAILED",
		_ => throw new ArgumentOutOfRangeException(nameof(status)),
	};
}
