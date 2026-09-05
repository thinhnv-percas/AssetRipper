using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Renders a method's ISIL as approximate C#. Intended to be read, not compiled: control flow is
/// expressed with labels and gotos, and unrecognised operations are left as comments.
/// </summary>
/// <param name="annotator">Names memory accesses from the runtime struct layouts, when one is loaded.</param>
/// <param name="appContext">
/// Used to put names to the addresses the lifter left bare. Optional: without it a call reads as
/// <c>0x8D8204()</c>, which is an address and not much else.
/// </param>
public sealed class PseudoCSharpWriter(RuntimeStructAccessAnnotator? annotator, ApplicationAnalysisContext? appContext = null)
{
	/// <summary>Formats <paramref name="method"/>, which must already have been analysed.</summary>
	/// <param name="method">The analysed method.</param>
	/// <param name="maxLines">Stop after this many statements and say so, so one pathological method cannot dominate the output.</param>
	public string Write(MethodAnalysisContext method, int maxLines = 400)
		=> WriteInstructions(method.ConvertedIsil, annotator?.Annotate(method), maxLines);

	/// <summary>
	/// Formats an ISIL instruction list directly, for callers that have one without a method around it.
	/// </summary>
	public string WriteInstructions(List<Instruction>? instructions, Dictionary<int, string>? memoryAccessNames = null, int maxLines = 400)
	{
		if (instructions is null || instructions.Count == 0)
		{
			return "";
		}

		Dictionary<int, string> annotations = memoryAccessNames ?? [];
		HashSet<int> labels = CollectLabels(instructions);

		StringBuilder builder = new();
		builder.Append("// Approximate reconstruction from native code. Reads as C#; does not compile.\n");

		int written = 0;
		int skipped = 0;
		foreach (Instruction instruction in instructions)
		{
			if (written >= maxLines)
			{
				builder.Append($"// ... {instructions.Count - instruction.Index} further instructions omitted\n");
				break;
			}

			bool isLabel = labels.Contains(instruction.Index);

			// Noise is dropped rather than written, both because it buries the statements that matter
			// and because every character competes for the injection budget. A label target is always
			// written, since something jumps to it.
			if (!isLabel && IsNoise(instruction, labels))
			{
				skipped++;
				continue;
			}

			if (isLabel)
			{
				builder.Append($"L_{instruction.Index:X4}:\n");
			}

			builder.Append(Format(instruction, annotations));
			builder.Append('\n');
			written++;
		}

		if (skipped > 0)
		{
			builder.Append($"// {skipped} bookkeeping instructions omitted: flag registers, address bases and no-ops.\n");
		}

		return builder.ToString();
	}

	/// <summary>
	/// Whether an instruction is machine bookkeeping rather than program logic.
	/// </summary>
	/// <remarks>
	/// Three kinds dominate an ARM64 body and none of them tells a reader anything: no-ops the lifter
	/// emits for instructions it modelled away, comparisons whose only consumer is the conditional jump
	/// that follows them, and the page-base half of an <c>adrp</c>/<c>add</c> address pair.
	/// </remarks>
	private static bool IsNoise(Instruction instruction, HashSet<int> labels)
	{
		switch (instruction.OpCode)
		{
			case OpCode.Nop:
			case OpCode.Interrupt:
				return true;

			// A comparison into a flag register, immediately consumed by the branch. The branch prints
			// its own condition, so this line is duplication.
			case OpCode.CheckEqual or OpCode.CheckNotEqual or OpCode.Subtract
				when instruction.Operands.Count >= 1 && IsFlagRegister(instruction.Operands[0]):
				return true;

			// adrp: a register loaded with a page-aligned constant, meaningful only once the low half
			// is added. The add that follows prints the whole address.
			case OpCode.Move when instruction.Operands.Count >= 2
				&& instruction.Operands[0] is Register
				&& instruction.Operands[1] is Immediate page
				&& page.Value != 0
				&& (page.Value & 0xFFF) == 0:
				return true;

			default:
				return false;
		}
	}

	/// <summary>
	/// Whether an operand is one of the condition-code pseudo-registers the lifter uses for flags.
	/// </summary>
	private static bool IsFlagRegister(IOperand operand)
	{
		if (operand is not Register register)
		{
			return false;
		}

		string name = register.Name;

		// Named by the instruction sets as Z, N, C, V and TEMP, sometimes with an SSA suffix.
		int cut = name.IndexOf('_');
		ReadOnlySpan<char> bare = cut < 0 ? name : name.AsSpan(0, cut);

		return bare is "Z" or "N" or "C" or "V" or "TEMP";
	}

