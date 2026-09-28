using System.Text;
using System.Text.Json;

namespace AssetRipper.Validation.Unity;

/// <summary>
/// One build attempt and everything needed to believe or disbelieve its status later.
/// </summary>
/// <remarks>
/// The status is a conclusion; the rest is the evidence it was drawn from, kept because a status
/// with no evidence behind it is the one kind of result this project has repeatedly had to retract.
/// </remarks>
public sealed record UnityBuildResult
{
	public required UnityBuildStatus Status { get; init; }

	/// <summary>Why the classifier decided what it did, in words.</summary>
	public required string Reason { get; init; }

	public required string Provider { get; init; }

	public string? UnityVersion { get; init; }

	public string? EditorPath { get; init; }

	public required string ProjectPath { get; init; }

	public required string TargetPlatform { get; init; }

	public RecoveredProjectFingerprint? Fingerprint { get; init; }

	public int? ExitCode { get; init; }

	public string StandardOutput { get; init; } = "";

	public string StandardError { get; init; } = "";

	public string? UnityLogPath { get; init; }

	public string? BuildArtifact { get; init; }

	public bool ArtifactExists { get; init; }

	public int Attempts { get; init; } = 1;

	public bool Transient { get; init; }

	public IReadOnlyList<string> CommandLine { get; init; } = [];

	public DateTimeOffset StartedUtc { get; init; }

	public DateTimeOffset FinishedUtc { get; init; }

	/// <summary>The compiler errors the log carried, for a compile failure; empty otherwise.</summary>
	public IReadOnlyList<string> CompilerErrors { get; init; } = [];

	/// <summary>The level of validation this result reaches, in the vocabulary reports use.</summary>
	public string ValidationLevel => Status switch
	{
		UnityBuildStatus.UnityBuildSucceeded => "PROJECT_BUILD_VALIDATED",
		UnityBuildStatus.UnityRuntimeSucceeded => "RUNTIME_VALIDATED",
		UnityBuildStatus.UnityNotAvailable => "BLOCKED",
		_ => "NOT_VALIDATED",
	};

	public string ToJson()
	{
		using MemoryStream stream = new();
		using (Utf8JsonWriter json = new(stream, new JsonWriterOptions { Indented = true }))
		{
			json.WriteStartObject();
			json.WriteString("status", Status.ToReportName());
			json.WriteString("validationLevel", ValidationLevel);
			json.WriteString("reason", Reason);
			json.WriteString("provider", Provider);
			json.WriteString("unityVersion", UnityVersion);
			json.WriteString("editorPath", EditorPath);
			json.WriteString("projectPath", ProjectPath);
			json.WriteString("targetPlatform", TargetPlatform);

			if (ExitCode is { } exitCode)
			{
				json.WriteNumber("exitCode", exitCode);
			}
			else
			{
				json.WriteNull("exitCode");
			}

			json.WriteNumber("attempts", Attempts);
			json.WriteBoolean("transient", Transient);
			json.WriteString("unityLog", UnityLogPath);
			json.WriteString("buildArtifact", BuildArtifact);
			json.WriteBoolean("artifactExists", ArtifactExists);
			json.WriteString("startedUtc", StartedUtc.ToString("O"));
			json.WriteString("finishedUtc", FinishedUtc.ToString("O"));

			json.WriteStartArray("commandLine");
			foreach (string argument in CommandLine)
			{
				json.WriteStringValue(argument);
			}
			json.WriteEndArray();

			json.WriteStartArray("compilerErrors");
			foreach (string error in CompilerErrors)
			{
				json.WriteStringValue(error);
			}
			json.WriteEndArray();

			if (Fingerprint is { } fingerprint)
			{
				json.WriteStartObject("fingerprint");
				json.WriteString("project", fingerprint.Project);
				json.WriteString("projectSettings", fingerprint.ProjectSettings);
				json.WriteString("packages", fingerprint.Packages);
				json.WriteString("packageLock", fingerprint.PackageLock);
				json.WriteString("scripts", fingerprint.Scripts);
				json.WriteString("assets", fingerprint.Assets);
				json.WriteNumber("files", fingerprint.FileCount);
				json.WriteEndObject();
			}
			else
			{
				json.WriteNull("fingerprint");
			}

			json.WriteString("stdout", StandardOutput);
			json.WriteString("stderr", StandardError);
			json.WriteEndObject();
		}

		return Encoding.UTF8.GetString(stream.ToArray());
	}
}
