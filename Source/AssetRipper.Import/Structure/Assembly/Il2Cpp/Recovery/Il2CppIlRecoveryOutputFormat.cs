using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using AssetRipper.CIL;
using AssetRipper.Import.Logging;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.OutputFormats;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
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

	/// <summary>Distinct imbalance shapes to name, with a worked example each.</summary>
	private const int ImbalanceShapesToReport = 12;

	/// <summary>
	/// Pops to try inserting into one body before giving up on it.
	/// </summary>
	/// <remarks>
	/// A body needing many is one where the generator went wrong in more than the one way this repairs,
	/// and the rounds are not free, so the loop stops rather than grinding.
	/// </remarks>
	private const int MaximumStackRepairs = 16;

	private readonly ConcurrentDictionary<string, int> failureReasons = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, int> invalidReasons = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, int> imbalanceShapes = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, string> imbalanceExamples = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, int> imbalanceNonBoundaryDetail = new(StringComparer.Ordinal);

	private int failedMethodCount;
	private int invalidMethodCount;
	private int repairedMethodCount;
	private int repairRoundCount;

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

	/// <summary>Methods whose stack was repaired, keeping a body that would otherwise have been discarded.</summary>
	public int RepairedMethodCount => Volatile.Read(ref repairedMethodCount);

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
			// walk off the end.
			body.Instructions.CalculateOffsets();
			body.VerifyLabels(false);

			// Then the stack, repairing what can be repaired rather than discarding the body over it.
			if (TryBalanceStack(body, out problem))
			{
				return;
			}
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

	/// <summary>
	/// Balances the evaluation stack, inserting the pops the generator left out.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The defect is specific and it is the only one the shapes point at: the generator emits a call to
	/// a method that returns a value, in a position where the value is discarded, and never pops it.
	/// <c>StringBuilder.Append</c> returns a <c>StringBuilder</c>, so a void method ending in
	/// <c>ldarg.0; ldfld builder; ldloc; call Append; ret</c> reaches its return with a value still on
	/// the stack and the whole body is rejected.
	/// </para>
	/// <para>
	/// Rather than reimplement the dataflow, this asks AsmResolver where the stack broke, pops one value
	/// at that return, and asks again. Each round either fixes one leftover or gives up, so a body that
	/// cannot be balanced costs a bounded number of rounds and still ends as a stub.
	/// </para>
	/// </remarks>
	private bool TryBalanceStack(CilMethodBody body, out string? problem)
	{
		problem = null;

		for (int round = 0; ; round++)
		{
			try
			{
				body.Instructions.CalculateOffsets();
				body.ComputeMaxStack(false);

				if (round > 0)
				{
					Interlocked.Increment(ref repairedMethodCount);
					Interlocked.Add(ref repairRoundCount, round);
				}

				return true;
			}
			catch (StackImbalanceException imbalance)
			{
				if (round >= MaximumStackRepairs)
				{
					RecordImbalance(body, imbalance.Offset, "gave up after " + MaximumStackRepairs + " repairs");
					problem = $"StackImbalanceException at IL_{imbalance.Offset:X4}, unrepaired after {MaximumStackRepairs} rounds";
					return false;
				}

				if (!TryPopLeftoverAtReturn(body, imbalance.Offset, out string? why))
				{
					RecordImbalance(body, imbalance.Offset, why);
					problem = $"StackImbalanceException at IL_{imbalance.Offset:X4}: {why}";
					return false;
				}
			}
		}
	}

	/// <summary>
	/// Pops one leftover value at the return the stack broke at, when that is what the imbalance is.
	/// </summary>
	/// <returns>False when the imbalance is not this defect, so the caller stops rather than guessing.</returns>
	private static bool TryPopLeftoverAtReturn(CilMethodBody body, int offset, out string? why)
	{
		int index = IndexOfOffset(body, offset);
		if (index < 0)
		{
			// The offset lands one past the last instruction, which is what AsmResolver reports when it
			// walks off the end of a body: the generator left the method without a terminator, so the
			// last instruction falls through into nothing. Terminating it is the repair.
			if (TryTerminateBody(body, offset))
			{
				why = null;
				return true;
			}

			why = "offset is not an instruction boundary";
			return false;
		}

		CilInstruction instruction = body.Instructions[index];
		if (instruction.OpCode.Code is not (CilCode.Ret or CilCode.Throw))
		{
			why = $"imbalance is at {instruction.OpCode.Mnemonic}, not at a return";
			return false;
		}

		// A void return wants an empty stack, so anything left is a discarded value. A value return
		// wants exactly one, and this cannot tell a leftover from a missing value, so it declines.
		if (instruction.OpCode.Code == CilCode.Ret
			&& body.Owner.Signature?.ReturnsValue == true)
		{
			why = "imbalance is at a value return, where a leftover cannot be told from a missing value";
			return false;
		}

		body.Instructions.Insert(index, new CilInstruction(CilOpCodes.Pop));
		why = null;
		return true;
	}

	/// <summary>
	/// Records what the generated IL looks like where the stack stopped balancing.
	/// </summary>
	/// <remarks>
	/// A count of failures says how bad the problem is; it does not say what the problem is. Grouping by
	/// the opcode shape around the offset does, because a generator defect shows up as the same few
	/// shapes repeated thousands of times rather than as thousands of unrelated ones.
	/// </remarks>
	private void RecordImbalance(CilMethodBody body, int offset, string? why)
	{
		bool exact = true;
		int index = IndexOfOffset(body, offset);
		if (index < 0)
		{
			// An offset that is not a boundary still localises to the instruction covering it, which is
			// what a reader needs; saying "not found" was a defect in this lookup rather than a finding.
			exact = false;
			index = IndexAtOrBefore(body, offset);
		}

		if (index < 0)
		{
			imbalanceShapes.AddOrUpdate($"offset IL_{offset:X4} is outside the body", 1, static (_, count) => count + 1);
			return;
		}

		if (!exact)
		{
			// An offset that lands inside an instruction has to be explained before the shapes around it
			// mean anything, so record how far inside, and whether the branches in this body carry
			// instruction labels or raw offsets - a raw offset goes stale when offsets are recalculated.
			CilInstruction covering = body.Instructions[index];
			int into = offset - covering.Offset;
			int rawOffsetLabels = body.Instructions.Count(i => i.Operand is CilOffsetLabel);

			imbalanceNonBoundaryDetail.AddOrUpdate(
				$"{into} bytes into {covering.OpCode.Mnemonic} (size {covering.Size}), body has {(rawOffsetLabels > 0 ? "raw offset labels" : "instruction labels only")}",
				1, static (_, count) => count + 1);
		}

		// The instruction the imbalance was detected at, and the three before it: enough to see which
		// construct the generator got wrong, short enough to group.
		string opcodes = string.Join(" ", Enumerable
			.Range(Math.Max(0, index - 3), Math.Min(4, index + 1))
			.Select(i => body.Instructions[i].OpCode.Mnemonic));

		string shape = $"{opcodes}{(exact ? "" : " (offset mid-instruction)")} - {why ?? "unrepaired"}";

		imbalanceShapes.AddOrUpdate(shape, 1, static (_, count) => count + 1);

		// One worked example per shape, so the shape can be looked at rather than guessed about.
		imbalanceExamples.TryAdd(shape, DescribeWindow(body, index));
	}

	private static int IndexOfOffset(CilMethodBody body, int offset)
	{
		for (int i = 0; i < body.Instructions.Count; i++)
		{
			if (body.Instructions[i].Offset == offset)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// Appends a return to a body that runs off its own end.
	/// </summary>
	/// <remarks>
	/// This is the dominant defect by count: 2379 of the imbalances in the test game report an offset
	/// one byte past a trailing call, because nothing terminates the body. A method that returns a value
	/// also needs something to return, and the default for its return type is the only honest choice -
	/// the real value is whatever the native code would have produced, which is exactly what could not
	/// be recovered.
	/// </remarks>
	private static bool TryTerminateBody(CilMethodBody body, int offset)
	{
		if (body.Instructions.Count == 0)
		{
			return false;
		}

		CilInstruction last = body.Instructions[^1];

		// Only when the offset really is the end of this body, and the end really is unterminated.
		if (offset != last.Offset + last.Size || IsTerminator(last))
		{
			return false;
		}

		if (body.Owner.Signature is { ReturnsValue: true } signature)
		{
			body.Instructions.AddDefaultValue(signature.ReturnType);
		}

		body.Instructions.Add(CilOpCodes.Ret);
		return true;
	}

	/// <summary>Whether an instruction ends a basic block, so nothing falls through past it.</summary>
	private static bool IsTerminator(CilInstruction instruction) => instruction.OpCode.Code
		is CilCode.Ret
		or CilCode.Throw
		or CilCode.Rethrow
		or CilCode.Br
		or CilCode.Br_S
		or CilCode.Leave
		or CilCode.Leave_S
		or CilCode.Endfinally
		or CilCode.Jmp;

	/// <summary>The instruction covering an offset, for an offset that is not itself a boundary.</summary>
	private static int IndexAtOrBefore(CilMethodBody body, int offset)
	{
		int best = -1;
		for (int i = 0; i < body.Instructions.Count; i++)
		{
			if (body.Instructions[i].Offset <= offset)
			{
				best = i;
			}
			else
			{
				break;
			}
		}
		return best;
	}

	/// <summary>Renders the instructions around an index, marking the one that failed.</summary>
	private static string DescribeWindow(CilMethodBody body, int index)
	{
		int start = Math.Max(0, index - 6);
		int end = Math.Min(body.Instructions.Count - 1, index + 3);

		StringBuilder window = new();
		window.Append(body.Owner.FullName);

		for (int i = start; i <= end; i++)
		{
			CilInstruction instruction = body.Instructions[i];
			window.Append("\n      ");
			window.Append(i == index ? " >> " : "    ");
			window.Append($"IL_{instruction.Offset:X4}: {instruction}");
		}

		return window.ToString();
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

		if (RepairedMethodCount > 0)
		{
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: repaired {RepairedMethodCount} bodies in " +
				$"{Volatile.Read(ref repairRoundCount)} rounds - popping call results the generator discarded, and " +
				"terminating bodies it left running off the end. Those bodies survive instead of becoming stubs.");
		}

		if (InvalidMethodCount > 0)
		{
			Logger.Warning(LogCategory.Import,
				$"Il2Cpp method body recovery: {InvalidMethodCount} generated bodies did not verify and were replaced with stubs. " +
				"Left in place they would abort decompilation of their whole assembly, losing every other method in it.");
		}

		Report("failure", failureReasons);
		Report("invalid body", invalidReasons);
		ReportImbalanceShapes();

		void ReportImbalanceShapes()
		{
			if (imbalanceShapes.IsEmpty)
			{
				return;
			}

			int total = imbalanceShapes.Values.Sum();
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {total} stack imbalances across {imbalanceShapes.Count} distinct opcode shapes. " +
				"A generator defect repeats a few shapes; unrelated shapes mean unrelated causes.");

			foreach ((string detail, int count) in imbalanceNonBoundaryDetail.OrderByDescending(pair => pair.Value).Take(8))
			{
				Logger.Info(LogCategory.Import, $"Il2Cpp method body recovery: {count} imbalances reported {detail}");
			}

			foreach ((string shape, int count) in imbalanceShapes.OrderByDescending(pair => pair.Value).Take(ImbalanceShapesToReport))
			{
				Logger.Info(LogCategory.Import,
					$"Il2Cpp method body recovery: {count} methods imbalance after [{shape}]");

				if (imbalanceExamples.TryGetValue(shape, out string? example))
				{
					Logger.Info(LogCategory.Import, $"      example: {example}");
				}
			}
		}

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
