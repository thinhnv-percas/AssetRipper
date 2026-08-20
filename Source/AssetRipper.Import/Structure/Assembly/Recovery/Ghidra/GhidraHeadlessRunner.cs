using AssetRipper.Import.Logging;
using System.Diagnostics;

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
/// deliberately a separate process so a crash or a hang cannot take AssetRipper down with it, and its
/// output is relayed to the log as it arrives so the run does not look like it has stalled.
/// </remarks>
public static class GhidraHeadlessRunner
{
	public const string ScriptName = "ExportIl2CppDecompilation";

	/// <summary>
	/// How long to wait for the analyzer before giving up.
	/// </summary>
	public static TimeSpan Timeout { get; set; } = TimeSpan.FromHours(4);

	/// <summary>
	/// The minimum gap between progress lines in the log. Ghidra reports far more often than is
	/// useful to read.
	/// </summary>
	public static TimeSpan ProgressInterval { get; set; } = TimeSpan.FromSeconds(15);

	/// <summary>
	/// How many recent lines to keep for diagnosing a failure. The full output of a real run is far
	/// too large to hold.
	/// </summary>
	private const int RetainedLineCount = 50;

	/// <summary>
	/// Builds the argument list for the headless analyzer.
	/// </summary>
	/// <param name="projectDirectory">A scratch directory for the Ghidra project.</param>
	/// <param name="projectName">The name of the Ghidra project.</param>
	/// <param name="binaryPath">The game binary to analyze.</param>
	/// <param name="scriptDirectory">The directory containing <see cref="ScriptName"/>.</param>
	/// <param name="symbolFilePath">The symbol file to label functions with.</param>
	/// <param name="outputDirectory">Where the decompiled output is written.</param>
	/// <param name="layoutFilePath">The type layouts, so field accesses decompile by name.</param>
	public static List<string> BuildArguments(
		string projectDirectory,
		string projectName,
		string binaryPath,
		string scriptDirectory,
		string symbolFilePath,
		string outputDirectory,
		string? layoutFilePath = null,
		string? globalFilePath = null)
	{
		List<string> arguments =
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
		];

		// Positional, so the layout file has to be there for the globals to be read as the fourth.
		if (!string.IsNullOrEmpty(layoutFilePath))
		{
			arguments.Add(layoutFilePath);

			if (!string.IsNullOrEmpty(globalFilePath))
			{
				arguments.Add(globalFilePath);
			}
		}

		// The project is scratch data, so there is no reason to pay for saving it.
		arguments.Add("-deleteProject");
		return arguments;
	}

	/// <summary>
	/// Extracts the counts that the export script reports on its last line.
	/// </summary>
	public static bool TryParseResult(string output, out int decompiled, out int failed)
	{
		foreach (string line in output.Split('\n'))
		{
			if (GhidraOutputParser.TryParseResult(line, out decompiled, out failed))
			{
				return true;
			}
		}

		decompiled = 0;
		failed = 0;
		return false;
	}

	/// <summary>
	/// Runs the analyzer and waits for it to finish, relaying its output to the log.
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

		OutputRelay relay = new();

		try
		{
			using Process process = new() { StartInfo = startInfo };
			process.OutputDataReceived += (_, e) => relay.Handle(e.Data);
			process.ErrorDataReceived += (_, e) => relay.Handle(e.Data);

			Stopwatch stopwatch = Stopwatch.StartNew();
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();

			if (!process.WaitForExit((int)Timeout.TotalMilliseconds))
			{
				Logger.Error(LogCategory.Import, $"Ghidra did not finish within {Timeout}. Killing it.");
				process.Kill(true);
				return new GhidraRunResult(false, 0, 0);
			}

			// Let the redirected streams flush before inspecting what was captured.
			process.WaitForExit();
			stopwatch.Stop();

			if (process.ExitCode != 0)
			{
				Logger.Error(LogCategory.Import, $"Ghidra exited with code {process.ExitCode}.");
				relay.LogRetainedLines();
				return new GhidraRunResult(false, 0, 0);
			}

			if (!relay.HasResult)
			{
				Logger.Error(LogCategory.Import, "Ghidra finished without reporting a result.");
				relay.LogRetainedLines();
				return new GhidraRunResult(false, 0, 0);
			}

			Logger.Info(LogCategory.Import, $"Ghidra finished in {stopwatch.Elapsed:hh\\:mm\\:ss}.");
			return new GhidraRunResult(true, relay.DecompiledCount, relay.FailedCount);
		}
		catch (Exception ex)
		{
			Logger.Error(LogCategory.Import, "Failed to run Ghidra.", ex);
			return new GhidraRunResult(false, 0, 0);
		}
	}

	/// <summary>
	/// Relays the analyzer's output to the log as it arrives, throttling the progress lines.
	/// </summary>
	private sealed class OutputRelay
	{
		private readonly object lockObject = new();
		private readonly Queue<string> retainedLines = new();
		private readonly Stopwatch sinceLastProgress = Stopwatch.StartNew();
		private string? lastProgressPhase;

		public bool HasResult { get; private set; }
		public int DecompiledCount { get; private set; }
		public int FailedCount { get; private set; }

		public void Handle(string? line)
		{
			if (line is null)
			{
				return;
			}

			lock (lockObject)
			{
				Retain(line);

				if (GhidraOutputParser.TryParseProgress(line, out string? phase, out int done, out int total))
				{
					// Always report the first line of a phase, then only occasionally.
					if (phase != lastProgressPhase || sinceLastProgress.Elapsed >= ProgressInterval)
					{
						Logger.Info(LogCategory.Import, GhidraOutputParser.FormatProgress(phase, done, total));
						lastProgressPhase = phase;
						sinceLastProgress.Restart();
					}
					return;
				}

				if (GhidraOutputParser.TryParseResult(line, out int decompiled, out int failed))
				{
					HasResult = true;
					DecompiledCount = decompiled;
					FailedCount = failed;
					return;
				}

				if (GhidraOutputParser.IsWorthLogging(line))
				{
					Logger.Info(LogCategory.Import, $"Ghidra: {GhidraOutputParser.Clean(line)}");
				}
				else
				{
					Logger.Verbose(LogCategory.Import, line.TrimEnd());
				}
			}
		}

		/// <summary>
		/// Dumps what was kept, so a failure has some context in the log.
		/// </summary>
		public void LogRetainedLines()
		{
			lock (lockObject)
			{
				Logger.Error(LogCategory.Import, "Last lines of the Ghidra output:");
				foreach (string line in retainedLines)
				{
					Logger.Error(LogCategory.Import, $"  {line}");
				}
			}
		}

		private void Retain(string line)
		{
			retainedLines.Enqueue(line.TrimEnd());
			if (retainedLines.Count > RetainedLineCount)
			{
				retainedLines.Dequeue();
			}
		}
	}
}
