using AssetRipper.Il2CppRestore.Binary;
using AssetRipper.Il2CppRestore.Lift.Registration;

namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// Turns disassembled ARM64 into <see cref="Statement"/>s by abstract interpretation: every register
/// holds a <see cref="SymValue"/> instead of a raw number, so by the time a <c>BL</c> or <c>RET</c> is
/// reached, its operands are already known to be "this", "a string literal", "field X of the this
/// pointer", etc. — guide §11.2.
/// </summary>
/// <remarks>
/// Realistic goal, stated up front in the guide and worth repeating here: this produces code a person
/// can read, not code that recompiles. Patterns this switch does not recognize fall back to
/// <see cref="SymValue.Unknown"/> rather than a guess.
/// </remarks>
public sealed class Arm64Lifter : IArchLifter
{
	public Architecture Arch => Architecture.Arm64;

	/// <summary>
	/// A function longer than this is not lifted — cut by instruction count rather than raw byte size
	/// (guide §11.5), with an actionable message instead of a bare "too big".
	/// </summary>
	public const int MaxInstructions = 4000;

	public IReadOnlyList<DecodedInstruction> Disassemble(ReadOnlyMemory<byte> code, ulong baseVa) =>
		Arm64Disassembler.Decode(code, baseVa);

	public List<Statement> Lift(IReadOnlyList<DecodedInstruction> instructions, LiftContext ctx)
	{
		if (instructions.Count > MaxInstructions)
		{
			return
			[
				new Statement.Comment($"[{instructions.Count} instructions, over the {MaxInstructions} limit] — this body was not lifted."),
				new Statement.Comment($"Re-run with a higher instruction limit ({instructions.Count + 1000}+) if this method matters."),
			];
		}

		SymValue[] regs = new SymValue[32];
		Array.Fill(regs, new SymValue.Unknown());

		// AAPCS64: x0..x7 carry the first 8 arguments; an instance method's x0 is `this`.
		int reg = 0;
		if (!ctx.Current.IsStatic)
		{
			regs[reg++] = new SymValue.This();
		}
		for (int i = 0; i < ctx.Current.Parameters.Count && reg < 8; i++, reg++)
		{
			regs[reg] = new SymValue.Arg(i, ctx.Current.Parameters[i].Type);
		}

		List<Statement> statements = [];
		HashSet<ulong> labels = CollectBranchTargets(instructions);

		foreach (DecodedInstruction ins in instructions)
		{
			if (labels.Contains(ins.Address))
			{
				statements.Add(new Statement.Label(ins.Address));
			}

			switch (ins.Mnemonic)
			{
				case "MOV":
					regs[ins.Rd] = new SymValue.Const(ins.Immediate);
					break;

				// ADRP + ADD/LDR is ARM64's standard "load the address of a global" pattern: ADRP loads
				// the 4KB page, and the ADD/LDR that follows adds the low bits of the real address.
				case "ADRP":
					regs[ins.Rd] = new SymValue.Const((long)ins.PageAddress);
					break;

				case "ADD" when regs[ins.Rn] is SymValue.Const baseConst:
					regs[ins.Rd] = new SymValue.Const(baseConst.Value + ins.Immediate);
					break;

				case "LDR" when regs[ins.Rn] is SymValue.Const baseAddr:
					regs[ins.Rd] = LiftLoadFromConstantAddress((ulong)(baseAddr.Value + ins.Immediate), ctx);
					break;

				case "LDR" when TryGetObjectType(regs[ins.Rn], out string? objType):
					regs[ins.Rd] = LiftFieldLoad(regs[ins.Rn], objType!, ins.Immediate, ctx);
					break;

				case "LDR":
					regs[ins.Rd] = new SymValue.Unknown();
					break;

				case "BL":
				{
					string name = ResolveCallee(ins.BranchTarget, ctx);
					IReadOnlyList<SymValue> args = CollectArgs(regs, ctx, ins.BranchTarget);
					string returnType = ReturnTypeOf(ins.BranchTarget, ctx);
					bool isVoid = returnType is "void" or "Void";
					string? tempName = isVoid ? null : ctx.NextTempName();

					statements.Add(new Statement.Call(name, args, tempName, returnType));
					regs[0] = tempName is null ? new SymValue.Unknown() : new SymValue.CallResult(name, returnType, tempName);
					InvalidateCallerSavedRegisters(regs);
					break;
				}

				case "RET":
					statements.Add(new Statement.Return(ctx.Current.ReturnType is "void" or "Void" ? null : regs[0]));
					break;

				case "CBZ" or "CBNZ" or "TBZ" or "TBNZ":
					// The compared register for these is the SECOND (or third, for TBZ/TBNZ) operand,
					// not the first like B/BL — a classic spot to lose every comparison-to-zero branch's
					// label if copied from a plain-branch pattern without checking (guide §11.3).
					statements.Add(new Statement.Branch(ins.Mnemonic, regs[ins.Rn], ins.BranchTarget));
					break;

				case "B":
					statements.Add(new Statement.Goto(ins.BranchTarget));
					break;
			}
		}

		return statements;
	}

