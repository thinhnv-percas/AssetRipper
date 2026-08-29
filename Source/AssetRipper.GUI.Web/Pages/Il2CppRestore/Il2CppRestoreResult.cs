using System.Diagnostics;

namespace AssetRipper.GUI.Web.Pages.Il2CppRestore;

/// <summary>
/// One run of the standalone <c>AssetRipper.Il2CppRestore.Cli</c> tool, launched as a subprocess.
/// </summary>
/// <remarks>
/// This page is deliberately a launcher, not a library caller. <c>AssetRipper.GUI.Free</c> — the actual
/// distributed binary this page ships inside of — publishes with <c>PublishAot=true</c> (NativeAOT).
/// The restore pipeline reads native struct layouts through reflection on a <c>Type</c> obtained at
/// runtime (see <c>AssetRipper.Il2CppRestore.Metadata.VersionedReader</c>) and builds assemblies with
/// Mono.Cecil, neither of which is something NativeAOT's ahead-of-time analysis can see through — and
/// there is no way to actually publish a NativeAOT binary and confirm that in the sandbox this was
/// written in. Referencing those projects directly from <c>AssetRipper.GUI.Web</c> would put that risk
/// onto every user of the free edition just to run this one optional feature. Shelling out to the
/// already-JIT-compiled Cli tool as a separate process keeps GUI.Free's own compilation untouched
/// regardless of whether the restore pipeline would have survived AOT — the same reasoning that already
/// applies to <see cref="AssetRipper.Export.UnityProjects.PackageRemapping"/> not living inside this
/// same process either, just for a different reason (that one is a released library dependency;
/// this one is a whole extra reflection-heavy tool).
/// </remarks>
public sealed class Il2CppRestoreResult
{
	public required bool Started { get; init; }
	public int ExitCode { get; init; }
	public required string Output { get; init; }
	public string? Error { get; init; }

	public static Il2CppRestoreResult Failure(string error) => new() { Started = false, Output = "", Error = error };

	public static async Task<Il2CppRestoreResult> RunAsync(string cliPath, string metadataPath, string? binaryPath, string? structDbDirectory, string? unityVersion, string outputPath)
	{
		if (string.IsNullOrWhiteSpace(cliPath) || !File.Exists(cliPath))
		{
			return Failure($"Could not find the Il2CppRestore.Cli tool at: {cliPath}. Build AssetRipper.Il2CppRestore.Cli and point this field at the resulting executable or .dll.");
		}
		if (string.IsNullOrWhiteSpace(metadataPath) || !File.Exists(metadataPath))
		{
			return Failure($"global-metadata.dat not found at: {metadataPath}");
		}
		if (string.IsNullOrWhiteSpace(outputPath))
		{
			return Failure("An output directory is required.");
		}

		List<string> arguments = ["--metadata", metadataPath, "--out", outputPath];
		if (!string.IsNullOrWhiteSpace(binaryPath))
		{
			arguments.Add("--binary");
			arguments.Add(binaryPath);
		}
		if (!string.IsNullOrWhiteSpace(structDbDirectory))
		{
			arguments.Add("--structdb");
			arguments.Add(structDbDirectory);
		}
		if (!string.IsNullOrWhiteSpace(unityVersion))
		{
			arguments.Add("--unity-version");
			arguments.Add(unityVersion);
		}

		// A plain .dll needs the `dotnet` host; a published self-contained/apphost binary is run directly.
		bool needsDotnetHost = cliPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase);
		ProcessStartInfo startInfo = new(needsDotnetHost ? "dotnet" : cliPath)
		{
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
		};
		if (needsDotnetHost)
		{
			startInfo.ArgumentList.Add(cliPath);
		}
		foreach (string argument in arguments)
		{
			startInfo.ArgumentList.Add(argument);
		}

		try
		{
			using Process process = Process.Start(startInfo) ?? throw new InvalidOperationException("The process did not start.");
			Task<string> stdoutTask = process.StandardOutput.ReadToEndAsync();
			Task<string> stderrTask = process.StandardError.ReadToEndAsync();
			await process.WaitForExitAsync();
			string stdout = await stdoutTask;
			string stderr = await stderrTask;

			return new Il2CppRestoreResult
			{
				Started = true,
				ExitCode = process.ExitCode,
				Output = stdout + (stderr.Length > 0 ? "\n" + stderr : ""),
			};
		}
		catch (Exception exception)
		{
			return Failure($"Could not run the Il2CppRestore.Cli tool: {exception.Message}");
		}
	}
}
