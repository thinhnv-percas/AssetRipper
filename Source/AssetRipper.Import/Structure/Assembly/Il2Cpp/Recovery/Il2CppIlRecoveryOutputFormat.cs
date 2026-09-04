using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;
using AssetRipper.CIL;
using AssetRipper.Import.Logging;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.OutputFormats;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text.RegularExpressions;

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
public sealed partial class Il2CppIlRecoveryOutputFormat : AsmResolverDllOutputFormatIlRecovery
{
	/// <summary>Distinct reasons to name in the summary. Enough to see the pattern, not a wall of text.</summary>
	private const int ReasonsToReport = 5;

	/// <summary>Characters of a reason kept for grouping. Long enough to be distinct, short enough to group.</summary>
	private const int ReasonKeyLength = 160;

	private readonly ConcurrentDictionary<string, int> failureReasons = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, int> invalidReasons = new(StringComparer.Ordinal);

	private int failedMethodCount;
	private int invalidMethodCount;

	/// <summary>Methods recovery was attempted on. Framework assemblies are stubbed and not counted.</summary>
	public int AttemptedMethodCount => TotalMethodCount;

	/// <summary>
	/// Of those, the ones that got through without an exception. A method whose native code produced no
	/// ISIL is counted here too and keeps an empty body, so this is not a count of recovered bodies.
	/// </summary>
	public int CompletedMethodCount => SuccessfulMethodCount;

	/// <summary>Methods whose conversion threw, and whose body is now a throw carrying the reason.</summary>
	public int FailedMethodCount => Volatile.Read(ref failedMethodCount);

	/// <summary>Methods whose generated IL did not verify and was replaced with a stub.</summary>
	public int InvalidMethodCount => Volatile.Read(ref invalidMethodCount);

	private ApplicationAnalysisContext? appContext;

	public override List<AssemblyDefinition> BuildAssemblies(ApplicationAnalysisContext context)
	{
		appContext = context;

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
			return;
		}

