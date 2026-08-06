using AssetRipper.Import.Logging;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// How a headless Ghidra run ended.
/// </summary>
/// <param name="Succeeded">Whether the analyzer ran to completion.</param>
/// <param name="DecompiledCount">The number of methods that produced output.</param>
/// <param name="FailedCount">The number of methods that could not be decompiled.</param>
public readonly record struct GhidraRunResult(bool Succeeded, int DecompiledCount, int FailedCount);

/// <summary>
/// Runs Ghidra's headless analyzer over a game binary, labelling every function with its Il2Cpp name
/// and exporting the decompiled output.
/// </summary>
/// <remarks>
/// Analysis of a full game binary regularly takes an hour or more and needs a lot of memory. This is
/// deliberately a separate process so a crash or a hang cannot take AssetRipper down with it.
/// </remarks>
public static partial class GhidraHeadlessRunner
{
	public const string ScriptName = "ExportIl2CppDecompilation";

	/// <summary>
	/// How long to wait for the analyzer before giving up.
	/// </summary>
	public static TimeSpan Timeout { get; set; } = TimeSpan.FromHours(4);

	[GeneratedRegex(@"RESULT decompiled=(\d+) failed=(\d+)")]
	private static partial Regex ResultRegex { get; }

	/// <summary>
	/// Builds the argument list for the headless analyzer.
	/// </summary>
	/// <param name="projectDirectory">A scratch directory for the Ghidra project.</param>
	/// <param name="projectName">The name of the Ghidra project.</param>
	/// <param name="binaryPath">The game binary to analyze.</param>
	/// <param name="scriptDirectory">The directory containing <see cref="ScriptName"/>.</param>
	/// <param name="symbolFilePath">The symbol file to label functions with.</param>
	/// <param name="outputDirectory">Where the decompiled output is written.</param>
	public static List<string> BuildArguments(
		string projectDirectory,
		string projectName,
		string binaryPath,
		string scriptDirectory,
		string symbolFilePath,
		string outputDirectory)
	{
		return
		[
			projectDirectory,
			projectName,
			"-import",
			binaryPath,
			"-scriptPath",
			scriptDirectory,
			"-postScript",
			ScriptName,
			symbolFilePath,
			outputDirectory,
			// The project is scratch data, so there is no reason to pay for saving it.
			"-deleteProject",
		];
	}

	/// <summary>
	/// Extracts the counts that the export script reports on its last line.
	/// </summary>
	public static bool TryParseResult(string output, out int decompiled, out int failed)
	{
		Match match = ResultRegex.Match(output);
		if (match.Success
			&& int.TryParse(match.Groups[1].ValueSpan, CultureInfo.InvariantCulture, out decompiled)
			&& int.TryParse(match.Groups[2].ValueSpan, CultureInfo.InvariantCulture, out failed))
		{
			return true;
		}

		decompiled = 0;
		failed = 0;
		return false;
	}

	/// <summary>
	/// Runs the analyzer and waits for it to finish.
	/// </summary>
	public static GhidraRunResult Run(GhidraInstallation installation, List<string> arguments)
	{
		ProcessStartInfo startInfo = new()
		{
			FileName = installation.HeadlessAnalyzerPath,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true,
		};

		foreach (string argument in arguments)
		{
			startInfo.ArgumentList.Add(argument);
		}

		StringBuilder output = new();

		try
		{
			using Process process = new() { StartInfo = startInfo };
			process.OutputDataReceived += (_, e) => AppendLine(output, e.Data);
			process.ErrorDataReceived += (_, e) => AppendLine(output, e.Data);

			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();

			if (!process.WaitForExit((int)Timeout.TotalMilliseconds))
			{
				Logger.Error(LogCategory.Import, $"Ghidra did not finish within {Timeout}. Killing it.");
				process.Kill(true);
				return new GhidraRunResult(false, 0, 0);
			}

			// Let the redirected streams flush before reading the accumulated output.
			process.WaitForExit();

			string text = output.ToString();
			if (process.ExitCode != 0)
			{
				Logger.Error(LogCategory.Import, $"Ghidra exited with code {process.ExitCode}.");
				return new GhidraRunResult(false, 0, 0);
			}

			return TryParseResult(text, out int decompiled, out int failed)
				? new GhidraRunResult(true, decompiled, failed)
				: new GhidraRunResult(false, 0, 0);
		}
		catch (Exception ex)
		{
			Logger.Error(LogCategory.Import, "Failed to run Ghidra.", ex);
			return new GhidraRunResult(false, 0, 0);
		}
	}

	private static void AppendLine(StringBuilder builder, string? line)
	{
		if (line is null)
		{
			return;
		}

		lock (builder)
		{
			builder.AppendLine(line);
		}
	}
}
