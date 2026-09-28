using System.Diagnostics;
using System.Text;

namespace AssetRipper.Validation.Unity;

public sealed record ProcessOutcome(int? ExitCode, string StandardOutput, string StandardError, bool TimedOut);

/// <summary>Runs a process; an interface so the build logic can be tested without an editor.</summary>
public interface IProcessRunner
{
	ProcessOutcome Run(string fileName, IReadOnlyList<string> arguments, string workingDirectory, TimeSpan timeout);
}

public sealed class SystemProcessRunner : IProcessRunner
{
	public ProcessOutcome Run(string fileName, IReadOnlyList<string> arguments, string workingDirectory, TimeSpan timeout)
	{
		ProcessStartInfo info = new(fileName)
		{
			WorkingDirectory = workingDirectory,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
		};

		// An argument list, never a concatenated command line: nothing is ever shell-parsed.
		foreach (string argument in arguments)
		{
			info.ArgumentList.Add(argument);
		}

		StringBuilder stdout = new();
		StringBuilder stderr = new();

		try
		{
			using Process process = new() { StartInfo = info };
			process.OutputDataReceived += (_, e) => { if (e.Data is not null) { lock (stdout) { stdout.AppendLine(e.Data); } } };
			process.ErrorDataReceived += (_, e) => { if (e.Data is not null) { lock (stderr) { stderr.AppendLine(e.Data); } } };
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();

			if (!process.WaitForExit(timeout))
			{
				process.Kill(entireProcessTree: true);
				return new ProcessOutcome(null, stdout.ToString(), stderr.ToString(), true);
			}

			process.WaitForExit();
			return new ProcessOutcome(process.ExitCode, stdout.ToString(), stderr.ToString(), false);
		}
		catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or FileNotFoundException or InvalidOperationException)
		{
			return new ProcessOutcome(null, stdout.ToString(), $"{stderr}{ex.Message}", false);
		}
	}
}
