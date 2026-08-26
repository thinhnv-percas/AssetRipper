namespace DevX.Cecil.Cil
{
	public struct OpCode
	{
		private short m_value;

		private byte m_code;

		private byte m_flowControl;

		private byte m_opCodeType;

		private byte m_operandType;

		private byte m_stackBehaviourPop;

		private byte m_stackBehaviourPush;

		public string Name
		{
			get
			{
				int num = (Size != 1) ? (Op2 + 256) : Op2;
				return OpCodeNames.names[num];
			}
		}

		public int Size => ((m_value & 0xFF00) == 65280) ? 1 : 2;

		public byte Op1 => (byte)(m_value >> 8);

		public byte Op2 => (byte)m_value;

		public short Value => (Size != 1) ? m_value : Op2;

		public Code Code => (Code)m_code;

		public FlowControl FlowControl => (FlowControl)m_flowControl;

		public OpCodeType OpCodeType => (OpCodeType)m_opCodeType;

		public OperandType OperandType => (OperandType)m_operandType;

		public StackBehaviour StackBehaviourPop => (StackBehaviour)m_stackBehaviourPop;

		public StackBehaviour StackBehaviourPush => (StackBehaviour)m_stackBehaviourPush;

		internal OpCode(byte op1, byte op2, Code code, FlowControl flowControl, OpCodeType opCodeType, OperandType operandType, StackBehaviour pop, StackBehaviour push)
		{
			m_value = (short)((op1 << 8) | op2);
			m_code = (byte)code;
			m_flowControl = (byte)flowControl;
			m_opCodeType = (byte)opCodeType;
			m_operandType = (byte)operandType;
			m_stackBehaviourPop = (byte)pop;
			m_stackBehaviourPush = (byte)push;
			if (op1 == byte.MaxValue)
			{
				OpCodes.OneByteOpCode[op2] = this;
			}
			else
			{
				OpCodes.TwoBytesOpCode[op2] = this;
			}
		}

		public override int GetHashCode()
		{
			return m_value;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is OpCode))
			{
				return false;
			}
			OpCode opCode = (OpCode)obj;
			return opCode.m_value == m_value;
		}

		public bool Equals(OpCode opcode)
		{
			return m_value == opcode.m_value;
		}

		public override string ToString()
		{
			return Name;
		}

		public static bool operator ==(OpCode one, OpCode other)
		{
			return one.m_value == other.m_value;
		}

		public static bool operator !=(OpCode one, OpCode other)
		{
			return one.m_value != other.m_value;
		}
	}
}
