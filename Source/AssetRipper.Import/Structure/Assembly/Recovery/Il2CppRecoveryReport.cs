using AssetRipper.Import.Logging;
using System.Globalization;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Recovery;

/// <summary>
/// Collects per method statistics while Il2Cpp method bodies are recovered at
/// <see cref="Configuration.ScriptContentLevel.Level3"/>.
/// </summary>
/// <remarks>
/// This exists to measure how much of a game is actually recovered. Cpp2IL only succeeds on a
/// fraction of methods, and that fraction varies heavily by instruction set, so a raw success
/// percentage per assembly is the input for deciding whether further work is worthwhile.
/// </remarks>
public static class Il2CppRecoveryReport
{
	private static readonly object lockObject = new();
	private static readonly List<MethodRecoveryRecord> records = [];

	/// <summary>
	/// Whether per method statistics are collected. Collection costs roughly 100 bytes per method.
	/// </summary>
	public static bool Enabled { get; set; } = true;

	/// <summary>
	/// The number of methods recorded so far.
	/// </summary>
	public static int Count
	{
		get
		{
			lock (lockObject)
			{
				return records.Count;
			}
		}
	}

	public static void Clear()
	{
		lock (lockObject)
		{
			records.Clear();
		}
	}

	public static void Add(MethodRecoveryRecord record)
	{
		lock (lockObject)
		{
			records.Add(record);
		}
	}

	public static MethodRecoveryRecord[] GetRecords()
	{
		lock (lockObject)
		{
			return records.ToArray();
		}
	}

	/// <summary>
	/// Writes a summary of the recorded outcomes to the log.
	/// </summary>
	public static void LogSummary()
	{
		MethodRecoveryRecord[] snapshot = GetRecords();
		if (snapshot.Length == 0)
		{
			return;
		}

		int analyzed = snapshot.Count(static r => IsAnalyzed(r.Outcome));
		int recovered = snapshot.Count(static r => r.Outcome is MethodRecoveryOutcome.Recovered);

		Logger.Info(LogCategory.Import, $"Il2Cpp method recovery: {recovered}/{analyzed} methods recovered ({FormatPercentage(recovered, analyzed)}) out of {snapshot.Length} total.");

		foreach (MethodRecoveryOutcome outcome in Enum.GetValues<MethodRecoveryOutcome>())
		{
			int count = snapshot.Count(r => r.Outcome == outcome);
			if (count > 0)
			{
				Logger.Info(LogCategory.Import, $"  {outcome}: {count}");
			}
		}

		// Assemblies excluded from analysis contribute nothing, so only report the ones that were analyzed.
		IEnumerable<IGrouping<string, MethodRecoveryRecord>> assemblies = snapshot
			.Where(static r => IsAnalyzed(r.Outcome))
			.GroupBy(static r => r.Assembly)
			.OrderByDescending(static g => g.Count())
			.Take(10);

		foreach (IGrouping<string, MethodRecoveryRecord> assembly in assemblies)
		{
			int total = assembly.Count();
			int success = assembly.Count(static r => r.Outcome is MethodRecoveryOutcome.Recovered);
			Logger.Info(LogCategory.Import, $"  {assembly.Key}: {success}/{total} ({FormatPercentage(success, total)})");
		}

		foreach ((string reason, int count) in GetTopFailureReasons(snapshot, 10))
		{
			Logger.Info(LogCategory.Import, $"  Failure x{count}: {reason}");
		}
	}

