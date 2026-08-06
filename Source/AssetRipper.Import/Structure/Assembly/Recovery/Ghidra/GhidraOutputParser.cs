using System.Globalization;
using System.Text.RegularExpressions;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Interprets the lines that the headless analyzer writes, so a run that takes an hour can report
/// what it is doing instead of going silent.
/// </summary>
public static partial class GhidraOutputParser
{
	[GeneratedRegex(@"^PROGRESS phase=(\w+) done=(\d+) total=(\d+)$")]
	private static partial Regex ProgressRegex { get; }

	[GeneratedRegex(@"^RESULT decompiled=(\d+) failed=(\d+)$")]
	private static partial Regex ResultRegex { get; }

	/// <summary>
	/// Ghidra prefixes every line with a level and suffixes it with the source that logged it.
	/// </summary>
	[GeneratedRegex(@"^(?:INFO|WARN|ERROR|DEBUG)\s+(.*?)(?:\s+\([A-Za-z0-9_.]+\))?\s*$")]
	private static partial Regex LogLineRegex { get; }

	/// <summary>
	/// Sources that only report on Ghidra starting up, which says nothing about the analysis.
	/// </summary>
	private static readonly string[] noisySources =
	[
		"(LoggingInitialization)",
		"(Preferences)",
		"(ClassSearcher)",
		"(SecureRandomFactory)",
		"(DefaultSSLContextInitializer)",
		"(DefaultTrustManagerFactory)",
	];

	/// <summary>
	/// Strips Ghidra's level prefix and source suffix, and the script name prefix on script output.
	/// </summary>
	public static string Clean(string line)
	{
		string trimmed = line.TrimEnd();

		Match match = LogLineRegex.Match(trimmed);
		string message = match.Success ? match.Groups[1].Value : trimmed;

		// Script output is prefixed with the script file name.
		int scriptPrefix = message.IndexOf(".java> ", StringComparison.Ordinal);
		if (scriptPrefix >= 0)
		{
			message = message[(scriptPrefix + 7)..];
		}

		// Continuation lines of a multi line entry keep their indentation.
		return message.Trim();
	}

	/// <summary>
	/// Lines the JVM itself writes before Ghidra starts logging.
	/// </summary>
	private static readonly string[] runtimeBanners =
	[
		"Picked up JAVA_TOOL_OPTIONS",
		"Picked up _JAVA_OPTIONS",
		"Picked up JAVA_OPTIONS",
		"openjdk version",
		"OpenJDK Runtime Environment",
		"OpenJDK 64-Bit Server VM",
		"Java HotSpot",
	];

	/// <summary>
	/// Whether a line says something about the run rather than about Ghidra or the JVM booting.
	/// </summary>
	public static bool IsWorthLogging(string line)
	{
		string trimmed = line.TrimEnd();
		if (trimmed.Trim().Length == 0)
		{
			return false;
		}

		// Per analyzer timing summaries are indented.
		if (trimmed.StartsWith("    ", StringComparison.Ordinal))
		{
			return false;
		}

		foreach (string source in noisySources)
		{
			if (trimmed.EndsWith(source, StringComparison.Ordinal))
			{
				return false;
			}
		}

		// The level prefix has to come off before the remaining checks, because a separator or a
		// dangling source tag is still logged by Ghidra at INFO.
		string cleaned = Clean(line);
		if (cleaned.Length == 0)
		{
			return false;
		}

		foreach (string banner in runtimeBanners)
		{
			if (cleaned.StartsWith(banner, StringComparison.Ordinal))
			{
				return false;
			}
		}

		if (cleaned.StartsWith("---", StringComparison.Ordinal))
		{
			return false;
		}

		// The tail of a multi line entry is just the source in parentheses.
		return !(cleaned.StartsWith('(') && cleaned.EndsWith(')'));
	}

	public static bool TryParseProgress(string line, [NotNullWhen(true)] out string? phase, out int done, out int total)
	{
		Match match = ProgressRegex.Match(Clean(line));
		if (match.Success
			&& int.TryParse(match.Groups[2].ValueSpan, CultureInfo.InvariantCulture, out done)
			&& int.TryParse(match.Groups[3].ValueSpan, CultureInfo.InvariantCulture, out total))
		{
			phase = match.Groups[1].Value;
			return true;
		}

		phase = null;
		done = 0;
		total = 0;
		return false;
	}

	public static bool TryParseResult(string line, out int decompiled, out int failed)
	{
		Match match = ResultRegex.Match(Clean(line));
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
	/// Formats a progress update for the log.
	/// </summary>
	public static string FormatProgress(string phase, int done, int total)
	{
		string percentage = total > 0
			? (done / (double)total).ToString("P1", CultureInfo.InvariantCulture)
			: "";

		return total > 0
			? $"Ghidra {phase}: {done}/{total} ({percentage})"
			: $"Ghidra {phase}: {done}";
	}
}
