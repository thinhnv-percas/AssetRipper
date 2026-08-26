using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public class ParsedInstruction
	{
		[CompilerGenerated]
		internal Type _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal readonly IList<uint> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A;

		[CompilerGenerated]
		internal readonly Instruction _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly IList<ParsedOperand> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = new List<ParsedOperand>();

		[CompilerGenerated]
		internal string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal object _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020;

		public Type ResultType
		{
			get;
			set;
		}

		public uint ResultId
		{
			get
			{
				for (int i = 0; i < Instruction.Operands.Count; i++)
				{
					if (Instruction.Operands[i].Type is IdResult)
					{
						return Operands[i].GetId();
					}
				}
				return 0u;
			}
		}

		public bool HasResult => ResultId != 0;

		public IList<uint> Words
		{
			get;
		}

		public Instruction Instruction
		{
			get;
		}

		public IList<ParsedOperand> Operands
		{
			get;
		}

		public string Name
		{
			get;
			set;
		}

		public object Value
		{
			get;
			set;
		}

		public ParsedInstruction(int opCode, IList<uint> words)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A = words;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020 = Instructions.OpcodeToInstruction[opCode];
			_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A();
		}

		internal void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A()
		{
			if (Instruction.Operands.Count == 0)
			{
				return;
			}
			int num = 1;
			int num2 = 0;
			List<object> list = new List<object>();
			Operand operand = null;
			while (num < Words.Count)
			{
				Operand operand2 = Instruction.Operands[num2];
				operand2.Type.ReadValue(Words, num, out object value, out int wordsUsed);
				if (operand2.Quantifier == OperandQuantifier.Varying)
				{
					list.Add(value);
					operand = operand2;
				}
				else
				{
					int count = Math.Min(Words.Count - num, wordsUsed);
					ParsedOperand item = new ParsedOperand(Words, num, count, value, operand2);
					Operands.Add(item);
				}
				num += wordsUsed;
				if (operand2.Quantifier != OperandQuantifier.Varying)
				{
					num2++;
				}
			}
			if (operand != null)
			{
				VaryingOperandValue value2 = new VaryingOperandValue(list);
				ParsedOperand item2 = new ParsedOperand(Words, num, Words.Count - num, value2, operand);
				Operands.Add(item2);
			}
		}

		public void ResolveResultType(IDictionary<uint, ParsedInstruction> objects)
		{
			if (Instruction.Operands.Count > 0 && Instruction.Operands[0].Type is IdResultType)
			{
				ResultType = objects[(uint)Operands[0].Value].ResultType;
			}
		}

		public void ResolveReferences(IDictionary<uint, ParsedInstruction> objects)
		{
			foreach (ParsedOperand operand in Operands)
			{
				ObjectReference objectReference;
				if ((objectReference = (operand.Value as ObjectReference)) != null)
				{
					objectReference.Resolve(objects);
				}
			}
		}
	}
}
