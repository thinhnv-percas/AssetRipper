using System;

namespace DevX.Cecil.Cil
{
	public sealed class CilWorker
	{
		private MethodBody m_mbody;

		private InstructionCollection m_instrs;

		internal CilWorker(MethodBody body)
		{
			m_mbody = body;
			m_instrs = m_mbody.Instructions;
		}

		public MethodBody GetBody()
		{
			return m_mbody;
		}

		public Instruction Create(OpCode opcode)
		{
			if (opcode.OperandType != OperandType.InlineNone)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode);
		}

		public Instruction Create(OpCode opcode, TypeReference type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (opcode.OperandType != OperandType.InlineType && opcode.OperandType != OperandType.InlineTok)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, type);
		}

		public Instruction Create(OpCode opcode, CallSite site)
		{
			if (site == null)
			{
				throw new ArgumentNullException("site");
			}
			if (opcode.Code != Code.Calli)
			{
				throw new ArgumentException("code");
			}
			return FinalCreate(opcode, site);
		}

		public Instruction Create(OpCode opcode, MethodReference method)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (opcode.OperandType != OperandType.InlineMethod && opcode.OperandType != OperandType.InlineTok)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, method);
		}

		public Instruction Create(OpCode opcode, FieldReference field)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			if (opcode.OperandType != OperandType.InlineField && opcode.OperandType != OperandType.InlineTok)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, field);
		}

		public Instruction Create(OpCode opcode, string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			if (opcode.OperandType != OperandType.InlineString)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, str);
		}

		public Instruction Create(OpCode opcode, sbyte b)
		{
			if (opcode.OperandType != OperandType.ShortInlineI && opcode != OpCodes.Ldc_I4_S)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, b);
		}

		public Instruction Create(OpCode opcode, byte b)
		{
			if (opcode.OperandType == OperandType.ShortInlineVar)
			{
				return Create(opcode, m_mbody.Variables[b]);
			}
			if (opcode.OperandType == OperandType.ShortInlineParam)
			{
				return Create(opcode, CodeReader.GetParameter(m_mbody, b));
			}
			if (opcode.OperandType != OperandType.ShortInlineI || opcode == OpCodes.Ldc_I4_S)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, b);
		}

		public Instruction Create(OpCode opcode, int i)
		{
			if (opcode.OperandType == OperandType.InlineVar)
			{
				return Create(opcode, m_mbody.Variables[i]);
			}
			if (opcode.OperandType == OperandType.InlineParam)
			{
				return Create(opcode, CodeReader.GetParameter(m_mbody, i));
			}
			if (opcode.OperandType != OperandType.InlineI)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, i);
		}

		public Instruction Create(OpCode opcode, long l)
		{
			if (opcode.OperandType != OperandType.InlineI8)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, l);
		}

		public Instruction Create(OpCode opcode, float f)
		{
			if (opcode.OperandType != OperandType.ShortInlineR)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, f);
		}

		public Instruction Create(OpCode opcode, double d)
		{
			if (opcode.OperandType != OperandType.InlineR)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, d);
		}

		public Instruction Create(OpCode opcode, Instruction label)
		{
			if (label == null)
			{
				throw new ArgumentNullException("label");
			}
			if (opcode.OperandType != 0 && opcode.OperandType != OperandType.ShortInlineBrTarget)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, label);
		}

		public Instruction Create(OpCode opcode, Instruction[] labels)
		{
			if (labels == null)
			{
				throw new ArgumentNullException("labels");
			}
			if (opcode.OperandType != OperandType.InlineSwitch)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, labels);
		}

		public Instruction Create(OpCode opcode, VariableDefinition var)
		{
			if (var == null)
			{
				throw new ArgumentNullException("var");
			}
			if (opcode.OperandType != OperandType.ShortInlineVar && opcode.OperandType != OperandType.InlineVar)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, var);
		}

		public Instruction Create(OpCode opcode, ParameterDefinition param)
		{
			if (param == null)
			{
				throw new ArgumentNullException("param");
			}
			if (opcode.OperandType != OperandType.ShortInlineParam && opcode.OperandType != OperandType.InlineParam)
			{
				throw new ArgumentException("opcode");
			}
			return FinalCreate(opcode, param);
		}

		private static Instruction FinalCreate(OpCode opcode)
		{
			return FinalCreate(opcode, null);
		}

		private static Instruction FinalCreate(OpCode opcode, object operand)
		{
			return new Instruction(opcode, operand);
		}

		public Instruction Emit(OpCode opcode)
		{
			Instruction instruction = Create(opcode);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, TypeReference type)
		{
			Instruction instruction = Create(opcode, type);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, MethodReference meth)
		{
			Instruction instruction = Create(opcode, meth);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, CallSite site)
		{
			Instruction instruction = Create(opcode, site);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, FieldReference field)
		{
			Instruction instruction = Create(opcode, field);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, string str)
		{
			Instruction instruction = Create(opcode, str);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, byte b)
		{
			Instruction instruction = Create(opcode, b);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, sbyte b)
		{
			Instruction instruction = Create(opcode, b);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, int i)
		{
			Instruction instruction = Create(opcode, i);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, long l)
		{
			Instruction instruction = Create(opcode, l);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, float f)
		{
			Instruction instruction = Create(opcode, f);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, double d)
		{
			Instruction instruction = Create(opcode, d);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, Instruction target)
		{
			Instruction instruction = Create(opcode, target);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, Instruction[] targets)
		{
			Instruction instruction = Create(opcode, targets);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, VariableDefinition var)
		{
			Instruction instruction = Create(opcode, var);
			Append(instruction);
			return instruction;
		}

		public Instruction Emit(OpCode opcode, ParameterDefinition param)
		{
			Instruction instruction = Create(opcode, param);
			Append(instruction);
			return instruction;
		}

		public void InsertBefore(Instruction target, Instruction instr)
		{
			int num = m_instrs.IndexOf(target);
			if (num == -1)
			{
				throw new ArgumentOutOfRangeException("Target instruction not in method body");
			}
			m_instrs.Insert(num, instr);
			instr.Previous = target.Previous;
			if (target.Previous != null)
			{
				target.Previous.Next = instr;
			}
			target.Previous = instr;
			instr.Next = target;
		}

		public void InsertAfter(Instruction target, Instruction instr)
		{
			int num = m_instrs.IndexOf(target);
			if (num == -1)
			{
				throw new ArgumentOutOfRangeException("Target instruction not in method body");
			}
			m_instrs.Insert(num + 1, instr);
			instr.Next = target.Next;
			if (target.Next != null)
			{
				target.Next.Previous = instr;
			}
			target.Next = instr;
			instr.Previous = target;
		}

		public void Append(Instruction instr)
		{
			Instruction instruction = null;
			if (m_instrs.Count > 0)
			{
				instruction = m_instrs[m_instrs.Count - 1];
			}
			if (instruction != null)
			{
				instruction.Next = instr;
				instr.Previous = instruction;
			}
			m_instrs.Add(instr);
		}

		public void Replace(Instruction old, Instruction instr)
		{
			int num = m_instrs.IndexOf(old);
			if (num == -1)
			{
				throw new ArgumentOutOfRangeException("Target instruction not in method body");
			}
			InsertAfter(old, instr);
			Remove(old);
		}

		public void Remove(Instruction instr)
		{
			if (!m_instrs.Contains(instr))
			{
				throw new ArgumentException("Instruction not in method body");
			}
			if (instr.Previous != null)
			{
				instr.Previous.Next = instr.Next;
			}
			if (instr.Next != null)
			{
				instr.Next.Previous = instr.Previous;
			}
			m_instrs.Remove(instr);
		}
	}
}
