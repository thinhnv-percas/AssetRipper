using System.Text.RegularExpressions;

namespace AssetRipper.Validation.Unity;

/// <summary>
/// Decides a build status from the evidence a Unity run leaves, in a fixed order of precedence.
/// </summary>
/// <remarks>
/// <para>
/// The order is the dependency order of the stages. An editor that has no licence never reaches an
/// import; a project that does not import never compiles; scripts that do not compile never build. So
/// the earliest stage the log shows failing is the one reported, whatever the later lines say -
/// a failed import is routinely followed by compile errors that are its consequence, not a second
/// defect.
/// </para>
/// <para>
/// Success needs three pieces of evidence, and each is checked separately: the validation script's
/// own <c>BUILD_RESULT Succeeded</c> line, an exit code of zero, and the player on disk. An exit code
/// of zero alone is not a build - Unity exits zero from a <c>-quit</c> run that never executed the
/// method at all.
/// </para>
/// </remarks>
public static partial class UnityLogClassifier
{
	public sealed record Classification(UnityBuildStatus Status, string Reason, bool Transient, IReadOnlyList<string> CompilerErrors);

	[GeneratedRegex(@"^.*\berror CS\d{4}:.*$", RegexOptions.Multiline)]
	private static partial Regex CompilerError();

	private static readonly string[] LicenceUnavailable =
	[
		"No valid Unity Editor license found",
		"Unity has not been activated",
		"LICENSE SYSTEM [",
		"Failed to activate license",
	];

	private static readonly string[] TransientLicence =
	[
		"Access token is unavailable",
		"Timed out waiting for the license",
		"Licensing::IpcConnector",
		"Connection to the licensing server",
	];

	private static readonly string[] ImportFailure =
	[
		"Failed to import package",
		"An error occurred while resolving packages",
		"Project has invalid dependencies",
		"Could not open project",
		"Couldn't open project",
		"Failed to load project",
	];

	private static readonly string[] Crash =
	[
		"Crash!!!",
		"Native Crash Reporting",
		"Received signal SIGSEGV",
	];

	public static Classification Classify(int? exitCode, string log, bool artifactExists)
	{
		List<string> compilerErrors = CompilerError().Matches(log).Select(m => m.Value.Trim()).Distinct().ToList();

		if (exitCode is null)
		{
			return new(UnityBuildStatus.UnityNotAvailable, "the editor process was not started", false, []);
		}

		if (TransientLicence.FirstOrDefault(log.Contains) is { } transient)
		{
			return new(UnityBuildStatus.UnityNotAvailable, $"licensing did not answer: \"{transient}\"", true, []);
		}

		// "LICENSE SYSTEM [" alone is how every Unity log starts, so it only counts beside a failure.
		if (LicenceUnavailable.Where(m => m != "LICENSE SYSTEM [").FirstOrDefault(log.Contains) is { } licence)
		{
			return new(UnityBuildStatus.UnityNotAvailable, $"no editor licence: \"{licence}\"", false, []);
		}

		if (ImportFailure.FirstOrDefault(log.Contains) is { } import)
		{
			return new(UnityBuildStatus.UnityImportFailed, $"the project did not import: \"{import}\"", false, compilerErrors);
		}

		if (compilerErrors.Count > 0 || log.Contains("Scripts have compiler errors", StringComparison.Ordinal)
			|| log.Contains($"{ValidationScript.Marker} BUILD_RESULT CompileFailed", StringComparison.Ordinal))
		{
			return new(UnityBuildStatus.UnityCompileFailed, $"{compilerErrors.Count} compiler error(s)", false, compilerErrors);
		}

		if (Crash.FirstOrDefault(log.Contains) is { } crash)
		{
			return new(UnityBuildStatus.UnityBuildFailed, $"the editor crashed: \"{crash}\" (exit {exitCode})", false, []);
		}

		bool markerSucceeded = log.Contains($"{ValidationScript.Marker} BUILD_RESULT Succeeded", StringComparison.Ordinal);
		bool markerFailed = log.Contains($"{ValidationScript.Marker} BUILD_RESULT Failed", StringComparison.Ordinal)
			|| log.Contains("Build Finished, Result: Failure", StringComparison.Ordinal);

		if (markerFailed)
		{
			return new(UnityBuildStatus.UnityBuildFailed, $"the player build reported failure (exit {exitCode})", false, []);
		}

		if (markerSucceeded && exitCode == 0 && artifactExists)
		{
			return new(UnityBuildStatus.UnityBuildSucceeded, "build reported success, exit 0, player on disk", false, []);
		}

		if (markerSucceeded)
		{
			string missing = exitCode != 0 ? $"exit code {exitCode}" : "no player on disk";
			return new(UnityBuildStatus.UnityBuildFailed, $"build reported success but {missing}", false, []);
		}

		if (log.Contains("executeMethod method", StringComparison.Ordinal) && log.Contains("could not be found", StringComparison.Ordinal))
		{
			return new(UnityBuildStatus.UnityBuildFailed, "the build method was not found, so no build ran", false, []);
		}

		return new(UnityBuildStatus.UnityBuildFailed,
			$"exit code {exitCode} and no line in the log that says what happened; not called a compile failure without one",
			false, []);
	}
}
