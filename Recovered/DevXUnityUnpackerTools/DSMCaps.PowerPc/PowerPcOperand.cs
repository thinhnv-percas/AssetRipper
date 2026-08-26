using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.PowerPc
{
	public sealed class PowerPcOperand
	{
		internal readonly PowerPcConditionRegisterOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020;

		internal readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		internal readonly PowerPcMemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		internal readonly PowerPcRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly PowerPcOperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public PowerPcConditionRegisterOperandValue ConditionRegister
		{
			get
			{
				if (Type != PowerPcOperandType.ConditionRegister)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "ConditionRegister", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020;
			}
		}

		public long Immediate
		{
			get
			{
				if (Type != PowerPcOperandType.Immediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public PowerPcMemoryOperandValue Memory
		{
			get
			{
				if (Type != PowerPcOperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public PowerPcRegister Register
		{
			get
			{
				if (Type != PowerPcOperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public PowerPcOperandType Type
		{
			get;
		}

		internal static PowerPcOperand[] Create(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A nativeInstructionDetail)
		{
			PowerPcOperand[] array = new PowerPcOperand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new PowerPcOperand(disassembler, ref nativeOperand);
			}
			return array;
		}

		internal PowerPcOperand(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A nativeOperand)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			switch (Type)
			{
			case PowerPcOperandType.ConditionRegister:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020 = new PowerPcConditionRegisterOperandValue(disassembler, ref nativeOperand.Value.ConditionRegister);
				break;
			case PowerPcOperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case PowerPcOperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new PowerPcMemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
				break;
			case PowerPcOperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = PowerPcRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.Register);
				break;
			}
		}
	}
}