	private static HashSet<int> CollectLabels(List<Instruction> instructions)
	{
		// A backward jump can target anything already emitted, so targets must be collected before writing.
		HashSet<int> labels = [];

		foreach (Instruction instruction in instructions)
		{
			if (instruction.OpCode is not (OpCode.Jump or OpCode.ConditionalJump))
			{
				continue;
			}

			if (TryGetBranchTarget(instruction, out int target))
			{
				labels.Add(target);
			}
		}

		return labels;
	}

	private static bool TryGetBranchTarget(Instruction instruction, out int target)
	{
		if (instruction.Operands.Count > 0)
		{
			switch (instruction.Operands[0])
			{
				case Instruction destination:
					target = destination.Index;
					return true;

				// Once the control flow graph is built the lifter rewrites branch operands to the block
				// they enter. Without this case every branch in every method fell through to the default
				// handler and was written as a comment, which is most of why the output read as a dump
				// rather than as code.
				case Block block when block.Instructions.Count > 0:
					target = block.Instructions[0].Index;
					return true;

				case Immediate immediate:
					target = (int)immediate.Value;
					return true;
			}
		}

		target = -1;
		return false;
	}

	/// <summary>
	/// Puts a name to a call whose target the lifter left as a bare address.
	/// </summary>
	/// <remarks>
	/// The lifter resolves the address, uses it, and then keeps only the number, so a call that Cpp2IL
	/// knows perfectly well reads as <c>0x8D8204()</c>. Looking it up again here is free: this is text,
	/// so unlike naming it in the generated IL there is no stack to get wrong.
	/// </remarks>
	private string DescribeAddress(long address)
	{
		if (appContext is null || address <= 0)
		{
			return FormatImmediate(address);
		}

		ulong target = (ulong)address;

		if (appContext.MethodsByAddress.TryGetValue(target, out List<MethodAnalysisContext>? methods)
			&& methods.Count > 0
			&& methods[0].FullName is { Length: > 0 } name)
		{
			// Several methods can share an address once the compiler folds identical bodies; the first
			// is as good a name as any, and the address stays for anyone who needs to be sure.
			string shared = methods.Count > 1 ? $" /* +{methods.Count - 1} sharing this address */" : "";
			return $"{name}{shared}";
		}

		if (appContext.ThrowHelperNamesByAddress.TryGetValue(target, out string? helper)
			&& !string.IsNullOrWhiteSpace(helper))
		{
			return $"{helper} /* throw helper */";
		}

		return FormatImmediate(address);
	}

	private string Format(Instruction instruction, Dictionary<int, string> annotations)
	{
		OperandList operands = instruction.Operands;

		switch (instruction.OpCode)
		{
			case OpCode.Move when operands.Count >= 2:
				return $"\t{Op(operands[0], instruction, annotations)} = {Op(operands[1], instruction, annotations)};";

			case OpCode.Add when operands.Count >= 3:
				return Binary(instruction, annotations, "+");
			case OpCode.Subtract when operands.Count >= 3:
				return Binary(instruction, annotations, "-");
			case OpCode.Multiply when operands.Count >= 3:
				return Binary(instruction, annotations, "*");
			case OpCode.Divide when operands.Count >= 3:
				return Binary(instruction, annotations, "/");
			case OpCode.ShiftLeft when operands.Count >= 3:
				return Binary(instruction, annotations, "<<");
			case OpCode.ShiftRight when operands.Count >= 3:
				return Binary(instruction, annotations, ">>");
			case OpCode.And when operands.Count >= 3:
				return Binary(instruction, annotations, "&");
			case OpCode.Or when operands.Count >= 3:
				return Binary(instruction, annotations, "|");
			case OpCode.Xor when operands.Count >= 3:
				return Binary(instruction, annotations, "^");
			case OpCode.CheckEqual when operands.Count >= 3:
				return Binary(instruction, annotations, "==");
			case OpCode.CheckNotEqual when operands.Count >= 3:
				return Binary(instruction, annotations, "!=");
			case OpCode.CheckGreater when operands.Count >= 3:
				return Binary(instruction, annotations, ">");
			case OpCode.CheckLess when operands.Count >= 3:
				return Binary(instruction, annotations, "<");
			case OpCode.CheckGreaterOrEqual when operands.Count >= 3:
				return Binary(instruction, annotations, ">=");
			case OpCode.CheckLessOrEqual when operands.Count >= 3:
				return Binary(instruction, annotations, "<=");

			case OpCode.Not when operands.Count >= 2:
				return $"\t{Op(operands[0], instruction, annotations)} = ~{Op(operands[1], instruction, annotations)};";
			case OpCode.Negate when operands.Count >= 2:
				return $"\t{Op(operands[0], instruction, annotations)} = -{Op(operands[1], instruction, annotations)};";

			case OpCode.Call when operands.Count >= 2:
				return $"\t{Op(operands[1], instruction, annotations)} = {CallTarget(operands[0], instruction, annotations)}({Args(instruction, annotations, 2)});";
			case OpCode.Call or OpCode.CallVoid or OpCode.IndirectCall when operands.Count >= 1:
				return $"\t{CallTarget(operands[0], instruction, annotations)}({Args(instruction, annotations, 1)});";

			case OpCode.Newobj when operands.Count >= 2:
				return $"\t{Op(operands[0], instruction, annotations)} = new {Op(operands[1], instruction, annotations)}();";

			case OpCode.Return:
				return operands.Count >= 1
					? $"\treturn {Op(operands[0], instruction, annotations)};"
					: "\treturn;";

			case OpCode.Throw when operands.Count >= 1:
				return $"\tthrow {Op(operands[0], instruction, annotations)};";

			case OpCode.Jump when TryGetBranchTarget(instruction, out int jumpTarget):
				return $"\tgoto L_{jumpTarget:X4};";

			case OpCode.ConditionalJump when operands.Count >= 2 && TryGetBranchTarget(instruction, out int branchTarget):
				return $"\tif ({Op(operands[1], instruction, annotations)}) goto L_{branchTarget:X4};";

			case OpCode.Nop:
				return "\t;";

			default:
				// Unhandled operations are shown rather than dropped, so nothing silently disappears.
				return $"\t// {instruction}";
		}
	}

