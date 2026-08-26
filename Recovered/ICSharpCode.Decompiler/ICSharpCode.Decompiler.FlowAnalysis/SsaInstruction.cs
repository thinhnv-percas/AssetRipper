using ICSharpCode.Decompiler.Disassembler;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class SsaInstruction
	{
		public readonly SsaBlock ParentBlock;

		public readonly SpecialOpCode SpecialOpCode;

		public readonly Instruction Instruction;

		public readonly Instruction[] Prefixes;

		public readonly TypeReference TypeOperand;

		public SsaVariable Target;

		public SsaVariable[] Operands;

		private static readonly SsaVariable[] emptyVariableArray = new SsaVariable[0];

		private static readonly Instruction[] emptyInstructionArray = new Instruction[0];

		public bool IsMoveInstruction
		{
			get
			{
				if (Target != null && Operands.Length == 1 && Instruction != null)
				{
					return OpCodeInfo.Get(Instruction.OpCode).IsMoveInstruction;
				}
				return false;
			}
		}

		public SsaInstruction(SsaBlock parentBlock, Instruction instruction, SsaVariable target, SsaVariable[] operands, Instruction[] prefixes = null, SpecialOpCode specialOpCode = SpecialOpCode.None, TypeReference typeOperand = null)
		{
			ParentBlock = parentBlock;
			Instruction = instruction;
			Prefixes = (prefixes ?? emptyInstructionArray);
			Target = target;
			Operands = (operands ?? emptyVariableArray);
			SpecialOpCode = specialOpCode;
			TypeOperand = typeOperand;
		}

		public void ReplaceVariableInOperands(SsaVariable oldVar, SsaVariable newVar)
		{
			for (int i = 0; i < Operands.Length; i++)
			{
				if (Operands[i] == oldVar)
				{
					Operands[i] = newVar;
				}
			}
		}

		public override string ToString()
		{
			StringWriter stringWriter = new StringWriter();
			WriteTo(stringWriter);
			return stringWriter.ToString();
		}

		public void WriteTo(TextWriter writer)
		{
			Instruction[] prefixes = Prefixes;
			for (int i = 0; i < prefixes.Length; i++)
			{
				prefixes[i].WriteTo(new PlainTextOutput(writer));
				writer.WriteLine();
			}
			if (Instruction != null && Instruction.Offset >= 0)
			{
				writer.Write(CecilExtensions.OffsetToString(Instruction.Offset));
				writer.Write(": ");
			}
			if (Target != null)
			{
				writer.Write(Target.ToString());
				writer.Write(" = ");
			}
			if (IsMoveInstruction)
			{
				writer.Write(Operands[0].ToString());
				if (Instruction != null)
				{
					writer.Write(" (" + Instruction.OpCode.Name + ")");
				}
				return;
			}
			if (Instruction == null)
			{
				writer.Write(SpecialOpCode.ToString());
			}
			else
			{
				writer.Write(Instruction.OpCode.Name);
				if (Instruction.Operand != null)
				{
					writer.Write(' ');
					DisassemblerHelpers.WriteOperand(new PlainTextOutput(writer), Instruction.Operand);
					writer.Write(' ');
				}
			}
			if (TypeOperand != null)
			{
				writer.Write(' ');
				writer.Write(TypeOperand.ToString());
				writer.Write(' ');
			}
			if (Operands.Length == 0)
			{
				return;
			}
			writer.Write('(');
			for (int j = 0; j < Operands.Length; j++)
			{
				if (j > 0)
				{
					writer.Write(", ");
				}
				writer.Write(Operands[j].ToString());
			}
			writer.Write(')');
		}
	}
}