	private static SymValue LiftLoadFromConstantAddress(ulong address, LiftContext ctx)
	{
		if (ctx.Usages.TryGetValue(address, out Usage usage))
		{
			return usage.Kind switch
			{
				UsageKind.StringLiteral => new SymValue.StrLit(ctx.Metadata.GetStringLiteral(usage.Index)),
				UsageKind.TypeInfo => new SymValue.TypeRef(ctx.Metadata.GetTypeName(usage.Index)),
				UsageKind.MethodDef => new SymValue.TypeRef(ctx.Metadata.GetMethodName(usage.Index)),
				_ => new SymValue.Unknown(),
			};
		}
		return new SymValue.Unknown();
	}

	private static SymValue LiftFieldLoad(SymValue obj, string objType, long offset, LiftContext ctx)
	{
		if (ctx.Structs?.TryResolveField(objType, offset, out string? nativePath) == true)
		{
			return new SymValue.FieldOf(obj, nativePath!, "var");
		}

		int typeDefIndex = FindTypeDefIndexByName(ctx, objType);
		if (typeDefIndex >= 0 && ctx.Metadata.TryResolveManagedField(typeDefIndex, (int)offset, out Il2CppMetadata.ManagedFieldGuess managed))
		{
			return new SymValue.FieldOf(obj, managed.Name, managed.Type);
		}

		return new SymValue.Unknown();
	}

