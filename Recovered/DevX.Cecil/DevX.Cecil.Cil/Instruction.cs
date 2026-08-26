namespace DevX.Cecil.Cil
{
	public sealed class Instruction : ICodeVisitable
	{
		private int m_offset;

		private OpCode m_opCode;

		private object m_operand;

		private Instruction m_previous;

		private Instruction m_next;

		private SequencePoint m_sequencePoint;

		public int Offset
		{
			get
			{
				return m_offset;
			}
			set
			{
				m_offset = value;
			}
		}

		public OpCode OpCode
		{
			get
			{
				return m_opCode;
			}
			set
			{
				m_opCode = value;
			}
		}

		public object Operand
		{
			get
			{
				return m_operand;
			}
			set
			{
				m_operand = value;
			}
		}

		public Instruction Previous
		{
			get
			{
				return m_previous;
			}
			set
			{
				m_previous = value;
			}
		}

		public Instruction Next
		{
			get
			{
				return m_next;
			}
			set
			{
				m_next = value;
			}
		}

		public SequencePoint SequencePoint
		{
			get
			{
				return m_sequencePoint;
			}
			set
			{
				m_sequencePoint = value;
			}
		}

		internal Instruction(int offset, OpCode opCode, object operand)
			: this(offset, opCode)
		{
			m_operand = operand;
		}

		internal Instruction(int offset, OpCode opCode)
		{
			m_offset = offset;
			m_opCode = opCode;
		}

		internal Instruction(OpCode opCode, object operand)
			: this(0, opCode, operand)
		{
		}

		internal Instruction(OpCode opCode)
			: this(0, opCode)
		{
		}

		public int GetSize()
		{
			int num = m_opCode.Size;
			switch (m_opCode.OperandType)
			{
			case OperandType.InlineSwitch:
				num += (1 + ((Instruction[])m_operand).Length) * 4;
				break;
			case OperandType.InlineI8:
			case OperandType.InlineR:
				num += 8;
				break;
			case OperandType.InlineBrTarget:
			case OperandType.InlineField:
			case OperandType.InlineI:
			case OperandType.InlineMethod:
			case OperandType.InlineString:
			case OperandType.InlineTok:
			case OperandType.InlineType:
			case OperandType.ShortInlineR:
				num += 4;
				break;
			case OperandType.InlineVar:
			case OperandType.InlineParam:
				num += 2;
				break;
			case OperandType.ShortInlineBrTarget:
			case OperandType.ShortInlineI:
			case OperandType.ShortInlineVar:
			case OperandType.ShortInlineParam:
				num++;
				break;
			}
			return num;
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitInstruction(this);
		}
	}
}