	private string Binary(Instruction instruction, Dictionary<int, string> annotations, string @operator)
	{
		OperandList operands = instruction.Operands;
		return $"\t{Op(operands[0], instruction, annotations)} = {Op(operands[1], instruction, annotations)} {@operator} {Op(operands[2], instruction, annotations)};";
	}

	private string Args(Instruction instruction, Dictionary<int, string> annotations, int skip)
	{
		OperandList operands = instruction.Operands;
		List<string> parts = [];
		for (int i = skip; i < operands.Count; i++)
		{
			parts.Add(Op(operands[i], instruction, annotations));
		}
		return string.Join(", ", parts);
	}

	/// <summary>Formats the target of a call, naming it when the operand is only an address.</summary>
	private string CallTarget(IOperand operand, Instruction instruction, Dictionary<int, string> annotations)
		=> operand is Immediate address
			? DescribeAddress(address.Value)
			: Op(operand, instruction, annotations);

	private string Op(IOperand operand, Instruction instruction, Dictionary<int, string> annotations) => operand switch
	{
		Block block when block.Instructions.Count > 0 => $"L_{block.Instructions[0].Index:X4}",

		MethodAnalysisContext method => method.FullName,
		TypeAnalysisContext type => type.FullName,
		FieldReference field => FieldPath(field),
		StringLiteral literal => Quote(literal.Value),
		LocalVariable local => local.Name,
		Register register => register.Name,
		Immediate immediate => FormatImmediate(immediate.Value),

		// A named access, when the annotator proved one; the raw expression otherwise.
		MemoryOperand memory => annotations.TryGetValue(instruction.Index, out string? named)
			? named
			: $"*({memory})",

		_ => operand.ToString() ?? "?",
	};

	/// <summary>
	/// The dotted path of a field access. Taken from the operand's own rendering rather than from the
	/// field name, because a field reached through a value type field is one name of several and only
	/// the whole path names it.
	/// </summary>
	private static string FieldPath(FieldReference field)
	{
		string rendered = field.ToString();
		int declaredType = rendered.LastIndexOf(" (", StringComparison.Ordinal);
		return declaredType < 0 ? rendered : rendered[..declaredType];
	}

	private static string FormatImmediate(long value)
		=> value is > -10 and < 10 ? value.ToString() : $"0x{value:X}";

	private static string Quote(string value)
	{
		StringBuilder builder = new(value.Length + 2);
		builder.Append('"');
		foreach (char c in value)
		{
			switch (c)
			{
				case '"': builder.Append("\\\""); break;
				case '\\': builder.Append(@"\\"); break;
				case '\n': builder.Append("\\n"); break;
				case '\r': builder.Append("\\r"); break;
				case '\t': builder.Append("\\t"); break;
				default: builder.Append(c); break;
			}
		}
		builder.Append('"');
		return builder.ToString();
	}
}