		ReplaceIfUnverifiable(methodDefinition);
		NamePlaceholderAddresses(methodDefinition.CilMethodBody);
	}

	/// <summary>
	/// Puts names to the addresses in the placeholder messages the generator leaves in a body.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Where the generator cannot resolve a call it emits <c>Console.WriteLine("Method not found @ACC5DC")</c>,
	/// which reads as nothing at all even though Cpp2IL resolved that address earlier in the run and
	/// then kept only the number. Appending the name turns the line into
	/// <c>Method not found @ACC5DC (UnityEngine.Object.op_Implicit)</c>.
	/// </para>
	/// <para>
	/// This only rewrites the text inside an existing <c>ldstr</c>. Naming the call properly — replacing
	/// the placeholder with a real call instruction — changes how many operands the body consumes, and
	/// measuring that showed it unbalances the stack in about a thousand methods, which then lose their
	/// body entirely. A longer string costs nothing.
	/// </para>
	/// </remarks>
	private void NamePlaceholderAddresses(CilMethodBody? body)
	{
		if (appContext is null || body is null)
		{
			return;
		}

		foreach (CilInstruction instruction in body.Instructions)
		{
			if (instruction.OpCode.Code != CilCode.Ldstr || instruction.Operand is not string text)
			{
				continue;
			}

			if (TryNameAddressesIn(text, out string? named))
			{
				instruction.Operand = named;
			}
		}
	}

	/// <summary>
	/// Rewrites every hex address in a placeholder message that resolves to something with a name.
	/// </summary>
	private bool TryNameAddressesIn(string text, [NotNullWhen(true)] out string? named)
	{
		named = null;

		// Both placeholder shapes the generator emits: "@<hex>" for a call and "[<hex>]" for a load.
		MatchCollection matches = PlaceholderAddress().Matches(text);
		if (matches.Count == 0)
		{
			return false;
		}

		string result = text;
		bool changed = false;

		foreach (Match match in matches)
		{
			string hex = match.Groups["address"].Value;
			if (!ulong.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out ulong address))
			{
				continue;
			}

			if (TryDescribe(address) is not string description)
			{
				continue;
			}

			// Appended rather than substituted: the address is how a reader cross-checks against the
			// binary, and it is what the [Address] attribute on the method is expressed in.
			result = result.Replace(match.Value, $"{match.Value} ({description})", StringComparison.Ordinal);
			changed = true;
		}

		if (!changed)
		{
			return false;
		}

		named = result;
		return true;
	}

	private string? TryDescribe(ulong address)
	{
		if (appContext is null || address == 0)
		{
			return null;
		}

		if (appContext.MethodsByAddress.TryGetValue(address, out List<MethodAnalysisContext>? methods)
			&& methods.Count > 0
			&& methods[0].FullName is { Length: > 0 } name)
		{
			return methods.Count > 1 ? $"{name} +{methods.Count - 1}" : name;
		}

		return appContext.ThrowHelperNamesByAddress.TryGetValue(address, out string? helper)
			&& !string.IsNullOrWhiteSpace(helper)
				? helper
				: null;
	}

	/// <summary>
	/// Matches the hex address in <c>@ABCDEF</c> and <c>[ABCDEF]</c>.
	/// </summary>
	/// <remarks>
	/// Source generated rather than constructed: this assembly builds AOT compatible, where
	/// <see cref="RegexOptions.Compiled"/> silently falls back to the interpreter.
	/// </remarks>
	[GeneratedRegex(@"[@\[](?<address>[0-9A-Fa-f]{4,16})\]?")]
	private static partial Regex PlaceholderAddress();

	/// <summary>
	/// Replaces a generated body that does not verify with a stub.
	/// </summary>
	/// <remarks>
	/// This is worth doing because of how the failure lands. ILSpy decompiles an assembly as one
	/// parallel unit, and a body it cannot read throws out of that unit, so
	/// <c>ScriptDecompiler.DecompileWholeProject</c> loses every remaining file in the assembly — a
	/// handful of bad bodies costs thousands of methods that were fine. Stubbing the bad one keeps the
	/// cost to that method.
	/// </remarks>
	private void ReplaceIfUnverifiable(MethodDefinition methodDefinition)
	{
		CilMethodBody? body = methodDefinition.CilMethodBody;
		if (body is null || body.Instructions.Count == 0)
		{
			return;
		}

		string? problem;
		try
		{
			// Branch targets first: an instruction pointing outside the body is what makes a reader
			// walk off the end. Then the stack, which has to balance for the body to be readable.
			body.Instructions.CalculateOffsets();
			body.VerifyLabels(false);
			body.ComputeMaxStack(false);
			return;
		}
		catch (Exception ex)
		{
			problem = $"{ex.GetType().Name}: {ex.Message}";
		}

		Interlocked.Increment(ref invalidMethodCount);
		invalidReasons.AddOrUpdate(Summarize(problem), 1, static (_, count) => count + 1);

		// The same minimal body Cpp2IL uses for a method it does not recover.
		methodDefinition.ReplaceMethodBodyWithMinimalImplementation();
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

		if (InvalidMethodCount > 0)
		{
			Logger.Warning(LogCategory.Import,
				$"Il2Cpp method body recovery: {InvalidMethodCount} generated bodies did not verify and were replaced with stubs. " +
				"Left in place they would abort decompilation of their whole assembly, losing every other method in it.");
		}

		Report("failure", failureReasons);
		Report("invalid body", invalidReasons);

		static void Report(string kind, ConcurrentDictionary<string, int> reasons)
		{
			if (reasons.IsEmpty)
			{
				return;
			}

			foreach ((string reason, int count) in reasons.OrderByDescending(pair => pair.Value).Take(ReasonsToReport))
			{
				Logger.Info(LogCategory.Import, $"Il2Cpp method body recovery {kind} ({count} methods): {reason}");
			}

			int distinct = reasons.Count;
			if (distinct > ReasonsToReport)
			{
				Logger.Info(LogCategory.Import,
					$"Il2Cpp method body recovery: {distinct - ReasonsToReport} further distinct {kind} reasons not listed.");
			}
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
