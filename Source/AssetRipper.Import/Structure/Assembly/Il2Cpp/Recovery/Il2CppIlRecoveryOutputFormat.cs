using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.CIL;
using AssetRipper.Import.Logging;
using Cpp2IL.Core.Analysis;
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
		IlGenerator.UnresolvedCall += RecordUnresolvedCall;
		IlGenerator.ResolvedMemoryLoad += RecordResolvedLoadCase;
		IlGenerator.UntypedLocal += ClassifyUntypedLocal;

		try
		{
			List<AssemblyDefinition> assemblies = base.BuildAssemblies(context);
			LogSummary();
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {Cpp2IL.Core.Utils.BaseCallingConventionResolver.AggregateArgumentsComposed} call arguments the ABI " +
				"spread over several vector registers were composed back into their value.");
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: a write narrower than the field its offset lands on named a member inside it "
				+ $"{Cpp2IL.Core.Analysis.MetadataResolver.NarrowWritesRefined} times; "
				+ $"{Cpp2IL.Core.Analysis.MetadataResolver.NarrowWritesUnresolved} times no member accounted for the width, so the field stood.");
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {widenedMemberCount} members of a game assembly were widened " +
				"because a recovered body reaches them from outside the type, or the assembly, that declares them.");
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {IlGenerator.HiddenFieldsReadThroughAProperty} reads of a hidden static field " +
				"were written as the public property that returns it.");
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {IlGenerator.SharedGenericCallsRetargeted} calls were retargeted from a " +
				"shared generic instantiation onto the one the receiver's own type names.");
			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: SSA destruction left copies - {Cpp2IL.Core.Analysis.CopyCoalescer.Coalesced} coalesced, " +
				$"{Cpp2IL.Core.Analysis.CopyCoalescer.RejectedForInterference} kept because the two locals are live at once, " +
				$"{Cpp2IL.Core.Analysis.CopyCoalescer.RejectedForType} because their types differ.");
			return assemblies;
		}
		finally
		{
			IlGenerator.UnresolvedMemoryLoad -= ClassifyUnresolvedLoad;
			IlGenerator.UnresolvedCall -= RecordUnresolvedCall;
			IlGenerator.ResolvedMemoryLoad -= RecordResolvedLoadCase;
			IlGenerator.UntypedLocal -= ClassifyUntypedLocal;
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

		WidenMembersTheBodyCannotReach(methodDefinition);
		ReplaceIfUnverifiable(methodDefinition);
		NamePlaceholderAddresses(methodDefinition.CilMethodBody);
	}

	private readonly ConcurrentDictionary<string, int> unresolvedLoadKinds = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, string> unresolvedLoadExamples = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, int> untypedLocalKinds = new(StringComparer.Ordinal);
	private readonly ConcurrentDictionary<string, string> untypedLocalExamples = new(StringComparer.Ordinal);

	/// <summary>
	/// Widens a member of this assembly that the generated body reaches but a compiler would not let it.
	/// </summary>
	/// <remarks>
	/// <para>
	/// il2cpp inlines a constructor into its caller, so what the caller does is allocate the object and
	/// write its fields. Where the type is a compiler-generated one — an iterator state machine, a
	/// closure — those fields are private, and a private member of a nested type is not accessible from
	/// the type it is nested in. So <c>LoadASynchronously</c> comes back writing
	/// <c>&lt;LoadASynchronously&gt;d__1.&lt;&gt;1__state</c> and the exported script does not compile,
	/// which was the one CS0122 in the game reported.
	/// </para>
	/// <para>
	/// The same happens across the game's own assemblies, and far more often: il2cpp inlines the fast
	/// path of a property, so <c>Assembly-CSharp</c> reaches straight into PlayMaker's
	/// <c>FsmBool.value</c> and <c>NamedVariable.useVariable</c> - 4606 errors on the test game, more
	/// than every other kind together. Those cannot be read back through the property, because the
	/// property is not a trivial one: <c>FsmBool.Value</c> consults <c>CastVariable</c> first, and the
	/// field access really is the inside of it.
	/// </para>
	/// <para>
	/// So a member of any assembly this export invented the source for is widened - to internal within
	/// the assembly, to public across two of them, and the owning type with it, since a public member
	/// of an internal type is reachable by nobody. A member of a *framework* assembly is left alone,
	/// because the assembly the script is really compiled against is not this one: there the answer is
	/// the public API, and where there is no public API the error is honest.
	/// </para>
	/// </remarks>
	private static void WidenMembersTheBodyCannotReach(MethodDefinition methodDefinition)
	{
		if (methodDefinition.CilMethodBody is not { } body || methodDefinition.DeclaringType is not { } accessor)
		{
			return;
		}

		if (methodDefinition.DeclaringModule is not { RuntimeContext: { } runtime } module)
		{
			return;
		}

		foreach (CilInstruction instruction in body.Instructions)
		{
			// A reference within this assembly arrives as the definition itself; one to another of the
			// game's assemblies has to be resolved to find what to widen.
			switch (instruction.Operand)
			{
				case IFieldDescriptor fieldDescriptor
					when fieldDescriptor.Resolve(runtime, out FieldDefinition? field) == ResolutionStatus.Success && field is not null:
					WidenField(field, accessor, module);
					break;
				case IMethodDescriptor methodDescriptor
					when methodDescriptor.Resolve(runtime, out MethodDefinition? called) == ResolutionStatus.Success && called is not null:
					WidenMethod(called, accessor, module);
					break;
			}
		}
	}

	private static void WidenField(FieldDefinition field, TypeDefinition accessor, ModuleDefinition? from)
	{
		if (field.DeclaringType is not { } owner || !CanWiden(owner, accessor, from, out bool acrossAssemblies))
		{
			return;
		}

		FieldAttributes access = field.Attributes & FieldAttributes.FieldAccessMask;
		FieldAttributes wanted = Widened(access, acrossAssemblies);

		if (wanted != access)
		{
			field.Attributes = (field.Attributes & ~FieldAttributes.FieldAccessMask) | wanted;
			Interlocked.Increment(ref widenedMemberCount);
		}

		WidenDeclaringTypes(owner, acrossAssemblies);
	}

	private static void WidenMethod(MethodDefinition method, TypeDefinition accessor, ModuleDefinition? from)
	{
		if (method.DeclaringType is not { } owner || !CanWiden(owner, accessor, from, out bool acrossAssemblies))
		{
			return;
		}

		MethodAttributes access = method.Attributes & MethodAttributes.MemberAccessMask;
		MethodAttributes wanted = Widened(access, acrossAssemblies);

		if (wanted != access)
		{
			method.Attributes = (method.Attributes & ~MethodAttributes.MemberAccessMask) | wanted;
			Interlocked.Increment(ref widenedMemberCount);
		}

		WidenDeclaringTypes(owner, acrossAssemblies);
	}

	/// <summary>
	/// Whether the accessibility of a member of <paramref name="owner"/> is this export's to state.
	/// </summary>
	private static bool CanWiden(TypeDefinition owner, TypeDefinition accessor, ModuleDefinition? from, out bool acrossAssemblies)
	{
		acrossAssemblies = owner.DeclaringModule != from;

		if (!acrossAssemblies)
		{
			// Within one assembly, only what a nesting relationship does not already reach.
			return !SameOrNestedIn(accessor, owner);
		}

		return owner.DeclaringModule?.Assembly?.Name is { } name
			&& !Il2CppRecoveryDiagnosticsProcessingLayer.IsFrameworkAssembly(name);
	}

	/// <summary>
	/// A public member of a type nobody can name is reachable by nobody, so the type goes with it.
	/// </summary>
	private static void WidenDeclaringTypes(TypeDefinition owner, bool acrossAssemblies)
	{
		if (!acrossAssemblies)
		{
			return;
		}

		for (TypeDefinition? type = owner; type is not null; type = type.DeclaringType)
		{
			TypeAttributes visibility = type.Attributes & TypeAttributes.VisibilityMask;
			TypeAttributes wanted = type.DeclaringType is null ? TypeAttributes.Public : TypeAttributes.NestedPublic;

			if (visibility != wanted)
			{
				type.Attributes = (type.Attributes & ~TypeAttributes.VisibilityMask) | wanted;
				Interlocked.Increment(ref widenedMemberCount);
			}
		}
	}

	/// <summary>
	/// The accessibility to give a member so that it reaches the code that names it, without ever
	/// reaching less than it did before.
	/// </summary>
	/// <remarks>
	/// <c>protected</c> to <c>internal</c> is not a widening: a derived type in another assembly can
	/// call a protected constructor and cannot call an internal one. Doing it to
	/// <c>System.Attribute..ctor</c> made every attribute the export declares uncompilable - five
	/// errors on a game that otherwise had two. Protected therefore becomes protected internal, which
	/// is the union of the two, and everything already at internal or wider is left alone.
	/// </remarks>
	private static FieldAttributes Widened(FieldAttributes access, bool acrossAssemblies)
		=> acrossAssemblies
			? FieldAttributes.Public
			: access switch
			{
				FieldAttributes.PrivateScope or FieldAttributes.Private or FieldAttributes.FamilyAndAssembly => FieldAttributes.Assembly,
				FieldAttributes.Family => FieldAttributes.FamilyOrAssembly,
				_ => access,
			};

	private static MethodAttributes Widened(MethodAttributes access, bool acrossAssemblies)
		=> acrossAssemblies
			? MethodAttributes.Public
			: access switch
			{
				MethodAttributes.CompilerControlled or MethodAttributes.Private or MethodAttributes.FamilyAndAssembly => MethodAttributes.Assembly,
				MethodAttributes.Family => MethodAttributes.FamilyOrAssembly,
				_ => access,
			};

	private static bool SameOrNestedIn(TypeDefinition type, TypeDefinition owner)
	{
		for (TypeDefinition? candidate = type; candidate is not null; candidate = candidate.DeclaringType)
		{
			if (candidate == owner)
			{
				return true;
			}
		}

		return false;
	}

	private static int widenedMemberCount;

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

		RecordUnresolvedLoadCase(methodContext, memory, kind);
	}

	/// <summary>
	/// Appends one line of evidence per unresolved load, when <c>CPP2IL_DUMP_LOADS</c> names a file.
	/// </summary>
	/// <remarks>
	/// The summary says how many loads of each kind there are and shows one example, which is enough
	/// to choose what to work on and not enough to work on it. A family of 850 is only worth treating
	/// as one bug if the cases really do share a cause, and that cannot be read off a single example -
	/// the last time a family was picked apart this way it turned out to be three causes and a
	/// measurement artefact. Each line here carries what is needed to tell them apart: the base's
	/// declared type, the offset asked for, and the largest offset any field of that type chain
	/// declares, so "past the last field" can be checked rather than believed.
	/// </remarks>
	private void RecordUnresolvedLoadCase(MethodAnalysisContext methodContext, MemoryOperand memory, string kind)
	{
		if (unresolvedLoadCaseFile is null)
		{
			return;
		}

		TypeAnalysisContext? baseType = (memory.Base as LocalVariable)?.Type;
		TypeAnalysisContext? owner = (baseType as StaticFieldStorageTypeAnalysisContext)?.OwnerType ?? baseType;

		long largest = 0;
		int fieldCount = 0;
		for (TypeAnalysisContext? candidate = owner; candidate is not null; candidate = candidate.BaseType)
		{
			foreach (FieldAnalysisContext field in candidate.Fields)
			{
				if (!field.IsStatic && field.BackingData?.FieldOffset is { } fieldOffset)
				{
					fieldCount++;
					if (fieldOffset > largest)
					{
						largest = fieldOffset;
					}
				}
			}
		}

		// The instruction that defines the base, which is where the base's type came from - or did not.
		// A load fails for one of two reasons and only this tells them apart: the layout could not
		// place the offset, or nothing gave the base a usable type in the first place.
		string baseDefinition = "<none>";
		if (memory.Base is LocalVariable baseLocal && methodContext.ControlFlowGraph is { } graph)
		{
			foreach (Instruction candidate in graph.Instructions)
			{
				if (candidate.Destination is LocalVariable defined && ReferenceEquals(defined, baseLocal))
				{
					baseDefinition = candidate.OpCode.ToString();

					if (candidate.OpCode is OpCode.Move or OpCode.IsInst && candidate.Operands.Count > 1)
					{
						baseDefinition += ":" + candidate.Operands[1] switch
						{
							MemoryOperand => "memory",
							FieldReference reference => "field " + reference.Field.FieldType.Name,
							LocalVariable { Type: { } copied } => "local " + copied.Name,
							LocalVariable => "untyped local",
							TypeAnalysisContext type => "type " + type.Name,
							_ => candidate.Operands[1].GetType().Name,
						};
					}

					break;
				}
			}
		}

		string row = string.Join('\t',
			kind,
			methodContext.DeclaringType?.DeclaringAssembly?.Name ?? "",
			methodContext.DeclaringType?.FullName ?? "",
			methodContext.Name,
			owner?.FullName ?? "<untyped>",
			owner?.BaseType?.FullName ?? "",
			owner?.GetType().Name ?? "",
			memory.Addend.ToString("X"),
			largest.ToString("X"),
			fieldCount.ToString(),
			memory.Size.ToString(),
			baseDefinition,
			RootCauseOf(methodContext, memory),
			MetadataStateOf(owner, memory, methodContext),
			OriginOf(methodContext, memory.Base),
			SearchAnswersNow(owner, memory),
			RuntimeFieldOf(baseType, memory, TestedBit(methodContext, memory)),
			ConsumerOf(methodContext, memory),
			memory.ToString());

		lock (unresolvedLoadCaseLock)
		{
			unresolvedLoadCaseWriter ??= new StreamWriter(unresolvedLoadCaseFile, append: false);
			unresolvedLoadCaseWriter.WriteLine(row);
		}
	}

	/// <summary>
	/// Which bit of the loaded value the consuming instruction tests, when it tests exactly one.
	/// </summary>
	/// <remarks>
	/// An offset names a storage unit; several bitfields share one, so the offset alone cannot say
	/// which member was reached. The consumer can: a mask with one bit set names that bit, and a
	/// signed less-than-zero test names the sign bit - which is how generated code reads the last
	/// member of a 32-bit bitfield without a shift. Anything else returns null rather than a guess,
	/// and the report falls back to naming the group.
	/// </remarks>
	private static int? TestedBit(MethodAnalysisContext methodContext, MemoryOperand memory)
	{
		if (methodContext.ControlFlowGraph is not { } graph)
		{
			return null;
		}

		string wanted = memory.ToString();

		foreach (Instruction instruction in graph.AllInstructions)
		{
			bool carries = false;
			long? mask = null;

			foreach (IOperand operand in instruction.Operands)
			{
				if (operand?.ToString() == wanted)
				{
					carries = true;
				}
				else if (operand is Immediate immediate)
				{
					try
					{
						mask = Convert.ToInt64(immediate.Value);
					}
					catch (Exception)
					{
						return null;
					}
				}
			}

			if (!carries)
			{
				continue;
			}

			// `value < 0` on a 32-bit word is the sign bit, which is how the last member of a full
			// bitfield is read: no shift, no mask, just the comparison.
			if (instruction.OpCode is Cpp2IL.Core.ISIL.OpCode.CheckLess && mask == 0)
			{
				return 31;
			}

			if (instruction.OpCode is Cpp2IL.Core.ISIL.OpCode.And && mask is { } value and > 0
				&& (value & (value - 1)) == 0)
			{
				return System.Numerics.BitOperations.TrailingZeroCount((ulong)value);
			}

			return null;
		}

		return null;
	}

	/// <summary>
	/// The instruction that consumes this load, and what it does with the value.
	/// </summary>
	/// <remarks>
	/// An offset names a member; what is done to the value afterwards names which <em>part</em> of it
	/// was wanted. A bitfield storage unit is one byte that several members share, so the offset alone
	/// cannot say which - but a mask and a shift can, and they are in the consuming instruction. This
	/// is the evidence that settles "recognise this shape and drop it" against "this is several
	/// shapes", which iteration 046 flagged and could not answer.
	/// </remarks>
	private static string ConsumerOf(MethodAnalysisContext methodContext, MemoryOperand memory)
	{
		if (methodContext.ControlFlowGraph is not { } graph)
		{
			return "-";
		}

		// Matched by text rather than by reference: the operand the generator hands this event is not
		// always the object still sitting in the graph - an operand nested inside another, or one a
		// late pass rebuilt, is equal without being identical, and reference equality reported "no
		// consumer" for all 2722.
		string wanted = memory.ToString();

		foreach (Instruction instruction in graph.AllInstructions)
		{
			for (int i = 0; i < instruction.Operands.Count; i++)
			{
				if (instruction.Operands[i]?.ToString() != wanted)
				{
					continue;
				}

				// The opcode plus the other operands: for a mask or a shift the immediate is the whole
				// answer, and for anything else the shape of the use is still what distinguishes it.
				List<string> others = [];
				for (int other = 0; other < instruction.Operands.Count; other++)
				{
					if (other != i)
					{
						others.Add(instruction.Operands[other] is Immediate immediate
							? "0x" + Convert.ToString(Convert.ToInt64(immediate.Value), 16)
							: instruction.Operands[other].GetType().Name);
					}
				}

				// The slot matters: operand 0 is the destination, so the same memory operand there is a
				// store rather than a load and the question "what was done with the value" is the
				// wrong one to ask of it.
				return others.Count == 0
					? $"{instruction.OpCode}[{i}]"
					: $"{instruction.OpCode}[{i}]:" + string.Join(",", others);
			}
		}

		return "<no consumer>";
	}

	/// <summary>
	/// The runtime structure member a read of <c>Il2CppClass</c> or <c>MethodInfo</c> reaches, by name.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A read of the runtime's own structures is the largest single group of unresolved loads and the
	/// one least like the others: the base is correctly typed, there is no managed field at the offset,
	/// and there never will be. Counting it as a recovery failure is wrong, and dropping it silently is
	/// worse - so it is named instead, from the same measured tables every pass that keys on one of
	/// these offsets reads (<c>Il2CppClassOffsetPatcher</c> prepends what it measured from the struct
	/// database, so the names follow the Unity version rather than being written down).
	/// </para>
	/// <para>
	/// An offset the tables do not name is reported as unnamed rather than guessed. That is the
	/// difference between "this is a vtable slot" and "this is somewhere in a structure we know the
	/// shape of", and only the first is a finished answer.
	/// </para>
	/// </remarks>
	private string RuntimeFieldOf(TypeAnalysisContext? baseType, MemoryOperand memory, int? testedBit)
	{
		if (appContext is null || memory.Addend is < 0 or > uint.MaxValue)
		{
			return "-";
		}

		uint offset = (uint)memory.Addend;
		bool is32Bit = appContext.Binary.is32Bit;

		switch (baseType)
		{
			case RuntimeClassTypeAnalysisContext:
				if (Il2CppClassUsefulOffsets.GetOffsetName(offset, is32Bit) is { } named)
				{
					return "Il2CppClass." + named;
				}

				// The vtable is not one member but a run of them, so its name is the run and the slot
				// is the rest of the answer. InterfaceDispatchRecovery is what turns one into a call.
				if (Il2CppClassUsefulOffsets.IsPointerIntoVtable(offset, appContext.MetadataVersion, is32Bit))
				{
					return "Il2CppClass.vtable[]";
				}

				// The curated table names what the passes key on; the struct database names the rest -
				// and where the byte is a bitfield unit, the bit the consumer tests says which member.
				if (testedBit is { } bit
					&& Il2CppClassOffsetPatcher.BitFieldMemberAt("Il2CppClass", offset, bit) is { } member)
				{
					return "Il2CppClass." + member;
				}

				return Il2CppClassOffsetPatcher.MemberNames("Il2CppClass").TryGetValue(offset, out string? measured)
					? "Il2CppClass." + measured
					: "Il2CppClass.<unnamed>";

			case RuntimeMethodInfoAnalysisContext:
				if (Il2CppMethodInfoUsefulOffsets.GetOffsetName(offset, appContext.Binary) is { } method)
				{
					return "MethodInfo." + method;
				}

				if (testedBit is { } methodBit
					&& Il2CppClassOffsetPatcher.BitFieldMemberAt("MethodInfo", offset, methodBit) is { } methodMember)
				{
					return "MethodInfo." + methodMember;
				}

				return Il2CppClassOffsetPatcher.MemberNames("MethodInfo").TryGetValue(offset, out string? measuredMethod)
					? "MethodInfo." + measuredMethod
					: "MethodInfo.<unnamed>";

			case StaticFieldStorageTypeAnalysisContext:
				return "Il2CppStaticFields";

			default:
				return "-";
		}
	}

	/// <summary>
	/// Whether the resolver's own field search answers for this load, asked where the load is counted.
	/// </summary>
	/// <remarks>
	/// A load reported unresolved with a well typed base and a field at exactly its offset reads as a
	/// defect in the search. It need not be one: the search runs inside the type fixpoint and the type
	/// on the row is the local's final one, so the same row is produced both by a search that ran and
	/// found nothing and by an operand the search never looked at. Running the search here settles
	/// which - SEARCH_ANSWERS means it was never asked, SEARCH_EMPTY means it was asked and had no
	/// answer - and those want opposite work.
	/// </remarks>
	private static string SearchAnswersNow(TypeAnalysisContext? owner, MemoryOperand memory)
	{
		if (owner is null)
		{
			return "NO_OWNER";
		}

		// The resolver only ever looks at [base + addend]. An indexed operand is an element address,
		// which the array path owns, so asking the field search about one answers a question nobody
		// asked: every [base + index] would "resolve" to whatever sits at offset zero.
		if (memory.Index is not null || memory.Scale != 0)
		{
			return "NOT_A_FIELD_ACCESS";
		}

		bool wantStatic = (memory.Base as LocalVariable)?.Type is StaticFieldStorageTypeAnalysisContext;

		try
		{
			FieldAnalysisContext? found = MetadataResolver.SearchFieldAtOffset(owner, memory.Addend, wantStatic);
			return found is null ? "SEARCH_EMPTY" : "SEARCH_ANSWERS:" + found.Name;
		}
		catch (Exception)
		{
			return "SEARCH_THREW";
		}
	}

	/// <summary>
	/// Walks a load's base back to where its type was lost, and names that rather than the symptom.
	/// </summary>
	/// <remarks>
	/// Every other column of the dump describes the load where it was given up on. That is the right
	/// place to count it and the wrong place to explain it: a base typed <c>object</c> three copies
	/// downstream of an unresolved call says nothing about the call, and grouping by what the load
	/// looks like has now four times produced a family that turned out to be several causes. The walk
	/// itself is <see cref="UnresolvedLoadProvenance"/>; what it means to end on a typed base is the
	/// half that needs metadata, so it is passed in.
	/// </remarks>
	private string RootCauseOf(MethodAnalysisContext methodContext, MemoryOperand memory)
	{
		Dictionary<LocalVariable, List<Instruction>> definitions = DefinitionsFor(methodContext);

		long offset = memory.Addend;

		return UnresolvedLoadProvenance.Of(
			memory.Base,
			local => definitions.TryGetValue(local, out List<Instruction>? found) ? found : Array.Empty<Instruction>(),
			local => local.Type is { } type ? ClassifyTypedOrigin(type, offset) : null,
			static local => local.Type is SzArrayTypeAnalysisContext);
	}

	/// <summary>
	/// Where the walk ends on a typed base, what about that type stopped the offset being placed.
	/// </summary>
	private string ClassifyTypedOrigin(TypeAnalysisContext type, long offset)
	{
		switch (type)
		{
			case RuntimeClassTypeAnalysisContext:
			case RuntimeMethodInfoAnalysisContext:
			case StaticFieldStorageTypeAnalysisContext:
				// Correctly typed, and there is no managed field at the offset because the thing being
				// read is the runtime's own struct. Not a typing failure at all.
				return "RUNTIME_STRUCT:" + type.GetType().Name;

			case SzArrayTypeAnalysisContext:
				return "ARRAY_ELEMENT:array-typed-base";

			case ByRefTypeAnalysisContext:
				return "TYPE_PROPAGATION:byref-base";
		}

		// A bare type parameter has no static layout at all: what T is laid out as is decided when the
		// runtime instantiates it. Iteration 040 counted these by walking their fields, found none, and
		// called them missing metadata - 111 of the 165 in that group. Nothing is missing; there is
		// nothing to have.
		if (type is GenericParameterTypeAnalysisContext)
		{
			return "GENERIC_LAYOUT:open-parameter";
		}

		if (type is GenericInstanceTypeAnalysisContext || type.GenericParameters.Count > 0)
		{
			// A generic instantiation's field offsets are not the definition's, and an open definition
			// records every one of its fields at zero.
			return "GENERIC_LAYOUT:" + (type is GenericInstanceTypeAnalysisContext ? "instantiation" : "open-definition");
		}

		// The computed layout, not the recorded offsets. Reading BackingData answers a different
		// question from the one the name suggests: it is null for every field of a generic instance, so
		// a type that merely *inherits* from one reads as having no layout while the layout is right
		// there - which is the defect this iteration fixed, and it was invisible in the old counting.
		IReadOnlyList<(FieldAnalysisContext Field, long Offset)> layout;

		try
		{
			layout = GenericInstanceFieldLayout.LayoutOf(type);
		}
		catch (Exception)
		{
			return "MISSING_METADATA:layout-could-not-be-computed";
		}

		if (layout.Count == 0)
		{
			bool declaresAny = false;

			for (TypeAnalysisContext? candidate = type; candidate is not null && !declaresAny; candidate = candidate.BaseType)
			{
				foreach (FieldAnalysisContext field in candidate.Fields)
				{
					if (!field.IsStatic)
					{
						declaresAny = true;
						break;
					}
				}
			}

			// A type with no instance fields has a complete layout that happens to be empty - reading
			// an offset off System.Object or System.Array is reaching past managed data into the
			// object header, not a metadata gap. A type that declares fields the layout could not place
			// is the gap.
			return declaresAny
				? "MISSING_METADATA:fields-declared-but-not-placed"
				: "NO_KNOWN_LAYOUT:type-has-no-instance-fields";
		}

		long largest = 0;

		foreach ((FieldAnalysisContext _, long fieldOffset) in layout)
		{
			if (fieldOffset > largest)
			{
				largest = fieldOffset;
			}
		}

		if (offset > largest)
		{
			return "PAST_LAST_FIELD:" + (type.IsValueType ? "value-type" : "class");
		}

		// Inside the layout. Whether a field is actually *at* the offset was never checked by the old
		// label, which said "on no field" without looking; it is checked here.
		foreach ((FieldAnalysisContext field, long fieldOffset) in layout)
		{
			if (fieldOffset == offset)
			{
				return "RESOLVABLE:field-at-this-exact-offset";
			}
		}

		return "MISSING_METADATA:inside-the-layout-between-fields";
	}

	[ThreadStatic] private static MethodAnalysisContext? definitionsOwner;
	[ThreadStatic] private static Dictionary<LocalVariable, List<Instruction>>? definitionsCache;

	/// <summary>
	/// Every instruction that defines each local, cached per method as <see cref="SourcesFor"/> is.
	/// </summary>
	/// <remarks>
	/// Every definition, not just the last: a pass that rewrites an instruction can leave a local with
	/// more than one, and a walk that keeps only one of them silently picks a side. Keeping only the
	/// last has already produced a better-looking number and deleted live code once in this project.
	/// </remarks>
	private static Dictionary<LocalVariable, List<Instruction>> DefinitionsFor(MethodAnalysisContext methodContext)
	{
		if (ReferenceEquals(definitionsOwner, methodContext) && definitionsCache is not null)
		{
			return definitionsCache;
		}

		Dictionary<LocalVariable, List<Instruction>> definitions = [];

		if (methodContext.ControlFlowGraph is { } cfg)
		{
			foreach (Block block in cfg.Blocks)
			{
				foreach (Instruction instruction in block.Instructions)
				{
					if (instruction.Destination is LocalVariable destination)
					{
						if (!definitions.TryGetValue(destination, out List<Instruction>? already))
						{
							definitions[destination] = already = [];
						}

						already.Add(instruction);
					}
				}
			}
		}

		definitionsOwner = methodContext;
		definitionsCache = definitions;
		return definitions;
	}

	/// <summary>
	/// What the metadata actually holds about the base type at this offset, as four tab-separated
	/// columns: layout kind, how many fields the computed layout places, the largest offset it
	/// reaches, and what sits at the offset asked for.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Counting fields by <c>BackingData.FieldOffset</c> answers a different question from the one the
	/// name suggests. Every field of a generic definition is recorded at offset 0, so such a type reads
	/// as having no layout - while <see cref="GenericInstanceFieldLayout"/> computes one for it and the
	/// resolver uses that. A bare type parameter genuinely has no static layout. A type with no
	/// instance fields at all - <c>System.Object</c>, <c>System.Array</c>, a pointer - has a complete
	/// layout that happens to be empty, which is not a gap either.
	/// </para>
	/// <para>
	/// Those three are indistinguishable in "fields with a recorded offset = 0", and they want
	/// completely different work, so they are separated here rather than being counted together.
	/// </para>
	/// </remarks>
	private string MetadataStateOf(TypeAnalysisContext? owner, MemoryOperand memory, MethodAnalysisContext methodContext)
	{
		if (owner is null)
		{
			return string.Join('\t', "NO_BASE_TYPE", "0", "0", "-", "NOT_APPLICABLE");
		}

		if (owner is RuntimeClassTypeAnalysisContext or RuntimeMethodInfoAnalysisContext or StaticFieldStorageTypeAnalysisContext)
		{
			return string.Join('\t', "RUNTIME_STRUCT", "0", "0", "-", "NOT_APPLICABLE");
		}

		// A bare type parameter has no layout of its own at all: what T is laid out as is decided when
		// the runtime instantiates it, and nothing static can say.
		if (owner is GenericParameterTypeAnalysisContext)
		{
			return string.Join('\t', "OPEN_TYPE_PARAMETER", "0", "0", "-", "NOT_APPLICABLE");
		}

		TypeAnalysisContext definition = owner is GenericInstanceTypeAnalysisContext instance ? instance.GenericType : owner;
		IReadOnlyList<TypeAnalysisContext>? arguments = (owner as GenericInstanceTypeAnalysisContext)?.GenericArguments;

		IReadOnlyList<(FieldAnalysisContext Field, long Offset)> layout;

		try
		{
			layout = GenericInstanceFieldLayout.LayoutOf(definition, arguments);
		}
		catch (Exception)
		{
			return string.Join('\t', "LAYOUT_THREW", "0", "0", "-", "NOT_APPLICABLE");
		}

		long computedLargest = 0;
		foreach ((FieldAnalysisContext _, long offset) in layout)
		{
			if (offset > computedLargest)
			{
				computedLargest = offset;
			}
		}

		// Declared instance fields, whether or not the layout could place them. The two counts differ
		// exactly when a field could not be sized, which is the layout giving up rather than metadata
		// being absent.
		int declared = 0;
		for (TypeAnalysisContext? candidate = definition; candidate is not null; candidate = candidate.BaseType)
		{
			foreach (FieldAnalysisContext field in candidate.Fields)
			{
				if (!field.IsStatic)
				{
					declared++;
				}
			}
		}

		string state = layout.Count switch
		{
			0 when declared == 0 => "NO_INSTANCE_FIELDS",
			0 => "LAYOUT_INCOMPLETE",
			_ when layout.Count < declared => "LAYOUT_PARTIAL",
			_ => "LAYOUT_KNOWN",
		};

		string at = "-";

		foreach ((FieldAnalysisContext field, long offset) in layout)
		{
			if (offset == memory.Addend)
			{
				at = "EXACT:" + field.Name;
				break;
			}
		}

		if (at == "-" && memory.Addend >= 0 && memory.Addend <= computedLargest)
		{
			// Inside the layout but not on a boundary, so it reaches a member of a value typed field -
			// which is what FindNestedFieldPath answers, and whether it answers is the whole question.
			List<FieldAnalysisContext>? path = MetadataResolver.FindNestedFieldPath(owner, memory.Addend, memory.Size, methodContext);
			at = path is { Count: > 0 } ? "NESTED:" + string.Join(".", path.Select(f => f.Name)) : "INSIDE_NO_FIELD";
		}
		else if (at == "-")
		{
			at = memory.Addend > computedLargest ? "BEYOND_LAYOUT" : "NEGATIVE";
		}

		return string.Join('\t', state, layout.Count.ToString(), computedLargest.ToString("X"), at, CoordinateEvidence(definition, owner, memory.Addend));
	}

	/// <summary>
	/// Which coordinate the offset in the code is measured from, judged by which reading lands on a field.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The offsets in metadata and the offsets in the code are not always in the same frame, and the
	/// frame is a property of <em>how the base pointer was obtained</em>, not of the type. Il2CppDumper
	/// emits the two shapes as C structs and the difference is exactly one header:
	/// <c>struct T_o { T_c *klass; void *monitor; T_Fields fields; }</c>, where the two pointers are
	/// emitted only when the type is not a value type. So a class's metadata offsets already include
	/// the 0x10 header and there is nothing to decide; a value type's do not.
	/// </para>
	/// <para>
	/// A value type still reaches the code both ways. il2cpp hands a value type's own instance method a
	/// receiver that points at the boxed object's header, so a field at metadata offset 0 is read at
	/// <c>[this + 0x10]</c>; the same struct reached as a stack slot or as a field inside another
	/// object is read at its own offset. Both are legitimate and no property of the type separates
	/// them, so this reports which readings land on a field rather than picking one. BOTH means the
	/// evidence does not separate them - which is the offset-zero ambiguity again, and a reason not to
	/// act rather than a reason to guess.
	/// </para>
	/// </remarks>
	private static string CoordinateEvidence(TypeAnalysisContext definition, TypeAnalysisContext owner, long addend)
	{
		if (!owner.IsValueType)
		{
			// A class's recorded offsets are already measured from the object, header included, so
			// there is nothing to decide. Named apart from the value-type answers so the two are never
			// counted together: only the value-type rows carry evidence about the header.
			return "CLASS_OBJECT_RELATIVE";
		}

		long header = 2L * definition.AppContext.Binary.PointerSizeBytes;
		bool valueRelative = false;
		bool objectRelative = false;

		for (TypeAnalysisContext? candidate = definition; candidate is not null; candidate = candidate.BaseType)
		{
			foreach (FieldAnalysisContext field in candidate.Fields)
			{
				if (field.IsStatic || field.BackingData?.FieldOffset is not { } recorded)
				{
					continue;
				}

				if (recorded == addend)
				{
					valueRelative = true;
				}

				if (recorded + header == addend)
				{
					objectRelative = true;
				}
			}
		}

		return (valueRelative, objectRelative) switch
		{
			(true, true) => "BOTH",
			(true, false) => "VALUE_RELATIVE",
			(false, true) => "OBJECT_RELATIVE",
			_ => "NEITHER",
		};
	}

	/// <summary>
	/// Where the base pointer of an unresolved load came from, read off the IR.
	/// </summary>
	/// <remarks>
	/// The classification itself is <see cref="BasePointerOrigin"/>; this is the adapter that gives it
	/// the three things it asks about a local. Only what the IR states outright is reported: a local
	/// flagged as the receiver, a register the stack analyser named after a frame offset, a type that
	/// is static field storage or one of the runtime's own structures, a definition that is a field
	/// read or an element address. Everything else is UNKNOWN, because the point of this column is to
	/// make the frame question answerable by a rule rather than by a guess, and a guessed origin would
	/// put the guess one step earlier.
	/// </remarks>
	private string OriginOf(MethodAnalysisContext methodContext, IOperand? baseOperand)
	{
		if (baseOperand is not LocalVariable local)
		{
			return BasePointerOrigin.Unknown;
		}

		Dictionary<LocalVariable, List<Instruction>> definitions = DefinitionsFor(methodContext);

		return BasePointerOrigin.Of(
			new IrLocal(local),
			candidate => definitions.TryGetValue(((IrLocal)candidate).Local, out List<Instruction>? found)
				? found.ConvertAll(instruction => DescribeOriginDefinition(instruction))
				: Array.Empty<BasePointerOrigin.DefinitionLike>(),
			candidate => DescribeLocal(((IrLocal)candidate).Local),
			(candidate, definition) => definition.Kind == BasePointerOrigin.DefinitionKind.Other
				&& IsReturnBuffer(((IrLocal)candidate).Local, methodContext),
			candidate => methodContext.ParameterOperands.Contains(((IrLocal)candidate).Local.Register)
				? BasePointerOrigin.Parameter
				: null);
	}

	/// <summary>
	/// Whether <paramref name="candidate"/> is the pointer side of an <c>Add</c>, and what it points into.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The walk had a rule for <c>Add pointer, constant</c> and nothing else, so every other shape
	/// read as "no idea" - 343 loads on the test game, which classifying rather than counting split
	/// into eleven shapes, most with an exact answer. The answers are not new: an operand that names
	/// storage in a <c>Move</c> names the same storage here, and this simply asks the same question of
	/// a second opcode.
	/// </para>
	/// <para>
	/// Between two registers the evidence is the type. Adding an integer to a pointer yields a pointer
	/// and two pointers are never added, so the side typed as an array, a pointer or a reference is
	/// the base - but only when it is typed. An untyped side beside an integer is *probably* the base
	/// and is left unclassified, because "probably" is what this classification exists not to report.
	/// </para>
	/// </remarks>
	private BasePointerOrigin.DefinitionLike? AddendOrigin(IOperand candidate, IOperand other) => candidate switch
	{
		FieldReference => new(BasePointerOrigin.DefinitionKind.FieldRead, null),
		AddressOf { Target: ArrayAccess } or ArrayAccess => new(BasePointerOrigin.DefinitionKind.ArrayElementAddress, null),
		AddressOf { Target: LocalVariable addressed } => new(BasePointerOrigin.DefinitionKind.CopyOfLocal, new IrLocal(addressed)),
		MemoryOperand => new(BasePointerOrigin.DefinitionKind.LoadFromMemory, null),
		LocalVariable based when other is Immediate => new(BasePointerOrigin.DefinitionKind.OffsetFromLocal, new IrLocal(based)),
		LocalVariable based when DescribeAddend(based) is "array" or "pointer" or "reference"
			&& other is LocalVariable => new(BasePointerOrigin.DefinitionKind.OffsetFromLocal, new IrLocal(based)),
		_ => null,
	};

	/// <summary>
	/// What one side of an <c>Add</c> of two locals is, for the purpose of deciding which is the base.
	/// </summary>
	/// <remarks>
	/// Adding an integer to a pointer yields a pointer and adding two pointers is not a thing, so the
	/// side that is not an integer is the base - but only where the types say so. This reports the two
	/// sides rather than deciding, because whether they discriminate is a question to measure before
	/// it is a rule to apply.
	/// </remarks>
	private static string DescribeAddend(IOperand operand) => operand is not LocalVariable local
		? operand.GetType().Name
		: local.Type switch
	{
		null => "untyped",
		{ IsValueType: true } type when type.FullName is "System.Int32" or "System.Int64" or "System.UInt32"
			or "System.UInt64" or "System.IntPtr" or "System.UIntPtr" or "System.Int16" or "System.UInt16"
			or "System.Byte" or "System.SByte" => "integer",
		SzArrayTypeAnalysisContext => "array",
		PointerTypeAnalysisContext or ByRefTypeAnalysisContext => "pointer",
		{ IsValueType: true } => "value",
		_ => "reference",
	};

	private sealed record IrLocal(LocalVariable Local) : BasePointerOrigin.LocalLike;

	/// <summary>What a local says about itself, before anything looks at what defined it.</summary>
	private static string? DescribeLocal(LocalVariable local)
	{
		if (local.IsThis)
		{
			return BasePointerOrigin.This;
		}

		// StackAnalyzer names every frame slot after its own offset, so the name is the evidence.
		if (local.Register.Name is { } name && name.StartsWith("stack_", StringComparison.Ordinal))
		{
			return BasePointerOrigin.StackSlot;
		}

		return local.Type switch
		{
			StaticFieldStorageTypeAnalysisContext => BasePointerOrigin.StaticField,
			RuntimeClassTypeAnalysisContext or RuntimeMethodInfoAnalysisContext => BasePointerOrigin.RuntimeStructure,
			_ => null,
		};
	}

	private BasePointerOrigin.DefinitionLike DescribeOriginDefinition(Instruction instruction)
	{
		OperandList operands = instruction.Operands;

		switch (instruction.OpCode)
		{
			case Cpp2IL.Core.ISIL.OpCode.Move when operands.Count > 1:
				return operands[1] switch
				{
					LocalVariable copied => new(BasePointerOrigin.DefinitionKind.CopyOfLocal, new IrLocal(copied)),
					FieldReference => new(BasePointerOrigin.DefinitionKind.FieldRead, null),
					// The address of an element, which ArrayRecovery folds into this shape.
					AddressOf { Target: ArrayAccess } => new(BasePointerOrigin.DefinitionKind.ArrayElementAddress, null),
					// The address of a local points into that local's storage, so the walk continues
					// there. Exact rather than inferred: taking an address does not change what is
					// being addressed, which is the same reasoning OffsetFromLocal already rests on.
					AddressOf { Target: LocalVariable addressed } => new(BasePointerOrigin.DefinitionKind.CopyOfLocal, new IrLocal(addressed)),
					AddressOf { Target: FieldReference } => new(BasePointerOrigin.DefinitionKind.FieldRead, null),
					MemoryOperand => new(BasePointerOrigin.DefinitionKind.LoadFromMemory, null),
					_ => new(BasePointerOrigin.DefinitionKind.Other, null, "Move:" + operands[1].GetType().Name),
				};

			// Adding to a pointer leaves it pointing into the same storage, so the pointer side is
			// followed. Which side that is comes from the same evidence a Move already uses - an
			// operand that names storage names it here too - and, between two registers, from the
			// types: an integer added to a pointer is a pointer, and two pointers are never added.
			case Cpp2IL.Core.ISIL.OpCode.Add when operands.Count > 2:
				return AddendOrigin(operands[1], operands[2])
					?? AddendOrigin(operands[2], operands[1])
					?? new(BasePointerOrigin.DefinitionKind.Other, null,
						"Add:" + DescribeAddend(operands[1]) + "+" + DescribeAddend(operands[2]));

			case Cpp2IL.Core.ISIL.OpCode.Call:
			case Cpp2IL.Core.ISIL.OpCode.IndirectCall:
				return new(BasePointerOrigin.DefinitionKind.CallResult, null);

			case Cpp2IL.Core.ISIL.OpCode.Newobj:
			case Cpp2IL.Core.ISIL.OpCode.NewArr:
				return new(BasePointerOrigin.DefinitionKind.Allocation, null);

			default:
				return new(BasePointerOrigin.DefinitionKind.Other, null, instruction.OpCode.ToString());
		}
	}

	/// <summary>
	/// Whether a call writes its return value through this local, which is what makes it the buffer
	/// the caller allocated rather than an ordinary result.
	/// </summary>
	/// <remarks>
	/// Which register carries the buffer comes from the callee's own calling convention, never a name
	/// written down - the same source <see cref="Cpp2IL.Core.Analysis.IndirectReturnBufferRecovery"/>
	/// reads it from, so the two agree by construction.
	/// </remarks>
	private bool IsReturnBuffer(LocalVariable local, MethodAnalysisContext methodContext)
	{
		if (appContext?.InstructionSet.CallingConventionResolver is not { } conventions
			|| methodContext.ControlFlowGraph is not { } graph)
		{
			return false;
		}

		foreach (Instruction instruction in graph.Instructions)
		{
			if (!instruction.IsCall || instruction.Operands.Count == 0
				|| instruction.Operands[0] is not MethodAnalysisContext callee
				|| conventions.HiddenReturnBufferRegister(callee) is not { } buffer)
			{
				continue;
			}

			foreach (IOperand operand in instruction.Operands)
			{
				if (operand is LocalVariable argument
					&& ReferenceEquals(argument, local)
					&& argument.Register.Number == buffer.Number)
				{
					return true;
				}
			}
		}

		return false;
	}

	private static readonly string? unresolvedLoadCaseFile = Environment.GetEnvironmentVariable("CPP2IL_DUMP_LOADS");
	private static readonly object unresolvedLoadCaseLock = new();
	private static StreamWriter? unresolvedLoadCaseWriter;

	private static readonly string? unresolvedCallFile = Environment.GetEnvironmentVariable("CPP2IL_DUMP_CALLS");
	private static readonly object unresolvedCallLock = new();
	private static StreamWriter? unresolvedCallWriter;

	/// <summary>
	/// Appends one line per call that became a placeholder, when <c>CPP2IL_DUMP_CALLS</c> names a file.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>Method not found</c> is the largest single placeholder kind in the export and had never been
	/// classified. The count is one number covering at least three causes that want opposite work, and
	/// the thing that separates them is how many managed methods sit on the address.
	/// </para>
	/// <para>
	/// <b>None</b> means it is not a managed call: a runtime helper, a PLT stub, or a veneer whose one
	/// jump nothing followed - so the work is recognition, in key-function recovery or the thunk hop.
	/// <b>One</b> should already have resolved, since the generator looks the address up itself, so it
	/// means the lookup ran before the address was final. <b>Several</b> is the opposite of "not
	/// found": the model knows the method perfectly well and generic sharing put every instantiation
	/// on one address, so the failure is choosing - and the receiver's own type is the evidence that
	/// would choose, exactly as <c>RetargetSharedGenericCalls</c> already does for resolved calls.
	/// </para>
	/// </remarks>
	private void RecordUnresolvedCall(MethodAnalysisContext methodContext, ulong address, int candidates)
	{
		string kind = candidates switch
		{
			< 0 => "NOT_AN_ADDRESS",
			0 => "NO_MANAGED_METHOD",
			1 => "ONE_CANDIDATE_UNRESOLVED",
			_ => "SHARED_" + (candidates < 10 ? candidates.ToString() : candidates < 100 ? "10s" : "100s"),
		};

		unresolvedCallKinds.AddOrUpdate(kind, 1, static (_, count) => count + 1);

		// AssetRipper: `METHOD_NOT_FOUND` is a symptom, and a symptom says nothing about whether the
		// call is recoverable. The reason does, and every reason below is read off evidence already in
		// hand at this point rather than guessed: how many managed methods sit on the address, and what
		// the first four instructions there are.
		string shape = NativeShapeAt(address);
		string reason = candidates switch
		{
			< 0 => "INDIRECT_TARGET",
			>= 2 => "GENERIC_SHARED",
			_ => shape switch
			{
				// A PLT entry jumps through the GOT into another shared library. No amount of managed
				// metadata will ever name it, so this is an external dependency and not a defect.
				"PLT_STUB" => "NATIVE_ONLY",
				// A single branch between the runtime and the generated code. Every call to a runtime
				// helper goes through one, so this is a helper key-function recovery did not recognise.
				"VENEER_B" => "RUNTIME_HELPER_VENEER",
				"FUNCTION_PROLOGUE" => "RUNTIME_HELPER",
				"UNMAPPED" => "REGISTRATION_MISSING",
				"UNREADABLE" => "ANALYSIS_FAILURE",
				_ => "UNKNOWN",
			},
		};

		unresolvedCallReasons.AddOrUpdate(reason, 1, static (_, count) => count + 1);

		if (unresolvedCallFile is null)
		{
			return;
		}

		// A veneer is a single jump between the runtime and the generated code, and every call to a
		// helper goes through one. Whether this address is one is the difference between "nothing is
		// there" and "nothing followed the jump", so it is asked rather than assumed.
		ulong behindThunk = 0;
		int behindThunkCandidates = 0;
		if (candidates == 0 && appContext is not null && address != 0)
		{
			try
			{
				behindThunk = appContext.InstructionSet.GetThunkTarget(appContext, address);
				if (behindThunk != 0 && appContext.MethodsByAddress.TryGetValue(behindThunk, out var behind))
				{
					behindThunkCandidates = behind.Count;
				}
			}
			catch (Exception)
			{
				behindThunk = 0;
			}
		}

		// The binary's own export table is ground truth for what a helper is called. Most are not
		// exported - il2cpp's internal helpers have no symbol - but the ones that are need no guess.
		string exported = "-";
		string exportedBehind = "-";
		if (appContext is not null)
		{
			try
			{
				if (address != 0 && appContext.Binary.TryGetExportedFunctionName(address, out string? named))
				{
					exported = named;
				}

				if (behindThunk != 0 && appContext.Binary.TryGetExportedFunctionName(behindThunk, out string? behindNamed))
				{
					exportedBehind = behindNamed;
				}
			}
			catch (Exception)
			{
				exported = "<threw>";
			}
		}

		string row = string.Join('\t',
			kind,
			methodContext.DeclaringType?.DeclaringAssembly?.Name ?? "",
			methodContext.DeclaringType?.FullName ?? "",
			methodContext.Name,
			address.ToString("X"),
			candidates.ToString(),
			behindThunk.ToString("X"),
			behindThunkCandidates.ToString(),
			exported,
			exportedBehind,
			shape,
			reason);

		lock (unresolvedCallLock)
		{
			unresolvedCallWriter ??= new StreamWriter(unresolvedCallFile, append: false);
			unresolvedCallWriter.WriteLine(row);
		}
	}

	/// <summary>
	/// What the first few instructions at a call target look like, which is what the target <em>is</em>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// "No managed method at this address" is one label for at least three things, and the native code
	/// separates them exactly. A PLT stub - <c>adrp x16 / ldr x17,[x16] / add x16 / br x17</c> - jumps
	/// through the GOT to a function <em>imported from another shared library</em>, so no amount of
	/// managed metadata will ever name it. A single <c>b</c> is a veneer, and what matters is what it
	/// jumps to. Anything else is a real function in this binary with a prologue, so it is an internal
	/// runtime helper that key-function recovery did not recognise.
	/// </para>
	/// <para>
	/// Only the encodings that are unambiguous are decoded, and anything else is reported as a
	/// prologue rather than guessed at. ARM64 only: on another architecture the shapes differ and the
	/// answer is that this was not asked.
	/// </para>
	/// </remarks>
	private string NativeShapeAt(ulong address)
	{
		if (appContext is null || address == 0 || appContext.Binary.is32Bit)
		{
			return "-";
		}

		uint[] words = new uint[4];

		try
		{
			long offset = appContext.Binary.MapVirtualAddressToRaw(address);
			if (offset <= 0)
			{
				return "UNMAPPED";
			}

			ReadOnlySpan<byte> content = appContext.Binary.GetRawBinaryContent();
			for (int index = 0; index < words.Length; index++)
			{
				words[index] = BitConverter.ToUInt32(content.Slice((int)offset + index * 4, 4));
			}
		}
		catch (Exception)
		{
			return "UNREADABLE";
		}

		// The AArch64 PLT entry, and the only four-instruction shape that ends in `br`.
		if ((words[0] & 0x9F00001F) == 0x90000010            // adrp x16, page
			&& (words[1] & 0xFFC003FF) == 0xF9400211         // ldr  x17, [x16, #imm]
			&& (words[2] & 0xFFC003FF) == 0x91000210         // add  x16, x16, #imm
			&& words[3] == 0xD61F0220)                       // br   x17
		{
			return "PLT_STUB";
		}

		if ((words[0] >> 26) == 0b000101)
		{
			return "VENEER_B";
		}

		return "FUNCTION_PROLOGUE";
	}

	private readonly ConcurrentDictionary<string, int> unresolvedCallKinds = new();

	private readonly ConcurrentDictionary<string, int> unresolvedCallReasons = new();

	private static readonly string? resolvedLoadCaseFile = Environment.GetEnvironmentVariable("CPP2IL_DUMP_RESOLVED_LOADS");
	private static readonly object resolvedLoadCaseLock = new();
	private static StreamWriter? resolvedLoadCaseWriter;

	/// <summary>
	/// Appends one line per load that <em>was</em> resolved to a field, when
	/// <c>CPP2IL_DUMP_RESOLVED_LOADS</c> names a file.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Iteration 044 found that base-pointer origin and coordinate frame cross-tabulate with no
	/// exceptions - static field storage reads value-relative, a receiver or a parameter reads
	/// object-relative - and declined to act on it, because the only population it could see was the
	/// loads that had been <em>given up on</em>. A rule inferred from the failures alone is inferred
	/// from a biased sample: it says nothing about whether the same shape is already handled correctly
	/// everywhere else, which is precisely what would make patching the resolver a regression.
	/// </para>
	/// <para>
	/// This is the other half of the sample. It is raised from the generator's <c>FieldReference</c>
	/// case, the exact mirror of the one place a memory operand is given up on, so the two files are
	/// the same measurement over the same pipeline stage and the cross-tab can be read across both.
	/// A pattern that appears in the resolved population and is absent from the unresolved one is a
	/// candidate missing resolver rule; a pattern that appears in both is not.
	/// </para>
	/// </remarks>
	private void RecordResolvedLoadCase(MethodAnalysisContext methodContext, FieldReference reference)
	{
		if (resolvedLoadCaseFile is null || appContext is null)
		{
			return;
		}

		TypeAnalysisContext? baseType = reference.Local.Type;
		TypeAnalysisContext? owner = (baseType as StaticFieldStorageTypeAnalysisContext)?.OwnerType ?? baseType;

		string frame = owner is null
			? "UNKNOWN"
			: CoordinateEvidence(owner, owner, reference.Offset);

		string row = string.Join('\t',
			"RESOLVED",
			methodContext.DeclaringType?.DeclaringAssembly?.Name ?? "",
			methodContext.DeclaringType?.FullName ?? "",
			methodContext.Name,
			owner?.FullName ?? "<untyped>",
			owner?.GetType().Name ?? "",
			reference.Offset.ToString("X"),
			reference.AccessSize.ToString(),
			OriginOf(methodContext, reference.Local),
			frame,
			reference.Field.DeclaringType?.FullName ?? "",
			reference.Field.Name,
			reference.Field.FieldType.FullName ?? "",
			reference.Field.IsStatic ? "STATIC" : "INSTANCE",
			reference.ElementIndex is null ? "-" : "ELEMENT",
			reference.ContainingFields.Count == 0 ? "DIRECT" : "NESTED");

		lock (resolvedLoadCaseLock)
		{
			resolvedLoadCaseWriter ??= new StreamWriter(resolvedLoadCaseFile, append: false);
			resolvedLoadCaseWriter.WriteLine(row);
		}
	}

	/// <summary>
	/// Counts an untyped local by what defines it, which is where a missing propagation rule shows.
	/// </summary>
	/// <remarks>
	/// A local the analysis could not type is declared <c>object</c>, and every use of it becomes a cast
	/// C# does not have - 78% of the errors the exported scripts still produce. The count on its own
	/// says nothing about what to do; grouped by the opcode that writes the local, and by whether that
	/// instruction's own operands were typed, it says which rule is missing and what it is worth.
	/// </remarks>
	private void ClassifyUntypedLocal(MethodAnalysisContext methodContext, LocalVariable local)
	{
		string kind = "written by nothing";
		string example = local.Name ?? "";
		int reads = 0;
		string? firstRead = null;

		if (methodContext.ControlFlowGraph is { } cfg)
		{
			bool found = false;

			foreach (Instruction instruction in cfg.Instructions)
			{
				if (!found && instruction.Operands.Count > 0 && ReferenceEquals(instruction.Destination, local))
				{
					kind = DescribeDefinition(instruction);
					example = instruction.ToString() ?? example;
					found = true;
				}

				foreach (IOperand source in instruction.Sources)
				{
					if (!ReferenceEquals(source, local))
					{
						continue;
					}

					reads++;

					if (firstRead is null)
					{
						firstRead = instruction.OpCode == OpCode.Call && instruction.Operands[0] is not MethodAnalysisContext
							? "an unresolved call"
							: instruction.OpCode == OpCode.Call && instruction.Operands[0] is MethodAnalysisContext resolved
								? $"a call to {(resolved.IsStatic ? "a static" : "an instance")} method"
								: instruction.OpCode.ToString();
					}
				}
			}
		}

		// A local nothing reads costs an unused declaration and nothing else; one that is read is where
		// a cast comes from. Weighting by that is the difference between a list to work down and a list
		// of things that are already harmless.
		kind = reads == 0 ? $"{kind} [never read]" : $"{kind}, first read by {firstRead}";

		untypedLocalKinds.AddOrUpdate(kind, 1, static (_, count) => count + 1);

		if (!untypedLocalExamples.ContainsKey(kind))
		{
			untypedLocalExamples.TryAdd(kind, $"{methodContext.DeclaringType?.Name}.{methodContext.Name}: {example}");
		}
	}

	/// <summary>What defines the local, and how much of what defines it was itself typed.</summary>
	private static string DescribeDefinition(Instruction instruction)
	{
		string opcode = instruction.OpCode.ToString();

		if (instruction.OpCode == OpCode.Call)
		{
			return instruction.Operands[0] is MethodAnalysisContext callee
				? $"{opcode} - the return of a resolved method ({(callee.ReturnType is null ? "no return type" : "typed")})"
				: $"{opcode} - the return of a call whose target is unknown";
		}

		if (instruction.OpCode == OpCode.Move && instruction.Operands.Count > 1)
		{
			return instruction.Operands[1] switch
			{
				MemoryOperand => $"{opcode} from memory",
				FieldReference => $"{opcode} from a field",
				LocalVariable { Type: null } => $"{opcode} from another untyped local",
				LocalVariable => $"{opcode} from a typed local",
				Immediate or StackOffset => $"{opcode} of a constant",
				_ => $"{opcode} of {instruction.Operands[1].GetType().Name}",
			};
		}

		if (instruction.OpCode == OpCode.Phi)
		{
			int untyped = instruction.Operands.Skip(1).Count(o => o is LocalVariable { Type: null });
			return $"{opcode} - a merge of {instruction.Operands.Count - 1} versions, {untyped} of them untyped";
		}

		return opcode;
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
		// AssetRipper: name the slot, not just its kind. A stack slot's register name carries its own
		// frame offset (StackAnalyzer.NameForSlot), so "AddressOf(stack_-88)" is what says whether a
		// load through this address has an arithmetically determined destination - which is the whole
		// of DECOMP-0022 group B. Without the name every such load reads as one undifferentiated family.
		AddressOf { Target: LocalVariable { Register.Name: { } slot } } addressed when slot.StartsWith("stack_")
			=> $"AddressOf({slot}{(addressed.Target is LocalVariable { Type: { } slotType } ? ", " + slotType.Name : "")})",
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
		ReportUntypedLocals();
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

		void ReportUntypedLocals()
		{
			if (untypedLocalKinds.IsEmpty)
			{
				return;
			}

			int total = untypedLocalKinds.Values.Sum();

			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {total} locals the analysis could not type, by what defines them:");

			foreach ((string kind, int count) in untypedLocalKinds.OrderByDescending(pair => pair.Value))
			{
				string example = untypedLocalExamples.TryGetValue(kind, out string? found) ? found : "";
				Logger.Info(LogCategory.Import, $"      {count,7} {kind}   e.g. {example}");
			}
		}

		void ReportUnresolvedLoads()
		{
			lock (unresolvedLoadCaseLock)
			{
				unresolvedLoadCaseWriter?.Flush();
			}

			lock (resolvedLoadCaseLock)
			{
				resolvedLoadCaseWriter?.Flush();
			}

			lock (unresolvedCallLock)
			{
				unresolvedCallWriter?.Flush();
			}

			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {IlGenerator.NativeImportOperationsRecovered} calls to a C library "
				+ "function were emitted as the C# operation equivalent to it.");

			Logger.Info(LogCategory.Import,
				$"Il2Cpp method body recovery: {Cpp2IL.Core.Analysis.InterfaceInvokeDataRecovery.Recovered} interface dispatches "
				+ "compiled as a runtime lookup were resolved to the interface method the slot names.");

			if (!unresolvedCallKinds.IsEmpty)
			{
				Logger.Info(LogCategory.Import,
					$"Il2Cpp method body recovery: {unresolvedCallKinds.Values.Sum()} calls became a placeholder, by how many "
					+ "managed methods sit on the address:");

				foreach ((string kind, int count) in unresolvedCallKinds.OrderByDescending(pair => pair.Value))
				{
					Logger.Info(LogCategory.Import, $"      {count,7} {kind}");
				}

				Logger.Info(LogCategory.Import,
					"Il2Cpp method body recovery: the same calls, by what would have to change to resolve them:");

				foreach ((string reason, int count) in unresolvedCallReasons.OrderByDescending(pair => pair.Value))
				{
					Logger.Info(LogCategory.Import, $"      {count,7} {reason}");
				}
			}

			var jumpKinds = Cpp2IL.Core.Analysis.IndirectJumpClassifier.Counts;

			if (jumpKinds.Count > 0)
			{
				Logger.Info(LogCategory.Import,
					$"Il2Cpp method body recovery: {jumpKinds.Sum(pair => pair.Value)} indirect jumps survived across "
					+ $"{Cpp2IL.Core.Analysis.IndirectJumpClassifier.MethodsSeen} analysed method bodies, "
					+ "by what the target register holds:");

				foreach ((string kind, int count) in jumpKinds)
				{
					Logger.Info(LogCategory.Import, $"      {count,7} {kind}");
				}
			}

			var callKinds = Cpp2IL.Core.Analysis.IndirectJumpClassifier.CallCounts;

			if (callKinds.Count > 0)
			{
				Logger.Info(LogCategory.Import,
					$"Il2Cpp method body recovery: {callKinds.Sum(pair => pair.Value)} indirect calls survived, by what the "
					+ "target holds - and for a vtable slot, by what the virtual resolver would have said:");

				foreach ((string kind, int count) in callKinds)
				{
					Logger.Info(LogCategory.Import, $"      {count,7} {kind}");
				}
			}

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