	/// <summary>
	/// Writes one row per method to a csv file so the results can be analyzed outside of AssetRipper.
	/// </summary>
	/// <param name="directory">The directory to write the file into.</param>
	/// <returns>The path of the written file, or null if there was nothing to write or writing failed.</returns>
	public static string? TryWriteCsv(string directory)
	{
		MethodRecoveryRecord[] snapshot = GetRecords();
		if (snapshot.Length == 0)
		{
			return null;
		}

		string path = Path.Join(directory, $"AssetRipper_Il2CppRecovery_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
		try
		{
			StringBuilder builder = new();
			builder.AppendLine("Assembly,Method,Outcome,InstructionCount,FailureMessage");
			foreach (MethodRecoveryRecord record in snapshot)
			{
				AppendCsvField(builder, record.Assembly);
				builder.Append(',');
				AppendCsvField(builder, record.Method);
				builder.Append(',');
				AppendCsvField(builder, record.Outcome.ToString());
				builder.Append(',');
				builder.Append(record.InstructionCount.ToString(CultureInfo.InvariantCulture));
				builder.Append(',');
				AppendCsvField(builder, record.FailureMessage ?? "");
				builder.AppendLine();
			}

			File.WriteAllText(path, builder.ToString());
			return path;
		}
		catch (Exception ex)
		{
			Logger.Error(LogCategory.Import, $"Failed to write the Il2Cpp recovery report to {path}", ex);
			return null;
		}
	}

	/// <summary>
	/// Groups failures by a normalized form of their message, so that the same underlying problem
	/// reported against different methods and addresses is counted together.
	/// </summary>
	public static List<(string Reason, int Count)> GetTopFailureReasons(IEnumerable<MethodRecoveryRecord> records, int limit)
	{
		return records
			.Where(static r => r.Outcome is MethodRecoveryOutcome.Failed)
			.GroupBy(static r => NormalizeFailureMessage(r.FailureMessage))
			.OrderByDescending(static g => g.Count())
			.Take(limit)
			.Select(static g => (g.Key, g.Count()))
			.ToList();
	}

	/// <summary>
	/// Only methods that recovery actually attempted count towards the success rate.
	/// </summary>
	private static bool IsAnalyzed(MethodRecoveryOutcome outcome)
	{
		return outcome is MethodRecoveryOutcome.Failed or MethodRecoveryOutcome.Minimal or MethodRecoveryOutcome.Recovered;
	}

	private static string FormatPercentage(int numerator, int denominator)
	{
		return denominator == 0
			? "n/a"
			: (numerator / (double)denominator).ToString("P1", CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Strips the parts of a failure message that vary between methods, leaving the shape of the error.
	/// </summary>
	private static string NormalizeFailureMessage(string? message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return "<none>";
		}

		int lineEnd = message.IndexOfAny(['\r', '\n']);
		ReadOnlySpan<char> firstLine = lineEnd < 0 ? message : message.AsSpan(0, lineEnd);

		StringBuilder builder = new(firstLine.Length);
		for (int i = 0; i < firstLine.Length; i++)
		{
			char c = firstLine[i];
			if (char.IsAsciiHexDigit(c) && IsInsideHexLiteral(firstLine, i))
			{
				// Collapse runs of hex digits following an 0x prefix into a single placeholder.
				if (builder.Length == 0 || builder[^1] != '#')
				{
					builder.Append('#');
				}
			}
			else if (char.IsAsciiDigit(c))
			{
				if (builder.Length == 0 || builder[^1] != '#')
				{
					builder.Append('#');
				}
			}
			else
			{
				builder.Append(c);
			}
		}

		string normalized = builder.ToString().Trim();
		const int MaxLength = 200;
		return normalized.Length > MaxLength ? normalized[..MaxLength] : normalized;
	}

	private static bool IsInsideHexLiteral(ReadOnlySpan<char> text, int index)
	{
		for (int i = index; i > 0; i--)
		{
			if (!char.IsAsciiHexDigit(text[i]))
			{
				return false;
			}
			if (i >= 2 && text[i - 1] is 'x' or 'X' && text[i - 2] is '0')
			{
				return true;
			}
		}
		return false;
	}

	private static void AppendCsvField(StringBuilder builder, string value)
	{
		builder.Append('"');
		foreach (char c in value)
		{
			if (c is '"')
			{
				builder.Append("\"\"");
			}
			else if (c is '\r' or '\n')
			{
				builder.Append(' ');
			}
			else
			{
				builder.Append(c);
			}
		}
		builder.Append('"');
	}
}
