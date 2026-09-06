using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using AssetRipper.CIL;
using AssetRipper.Import.Logging;
using Cpp2IL.Core;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.OutputFormats;
using LibCpp2IL.Elf;
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
	/// and the rounds are not free, so the loop stops rather than grinding. Raising this to 64 was tried
	/// and changed nothing: the same 18 bodies gave up, having accumulated 64 pops instead of 16. They
	/// do not converge because their imbalance is a branch join that merely surfaces at the return, so
	/// popping there can never settle it, and the extra rounds are pure cost.
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

	/// <summary>
	/// How far past a method's entry point an address is still called part of that method.
	/// </summary>
	/// <remarks>
	/// A bound rather than the real method length, which Cpp2IL does not carry here. 4 KB is well past
	/// any ordinary method and still far short of the gap to the runtime helper region, which on the
	/// test game is megabytes: every occurrence beyond this window was hundreds of KB away, so nothing
	/// is being claimed for an address that merely happens to follow a method.
	/// </remarks>
	private const ulong InteriorWindow = 0x1000;

	private ApplicationAnalysisContext? appContext;

	/// <summary>Managed method entry points, sorted. Built once, before any body is generated.</summary>
	private ulong[]? methodStarts;

	public override List<AssemblyDefinition> BuildAssemblies(ApplicationAnalysisContext context)
	{
		appContext = context;
		methodStarts = BuildMethodStarts(); // before the parallel body generation that reads it

		IlGenerator.UnresolvedMemoryLoad += ClassifyUnresolvedLoad;

		try
		{
			List<AssemblyDefinition> assemblies = base.BuildAssemblies(context);
			LogSummary();
			return assemblies;
		}
		finally
		{
			IlGenerator.UnresolvedMemoryLoad -= ClassifyUnresolvedLoad;
		}
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

	private readonly ConcurrentDictionary<string, int> unresolvedLoadKinds = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, string> unresolvedLoadExamples = new(StringComparer.Ordinal);

	/// <summary>
	/// Counts what the memory operands the generator gives up on actually are.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Every one of them becomes an <c>Unmanaged memory load</c> placeholder, and from the output they
	/// are indistinguishable: an offset off a register. The offset alone does not say why — the same
	/// <c>+0x18</c> is a field of a class whose base was never typed, a field of a generic instance
	/// whose layout could not be computed, and a member of a runtime struct that has no managed
	/// meaning at all, and those want three different fixes.
	/// </para>
	/// <para>
	/// So this classifies each one where the types are still in hand, before it is flattened into a
	/// string, and the summary at the end of the run says how many of each there were with an example
	/// of each. That is the list to work down. It hangs off the generator rather than walking the
	/// finished graph so that the count is of operands that were actually given up on, not of every
	/// operand in the method.
	/// </para>
	/// </remarks>
	private void ClassifyUnresolvedLoad(MethodAnalysisContext methodContext, IOperand operand)
	{
		if (appContext is null || operand is not MemoryOperand memory)
		{
			return;
		}

		string kind = ClassifyOperand(memory, appContext.Binary.is32Bit, SourcesFor(methodContext));
		unresolvedLoadKinds.AddOrUpdate(kind, 1, static (_, count) => count + 1);

		if (!unresolvedLoadExamples.ContainsKey(kind))
		{
			unresolvedLoadExamples.TryAdd(kind, $"{methodContext.DeclaringType?.Name}.{methodContext.Name}: {ExampleFor(methodContext, operand)}");
		}
	}

	/// <summary>The instruction the operand belongs to, which says far more than the operand alone.</summary>
	private static string ExampleFor(MethodAnalysisContext methodContext, IOperand operand)
	{
		if (methodContext.ControlFlowGraph is { } cfg)
		{
			foreach (Block block in cfg.Blocks)
			{
				foreach (Instruction instruction in block.Instructions)
				{
					foreach (IOperand candidate in instruction.Operands)
					{
						if (candidate.Equals(operand))
						{
							return instruction.ToString();
						}
					}
				}
			}
		}

		return operand.ToString() ?? "";
	}

	[ThreadStatic] private static MethodAnalysisContext? sourcesOwner;
	[ThreadStatic] private static Dictionary<LocalVariable, string>? sourcesCache;

	/// <summary>
	/// What defined each local in the method, so that a base can be named by where it came from.
	/// </summary>
	/// <remarks>
	/// Bodies are generated in parallel and every unresolved load in one body wants the same map, so
	/// it is built once per method and cached per thread.
	/// </remarks>
	private static Dictionary<LocalVariable, string> SourcesFor(MethodAnalysisContext methodContext)
	{
		if (ReferenceEquals(sourcesOwner, methodContext) && sourcesCache is not null)
		{
			return sourcesCache;
		}

		Dictionary<LocalVariable, string> sources = [];

		if (methodContext.ControlFlowGraph is { } cfg)
		{
			foreach (Block block in cfg.Blocks)
			{
				foreach (Instruction instruction in block.Instructions)
				{
					if (instruction.Destination is LocalVariable destination)
					{
						sources[destination] = instruction.OpCode switch
						{
							Cpp2IL.Core.ISIL.OpCode.Move when instruction.Operands.Count > 1 => $"Move from {DescribeSource(instruction.Operands[1])}",
							Cpp2IL.Core.ISIL.OpCode.Add when instruction.Operands.Count > 2 => $"Add of {DescribeSource(instruction.Operands[1])} and {DescribeSource(instruction.Operands[2])}",
							Cpp2IL.Core.ISIL.OpCode.Phi => "Phi",
							Cpp2IL.Core.ISIL.OpCode.Call or Cpp2IL.Core.ISIL.OpCode.IndirectCall => "a call's result",
							_ => instruction.OpCode.ToString(),
						};
					}
				}
			}
		}

		sourcesOwner = methodContext;
		sourcesCache = sources;
		return sources;
	}

	private static string DescribeSource(IOperand operand) => operand switch
	{
		MemoryOperand { Base: null } => "an absolute address",
		MemoryOperand { Base: LocalVariable { Type: { } baseType } } memory => $"[{baseType.Name} + 0x{memory.Addend:X}]",
		MemoryOperand => "an untyped base",
		AddressOf { Target: LocalVariable { Type: { } addressedType } } => $"AddressOf({addressedType.Name})",
		AddressOf { Target: LocalVariable } => "AddressOf(an untyped local)",
		AddressOf addressOf => $"AddressOf({addressOf.Target.GetType().Name})",
		LocalVariable { Type: { } sourceType } => sourceType.Name,
		LocalVariable => "an untyped local",
		FieldReference field => $"the field {field.Field.FieldType.Name}",
		_ => operand.GetType().Name,
	};

	private static string SourceOf(LocalVariable local, Dictionary<LocalVariable, string> baseSources)
		=> baseSources.TryGetValue(local, out string? found) ? found : "no definition";

	private string ClassifyOperand(MemoryOperand memory, bool is32Bit, Dictionary<LocalVariable, string> baseSources)
	{
		if (memory.Base is null)
		{
			return memory.Index is null ? "absolute address" : "indexed, no base";
		}

		if (memory.Base is not LocalVariable local)
		{
			return $"base is a {memory.Base.GetType().Name}";
		}

		if (local.Type is null)
		{
			// what defined it is the question, so say that rather than just "no type"
			return $"base has no type, from {SourceOf(local, baseSources)}";
		}

		string offset = memory.Addend < 0 ? $"-0x{-memory.Addend:X}" : $"0x{memory.Addend:X}";

		// negative or past what a uint can hold is never a named member of a runtime struct
		uint? member = memory.Addend is >= 0 and <= uint.MaxValue ? (uint)memory.Addend : null;

		switch (local.Type)
		{
			case RuntimeClassTypeAnalysisContext:
				return $"Il2CppClass.{(member is { } classMember ? Il2CppClassUsefulOffsets.GetOffsetName(classMember, is32Bit) : null) ?? offset}";
			case RuntimeMethodInfoAnalysisContext:
				return $"Il2CppMethodInfo.{(member is { } methodMember ? Il2CppMethodInfoUsefulOffsets.GetOffsetName(methodMember, appContext!.Binary) : null) ?? offset}";
			case StaticFieldStorageTypeAnalysisContext:
				return $"static field storage at {offset}";
			case SzArrayTypeAnalysisContext:
				return $"array at {offset}, from {SourceOf(local, baseSources)}";
			case ByRefTypeAnalysisContext:
				return $"byref at {offset}, from {SourceOf(local, baseSources)}";
		}

		if (memory.Addend < 0)
		{
			return "negative offset off a typed base";
		}

		TypeAnalysisContext owner = local.Type;

		if (owner is GenericInstanceTypeAnalysisContext generic)
		{
			return generic.GenericArguments.Any(a => a.IsValueType)
				? "generic instance, value type argument"
				: "generic instance, reference arguments";
		}

		if (owner.GenericParameters.Count > 0)
		{
			return "open generic type";
		}

		if (owner.IsValueType)
		{
			return "value type base";
		}

		long largest = 0;

		for (TypeAnalysisContext? candidate = owner; candidate is not null; candidate = candidate.BaseType)
		{
			foreach (FieldAnalysisContext field in candidate.Fields)
			{
				if (!field.IsStatic && field.BackingData?.FieldOffset is { } fieldOffset && fieldOffset > largest)
				{
					largest = fieldOffset;
				}
			}
		}

		return memory.Addend > largest
			? "past the last field of the base type"
			: "between fields of the base type";
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
			// Generic sharing folds many methods onto one address. Say so in words: written as "+53"
			// this read as an offset into the method, which is a different thing entirely.
			return methods.Count > 1 ? $"{name}, and {methods.Count - 1} more at this address" : name;
		}

		if (appContext.ThrowHelperNamesByAddress.TryGetValue(address, out string? helper)
			&& !string.IsNullOrWhiteSpace(helper))
		{
			return helper;
		}

		if (DescribePltStub(address) is string import)
		{
			return import;
		}

		return DescribeInteriorAddress(address);
	}

	/// <summary>Names resolved for PLT stubs, and the addresses that turned out not to be one.</summary>
	private readonly ConcurrentDictionary<ulong, string?> pltImports = new();

	/// <summary>
	/// Describes an address that is a stub in the ELF procedure linkage table.
	/// </summary>
	/// <remarks>
	/// These are calls into libc and the C++ runtime — 1794 of them on the test game, over 24 distinct
	/// addresses. They start no managed method and sit below the lowest one, so the interior-address
	/// naming below has nothing to say about them, and the code reads as a call to a bare number. The
	/// stub jumps through a GOT slot, and the dynamic linker's own relocations say which imported
	/// function that slot is bound to, so the name is in the file and only needed reading.
	/// </remarks>
	private string? DescribePltStub(ulong address)
	{
		if (appContext is null)
		{
			return null;
		}

		return pltImports.GetOrAdd(address, static (key, context) =>
		{
			if (context.Binary is not ElfFile elf)
			{
				return null;
			}

			ulong slot = context.InstructionSet.GetPltGotSlot(context, key);

			return slot != 0 && elf.TryGetPltImportName(slot, out string? name) ? $"native {name}" : null;
		}, appContext);
	}

	/// <summary>
	/// Describes an address that starts no managed method but falls inside one.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Measured on the test game, the addresses that reach here divide three ways. Most, 18862 of
	/// 22904 occurrences, are further than <see cref="InteriorWindow"/> from any managed method: they
	/// are il2cpp runtime helpers compiled into the same section as generated code, and the binary is
	/// stripped, so there is nothing to name them with. 1794 sit below the lowest managed method
	/// altogether, in the PLT, and are calls into libc and the C++ runtime. The remaining 2248 land
	/// inside a method that is known, at 191 distinct offsets, and those are what this names.
	/// </para>
	/// <para>
	/// "inside", not the method's own name: the address is not that method's entry point, and reading
	/// it as though the call went there would be wrong. What it gives a reader is a place in the
	/// binary to look, next to code they can already see decompiled.
	/// </para>
	/// </remarks>
	private string? DescribeInteriorAddress(ulong address)
	{
		ulong[] starts = methodStarts ?? [];

		if (starts.Length == 0 || address < starts[0])
		{
			return null;
		}

		int index = Array.BinarySearch(starts, address);
		if (index < 0)
		{
			index = ~index - 1;
		}

		if (index < 0)
		{
			return null;
		}

		ulong start = starts[index];
		ulong offset = address - start;

		if (offset == 0 || offset > InteriorWindow)
		{
			return null;
		}

		return appContext!.MethodsByAddress.TryGetValue(start, out List<MethodAnalysisContext>? methods)
			&& methods.Count > 0
			&& methods[0].FullName is { Length: > 0 } name
				? $"inside {name} +0x{offset:X}"
				: null;
	}

	private ulong[] BuildMethodStarts()
	{
		ulong[] starts = [.. appContext!.MethodsByAddress.Keys.Where(static address => address != 0)];
		Array.Sort(starts);
		return starts;
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
		ReportUnresolvedLoads();
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

		void ReportUnresolvedLoads()
		{
			if (unresolvedLoadKinds.IsEmpty)
			{
				return;
			}

			int total = unresolvedLoadKinds.Values.Sum();

			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {total} memory loads the generator gave up on, by kind:");

			foreach ((string kind, int count) in unresolvedLoadKinds.OrderByDescending(pair => pair.Value))
			{
				string example = unresolvedLoadExamples.TryGetValue(kind, out string? found) ? found : "";
				Logger.Info(LogCategory.Import, $"      {count,7} {kind}   e.g. {example}");
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
