using AssetRipper.Import.Logging;
using AssetRipper.IO.Files;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// What a fetch did, which is what the page reports and the export logs.
/// </summary>
/// <param name="Directory">Where the clone is, whether or not this call made it.</param>
public readonly record struct GitFetchResult(bool Success, string Directory, string Message);

/// <summary>
/// Turns a git source into a folder on disk.
/// </summary>
/// <remarks>
/// Only the working tree is wanted here — the meta files and what they give guids to — so every clone is
/// shallow and updating one is deleting it and cloning again. That is more bytes than a fetch, and it is
/// the only way that cannot end up in a state a checkout has to be reasoned about: a branch that was
/// force pushed, a tag that moved, a detached head left by the last run.
/// </remarks>
public static class GitPackageFetcher
{
	/// <summary>
	/// Where the clones live, beside the executable, as the remapping configuration does.
	/// </summary>
	public const string WorkingDirectoryName = "PackageSources";

	/// <summary>
	/// Long enough for a repository holding a Unity project, short enough that an export cannot hang on
	/// a host that never answers.
	/// </summary>
	private static readonly TimeSpan Timeout = TimeSpan.FromMinutes(5);

	public static string WorkingDirectory => Path.Join(LocalFileSystem.ExecutingDirectory, WorkingDirectoryName);

	/// <summary>
	/// Where a source's clone belongs.
	/// </summary>
	/// <remarks>
	/// The name carries the repository so a folder can be recognised by eye, and a hash of the url and
	/// revision so two branches of one repository are two clones rather than one that keeps changing.
	/// </remarks>
	public static string GetCloneDirectory(PackageSource source)
	{
		string name = source.Location.TrimEnd('/');
		int separator = name.AsSpan().LastIndexOfAny('/', '\\', ':');
		name = separator < 0 ? name : name[(separator + 1)..];
		if (name.EndsWith(".git", StringComparison.OrdinalIgnoreCase))
		{
			name = name[..^4];
		}

		StringBuilder cleaned = new(name.Length);
		foreach (char character in name)
		{
			cleaned.Append(char.IsAsciiLetterOrDigit(character) || character is '-' or '_' or '.' ? character : '_');
		}

		if (cleaned.Length == 0)
		{
			cleaned.Append("repository");
		}

		uint hash = Hash($"{source.Location}#{source.Revision}");
		return Path.Join(WorkingDirectory, $"{cleaned}-{hash.ToString("x8", CultureInfo.InvariantCulture)}");
	}

	public static bool IsCloned(PackageSource source)
	{
		return Directory.Exists(Path.Join(GetCloneDirectory(source), ".git"));
	}

	/// <summary>
	/// Makes sure the source's clone is on disk.
	/// </summary>
	/// <param name="update">Whether to replace a clone that is already there with a fresh one.</param>
	public static GitFetchResult Fetch(PackageSource source, bool update)
	{
		string directory = GetCloneDirectory(source);

		if (source.Location.Length == 0)
		{
			return new GitFetchResult(false, directory, "The source has no repository url.");
		}

		// Nothing is run through a shell, so the only way a source could smuggle in an option is by being
		// one. The url is guarded by the -- every clone below passes; a revision is a name git resolves
		// and has nowhere to put a -- in front of, so it is refused instead.
		if (source.Revision.StartsWith('-'))
		{
			return new GitFetchResult(false, directory, "A revision cannot start with a dash.");
		}

		if (IsCloned(source) && !update)
		{
			return new GitFetchResult(true, directory, "Already cloned.");
		}

		if (!TryDelete(directory, out string? failure))
		{
			return new GitFetchResult(false, directory, $"The clone directory could not be prepared: {failure}");
		}

		try
		{
			Directory.CreateDirectory(WorkingDirectory);
		}
		catch (Exception exception)
		{
			return new GitFetchResult(false, directory, $"The clone directory could not be prepared: {exception.Message}");
		}

		// A revision is asked for by name first, which is what a branch or a tag is and what keeps the
		// clone shallow. A commit is not a name git can clone, so that attempt fails and the second one,
		// a full clone followed by a checkout, is what covers it.
		if (source.Revision.Length > 0)
		{
			GitFetchResult shallow = Run(directory, "clone", "--depth", "1", "--single-branch", "--branch", source.Revision, "--", source.Location, directory);
			if (shallow.Success)
			{
				return shallow;
			}

			GitFetchResult full = Run(directory, "clone", "--", source.Location, directory);
			if (!full.Success)
			{
				return full;
			}

			return Run(directory, "-C", directory, "checkout", "--force", source.Revision);
		}

		return Run(directory, "clone", "--depth", "1", "--", source.Location, directory);
	}

