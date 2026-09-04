using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;
using AssetRipper.Import.Logging;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.OutputFormats;
using System.Collections.Concurrent;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Cpp2IL's IL recovery output format, plus an account of what it managed on this run.
/// </summary>
/// <remarks>
/// <para>
/// Empty method bodies have several causes that look identical in the exported scripts — an
/// architecture with no ISIL lifter, a framework assembly stubbed by design, a method over the
/// analysis size cap, a conversion that threw — and the run reports success either way.
/// </para>
/// <para>
/// Cpp2IL does name the reason per method, but through its own warning channel, which
/// <see cref="Logger"/> maps to <see cref="LogType.Verbose"/> and then discards because verbose
/// logging is never switched on. Rather than turn that flood on, the reason is read back out of the
/// body the base class emits for a failure — it puts the message in the <c>ldstr</c> it throws — and
/// reported as counts per distinct reason.
/// </para>
/// </remarks>
public sealed class Il2CppIlRecoveryOutputFormat : AsmResolverDllOutputFormatIlRecovery
{
	/// <summary>Distinct reasons to name in the summary. Enough to see the pattern, not a wall of text.</summary>
	private const int ReasonsToReport = 5;

	/// <summary>Characters of a reason kept for grouping. Long enough to be distinct, short enough to group.</summary>
	private const int ReasonKeyLength = 160;

	private readonly ConcurrentDictionary<string, int> failureReasons = new(StringComparer.Ordinal);

	private int failedMethodCount;

	/// <summary>Methods recovery was attempted on. Framework assemblies are stubbed and not counted.</summary>
	public int AttemptedMethodCount => TotalMethodCount;

	/// <summary>
	/// Of those, the ones that got through without an exception. A method whose native code produced no
	/// ISIL is counted here too and keeps an empty body, so this is not a count of recovered bodies.
	/// </summary>
	public int CompletedMethodCount => SuccessfulMethodCount;

	/// <summary>Methods whose conversion threw, and whose body is now a throw carrying the reason.</summary>
	public int FailedMethodCount => Volatile.Read(ref failedMethodCount);

	public override List<AssemblyDefinition> BuildAssemblies(ApplicationAnalysisContext context)
	{
		List<AssemblyDefinition> assemblies = base.BuildAssemblies(context);
		LogSummary();
		return assemblies;
	}

	protected override void FillMethodBody(MethodDefinition methodDefinition, MethodAnalysisContext methodContext)
	{
		base.FillMethodBody(methodDefinition, methodContext);

		if (TryGetFailureReason(methodDefinition.CilMethodBody, out string? reason))
		{
			Interlocked.Increment(ref failedMethodCount);
			failureReasons.AddOrUpdate(Summarize(reason), 1, static (_, count) => count + 1);
		}
	}

	private void LogSummary()
	{
		int attempted = AttemptedMethodCount;

		if (attempted == 0)
		{
			Logger.Warning(LogCategory.Import,
				"Il2Cpp method body recovery attempted 0 methods. Recovery never reached the game's own code — " +
				"either no script assemblies were loaded, or every assembly was treated as a framework assembly.");
			return;
		}

		Logger.Info(LogCategory.Import,
			$"Il2Cpp method body recovery attempted {attempted} methods; {FailedMethodCount} failed to convert. " +
			"Framework assemblies are stubbed by design, and a method whose native code produced no ISIL keeps an empty body.");

		if (failureReasons.IsEmpty)
		{
			return;
		}

		foreach ((string reason, int count) in failureReasons.OrderByDescending(pair => pair.Value).Take(ReasonsToReport))
		{
			Logger.Info(LogCategory.Import, $"Il2Cpp method body recovery failure ({count} methods): {reason}");
		}

		int distinct = failureReasons.Count;
		if (distinct > ReasonsToReport)
		{
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {distinct - ReasonsToReport} further distinct failure reasons not listed.");
		}
	}

	/// <summary>
	/// Recognises the body the base class emits when conversion throws — the message, an exception, a
	/// throw — and returns the message it carries.
	/// </summary>
	private static bool TryGetFailureReason(CilMethodBody? body, [NotNullWhen(true)] out string? reason)
	{
		reason = null;

		if (body is null || body.Instructions.Count != 3)
		{
			return false;
		}

		if (body.Instructions[0].OpCode.Code != CilCode.Ldstr
			|| body.Instructions[1].OpCode.Code != CilCode.Newobj
			|| body.Instructions[2].OpCode.Code != CilCode.Throw)
		{
			return false;
		}

		reason = body.Instructions[0].Operand as string;
		return reason is not null;
	}

	/// <summary>
	/// Reduces a failure message to something worth grouping on: its first line, trimmed to length.
	/// </summary>
	private static string Summarize(string reason)
	{
		int newline = reason.IndexOfAny(['\r', '\n']);
		string firstLine = (newline < 0 ? reason : reason[..newline]).Trim();

		return firstLine.Length <= ReasonKeyLength ? firstLine : firstLine[..ReasonKeyLength] + "…";
	}
}
