using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Renders a method's ISIL as approximate C#. Intended to be read, not compiled: control flow is
/// expressed with labels and gotos, and unrecognised operations are left as comments.
/// </summary>
public sealed class PseudoCSharpWriter(RuntimeStructAccessAnnotator? annotator)
{
	/// <summary>Formats <paramref name="method"/>, which must already have been analysed.</summary>
	/// <param name="method">The analysed method.</param>
	/// <param name="maxLines">Stop after this many statements and say so, so one pathological method cannot dominate the output.</param>
	public string Write(MethodAnalysisContext method, int maxLines = 400)
	{
		List<Instruction>? instructions = method.ConvertedIsil;
		if (instructions is null || instructions.Count == 0)
		{
			return "";
		}

		Dictionary<int, string> annotations = annotator?.Annotate(method) ?? [];
		HashSet<int> labels = CollectLabels(instructions);

		StringBuilder builder = new();
		builder.Append("// Approximate reconstruction from native code. Reads as C#; does not compile.\n");

		int written = 0;
		foreach (Instruction instruction in instructions)
		{
			if (written >= maxLines)
			{
				builder.Append($"// ... {instructions.Count - instruction.Index} further instructions omitted\n");
				break;
			}

			if (labels.Contains(instruction.Index))
			{
				builder.Append($"L_{instruction.Index:X4}:\n");
			}

			builder.Append(Format(instruction, annotations));
			builder.Append('\n');
			written++;
		}

		return builder.ToString();
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
				case Immediate immediate:
					target = (int)immediate.Value;
					return true;
			}
		}

		target = -1;
		return false;
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
				return $"\t{Op(operands[1], instruction, annotations)} = {Op(operands[0], instruction, annotations)}({Args(instruction, annotations, 2)});";
			case OpCode.Call or OpCode.CallVoid or OpCode.IndirectCall when operands.Count >= 1:
				return $"\t{Op(operands[0], instruction, annotations)}({Args(instruction, annotations, 1)});";

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

	private string Op(IOperand operand, Instruction instruction, Dictionary<int, string> annotations) => operand switch
	{
		MethodAnalysisContext method => method.FullName,
		TypeAnalysisContext type => type.FullName,
		FieldReference field => $"{field.Local.Name}.{field.Field.Name}",
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