	/// <summary>
	/// Removes a clone, whatever git left it marked as.
	/// </summary>
	/// <remarks>
	/// A pack file in a repository's object store is written read only, which on Windows is enough to
	/// make deleting the folder that holds it fail outright. Nothing here is meant to be kept, so the
	/// attribute is cleared off everything first.
	/// <para>
	/// The retry is for the other reason a delete of a folder that was just read fails: a virus scanner
	/// or a file manager still has a handle open, and a moment later it does not.
	/// </para>
	/// </remarks>
	private static bool TryDelete(string directory, out string? failure)
	{
		failure = null;

		for (int attempt = 0; ; attempt++)
		{
			if (!Directory.Exists(directory))
			{
				return true;
			}

			try
			{
				ClearReadOnly(directory);
				Directory.Delete(directory, true);
				return true;
			}
			catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
			{
				failure = exception.Message;
				if (attempt >= 2)
				{
					return false;
				}

				Thread.Sleep(200);
			}
		}
	}

	private static void ClearReadOnly(string directory)
	{
		foreach (string path in Directory.EnumerateFileSystemEntries(directory, "*", SearchOption.AllDirectories))
		{
			try
			{
				FileAttributes attributes = File.GetAttributes(path);
				if ((attributes & FileAttributes.ReadOnly) != 0)
				{
					File.SetAttributes(path, attributes & ~FileAttributes.ReadOnly);
				}
			}
			catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
			{
				// The delete below is what reports a path that cannot be given up.
			}
		}
	}

	private static GitFetchResult Run(string directory, params string[] arguments)
	{
		try
		{
			ProcessStartInfo startInfo = new()
			{
				FileName = "git",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			};

			foreach (string argument in arguments)
			{
				startInfo.ArgumentList.Add(argument);
			}

			using Process process = new() { StartInfo = startInfo };
			process.Start();

			// The streams are read before waiting, because a process that fills a pipe nobody is reading
			// blocks forever and the timeout below would be the only thing that ever ended it.
			Task<string> error = process.StandardError.ReadToEndAsync();
			process.StandardOutput.ReadToEnd();

			if (!process.WaitForExit(Timeout))
			{
				process.Kill(true);
				return new GitFetchResult(false, directory, $"git took longer than {Timeout.TotalMinutes} minutes and was stopped.");
			}

			string message = error.GetAwaiter().GetResult().Trim();
			if (process.ExitCode == 0)
			{
				return new GitFetchResult(true, directory, message);
			}

			Logger.Warning(LogCategory.Export, $"git {string.Join(' ', arguments)} failed: {message}");
			return new GitFetchResult(false, directory, message.Length > 0 ? message : $"git exited with code {process.ExitCode}.");
		}
		catch (Exception exception)
		{
			return new GitFetchResult(false, directory, $"git could not be run: {exception.Message}. It has to be installed and on the path.");
		}
	}

	/// <summary>
	/// A stable hash, which the runtime's string hash is deliberately not: a folder name has to be the
	/// same one the last run used.
	/// </summary>
	/// <remarks>
	/// Unchecked because this project builds with overflow checking on, and wrapping is what the
	/// multiplication of a hash is for.
	/// </remarks>
	private static uint Hash(string text)
	{
		unchecked
		{
			uint hash = 2166136261;
			foreach (char character in text)
			{
				hash = (hash ^ character) * 16777619;
			}
			return hash;
		}
	}
}