	private static int FindTypeDefIndexByName(LiftContext ctx, string typeName)
	{
		for (int i = 0; i < ctx.Metadata.TypeDefs.Length; i++)
		{
			if (ctx.Metadata.GetTypeDefName(i) == typeName)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// The type name a symbolic value would have as a managed/native object, when it has one — the
	/// gate that decides whether an <c>LDR</c> is plausibly a field access at all.
	/// </summary>
	private static bool TryGetObjectType(SymValue value, out string? typeName)
	{
		typeName = value switch
		{
			SymValue.This => "this",
			SymValue.Arg a => a.Type,
			SymValue.Local l => l.Type,
			SymValue.FieldOf f => f.Type,
			SymValue.CallResult r => r.RetType,
			_ => null,
		};
		return typeName is not null;
	}

	/// <summary>
	/// A branch cannot be labeled until the whole function has been scanned once — a backward jump's
	/// target is only known after it, and a forward one is only known before it is reached. TBZ/TBNZ/
	/// CBZ/CBNZ are included explicitly because their target lives in a different operand slot than a
	/// plain B/BL, and it is easy to only handle the common case and quietly drop these (guide §11.3).
	/// </summary>
	private static HashSet<ulong> CollectBranchTargets(IReadOnlyList<DecodedInstruction> instructions)
	{
		HashSet<ulong> targets = [];
		foreach (DecodedInstruction ins in instructions)
		{
			if (ins.IsBranch && !ins.IsCall && ins.BranchTarget != 0)
			{
				targets.Add(ins.BranchTarget);
			}
		}
		return targets;
	}

	/// <summary>
	/// Three tiers, tried in order of how certain they are. Runtime helpers
	/// (<c>il2cpp_codegen_object_new</c> and friends) have no metadata entry and usually no symbol
	/// either, so <see cref="LearnHelpers"/> has to fill that gap — a heuristic tied to one specific
	/// caller pattern breaks the moment Unity's codegen changes it (guide §11.4).
	/// </summary>
	private static string ResolveCallee(ulong target, LiftContext ctx)
	{
		if (ctx.MethodsByVa.TryGetValue(target, out MethodRef? method))
		{
			return method.FullName;
		}
		if (ctx.Image.SymbolsByVa.TryGetValue(target, out string? symbol))
		{
			return symbol;
		}
		if (ctx.KnownHelpers.TryGetValue(target, out string? known))
		{
			return known;
		}
		return $"sub_{target:X}";
	}

	private static IReadOnlyList<SymValue> CollectArgs(SymValue[] regs, LiftContext ctx, ulong target)
	{
		int count = ctx.MethodsByVa.TryGetValue(target, out MethodRef? method)
			? method.Parameters.Count + (method.IsStatic ? 0 : 1)
			: 1; // an unknown callee: show at least x0, since almost everything worth showing carries `this` or its first real argument there.

		List<SymValue> args = new(Math.Min(count, 8));
		for (int i = 0; i < count && i < 8; i++)
		{
			args.Add(regs[i]);
		}
		return args;
	}

	private static string ReturnTypeOf(ulong target, LiftContext ctx) =>
		ctx.MethodsByVa.TryGetValue(target, out MethodRef? method) ? method.ReturnType : "object";

	/// <summary>x0..x17 are caller-saved under AAPCS64: a call can freely clobber them, so anything the lifter thought it knew about them stops being trustworthy afterward.</summary>
	private static void InvalidateCallerSavedRegisters(SymValue[] regs)
	{
		for (int i = 1; i <= 17 && i < regs.Length; i++)
		{
			regs[i] = new SymValue.Unknown();
		}
	}

	/// <summary>
	/// Learns runtime helper addresses by exploiting methods whose content is already known for certain
	/// — every constructor call is necessarily preceded by <c>il2cpp_codegen_object_new</c> when the
	/// object being constructed was freshly allocated, so a target seen immediately before hundreds of
	/// distinct, already-identified <c>.ctor</c> calls is that helper with very high confidence. A vote
	/// count threshold (not a single match) is what keeps this from mistaking one coincidence for a rule
	/// (guide §11.4) — this has to run once, over the whole binary, before lifting individual methods.
	/// </summary>
	public void LearnHelpers(LiftContext ctx, IEnumerable<(MethodRef Method, IReadOnlyList<DecodedInstruction> Instructions)> allMethods)
	{
		Dictionary<ulong, Dictionary<string, int>> votes = [];

		foreach ((MethodRef _, IReadOnlyList<DecodedInstruction> instructions) in allMethods)
		{
			for (int i = 0; i + 1 < instructions.Count; i++)
			{
				if (instructions[i].Mnemonic != "BL" || instructions[i + 1].Mnemonic != "BL")
				{
					continue;
				}
				if (!ctx.MethodsByVa.TryGetValue(instructions[i + 1].BranchTarget, out MethodRef? next) || !next.FullName.EndsWith(".ctor", StringComparison.Ordinal))
				{
					continue;
				}
				if (ctx.MethodsByVa.ContainsKey(instructions[i].BranchTarget))
				{
					continue; // Already a known method, not an unnamed helper.
				}

				Vote(votes, instructions[i].BranchTarget, "il2cpp_codegen_object_new");
			}
		}

		foreach ((ulong va, Dictionary<string, int> tally) in votes)
		{
			(string name, int count) = tally.MaxBy(kv => kv.Value);
			if (count >= 10)
			{
				ctx.KnownHelpers[va] = name;
			}
		}
	}

	private static void Vote(Dictionary<ulong, Dictionary<string, int>> votes, ulong va, string name)
	{
		Dictionary<string, int> tally = votes.TryGetValue(va, out Dictionary<string, int>? existing) ? existing : votes[va] = [];
		tally[name] = tally.GetValueOrDefault(name) + 1;
	}
}
